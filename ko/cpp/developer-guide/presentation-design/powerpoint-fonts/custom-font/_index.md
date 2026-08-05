---
title: C++에서 PowerPoint 글꼴 사용자 지정
linktitle: 맞춤 글꼴
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
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드의 글꼴을 사용자 지정하고, 프레젠테이션을 모든 장치에서 선명하고 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 운영 체제에 글꼴을 설치하지 않고도 프레젠테이션에서 사용자 지정 글꼴을 사용할 수 있습니다. 사용자 지정 폴더에서 글꼴을 로드하거나 문서 수준 글꼴 소스를 통해 특정 프레젠테이션에 글꼴을 제공하거나 바이너리 데이터에서 직접 외부 글꼴을 로드할 수 있습니다.

로드된 글꼴은 프레젠테이션이 렌더링되거나 PDF, 이미지 및 기타 지원 형식으로 내보낼 때 사용됩니다. 이를 통해 다양한 환경에서 프레젠테이션 출력이 일관되게 유지됩니다. 이 기사에서는 Aspose.Slides에서 사용하는 글꼴 폴더를 확인하는 방법과 외부 글꼴 작업 후 글꼴 캐시를 지우는 방법도 설명합니다.

렌더링을 위한 사용자 지정 글꼴 등록은 PPTX 파일에 글꼴을 포함하는 것과 별개입니다. 프레젠테이션 자체에 글꼴을 저장해야 하는 경우, 글꼴 포함 기능을 명시적으로 사용하십시오.

{{% alert color="primary" %}} 

Aspose Slides는 다음 메서드를 사용하여 이러한 글꼴을 로드할 수 있습니다: [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType(.ttf) 및 TrueType Collection(.ttc) 글꼴. 자세히: [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType(.otf) 글꼴. 자세히: [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **맞춤 글꼴 로드**

Aspose.Slides를 사용하면 시스템에 글꼴을 설치하지 않고도 프레젠테이션에서 사용하는 글꼴을 로드할 수 있습니다. 이는 PDF, 이미지 및 기타 지원 형식과 같은 내보내기 출력에 영향을 주어 환경에 관계없이 문서가 일관된 모양을 유지하도록 합니다. 글꼴은 사용자 지정 디렉터리에서 로드됩니다.

1. 글꼴 파일이 포함된 하나 이상의 폴더를 지정합니다.
2. 정적 메서드 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/)를 호출하여 해당 폴더에서 글꼴을 로드합니다.
3. 프레젠테이션을 로드하고 렌더링/내보냅니다.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/clearcache/)를 호출하여 글꼴 캐시를 정리합니다.

다음 코드 예제는 글꼴 로드 과정을 보여줍니다:

```cpp
// 사용자 지정 글꼴 파일이 포함된 폴더를 정의합니다.
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

{{% alert color="info" title="참고" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/)는 글꼴 검색 경로에 추가 폴더를 등록하지만, 글꼴 초기화 순서는 변경되지 않습니다.  
글꼴은 다음 순서로 초기화됩니다:

1. 기본 운영 체제 글꼴 경로.
1. [FontsLoader](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/)를 통해 로드된 경로.

{{%/alert %}}

## **맞춤 글꼴 폴더 가져오기**
Aspose.Slides는 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/getfontfolders/) 메서드를 제공하여 현재 등록된 글꼴 폴더를 확인할 수 있습니다. 이 메서드는 `LoadExternalFonts` 메서드를 통해 추가된 폴더와 시스템 글꼴 폴더를 모두 반환합니다.

다음 C++ 코드에서 [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/getfontfolders/) 메서드 사용 방법을 보여줍니다:

``` cpp
// 이 줄은 글꼴 파일이 확인되는 폴더를 출력합니다.
// 이는 LoadExternalFonts 메서드와 시스템 글꼴 폴더를 통해 추가된 폴더입니다.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **프레젠테이션에 사용될 맞춤 글꼴 지정**
Aspose.Slides는 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 속성을 제공하여 프레젠테이션에 사용할 외부 글꼴을 지정할 수 있습니다.

다음 C++ 코드에서 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) 속성 사용 방법을 보여줍니다:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //프레젠테이션 작업
    //CustomFont1, CustomFont2 및 assets\fonts 및 global\fonts 폴더와 그 하위 폴더의 글꼴이 프레젠테이션에서 사용 가능합니다
}
```

## **외부에서 글꼴 관리**
Aspose.Slides는 [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfont/) 메서드를 제공하여 외부 글꼴을 바이트 배열 형태로 로드할 수 있습니다.

다음 C++ 코드에서 바이트 배열을 이용한 글꼴 로드 과정을 시연합니다:

```cpp
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

## **FAQ**

**맞춤 글꼴이 모든 형식(PDF, PNG, SVG, HTML)으로의 내보내기에 영향을 줍니까?**

예. 연결된 글꼴은 모든 내보내기 형식에서 렌더러에 의해 사용됩니다.

**맞춤 글꼴이 결과 PPTX에 자동으로 포함됩니까?**

아니요. 렌더링을 위한 글꼴 등록은 PPTX에 포함시키는 것과 동일하지 않습니다. 프레젠테이션 파일에 글꼴을 저장해야 하면 명시적인 [임베딩 기능](/slides/ko/cpp/embedded-font/)을 사용해야 합니다.

**맞춤 글꼴에 특정 글리프가 없을 때 대체 동작을 제어할 수 있나요?**

예. [글꼴 대체](/slides/ko/cpp/font-substitution/), [교체 규칙](/slides/ko/cpp/font-replacement/), [대체 세트](/slides/ko/cpp/fallback-font/)를 구성하여 요청된 글리프가 없을 때 사용할 글꼴을 정확히 정의할 수 있습니다.

**Linux/Docker 컨테이너에서 시스템 전역에 설치하지 않고 글꼴을 사용할 수 있나요?**

예. 자체 글꼴 폴더를 지정하거나 바이트 배열에서 글꼴을 로드하면 컨테이너 이미지 내 시스템 글꼴 디렉터리에 대한 의존성을 제거할 수 있습니다.

**라이선스는 어떻게 되나요—맞춤 글꼴을 제한 없이 임베드할 수 있나요?**

글꼴 라이선스 준수는 사용자의 책임입니다. 라이선스에 따라 임베드 또는 상업적 사용을 금지할 수도 있습니다. 출력물을 배포하기 전에 항상 해당 글꼴의 EULA를 검토하십시오.