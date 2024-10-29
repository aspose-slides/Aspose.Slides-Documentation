---
title: プレゼンテーションノート
type: docs
weight: 110
url: /ja/net/presentation-notes/
keywords: "ノート, PowerPointノート, ノートを追加, ノートを削除, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにノートを追加および削除する"
---



Aspose.Slidesは、プレゼンテーションからノートスライドを削除することをサポートしています。このトピックでは、ノートを削除する際の新しい機能と、任意のプレゼンテーションからノートスタイルスライドを追加する機能を紹介します。Aspose.Slides for .NETは、任意のスライドのノートを削除する機能と、既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます：

- プレゼンテーションの特定のスライドのノートを削除します。
- プレゼンテーションのすべてのスライドのノートを削除します。
## **スライドからノートを削除**
特定のスライドのノートは、以下の例に示すように削除できます：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 最初のスライドのノートを削除
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// プレゼンテーションをディスクに保存
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **すべてのスライドからノートを削除**
プレゼンテーションのすべてのスライドのノートは、以下の例に示すように削除できます：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("AccessSlides.pptx");

// すべてのスライドのノートを削除
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// プレゼンテーションをディスクに保存
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **ノートスタイルの追加**
NotesStyleプロパティは、[IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide)インターフェースおよび[MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide)クラスに追加されました。このプロパティは、ノートテキストのスタイルを指定します。実装は以下の例に示されています。

```c#
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlideテキストスタイルを取得
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 最初のレベルの段落にシンボルバレットを設定
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTXファイルをディスクに保存
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```