---
title: プレースホルダーの管理
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords: "プレースホルダー, プレースホルダー テキスト, プロンプト テキスト, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションのプレースホルダーテキストとプロンプトテキストを変更します"
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for .NET](/slides/ja/net/)を使用すると、プレゼンテーションのスライド上のプレースホルダーを見つけて修正できます。Aspose.Slidesを使用すると、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。標準のMicrosoft PowerPointアプリでそのようなプレゼンテーションを作成できます。

これが、そのプレゼンテーションのプレースホルダー内のテキストを置き換えるためのAspose.Slidesの使用方法です：

1. [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライドの参照を取得します。
3. シェイプを繰り返してプレースホルダーを見つけます。
4. プレースホルダーシェイプを[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/)を使用してテキストを変更します。
5. 修正されたプレゼンテーションを保存します。

このC#コードは、プレースホルダー内のテキストを変更する方法を示しています：

```c#
// プレゼンテーションクラスをインスタンス化
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    // プレースホルダーを見つけるためにシェイプを繰り返す
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 各プレースホルダーのテキストを変更
            ((IAutoShape)shp).TextFrame.Text = "これはプレースホルダーです";
        }

    // プレゼンテーションをディスクに保存
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **プレースホルダーのプロンプトテキストを設定する**
標準およびプリビルドのレイアウトには、***タイトルを追加するにはクリック***や***サブタイトルを追加するにはクリック***のようなプレースホルダープロンプトテキストが含まれています。Aspose.Slidesを使用すると、プレースホルダーレイアウトに好みのプロンプトテキストを挿入できます。

このC#コードは、プレースホルダー内のプロンプトテキストを設定する方法を示しています：

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // スライドを繰り返す
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPointは「タイトルを追加するにはクリック」と表示
            {
                text = "タイトルを追加";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // サブタイトルを追加
            {
                text = "サブタイトルを追加";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"テキストを含むプレースホルダー: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **プレースホルダーの画像の透過性を設定する**

Aspose.Slidesを使用すると、テキストプレースホルダー内の背景画像の透過性を設定できます。このようなフレーム内の画像の透過性を調整することで、テキストや画像が際立つようにできます（テキストと画像の色に応じて）。

このC#コードは、シェイプ内の画像背景の透過性を設定する方法を示しています：

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```