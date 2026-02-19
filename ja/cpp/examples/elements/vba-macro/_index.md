---
title: VBA マクロ
type: docs
weight: 150
url: /ja/cpp/examples/elements/vba-macro/
keywords:
- コード例
- VBA
- マクロ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションを自動化します。明確な C++ の例を使い、PPT、PPTX、ODP で VBA マクロを作成、実行、インポート、そして保護します。"
---
この記事では、**Aspose.Slides for C++** を使用して VBA マクロを追加、取得、および削除する方法を示します。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロ モジュールを含むプレゼンテーションを作成します。

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

## **VBA マクロの取得**

VBA プロジェクトから最初のモジュールを取得します。

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

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

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