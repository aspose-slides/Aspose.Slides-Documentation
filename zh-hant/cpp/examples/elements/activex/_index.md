---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/cpp/examples/elements/activex/
keywords:
- 程式碼範例
- ActiveX
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "參考 Aspose.Slides for C++ 的 ActiveX 範例：插入、設定及控制 PPT 與 PPTX 簡報中的 ActiveX 物件，並以清晰的 C++ 程式碼示範。"
---
本文示範如何在簡報中使用 **Aspose.Slides for C++** 添加、存取、移除及設定 ActiveX 控制項。

## **新增 ActiveX 控制項**
插入新的 ActiveX 控制項，並可選擇設定其屬性。

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 新增一個 ActiveX 控制項。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // 可選地設定一些屬性。
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **存取 ActiveX 控制項**
從投影片上的第一個 ActiveX 控制項讀取資訊。

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 存取第一個 ActiveX 控制項。
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **移除 ActiveX 控制項**
從投影片中刪除現有的 ActiveX 控制項。

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 移除第一個 ActiveX 控制項。
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **設定 ActiveX 屬性**
新增控制項並設定多個 ActiveX 屬性。

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 新增 Windows Media Player 控制項並設定屬性。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```