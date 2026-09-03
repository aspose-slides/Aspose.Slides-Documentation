---
title: Android에서 프레젠테이션의 텍스트 상자 관리
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
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 생성, 식별, 서식 지정 및 업데이트합니다."
---
## **소개**

Aspose.Slides for Android via Java에서는 슬라이드 텍스트가 도형에 속한 텍스트 프레임에 저장됩니다. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 인터페이스는 가장 일반적인 텍스트를 포함하는 도형을 나타내며, 텍스트는 [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) 메서드를 통해 노출됩니다.

{{% alert color="info" title="Note" %}}
모든 자동 도형은 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)을 구현하지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때 텍스트에 접근하기 전에 도형이 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)을 구현하는지 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 해당 텍스트 프레임에 텍스트를 삽입한 뒤 프레젠테이션을 저장합니다. 다음 예제는 사각형 텍스트 상자를 생성합니다:

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

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)는 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 도형 확인**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 메서드를 사용하여 자동 도형이 텍스트 상자로 취급되는지 확인할 수 있습니다. 이는 프레젠테이션에 텍스트를 포함하는 자동 도형과 순수 그래픽 자동 도형이 모두 포함된 경우 유용합니다.

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

새로 추가된 자동 도형은 비어 있지 않은 텍스트를 포함하기 전까지 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 또는 [ITextFrame.setText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-)을 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 [IAutoShape.isTextBox](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/#isTextBox--)이 `false`를 반환합니다:

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

일반 텍스트 처리 코드는 어떤 프레젠테이션 객체에 포함되어 있는지 모르는 상태로 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)을 받을 수 있습니다. 읽기 전용 [ITextFrame.getParentShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#getParentShape--) 메서드를 사용하여 해당 도형으로 돌아갈 수 있습니다.

자동 도형 또는 다른 텍스트를 포함하는 도형이 소유하는 텍스트 프레임의 경우, [ITextFrame.getParentShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#getParentShape--)은 소유자를 반환하고 [ITextFrame.getParentCell](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#getParentCell--)은 `null`을 반환합니다. 반환값에 접근하기 전에 확인하십시오. 도형과 표 셀 소유자를 모두 식별하려면 SmartArt 노드와 연결된 도형을 포함하여 [Search and Replace Text](/slides/ko/androidjava/search-and-replace-text/)를 참조하십시오.

## **텍스트 상자에 열 추가**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) 메서드는 텍스트 프레임을 열로 나누고, [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 메서드는 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정은 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 동일한 도형 내에서 열 사이에 흐르며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 열 사이에 10포인트 간격을 두고 3열 텍스트 상자를 만든 뒤 프레젠테이션을 저장하고, 출력 파일에서 저장된 설정을 다시 읽어옵니다:

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

[ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) 메서드를 사용하면 기존 텍스트 프레임에서 각 시각적 열에 할당된 텍스트를 가져올 수 있습니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대해 하나의 문자열을 반환합니다. 단일 열 텍스트 프레임은 하나의 요소를 가진 배열을 반환하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열에는 순수 텍스트만 포함되며, 부분 수준 서식은 유지되지 않습니다.

이 기능은 다음과 같은 경우에 유용합니다:

- 열 기반 읽기 순서를 유지하면서 텍스트를 추출해야 할 때.
- 다중 열 슬라이드의 내용을 색인화하거나 비교해야 할 때.
- 각 열을 별도의 파일, 데이터베이스 필드 또는 다른 대상에 내보낼 때.
- [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), 글꼴 또는 텍스트 프레임 크기를 변경한 후 텍스트가 어떻게 재배치되는지 확인하고 싶을 때.

이 메서드는 현재 [ITextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)에 배분된 텍스트만 보고하며, 별도의 도형이나 텍스트 상자 간에 자동으로 텍스트가 흐르지는 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 중요한 경우 필요한 글꼴이 확보되어 있는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임이 있는 첫 번째 다중 열 자동 도형을 찾아 구성된 열 수를 읽은 뒤, 각 열의 텍스트를 별도의 파일에 씁니다. 텍스트 프레임을 제공하지 않는 도형은 건너뜁니다:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 순회하면서 자동 도형을 선택한 뒤 텍스트 부분을 편집합니다. 부분 수준에서 작업하면 텍스트와 문자 서식을 동시에 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years`를 `months`로 모두 바꾸고, 영향을 받은 부분을 굵게 설정합니다:

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

이 순회는 자동 도형의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹화된 도형에 저장된 텍스트는 해당 객체의 컬렉션을 별도로 순회해야 변경됩니다.

## **하이퍼링크가 포함된 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 부분에만 할당할 수 있으므로 해당 텍스트만 클릭 가능한 링크가 됩니다. [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)을 사용하여 해당 부분을 외부 URL과 연결하십시오.

다음 예제는 링크된 텍스트를 만든 뒤 프레젠테이션에 저장합니다:

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

**텍스트 상자와 마스터 혹은 레이아웃 슬라이드의 텍스트 자리표시자(플레이스홀더)의 차이점은 무엇인가요?**

[placeholder](/slides/ko/androidjava/manage-placeholder/)은 [master slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/masterslide/) 또는 [layout slide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/layoutslide/)으로부터 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형으로 존재하며, 레이아웃이 변경되어도 플레이스홀더 동작을 취득하지 않습니다.

**차트, 표 또는 SmartArt의 텍스트는 변경하지 않고 텍스트만 교체하려면 어떻게 해야 하나요?**

Update Text 예제에서와 같이 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)을 구현하는 도형만 순회하도록 제한하십시오. 차트, 표 및 SmartArt는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에 의해 수정되지 않습니다.