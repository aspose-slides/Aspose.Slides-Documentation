---
title: PHPでプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/php-java/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダー テキスト
- フッター
- フッター テキスト
- ヘッダーを設定
- フッターを設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、スライド、ノートページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーの管理方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for PHP via Java を使用すると、ヘッダー/フッターマネージャークラスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープに依存します：

| スコープ | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | いいえ | はい | はい | はい |
| ノートマスター | はい | はい | はい | はい |
| ノートスライド | はい | はい | はい | はい |
| 配布資料マスター | はい | はい | はい | はい |

通常のプレゼンテーションスライドにはヘッダープレースホルダーがありません。ヘッダーはノートページと配布資料で利用できます。通常のスライドでは、代わりにフッター、日付/時刻、スライド番号プレースホルダーを使用してください。

変更のスコープは使用するマネージャーによって決まります。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideheaderfootermanager/) クラスは1つの通常スライドを制御します。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslideheaderfootermanager/) クラスは1つのノートスライドを制御します。マスターおよびレイアウトマネージャーは設定を依存スライドへ伝搬させることもでき、[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) クラスは配布資料マスターを制御します。

## **通常スライドでフッター、日付/時刻、スライド番号を設定する**

通常スライドでは、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションによって生成されるため、表示/非表示の制御だけが必要です。

テキストを設定するには [`setFooterText`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) と [`setDateTimeText`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) を使用し、対応するプレースホルダーを表示するには [`setFooterVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) を使用します。

以下のエンドツーエンド例は、すべての通常スライドに同じフッター、日付/時刻テキスト、およびスライド番号の表示を適用します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

特定のスライドだけを更新する必要がある場合は、コレクション全体を反復処理する代わりに、[`getSlides`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getslides/) メソッドでそのスライドに直接アクセスしてください。

## **ノートマスターでヘッダーとフッターを設定する**

ノートマスターはノートページの共通フォーマットとプレースホルダーの動作を定義します。ノートマスター自体だけを変更したい場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/) クラスを使用します。

以下の例は、ノートマスターにヘッダー、フッター、日付/時刻テキストを設定し、そのマスター上のすべてのサポートされているプレースホルダーを表示可能にします：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[`getMasterNotesSlide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) メソッドは、プレゼンテーションにノートマスターが含まれていない場合 `null` を返します。

## **ノートマスター設定を子ノートスライドに適用する**

ノートマスターはヘッダーおよびフッター設定を自身とすべての依存ノートスライドに適用できます。同一設定をノート階層全体に適用する必要がある場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/) の専用伝搬メソッドを使用してください。

例として、[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) と [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) はノートマスターのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号に対しても同等のメソッドが用意されています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

上記で使用した伝搬メソッドは [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/) です。

## **個別ノートスライドでヘッダーとフッターを設定する**

ノートスライドは特定の通常スライドに属します。そのノートページだけをカスタマイズしたい場合は、[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslideheaderfootermanager/) クラスを使用してください。

[`addNotesSlide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslidemanager/addnotesslide/) メソッドは現在のスライドに対するノートスライドを返し、存在しない場合は新たに作成します。以下の例は、最初のプレゼンテーションスライドに関連付けられたノートページを構成します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

まずノートマスターから設定を伝搬し、次に個別のノートスライドを変更すると、後のスライド単位の設定によりそのノートページを個別にカスタマイズできます。

## **配布資料マスターでヘッダーとフッターを設定する**

配布資料ページはヘッダー、フッター、日付/時刻、ページ番号プレースホルダーに handout master を使用します。ノートページとは異なり、配布資料の設定は個別の配布資料スライドではなく handout master を通じて管理されます。

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) メソッドで handout master にアクセスします。存在しない場合は、[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) を呼び出してデフォルトの handout master を作成してください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **スコープと継承を理解する**

変更したいスコープに合わせたヘッダー/フッターマネージャーを選択してください：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideheaderfootermanager/) は1つの通常スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポートされている設定を依存スライドに伝搬できます。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslideheaderfootermanager/) は通常スライドのマスターを制御し、サポートされている設定を依存スライドに伝搬できます。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslideheaderfootermanager/) はノートマスターを制御し、すべての依存ノートスライドに設定を伝搬できます。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslideheaderfootermanager/) は1つのノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダープレースホルダーもサポートします。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) は配布資料マスターを変更し、4つすべてのプレースホルダータイプをサポートします。

同一設定を階層全体に適用したい場合は、マスターまたはレイアウトから伝搬させてください。1ページだけにローカル設定が必要な場合は、個別のスライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**通常のスライドにヘッダーを追加できますか？**

いいえ。PowerPoint は通常のスライドにヘッダープレースホルダーを定義していません。通常のスライドでは、フッター、日付/時刻、スライド番号プレースホルダーを使用してください。ヘッダープレースホルダーはノートページと配布資料で利用可能です。

**フッター、日付/時刻、またはスライド番号のプレースホルダーが表示されていない場合はどうすればよいですか？**

該当するヘッダー/フッターマネージャーを使用して表示状態を確認し、必要に応じて有効化してください。例として、[`isFooterVisible`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) はフッタープレースホルダーが存在するかを報告し、[`setFooterVisibility`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) はその表示状態を変更します。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [`setFirstSlideNumber`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/setfirstslidenumber/) メソッドを呼び出してください。その後、スライド番号プレースホルダーは更新された番号シーケンスを使用します。

**PDF、画像、または HTML にエクスポートする際、ヘッダーとフッターはどうなりますか？**

表示されているヘッダーおよびフッター要素は、出力フォーマットでプレゼンテーションの他のコンテンツと同様にレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの表示設定に依存します。