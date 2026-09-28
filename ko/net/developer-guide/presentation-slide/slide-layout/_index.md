---
title: .NET에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/net/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리 표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 미사용 레이아웃
- 바닥글 가시성
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 레이아웃을 적용, 생성 및 수정하고, 자리 표시자를 추가하며, 미사용 레이아웃을 제거하고, 바닥글 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리 표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 가지면서도 각 슬라이드가 자체 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제목 자리 표시자를 포함합니다.
- **제목 및 내용**: 제목 자리 표시자와 일반 용도 콘텐츠 자리 표시자를 포함합니다.
- **빈 슬라이드**: 콘텐츠 자리 표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션은 세 가지 관련 수준을 가집니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [일반 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/) uses one layout and stores the content entered for that slide.

A 일반 슬라이드 inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a 일반 슬라이드 overrides the inherited value at that level. When a 일반 슬라이드 is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the 일반 슬라이드.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing 일반 슬라이드.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [슬라이드 마스터](/slides/ko/net/slide-master/).

To hide inherited logos or decorative master shapes on one slide or through a shared layout, see [마스터 그래픽 가시성 제어](/slides/ko/net/slide-master/). The example compares two slides using the same master.

## **슬라이드 레이아웃 선택 및 적용**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **제목 및 내용** on the first master. If that layout is unavailable, it deliberately falls back to **빈 슬라이드**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [ISlide.LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/layoutslide/) property.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **레이아웃 슬라이드 추가**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/masterlayoutslidecollection/add/) method on the target master's layout collection.

The following example always adds a new **제목 및 내용** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **레이아웃 슬라이드에 자리 표시자 추가**

The [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/placeholdermanager/) property provides an [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint 자리 표시자 | `ILayoutPlaceholderManager` 메서드 |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

The following example verifies that the **빈 슬라이드** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

결과:

![레이아웃 슬라이드의 자리 표시자](add_placeholders.png)

{{% alert color="warning" title="경고" %}}
Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

Use the [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

To remove one specific layout, first use its [HasDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/hasdependingslides/) property or [GetDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/getdependingslides/) method. Reassign any dependent slides before calling [ILayoutSlide.Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/remove/). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception/).

## **레이아웃 슬라이드에서 바닥글 가시성 제어**

A layout has its own footer, slide-number, and date-time placeholders. Use the [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/headerfootermanager/) property to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **마스터 및 해당 자식 레이아웃에서 바닥글 가시성 제어**

To apply consistent footer settings across a master hierarchy, use the [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/headerfootermanager/) property. The propagation methods of [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **자주 묻는 질문**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇입니까?**

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**레이아웃 슬라이드를 한 프레젠테이션에서 다른 프레젠테이션으로 복사할 수 있습니까?**

Yes. Add a copy to the destination collection with the [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/globallayoutslidecollection/addclone/) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**이미 사용 중인 레이아웃을 수정하면 어떻게 됩니까?**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [GetDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/getdependingslides/) to identify the affected slides before editing the layout.

**여전히 사용 중인 레이아웃을 제거하면 어떻게 됩니까?**

Aspose.Slides throws a [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) to remove only unreferenced layouts.