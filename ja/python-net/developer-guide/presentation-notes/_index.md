---
title: Pythonでプレゼンテーションノートを管理
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/python-net/presentation-notes/
keywords:
- ノート
- ノートスライド
- ノートの追加
- ノートの削除
- ノートスタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーションノートをカスタマイズします。PowerPoint と OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---

Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートします。このトピックでは、ノートを削除し、任意のプレゼンテーションにノート スタイル スライドを追加する新機能をご紹介します。Aspose.Slides for Python via .NET は、任意のスライドのノートを削除し、既存のノートにスタイルを追加する機能を提供します。開発者は次の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドのノートを削除する。
- プレゼンテーション内のすべてのスライドのノートを削除する。

## **スライドからノートを削除**
特定のスライドのノートは、以下の例のように削除できます。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 最初のスライドのノートを削除します
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # プレゼンテーションをディスクに保存します
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **すべてのスライドからノートを削除**
プレゼンテーション内のすべてのスライドのノートは、以下の例のように削除できます。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # すべてのスライドのノートを削除します
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # プレゼンテーションをディスクに保存します
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **NotesStyle を追加**
[notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/) プロパティが [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) クラスに追加されました。このプロパティはノート テキストのスタイルを指定します。実装は以下の例で示しています。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide のテキスト スタイルを取得します
        notesStyle = notesMaster.notes_style

        #Set 最初のレベルの段落にシンボル箇条書きを設定します
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX ファイルをディスクに保存します
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**特定のスライドのノートへアクセスできる API エンティティはどれですか？**

ノートはスライドのノート マネージャーからアクセスします。スライドは [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) を持ち、[property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) がノート オブジェクトを返します（ノートがない場合は `None` が返ります）。

**ライブラリがサポートする PowerPoint バージョン間でノートのサポートに違いはありますか？**

このライブラリは Microsoft PowerPoint の幅広い形式（97 以降）および ODP を対象としており、これらの形式内でノートは PowerPoint がインストールされていなくてもサポートされます。