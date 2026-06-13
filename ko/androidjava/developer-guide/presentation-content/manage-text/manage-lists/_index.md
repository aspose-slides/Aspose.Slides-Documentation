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
- 이미지 글머리표
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
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 이미지, 다중 수준 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Android via Java를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표와 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 단락이며 해당 단락의 글머리표 설정은 단락 형식을 통해 제어됩니다.

[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) 메서드를 사용하여 단락 수준 목록 설정에 접근합니다. 주요 진입점은 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)이며, 이는 [IBulletFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음을 수행하는 방법을 보여줍니다.

- 사용자 정의 기호가 있는 글머리표 목록 만들기
- 이미지 글머리표 만들기
- 단락 깊이를 설정하여 다중 수준 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식 검사 및 변경

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)에 단락을 추가하고 [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Symbol](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [IBulletFormat.setChar](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#getColor--) 및 [IBulletFormat.setHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-)을 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 Java 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
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

항목 순서가 중요할 때 번호 매기기 목록을 사용합니다. [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Numbered](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/)으로 설정합니다. 또한 [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)으로 번호 매기기 형식을 선택하거나, 목록을 1이 아닌 다른 값부터 시작하도록 해야 할 경우 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)을 설정할 수 있습니다.

다음 Java 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```java
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

## **이미지 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 이미지 글머리표는 작은 크기에서도 읽을 수 있는 간단한 이미지(예: 아이콘 또는 작은 투명 PNG 파일)와 가장 잘 어울립니다.

{{% alert color="primary" %}}
가능하면 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경이 있는 간단한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 정의 글머리표 기호로 잘 작동합니다.

이미지는 매우 작은 크기로 축소됩니다. 따라서 리스트에서 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택하는 것이 좋습니다.
{{% /alert %}}

이미지 글머리표를 만들려면 [Presentation.getImages](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getImages--)에 이미지를 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 객체를 [IBulletFormat.getPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#getPicture--)에 할당합니다. 이미지를 할당하기 전에 [IBulletFormat.setType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)을 [BulletType.Picture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/bullettype/)으로 설정합니다.

예를 들어 "image.png" 파일이 있다고 가정합니다:

![글머리표용 이미지](picture_for_bullets.png)

다음 Java 코드는 슬라이드에서 이미지 글머리표를 만드는 방법을 보여줍니다:

```java
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

![이미지 글머리표](picture_bullets.png)

## **다중 수준 목록 만들기**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)을 사용하여 목록 항목을 서로 다른 수준에 배치합니다. 레벨 0은 최상위 수준이고, 레벨 1은 그 아래에 중첩되는 식으로 계속됩니다.

다음 Java 코드는 다중 수준 글머리표 목록을 만드는 방법을 보여줍니다:

```java
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

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근하여 해당 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 메서드를 사용하여 PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 수 있습니다.

다음 Java 코드는 텍스트 프레임의 첫 번째 단락을 번호 매기기 목록 스타일로 변경합니다:

```java
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

## **FAQ**

**글머리표와 번호 매기기 목록을 PDF 또는 이미지로 내보낼 수 있나요?**

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 보존합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고, 대상 단락에 접근하여 해당 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 설정을 검사하거나 업데이트한 다음 프레젠테이션을 저장합니다.

**목록에 비라틴 텍스트를 포함할 수 있나요?**

예. 목록 항목 텍스트는 유니코드 문자를 포함할 수 있으므로 다국어 프레젠테이션에서도 목록을 만들 수 있습니다. 프레젠테이션에 사용되는 글꼴이 필요한 문자를 지원하는지 확인하십시오.