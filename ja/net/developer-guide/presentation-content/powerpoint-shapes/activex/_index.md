---
title: .NET でプレゼンテーションの ActiveX コントロールを管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX を管理
- ActiveX を追加
- ActiveX を変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化・強化し、開発者にスライドの強力な制御を提供する方法を学びます。"
---

プレゼンテーションで ActiveX コントロールが使用されます。Aspose.Slides for .NET を使用すると ActiveX コントロールを管理できますが、管理はやや複雑で通常のプレゼンテーション シェイプとは異なります。Aspose.Slides for .NET 6.9.0 以降、このコンポーネントは ActiveX コントロールの管理をサポートしています。現在、プレゼンテーションに追加済みの ActiveX コントロールにアクセスし、さまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部ではなく、別個の IControlCollection に属していることに注意してください。この記事ではそれらの操作方法を示します。

## **ActiveX コントロールの変更**
スライド上のテキストボックスやシンプルなコマンドボタンなど、シンプルな ActiveX コントロールを管理する手順:

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。  
2. インデックスでスライド参照を取得します。  
3. IControlCollection にアクセスしてスライド内の ActiveX コントロールにアクセスします。  
4. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。  
5. テキスト、フォント、フォント高さ、フレーム位置など、TextBox1 ActiveX コントロールのさまざまなプロパティを変更します。  
6. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。  
7. ボタンのキャプション、フォント、位置を変更します。  
8. ActiveX コントロールのフレーム位置をシフトします。  
9. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコード スニペットは、プレゼンテーション スライドの ActiveX コントロールを下記のように更新します。
```c#
// Accessing the presentation with ActiveX controls
Presentation presentation = new Presentation("ActiveX.pptm");

// Accessing the first slide in presentation
ISlide slide = presentation.Slides[0];

// changing TextBox text
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // changing substitute image. Powerpoint will replace this image during activeX activation, so sometime it's OK to leave image unchanged.
    // 代替画像を変更します。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、画像を変更しないままにしても問題ないことがあります。

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

// changing Button caption
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // changing substitute
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
// 編集した ActiveX コントロール付きのプレゼンテーションを保存
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Now removing controls
// コントロールを削除しています
slide.Controls.Clear();

// Saving the presentation with cleared ActiveX controls
// ActiveX コントロールをクリアしたプレゼンテーションを保存
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveX メディア プレーヤー コントロールの追加**
ActiveX Media Player コントロールを追加するには、次の手順を実行してください。

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプル プレゼンテーションをロードします。  
2. 対象となる Presentation クラスのインスタンスを作成し、空のプレゼンテーション インスタンスを生成します。  
3. テンプレート プレゼンテーションの Media Player ActiveX コントロールを含むスライドを対象の Presentation にクローンします。  
4. 対象の Presentation でクローンされたスライドにアクセスします。  
5. IControlCollection にアクセスしてスライド内の ActiveX コントロールにアクセスします。  
6. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオ パスを設定します。  
7. プレゼンテーションを PPTX ファイルに保存します。
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation("template.pptx");

// 空のプレゼンテーション インスタンスを作成
Presentation newPresentation = new Presentation();

// デフォルトのスライドを削除
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX コントロールを含むスライドをクローン
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX コントロールにアクセスし、ビデオパスを設定
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// プレゼンテーションを保存
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Aspose.Slides は .NET ランタイムで実行できなくても、読み取りおよび再保存時に ActiveX コントロールを保持しますか？**  
はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はなく、保持されます。

**ActiveX コントロールはプレゼンテーションの OLE オブジェクトとどう異なりますか？**  
ActiveX コントロールはインタラクティブな管理対象コントロール（ボタン、テキスト ボックス、メディア プレーヤー）です。一方、[OLE](/slides/ja/net/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。これらは保存方法や取り扱いが異なり、プロパティ モデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX イベントや VBA マクロは機能しますか？**  
Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows の PowerPoint 内でセキュリティが許可された場合にのみ実行されます。このライブラリは VBA を実行しません。