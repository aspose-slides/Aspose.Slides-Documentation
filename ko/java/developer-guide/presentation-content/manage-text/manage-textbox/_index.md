---
title: Java를 사용하여 프레젠테이션의 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/java/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 생성
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 만들고, 식별하고, 서식 지정하고, 업데이트합니다."
---
## **소개**

Aspose.Slides for Java에서는 슬라이드 텍스트가 도형에 속한 텍스트 프레임에 저장됩니다. [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 인터페이스는 가장 일반적인 텍스트를 포함하는 도형을 나타내며, [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#getTextFrame--) 메서드를 통해 텍스트에 접근할 수 있습니다.

{{% alert color="info" title="Note" %}}
모든 자동 도형은 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 구현하지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때는 텍스트에 접근하기 전에 도형이 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)를 구현하는지 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 해당 도형의 텍스트 프레임에 텍스트를 넣은 다음 프레젠테이션을 저장합니다. 다음 예제는 직사각형 텍스트 상자를 생성합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 도형 확인**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#isTextBox--) 메서드를 사용하여 자동 도형이 텍스트 상자로 취급되는지를 확인합니다. 프레젠테이션에 텍스트가 포함된 자동 도형과 순수 그래픽 자동 도형이 모두 있을 때 유용합니다.

![텍스트 상자와 도형](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 도형을 검사합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

새로 추가된 자동 도형은 비어 있지 않은 텍스트를 포함하기 전까지는 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 또는 [ITextFrame.setText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#setText-java.lang.String-)를 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 [IAutoShape.isTextBox](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/#isTextBox--)는 `false`를 반환합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

첫 번째와 두 번째 호출은 `true`를 출력하고, 마지막 두 호출은 `false`를 출력합니다.

## **텍스트 프레임을 소유한 도형 찾기**

일반적인 텍스트 처리 코드는 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)을 받을 수 있지만, 이를 포함하는 프레젠테이션 객체를 알지 못할 수 있습니다. 읽기 전용 [ITextFrame.getParentShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#getParentShape--) 메서드를 사용하여 해당 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 소유자(부모 도형)로 돌아갈 수 있습니다.

자동 도형이나 다른 텍스트를 포함하는 도형이 소유한 텍스트 프레임의 경우, [ITextFrame.getParentShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#getParentShape--)는 소유자를 반환하고 [ITextFrame.getParentCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#getParentCell--)은 `null`을 반환합니다. 접근하기 전에 반환값을 확인하십시오. 도형과 표 셀 소유자를 모두 식별하려면, SmartArt 노드와 연결된 도형도 포함하여, [Search and Replace Text](/slides/ko/java/search-and-replace-text/)를 참조하십시오.

## **텍스트 상자에 열 추가**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) 메서드는 텍스트 프레임을 여러 열로 나누며, [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)은 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정은 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 같은 도형 내에서 열 사이에 재배치되며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 10포인트 간격을 가진 3열 텍스트 상자를 만들고, 프레젠테이션을 저장한 뒤 출력 파일에서 저장된 설정을 다시 읽어옵니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **개별 열에서 텍스트 추출**

[ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#splitTextByColumns--) 메서드를 사용하여 기존 텍스트 프레임의 각 시각적 열에 할당된 텍스트를 가져올 수 있습니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대한 문자열을 반환합니다. 단일 열 텍스트 프레임은 한 요소를 가진 배열을 반환하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열은 순수 텍스트만 포함하며, 부분 수준 서식은 보존되지 않습니다.

이 기능은 다음과 같은 경우에 유용합니다:

- 열 기반 읽기 순서를 유지하면서 텍스트를 추출합니다.
- 다열 슬라이드의 내용을 색인하거나 비교합니다.
- 각 열을 별개의 파일, 데이터베이스 필드 또는 다른 대상에 내보냅니다.
- [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), 글꼴 또는 텍스트 프레임 크기를 변경한 후 텍스트가 어떻게 재배치되는지 확인합니다.

이 메서드는 현재 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/) 내에 배분된 텍스트를 보고하며, 별도의 도형이나 텍스트 상자 사이에 텍스트를 자동으로 흐르게 하지 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 중요한 경우 필요한 글꼴이 존재하는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임을 가진 첫 번째 다열 자동 도형을 찾아, 설정된 열 수를 읽은 뒤 각 열의 텍스트를 별도의 파일에 기록합니다. 텍스트 프레임을 제공하지 않는 도형은 건너뛰게 됩니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 업데이트**

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 순회하면서 자동 도형을 선택하고 해당 텍스트 부분을 편집합니다. 부분 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years`를 모두 `months`로 교체하고, 영향을 받은 각 부분을 굵게 만듭니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 순회는 자동 도형의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹화된 도형에 저장된 텍스트를 변경하려면 해당 객체들의 컬렉션을 별도로 순회해야 합니다.

## **하이퍼링크가 있는 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 부분에 할당할 수 있어, 해당 텍스트만 클릭 가능한 링크가 됩니다. [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 메서드를 사용하여 해당 부분을 외부 URL과 연결합니다.

다음 예제는 하이퍼링크가 있는 텍스트를 생성하고 프레젠테이션에 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**텍스트 상자와 마스터 또는 레이아웃 슬라이드의 텍스트 자리 표시자(placeholder)의 차이점은 무엇인가요?**

[자리 표시자](/slides/ko/java/manage-placeholder/)는 마스터 슬라이드([master slide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/masterslide/)) 또는 [layout slide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/layoutslide/)에서 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형이며, 레이아웃이 변경될 때 자리 표시자 동작을 취득하지 않습니다.

**차트, 표 또는 SmartArt의 텍스트를 변경하지 않고 텍스트를 교체하려면 어떻게 해야 하나요?**

Update Text 예제와 같이 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)를 구현하는 도형만 순회하도록 제한하십시오. 차트, 표 및 SmartArt는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에 의해 수정되지 않습니다.