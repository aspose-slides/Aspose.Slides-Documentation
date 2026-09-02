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
- 걸림 들여쓰기
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
description: "Aspose.Slides for Android via Java를 사용하여 단락, 구획, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java 은 텍스트를 텍스트 프레임, 단락 및 구획의 계층 구조로 나타냅니다.

* [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 은 도형의 텍스트 컨테이너를 나타내며 해당 도형의 단락 컬렉션에 접근할 수 있게 합니다.
* [IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/) 은 텍스트 프레임 내의 하나의 단락을 나타내며 그 구획들과 단락 수준 서식에 접근할 수 있습니다.
* [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 은 단락 내의 텍스트 실행을 나타냅니다. 각 구획은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구획을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구획을 가진 단락 만들기**

다음 단계는 세 개의 구획을 각각 포함하는 세 개의 단락을 가진 텍스트 프레임을 생성합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 추가 [IParagraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/) 객체를 추가합니다.
6. 각 단락이 세 개의 구획을 포함하도록 충분한 [IPortion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/) 객체를 추가합니다. 기본 단락에는 이미 빈 구획 하나가 포함되어 있습니다.
7. 각 구획의 텍스트를 설정합니다.
8. [IPortion.getPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 단계들을 구현합니다:

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

글머리표와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서는 목록 설정이 [IBulletFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/) 을 통해 정의됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. 선택한 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리표용 [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/) 을 생성합니다.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Symbol](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 색상 및 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Numbered](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정합니다.
11. 번호 매기기 글머리 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 기호 글머리표와 번호 매기기 글머리표를 생성합니다:

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

그림 글머리표를 사용하면 기호 또는 숫자 대신 사용자 정의 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가하고 해당 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 이미지를 로드하고 이를 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 로 프레젠테이션 이미지 컬렉션에 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/) 을 생성하고 텍스트를 설정합니다.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 을 [BulletType.Picture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/) 로 설정합니다.
8. [IBulletFormat.getPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#getPicture--) 을 통해 이미지를 할당하고 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 그림 글머리표를 생성합니다:

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
3. 네 개의 단락을 만들고 글머리 기호를 구성합니다.
4. 각 단락의 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 값을 `0`, `1`, `2`, `3` 으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 네 단계 글머리 목록을 생성합니다:

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

### **번호 매기기 항목을 사용자 지정 값으로 시작**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 를 사용하여 번호 매기기 단락에 표시될 초기 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 을 생성하고 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 삭제합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 각 단락에 대해 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 를 각각 `2`, `3`, `7` 로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 각 단락에 사용자 지정 시작 번호를 할당합니다:

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

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백에 상대적으로 첫 번째 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동하려면 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 를 사용하고, 첫 줄만 이동하려면 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 를 사용합니다.

아래 예제는 여러 단락을 생성하고 다양한 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 값으로 첫 줄 들여쓰기가 단락 레이아웃에 어떤 영향을 미치는지 보여 줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각에 다른 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여 줍니다:

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

### **걸림 들여쓰기 설정**

걸림 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에서 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 에 음수 값을 전달하여 첫 줄을 단락 본문에 상대적으로 왼쪽으로 이동시킵니다.

실제로는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 이 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 이 첫 줄의 위치를 그 여백에 상대적으로 정의합니다. 걸림 들여쓰기를 만들려면 `setMarginLeft` 에 양수 값을, `setIndent` 에 음수 값을 전달합니다.

이 서식은 참고문헌, 인용문, 용어 사전 항목 및 다른 단락에서 줄 바꿈이 첫 줄 첫 글자 아래가 아니라 본문 아래에 정렬되어야 할 때 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
4. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 에 양수 값을 전달합니다.
6. 걸림 들여쓰기 효과를 만들기 위해 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 에 음수 값을 전달합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락에 걸림 들여쓰기를 설정하는 방법을 보여 줍니다:

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

![단락의 걸림 들여쓰기](hanging_indent.png)

### **끝 단락 실행 속성 설정**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 은 단락 끝 표시(marks)의 서식을 제어합니다. 다음 예제는 두 번째 단락의 끝 표시에 글꼴 크기와 라틴 글꼴을 할당합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 을 로드하고 슬라이드에 접근합니다.
2. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가하고 기본 단락을 삭제합니다.
3. 두 개의 단락을 만들고 텍스트 구획을 추가합니다.
4. 두 번째 단락의 끝 표시를 위한 [PortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portionformat/) 을 생성합니다.
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

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구획으로 변환합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 추가합니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근하고 기본 단락을 삭제합니다.
4. 원본 HTML 파일을 읽습니다.
5. HTML 문자열을 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 Android via Java 예제가 HTML을 텍스트 프레임에 가져옵니다:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 을 사용하여 선택된 단락 범위를 HTML로 내보냅니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트가 포함된 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 를 찾습니다.
3. 도형의 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/) 에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 를 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

다음 Android via Java 예제가 첫 번째 텍스트 도형의 모든 단락을 내보냅니다:

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

[IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage--) 은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 를 반환합니다. 반환된 이미지는 [IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 파일이나 스트림에 저장할 수 있습니다. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage--) 은 단락이 상위 컬렉션에 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없을 경우 `null` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 반드시 해제하십시오.

#### **기본 배율로 단락 렌더링**

예를 들어 sample.pptx 파일에 슬라이드가 하나 있고 첫 번째 도형이 세 개의 단락을 포함하는 텍스트 상자라고 가정합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 두 번째 단락을 일반 텍스트 도형에서 기본 배율로 렌더링하고 PNG 형식으로 저장합니다. `finally` 블록은 이미지가 올바르게 해제되도록 보장합니다.

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

#### **표 셀에서 배율을 적용해 단락 렌더링**

`float scaleX` 와 `float scaleY` 매개변수를 받는 [IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) 오버로드를 사용하여 가로 및 세로 배율을 설정합니다. 다음 예제는 표를 만들고 첫 번째 셀의 단락을 기본 폭·높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다.

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

배율 계수 `1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 계수를 모두 `2` 로 지정하면 이미지의 가로·세로가 기본 치수의 약 두 배가 되어 픽셀 수는 네 배가 됩니다. 큰 계수는 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 계수는 상세 정보가 적은 작은 이미지를 생성합니다. 비율을 유지하려면 가로·세로 계수를 동일하게 사용하고, 서로 다른 값을 사용하면 이미지가 개별 축에 따라 늘어나거나 줄어듭니다.

전체 도형을 [IShape.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getImage--) 로 렌더링하는 것은 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함해야 할 때 여전히 유용합니다. 단락 전용 이미지는 [IParagraph.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getImage--) 를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) 를 설정하여 텍스트 프레임의 가장자에서 줄이 끊기지 않도록 할 수 있습니다.

**특정 단락의 정확한 슬라이드 내 경계를 어떻게 얻을 수 있나요?**

[IParagraph.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getRect--) 을 사용하여 단락의 경계 사각형을 가져옵니다. [IPortion.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportion/#getRect--) 은 개별 구획의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디에서 제어되나요?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 은 단락 수준 설정이며 개별 구획 서식에 관계없이 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구획에 대해 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 을 설정하면 하나의 단락에 여러 언어의 텍스트를 포함시킬 수 있습니다.