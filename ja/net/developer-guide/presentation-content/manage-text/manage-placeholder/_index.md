---
title: ".NET でプレゼンテーションのプレースホルダーを管理する"
linktitle: "プレースホルダーを管理する"
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords:
- "プレースホルダー"
- "テキストプレースホルダー"
- "画像プレースホルダー"
- "チャートプレースホルダー"
- "プロンプトテキスト"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でプレースホルダーを簡単に管理できます。テキストの置換、プロンプトのカスタマイズ、PowerPoint および OpenDocument の画像透過設定が可能です。"
---

## **プレースホルダーのテキストを変更する**
Aspose.Slides for .NET を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索および変更できます。Aspose.Slides を使用すると、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダー内のテキストを置換する手順です:

1. [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスでスライド参照を取得します。
3. 形状を反復処理してプレースホルダーを探します。
4. プレースホルダー形状を [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) に型変換し、[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) を使用してテキストを変更します。
5. 変更したプレゼンテーションを保存します。

This C# code shows how to change the text in a placeholder:
```c#
// Presentation クラスのインスタンス化
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    // プレースホルダーを検索するためにシェイプを反復処理
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 各プレースホルダーのテキストを変更
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // プレゼンテーションをディスクに保存
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** といったプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、好きなプロンプトテキストをプレースホルダーのレイアウトに挿入できます。

This C# code shows you how to set the prompt text in a placeholder:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // スライド内のシェイプを反復処理
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint は「クリックしてタイトルを追加」と表示します
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // サブタイトルを追加します
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **プレースホルダー画像の透明度を設定する**
Aspose.Slides を使用すると、テキストプレースホルダー内の背景画像の透明度を設定できます。そのようなフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色によります）。

This C# code shows you how to set the transparency for a picture background (inside a shape):
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


## **FAQ**

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとどのように異なるか？**

ベースプレースホルダーは、スライドのシェイプが継承するレイアウトまたはマスタ上の元のシェイプです。タイプ、位置、いくつかの書式設定はそれから継承されます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承は適用されません。

**プレゼンテーション全体のすべてのタイトルやキャプションを、各スライドを反復せずに更新するには？**

レイアウトまたはマスタ上の対応するプレースホルダーを編集します。そのレイアウト/マスタに基づくスライドは自動的に変更を継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御しますか？**

適切なスコープ（通常スライド、レイアウト、マスタ、ノート/配布資料）で HeaderFooter マネージャーを使用し、これらのプレースホルダーをオン/オフにしたり、内容を設定したりします。