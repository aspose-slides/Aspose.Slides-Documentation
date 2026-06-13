---
title: Android에서 프레젠테이션 슬라이드 제거
linktitle: 슬라이드 제거
type: docs
weight: 30
url: /ko/androidjava/remove-slide-from-presentation/
keywords:
- 슬라이드 제거
- 슬라이드 삭제
- 사용되지 않은 슬라이드 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 손쉽게 제거하세요. 명확한 Java 코드 예제를 제공받아 작업 흐름을 향상시킵니다."
---
## **소개**

슬라이드(또는 그 내용)가 중복되면 삭제할 수 있습니다. Aspose.Slides는 프레젠테이션의 모든 슬라이드를 저장하는 저장소인 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidecollection/)을 캡슐화하는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 제공합니다. 알려진 [ISlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) 객체에 대한 포인터(참조 또는 인덱스)를 사용하여 제거하려는 슬라이드를 지정할 수 있습니다.

## **참조로 슬라이드 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 제거하려는 슬라이드에 대한 참조를 ID 또는 인덱스로 가져옵니다.
1. 프레젠테이션에서 해당 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 참조를 통해 슬라이드를 제거하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    // 슬라이드 컬렉션의 인덱스를 통해 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 참조를 통해 슬라이드를 제거합니다
    pres.getSlides().remove(slide);
    
    // 수정된 프레젠테이션을 저장합니다
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **인덱스로 슬라이드 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스 위치를 사용하여 프레젠테이션에서 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 인덱스를 사용하여 슬라이드를 제거하는 방법을 보여줍니다:

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

## **사용되지 않는 레이아웃 슬라이드 제거**

Aspose.Slides는 원하지 않거나 사용되지 않는 레이아웃 슬라이드를 삭제할 수 있는 [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) 클래스의 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 메서드를 제공합니다. 다음 Java 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용되지 않는 마스터 슬라이드 제거**

Aspose.Slides는 원하지 않거나 사용되지 않는 마스터 슬라이드를 삭제할 수 있는 [Compress](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/) 클래스의 [removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 메서드를 제공합니다. 다음 Java 코드는 PowerPoint 프레젠테이션에서 마스터 슬라이드를 제거하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **자주 묻는 질문**

**슬라이드를 삭제한 후 슬라이드 인덱스는 어떻게 됩니까?**

삭제 후, [collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/)은 재인덱싱됩니다: 뒤따르는 모든 슬라이드가 한 위치씩 왼쪽으로 이동하므로 이전 인덱스 번호는 더 이상 유효하지 않게 됩니다. 안정적인 참조가 필요하다면 인덱스 대신 각 슬라이드의 영구 ID를 사용하십시오.

**슬라이드 ID와 인덱스는 다르며, 인접한 슬라이드가 삭제될 때 변경되나요?**

예. 인덱스는 슬라이드의 위치를 나타내며 슬라이드가 추가되거나 제거될 때 변경됩니다. 슬라이드 ID는 영구 식별자로, 다른 슬라이드가 삭제되더라도 변경되지 않습니다.

**슬라이드 삭제가 슬라이드 섹션에 어떤 영향을 줍니까?**

슬라이드가 섹션에 속해 있었다면, 그 섹션은 하나의 슬라이드가 줄어들게 됩니다. 섹션 구조는 유지되며, 섹션이 비게 되면 필요에 따라 [섹션을 제거하거나 재구성](/slides/ko/androidjava/slide-section/)할 수 있습니다.

**슬라이드가 삭제될 때 해당 슬라이드에 부착된 노트와 댓글은 어떻게 됩니까?**

[Notes](/slides/ko/androidjava/presentation-notes/)와 [comments](/slides/ko/androidjava/presentation-comments/)는 해당 슬라이드에 연결되어 있으며, 슬라이드가 삭제될 때 함께 제거됩니다. 다른 슬라이드의 내용은 영향을 받지 않습니다.

**슬라이드 삭제와 사용되지 않는 레이아웃/마스터 정리의 차이점은 무엇입니까?**

삭제는 프레젠테이션에서 특정 일반 슬라이드를 제거합니다. 사용되지 않는 레이아웃/마스터를 정리하면 아무것도 참조하지 않는 레이아웃 슬라이드나 마스터 슬라이드가 제거되어 파일 크기가 감소하지만 나머지 슬라이드 내용은 변경되지 않습니다. 이러한 작업은 보완적이며 일반적으로 먼저 슬라이드를 삭제한 다음 정리를 수행합니다.