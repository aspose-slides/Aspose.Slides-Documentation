---
title: ActiveX
type: docs
weight: 200
url: /ko/cpp/examples/elements/activex/
keywords:
- 코드 예제
- ActiveX
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ActiveX 예제를 확인하십시오: PPT 및 PPTX 프레젠테이션에서 ActiveX 객체를 삽입, 구성 및 제어하는 방법을 명확한 C++ 코드와 함께 제공합니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 프레젠테이션에 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

새 ActiveX 컨트롤을 삽입하고 선택적으로 해당 속성을 설정합니다.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 새 ActiveX 컨트롤을 추가합니다.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // 선택적으로 일부 속성을 설정합니다.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX 컨트롤 액세스**

슬라이드에 있는 첫 번째 ActiveX 컨트롤의 정보를 읽습니다.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 첫 번째 ActiveX 컨트롤에 접근합니다.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 첫 번째 ActiveX 컨트롤을 제거합니다.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX 속성 설정**

컨트롤을 추가하고 여러 ActiveX 속성을 구성합니다.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Windows Media Player 컨트롤을 추가하고 속성을 구성합니다.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```