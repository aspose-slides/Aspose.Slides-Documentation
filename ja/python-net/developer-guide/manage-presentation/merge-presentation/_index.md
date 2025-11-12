---
title: Pythonでプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/python-net/merge-presentation/
keywords:
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PowerPoint を組み合わせ
- プレゼンテーションを組み合わせ
- スライドを組み合わせ
- PPT を組み合わせ
- PPTX を組み合わせ
- ODP を組み合わせ
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET 経由) を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手間なく結合し、ワークフローを効率化します。"
---

## **プレゼンテーション結合の最適化**

[ Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) を使用すれば、スタイル、レイアウト、すべての要素を保持したまま PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを損なうことなくプレゼンテーションを結合します。デッキ全体、特定のスライド、あるいは異なるファイル形式（例: PPT から PPTX）を結合できます。

### **結合機能**

- **全体プレゼンテーション結合:** すべてのスライドを 1 つのファイルにまとめます。
- **特定スライド結合:** 選択したスライドのみを結合します。
- **クロスフォーマット結合:** 異なる形式のプレゼンテーションを統合し、整合性を保ちます。

## **プレゼンテーションの結合**

1 つのプレゼンテーションを別のプレゼンテーションに結合すると、スライドが 1 つにまとめられ、単一のファイルが生成されます。PowerPoint や OpenOffice などの多くのプレゼンテーション ソフトウェアは、このような結合機能を提供していません。

しかし、[Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) を使用すれば、さまざまな方法でプレゼンテーションを結合できます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなどをすべて保持したまま結合でき、品質やデータの損失はありません。

**関連項目**

[Python で PowerPoint スライドをクローンする](/slides/ja/python-net/clone-slides/)

### **結合できるもの**

Aspose.Slides を使用すると、次のものを結合できます。

- **全体プレゼンテーション:** ソース デッキのすべてのスライドを 1 つのプレゼンテーションに結合します。
- **特定スライド:** 選択したスライドのみを 1 つのプレゼンテーションに結合します。
- **同一形式または異なる形式:** PPT→PPT、PPTX→PPTX のような同一形式、または PPT→PPTX、PPTX→ODP のような異なる形式でも結合できます。

{{% alert title="注" color="info" %}}

プレゼンテーションに加えて、Aspose.Slides は次のファイルの結合もサポートしています。

- [画像](https://products.aspose.com/slides/python-net/merger/image-to-image/)（例: [JPG から JPG]((https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/))、[PNG から PNG]((https://products.aspose.com/slides/python-net/merger/png-to-png/))）。
- 文書（例: [PDF から PDF]((https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/))、[HTML から HTML]((https://products.aspose.com/slides/python-net/merger/html-to-html/))）。
- 異なるファイルタイプ（例: [画像から PDF]((https://products.aspose.com/slides/python-net/merger/image-to-pdf/))、[JPG から PDF]((https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/))、[TIFF から PDF]((https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/))）。

{{% /alert %}}

### **結合オプション**

次のいずれかを制御できます。

- 出力プレゼンテーションの各スライドが元のスタイルを保持するか、
- すべてのスライドに単一のスタイルを適用するか。

プレゼンテーションを結合するには、Aspose.Slides が提供する [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) メソッド（`SlideCollection` クラス）を使用します。このメソッドのオーバーロードにより結合方法が決まります。すべての `Presentation` オブジェクトは `slides` コレクションを公開しているため、対象プレゼンテーションのスライド コレクションで `add_clone` を呼び出します。

`add_clone` メソッドは `Slide`（ソース スライドのクローン）を返します。出力プレゼンテーションのスライドは元のコピーなので、スタイルや書式設定、レイアウトを変更してもソース プレゼンテーションには影響しません。

## **プレゼンテーションの結合** 

Aspose.Slides は [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) メソッドを提供し、レイアウトとスタイルを保持したままスライドを結合できます（デフォルト パラメータ使用）。

次の Python サンプルはプレゼンテーションを結合する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **スライド マスターを使用したプレゼンテーション結合**

Aspose.Slides は [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) メソッドを提供し、テンプレートのスライド マスターを適用しながらスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

次の Python サンプルはこの操作を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注" color="warning" %}}

指定されたスライド マスターの下にある適切なレイアウトは自動的に決定されます。適切なレイアウトが見つからず、`add_clone` メソッドの `allow_clone_missing_layout` ブール パラメータが `True` に設定されている場合、ソース スライドのレイアウトが使用されます。それ以外の場合は [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用するには、[add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) メソッドを使用します。

## **プレゼンテーションから特定スライドを結合**

複数のプレゼンテーションから特定のスライドを結合すると、カスタム スライド デッキの作成に便利です。Aspose.Slides は必要なスライドだけを選択してインポートし、元のスライドの書式設定、レイアウト、デザインを保持します。

次の Python サンプルは新しいプレゼンテーションを作成し、2 つの別プレゼンテーションからタイトル スライドを追加してファイルに保存します。

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

## **スライド レイアウトを使用したプレゼンテーション結合**

次の Python サンプルは、複数のプレゼンテーションからスライドを結合し、特定のスライド レイアウトを適用して単一の出力プレゼンテーションを作成する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **異なるスライド サイズのプレゼンテーション結合**

{{% alert title="注" color="warning" %}}

サイズが異なるスライドを持つプレゼンテーションは直接結合できません。

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションを結合するには、まず 1 つのプレゼンテーションのスライド サイズをもう一方に合わせてリサイズします。

次のサンプル コードはこの手順を示しています。

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

## **スライドをセクションに結合**

次の Python サンプルは、特定のスライドをプレゼンテーション セクションに結合する方法を示しています。

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

無料でオンラインで **PowerPoint プレゼンテーションを結合** したいですか？ **Aspose PowerPoint Merger** をお試しください。

- **PowerPoint ファイルを簡単に結合**: 複数の **PPT、PPTX、ODP** プレゼンテーションを 1 つのファイルに統合します。  
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP** などを結合できます。  
- **インストール不要**: ブラウザー上で直接実行、迅速かつ安全です。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

今すぐ **Aspose の無料オンライン ツール** で PowerPoint ファイルの結合を始めましょう！

{{% /alert %}}

{{% alert title="ヒント" color="primary" %}}

Aspose は [無料のコラージュ Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンライン サービスで [JPG から JPG]((https://products.aspose.app/slides/collage/jpg)) や PNG から PNG の画像を結合したり、[フォトグリッド]((https://products.aspose.app/slides/collage/photo-grid)) を作成したりできます。 

{{% /alert %}}

## **FAQ**

**スピーカーノートは結合時に保持されますか？**

はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションを含むすべてのスライド要素を引き継ぎます。

**コメントとその作成者は転送されますか？**

コメントはスライド コンテンツの一部としてコピーされ、コメント作成者のラベルも結果のプレゼンテーション内のコメント オブジェクトとして保持されます。

**ソースプレゼンテーションがパスワードで保護されている場合は？**

[LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) を使用して [パスワードで保護されたプレゼンテーション](/slides/ja/python-net/password-protected-presentation/) を開く必要があります。ロード後、スライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。

**結合操作はスレッドセーフですか？**

同じ [Presentation](/slides/ja/python-net/multithreading/) インスタンスを複数スレッドから使用しないでください。推奨ルールは「1 ドキュメント – 1 スレッド」です。別々のファイルは個別のスレッドで並列処理できます。