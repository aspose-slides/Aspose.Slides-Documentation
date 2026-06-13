---
title: C++를 사용한 프레젠테이션에서 커넥터 관리
linktitle: 커넥터
type: docs
weight: 10
url: /ko/cpp/connector/
keywords:
- 커넥터
- 커넥터 유형
- 커넥터 포인트
- 커넥터 라인
- 커넥터 각도
- 도형 연결
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++ 애플리케이션이 PowerPoint 슬라이드에서 선을 그리고, 연결하고, 자동 라우팅하도록 지원하여 직선, 엘보 및 곡선 커넥터를 완전히 제어할 수 있습니다."
---
## **소개**

PowerPoint 커넥터는 두 도형을 연결하거나 연결된 상태로 유지하는 특수한 선이며, 슬라이드에서 도형을 이동하거나 재배치해도 도형에 부착된 상태로 남습니다.

커넥터는 일반적으로 *연결점*(녹색 점)에 연결되며, 이 연결점은 모든 도형에 기본적으로 존재합니다. 커서가 연결점에 가까워지면 표시됩니다.

*조정점*(주황색 점)은 일부 커넥터에만 존재하며, 커넥터의 위치와 형태를 수정하는 데 사용됩니다.

## **커넥터 종류**

PowerPoint에서는 직선, 엘보(각진) 및 곡선 커넥터를 사용할 수 있습니다.

Aspose.Slides는 다음과 같은 커넥터를 제공합니다.

| 커넥터 | 이미지 | 조정점 수 |
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

## **커넥터를 사용하여 도형 연결하기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. `Shapes` 객체가 제공하는 `AddAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.auto_shape)을 추가합니다.
1. 커넥터 유형을 정의하여 `Shapes` 객체가 제공하는 `AddConnector` 메서드로 커넥터를 추가합니다.
1. 커넥터를 사용해 도형을 연결합니다.
1. 가장 짧은 연결 경로를 적용하려면 `Reroute` 메서드를 호출합니다.
1. 프레젠테이션을 저장합니다.

다음 C++ 코드는 두 도형(타원과 사각형) 사이에 구부러진 커넥터를 추가하는 방법을 보여 줍니다:

```c++
// 문서 디렉터리 경로.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 원하는 프레젠테이션을 로드합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 특정 슬라이드의 도형 컬렉션에 접근합니다
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 타원 자동 도형을 추가합니다
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 사각형 자동 도형을 추가합니다
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// 슬라이드 도형 컬렉션에 커넥터 도형을 추가합니다
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// 커넥터를 사용해 도형을 연결합니다
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// 도형 간 자동 최단 경로를 설정하는 reroute를 호출합니다
	connector->Reroute();
	
	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
`connector->Reroute` 메서드는 커넥터를 재배치하여 도형 사이의 최단 경로를 강제합니다. 이 과정을 위해 메서드는 `StartShapeConnectionSiteIndex`와 `EndShapeConnectionSiteIndex` 값을 변경할 수 있습니다. 
{{% /alert %}} 

## **연결점 지정하기**

특정 도형의 지정된 점을 이용해 커넥터가 두 도형을 연결하도록 하려면 다음과 같이 선호하는 연결점을 지정하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. `Shapes` 객체가 제공하는 `AddAutoShape` 메서드를 사용하여 슬라이드에 두 개의 [AutoShape](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.auto_shape)을 추가합니다.
1. 커넥터 유형을 정의하여 `Shapes` 객체가 제공하는 `AddConnector` 메서드로 커넥터를 추가합니다.
1. 커넥터를 사용해 도형을 연결합니다.
1. 도형에 선호하는 연결점을 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 C++ 코드는 선호하는 연결점을 지정하는 예시를 보여 줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 원하는 프레젠테이션을 로드합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 특정 슬라이드의 도형 컬렉션에 접근합니다
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 타원 자동 도형을 추가합니다
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 사각형 자동 도형을 추가합니다
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// 슬라이드 도형 컬렉션에 커넥터 도형을 추가합니다
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// 커넥터를 사용해 도형을 연결합니다
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// 타원 도형에 선호하는 연결점 인덱스를 설정합니다
	int wantedIndex = 6;

	// 선호 인덱스가 최대 사이트 인덱스 수보다 작은지 확인합니다
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 타원 자동 도형에 선호하는 연결점을 설정합니다
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **커넥터 점 조정하기**

조정점을 가진 커넥터만 해당 방식으로 변경할 수 있습니다. **[Types of connectors.](/slides/ko/cpp/connector/#types-of-connectors)** 표를 참고하십시오.

### **간단한 사례**

두 도형(A와 B) 사이의 커넥터가 세 번째 도형(C)를 통과하는 경우를 생각해 보십시오:

![connector-obstruction](connector-obstruction.png)

코드:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

세 번째 도형을 피하려면 커넥터의 수직선을 왼쪽으로 이동시켜 조정할 수 있습니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **복잡한 사례** 

더 복잡한 조정을 수행하려면 다음 사항을 고려해야 합니다:

* 커넥터의 조정점은 해당 위치를 계산하는 수식과 강하게 연결됩니다. 따라서 점 위치를 변경하면 커넥터 형태가 바뀔 수 있습니다.
* 조정점은 배열에 정의된 엄격한 순서대로 번호가 매겨집니다. 시작점부터 끝점까지 순서대로 번호가 부여됩니다.
* 조정점 값은 커넥터 도형의 너비/높이에 대한 백분율을 나타냅니다.  
  * 도형은 시작점과 끝점을 1000배한 값으로 제한됩니다.  
  * 첫 번째, 두 번째, 세 번째 점은 각각 너비 비율, 높이 비율, 다시 너비 비율을 정의합니다.
* 조정점 좌표를 계산할 때는 커넥터의 회전 및 반사를 고려해야 합니다. **Note**: **[Types of connectors](/slides/ko/cpp/connector/#types-of-connectors)**에 표시된 모든 커넥터의 회전 각도는 0입니다.

#### **사례 1**

두 개의 텍스트 프레임 개체가 커넥터를 통해 연결된 경우를 살펴보십시오:

![connector-shape-complex](connector-shape-complex.png)

코드:

```c++
 // PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
 auto pres = System::MakeObject<Presentation>();
 // 프레젠테이션의 첫 번째 슬라이드를 가져옵니다
 auto slide = pres->get_Slides()->idx_get(0);
 // 첫 번째 슬라이드에서 도형을 가져옵니다
 auto shapes = slide->get_Shapes();
 // 커넥터를 통해 함께 연결될 도형을 추가합니다
 auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
 shapeFrom->get_TextFrame()->set_Text(u"From");
 auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
 shapeTo->get_TextFrame()->set_Text(u"To");
 // 커넥터를 추가합니다
 auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
 auto lineFormat = connector->get_LineFormat();
 // 커넥터의 방향을 지정합니다
 lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
 // 커넥터 선의 두께를 지정합니다
 lineFormat->set_Width(3);
 // 커넥터의 색상을 지정합니다
 auto lineFillFormat = lineFormat->get_FillFormat();
 lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
 lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

 // 커넥터로 도형들을 연결합니다
 connector->set_StartShapeConnectedTo(shapeFrom);
 connector->set_StartShapeConnectionSiteIndex(3);
 connector->set_EndShapeConnectedTo(shapeTo);
 connector->set_EndShapeConnectionSiteIndex(2);

 // 커넥터의 조정점을 가져옵니다
 auto adjustments = connector->get_Adjustments();
 auto adjValue_0 = adjustments->idx_get(0);
 auto adjValue_1 = adjustments->idx_get(1);
```

**조정**

해당 너비와 높이 백분율을 각각 20%와 200% 늘려 커넥터의 조정점 값을 변경할 수 있습니다:

```c++
// 조정점의 값을 변경합니다
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

결과:

![connector-adjusted-1](connector-adjusted-1.png)

각 조정점의 좌표와 형태를 정의하는 모델을 만들기 위해, `connector.Adjustments[0]` 점에 해당하는 수평 구성 요소를 나타내는 도형을 생성합니다:

```c++
// 커넥터의 수직 구성 요소를 그립니다
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

결과:

![connector-adjusted-2](connector-adjusted-2.png)

#### **사례 2**

**사례 1**에서는 기본 원리를 사용한 간단한 조정 작업을 보여 주었습니다. 일반 상황에서는 `connector.Rotation`, `connector.Frame.FlipH`, `connector.Frame.FlipV`가 설정하는 회전 및 표시 방식을 고려해야 합니다. 이제 과정을 설명합니다.

먼저 슬라이드에 새로운 텍스트 프레임 객체(**To 1**)를 추가하고(연결용) 기존에 만든 개체와 연결되는 새로운(녹색) 커넥터를 생성합니다.

```c++
// 새 바인딩 객체를 생성합니다
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// 새 커넥터를 생성합니다
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 새로 만든 커넥터를 사용해 객체를 연결합니다
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// 커넥터의 조정점을 가져옵니다
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// 조정점의 값을 변경합니다
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

결과:

![connector-adjusted-3](connector-adjusted-3.png)

그 다음, 새 커넥터의 조정점 `connector.Adjustments[0]`을 통과하는 수평 구성 요소에 해당하는 도형을 생성합니다. 회전 각 α에 대한 좌표 변환 식을 사용합니다:

X=(x—x0)*cos(alpha)—(y—y0)*sin(alpha)+x0;
Y=(x—x0)*sin(alpha)+(y—y0)*cos(alpha)+y0;

여기서 객체의 회전 각은 90도이며 커넥터는 수직으로 표시되므로 해당 코드는 다음과 같습니다:

```c++

```

결과:

![connector-adjusted-4](connector-adjusted-4.png)

우리는 단순 조정과 회전 각이 포함된 복잡한 조정점을 모두 다루는 계산을 시연했습니다. 이 지식을 바탕으로 `GraphicsPath` 객체를 얻거나 특정 슬라이드 좌표에 따라 커넥터의 조정점 값을 설정하는 자체 모델이나 코드를 개발할 수 있습니다.

## **커넥터 선의 각도 찾기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
1. 커넥터 선 도형에 접근합니다.
1. 선의 너비, 높이, 도형 프레임 높이 및 도형 프레임 너비를 사용해 각도를 계산합니다.

다음 C++ 코드는 커넥터 선 도형의 각도를 계산하는 작업을 보여 줍니다:

```c++
void ConnectorLineAngle()
{

	// 문서 디렉터리 경로.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 원하는 프레젠테이션을 로드합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// 슬라이드의 도형 컬렉션에 접근합니다
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **FAQ**

**특정 도형에 커넥터를 “붙일” 수 있는지 확인하려면 어떻게 해야 하나요?**

도형이 [connection sites](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/get_connectionsitecount/)를 노출하는지 확인하십시오. 없거나 개수가 0이면 붙이기 기능을 사용할 수 없으므로 자유 끝점을 사용하고 수동으로 위치를 지정해야 합니다. 연결 전에 사이트 수를 확인하는 것이 현명합니다.

**연결된 도형 중 하나를 삭제하면 커넥터는 어떻게 되나요?**

양쪽 끝이 분리됩니다. 커넥터는 자유 시작/끝을 가진 일반 선으로 슬라이드에 남으며, 삭제하거나 연결을 재지정하고 필요하면 [reroute](https://reference.aspose.com/slides/ko/cpp/aspose.slides/connector/reroute/)할 수 있습니다.

**슬라이드를 다른 프레젠테이션으로 복사할 때 커넥터 바인딩이 유지되나요?**

대부분 유지됩니다. 대상 도형도 함께 복사되는 경우에 한합니다. 연결된 도형 없이 슬라이드만 삽입하면 양쪽 끝이 자유롭게 되고 다시 연결해야 합니다.