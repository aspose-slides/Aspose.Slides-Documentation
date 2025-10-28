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
- フッターテキスト
- ヘッダー設定
- フッター設定
- ハンドアウト
- ノート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションにヘッダーとフッターを追加・カスタマイズし、プロフェッショナルな外観にします。"
---

## **概要**

Aspose.Slides for Python を使用すると、プレゼンテーション全体のヘッダーとフッター プレースホルダーを正確なスコープで制御できます。フッターテキスト、日付/時刻、スライド番号はマスターレベルで管理され、全体に適用することも、スライドごとに調整することも可能です。ヘッダーはノートとハンドアウトでサポートされており、マスターノート スライドまたは個別のノート スライド上の専用ヘッダー & フッターマネージャーを介して、表示の切り替えやヘッダー、フッター、日付/時刻、ページ番号のテキスト設定が行えます。本記事では、これらのプレースホルダーを更新し、デッキ全体に一貫して変更を反映させるための主要パターンを概説します。

## **ヘッダーとフッターテキストの管理**

このセクションでは、プレゼンテーション内のヘッダーとフッター コンテンツの管理方法—フッター、日付と時刻、スライド番号の有効化または変更—について学びます。設定を適用するスコープ（プレゼンテーション全体、個別スライド、ノート/ハンドアウト ビュー）を簡潔に説明し、Aspose.Slides API を使用してそれらを迅速かつ一貫して更新する方法を示します。

以下のコード例は、プレゼンテーションを開き、フッターテキストを有効化して設定し、マスターノート スライド上のヘッダーテキストを更新し、ファイルを保存します。

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

## **ノート スライド上のヘッダーとフッターの管理**

このセクションでは、Aspose.Slides におけるノート スライド専用のヘッダーとフッターの管理方法を学びます。対象プレースホルダーの有効化、フッター、日付/時刻、ページ番号のテキスト設定、そしてこれらの変更をノートマスターと個々のノートページ全体に一貫して適用する方法を取り上げます。

以下の手順に従ってください。

1. プレゼンテーション ファイルを読み込む。  
1. マスターノート スライドとその[ヘッダー & フッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/)を取得する。  
1. マスターノート スライド上で、ヘッダー、フッター、スライド番号、日付/時刻の表示をマスターとすべての子ノート スライドで有効にする。  
1. マスターノート スライド上で、ヘッダー、フッター、日付/時刻のテキストをマスターとすべての子ノート スライドで設定する。  
1. 最初のプレゼンテーション スライドのノート スライドとその[ヘッダー & フッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/)を取得する。  
1. この最初のノート スライドだけについて、ヘッダー、フッター、スライド番号、日付/時刻が表示されていることを確認する（オフの場合はオンにする）。  
1. この最初のノート スライドだけについて、ヘッダー、フッター、日付/時刻のテキストを設定する。  
1. プレゼンテーションを PPTX 形式で保存する。

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

## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートとハンドアウトにのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号がサポートされます。Aspose.Slides でも同様の制限があり、ヘッダーはノート/ハンドアウト専用、スライド上ではフッター/日付時刻/スライド番号のみです。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効化してください。この API の指標とメソッドは、プレースホルダーが存在しないまたは非表示の場合に対応できるよう設計されています。

**スライド番号を 1 以外の値から開始したい場合はどうすればよいですか？**

プレゼンテーションの[最初のスライド番号](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/)を設定します。これにより、以降のすべての番号が再計算されます。たとえば 0 や 10 から開始し、タイトルスライドの番号を非表示にすることもできます。

**PDF/画像/HTML にエクスポートしたとき、ヘッダー/フッターはどうなりますか？**

エクスポート先でもプレゼンテーションの通常のテキスト要素として描画されます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。