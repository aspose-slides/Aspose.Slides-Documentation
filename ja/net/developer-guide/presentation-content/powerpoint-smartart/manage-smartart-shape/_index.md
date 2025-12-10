---
title: .NET でプレゼンテーションの SmartArt グラフィックを管理
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/net/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウト タイプ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **スマートアート シェイプの作成**
Aspose.Slides for .NET は、スライドにカスタムの SmartArt シェイプをゼロから追加できるようになりました。Aspose.Slides for .NET は、SmartArt シェイプを最も簡単に作成できるシンプルな API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。
```c#
// プレゼンテーションのインスタンス化
using (Presentation pres = new Presentation())
{

    // プレゼンテーションのスライドにアクセス
    ISlide slide = pres.Slides[0];

    // Smart Art シェイプを追加
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // プレゼンテーションを保存
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **スライド上の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、SmartArt シェイプかどうかを確認します。シェイプが SmartArt タイプの場合は、SmartArt インスタンスに型変換します。
```c#
// 目的のプレゼンテーションをロードする
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプかどうかを確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **特定の Layout Type を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプが追加されたときにのみ設定されるため、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型変換します。
- 特定の LayoutType を持つ SmartArt シェイプを確認し、その後に必要な処理を実行します。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプかどうかを確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt のレイアウトを確認する
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **SmartArt シェイプのスタイルを変更する**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスするのに役立ちます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型変換します。
- 特定の Style を持つ SmartArt シェイプを見つけます。
- SmartArt シェイプに新しい Style を設定します。
- プレゼンテーションを保存します。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプかどうかを確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt のスタイルを確認する
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt のスタイルを変更する
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // プレゼンテーションを保存する
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **SmartArt シェイプのカラースタイルを変更する**
この例では、任意の SmartArt シェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードは、特定のカラー スタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型変換します。
- 特定の Color Style を持つ SmartArt シェイプを見つけます。
- SmartArt シェイプに新しい Color Style を設定します。
- プレゼンテーションを保存します。
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプかどうかを確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt のカラータイプを確認する
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt のカラータイプを変更する
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // プレゼンテーションを保存する
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**
はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API を使用して [標準アニメーション](/slides/ja/net/powerpoint-animation/)（開始、終了、強調、動きのパス）を適用できます。

**スライド上で内部 ID が分からない場合、特定の SmartArt をどのように見つけますか？**
代替テキスト (AltText) を設定して使用し、その値でシェイプを検索します。これが対象シェイプを見つける推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**
はい。SmartArt を他のシェイプ（画像、表など）とグループ化し、[グループを操作](/slides/ja/net/group/)することができます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するにはどうすればよいですか？**
シェイプのサムネイル/画像をエクスポートします。ライブラリは個々のシェイプをラスターファイル（PNG/JPG/TIFF）に [レンダリング](/slides/ja/net/create-shape-thumbnails/)できます。

**プレゼンテーション全体を PDF に変換した際、SmartArt の外観は保持されますか？**
はい。レンダリング エンジンは [PDF エクスポート](/slides/ja/net/convert-powerpoint-to-pdf/) において高忠実度を目指しており、さまざまな品質と互換性のオプションを提供します。