---
title: Android에서 프레젠테이션 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/androidjava/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 만들기
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 생성, 편집 및 복제할 수 있어 프레젠테이션 자동화를 향상시킵니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가하고 그 안에 텍스트를 넣어야 합니다. Aspose.Slides for Android via Java는 텍스트를 포함하는 도형을 추가할 수 있는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 인터페이스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape) 인터페이스도 제공합니다. 그러나 `IShape` 인터페이스를 통해 추가된 모든 도형이 텍스트를 포함할 수 있는 것은 아닙니다. 하지만 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 인터페이스를 통해 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 `IAutoShape` 인터페이스로 캐스팅되었는지 확인하고 확인하는 것이 좋습니다. 그래야만 `IAutoShape` 아래 속성인 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TextFrame) 을 사용할 수 있습니다. 이 페이지의 [Update Text](https://docs.aspose.com/slides/ko/androidjava/manage-textbox/#update-text) 섹션을 참조하세요.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

슬라이드에 텍스트 상자를 만들려면 다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드의 지정된 위치에 `Rectangle`으로 설정된 [ShapeType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-)을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 객체를 추가하고 새로 추가된 `IAutoShape` 객체에 대한 참조를 얻습니다.
4. 텍스트를 포함할 `IAutoShape` 객체에 `TextFrame` 속성을 추가합니다. 아래 예제에서는 이 텍스트를 추가했습니다: *Aspose TextBox*
5. 마지막으로 `Presentation` 객체를 사용하여 PPTX 파일을 저장합니다.

위 단계들을 구현한 이 Java 코드는 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```java
// Presentation 객체를 생성합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle 유형으로 AutoShape을 추가합니다
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle에 TextFrame을 추가합니다
    ashp.addTextFrame(" ");

    // 텍스트 프레임에 접근합니다
    ITextFrame txtFrame = ashp.getTextFrame();

    // 텍스트 프레임용 Paragraph 객체를 생성합니다
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Paragraph용 Portion 객체를 생성합니다
    IPortion portion = para.getPortions().get_Item(0);

    // 텍스트를 설정합니다
    portion.setText("Aspose TextBox");

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 상자 도형 확인**

Aspose.Slides는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 인터페이스의 [isTextBox](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 메서드를 제공하여 도형을 검사하고 텍스트 상자를 식별할 수 있습니다.

![텍스트 상자와 도형](istextbox.png)

다음 Java 코드는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

참고로 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/) 인터페이스의 `addAutoShape` 메서드로 자동 도형을 단순히 추가하면 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드를 사용하여 자동 도형에 텍스트를 추가하면 `isTextBox` 속성은 `true`를 반환합니다.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox()는 false를 반환합니다
shape1.addTextFrame("shape 1");
// shape1.isTextBox()는 true를 반환합니다

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox()는 false를 반환합니다
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox()는 true를 반환합니다

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox()는 false를 반환합니다
shape3.addTextFrame("");
// shape3.isTextBox()는 false를 반환합니다

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox()는 false를 반환합니다
shape4.getTextFrame().setText("");
// shape4.isTextBox()는 false를 반환합니다
```

## **텍스트 상자에 열 추가**

Aspose.Slides는 텍스트 상자에 열을 추가할 수 있도록 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat) 인터페이스와 [TextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TextFrameFormat) 클래스에서 제공되는 [ColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 및 [ColumnSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 속성을 제공합니다. 텍스트 상자에 열 수를 지정하고 열 사이의 간격을 포인트 단위로 설정할 수 있습니다.

다음 Java 코드는 위에서 설명한 작업을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle 유형으로 AutoShape을 추가합니다
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle에 TextFrame을 추가합니다
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame의 텍스트 형식을 가져옵니다
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame의 열 수를 지정합니다
    format.setColumnCount(3);

    // 열 사이의 간격을 지정합니다
    format.setColumnSpacing(10);

    // 프레젠테이션을 저장합니다
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 프레임에 열 추가**

Aspose.Slides for Android via Java는 텍스트 프레임에 열을 추가할 수 있는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat) 인터페이스의 [ColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 속성을 제공합니다. 이 속성을 통해 텍스트 프레임에 원하는 열 수를 지정할 수 있습니다.

다음 Java 코드는 텍스트 프레임 안에 열을 추가하는 방법을 보여줍니다:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 업데이트**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트 혹은 프레젠테이션에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다.

다음 Java 코드는 프레젠테이션에 있는 모든 텍스트를 업데이트하거나 변경하는 작업을 보여줍니다:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //텍스트 프레임의 단락을 순회합니다
                {
                    for (IPortion portion : paragraph.getPortions()) //단락의 각 포션을 순회합니다
                    {
                        portion.setText(portion.getText().replace("years", "months")); //텍스트를 변경합니다
                        portion.getPortionFormat().setFontBold(NullableBool.True); //서식을 변경합니다
                    }
                }
            }
        }
    }

    //수정된 프레젠테이션을 저장합니다
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **하이퍼링크가 있는 텍스트 상자 추가**

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 해당 링크를 열도록 안내됩니다.

링크가 포함된 텍스트 상자를 추가하려면 다음 단계를 수행합니다:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 새로 만든 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드의 지정된 위치에 `Rectangle`으로 설정된 `ShapeType`을 가진 `AutoShape` 객체를 추가하고 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.
4. 기본 텍스트로 *Aspose TextBox*가 포함된 `TextFrame`을 `AutoShape` 객체에 추가합니다.
5. `IHyperlinkManager` 클래스를 인스턴스화합니다.
6. `IHyperlinkManager` 객체를 `TextFrame`의 원하는 부분에 연결된 [HyperlinkClick](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) 속성에 할당합니다.
7. 마지막으로 `Presentation` 객체를 사용하여 PPTX 파일을 저장합니다.

위 단계들을 구현한 이 Java 코드는 하이퍼링크가 포함된 텍스트 상자를 슬라이드에 추가하는 방법을 보여줍니다:

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 유형을 Rectangle로 설정한 AutoShape 객체를 추가합니다
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 도형을 AutoShape으로 캐스팅합니다
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape에 연결된 ITextFrame 속성에 접근합니다
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 프레임에 텍스트를 추가합니다
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 포션 텍스트에 대한 하이퍼링크를 설정합니다
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX 프레젠테이션을 저장합니다
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**마스터 슬라이드 작업 시 텍스트 상자와 텍스트 자리표시자(플레이스홀더)의 차이점은 무엇인가요?**

[placeholder](/slides/ko/androidjava/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/masterslide/)로부터 스타일과 위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/layoutslide/)에서 재정의될 수 있지만, 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체로, 레이아웃을 전환해도 변경되지 않습니다.

**차트, 표 및 SmartArt 내부의 텍스트를 건드리지 않고 프레젠테이션 전체에서 대량 텍스트 교체를 수행하려면 어떻게 해야 하나요?**

텍스트 프레임이 있는 자동 도형만 반복 대상으로 제한하고, 삽입된 개체([charts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/smartart/))는 별도의 컬렉션을 순회하거나 해당 개체 유형을 건너뛰어 제외합니다.