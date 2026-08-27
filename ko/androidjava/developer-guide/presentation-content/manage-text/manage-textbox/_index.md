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
description: "Aspose.Slides for Android via Java를 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽고 편리하게 만들고, 편집하고, 복제할 수 있어 프레젠테이션 자동화를 향상시킵니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가하고 그 텍스트 상자 안에 텍스트를 넣어야 합니다. Aspose.Slides for Android via Java는 텍스트를 포함하는 도형을 추가할 수 있는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 인터페이스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 슬라이드에 도형을 추가할 수 있는 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShape) 인터페이스도 제공합니다. 그러나 `IShape` 인터페이스를 통해 추가된 모든 도형이 텍스트를 보유할 수 있는 것은 아닙니다. 그러나 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 인터페이스를 통해 추가된 도형은 텍스트를 포함할 수 있습니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 `IAutoShape` 인터페이스로 캐스팅되었는지 확인하고 확인하는 것이 좋습니다. 그래야만 `IAutoShape` 아래 속성인 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TextFrame)을 사용할 수 있습니다. 이 페이지의 [Update Text](https://docs.aspose.com/slides/ko/androidjava/manage-textbox/#update-text) 섹션을 참조하세요.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 슬라이드에 만들려면 다음 단계를 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션에서 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
3. 슬라이드의 지정된 위치에 `Rectangle`으로 설정된 [ShapeType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-)을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IAutoShape) 객체를 추가하고, 새로 추가된 `IAutoShape` 객체에 대한 참조를 얻습니다.  
4. 텍스트를 포함할 `TextFrame` 속성을 `IAutoShape` 객체에 추가합니다. 아래 예제에서는 *Aspose TextBox* 라는 텍스트를 추가했습니다.  
5. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

다음 Java 코드(위 단계 구현)는 슬라이드에 텍스트를 추가하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 인스턴스 생성
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 타입을 Rectangle로 설정하여 AutoShape를 추가합니다
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

Aspose.Slides는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 인터페이스의 [isTextBox](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 메서드를 제공하여 도형을 검사하고 텍스트 상자를 식별할 수 있게 합니다.

![Text box and shape](istextbox.png)

다음 Java 코드는 도형이 텍스트 상자로 만들어졌는지 확인하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

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

`addAutoShape` 메서드를 사용해 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/) 인터페이스에서 자동 도형을 단순히 추가하면 해당 자동 도형의 `isTextBox` 메서드는 `false`를 반환합니다. 그러나 `addTextFrame` 메서드나 `setText` 메서드를 사용해 자동 도형에 텍스트를 추가하면 `isTextBox` 속성은 `true`를 반환합니다.

```java
import com.aspose.slides.*;

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

## **텍스트 프레임을 소유한 도형 찾기**

일반적인 텍스트 처리 코드에서 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)을 받을 때, 해당 프레임을 포함하고 있는 프레젠테이션 객체를 아직 모를 수 있습니다. [ITextFrame.getParentShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#getParentShape--) 메서드를 사용해 소유자 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)로 다시 이동하십시오.

[IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 또는 다른 텍스트 포함 도형에 속한 텍스트 프레임의 경우, `ITextFrame.getParentShape`는 소유자를 반환하고 `ITextFrame.getParentCell`은 `null`을 반환합니다. 두 메서드는 읽기 전용 탐색을 제공하므로 호출해도 소유권이 변경되지 않습니다. 항상 반환값이 `null`인지 확인한 후 도형에 접근하십시오.

도형 및 표 셀 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 도형 포함)는 [Search and Replace Text](/slides/ko/androidjava/search-and-replace-text/)를 참조하세요.

## **텍스트 상자에 열 추가**

Aspose.Slides는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat) 인터페이스와 [TextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TextFrameFormat) 클래스에서 제공하는 [ColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 및 [ColumnSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 속성을 사용하여 텍스트 상자에 열을 추가할 수 있습니다. 텍스트 상자의 열 수와 열 사이의 간격(포인트)을 지정할 수 있습니다.

다음 Java 코드는 해당 작업을 시연합니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 타입을 Rectangle로 설정하여 AutoShape를 추가합니다
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

Aspose.Slides for Android via Java는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat) 인터페이스에서 제공하는 [ColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 속성을 통해 텍스트 프레임에 열을 추가할 수 있게 합니다. 이 속성을 사용해 텍스트 프레임에 원하는 열 수를 지정할 수 있습니다.

다음 Java 코드는 텍스트 프레임에 열을 추가하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **텍스트 업데이트**

Aspose.Slides를 사용하면 텍스트 상자에 포함된 텍스트 또는 프레젠테이션 전체에 포함된 모든 텍스트를 변경하거나 업데이트할 수 있습니다.

다음 Java 코드는 프레젠테이션의 모든 텍스트를 업데이트하거나 변경하는 작업을 시연합니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // shape이 텍스트 프레임(IAutoShape)을 지원하는지 확인합니다.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // 텍스트 프레임의 단락들을 반복합니다
                {
                    for (IPortion portion : paragraph.getPortions()) // 단락 내 각 부분을 반복합니다
                    {
                        portion.setText(portion.getText().replace("years", "months")); // 텍스트를 변경합니다
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 서식을 변경합니다
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

텍스트 상자 안에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 사용자가 링크를 열게 됩니다.

하이퍼링크가 포함된 텍스트 상자를 추가하려면 다음 단계를 수행합니다:

1. `Presentation` 클래스의 인스턴스를 생성합니다.  
2. 새로 만든 프레젠테이션에서 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
3. 슬라이드의 지정된 위치에 `Rectangle`으로 설정된 `ShapeType`을 가진 `AutoShape` 객체를 추가하고, 새로 추가된 AutoShape 객체에 대한 참조를 얻습니다.  
4. `AutoShape` 객체에 `TextFrame`을 추가하고 첫 번째 부분의 텍스트를 설정합니다. 아래 예제에서는 *Aspose.Slides* 라는 텍스트를 사용했습니다.  
5. 원하는 `TextFrame` 부분의 `PortionFormat`에서 [IHyperlinkManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihyperlinkmanager/) 객체를 가져옵니다.  
6. 해당 객체에 대해 [setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 를 호출하여 텍스트 클릭 시 열릴 링크를 설정합니다.  
7. 마지막으로 `Presentation` 객체를 통해 PPTX 파일을 저장합니다.  

다음 Java 코드는 위 단계 구현을 통해 슬라이드에 하이퍼링크가 포함된 텍스트 상자를 추가하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 타입을 Rectangle로 설정한 AutoShape 객체를 추가합니다
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // shape을 AutoShape으로 캐스팅합니다
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape에 연결된 ITextFrame 속성에 접근합니다
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 프레임에 텍스트를 추가합니다
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 부분 텍스트에 하이퍼링크를 설정합니다
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

[플레이스홀더](/slides/ko/androidjava/manage-placeholder/)는 [마스터](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/masterslide/)의 스타일/위치를 상속받으며 [레이아웃](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/layoutslide/)에서 재정의될 수 있습니다. 반면 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체로 존재하며 레이아웃을 변경해도 영향을 받지 않습니다.

**차트, 표, SmartArt 내부의 텍스트는 제외하고 프레젠테이션 전체에서 텍스트를 일괄 교체하려면 어떻게 해야 하나요?**

텍스트 프레임이 있는 자동 도형만 반복 대상으로 제한하고, 임베디드 객체([차트](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chart/), [표](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/smartart/))는 별도로 컬렉션을 탐색하거나 해당 유형을 건너뛰어 처리하십시오.