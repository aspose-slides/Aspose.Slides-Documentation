---
title: Convert PPT와 PPTX를 PHP에서 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/php-java/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint PPT/PPTX를 고품질 및 검색 가능한 PDF로 변환합니다. 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

PHP에서 PowerPoint 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨긴 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 변환할 특정 슬라이드 선택, 출력 문서에 규정 준수 표준 적용 등을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인수로 전달한 다음 `save` 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 `save` 메서드를 제공합니다.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java은 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.

{{% /alert %}}

Aspose.Slides는 다음과 같은 변환을 지원합니다.

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내어 결과 PDF가 원본 프레젠테이션과 거의 동일하게 유지되도록 합니다. 변환 과정에서 요소와 속성이 정확하게 렌더링됩니다.

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 최적의 설정과 최고 품질 수준으로 제공된 프레젠테이션을 PDF로 변환하려고 시도합니다.

다음 코드는 프레젠테이션(PPT, PPTX, ODP 등)을 PDF로 변환하는 방법을 보여줍니다.

```php
# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 프레젠테이션을 PDF로 저장합니다.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose는 무료 온라인 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-pdf)를 제공하여 프레젠테이션‑to‑PDF 변환 프로세스를 시연합니다. 여기서 설명한 절차를 직접 테스트해 볼 수 있습니다.

{{% /alert %}}

## **옵션을 사용한 PowerPoint to PDF 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PdfOptions) 클래스 아래에 있는 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하거나 비밀번호로 잠그거나 변환 과정을 제어할 수 있습니다.

### **사용자 지정 옵션을 사용한 PowerPoint to PDF 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 설정 등을 정의할 수 있습니다.

아래 코드는 여러 사용자 지정 옵션을 사용하여 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```php
# PdfOptions 클래스를 인스턴스화합니다.
$pdfOptions = new PdfOptions();

# JPG 이미지 품질을 설정합니다.
$pdfOptions->setJpegQuality(90);

# 이미지 DPI를 설정합니다.
$pdfOptions->setSufficientResolution(300);

# 메타파일 처리 방식을 설정합니다.
$pdfOptions->setSaveMetafilesAsPng(true);

# 텍스트 콘텐츠에 대한 압축 수준을 설정합니다.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDF 규격 준수 모드를 정의합니다.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 프레젠테이션을 PDF 문서로 저장합니다.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **숨긴 슬라이드를 포함한 PowerPoint to PDF 변환**

프레젠테이션에 숨긴 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PdfOptions) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 메서드를 사용하여 숨긴 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

다음 코드는 숨긴 슬라이드를 포함하여 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```php
# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions 클래스를 인스턴스화합니다.
    $pdfOptions = new PdfOptions();

    # 숨긴 슬라이드를 추가합니다.
    $pdfOptions->setShowHiddenSlides(true);

    # 프레젠테이션을 PDF로 저장합니다.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스의 보호 매개변수를 사용하여 PowerPoint 프레젠테이션을 비밀번호로 보호된 PDF로 변환하는 방법을 보여줍니다.

```php
# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions 클래스를 인스턴스화합니다.
    $pdfOptions = new PdfOptions();

    # PDF 비밀번호와 접근 권한을 설정합니다.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # 프레젠테이션을 PDF로 저장합니다.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setWarningCallback) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 코드는 글꼴 대체를 감지하는 방법을 보여줍니다.

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// PDF 옵션에서 경고 콜백을 설정합니다.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Presentation 클래스를 인스턴스화합니다(PowerPoint 또는 OpenDocument 파일을 나타냅니다).
$presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션을 PDF로 저장합니다.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/php-java/font-substitution/) 문서를 참고하십시오.

{{% /alert %}} 

## **선택한 슬라이드를 PDF로 변환**

다음 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택하여 PDF로 변환하는 방법을 보여줍니다.

```php
# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 슬라이드 번호 배열을 설정합니다.
    $slides = array(1, 3);

    # 프레젠테이션을 PDF로 저장합니다.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **사용자 지정 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 코드는 지정된 슬라이드 크기로 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("SelectedSlides.pptx");

# 조정된 슬라이드 크기로 새로운 프레젠테이션을 생성합니다.
$resizedPresentation = new Presentation();

try {
    # 사용자 지정 슬라이드 크기를 설정합니다.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # 원본 프레젠테이션에서 첫 번째 슬라이드를 복제합니다.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # 노트가 포함된 PDF로 크기 조정된 프레젠테이션을 저장합니다.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **노트 슬라이드 보기로 PowerPoint를 PDF에 변환**

다음 코드는 노트를 포함한 PDF를 생성하도록 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다.

```php
# PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # 노트 레이아웃으로 PDF 옵션을 구성합니다.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있게 합니다. 다음 중 하나의 규정 준수 표준을 사용하여 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

아래 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 시연합니다.

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides는 PDF 변환 작업을 지원하여 PDF 파일을 다양한 파일 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-png/) 변환이 가능합니다. 또한 [PDF to SVG](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/ko/php-java/conversion/pdf-to-xml/)과 같은 특수 형식으로의 변환도 지원합니다.

{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복잡한 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 그림에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

물론입니다. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스를 사용하여 비밀번호와 접근 권한을 설정하십시오.

**PDF에 숨긴 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스의 `setShowHiddenSlides` 메서드를 사용하여 숨긴 슬라이드를 결과 PDF에 포함시킬 수 있습니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예, [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스의 `setJpegQuality` 및 `setSufficientResolution`와 같은 메서드를 사용하여 PDF 내 이미지 품질을 고품질로 유지하도록 제어할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준을 준수하는 PDF를 내보낼 수 있어 문서가 접근성 및 보관 요구 사항을 충족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for PHP via Java Documentation](/slides/ko/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/ko/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ko/conversion)