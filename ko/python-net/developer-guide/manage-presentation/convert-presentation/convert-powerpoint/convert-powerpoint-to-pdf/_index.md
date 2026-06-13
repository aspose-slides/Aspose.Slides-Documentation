---
title: Python에서 PPT 및 PPTX를 PDF로 변환 | 고급 옵션
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/python-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션
- PowerPoint를 PDF로
- PPT를 PDF로
- PPTX를 PDF로
- PowerPoint를 PDF로 저장
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Python과 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP를 고품질이며 WCAG에 준수하는 PDF로 변환하는 단계별 가이드—비밀번호 보호, 슬라이드 선택 및 이미지 품질 제어 포함."
showReadingTime: true
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP)을 Python에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 서로 다른 장치 간 호환성을 보장하고 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 문서에 암호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 그리고 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

Python에서 프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스의 인수로 전달한 다음 [Save](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/#methods) 메서드를 사용하여 프레젠테이션을 PDF로 저장하면 됩니다. [Presentation](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [Save](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides/presentation/#methods) 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python은 출력 문서에 API 정보와 버전 번호를 직접 기록합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides for Python은 Application 필드에 '*Aspose.Slides*' 값을, PDF Producer 필드에 '*Aspose.Slides v XX.XX*' 형식의 값을 채웁니다. **참고** 이 정보는 Aspose.Slides for Python에서 변경하거나 제거하도록 지정할 수 없습니다.

{{% /alert %}}

Aspose.Slides는 다음과 같이 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내면서 결과 PDF의 내용이 원본 프레젠테이션과 가깝게 일치하도록 보장합니다. 변환 과정에서 요소와 속성이 정확하게 렌더링되며, 포함되는 항목은 다음과 같습니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint PDF 변환 작업은 기본 옵션을 사용하여 실행됩니다. 이 경우 Aspose.Slides는 최적 설정과 최고 품질 수준을 적용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다. 다음 Python 코드는 PowerPoint를 PDF로 변환하는 방법을 보여줍니다:

_Steps: PowerPoint를 PDF로 변환하는 단계 (Python)_

다음 샘플 코드는 Python via .NET을 사용한 변환을 설명합니다
- <a name="python-net-powerpoint-to-pdf"><strong>단계: Python via .NET를 사용하여 PowerPoint를 PDF로 변환</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>단계: Python via .NET를 사용하여 PPT를 PDF로 변환</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>단계: Python via .NET를 사용하여 PPTX를 PDF로 변환</a></strong>
- <a name="python-net-odp-to-pdf"><strong>단계: Python via .NET를 사용하여 ODP를 PDF로 변환</a></strong>
- <a name="python-net-odp-to-pdf"><strong>단계: Python via .NET를 사용하여 PPS를 PDF로 변환</a></strong>

_코드 단계:_

- [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 PowerPoint 파일을 제공합니다.
  * _.ppt_ 확장자를 사용하여 **PPT** 파일을 _Presentation_ 클래스에 로드합니다.
  * _.pptx_ 확장자를 사용하여 **PPTX** 파일을 _Presentation_ 클래스에 로드합니다.
  * _.odp_ 확장자를 사용하여 **ODP** 파일을 _Presentation_ 클래스에 로드합니다.
  * _.pps_ 확장자를 사용하여 **PPS** 파일을 _Presentation_ 클래스에 로드합니다.
- **Save** 메서드를 호출하고 **SaveFormat.PDF** 열거형을 사용하여 _Presentation_을 **PDF** 형식으로 저장합니다.

```python
import aspose.slides as slides

# PowerPoint 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = slides.Presentation("PowerPoint.ppt")

# 프레젠테이션을 PDF로 저장합니다
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose는 프레젠테이션을 PDF로 변환하는 과정을 보여주는 무료 온라인 **PowerPoint to PDF converter**를 제공합니다. 여기서 설명한 절차를 실제로 구현해 보려면 변환기를 사용하여 테스트할 수 있습니다.

{{% /alert %}}

## **옵션을 사용하여 PowerPoint를 PDF로 변환**

Aspose.Slides는 변환 과정에서 생성된 PDF를 사용자 정의하고, PDF에 암호를 설정하거나, 변환 흐름을 지정할 수 있도록 [PdfOptions](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides.export/pdfoptions/) 클래스의 속성을 제공합니다.

### **사용자 정의 옵션을 사용하여 PowerPoint를 PDF로 변환**

사용자 정의 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 지정할 수 있습니다.

다음 코드 예시는 여러 사용자 정의 옵션을 적용하여 PowerPoint 프레젠테이션을 PDF로 변환하는 작업을 보여줍니다:

```python
import aspose.slides as slides

# PdfOptions 클래스를 인스턴스화합니다
pdf_options = slides.export.PdfOptions()

# JPG 이미지의 품질을 설정합니다
pdf_options.jpeg_quality = 90

# 이미지의 DPI를 설정합니다
pdf_options.sufficient_resolution = 300

# 메타파일의 동작을 설정합니다
pdf_options.save_metafiles_as_png = True

# 텍스트 콘텐츠의 압축 수준을 설정합니다
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF 준수 모드를 정의합니다
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint 문서를 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation("PowerPoint.pptx") as presentation:
    # 프레젠테이션을 PDF 문서로 저장합니다
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **숨겨진 슬라이드가 포함된 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우, [PdfOptions](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides.export/pdfoptions/) 클래스의 `show_hidden_slides` 속성을 사용하여 Aspose.Slides가 숨겨진 슬라이드를 결과 PDF의 페이지로 포함하도록 지시할 수 있습니다.

다음 Python 코드는 숨겨진 슬라이드가 포함된 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PowerPoint 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions 클래스를 인스턴스화합니다
pdfOptions = slides.export.PdfOptions()

# 숨겨진 슬라이드를 추가합니다
pdfOptions.show_hidden_slides = True

# 프레젠테이션을 PDF로 저장합니다
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **암호 보호된 PDF로 PowerPoint 변환**

다음 Python 코드는 [PdfOptions](https://docs.aspose.com/slides/ko/python-net/api-reference/aspose.slides.export/pdfoptions/) 클래스의 보호 매개변수를 사용하여 암호 보호된 PDF로 PowerPoint를 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PowerPoint 파일을 나타내는 Presentation 객체를 인스턴스화합니다
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions 클래스를 인스턴스화합니다
pdfOptions = slides.export.PdfOptions()

# PDF 비밀번호와 접근 권한을 설정합니다
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# 프레젠테이션을 PDF로 저장합니다
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint에서 선택한 슬라이드만 PDF로 변환**

다음 Python 코드는 PowerPoint 프레젠테이션의 특정 슬라이드만 PDF로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PowerPoint 파일을 나타내는 Presentation 객체를 인스턴스화합니다
presentation = slides.Presentation("PowerPoint.pptx")

# 슬라이드 위치 배열을 설정합니다
slides_array = [ 1, 3 ]

# 프레젠테이션을 PDF로 저장합니다
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 Python 코드는 슬라이드 크기가 지정된 PowerPoint를 PDF로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 조정된 슬라이드 크기로 새 프레젠테이션을 생성합니다.
    with slides.Presentation() as resized_presentation:

        # 사용자 정의 슬라이드 크기를 설정합니다.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 원본 프레젠테이션에서 첫 번째 슬라이드를 복제합니다.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 조정된 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 Python 코드는 노트 슬라이드가 포함된 PowerPoint를 PDF로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PowerPoint 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 프레젠테이션을 PDF 노트로 저장합니다
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있도록 지원합니다. 다음 규정 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 Python 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint to PDF 변환 작업을 시연합니다:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides의 PDF 변환 기능은 PDF를 가장 인기 있는 파일 형식으로 변환할 수 있도록 확장됩니다. [PDF to HTML](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 [PDF to SVG](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/ko/python-net/conversion/pdf-to-xml/) 같은 특수 형식으로의 변환도 지원됩니다.

{{% /alert %}}

> **참고:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**Aspose.Slides for Python이 PDF에서 애플리케이션 정보를 제거할 수 있나요?**

아니요, Aspose.Slides for Python은 출력 PDF에 API 정보와 버전 번호를 자동으로 포함합니다. 이 정보는 수정하거나 제거할 수 없습니다.

**PDF 변환에 포함할 슬라이드를 어떻게 지정하나요?**

`save` 메서드에 슬라이드 위치 배열을 전달하여 변환하려는 슬라이드 인덱스를 지정할 수 있습니다.

**변환 중에 PDF에 암호를 설정할 수 있나요?**

예, PDF로 저장하기 전에 `PdfOptions` 클래스를 사용하여 비밀번호와 액세스 권한을 설정할 수 있습니다.

**Aspose.Slides가 PDF를 다른 형식으로 변환하는 것을 지원하나요?**

예, Aspose.Slides는 PDF를 HTML, 이미지 형식(JPG, PNG), SVG, TIFF 및 XML 등으로 변환하는 것을 지원합니다.

**PDF가 접근성 표준을 준수하도록 하려면 어떻게 해야 하나요?**

`PdfOptions`의 `compliance` 속성을 `PDF_A1A`, `PDF_A1B` 또는 `PDF_UA`와 같은 표준으로 설정하면 접근성 가이드라인을 만족하는 PDF를 만들 수 있습니다.

**숨겨진 슬라이드를 PDF에 포함할 수 있나요?**

예, `PdfOptions`에서 `show_hidden_slides` 속성을 `True`로 설정하면 숨겨진 슬라이드가 PDF에 포함됩니다.

**변환 중 이미지 품질과 해상도를 어떻게 조정하나요?**

`PdfOptions`의 `jpeg_quality`와 `sufficient_resolution` 속성을 사용하여 결과 PDF의 이미지 품질과 해상도를 제어할 수 있습니다.

**Aspose.Slides가 글꼴 대체를 자동으로 처리하나요?**

Aspose.Slides는 변환 중 글꼴 대체를 감지하며, 현재 제한적인 `SaveOptions`의 `warning_callback` 속성을 통해 이를 처리할 수 있습니다.

## **추가 자료**

- [Aspose.Slides for .NET 문서](https://docs.aspose.com/slides/ko/python-net/)
- [Aspose.Slides API 레퍼런스](https://reference.aspose.com/slides/ko/python-net/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/ko/conversion)