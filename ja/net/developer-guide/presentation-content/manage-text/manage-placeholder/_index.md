---
title: .NET でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレースホルダーを手軽に管理: テキストの置換、プロンプトのカスタマイズ、PowerPoint および OpenDocument の画像透明度設定。"
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for .NET](/slides/ja/net/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索および変更できます。Aspose.Slides を使用すると、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは、標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダーのテキストを置換する方法です:

1. [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. シェイプを反復処理してプレースホルダーを見つけます。
4. プレースホルダーシェイプを [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) に型変換し、[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この C# コードは、プレースホルダーのテキストを変更する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // プレースホルダーを見つけるためにシェイプを反復処理します
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // 各プレースホルダーのテキストを変更します
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // プレゼンテーションをディスクに保存します
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** のようなプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、好きなプロンプトテキストをプレースホルダー レイアウトに挿入できます。

この C# コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // スライドを反復処理します
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
Aspose.Slides を使用すると、テキスト プレースホルダー内の背景画像の透明度を設定できます。このフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色に依存します）。

この C# コードは、シェイプ内の画像背景の透明度を設定する方法を示しています:
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

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとはどう違うのか？**  
ベースプレースホルダーは、レイアウトまたはマスター上にある元のシェイプで、スライドのシェイプがそれから継承します。タイプ、位置、そしていくつかの書式設定がそこから引き継がれます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承は適用されません。

**すべてのタイトルやキャプションをプレゼンテーション全体で更新したいが、各スライドを反復処理したくない。**  
レイアウトまたはマスター上の該当するプレースホルダーを編集します。これらのレイアウト／マスターに基づくスライドは、変更を自動的に継承します。

**標準ヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**  
適切なスコープ（標準スライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用し、これらのプレースホルダーのオン/オフを切り替え、内容を設定します。