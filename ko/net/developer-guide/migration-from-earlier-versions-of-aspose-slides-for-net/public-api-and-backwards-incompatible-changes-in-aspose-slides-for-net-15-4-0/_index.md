---
title: Aspose.Slides for .NET 15.4.0의 공용 API 및 역호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공용 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) 클래스, 메서드, 속성 등을 나열하고, Aspose.Slides for .NET 15.4.0 API와 함께 도입된 기타 변경 사항을 보여줍니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **Enum OrganizationChartLayoutType이 추가되었습니다**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 열거형은 조직도에서 자식 노드의 서식 유형을 나타냅니다.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts가 추가되었습니다**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 메서드는 글머리표가 활성화된 경우(PowerPoint에서 단락 글머리표/번호 매기기를 활성화하면와 동일) 효과적인 단락 들여쓰기와 MarginLeft에 대한 기본 비영(0이 아닌) 이동값을 설정합니다. 글머리표가 비활성화된 경우에는 단락 들여쓰기와 MarginLeft을 기본값으로 재설정합니다(PowerPoint에서 단락 글머리표/번호 매기기를 비활성화하면와 동일).

예제는 [here](/slides/ko/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)에서 확인하세요:
#### **Method IConnector.Reroute가 추가되었습니다**
Aspose.Slides.IConnector.Reroute 메서드는 연결된 도형 사이에서 가능한 가장 짧은 경로를 찾도록 커넥터를 재배치합니다. 이를 위해 Reroute() 메서드는 StartShapeConnectionSiteIndex와 EndShapeConnectionSiteIndex를 변경할 수 있습니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Method IPresentation.GetSlideById가 추가되었습니다**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 메서드는 슬라이드 ID로 Slide, MasterSlide 또는 LayoutSlide을 반환합니다.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Property IShape.ConnectionSiteCount가 추가되었습니다**
Aspose.Slides.IShape.ConnectionSiteCount 속성은 도형의 연결 지점 수를 반환합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.IsReversed가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.IsReversed 속성은 다이어그램이 역전 기능을 지원하는 경우, 스마트아트 다이어그램의 (왼쪽에서 오른쪽) LTR 또는 (오른쪽에서 왼쪽) RTL 상태를 가져오거나 설정할 수 있게 합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Nodes가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.Nodes 속성은 SmartArt 객체의 루트 노드 컬렉션을 반환합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 두 번째 루트 노드 선택

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 속성은 해당 노드가 데이터 모델에서 숨겨진 노드인 경우 true를 반환합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true 를 반환합니다

  if(hidden)

  {

    //일부 작업 또는 알림을 수행합니다

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 속성은 현재 노드와 연관된 조직도 유형을 가져오거나 설정할 수 있게 합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Layout에 대한 Set 메서드가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.Layout 속성에 대한 set 메서드가 추가되었습니다. 이를 통해 기존 다이어그램의 레이아웃 유형을 변경할 수 있습니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **사소한 API 변경 사항**
**다음은 사소한 API 변경 사항 목록입니다:**

|Enum Aspose.Slides.BevelColorMode |삭제됨, 사용되지 않는 열거형 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |삭제됨, 사용되지 않는 속성 |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |추가됨 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |삭제됨 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |구식으로 삭제됨 |