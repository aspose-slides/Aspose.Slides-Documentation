---
title: C++에서 PowerPoint 글꼴 사용자 지정
linktitle: 사용자 지정 글꼴
type: docs
weight: 20
url: /ko/cpp/custom-font/
keywords:
- 글꼴
- 맞춤 글꼴
- 외부 글꼴
- 글꼴 로드
- 글꼴 관리
- 글꼴 폴더
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 지정하면 프레젠테이션을 어느 디바이스에서든 선명하고 일관되게 유지할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있습니다. 사용자 지정 폴더에서 글꼴을 로드하거나, 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나, 바이너리 데이터에서 외부 글꼴을 직접 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원되는 형식으로 내보내질 때 사용됩니다. 이는 다양한 환경에서 프레젠테이션 출력이 일관되도록 도와줍니다. 이 문서에서는 Aspose.Slides에서 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴을 사용한 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 지정 글꼴 등록은 PPTX 파일에 글꼴을 포함시키는 것과 별개입니다. 글꼴을 프레젠테이션 자체에 저장해야 하는 경우, 글꼴 포함 기능을 명시적으로 사용하십시오.

프레젠테이션 테마는 개별 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 참조할 수 있습니다. 이러한 매핑은 글꼴 이름만 저장하며 글꼴 파일을 설치하거나 로드하지 않습니다. 매핑을 관리하려면 [Script-Specific Theme Fonts](/slides/ko/cpp/script-specific-font-mappings/)를 참조하고, 아래 로드 옵션을 사용하여 일관된 렌더링을 위해 참조된 글꼴을 사용할 수 있도록 하십시오.

{{% alert color="info" title="Note" %}}
Aspose Slides는 다음과 같이 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/)을 사용하여 이러한 글꼴을 로드할 수 있습니다:

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세한 내용은 [TrueType](https://en.wikipedia.org/wiki/TrueType)을 참조하십시오.
* OpenType(.otf) 글꼴. 자세한 내용은 [OpenType](https://en.wikipedia.org/wiki/OpenType)을 참조하십시오.
{{% /alert %}}

## **사용자 지정 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 설치하지 않고도 프레젠테이션에서 사용되는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원되는 형식과 같은 내보내기 결과에 영향을 주어, 결과 문서가 다양한 환경에서 일관되게 보이도록 합니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 들어 있는 하나 이상의 폴더를 지정합니다.
2. 해당 폴더에서 글꼴을 로드하기 위해 정적 메서드 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/)를 호출합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. 글꼴 캐시를 지우기 위해 [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/clearcache/)를 호출합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:
```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 사용자 지정 글꼴 파일이 들어 있는 폴더를 정의합니다.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// 지정된 폴더에서 사용자 지정 글꼴을 로드합니다.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 로드된 글꼴을 사용하여 프레젠테이션을 렌더링/내보냅니다(예: PDF, 이미지 또는 기타 형식).
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// 작업이 끝난 후 글꼴 캐시를 지웁니다.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/)는 글꼴 검색 경로에 추가 폴더를 추가하지만, 글꼴 초기화 순서는 변경하지 않습니다. 글꼴은 다음 순서대로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/)를 통해 로드된 경로.
{{%/alert %}}

## **사용자 지정 글꼴 폴더 가져오기**

Aspose.Slides는 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/getfontfolders/)를 제공하여 글꼴 폴더를 찾을 수 있도록 합니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 반환합니다.

다음 C++ 코드는 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/getfontfolders/) 메서드 사용 방법을 보여줍니다:
``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// 이 라인은 글꼴 파일이 검사되는 폴더들을 출력합니다.
// 이 폴더들은 LoadExternalFonts 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더입니다.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **프레젠테이션에 사용되는 사용자 지정 글꼴 지정**

Aspose.Slides는 프레젠테이션과 함께 사용할 외부 글꼴을 지정할 수 있도록 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 속성을 제공합니다.

다음 C++ 코드는 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 속성 사용 방법을 보여줍니다:
``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //프레젠테이션 작업
    //CustomFont1, CustomFont2와 assets\fonts 및 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
}
```

## **외부에서 글꼴 관리**

Aspose.Slides는 외부 글꼴을 바이트 배열로 로드할 수 있도록 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfont/) 메서드를 제공합니다.

다음 C++ 코드는 바이트 배열을 사용한 글꼴 로드 과정을 보여줍니다:
```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// 문서 디렉터리 경로
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **자주 묻는 질문**

### 맞춤 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로 내보내기에 영향을 줍니까?

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

### 맞춤 글꼴이 결과 PPTX에 자동으로 포함됩니까?

아니요. 렌더링을 위해 글꼴을 등록하는 것은 PPTX에 글꼴을 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 포함해야 하는 경우, 명시적인 [임베딩 기능](/slides/ko/cpp/embedded-font/)를 사용해야 합니다.

### 맞춤 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있습니까?

예. 요청된 글리프가 없을 때 사용될 글꼴을 정확히 정의하려면 [글꼴 대체](/slides/ko/cpp/font-substitution/), [대체 규칙](/slides/ko/cpp/font-replacement/), 및 [대체 세트](/slides/ko/cpp/fallback-font/)를 구성하십시오.

### Linux/Docker 컨테이너에서 시스템 전체에 설치하지 않고 글꼴을 사용할 수 있습니까?

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 됩니다. 이렇게 하면 컨테이너 이미지에서 시스템 글꼴 디렉터리에 대한 모든 의존성이 제거됩니다.

### 라이선스는 어떻게 되나요—제한 없이 모든 맞춤 글꼴을 포함할 수 있습니까?

글꼴 라이선스 준수는 사용자의 책임입니다. 조건은 다양하며, 일부 라이선스는 포함하거나 상업적 사용을 금지합니다. 출력물을 배포하기 전에 반드시 글꼴의 EULA를 확인하십시오.