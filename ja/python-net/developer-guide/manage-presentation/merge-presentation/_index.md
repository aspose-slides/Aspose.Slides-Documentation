---
title: Pythonでプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/python-net/developer-guide/manage-presentation/merge-presentation/
keywords:
- PowerPointをマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPTをマージ
- PPTXをマージ
- ODPをマージ
- PowerPointを結合
- プレゼンテーションを結合
- スライドを結合
- PPTを結合
- PPTXを結合
- ODPを結合
- Python
- Aspose.Slides
description: "PowerPoint (PPT, PPTX) および OpenDocument (ODP) プレゼンテーションを Aspose.Slides for Python via .NET で手軽にマージし、作業フローを効率化します。"
---

## **プレゼンテーションのマージを最適化する**

[Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) を使用すれば、スタイル、レイアウト、すべての要素を保持しながら PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを失うことなくプレゼンテーションをマージします。デッキ全体、特定のスライド、あるいは異なるファイル形式（例: PPT から PPTX）をマージできます。

### **マージ機能**

- **全プレゼンテーションのマージ:** すべてのスライドを単一ファイルにまとめます。  
- **特定スライドのマージ:** 任意のスライドを選択して結合します。  
- **クロスフォーマットマージ:** 異なる形式のプレゼンテーションを統合し、完全性を維持します。

## **プレゼンテーションのマージ**

プレゼンテーションを別のものにマージすると、スライドを 1 つのプレゼンテーションに統合して 1 つのファイルを作成することになります。PowerPoint や OpenOffice などの多くのプレゼンテーションソフトは、このようなマージ機能を提供していません。

しかし、[Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) では、さまざまな方法でプレゼンテーションをマージできます。形状、スタイル、テキスト、書式設定、コメント、アニメーションをすべて保持したまま、品質やデータの損失なしにマージ可能です。

**関連項目**

[Python で PowerPoint スライドをクローンする](/slides/ja/python-net/clone-slides/)

### **マージできる対象**

Aspose.Slides を使用すると、次のものをマージできます。

- **全体のプレゼンテーション:** ソース デッキのすべてのスライドを 1 つのプレゼンテーションに結合します。  
- **特定のスライド:** 選択したスライドだけを 1 つのプレゼンテーションに結合します。  
- **同一フォーマットまたは異なるフォーマット:** 例: PPT→PPT、PPTX→PPTX、または PPT→PPTX、PPTX→ODP など。

{{% alert title="注意" color="info" %}}

プレゼンテーションに加えて、Aspose.Slides は他のファイルもマージできます。

- **画像** (例: [JPG から JPG](/slides/ja/python-net/merger/jpg-to-jpg/) や [PNG から PNG](/slides/ja/python-net/merger/png-to-png/))。  
- **ドキュメント** (例: [PDF から PDF](/slides/ja/python-net/merger/pdf-to-pdf/) や [HTML から HTML](/slides/ja/python-net/merger/html-to-html/))。  
- **異なるファイルタイプ** (例: [画像から PDF](/slides/ja/python-net/merger/image-to-pdf/)、[JPG から PDF](/slides/ja/python-net/merger/jpg-to-pdf/)、[TIFF から PDF](/slides/ja/python-net/merger/tiff-to-pdf/))。

{{% /alert %}}

### **マージオプション**

次のいずれかを制御できます。  
- 出力プレゼンテーションの各スライドが元のスタイルを保持するか、  
- 出力プレゼンテーション全体に単一のスタイルが適用されるか。

プレゼンテーションをマージするには、Aspose.Slides が提供する [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) メソッドを使用します。`SlideCollection` クラス上にあるこれらのオーバーロードは、マージ方法を定義します。すべての `Presentation` オブジェクトは `slides` コレクションを公開しているため、宛先プレゼンテーションのスライド コレクションで `add_clone` を呼び出します。

`add_clone` メソッドは、ソース スライドのクローンである `Slide` を返します。出力プレゼンテーションのスライドは元のコピーなので、スタイルや書式設定、レイアウトを変更してもソースには影響しません。

## **プレゼンテーションのマージ** 

Aspose.Slides は [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) メソッドを提供しており、デフォルト パラメーターでレイアウトとスタイルを保持しながらスライドを結合できます。

以下の Python サンプルは、プレゼンテーションをマージする方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **スライド マスター付きでプレゼンテーションをマージ** 

Aspose.Slides は [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) メソッドを提供しており、テンプレートのスライド マスターを適用してスライドをマージできます。必要に応じて、出力プレゼンテーションのスライドのスタイルを変更できます。

以下の Python サンプルはこの操作を示します。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注意" color="warning" %}}

指定されたスライド マスターの下で適切なレイアウトが自動的に判定されます。適切なレイアウトが見つからず、`add_clone` メソッドの `allow_clone_missing_layout` ブール パラメーターが `True` に設定されている場合は、ソース スライドのレイアウトが使用されます。それ以外の場合は、[PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用するには、[add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) メソッドを使用してください。

## **プレゼンテーションから特定スライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすることは、カスタム デッキ作成に便利です。Aspose.Slides を使えば、必要なスライドだけを選択してインポートでき、元の書式、レイアウト、デザインを保持したまま結合できます。

以下の Python サンプルは、新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加してファイルに保存します。

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

## **スライド レイアウト付きでプレゼンテーションをマージ** 

以下の Python サンプルは、複数のプレゼンテーションからスライドをマージし、特定のスライド レイアウトを適用して単一の出力プレゼンテーションを作成する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **スライド サイズが異なるプレゼンテーションをマージ** 

{{% alert title="注意" color="warning" %}}

スライド サイズが異なるプレゼンテーションは直接マージできません。

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションをマージするには、先に一方のスライド サイズを他方に合わせてリサイズします。

以下のサンプルコードは、その手順を示します。

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

## **スライドをプレゼンテーション セクションにマージ** 

以下の Python サンプルは、特定のスライドをプレゼンテーションのセクションにマージする方法を示します。

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

無料で **オンライン** に PowerPoint プレゼンテーションを **マージ** したいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) をお試しください。

- **PowerPoint ファイルを簡単にマージ**: 複数の **PPT、PPTX、ODP** プレゼンテーションを 1 つのファイルに結合。  
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP** など、さまざまな変換が可能。  
- **インストール不要**: ブラウザ上で直接動作し、迅速かつ安全です。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

今すぐ **Aspose の無料オンライン ツール** で PowerPoint ファイルのマージを開始しましょう！  

{{% /alert %}}

{{% alert title="ヒント" color="primary" %}}

Aspose は [無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスで、[JPG から JPG](/slides/ja/python-net/collage/jpg) や PNG から PNG 画像のマージ、[フォト グリッド](/slides/ja/python-net/collage/photo-grid) の作成などが可能です。  

{{% /alert %}}

## **FAQ**

**マージ時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、ノートを含むすべてのスライド要素が Aspose.Slides によってコピーされます。

**コメントとその作成者は転送されますか？**

コメントはスライド コンテンツの一部としてコピーされ、コメント作成者のラベルも結果のプレゼンテーションで保持されます。

**ソース プレゼンテーションがパスワードで保護されている場合は？**

[LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) を使用して [/slides/python-net/password-protected-presentation/](/slides/ja/python-net/password-protected-presentation/) で開く必要があります。ロード後、スライドは保護されていない（または保護された）ターゲット ファイルに安全にクローンできます。

**マージ操作はスレッド セーフですか？**

同一の [Presentation](/slides/ja/python-net/multithreading/) インスタンスを複数スレッドで使用しないでください。推奨は「1 ドキュメント – 1 スレッド」です。別々のファイルは別スレッドで並行処理可能です。