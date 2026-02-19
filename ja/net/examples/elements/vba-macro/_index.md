---
title: VBA マクロ
type: docs
weight: 150
url: /ja/net/examples/elements/vba-macro/
keywords:
- VBA マクロ
- VBA マクロの追加
- VBA マクロへのアクセス
- VBA マクロの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションを自動化します。PPT、PPTX、ODP で VBA マクロを作成、実行、インポート、保護する方法を、明確な C# サンプルで示します。"
---
この記事では、**Aspose.Slides for .NET** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロモジュールを含むプレゼンテーションを作成します。

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **VBA マクロへのアクセス**

VBA プロジェクトから最初のモジュールを取得します。

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```