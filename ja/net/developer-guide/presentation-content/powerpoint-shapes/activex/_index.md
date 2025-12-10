---
title: .NET でのプレゼンテーションにおける ActiveX コントロールの管理
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
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が ActiveX を活用して PowerPoint プレゼンテーションを自動化および強化する方法を学び、開発者にスライドの強力な制御を提供します。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for .NET は ActiveX コントロールの管理を可能にしますが、管理はやや複雑で通常のスライドシェイプとは異なります。Aspose.Slides for .NET 6.9.0 以降、このコンポーネントは ActiveX コントロールの管理をサポートしています。現在、プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、そのさまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部ではなく、別個の IControlCollection に属しています。本記事ではそれらの操作方法を示します。

## **ActiveX コントロールの変更**
スライド上のテキストボックスやシンプルなコマンドボタンなどの簡単な ActiveX コントロールを管理するには、次の手順を実行します：

1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションを読み込みます。
1. インデックスでスライドの参照を取得します。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォントサイズ、フレーム位置など、TextBox1 ActiveX コントロールのさまざまなプロパティを変更します。
1. CommandButton1 と呼ばれる 2 番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下のコードスニペットは、プレゼンテーションのスライド上の ActiveX コントロールを下図のように更新します。
```c#
// ActiveX コントロールを使用したプレゼンテーションへのアクセス
Presentation presentation = new Presentation("ActiveX.pptm");

// プレゼンテーションの最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// テキストボックスのテキストを変更
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 代替画像を変更します。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、画像を変更せずにそのままにしておくことも時には問題ありません。

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

// 編集した ActiveX コントロール付きでプレゼンテーションを保存
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// コントロールを削除
slide.Controls.Clear();

// クリアされた ActiveX コントロール付きでプレゼンテーションを保存
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveX メディアプレイヤーコントロールの追加**
ActiveX メディアプレイヤーコントロールを追加するには、次の手順を実行してください：

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプルプレゼンテーションを読み込みます。
1. 対象の Presentation クラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. テンプレートプレゼンテーションの Media Player ActiveX コントロールが含まれるスライドを対象の Presentation にクローンします。
1. 対象の Presentation でクローンされたスライドにアクセスします。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。
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

**Aspose.Slides は .NET ランタイムで実行できない場合でも、読み取りおよび再保存時に ActiveX コントロールを保持しますか？**

はい。Aspose.Slides はこれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**ActiveX コントロールはプレゼンテーション内の OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキストボックス、メディアプレイヤー）です。一方、[OLE](/slides/ja/net/manage-ole/) は埋め込みアプリケーションオブジェクト（例: Excel ワークシート）を指します。これらは保存方法や処理方法が異なり、プロパティモデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX イベントや VBA マクロは機能しますか？**

Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows 上の PowerPoint で、セキュリティが許可された場合にのみ実行されます。このライブラリは VBA を実行しません。