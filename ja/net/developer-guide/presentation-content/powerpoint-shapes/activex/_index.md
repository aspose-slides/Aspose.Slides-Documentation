---
title: ActiveX
type: docs
weight: 80
url: /ja/net/activex/
keywords: "ActiveX, ActiveX コントロール, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーション内の ActiveX コントロールを管理します"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for .NET を使用すると ActiveX コントロールを管理できますが、管理はやや複雑で通常のプレゼンテーション シェイプとは異なります。Aspose.Slides for .NET 6.9.0 以降、コンポーネントは ActiveX コントロールの管理をサポートしています。現在、プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、そのさまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部でもなく、別個の IControlCollection に属しています。この記事ではそれらの操作方法を示します。

## **ActiveX コントロールの変更**
スライド上のテキスト ボックスやシンプルなコマンド ボタンなどのシンプルな ActiveX コントロールを管理するには、次の手順を実行します。

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションをロードします。
1. インデックスでスライド参照を取得します。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、フレーム位置など、TextBox1 ActiveX コントロールのさまざまなプロパティを変更します。
1. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコード スニペットは、プレゼンテーション スライド上の ActiveX コントロールを下記のように更新します。
```c#
// ActiveX コントロール付きプレゼンテーションにアクセス
Presentation presentation = new Presentation("ActiveX.pptm");

// プレゼンテーションの最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// テキストボックスのテキストを変更
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 代替画像を変更。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、場合によっては画像を変更しなくても問題ない。

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

// ActiveX フレームを 100 ポイント下に移動
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// 編集された ActiveX コントロール付きプレゼンテーションを保存
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);

// コントロールを削除中
slide.Controls.Clear();

// クリアされた ActiveX コントロール付きプレゼンテーションを保存
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveX メディア プレーヤー コントロールの追加**
ActiveX メディア プレーヤー コントロールを追加するには、以下の手順を実行してください。

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプル プレゼンテーションをロードします。
1. 対象となる Presentation クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. テンプレート プレゼンテーションの Media Player ActiveX コントロールが含まれるスライドを対象の Presentation にクローンします。
1. 対象の Presentation でクローンされたスライドにアクセスします。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオ パスを設定します。
1. プレゼンテーションを PPTX ファイルに保存します。
```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation presentation = new Presentation("template.pptx");

// 空のプレゼンテーションインスタンスを作成
Presentation newPresentation = new Presentation();

// デフォルトのスライドを削除
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX コントロールがあるスライドをクローン
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX コントロールにアクセスし、ビデオ パスを設定
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// プレゼンテーションを保存
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **よくある質問**

**Python ランタイムで実行できない場合でも、Aspose.Slides は ActiveX コントロールを読み取り再保存時に保持しますか？**  
はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行しなくても保持されます。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどのように異なりますか？**  
ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキスト ボックス、メディア プレーヤー）であり、[OLE](/slides/ja/net/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。これらは保存方法や取り扱いが異なり、プロパティ モデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX イベントや VBA マクロは機能しますか？**  
Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロはセキュリティが許可する場合に限り、Windows の PowerPoint 内でのみ実行されます。このライブラリは VBA を実行しません。