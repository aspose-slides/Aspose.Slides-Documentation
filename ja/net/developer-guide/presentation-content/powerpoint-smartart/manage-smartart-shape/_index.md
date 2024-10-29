---
title: SmartArt図形の管理
type: docs
weight: 20
url: /ja/net/manage-smartart-shape/
keywords: "SmartArt図形, SmartArt図形スタイル, SmartArt図形の色スタイル, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーション内のSmartArtを管理"
---

## **SmartArt図形を作成**
Aspose.Slides for .NETは、スライドにカスタムSmartArt図形を最初から追加できるようになりました。Aspose.Slides for .NETは、簡単な方法でSmartArt図形を作成するための最もシンプルなAPIを提供しています。スライドにSmartArt図形を作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutTypeを設定してSmartArt図形を追加します。
- 修正したプレゼンテーションをPPTXファイルとして保存します。

```c#
// プレゼンテーションのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // プレゼンテーションスライドにアクセス
    ISlide slide = pres.Slides[0];

    // Smart Art図形を追加
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // プレゼンテーションを保存
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **スライド内のSmartArt図形にアクセス**
以下のコードは、プレゼンテーションスライドに追加されたSmartArt図形にアクセスする際に使用されます。サンプルコードでは、スライド内のすべての図形を横断し、それがSmartArt図形であるかどうかを確認します。図形がSmartArtタイプの場合は、それをSmartArtインスタンスに型変換します。

```c#
// 必要なプレゼンテーションをロード
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 最初のスライド内のすべての図形を横断
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 図形がSmartArtタイプか確認
        if (shape is ISmartArt)
        {
            // 図形をSmartArtExに型変換
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("図形名:" + smart.Name);

        }
    }
}
```



## **特定のLayoutTypeでSmartArt図形にアクセス**
以下のサンプルコードは、特定のLayoutTypeでSmartArt図形にアクセスするのに役立ちます。SmartArt図形は読み取り専用で、SmartArt図形が追加されたときにのみ設定されるため、LayoutTypeを変更することはできないことに注意してください。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を横断します。
- 図形がSmartArtタイプか確認し、SmartArtの場合は選択した図形を型変換します。
- 特定のLayoutTypeを持つSmartArt図形を確認し、その後に必要な処理を行います。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべての図形を横断
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 図形がSmartArtタイプか確認
        if (shape is ISmartArt)
        {
            // 図形をSmartArtExに型変換
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt Layoutを確認
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("ここで何かを行います....");
            }
        }
    }
}
```



## **SmartArt図形のスタイルを変更**
以下のサンプルコードは、特定のLayoutTypeでSmartArt図形にアクセスするのに役立ちます。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を横断します。
- 図形がSmartArtタイプか確認し、SmartArtの場合は選択した図形を型変換します。
- 特定のスタイルを持つSmartArt図形を見つけます。
- SmartArt図形に新しいスタイルを設定します。
- プレゼンテーションを保存します。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべての図形を横断
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 図形がSmartArtタイプか確認
        if (shape is ISmartArt)
        {
            // 図形をSmartArtExに型変換
            ISmartArt smart = (ISmartArt)shape;

            // SmartArtスタイルの確認
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArtスタイルの変更
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // プレゼンテーションを保存
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **SmartArt図形の色スタイルを変更**
この例では、任意のSmartArt図形の色スタイルを変更する方法を学びます。以下のサンプルコードでは、特定の色スタイルを持つSmartArt図形にアクセスし、そのスタイルを変更します。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を横断します。
- 図形がSmartArtタイプか確認し、SmartArtの場合は選択した図形を型変換します。
- 特定の色スタイルを持つSmartArt図形を見つけます。
- SmartArt図形に新しい色スタイルを設定します。
- プレゼンテーションを保存します。

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 最初のスライド内のすべての図形を横断
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 図形がSmartArtタイプか確認
        if (shape is ISmartArt)
        {
            // 図形をSmartArtExに型変換
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt色タイプの確認
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt色タイプの変更
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // プレゼンテーションを保存
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```