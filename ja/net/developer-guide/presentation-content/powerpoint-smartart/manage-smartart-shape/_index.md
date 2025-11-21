---
title: .NET でプレゼンテーションの SmartArt グラフィックを管理する
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
description: "Aspose.Slides を使用して .NET で PowerPoint の SmartArt 作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt シェイプの作成**
Aspose.Slides for .NET は、スライドにカスタム SmartArt シェイプを最初から追加できるようになりました。Aspose.Slides for .NET は、最も簡単な方法で SmartArt シェイプを作成するためのシンプルな API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

- [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- 変更したプレゼンテーションを PPTX ファイルとして保存します。
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




## **スライド内の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、SmartArt シェイプかどうかを確認します。シェイプが SmartArt の場合は、SmartArt インスタンスにキャストします。
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
            // シェイプを SmartArtEx にキャストする
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```




## **特定のレイアウト タイプを持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されるため、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt にキャストします。
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
            // シェイプを SmartArtEx にキャストする
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt のレイアウトをチェックする
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```




## **SmartArt シェイプのスタイル変更**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスする方法を示します。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt にキャストします。
- 特定のスタイルを持つ SmartArt シェイプを検索します。
- SmartArt シェイプに新しいスタイルを設定します。
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
            // シェイプを SmartArtEx にキャストする
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt のスタイルをチェックする
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




## **SmartArt シェイプのカラー スタイル変更**
この例では、任意の SmartArt シェイプのカラー スタイルを変更する方法を学びます。以下のサンプルコードは、特定のカラー スタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt にキャストします。
- 特定のカラー スタイルを持つ SmartArt シェイプを検索します。
- SmartArt シェイプに新しいカラー スタイルを設定します。
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
            // シェイプを SmartArtEx にキャストする
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt のカラータイプをチェックする
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

**SmartArt を単一のオブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API（開始、終了、強調、モーション パス）を使用して[標準アニメーション](/slides/ja/net/powerpoint-animation/)を適用できます。

**スライド上で内部 ID が分からない特定の SmartArt をどうやって見つけますか？**

代替テキスト (AltText) を設定し、その値でシェイプを検索します。これは対象シェイプを特定する推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像や表などの他のシェイプとグループ化でき、その後[グループを操作](/slides/ja/net/group/)できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するには？**

シェイプのサムネイル/画像をエクスポートします。ライブラリは個々のシェイプをラスターファイル（PNG/JPG/TIFF）に[レンダリング](/slides/ja/net/create-shape-thumbnails/)できます。

**プレゼンテーション全体を PDF に変換するとき、SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは[PDF エクスポート](/slides/ja/net/convert-powerpoint-to-pdf/)の高忠実度を目指しており、品質や互換性のオプションが豊富に用意されています。