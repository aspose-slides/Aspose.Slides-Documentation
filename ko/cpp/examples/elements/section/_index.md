---
title: 섹션
type: docs
weight: 90
url: /ko/cpp/examples/elements/section/
keywords:
- 코드 예제
- 섹션
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 섹션을 관리합니다: C++ 예제를 사용하여 PPT, PPTX 및 ODP용 슬라이드를 생성, 이름 바꾸기, 순서 변경 및 그룹화."
---
프레젠테이션 섹션을 관리하는 예제—프로그래밍 방식으로 섹션을 추가, 액세스, 제거 및 이름 바꾸기를 **Aspose.Slides for C++**를 사용하여 수행합니다.

## **섹션 추가**

특정 슬라이드에서 시작하는 섹션을 생성합니다.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 섹션 시작을 표시하는 슬라이드를 지정합니다.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **섹션 접근**

프레젠테이션에서 섹션 정보를 읽어옵니다.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // 인덱스로 섹션에 접근합니다.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // 첫 번째 섹션을 제거합니다.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```