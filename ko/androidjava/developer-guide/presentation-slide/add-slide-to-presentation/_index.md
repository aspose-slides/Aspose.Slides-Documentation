---
title: Android에서 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/androidjava/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가합니다—몇 초 안에 원활하고 효율적인 슬라이드 삽입을 제공합니다."
---
## **Overview**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에 슬라이드를 추가할 수 있습니다. 프레젠테이션에는 마스터/레이아웃 슬라이드와 일반 슬라이드가 포함되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드에는 고유한 ID가 있으며 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서에서는 `Presentation` 개체를 생성하고, 슬라이드 컬렉션에 접근하며, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드를 작업한 후 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하거나 레이아웃을 사용하고, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 이해와 같은 관련 내용도 다룹니다.

## **Add a Slide to a Presentation**

프레젠테이션 파일에 슬라이드를 추가하는 이야기를 하기 전에 슬라이드에 대한 몇 가지 사실을 살펴보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 **Master / Layout** 슬라이드와 기타 **Normal** 슬라이드가 포함됩니다. 이는 프레젠테이션 파일에 하나 이상(또는 그 이상의) 슬라이드가 존재함을 의미합니다. 슬라이드가 없는 프레젠테이션 파일은 Aspose.Slides for Android via Java에서 지원되지 않는다는 점을 알아두는 것이 중요합니다. 각 슬라이드에는 고유한 Id가 있으며 모든 Normal 슬라이드는 0부터 시작하는 인덱스에 따라 정렬됩니다.

Aspose.Slides for Android via Java를 사용하면 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있습니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계에 따라 수행하십시오:

- Presentation 클래스의 인스턴스를 생성합니다.  
  - Create an instance of [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스.
- [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) 클래스를 인스턴스화하고, [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 객체가 제공하는 [Slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) (내용 Slide 객체의 컬렉션) 속성을 참조하도록 설정합니다.  
  - Instantiate [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) 클래스 by setting a reference to the [Slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) (collection of content Slide objects) property exposed by the [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) object.
- [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) 객체가 제공하는 [**addEmptySlide**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 메서드를 호출하여 콘텐츠 슬라이드 컬렉션의 끝에 빈 슬라이드를 프레젠테이션에 추가합니다.  
  - Add an empty slide to the presentation at the end of the content slides collection by calling the [**addEmptySlide**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) methods exposed by [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) object.
- 새로 추가된 빈 슬라이드에 대한 작업을 수행합니다.  
  - Do some work with the newly added empty slide.
- 마지막으로 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 객체를 사용하여 프레젠테이션 파일을 저장합니다.  
  - Finally, write the presentation file using the [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) object.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // SlideCollection 클래스를 인스턴스화합니다
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides 컬렉션에 빈 슬라이드를 추가합니다
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 새로 추가된 슬라이드에 대해 작업을 수행합니다

    // PPTX 파일을 디스크에 저장합니다
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**특정 위치에 새 슬라이드를 삽입할 수 있나요, 단지 끝에만 추가하는 것이 아니라?**  
예. 이 라이브러리는 슬라이드 컬렉션과 [insert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 작업을 지원하므로 끝에만 추가하는 것이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**레이아웃을 기반으로 슬라이드를 추가할 때 테마/스타일이 유지되나요?**  
예. 레이아웃은 마스터로부터 서식을 상속받으며, 새 슬라이드는 선택한 레이아웃 및 해당 마스터로부터 상속받습니다.

**슬라이드를 추가하기 전에 새 "empty" 프레젠테이션에 어떤 슬라이드가 존재하나요?**  
새로 만든 프레젠테이션에는 인덱스 0인 빈 슬라이드가 하나 이미 포함됩니다. 삽입 인덱스를 계산할 때 이것을 고려하는 것이 중요합니다.

**마스터에 여러 옵션이 있는 경우 새 슬라이드에 적합한 레이아웃을 어떻게 선택합니까?**  
일반적으로 필요한 구조에 맞는 [LayoutSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/layoutslide/) 를 선택합니다([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidelayouttype/)). 해당 레이아웃이 없을 경우 [add it to the master](/slides/ko/androidjava/slide-layout/) 를 통해 마스터에 추가한 다음 사용할 수 있습니다.