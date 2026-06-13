---
title: ".NET에서 프레젠테이션 슬라이드 제거"
linktitle: "슬라이드 제거"
type: docs
weight: 30
url: /ko/net/remove-slide-from-presentation/
keywords:
- 슬라이드 제거
- 슬라이드 삭제
- 사용되지 않는 슬라이드 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 손쉽게 제거합니다. 명확한 C# 코드 예제를 제공하여 작업 흐름을 향상시킵니다."
---
## **소개**

슬라이드(또는 해당 슬라이드의 내용)가 중복되면 삭제할 수 있습니다. Aspose.Slides는 프레젠테이션의 모든 슬라이드를 저장하는 저장소인 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection)를 캡슐화하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 제공합니다. 알려진 [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/) 객체에 대한 포인터(참조 또는 인덱스)를 사용하여 제거하려는 슬라이드를 지정할 수 있습니다. 

## **참조로 슬라이드 삭제**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 통해 삭제하려는 슬라이드의 참조를 가져옵니다.
1. 프레젠테이션에서 해당 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 참조를 사용하여 슬라이드를 삭제하는 방법을 보여줍니다:

```c#
// Presentation 객체를 인스턴스화하여 프레젠테이션 파일을 나타냅니다
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // 슬라이드 컬렉션의 인덱스를 통해 슬라이드에 접근합니다
    ISlide slide = pres.Slides[0];

    // 슬라이드 참조를 통해 슬라이드를 제거합니다
    pres.Slides.Remove(slide);

    // 수정된 프레젠테이션을 저장합니다
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **인덱스로 슬라이드 삭제**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스 위치를 통해 프레젠테이션에서 슬라이드를 삭제합니다.
1. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 인덱스를 사용하여 슬라이드를 삭제하는 방법을 보여줍니다:

```c#
// Presentation 객체를 인스턴스화하여 프레젠테이션 파일을 나타냅니다
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // 슬라이드 인덱스를 통해 슬라이드를 제거합니다
    pres.Slides.RemoveAt(0);

    // 수정된 프레젠테이션을 저장합니다
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **사용되지 않는 레이아웃 슬라이드 삭제**

Aspose.Slides는 원치 않거나 사용되지 않는 레이아웃 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 클래스의 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 메서드를 제공합니다. 다음 C# 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 삭제하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **사용되지 않는 마스터 슬라이드 삭제**

Aspose.Slides는 원치 않거나 사용되지 않는 마스터 슬라이드를 삭제할 수 있도록 [Compress](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/) 클래스의 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 메서드를 제공합니다. 다음 C# 코드는 PowerPoint 프레젠테이션에서 마스터 슬라이드를 삭제하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**슬라이드를 삭제한 후 슬라이드 인덱스는 어떻게 됩니까?**

삭제 후, [collection](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/)은 다시 인덱싱됩니다: 이후 모든 슬라이드가 한 위치씩 왼쪽으로 이동하므로 이전 인덱스 번호는 더 이상 유효하지 않게 됩니다. 안정적인 참조가 필요하면 인덱스 대신 각 슬라이드의 영구 ID를 사용하십시오.

**슬라이드 ID와 인덱스는 다른가요? 그리고 인접 슬라이드가 삭제될 때 변경되나요?**

예합니다. 인덱스는 슬라이드의 위치를 나타내며 슬라이드가 추가되거나 제거될 때 변경됩니다. 슬라이드 ID는 영구 식별자로, 다른 슬라이드가 삭제되어도 변하지 않습니다.

**슬라이드 삭제가 슬라이드 섹션에 어떤 영향을 줍니까?**

슬라이드가 섹션에 속해 있었다면 해당 섹션은 슬라이드 수가 하나 줄어듭니다. 섹션 구조는 그대로 유지되며, 섹션이 비게 되면 필요에 따라 [섹션을 제거하거나 재구성](/slides/ko/net/slide-section/)할 수 있습니다.

**슬라이드를 삭제하면 해당 슬라이드에 연결된 노트와 댓글은 어떻게 됩니까?**

[Notes](/slides/ko/net/presentation-notes/)와 [comments](/slides/ko/net/presentation-comments/)는 해당 슬라이드에 연결되어 있으므로 슬라이드와 함께 삭제됩니다. 다른 슬라이드의 내용은 영향을 받지 않습니다.

**슬라이드 삭제와 사용되지 않는 레이아웃/마스터 정리의 차이는 무엇입니까?**

삭제는 데크에서 특정 일반 슬라이드를 제거합니다. 사용되지 않는 레이아웃/마스터 정리는 아무도 참조하지 않는 레이아웃 또는 마스터 슬라이드를 제거하여 파일 크기를 줄이며 나머지 슬라이드 내용은 변경되지 않게 합니다. 이 두 작업은 보완적이며, 일반적으로 먼저 삭제하고 그 다음 정리합니다.