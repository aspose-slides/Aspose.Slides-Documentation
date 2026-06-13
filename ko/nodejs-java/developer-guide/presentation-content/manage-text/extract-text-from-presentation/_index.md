---
title: JavaScript에서 프레젠테이션의 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/nodejs-java/extract-text-from-presentation/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 가져오기
- 슬라이드에서 텍스트 가져오기
- 프레젠테이션에서 텍스트 가져오기
- PowerPoint에서 텍스트 가져오기
- OpenDocument에서 텍스트 가져오기
- PPT에서 텍스트 가져오기
- PPTX에서 텍스트 가져오기
- ODP에서 텍스트 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출합니다. 시간을 절약할 수 있는 간단한 단계별 가이드를 따라 보세요."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 일반적이면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 포맷)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 검색하는 것은 분석, 자동화, 인덱싱 또는 콘텐츠 마이그레이션에 매우 중요할 수 있습니다.

이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 PPT, PPTX 및 ODP를 포함한 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대해 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 반복하면서 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for Node.js via Java는 [SlideUtil](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/) 클래스를 제공합니다. 이 클래스는 프레젠테이션 또는 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 노출합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [getAllTextBoxes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) 메서드를 사용하십시오. 이 메서드는 슬라이드 객체를 매개변수로 받습니다. 실행되면 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾고, 텍스트 형식을 그대로 유지한 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 객체 배열을 반환합니다.

다음 코드 스니펫은 프레젠테이션 첫 번째 슬라이드의 모든 텍스트를 추출합니다:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션에서 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/) 클래스가 제공하는 [getAllTextFrames](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 정적 메서드를 사용하십시오. 이 메서드는 두 개의 매개변수를 받습니다:

1. 첫 번째는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 객체입니다.
1. 두 번째는 프레젠테이션에서 텍스트를 스캔할 때 마스터 슬라이드를 포함할지 여부를 나타내는 `boolean` 값입니다.

이 메서드는 텍스트 형식 정보를 포함한 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 객체 배열을 반환합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트 및 형식 정보를 스캔합니다.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **구분된 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/) 클래스는 프레젠테이션에서 모든 텍스트를 추출하는 메서드도 제공합니다:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textextractionarrangingmode/) 열거형 인자는 텍스트 추출 결과를 정리하는 방식을 나타내며 다음 값으로 설정할 수 있습니다:
- `Unarranged` - 슬라이드 내 위치와 무관한 원시 텍스트.
- `Arranged` - 슬라이드와 동일한 순서대로 정렬된 텍스트.

속도가 중요한 경우에는 정렬되지 않은 모드를 사용할 수 있으며, 이는 정렬된 모드보다 빠릅니다.

[PresentationText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationtext/)은 프레젠테이션에서 추출한 원시 텍스트를 나타냅니다. `getSlidesText` 메서드는 각 슬라이드의 텍스트를 나타내는 객체 배열을 반환합니다. 각 슬라이드 텍스트 객체는 다음 메서드를 제공합니다:
- Its `getText` 메서드는 슬라이드 도형 내의 텍스트를 반환합니다.
- Its `getMasterText` 메서드는 이 슬라이드와 연결된 마스터 슬라이드 도형 내의 텍스트를 반환합니다.
- Its `getLayoutText` 메서드는 이 슬라이드와 연결된 레이아웃 슬라이드 도형 내의 텍스트를 반환합니다.
- Its `getNotesText` 메서드는 이 슬라이드와 연결된 노트 슬라이드 도형 내의 텍스트를 반환합니다.
- Its `getCommentsText` 메서드는 이 슬라이드와 연결된 댓글 내의 텍스트를 반환합니다.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**대용량 프레젠테이션을 텍스트 추출 시 Aspose.Slides는 얼마나 빠르게 처리합니까?**

Aspose.Slides는 고성능을 위해 최적화되어 있어 [대용량 프레젠테이션](/slides/ko/nodejs-java/open-presentation/)도 처리할 수 있으므로 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides가 프레젠테이션 내 테이블 및 차트에서 텍스트를 추출할 수 있나요?**

예. Aspose.Slides는 테이블 및 차트와 관련된 객체를 포함한 많은 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 체험 버전의 Aspose.Slides를 사용하여 텍스트를 추출할 수 있지만, [일부 제한](/slides/ko/nodejs-java/licensing/)이 있어 제한된 슬라이드 수만 처리할 수 있습니다. 제한 없이 사용하고 대용량 프레젠테이션을 처리하려면 정식 라이선스를 구매하는 것이 권장됩니다.