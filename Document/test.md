# Unity 프로젝트 폴더 구조 정리

> 본 문서는 현재 Unity 프로젝트의 폴더/에셋 구성을 GitHub에서 보기 좋게 정리한 문서입니다.  
> 제공된 파일 트리를 기반으로 작성되었으며, **`Assets/`는 외부 에셋 비중이 크고**, 사용자 작성 스크립트는 `Assets/Script/`에 집중되어 있습니다.  
> 입력은 `InputSystem_Actions.inputactions`(Unity New Input System)로 구성되어 있습니다.

---

## 전체 구조 개요

ProjectRoot/
├── Assets/            # 게임 리소스/외부 에셋/사용자 스크립트
├── Packages/          # 패키지 매니저(manifest.json)
└── ProjectSettings/   # 프로젝트 설정(품질/입력/그래픽/빌드 등)


==============================================================================================


```text
📦 ProjectRoot/
├── .gitattributes
├── Assets/
│   ├── Free Burrow Cute Series/                 # 외부 캐릭터 에셋(버로우)
│   ├── Jammo-Character/                         # 외부 캐릭터 에셋(잠모)
│   ├── Mnostva_Art/Flying_Sci_Fi_Island_city/   # 외부 환경 에셋(공중 SF 섬/도시)
│   ├── Polygonal Mind/Assets/2108_ABMAssetPack/ # 외부 에셋팩(대규모)
│   ├── Stylized_Astronaut/                      # 외부 캐릭터 에셋(우주비행사)
│   ├── TextMesh Pro/                            # TextMesh Pro 리소스(+ 예제 포함)
│   ├── Scenes/                                  # 사용자 씬(테스트)
│   ├── Script/                                  # 사용자 작성 스크립트
│   └── InputSystem_Actions.inputactions         # 입력 액션맵(New Input System)
├── Packages/
│   ├── manifest.json
│   └── packages-lock.json
└── ProjectSettings/
    └── (Audio/Graphics/Input/Build 등 Unity 설정 파일)


==============================================================================================


## 폴더별 상세 설명

> 아래는 `Assets/` 중심으로 “무엇이 들어있는지 / 어떤 용도인지”를 폴더 단위로 정리한 섹션입니다.  
> (외부 에셋은 **원 제작사/팩 단위**, 사용자 로직은 **Script/Scenes/Input** 위주로 구분)

---

### `Assets/Free Burrow Cute Series/` (외부 에셋: Burrow 캐릭터)

- **역할**: 캐릭터 모델/애니메이션/프리팹 + 데모 씬 제공
- **주요 구성**
  - `Cute series demo assets/`: 카메라 프리셋(`Cute Ortho`, `Cute Perspective`), 바닥(Ground) 프리팹/머티리얼, 회전 애니메이션 컨트롤러 등 데모용 리소스
  - `FBX/`: 캐릭터 FBX 및 애니메이션 클립(예: `Burrow@Walk...`)
  - `Materials/`: 캐릭터 머티리얼(`Free Burrow.mat`)
  - `Prefabs/`: 캐릭터 프리팹(`Free Burrow.prefab`)
  - `Scenes/`: 데모 씬(`Demo.unity`)
  - `Read Me/`: 안내 PDF 문서
  - `Textures/`: 텍스처 원본(PSD 포함)

---

### `Assets/Jammo-Character/` (외부 에셋: Jammo 캐릭터)

- **역할**: 플레이어용 캐릭터(모델/애니메이션/프리팹) + 샘플 씬 + 일부 컨트롤 스크립트 포함
- **주요 구성**
  - `Models/`: 캐릭터 모델(`Jammo_LowPoly.fbx`)
  - `Animations/`: 애니메이션 클립, `AnimatorController_Jamo.controller`
  - `Prefabs/`: 플레이어 프리팹(`Jammo_Player.prefab`)
  - `Scenes/`: `JammoScene.unity` 및 라이트맵/리플렉션 프로브 등 씬 데이터
  - `Scripts/`: 에셋 제공 스크립트(예: `MovementInput.cs`, `CharacterSkinController.cs`)
  - `Textures/`: 기본 텍스처 + `Alternates/`(변형 PSD 등)

> 참고: 라이트맵(`Lightmap-*.exr/png`)과 `LightingData.asset` 등 **용량 큰 바이너리**가 포함될 수 있습니다.

---

### `Assets/Mnostva_Art/Flying_Sci_Fi_Island_city/` (외부 에셋: 환경/도시)

- **역할**: 공중 섬/도시 환경 구성(메쉬·프리팹·머티리얼·텍스처) + 데모/샘플 씬
- **주요 구성**
  - `Meshes/`
    - `interiors/`: 내부 공간용 메쉬 FBX
    - `island/`: 섬/건물/나무 등 환경 메쉬 FBX
  - `Prefabs/`: 메쉬에 대응하는 프리팹(예: `House_*`, `Tree_*`, `Island`, `Sci_Fi_Island`)
  - `Materials/`: 유리/지형 등 머티리얼(`Glass_Material.mat`, `Island_Mat.mat`)
  - `Textures/`: 해상도별 텍스처(`Texture_128~2048.png`)
  - `Scenes/`: `Demo.unity`, `SampleScene.unity`
  - `info_flying_sci_fi_island_city.txt`: 에셋 안내 텍스트

---

### `Assets/Polygonal Mind/Assets/2108_ABMAssetPack/` (외부 에셋: 대규모 팩)

- **역할**: 모델/머티리얼/텍스처/프리팹이 대량 포함된 환경/소품 팩 + 에디터 툴 + 샘플 씬
- **주요 구성**
  - `Models/`: FBX 모델 다량
  - `Materials/`: 머티리얼 다량(플랫폼, 패널, 홀로그래픽 등)
  - `Textures/Textures/`: 텍스처 리소스(tif/png 등) 대량
  - `Prefabs/`: 모델/머티리얼이 조합된 프리팹 다량
  - `Tools/Editor/PolygonalMind_Overlay.cs`: 에디터 오버레이/도구 스크립트
  - `ABMAssets.unity`: 샘플/데모 씬

---

### `Assets/Stylized_Astronaut/` (외부 에셋: 캐릭터 + 3인칭 컨트롤)

- **역할**: 우주비행사 캐릭터(모델/애니메이션/프리팹) + 3인칭 컨트롤러/카메라 스크립트 + 데모 씬
- **주요 구성**
  - `Character/`
    - `Astronaut.fbx`: 캐릭터 모델
    - `AstronautCharacterController.controller`: 애니메이터 컨트롤러
    - `AstronautPlayer.cs`: 플레이어 컨트롤(에셋 제공)
    - `AstronautThirdPersonCamera.cs`: 3인칭 카메라(에셋 제공)
    - `Character Documentation.pdf`: 문서
  - `Demo/`: 데모 씬(`DemoScene.unity`) 및 관련 리소스
  - `Stylized Astronaut.prefab`: 캐릭터 프리팹

---

### `Assets/TextMesh Pro/` (Unity 기본/표준 텍스트 시스템)

- **역할**: TextMesh Pro 기본 리소스 및 샘플(프로젝트 UI/텍스트 렌더링 기반)
- **주요 구성**
  - `Resources/`: 폰트/머티리얼/기본 설정 리소스
  - `Examples & Extras/`: 예제 씬/스크립트/리소스(학습/참고용)

> 참고: 배포/레포 정리 정책에 따라 `Examples & Extras/`는 제외 또는 분리 대상이 될 수 있습니다.

---

### `Assets/Scenes/` (사용자 씬)

- **역할**: 프로젝트에서 직접 사용하는 씬(테스트/프로토타입 포함)
- **주요 구성**
  - `charactersTest.unity`: 캐릭터/입력/상호작용 테스트 씬으로 추정

---

### `Assets/Script/` (사용자 작성 C# 스크립트)

- **역할**: 본 프로젝트의 “커스텀 로직” 핵심 영역(캡스톤 AI/상호작용 로직의 출발점)
- **주요 파일**
  - `MainScript.cs`: 메인 흐름/테스트 로직(프로젝트 중심 스크립트)
  - `npc_trigger.cs`: NPC 트리거/상호작용 감지 로직
  - `stairs.cs`: 계단/경사 처리 또는 트리거 기반 이동 보정 로직

---

### `Assets/InputSystem_Actions.inputactions` (New Input System)

- **역할**: Unity **New Input System**의 액션맵 정의 파일(이동/점프/상호작용 등 입력을 “데이터”로 관리)
- **연동 가능 지점**
  - 캐릭터 컨트롤 스크립트(예: `MovementInput.cs`) 또는 사용자 스크립트(`MainScript.cs`)에서 액션을 참조해 입력 이벤트 처리

---

## 프로젝트 설정/패키지(참고)

### `Packages/`
- `manifest.json`, `packages-lock.json`을 통해 프로젝트 의존 패키지 고정/관리

### `ProjectSettings/`
- Unity 에디터/플랫폼/입력/그래픽/오디오 등 설정 파일 집합
- 확인된 항목(예시)
  - `com.unity.dedicated-server/MultiplayerRolesSettings.asset` (Dedicated Server 역할 설정)
  - `com.unity.testtools.codecoverage/Settings.json` (코드 커버리지 설정)