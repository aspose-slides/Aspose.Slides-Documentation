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
- PowerPoint を統合
- プレゼンテーションを統合
- スライドを統合
- PPT を統合
- PPTX を統合
- ODP を統合
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET 経由）を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手間なく結合し、ワークフローを効率化します。"
---

## **プレゼンテーション結合の最適化**

Aspose.Slides for Python を使用すれば、スタイル、レイアウト、およびすべての要素を保持したまま、PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを損なうことなくプレゼンテーションを結合します。全体のデッキ、特定のスライド、あるいは異なるファイル形式（例: PPT から PPTX）も結合できます。

### **結合機能**

- **完全プレゼンテーション結合:** すべてのスライドを単一のファイルにまとめます。
- **特定スライド結合:** 選択したスライドを選んで結合します。
- **クロスフォーマット結合:** 異なる形式のプレゼンテーションを統合し、完全性を維持します。

## **プレゼンテーション結合**

プレゼンテーションを別のプレゼンテーションに結合すると、実質的にスライドを 1 つのプレゼンテーションにまとめて 1 つのファイルを作成します。PowerPoint や OpenOffice などのほとんどのプレゼンテーションプログラムは、このようにプレゼンテーションを結合する機能を提供していません。

しかし、Aspose.Slides for Python を使用すると、さまざまな方法でプレゼンテーションを結合できます。形状、スタイル、テキスト、書式設定、コメント、アニメーションをすべて含むプレゼンテーションを、品質やデータを失うことなく結合できます。

**参照**
[PythonでPowerPointスライドをクローン](/slides/ja/python-net/clone-slides/)

### **何が結合できるか**

- **全体のプレゼンテーション:** ソース デッキのすべてのスライドが単一のプレゼンテーションに結合されます。
- **特定のスライド:** 選択されたスライドのみが単一のプレゼンテーションに結合されます。
- **同一形式のプレゼンテーション (例: PPT→PPT、PPTX→PPTX) または異なる形式間 (例: PPT→PPTX、PPTX→ODP) の結合。**

### **結合オプション**

以下を制御できます:
- 出力プレゼンテーションの各スライドが元のスタイルを保持するか、または
- 出力プレゼンテーションの全スライドに単一のスタイルが適用されるか。

プレゼンテーションを結合するには、Aspose.Slides が [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラス上の [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) メソッドを提供します。これらのメソッドのオーバーロードにより、結合の方法が定義されます。すべての [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトは [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションを公開しているため、宛先プレゼンテーションのスライドコレクションで `add_clone` を呼び出します。

`add_clone` メソッドは `Slide` を返します—これはソーススライドのクローンです。出力プレゼンテーションのスライドは元のコピーなので、元のプレゼンテーションに影響を与えることなく、結果のスライドを（例としてスタイル、書式設定、レイアウトを適用するなど）変更できます。

## **プレゼンテーションの結合**

Aspose.Slides は [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) メソッドを提供し、レイアウトとスタイルを保持したままスライドを結合できます（デフォルト パラメーターを使用）。

以下の Python の例は、プレゼンテーションの結合方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドマスターを使用したプレゼンテーションの結合**

Aspose.Slides は [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) メソッドを提供し、テンプレートからスライドマスターを適用しながらスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

以下の Python の例はこの操作を示しています。
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}
指定されたスライドマスターの下で適切なレイアウトが自動的に決定されます。適切なレイアウトが見つからず、`add_clone` メソッドの `allow_clone_missing_layout` ブールパラメーターが `True` に設定されている場合は、代わりにソーススライドのレイアウトが使用されます。そうでない場合、[PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) がスローされます。
{{% /alert %}}

出力プレゼンテーションのスライドに別のスライドレイアウトを適用するには、結合時に [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) メソッドを使用します。

## **プレゼンテーションから特定のスライドを結合**

複数のプレゼンテーションから特定のスライドを結合することは、カスタムスライドデッキを作成する際に便利です。Aspose.Slides を使用すると、必要なスライドだけを選択してインポートでき、元のスライドの書式設定、レイアウト、デザインを保持します。

以下の Python の例は、新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトルスライドを追加し、結果をファイルに保存します。
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

以下の Python の例は、特定のスライドレイアウトを適用しながら複数のプレゼンテーションからスライドを結合し、単一の出力プレゼンテーションを作成する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```


## **異なるスライドサイズのプレゼンテーションの結合**

{{% alert title="Note" color="warning" %}}
異なるスライドサイズを持つプレゼンテーションは直接結合できません。
{{% /alert %}}

異なるスライドサイズの 2 つのプレゼンテーションを結合するには、まず一方のプレゼンテーションのスライドサイズをもう一方に合わせてリサイズします。

以下のサンプルコードはこのプロセスを示しています。
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


## **プレゼンテーションのセクションにスライドを結合**

以下の Python の例は、特定のスライドをプレゼンテーションのセクションに結合する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```


スライドはセクションの末尾に追加されます。

{{% alert title="Tip" color="primary" %}}
PowerPoint プレゼンテーションを **無料でオンラインで素早く結合** できるツールを探していますか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) をお試しください。

- **PowerPoint ファイルを簡単に結合**: 複数の **PPT、PPTX、ODP** プレゼンテーションを単一のファイルに結合します。  
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP** などを結合します。  
- **インストール不要**: ブラウザ上で直接動作し、迅速かつ安全です。  

[![PowerPoint ファイルをオンラインで結合](slides-merger.png)](https://products.aspose.app/slides/merger)  

今日から **Aspose の無料オンラインツール** で PowerPoint ファイルの結合を始めましょう！  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose は [無料 Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。  
{{% /alert %}}

## **よくある質問**

**結合時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションなど、すべてのスライド要素を引き継ぎます。

**コメントとその作成者は転送されますか？**

コメントはスライドコンテンツの一部としてスライドと共にコピーされます。コメント作成者のラベルは、結果のプレゼンテーションでコメントオブジェクトとして保持されます。

**ソースプレゼンテーションがパスワード保護されている場合はどうなりますか？**

[LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) を使用して [パスワードで開く](/slides/ja/python-net/password-protected-presentation/) 必要があります。読み込み後、これらのスライドは保護されていないターゲットファイル（または保護されたファイル）に安全にクローンできます。

**結合操作はスレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/python-net/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント — 1 スレッド」です。異なるファイルは別々のスレッドで並行処理できます。