---
title: Java에서 프레젠테이션의 커넥터 관리
linktitle: 커넥터
type: docs
weight: 10
url: /ko/java/connector/
keywords:
- 커넥터
- 커넥터 유형
- 커넥터 포인트
- 커넥터 라인
- 커넥터 각도
- 연결 지점
- 조정점
- 도형 연결
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 직선, 굽은 및 곡선 PowerPoint 커넥터를 추가, 연결, 재경로 지정, 조정 및 검사하는 방법을 학습합니다."
---
## **개요**

커넥터는 두 도형 중 하나가 움직여도 두 도형에 연결된 상태를 유지할 수 있는 선입니다. 그 끝은 PowerPoint에서 녹색 점으로 표시되는 연결 지점에 연결됩니다. 일부 굽은 및 곡선형 커넥터는 주황색 점으로 표시되는 조정점을 노출하여 개별 커넥터 세그먼트의 위치를 제어합니다.

Aspose.Slides는 커넥터를 [IConnector](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/) 인터페이스를 통해 표현합니다. 커넥터를 생성하고, 끝을 도형에 연결하고, 연결 지점을 선택하고, 재경로할 수 있으며, 조정점이 있는 커넥터의 기하학을 수정할 수 있습니다.

## **커넥터 유형**

[ShapeType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapetype/) 클래스는 직선, 굽은 및 곡선형 커넥터 프리셋을 포함합니다. 다음 표는 사용 가능한 커넥터 기하학과 각 프리셋에서 정의된 조정점 수를 보여줍니다.

| 커넥터 | 이미지 | 조정점 수 |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

조정점의 수와 의미는 선택된 커넥터 프리셋의 일부입니다. 두 개의 서로 다른 커넥터 유형이 동일한 컬렉션 레이아웃을 노출한다고 가정하지 마십시오.

## **두 도형 연결**

[IShapeCollection.addConnector](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-)을 사용하여 커넥터를 추가하고, [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) 및 [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-)을 사용하여 양쪽 끝을 연결합니다. 양쪽 끝이 연결된 후, [IConnector.reroute](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/#reroute--)은 도형 사이의 짧은 경로를 선택합니다.

다음 예제는 타원과 사각형을 굽은 커넥터로 연결합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
`reroute`를 호출하면 [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) 및 [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) 값이 변경될 수 있습니다. 해당 사이트를 고정해야 한다면 재경로 후에 특정 연결 지점을 지정하십시오.
{{% /alert %}}

## **연결 지점 선택**

연결 가능한 각 도형은 [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getConnectionSiteCount--)를 통해 사이트 수를 보고합니다. 커넥터 끝에 할당하기 전에 선호하는 0 기반 사이트 인덱스를 검증하십시오; 사이트 수는 도형의 기하학에 따라 다릅니다.

이 예제는 해당 사이트가 존재할 경우 타원에 특정 사이트에 커넥터를 연결합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **커넥터 포인트 조정**

조정점이 있는 커넥터는 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igeometryshape/#getAdjustments--)를 통해 노출됩니다. 모든 [IAdjustValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/)를 검사하고 [setRawValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#setRawValue-long-)로 변경하기 전에 해당 [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getType--) 값을 확인하십시오. 프리셋 도형 조정 식별에 대한 일반 규칙은 [Shape Manipulation](/slides/ko/java/shape-manipulations/)에 설명되어 있습니다.

커넥터 조정의 수, 순서, 의미 및 유효 값 범위는 커넥터 프리셋에 따라 다릅니다. 조정 유형은 읽기 전용이며, 조정 값은 쓰기가 가능합니다. 읽기 전용 [getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getName--) 메서드는 동일한 의미 유형의 조정이 여러 개 있을 때 추가 식별 정보를 제공합니다.

### **장애물 우회**

다음 레이아웃에서 두 도형 사이의 `BentConnector5` 커넥터가 세 번째 도형을 통과합니다:

![connector-obstruction](connector-obstruction.png)

이 코드는 방해받는 커넥터를 생성합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

수직 굽힘을 이동하면 경로가 바뀌어 커넥터가 장애물을 우회합니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

컬렉션 인덱스 `1`이 항상 수직 굽힘을 나타낸다고 가정하는 대신, 이 예제는 `ConnectorBendPositionY`를 검색하고 예상 의미 유형이 존재할 때만 변경합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5`에는 두 개의 `ConnectorBendPositionX` 조정과 하나의 `ConnectorBendPositionY` 조정이 있습니다. 필요 유형이 여러 번 나타나는 경우, 선택하기 전에 `getName`과 해당 프리셋의 알려진 기하학을 검사하십시오. 조정이 `ShapeAdjustmentType.Custom`을 반환하면 그 의미와 범위를 프리셋 전용으로 간주하고 해당 계약이 알려질 때까지 변경하지 마십시오.

## **조정 값을 커넥터 기하학에 연결**

굽은 커넥터의 경우, 조정 값을 사용하여 개별 세그먼트 위치를 추정할 수 있습니다. 이러한 계산은 커넥터 프리셋에 특화됩니다:

- `BentConnector4`는 일반적으로 하나의 `ConnectorBendPositionX`와 하나의 `ConnectorBendPositionY` 조정을 노출합니다.
- 이 굽힘 위치에 대해 `getRawValue`가 반환하는 값을 `100000f`로 나누면 아래 예제에서 사용되는 커넥터 프레임 너비 또는 높이의 비율이 됩니다.
- 커넥터 프레임은 회전되거나 뒤집힐 수 있으므로, 프레임 좌표는 슬라이드 좌표와 비교하기 전에 변환되어야 합니다.

다음 예제는 먼저 `getType`을 사용하여 조정을 식별합니다. 컬렉션 인덱스를 이동 가능한 식별자로 취급하지 않습니다.

### **회전되지 않은 커넥터**

초기 레이아웃에는 `BentConnector4`로 연결된 두 텍스트 도형이 포함됩니다:

![connector-shape-complex](connector-shape-complex.png)

이 예제는 커넥터를 검사하고 수평 및 수직 굽힘 조정을 얻습니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

두 굽힘을 모두 변경하려면 각 예상 유형을 찾아 두 개가 모두 발견된 후에만 값을 수정하십시오:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

그 결과 수평 및 수직 세그먼트가 이동한 커넥터가 됩니다:

![connector-adjusted-1](connector-adjusted-1.png)

의미 유형이 알려지면 그 값을 커넥터 프레임 좌표로 변환할 수 있습니다. 이 예제는 두 굽힘 조정에 의해 제어되는 수직 세그먼트 위에 얇은 사각형을 그립니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

가이드 도형은 계산된 세그먼트를 표시합니다:

![connector-adjusted-2](connector-adjusted-2.png)

### **회전되거나 뒤집힌 커넥터**

동일한 커넥터 기하학이 수직으로 배치될 때, [IShape.getFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapeframe/#getFlipH--), 및 [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapeframe/#getFlipV--) 값은 커넥터 프레임 좌표를 슬라이드 좌표로 변환하는 데 영향을 줍니다.

이 예제는 수직으로 배치된 커넥터를 생성하고 조정합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

조정된 커넥터는 도형 사이에 수직으로 표시됩니다:

![connector-adjusted-3](connector-adjusted-3.png)

임의의 회전 각도 `alpha`에 대해, 커넥터 프레임 점 `(x, y)`를 프레임 중심 `(x0, y0)`를 기준으로 회전합니다:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

다음 코드는 이 예제에서 사용된 90도 방향을 처리하고 해당 커넥터 세그먼트 위에 빨간 가이드를 그립니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

좌표 변환 후 빨간 가이드는 계산된 세그먼트를 표시합니다:

![connector-adjusted-4](connector-adjusted-4.png)

이 공식들은 예제에 사용된 프리셋을 설명할 뿐, 일반적인 커넥터 모델을 의미하지 않습니다. 다른 프리셋에 동일한 계산을 적용하기 전에 조정 유형, 프레임 방향 및 값 범위를 검증하십시오.

## **커넥터 방향 각도 찾기**

직선 커넥터의 방향은 너비와 높이에서 수평 및 수직 뒤집기를 적용하여 계산할 수 있습니다. 다음 예제는 슬라이드 좌표에서 양의 수평 축을 기준으로 시계 방향 각도를 보고합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**커넥터가 도형에 연결될 수 있는지 어떻게 확인할 수 있나요?**  
도형의 [getConnectionSiteCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getConnectionSiteCount--) 값을 확인하십시오. 양수인 경우 도형이 연결 지점을 노출한다는 의미입니다. 선택한 사이트 인덱스를 커넥터 양쪽 끝에 할당하기 전에 검증하십시오.

**컬렉션 인덱스로 커넥터 조정을 식별할 수 있나요?**  
인덱스는 알려진 커넥터 프리셋 및 컬렉션 레이아웃에 대해서만 의미가 있습니다. 값을 수정하기 전에 [IAdjustValue.getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getType--)을 확인하고, 동일한 의미 유형이 여러 번 나타날 경우 [IAdjustValue.getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iadjustvalue/#getName--)을 추가 정보로 사용하십시오.

**연결된 도형이 삭제되면 어떻게 되나요?**  
해당 커넥터 끝이 분리됩니다. 커넥터는 슬라이드에 남아 삭제하거나 자유 선으로 위치를 지정하거나 다른 도형에 연결할 수 있습니다.

**슬라이드를 복사할 때 커넥터 연결이 유지되나요?**  
연결된 도형과 함께 슬라이드를 복사하면 바인딩이 일반적으로 유지됩니다. 커넥터가 대상 도형 중 하나 없이 복사된 경우, 영향을 받은 끝을 다시 연결해야 합니다.