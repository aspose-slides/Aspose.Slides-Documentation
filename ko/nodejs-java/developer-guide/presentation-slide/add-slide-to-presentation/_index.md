---
title: JavaScript를 사용하여 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/nodejs-java/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가합니다 — 몇 초 만에 원활하고 효율적인 슬라이드 삽입을 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에 슬라이드를 추가할 수 있습니다. 프레젠테이션에는 마스터/레이아웃 슬라이드와 일반 슬라이드가 포함되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드에는 고유한 ID가 있으며, 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서에서는 `Presentation` 개체를 생성하고, 슬라이드 컬렉션에 접근하며, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드를 작업하고, 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하고, 레이아웃을 사용하며, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 이해와 같은 관련 사항도 다룹니다.

## **프레젠테이션에 슬라이드 추가**

프레젠테이션 파일에 슬라이드를 추가하기 전에 슬라이드에 대한 몇 가지 사실을 논의해 보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 **Master / Layout** 슬라이드와 기타 **Normal** 슬라이드가 포함되어 있습니다. 이는 프레젠테이션 파일에 하나 이상의 슬라이드가 포함되어 있음을 의미합니다. 슬라이드가 없는 프레젠테이션 파일은 Aspose.Slides for Node.js via Java에서 지원되지 않음을 알아두는 것이 중요합니다. 각 슬라이드에는 고유한 Id가 있으며, 모든 Normal 슬라이드는 0부터 시작하는 인덱스로 지정된 순서대로 정렬됩니다.

Aspose.Slides for Node.js via Java를 사용하면 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있습니다. 프레젠테이션에 빈 슬라이드를 추가하려면 아래 단계에 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 객체가 노출하는 [Slides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) (콘텐츠 Slide 객체의 컬렉션) 속성을 참조로 설정하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection) 클래스를 인스턴스화합니다.
- [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection) 객체가 노출하는 [**addEmptySlide**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) 메서드를 호출하여 콘텐츠 슬라이드 컬렉션 끝에 빈 슬라이드를 프레젠테이션에 추가합니다.
- 새로 추가된 빈 슬라이드로 작업을 수행합니다.
- 마지막으로, [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 객체를 사용하여 프레젠테이션 파일을 저장합니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // SlideCollection 클래스를 인스턴스화합니다
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides 컬렉션에 빈 슬라이드를 추가합니다
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 새로 추가된 슬라이드에 대해 작업을 수행합니다
    // PPTX 파일을 디스크에 저장합니다
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**새 슬라이드를 끝이 아닌 특정 위치에 삽입할 수 있나요?**

예. 라이브러리는 슬라이드 컬렉션과 [insert](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/insertclone/) 작업을 지원하므로, 끝에만 추가하는 것이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**레이아웃을 기반으로 슬라이드를 추가할 때 테마/스타일이 유지되나요?**

예. 레이아웃은 마스터로부터 서식을 상속하며, 새 슬라이드는 선택한 레이아웃 및 해당 마스터로부터 상속받습니다.

**슬라이드를 추가하기 전에 새 "빈" 프레젠테이션에 어떤 슬라이드가 존재합니까?**

새로 만든 프레젠테이션에는 인덱스 0인 빈 슬라이드가 이미 하나 포함되어 있습니다. 삽입 인덱스를 계산할 때 이를 고려하는 것이 중요합니다.

**마스터에 여러 옵션이 있는 경우 새 슬라이드에 적절한 레이아웃을 어떻게 선택합니까?**

대체로 필요한 구조에 맞는 [LayoutSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/) (예: [Title and Content, Two Content, 등.](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidelayouttype/))을 선택합니다. 해당 레이아웃이 없으면 [add it to the master](/slides/ko/nodejs-java/slide-layout/)를 사용하여 마스터에 추가한 뒤 사용할 수 있습니다.