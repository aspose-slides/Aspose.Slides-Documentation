---
title: .NET でプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化および強化し、開発者にスライドに対する強力な制御を提供する方法を学びます。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for .NET は ActiveX コントロールの管理を可能にしますが、管理はやや複雑で通常のスライド シェイプとは異なります。Aspose.Slides for .NET 6.9.0 以降、このコンポーネントは ActiveX コントロールの管理をサポートしています。現在、プレゼンテーションに既に追加されている ActiveX コントロールにアクセスし、さまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部ではなく、別個の IControlCollection に属していることに注意してください。本記事ではそれらの操作方法を示します。
## **ActiveX コントロールの変更**
スライド上のテキスト ボックスやシンプルなコマンド ボタンなど、シンプルな ActiveX コントロールを管理する手順:

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションを読み込みます。
1. インデックスでスライド参照を取得します。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールを取得します。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. TextBox1 ActiveX コントロールのテキスト、フォント、フォント サイズ、フレーム位置など、さまざまなプロパティを変更します。
1. 2 番目のコントロールである CommandButton1 にアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコード スニペットは、スライド上の ActiveX コントロールを更新する例を示しています。
```c#
// ActiveX コントロールでプレゼンテーションにアクセス
Presentation presentation = new Presentation("ActiveX.pptm");

// プレゼンテーションの最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// TextBox のテキストを変更
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 代替画像を変更。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、画像を変更しないままにしても問題ないことがあります。

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ボタンのキャプションを変更
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // 代替画像を変更
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Moving ActiveX frames 100 points down
 // ActiveX フレームを 100 ポイント下に移動
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Save the presentation with Edited ActiveX Controls
 // 編集された ActiveX コントロール付きでプレゼンテーションを保存
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Now removing controls
 // コントロールを削除中
slide.Controls.Clear();

// Saving the presentation with cleared ActiveX controls
 // クリアされた ActiveX コントロール付きでプレゼンテーションを保存
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```



## **ActiveX メディアプレーヤー コントロールの追加**
ActiveX メディア プレーヤー コントロールを追加するには、次の手順を実行してください。

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプル プレゼンテーションを読み込みます。
1. 対象となる Presentation クラスのインスタンスを作成し、空のプレゼンテーション インスタンスを生成します。
1. テンプレート プレゼンテーション内の Media Player ActiveX コントロールが含まれるスライドを対象の Presentation にクローンします。
1. 対象の Presentation でクローンされたスライドにアクセスします。
1. IControlCollection にアクセスしてスライド内の ActiveX コントロールを取得します。
1. Media Player ActiveX コントロールにアクセスし、プロパティを使用してビデオ パスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。
```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation presentation = new Presentation("template.pptx");

// 空のプレゼンテーション インスタンスを作成
Presentation newPresentation = new Presentation();

// 既定のスライドを削除
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX コントロールを含むスライドをクローン
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX コントロールにアクセスし、ビデオのパスを設定
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// プレゼンテーションを保存
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Python runtime?**

Yes. Aspose.Slides treats them as part of the presentation and can read/modify their properties and frames; executing the controls themselves is not required to preserve them.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX controls are interactive managed controls (buttons, text boxes, media player), whereas [OLE](/slides/ja/net/manage-ole/) refers to embedded application objects (for example, an Excel worksheet). They are stored and handled differently and have different property models.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides preserves the existing markup and metadata; however, events and macros run only inside PowerPoint on Windows when security allows it. The library does not execute VBA.