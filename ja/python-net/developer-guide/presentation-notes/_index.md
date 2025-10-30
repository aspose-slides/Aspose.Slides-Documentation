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

Aspose.Slides は、プレゼンテーションからノートスライドを削除することをサポートしています。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノートスタイルスライドを追加する機能を紹介します。Aspose.Slides for Python via .NET は、任意のスライドのノートを削除したり、既存のノートにスタイルを追加したりする機能を提供します。開発者は以下の方法でノートを削除できます:

- プレゼンテーションの特定スライドのノートを削除する。
- プレゼンテーションのすべてのスライドのノートを削除する。

## **スライドからノートを削除**

特定のスライドのノートは、以下の例のように削除できます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 最初のスライドのノートを削除します
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # プレゼンテーションをディスクに保存します
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **すべてのスライドからノートを削除**

プレゼンテーションのすべてのスライドのノートは、以下の例のように削除できます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # すべてのスライドのノートを削除します
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # プレゼンテーションをディスクに保存します
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ノートスタイルを追加**

NotesStyle プロパティが IMasterNotesSlide インターフェイスと MasterNotesSlide クラスにそれぞれ追加されました。このプロパティはノートテキストのスタイルを指定します。実装例は以下の通りです。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide のテキストスタイルを取得します
        notesStyle = notesMaster.notes_style

        # 第1レベル段落の記号バレットを設定します
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX ファイルをディスクに保存します
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**特定スライドのノートにアクセスできる API エンティティはどれですか？**

ノートはスライドの notes manager を通じてアクセスされます。スライドには NotesSlideManager があり、ノートオブジェクトを返すプロパティがあります。ノートが存在しない場合は `None` が返されます。

**ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いがありますか？**

このライブラリは Microsoft PowerPoint の幅広いフォーマット（97 以降）および ODP を対象としています。ノートはこれらのフォーマット内でサポートされており、PowerPoint がインストールされているかどうかに依存しません。