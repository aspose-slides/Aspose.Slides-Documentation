---
title: Java에서 PPT 및 PPTX를 PDF로 변환 (고급 기능 포함)
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
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 Java에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 서로 다른 장치 간 호환성 확보와 프레젠테이션의 레이아웃 및 서식을 그대로 유지하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하고, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 출력 문서에 규격 적용 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 전달해 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스를 만든 뒤, [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드로 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환할 때 사용하는 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Application 필드에 "*Aspose.Slides*"가, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값이 채워집니다. **Note** 이 정보는 출력 문서에서 변경하거나 제거할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드만 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보낼 때 원본과 거의 동일하게 렌더링됩니다. 변환 과정에서 다음 요소와 속성이 정확히 표시됩니다.

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

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정으로 모든 표시 슬라이드를 PDF에 저장합니다.

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
Aspose는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 를 제공하며, 여기서 여기서 설명한 프레젠테이션‑to‑PDF 변환 과정을 직접 확인할 수 있습니다.
{{% /alert %}}

## **옵션을 사용한 PowerPoint‑to‑PDF 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래에 있는 사용자 정의 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하고, PDF에 비밀번호를 설정하거나, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 정의 옵션을 사용한 PowerPoint‑to‑PDF 변환**

사용자 정의 변환 옵션을 사용하면 래스터 이미지 품질, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 지정할 수 있습니다.

다음 예제는 PDF 1.5 버전으로 내보내면서 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용합니다.

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

### **이미지 압축 자동 선택**

프레젠테이션에 사진이나 스크린샷이 많이 포함된 경우, 내보낸 PDF의 크기를 줄이면 이메일 전송이나 다운로드가 쉬워집니다. PDF 내보내기 중 각 이미지에 가장 적합한 압축 알고리즘을 자동으로 선택하려면 `true`와 함께 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) 를 호출하세요.

다음 예제는 기존 프레젠테이션을 로드하고 자동 이미지 압축 선택을 활성화한 뒤 PDF 문서로 저장합니다. 다른 모든 PDF 내보내기 설정은 기본값을 유지합니다.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

이 옵션은 각 이미지에 대해 압축 알고리즘을 선택합니다. [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 에 전달하는 값을 낮추면 JPEG 이미지 품질이 감소하고, [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 에 전달하는 값을 낮추면 이미지가 낮은 해상도로 다운샘플링되어 세부 정보가 감소합니다. 자동 압축 선택을 활성화해도 이러한 설정 자체는 낮아지지 않습니다.

이미지 압축 알고리즘을 선택하면 추가 처리 시간과 메모리가 필요합니다. 크기 감소는 프레젠테이션의 이미지와 내보내기 설정에 따라 달라지며, 모든 프레젠테이션에 대해 일정하게 감소한다고 보장할 수 없습니다.

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 워크북이 포함된 경우, PDF 수신자가 슬라이드와 함께 워크북 데이터를 확인할 수 있도록 하려면 `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 를 호출하세요.

기본값은 `false`이며, 이 경우 OLE 객체의 미리보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터도 첨부 파일에 포함됩니다. 미리보기는 시각적 표시만 제공하며, 첨부 파일을 통해 수신자는 별도로 파일을 열거나 저장할 수 있습니다. OLE 객체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되는 것은 아닙니다.

다음 예제는 이미 임베드된 Excel 워크북이 포함된 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함시켜 PDF로 내보냅니다.

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

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 검토하거나, 뷰어가 허용한다면 직접 열어봅니다. PDF 페이지의 미리보기와 첨부 파일은 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베드 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 형식을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides만의 제한이 아닙니다. 이 예제는 기본 PDF 규격 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.
{{% /alert %}}

### **숨겨진 슬라이드 포함 변환**

프레젠테이션에 숨겨진 슬라이드가 포함되어 있으면 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 `true`와 함께 호출하여 숨겨진 슬라이드를 결과 PDF 페이지에 포함시킬 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함해 프레젠테이션을 PDF로 내보냅니다.

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

다음 예제는 열 때 `password` 비밀번호가 필요하고, 인쇄 권한(고품질 인쇄 포함)을 허용하는 PDF로 프레젠테이션을 내보냅니다.

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

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 발생하는 글꼴 대체를 감지할 수 있습니다.

다음 예제는 프레젠테이션을 PDF로 내보내면서 콘솔에 글꼴 대체 경고를 출력합니다. 사용 가능한 글꼴이 없을 때만 경고가 출력됩니다.

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
글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/java/font-substitution/) 문서를 참고하세요.
{{% /alert %}} 

### **전용 볼드 글꼴이 없는 경우 처리**

프레젠테이션은 글꼴에 전용 볼드 형태가 없더라도 텍스트에 볼드 서식을 적용할 수 있습니다. 이 경우 합성 볼드가 적용되어 일반 글리프가 인위적으로 두껍게 보입니다. PDF에서 해당 텍스트가 너무 무겁게 보이거나 기대와 다르게 표시될 경우, `true`와 함께 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) 를 호출해 보세요. 이 옵션을 활성화하면 변환 시 해당 텍스트를 비트맵으로 렌더링하여 특정 글꼴의 표시를 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 일반 텍스트 상자와 동일한 글꼴에 볼드 서식을 적용한 텍스트 상자가 포함되어 있습니다. 다음 예제는 프레젠테이션을 로드하고 전용 볼드가 없는 글꼴 스타일을 래스터화하도록 설정한 뒤 PDF로 내보냅니다.

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

다음 미리보기는 옵션 비활성화와 활성화 결과를 보여줍니다. 이 예제에서 옵션 비활성화 시 볼드 텍스트의 획이 더 굵게 나타납니다. 옵션 활성화 시 획이 얇아지고 일반 텍스트는 변하지 않습니다. 프레젠테이션에 적합한 설정을 선택하기 전에 결과를 비교해 보세요.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 볼드 텍스트만 비트맵으로 변환됩니다. 따라서 OCR 없이 텍스트를 선택, 복사 또는 검색할 수 없으며, 800% 확대 시 가장자리가 부드럽게 보입니다. 일반 텍스트는 계속 검색 가능합니다. 옵션 비활성화 시 두 문자열 모두 텍스트 형태로 유지됩니다.

이 옵션은 전용 볼드 글꼴이 없는 경우 볼드 서식 텍스트를 래스터화합니다. [Font substitution](/slides/ko/java/font-substitution/) 은 원본 글꼴이 없을 때 다른 글꼴을 선택합니다.

## **선택한 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택해 PDF로 내보냅니다. 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

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

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 첫 번째 슬라이드를 새 프레젠테이션에 복사하고, 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용을 맞게 스케일링한 뒤 단일 슬라이드를 PDF로 내보냅니다.

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

    // 새 프레젠테이션이 생성될 때 만든 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내면서 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하세요.

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

## **PDF 접근성 및 규격 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있습니다. 다음 규격 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 서로 다른 규격을 적용해 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다.

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
Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 변환이 가능합니다. 또한 특수 형식인 [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) 변환도 지원합니다.
{{% /alert %}}

> **Note:** PDF/UA 로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식 등 복잡한 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며, 대신 전체 도형에 대한 대체 텍스트만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 일괄적으로 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 한 번에 PDF로 변환하는 배치 변환을 지원합니다. 파일을 반복하면서 프로그래밍 방식으로 변환 과정을 적용하면 됩니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

네. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스를 사용해 비밀번호와 접근 권한을 지정하면 됩니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 하나요?**

[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 `true`로 호출하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

네. [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 및 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 메서드를 사용해 이미지 품질을 고품질로 설정할 수 있습니다.

**Aspose.Slides가 PDF/A 규격을 지원하나요?**

네. Aspose.Slides는 [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) 를 포함해 PDF/A1a, PDF/A1b, PDF/UA 등 PDF/A 규격을 준수하는 PDF를 내보낼 수 있어 접근성과 보존 요구 사항을 만족합니다.

## **추가 리소스**

- [Aspose.Slides for Java Documentation](/slides/ko/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)