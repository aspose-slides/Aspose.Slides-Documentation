---
title: JavaScript를 사용한 프레젠테이션 연결선 관리
linktitle: 연결선
type: docs
weight: 10
url: /ko/nodejs-java/connector/
keywords:
- 연결선
- 연결선 유형
- 연결점
- 연결선 라인
- 연결선 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript 애플리케이션이 PowerPoint 슬라이드에서 선을 그리며 연결하고 자동 라우팅하도록 지원하여 직선, 팔꿈치형 및 곡선 연결선을 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint 연결선은 두 개의 도형을 연결하거나 연결하는 특수한 선으로, 슬라이드에서 도형이 이동하거나 위치가 바뀌어도 도형에 부착된 상태로 유지됩니다. 

연결선은 일반적으로 *연결 점* (녹색 점)에 연결되며, 이는 기본적으로 모든 도형에 존재합니다. 커서가 근접하면 연결 점이 표시됩니다.

*조정점* (주황색 점)은 특정 연결선에만 존재하며, 연결선의 위치와 모양을 수정하는 데 사용됩니다.

## **연결선 유형**

PowerPoint에서는 직선, 팔꿈치(각도) 및 곡선 연결선을 사용할 수 있습니다.  
Aspose.Slides는 다음과 같은 연결선을 제공합니다:

| 연​결​선 | 이미지 | 조정점 수 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **연결선을 사용하여 도형 연결하기**

1. [Presentation](https://apireference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만듭니다.  
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
1. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)를 추가합니다.  
1. `Shapes` 객체가 제공하는 `addConnector` 메서드로 연결선 유형을 정의하여 연결선을 추가합니다.  
1. 연결선을 사용하여 도형을 연결합니다.  
1. 가장 짧은 연결 경로를 적용하기 위해 `reroute` 메서드를 호출합니다.  
1. 프레젠테이션을 저장합니다.  

다음 JavaScript 코드는 두 도형(타원과 사각형) 사이에 연결선(굽은 연결선)을 추가하는 방법을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 특정 슬라이드의 도형 컬렉션에 접근합니다
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 타원 자동 도형을 추가합니다
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 사각형 자동 도형을 추가합니다
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 슬라이드 도형 컬렉션에 연결선 도형을 추가합니다
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 연결선을 사용하여 도형을 연결합니다
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 도형 간 자동 최단 경로를 설정하는 reroute 메서드를 호출합니다
    connector.reroute();
    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 메서드는 연결선을 재경로 지정하여 도형 간 최단 경로를 강제로 따르게 합니다. 이를 달성하기 위해 메서드는 `setStartShapeConnectionSiteIndex` 및 `setEndShapeConnectionSiteIndex` 지점을 변경할 수 있습니다. 
{{% /alert %}} 

## **연결점 지정**

연결선이 도형의 특정 점을 사용하여 두 도형을 연결하도록 하려면 다음과 같이 원하는 연결점을 지정해야 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만듭니다.  
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
1. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)를 추가합니다.  
1. `Shapes` 객체가 제공하는 `addConnector` 메서드로 연결선 유형을 정의하여 연결선을 추가합니다.  
1. 연결선을 사용하여 도형을 연결합니다.  
1. 도형에 원하는 연결점을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 JavaScript 코드는 선호하는 연결점을 지정하는 작업을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 특정 슬라이드의 도형 컬렉션에 접근합니다
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 타원 자동 도형을 추가합니다
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 사각형 자동 도형을 추가합니다
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 슬라이드의 도형 컬렉션에 연결선 도형을 추가합니다
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 연결선을 사용하여 도형을 연결합니다
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 타원 도형에 선호하는 연결점 인덱스를 설정합니다
    var wantedIndex = 6;
    // 선호하는 인덱스가 최대 사이트 인덱스 수보다 작은지 확인합니다
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // 타원 자동 도형에 선호하는 연결점을 설정합니다
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **연결선 점 조정**

기존 연결선을 조정점을 통해 조정할 수 있습니다. 조정점이 있는 연결선만 이러한 방식으로 변경할 수 있습니다. **[연결선 유형](/slides/ko/nodejs-java/connector/#types-of-connectors)** 아래 표를 참고하세요.

### **단순 사례**

두 도형(A와 B) 사이의 연결선이 세 번째 도형(C)을 통과하는 경우를 고려해 보세요:

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

세 번째 도형을 피하거나 우회하려면 연결선의 수직선을 왼쪽으로 이동하여 조정할 수 있습니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **복잡한 사례들** 

보다 복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 연결선의 조정 가능한 점은 그 위치를 계산하고 결정하는 공식과 강하게 연결되어 있습니다. 따라서 점 위치를 변경하면 연결선의 모양이 바뀔 수 있습니다.  
* 연결선의 조정점은 배열에 엄격한 순서대로 정의됩니다. 조정점은 연결선의 시작점부터 끝점까지 번호가 매겨집니다.  
* 조정점 값은 연결선 도형의 폭/높이 비율을 나타냅니다.  
  * 도형은 연결선의 시작점과 끝점을 1000배한 범위 내에 제한됩니다.  
  * 첫 번째 점은 폭 비율을, 두 번째 점은 높이 비율을, 세 번째 점은 다시 폭 비율을 각각 정의합니다.  
* 연결선 조정점 좌표를 계산할 때는 연결선의 회전 및 반사를 고려해야 합니다. **참고** **[연결선 유형](/slides/ko/nodejs-java/connector/#types-of-connectors)** 에 표시된 모든 연결선의 회전 각도는 0입니다.

#### **사례 1**

두 개의 텍스트 프레임 객체가 연결선을 통해 연결된 경우를 고려해 보세요:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 연결선을 통해 함께 연결될 도형들을 추가합니다
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 연결선을 추가합니다
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // 연결선의 방향을 지정합니다
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // 연결선의 색상을 지정합니다
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 연결선 선의 두께를 지정합니다
    connector.getLineFormat().setWidth(3);
    // 도형들을 연결선으로 연결합니다
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // 연결선의 조정점을 가져옵니다
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**조정**

연결선의 조정점 값을 해당 폭 비율을 20% 증가시키고 높이 비율을 200% 증가시켜 변경할 수 있습니다:

```javascript
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

연결선의 개별 부분의 좌표와 형태를 결정할 수 있는 모델을 정의하기 위해, `connector.getAdjustments().get_Item(0)` 지점에서 연결선의 수평 구성 요소에 해당하는 도형을 만들어 보겠습니다:

```javascript
// 연결선의 수직 구성 요소를 그립니다
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서는 기본 원리를 이용한 간단한 연결선 조정 작업을 보여주었습니다. 일반 상황에서는 연결선 회전 및 표시(이는 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` 로 설정됨)를 고려해야 합니다. 이제 그 과정을 보여드리겠습니다.

먼저, 슬라이드에 새로운 텍스트 프레임 객체(**To 1**)를 추가하고(연결을 위해) 기존에 만든 객체와 연결하는 새로운(녹색) 연결선을 만들겠습니다.

```javascript
// 새 바인딩 객체를 생성합니다
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 새 연결선을 생성합니다
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// 새로 만든 연결선을 사용해 객체를 연결합니다
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 연결선의 조정점을 가져옵니다
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

둘째, 새 연결선의 조정점 `connector.getAdjustments().get_Item(0)` 를 통과하는 수평 구성 요소에 해당하는 도형을 생성합니다. 우리는 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` 값들을 사용하고 주어진 점 x0를 중심으로 회전하는 좌표 변환 공식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리의 경우 객체 회전 각도는 90도이며 연결선이 수직으로 표시되므로 아래와 같은 코드가 해당됩니다:

```javascript
// 연결선 좌표를 저장합니다
x = connector.getX();
y = connector.getY();
// 연결선 좌표가 나타나는 경우 보정합니다
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// 조정점 값을 좌표로 사용합니다
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Sin(90)=1이고 Cos(90)=0이므로 좌표를 변환합니다
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// 두 번째 조정점 값을 사용하여 수평 구성 요소의 너비를 결정합니다
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 간단한 조정 및 회전 각도가 포함된 복잡한 조정점에 대한 계산을 시연했습니다. 습득한 지식을 활용해 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표에 따라 연결선의 조정점 값을 설정하는 모델(또는 코드를) 개발할 수 있습니다.

## **연결선 각도 찾기**

1. 클래​스​의 인스턴스를 생성합니다.  
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
1. 연결선 도형에 접근합니다.  
1. 선의 너비, 높이, 도형 프레임 높이 및 도형 프레임 너비를 사용하여 각도를 계산합니다.  

다음 JavaScript 코드는 연결선 도형의 각도를 계산하는 작업을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**연결선을 특정 도형에 "붙일" 수 있는지 어떻게 확인할 수 있나요?**  
도형이 [connection sites](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getconnectionsitecount/) 를 제공하는지 확인하세요. 없거나 개수가 0이면 붙이기가 불가능하므로 자유로운 끝점을 사용하고 수동으로 위치를 지정해야 합니다. 연결하기 전에 사이트 개수를 확인하는 것이 현명합니다.

**연결된 도형 중 하나를 삭제하면 연결선은 어떻게 되나요?**  
끝이 분리되며 연결선은 자유 시작/끝을 가진 일반 선으로 슬라이드에 남습니다. 삭제하거나 연결을 다시 지정할 수 있으며 필요시 [reroute](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/connector/reroute/) 를 사용할 수 있습니다.

**슬라이드를 다른 프레젠테이션에 복사할 때 연결선 바인딩이 유지되나요?**  
일반적으로 대상 도형도 함께 복사되는 경우 유지됩니다. 연결된 도형 없이 슬라이드를 다른 파일에 삽입하면 끝이 자유롭게 변하고 다시 연결해야 합니다.