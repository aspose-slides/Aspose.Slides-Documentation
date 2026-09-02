---
title: JavaScript でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/nodejs-java/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダー テキスト
- フッター
- フッター テキスト
- ヘッダー を設定
- フッター を設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、スライド、ノートページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッターのプレースホルダーを使用します。Aspose.Slides for Node.js via Java を使用すると、ヘッダー/フッターマネージャークラスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープに依存します：

| スコープ | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | なし | あり | あり | あり |
| ノートマスター | あり | あり | あり | あり |
| ノートスライド | あり | あり | あり | あり |
| ハンドアウトマスター | あり | あり | あり | あり |

通常のプレゼンテーションスライドにはヘッダープレースホルダーがありません。ヘッダーはノートページとハンドアウトで利用できます。通常スライドでは、代わりにフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。

変更のスコープは使用するマネージャーに依存します。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideheaderfootermanager/) クラスは 1 つの通常スライドを制御します。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslideheaderfootermanager/) クラスは 1 つのノートスライドを制御します。マスターおよびレイアウトマネージャーは設定を依存スライドに伝播させることもでき、[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) クラスはハンドアウトマスターを制御します。

## **通常スライドでフッター、日付/時刻、スライド番号を設定する**

通常スライドでは、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションが自動生成するため、表示状態だけを制御すればよいです。

テキストの設定には [`setFooterText`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) と [`setDateTimeText`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) を使用し、対応するプレースホルダーの表示には [`setFooterVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) および [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) を使用します。

以下のエンドツーエンド例は、すべての通常スライドに同じフッター、日付/時刻テキスト、およびスライド番号の表示を適用します：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 枚だけ更新したい場合は、コレクション全体を反復処理する代わりに [`getSlides`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) メソッドで対象スライドに直接アクセスしてください。

## **ノートマスターでヘッダーとフッターを設定する**

ノートマスターはノートページの共通書式とプレースホルダー動作を定義します。ノートマスター自体だけを変更したい場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) クラスを使用します。

次の例はノートマスターにヘッダー、フッター、日付/時刻テキストを設定し、そのマスター上のすべてのサポート対象プレースホルダーを表示します：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

プレゼンテーションにノートマスターが含まれていない場合、[`getMasterNotesSlide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) メソッドは `null` を返します。

## **ノートマスターの設定を子ノートスライドに適用する**

ノートマスターはヘッダーとフッターの設定を自身とすべての依存ノートスライドに適用できます。同一設定をノート階層全体に適用する必要がある場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) の専用伝搬メソッドを使用します。

たとえば、[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) と [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) はノートマスターのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号向けの同等メソッドも用意されています。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上記で使用した伝搬メソッドは [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility)、および [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility) です。

## **個別ノートスライドでヘッダーとフッターを設定する**

ノートスライドは特定の通常スライドに紐づきます。そのノートページだけをカスタマイズしたい場合は、[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslideheaderfootermanager/) クラスを使用します。

[`addNotesSlide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) メソッドは現在のスライドに対応するノートスライドを返し、存在しない場合は作成します。以下の例は最初のプレゼンテーションスライドに関連付けられたノートページを構成します：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

まずノートマスターから設定を伝搬させ、次に個別ノートスライドを変更すると、後者のスライド単位設定によりそのノートページを独立してカスタマイズできます。

## **ハンドアウトマスターでヘッダーとフッターを設定する**

ハンドアウトページはヘッダー、フッター、日付/時刻、ページ番号のプレースホルダーにハンドアウトマスターを使用します。ノートページとは異なり、ハンドアウト設定は個別ハンドアウトスライドではなくハンドアウトマスターを通じて管理されます。

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) を使用してハンドアウトマスターにアクセスします。存在しない場合は [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) を呼び出してデフォルトハンドアウトマスターを作成してください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スコープと継承を理解する**

変更したいスコープに一致するヘッダー/フッターマネージャーを選択してください：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideheaderfootermanager/) は 1 つの通常スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポート対象設定を依存スライドに伝播させることができます。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslideheaderfootermanager/) は通常スライドマスターを制御し、サポート対象設定を依存スライドに伝播させます。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) はノートマスターを制御し、すべての依存ノートスライドに設定を伝搬させます。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslideheaderfootermanager/) は 1 つのノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダー プレースホルダーもサポートします。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) はハンドアウトマスターを変更し、4 つすべてのプレースホルダータイプをサポートします。

同一設定を階層全体に適用したい場合は、マスターまたはレイアウトから伝搬させます。1 ページだけのローカル設定が必要な場合は、個別スライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**通常スライドにヘッダーを追加できますか？**

いいえ。PowerPoint は通常スライド用のヘッダープレースホルダーを定義していません。通常スライドではフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。ヘッダープレースホルダーはノートページとハンドアウトで利用可能です。

**フッター、日付/時刻、またはスライド番号のプレースホルダーが表示されていない場合はどうすればよいですか？**

対応するヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効にします。たとえば、[`isFooterVisible`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) はフッタープレースホルダーの有無を報告し、[`setFooterVisibility`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) で表示状態を変更できます。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [`setFirstSlideNumber`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) メソッドを呼び出してください。これにより、スライド番号プレースホルダーは更新された番号順序を使用します。

**PDF、画像、または HTML にエクスポートする際、ヘッダーとフッターはどうなりますか？**

表示されているヘッダーおよびフッター要素は、出力形式のプレゼンテーションコンテンツと一緒にレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの表示設定に依存します。