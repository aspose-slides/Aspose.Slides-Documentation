---
title: C++를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/cpp/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- 외부 SVG 리소스
- SVG 해석기
- 연결된 SVG 이미지
- SVG 폰트
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument의 이미지 관리를 간소화하고, 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 매력적이고 시각적으로 돋보이게 만듭니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 소스에서 슬라이드에 그림을 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 여러 가지 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert title="Tip" color="info" %}} 
Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
이미지를 그림 프레임으로 추가하려는 경우—특히 크기 조정, 효과 적용 또는 기타 표준 서식 옵션을 사용할 계획이라면—[Picture Frame](/slides/ko/cpp/picture-frame/)을 참조하십시오. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: 변환 [이미지를 JPG로]((https://products.aspose.com/slides/ko/cpp/conversion/image-to-jpg/)), [JPG를 이미지로]((https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-image/)), [JPG를 PNG로]((https://products.aspose.com/slides/ko/cpp/conversion/jpg-to-png/)), [PNG를 JPG로]((https://products.aspose.com/slides/ko/cpp/conversion/png-to-jpg/)), [PNG를 SVG로]((https://products.aspose.com/slides/ko/cpp/conversion/png-to-svg/)), 및 [SVG를 PNG로]((https://products.aspose.com/slides/ko/cpp/conversion/svg-to-png/)). 
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 일반적인 형식의 이미지를 지원합니다. 

## **슬라이드에 로컬에 저장된 이미지 추가**

컴퓨터에 저장된 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 C++ 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **웹에서 슬라이드에 이미지 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 저장되어 있지 않은 경우 웹에서 직접 추가할 수 있습니다. 

다음 C++ 샘플 코드는 웹에서 이미지를 가져와 슬라이드에 추가하는 방법을 보여줍니다:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터를 사용하는 슬라이드의 테마 및 레이아웃과 같은 정보를 저장하고 제어합니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 기반으로 하는 모든 슬라이드에 이미지가 표시됩니다. 

다음 C++ 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **이미지를 슬라이드 배경으로 추가**

한 장 이상의 슬라이드 배경으로 그림을 사용할 수 있습니다. 자세한 내용은 *[Setting Images as Backgrounds for Slides](/slides/ko/cpp/presentation-background/#setting-images-as-background-for-slides)*을(를) 참조하십시오.

## **프레젠테이션에 SVG 추가**

SVG 콘텐츠는 [SvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/svgimage/) 클래스를 사용하여 프레젠테이션에 추가할 수 있습니다. 결과 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체는 프레젠테이션 이미지 컬렉션에 추가된 후 그림 프레임을 만드는 데 사용할 수 있습니다.

다음 C++ 예제는 자체 포함된 SVG 문자열을 가져옵니다. 이 SVG에서 사용되는 모든 이미지, 스타일 및 기타 리소스가 SVG 콘텐츠에 직접 포함됩니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **외부 리소스가 포함된 SVG 콘텐츠 가져오기**

디자인 도구, 다이어그램 편집기, 아이콘 시스템 및 웹 파이프라인에서 내보낸 SVG 파일은 SVG 문서 외부에 저장된 리소스를 참조할 수 있습니다. 예를 들어, SVG는 `images/photo.png`와 같은 이미지 링크, CSS `url(...)` 값 또는 폰트 URL을 포함할 수 있습니다.

이러한 SVG 콘텐츠를 가져오려면 [IExternalResourceResolver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/iexternalresourceresolver/) 구현을 생성하고 이를 기본 URI와 함께 적절한 `SvgImage` 생성자에 전달합니다. 기본 URI는 SVG 문서의 위치를 식별하고 상대 링크를 해결하는 데 사용됩니다.

[ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 인터페이스는 가져온 SVG에 대한 정보를 제공합니다:

- `get_SvgContent()`는 SVG 마크업을 문자열로 반환합니다.
- `get_SvgData()`는 SVG 콘텐츠를 바이트 배열로 반환합니다.
- `get_BaseUri()`는 상대 링크에 사용되는 기본 URI를 반환합니다.
- `get_ExternalResourceResolver()`는 SVG 이미지에 할당된 리소스 해결자를 반환합니다.

### **외부 리소스 해결자 구현**

해결자는 두 가지 메서드를 가집니다:

- [ResolveUri](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/)는 기본 URI와 상대 리소스 링크를 결합하여 절대 URI를 반환합니다. 링크를 해결할 수 없거나 허용되지 않을 경우 null 문자열을 반환하십시오.
- [GetEntity](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/iexternalresourceresolver/getentity/)는 절대 리소스 URI에 대한 읽기 가능한 스트림을 반환합니다. 리소스가 없거나 차단되었거나 사용할 수 없는 경우 `nullptr`을 반환하십시오. 필요한 경우 대체 스트림을 반환할 수도 있습니다.

다음 해결자는 허용된 로컬 디렉터리에서만 연결된 리소스를 로드합니다. 네트워크 리소스와 허용된 디렉터리 외부 경로는 차단됩니다. 해결되지 않은 이미지 링크에 대해 선택적 대체 이미지가 반환됩니다.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // 이 해결자는 의도적으로 로컬 파일만 허용합니다.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // 이미지 리소스에 대해서만 대체 이미지를 사용합니다. 이미지 스트림을 반환
        // 누락된 폰트나 스타일시트에 대해서는 유효하지 않습니다.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **SVG 가져오기 중에 연결된 리소스 해결**

`assets/diagram.svg`에 다음과 같은 상대 참조가 포함되어 있다고 가정합니다:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

다음 C++ 예제는 SVG 파일 URI를 기본 URI로 전달하고 사용자 정의 해결자를 제공합니다. 해결자는 상대 이미지 링크를 절대 URI로 변환하고 Aspose.Slides가 SVG를 처리하는 동안 연결된 리소스를 포함하는 스트림을 반환합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// 기본 URI는 SVG 문서의 위치를 나타냅니다.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage는 소스 콘텐츠, 바이너리 데이터, 기본 URI 및 해결자를 노출합니다.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` 클래스는 또한 SVG 데이터를 바이트 배열이나 스트림으로 받아들이는 오버로드와 외부 리소스 해결자 및 기본 URI를 함께 사용할 수 있습니다.

{{% alert title="Important" color="warning" %}}
리소스 해결자는 Aspose.Slides가 SVG를 처리 및 렌더링하는 동안 외부 리소스를 사용할 수 있게 합니다. 원본 SVG 마크업을 수정하거나 해결된 리소스를 자동으로 삽입하지는 않습니다.

`ISvgImage`가 프레젠테이션 이미지 컬렉션에 추가될 때 PPTX 파일은 원본 SVG 표현과 래스터 대체 이미지를 모두 포함할 수 있습니다. 연결된 리소스는 생성된 대체 이미지에 나타날 수 있지만 `images/photo.png`와 같은 상대 링크는 저장된 SVG에 그대로 유지됩니다. 네이티브 SVG 표현을 렌더링하는 애플리케이션은 원본 외부 리소스를 사용할 수 없을 경우 해당 연결된 콘텐츠를 생략할 수 있습니다.
{{% /alert %}}

### **휴대용 SVG 그림 만들기**

외부 파일에 의존하지 않는 SVG 그림을 만들려면 `SvgImage`를 생성하기 전에 SVG를 자체 포함형으로 만들어야 합니다. 예를 들어, 연결된 이미지 URL을 이미지 데이터를 포함하는 `data:` URI로 교체합니다:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

필요한 모든 리소스가 SVG 콘텐츠에 삽입된 후 `SvgImage`를 생성하고 프레젠테이션 이미지 컬렉션에 추가한 다음 이전 예제와 같이 그림 프레임에 삽입합니다.

### **누락되거나 차단된 리소스 처리**

`ResolveUri`에서 리소스 URI가 유효하지 않거나 금지되었거나 해결할 수 없을 때 null 문자열을 반환하십시오. `GetEntity`에서 리소스를 읽을 수 없을 때 `nullptr`을 반환하십시오. 가능한 경우 Aspose.Slides는 해당 리소스 없이도 SVG 처리를 계속합니다.

누락된 리소스에 대해 대체 스트림을 반환할 수 있지만, 해당 스트림의 콘텐츠는 요청된 리소스 유형과 호환되어야 합니다. 예를 들어, 누락된 이미지에 대해서만 이미지 스트림을 반환하고 폰트나 스타일시트에 대해서는 반환하지 않도록 하십시오.

{{% alert title="Security" color="warning" %}}
신뢰할 수 없는 SVG 파일에서 임의의 파일 경로나 무제한 네트워크 URL을 해결하지 마십시오. 허용된 스킴, 디렉터리 및 호스트를 제한하십시오. 네트워크 리소스의 경우 연결 시간 제한, 응답 크기 제한 및 콘텐츠 검증도 적용하십시오.
{{% /alert %}}

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 SVG를 도형 집합으로 변환할 수 있으며, 이는 PowerPoint의 해당 기능과 유사합니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 인터페이스의 [AddGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 메서드 오버로드가 제공하며, 첫 번째 매개변수로 [ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/) 객체를 받습니다.

다음 C++ 샘플 코드는 이 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// 소스 SVG 파일 이름
auto svgFileName = System::String(u"sample.svg");

// 출력 프레젠테이션 파일 이름
auto outPptxPath = System::String(u"presentation.pptx");

// 새 프레젠테이션 생성
auto presentation = System::MakeObject<Presentation>();

// SVG 파일 내용을 읽기
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage 객체 생성
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// 슬라이드 크기 가져오기
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 스케일링
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 프레젠테이션을 PPTX 형식으로 저장
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **이미지를 EMF로 슬라이드에 추가**

Aspose.Slides for C++를 사용하면 Aspose.Cells와 함께 Excel 워크시트에서 EMF 이미지를 생성하고 이를 프레젠테이션 슬라이드에 추가할 수 있습니다. 

다음 C++ 샘플 코드는 이를 수행하는 방법을 보여줍니다:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++는 해당 타입을 사용하기 전에 시작되어야 합니다.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// 워크시트를 EMF 형식으로 렌더링합니다.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells는 렌더링된 페이지를 버퍼로 반환하고, Aspose.Slides는 이를 이미지로 추가합니다.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides는 슬라이드 도형에서 사용되는 이미지를 포함하여 프레젠테이션의 이미지 컬렉션에 저장된 이미지를 교체할 수 있게 해줍니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체할 수 있습니다.

다음 단계를 따르십시오:

1. 이미지를 포함한 프레젠테이션 파일을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스로 로드합니다.
2. 파일에서 새 이미지를 로드하여 바이트 배열에 저장합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 방법에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체로 로드한 다음 해당 객체로 대상 이미지를 교체합니다.
5. 세 번째 방법에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 첫 번째 방법.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 두 번째 방법.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 세 번째 방법.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 프레젠테이션을 파일에 저장합니다.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고 GIF를 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

**삽입 후에도 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 표시 방식은 슬라이드에서 [picture](/slides/ko/cpp/picture-frame/)가 어떻게 확대/축소되는지와 저장 시 적용된 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇입니까?**

마스터 슬라이드나 레이아웃에 로고를 배치하고 프레젠테이션의 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있습니까?**

예. SVG를 도형 그룹으로 변환하면 개별 부분을 표준 도형 속성으로 편집할 수 있게 됩니다.

**여러 슬라이드에 한 번에 그림을 배경으로 설정하려면 어떻게 해야 합니까?**

마스터 슬라이드나 해당 레이아웃에서 이미지를 배경으로 지정하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일이 너무 커지는 것을 어떻게 방지할 수 있습니까?**

중복된 이미지 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 가능한 경우 마스터에 반복 그래픽을 배치합니다.