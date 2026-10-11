---
title: C++でプレゼンテーションノートを管理する
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させます。"
---
## **概要**

Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートしています。このトピックでは、ノートの削除方法とプレゼンテーション内のノート スライドにスタイルを適用する方法について紹介します。Aspose.Slides を使用すると、任意のスライドからノートを削除したり、既存のノートにスタイルを適用したりできます。開発者は次の方法でノートを削除できます:

- プレゼンテーション内の特定のスライドからノートを削除する。
- プレゼンテーション内のすべてのスライドからノートを削除する。

ノート ページのサイズを読み取ったり変更したり、向きを切り替えたり、エクスポートの動作を確認するには、[ノートページサイズ](/slides/ja/cpp/notes-size/) を参照してください。

## **特定のスライドからノートを削除する**
特定のスライドからノートを削除する例を次に示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **すべてのスライドからノートを削除する**
プレゼンテーション内のすべてのスライドからノートを削除する例を次に示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **ノート スタイルを追加する**
IMasterNotesSlide インターフェイスと MasterNotesSlide クラスに NotesStyle プロパティが追加されました。このプロパティはノート テキストのスタイルを指定します。実装は以下の例で示されています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### 特定のスライドのノートにアクセスできる API エンティティはどれですか？

ノートはスライドのノート マネージャを介してアクセスします。スライドには[NotesSlideManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/notesslidemanager/) があり、ノート オブジェクト（存在しない場合は`null`）を返す[method](https://reference.aspose.com/slides/ja/cpp/aspose.slides/notesslidemanager/get_notesslide/)があります。

### ライブラリが対応する PowerPoint バージョン間でノートのサポートに違いはありますか？

ライブラリは Microsoft PowerPoint の幅広い形式（97 以降）および ODP を対象としており、インストールされた PowerPoint に依存せずこれらの形式内でノートがサポートされます。