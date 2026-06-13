---
title: Java에서 프레젠테이션 슬라이드 제거
linktitle: 슬라이드 제거
type: docs
weight: 30
url: /ko/java/remove-slide-from-presentation/
keywords:
- 슬라이드 제거
- 슬라이드 삭제
- 사용되지 않는 슬라이드 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 손쉽게 제거하십시오. 명확한 코드 예제를 제공하고 작업 흐름을 향상시킵니다."
---
## **소개**

슬라이드(또는 그 내용)가 중복되면 삭제할 수 있습니다. Aspose.Slides는 프레젠테이션의 모든 슬라이드를 저장하는 저장소인 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidecollection/)을 캡슐화하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 제공합니다. 알려진 [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/) 객체에 대한 포인터(참조 또는 인덱스)를 사용하여 삭제하려는 슬라이드를 지정할 수 있습니다.

## **참조로 슬라이드 삭제**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 삭제하려는 슬라이드의 ID 또는 인덱스를 통해 해당 슬라이드에 대한 참조를 가져옵니다.
1. 프레젠테이션에서 해당 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    // 슬라이드 컬렉션에서 인덱스로 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 참조를 사용하여 슬라이드를 제거합니다
    pres.getSlides().remove(slide);
    
    // 수정된 프레젠테이션을 저장합니다
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **인덱스로 슬라이드 삭제**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스 위치를 통해 프레젠테이션에서 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    // 슬라이드 인덱스를 통해 슬라이드를 제거합니다
    pres.getSlides().removeAt(0);
    
    // 수정된 프레젠테이션을 저장합니다
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **사용되지 않는 레이아웃 슬라이드 삭제**

Aspose.Slides는 원하지 않거나 사용되지 않는 레이아웃 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/) 클래스의 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 메서드를 제공합니다. 이 Java 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용되지 않는 마스터 슬라이드 삭제**

Aspose.Slides는 원하지 않거나 사용되지 않는 마스터 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/) 클래스의 [removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 메서드를 제공합니다. 이 Java 코드는 PowerPoint 프레젠테이션에서 마스터 슬라이드를 제거하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **FAQ**

**슬라이드를 삭제한 후 슬라이드 인덱스는 어떻게 되나요?**

삭제가 이루어지면 [collection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/)이 다시 인덱싱됩니다. 뒤에 있는 모든 슬라이드가 한 위치씩 왼쪽으로 이동하므로 이전 인덱스 번호는 더 이상 유효하지 않게 됩니다. 안정적인 참조가 필요하면 인덱스 대신 각 슬라이드의 지속 ID를 사용하십시오.

**슬라이드 ID와 인덱스는 다르며, 인접 슬라이드가 삭제될 때 변경되나요?**

예. 인덱스는 슬라이드의 위치를 나타내며 슬라이드가 추가되거나 삭제될 때 변경됩니다. 슬라이드 ID는 지속적인 식별자로, 다른 슬라이드가 삭제되어도 변하지 않습니다.

**슬라이드 삭제가 슬라이드 섹션에 어떤 영향을 줍니까?**

슬라이드가 섹션에 속해 있었다면 해당 섹션은 슬라이드가 하나 줄어들게 됩니다. 섹션 구조는 그대로 유지되며, 섹션이 비게 되면 필요에 따라 [remove or reorganize sections](/slides/ko/java/slide-section/)를 수행할 수 있습니다.

**슬라이드가 삭제될 때 해당 슬라이드에 연결된 노트와 댓글은 어떻게 되나요?**

[Notes](/slides/ko/java/presentation-notes/)와 [comments](/slides/ko/java/presentation-comments/)은 해당 슬라이드에 연결되어 있으므로 슬라이드와 함께 삭제됩니다. 다른 슬라이드의 내용은 영향을 받지 않습니다.

**슬라이드 삭제와 사용되지 않은 레이아웃/마스터 정리의 차이점은 무엇인가요?**

삭제는 데크에서 특정 일반 슬라이드를 제거합니다. 사용되지 않은 레이아웃/마스터 정리는 아무 것도 참조하지 않는 레이아웃 슬라이드나 마스터 슬라이드를 제거하여 파일 크기를 줄이되 나머지 슬라이드 내용은 변경하지 않습니다. 두 작업은 보완 관계에 있으며 일반적으로 먼저 삭제하고 그 다음 정리합니다.