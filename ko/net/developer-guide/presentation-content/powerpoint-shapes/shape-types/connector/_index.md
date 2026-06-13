---
title: ".NET에서 프레젠테이션의 연결선 관리"
linktitle: "연결선"
type: docs
weight: 10
url: /ko/net/connector/
keywords:
- "연결선"
- "연결선 유형"
- "연결선 점"
- "연결선 라인"
- "연결선 각도"
- "도형 연결"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET 애플리케이션이 PowerPoint 슬라이드에서 선을 그리기, 연결하기 및 자동 라우팅하도록 지원합니다—직선, 팔꿈치 및 곡선 연결선을 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint 연결선은 두 개의 도형을 연결하거나 연결하는 특별한 선이며, 슬라이드에서 도형이 이동하거나 재배치될 때에도 도형에 부착된 상태를 유지합니다.  

연결선은 일반적으로 *연결점*(녹색 점)에 연결되며, 모든 도형에 기본적으로 존재합니다. 커서가 연결점에 가까워지면 연결점이 표시됩니다.

*조정점*(주황색 점)은 특정 연결선에만 존재하며, 연결선의 위치와 모양을 수정하는 데 사용됩니다.

## **연결선 종류**

PowerPoint에서는 직선, 팔꿈치(각진) 및 곡선 연결선을 사용할 수 있습니다.  

Aspose.Slides는 다음과 같은 연결선을 제공합니다:

| 연결선 | 이미지 | 조정점 수 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
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

## **연결선을 사용하여 도형 연결하기**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. `Shapes` 객체가 제공하는 `AddAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
1. `Shapes` 객체가 제공하는 `AddConnector` 메서드를 사용하여 연결선 유형을 정의하고 연결선을 추가합니다.
1. 연결선을 사용하여 도형을 연결합니다.
1. `Reroute` 메서드를 호출하여 최단 연결 경로를 적용합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 두 도형(타원과 사각형) 사이에 굽은 연결선(굽은 연결선)을 추가하는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
using (Presentation input = new Presentation())
{                
    // 특정 슬라이드의 도형 컬렉션에 접근합니다
    IShapeCollection shapes = input.Slides[0].Shapes;

    // 타원 자동 도형을 추가합니다
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 사각형 자동 도형을 추가합니다
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 슬라이드 도형 컬렉션에 연결선 도형을 추가합니다
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 연결선을 사용하여 도형을 연결합니다
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 도형 간 자동 최단 경로를 설정하는 reroute를 호출합니다
    connector.Reroute();

    // 프레젠테이션을 저장합니다
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.Reroute` 메서드는 연결선을 재배선하고 도형 사이의 가장 짧은 경로를 강제로 취하도록 합니다. 이를 수행하기 위해 메서드는 `StartShapeConnectionSiteIndex` 및 `EndShapeConnectionSiteIndex` 점을 변경할 수 있습니다. 

{{% /alert %}} 

## **연결점 지정하기**
연결선이 도형의 특정 점을 사용하여 두 도형을 연결하도록 하려면 다음과 같이 선호하는 연결점을 지정해야 합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. `Shapes` 객체가 제공하는 `AddAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)을 추가합니다.
1. `Shapes` 객체가 제공하는 `AddConnector` 메서드를 사용하여 연결선 유형을 정의하고 연결선을 추가합니다.
1. 연결선을 사용하여 도형을 연결합니다.
1. 도형에 선호하는 연결점을 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 선호하는 연결점을 지정하는 작업을 보여줍니다:

```c#
 // PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 특정 슬라이드의 도형 컬렉션에 접근합니다
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // 슬라이드의 도형 컬렉션에 연결선 도형을 추가합니다
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // 타원 자동 도형을 추가합니다
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 사각형 자동 도형을 추가합니다
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // 연결선을 사용하여 도형을 연결합니다
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // 타원 도형에 원하는 연결점 인덱스를 설정합니다
    uint wantedIndex = 6;

    // 선호하는 인덱스가 최대 사이트 인덱스 개수보다 작은지 확인합니다
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // 타원 자동 도형에 원하는 연결점을 설정합니다
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // 프레젠테이션을 저장합니다
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **연결선 점 조정하기**

조정점이 있는 기존 연결선을 조정할 수 있습니다. 조정점이 있는 연결선만 이 방식으로 변경할 수 있습니다. **[연결선 종류](/slides/ko/net/connector/#types-of-connectors)** 표를 참고하세요.

### **단순 사례**

두 도형(A와 B) 사이의 연결선이 세 번째 도형(C)을 통과하는 경우를 고려합니다:

![connector-obstruction](connector-obstruction.png)

코드:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

세 번째 도형을 피하거나 우회하려면 연결선을 왼쪽으로 수직선을 이동시켜 조정할 수 있습니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **복합 사례** 

보다 복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 연결선의 조정점은 위치를 계산하고 결정하는 수식과 강하게 연결되어 있습니다. 따라서 점 위치를 변경하면 연결선 모양이 바뀔 수 있습니다.
* 연결선의 조정점은 배열에 엄격한 순서대로 정의됩니다. 조정점은 연결선 시작점에서 끝점까지 번호가 매겨집니다.
* 조정점 값은 연결선 형태의 너비/높이 비율을 나타냅니다.  
  * 형태는 연결선 시작점과 끝점을 1000배한 범위 내에 있습니다.  
  * 첫 번째, 두 번째, 세 번째 점은 각각 너비 비율, 높이 비율, 다시 너비 비율을 정의합니다.
* 연결선 조정점 좌표를 계산할 때는 연결선의 회전 및 반사를 고려해야 합니다. **Note**: **[연결선 종류](/slides/ko/net/connector/#types-of-connectors)**에 표시된 모든 연결선의 회전 각도는 0입니다.

#### **사례 1**

두 텍스트 프레임 개체가 연결선을 통해 연결된 경우를 고려합니다:

![connector-shape-complex](connector-shape-complex.png)

코드:

```c#
// PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
// 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
ISlide sld = pres.Slides[0];
// 연결선을 통해 결합될 도형들을 추가합니다
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// 연결선을 추가합니다
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// 연결선의 방향을 지정합니다
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// 연결선의 색상을 지정합니다
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// 연결선의 선 두께를 지정합니다
connector.LineFormat.Width = 3;

// 연결선을 사용해 도형들을 연결합니다
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// 연결선의 조정점을 가져옵니다
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**조정**

해당 너비와 높이 비율을 각각 20%와 200% 증가시켜 연결선의 조정점 값을 변경할 수 있습니다:

```c#
// 조정점의 값을 변경합니다
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

개별 부분의 좌표와 형태를 결정할 수 있는 모델을 정의하기 위해, 연결선.Adjustments[0] 점에 해당하는 수평 요소를 나타내는 도형을 만들어 보겠습니다:

```c#
// 연결선의 수직 구성 요소를 그립니다
float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서 기본 원리를 사용한 간단한 연결선 조정 작업을 보여주었습니다. 일반 상황에서는 연결선 회전 및 표시(Connector.Rotation, Connector.Frame.FlipH, Connector.Frame.FlipV)도 고려해야 합니다. 이제 과정을 시연합니다.

먼저, 슬라이드에 새로운 텍스트 프레임 개체(**To 1**)를 추가하고(연결 목적) 기존 개체에 연결되는 새로운(녹색) 연결선을 생성합니다.

```c#
// 새 바인딩 개체를 생성합니다
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// 새 연결선을 생성합니다
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// 새로 만든 연결선을 사용하여 객체를 연결합니다
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// 연결선의 조정점을 가져옵니다
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// 조정점의 값을 변경합니다 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

둘째, 새 연결선의 조정점 connector.Adjustments[0]을 통과하는 수평 요소에 해당하는 도형을 만들겠습니다. 여기서는 connector.Rotation, connector.Frame.FlipH, connector.Frame.FlipV 값을 사용하고, 주어진 점 x0을 기준으로 회전하는 일반 좌표 변환 수식을 적용합니다:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

우리 경우 객체 회전 각도가 90도이며, 연결선이 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```c#
 // 연결선 좌표를 저장합니다
x = connector.X;
y = connector.Y;
 // 연결선 좌표가 나타날 경우 이를 보정합니다
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
 // 조정점 값을 좌표로 사용합니다
x += connector.Width * adjValue_0.RawValue / 100000;
 //  좌표를 변환합니다 (Sin(90)=1, Cos(90)=0이므로)
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
 // 두 번째 조정점 값을 사용해 수평 구성 요소의 너비를 결정합니다
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 간단한 조정과 복잡한 조정점(회전 각도가 있는 조정점) 계산을 시연했습니다. 이 지식을 활용하면 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표에 따라 연결선 조정점 값을 설정하는 자체 모델(또는 코드를) 개발할 수 있습니다.

## **연결선의 각도 찾기**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. 연결선 도형에 접근합니다.
1. 선의 너비, 높이, 도형 프레임 높이 및 도형 프레임 너비를 사용하여 각도를 계산합니다.

다음 C# 코드는 연결선 도형의 각도를 계산하는 작업을 보여줍니다:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**연결선을 특정 도형에 “붙일 수” 있는지 어떻게 확인합니까?**

해당 도형이 [연결 사이트](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/connectionsitecount/)를 제공하는지 확인하세요. 연결 사이트가 없거나 개수가 0이면 붙이기가 지원되지 않으며, 이 경우 자유 끝점을 사용해 수동으로 위치를 지정해야 합니다. 붙이기 전에 사이트 개수를 확인하는 것이 바람직합니다.

**연결된 도형 중 하나를 삭제하면 연결선은 어떻게 됩니까?**

양 끝이 분리됩니다; 연결선은 자유 시작/끝을 가진 일반 선으로 슬라이드에 남습니다. 이를 삭제하거나 다시 연결하고 필요에 따라 [reroute](https://reference.aspose.com/slides/ko/net/aspose.slides/connector/reroute/)할 수 있습니다.

**슬라이드를 다른 프레젠테이션에 복사할 때 연결선 바인딩이 유지됩니까?**

일반적으로 대상 도형도 함께 복사되면 유지됩니다. 슬라이드가 연결된 도형 없이 다른 파일에 삽입되면 양 끝이 자유롭게 되고 다시 붙여야 합니다.