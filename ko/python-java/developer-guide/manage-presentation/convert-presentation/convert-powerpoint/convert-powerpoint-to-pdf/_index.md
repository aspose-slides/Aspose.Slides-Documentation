---
title: "Python을 통한 Java에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]"
linktitle: "PowerPoint를 PDF로"
type: docs
weight: 40
url: /ko/python-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint 변환"
- "프레젠테이션 변환"
- "PowerPoint를 PDF로"
- "프레젠테이션을 PDF로"
- "PPT를 PDF로"
- "PPT를 PDF로 변환"
- "PPTX를 PDF로"
- "PPTX를 PDF로 변환"
- "PowerPoint를 PDF로 저장"
- "PPT를 PDF로 저장"
- "PPTX를 PDF로 저장"
- "PPT를 PDF로 내보내기"
- "PPTX를 PDF로 내보내기"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides를 사용하여 Python을 통한 Java에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

Python을 통한 Java에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션 레이아웃과 서식 보존이 포함됩니다. 이 가이드에서는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨김 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환 및 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint에서 PDF 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스에 전달한 다음 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드를 사용해 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java은 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **참고** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 거의 일치하도록 합니다. 변환 시 요소와 속성이 정확하게 렌더링됩니다(예: 

* 이미지
* 텍스트 상자와 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표)

## **PowerPoint를 PDF로 변환**

표준 변환은 기본 PDF 내보내기 설정을 사용합니다. 이미지 품질, 페이지 내용 또는 PDF 규정 준수를 제어해야 할 경우 사용자 지정 옵션을 사용하십시오.

예제를 실행하기 전에 [Aspose.Slides for Python via Java](/slides/ko/python-java/installation/)와 호환되는 Java 런타임을 설치하십시오. 각 예제는 현재 작업 디렉터리에서 `presentation.pptx` 파일을 읽으며, 이를 PPT, PPTX 또는 ODP 파일로 교체하십시오. Python 프로세스당 JVM은 한 번만 시작됩니다.

다음 코드는 프레젠테이션을 PDF로 변환합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose는 무료 온라인 **PowerPoint to PDF 변환기**(https://products.aspose.app/slides/ko/conversion/ppt-to-pdf)를 제공하며, 여기서 프레젠테이션을 PDF로 변환하는 과정을 직접 시험해 볼 수 있습니다.
{{% /alert %}}

## **옵션을 사용하여 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스의 속성을 통해 결과 PDF를 사용자 지정하고, 비밀번호로 PDF를 잠그며, 변환 프로세스 진행 방식을 지정할 수 있는 사용자 지정 옵션을 제공합니다.

### **사용자 지정 옵션으로 PowerPoint를 PDF로 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지 품질, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 코드 예제는 여러 사용자 지정 옵션을 사용해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **숨김 슬라이드를 포함해 PowerPoint를 PDF로 변환**

프레젠테이션에 숨김 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 메서드를 사용해 숨김 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

다음 코드는 숨김 슬라이드가 포함된 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **비밀번호가 보호된 PDF로 PowerPoint 변환**

다음 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스의 보호 매개변수를 사용해 비밀번호가 보호된 PDF로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveoptions/#setWarningCallback) 메서드를 제공하여 프레젠테이션을 PDF로 변환하는 동안 발생하는 글꼴 대체를 감지할 수 있습니다.

Java API에서 경고 콜백을 받기 위해 JPype 프록시를 사용하십시오. Java 설명 문자열을 Python 문자열로 변환한 후 접두사를 확인합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
렌더링 과정에서 글꼴 대체에 대한 콜백을 받는 방법에 대한 자세한 내용은 [Getting Warning Callbacks for Font Substitution](/slides/ko/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)를 참조하십시오.

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/python-java/font-substitution/) 문서를 참고하십시오.
{{% /alert %}}

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

[Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드에 전달되는 슬라이드 번호는 1부터 시작합니다. 이 예제는 슬라이드 1과 3이 모두 존재할 때 해당 슬라이드만 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

이 예제는 페이지 크기 612×792 포인트(US Letter)로 첫 번째 슬라이드를 내보냅니다. 지정된 크기로 새 프레젠테이션에 슬라이드를 복제합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 코드는 노트가 포함된 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF를 위한 접근성 및 규정 준수 표준**

접근 가능한 PDF를 만들 때는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)를 참고하십시오. [PdfOptions.setCompliance](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setCompliance) 메서드를 사용해 출력 표준을 선택할 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **참고:** PDF/UA로 내보낼 경우 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복잡한 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 그림에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 배치로 PDF로 변환하는 기능을 지원합니다. 파일을 반복하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

예. 변환 과정에서 비밀번호와 접근 권한을 설정하려면 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스를 사용하십시오.

**숨김 슬라이드를 PDF에 포함하려면 어떻게 하나요?**

숨김 슬라이드를 결과 PDF에 포함하려면 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 메서드를 사용하십시오.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setJpegQuality) 및 [setSufficientResolution](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSufficientResolution)와 같은 메서드를 사용해 PDF에서 고품질 이미지를 보장할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 [various standards](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfcompliance/)를 포함해 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 PDF/A 규정 준수 표준에 맞는 PDF를 내보낼 수 있습니다. 필요에 맞는 표준을 선택하고 출력 결과를 검토하십시오.

## **추가 리소스**

- [Aspose.Slides for Python via Java Documentation](/slides/ko/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/ko/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ko/conversion)