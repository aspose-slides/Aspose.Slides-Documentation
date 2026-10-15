---
title: Java에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 행걸이 들여쓰기
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 단락, 구절, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 생성하고 서식 지정하는 방법을 배우세요."
---
## **개요**

Aspose.Slides for Java는 텍스트를 텍스트 프레임, 단락 및 구절의 계층 구조로 나타냅니다:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) shape에서 텍스트 컨테이너를 나타내며 해당 단락 컬렉션에 대한 액세스를 제공합니다.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 텍스트 프레임에서 하나의 단락을 나타내며 해당 구절 및 단락 수준 서식에 대한 액세스를 제공합니다.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) 단락 내에서 텍스트 실행을 나타냅니다. 각 구절은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구절을 사용하여 다른 글꼴, 색상, 크기 및 기타 서식이 적용된 텍스트를 포함할 수 있습니다.

## **단락 생성 및 서식 지정**

shape의 텍스트 프레임에 단락을 만들고 구절을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락 내에 여러 구절을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **다중 구절을 사용한 단락 생성**

다음 Java 예제는 세 개의 단락을 생성하며, 각 단락은 [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) 컬렉션에서 반환된 컬렉션에 세 개의 텍스트 실행을 포함합니다. 기본 단락과 빈 구절을 재사용하고, 나머지 단락과 구절을 추가합니다. 서식은 [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--)을 통해 적용됩니다: 각 단락의 첫 번째 구절은 빨간색, 굵게, 15포인트이며; 두 번째는 파란색, 기울임, 18포인트입니다. 세 번째 구절은 기본 서식을 유지합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

기호, 숫자 또는 사용자 지정 이미지를 사용하여 단락 텍스트를 목록으로 정리합니다. 이 섹션의 예제는 글머리표 서식, 다중 레벨 목록 및 사용자 지정 시작 번호를 다룹니다.

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 쉽게 스캔하도록 합니다. Aspose.Slides에서는 목록 설정을 [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/)을 통해 정의합니다.

이 Java 예제는 동일한 텍스트 프레임에 기호 글머리표와 번호 매기기 항목을 추가합니다. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)는 글머리표 유형을 선택하고, [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-)는 기호를 제공하며, [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)는 번호 매기기 스타일을 선택합니다. 두 항목 모두 높이 100%의 검정색 글머리표와 25포인트 단락 들여쓰기를 사용합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

그림 글머리표는 기호나 숫자 대신 사용자 지정 이미지를 사용할 수 있게 합니다.

이 Java 예제는 프레젠테이션의 이미지 컬렉션에 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)으로 이미지를 추가하고 이를 단락 글머리표로 사용합니다. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)를 호출하여 그림 글머리표를 사용하도록 하고, [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--)를 통해 이미지를 지정합니다. [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-)를 100%로 설정하여 단락 텍스트에 상대적인 크기로 글머리표를 조정합니다:

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

### **다중 레벨 목록 만들기**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-)를 설정하여 리스트의 서로 다른 레벨에 단락을 배치합니다. 최상위 레벨의 깊이는 `0`입니다.

이 Java 예제는 네 개의 단락에 대해 0부터 3까지의 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 값을 할당하여 하나의 텍스트 프레임 내에 계층 구조를 만듭니다. 각 단락은 기호 글머리표를 사용하며, [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-)가 원형 글머리표와 하이픈을 교대로 사용하여 인접 레벨을 구분합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **사용자 지정 값으로 번호 매기기 목록 시작**

[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)를 사용하여 번호 매기기 단락에 표시될 초기 번호를 설정합니다.

이 Java 예제는 세 개의 단락에 번호 매기기를 사용하도록 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)를 설정하고, [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 구성되어 표시되는 번호가 건너뛸 수 있게 합니다:

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

단락 여백과 들여쓰기를 조정하여 첫 줄과 줄 바꿈된 줄의 위치를 제어합니다. 또한 표시되는 텍스트 구절과 별도로 단락 끝 표시를 서식 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 설정은 단락 왼쪽 여백에 대해 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키며, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 때는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)를 사용하고, 첫 줄만 이동해야 할 때는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-)를 사용합니다.

다음 예제는 세 단락에 동일한 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20포인트와 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 각각 0, 20, 40포인트 적용합니다. 첫 줄은 점점 큰 오프셋에서 시작하고, 줄 바꿈된 줄은 동일한 왼쪽 여백을 유지합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **행걸이 들여쓰기 설정**

행걸이 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에서 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 속성을 사용하여 이 효과를 만들 수 있습니다. `Indent`를 음수 값으로 설정하면 단락 본문에 대해 첫 줄을 왼쪽으로 이동시킵니다.

실제로는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)이 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-)가 해당 여백에 대한 첫 줄 위치를 정의합니다. 행걸이 들여쓰기를 만들려면 양의 `MarginLeft` 값과 음의 `Indent` 값을 설정합니다.

이 서식은 참고 문헌, 인용, 용어 정의 등 줄 바꿈된 줄이 첫 줄 첫 글자 아래가 아니라 단락 본문 아래에 맞춰야 할 경우에 유용합니다.

다음 Java 예제는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 값을 40과 60포인트로, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 -20과 -30포인트로 짝지어 적용합니다. 각 단락에서 첫 줄은 줄 바꿈된 줄보다 왼쪽에서 시작하고, 두 번째 단락은 더 깊은 행걸이 들여쓰기를 가집니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![단락의 행걸이 들여쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 메서드는 단락 끝 표시의 서식을 제어합니다. 다음 예제는 [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/)을 생성하고, [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-)을 48포인트, [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)를 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 끝 표시에 할당하여 표시 텍스트 구절은 변경되지 않게 합니다:

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

## **렌더링된 라인 수 계산**

줄 바꿈 제어와 [줄 바꿈 제어](/slides/ko/java/text-formatting/#control-line-breaking) 및 [행걸이 구두점 제어](/slides/ko/java/text-formatting/#control-hanging-punctuation)에 영향을 주는 단락 규칙에 대해서는 해당 섹션을 참조하십시오.

[IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--)를 사용하여 텍스트 레이아웃 후 단락이 차지하는 라인 수를 자동 줄 바꿈을 포함해 계산합니다. 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--)의 항목 중 하나이며 여러 렌더링 라인을 차지할 수 있습니다. 단락 내 명시적 줄 바꿈은 새 줄을 강제하지만 새 단락을 만들지는 않습니다. 자동 줄 바꿈은 텍스트에 명시적 줄 바꿈을 삽입하지 않고 가용 너비에 따라 라인을 생성합니다. 따라서 단락 수나 줄 바꿈 문자 수를 세는 것으로는 렌더링된 라인 수를 얻을 수 없습니다.

다음 예제는 텍스트 도형을 만들고, 라인 수를 세고, 도형을 좁힌 뒤 텍스트를 짧은 문자열로 교체합니다. 예제는 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)로 줄 바꿈을 활성화하고 [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-)으로 자동 맞춤을 비활성화하여 도형 너비가 줄 바꿈을 제어하도록 합니다. 각 측정은 [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--)를 사용합니다. 도형 크기는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 라인 수를 합산합니다:

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

이 텍스트와 차원으로 도형을 좁히면 라인 수가 증가하고, 짧은 문자열로 교체하면 라인 수가 감소합니다. 정확한 수는 글꼴 가용성, 대체, 글꼴 크기, 여백, 들여쓰기, 줄 바꿈 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때 대상 환경에 맞는 글꼴 및 레이아웃 설정을 사용하십시오.

라인 수만으로 텍스트가 컨테이너를 초과하는지 판단할 수 없습니다. 사용 가능한 높이, 라인 높이, 단락 및 라인 간격, 자동 맞춤 동작도 중요합니다; 줄 바꿈이 비활성화된 경우 단일 라인이라도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

HTML을 사용하여 텍스트를 프레젠테이션에 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보낼 수 있습니다. 이 섹션에서는 테이블 셀의 단락을 포함한 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구절로 변환합니다.

이 Java 예제는 파일에서 HTML을 읽고 마크업을 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)에 전달합니다. 텍스트 프레임의 기본 단락을 지워 프레임에 가져온 내용만 포함되도록 합니다. 직사각형 도형은 슬라이드 각 면에 10포인트 여백을 남깁니다:

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

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)을 사용하여 선택된 단락 범위를 HTML로 내보냅니다. 웹사이트에서 프레젠테이션 텍스트를 재사용할 때 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 전달하지 않고 로컬 강조를 유지하고 싶을 수 있습니다. [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-)을 설정하여 변환기가 서식 상속을 따르는 깊이를 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx)을 다운로드하고 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 포함된 텍스트 도형이 하나 있습니다. 입력은 의도적으로 여러 서식 레벨을 사용합니다:

- 프레젠테이션의 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 1단계 텍스트 스타일은 파란색 텍스트와 기울임을 제공합니다.
- 단락은 명시적으로 굵은 텍스트를 설정합니다.
- 두 번째 구절인 "explicitly red 18pt"은 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 완전한 예제는 동일한 단락을 세 번 내보냅니다. 내보내기 메서드에 [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/)을 전달하고 각 결과를 별도의 UTF-8 HTML 파일로 작성합니다:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

생성된 HTML에는 첫 구절 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표는 관련 선언을 나열하며, 명확성을 위해 다른 생성 속성은 생략되었습니다.

| 출력 | 첫 구절에 대한 관련 CSS | 모양 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능하면 28pt 크기의 파란색 굵은 기울임 텍스트. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색 굵은 기울임 텍스트; 주변 페이지나 브라우저가 글꼴 패밀리와 크기를 제공합니다. |
| `ParagraphOnly.html` | `font-weight:bold` | 굵은 텍스트; 주변 페이지나 브라우저가 글꼴 패밀리, 크기, 색상 및 기울임 스타일을 제공합니다. |

두 번째 구절은 세 출력 모두에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold`를 유지합니다. 또한 `All` 및 `TextBox`에서는 기울임을 유지하지만 `ParagraphOnly`에서는 유지되지 않습니다. 따라서 상속 제한은 단락이나 구절에 명시적으로 지정된 서식을 제거하지 않습니다.

같은 브라우저에서 파일을 열어 비교하십시오. 제한된 두 모드에서는 누락된 CSS 속성이 대상 페이지의 스타일이나 브라우저 기본값에 의해 해결되므로 최종 모양은 HTML이 사용되는 위치에 따라 달라집니다.

### **단락을 이미지로 렌더링**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)를 반환합니다. 결과를 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)로 파일이나 스트림에 저장하십시오. 포함된 도형을 렌더링하거나 비트를 수동으로 자를 필요가 없습니다.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)은 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `null`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 비율로 단락 렌더링**

예제는 하나의 슬라이드가 포함된 프레젠테이션을 사용하며, 첫 번째 도형은 세 단락이 포함된 텍스트 상자입니다.

![세 단락이 포함된 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 인덱스 1의 두 번째 단락을 선택하고 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)을 스케일 매개변수 없이 호출합니다. 도형에 필요한 단락이 포함되어 있는지와 렌더링이 이미지를 반환하는지를 확인한 후 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)으로 PNG 형식으로 저장합니다. `finally` 블록에서 사용 후 이미지를 해제합니다.

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

#### **테이블 셀에서 스케일링으로 단락 렌더링**

`float scaleX`와 `float scaleY` 매개변수를 받아 가로·세로 스케일 계수를 설정하는 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) 오버로드를 사용합니다. 다음 예제는 표를 만든 뒤 첫 번째 셀에서 단락을 기본 너비·높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

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

스케일 계수 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 계수를 모두 `2`로 하면 이미지의 너비와 높이가 기본 차원의 약 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 계수는 확대나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기가 증가합니다. `1` 이하의 계수는 세부 정보가 적은 작은 이미지를 생성합니다. 비율을 유지하려면 동일한 계수를 사용하고, 가로와 세로를 다르게 설정하면 출력이 각각 독립적으로 늘어나게 됩니다.

[IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--)로 전체 도형을 렌더링하는 것이 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함해야 할 때 유용합니다. 단락 전용 이미지의 경우 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)를 설정하여 줄 바꿈을 비활성화하면 라인이 텍스트 프레임 가장자리에서 끊기지 않습니다.

**특정 단락의 슬라이드 상 정확한 경계값을 어떻게 얻을 수 있나요?**

[IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--)을 사용하여 단락의 경계 사각형을 가져옵니다. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--)은 개별 구절의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어되나요?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)은 단락 수준 설정이며 개별 구절 서식과 무관하게 전체 단락에 적용됩니다.

줄 내에서 글꼴 수직 정렬을 보려면 [줄 내에서 글꼴 수직 정렬](/slides/ko/java/text-formatting/#align-fonts-within-a-line)을 참고하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구절에 대해 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)를 설정하면 하나의 단락에 여러 언어 텍스트를 포함시킬 수 있습니다.