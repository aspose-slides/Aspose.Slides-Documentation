---
title: Linux 및 Docker에서 Aspose.Slides용 글꼴 배포
linktitle: 글꼴 배포
type: docs
weight: 145
url: /ko/net/deploy-fonts/
keywords:
- 글꼴 배포
- 글꼴 설치
- Docker의 글꼴
- Linux의 글꼴
- 누락된 글꼴
- 글꼴 대체
- Microsoft 핵심 글꼴
- ttf-mscorefonts-installer
- 사용자 정의 글꼴
- 기본 글꼴
- 서버
- 컨테이너
- PDF 변환
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Linux 서버와 Docker 컨테이너에서 Aspose.Slides for .NET용 글꼴을 배포합니다: 대체되는 글꼴을 확인하고, Debian, Ubuntu 및 Alpine에 글꼴 패키지를 설치하며, 자체 글꼴 파일을 추가하고, 기본 글꼴을 설정합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 렌더링할 때 사용 가능한 글꼴로 텍스트를 그립니다. 예를 들어 슬라이드를 PDF 또는 이미지로 변환할 때입니다. Windows 데스크톱에는 일반적으로 프레젠테이션에서 사용하는 글꼴이 있습니다. Linux 서버와 컨테이너에는 글꼴이 거의 없거나 전혀 없기 때문에 Aspose.Slides는 대체 글꼴로 텍스트를 그립니다. 대체 글꼴은 글자 모양과 폭이 다르므로 줄이 다르게 감싸지거나 텍스트가 형태를 벗어날 수 있으며, 대체 글꼴에 없는 문자는 올바르게 그려지지 않습니다. 글꼴이 전혀 설치되지 않은 경우 변환이 오류와 함께 중단됩니다.

이 문서에서는 Aspose.Slides가 대체하는 글꼴을 확인하는 방법, Debian, Ubuntu 및 Alpine Linux에 글꼴을 설치하는 방법, 자체 글꼴 파일을 추가하는 방법, 그리고 글꼴이 없을 때 사용할 글꼴을 설정하는 방법을 보여줍니다. 예제는 공식 .NET 이미지에서 Docker로 실행되며, [Run Aspose.Slides for .NET in Docker](/slides/ko/net/how-to-run-aspose-slides-in-docker/)와 동일합니다. 패키지 명령은 Dockerfile 지시문이며, Linux 서버에서는 루트 권한으로 동일한 명령을 실행합니다.

프레젠테이션에 글꼴을 임베드하거나 대체 및 교체 규칙과 같은 글꼴 API 자체에 대해서는 [PowerPoint Fonts](/slides/ko/net/powerpoint-fonts/)를 참조하십시오.

## **대체되는 글꼴 확인**

다음 콘솔 애플리케이션은 현재 환경에서 Aspose.Slides가 대체하는 글꼴을 보고합니다. *FontCheck* 라는 폴더를 만들고 아래 파일들을 추가하십시오.

*FontCheck.csproj*는 Debian 및 Ubuntu용 패키지인 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)을 참조합니다. 또한 선택적인 *fonts* 폴더의 파일을 애플리케이션 출력으로 복사합니다; [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) 섹션에서 사용됩니다.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs*는 각 글꼴 이름마다 슬라이드에 텍스트 상자를 하나 추가하고 [LatinFont](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/latinfont/) 속성을 통해 글꼴을 할당합니다. 글꼴 이름은 명령줄에서 가져오며, 인수가 없을 경우 애플리케이션은 Calibri, Arial 및 Times New Roman을 확인합니다. Aspose.Slides가 글꼴을 찾는 폴더([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/getfontfolders/))를 출력하고, 슬라이드를 *output/fonts.pdf* 로 렌더링하며, [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/)에서 보고된 대체 정보를 출력합니다. 시작 부분의 두 선택적 단계인 *fonts* 폴더 로드와 `DEFAULT_FONT` 변수 읽기에 대한 설명은 본 문서 후반에서 다룹니다.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// 확인할 글꼴: 명령줄 인수 또는 일반적인 Office 글꼴 세 개.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// 앱 옆에 있는 fonts 폴더에서 글꼴 파일을 로드합니다(폴더가 있는 경우).
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// DEFAULT_FONT 환경 변수에 지정된 글꼴을 사용합니다(설정된 경우), 글꼴이 없는 텍스트에 대해.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore*는 로컬 빌드 결과물을 빌드 컨텍스트에서 제외합니다:

```text
bin/
obj/
output/
```

*Dockerfile*은 .NET SDK 이미지를 사용해 애플리케이션을 빌드하고 .NET 런타임 이미지에서 실행합니다. 런타임 단계에서는 Aspose.Slides.NET6.CrossPlatform이 필요로 하는 `libfontconfig1`와 DejaVu 글꼴을 설치합니다. [Run Aspose.Slides for .NET in Docker](/slides/ko/net/how-to-run-aspose-slides-in-docker/)에서 각 명령을 설명합니다.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

이미지를 빌드하고 검사를 실행합니다:

```bash
docker build -t font-check .
docker run --rm font-check
```

이미지에는 DejaVu 글꼴만 포함되어 있으므로 세 글꼴 모두 DejaVu Sans로 대체됩니다:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

자신의 프레젠테이션 글꼴을 확인하려면 글꼴 이름을 인수로 전달하십시오. 예: `docker run --rm font-check "Segoe UI" Consolas`. 컨테이너에서 *output/fonts.pdf* 를 복사하려면 [Copy the Output to Your Machine](/slides/ko/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine)의 명령을 사용하십시오.

## **Debian 및 Ubuntu에 글꼴 설치**

### **Microsoft 핵심 글꼴**

`ttf-mscorefonts-installer` 패키지는 Arial, Times New Roman, Courier New, Verdana, Georgia, Trebuchet MS 등을 포함한 Microsoft의 웹용 핵심 글꼴을 다운로드하고 설치합니다. 이 글꼴들은 Microsoft 최종 사용자 사용권 계약(EULA) 아래 라이선스가 부여되며, 패키지는 EULA가 수락된 경우에만 설치합니다. Docker 빌드에서는 프롬프트에 응답할 수 없으므로 설치 프로그램이 EULA를 거부하고 글꼴을 설치하지 않으며, `apt-get install`은 여전히 성공을 보고합니다. 패키지를 설치하기 **전** `debconf-set-selections` 로 EULA를 수락하십시오.

*Dockerfile*에서 런타임 단계에 패키지를 설치하는 `RUN` 명령을 다음으로 교체하십시오:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

이미지를 빌드하고 동일한 두 명령으로 검사를 다시 실행하십시오. 이제 Arial과 Times New Roman이 설치되었습니다:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Aspose.Slides가 생성하는 프레젠테이션의 기본 글꼴인 Calibri는 핵심 글꼴에 포함되지 않으므로 여전히 대체됩니다. [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts) 를 참조하십시오.

Debian에서는 패키지가 `contrib` 저장소 구성 요소에 포함되어 있으며, Debian 이미지에서는 이 구성 요소가 활성화되지 않습니다; 기본 .NET 8 및 .NET 9 이미지는 Debian 12 기반입니다. 같은 명령에서 `contrib` 를 활성화하십시오:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Ubuntu 기반 .NET 10 이미지에서는 이미 `multiverse` 가 활성화되어 있으며, 이는 해당 패키지를 포함하는 Ubuntu 구성 요소입니다.

### **기타 글꼴 패키지**

Debian 및 Ubuntu는 자유 라이선스 글꼴도 패키징하며, 예를 들어:

| 패키지 | 글꼴 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, 및 Mono, Arial, Times New Roman 및 Courier New와 동일한 메트릭 |
| `fonts-crosextra-carlito` | Carlito, Calibri와 동일한 메트릭 |
| `fonts-crosextra-caladea` | Caladea, Cambria와 동일한 메트릭 |

`apt-get install` 로 동일한 `RUN` 명령에 설치하십시오. Aspose.Slides.NET6.CrossPlatform은 Linux 글꼴 구성의 별칭을 적용하지 않습니다. `fonts-liberation`을 설치해도 Arial 텍스트는 일반 대체 글꼴로 그려지며 Liberation Sans로 대체되지 않습니다. 누락된 글꼴 대신 메트릭이 호환되는 글꼴을 사용하려면 이를 [default font](#set-a-default-font-for-missing-fonts) 로 설정하거나 [font substitution rule](/slides/ko/net/font-substitution/)을 추가하십시오.

## **자체 글꼴 파일 추가**

배포판에 포함되지 않은 글꼴, 예를 들어 조직의 글꼴이나 서버에서 사용 라이선스가 있는 기타 글꼴은 글꼴 파일로 추가할 수 있습니다. *.ttf* 파일과 같이 글꼴 파일을 *FontCheck* 폴더 내부의 *fonts* 폴더에 넣으십시오. 아래 예제에서는 Calibri와 동일한 메트릭을 가진 Carlito 파일을 사용하며, 이는 [Google Fonts](https://fonts.google.com/specimen/Carlito)에서 다운로드할 수 있습니다.

### **시스템 글꼴 폴더에 글꼴 설치**

Aspose.Slides는 `Font folders` 라인에 출력된 폴더에서 글꼴을 읽습니다. 이미지 내 모든 애플리케이션에서 사용할 글꼴을 설치하려면 */usr/local/share/fonts* (로컬에 설치된 글꼴 폴더) 로 복사하십시오. 패키지를 설치하는 `RUN` 명령 뒤에 *Dockerfile*의 런타임 단계에 다음 명령을 추가합니다:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **애플리케이션 폴더에서 글꼴 로드**

이미지에 글꼴을 설치하는 대신, 애플리케이션에 포함시켜 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsloader/loadexternalfonts/) 로 로드할 수 있습니다. 이렇게 하면 글꼴은 Aspose.Slides에서만 사용 가능하며 애플리케이션과 함께 배포됩니다. *FontCheck*은 다음과 같이 구현됩니다: *FontCheck.csproj*가 *fonts* 폴더를 애플리케이션 출력에 복사하고, *Program.cs*가 프레젠테이션을 생성하기 전에 해당 폴더를 `LoadExternalFonts`에 전달합니다. [Custom Font](/slides/ko/net/custom-font/)에서는 메모리에서 로드하는 등 다른 글꼴 제공 방법을 설명합니다.

이미지를 다시 빌드하고 Calibri와 Carlito를 확인하십시오:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

애플리케이션 폴더가 이제 글꼴 폴더에 나타나며, Carlito는 더 이상 대체되지 않습니다:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **누락된 글꼴에 대한 기본 글꼴 설정**

글꼴이 없을 경우, Aspose.Slides는 자체적으로 선택한 대체 글꼴을 사용합니다. 직접 선택하려면 [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)의 [DefaultRegularFont](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaultregularfont/) 속성을 설정하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 생성자에 전달하십시오. *FontCheck*은 `DEFAULT_FONT` 환경 변수에서 글꼴 이름을 읽습니다. Carlito를 로드한 상태에서 누락된 글꼴에 이를 사용합니다:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

이제 Calibri가 Carlito로 그려지며, 해당 문자의 폭이 Calibri와 동일하므로 텍스트가 줄바꿈을 유지합니다:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

기본 글꼴은 모든 누락된 글꼴을 대체합니다. 개별 글꼴을 매핑하려면, 예를 들어 Arial을 Liberation Sans로, Calibri를 Carlito로 매핑하려면 [font substitution rules](/slides/ko/net/font-substitution/)을 사용하십시오. 규칙은 렌더링 결과를 변경하지만 `GetSubstitutions` 에서는 반영되지 않으므로 출력 파일의 글꼴을 확인하십시오. 아시아 문자에 대해서는 [DefaultAsianFont](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaultasianfont/)도 설정하십시오; 자세한 내용은 [Default Font](/slides/ko/net/default-font/)를 참고하십시오.

## **Alpine Linux에 글꼴 설치**

Alpine Linux에서는 Aspose.Slides.NET 패키지를 사용하십시오; [Run on Alpine Linux](/slides/ko/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) 에 프로젝트 변경 사항이 나열되어 있습니다. *FontCheck*에도 동일한 변경을 적용하십시오: 패키지 참조를 교체하고, *Program.cs*에 `SetSwitch` 문을 추가하며, Microsoft 핵심 글꼴도 설치하는 이 런타임 단계를 사용합니다:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts`는 Debian 및 Ubuntu 패키지와 동일한 Microsoft 핵심 글꼴을 다운로드하고 설치하며, EULA도 동일하게 적용됩니다. `fc-cache`는 글꼴 캐시를 업데이트합니다.

Linux에서 Aspose.Slides.NET을 사용할 때, 글꼴 구성 라이브러리(fontconfig)가 누락된 글꼴의 대체 글꼴을 선택하며, `GetSubstitutions`는 이를 보고하지 않으므로 *FontCheck*는 `No font substitutions.` 를 출력합니다. 글꼴 이름에 어떤 글꼴이 사용되는지 확인하려면 컨테이너에서 fontconfig에 문의하십시오:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Microsoft 핵심 글꼴이 설치된 경우, Arial에 대해 Arial이 사용됩니다:

```text
Arial.ttf: "Arial" "Regular"
```

이 글꼴이 없을 경우, `RUN` 명령이 `icu-libs libgdiplus font-dejavu`만 설치하면 동일한 명령이 다음을 출력합니다:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **자주 묻는 질문**

**서버에서 변환할 때 프레젠테이션이 다르게 보이는 이유는 무엇인가요?**

서버에 프레젠테이션에서 사용하는 글꼴이 없기 때문에 Aspose.Slides는 문자 폭이 다른 대체 글꼴로 텍스트를 그립니다. 프레젠테이션의 글꼴 이름을 사용하여 *FontCheck*를 실행하면 어떤 글꼴이 대체되는지 확인할 수 있으며, 해당 글꼴을 설치하거나 애플리케이션 폴더에서 로드하면 됩니다.

**빌드에 ttf-mscorefonts-installer를 설치했지만 여전히 Arial이 대체됩니다. 이유가 무엇인가요?**

패키지를 설치하기 전에 EULA가 수락되지 않아 설치 프로그램이 글꼴을 건너뛰었습니다. [Microsoft Core Fonts](#microsoft-core-fonts) 에 표시된 대로 `apt-get install` 이전에 `debconf-set-selections` 명령을 추가하고 이미지를 다시 빌드하십시오.

**PDF를 여는 컴퓨터에 글꼴이 필요합니까?**

아니요. 이 예제에서는 PDF에 텍스트를 그리는 데 사용된 글꼴이 포함되어 있어 어떤 컴퓨터에서 열어도 동일하게 보입니다. 글꼴은 Aspose.Slides가 프레젠테이션을 렌더링하는 곳에만 필요합니다.