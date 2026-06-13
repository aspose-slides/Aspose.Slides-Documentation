---
title: JavaScript에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]
linktitle: PowerPoint를 PDF로
type: docs
weight: 40
url: /ko/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint PPT/PPTX를 고품질 검색 가능한 PDF로 변환하고, 빠른 코드 예제 및 고급 변환 옵션을 제공합니다."
---
## **개요**

PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP 등)을 JavaScript에서 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드는 프레젠테이션을 PDF 문서로 변환하는 방법, 이미지 품질을 제어하는 옵션 사용, 숨겨진 슬라이드 포함, PDF 파일에 비밀번호 보호, 글꼴 대체 감지, 변환할 특정 슬라이드 선택, 출력 문서에 준수 표준 적용 등을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스에 인수로 전달한 다음 `save` 메서드를 사용해 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 `save` 메서드를 제공합니다.

{{%  alert title="참고"  color="warning"   %}} 
Aspose.Slides for Node.js via Java는 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** 이 정보를 출력 문서에서 변경하거나 제거하도록 Aspose.Slides에 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보내면서 원본 프레젠테이션과 거의 일치하도록 합니다. 변환 과정에서 다음 요소와 속성이 정확히 렌더링됩니다.

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

다음 코드는 프레젠테이션(PPT, PPTX, ODP 등)을 PDF로 변환하는 방법을 보여줍니다.

```js
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // 프레젠테이션을 PDF로 저장합니다.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose는 프레젠테이션‑to‑PDF 변환 과정을 시연하는 무료 온라인 **PowerPoint to PDF converter**[https://products.aspose.app/slides/ko/conversion/ppt-to-pdf]를 제공합니다. 이 변환기를 사용해 여기서 설명한 절차를 실시간으로 테스트할 수 있습니다.
{{% /alert %}}

## **옵션을 사용하여 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 사용자 지정 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하고, 비밀번호로 PDF를 잠그거나 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **사용자 지정 옵션으로 PowerPoint를 PDF로 변환**

사용자 지정 변환 옵션을 사용하면 래스터 이미지 품질, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 코드 예제는 여러 사용자 지정 옵션을 적용해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```js
// PdfOptions 클래스를 인스턴스화합니다.
let pdfOptions = new aspose.slides.PdfOptions();

// JPG 이미지의 품질을 설정합니다.
pdfOptions.setJpegQuality(java.newByte(90));

// 이미지의 DPI를 설정합니다.
pdfOptions.setSufficientResolution(300);

// 메타파일에 대한 동작을 설정합니다.
pdfOptions.setSaveMetafilesAsPng(true);

// 텍스트 콘텐츠에 대한 압축 수준을 설정합니다.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// PDF 준수 모드를 정의합니다.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 프레젠테이션을 PDF 문서로 저장합니다.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **숨겨진 슬라이드가 포함된 PowerPoint를 PDF로 변환**

프레젠테이션에 숨겨진 슬라이드가 있는 경우 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) 메서드를 사용해 숨겨진 슬라이드를 결과 PDF의 페이지로 포함시킬 수 있습니다.

다음 JavaScript 코드는 숨겨진 슬라이드를 포함해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```js
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions 클래스를 인스턴스화합니다.
    let pdfOptions = new aspose.slides.PdfOptions();

    // 숨겨진 슬라이드를 추가합니다.
    pdfOptions.setShowHiddenSlides(true);

    // 프레젠테이션을 PDF로 저장합니다.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **비밀번호로 보호된 PDF로 PowerPoint 변환**

다음 JavaScript 코드는 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스의 보호 매개변수를 사용해 PowerPoint 프레젠테이션을 비밀번호 보호 PDF로 변환하는 방법을 보여줍니다.

```js
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions 클래스를 인스턴스화합니다.
    let pdfOptions = new aspose.slides.PdfOptions();

    // PDF 비밀번호와 접근 권한을 설정합니다.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // 프레젠테이션을 PDF로 저장합니다.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 JavaScript 코드는 글꼴 대체를 감지하는 방법을 보여줍니다.

```js
// PDF 옵션에서 경고 콜백을 설정합니다.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("sample.pptx");

// 프레젠테이션을 PDF로 저장합니다.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 
글꼴 대체에 대한 자세한 내용은 [Font Substitution](/slides/ko/nodejs-java/font-substitution/) 문서를 참고하십시오.
{{% /alert %}} 

## **선택된 슬라이드만 PDF로 변환**

다음 JavaScript 코드는 PowerPoint 프레젠테이션에서 특정 슬라이드만 선택해 PDF로 변환하는 방법을 보여줍니다.

```js
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 슬라이드 번호 배열을 설정합니다.
    let slides = java.newArray("int", [1, 3]);

    // 프레젠테이션을 PDF로 저장합니다.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 JavaScript 코드는 지정된 슬라이드 크기를 적용해 PowerPoint 프레젠테이션을 PDF로 변환하는 방법을 보여줍니다.

```js
const slideWidth = 612;
const slideHeight = 792;

// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// 조정된 슬라이드 크기로 새 프레젠테이션을 생성합니다.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // 사용자 지정 슬라이드 크기를 설정합니다.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // 원본 프레젠테이션에서 첫 번째 슬라이드를 복제합니다.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 조정된 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기로 PowerPoint를 PDF에 포함**

다음 JavaScript 코드는 노트를 포함한 PDF를 생성하도록 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다.

```js
// PowerPoint 또는 OpenDocument 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // 노트 레이아웃으로 PDF 옵션을 구성합니다.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 프레젠테이션을 노트가 포함된 PDF로 저장합니다.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF에 대한 접근성 및 준수 표준**

Aspose.Slides는 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 를 준수하는 변환 절차를 사용할 수 있게 합니다. 다음 준수 표준 중 하나를 사용해 PowerPoint 문서를 PDF/A1a, PDF/A1b, PDF/UA 형식으로 내보낼 수 있습니다.

다음 JavaScript 코드는 다양한 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다.

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides는 PDF 변환 작업을 지원하므로 PDF 파일을 인기 있는 파일 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/ko/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/ko/nodejs-java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/ko/nodejs-java/conversion/pdf-to-png/) 변환이 가능합니다. 또한 [PDF to SVG](https://products.aspose.com/slides/ko/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ko/nodejs-java/conversion/pdf-to-tiff/)와 같은 특수 형식으로의 변환도 지원됩니다.
{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복합 그래픽을 단일 그림으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있으며, 대체 텍스트는 전체 그림에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

네, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 순회하면서 프로그래밍 방식으로 변환 프로세스를 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

물론입니다. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스를 사용해 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨겨진 슬라이드를 포함하려면 어떻게 하나요?**

[PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스의 `setShowHiddenSlides` 메서드를 사용해 숨겨진 슬라이드를 결과 PDF에 포함시킬 수 있습니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

네, [PdfOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PdfOptions) 클래스의 `setJpegQuality` 및 `setSufficientResolution` 같은 메서드를 사용해 PDF에서 고품질 이미지를 보장할 수 있습니다.

**Aspose.Slides가 PDF/A 준수 표준을 지원하나요?**

네, Aspose.Slides는 PDF/A1a, PDF/A1b, PDF/UA 등 다양한 표준을 준수하는 PDF를 내보낼 수 있어 문서가 접근성과 보존 요구 사항을 만족하도록 합니다.

## **추가 리소스**

- [Aspose.Slides for Node.js via Java Documentation](/slides/ko/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/ko/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ko/conversion)