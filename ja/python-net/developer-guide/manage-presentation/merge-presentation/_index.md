---
title: Python でプレゼンテーションを効率的に結合
linktitle: プレゼンテーションを結合
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
description: "Aspose.Slides for Python (via .NET) を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手間なく結合し、ワークフローを簡素化します。"
---

## **プレゼンテーション結合の最適化**

With [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/), you can seamlessly combine PowerPoint presentations while preserving styles, layouts, and all elements. Unlike other tools, Aspose.Slides merges presentations without compromising quality or losing data. Merge entire decks, specific slides, or even different file formats (e.g., PPT to PPTX).

### **結合機能**

- **フルプレゼンテーション結合:** すべてのスライドを単一のファイルにまとめます。
- **特定スライド結合:** 選択したスライドを組み合わせます。
- **クロスフォーマット結合:** 異なる形式のプレゼンテーションを統合し、整合性を保ちます。

## **プレゼンテーション結合**

When you merge one presentation into another, you are effectively combining their slides into a single presentation to produce one file. Most presentation programs—such as PowerPoint or OpenOffice—do not provide features that let you merge presentations in this way.

However, [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) allows you to merge presentations in several ways. You can merge presentations with all their shapes, styles, text, formatting, comments, and animations, without any loss of quality or data.

**See also**

[Clone PowerPoint Slides in Python](/slides/ja/python-net/clone-slides/)

### **結合可能なもの**

With Aspose.Slides, you can merge:

- **全体のプレゼンテーション:** ソースデッキのすべてのスライドが単一のプレゼンテーションに結合されます。
- **特定スライド:** 選択したスライドだけが単一のプレゼンテーションに結合されます。
- **同一形式のプレゼンテーション (例: PPT→PPT, PPTX→PPTX) または異なる形式間 (例: PPT→PPTX, PPTX→ODP).**

{{% alert title="Note" color="info" %}}

プレゼンテーションに加えて、Aspose.Slides は他のファイルの結合もサポートします:

- [Images](https://products.aspose.com/slides/python-net/merger/image-to-image/)、例: [JPG to JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) または [PNG to PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)。
- Documents、例: [PDF to PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) または [HTML to HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)。
- 異なるファイルタイプの組み合わせ、例: [image to PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)、[JPG to PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)、[TIFF to PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/)。

{{% /alert %}}

### **結合オプション**

You can control whether:
- Each slide in the output presentation retains its original style, or
- A single style is applied to all slides in the output presentation.

To merge presentations, Aspose.Slides provides the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) methods on the [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) class. These method overloads define how the merge is performed. Every [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object exposes a [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection, so you call `add_clone` on the destination presentation’s slide collection.

The `add_clone` method returns an `Slide`—a clone of the source slide. Slides in the output presentation are copies of the originals, so you can modify the resulting slides (for example, apply styles, formatting, or layouts) without affecting the source presentations.

## **プレゼンテーションの結合** 

Aspose.Slides provides the [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) method, which allows you to combine slides while preserving their layouts and styles (using default parameters).

The following Python example shows how to merge presentations:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドマスターを使用したプレゼンテーション結合**

Aspose.Slides provides the [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) method, which allows you to merge slides while applying a slide master from a template. This way, when needed, you can restyle the slides in the output presentation.

The following Python example demonstrates this operation:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}

The appropriate layout under the specified slide master is determined automatically. If no suitable layout can be found and the `allow_clone_missing_layout` boolean parameter of the `add_clone` method is set to `True`, the source slide’s layout is used instead. Otherwise, a [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) is thrown.

{{% /alert %}}

To apply a different slide layout to slides in the output presentation, use the [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) method when merging.

## **プレゼンテーションから特定スライドを結合**

Merging specific slides from multiple presentations is useful when creating custom slide decks. Aspose.Slides lets you select and import only the slides you need, while preserving the original slides’ formatting, layout, and design.

The following Python example creates a new presentation, adds title slides from two other presentations, and saves the result to a file:
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


## **スライドレイアウトを使用したプレゼンテーション結合**

The following Python example shows how to merge slides from multiple presentations while applying a specific slide layout to produce a single output presentation:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```


## **異なるスライドサイズのプレゼンテーション結合**

{{% alert title="Note" color="warning" %}}

異なるスライドサイズのプレゼンテーションは直接結合できません。

{{% /alert %}}

To merge two presentations with different slide sizes, first resize one presentation so its slide size matches the other’s.

The following sample code demonstrates this process:
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


## **プレゼンテーションセクションにスライドを結合**

The following Python example shows how to merge a specific slide into a section of a presentation:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```


The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}}

Looking for a quick and **free online tool** to **merge PowerPoint presentations**? Try the [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **Merge PowerPoint files easily**: Combine multiple **PPT, PPTX, ODP** presentations into a single file.  
- **Supports different formats**: Merge **PPT to PPTX**, **PPTX to ODP**, and more.  
- **No installation required**: Works directly in your browser, fast and secure.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Start merging your PowerPoint files with **Aspose free online tool** today!  

{{% /alert %}}

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}

## **よくある質問**

**結合時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションを含むすべてのスライド要素を引き継ぎます。

**コメントとその作成者は転送されますか？**

コメントはスライドコンテンツの一部としてコピーされ、コメント作成者のラベルは結果のプレゼンテーション内のコメントオブジェクトとして保持されます。

**ソースのプレゼンテーションがパスワードで保護されている場合はどうなりますか？**

[パスワードで開く](/slides/ja/python-net/password-protected-presentation/) 必要があります。`LoadOptions.password` を使用してロードした後、そのスライドは保護されていないターゲットファイル（または保護されたファイル）に安全にクローンできます。

**結合操作はどの程度スレッドセーフですか？**

同じ [Presentation](/slides/ja/python-net/multithreading/) インスタンスを [複数のスレッド](/slides/ja/python-net/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント ‑ 1 スレッド」です。別々のファイルは別スレッドで並行処理できます。