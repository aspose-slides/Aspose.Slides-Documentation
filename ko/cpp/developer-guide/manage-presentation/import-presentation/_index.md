---
title: PDF 또는 HTML에서 C++로 프레젠테이션 가져오기
linktitle: 프레젠테이션 가져오기
type: docs
weight: 60
url: /ko/cpp/import-presentation/
keywords:
- 프레젠테이션 가져오기
- 슬라이드 가져오기
- PDF 가져오기
- HTML 가져오기
- PDF를 프레젠테이션으로
- PDF를 PPT로
- PDF를 PPTX로
- PDF를 ODP로
- HTML을 프레젠테이션으로
- HTML을 PPT로
- HTML을 PPTX로
- HTML을 ODP로
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides와 함께 C++에서 PDF 및 HTML 문서를 PowerPoint와 OpenDocument 프레젠테이션으로 손쉽게 가져와 원활하고 고성능 슬라이드 처리를 구현합니다."
---
## **소개**

[**Aspose.Slides for C++**](https://products.aspose.com/slides/ko/cpp/)를 사용하면 다른 형식의 파일에서 프레젠테이션을 가져올 수 있습니다. Aspose.Slides는 PDF, HTML 문서 등에서 프레젠테이션을 가져올 수 있도록 [SlideCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.slide_collection) 클래스를 제공합니다.

## **PDF에서 PowerPoint 가져오기**

이 경우 PDF를 PowerPoint 프레젠테이션으로 변환할 수 있습니다.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 프레젠테이션 클래스의 객체를 인스턴스화합니다.  
2. PDF 파일을 전달하여 [AddFromPdf()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) 메서드를 호출합니다.  
3. PowerPoint 형식으로 파일을 저장하기 위해 [Save()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 메서드를 사용합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="팁" color="info" %}} 

**Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 확인해 보세요. 이 앱은 여기에서 설명한 프로세스의 실시간 구현입니다. 

{{% /alert %}} 

## **HTML에서 PowerPoint 가져오기**

이 경우 HTML 문서를 PowerPoint 프레젠테이션으로 변환할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.  
2. HTML 파일을 전달하여 [AddFromHtml()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) 메서드를 호출합니다.  
3. PowerPoint 형식으로 파일을 저장하기 위해 [Save()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 메서드를 사용합니다.

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="참고" color="warning" %}} 

Aspose.Slides를 사용하여 HTML을 다른 인기 파일 형식으로 변환할 수도 있습니다: 

* [HTML을 이미지로](https://products.aspose.com/slides/ko/cpp/conversion/html-to-image/)  
* [HTML을 JPG로](https://products.aspose.com/slides/ko/cpp/conversion/html-to-jpg/)  
* [HTML을 XML로](https://products.aspose.com/slides/ko/cpp/conversion/html-to-xml/)  
* [HTML을 TIFF로](https://products.aspose.com/slides/ko/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### PDF를 가져올 때 표가 보존되며, 감지를 개선할 수 있나요?

표는 가져오는 동안 감지될 수 있습니다; [PdfImportOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/pdfimportoptions/)에는 표 인식을 가능하게 하는 [set_DetectTables](https://reference.aspose.com/slides/ko/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) 메서드가 포함되어 있습니다. 효과는 PDF의 구조에 따라 달라집니다.