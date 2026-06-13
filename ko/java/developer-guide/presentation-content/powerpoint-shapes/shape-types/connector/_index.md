---
title: Java를 사용한 프레젠테이션 연결선 관리
linktitle: 연결선
type: docs
weight: 10
url: /ko/java/connector/
keywords:
- 연결선
- 연결선 유형
- 연결점
- 연결선
- 연결선 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java 애플리케이션이 PowerPoint 슬라이드에서 선을 그리며 연결하고 자동 경로 지정하도록 지원합니다—직선, 엘보(각도) 및 곡선 연결선을 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint 연결선은 두 개의 도형을 연결하거나 링크하는 특수한 선으로, 슬라이드에서 도형이 이동하거나 재배치되더라도 도형에 부착된 상태를 유지합니다.  

연결선은 일반적으로 *연결점* (녹색 점)에 연결되며, 이는 모든 도형에 기본적으로 존재합니다. 커서가 연결점에 가까이 오면 표시됩니다.  

*조정점* (주황색 점)은 특정 연결선에만 존재하며, 연결선의 위치와 형태를 수정하는 데 사용됩니다.

## **연결선 종류**

PowerPoint에서는 직선, 엘보(각도) 및 곡선 연결선을 사용할 수 있습니다.  

Aspose.Slides는 다음과 같은 연결선을 제공합니다:

| 연결선 | 이미지 | 조정점 수 |
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

## **연결선을 사용하여 도형 연결**

1. [Presentation](https://apireference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/AutoShape)를 추가합니다.  
4. `Shapes` 객체가 제공하는 `addConnector` 메서드와 연결선 유형을 정의하여 연결선을 추가합니다.  
5. 연결선을 사용하여 도형을 연결합니다.  
6. `reroute` 메서드를 호출하여 최단 연결 경로를 적용합니다.  
7. 프레젠테이션을 저장합니다.  

다음 Java 코드는 두 도형(타원과 사각형) 사이에 연결선(굽은 연결선)을 추가하는 방법을 보여줍니다:

```Java
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 특정 슬라이드에 대한 도형 컬렉션에 접근합니다
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Ellipse 자동도형을 추가합니다
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Rectangle 자동도형을 추가합니다
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // 슬라이드 도형 컬렉션에 연결선 도형을 추가합니다
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // 연결선을 사용하여 도형들을 연결합니다
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 도형 사이의 자동 최단 경로를 설정하는 reroute를 호출합니다
    connector.reroute();
    
    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 메서드는 연결선을 재경로 지정하여 도형 사이에서 가능한 최단 경로를 취하도록 강제합니다. 이를 위해 이 메서드는 `setStartShapeConnectionSiteIndex` 및 `setEndShapeConnectionSiteIndex` 포인트를 변경할 수 있습니다. 
{{% /alert %}} 

## **연결점 지정**

특정 도형의 연결점을 사용하여 두 도형을 연결하려면, 다음과 같이 원하는 연결점을 지정해야 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. `Shapes` 객체가 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/AutoShape)를 추가합니다.  
4. `Shapes` 객체가 제공하는 `addConnector` 메서드와 연결선 유형을 정의하여 연결선을 추가합니다.  
5. 연결선을 사용하여 도형을 연결합니다.  
6. 도형에 원하는 연결점을 설정합니다.  
7. 프레젠테이션을 저장합니다.  

다음 Java 코드는 선호하는 연결점을 지정하는 동작을 보여줍니다:

```java
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 특정 슬라이드에 대한 도형 컬렉션에 접근합니다
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Ellipse 자동도형을 추가합니다
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Rectangle 자동도형을 추가합니다
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 슬라이드의 도형 컬렉션에 연결선 도형을 추가합니다
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 연결선을 사용하여 도형들을 연결합니다
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Ellipse 도형에 선호하는 연결점 인덱스를 설정합니다
    int wantedIndex = 6;

    // 선호하는 인덱스가 최대 사이트 인덱스 개수보다 작은지 확인합니다
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Ellipse 자동도형에 선호하는 연결점을 설정합니다
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **연결선 포인트 조정**

기존 연결선은 조정점을 통해 조정할 수 있습니다. 조정점이 있는 연결선만 이 방법으로 변경할 수 있습니다. **[연결선 종류](/slides/ko/java/connector/#types-of-connectors)** 표를 참조하십시오.

### **간단한 사례**

연결선이 두 도형(A와 B) 사이를 연결하면서 세 번째 도형(C)을 통과하는 경우를 고려해 보겠습니다:

![연결선-방해](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

세 번째 도형을 피하거나 우회하려면, 연결선의 수직선을 왼쪽으로 이동시켜 조정할 수 있습니다:

![연결선-방해-수정](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **복잡한 사례** 

보다 복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 연결선의 조정 가능한 포인트는 그 위치를 계산하고 결정하는 수식과 강하게 연결되어 있습니다. 따라서 포인트 위치를 변경하면 연결선의 형태가 바뀔 수 있습니다.  
* 연결선의 조정점은 배열에서 엄격한 순서로 정의됩니다. 조정점은 연결선의 시작점부터 끝점까지 번호가 매겨집니다.  
* 조정점 값은 연결선 도형의 너비/높이 비율을 나타냅니다.  
  * 도형은 연결선의 시작점과 끝점에 1000을 곱한 값으로 정의됩니다.  
  * 첫 번째 포인트는 너비 비율, 두 번째 포인트는 높이 비율, 세 번째 포인트는 다시 너비 비율을 정의합니다.  
* 연결선 조정점 좌표를 계산할 때는 연결선의 회전 및 반사를 고려해야 합니다. **참고** **[연결선 종류](/slides/ko/java/connector/#types-of-connectors)**에 표시된 모든 연결선의 회전 각도는 0입니다.  

#### **사례 1**

두 개의 텍스트 프레임 개체가 연결선을 통해 연결된 경우를 고려해 보겠습니다:

![연결선-도형-복합](connector-shape-complex.png)

```java
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    // 연결선을 통해 함께 연결될 도형들을 추가합니다
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 연결선을 추가합니다
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // 연결선의 방향을 지정합니다
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // 연결선의 색상을 지정합니다
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // 연결선의 두께를 지정합니다
    connector.getLineFormat().setWidth(3);
    
    // 연결선을 사용하여 도형들을 연결합니다
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // 연결선의 조정점을 가져옵니다
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Adjustment**

연결선의 조정점 값을 해당 너비와 높이 비율을 각각 20%와 200% 증가시켜 변경할 수 있습니다:

```java
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

연결선의 개별 부분 좌표와 형태를 결정할 수 있는 모델을 정의하기 위해, `connector.getAdjustments().get_Item(0)` 포인트에서 연결선의 수평 구성요소에 해당하는 도형을 생성해 보겠습니다:

```java
// 연결선의 수직 구성 요소를 그립니다
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서는 기본 원리를 사용한 간단한 연결선 조정 작업을 시연했습니다. 일반적인 상황에서는 연결선의 회전 및 표시(이것은 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()`에 의해 설정됩니다)를 고려해야 합니다. 이제 그 과정을 시연하겠습니다.

먼저, 슬라이드에 새로운 텍스트 프레임 객체(**To 1**)를 추가하고(연결용) 기존에 만든 객체와 연결되는 새로운(녹색) 연결선을 생성합니다.

```java
// 새 바인딩 객체를 생성합니다
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 새 연결선을 생성합니다
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 새로 만든 연결선을 사용하여 객체를 연결합니다
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 연결선 조정점을 가져옵니다
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

둘째, 새 연결선의 조정점 `connector.getAdjustments().get_Item(0)`을 통과하는 수평 구성요소에 해당하는 도형을 생성합니다. 우리는 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()`의 값을 사용하고, 주어진 점 x0를 중심으로 회전하는 좌표 변환 공식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리의 경우, 객체의 회전 각도는 90도이며 연결선은 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```java
// 연결선 좌표를 저장합니다
x = connector.getX();
y = connector.getY();
// 나타날 경우 연결선 좌표를 보정합니다
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 조정점 값을 좌표로 사용합니다
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  좌표를 변환합니다 (Sin(90)=1, Cos(90)=0)
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 두 번째 조정점 값을 사용하여 수평 구성 요소의 너비를 결정합니다
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 단순 조정과 회전 각도가 포함된 복잡한 조정점 계산을 시연했습니다. 습득한 지식을 활용하여 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표를 기반으로 연결선의 조정점 값을 설정하는 모델(또는 코드를) 개발할 수 있습니다.

## **연결선 각도 찾기**

1. 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용해 슬라이드의 참조를 가져옵니다.  
3. 연결선 도형에 접근합니다.  
4. 선 너비, 높이, 도형 프레임 높이 및 도형 프레임 너비를 사용해 각도를 계산합니다.  

다음 Java 코드는 연결선 도형의 각도를 계산하는 작업을 시연합니다:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**연결선을 특정 도형에 "붙일" 수 있는지 어떻게 알 수 있나요?**

도형이 [connection sites](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getConnectionSiteCount--)를 제공하는지 확인하십시오. 연결점이 없거나 개수가 0이면 붙이기가 불가능하므로, 대신 자유 엔드포인트를 사용하여 수동으로 위치를 지정합니다. 연결하기 전에 사이트 개수를 확인하는 것이 좋습니다.

**연결된 도형 중 하나를 삭제하면 연결선은 어떻게 되나요?**

연결선의 양 끝이 분리되고, 해당 연결선은 자유 시작/끝을 가진 일반 선으로 슬라이드에 남아 있습니다. 이를 삭제하거나 연결을 재지정할 수 있으며, 필요하면 [reroute](https://reference.aspose.com/slides/ko/java/com.aspose.slides/connector/#reroute--)를 사용할 수 있습니다.

**슬라이드를 다른 프레젠테이션으로 복사할 때 연결선 바인딩이 유지되나요?**

일반적으로 대상 도형도 함께 복사되는 경우 유지됩니다. 연결된 도형 없이 슬라이드를 다른 파일에 삽입하면 끝이 자유롭게 되며, 다시 연결해야 합니다.