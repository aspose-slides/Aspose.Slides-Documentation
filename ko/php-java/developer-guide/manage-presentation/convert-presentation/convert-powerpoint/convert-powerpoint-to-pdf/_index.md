---
title: PHP에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PowerPoint PDF 변환
- 프레젠테이션 PDF 변환
- PPT PDF 변환
- PPT PDF 변환
- PPTX PDF 변환
- PPTX PDF 변환
- PowerPoint를 PDF로 저장
- PPT를 PDF로 저장
- PPTX를 PDF로 저장
- PPT를 PDF로 내보내기
- PPTX를 PDF로 내보내기
- 첨부 파일
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint PPT/PPTX를 고품질, 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PHP에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 다양한 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호 설정, 글꼴 대체 감지, 변환할 슬라이드 선택 및 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스에 인수로 전달한 다음 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 메서드를 사용해 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형태의 값을 채웁니다. **Note** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로
* 프레젠테이션의 특정 슬라이드를 PDF로

Aspose.Slides는 프레젠테이션을 PDF로 내보낼 때 원본 프레젠테이션과 거의 동일하게 PDF가 생성되도록 합니다. 변환 중에는 다음 요소와 속성이 정확히 렌더링됩니다.

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정으로 최대 품질 수준에서 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정으로 모든 보이는 슬라이드를 PDF로 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose는 프레젠테이션‑to‑PDF 변환 프로세스를 시연하는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 를 제공합니다. 여기에서 이 변환기를 사용해 실시간으로 절차를 테스트할 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 사용자 정의 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하고, PDF에 비밀번호를 걸거나 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 정의 옵션을 사용한 PowerPoint‑to‑PDF 변환**

사용자 정의 변환 옵션을 사용하면 래스터 이미지에 대한 원하는 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 예제는 JPEG 품질을 90으로, 이미지 해상도를 300 DPI로, 메타파일을 PNG로 저장하고 Flate 텍스트 압축을 적용한 PDF 1.5를 내보냅니다.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **임베드된 OLE 파일을 PDF 첨부 파일로 보존**

프레젠테이션에 임베드된 Excel 통합 문서가 포함된 경우 PDF 수신자가 슬라이드와 함께 통합 문서 데이터를 액세스할 수 있도록 할 수 있습니다. `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 를 호출하면 임베드된 OLE 파일을 결과 PDF의 첨부 파일로 보존합니다.

기본값은 `false`이며, 이 경우 OLE 개체의 미리 보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 임베드된 파일은 첨부 파일로 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터가 추가로 포함됩니다. 미리 보기는 시각적 표현으로 남고, 첨부 파일을 통해 수신자는 임베드된 파일을 별도로 열거나 저장할 수 있습니다. OLE 개체가 PDF 페이지에서 인터랙티브한 Excel 워크시트가 되지는 않습니다.

다음 예제는 이미 임베드된 Excel 통합 문서를 포함하고 있는 프레젠테이션을 로드한 뒤 해당 워크북을 첨부한 상태로 PDF로 내보냅니다.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

결과 확인 방법:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 임베드된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용하는 경우 직접 엽니다. PDF 페이지의 미리 보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}

PDF/A 표준은 첨부 파일에 제한을 둡니다. PDF/A‑1은 임베드된 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 통합 문서를 포함한 기타 파일 형식을 허용합니다. 이는 표준의 요구사항이며 Aspose.Slides 고유의 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.

{{% /alert %}}

### **숨겨진 슬라이드를 포함한 PowerPoint‑to‑PDF 변환**

프레젠테이션에 숨겨진 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) 메서드를 사용해 숨겨진 슬라이드를 결과 PDF의 페이지로 포함할 수 있습니다.

다음 예제는 숨겨진 슬라이드를 포함해 프레젠테이션을 PDF로 내보냅니다.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 예제는 비밀번호 `password`를 입력해야 열 수 있는 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄, 고품질 인쇄를 허용하도록 설정됩니다.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 예제는 프레젠테이션을 PDF로 내보내면서 콘솔에 글꼴 대체 경고를 출력합니다. 사용 가능한 글꼴이 없을 때만 경고가 출력됩니다.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/php-java/font-substitution/) 문서를 참조하세요.

{{% /alert %}} 

### **전용 볼드 체형이 없는 글꼴 처리**

프레젠테이션은 해당 글꼴에 전용 볼드 체형이 없더라도 텍스트에 볼드 서식을 적용할 수 있습니다. 이 경우 인공적으로 글리프가 두꺼워져 보이게 됩니다. PDF에서 해당 텍스트가 너무 굵게 보이거나 의도와 다르게 표시될 경우 [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 를 `true`와 함께 호출해 보십시오. 이 옵션은 PDF 내보낼 때 영향을 받는 텍스트를 비트맵으로 렌더링하여 특정 글꼴의 표시 품질을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 일반 텍스트 상자와 동일한 글꼴에 볼드 서식을 적용한 텍스트 상자 두 개가 포함되어 있습니다. 해당 글꼴은 전용 볼드 체형이 없습니다. 다음 예제는 프레젠테이션을 로드하고 전용 볼드 체형이 없는 글꼴 스타일을 래스터화하도록 설정한 뒤 PDF로 내보냅니다.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

아래 미리보기는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예제에서는 옵션이 비활성화된 경우 볼드 텍스트가 두꺼운 획을 갖습니다. 옵션을 활성화하면 획이 얇아지고 일반 텍스트는 변하지 않습니다. 결과를 비교한 뒤 프레젠테이션에 적합한 설정을 선택하십시오.

| 옵션 비활성화 (`false`, 기본값) | 옵션 활성화 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 볼드 텍스트만 비트맵으로 변환됩니다. 비트맵 텍스트는 OCR 없이 선택, 복사 또는 검색할 수 없으며 800% 줌에서 가장자리가 부드럽게 보입니다. 일반 텍스트는 검색 가능 상태를 유지합니다. 옵션을 비활성화하면 두 문자열 모두 텍스트로 남아 있습니다.

이 옵션은 전용 볼드 체형이 없는 경우 볼드로 서식 지정된 텍스트를 래스터화합니다. [Font substitution](/slides/ko/php-java/font-substitution/) 은 원본 글꼴이 없을 때 다른 글꼴을 선택합니다.

## **선택한 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택해 PDF로 내보냅니다. 배열에 지정된 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에는 최소 세 개의 슬라이드가 포함되어 있어야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션에 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 설정합니다. 슬라이드 내용을 맞춰 스케일링한 뒤 단일 슬라이드를 PDF로 내보냅니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // 새 프레젠테이션이 생성될 때 만든 빈 슬라이드를 제거합니다.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **노트 슬라이드 보기로 PowerPoint를 PDF에 변환**

다음 예제는 프레젠테이션을 PDF로 내보내면서 각 슬라이드 아래에 발표자 노트를 배치합니다. 결과를 보려면 발표자 노트가 포함된 프레젠테이션을 사용하십시오.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF 접근성 및 규정 준수 표준**

Aspose.Slides를 사용하면 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 충족하는 변환 절차를 사용할 수 있습니다. 다음 규정 준수 표준 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다.

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 다양한 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) 변환이 가능합니다. 또한 [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) 등 특수 형식으로의 변환도 지원됩니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식 등 복잡한 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 그림에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 배치 변환하여 PDF로 만들 수 있습니다. 파일을 순회하면서 프로그래밍 방식으로 변환 절차를 적용하면 됩니다.

**변환된 PDF에 비밀번호를 걸 수 있나요?**

예. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스를 사용해 비밀번호와 접근 권한을 설정하면 됩니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) 메서드를 `true`와 함께 호출하면 결과 PDF에 숨겨진 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) 및 [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) 메서드를 사용해 이미지 품질을 제어할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) 를 포함한 PDF/A1a, PDF/A1b, PDF/UA 등 규정 준수 표준에 맞는 PDF를 내보낼 수 있어 문서가 접근성 및 보존 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for PHP via Java Documentation](/slides/ko/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)