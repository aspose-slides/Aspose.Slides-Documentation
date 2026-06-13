---
title: .NET에서 프레젠테이션 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 100
url: /ko/net/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument의 슬라이드 섹션을 간소화합니다 — 분할, 이름 변경, 순서 재배치를 통해 PPTX 및 ODP 작업 흐름을 최적화합니다."
---
## **Introduction**

Aspose.Slides for .NET를 사용하면 PowerPoint 프레젠테이션을 섹션으로 구성할 수 있습니다. 특정 슬라이드를 포함하는 섹션을 만들 수 있습니다.

다음과 같은 상황에서 섹션을 만들고 이를 사용하여 프레젠테이션의 슬라이드를 논리적인 부분으로 조직하거나 구분하고 싶을 수 있습니다:

- 여러 사람 또는 팀과 함께 큰 프레젠테이션을 작업하고 있으며, 특정 슬라이드를 동료나 팀원에게 할당해야 할 때.  
- 많은 슬라이드가 포함된 프레젠테이션을 다루고 있으며, 한 번에 내용을 관리하거나 편집하기가 어려울 때.

가능하면, 비슷한 슬라이드들을 포함하는 섹션을 만들고(슬라이드가 공통점을 갖거나 규칙에 따라 그룹화될 수 있음) 그 섹션에 내부 슬라이드를 설명하는 이름을 부여해야 합니다.

## **Create Sections in Presentations**

프레젠테이션에 슬라이드를 포함하는 섹션을 추가하려면, Aspose.Slides for .NET이 제공하는 AddSection 메서드를 사용하여 만들 섹션의 이름과 섹션이 시작되는 슬라이드를 지정할 수 있습니다.

다음 샘플 코드는 C#에서 프레젠테이션에 섹션을 만드는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1은 newSlide2에서 끝나고 그 뒤에 section2가 시작됩니다   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Change the Names of Sections**

PowerPoint 프레젠테이션에 섹션을 만든 후, 해당 섹션의 이름을 변경하고 싶을 수 있습니다.

다음 샘플 코드는 Aspose.Slides를 사용해 C#에서 프레젠테이션의 섹션 이름을 변경하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. Only individual slides can be hidden. A section as an entity has no "hidden" state.

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**

Yes. A section is uniquely defined by its starting slide; given a slide you can determine which section it belongs to, and for a section you can access its first slide.