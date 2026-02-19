---
title: VBA 宏
type: docs
weight: 150
url: /zh/cpp/examples/elements/vba-macro/
keywords:
- 代码示例
- VBA
- 宏
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自动化演示文稿：创建、运行、导入并保护 PPT、PPTX 和 ODP 中的 VBA 宏，提供清晰的 C++ 示例。"
---
本文演示了如何使用 **Aspose.Slides for C++** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和一个简单宏模块的演示文稿。

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

## **访问 VBA 宏**

从 VBA 项目中检索第一个模块。

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

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

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