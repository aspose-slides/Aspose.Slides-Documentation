---
title: Python에서 PPT 및 PPTX를 PDF로 변환 | 고급 옵션
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션
- PowerPoint를 PDF로
- PPT를 PDF로
- PPTX를 PDF로
- PowerPoint를 PDF로 저장
- 첨부 파일
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Aspose.Slides를 사용하여 Python에서 PPT, PPTX 및 ODP를 고품질이며 WCAG 준수 PDF로 변환하는 단계별 가이드—암호 보호, 슬라이드 선택 및 이미지 품질 제어를 포함합니다."
showReadingTime: true
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP)을 Python에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 기기 간 호환성 보장 및 프레젠테이션의 레이아웃과 서식을 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 문서에 암호 보호 적용, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 그리고 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

Python에서 프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스에 인수로 전달한 다음 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 메서드를 사용해 프레젠테이션을 PDF로 저장하면 됩니다. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python은 출력 문서에 API 정보와 버전 번호를 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides for Python은 Application 필드에 ‘*Aspose.Slides*’ 값을, PDF Producer 필드에 ‘*Aspose.Slides v XX.XX*’ 형태의 값을 채웁니다. **참고**: Aspose.Slides for Python에 이 정보를 변경하거나 제거하도록 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보낼 때 결과 PDF의 내용이 원본 프레젠테이션과 거의 일치하도록 보장합니다. 변환 시 정확하게 렌더링되는 요소 및 속성은 다음과 같습니다.

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용해 모든 표시 슬라이드를 PDF로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose는 무료 온라인 [**PowerPoint PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하며, 여기서 프레젠테이션을 PDF로 변환하는 과정을 시연합니다. 여기서 설명한 절차를 실제로 확인하려면 변환기를 사용해 테스트해 보세요.
{{% /alert %}}

## **옵션을 사용한 PowerPoint PDF 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 클래스 아래에 있는 사용자 지정 옵션—속성—을 제공하여 변환 과정에서 생성되는 PDF를 맞춤 설정하고, PDF에 암호를 걸며, 변환 프로세스의 동작 방식을 지정할 수 있습니다.

### **사용자 지정 옵션을 사용한 PowerPoint PDF 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지의 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 지정할 수 있습니다.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PDF 첨부 파일로 OLE 파일 임베드 유지**

프레젠테이션에 임베드된 Excel 워크북이 포함된 경우, PDF 수신자가 슬라이드와 함께 워크북 데이터에도 접근할 수 있도록 할 수 있습니다. [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/)를 `True`로 설정하면 임베드된 OLE 파일이 결과 PDF에 첨부 파일로 보존됩니다.

기본값은 `False`이며, 이 경우 OLE 객체의 미리보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 임베드된 파일은 첨부되지 않습니다. 옵션을 `True`로 설정하면 파일 데이터도 추가로 포함됩니다. 미리보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 파일을 별도로 열거나 저장할 수 있습니다. OLE 객체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되지는 않습니다.

다음 예제는 이미 임베드된 Excel 워크북을 포함하고 있는 프레젠테이션을 로드하고 워크북을 첨부한 상태로 PDF로 내보냅니다.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

결과를 확인하려면:

1. 파일 첨부 기능을 지원하는 PDF 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하는 경우 직접 엽니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베드 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides 고유의 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지는 않습니다.
{{% /alert %}}

### **숨겨진 슬라이드 포함한 PowerPoint PDF 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 클래스의 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 속성을 사용해 숨겨진 슬라이드를 결과 PDF의 페이지로 포함하도록 Aspose.Slides에 지시할 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **암호 보호된 PDF로 PowerPoint 변환**

다음 예제는 열려면 `password` 암호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며 고품질 인쇄도 포함합니다.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택해 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에 최소 세 개의 슬라이드가 있어야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 612 × 792 포인트(8.5 × 11 인치) 슬라이드 크기를 가진 새 프레젠테이션에 복사합니다. 슬라이드 내용을 맞게 스케일링하고 단일 슬라이드를 PDF로 내보냅니다.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 새 프레젠테이션이 생성될 때 만든 빈 슬라이드를 제거합니다.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보낼 때 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하세요.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있게 해줍니다. 다음 표준 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 Python 코드 예제는 서로 다른 규정 준수 표준에 따라 여러 PDF를 얻는 PowerPoint‑to‑PDF 변환 작업을 보여줍니다.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides의 PDF 변환 기능은 PDF를 가장 많이 사용되는 파일 형식으로 변환할 수 있습니다. 다음 변환을 수행할 수 있습니다: [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), 그리고 [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 변환. 또한 [PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) 등 특수 형식으로의 변환도 지원됩니다.
{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에 대해서만 제공됩니다.

## **FAQ**

**Aspose.Slides for Python이 PDF에서 애플리케이션 정보를 제거할 수 있나요?**

아니요, Aspose.Slides for Python은 출력 PDF에 API 정보와 버전 번호를 자동으로 포함합니다. 이 정보는 수정하거나 제거할 수 없습니다.

**PDF 변환 시 특정 슬라이드만 포함하려면 어떻게 하나요?**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 메서드에 슬라이드 위치 배열을 전달하여 변환할 슬라이드 인덱스를 지정할 수 있습니다.

**변환 과정에서 PDF에 암호를 설정할 수 있나요?**

예, PDF를 저장하기 전에 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 클래스를 사용해 비밀번호와 접근 권한을 정의할 수 있습니다.

**Aspose.Slides가 PDF를 다른 형식으로 변환하는 것을 지원하나요?**

예, Aspose.Slides는 PDF를 HTML, 이미지 형식(JPG, PNG), SVG, TIFF 및 XML 등으로 변환하는 것을 지원합니다.

**PDF가 접근성 표준을 준수하도록 하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)의 [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) 속성을 `PDF_A1A`, `PDF_A1B` 또는 `PDF_UA`와 같은 표준으로 설정하면 접근성 가이드라인을 만족하는 PDF를 생성할 수 있습니다.

**숨겨진 슬라이드를 PDF 출력에 포함할 수 있나요?**

예, [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)의 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 속성을 `True`로 설정하면 숨겨진 슬라이드가 PDF에 포함됩니다.

**이미지 품질 및 해상도를 어떻게 조정하나요?**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)의 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 및 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 속성을 사용해 결과 PDF의 이미지 품질과 해상도를 제어할 수 있습니다.

**Aspose.Slides가 글꼴 대체를 자동으로 처리하나요?**

Aspose.Slides는 변환 중에 글꼴 대체를 감지하며, 현재 제한된 `warning_callback` 속성을 사용해 이를 처리할 수 있습니다.

## **추가 리소스**

- [Aspose.Slides for Python via .NET Documentation](/slides/ko/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)