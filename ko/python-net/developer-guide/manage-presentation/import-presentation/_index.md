---
title: Python으로 프레젠테이션 가져오기
linktitle: 프레젠테이션 가져오기
type: docs
weight: 60
url: /ko/python-net/import-presentation/
keywords:
- PowerPoint 가져오기
- 프레젠테이션 가져오기
- 슬라이드 가져오기
- PDF에서 프레젠테이션으로
- PDF에서 PPT로
- PDF에서 PPTX로
- PDF에서 ODP로
- HTML에서 프레젠테이션으로
- HTML에서 PPT로
- HTML에서 PPTX로
- HTML에서 ODP로
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PDF 및 HTML 문서를 PowerPoint 및 OpenDocument 프레젠테이션으로 손쉽게 가져와 원활하고 고성능 슬라이드 처리를 수행합니다."
---
## **소개**

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/ko/python-net/)를 사용하면 다른 파일 형식에서 프레젠테이션으로 콘텐츠를 가져올 수 있습니다. [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/) 클래스는 PDF, HTML 및 기타 소스에서 슬라이드를 가져오는 메서드를 제공합니다.

## **PDF를 프레젠테이션으로 변환**

이 섹션에서는 Aspose.Slides를 사용하여 PDF를 프레젠테이션으로 변환하는 방법을 보여줍니다. PDF를 가져오고 페이지를 슬라이드로 변환한 다음 결과를 PPTX 파일로 저장하는 과정을 단계별로 안내합니다.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. [add_from_pdf](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_from_pdf/) 메서드를 호출하고 PDF 파일을 전달합니다.  
3. [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드를 사용해 프레젠테이션을 PowerPoint 형식으로 저장합니다.

다음 Python 예제는 PDF를 프레젠테이션으로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="팁" color="primary" %}}
Aspose가 제공하는 무료 [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 사용해 볼 수 있습니다. 이 앱은 여기서 설명한 프로세스의 실시간 구현 버전입니다.
{{% /alert %}}

## **HTML을 프레젠테이션으로 변환**

이 섹션에서는 Aspose.Slides를 사용하여 HTML 콘텐츠를 프레젠테이션으로 가져오는 방법을 보여줍니다. HTML을 로드하고 텍스트, 이미지 및 기본 서식이 보존된 슬라이드로 변환한 뒤 결과를 PPTX 파일로 저장하는 과정을 다룹니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. [add_from_html](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/add_from_html/) 메서드를 호출하고 HTML 파일을 전달합니다.  
3. [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드를 사용해 프레젠테이션을 PowerPoint 형식으로 저장합니다.

다음 Python 예제는 HTML을 프레젠테이션으로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**PDF를 가져올 때 표가 보존되며, 표 인식을 개선할 수 있나요?**

가져오는 동안 표를 감지할 수 있습니다. [PdfImportOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.importing/pdfimportoptions/)에 포함된 [detect_tables](https://reference.aspose.com/slides/ko/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) 매개변수를 사용하면 표 인식을 활성화할 수 있습니다. 효과는 PDF의 구조에 따라 달라집니다.

{{% alert title="참고" color="info" %}}
Aspose.Slides를 사용하면 HTML을 다음과 같은 다른 인기 파일 형식으로 변환할 수도 있습니다:

* [HTML to image](https://products.aspose.com/slides/ko/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/ko/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/ko/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/ko/python-net/conversion/html-to-tiff/)

{{% /alert %}}