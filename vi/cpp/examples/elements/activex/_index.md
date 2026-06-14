---
title: ActiveX
type: docs
weight: 200
url: /vi/cpp/examples/elements/activex/
keywords:
- ví dụ mã
- ActiveX
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Xem các ví dụ ActiveX của Aspose.Slides for C++: chèn, cấu hình và điều khiển các đối tượng ActiveX trong các bản trình chiếu PPT và PPTX với mã C++ rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản trình chiếu bằng cách sử dụng **Aspose.Slides for C++**.

## **Thêm một điều khiển ActiveX**

Chèn một điều khiển ActiveX mới và tùy chọn thiết lập các thuộc tính của nó.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một điều khiển ActiveX mới.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Tùy chọn thiết lập một số thuộc tính.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Truy cập một điều khiển ActiveX**

Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Truy cập điều khiển ActiveX đầu tiên.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Xóa một điều khiển ActiveX**

Xóa một điều khiển ActiveX hiện có khỏi slide.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Xóa điều khiển ActiveX đầu tiên.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Thiết lập thuộc tính ActiveX**

Thêm một điều khiển và cấu hình một số thuộc tính ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một điều khiển Windows Media Player và cấu hình các thuộc tính.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```