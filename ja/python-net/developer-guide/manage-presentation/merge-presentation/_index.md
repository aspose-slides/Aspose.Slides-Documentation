---
title: Python でプレゼンテーションを効率的に結合する
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/python-net/merge-presentation/
keywords:
- merge PowerPoint
- merge presentations
- merge slides
- merge PPT
- merge PPTX
- merge ODP
- combine PowerPoint
- combine presentations
- combine slides
- combine PPT
- combine PPTX
- combine ODP
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手軽に結合し、ワークフローを簡素化します。"
---

## **プレゼンテーション結合の最適化**

[**Aspose.Slides for Python**](https://products.aspose.com/slides/python-net/) を使用すれば、スタイル、レイアウト、すべての要素を保持したまま PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを損なうことなくプレゼンテーションをマージします。デッキ全体、特定のスライド、または異なるファイル形式（例: PPT から PPTX）を結合できます。

### **マージ機能**

- **フル プレゼンテーション マージ:** すべてのスライドを単一ファイルにまとめます。
- **特定スライド マージ:** 選択したスライドだけを結合します。
- **クロスフォーマット マージ:** 形式が異なるプレゼンテーションを統合し、整合性を保ちます。

## **プレゼンテーションの結合**

1 つのプレゼンテーションを別のプレゼンテーションに結合すると、スライドが 1 つのファイルにまとめられます。PowerPoint や OpenOffice などの多くのプレゼンテーションプログラムは、このような結合機能を提供していません。

しかし、[**Aspose.Slides for Python**](https://products.aspose.com/slides/python-net/) では、形状、スタイル、テキスト、書式設定、コメント、アニメーションなどをすべて保持したままプレゼンテーションを結合できます。品質やデータの損失はありません。

**関連項目**  
[Python で PowerPoint スライドをクローンする](/slides/ja/python-net/clone-slides/)

### **マージ可能なもの**

Aspose.Slides を使用すると、以下を結合できます。

- **全体プレゼンテーション:** ソースデッキのすべてのスライドを単一のプレゼンテーションに統合します。
- **特定スライド:** 選択したスライドだけを単一のプレゼンテーションに統合します。
- **同一形式または異なる形式:** 例: PPT→PPT、PPTX→PPTX、または PPT→PPTX、PPTX→ODP など。

{{% alert title="注意" color="info" %}}

プレゼンテーションに加えて、Aspose.Slides は他のファイルの結合もサポートしています。

- **画像**（例: [JPG から JPG]、[PNG から PNG]）
- **文書**（例: [PDF から PDF]、[HTML から HTML]）
- **異種ファイル**（例: 画像から PDF、JPG から PDF、TIFF から PDF）

{{% /alert %}}

### **マージオプション**

次のいずれかを制御できます。  
- 出力プレゼンテーションの各スライドが元のスタイルを保持するか、  
- すべてのスライドに単一のスタイルを適用するか。

プレゼンテーションを結合するには、Aspose.Slides の [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスの `add_clone` メソッドを使用します。このメソッドのオーバーロードにより、結合方法を指定できます。すべての [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトは `slides` コレクションを公開しているので、宛先プレゼンテーションのスライドコレクションで `add_clone` を呼び出します。

`add_clone` メソッドは `Slide`（ソーススライドのクローン）を返します。出力プレゼンテーションのスライドは元のコピーなので、レイアウトや書式を変更してもソースには影響しません。

## **プレゼンテーションの結合** 

Aspose.Slides は `add_clone(ISlide)` メソッドを提供し、レイアウトとスタイルを保持しながらスライドを結合できます（デフォルトパラメータ使用）。

以下の Python サンプルはプレゼンテーションの結合方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドマスターを使用したプレゼンテーションの結合**

`add_clone(ISlide, IMasterSlide, Boolean)` メソッドを使用すると、テンプレートのスライドマスターを適用してスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

以下の Python サンプルはこの操作を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注意" color="warning" %}}

指定したスライドマスターに適したレイアウトが自動的に決定されます。適切なレイアウトが見つからず、`add_clone` の `allow_clone_missing_layout` ブールパラメータを `True` に設定した場合は、ソーススライドのレイアウトが使用されます。そうでない場合は [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) がスローされます。

{{% /alert %}}

別のレイアウトを適用したい場合は、`add_clone(ISlide, ILayoutSlide)` メソッドを使用してください。

## **プレゼンテーションから特定のスライドを結合**

複数のプレゼンテーションから特定のスライドだけを結合すると、カスタムデッキの作成に便利です。Aspose.Slides は必要なスライドだけをインポートし、元の書式、レイアウト、デザインを保持します。

以下の Python 例は、新しいプレゼンテーションに 2 つの別プレゼンテーションからタイトルスライドを追加し、ファイルに保存します。

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドレイアウトを使用したプレゼンテーションの結合**

以下の Python 例は、複数のプレゼンテーションからスライドを結合し、特定のスライドレイアウトを適用して単一の出力プレゼンテーションを作成する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **異なるスライドサイズのプレゼンテーションの結合**

{{% alert title="注意" color="warning" %}}

スライドサイズが異なるプレゼンテーションは直接結合できません。

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションを結合するには、最初に片方のスライドサイズをもう一方に合わせてリサイズします。

以下のサンプルコードはその手順を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **スライドをプレゼンテーションのセクションに結合**

以下の Python 例は、特定のスライドをプレゼンテーションのセクションに結合する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

スライドはセクションの末尾に追加されます。

{{% alert title="ヒント" color="primary" %}}

無料で **オンライン** に PowerPoint プレゼンテーションを結合したいですか？ **Aspose PowerPoint Merger** を試してみてください。

- **PowerPoint ファイルを簡単に結合**: 複数の **PPT、PPTX、ODP** プレゼンテーションを単一ファイルに統合します。  
- **異なる形式に対応**: **PPT → PPTX**、**PPTX → ODP** などを結合。  
- **インストール不要**: ブラウザ上で直接動作、迅速かつ安全です。

[![オンラインで PowerPoint ファイルを結合] (slides-merger.png)](https://products.aspose.app/slides/merger)  

今すぐ **Aspose の無料オンラインツール** で PowerPoint ファイルの結合を始めましょう！  

{{% /alert %}}

{{% alert title="ヒント" color="primary" %}}

Aspose は **無料の Collage ウェブアプリ** を提供しています。オンラインサービスを使って、[JPG から JPG] や PNG から PNG 画像の結合、[フォトグリッド] の作成などが可能です。  

{{% /alert %}}

## **FAQ**

**結合時にスピーカーノートは保持されますか？**  
はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素が引き継がれます。

**コメントとコメント作者は転送されますか？**  
コメントはスライドコンテンツの一部としてコピーされ、コメント作者ラベルも結果のプレゼンテーションに保持されます。

**ソースプレゼンテーションがパスワードで保護されている場合は？**  
[LoadOptions.password](/slides/ja/python-net/password-protected-presentation/) を使用してパスワードで開く必要があります。読み込んだ後、そのスライドは保護されていない（または保護された）ターゲットファイルに安全にクローンできます。

**結合操作はスレッドセーフですか？**  
同じ [Presentation] インスタンスを複数スレッドから使用しないでください。推奨ルールは「1 ドキュメント — 1 スレッド」です。別ファイルは別スレッドで並行処理可能です。  