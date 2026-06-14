---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/cpp/examples/elements/vba-macro/
keywords:
- 程式碼範例
- VBA
- 巨集
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自動化簡報：在 PPT、PPTX 與 ODP 中建立、執行、匯入與保護 VBA 巨集，提供清晰的 C++ 範例。"
---
本文示範如何使用 **Aspose.Slides for C++** 新增、存取和移除 VBA 巨集。

## **新增 VBA 巨集**

建立一個包含 VBA 專案與簡易巨集模組的簡報。

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

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

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

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

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