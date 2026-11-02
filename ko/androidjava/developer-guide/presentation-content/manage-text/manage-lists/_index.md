---
title: Android에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리
linktitle: 목록 관리
type: docs
weight: 60
url: /ko/androidjava/manage-lists/
keywords:
- 글머리표
- 글머리표 목록
- 번호 매기기 목록
- 기호 글머리표
- 그림 글머리표
- 맞춤 글머리표
- 다중 수준 목록
- 글머리표 만들기
- 글머리표 추가
- 목록 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다중 수준 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 글머리표 설정이 단락 서식을 통해 제어되는 단락입니다.

단락 수준 목록 설정에 접근하려면 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) 메서드를 사용하십시오. 주요 진입점은 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음과 같은 방법을 보여줍니다:

- 사용자 지정 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다중 수준 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식을 검사하고 변경하기
- 단락 텍스트와 함께 실제 목록 마커 및 번호 읽기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)에 단락을 추가하고 [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getColor--), 및 [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-)을 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 Java 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    int bulletColor = Color.rgb(205, 92, 92);

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

항목의 순서가 중요할 때 번호 매기기 목록을 사용합니다. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)으로 설정하십시오. 또한 [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)을 사용하여 번호 매기기 형식을 선택하거나, 목록을 1이 아닌 다른 값에서 시작하도록 할 경우 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)을 설정할 수 있습니다.

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

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 바꿀 수 있습니다. 그림 글머리표는 아이콘이나 작은 투명 PNG 파일처럼 작은 크기에서도 읽기 쉬운 간단한 이미지와 가장 잘 어울립니다.

{{% alert color="info" title="Note" %}}
가능하면 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경을 가진 단순한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 지정 글머리표 기호로 잘 작동합니다.

이미지는 매우 작은 크기로 축소됩니다. 따라서 목록의 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택하는 것을 강력히 권장합니다.
{{% /alert %}}

그림 글머리표를 만들려면 [Presentation.getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--)에 이미지를 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 객체를 [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)으로 설정하십시오.

예를 들어 "image.png"가 있다고 가정해 보겠습니다:

![글머리표용 이미지](picture_for_bullets.png)

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

## **다중 수준 목록 만들기**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)을 사용하여 목록 항목을 서로 다른 수준에 배치합니다. 레벨 0은 최상위 수준이며, 레벨 1은 그 아래에 중첩됩니다.

다음 Java 코드는 다중 수준 목록을 만드는 방법을 보여줍니다:

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

![다중 수준 목록](multilevel_list.png)

## **기존 목록 변경**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근한 후 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 메서드를 사용하여 PPT, PPTX 또는 ODP 파일에서 로드한 목록을 검사하거나 수정할 수 있습니다.

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

프레젠테이션 콘텐츠를 추출할 때 목록 마커를 단락 텍스트와 함께 유지합니다. [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--)을 호출하고 [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformateffectivedata/#getBullet--)에 접근하여 실제 적용된 글머리표 형식을 가져옵니다. [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)을 읽기 전에 [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getType--)을 확인하십시오.

번호 매기기 목록의 경우 다음 세 값을 구분합니다:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--)은 형식을 결정합니다(예: 마침표가 뒤따르는 아라비아 숫자 또는 소문자 알파벳).
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--)은 번호 매기기 단락 그룹의 시작 번호를 지정합니다.
- [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)은 특정 단락에 대한 서식이 적용된 마커를 반환합니다. 예를 들어 5부터 시작하는 목록의 두 번째 항목은 `6.`을 반환합니다.

각 단락에 대해 [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDepth--)를 보존하여 중첩 수준을 유지하십시오. 실제 마커는 전체 계층 구조를 인코딩하지 않으며, 중첩된 항목은 `6.c.`와 같은 결합 레이블 대신 `c.`를 반환할 수 있습니다.

다음 자체 포함 예제는 목록을 만들고 프레젠테이션에 저장한 후 프레젠테이션을 다시 로드하여 각 단락의 텍스트, 깊이, 글머리표 유형 및 실제 값을 보고합니다. 작은 파란색 그림 마커는 인라인 SVG에서 생성됩니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

소스 목록은 아래에 표시됩니다.

![5부터 시작하고, 중첩된 문자 및 로마 숫자 항목, 기호 마커, 글머리표 없는 단락, 파란색 그림 마커](actual_bullet_values.png)

보고서는 PowerPoint에 표시된 마커와 일치합니다:

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

[BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)의 경우, [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)은 빈 문자열이 아니라 `null`을 반환합니다. 이러한 유형을 별도로 처리하십시오: 전자는 마커가 없으며, 후자는 글머리표 이미지를 별도로 추출해야 합니다. 그림 글머리표는 텍스트 마커만 추출해서는 재현할 수 없습니다.

## **FAQ**

**글머리표 및 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 보존합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고 대상 단락에 접근한 다음 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 검사하거나 업데이트하고 프레젠테이션을 저장하십시오.

**목록에 비라틴 문자 텍스트를 포함할 수 있나요?**

예. 목록 항목 텍스트는 Unicode 문자를 포함할 수 있으므로 다국어 프레젠테이션에서 목록을 만들 수 있습니다. 프레젠테이션에 사용되는 글꼴이 필요한 문자를 지원하는지 확인하십시오.