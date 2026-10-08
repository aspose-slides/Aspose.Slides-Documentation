---
title: Java에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PowerPoint를 PDF로
- 프레젠테이션을 PDF로
- PPT를 PDF로
- PPT를 PDF로 변환
- PPTX를 PDF로
- PPTX를 PDF로 변환
- PowerPoint를 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 첨부 파일
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 Java에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간의 호환성 확보와 프레젠테이션의 레이아웃 및 서식 보존이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 그리고 출력 문서에 규격 준수를 적용하는 방법을 설명합니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스의 인수로 전달한 다음 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하여 프레젠테이션을 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 노출합니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어, 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides는 다음과 같은 변환을 지원합니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드만 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내며, 결과 PDF가 원본 프레젠테이션과 거의 동일하게 매치되도록 합니다. 변환 시 정확히 렌더링되는 요소 및 속성에는 다음이 포함됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최고 품질 수준을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 모든 보이는 슬라이드를 기본 내보내기 설정으로 PDF에 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하며, 여기서 프레젠테이션‑to‑PDF 변환 프로세스를 시연합니다. 이 변환기를 사용하여 여기서 설명한 절차를 실시간으로 테스트할 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint‑to‑PDF 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래의 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 사용자 정의하고, PDF에 비밀번호를 설정하며, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 지정 옵션을 사용한 PowerPoint‑to‑PDF 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 설정 등을 정의할 수 있습니다.

다음 예제는 프레젠테이션을 PDF 1.5로 내보내며 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고 Flate 텍스트 압축을 사용합니다.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 워크북이 포함된 경우 PDF 수신자가 워크북 데이터를 액세스하고 슬라이드를 볼 수 있도록 할 수 있습니다. `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)를 호출하면 결과 PDF에 임베드된 OLE 파일을 첨부 파일로 보존합니다.

기본값은 `false`이며, 이 경우 OLE 객체의 미리 보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터가 추가로 포함됩니다. 미리 보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 임베드된 파일을 별도로 열거나 저장할 수 있습니다. OLE 객체가 PDF 페이지에서 인터랙티브한 Excel 워크시트로 변환되지는 않습니다.

다음 예제는 이미 임베드된 Excel 워크북을 포함하고 있는 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함하여 PDF로 내보냅니다.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

결과 확인 방법:

1. 파일 첨부를 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 검사하거나, 뷰어가 허용하는 경우 바로 엽니다. PDF 페이지의 미리 보기와 첨부 파일은 별개입니다.

{{% alert color="info" title="Note" %}}

PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베드 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에 특정된 제한이 아닙니다. 이 예제는 기본 PDF 준수 설정을 사용하며 PDF/A 내보내기는 시연하지 않습니다.

{{% /alert %}}

### **숨겨진 슬라이드를 포함한 PowerPoint‑to‑PDF 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **비밀번호로 보호된 PDF 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며, 열려면 `password` 비밀번호가 필요합니다. 액세스 권한은 인쇄를 허용하며 고품질 인쇄도 포함합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래의 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 사용 가능한 글꼴이 없을 때만 경고가 출력됩니다.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/java/font-substitution/) 문서를 참고하십시오.

{{% /alert %}} 

### **전용 굵은 글꼴이 없는 경우 처리**

프레젠테이션은 글꼴에 전용 굵은 스타일이 없더라도 굵게 서식을 적용할 수 있습니다. 이 경우 텍스트는 인공적인 굵게 처리(스레시스 증가)로 표시됩니다. PDF에서 해당 텍스트가 너무 무겁게 보이거나 기대와 다를 경우 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-)를 `true`와 함께 호출해 보십시오. 이 옵션은 PDF 내보내기 시 영향을 받는 텍스트를 비트맵으로 렌더링하여 특정 글꼴에 대한 표시를 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 두 개의 텍스트 상자가 있습니다: 하나는 일반 텍스트, 다른 하나는 전용 굵은 스타일이 없는 동일 글꼴에 굵은 서식을 적용했습니다. 다음 예제는 프레젠테이션을 로드하고 전용 굵은 글꼴이 없는 경우 래스터화를 활성화한 뒤 PDF로 내보냅니다:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

아래 미리 보기는 옵션 비활성화와 활성화된 경우의 결과를 보여줍니다. 이 예제에서 옵션이 비활성화된 경우 굵은 텍스트의 스트로크가 더 두껍습니다. 옵션을 활성화하면 스트로크가 얇아지고 일반 텍스트는 변하지 않습니다. 설정을 선택하기 전에 결과를 비교하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다: OCR 없이 텍스트를 선택, 복사 또는 검색할 수 없으며 800 % 확대 시 가장자리가 더 부드럽게 보입니다. 일반 텍스트는 여전히 검색 가능합니다. 옵션을 비활성화하면 두 문자열 모두 텍스트로 남습니다.

이 옵션은 전용 굵은 글꼴이 없는 경우 굵게 서식이 적용된 텍스트를 래스터화합니다. [Font substitution](/slides/ko/java/font-substitution/)은 원본 글꼴이 없을 때 다른 글꼴을 선택합니다.

## **선택한 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택하여 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션으로 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용을 맞게 스케일링하고 단일 슬라이드를 PDF로 내보냅니다.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 새 프레젠테이션이 생성될 때 생긴 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 뷰에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며, 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 접근성 및 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)와 호환되는 변환 절차를 사용할 수 있게 합니다. 다음과 같은 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 다양한 준수 표준에 따라 여러 개의 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 변환을 수행할 수 있습니다. 또한 [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) 등 특수 형식으로의 변환도 지원됩니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트 및 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

네. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스를 사용해 비밀번호와 접근 권한을 설정하면 됩니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드에 `true`를 전달하면 결과 PDF에 숨겨진 슬라이드가 페이지로 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

네. [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 및 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-)와 같은 메서드를 사용해 이미지 품질을 제어하면 PDF에서 고품질 이미지를 보장할 수 있습니다.

**Aspose.Slides가 PDF/A 준수 표준을 지원하나요?**

네. Aspose.Slides는 [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)를 포함한 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 규격에 부합하는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for Java Documentation](/slides/ko/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)