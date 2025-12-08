---
title: プレゼンテーション ノート
type: docs
weight: 110
url: /ja/net/presentation-notes/
keywords: "ノート、PowerPoint ノート、ノートを追加、ノートを削除、PowerPoint プレゼンテーション、C#、Csharp、Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションのノートを追加および削除します"
---

Aspose.Slides はプレゼンテーションからノート スライドを削除することをサポートします。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノート スタイル スライドを追加する方法をご紹介します。Aspose.Slides for .NET は、任意のスライドのノートを削除し、既存のノートにスタイルを追加する機能を提供します。開発者は次の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドのノートを削除する。
- プレゼンテーション内のすべてのスライドのノートを削除する。

## **Remove Notes from Slide**
特定のスライドのノートは、以下の例のように削除できます。
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 最初のスライドのノートを削除します
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// プレゼンテーションをディスクに保存します
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Remove Notes from All Slides**
プレゼンテーション内のすべてのスライドのノートは、以下の例のように削除できます。
```c#
 // Instantiate a Presentation object that represents a presentation file 
 Presentation presentation = new Presentation("AccessSlides.pptx");

// Removing notes of all slides
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Save presentation to disk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Add NotesStyle**
NotesStyle プロパティが [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) インターフェイスおよび [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) クラスにそれぞれ追加されました。このプロパティはノート テキストのスタイルを指定します。実装は以下の例で示されています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide のテキストスタイルを取得します
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 最初のレベルの段落にシンボル箇条書き設定します
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX ファイルをディスクに保存します
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

ノートはスライドのノート マネージャーを介してアクセスできます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) があり、ノート オブジェクトを返す [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) が提供されます。ノートが存在しない場合は `null` が返されます。

**Are there differences in notes support across the PowerPoint versions the library works with?**

このライブラリは Microsoft PowerPoint の広範なフォーマット（97 以降）および ODP を対象としており、インストールされた PowerPoint に依存せずにこれらのフォーマット内でノートがサポートされます。