---
title: ActiveX
type: docs
weight: 200
url: /ja/net/examples/elements/activex/
keywords:
- ActiveX の例
- ActiveX コントロール
- ActiveX を追加
- ActiveX にアクセス
- ActiveX を削除
- ActiveX プロパティ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用して PowerPoint プレゼンテーションの ActiveX コントロールを検索、編集、削除し、プロパティを更新する方法を学びます。"
---

**Aspose.Slides for .NET** を使用して、プレゼンテーションに ActiveX コントロールを追加、アクセス、削除、および構成する方法を示します。

## **ActiveX コントロールの追加**

新しい ActiveX コントロールを挿入し、必要に応じてプロパティを設定します。
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 新しい ActiveX コントロール (TextBox) を追加
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 任意でいくつかのプロパティを設定
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を読み取ります。
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // 最初の ActiveX コントロールにアクセス
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```


## **ActiveX コントロールの削除**

スライドから既存の ActiveX コントロールを削除します。
```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 最初の ActiveX コントロールを削除
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## **ActiveX プロパティの設定**

コントロールを追加し、複数の ActiveX プロパティを構成します。
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // CommandButton を追加し、プロパティを設定
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
