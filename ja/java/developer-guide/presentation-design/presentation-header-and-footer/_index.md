---
title: Java でプレゼンテーションのヘッダーとフッターを管理
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/java/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダー設定
- フッター設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、スライド、ノートページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for Java を使用すると、これらのプレースホルダーのテキストと表示状態をヘッダー/フッターマネージャーインターフェイスで制御できます。

利用可能なプレースホルダーはスコープによって異なります。

| スコープ | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | いいえ | はい | はい | はい |
| ノートマスター | はい | はい | はい | はい |
| ノートスライド | はい | はい | はい | はい |
| 配布資料マスター | はい | はい | はい | はい |

通常のプレゼンテーションスライドにはヘッダー プレースホルダーがありません。ヘッダーはノート ページと配布資料で利用できます。通常スライドでは、代わりにフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。

変更のスコープは使用するマネージャーに依存します。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideheaderfootermanager/) インターフェイスは 1 つの通常スライドを制御します。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotesslideheaderfootermanager/) インターフェイスは 1 つのノートスライドを制御します。マスターやレイアウトのマネージャーは設定を依存スライドへ伝搬させることができ、[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) インターフェイスは配布資料マスターを制御します。

## **通常スライドでフッター、日付/時刻、スライド番号を設定**

通常スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションによって自動生成されるため、表示・非表示の制御だけが必要です。

テキストの設定には [`setFooterText`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) と [`setDateTimeText`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) を使用し、対応するプレースホルダーの表示は [`setFooterVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)、[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) で制御します。

以下のエンドツーエンド例は、すべての通常スライドに同じフッター、日付/時刻テキスト、およびスライド番号の表示を適用します：

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

1 つのスライドだけを更新する必要がある場合は、コレクション全体を反復処理する代わりに [`getSlides`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) メソッドで対象スライドに直接アクセスしてください。

## **ノートマスターでヘッダーとフッターを設定**

ノートマスターはノートページの共通書式とプレースホルダー動作を定義します。ノートマスター自体だけを変更したい場合は [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/) インターフェイスを使用します。

次の例はノートマスターにヘッダー、フッター、日付/時刻テキストを設定し、サポートされているすべてのプレースホルダーを表示します：

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

プレゼンテーションにノートマスターが含まれていない場合、[`getMasterNotesSlide`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) メソッドは `null` を返します。

## **ノートマスター設定を子ノートスライドに適用**

ノートマスターは自分自身およびすべての依存ノートスライドにヘッダーとフッターの設定を適用できます。同一設定をノート階層全体に適用する場合は [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/) の専用伝搬メソッドを使用してください。

例えば、[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) と [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) はノートマスターのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号についても同等のメソッドが用意されています。

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

上記で使用した伝搬メソッドは [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)、[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-) です。

## **個別ノートスライドでヘッダーとフッターを設定**

ノートスライドは特定の通常スライドに属します。そのノートページだけをカスタマイズしたい場合は [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotesslideheaderfootermanager/) インターフェイスを使用します。

[`addNotesSlide`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) メソッドは現在のスライドに対応するノートスライドを返し、存在しない場合は新規作成します。次の例は最初のプレゼンテーションスライドに関連付けられたノートページを構成します：

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

まずノートマスターから設定を伝搬し、その後個別ノートスライドを変更すると、後からのスライド単位の設定によりそのノートページを独立してカスタマイズできます。

## **配布資料マスターでヘッダーとフッターを設定**

配布資料ページはヘッダー、フッター、日付/時刻、ページ番号プレースホルダーに配布資料マスターを使用します。ノートページとは異なり、配布資料の設定は個々の配布資料スライドではなく配布資料マスターを通じて管理されます。

[`getMasterHandoutSlide`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) メソッドで配布資料マスターにアクセスします。存在しない場合は [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) を呼び出してデフォルトの配布資料マスターを作成してください。

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

変更したいスコープに合わせてヘッダー/フッターマネージャーを選択してください。

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideheaderfootermanager/) は 1 つの通常スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポートされている設定を依存スライドへ伝搬できます。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslideheaderfootermanager/) は通常スライドマスターを制御し、サポートされている設定を依存スライドへ伝搬できます。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslideheaderfootermanager/) はノートマスターを制御し、すべての依存ノートスライドへ設定を伝搬できます。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotesslideheaderfootermanager/) は 1 つのノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダー プレースホルダーもサポートします。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) は配布資料マスターを変更し、4 つすべてのプレースホルダータイプをサポートします。

同一設定を階層全体に適用する場合はマスターまたはレイアウトから伝搬させます。1 ページだけのローカル設定が必要なときは個別スライドまたはノートスライドマネージャーを使用してください。

## **よくある質問**

**通常スライドにヘッダーを追加できますか？**

いいえ。PowerPoint では通常スライドにヘッダー プレースホルダーは定義されていません。通常スライドではフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。ヘッダー プレースホルダーはノートページと配布資料で利用可能です。

**フッター、日付/時刻、またはスライド番号のプレースホルダーが表示されない場合はどうすればよいですか？**

対応するヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効にしてください。例えば、[`isFooterVisible`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) はフッタープレースホルダーが存在するかどうかを返し、[`setFooterVisibility`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) で表示状態を変更できます。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [`setFirstSlideNumber`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) メソッドを呼び出します。これによりスライド番号プレースホルダーは更新された番号付けシーケンスを使用します。

**PDF、画像、HTML へエクスポートした際にヘッダーとフッターはどうなりますか？**

表示されているヘッダーとフッター要素は、出力形式の他のコンテンツと同様にレンダリングされます。表示結果はエクスポート対象のページタイプと対応するプレースホルダーの表示設定に依存します。