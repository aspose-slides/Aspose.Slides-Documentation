---
title: C++でプレゼンテーションノートを管理する
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションノートをカスタマイズします。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---

## **スライドノートの追加と削除**
Aspose.Slidesはプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノートスタイルスライドを追加する方法を紹介します。Aspose.Slides for C++は、任意のスライドのノートを削除したり、既存のノートにスタイルを付与したりする機能を提供します。開発者は以下の方法でノートを削除できます。

- プレゼンテーション内の特定のスライドのノートを削除する。
- プレゼンテーション内のすべてのスライドのノートを削除する。

## **特定のスライドからノートを削除**
特定のスライドのノートを削除する例を以下に示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **すべてのスライドからノートを削除**
プレゼンテーション内のすべてのスライドのノートを削除する例を以下に示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **ノートのスタイルを追加**
NotesStyleプロパティがIMasterNotesSlideインターフェイスとMasterNotesSlideクラスに追加されました。このプロパティはノートテキストのスタイルを指定します。実装は以下の例で示されています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**特定のスライドのノートにアクセスできるAPIエンティティはどれですか？**

ノートはスライドのノートマネージャを介してアクセスします。スライドには[NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/)があり、ノートオブジェクト（存在しない場合は`null`）を返す[method](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/)があります。

**ライブラリが対応するPowerPointバージョン間でノートサポートに違いはありますか？**

ライブラリはMicrosoft PowerPoint形式（97〜以降）とODPの広範な範囲を対象としており、これらの形式内でノートはサポートされ、PowerPointがインストールされているかどうかに依存しません。