---
title: .NET에서 프레젠테이션 슬라이드 비교
linktitle: 슬라이드 비교
type: docs
weight: 50
url: /ko/net/compare-slides/
keywords:
- 슬라이드 비교
- 슬라이드 비교
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 프로그래밍 방식으로 비교합니다. 코드에서 슬라이드 차이를 빠르게 식별합니다."
---
## **개요**

Aspose.Slides는 `IBaseSlide` 인터페이스와 `BaseSlide` 클래스에서 제공하는 `Equals` 메서드를 사용하여 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드를 비교할 수 있습니다. 이 메서드는 비교된 슬라이드가 구조와 정적 콘텐츠가 동일할 때 `true`를 반환합니다.

## **두 슬라이드 비교**

`Equals` 메서드가 [IBaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide) 인터페이스와 [BaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslide) 클래스에 추가되었습니다. 이 메서드는 구조와 정적 콘텐츠가 동일한 슬라이드/레이아웃 및 슬라이드/마스터 슬라이드에 대해 true를 반환합니다.

두 슬라이드는 모든 도형, 스타일, 텍스트, 애니메이션 및 기타 설정 등이 모두 동일할 때 동일하다고 판단됩니다. 비교에서는 SlideId와 같은 고유 식별자 값이나 날짜 자리표시자와 같은 동적 콘텐츠는 고려되지 않습니다.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**슬라이드가 숨김 상태인 것이 슬라이드 자체 비교에 영향을 줍니까?**

[Hidden status](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/hidden/) 은 프레젠테이션/재생 수준의 속성이며 시각적 콘텐츠가 아닙니다. 두 특정 슬라이드의 동일성은 그들의 구조와 정적 콘텐츠에 의해 결정되며, 슬라이드가 숨김 상태라는 사실만으로 슬라이드가 다르다고 판단되지 않습니다.

**하이퍼링크와 해당 매개변수가 고려됩니까?**

네. 링크는 슬라이드의 정적 콘텐츠의 일부입니다. URL이나 하이퍼링크 동작이 다르면 일반적으로 정적 콘텐츠 차이로 간주됩니다.

**차트가 외부 Excel 파일을 참조하는 경우 해당 파일의 내용이 고려됩니까?**

아니요. 비교는 슬라이드 자체를 기준으로 수행됩니다. 외부 데이터 소스는 일반적으로 비교 시 읽히지 않으며, 슬라이드의 구조와 정적 상태에 존재하는 내용만 고려됩니다.