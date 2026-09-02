---
title: C++에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- C++
- Aspose.Slides
description: "C++에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지가 저장되고 참조되는 위치를 제어합니다."
---
## **개요**

Aspose.Slides for C++는 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 관리 워크플로를 위해 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환할 수 있습니다. Markdown 형식을 선택하고, 슬라이드 내용이 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 어떻게 참조하는지 결정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력만 사용합니다. 시각적 콘텐츠를 내보내려면 [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) 메서드를 [MarkdownExportType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownexporttype/) 열거형의 `Sequential` 또는 `Visual` 값으로 설정하십시오. `Sequential`은 슬라이드 항목을 별도로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 내보내지 않으므로 해당 모드에서는 이미지 저장 이벤트가 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스에서 로드한 다음, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/) 메서드를 호출하고 [SaveFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveformat/) 열거형의 `Md` 값을 사용합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Markdown 형식 선택**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) 메서드는 출력에 사용되는 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/) 클래스는 로컬에 저장되는 이미지를 구성하기 위한 두 가지 메서드를 제공합니다:

- [set_BasePath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/)은 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/)은 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images`입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고 이미지를 `output/assets`에 기록하며 Markdown 문서에 상대 이미지 참조를 생성합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

이 동작은 사용자 지정 이미지 저장 핸들러가 `false`를 반환할 때 대체 동작으로도 사용됩니다.

## **이미지 저장 및 Markdown 링크 사용자 지정**

Markdown 내보내기 중에 방출되는 비 SVG 비트맵 및 메타파일 리소스에 대해 `MarkdownSaveOptions::ImageSaving` 이벤트를 사용합니다. 해당 [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) 대리자는 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체, 그 [ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/) 및 `System::String&` 형식의 생성된 Markdown 링크를 매개변수로 받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `link`를 Markdown 출력에 표시되어야 할 참조로 교체합니다.

SVG 형식으로 방출되는 리소스는 별도로 처리됩니다. `MarkdownSaveOptions::SvgImageSaving` 이벤트에 구독하고, 해당 [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) 대리자는 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체와 `System::String& link` 매개변수를 받습니다. SVG에는 `ImageFormat` 인수가 없으므로 대신 [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/get_svgdata/) 메서드에서 XML 데이터를 쓰거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 원본 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 그 결과 비 SVG 리소스는 `ImageSaving`에 전달됩니다. 모든 내보낸 시각적 리소스에 사용자 지정 처리가 필요할 경우 두 이벤트 모두에 구독하십시오.

핸들러 반환 값에 따라 이미지 처리를 담당하는 주체가 결정됩니다:

- 핸들러가 이미지를 저장·업로드·변환하거나 기타 처리한 후 유효한 값을 `link`에 할당한 경우 `true`를 반환합니다. Aspose.Slides는 해당 값을 Markdown 문서에 기록하고 기본 로컬 저장을 수행하지 않습니다.
- `false`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고 [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 및 [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/)에 따라 링크를 생성합니다.

{{% alert color="warning" title="Important" %}}
`true`를 반환하는 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 할당하지 않고 `true`를 반환하면 `InvalidOperationException`으로 내보내기가 실패합니다.
{{% /alert %}}

### **이미지를 CDN 오리진 디렉터리에 저장하고 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되거나 동기화된 CDN 오리진 디렉터리로 취급합니다. 각 핸들러는 생성된 파일 이름을 추출하고 해당 사용자 지정 디렉터리에 이미지를 저장한 다음, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 오리진으로 마운트되거나 파일이 CDN에 게시된 후에 URL이 유효해집니다. 객체 스토리지의 경우 파일 시스템 기록을 스토리지 SDK의 업로드 작업으로 교체하고 업로드가 성공한 후에만 `link`를 할당하십시오.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

비트맵 핸들러는 128 × 128 픽셀보다 작은 이미지에 대해 의도적으로 `false`를 반환하므로 Aspose.Slides는 해당 이미지를 기본 동작으로 `output/fallback-images`에 저장합니다. 더 큰 비트맵 및 메타파일 리소스와 SVG 리소스는 사용자 지정 코드로 처리됩니다. 예를 들어, `fallback-images/image1.png`와 같은 생성된 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`가 됩니다. 핸들러는 파일을 쓸 때만 운영 체제 경로를 사용하고, Markdown에 기록되는 링크는 슬래시(`/`)와 URL‑인코딩된 파일 이름을 사용합니다. 상대 링크를 만들 때도 같은 규칙을 적용하고, 플랫폼 별 디렉터리 구분자가 아닌 `/`를 사용하십시오.

## **FAQ**

**하나의 핸들러가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니요. 방출된 비트맵 및 메타파일 리소스에는 `MarkdownSaveOptions::ImageSaving`을, SVG 로 방출된 리소스에는 `MarkdownSaveOptions::SvgImageSaving`을 사용하십시오. 전자는 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체와 [ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/)를 제공하고, 후자는 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체와 그 SVG 데이터를 읽을 수 있는 [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/get_svgdata/)를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 `ImageSaving`으로 처리됩니다.

**이미지 저장 핸들러가 `false`를 반환하면 어떻게 됩니까?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 및 [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/)에 의해 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

예. 핸들러가 이미지를 객체 스토리지에 업로드하거나 다른 서비스에 전달하고, 결과 URL을 `link`에 할당한 뒤 `true`를 반환하면 됩니다. `true`를 반환하면 기본 로컬 저장이 방지됩니다.

**핸들러에서 `InvalidOperationException`이 발생하는 이유는 무엇입니까?**

핸들러가 `true`를 반환했지만 유효한 링크를 제공하지 않았을 때 발생합니다. `true`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 할당하십시오.

**이미지 링크는 어떤 경로 구분자를 사용해야 합니까?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로를 구성할 때는 `Path::Combine`을 사용하고, Markdown 참조는 별도로 정규화하십시오.

**Markdown 내보내기 시 하이퍼링크가 보존됩니까?**

예. 텍스트 [하이퍼링크](/slides/ko/cpp/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [전환](/slides/ko/cpp/slide-transition/) 및 [애니메이션](/slides/ko/cpp/powerpoint-animation/)은 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있습니까?**

다른 프레젠테이션 파일을 병렬로 처리할 수 있지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. [멀티스레딩 가이드라인](/slides/ko/cpp/multithreading/)을 따르고 파일당 별도 인스턴스를 사용하십시오.