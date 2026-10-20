---
title: "JavaScript에서 PPT 및 PPTX를 PDF로 변환 [고급 기능 포함]"
linktitle: "PowerPoint PDF 변환"
type: docs
weight: 40
url: /ko/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PowerPoint PDF 변환
- 프레젠테이션을 PDF로
- PPT PDF 변환
- PPT를 PDF로 변환
- PPTX PDF 변환
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint PPT/PPTX를 고품질이며 검색 가능한 PDF로 변환하고, 빠른 코드 예제와 고급 변환 옵션을 제공합니다."
---
## **개요**

JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP 등)을 PDF 형식으로 변환하면 다양한 장점이 있습니다. 여기에는 다양한 장치 간 호환성 및 프레젠테이션의 레이아웃과 서식을 보존하는 것이 포함됩니다. 이 가이드에서는 프레젠테이션을 PDF 문서로 변환하고, 이미지 품질을 제어하는 옵션을 사용하며, 숨김 슬라이드를 포함하고, PDF 파일에 비밀번호를 설정하고, 글꼴 대체를 감지하고, 변환할 특정 슬라이드를 선택하고, 출력 문서에 규정 준수 표준을 적용하는 방법을 보여줍니다.

## **PowerPoint를 PDF로 변환**

Aspose.Slides를 사용하면 다음 형식의 프레젠테이션을 PDF로 변환할 수 있습니다.

* **PPT**
* **PPTX**
* **ODP**

프레젠테이션을 PDF로 변환하려면 파일 이름을 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스의 인수로 전달한 다음 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 메서드를 사용하여 PDF로 저장합니다. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스는 일반적으로 프레젠테이션을 PDF로 변환하는 데 사용되는 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 메서드를 제공합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java은 API 정보와 버전 번호를 출력 문서에 삽입합니다. 예를 들어 프레젠테이션을 PDF로 변환할 때 Aspose.Slides는 Application 필드에 "*Aspose.Slides*"를, PDF Producer 필드에는 "*Aspose.Slides v XX.XX*" 형식의 값을 채웁니다. **Note** Aspose.Slides에 이 정보를 출력 문서에서 변경하거나 제거하도록 지시할 수 없습니다.
{{% /alert %}}

Aspose.Slides를 사용하면 다음을 변환할 수 있습니다.

* 전체 프레젠테이션을 PDF로 변환
* 프레젠테이션의 특정 슬라이드를 PDF로 변환

Aspose.Slides는 프레젠테이션을 PDF로 내보릴 때 원본 프레젠테이션과 매우 유사하게 PDF를 생성합니다. 변환 과정에서 다음 요소와 속성이 정확하게 렌더링됩니다.

* 이미지
* 텍스트 상자 및 도형
* 텍스트 서식
* 단락 서식
* 하이퍼링크
* 머리글 및 바닥글
* 글머리표
* 표

## **PowerPoint를 PDF로 변환**

표준 PowerPoint‑to‑PDF 변환 프로세스는 기본 옵션을 사용합니다. 이 경우 Aspose.Slides는 가능한 최고 품질 수준에서 최적의 설정을 사용하여 제공된 프레젠테이션을 PDF로 변환합니다.

다음 예제는 프레젠테이션을 로드하고 기본 내보내기 설정을 사용하여 모든 표시 슬라이드를 PDF로 저장합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose는 무료 온라인 [**PowerPoint PDF 변환기**](https://products.aspose.app/slides/conversion/ppt-to-pdf)를 제공하여 프레젠테이션‑to‑PDF 변환 프로세스를 시연합니다. 여기서 설명한 절차를 실제로 테스트하려면 이 변환기를 사용해 보세요.
{{% /alert %}}

## **옵션을 사용한 PowerPoint를 PDF로 변환**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 사용자 정의 옵션(속성)을 제공하여 결과 PDF를 맞춤 설정하거나 비밀번호로 잠그거나 변환 프로세스 진행 방식을 지정할 수 있습니다.

### **옵션을 사용한 PowerPoint를 PDF로 변환**

사용자 정의 변환 옵션을 사용하면 래스터 이미지에 대한 선호 품질 설정, 메타파일 처리 방식, 텍스트 압축 수준, 이미지 DPI 등을 정의할 수 있습니다.

다음 예제는 JPEG 품질 90, 이미지 해상도 300 DPI, 메타파일을 PNG로 저장하고 Flate 텍스트 압축을 적용한 PDF 1.5로 프레젠테이션을 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **이미지 압축 자동 선택**

프레젠테이션에 사진이나 스크린샷이 많이 포함된 경우, 내보낸 PDF 크기를 줄이면 이메일이나 다운로드가 쉬워집니다. PDF 내보내기 중 각 이미지에 가장 적합한 압축 알고리즘을 자동으로 선택하려면 `true`와 함께 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/)를 호출하세요.

다음 예제는 기존 프레젠테이션을 로드하고 자동 이미지 압축 선택을 활성화한 뒤 PDF 문서로 저장합니다. 다른 모든 PDF 내보내기 설정은 기본값을 유지합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

이 옵션은 각 이미지에 대해 압축 알고리즘을 선택합니다. [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/)에 전달되는 값을 낮추면 JPEG 이미지 품질이 감소하고, [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/)에 전달되는 값을 낮추면 이미지가 더 낮은 해상도로 다운샘플링되어 디테일이 줄어듭니다. 자동 압축 선택을 활성화해도 이러한 설정 자체가 낮아지지는 않습니다.

이미지 압축 알고리즘을 선택하면 추가 처리 시간과 메모리가 필요합니다. 크기 감소는 프레젠테이션의 이미지와 내보내기 설정에 따라 달라지며, 모든 프레젠테이션에 대해 일정한 감소가 보장되지는 않습니다.

### **PDF 첨부 파일로 포함된 OLE 파일 보존**

프레젠테이션에 포함된 Excel 워크북이 있는 경우 PDF 수신자가 슬라이드뿐만 아니라 워크북 데이터에도 접근할 수 있도록 하고 싶을 수 있습니다. `true`와 함께 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)를 호출하면 포함된 OLE 파일을 결과 PDF의 첨부 파일로 보존합니다.

기본값은 `false`이며, OLE 개체의 미리보기 이미지 또는 아이콘만 PDF 페이지에 렌더링되고 실제 첨부 파일은 포함되지 않습니다. 옵션을 `true`로 설정하면 파일 데이터도 함께 포함됩니다. 미리보기는 여전히 시각적 표현이며, 첨부 파일을 통해 수신자는 별도로 파일을 열거나 저장할 수 있습니다. OLE 개체 자체가 PDF 페이지에서 인터랙티브한 Excel 워크시트로 변환되지는 않습니다.

다음 예제는 이미 Excel 워크북이 포함된 프레젠테이션을 로드하고 워크북을 첨부 파일로 포함하여 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

결과 확인 방법:

1. 파일 첨부 기능을 지원하는 뷰어(예: Adobe Acrobat Reader)에서 내보낸 PDF를 엽니다.
2. 뷰어의 **Attachments** 패널을 열고 포함된 워크북을 찾습니다.
3. 첨부 파일을 저장하고 Excel에서 열어 데이터를 확인하거나, 뷰어가 허용한다면 직접 열어봅니다. PDF 페이지의 미리보기는 첨부 파일과 별개입니다.

{{% alert color="info" title="Note" %}}
PDF/A 표준은 첨부 파일에 제한을 두고 있습니다. PDF/A‑1은 첨부 파일을 금지하고, PDF/A‑2는 PDF/A 첨부 파일만 허용하며, PDF/A‑3은 Excel 워크북을 포함한 기타 파일 유형을 허용합니다. 이는 표준 자체의 요구 사항이며 Aspose.Slides에 특화된 제한이 아닙니다. 이 예제는 기본 PDF 규정 준수 설정을 사용하며 PDF/A 내보내기를 시연하지 않습니다.
{{% /alert %}}

### **숨김 슬라이드 포함하여 PowerPoint를 PDF로 변환**

프레젠테이션에 숨김 슬라이드가 포함된 경우 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 메서드를 `true`로 호출하면 숨김 슬라이드를 결과 PDF 페이지에 포함시킬 수 있습니다.

다음 예제는 숨김 슬라이드를 포함하여 프레젠테이션을 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **비밀번호가 설정된 PDF로 PowerPoint 변환**

다음 예제는 열려면 비밀번호 `password`가 필요한 PDF로 프레젠테이션을 내보냅니다. 접근 권한은 인쇄를 허용하며 고품질 인쇄도 포함합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **글꼴 대체 감지**

Aspose.Slides는 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스 아래에 있는 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 메서드를 제공하여 프레젠테이션‑to‑PDF 변환 과정에서 글꼴 대체를 감지할 수 있게 합니다.

다음 예제는 프레젠테이션을 PDF로 내보내고 콘솔에 글꼴 대체 경고를 출력합니다. 사용 불가능한 글꼴이 대체될 때만 경고가 출력됩니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
글꼴 대체에 대한 자세한 내용은 [글꼴 대체](/slides/ko/nodejs-java/font-substitution/) 문서를 참조하십시오.
{{% /alert %}} 

### **전용 굵은 글꼴이 없는 경우 처리**

프레젠테이션은 해당 글꼴에 전용 굵은 스타일이 없더라도 굵게 서식을 적용할 수 있습니다. 이 경우 합성 굵게가 적용되어 일반 글리프가 인위적으로 두꺼워집니다. PDF에서 해당 텍스트가 너무 무겁게 보이거나 의도와 다르게 표시될 경우 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)를 `true`로 호출해 보세요. 이 옵션은 PDF 내보내기 중에 해당 텍스트를 비트맵으로 렌더링하여 특정 글꼴에 대해 외观을 개선할 수 있습니다. 기본값은 `false`입니다.

샘플 프레젠테이션에는 같은 글꼴을 사용하지만 전용 굵은 스타일이 없는 두 개의 텍스트 상자가 포함되어 있습니다. 다음 예제는 프레젠테이션을 로드하고 전용 굵은 글꼴이 없는 경우 래스터화를 활성화한 뒤 PDF로 내보냅니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

다음 미리보기는 옵션이 비활성화된 출력과 활성화된 출력을 보여줍니다. 이 예제에서 옵션이 비활성화된 경우 굵은 텍스트의 획이 더 두껍게 표시됩니다. 옵션을 활성화하면 획이 더 가벼워지고 일반 텍스트는 변하지 않습니다. 프레젠테이션에 적용할 설정을 선택하기 전에 결과를 비교하십시오.

| 옵션 비활성 (`false`, 기본값) | 옵션 활성 (`true`) |
|---|---|
| ![PDF 지원되지 않는 글꼴 스타일 래스터화 비활성](unsupported-bold-disabled.png) | ![PDF 지원되지 않는 글꼴 스타일 래스터화 활성](unsupported-bold-enabled.png) |

이 예제에서 옵션을 활성화하면 굵은 텍스트만 비트맵으로 변환됩니다. 즉, OCR 없이 텍스트를 선택, 복사 또는 검색할 수 없으며 800 % 확대 시 가장자리가 부드럽게 표시됩니다. 일반 텍스트는 그대로 검색 가능합니다. 옵션을 비활성화하면 두 문자열 모두 텍스트 상태를 유지합니다.

이 옵션은 전용 굵은 글꼴이 없는 경우 굵게 서식이 적용된 텍스트를 래스터화합니다. [글꼴 대체](/slides/ko/nodejs-java/font-substitution/)는 원본 글꼴이 없을 때 다른 글꼴을 선택합니다.

## **PowerPoint에서 선택된 슬라이드만 PDF로 변환**

다음 예제는 프레젠테이션에서 슬라이드 1과 3을 선택하여 PDF로 내보냅니다. 배열의 슬라이드 번호는 1부터 시작하며, 입력 프레젠테이션에 최소 세 개의 슬라이드가 있어야 합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **맞춤 슬라이드 크기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션의 첫 번째 슬라이드를 새 프레젠테이션에 복사하고 슬라이드 크기를 612 × 792 포인트(8.5 × 11 인치)로 지정합니다. 슬라이드 콘텐츠를 맞춰서 단일 슬라이드를 PDF로 내보냅니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 새 프레젠테이션이 생성될 때 만든 빈 슬라이드를 제거합니다.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **노트 슬라이드 보기로 PowerPoint를 PDF로 변환**

다음 예제는 프레젠테이션을 PDF로 내보내면서 각 슬라이드 아래에 발표자 메모를 배치합니다. 결과를 확인하려면 발표자 메모가 포함된 프레젠테이션을 사용하세요.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF에 대한 접근성 및 규정 준수 표준**

Aspose.Slides를 사용하면 [웹 콘텐츠 접근성 지침 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)과 호환되는 변환 절차를 사용할 수 있습니다. 다음 표준 중 하나를 사용해 PowerPoint 문서를 PDF로 내보낼 수 있습니다: **PDF/A1a**, **PDF/A1b**, **PDF/UA**.

다음 코드는 다양한 규정 준수 표준에 따라 여러 PDF를 생성하는 PowerPoint‑to‑PDF 변환 프로세스를 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
Aspose.Slides는 PDF 변환 작업을 지원하며 PDF 파일을 다양한 형식으로 변환할 수 있습니다. [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 변환이 가능합니다. 또한 [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)와 같은 특수 형식으로의 변환도 지원합니다.
{{% /alert %}}

> **Note:** PDF/UA로 내보낼 때 Aspose.Slides는 SmartArt, 차트, 수식과 같은 복잡한 그래픽을 단일 도형으로 처리합니다. 개별 경로 요소는 별도 콘텐츠로 보존되지 않으며 아티팩트로 표시될 수 있습니다; 대체 텍스트는 전체 도형에만 제공됩니다.

## **FAQ**

**여러 PowerPoint 파일을 한 번에 PDF로 변환할 수 있나요?**

예, Aspose.Slides는 여러 PPT 또는 PPTX 파일을 PDF로 일괄 변환하는 기능을 지원합니다. 파일을 반복 처리하며 프로그래밍 방식으로 변환 과정을 적용할 수 있습니다.

**변환된 PDF에 비밀번호를 설정할 수 있나요?**

예. 변환 과정에서 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스를 사용해 비밀번호를 설정하고 접근 권한을 정의할 수 있습니다.

**PDF에 숨김 슬라이드를 포함하려면 어떻게 해야 하나요?**

[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스의 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 메서드를 `true`로 호출하면 결과 PDF에 숨김 슬라이드가 포함됩니다.

**Aspose.Slides가 PDF에서 높은 이미지 품질을 유지할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 클래스의 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/)와 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 메서드를 사용해 이미지 품질을 고품질로 유지할 수 있습니다.

**Aspose.Slides가 PDF/A 규정 준수 표준을 지원하나요?**

예. Aspose.Slides는 [다양한 표준](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/)을 지원하며, PDF/A1a, PDF/A1b, PDF/UA 등 접근성 및 보존 요구 사항을 충족하는 PDF를 내보낼 수 있습니다.

## **추가 리소스**

- [Aspose.Slides for Node.js via Java 문서](/slides/ko/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 레퍼런스](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 무료 온라인 변환기](https://products.aspose.app/slides/conversion)