---
title: プレゼンテーション ノート
type: docs
weight: 110
url: /cpp/presentation-notes/
keywords: "PowerPoint プレゼンテーション スピーカーノート"
---


## **スライドノートの追加と削除**
Aspose.Slides は、プレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除する新しい機能と、任意のプレゼンテーションからスタイル付きノートスライドを追加する機能を紹介します。Aspose.Slides for C++ は、任意のスライドのノートを削除する機能と、既存のノートにスタイルを追加する機能を提供します。開発者は、以下の方法でノートを削除できます。

- プレゼンテーションの特定のスライドのノートを削除する。
- プレゼンテーションのすべてのスライドのノートを削除する。

## **特定のスライドからノートを削除する**
特定のスライドのノートは、以下の例のように削除することができます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **すべてのスライドからノートを削除する**
プレゼンテーションのすべてのスライドのノートは、以下の例のように削除することができます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **NotesStyleの追加**
NotesStyle プロパティが、IMasterNotesSlide インターフェースおよび MasterNotesSlide クラスに追加されました。このプロパティは、ノートテキストのスタイルを指定します。実装は以下の例で示されています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}