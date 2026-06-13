---
title: Android에서 프레젠테이션의 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출하세요. 간단한 단계별 가이드를 따라 시간을 절약하십시오."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 개발자가 슬라이드 콘텐츠를 다룰 때 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 가져오는 것은 분석, 자동화, 인덱싱, 또는 콘텐츠 마이그레이션 등에 중요할 수 있습니다.

이 문서에서는 Aspose.Slides for Android via Java를 사용하여 PPT, PPTX 및 ODP와 같은 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대한 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 순회하면서 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for Android via Java는 [SlideUtil](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/) 클래스를 제공합니다. 이 클래스는 프레젠테이션 또는 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 static 메서드를 제공합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [getAllTextBoxes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 메서드를 사용합니다. 이 메서드는 [IBaseSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseslide/) 유형의 객체를 매개변수로 받아들입니다. 실행되면 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾아 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 유형의 객체 배열을 반환하며 텍스트 서식도 보존합니다.

다음 코드 스니펫은 프레젠테이션의 첫 번째 슬라이드에서 모든 텍스트를 추출합니다:
```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션의 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/) 클래스에서 제공하는 [getAllTextFrames](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) static 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다:

1. 첫 번째 매개변수는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [IPresentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/) 객체입니다.
2. 두 번째 매개변수는 프레젠테이션의 텍스트를 스캔할 때 마스터 슬라이드를 포함할지 여부를 나타내는 `boolean` 값입니다.

이 메서드는 텍스트 서식 정보를 포함하는 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 유형의 객체 배열을 반환합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트 및 서식 세부 정보를 스캔합니다.
```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **분류 및 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationfactory/) 클래스는 또한 프레젠테이션에서 모든 텍스트를 추출하는 메서드를 제공합니다:
```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textextractionarrangingmode/) 열거형 인자는 텍스트 추출 결과를 정리하는 모드를 나타내며 다음 값으로 설정할 수 있습니다:
- `Unarranged` - 슬라이드상의 위치와 무관한 원시 텍스트.
- `Arranged` - 슬라이드와 동일한 순서대로 정렬된 텍스트.

속도가 중요한 경우 정렬되지 않은 모드(`Unarranged`)를 사용할 수 있으며, 이는 정렬된 모드보다 더 빠릅니다.

[IPresentationText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationtext/)은 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. `getSlidesText` 메서드는 [ISlideText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidetext/) 유형의 객체 배열을 반환합니다. 각 객체는 해당 슬라이드의 텍스트를 나타냅니다. [ISlideText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidetext/) 유형의 객체는 다음 메서드를 제공합니다:

- `getText` - 슬라이드 도형 내의 텍스트.
- `getMasterText` - 해당 슬라이드와 연결된 마스터 슬라이드 도형 내의 텍스트.
- `getLayoutText` - 해당 슬라이드와 연결된 레이아웃 슬라이드 도형 내의 텍스트.
- `getNotesText` - 해당 슬라이드와 연결된 노트 슬라이드 도형 내의 텍스트.
- `getCommentsText` - 해당 슬라이드와 연결된 주석 내의 텍스트.
```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Aspose.Slides는 텍스트 추출 중 대용량 프레젠테이션을 얼마나 빠르게 처리합니까?**

Aspose.Slides는 고성능을 위해 최적화되어 있어 대형 프레젠테이션도 [large presentations](/slides/ko/androidjava/open-presentation/)를 처리할 수 있어 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides는 프레젠테이션 내 테이블 및 차트에서 텍스트를 추출할 수 있습니까?**

예. Aspose.Slides는 테이블 및 차트와 같은 슬라이드 요소를 포함한 많은 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 체험 버전의 Aspose.Slides를 사용하여 텍스트를 추출할 수 있지만, [certain limitations](/slides/ko/androidjava/licensing/)과 같이 슬라이드 수가 제한되는 등 몇 가지 제한이 있습니다. 무제한 사용 및 대용량 프레젠테이션 처리를 위해서는 전체 라이선스를 구매하는 것이 권장됩니다.