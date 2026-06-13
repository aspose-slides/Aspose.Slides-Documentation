---
title: 헤더 푸터
type: docs
weight: 220
url: /ko/cpp/examples/elements/header-footer/
keywords:
- 코드 예제
- 헤더
- 푸터
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 슬라이드 헤더와 푸터를 제어합니다: C++ 예제를 통해 PPT, PPTX 및 ODP에 날짜, 슬라이드 번호 및 사용자 지정 텍스트를 추가합니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 바닥글을 추가하고 날짜 및 시간 자리 표시자를 업데이트하는 방법을 보여줍니다.

## **바닥글 추가**
슬라이드의 바닥글 영역에 텍스트를 추가하고 표시되도록 합니다.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **날짜 및 시간 업데이트**
슬라이드의 날짜 및 시간 자리 표시자를 수정합니다.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```