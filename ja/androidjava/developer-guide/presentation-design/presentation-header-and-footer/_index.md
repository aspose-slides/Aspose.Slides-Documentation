---
title: Android でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/androidjava/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダーを設定
- フッターを設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、スライド、ノートページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダープレースホルダーの管理方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for Android via Java を使用すると、ヘッダー/フッターマネージャー インターフェイスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用できるプレースホルダーはスコープによって異なります:

| 範囲 | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 標準スライド | いいえ | はい | はい | はい |
| ノートマスタ | はい | はい | はい | はい |
| ノートスライド | はい | はい | はい | はい |
| ハンドアウトマスタ | はい | はい | はい | はい |

標準のプレゼンテーションスライドにはヘッダープレースホルダーがありません。ヘッダーはノートページとハンドアウトで利用可能です。標準スライドでは、フッター、日付/時刻、スライド番号プレースホルダーを使用してください。

変更のスコープは使用するマネージャーによって決まります。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islideheaderfootermanager/) インターフェイスは 1 つの標準スライドを制御します。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) インターフェイスは 1 つのノートスライドを制御します。マスタおよびレイアウトマネージャーは設定を依存スライドに伝播させることができ、[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) インターフェイスはハンドアウトマスタを制御します。

## **標準スライドでフッター、日付/時刻、スライド番号を設定する**

標準スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションが自動生成するため、表示状態のみを制御すればよいです。

テキストの設定には [`setFooterText`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) と [`setDateTimeText`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) を使用し、プレースホルダーの表示は [`setFooterVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)、[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) で制御します。

以下のエンドツーエンド例は、すべての標準スライドに同じフッター、日付/時刻テキスト、スライド番号の表示設定を適用します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つのスライドだけを更新したい場合は、コレクション全体を走査する代わりに [`getSlides`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlides--) メソッドで対象スライドに直接アクセスしてください。

## **ノートマスタでヘッダーとフッターを設定する**

ノートマスタはノートページの共通書式とプレースホルダーの動作を定義します。ノートマスタ自体だけを変更したい場合は [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) インターフェイスを使用します。

以下の例はノートマスタにヘッダー、フッター、日付/時刻テキストを設定し、そのマスタでサポートされているすべてのプレースホルダーを表示可能にします:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

プレゼンテーションにノートマスタが含まれていない場合、[`getMasterNotesSlide`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) メソッドは `null` を返します。

## **ノートマスタ設定を子ノートスライドに適用する**

ノートマスタは自分自身とすべての依存ノートスライドにヘッダーとフッターの設定を適用できます。同一設定をノート階層全体に適用する場合は、[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) の専用伝搬メソッドを使用します。

たとえば、[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) と [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) はノートマスタのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号にも同等のメソッドがあります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上記で使用した伝搬メソッドは [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)、[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-) です。

## **個別ノートスライドでヘッダーとフッターを設定する**

ノートスライドは特定の標準スライドに属します。そのノートページだけをカスタマイズしたい場合は、[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) インターフェイスを使用します。

[`addNotesSlide`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) メソッドは現在のスライドに対するノートスライドを返し、存在しない場合は作成します。以下の例は最初のプレゼンテーションスライドに関連付けられたノートページを設定します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最初にノートマスタから設定を伝搬し、その後個別ノートスライドを変更すると、後者のスライド固有設定でそのノートページを独立してカスタマイズできます。

## **ハンドアウトマスタでヘッダーとフッターを設定する**

ハンドアウトページはハンドアウトマスタのヘッダー、フッター、日付/時刻、ページ番号プレースホルダーを使用します。ノートページとは異なり、ハンドアウト設定は個々のハンドアウトスライドではなくハンドアウトマスタを介して管理されます。

ハンドアウトマスタにアクセスするには [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) メソッドを使用します。存在しない場合は、[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) を呼び出してデフォルトのハンドアウトマスタを作成してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スコープと継承を理解する**

変更したいスコープに合ったヘッダー/フッターマネージャーを選択してください。

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islideheaderfootermanager/) は 1 つの標準スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポートされている設定を依存スライドに伝搬できます。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) は標準スライドマスタを制御し、同様に設定を伝搬できます。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) はノートマスタを制御し、すべての依存ノートスライドに設定を伝搬します。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) は 1 つのノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダープレースホルダーもサポートします。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) はハンドアウトマスタを変更し、4 種類すべてのプレースホルダーをサポートします。

同一設定を階層全体に適用したい場合はマスタまたはレイアウトから伝搬させます。特定のページだけローカル設定が必要な場合は個別スライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**標準スライドにヘッダーを追加できますか？**

いいえ。PowerPoint は標準スライド用のヘッダープレースホルダーを定義していません。標準スライドではフッター、日付/時刻、スライド番号プレースホルダーを使用してください。ヘッダープレースホルダーはノートページとハンドアウトで利用可能です。

**フッター、日付/時刻、またはスライド番号プレースホルダーが表示されない場合はどうすればよいですか？**

該当するヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にしてください。例えば、[`isFooterVisible`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) はフッタープレースホルダーの有無を報告し、[`setFooterVisibility`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) で可視性を変更できます。

**スライド番号を 1 以外の値から開始させるには？**

プレゼンテーションの [`setFirstSlideNumber`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) メソッドを呼び出します。これによりスライド番号プレースホルダーは更新された連番を使用します。

**PDF、画像、HTML にエクスポートしたとき、ヘッダーやフッターはどうなりますか？**

表示されているヘッダーおよびフッター要素は、他のプレゼンテーションコンテンツと同様に出力形式にレンダリングされます。外観はエクスポート対象のページタイプと対応するプレースホルダーの可視性設定に依存します。