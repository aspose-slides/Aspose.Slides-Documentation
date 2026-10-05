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
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

Java에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 확보와 프레젠테이션의 레이아웃 및 서식 보존이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하고, 이미지 품질을 제어하는 옵션을 사용하고, 숨김 슬라이드를 포함하고, PDF 파일에 비밀번호를 설정하고, 글꼴 대체를 감지하고, 특정 슬라이드를 선택하여 변환하며, 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 전달하여 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스를 생성한 다음 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **참고**: Aspose.Slides에 이 정보를 변경하거나 제거하도록 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션에서 특정 슬라이드만 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보낼 때 원본 프레젠테이션과 매우 유사한 결과물을 생성합니다. 변환 과정에서 다음 요소와 속성이 정확하게 렌더링됩니다:

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 표시 슬라이드를 PDF로 저장합니다.

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

Aspose는 무료 온라인 [**PowerPoint를 PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하며, 여기에서 여기서 설명한 프레젠테이션‑to‑PDF 변환 프로세스를 직접 테스트할 수 있습니다.

{{% /alert %}}

## **PowerPoint를 PDF로 옵션과 함께 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래에 있는 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 사용자 지정하고, 비밀번호로 PDF를 잠그고, 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **PowerPoint를 PDF로 사용자 지정 옵션과 함께 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 예제는 프레젠테이션을 PDF 1.5로 내보내며 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고 Flate 텍스트 압축을 적용합니다.

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

### **PDF 첨부 파일로 포함된 OLE 파일 보존**

프레젠테이션에 포함된 Excel 통합 문서가 있는 경우 PDF 수신자가 슬라이드와 함께 통합 문서 데이터를 액세스할 수 있도록 할 수 있습니다. `true`를 전달하여 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)를 호출하면 결과 PDF에 포함된 OLE 파일을 첨부 파일로 보존합니다.

기본값은 `false`이며, 이 경우 OLE 개체의 미리 보기 이미지 또는 아이콘만 PDF 페이지에 표시되고 첨부 파일은 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터도 추가로 포함됩니다. 미리 보기는 시각적 표현으로 남으며, 첨부 파일을 통해 수신자는 별도로 파일을 열거나 저장할 수 있습니다. OLE 개체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되는 것은 아닙니다.

다음 예제는 이미 Excel 통합 문서를 포함하고 있는 프레젠테이션을 로드하고 통합 문서를 첨부 파일로 포함하여 PDF로 내보냅니다.

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

결과를 확인하려면:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 포함된 통합 문서를 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하는 경우 직접 엽니다. PDF 페이지의 미리 보기와 첨부 파일은 별도로 존재합니다.

{{% alert color="info" title="Note" %}}

PDF/A 표준은 첨부 파일에 제한을 두고 있습니다. PDF/A‑1은 첨부 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3는 Excel 통합 문서를 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에 특정된 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하므로 PDF/A 내보내기를 시연하지 않습니다.

{{% /alert %}}

### **숨김 슬라이드가 포함된 PDF로 변환**

프레젠테이션에 숨김 슬라이드가 있는 경우 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 사용하여 숨김 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨김 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

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

### **비밀번호로 보호된 PDF로 변환**

다음 예제는 열려면 `password` 비밀번호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며 고품질 인쇄도 포함합니다.

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

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 사용불가능한 글꼴이 대체될 때만 경고가 표시됩니다.

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

글꼴 대체에 대한 자세한 내용은 [폰트 대체](/slides/ko/java/font-substitution/) 문서를 참고하십시오.

{{% /alert %}} 

## **PowerPoint에서 선택한 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션의 1번 슬라이드와 3번 슬라이드를 선택하여 PDF로 내보냅니다. 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

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

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 크기 612 × 792 포인트(8.5 × 11 인치)인 새 프레젠테이션에 복사하고, 슬라이드 내용을 맞추어 확대·축소한 뒤 단일 슬라이드를 PDF로 내보냅니다.

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

    // 새 프레젠테이션이 생성된 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

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

## **PDF 접근성 및 규정 준수 표준**

Aspose.Slides를 사용하면 [웹 콘텐츠 접근성 가이드라인 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)를 준수하는 변환 절차를 활용할 수 있습니다. 다음 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 서로 다른 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

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

Aspose.Slides는 PDF 변환 작업을 지원하며, PDF 파일을 다양한 파일 형식으로 변환할 수 있습니다. 다음 변환을 수행할 수 있습니다: [PDF를 HTML로](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF를 이미지로](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF를 JPG로](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), [PDF를 PNG로](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 변환. 또한 특수 형식으로의 변환도 지원합니다: [PDF를 SVG로](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF를 TIFF로](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), [PDF를 XML로](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) 변환.

{{% /alert %}}

> **Note:** PDF/UA 로 내보낼 때 Aspose.Slides는 SmartArt, 차트 및 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 대량으로 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용하면 됩니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

네. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스를 사용하여 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨김 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스에서 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 `true`로 호출하면 결과 PDF에 숨김 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

네. [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 및 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 메서드를 사용하여 이미지 품질을 제어하고 PDF에서 고품질 이미지를 보장할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

네, Aspose.Slides는 [다양한 표준](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)을 준수하는 PDF를 내보낼 수 있습니다. 여기에는 PDF/A1a, PDF/A1b 및 PDF/UA가 포함되며, 문서가 접근성 및 보관 요구 사항을 충족하도록 합니다.

## **Additional Resources**

- [Aspose.Slides for Java Documentation](/slides/ko/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)