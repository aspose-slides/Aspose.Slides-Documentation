---
title: Macro VBA
type: docs
weight: 150
url: /vi/cpp/examples/elements/vba-macro/
keywords:
- ví dụ mã
- VBA
- macro
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tự động hoá các bài thuyết trình với Aspose.Slides cho C++: tạo, chạy, nhập và bảo vệ các macro VBA trong PPT, PPTX và ODP bằng các ví dụ C++ rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập và xóa các macro VBA bằng **Aspose.Slides for C++**.

## **Thêm một macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Truy cập một macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Xóa một macro VBA**

Xóa một mô-đun khỏi dự án VBA.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```