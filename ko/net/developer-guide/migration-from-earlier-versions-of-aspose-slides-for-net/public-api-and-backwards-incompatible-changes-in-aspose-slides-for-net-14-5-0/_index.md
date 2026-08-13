---
title: Aspose.Slides for .NET 14.5.0의 공용 API 및 하위 호환성 깨지는 변경 사항
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Aspose.Slides for .NET의 공용 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for .NET 14.5.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 [restrictions](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 및 기타 [changes](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)을 소개합니다.

{{% /alert %}} 
## **공용 API 및 호환되지 않는 변경 사항**
### **추가된 인터페이스, 클래스, 속성 및 메서드**
#### **Aspose.Slides.IPresentationInfo 인터페이스 및 PresentationInfo 클래스 추가**
프레젠테이션에 대한 정보를 나타냅니다.

- Boolean 형식의 IsEncrypted 속성은 프레젠테이션이 암호화된 경우 True를, 그렇지 않은 경우 False를 반환합니다.
- LoadFormat 속성은 프레젠테이션의 유형을 가져옵니다.
#### **Aspose.Slides.IShape.IsGrouped 속성 추가**
Aspose.Slides.IShape.IsGrouped 속성은 도형이 그룹화되어 있는지 여부를 판단합니다.
#### **Aspose.Slides.IShape.ParentGroup 속성 추가**
Aspose.Slides.IShape.ParentGroup 속성은 도형이 그룹화된 경우 상위 GroupShape 객체를 반환하고, 그렇지 않으면 null을 반환합니다.
#### **Aspose.Slides.IShapeCollection.AddGroupShape() 메서드 추가**
Aspose.Slides.IShapeCollection.AddGroupShape() 메서드는 새로운 GroupShape을 생성하고 컬렉션의 끝에 추가합니다.
새 도형이 추가될 때 GroupShape의 프레임 크기와 위치가 콘텐츠에 맞게 조정됩니다.
#### **Aspose.Slides.IShapeCollection.Clear() 메서드 추가**
Aspose.Slides.IShapeCollection.Clear() 메서드는 컬렉션에서 모든 도형을 제거합니다.
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) 메서드 추가**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) 메서드는 새로운 GroupShape을 생성하고 지정된 인덱스 위치에 컬렉션에 삽입합니다.
새 도형이 추가될 때 GroupShape의 프레임 크기와 위치가 콘텐츠에 맞게 조정됩니다.
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) 메서드 추가**
이 메서드들은 프레젠테이션을 전체 로드하지 않고도 프레젠테이션 파일 또는 스트림에 대한 정보를 얻을 수 있게 해줍니다.
#### **IPresentationFactory PresentationFactory.Instance 속성 추가**
이 속성은 개발자가 인스턴스를 생성하지 않고도 팩터리 기능을 사용할 수 있게 합니다.
### **제한 사항**
#### **IShape.Frame에 대한 제한**
IShape.Frame에 대한 정의되지 않은 값을 사용하는 것에 제한이 추가되었습니다. IShape.Frame에 정의되지 않은 프레임을 할당하려는 코드는 대부분의 경우 의미가 없으며(특히 상위 GroupShape이 다른 {{GroupShape}}들에 다중 중첩된 경우), 예를 들어:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// ArgumentException을 발생시킵니다: 프레임 값은 정의되어 있어야 합니다.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// ArgumentException을 발생시킵니다: x, y, width 및 height가 정의되어 있어야 합니다.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

이러한 코드는 상황을 모호하게 만들 수 있습니다. 따라서 IShape.Frame에 정의되지 않은 값을 사용하는 것이 제한되었습니다. x, y, width, height, flipH, flipV, rotationAngle 값은 정의되어 있어야 하며(float.NaN 또는 NullableBool.NotDefined 로 설정해서는 안 됩니다). 위 예제 코드는 이제 ArgumentException 예외를 발생시킵니다.
다음 사용 사례에 적용됩니다:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x, y, width 및 height 매개변수는 float.NaN일 수 없으며, flipH와 flipV는 NullableBool.NotDefined일 수 없습니다:
 // cannot be NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// 동일한 제한이 도형을 생성하는 모든 메서드에 적용됩니다:
 // AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
 // AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
 // InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
 // InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

하지만 IShape.RawFrame 프레임 속성은 정의되지 않을 수 있습니다. 이는 도형이 플레이스홀더에 연결된 경우에 의미가 있습니다. 이때 정의되지 않은 도형 프레임 값은 상위 플레이스홀더 도형에서 대체됩니다. 상위 플레이스홀더가 없으면 해당 도형은 IShape.RawFrame을 기반으로 유효 프레임을 계산할 때 기본값을 사용합니다. 기본값은 x, y, width, height, flipH, flipV, rotationAngle에 대해 0 및 NullableBool.False 입니다. 예를 들어:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 도형이 플레이스홀더에 연결되어 있습니다
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // 이제 도형은 플레이스홀더에서 x, y, height, flipH, flipV 값을 상속받고 width=100 및 rotationAngle=0을 재정의합니다.
}
``` 
### **변경된 속성**
#### **Aspose.Slides.IShapeCollection.Parent 속성 이름 및 유형 변경**
- Aspose.Slides.IShapeCollection.Parent 속성의 유형이 ISlideComponent에서 새로운 IGroupShape 인터페이스로 변경되었습니다. IGroupShape 인터페이스는 ISlideComponent의 하위이므로 기존 코드는 변경할 필요가 없습니다.
- Aspose.Slides.IShapeCollection.Parent 속성의 이름이 Parent에서 ParentGroup으로 변경되었습니다.
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV 속성 유형 변경**
- Aspose.Slides.IShapeFrame.FlipH 속성의 유형이 bool에서 NullableBool로 변경되었습니다.
- IShape.Frame 속성은 모든 속성이 정의된 유효 값을 갖는 IShapeFrame의 인스턴스를 반환합니다.
- IShape.RawFrame 속성은 각 속성이 정의되지 않을 수 있는 IShapeFrame 인스턴스를 반환합니다(특히 FlipH 또는 FlipV는 NullableBool.NotDefined 값을 가질 수 있습니다).