---
title: 설치
type: docs
weight: 70
url: /ko/nodejs-net/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "npm에서 Windows 또는 Linux용 Aspose.Slides for Node.js via .NET를 설치합니다: 전제 조건, edge-js 오버라이드, 한 번만 수행되는 NuGet 복원, 그리고 프레젠테이션을 생성하는 첫 번째 프로그램."
---
## **개요**

Aspose.Slides for Node.js via .NET는 npm 패키지 `aspose.slides.via.net`입니다. 이 패키지는 [edge-js](https://github.com/agracio/edge-js) 브리지를 통해 Node.js 내부에서 Aspose.Slides .NET 라이브러리를 실행하므로, 정상적인 설치를 위해서는 Node.js와 .NET가 모두 필요합니다.

이 문서에서는 초기 환경에서 프레젠테이션을 만드는 첫 번째 프로그램까지 안내합니다. 네 단계가 있습니다: edge-js 오버라이드를 사용해 프로젝트를 만들고, npm에서 패키지를 설치하고, 패키지의 .NET 종속성을 한 번 복원한 후, 프로젝트 폴더에서 스크립트를 실행합니다.

## **전제 조건**

- **Node.js 22 또는 24 LTS**, x64 빌드, [nodejs.org](https://nodejs.org/en/download)에서 다운로드.
- **.NET SDK 8 이상**, [dotnet.microsoft.com](https://dotnet.microsoft.com/download)에서 다운로드. .NET 런타임만으로는 충분하지 않습니다. 아래 복원 단계와 스크립트 실행 시 브리지 모두 SDK가 필요합니다. 설치된 SDK를 확인하려면 `dotnet --list-sdks`를 실행하십시오.
- **Linux 전용**:
  - npm이 Linux에서 설치 중 edge-js를 컴파일하므로 `python3`, `make`, `g++` 빌드 도구가 필요합니다.
  - Aspose.Slides 네이티브 드로잉 라이브러리가 로드하는 fontconfig 라이브러리.
  - Debian의 경우 이 패키지는 `python3`, `make`, `g++`, `libfontconfig1`입니다.

이 문서의 단계는 다음 플랫폼에서 테스트되었습니다:

| 플랫폼 | 결과 |
|---|---|
| Windows x64 with Node.js 22 or 24 | 동작합니다. Microsoft Visual C++ 재배포 가능 패키지가 설치된 상태에서 테스트되었습니다. |
| Linux x64 with Node.js 22 or 24, where the system OpenSSL is from the same release line as the OpenSSL built into Node.js, such as Debian 13 | 동작합니다. |
| Linux where the two OpenSSL versions differ, such as Debian 12 | 프레젠테이션을 생성할 때 Node.js가 세그멘테이션 오류로 충돌합니다. |
| macOS | 검증되지 않음. |

Linux에서는 시작하기 전에 두 버전을 비교하십시오. 첫 번째 명령은 Node.js에 내장된 OpenSSL 버전을 출력하고, 두 번째는 시스템 버전을 출력합니다. 두 버전이 동일한 주요 및 부 버전(예: `3.5`)으로 시작하는 시스템을 사용하십시오:

```sh
node -p process.versions.openssl
openssl version
```

`openssl` 명령을 찾을 수 없으면 먼저 `openssl` 패키지를 설치하십시오.

## **프로젝트 만들기**

프로젝트용 폴더를 만들고 초기화한 뒤, npm이 설치할 edge-js 릴리즈를 지정하는 오버라이드를 추가합니다:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

패키지는 Windows 바이너리가 Node.js 20까지 지원되는 오래된 edge-js 릴리즈를 요구합니다. 따라서 오버라이드가 없으면 Windows에서 첫 번째 스크립트가 "The edge module has not been pre-compiled for node.js version" 오류와 함께 중단됩니다. 이 명령은 `package.json`의 `overrides` 섹션에 오버라이드를 기록합니다; 패키지를 설치하기 전에 추가하십시오.

## **패키지 설치**

npm에서 Aspose.Slides for Node.js via .NET를 설치하십시오:

```sh
npm install aspose.slides.via.net
```

설치 중에 패키지는 네이티브 드로잉 라이브러리(파일 이름에 `aspose.slides.drawing.capi`가 포함된 파일)를 `package.json` 옆의 프로젝트 폴더에 복사합니다.

패키지는 [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/)에서도 ZIP 아카이브로 제공됩니다. 이 문서는 npm을 통한 설치만 다룹니다.

## **.NET 종속성 복원**

패키지에는 Aspose.Slides .NET 어셈블리가 포함되어 있지만, 해당 어셈블리가 의존하는 20개의 NuGet 패키지는 포함되어 있지 않습니다. 실행 시 .NET은 NuGet 패키지 캐시에서 이를 찾습니다: Windows에서는 `%USERPROFILE%\.nuget\packages`, Linux에서는 `~/.nuget/packages`, 혹은 `NUGET_PACKAGES` 환경 변수에 설정된 폴더. 캐시가 비어 있으면 첫 번째 스크립트가 "assembly specified in the dependencies manifest was not found" 오류와 함께 중단됩니다.

캐시를 채우려면 프로젝트 폴더에 `deps` 라는 폴더를 만들고, 그 안에 `deps.csproj`라는 파일을 다음 내용으로 저장하십시오. 각 `PackageDownload` 항목은 괄호 안 정확한 버전의 패키지를 하나씩 다운로드합니다; 빌드는 수행되지 않습니다.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

그런 다음 프로젝트 폴더에서 복원하십시오:

```sh
dotnet restore deps/deps.csproj
```

이 단계는 머신당 한 번만 수행하면 됩니다; 패키지는 NuGet 캐시에 남으며 동일 머신의 다른 프로젝트에서도 사용됩니다. 복원 후 `deps` 폴더를 삭제해도 됩니다.

## **첫 프로그램 실행**

프로젝트 폴더에 `hello.js` 파일을 생성하고 아래 코드를 넣으십시오. 이 코드는 프레젠테이션을 생성하고, 첫 번째 슬라이드에 텍스트 "Hello, World!"가 들어간 사각형을 추가한 뒤, 결과를 `hello.pptx`로 저장합니다:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 새 프레젠테이션에는 빈 슬라이드가 하나 포함됩니다.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 위치와 크기는 포인트(1/72 인치) 단위이며: x, y, 너비, 높이.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 프레젠테이션을 지원하는 .NET 객체를 해제합니다.
    presentation.dispose();
}
```

프로젝트 폴더에서 실행하십시오:

```sh
node hello.js
```

스크립트는 `Saved hello.pptx`를 출력합니다. `hello.pptx`를 열어 텍스트가 들어간 채워진 사각형이 포함된 슬라이드 한 장을 확인하십시오. 라이선스가 없으면 Aspose.Slides는 평가 워터마크도 추가합니다; 자세한 내용은 [Evaluate Aspose.Slides](/slides/ko/nodejs-net/evaluate-aspose-slides/) 및 [Licensing](/slides/ko/nodejs-net/licensing/)를 참조하십시오.

{{% alert color="info" title="Note" %}}
스크립트를 실행할 때는 `package.json`이 포함된 프로젝트 폴더에서 실행하십시오. `hello.pptx`와 같은 상대 경로는 현재 폴더를 기준으로 해석되며, 일부 머신에서는 다른 폴더에서 시작된 스크립트가 프레젠테이션을 만들 수 없습니다.
{{% /alert %}}

JavaScript API는 Aspose.Slides for .NET을 그대로 반영합니다: 클래스는 .NET 이름을 유지하고, 속성과 메서드는 camelCase(`Slides`는 `slides`, `AddAutoShape`는 `addAutoShape`)를 사용하며, 컬렉션 항목은 `get(index)`로 읽습니다. 이 패키지에 별도의 API 레퍼런스는 없으며, 클래스 및 멤버 상세는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/)를 활용하십시오. 예: [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 및 [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**"The edge module has not been pre-compiled for node.js version"은 무슨 의미인가요?**

npm이 패키지가 요구하는 오래된 edge-js 릴리즈를 설치했습니다. [Create a Project](#create-a-project) 섹션의 오버라이드를 추가하고 `npm install`을 다시 실행하십시오.

**"assembly specified in the dependencies manifest was not found"은 무슨 의미인가요?**

.NET 종속성이 NuGet 캐시에 없습니다. 동일 실행은 또한 "edge.initializeClrFunc is not a function" 오류를 보고합니다. [Restore the .NET Dependencies](#restore-the-net-dependencies) 섹션을 한 번 수행한 뒤 스크립트를 다시 실행하십시오.

**Linux에서 "The edge native module is not available"은 무슨 의미인가요?**

`npm install` 중 edge-js가 컴파일되지 않았기 때문일 수 있습니다(예: `python3`, `make`, `g++`가 없었음). npm은 이를 오류로 보고하지 않습니다. 빌드 도구를 설치한 뒤 프로젝트 폴더에서 `npm rebuild edge-js`를 실행하십시오.

**빈 "Error"와 함께 프레젠테이션 생성이 실패하는 이유는 무엇인가요?**

Linux에서는 `libfontconfig1`(Debian)과 같은 fontconfig 라이브러리가 설치되어 있는지 확인하십시오; 없으면 네이티브 드로잉 라이브러리를 로드할 수 없습니다. 모든 시스템에서 스크립트를 프로젝트 폴더에서 실행하는지도 확인하십시오.

**Linux에서 Node.js가 세그멘테이션 오류로 충돌하는 이유는 무엇인가요?**

시스템 OpenSSL과 Node.js에 내장된 OpenSSL이 서로 다른 릴리즈 라인에 속합니다. [Prerequisites](#prerequisites)에서 보여준 대로 버전을 비교하고, 두 버전이 일치하는 배포판이나 Node.js 빌드를 사용하십시오.

**모든 프로젝트마다 NuGet 복원을 반복해야 하나요?**

아니요. 복원은 사용자 계정의 NuGet 캐시를 채우며, 해당 머신의 모든 프로젝트가 동일한 캐시를 사용합니다.