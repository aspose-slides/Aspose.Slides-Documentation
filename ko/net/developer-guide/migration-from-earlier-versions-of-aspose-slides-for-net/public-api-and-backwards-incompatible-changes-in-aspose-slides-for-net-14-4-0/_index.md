---
title: Aspose.Slides for .NET 14.4.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
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
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활히 마이그레이션하세요."
---
## **공개 API 및 이전 버전과 호환되지 않는 변경 사항**
### **추가된 인터페이스, 클래스, 메서드 및 속성**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides 속성이 추가되었습니다**
속성 Aspose.Slides.ILayoutSlide.HasDependingSlides는 이 레이아웃 슬라이드에 의존하는 슬라이드가 하나라도 존재하면 true를 반환합니다. 예시:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() 메서드**
메서드 Aspose.Slides.ILayoutSlide.Remove()는 최소한의 코드로 프레젠테이션에서 레이아웃을 제거할 수 있게 해 줍니다. 예시:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 메서드**
메서드 Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)는 컬렉션에서 레이아웃을 제거할 수 있게 해 줍니다. 코드 예시:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
메서드 Aspose.Slides.ILayoutSlideCollection.RemoveUnused()는 사용되지 않는 레이아웃 슬라이드(HasDependingSlides가 false인 레이아웃 슬라이드)를 제거할 수 있게 해 줍니다. 코드 예시:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides 속성**
속성 Aspose.Slides.IMasterSlide.HasDependingSlides는 이 마스터 슬라이드에 의존하는 슬라이드가 하나라도 있으면 true를 반환합니다. 예시:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() 메서드**
메서드 Aspose.Slides.ISlide.Remove()는 최소한의 코드로 프레젠테이션에서 슬라이드를 제거할 수 있게 해 줍니다. 예시:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
속성 Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat은 레이아웃이 글머리표를 제공하는 경우 SmartArt 노드 글머리표에 대한 IFillFormat을 반환합니다. 글머리표 이미지를 설정하는 데 사용할 수 있습니다.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level 속성**
속성 Aspose.Slides.SmartArt.ISmartArtNode.Level은 SmartArt 노드의 중첩 레벨을 반환합니다.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position 속성**
속성 Aspose.Slides.SmartArt.ISmartArtNode.Position은 형제 노드 중에서 해당 노드의 위치를 반환합니다.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() 메서드가 추가되었습니다**
메서드 Aspose.Slides.SmartArt.ISmartArtNode.Remove()는 다이어그램에서 노드를 제거할 수 있게 해 줍니다.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection 인터페이스 및 GlobalLayoutSlideCollection 클래스**
IGlobalLayoutSlideCollection 인터페이스와 GlobalLayoutSlideCollection 클래스가 Aspose.Slides 네임스페이스에 추가되었습니다.

GlobalLayoutSlideCollection 클래스는 IGlobalLayoutSlideCollection 인터페이스를 구현합니다.

IGlobalLayoutSlideCollection 인터페이스는 프레젠테이션의 모든 레이아웃 슬라이드 컬렉션을 나타냅니다. IPresentation.LayoutSlides 속성은 IGlobalLayoutSlideCollection 형식입니다. IGlobalLayoutSlideCollection은 마스터 레이아웃 슬라이드의 개별 컬렉션을 통합하는 맥락에서 레이아웃 슬라이드를 추가 및 복제하는 메서드와 함께 ILayoutSlideCollection 인터페이스를 확장합니다:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 지정된 레이아웃 슬라이드의 복사본을 프레젠테이션에 추가하는 데 사용할 수 있습니다. 이 메서드는 원본 서식을 유지합니다(다른 프레젠테이션 간에 레이아웃을 복제할 때 마스터도 복제될 수 있습니다. 내부 레지스트리를 사용해 자동 복제된 마스터를 추적하여 같은 마스터 슬라이드의 복제본이 여러 개 생성되는 것을 방지합니다.).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 지정된 레이아웃 슬라이드의 복사본을 프레젠테이션에 추가합니다. 새 레이아웃은 대상 프레젠테이션의 지정된 마스터에 연결됩니다. 이 옵션은 Microsoft PowerPoint의 **Use Destination Theme** 옵션을 사용해 복사/붙여넣기와 동일합니다.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 프레젠테이션에 새 레이아웃 슬라이드를 추가합니다. 지원되는 레이아웃 유형: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. 레이아웃 이름은 자동으로 생성될 수 있습니다. SlideLayoutType.Custom 유형의 추가된 레이아웃은 플레이스홀더와 도형이 없습니다. 이 메서드의 유사 메서드는 IMasterSlide.LayoutSlides 속성을 통해 접근하는 IMasterLayoutSlideCollection.Add(SlideLayoutType, string) 메서드입니다.
#### **인터페이스 IMasterLayoutSlideCollection 및 클래스 MasterLayoutSlideCollection**
IMasterLayoutSlideCollection 인터페이스와 MasterLayoutSlideCollection 클래스가 Aspose.Slides 네임스페이스에 추가되었습니다. MasterLayoutSlideCollection 클래스는 IMasterLayoutSlideCollection 인터페이스를 구현합니다.

IMasterLayoutSlideCollection 인터페이스는 정의된 마스터 슬라이드의 모든 레이아웃 슬라이드 컬렉션을 나타냅니다. 이는 마스터의 개별 레이아웃 슬라이드 컬렉션 맥락에서 레이아웃 슬라이드를 추가, 삽입, 제거 또는 복제하는 메서드를 포함하도록 ILayoutSlideCollection 인터페이스를 확장합니다:

``` csharp

 // 메서드 시그니처:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// sourceLayout의 복사본을 destMasterSlide에 연결하는 코드 예제:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

메서드는 지정된 레이아웃 슬라이드의 복사본을 컬렉션 끝에 추가하는 데 사용할 수 있습니다. 새 레이아웃은 이 레이아웃 슬라이드 컬렉션의 부모 마스터 슬라이드와 연결됩니다. 따라서 PowerPoint에서 **Use Destination Theme** 옵션을 사용해 복사/붙여넣기와 동일합니다. 이 메서드의 유사 메서드는 IPresentation.LayoutSlides 속성을 통해 접근하는 IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) 메서드입니다.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 지정된 위치에 지정된 레이아웃 슬라이드의 복사본을 삽입하는 데 사용됩니다. 새 레이아웃은 해당 컬렉션의 부모 마스터 슬라이드와 연결됩니다. 따라서 PowerPoint에서 **Use Destination Theme** 옵션을 사용한 복사/붙여넣기와 동일합니다.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 지정된 위치에 새 레이아웃 슬라이드를 추가하거나 삽입합니다. 지원되는 레이아웃 유형: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. 레이아웃 이름은 자동으로 생성될 수 있습니다. SlideLayoutType.Custom 유형의 추가된 레이아웃은 플레이스홀더와 도형이 없습니다. 이 메서드의 유사 메서드는 IPresentation.LayoutSlides 속성을 통해 접근하는 IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) 메서드입니다.
- void RemoveAt(int index); – 컬렉션에서 지정된 인덱스의 레이아웃을 제거합니다.
- void Reorder(int index, ILayoutSlide layoutSlide); – 컬렉션에서 레이아웃 슬라이드를 지정된 위치로 이동합니다.
### **변경된 메서드 및 속성**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) 메서드 시그니처**
ISlideCollection 메서드의 시그니처:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
이 시그니처는 이제 사용되지 않으며 다음 시그니처로 교체되었습니다.
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)
allowCloneMissingLayout 매개변수는 대상 마스터에 새로운(복제된) 슬라이드에 적합한 레이아웃이 없을 경우 수행할 작업을 지정합니다. 적합한 레이아웃은 원본 슬라이드와 동일한 유형 또는 이름을 가진 레이아웃입니다. 지정된 마스터에 적합한 레이아웃이 없으면 원본 슬라이드의 레이아웃이 복제됩니다(allowCloneMissingLayout가 true인 경우) 또는 PptxEditException이 발생합니다(allowCloneMissingLayout가 false인 경우).

구식 메서드를 호출하면
AddClone(sourceSlide, destMaster);
allowCloneMissingLayout가 false와 동일하게 간주됩니다(즉, 적절한 레이아웃이 없으면 PptxEditException이 발생). 새로운 시그니처를 사용하는 동일한 기능의 호출은 다음과 같습니다.
AddClone(sourceSlide, destMaster, false);

누락된 레이아웃을 자동으로 복제하고 싶다면 allowCloneMissingLayout 매개변수를 true로 전달하십시오.

동일하게 다음 메서드도 이제 사용되지 않으며 새 시그니처로 교체되었습니다.
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);
새 시그니처:
ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides 속성의 타입**
Aspose.Slides.IMasterSlide.LayoutSlides 속성의 타입이 ILayoutSlideCollection에서 새로운 IMasterLayoutSlideCollection 인터페이스로 변경되었습니다. IMasterLayoutSlideCollection 인터페이스는 ILayoutSlideCollection의 하위 인터페이스이므로 기존 코드는 별도의 수정이 필요하지 않습니다.
#### **Aspose.Slides.IPresentation.LayoutSlides 속성의 타입이 변경되었습니다**
Aspose.Slides.IPresentation.LayoutSlides 속성의 타입이 ILayoutSlideCollection에서 새로운 IGlobalLayoutSlideCollection 인터페이스로 변경되었습니다. IGlobalLayoutSlideCollection 인터페이스는 ILayoutSlideCollection의 하위 인터페이스이므로 기존 코드는 별도의 수정이 필요하지 않습니다.