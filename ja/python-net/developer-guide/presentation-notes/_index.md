---
title: Python でプレゼンテーションノートを管理する
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/python-net/presentation-notes/
keywords:
- ノート
- ノートスライド
- ノートを追加
- ノートを削除
- ノートスタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーションノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させます。"
---

Aspose.Slides はプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノートスタイルスライドを追加する方法を紹介します。Aspose.Slides for Python via .NET は、任意のスライドのノートを削除したり、既存のノートにスタイルを追加したりする機能を提供します。開発者は以下の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドのノートを削除する。
- プレゼンテーション内のすべてのスライドのノートを削除する。

## **スライドからノートを削除する**
特定のスライドのノートを以下の例のように削除できます。

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **すべてのスライドからノートを削除する**
プレゼンテーション内のすべてのスライドのノートを以下の例のように削除できます。

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ノートスタイルを追加する**
NotesStyle プロパティが [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) インターフェイスと [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) クラスにそれぞれ追加されました。このプロパティはノートテキストのスタイルを指定します。実装例は以下の通りです。

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**特定のスライドのノートにアクセスできる API エンティティはどれですか？**

ノートはスライドのノートマネージャーを通じてアクセスします。スライドには [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) があり、[notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) プロパティでノートオブジェクト（ノートがない場合は `None`）を取得できます。

**ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いはありますか？**

このライブラリは Microsoft PowerPoint の幅広いフォーマット（97 以降）および ODP を対象としており、インストールされた PowerPoint の有無に関係なく、これらの形式内でノートがサポートされています。