---
title: プレースホルダーの管理
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords: "プレースホルダー, プレースホルダー テキスト, プロンプトテキスト, PowerPoint プレゼンテーション, C#, C#, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションのプレースホルダー テキストとプロンプトテキストを C# または .NET で変更する"
---

## **プレースホルダーのテキストを変更する**
Aspose.Slides for .NET を使用すると、プレゼンテーションのスライド内のプレースホルダーを検索・変更できます。Aspose.Slides を使って、プレースホルダー内のテキストを変更できます。

**Prerequisite**: プレースホルダーが含まれるプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダーのテキストを置換する手順です。

1. `Presentation` クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. シェイプをイテレートしてプレースホルダーを見つけます。
4. プレースホルダーシェイプを `AutoShape` にキャストし、`AutoShape` に関連付けられた `TextFrame` を使用してテキストを変更します。 
5. 変更したプレゼンテーションを保存します。

この C# コードは、プレースホルダーのテキストを変更する方法を示しています。
```c#
// Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // プレースホルダーを探すためにシェイプを列挙します
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


## **プレースホルダーのプロンプトテキストを設定する**
標準およびプリセットのレイアウトには、***クリックしてタイトルを追加*** や ***クリックしてサブタイトルを追加*** などのプレースホルダー用プロンプトテキストが含まれています。Aspose.Slides を使用すると、好きなプロンプトテキストをプレースホルダーレイアウトに挿入できます。

この C# コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // スライドをイテレートします
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint は「Click to add title」を表示します
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

Aspose.Slides では、テキスト プレースホルダー内の背景画像の透明度を設定できます。そのフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色によります）。

この C# コードは、シェイプ内の画像背景の透明度を設定する方法を示しています。
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

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとはどのように異なるか**

ベースプレースホルダーは、レイアウトまたはマスタ上にあるスライドのシェイプが継承する元となるシェイプです。そのタイプ、位置、および一部の書式設定はベースプレースホルダーから継承されます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承は適用されません。

**プレゼンテーション全体のタイトルやキャプションを、各スライドを走査せずに更新するにはどうすればよいですか？**

レイアウトまたはマスタ上の該当プレースホルダーを編集します。そのレイアウトやマスタを使用しているスライドは、変更を自動的に継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**

適切なスコープ（通常スライド、レイアウト、マスタ、ノート/配布資料）の HeaderFooter マネージャーを使用して、これらのプレースホルダーを有効または無効にし、内容を設定します。