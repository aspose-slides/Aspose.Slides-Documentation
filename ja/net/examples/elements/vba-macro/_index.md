---
title: Vbaマクロ
type: docs
weight: 150
url: /ja/net/examples/elements/vba-macro/
keywords:
- VBAマクロの例
- VBAマクロの追加
- VBAマクロへのアクセス
- VBAマクロの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で VBA マクロを操作します：プロジェクトやモジュールの追加・編集、マクロへの署名または削除、そして PPT、PPTX、ODP 形式でプレゼンテーションを保存します。"
---

**Aspose.Slides for .NET** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

## Add a VBA Macro
VBA プロジェクトとシンプルなマクロ モジュールを含むプレゼンテーションを作成します。
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## Access a VBA Macro
VBA プロジェクトから最初のモジュールを取得します。
```csharp
static void Access_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = pres.VbaProject.Modules[0];
}
```


## Remove a VBA Macro
VBA プロジェクトからモジュールを削除します。
```csharp
static void Remove_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    pres.VbaProject.Modules.Remove(module);
}
```
