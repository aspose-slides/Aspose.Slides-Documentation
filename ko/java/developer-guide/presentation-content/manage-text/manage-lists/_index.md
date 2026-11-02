---
title: Java에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리
linktitle: 목록 관리
type: docs
weight: 60
url: /ko/java/manage-lists/
keywords:
- 글머리표
- 글머리표 목록
- 번호 매기기 목록
- 기호 글머리표
- 그림 글머리표
- 맞춤 글머리표
- 다단계 목록
- 글머리표 만들기
- 글머리표 추가
- 목록 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다단계 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Java는 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있게 해 줍니다. 목록 항목은 글머리표 설정이 단락 형식을 통해 제어되는 단락입니다.

단락 수준 목록 설정에 액세스하려면 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 메서드를 사용합니다. 주 진입점은 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), 이는 [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 종류, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

본 문서에서는 다음과 같이 하는 방법을 제공합니다:

- 사용자 지정 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다단계 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식을 검사하고 변경하기
- 단락 텍스트와 함께 실제 목록 표시기와 번호 읽기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 객체를 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)에 추가하고 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol)으로 설정합니다. 그런 다음 [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) 및 [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-)을 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 Java 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![기호 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

항목 순서가 중요할 때 번호 매기기 목록을 사용합니다. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered)으로 설정합니다. 또한 [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)을 사용하여 번호 매기기 형식을 선택하거나 목록이 1이 아닌 값에서 시작해야 할 경우 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)을 설정할 수 있습니다.

다음 Java 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![번호 매기기 글머리표](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 그림 글머리표는 작은 크기에서도 읽기 쉬운 단순한 이미지(예: 아이콘 또는 작은 투명 PNG 파일)에 가장 적합합니다.

{{% alert color="info" title="Note" %}}
Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.

Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.
{{% /alert %}}

그림 글머리표를 만들려면 이미지를 [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--)에 추가하고 반환된 이미지 객체를 [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture)으로 설정합니다.

예를 들어 "image.png" 파일이 있다고 가정해 보겠습니다:

![글머리표용 그림](picture_for_bullets.png)

다음 Java 코드는 슬라이드에서 그림 글머리표를 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![그림 글머리표](picture_bullets.png)

## **다단계 목록 만들기**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-)을 사용하여 목록 항목을 서로 다른 수준에 배치합니다. 레벨 0은 최상위 레벨이며, 레벨 1은 그 아래에 중첩됩니다.

다음 Java 코드는 다단계 글머리표 목록을 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![다단계 목록](multilevel_list.png)

## **기존 목록 변경**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근하여 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 업데이트합니다. PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 때도 동일한 속성을 사용할 수 있습니다.

다음 Java 코드는 텍스트 프레임의 첫 번째 단락을 번호 매기기 목록 스타일로 변경합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **실제 글머리표 값 읽기**

프레젠테이션 콘텐츠를 추출할 때는 단락 텍스트와 함께 목록 표시기를 유지합니다. [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--)을 호출하고 [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--)에 접근하여 실제 글머리표 서식을 얻습니다. 읽기 전에 [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--)을 확인하고 [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)을 읽습니다.

번호 매기기 목록의 경우 다음 세 값을 구분합니다:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--)은 형식을 결정합니다(예: 마침표가 있는 아라비아 숫자 또는 마침표가 있는 소문자 알파벳).
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--)은 번호 매기기 단락 그룹의 시작 번호를 지정합니다.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)은 특정 단락에 대한 서식이 적용된 표시기를 반환합니다. 예를 들어 5에서 시작하는 목록의 두 번째 항목은 `6.`을 반환합니다.

각 단락에 대해 [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--)를 보존하여 중첩 수준을 유지합니다. 실제 표시기는 전체 계층 구조를 인코딩하지 않으며, 중첩 항목은 `c.`와 같이 반환될 수 있고 `6.c.`와 같은 결합 레이블은 아닙니다.

다음 자체 포함 예제는 목록을 만들고 프레젠테이션에 저장한 다음 프레젠테이션을 다시 로드하여 각 단락의 텍스트, 깊이, 글머리표 유형 및 실제 값을 보고합니다. 작은 파란색 그림 표시기는 인라인 SVG에서 생성됩니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 외부 이미지 파일 없이 그림 마커를 생성합니다.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

소스 목록이 아래에 표시됩니다.

![시작 번호 5, 중첩된 문자 및 로마 숫자 항목, 기호 표시기, 글머리표 없는 단락, 파란색 그림 표시기](actual_bullet_values.png)

보고서는 PowerPoint에 표시된 표시기와 일치합니다:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/)에 대해서는 [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)가 빈 문자열이 아니라 `null`을 반환합니다. 이러한 유형을 별도로 처리하십시오: 첫 번째는 표시기가 없으며, 두 번째는 글머리표 이미지를 별도로 추출해야 합니다. 그림 글머리표는 텍스트 표시기를 추출하는 것만으로 재현할 수 없습니다.

## **FAQ**

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 그대로 유지합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고 대상 단락에 접근한 뒤 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 검사하거나 업데이트하고 프레젠테이션을 저장하면 됩니다.

**목록에 비라틴어 텍스트를 포함할 수 있나요?**

예. 목록 항목 텍스트는 Unicode 문자를 포함할 수 있으므로 다국어 프레젠테이션에서도 목록을 만들 수 있습니다. 사용하려는 문자를 지원하는 글꼴이 프레젠테이션에 포함되어 있는지 확인하십시오.