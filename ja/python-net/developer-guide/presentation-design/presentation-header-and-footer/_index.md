---
title: Pythonでプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/python-net/developer-guide/presentation-design/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダー テキスト
- フッター
- フッター テキスト
- ヘッダーを設定
- フッターを設定
- ハンドアウト
- ノート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにヘッダーとフッターを追加・カスタマイズし、プロフェッショナルな外観を実現します。"
---

## **概要**

Aspose.Slides for Python は、プレゼンテーション全体にわたってヘッダーおよびフッタープレースホルダーを正確なスコープで制御できます。フッターテキスト、日付/時刻、スライド番号はマスターレベルで管理され、全体に適用したりスライドごとに調整したりできます。ヘッダーはノートおよびハンドアウトでサポートされており、マスターノートスライドまたは個別のノートスライド上の専用ヘッダー＆フッターマネージャーを通じて、表示のオン/オフやヘッダー、フッター、日付/時刻、ページ番号のテキスト設定が可能です。本記事では、これらのプレースホルダーを更新し、デッキ全体に一貫して変更を反映させるための主要パターンを概説します。

## **ヘッダーとフッターテキストの管理**

このセクションでは、プレゼンテーション内のヘッダーおよびフッターコンテンツの管理方法—フッター、日付/時刻、スライド番号の有効化または変更—について学びます。設定を適用するスコープ（プレゼンテーション全体、個別スライド、ノート/ハンドアウトビュー）を簡潔に説明し、Aspose.Slides API を使用して迅速かつ一貫して更新する方法を示します。

以下のコード例はプレゼンテーションを開き、フッターテキストを有効化して設定し、マスターノートスライドのヘッダーテキストを更新し、ファイルを保存します。

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ノートスライドのヘッダーとフッターの管理**

このセクションでは、Aspose.Slides におけるノートスライド専用のヘッダーとフッターの管理方法を学びます。関連プレースホルダーの有効化、フッター・日付/時刻・ページ番号のテキスト設定、およびこれらの変更をノートマスターと個々のノートページ全体に一貫して適用する方法を扱います。

以下の手順に従ってください：

1. プレゼンテーションファイルを読み込む。
2. マスターノートスライドとその[header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/) を取得する。
3. マスターノートスライドで、ヘッダー、フッター、スライド番号、日時の表示をマスターとすべての子ノートスライドに対して有効にする。
4. マスターノートスライドで、ヘッダー、フッター、日時のテキストをマスターとすべての子ノートスライドに設定する。
5. 最初のプレゼンテーションスライドのノートスライドとその[header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/) を取得する。
6. この最初のノートスライドだけで、ヘッダー、フッター、スライド番号、日時が表示されていることを確認する（オフになっているものはオンにする）。
7. この最初のノートスライドだけで、ヘッダー、フッター、日時のテキストを設定する。
8. プレゼンテーションを PPTX 形式で保存する。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートとハンドアウトにのみ存在します。通常のスライドでサポートされている要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同様の制限があり、ヘッダーはノート/ハンドアウト専用、スライド上ではフッター/日付時刻/スライド番号のみが利用可能です。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効にしてください。これらの API インジケーターとメソッドは、プレースホルダーが欠落または非表示の場合に対応できるよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの[first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) を設定します。その後、すべての番号付けが再計算されます。たとえば 0 や 10 から開始し、タイトルスライドの番号を非表示にすることも可能です。

**PDF/画像/HTML にエクスポートしたとき、ヘッダー/フッターはどうなりますか？**

エクスポート時には、ヘッダー/フッターはプレゼンテーションの通常のテキスト要素として描画されます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。