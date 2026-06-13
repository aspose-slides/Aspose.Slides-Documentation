---
title: .NET에서 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/net/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint와 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가하세요—몇 초 만에 원활하고 효율적인 슬라이드 삽입이 가능합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에 프로그래밍 방식으로 슬라이드를 추가할 수 있습니다. 프레젠테이션은 마스터/레이아웃 슬라이드와 일반 슬라이드로 구성되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드는 고유 ID를 가지고 있으며, 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서는 `Presentation` 객체를 생성하고, 슬라이드 컬렉션에 접근하며, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드로 작업한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하고, 레이아웃을 사용하며, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 내용도 다룹니다.

## **프레젠테이션에 슬라이드 추가**
프레젠테이션 파일에 슬라이드를 추가하기 전에 슬라이드에 대한 몇 가지 사실을 살펴보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 마스터/레이아웃 슬라이드와 기타 일반 슬라이드가 포함됩니다. 즉, 프레젠테이션 파일에는 하나 이상의 슬라이드가 포함됩니다. Aspose.Slides for .NET에서는 슬라이드가 없는 프레젠테이션 파일을 지원하지 않는다는 점을 알아두어야 합니다. 각 슬라이드는 고유 Id를 가지며, 모든 일반 슬라이드는 0 기반 인덱스로 지정된 순서대로 배열됩니다. Aspose.Slides for .NET은 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있도록 지원합니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계에 따라 진행하십시오:

- Create an instance of [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) class by setting a reference to the Slides(collection of content Slide objects) property exposed by the Presentation object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the AddEmptySlide methods exposed by ISlideCollection object
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) object.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Yes. The library supports slide collections and [insert](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/insertclone/) operations, so you can add a slide at the required index rather than only at the end.

**Are the theme/styles preserved when adding a slide based on a layout?**

Yes. A layout inherits formatting from its master, and the new slide inherits from the selected layout and its associated master.

**Which slide is present in a new "empty" presentation before adding slides?**

A newly created presentation already contains one blank slide with index zero. This is important to consider when calculating insertion indices.

**How do I choose the "right" layout for a new slide if the master has many options?**

Generally choose the [LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/) that matches the required structure ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/ko/net/aspose.slides/slidelayouttype/)). If such a layout is missing, you can [add it to the master](/slides/ko/net/slide-layout/) and then use it.