---
title: "Python via Javaでプレゼンテーションのヘッダーとフッターを管理"
linktitle: "ヘッダーとフッター"
type: docs
weight: 140
url: /ja/python-java/presentation-header-and-footer/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、スライド、ノート ページ、配布資料のフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページ タイプに応じて異なるヘッダーおよびフッター プレースホルダーを使用します。Aspose.Slides for Python via Java を使用すると、ヘッダー/フッター マネージャー クラスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープによって異なります。

| 範囲 | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | いいえ | はい | はい | はい |
| ノート マスタ | はい | はい | はい | はい |
| ノート スライド | はい | はい | はい | はい |
| 配布資料 マスタ | はい | はい | はい | はい |

通常のプレゼンテーション スライドにはヘッダー プレースホルダーがありません。ヘッダーはノート ページと配布資料で使用できます。通常スライドでは、代わりにフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。

変更のスコープは使用するマネージャーに依存します。[SlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideheaderfootermanager/) クラスは単一の通常スライドを制御します。[NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notesslideheaderfootermanager/) クラスは単一のノート スライドを制御します。マスタおよびレイアウト マネージャーは設定を依存スライドに伝搬させることができ、[MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) クラスは配布資料マスタを制御します。

## **通常スライドでフッター、日付/時刻、スライド番号を設定**

通常スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効化してプレゼンテーションを保存することです。スライド番号はプレゼンテーションが自動生成するため、表示の制御だけが必要です。

テキストの設定には [setFooterText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) と [setDateTimeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) を使用し、表示の切り替えには [setFooterVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)、[setDateTimeVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility)、[setSlideNumberVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) を使用します。

以下のエンドツーエンド例は、すべての通常スライドに同じフッター、日付/時刻テキスト、およびスライド番号の表示を適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

1 つのスライドだけを更新したい場合は、コレクション全体を反復処理する代わりに [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) メソッドで対象スライドに直接アクセスしてください。

## **ノート マスタでヘッダーとフッターを設定**

ノート マスタはノート ページの共通書式とプレースホルダー動作を定義します。ノート マスタ自体だけを変更したい場合は、[MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/) クラスを使用します。

以下の例はノート マスタにヘッダー、フッター、日付/時刻テキストを設定し、そのマスタ上のサポート対象プレースホルダーすべてを表示可能にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`getMasterNotesSlide` メソッドは、プレゼンテーションにノート マスタが含まれていない場合に `None` を返します。

## **ノート マスタ設定を子ノート スライドに適用**

ノート マスタは自身とすべての依存ノート スライドにヘッダーとフッター設定を伝搬できます。ノート階層全体で同一設定を適用する場合は、[MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/) の専用伝搬メソッドを使用してください。

たとえば、[setHeaderAndChildHeadersText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) と [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) はノート マスタのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号についても同等のメソッドが用意されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上記で使用した伝搬メソッドは [setFooterAndChildFootersText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)、[setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)、[setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)、[setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility)、[setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility) です。

## **個別ノート スライドでヘッダーとフッターを設定**

ノート スライドは特定の通常スライドに属します。そのノート ページだけをカスタマイズしたい場合は、[NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notesslideheaderfootermanager/) クラスを使用します。

[addNotesSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notesslidemanager/#addNotesSlide) メソッドは現在のスライドに対するノート スライドを返し、存在しない場合は作成します。以下の例は最初のプレゼンテーション スライドに関連付けられたノート ページを構成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

まずノート マスタから設定を伝搬し、その後個別ノート スライドを変更すると、後者のスライド固有設定によりそのノート ページを独立してカスタマイズできます。

## **配布資料 マスタでヘッダーとフッターを設定**

配布資料ページは配布資料マスタのヘッダー、フッター、日付/時刻、ページ番号プレースホルダーを使用します。ノート ページとは異なり、配布資料の設定は個別配布資料スライドではなく配布資料マスタを通じて管理されます。

`getMasterHandoutSlide` メソッドで配布資料マスタにアクセスし、存在しない場合は `setDefaultMasterHandoutSlide` を呼び出してデフォルトの配布資料マスタを作成してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スコープと継承を理解する**

変更したいスコープに合ったヘッダー/フッターマネージャーを選択してください。

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideheaderfootermanager/) は単一の通常スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslideheaderfootermanager/) はレイアウト スライドを制御し、サポートされる設定を依存スライドに伝搬できます。
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslideheaderfootermanager/) は通常スライド マスタを制御し、サポートされる設定を依存スライドに伝搬できます。
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslideheaderfootermanager/) はノート マスタを制御し、すべての依存ノート スライドに設定を伝搬できます。
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notesslideheaderfootermanager/) は単一のノート スライドを変更し、ヘッダー プレースホルダーに加えてフッター、日付/時刻、スライド番号をサポートします。
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) は配布資料マスタを変更し、4 つのプレースホルダーすべてをサポートします。

同一設定を階層全体に適用したい場合は、マスタまたはレイアウトから伝搬させます。1 ページだけのローカル設定が必要な場合は、個別スライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**通常スライドにヘッダーを追加できますか？**

いいえ。PowerPoint は通常スライド用のヘッダー プレースホルダーを定義していません。通常スライドではフッター、日付/時刻、スライド番号のプレースホルダーを使用してください。ヘッダー プレースホルダーはノート ページと配布資料で利用可能です。

**フッター、日付/時刻、またはスライド番号のプレースホルダーが表示されない場合はどうすればよいですか？**

該当するヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効化します。たとえば、[isFooterVisible](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) はフッター プレースホルダーの有無を返し、[setFooterVisibility](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) で可視性を変更できます。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [setFirstSlideNumber](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#setFirstSlideNumber) メソッドを呼び出します。その後、スライド番号プレースホルダーは更新された番号付けシーケンスを使用します。

**PDF、画像、HTML にエクスポートしたとき、ヘッダーとフッターはどうなりますか？**

表示されているヘッダーおよびフッター要素は、出力形式のプレゼンテーション コンテンツと一緒にレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの可視性設定に依存します。