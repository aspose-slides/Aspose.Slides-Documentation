---
title: ActiveX
type: docs
weight: 200
url: /zh/cpp/examples/elements/activex/
keywords:
- 代码示例
- ActiveX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "查看 Aspose.Slides for C++ 的 ActiveX 示例：在 PPT 和 PPTX 演示文稿中插入、配置和控制 ActiveX 对象，代码清晰明了。"
---
本文演示如何在演示文稿中使用 **Aspose.Slides for C++** 添加、访问、移除和配置 ActiveX 控件。

## **添加 ActiveX 控件**

插入一个新的 ActiveX 控件，并可选地设置其属性。

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 添加一个新的 ActiveX 控件。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // 可选地设置一些属性。
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 访问第一个 ActiveX 控件。
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **移除 ActiveX 控件**

从幻灯片中删除现有的 ActiveX 控件。

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 移除第一个 ActiveX 控件。
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **设置 ActiveX 属性**

添加控件并配置多个 ActiveX 属性。

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 添加 Windows Media Player 控件并配置属性。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```