---
title: Docker에서 Aspose.Slides for .NET 실행
linktitle: Docker
type: docs
weight: 140
url: /ko/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 컨테이너
- 다단계 빌드
- 컨테이너 이미지
- 리눅스
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- 폰트
- PDF 변환
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Docker에서 Aspose.Slides for .NET 콘솔 애플리케이션을 빌드하고 실행합니다: 공식 .NET 이미지 위에 다단계 Dockerfile, 필요한 Linux 라이브러리와 폰트, 그리고 생성된 파일을 머신으로 복사하는 방법."
---
## **개요**

이 문서에서는 Docker 컨테이너에서 Aspose.Slides for .NET을 실행하는 방법을 보여줍니다. 텍스트 상자가 포함된 프레젠테이션을 만들고 PDF로 변환하는 작은 콘솔 애플리케이션을 만든 뒤, Microsoft 공식 .NET 이미지 위에 다단계 Dockerfile로 패키징하고 실행하여 생성된 파일을 로컬 머신으로 복사합니다. 또한 컨테이너에서 Aspose.Slides가 필요로 하는 Linux 라이브러리와 폰트 목록을 제공하고, Alpine Linux용 변형으로 마무리합니다.

머신에 Docker만 있으면 됩니다. .NET SDK는 빌드 이미지에 포함되어 있으므로 별도로 설치할 필요가 없습니다. Docker 설치 방법은 [Get Docker](https://docs.docker.com/get-started/get-docker/)를 참고하세요.

## **패키지 및 기본 이미지 선택**

기본 .NET 10 컨테이너 이미지들은 Ubuntu 24.04 기반입니다. 이러한 이미지에서는 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 패키지를 사용합니다. 이 패키지는 `fontconfig` 라이브러리를 필요로 하며, .NET 런타임 이미지에는 해당 라이브러리와 폰트가 포함되어 있지 않으므로 이 문서의 Dockerfile에서 두 가지를 모두 설치합니다.

Aspose.Slides.NET6.CrossPlatform은 Alpine Linux에서는 실행되지 않습니다. Alpine 기반 이미지의 경우 [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 패키지를 `libgdiplus`와 함께 사용하십시오. 자세한 내용은 [Run on Alpine Linux](#run-on-alpine-linux) 를 확인하세요. 두 패키지의 차이는 [Installation](/slides/ko/net/installation/) 에서 비교합니다.

## **프로젝트 생성**

*HelloSlidesDocker* 라는 폴더를 만들고 아래 세 파일을 추가합니다.

*HelloSlidesDocker.csproj* 파일은 .NET 10 콘솔 애플리케이션, 아래에서 사용할 컨테이너 이미지 버전, 그리고 **Aspose.Slides.NET6.CrossPlatform**에 대한 참조를 정의합니다. 패키지 버전은 [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)에 나와 있는 최신 버전으로 지정합니다.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* 파일은 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)을 생성하고 첫 번째 슬라이드에 텍스트가 포함된 사각형을 추가한 뒤, [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드로 PPTX와 PDF 두 형식으로 저장합니다. 두 파일 모두 작업 디렉터리 아래 *output* 폴더에 저장됩니다. 이후 애플리케이션은 PDF가 렌더링되는 동안 교체된 폰트를 `[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/)` 로 열거해 컨테이너에 프레젠테이션이 사용하는 폰트가 존재하는지 확인할 수 있게 합니다.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* 파일은 로컬 빌드 시 생성되는 *bin* 및 *obj* 폴더와 이전 실행 결과물을 Docker 빌드 컨텍스트에서 제외시켜, 이미지가 소스 파일만으로 구성되도록 합니다.

```text
bin/
obj/
output/
```

## **Dockerfile 작성**

같은 폴더에 *Dockerfile* 파일을 추가합니다:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

파일은 두 단계로 구성됩니다.

- **빌드 단계**는 .NET SDK 이미지에서 시작합니다. 프로젝트 파일을 먼저 복사하고 NuGet 패키지를 복원하므로, 프로젝트 파일이 변경되지 않는 한 Docker가 이 레이어를 재사용합니다. 이후 소스 코드를 복사하고 애플리케이션을 */app* 에 게시합니다.
- **런타임 단계**는 SDK가 포함되지 않은 더 작은 .NET 런타임 이미지에서 시작하고, 게시된 애플리케이션만 복사합니다. 여기서는 두 패키지를 설치합니다:
  - `libfontconfig1` : Aspose.Slides.NET6.CrossPlatform이 시작할 때 이 라이브러리를 로드합니다. 없으면 `DllNotFoundException` 이 발생하고 `libfontconfig.so.1` 이라는 파일을 찾을 수 없다고 표시됩니다.
  - `fonts-dejavu-core` : 런타임 이미지에는 폰트가 전혀 없으며, Aspose.Slides가 텍스트를 그리려면 최소 하나의 폰트가 설치돼 있어야 합니다. 폰트가 없으면 `InvalidOperationException: Cannot find any fonts installed on the system.` 이 발생합니다. 설치되지 않은 폰트는 대체 폰트로 그려지며, DejaVu 폰트는 텍스트가 표시될 수 있도록 하는 최소 세트입니다. 프레젠테이션을 원본 디자인 폰트로 렌더링하려면 [Deploy Fonts](/slides/ko/net/deploy-fonts/) 를 참고하세요.

  `--no-install-recommends` 옵션과 패키지 목록을 삭제하는 과정을 통해 이미지 크기를 최소화합니다. 마지막 명령은 *output* 폴더를 생성하고, 공식 .NET 이미지가 정의한 비루트 `app` 사용자(`APP_UID` 변수에 사용자 ID가 들어 있음)에게 소유권을 부여한 뒤, 해당 사용자로 애플리케이션을 실행합니다.

ASP.NET Core 애플리케이션의 경우, 런타임 단계를 `mcr.microsoft.com/dotnet/aspnet:10.0` 이미지에서 시작하면 됩니다. 이 이미지 역시 동일한 Ubuntu 기반이므로 동일한 패키지가 필요합니다.

## **컨테이너 빌드 및 실행**

*HelloSlidesDocker* 폴더에서 터미널을 열고 이미지를 빌드한 뒤 컨테이너를 실행합니다:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

첫 번째 빌드에서는 기본 이미지와 NuGet 패키지를 다운로드하므로 이후 빌드보다 시간이 더 걸립니다. 컨테이너는 애플리케이션을 실행하고 종료합니다. 다음과 같은 출력이 표시됩니다:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

첫 번째 줄은 텍스트가 새 프레젠테이션의 기본 폰트인 Calibri를 사용하지만 이미지에 Calibri가 설치되어 있지 않아 Aspose.Slides가 DejaVu Sans 로 대체했음을 보여줍니다. PDF 내 텍스트는 실제 선택 가능한 텍스트이며 해당 폰트로 표시됩니다. 라이선스가 없을 경우 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가하므로, 자세한 내용은 [Licensing](/slides/ko/net/licensing/) 를 확인하세요.

## **출력 파일을 로컬 머신으로 복사**

파일은 중지된 컨테이너의 */app/output* 폴더에 있습니다. 이를 로컬 머신의 *output* 폴더로 복사한 뒤 컨테이너를 삭제합니다:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

위 두 명령은 Bash, PowerShell, Windows 명령 프롬프트 모두에서 동일하게 동작합니다.

Linux 환경에서는 대신 머신의 폴더를 컨테이너에 마운트하여 애플리케이션이 직접 해당 폴더에 파일을 쓸 수 있습니다:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 옵션은 현재 사용자와 그룹 ID로 애플리케이션을 실행하도록 하여 만든 폴더에 쓸 수 있게 하고, 생성된 파일이 해당 사용자 소유가 되도록 합니다. `--rm` 은 컨테이너가 종료될 때 자동으로 삭제합니다.

## **Alpine Linux에서 실행**

Alpine 기반 이미지에서 애플리케이션을 실행하려면 Aspose.Slides.NET 패키지로 전환하고 런타임 단계를 변경합니다. 빌드 단계는 그대로 유지합니다.

1. *HelloSlidesDocker.csproj* 파일에서 패키지 참조를 다음과 같이 교체합니다:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. *Program.cs* 파일에서 `using` 지시문 뒤, 첫 번째 Aspose.Slides 호출 이전에 다음 코드를 추가합니다. 이는 Linux에서 Aspose.Slides.NET이 사용하는 System.Drawing 지원을 활성화합니다:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. *Dockerfile* 에서 런타임 단계(두 번째 `FROM` 라인부터)를 다음 내용으로 교체합니다:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine 단계에서는 세 개의 패키지를 설치하고 하나의 설정을 변경합니다:

- `libgdiplus` : Linux에서 Aspose.Slides.NET이 사용하는 그래픽 라이브러리입니다.
- `font-dejavu` : 폰트를 제공합니다. 폰트가 없으면 `System.ArgumentException: Font '?' cannot be found` 에러가 발생합니다.
- `icu-libs` 와 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` : 문화권 데이터를 제공합니다. Alpine .NET 이미지는 기본적으로 글로벌화 비활성화 모드로 실행되며, 이 모드에서는 Aspose.Slides가 `en-US` 에 대해 `CultureNotFoundException` 을 발생시킵니다.

위와 동일한 명령을 사용해 빌드, 실행 및 출력 복사를 수행합니다. 이 이미지에서는 애플리케이션이 `Saved` 라인만 출력합니다. Linux에서 Aspose.Slides.NET을 사용할 경우, fontconfig 가 누락된 폰트의 대체 폰트를 선택하고 [GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/) 은 이를 표시하지 않습니다. 사용된 폰트를 확인하는 방법은 [Deploy Fonts](/slides/ko/net/deploy-fonts/) 에 나와 있습니다.

## **FAQ**

**“Unable to load shared library 'libaspose.slides.drawing.capi…'” 오류가 발생합니다. 무엇이 누락된 건가요?**

Ubuntu 및 Debian 이미지에서는 `libfontconfig1` 패키지가 필요합니다. 오류 메시지에 `libfontconfig.so.1` 파일을 열 수 없다고 표시됩니다. Alpine Linux에서는 Aspose.Slides.NET6.CrossPlatform을 사용하고 있기 때문에 발생하는 메시지이며, [Run on Alpine Linux](#run-on-alpine-linux) 에서 설명한 대로 Aspose.Slides.NET 으로 전환하면 해결됩니다.

**PDF의 텍스트가 PowerPoint와 다른 폰트로 표시되는 이유는?**

프레젠테이션에 사용된 폰트가 이미지에 설치돼 있지 않기 때문에 Aspose.Slides가 대체 폰트로 텍스트를 그립니다. 애플리케이션 출력에 교체된 각 폰트가 표시됩니다. 이미지에 폰트를 설치하거나 애플리케이션 폴더에서 로드하는 방법은 [Deploy Fonts](/slides/ko/net/deploy-fonts/) 를 참고하세요.

**내 머신에 .NET SDK가 필요합니까?**

필요 없습니다. 빌드 단계는 SDK 이미지 내부에서 애플리케이션을 컴파일합니다. Docker 외부에서 직접 빌드 및 실행하려는 경우에만 SDK가 필요하므로, 자세한 내용은 [Installation](/slides/ko/net/installation/) 를 확인하세요.