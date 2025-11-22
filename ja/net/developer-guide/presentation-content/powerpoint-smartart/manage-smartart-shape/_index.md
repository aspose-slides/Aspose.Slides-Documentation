---
title: SmartArt シェイプの管理
type: docs
weight: 20
url: /ja/net/manage-smartart-shape/
keywords: "SmartArt シェイプ, SmartArt シェイプスタイル, SmartArt シェイプ カラースタイル, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションの SmartArt を管理する"
---

## **SmartArt シェイプの作成**
Aspose.Slides for .NET は、スライドにカスタム SmartArt シェイプを最初から追加できるようになりました。Aspose.Slides for .NET は、SmartArt シェイプを最も簡単な方法で作成できる API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- 変更したプレゼンテーションを PPTX ファイルとして保存します。
```c#
// プレゼンテーションをインスタンス化する
using (Presentation pres = new Presentation())
{

    // プレゼンテーションのスライドにアクセスする
    ISlide slide = pres.Slides[0];

    // Smart Art シェイプを追加する
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // プレゼンテーションを保存する
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **スライド内の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、SmartArt シェイプかどうかを確認します。SmartArt タイプのシェイプであれば、SmartArt インスタンスにキャストします。
```c#
// 目的のプレゼンテーションを読み込む
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプかどうかを確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型キャストする
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **特定の LayoutType を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定され、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションを読み込みます。
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
            // シェイプを SmartArtEx に型キャストする
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

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt にキャストします。
- 特定の Style を持つ SmartArt シェイプを検索します。
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
            // シェイプを SmartArtEx に型キャストする
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

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt にキャストします。
- 特定の Color Style を持つ SmartArt シェイプを検索します。
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
            // シェイプを SmartArtEx に型キャストする
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt のカラースタイルをチェックする
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt のカラースタイルを変更する
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

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API（開始、終了、強調、モーション パス）を使用して [standard animations](/slides/ja/net/powerpoint-animation/) を適用できます。

**スライド上の特定の SmartArt の内部 ID が分からない場合、どうやって見つけますか？**

代替テキスト（AltText）を設定し、その値でシェイプを検索します。これが対象シェイプを特定する推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像や表などの他のシェイプとグループ化でき、その後 [manipulate the group](/slides/ja/net/group/) が可能です。

**特定の SmartArt の画像（プレビューやレポート用）を取得するには？**

シェイプのサムネイル/画像をエクスポートできます。ライブラリは個別シェイプを [render individual shapes](/slides/ja/net/create-shape-thumbnails/) して PNG/JPG/TIFF 形式のラスターファイルに出力できます。

**プレゼンテーション全体を PDF に変換した際、SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは [PDF export](/slides/ja/net/convert-powerpoint-to-pdf/) において高忠実度を目指しており、品質や互換性のオプションが用意されています。