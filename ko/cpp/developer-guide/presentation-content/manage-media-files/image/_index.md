---
title: C++를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/cpp/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 연결 이미지
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- SVG를 도형으로 변환
- 외부 SVG 리소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터 및 SVG 이미지를 추가, 재사용, 연결, 교체 및 관리하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for C++는 이미지를 다루는 여러 방법을 제공하며, 각각은 다른 목적을 가집니다. 이미지를 프레젠테이션에 저장하거나, 그림 프레임에 표시하거나, 슬라이드 배경으로 사용하거나, 외부 이미지에 링크하거나, 공유 이미지 리소스를 교체하거나, SVG 콘텐츠를 편집 가능 형상으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전반에 걸친 사용 방법에 초점을 맞춥니다. 개별 그림 프레임에 적용되는 자르기, 투명도, 효과, 스트레칭 및 기타 서식에 대해서는 [그림 프레임](/slides/ko/cpp/picture-frame/)을 참조하십시오.

## **이미지 모델 이해**

다음 API 개념은 밀접하게 관련되어 있지만 서로 교환할 수는 없습니다:

- [프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/)은 프레젠테이션에서 사용하는 이미지 리소스를 저장합니다. 이미지 데이터를 추가하고 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 리소스를 얻으려면 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/)을 사용하십시오.
- [그림 프레임](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 슬라이드에 이미지 리소스를 배치하려면 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addpictureframe/)을 사용하십시오.
- 슬라이드 배경은 도형이 아니라 슬라이드 채우기의 일부로 이미지를 사용합니다. 따라서 그림 프레임처럼 동작하지 않습니다.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/replaceimage/)은 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용하고 있다면 모두 교체된 리소스를 사용하게 됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 생성됩니다. 변환 후에는 콘텐츠가 더 이상 하나의 그림 리소스로 관리되지 않습니다.

일반적인 작업 흐름은 다음과 같습니다: 이미지 데이터를 이미지 컬렉션에 추가하고, [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)을 받은 다음, 해당 리소스를 하나 이상의 그림 프레임이나 채우기에 사용합니다.

## **임베디드 이미지 추가**

로컬 이미지를 삽입하려면 파일을 읽고, 데이터를 이미지 컬렉션에 추가한 다음, 반환된 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 리소스를 사용하는 그림 프레임을 생성합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

이 방식으로 추가된 이미지는 프레젠테이션에 임베디드되므로 결과 파일이 원본 이미지 파일에 의존하지 않습니다.

### **웹에서 이미지 추가**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우, 바이트를 다운로드하고 프레젠테이션 이미지 컬렉션에 추가한 뒤, 로컬 이미지와 동일한 방식으로 반환된 이미지 리소스를 사용합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

신뢰할 수 없는 소스인 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증하십시오. 이미 다른 HTTP 클라이언트를 사용하고 있다면 해당 클라이언트로 이미지를 다운로드한 뒤, 결과 바이트 또는 스트림을 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/)에 전달할 수 있습니다.

## **슬라이드 간 이미지 재사용**

같은 이미지를 여러 번 사용할 필요가 있다면, 프레젠테이션에 한 번만 추가하고 추가 그림 프레임을 만들 때 반환된 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)을 재사용하십시오. 이렇게 하면 동일한 원본 데이터를 반복해서 로드하는 것을 방지하고, 공유 이미지 리소스와 사용 위치 간의 관계를 명확히 할 수 있습니다.

많은 슬라이드에 자동으로 표시되어야 하는 그래픽(예: 회사 로고)의 경우, 모든 슬라이드에 동일한 도형을 추가하는 대신 [슬라이드 마스터](/slides/ko/cpp/slide-master/)나 레이아웃에 그림 프레임을 배치하는 것을 고려하십시오.

## **이미지를 슬라이드 배경으로 사용**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 이는 그림이 슬라이드 배경 전체를 차지하고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [프레젠테이션 배경](/slides/ko/cpp/presentation-background/)을 참조하십시오.

## **임베디드 이미지와 연결 이미지**

임베디드 이미지와 연결 이미지에는 포터블성 및 파일 크기 측면에서 서로 다른 트레이드오프가 있습니다:

- **임베디드 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션이 독립형이 되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **연결 이미지:** 프레젠테이션이 외부 이미지에 대한 경로나 URL을 저장합니다. 이는 프레젠테이션 크기를 줄일 수 있지만, 외부 리소스가 열거나 렌더링될 때 접근 가능해야 합니다.

연결된 그림은 이미지 데이터를 임베디드하지 않고 [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidespicture/set_linkpathlong/)를 통해 외부 경로나 URL을 지정하여 만들 수 있습니다.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

외부 리소스에 안정적으로 접근할 수 있는 배포 환경인 경우에만 연결 이미지를 사용하십시오. 오프라인으로 작동하거나 시스템 간에 이동해야 하는 프레젠테이션의 경우, 임베디드 이미지가 일반적으로 더 안전합니다.

## **SVG 이미지 작업**

SVG는 벡터 포맷이므로 아이콘, 다이어그램 및 래스터 이미지와 달리 상세 손실 없이 확대/축소가 필요한 그래픽에 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로뿐만 아니라 편집 가능한 슬라이드 도형의 소스로도 지원합니다.

### **SVG를 이미지로 추가**

[SvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/svgimage/)을 생성하고 이미지 컬렉션에 추가한 뒤, 결과 이미지 리소스를 그림 프레임에 배치하십시오.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **외부 리소스를 포함하는 SVG 파일**

SVG는 외부 이미지, 스타일시트 또는 글꼴을 참조할 수 있습니다. 이러한 경우 [SvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/svgimage/)은 [IExternalResourceResolver](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/iexternalresourceresolver/)와 기본 URI를 받아들이는 생성자를 제공합니다. 이 리졸버는 상대 URI를 허용된 절대 URI로 매핑하고 요청된 리소스에 대한 스트림을 반환할 수 있습니다.

리졸버는 SVG 처리 중 외부 리소스를 사용할 수 있게 하지만, SVG 자체를 자체 포함 문서로 변환하지는 않습니다. SVG가 포터블해야 한다면, 예를 들어 연결된 이미지를 `data:` URI 로 삽입하는 등 필요한 리소스를 SVG에 직접 임베디드하십시오.

신뢰되지 않은 소스에서 SVG 파일이 들어오는 경우, 리졸버가 접근할 수 있는 스키마, 파일 위치 및 호스트를 제한하십시오. 네트워크 리졸버는 또한 타임아웃, 응답 크기 제한 및 콘텐츠 검증을 적용해야 합니다.

### **SVG를 편집 가능한 도형으로 변환**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 해당 PowerPoint 명령과 유사합니다.

![PowerPoint 팝업 메뉴](img_01_01.png)

[ISvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/)을 인수로 받는 [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addgroupshape/) 오버로드를 사용하여 변환을 수행하십시오.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

SVG의 개별 벡터 요소를 PowerPoint 도형으로 편집해야 할 때 SVG‑to‑shapes 변환을 사용하십시오. SVG를 단순히 표시만 하면 되는 경우 이미지를 그대로 사용하는 것이 더 간단하고 많은 개별 도형을 생성하는 것을 피할 수 있습니다.

## **기존 이미지 리소스 교체**

기존 이미지 리소스를 교체하려면 [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/replaceimage/)를 사용하십시오. 이는 로고와 같은 공유 그래픽을 교체할 때 특히 유용합니다.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용하고 있다면, 해당 리소스를 교체하면 모든 사용 위치가 업데이트됩니다. 하나의 그림 프레임만 변경해야 한다면 공유 리소스를 교체하지 말고 해당 프레임에 다른 이미지를 할당하십시오.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/replaceimage/)은 또한 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 또는 다른 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)을 인수로 받는 오버로드를 제공합니다.

## **실용적인 이미지 관리 가이드**

### **프레젠테이션 크기 제어**

큰 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 표시하려는 크기에 맞는 원본 이미지를 사용하고, 가능한 경우 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽을 중복 임베디드하지 않도록 하십시오.

이미 그림 프레임에 이미 배치된 래스터 사진의 경우, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/compressimage/)를 사용하여 선택된 해상도와 크롭 설정에 따라 이미지 데이터를 압축할 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 서식 작업은 [그림 프레임](/slides/ko/cpp/picture-frame/)을 참고하십시오.

### **임베디드와 연결 콘텐츠 선택**

임베디드는 모든 이미지 데이터를 파일에 포함시켜 프레젠테이션을 포터블하게 만들지만 파일 크기가 커집니다. 연결은 파일 크기를 줄일 수 있지만 외부 의존성을 도입합니다. 외부 의존성이 허용되고 안정적일 때만 링크를 사용하십시오.

### **공유 브랜딩 재사용**

반복되는 로고, 워터마크 또는 장식 그래픽은 하나의 이미지 리소스를 사용하고 재사용하십시오. 그래픽이 슬라이드 내용보다 프레젠테이션 디자인에 속한다면 마스터 또는 레이아웃에 배치하여 해당 슬라이드가 상속하도록 하십시오.

### **SVG 리소스 포터블 유지**

자체 포함된 SVG는 외부 파일이나 네트워크 리소스에 의존하는 SVG보다 이동 및 일관된 렌더링이 쉽습니다. 가능하면 SVG를 가져오기 전에 필요한 리소스를 임베디드하십시오. 개별 벡터 요소를 편집해야 할 때만 SVG를 도형으로 변환하십시오.

### **Aspose.Slides 이미지 API 사용**

C++ 이미지 작업 흐름에서는 이미지 객체가 필요할 때 Aspose.Slides [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 및 [Images](https://reference.aspose.com/slides/ko/cpp/aspose.slides/images/) API를 사용하고, 프레젠테이션 리소스로 이미지 데이터를 등록해야 할 때는 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/)를 사용하십시오. 컬렉션 오버로드는 바이트 배열 및 스트림도 지원하므로 파일, 네트워크 클라이언트, 데이터베이스 또는 기타 라이브러리에서 이미지 데이터를 가져올 때 유용합니다.

스프레드시트나 다른 제품에서 EMF 콘텐츠를 생성하는 것은 별도의 통합 작업이며 이 문서의 범위를 벗어납니다. 기존 WMF 또는 EMF 파일을 프레젠테이션에 삽입만 하면 되는 경우, 이미지 관리 워크플로에 두 번째 제품 의존성을 추가하지 말고 적절한 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/) 오버로드에 데이터를 전달하십시오.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇인가요?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 해당 리소스 중 하나를 표시하는 슬라이드 도형이며, 자르기 및 효과와 같은 그림 전용 서식을 제공합니다.

**같은 로고를 모든 곳에서 교체하려면 가장 좋은 방법은?**

이미 로고가 하나의 이미지 리소스로 공유되어 있다면 [IPPImage::ReplaceImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/replaceimage/)로 해당 리소스를 교체하십시오. 프레젠테이션 전체 브랜딩을 위해서는 마스터나 레이아웃에 로고를 배치하는 것도 중복 슬라이드 콘텐츠를 줄이는 방법입니다.

**연결된 이미지가 다른 컴퓨터에서 사라지는 이유는?**

연결된 그림은 외부 파일이나 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 연결된 이미지가 표시되지 않을 수 있습니다. 프레젠테이션이 자체 포함되어야 한다면 이미지를 임베디드하십시오.

**삽입된 SVG를 PowerPoint 도형으로 편집할 수 있나요?**

예. [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addgroupshape/)를 사용해 SVG를 변환하면 결과 그룹에 편집 가능한 슬라이드 도형이 포함됩니다.

**많은 이미지를 포함하는 프레젠테이션을 어떻게 작게 유지할 수 있나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절한 경우 래스터 사진을 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 두고, 외부 의존성이 허용될 때만 연결 이미지를 사용하십시오.