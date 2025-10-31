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
- ヘッダー を設定
- フッター を設定
- ハンドアウト
- ノート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET を介した Python 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加およびカスタマイズし、プロフェッショナルな外観にします。"
---

## **概要**

Aspose.Slides for Python は、プレゼンテーション全体でヘッダーとフッターのプレースホルダーを正確なスコープで制御できます。フッターテキスト、日時、スライド番号はマスターレベルで管理され、全体に適用したりスライドごとに調整したりできます。ヘッダーはノートやハンドアウトでサポートされ、マスターノートスライドまたは個々のノートスライド上の専用ヘッダー＆フッターマネージャーを使用して、表示の切り替えやヘッダー、フッター、日時、ページ番号のテキスト設定が可能です。本記事では、これらのプレースホルダーを更新し、デッキ全体に一貫して変更を伝搬させるための主要パターンを説明します。

## **ヘッダーとフッターのテキストを管理する**

このセクションでは、プレゼンテーション内のヘッダーとフッターのコンテンツを管理する方法—フッター、日時、スライド番号の有効化または変更—を学びます。設定を適用するスコープ（プレゼンテーション全体、個々のスライド、ノート/ハンドアウトビュー）を簡潔に概説し、Aspose.Slides API を使用してそれらを迅速かつ一貫して更新する方法を示します。

以下のコード例はプレゼンテーションを開き、フッターのテキストを有効化して設定し、マスターノートスライド上のヘッダーテキストを更新し、ファイルを保存します。

```py
import aspose.slides as slides

# ヘッダーテキストを設定する関数。
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# プレゼンテーションをロード。
with slides.Presentation("sample.pptx") as presentation:
    # フッターを設定。
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # ヘッダーにアクセスして更新。
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # プレゼンテーションを保存。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ノートスライドでヘッダーとフッターを管理する**

このセクションでは、Aspose.Slides におけるノートスライド専用のヘッダーとフッターの管理方法を学びます。関連プレースホルダーの有効化、フッター・日時・ページ番号のテキスト設定、そしてノートマスターと個々のノートページ全体にこれらの変更を一貫して適用する方法を取り上げます。

以下の手順に従ってください。

1. プレゼンテーションファイルをロードします。
2. マスターノートスライドとその[ヘッダーとフッターマネージャ]（https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/）を取得します。
3. マスターノートスライドで、ヘッダー、フッター、スライド番号、日時の表示をマスターとすべての子ノートスライドで有効にします。
4. マスターノートスライドで、ヘッダー、フッター、日時のテキストをマスターとすべての子ノートスライドで設定します。
5. 最初のプレゼンテーションスライドに対応するノートスライドとその[ヘッダーとフッターマネージャ]（https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/）を取得します。
6. この最初のノートスライドだけで、ヘッダー、フッター、スライド番号、日時が表示されていることを確認します（オフになっているものはオンにします）。
7. この最初のノートスライドだけで、ヘッダー、フッター、日時のテキストを設定します。
8. プレゼンテーションを PPTX 形式で保存します。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # マスターノートスライドとすべての子ヘッダー、フッター、スライド番号、日時プレースホルダーを表示可能にする。
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # マスターノートスライドとすべての子ヘッダー、フッター、日時プレースホルダーにテキストを設定。
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 最初のノートスライドだけのヘッダー、フッター、スライド番号、日時設定を変更。
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # ヘッダー、フッター、スライド番号、日時プレースホルダーが表示されていることを確認。
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # ノートスライドのヘッダー、フッター、日時プレースホルダーにテキストを設定。
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # プレゼンテーションを保存。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートとハンドアウトにのみ存在し、通常のスライドではフッター、日時、スライド番号のみがサポートされます。Aspose.Slides でも同様の制限があり、ヘッダーはノート/ハンドアウト専用で、スライド上ではフッター/日時/スライド番号が利用可能です。

**レイアウトにフッター領域がない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にします。この API の指標とメソッドは、プレースホルダーが存在しない、または非表示の場合に対応できるよう設計されています。

**スライド番号の開始番号を 1 以外にしたい場合はどうすればよいですか？**

プレゼンテーションの[first_slide_number]（https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/）を設定します。その後、すべての番号付けが再計算されます。たとえば 0 や 10 から開始したり、タイトルスライドで番号を非表示にしたりできます。

**PDF/画像/HTML にエクスポートしたとき、ヘッダー/フッターはどうなりますか？**

エクスポート時にもプレゼンテーションの通常テキスト要素として描画されます。つまり、スライドやノートページで要素が表示されていれば、出力形式でもコンテンツの一部として表示されます。