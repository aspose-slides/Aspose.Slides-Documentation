---
title: .NET でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、スライド、ノートページ、配布資料のフッター、日付時刻、スライド番号、ヘッダープレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for .NET を使用すると、ヘッダー/フッターマネージャーインターフェイスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープによって異なります。

| スコープ | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 標準スライド | なし | あり | あり | あり |
| ノートマスタ | あり | あり | あり | あり |
| ノートスライド | すべて | すべて | すべて | すべて |
| 配布資料マスタ | すべて | すべて | すべて | すべて |

標準のプレゼンテーション スライドにはヘッダー プレースホルダーがありません。ヘッダーはノート ページと配布資料で利用できます。標準スライドでは、代わりにフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。

変更のスコープは使用するマネージャーによって決まります。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/islideheaderfootermanager/) インターフェイスは 1 つの標準スライドを制御します。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/inotesslideheaderfootermanager/) インターフェイスは 1 つのノートスライドを制御します。マスタおよびレイアウト マネージャーは設定を従属スライドに伝搬させることができ、[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslideheaderfootermanager/) インターフェイスは配布資料マスタを制御します。

## **標準スライドのフッター、日付/時刻、およびスライド番号の設定**

標準スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションによって自動生成されるため、表示状態だけを制御すればよいです。

テキストの設定には[`SetFooterText`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) と[`SetDateTimeText`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) を使用し、対応するプレースホルダーの表示は[`SetFooterVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)、[`SetDateTimeVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)、[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) で制御します。

以下のエンドツーエンドの例は、すべての標準スライドに同じフッター、日付/時刻テキスト、およびスライド番号の表示を適用します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

1 つのスライドだけを更新したい場合は、コレクション全体を走査する代わりに [`Slides`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションから対象スライドに直接アクセスしてください。

## **ノートマスタのヘッダーとフッターの設定**

ノートマスタはノートページ全体の共通書式とプレースホルダー動作を定義します。ノートマスタ自体だけを変更したいときは、[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslideheaderfootermanager/) インターフェイスを使用します。

次の例はノートマスタにヘッダー、フッター、日付/時刻テキストを設定し、サポートされているすべてのプレースホルダーを表示可能にします。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

プレゼンテーションにノートマスタが含まれていない場合、[`MasterNotesSlide`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslidemanager/masternotesslide/) プロパティは `null` を返します。

## **ノートマスタ設定の子ノートスライドへの適用**

ノートマスタはヘッダーとフッターの設定を自身とすべての従属ノートスライドに適用できます。同一設定をノート階層全体に適用する場合は、[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslideheaderfootermanager/) の専用伝搬メソッドを使用します。

たとえば、[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) と[`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) はノートマスタのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号にも同等のメソッドが用意されています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

上記で使用した伝搬メソッドは [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)、[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/) です。

## **個別ノートスライドのヘッダーとフッターの設定**

ノートスライドは特定の標準スライドに属します。そのノートページだけをカスタマイズしたい場合は、[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/inotesslideheaderfootermanager/) インターフェイスを使用してください。

[`AddNotesSlide`](https://reference.aspose.com/slides/ja/net/aspose.slides/inotesslidemanager/addnotesslide/) メソッドは現在のスライドに対するノートスライドを返し、存在しない場合は新しく作成します。次の例は最初のプレゼンテーション スライドに関連付けられたノートページを構成します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

まずノートマスタから設定を伝搬させ、次に個別ノートスライドを変更すると、後者のスライド単位設定によりそのノートページを独立してカスタマイズできます。

## **配布資料マスタのヘッダーとフッターの設定**

配布資料ページは配布資料マスタのヘッダー、フッター、日付/時刻、ページ番号プレースホルダーを使用します。ノートページとは異なり、配布資料の設定は個別の配布資料スライドではなく配布資料マスタを介して管理されます。

[`MasterHandoutSlide`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) プロパティで配布資料マスタにアクセスします。存在しない場合は、[`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) を呼び出してデフォルトの配布資料マスタを作成してください。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **スコープと継承の理解**

変更したいスコープに合わせて適切なヘッダー/フッターマネージャーを選択してください。

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/islideheaderfootermanager/) は 1 つの標準スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポートされている設定を従属スライドに伝搬できます。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslideheaderfootermanager/) は標準スライドマスタを制御し、同様に設定を従属スライドに伝搬します。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslideheaderfootermanager/) はノートマスタを制御し、すべての従属ノートスライドに設定を伝搬できます。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/inotesslideheaderfootermanager/) は 1 つのノートスライドを変更し、ヘッダープレースホルダーに加えてフッター、日付/時刻、スライド番号をサポートします。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslideheaderfootermanager/) は配布資料マスタを変更し、4 種類すべてのプレースホルダーをサポートします。

同一設定を階層全体に適用したい場合はマスタまたはレイアウトから伝搬させます。1 ページだけのローカル設定が必要なときは個別スライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**標準スライドにヘッダーを追加できますか？**

できません。PowerPoint は標準スライド用のヘッダープレースホルダーを定義していません。標準スライドではフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。ヘッダーはノートページと配布資料で利用可能です。

**フッター、日付/時刻、またはスライド番号のプレースホルダーが表示されない場合はどうすればよいですか？**

該当するヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効化します。たとえば [`IsFooterVisible`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) はフッタープレースホルダーが存在するかを返し、[`SetFooterVisibility`](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) で表示状態を変更できます。

**スライド番号を 1 以外の値から開始させるには？**

プレゼンテーションの [`FirstSlideNumber`](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/firstslidenumber/) プロパティを設定します。スライド番号プレースホルダーはこの更新された番号付けシーケンスを使用します。

**PDF、画像、HTML へエクスポートするときにヘッダーとフッターはどうなりますか？**

表示されているヘッダーとフッターの要素は、出力形式のプレゼンテーションコンテンツとともにレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの表示設定に依存します。