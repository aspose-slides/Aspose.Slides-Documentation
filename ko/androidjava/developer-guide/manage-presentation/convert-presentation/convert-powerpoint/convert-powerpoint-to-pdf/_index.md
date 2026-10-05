---
title: Android에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로 변환
type: docs
weight: 40
url: /ko/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 PowerPoint PPT/PPTX를 고품질의 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

Android에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 디바이스 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 암호 보호, 글꼴 대체 감지, 특정 슬라이드 선택 변환, 및 출력 문서에 규정 준수 표준 적용 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

다음 형식의 프레젠테이션을 Aspose.Slides를 사용하여 PDF로 변환할 수 있습니다:

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 인수로 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스에 전달한 다음 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하여 프레젠테이션을 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java은 출력 문서에 API 정보와 버전 번호를 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **참고** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다:

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내어 결과 PDF가 원본 프레젠테이션과 매우 유사하도록 보장합니다. 변환 시 요소와 속성이 정확하게 렌더링되며, 포함 항목은 다음과 같습니다:

* 이미지
* 텍스트 상자와 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 과정은 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최대 품질 수준을 사용하여 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 보이는 슬라이드를 PDF로 저장합니다.

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
Aspose는 프레젠테이션‑to‑PDF 변환 과정을 시연하는 무료 온라인 [**PowerPoint를 PDF로 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공합니다. 여기서 설명한 절차를 실시간으로 구현하려면 이 변환기로 테스트를 실행할 수 있습니다.
{{% /alert %}}

## **옵션과 함께 PowerPoint를 PDF로 변환**

Aspose.Slides는 결과 PDF를 사용자 지정하고, PDF에 암호를 걸며, 변환 과정의 진행 방식을 지정할 수 있는 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스의 속성이라는 맞춤 옵션을 제공합니다.

### **옵션을 사용하여 PowerPoint를 PDF로 변환**

맞춤 변환 옵션을 사용하면 래스터 이미지의 원하는 품질 설정을 정의하고, 메타파일 처리 방식을 지정하며, 텍스트 압축 수준을 설정하고, 이미지 DPI를 구성하는 등 다양한 작업을 수행할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고, Flate 텍스트 압축을 적용하여 PDF 1.5로 프레젠테이션을 내보냅니다.

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

### **PDF 첨부 파일으로 포함된 OLE 파일 보존**

프레젠테이션에 포함된 Excel 워크북이 있는 경우 PDF 수신자가 슬라이드를 보는 동시에 워크북 데이터를 액세스할 수 있기를 원할 수 있습니다. `true`를 사용하여 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)를 호출하면 포함된 OLE 파일을 결과 PDF의 첨부 파일로 보존합니다.

기본값은 `false`입니다: OLE 객체의 미리보기 이미지 또는 아이콘은 PDF 페이지에 렌더링되지만, 포함된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터가 추가로 포함됩니다. 미리보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 포함된 파일을 별도로 열거나 저장할 수 있습니다. OLE 객체는 PDF 페이지에서 대화형 Excel 워크시트가 되지 않습니다.

다음 예제는 이미 포함된 Excel 워크북이 있는 프레젠테이션을 로드하고 워크북이 첨부된 상태로 PDF로 내보냅니다.

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

1. Adobe Acrobat Reader와 같이 파일 첨부를 지원하는 뷰어에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 포함된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하면 바로 열 수 있습니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 가합니다: PDF/A-1은 내장 파일을 금지하고, PDF/A-2는 PDF/A 첨부 파일만 허용하며, PDF/A-3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준의 요구 사항이며 Aspose.Slides에만 해당되는 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.
{{% /alert %}}

### **숨겨진 슬라이드를 포함하여 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 메서드를 사용하여 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

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

### **암호로 보호된 PDF로 PowerPoint 변환**

다음 예제는 열려면 `password` 암호가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며, 고품질 인쇄도 포함됩니다.

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

Aspose.Slides는 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있도록 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 메서드를 제공합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 경고는 사용 불가능한 글꼴이 내보내기 중 대체될 때만 출력됩니다.

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
글꼴 대체에 대한 자세한 내용은 [글꼴 대체](/slides/ko/androidjava/font-substitution/) 문서를 참조하십시오.
{{% /alert %}} 

## **PowerPoint에서 선택된 슬라이드를 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 PDF로 내보냅니다. 이 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 있어야 합니다.

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

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 슬라이드 크기가 612 × 792 포인트(8.5 × 11 인치)인 새 프레젠테이션으로 복사합니다. 슬라이드 내용을 맞게 스케일링하고 단일 슬라이드를 PDF로 내보냅니다.

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

    // 새 프레젠테이션이 생성될 때 포함된 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기에서 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내며 각 슬라이드의 발표자 노트를 슬라이드 아래에 배치합니다. 결과를 확인하려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

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

Aspose.Slides를 사용하면 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있습니다. 다음과 같은 규정 준수 표준 중 하나를 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 과정을 보여줍니다:

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
Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 인기 있는 파일 형식으로 변환할 수 있습니다. 다음과 같은 변환을 수행할 수 있습니다: [PDF를 HTML로](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF를 이미지로](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF를 JPG로](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), 그리고 [PDF를 PNG로](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 변환. SVG, TIFF, XML 등 특수 형식으로의 변환도 지원됩니다: [PDF를 SVG로](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF를 TIFF로](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), [PDF를 XML로](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) .
{{% /alert %}}

> **참고:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며, 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 것을 지원합니다. 파일들을 반복하면서 프로그래밍 방식으로 변환 과정을 적용할 수 있습니다.

**변환된 PDF에 암호 보호를 적용할 수 있나요?**

예. 변환 과정 중에 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스를 사용하여 암호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

`true` 값을 사용하여 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스에서 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)를 호출하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예, [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 및 [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-)와 같은 메서드를 사용하여 PDF에서 고품질 이미지를 보장하도록 이미지 품질을 제어할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예, Aspose.Slides는 [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) 를 포함한 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준에 맞는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for Android via Java 문서](/slides/ko/androidjava/)
- [Aspose.Slides for Android via Java API 레퍼런스](https://reference.aspose.com/slides/androidjava/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/conversion)