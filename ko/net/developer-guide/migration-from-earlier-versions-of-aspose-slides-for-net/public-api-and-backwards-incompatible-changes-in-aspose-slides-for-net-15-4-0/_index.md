---
title: Aspose.Slides for .NET 15.4.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항
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
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for .NET 15.4.0 API에 도입된 추가되었거나 제거된 클래스, 메서드, 속성 등과 기타 변경 사항을 모두 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **Enum OrganizationChartLayoutType 가 추가되었습니다**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 열거형은 조직도에서 자식 노드의 서식 유형을 나타냅니다.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts 가 추가되었습니다**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 메서드는 글머리표가 활성화된 경우(PowerPoint가 단락 글머리표/번호 매기기를 활성화했을 때와 동일) 효과적인 단락 들여쓰기와 MarginLeft에 기본 비영(0이 아닌) 값을 설정합니다. 글머리표가 비활성화된 경우 단락 들여쓰기와 MarginLeft를 재설정합니다(PowerPoint가 단락 글머리표/번호 매기기를 비활성화했을 때와 동일).

예제는 [여기](/slides/ko/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)에서 확인할 수 있습니다.
#### **Method IConnector.Reroute 가 추가되었습니다**
Aspose.Slides.IConnector.Reroute 메서드는 연결기(connector)를 재배치하여 연결된 도형 사이의 최단 경로를 취하도록 합니다. 이를 위해 Reroute() 메서드는 StartShapeConnectionSiteIndex와 EndShapeConnectionSiteIndex를 변경할 수 있습니다.

``` csharp

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
#### **Method IPresentation.GetSlideById 가 추가되었습니다**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 메서드는 슬라이드 ID로 슬라이드, 마스터 슬라이드 또는 레이아웃 슬라이드를 반환합니다.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount 가 추가되었습니다**
Aspose.Slides.IShape.ConnectionSiteCount 속성은 도형에 있는 연결 지점의 수를 반환합니다.

``` csharp

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
#### **Property ISmartArt.IsReversed 가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.IsReversed 속성은 다이어그램이 왼쪽에서 오른쪽(LTR) 또는 오른쪽에서 왼쪽(RTL) 방향으로 반전될 수 있는 경우 해당 상태를 가져오거나 설정합니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes 가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.Nodes 속성은 SmartArt 객체의 루트 노드 컬렉션을 반환합니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 두 번째 루트 노드 선택

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden 가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 속성은 이 노드가 데이터 모델에서 숨겨진 노드인지 여부를 true로 반환합니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true를 반환합니다

  if(hidden)

  {

    //몇 가지 동작 또는 알림 수행

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout 가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 속성은 현재 노드와 연결된 조직도 차트 유형을 가져오거나 설정합니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout 가 추가되었습니다**
Aspose.Slides.SmartArt.ISmartArt.Layout 속성의 set 메서드가 추가되었습니다. 이를 통해 기존 다이어그램의 레이아웃 유형을 변경할 수 있습니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **경미한 API 변경 사항**
**경미한 API 변경 사항 목록:**

|Enum Aspose.Slides.BevelColorMode |삭제된, 사용되지 않는 열거형 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |삭제된, 사용되지 않는 속성 |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |추가 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |삭제 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |obsolete(구식)로 삭제 |