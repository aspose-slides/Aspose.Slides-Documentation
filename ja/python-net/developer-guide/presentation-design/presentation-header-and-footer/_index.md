---
title: Python でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/python-net/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダー テキスト
- フッター
- フッター テキスト
- ヘッダーの設定
- フッターの設定
- ハンドアウト
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、スライド、ノートページ、ハンドアウトのフッター、日付/時刻、スライド番号、ヘッダー プレースホルダーを管理する方法を学びます。"
---
## **概要**

PowerPoint はページの種類に応じて異なるヘッダーおよびフッタープレースホルダーを使用します。Aspose.Slides for Python via .NET を使用すると、ヘッダー/フッターマネージャークラスを介してこれらのプレースホルダーのテキストと表示状態を制御できます。

利用可能なプレースホルダーはスコープによって異なります。

| スコープ | ヘッダー | フッター | 日付/時刻 | スライド/ページ番号 |
|---|---|---|---|---|
| 通常スライド | いいえ | はい | はい | はい |
| ノートマスター | はい | はい | はい | はい |
| ノートスライド | はい | はい | はい | はい |
| ハンドアウトマスター | はい | はい | はい | はい |

通常のプレゼンテーションスライドにはヘッダープレースホルダーがありません。ヘッダーはノートページとハンドアウトで利用できます。通常スライドでは、代わりにフッター、日付/時刻、スライド番号プレースホルダーを使用してください。

変更のスコープは使用するマネージャーによって決まります。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slideheaderfootermanager/) クラスは1つの標準スライドを制御します。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notesslideheaderfootermanager/) クラスは1つのノートスライドを制御します。マスターおよびレイアウトマネージャーは設定を依存スライドに伝搬させることもでき、[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) クラスはハンドアウトマスターを制御します。

## **標準スライドでフッター、日付/時刻、スライド番号を設定する**

標準スライドの場合、基本的な手順は各スライドのヘッダー/フッターマネージャーにアクセスし、フッターと日付/時刻のテキストを設定し、必要なプレースホルダーを有効にしてプレゼンテーションを保存することです。スライド番号はプレゼンテーションによって自動生成されるため、表示状態だけを制御すればよいです。

[`set_footer_text`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) と [`set_date_time_text`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) を使用してテキストを設定し、[`set_footer_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), [`set_slide_number_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) を使用して対応するプレースホルダーを表示します。

以下のエンドツーエンドの例は、すべての標準スライドに同じフッター、日付/時刻テキスト、スライド番号の表示を適用します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

1枚だけスライドを更新する必要がある場合は、コレクション全体を反復するのではなく、[`slides`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) コレクションからそのスライドに直接アクセスしてください。

## **ノートマスターでヘッダーとフッターを設定する**

ノートマスターはノートページの共通書式とプレースホルダー動作を定義します。ノートマスター自体のみを変更したい場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/) クラスを使用します。

以下の例は、ノートマスターにヘッダー、フッター、日付/時刻テキストを設定し、そのマスター上ですべてのサポートされているプレースホルダーを表示可能にします。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

プレゼンテーションにノートマスターが含まれていない場合があるため、変更する前に返された値が `None` でないか確認してください。

## **ノートマスター設定を子ノートスライドに適用する**

ノートマスターはヘッダーとフッターの設定を自身とすべての依存ノートスライドに適用できます。同じ設定をノート階層全体に適用する必要がある場合は、[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/) の専用伝搬メソッドを使用してください。

たとえば、[`set_header_and_child_headers_text`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) と [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) はノートマスターのヘッダーとすべての子ヘッダーを更新します。フッター、日付/時刻、スライド番号にも同等のメソッドが用意されています。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

上記で使用した伝搬メソッドは [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/) です。

## **個別ノートスライドでヘッダーとフッターを設定する**

ノートスライドは特定の標準スライドに属します。そのノートページのみをカスタマイズしたい場合は、[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notesslideheaderfootermanager/) クラスを使用してください。

[`add_notes_slide`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notesslidemanager/add_notes_slide/) メソッドは現在のスライドに対するノートスライドを返し、存在しない場合は作成します。以下の例は、最初のプレゼンテーションスライドに関連付けられたノートページを構成します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

最初にノートマスターから設定を伝搬し、その後個別のノートスライドを変更すると、後のスライド単位の設定によりそのノートページを独立してカスタマイズできます。

## **ハンドアウトマスターでヘッダーとフッターを設定する**

ハンドアウトページはヘッダー、フッター、日付/時刻、ページ番号プレースホルダーにハンドアウトマスターを使用します。ノートページとは異なり、ハンドアウト設定は個別のハンドアウトスライドではなくハンドアウトマスターを介して管理されます。

ハンドアウトマスターにアクセスするには、[`master_handout_slide`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) プロパティを使用します。存在しない場合は、[`set_default_master_handout_slide`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) を呼び出してデフォルトのハンドアウトマスターを作成してください。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **スコープと継承を理解する**

変更したいスコープに合致するヘッダー/フッターマネージャーを選択してください。

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slideheaderfootermanager/) は1つの標準スライドのフッター、日付/時刻、スライド番号設定を変更します。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslideheaderfootermanager/) はレイアウトスライドを制御し、サポートされている設定を依存スライドに伝搬できます。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslideheaderfootermanager/) は標準スライドマスターを制御し、サポートされている設定を依存スライドに伝搬できます。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masternotesslideheaderfootermanager/) はノートマスターを制御し、すべての依存ノートスライドに設定を伝搬できます。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/notesslideheaderfootermanager/) は1つのノートスライドを変更し、フッター、日付/時刻、スライド番号に加えてヘッダープレースホルダーもサポートします。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) はハンドアウトマスターを変更し、4つのプレースホルダー全てをサポートします。

同じ設定を階層全体に適用したい場合は、マスターまたはレイアウトから伝搬を使用してください。1ページだけのローカル設定が必要な場合は、個別のスライドまたはノートスライドマネージャーを使用してください。

## **FAQ**

**標準スライドにヘッダーを追加できますか？**

いいえ。PowerPoint では標準スライド用のヘッダープレースホルダーは定義されていません。標準スライドではフッター、日付/時刻、スライド番号プレースホルダーを使用してください。ヘッダープレースホルダーはノートページとハンドアウトで利用できます。

**フッター、日付/時刻、またはスライド番号プレースホルダーが表示されていない場合はどうすればよいですか？**

対応するヘッダー/フッターマネージャーを使用して表示状態を確認し、必要に応じて有効にしてください。例として、[`is_footer_visible`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) はフッタープレースホルダーの有無を報告し、[`set_footer_visibility`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) はその表示状態を変更します。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの [`first_slide_number`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/first_slide_number/) プロパティを設定します。これによりスライド番号プレースホルダーは更新された番号付けシーケンスを使用します。

**PDF、画像、または HTML にエクスポートしたとき、ヘッダーとフッターはどうなりますか？**

表示されているヘッダーとフッター要素は、出力形式のプレゼンテーションコンテンツと共にレンダリングされます。その外観はエクスポート対象のページタイプと対応するプレースホルダーの可視設定に依存します。