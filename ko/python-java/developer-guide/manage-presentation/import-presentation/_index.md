---
title: Python via Java에서 PDF 또는 HTML로 프레젠테이션 가져오기
linktitle: 프레젠테이션 가져오기
type: docs
weight: 60
url: /ko/python-java/import-presentation/
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
- 파워포인트
- 오픈문서
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java에서 PDF 및 HTML 콘텐츠를 PowerPoint 프레젠테이션으로 가져오고 결과를 PPTX 파일로 저장하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for Python via Java는 Microsoft PowerPoint 없이 PDF 페이지나 HTML 콘텐츠를 PowerPoint 슬라이드로 변환할 수 있습니다. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 클래스는 가져온 콘텐츠를 프레젠테이션에 추가하기 위해 [addFromPdf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromPdf)와 [addFromHtml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromHtml)를 제공합니다.

HTML 배치를 보다 세밀하게 제어하려면, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertFromHtml)를 사용해 지정된 컬렉션 인덱스에 슬라이드를 삽입하거나 기존 슬라이드의 사용 가능한 공간에 채울 수 있습니다. 길이가 긴 HTML은 자동으로 추가 슬라이드에 페이지가 나뉘며, 소스는 문자열이나 스트림으로 제공될 수 있고, 외부 리소스는 기본 URI와 함께 [ExternalResourceResolver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/externalresourceresolver/)를 통해 로드될 수 있습니다. 반환된 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 배열은 영향을 받은 슬라이드와 새로 생성된 슬라이드를 식별합니다.

## **PDF에서 가져오기**

PDF 문서를 PowerPoint 프레젠테이션으로 변환하려면, 슬라이드 컬렉션에 내용을 가져온 뒤 결과를 PPTX 파일로 저장합니다.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 새 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 생성합니다.  
2. PDF 파일 경로와 함께 [addFromPdf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromPdf)를 호출합니다.  
3. [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx)를 사용해 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 호출하여 프레젠테이션을 PPTX 파일로 기록합니다.

다음 Python 예제는 PDF 문서를 가져와 생성된 슬라이드를 PowerPoint 프레젠테이션으로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

기본 빈 슬라이드가 프레젠테이션에 남아 있는 이유는 가져오기가 슬라이드를 추가하기 때문입니다. 가져온 페이지만 남기려면 가져오기 전에 [SlideCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#clear)로 슬라이드 컬렉션을 비워야 합니다.

[addFromPdf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromPdf) 메서드는 추가된 슬라이드를 반환하므로, 가져온 슬라이드만 별도로 처리할 때 유용합니다.

{{% alert title="팁" color="success" %}}
무료 [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 사용해 이 변환 워크플로우를 직접 체험해 보세요.
{{% /alert %}}

## **HTML에서 가져오기**

Aspose.Slides는 HTML 문서에서도 슬라이드를 생성할 수 있습니다. 소스는 HTML 텍스트 또는 스트림으로 제공될 수 있습니다. 다음 단계에서는 파일 스트림을 사용합니다.

1. 새 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 생성합니다.  
2. HTML 파일을 읽기 전용으로 열고 스트림을 [addFromHtml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromHtml)에 전달합니다.  
3. [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx)를 사용해 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 호출하여 결과를 PPTX 파일로 기록합니다.

다음 Python 예제는 HTML 문서를 가져와 생성된 슬라이드를 PowerPoint 프레젠테이션으로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML 콘텐츠 삽입**

HTML로 생성된 슬라이드를 추가 대신 특정 위치에 배치해야 할 경우 [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertFromHtml)를 사용합니다. 인덱스는 0부터 시작하며, 가져오기가 시작되는 위치를 지정합니다.

`useSlideWithIndexAsStart` 인자는 가져오기 동작을 다음과 같이 제어합니다:

- `False`이면, 지정된 인덱스에 새 슬라이드를 만들고 이후 슬라이드를 오른쪽으로 이동시킵니다.  
- `True`이면, 해당 인덱스에 있는 기존 슬라이드의 사용 가능한 공간에 콘텐츠를 배치합니다. HTML이 공간에 맞지 않으면 Aspose.Slides가 자동으로 페이지를 나누고 시작 슬라이드 바로 뒤에 추가 슬라이드를 삽입합니다.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertFromHtml)는 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 객체 배열을 반환합니다. 삽입이 새 슬라이드에서 시작되면 반환된 모든 항목이 새로 생성된 슬라이드이며, 기존 슬라이드가 시작점으로 사용될 경우 해당 슬라이드와 이후에 추가된 오버플로 슬라이드가 포함됩니다. 프레젠테이션 슬라이드 수를 계산하는 대신 이 배열을 검사하여 영향을 받은 범위를 확인할 수 있습니다.

### **새 슬라이드로 HTML 삽입**

다음 예제는 HTML 문자열을 제공하고 컬렉션 인덱스 `1`에 생성된 슬라이드를 삽입합니다. `False`를 전달하면 기존 슬라이드는 위치가 이동될 뿐 내용은 변경되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **기존 슬라이드에서 시작**

다음 예제는 스트림을 통해 HTML을 제공하며, 기존 템플릿 슬라이드에 헤더 도형을 유지하고, 차지된 영역 아래에서 가져오기를 시작해 긴 본문을 새 슬라이드로 이어갑니다.

HTML에는 상대 이미지 URL도 포함되어 있습니다. [ExternalResourceResolver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/externalresourceresolver/)가 리소스를 가져오며, base URI는 `images/logo.png`를 어떻게 해석할지 알려줍니다. 이 예제에서는 해당 파일이 `html-assets/images/logo.png`에 존재한다고 가정합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="경고" color="warning" %}}
제한되지 않은 외부 리소스 해석기는 HTML에 참조된 로컬 또는 네트워크 리소스를 읽을 수 있습니다. 신뢰할 수 없는 입력에 대해서는 허용된 스킴, 디렉터리 및 호스트 목록을 기반으로 리소스 URL을 검증 및 정화한 후 HTML을 가져오세요.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 PDF를 가져올 때 표를 감지할 수 있나요?**

네. [PdfImportOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfimportoptions/) 객체를 생성하고, `True`와 함께 [setDetectTables](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfimportoptions/#setDetectTables)를 호출한 뒤, 옵션을 [addFromPdf](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addFromPdf)에 전달합니다. 표 인식 품질은 원본 PDF의 구조와 복잡도에 따라 달라집니다.

{{% alert title="참고" color="info" %}}
HTML을 가져온 후에는 슬라이드를 [images](/slides/ko/python-java/convert-powerpoint-to-png/), [TIFF](/slides/ko/python-java/convert-powerpoint-to-tiff/), 또는 [SVG](/slides/ko/python-java/render-slide-as-svg/)로 내보낼 수도 있습니다.
{{% /alert %}}