---
title: JavaScript로 프레젠테이션에서 슬라이드 제거
linktitle: 슬라이드 제거
type: docs
weight: 30
url: /ko/nodejs-java/remove-slide-from-presentation/
keywords:
- 슬라이드 제거
- 슬라이드 삭제
- 사용되지 않는 슬라이드 삭제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용해 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 손쉽게 제거하세요. 명확한 코드 예제를 확인하고 작업 효율을 높일 수 있습니다."
---
## **소개**

슬라이드(또는 그 내용)가 중복될 경우 삭제할 수 있습니다. Aspose.Slides는 프레젠테이션의 모든 슬라이드를 저장하는 저장소인 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)를 캡슐화하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 제공합니다. 알려진 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/) 개체에 대한 포인터(참조 또는 인덱스)를 사용하여 제거하려는 슬라이드를 지정할 수 있습니다.

## **참조로 슬라이드 제거**

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 통해 제거하려는 슬라이드의 참조를 가져옵니다.
1. 프레젠테이션에서 해당 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다. 

This JavaScript code shows you how to remove a slide through its reference:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 슬라이드 컬렉션에서 인덱스를 통해 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 참조를 통해 슬라이드를 제거합니다
    pres.getSlides().remove(slide);
    // 수정된 프레젠테이션을 저장합니다
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **인덱스로 슬라이드 제거**

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. 인덱스 위치를 통해 프레젠테이션에서 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다. 

This JavaScript code shows you how to remove a slide through its index:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 슬라이드 인덱스를 통해 슬라이드를 제거합니다
    pres.getSlides().removeAt(0);
    // 수정된 프레젠테이션을 저장합니다
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **사용되지 않는 레이아웃 슬라이드 제거**

Aspose.Slides는 원하지 않거나 사용되지 않는 레이아웃 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스의 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) 메서드를 제공합니다. 이 JavaScript 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **사용되지 않는 마스터 슬라이드 제거**

Aspose.Slides는 원하지 않거나 사용되지 않는 마스터 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/) 클래스의 [removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) 메서드를 제공합니다. 이 JavaScript 코드는 PowerPoint 프레젠테이션에서 마스터 슬라이드를 제거하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**슬라이드를 삭제한 후 슬라이드 인덱스는 어떻게 되나요?**

삭제 후, [collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidecollection/)은 다시 인덱싱됩니다: 이후 모든 슬라이드가 한 위치씩 왼쪽으로 이동하므로 이전 인덱스 번호는 더 이상 유효하지 않게 됩니다. 안정적인 참조가 필요하면 인덱스 대신 각 슬라이드의 영구 ID를 사용하십시오.

**슬라이드 ID는 인덱스와 다르고, 인접한 슬라이드가 삭제될 때 변경되나요?**

예. 인덱스는 슬라이드의 위치이며 슬라이드가 추가되거나 제거될 때 변경됩니다. 슬라이드 ID는 영구 식별자로, 다른 슬라이드가 삭제되어도 변하지 않습니다.

**슬라이드를 삭제하면 섹션에 어떤 영향을 미칩니까?**

슬라이드가 섹션에 속해 있었다면, 해당 섹션은 슬라이드 수가 하나 줄어듭니다. 섹션 구조는 유지되며, 섹션이 비게 되면 필요에 따라 [remove or reorganize sections](/slides/ko/nodejs-java/slide-section/) 를 할 수 있습니다.

**슬라이드가 삭제될 때 해당 슬라이드에 첨부된 노트와 댓글은 어떻게 되나요?**

[Notes](/slides/ko/nodejs-java/presentation-notes/)와 [comments](/slides/ko/nodejs-java/presentation-comments/)는 해당 슬라이드에 연결되어 있으며 슬라이드와 함께 삭제됩니다. 다른 슬라이드의 내용은 영향을 받지 않습니다.

**슬라이드 삭제와 사용되지 않은 레이아웃/마스터 정리의 차이점은 무엇인가요?**

삭제는 데크에서 특정 일반 슬라이드를 제거합니다. 사용되지 않은 레이아웃/마스터를 정리하면 아무도 참조하지 않는 레이아웃 또는 마스터 슬라이드를 제거하여 파일 크기를 줄이지만 남은 슬라이드 내용은 변경되지 않습니다. 이러한 작업은 상호 보완적이며 일반적으로 먼저 삭제하고, 그 다음에 정리합니다.