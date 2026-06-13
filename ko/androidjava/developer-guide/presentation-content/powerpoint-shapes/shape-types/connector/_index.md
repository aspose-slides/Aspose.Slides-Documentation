---
title: Android에서 프레젠테이션의 커넥터 관리
linktitle: 커넥터
type: docs
weight: 10
url: /ko/androidjava/connector/
keywords:
- 커넥터
- 커넥터 유형
- 커넥터 포인트
- 커넥터 라인
- 커넥터 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 슬라이드에 선을 그리며 연결하고 자동 라우팅하도록 Java 앱을 지원합니다 - 직선, 팔꿈치 및 곡선 커넥터를 완벽히 제어할 수 있습니다."
---
## **소개**

PowerPoint 커넥터는 두 도형을 연결하거나 연결해 주는 특수한 선으로, 해당 슬라이드에서 도형을 이동하거나 재배치해도 도형에 계속 부착된 상태를 유지합니다.  

커넥터는 일반적으로 *연결 점* (녹색 점)에 연결되며, 이 점은 기본적으로 모든 도형에 존재합니다. 커서가 연결 점에 가까이 다가가면 표시됩니다.  

*조정 점* (주황색 점)은 특정 커넥터에만 존재하며, 커넥터의 위치와 형태를 변경하는 데 사용됩니다.  

## **커넥터 유형**

PowerPoint에서는 직선, 팔꿈치(각도) 및 곡선 커넥터를 사용할 수 있습니다.  

Aspose.Slides에서는 다음 커넥터를 제공합니다:

| 커넥터 | 이미지 | 조정 점 수 |
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

## **커넥터를 사용하여 도형 연결**

1. 다음 [프레젠테이션](https://apireference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. `Shapes` 객체에서 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AutoShape) 을 추가합니다.  
1. `Shapes` 객체에서 제공하는 `addConnector` 메서드를 사용하여 커넥터 유형을 지정하고 커넥터를 추가합니다.  
1. 커넥터를 사용하여 도형을 연결합니다.  
1. 가장 짧은 연결 경로를 적용하려면 `reroute` 메서드를 호출합니다.  
1. 프레젠테이션을 저장합니다.  

다음 Java 코드는 두 도형(타원과 사각형) 사이에 커넥터(굽은 커넥터)를 추가하는 방법을 보여 줍니다:

```Java
    // PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
    Presentation pres = new Presentation();
    try {
        // 특정 슬라이드의 도형 컬렉션에 접근합니다
        IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
        
        // 타원 자동 도형을 추가합니다
        IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
        
        // 사각형 자동 도형을 추가합니다
        IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
        
        // 슬라이드 도형 컬렉션에 커넥터 도형을 추가합니다
        IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        
        // 커넥터를 사용해 도형을 연결합니다
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
`Connector.reroute` 메서드는 커넥터의 경로를 다시 설정하여 도형 사이의 가장 짧은 경로를 강제로 사용하도록 합니다. 이를 수행하기 위해 메서드는 `setStartShapeConnectionSiteIndex` 및 `setEndShapeConnectionSiteIndex` 값을 변경할 수 있습니다. 
{{% /alert %}} 

## **연결 점 지정**

커넥터가 도형의 특정 점을 사용하여 두 도형을 연결하도록 하려면 다음과 같이 원하는 연결 점을 지정해야 합니다:

1. 다음 [프레젠테이션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. `Shapes` 객체에서 제공하는 `addAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AutoShape) 을 추가합니다.  
1. `Shapes` 객체에서 제공하는 `addConnector` 메서드를 사용하여 커넥터 유형을 지정하고 커넥터를 추가합니다.  
1. 커넥터를 사용하여 도형을 연결합니다.  
1. 도형에 원하는 연결 점을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 Java 코드는 원하는 연결 점을 지정하는 작업을 보여 줍니다:

```java
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 특정 슬라이드의 도형 컬렉션에 접근합니다
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 타원 자동 도형을 추가합니다
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 사각형 자동 도형을 추가합니다
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 슬라이드의 도형 컬렉션에 커넥터 도형을 추가합니다
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 커넥터를 사용해 도형들을 연결합니다
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 타원 도형에 원하는 연결 점 인덱스를 설정합니다
    int wantedIndex = 6;

    // 원하는 인덱스가 최대 사이트 인덱스 개수보다 작은지 확인합니다
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 타원 자동 도형에 원하는 연결 점을 설정합니다
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // 프레젠테이션을 저장합니다
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **커넥터 점 조정**

기존 커넥터는 조정 점을 통해 조정할 수 있습니다. 조정 점이 있는 커넥터만 이 방법으로 변경할 수 있습니다. **[커넥터 유형](/slides/ko/androidjava/connector/#types-of-connectors)** 표를 참조하십시오.

### **단순 사례**

두 도형(A와 B) 사이의 커넥터가 세 번째 도형(C)을 통과하는 경우를 고려해 보겠습니다:

![connector-obstruction](connector-obstruction.png)

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

세 번째 도형을 피하거나 우회하려면 커넥터의 수직선을 왼쪽으로 이동하여 조정할 수 있습니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **복합 사례** 

보다 복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 커넥터의 조정 가능한 점은 해당 점의 위치를 계산하고 결정하는 수식과 강하게 연결되어 있습니다. 따라서 점 위치를 변경하면 커넥터의 형태가 바뀔 수 있습니다.  
* 커넥터의 조정 점은 배열에서 엄격한 순서로 정의됩니다. 조정 점은 커넥터의 시작점에서 끝점까지 번호가 매겨집니다.  
* 조정 점 값은 커넥터 도형의 너비/높이에 대한 백분율을 나타냅니다.  
  * 도형은 커넥터의 시작점과 끝점을 1000배한 범위 내에 있습니다.  
  * 첫 번째 점은 너비에 대한 백분율, 두 번째 점은 높이에 대한 백분율, 세 번째 점은 다시 너비에 대한 백분율을 정의합니다.  
* 커넥터 조정 점 좌표를 계산할 때는 커넥터의 회전 및 반사를 고려해야 합니다. **주의** 모든 커넥터에 대한 회전 각도는 **[커넥터 유형](/slides/ko/androidjava/connector/#types-of-connectors)**에 표시된 바와 같이 0입니다.  

#### **사례 1**

두 텍스트 프레임 객체가 커넥터를 통해 연결된 경우를 고려해 보겠습니다:

![connector-shape-complex](connector-shape-complex.png)

```java
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    // 커넥터를 통해 연결될 도형들을 추가합니다
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 커넥터를 추가합니다
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // 커넥터의 방향을 지정합니다
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // 커넥터의 색상을 지정합니다
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // 커넥터 선의 두께를 지정합니다
    connector.getLineFormat().setWidth(3);
    
    // 커넥터로 도형들을 연결합니다
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // 커넥터의 조정점을 가져옵니다
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**조정**

각각 너비와 높이 백분율을 20%와 200%씩 증가시켜 커넥터의 조정 점 값을 변경할 수 있습니다:

```java
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

커넥터 개별 부품의 좌표와 형태를 결정할 수 있는 모델을 정의하기 위해, `connector.getAdjustments().get_Item(0)` 점에서 커넥터의 수평 구성 요소에 해당하는 도형을 생성해 보겠습니다:

```java
// 커넥터의 수직 구성 요소를 그립니다
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서 기본 원리를 사용하여 간단한 커넥터 조정 작업을 보여 주었습니다. 일반적인 상황에서는 커넥터 회전 및 표시(이것은 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()`에 의해 설정됩니다)를 고려해야 합니다. 이제 그 과정을 보여 드리겠습니다.

첫 번째로, 연결 목적으로 슬라이드에 새로운 텍스트 프레임 객체(**To 1**)를 추가하고, 기존에 만든 객체와 연결되는 새로운 (녹색) 커넥터를 생성합니다.

```java
// 새로운 바인딩 객체를 생성합니다
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 새로운 커넥터를 생성합니다
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 새로 만든 커넥터를 사용해 객체들을 연결합니다
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 커넥터의 조정점을 가져옵니다
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 조정점의 값을 변경합니다
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

두 번째로, 새로운 커넥터의 조정 점 `connector.getAdjustments().get_Item(0)`을 통과하는 커넥터의 수평 구성 요소에 해당하는 도형을 생성합니다. 우리는 `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()`의 값을 사용하고, 주어진 점 x0를 기준으로 회전하는 좌표 변환 공식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리의 경우, 객체의 회전 각도는 90도이며 커넥터가 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```java
// 커넥터 좌표를 저장합니다
x = connector.getX();
y = connector.getY();
// 커넥터 좌표가 뒤집힌 경우 보정합니다
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
// Sin(90)=1, Cos(90)=0 이므로 좌표를 변환합니다
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 두 번째 조정점 값을 사용해 수평 구성 요소의 너비를 결정합니다
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 간단한 조정과 회전 각도가 있는 복잡한 조정 점을 포함한 계산을 시연했습니다. 습득한 지식을 활용하여 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표를 기반으로 커넥터의 조정 점 값을 설정하는 모델(또는 코드를) 개발할 수 있습니다.

## **커넥터 선의 각도 찾기**

1. 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.  
1. 커넥터 선 도형에 접근합니다.  
1. 선의 너비, 높이, 도형 프레임 높이 및 도형 프레임 너비를 사용하여 각도를 계산합니다.  

다음 Java 코드는 커넥터 선 도형의 각도를 계산하는 작업을 보여 줍니다:

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

**특정 도형에 커넥터를 "붙일" 수 있는지 어떻게 확인할 수 있나요?**  
도형이 [연결 지점](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--)을 제공하는지 확인하십시오. 연결 지점이 없거나 개수가 0이면 붙이기 기능을 사용할 수 없으며, 이 경우 자유로운 끝점을 사용해 수동으로 배치해야 합니다. 연결하기 전에 사이트 개수를 확인하는 것이 좋습니다.  

**연결된 도형 중 하나를 삭제하면 커넥터는 어떻게 되나요?**  
양끝이 분리되어 슬라이드에 일반 선으로 남으며, 시작/끝이 자유로운 상태가 됩니다. 이를 삭제하거나 연결을 재지정할 수 있으며, 필요한 경우 [reroute](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/connector/#reroute--)를 사용할 수 있습니다.  

**슬라이드를 다른 프레젠테이션으로 복사할 때 커넥터 연결이 유지되나요?**  
대상 도형도 함께 복사되는 경우 일반적으로 유지됩니다. 연결된 도형 없이 슬라이드를 다른 파일에 삽입하면 끝점이 자유롭게 되고 다시 연결해야 합니다.