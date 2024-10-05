---
title: ActiveX
type: docs
weight: 80
url: /net/activex/
keywords: "ActiveX, ActiveXコントロール, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションのActiveXコントロールを管理する"
---

ActiveXコントロールはプレゼンテーションで使用されます。Aspose.Slides for .NETを使用すると、ActiveXコントロールを管理できますが、通常のプレゼンテーションシェイプとは異なり、少しトリッキーです。Aspose.Slides for .NET 6.9.0以降、このコンポーネントはActiveXコントロールの管理をサポートしています。現在、プレゼンテーションに既に追加されたActiveXコントロールにアクセスし、そのさまざまなプロパティを使用して変更または削除できます。ActiveXコントロールはシェイプではなく、プレゼンテーションのIShapeCollectionの一部ではなく、別のIControlCollectionです。この記事では、それらの操作方法を示します。
## **ActiveXコントロールの変更**
スライド上のテキストボックスやシンプルなコマンドボタンのようなシンプルなActiveXコントロールを管理するには：

1. Presentationクラスのインスタンスを作成し、ActiveXコントロールを含むプレゼンテーションをロードします。
1. インデックスによってスライドの参照を取得します。
1. IControlCollectionにアクセスしてスライド内のActiveXコントロールにアクセスします。
1. ControlExオブジェクトを使用してTextBox1 ActiveXコントロールにアクセスします。
1. テキスト、フォント、フォントの高さ、およびフレームの位置を含むTextBox1 ActiveXコントロールのさまざまなプロパティを変更します。
1. CommandButton1という2番目のアクセスコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveXコントロールフレームの位置を移動します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

以下のコードスニペットは、プレゼンテーションスライド上のActiveXコントロールを更新します。

```c#
// ActiveXコントロールを含むプレゼンテーションにアクセス
Presentation presentation = new Presentation("ActiveX.pptm");

// プレゼンテーション内の最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// TextBoxテキストの変更
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "変更されたテキスト";
    control.Properties["Value"] = newText;

    // 代替画像を変更します。PowerPointはActiveXのアクティブ化中にこの画像を置き換えるため、時には画像を変更しないでおくことが適切です。

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
    String newCaption = "メッセージボックス";
    control.Properties["Caption"] = newCaption;

    // 代替を変更
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

// ActiveXフレームを100ポイント下に移動
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// 編集されたActiveXコントロールを含むプレゼンテーションを保存
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// 現在コントロールを削除します
slide.Controls.Clear();

// ActiveXコントロールをクリアしたプレゼンテーションを保存
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveXメディアプレーヤーコントロールの追加**
ActiveXメディアプレーヤーコントロールを追加するには、次の手順を実行します。

1. Presentationクラスのインスタンスを作成し、Media Player ActiveXコントロールを含むサンプルプレゼンテーションをロードします。
1. 対象のPresentationクラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. テンプレートプレゼンテーション内のMedia Player ActiveXコントロールを含むスライドを対象のPresentationにクローンします。
1. 対象のPresentation内のクローンしたスライドにアクセスします。
1. IControlCollectionにアクセスして、スライド内のActiveXコントロールにアクセスします。
1. Media Player ActiveXコントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションをPPTXファイルに保存します。

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation presentation = new Presentation("template.pptx");

// 空のプレゼンテーションインスタンスを作成
Presentation newPresentation = new Presentation();

// デフォルトスライドを削除
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveXコントロールを含むスライドをクローン
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveXコントロールにアクセスし、ビデオパスを設定
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// プレゼンテーションを保存
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```