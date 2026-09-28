---
title: Android에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 걸어 내린 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 단락, 구절, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java는 텍스트를 텍스트 프레임, 단락 및 구절의 계층 구조로 나타냅니다:

* [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 은 도형 내 텍스트 컨테이너를 나타내며 단락 컬렉션에 대한 액세스를 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/) 은 텍스트 프레임의 단일 단락을 나타내며 구절 및 단락 수준 서식에 대한 액세스를 제공합니다.
* [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 은 단락 내 텍스트 실행을 나타냅니다. 각 구절은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구절을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구절이 있는 단락 만들기**

다음 단계는 세 개의 단락을 가진 텍스트 프레임을 만들고, 각 단락에 세 개의 구절을 포함합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 추가 [IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/) 객체를 추가합니다.
6. 각 단락에 세 개의 구절을 포함하도록 충분한 [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 객체를 추가합니다. 기본 단락에는 이미 빈 구절이 하나 포함되어 있습니다.
7. 각 구절의 텍스트를 설정합니다.
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

이 Android via Java 예제는 위 단계들을 구현합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **글머리표 및 번호 매기기 목록 만들기**

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서는 목록 설정을 [IBulletFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/) 을 통해 정의합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 선택한 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리표용 [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/) 을 생성합니다.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Symbol](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정하고 글머리표 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리표 색상 및 글머리표 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Numbered](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정합니다.
11. 번호 매기기 글머리표 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

이 Android via Java 예제는 기호 글머리표와 번호 매기기 글머리표를 만듭니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호 또는 숫자 대신 사용자 지정 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가하고 해당 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리표 이미지를 로드하고 프레젠테이션의 이미지 컬렉션에 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 로 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/) 을 생성하고 텍스트를 설정합니다.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Picture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정합니다.
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#getPicture--) 를 통해 이미지를 지정하고 글머리표 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

이 Android via Java 예제는 그림 글머리표를 만듭니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **다단계 목록 만들기**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 를 설정하여 단락을 목록의 서로 다른 수준에 배치합니다. 최상위 수준은 깊이가 `0` 입니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 을 생성하고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가하고 해당 텍스트 프레임에서 기본 단락을 삭제합니다.
3. 네 개의 단락을 만들고 글머리표 기호를 구성합니다.
4. 각 단락의 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 값을 `0`, `1`, `2`, `3` 으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 Android via Java 예제는 네 수준의 글머리표 목록을 만듭니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **번호 매기기 목록 항목을 사용자 지정 값으로 시작**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 를 사용하여 번호 매기기 단락에 표시되는 시작 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 을 생성하고 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 삭제합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 해당 단락에 대해 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 를 각각 `2`, `3`, `7` 로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 Android via Java 예제는 각 단락에 사용자 지정 시작 번호를 할당합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **단락 레이아웃 및 끝 속성 제어**

### **첫 줄 들여쓰기 설정**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백에 상대적으로 첫 줄만 이동합니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 를 사용합니다. 첫 줄만 이동하려면 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 를 사용합니다.

아래 예제는 여러 단락을 만들고 서로 다른 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떻게 영향을 주는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각 다른 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

### **걸어 내린 들여쓰기 설정**

걸어 내린 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 에 음수 값을 전달하여 첫 줄을 단락 본문에 대해 왼쪽으로 이동시켜 구현합니다.

실제로 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 은 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 은 해당 여백에 대한 첫 줄의 위치를 정의합니다. 걸어 내린 들여쓰기를 만들려면 `setMarginLeft` 에 양수 값을, `setIndent` 에 음수 값을 전달합니다.

이 서식은 참고문헌, 인용문, 용어집 항목 및 랩된 줄이 첫 줄 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 에 양수 값을 전달하여 단락을 생성합니다.
6. 걸어 내린 들여쓰기 효과를 만들기 위해 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 에 음수 값을 전달합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락에 걸어 내린 들여쓰기를 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![단락의 걸어 내린 들여쓰기](hanging_indent.png)

### **끝 단락 실행 속성 설정**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 은 단락 끝 표시의 서식을 제어합니다. 다음 예제는 두 번째 단락의 끝 표시에 글꼴 크기와 라틴 글꼴을 할당합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 을 로드하고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가하고 기본 단락을 삭제합니다.
3. 두 개의 단락을 만들고 텍스트 구절을 추가합니다.
4. 두 번째 단락 끝 표시용 [PortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portionformat/) 을 생성합니다.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 와 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) 를 설정합니다.
6. [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 로 형식을 할당하고 프레젠테이션을 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **렌더링된 줄 수 세기**

줄 바꿈 및 줄 끝 구두점에 영향을 주는 단락 규칙에 대해서는 [Control Line Breaking](/slides/ko/androidjava/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/androidjava/text-formatting/#control-hanging-punctuation) 을 참조하십시오.

[IParagraph.getLinesCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) 를 사용하여 텍스트 레이아웃 후 단락이 차지하는 줄 수를 셀 수 있습니다. 이 기능은 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [ITextFrame.getParagraphs](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#getParagraphs--) 에 있는 항목 중 하나이며 여러 개의 렌더링된 줄을 차지할 수 있습니다. 단락 내 명시적 줄 바꿈은 새 줄을 강제로 만들지만 다른 단락을 생성하지는 않습니다. 자동 줄 바꿈은 명시적인 줄 바꿈 문자를 삽입하지 않고 가용 너비에 따라 줄을 생성합니다. 따라서 단락 수나 줄 바꿈 문자만으로는 렌더링된 줄 수를 알 수 없습니다.

다음 예제는 텍스트 도형을 만들고, 줄 수를 계산한 다음, 도형을 좁히고, 짧은 문자열로 텍스트를 교체합니다. 줄 바꿈이 활성화되고 자동 맞춤이 비활성화되어 도형 너비가 줄 바꿈을 제어하고 텍스트나 도형이 자동으로 축소되지 않게 합니다. 도형 치수는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 줄 수를 합산합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

이 텍스트와 치수로 도형을 좁히면 줄 수가 증가하고, 짧은 문자열로 교체하면 줄 수가 감소합니다. 정확한 개수는 글꼴 가용성 및 대체, 글꼴 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 다를 수 있습니다. 템플릿을 확인할 때 대상 환경에 맞는 글꼴 및 레이아웃 설정을 사용하십시오.

줄 수만으로 텍스트가 컨테이너를 초과하는지 여부를 판단할 수 없습니다. 사용 가능한 높이, 줄 높이, 단락 및 줄 간격, 자동 맞춤 동작도 중요합니다. 자동 맞춤이 비활성화된 경우 단일 줄이라도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구절로 변환합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 접근하고 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 삭제합니다.
4. 소스 HTML 파일을 읽습니다.
5. HTML 문자열을 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 Android via Java 예제는 HTML을 텍스트 프레임에 가져옵니다:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 을 사용하여 선택한 단락 범위를 HTML로 내보냅니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트를 포함한 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 찾습니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 를 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

이 Android via Java 예제는 첫 번째 텍스트 도형의 모든 단락을 내보냅니다:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **단락을 이미지로 렌더링**

[IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage--) 은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 를 반환합니다. 반환된 이미지를 [IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 파일이나 스트림에 저장하십시오. 도형 전체를 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage--) 은 단락이 상위 컬렉션에 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 스케일로 단락 렌더링**

sample.pptx 라는 파일에 하나의 슬라이드가 있고, 첫 번째 도형이 세 개의 단락을 포함하는 텍스트 상자라고 가정합니다.

![텍스트 상자와 세 개의 단락](paragraph_to_image_input.png)

다음 예제는 일반 텍스트 도형의 두 번째 단락을 기본 스케일로 렌더링하고 PNG 형식으로 반환된 이미지를 저장합니다. `finally` 블록은 이미지가 올바르게 해제되는 것을 보장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

결과:

![단락 이미지](paragraph_to_image_output.png)

#### **테이블 셀에서 스케일링을 적용해 단락 렌더링**

`float` 타입의 `scaleX` 와 `float` 타입의 `scaleY` 매개변수를 받아들이는 [IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) 오버로드를 사용합니다. 아래 예제는 표를 만들고 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 후 PNG 이미지로 저장합니다.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 `2` 를 두 축에 적용하면 너비와 높이가 기본 크기의 약 두 배가 되어 네 배의 픽셀 수가 됩니다. 큰 규모는 확대나 고해상도 출력에 더 선명한 텍스트를 제공하지만 메모리 사용량과 파일 크기가 증가합니다. `1` 미만의 계수는 세부 정보가 적은 작은 이미지를 만듭니다. 비율을 유지하려면 동일한 계수를 사용하고, 가로와 세로 계수를 다르게 하면 출력이 독립적으로 늘어나거나 줄어듭니다.

전체 도형을 [IShape.getImage] 로 렌더링하는 것은 출력에 도형의 채우기, 테두리 또는 다른 시각적 컨텍스트가 포함되어야 할 때 여전히 유용합니다. 단락만의 이미지는 [IParagraph.getImage] 를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) 를 설정하여 줄 바꿈을 비활성화하면 텍스트 프레임 가장자리에서 줄이 끊기지 않습니다.

**특정 단락의 슬라이드상의 정확한 경계를 얻으려면 어떻게 해야 하나요?**

[IParagraph.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getRect--) 을 사용하면 단락의 경계 사각형을 가져올 수 있습니다. 개별 구절의 경계는 [IPortion.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getRect--) 로 확인합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디서 제어하나요?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 은 단락 수준 설정이며 개별 구절 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구절에 대해 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 을 설정하면 하나의 단락에 여러 언어의 텍스트를 포함할 수 있습니다.