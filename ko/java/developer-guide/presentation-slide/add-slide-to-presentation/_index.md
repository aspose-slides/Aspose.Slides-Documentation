---
title: Java에서 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/java/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가합니다—몇 초 만에 매끄럽고 효율적인 슬라이드 삽입을 구현합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에 슬라이드를 추가할 수 있습니다. 프레젠테이션은 마스터/레이아웃 슬라이드와 일반 슬라이드로 구성되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드는 고유한 ID를 가지며 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서에서는 `Presentation` 객체를 생성하고, 슬라이드 컬렉션에 접근하며, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드를 작업한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하고, 레이아웃을 사용하며, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 내용을 다룹니다.

## **프레젠테이션에 슬라이드 추가**

프레젠테이션 파일에 슬라이드를 추가하기 전에 슬라이드에 관한 몇 가지 사실을 살펴보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 **Master / Layout** 슬라이드와 기타 **Normal** 슬라이드가 포함됩니다. 즉, 프레젠테이션 파일에는 하나 이상(또는 그 이상의) 슬라이드가 포함되어야 합니다. Aspose.Slides for Java에서는 슬라이드가 없는 프레젠테이션 파일을 지원하지 않는다는 점을 알아두세요. 각 슬라이드는 고유한 Id를 가지며 모든 Normal 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다.

Aspose.Slides for Java는 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있도록 합니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- Presentation 객체가 제공하는 [Slides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) (콘텐츠 슬라이드 객체 컬렉션) 속성에 대한 참조를 설정하여 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection) 클래스를 인스턴스화합니다.
- [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection) 객체가 제공하는 [**addEmptySlide**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 메서드를 호출하여 콘텐츠 슬라이드 컬렉션의 끝에 빈 슬라이드를 추가합니다.
- 새로 추가된 빈 슬라이드에 대해 작업을 수행합니다.
- 마지막으로, [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 객체를 사용하여 프레젠테이션 파일을 저장합니다.

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

**특정 위치에 새 슬라이드를 삽입할 수 있나요, 끝에만이 아니고?**

예. 이 라이브러리는 슬라이드 컬렉션 및 [insert](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 연산을 지원하므로, 끝에만이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**레이아웃을 기반으로 슬라이드를 추가할 때 테마/스타일이 유지되나요?**

예. 레이아웃은 마스터로부터 서식을 상속받으며, 새 슬라이드는 선택된 레이아웃 및 해당 마스터로부터 서식을 상속받습니다.

**슬라이드를 추가하기 전에 새 "빈" 프레젠테이션에 어떤 슬라이드가 존재하나요?**

새로 만든 프레젠테이션에는 인덱스 0인 빈 슬라이드가 이미 하나 포함되어 있습니다. 삽입 인덱스를 계산할 때 이를 고려해야 합니다.

**마스터에 여러 옵션이 있을 때 새 슬라이드에 적절한 레이아웃을 어떻게 선택하나요?**

일반적으로 요구되는 구조([Title and Content, Two Content, 등](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidelayouttype/))에 맞는 [LayoutSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/layoutslide/)을 선택합니다. 해당 레이아웃이 없을 경우, [마스터에 추가](/slides/ko/java/slide-layout/)한 후 사용할 수 있습니다.