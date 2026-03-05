# Unity 프로젝트 구조 문서

## 📌 프로젝트 개요

본 문서는 현재 Unity 프로젝트의 폴더 및 에셋 구조를 설명하기 위한 문서입니다.

이 프로젝트는 다음과 같은 요소들로 구성되어 있습니다.

* 여러 개의 **외부 에셋 팩**
* 사용자 정의 **게임 로직 스크립트**
* Unity **New Input System**
* 테스트 및 프로토타입용 **씬(Scene)**

대부분의 외부 리소스는 `Assets/` 폴더에 포함되어 있으며,
사용자가 작성한 스크립트는 주로 다음 경로에 위치합니다.

```
Assets/Script/
```

---

# 📦 프로젝트 구조

```
ProjectRoot/
│
├── Assets/            # 게임 리소스, 외부 에셋, 사용자 스크립트
├── Packages/          # Unity Package Manager 의존성
└── ProjectSettings/   # Unity 프로젝트 설정
```

---

# 📂 전체 파일 트리

```
📦 ProjectRoot/
├── .gitattributes
│
├── Assets/
│   ├── Free Burrow Cute Series/
│   ├── Jammo-Character/
│   ├── Mnostva_Art/
│   │   └── Flying_Sci_Fi_Island_city/
│   ├── Polygonal Mind/
│   │   └── Assets/2108_ABMAssetPack/
│   ├── Stylized_Astronaut/
│   ├── TextMesh Pro/
│   │
│   ├── Scenes/
│   │   └── charactersTest.unity
│   │
│   ├── Script/
│   │   ├── MainScript.cs
│   │   ├── npc_trigger.cs
│   │   └── stairs.cs
│   │
│   └── InputSystem_Actions.inputactions
│
├── Packages/
│   ├── manifest.json
│   └── packages-lock.json
│
└── ProjectSettings/
```

---

# 🧩 외부 에셋 (External Assets)

본 프로젝트에는 여러 개의 외부 에셋 팩이 포함되어 있습니다.

---

## 1️⃣ Free Burrow Cute Series

**유형:** 캐릭터 에셋

포함 요소

* 캐릭터 FBX 모델
* 애니메이션 클립
* 프리팹(Prefab)
* 머티리얼(Material)
* 데모 씬
* 텍스처 원본 파일(PSD)

구조

```
Free Burrow Cute Series/
├── FBX/
├── Materials/
├── Prefabs/
├── Scenes/
├── Textures/
```

---

## 2️⃣ Jammo Character

**유형:** 플레이어 캐릭터 에셋

포함 요소

* 캐릭터 모델
* 애니메이션 컨트롤러
* 플레이어 프리팹
* 예제 스크립트
* 데모 씬

구조

```
Jammo-Character/
├── Models/
├── Animations/
├── Prefabs/
├── Scenes/
├── Scripts/
└── Textures/
```

참고

다음과 같은 **용량이 큰 바이너리 파일**이 포함될 수 있습니다.

* `Lightmap-*.exr`
* `LightingData.asset`

---

## 3️⃣ Flying Sci-Fi Island City

**유형:** 환경(Environment) 에셋

스타일화된 **공중 섬 도시 환경**을 제공하는 에셋입니다.

구성

```
Flying_Sci_Fi_Island_city/
├── Meshes/
│   ├── interiors/
│   └── island/
├── Prefabs/
├── Materials/
├── Textures/
└── Scenes/
```

사용 목적

* 환경 구성
* 도시 / 섬 씬 제작
* 레벨 디자인 프로토타입

---

## 4️⃣ Polygonal Mind Asset Pack

**유형:** 대규모 환경 / 소품 에셋 팩

다양한 3D 리소스를 포함하고 있습니다.

포함 요소

* 3D 모델
* 머티리얼
* 프리팹
* 텍스처
* 에디터 툴

구조

```
2108_ABMAssetPack/
├── Models/
├── Materials/
├── Prefabs/
├── Textures/
├── Tools/
│   └── Editor/
└── ABMAssets.unity
```

---

## 5️⃣ Stylized Astronaut

**유형:** 캐릭터 + 3인칭 컨트롤러

포함 요소

* 우주비행사 캐릭터 모델
* 애니메이터 컨트롤러
* 3인칭 플레이어 스크립트
* 3인칭 카메라 스크립트
* 데모 씬

구조

```
Stylized_Astronaut/
├── Character/
│   ├── Astronaut.fbx
│   ├── AstronautPlayer.cs
│   ├── AstronautThirdPersonCamera.cs
│   └── Animator Controller
│
├── Demo/
└── Stylized Astronaut.prefab
```

---

# 💻 사용자 작성 코드

프로젝트의 사용자 정의 게임 로직은 다음 폴더에 저장되어 있습니다.

```
Assets/Script/
```

주요 파일

| 스크립트             | 설명                  |
| ---------------- | ------------------- |
| `MainScript.cs`  | 프로젝트 메인 흐름 및 테스트 로직 |
| `npc_trigger.cs` | NPC 상호작용 트리거 감지 로직  |
| `stairs.cs`      | 계단 / 경사 이동 보정 처리    |

이 폴더는 프로젝트의 **핵심 커스텀 로직이 구현되는 영역**입니다.

---

# 🎮 입력 시스템 (Input System)

본 프로젝트는 **Unity New Input System**을 사용합니다.

입력 액션은 다음 파일에서 정의됩니다.

```
Assets/InputSystem_Actions.inputactions
```

사용 예

* 캐릭터 이동
* 점프
* 상호작용
* UI 입력

다음과 같은 스크립트에서 참조될 수 있습니다.

* `MovementInput.cs`
* `MainScript.cs`

---

# 📦 Unity 패키지

Unity 의존성 패키지는 다음 폴더에서 관리됩니다.

```
Packages/
```

포함 파일

```
manifest.json
packages-lock.json
```

이 파일들은 프로젝트에서 사용하는 **Unity 패키지 버전을 관리**합니다.

---

# ⚙️ 프로젝트 설정

Unity 프로젝트 설정은 다음 폴더에 저장됩니다.

```
ProjectSettings/
```

설정 예시

* Graphics
* Audio
* Input
* Quality
* Build Settings

확인된 설정 파일

```
com.unity.dedicated-server/MultiplayerRolesSettings.asset
com.unity.testtools.codecoverage/Settings.json
```

---

# 📌 참고 사항

* 본 레포지토리의 대부분의 에셋은 **프로토타입 제작을 위한 외부 에셋**입니다.
* 사용자 로직은 주로 **Script 폴더**에 구현되어 있습니다.
* 일부 씬에는 **라이트맵 또는 라이팅 데이터**와 같은 용량이 큰 파일이 포함될 수 있습니다.

---
