---
title: PowerPoint スライドを Python で PNG に変換
linktitle: スライドから PNG
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- ODP を PNG に変換
- PowerPoint から PNG へ
- プレゼンテーションから PNG へ
- スライドから PNG へ
- PPT を PNG に変換
- PPTX を PNG に変換
- ODP を PNG に変換
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **概要**

Aspose.Slides for Python via .NET は PowerPoint プレゼンテーションを PNG に変換する作業を簡単にします。プレゼンテーションをロードし、スライドを反復処理し、各スライドをラスタ画像にレンダリングし、結果を PNG ファイルとして保存します。これはスライドのプレビュー生成や、ウェブページへのスライド埋め込み、または下流処理用の静的資産の作成に最適です。

## **スライドを PNG に変換**

このセクションでは、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションを PNG 画像に変換する最もシンプルな例を示します。

次の手順を実行します:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `Presentation.slides` コレクションからスライドを取得します（[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) クラスを参照）。
3. `Slide.get_image` メソッドを使用してスライドのサムネイルを生成します。
4. `Presentation.save` メソッドを使用してスライドのサムネイルを PNG 形式で保存します。

この Python コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **カスタム寸法でスライドを PNG に変換**

スライドをカスタムスケールで PNG にエクスポートするには、`Slide.get_image` に水平および垂直のスケール係数を指定します。これらの乗数はスライドの元のサイズに対して出力をリサイズします。たとえば、`2.0` は幅と高さの両方を倍にします。アスペクト比を保持するには、`scale_x` と `scale_y` に同じ値を使用します。

この Python コードは上記の操作を示しています:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **カスタムサイズでスライドを PNG に変換**

特定のサイズで PNG ファイルを生成したい場合は、希望する `width` と `height` の値を指定します。以下のコードは、画像サイズを指定して PowerPoint を PNG に変換する方法を示しています: 
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tip" color="primary" %}}
Aspose の無料 **PowerPoint から PNG へのコンバータ**—[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png) を試してみるとよいでしょう。これらはこのページで説明したプロセスのライブ実装を提供します。
{{% /alert %}}

## **FAQ**

**スライド全体ではなく、特定のシェイプ（例えば、チャートや画像）だけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/python-net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバーでの並列変換はサポートされていますか？**

はい、ただしスレッド間で単一の Presentation インスタンスを共有しないでください（[共有しない](/slides/ja/python-net/multithreading/)）。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG へのエクスポート時の試用版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで[その他の制限](/slides/ja/python-net/licensing/)が課されます。