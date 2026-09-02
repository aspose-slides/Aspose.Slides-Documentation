---
title: C++ でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/cpp/presentation-header-and-footer/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、スライド、ノートページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for C++ は、ヘッダー/フッターマネージャー インターフェイスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープによって異なります:

| 範囲 | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | なし | あり | あり | あり |
| ノートマスター | あり | あり | あり | あり |
| ノートスライド | あり | あり | あり | あり |
| 配布資料マスター | あり | あり | あり | あり |

通常のプレゼンテーション スライドにはヘッダー プレースホルダーがありません。ヘッダーはノートページと配布資料で利用可能です。通常スライドでは、フッター、日付/時刻、スライド番号のプレースホルダーを使用してください。

変更のスコープは使用するマネージャーによって決まります。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideheaderfootermanager/) インターフェイスは 1 枚の通常スライドを制御します。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslideheaderfootermanager/) インターフェイスは 1 枚のノートスライドを制御します。マスターおよびレイアウト マネージャーは設定を依存スライドに伝搬させることができ、[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) インターフェイスは配布資料マスターを制御します。

## **通常スライドのフッター、日付/時刻、スライド番号の設定**

通常スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションが自動的に生成するため、表示状態のみを制御すればよいです。

テキストの設定には [`SetFooterText`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) と [`SetDateTimeText`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) を使用し、対応するプレースホルダーの表示は [`SetFooterVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/)、[`SetDateTimeVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/)、[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) で制御します。

以下のエンドツーエンド例は、すべての通常スライドに同じフッター、日付/時刻テキスト、スライド番号の表示を適用します:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

1 枚だけ更新したい場合は、スライドコレクション全体を列挙する代わりに [`Presentation::get_Slide`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slide/) で対象スライドに直接アクセスしてください。

## **ノートマスターのヘッダーとフッターの設定**

ノートマスターはノートページ全体の書式設定とプレースホルダーの動作を定義します。ノートマスター自体のみを変更したい場合は、[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/) インターフェイスを使用します。

次の例はノートマスターにヘッダー、フッター、日付/時刻テキストを設定し、そのマスター上のすべてのサポート対象プレースホルダーを表示可能にします:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

ノートマスターが存在しないプレゼンテーションの場合、[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) は `nullptr` を返します。

## **ノートマスター設定の子ノートスライドへの適用**

ノートマスターは自身およびすべての依存ノートスライドにヘッダーとフッターの設定を適用できます。ノート階層全体に同じ設定を適用する場合は、[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/) の専用伝搬メソッドを使用してください。

例えば、[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) と [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) はノートマスターのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号についても同様のメソッドが用意されています。

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

上記で使用した伝搬メソッドは [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)、[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/) です。

## **個別ノートスライドのヘッダーとフッターの設定**

ノートスライドは特定の通常スライドに紐づきます。そのノートページだけをカスタマイズしたい場合は、[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslideheaderfootermanager/) インターフェイスを使用してください。

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslidemanager/addnotesslide/) メソッドは現在のスライドに対するノートスライドを返し、存在しない場合は作成します。次の例は最初のプレゼンテーション スライドに関連付けられたノートページを構成します:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

まずノートマスターから設定を伝搬させ、その後個別ノートスライドを変更すると、後者のスライド固有設定でそのノートページを独立してカスタマイズできます。

## **配布資料マスターのヘッダーとフッターの設定**

配布資料ページはヘッダー、フッター、日付/時刻、ページ番号プレースホルダーに配布資料マスターを使用します。ノートページとは異なり、配布資料の設定は個別スライドではなく配布資料マスターを介して管理されます。

配布資料マスターにアクセスするには [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) を使用します。存在しない場合は [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) を呼び出してデフォルトの配布資料マスターを作成してください。

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **スコープと継承の理解**

変更したいスコープに合ったヘッダー/フッターマネージャーを選択してください:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islideheaderfootermanager/) は 1 枚の通常スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポート対象設定を依存スライドに伝搬できます。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslideheaderfootermanager/) は通常スライドマスターを制御し、サポート対象設定を依存スライドに伝搬できます。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslideheaderfootermanager/) はノートマスターを制御し、すべての依存ノートスライドに設定を伝搬できます。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslideheaderfootermanager/) は 1 枚のノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダー プレースホルダーもサポートします。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) は配布資料マスターを変更し、4 つのプレースホルダーすべてをサポートします。

同じ設定を階層全体に適用したい場合は、マスターまたはレイアウトから伝搬させます。1 ページだけローカル設定が必要な場合は、個別スライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**通常スライドにヘッダーを追加できますか？**

いいえ。PowerPoint は通常スライドにヘッダー プレースホルダーを定義していません。通常スライドではフッター、日付/時刻、スライド番号プレースホルダーを使用してください。ヘッダー プレースホルダーはノートページと配布資料で利用可能です。

**フッター、日付/時刻、またはスライド番号プレースホルダーが表示されない場合はどうすればよいですか？**

対応するヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にします。たとえば、[`get_IsFooterVisible`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) はフッタープレースホルダーの有無を示し、[`SetFooterVisibility`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) で可視性を変更できます。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

[`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/set_firstslidenumber/) を使用して最初のスライド番号を設定します。その後、スライド番号プレースホルダーは更新された番号付けシーケンスを使用します。

**PDF、画像、HTML へエクスポートした際にヘッダーとフッターはどうなりますか？**

表示されているヘッダーとフッター要素は、出力形式のプレゼンテーション コンテンツと共にレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの可視性設定に依存します。