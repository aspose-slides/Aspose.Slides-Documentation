---
title: Java에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/java/manage-paragraph/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리 기호 관리
- 단락 들여쓰기
- 매달린 들여쓰기
- 단락 글머리 기호
- 번호 매기기 목록
- 글머리 기호 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- 파워포인트
- 오픈문서
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 단락 서식을 마스터하고, PPT, PPTX, ODP 프레젠테이션에서 정렬, 간격 및 스타일을 최적화합니다."
---
## **소개**

Aspose.Slides는 Java에서 PowerPoint 텍스트, 단락 및 구문을 작업하는 데 필요한 모든 인터페이스와 클래스를 제공합니다.

* Aspose.Slides는 단락을 나타내는 객체를 추가할 수 있도록 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 인터페이스를 제공합니다. `ITextFame` 객체는 하나 이상의 단락을 가질 수 있습니다(각 단락은 캐리지 리턴을 통해 생성됨).
* Aspose.Slides는 구문을 나타내는 객체를 추가할 수 있도록 [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/) 인터페이스를 제공합니다. `IParagraph` 객체는 하나 이상의 구문을 가질 수 있습니다(iPortions 객체의 컬렉션).
* Aspose.Slides는 텍스트와 해당 서식 속성을 나타내는 객체를 추가할 수 있도록 [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/) 인터페이스를 제공합니다.

`IParagraph` 객체는 기본 `IPortion` 객체를 통해 다양한 서식 속성을 가진 텍스트를 처리할 수 있습니다.

## **여러 구문을 포함하는 여러 단락 추가**

다음 단계에서는 3개의 단락을 포함하고 각 단락이 3개의 구문을 포함하는 텍스트 프레임을 추가하는 방법을 보여줍니다:

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 사각형 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. 해당 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)와 연결된 ITextFrame을 가져옵니다.
5. [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/) 객체 두 개를 생성하고 이를 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)의 `IParagraphs` 컬렉션에 추가합니다.
6. 각 새 `IParagraph`마다 세 개의 [IPortion](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iportion/) 객체를 생성(기본 단락에는 두 개의 Portion 객체)하고 각 `IPortion` 객체를 해당 `IParagraph`의 IPortion 컬렉션에 추가합니다.
7. 각 구문에 텍스트를 설정합니다.
8. `IPortion` 객체가 제공하는 서식 속성을 사용하여 각 구문에 원하는 서식 기능을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle 유형의 AutoShape을 추가합니다
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape의 TextFrame에 접근합니다
    ITextFrame tf = ashp.getTextFrame();

    // 다양한 텍스트 형식으로 Paragraph와 Portion을 생성합니다
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // PPTX를 디스크에 저장합니다
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **단락 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 글머리 기호가 있는 단락은 읽고 이해하기가 항상 더 쉽습니다.

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 선택한 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`에 있는 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. 단락의 글머리 기호 `Type`을 `Symbol`로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락의 `Text`를 설정합니다.
9. 글머리 기호에 대한 단락 `Indent`를 설정합니다.
10. 글머리 기호 색상을 설정합니다.
11. 글머리 기호의 높이를 설정합니다.
12. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
13. 두 번째 단락을 추가하고 7~13 단계의 과정을 반복합니다.
14. 프레젠테이션을 저장합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape를 추가하고 접근합니다
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape의 텍스트 프레임에 접근합니다
    ITextFrame txtFrm = aShp.getTextFrame();

    // 기본 단락을 제거합니다
    txtFrm.getParagraphs().removeAt(0);

    // 단락을 생성합니다
    Paragraph para = new Paragraph();

    // 단락 글머리 기호 스타일 및 기호를 설정합니다
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 단락 텍스트를 설정합니다
    para.setText("Welcome to Aspose.Slides");

    // 글머리 들여쓰기를 설정합니다
    para.getParagraphFormat().setIndent(25);

    // 글머리 색상을 설정합니다
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor를 true로 설정하여 자체 글머리 색상을 사용합니다

    // 글머리 높이를 설정합니다
    para.getParagraphFormat().getBullet().setHeight(100);

    // 단락을 텍스트 프레임에 추가합니다
    txtFrm.getParagraphs().add(para);

    // 두 번째 단락을 생성합니다
    Paragraph para2 = new Paragraph();

    // 단락 글머리 기호 유형 및 스타일을 설정합니다
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 단락 텍스트를 추가합니다
    para2.setText("This is numbered bullet");

    // 글머리 들여쓰기를 설정합니다
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor를 true로 설정하여 자체 글머리 색상을 사용합니다

    // 글머리 높이를 설정합니다
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 단락을 텍스트 프레임에 추가합니다
    txtFrm.getParagraphs().add(para2);
    
    // 수정된 프레젠테이션을 저장합니다
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **그림 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 그림 단락은 읽고 이해하기 쉽습니다.

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
7. [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)에 이미지를 로드합니다.
8. 글머리 기호 유형을 [Picture](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)으로 설정하고 이미지를 지정합니다.
9. 단락의 `Text`를 설정합니다.
10. 글머리 기호에 대한 단락 `Indent`를 설정합니다.
11. 글머리 기호 색상을 설정합니다.
12. 글머리 기호의 높이를 설정합니다.
13. 새 단락을 `TextFrame`의 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 이전 단계에 따라 과정을 반복합니다.
15. 수정된 프레젠테이션을 저장합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = presentation.getSlides().get_Item(0);

    // 글머리 기호용 이미지를 인스턴스화합니다
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape를 추가하고 접근합니다
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape의 텍스트 프레임에 접근합니다
    ITextFrame textFrame = autoShape.getTextFrame();

    // 기본 단락을 제거합니다
    textFrame.getParagraphs().removeAt(0);

    // 새로운 단락을 생성합니다
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 단락 글머리 기호 스타일과 이미지를 설정합니다
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 글머리 높이를 설정합니다
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 단락을 텍스트 프레임에 추가합니다
    textFrame.getParagraphs().add(paragraph);

    // 프레젠테이션을 PPTX 파일로 저장합니다
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // 프레젠테이션을 PPT 파일로 저장합니다
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **다단계 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 다단계 글머리 기호는 읽고 이해하기 쉽습니다.

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 새 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. autoshape의 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성하고 깊이를 0으로 설정합니다.
7. `Paragraph` 클래스를 사용하여 두 번째 단락 인스턴스를 생성하고 깊이를 1로 설정합니다.
8. `Paragraph` 클래스를 사용하여 세 번째 단락 인스턴스를 생성하고 깊이를 2로 설정합니다.
9. `Paragraph` 클래스를 사용하여 네 번째 단락 인스턴스를 생성하고 깊이를 3으로 설정합니다.
10. 새 단락들을 `TextFrame`의 단락 컬렉션에 추가합니다.
11. 수정된 프레젠테이션을 저장합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape를 추가하고 접근합니다
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 생성된 Autoshape의 텍스트 프레임에 접근합니다
    ITextFrame text = aShp.addTextFrame("");

    // 기본 단락을 삭제합니다
    text.getParagraphs().clear();

    // 첫 번째 단락을 추가합니다
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 글머리 수준을 설정합니다
    para1.getParagraphFormat().setDepth((short)0);

    // 두 번째 단락을 추가합니다
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 글머리 수준을 설정합니다
    para2.getParagraphFormat().setDepth((short)1);

    // 세 번째 단락을 추가합니다
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 글머리 수준을 설정합니다
    para3.getParagraphFormat().setDepth((short)2);

    // 네 번째 단락을 추가합니다
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 글머리 수준을 설정합니다
    para4.getParagraphFormat().setDepth((short)3);

    // 단락을 컬렉션에 추가합니다
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // 프레젠테이션을 PPTX 파일로 저장합니다
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용자 정의 번호 매기기 목록이 있는 단락 관리**

[IBulletFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibulletformat/) 인터페이스는 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 속성 등을 제공하여 사용자 정의 번호 매기기나 서식이 적용된 단락을 관리할 수 있게 합니다.

1. 다음과 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 단락이 포함된 슬라이드에 접근합니다.
3. 슬라이드에 [autoshape]을 추가합니다.
4. autoshape의 [TextFrame]에 접근합니다.
5. `TextFrame`의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성하고 [NumberedBulletStartWith](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)을 2로 설정합니다.
7. `Paragraph` 클래스를 사용하여 두 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 3으로 설정합니다.
8. `Paragraph` 클래스를 사용하여 세 번째 단락 인스턴스를 생성하고 `NumberedBulletStartWith`를 7으로 설정합니다.
9. 새 단락들을 `TextFrame`의 단락 컬렉션에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 생성된 Autoshape의 텍스트 프레임에 접근합니다
    ITextFrame textFrame = shape.getTextFrame();

    // 기존 기본 단락을 제거합니다
    textFrame.getParagraphs().removeAt(0);

    // 첫 번째 목록
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **단락의 첫 줄 들여쓰기 설정**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 메서드를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 단락의 왼쪽 여백을 기준으로 첫 줄만 이동시킵니다. 양수값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 경우에는 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)을 사용하고, 첫 줄만 이동해야 할 경우에는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-)을 사용합니다.

아래 예제는 여러 단락을 만들고 서로 다른 들여쓰기 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떻게 영향을 미치는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 여러 단락을 생성하고 각각에 서로 다른 [Indent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

결과:
![단락의 첫 줄 들여쓰기](first_line_indent.png)

## **단락의 매달린 들여쓰기 설정**

매달린 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에서 시작하는 단락 레이아웃입니다. Aspose.Slides에서는 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 메서드를 사용하여 이 효과를 만들 수 있습니다. 들여쓰기를 음수값으로 설정하면 첫 줄이 단락 본문에 대해 왼쪽으로 이동합니다.

실제로 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)은 단락 본문의 왼쪽 위치를 정의하고, [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-)은 해당 여백에 대한 첫 줄의 위치를 정의합니다. 매달린 들여쓰기를 만들려면 양수 `MarginLeft` 값과 음수 `Indent` 값을 설정합니다.

이 서식은 참고문헌, 인용, 용어집 항목 및 줄 바꿈된 줄이 첫 줄의 첫 문자 아래가 아니라 단락 본문 아래에 맞춰져야 하는 다른 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/autoshape/)을 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [MarginLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 값을 설정합니다.
6. 매달린 들여쓰기 효과를 만들기 위해 음수 [Indent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 값을 설정합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

결과:
![단락의 매달린 들여쓰기](hanging_indent.png)

## **단락 끝 실행 속성 관리**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 해당 위치를 통해 단락이 포함된 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 사각형 [autoshape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. 사각형에 두 개의 단락이 포함된 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)을 추가합니다.
5. 단락에 대한 `FontHeight` 및 글꼴 유형을 설정합니다.
6. 단락에 대한 End 속성을 설정합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML 텍스트를 단락으로 가져오기**

Aspose.Slides는 HTML 텍스트를 단락으로 가져오는 기능을 향상시켰습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. 슬라이드에 [autoshape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 추가합니다.
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)을 추가하고 접근합니다.
5. `ITextFrame`의 기본 단락을 제거합니다.
6. TextReader를 사용하여 원본 HTML 파일을 읽습니다.
7. [Paragraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraph/) 클래스를 사용하여 첫 번째 단락 인스턴스를 생성합니다.
8. 읽은 TextReader의 HTML 파일 내용을 TextFrame의 [ParagraphCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraphcollection/)에 추가합니다.
9. 수정된 프레젠테이션을 저장합니다.

```java
// 빈 프레젠테이션 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML 콘텐츠를 담을 AutoShape를 추가합니다
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // 도형에 텍스트 프레임을 추가합니다
    ashape.addTextFrame("");

    // 추가된 텍스트 프레임의 모든 단락을 삭제합니다
    ashape.getTextFrame().getParagraphs().clear();

    // 스트림 리더를 사용하여 HTML 파일을 로드합니다
    TextReader tr = new StreamReader("file.html");

    // 텍스트 프레임에 HTML 스트림 리더의 텍스트를 추가합니다
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // 프레젠테이션을 저장합니다
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **단락 텍스트를 HTML로 내보내기**

Aspose.Slides는 단락에 포함된 텍스트를 HTML로 내보내는 기능을 향상시켰습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드의 참조에 접근합니다.
3. HTML로 내보낼 텍스트가 포함된 도형에 접근합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframe/)에 접근합니다.
5. `StreamWriter` 인스턴스를 생성하고 새 HTML 파일을 추가합니다.
6. StreamWriter에 시작 인덱스를 제공하고 원하는 단락을 내보냅니다.

```java
// 프레젠테이션 파일을 로드합니다
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // 프레젠테이션의 기본 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 원하는 인덱스
    int index = 0;

    // 추가된 도형에 접근합니다
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 출력 HTML 파일을 생성합니다
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 첫 번째 단락을 HTML로 추출합니다
    // 단락 시작 인덱스와 복사할 총 단락 수를 제공하여 단락 데이터를 HTML로 씁니다
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **단락을 이미지로 저장**

이 섹션에서는 [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/) 인터페이스로 표현되는 텍스트 단락을 이미지로 저장하는 두 가지 예제를 살펴봅니다. 두 예제 모두 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스의 `getImage` 메서드를 사용하여 단락이 포함된 도형의 이미지를 얻고, 도형 내 단락의 경계를 계산한 뒤 비트맵 이미지로 내보내는 과정을 포함합니다. 이러한 방법을 통해 PowerPoint 프레젠테이션에서 텍스트의 특정 부분을 추출하여 별도의 이미지로 저장할 수 있으며, 다양한 시나리오에서 활용할 수 있습니다.

sample.pptx라는 프레젠테이션 파일에 슬라이드가 하나 있다고 가정해 보겠습니다. 첫 번째 도형은 세 개의 단락이 포함된 텍스트 상자입니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

**예제 1**

이 예제에서는 두 번째 단락을 이미지로 가져옵니다. 이를 위해 프레젠테이션 첫 번째 슬라이드의 도형 이미지를 추출한 다음, 도형 텍스트 프레임에서 두 번째 단락의 경계를 계산합니다. 그런 다음 해당 단락을 새 비트맵 이미지에 다시 그려 PNG 형식으로 저장합니다. 이 방법은 텍스트의 정확한 크기와 서식을 유지하면서 특정 단락을 별도의 이미지로 저장해야 할 때 특히 유용합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 형태를 메모리에 비트맵으로 저장합니다.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 메모리에서 형태 비트맵을 생성합니다.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 두 번째 단락의 경계를 계산합니다.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 형태 비트맵을 잘라서 단락 비트맵만 얻습니다.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

결과:
![단락 이미지](paragraph_to_image_output.png)

**예제 2**

이 예제에서는 앞의 방법에 단락 이미지에 스케일 팩터를 추가하여 확장합니다. 도형을 프레젠테이션에서 추출하고 스케일 팩터 `2`로 이미지로 저장합니다. 이렇게 하면 단락을 내보낼 때 더 높은 해상도의 출력이 가능합니다. 그런 다음 스케일을 고려하여 단락 경계를 계산합니다. 스케일링은 고품질 인쇄물 등에 사용되는 보다 상세한 이미지가 필요할 때 특히 유용합니다.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 스케일링을 적용하여 형태를 메모리에 비트맵으로 저장합니다.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 메모리에서 형태 비트맵을 생성합니다.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 두 번째 단락의 경계를 계산합니다.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 형태 비트맵을 잘라서 단락 비트맵만 얻습니다.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. 텍스트 프레임의 줄 바꿈 설정([setWrapText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/textframeformat/#setWrapText-byte-))을 사용하여 줄 바꿈을 끄면 줄이 프레임 가장자리에서 끊기지 않습니다.

**특정 단락의 슬라이드 상 정확한 경계를 어떻게 얻을 수 있나요?**

단락(또는 단일 구문)의 경계 사각형을 가져와 슬라이드 상의 정확한 위치와 크기를 알 수 있습니다.

**단락 정렬(왼쪽/오른쪽/가운데/양쪽 정렬)은 어디에서 제어되나요?**

[Alignment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraphformat/#setAlignment-int-)은 [ParagraphFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/paragraphformat/)에서 단락 수준 설정이며, 개별 구문 서식에 관계없이 전체 단락에 적용됩니다.

**단락의 일부(예: 한 단어)만 맞춤법 검사 언어를 설정할 수 있나요?**

예. 언어는 구문 수준([PortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))에서 설정되므로 하나의 단락 내에 여러 언어가 공존할 수 있습니다.