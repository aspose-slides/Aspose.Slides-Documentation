---
title: .NET でプレゼンテーション ノートを管理する
linktitle: プレゼンテーション ノート
type: docs
weight: 110
url: /ja/net/presentation-notes/
keywords:
- ノート
- ノート スライド
- ノートを追加
- ノートを削除
- ノート スタイル
- マスター ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーション ノートをカスタマイズします。PowerPoint と OpenDocument のノートをシームレスに操作し、作業効率を向上させます。"
---
## **概要**

Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートしています。このトピックでは、この機能の概要と、ノートの削除方法およびプレゼンテーション内のノート スライドにスタイルを適用する方法を紹介します。Aspose.Slides を使用すると、任意のスライドからノートを削除したり、既存のノートにスタイルを適用したりできます。開発者は以下の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドからノートを削除する。
- プレゼンテーション内のすべてのスライドからノートを削除する。

ノート ページのサイズを読み取ったり変更したり、向きを切り替えたり、エクスポートの動作を確認するには、[ノート ページ サイズ](/slides/ja/net/notes-size/) を参照してください。

## **スライドからノートを削除**
特定のスライドのノートを削除する例を以下に示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");

// 最初のスライドのノートを削除しています
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// プレゼンテーションをディスクに保存します
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **すべてのスライドからノートを削除**
プレゼンテーションのすべてのスライドからノートを削除する例を以下に示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");

// すべてのスライドのノートを削除しています
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// プレゼンテーションをディスクに保存します
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **ノートのスタイルを追加**
NotesStyle プロパティが [IMasterNotesSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslide) インターフェイスおよび [MasterNotesSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslide) クラスに追加されました。このプロパティはノート テキストのスタイルを指定します。実装例は以下のとおりです。

```c#
using Aspose.Slides;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide のテキストスタイルを取得します
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 第1レベルの段落にシンボル箇条書きを設定します
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX ファイルをディスクに保存します
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **よくある質問**

### 特定のスライドのノートにアクセスできる API エンティティはどれですか？

ノートはスライドのノート マネージャーを通じてアクセスされます。スライドには [NotesSlideManager](https://reference.aspose.com/slides/ja/net/aspose.slides/notesslidemanager/) があり、ノート オブジェクトを返す [property](https://reference.aspose.com/slides/ja/net/aspose.slides/notesslidemanager/notesslide/) があります。ノートが存在しない場合は `null` が返されます。

### ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いはありますか？

このライブラリは Microsoft PowerPoint の幅広いフォーマット（97 以降）および ODP を対象としており、インストールされた PowerPoint の有無に関係なく、これらのフォーマット内でノートがサポートされます。