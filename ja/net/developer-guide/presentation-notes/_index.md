---
title: .NETでプレゼンテーションノートを管理
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---

Aspose.Slides はプレゼンテーションからノート スライドを削除することをサポートします。このトピックでは、任意のプレゼンテーションからノートを削除し、ノート スタイル スライドを追加する新機能をご紹介します。Aspose.Slides for .NET は、任意のスライドのノートを削除したり、既存のノートにスタイルを追加したりする機能を提供します。開発者は次の方法でノートを削除できます:

- プレゼンテーション内の特定のスライドのノートを削除する。
- プレゼンテーション内のすべてのスライドのノートを削除する。
## **スライドからノートを削除**
特定のスライドのノートは、以下の例のように削除できます:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 最初のスライドのノートを削除します
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// プレゼンテーションをディスクに保存します
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```



## **すべてのスライドからノートを削除**
プレゼンテーション内のすべてのスライドのノートは、以下の例のように削除できます:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します 
Presentation presentation = new Presentation("AccessSlides.pptx");

// すべてのスライドのノートを削除します
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// プレゼンテーションをディスクに保存します
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```



## **ノート スタイルを追加**
NotesStyle プロパティが [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) インターフェイスと [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) クラスにそれぞれ追加されました。このプロパティはノート テキストのスタイルを指定します。実装は以下の例で示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide のテキスト スタイルを取得
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //シンボル バレットを最初のレベルの段落に設定
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX ファイルをディスクに保存
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**
ノートはスライドのノート マネージャーを通じてアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) があり、ノート オブジェクトを返す [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) が存在します。ノートがない場合は `null` が返されます。

**Are there differences in notes support across the PowerPoint versions the library works with?**
このライブラリは Microsoft PowerPoint の幅広い形式（97 以降）および ODP を対象としており、これらの形式では PowerPoint がインストールされていなくてもノートがサポートされます。