---
title: ActiveX
type: docs
weight: 200
url: /ja/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX を追加
- ActiveX にアクセス
- ActiveX を削除
- ActiveX のプロパティ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の ActiveX の例をご覧ください: PPT および PPTX プレゼンテーションで ActiveX オブジェクトを挿入、構成、制御する方法を、明確な C# コードで示します。"
---
この記事では、**Aspose.Slides for .NET** を使用してプレゼンテーションに ActiveX コントロールを追加、アクセス、削除、構成する方法を示します。

## **ActiveX コントロールの追加**

新しい ActiveX コントロールを挿入し、必要に応じてプロパティを設定します。

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 新しい ActiveX コントロールを追加します。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // 必要に応じていくつかのプロパティを設定します。
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を読み取ります。

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // 最初の ActiveX コントロールにアクセスします。
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
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // 最初の ActiveX コントロールを削除します。
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX プロパティの設定**

コントロールを追加し、複数の ActiveX プロパティを構成します。

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // CommandButton を追加し、プロパティを構成します。
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```