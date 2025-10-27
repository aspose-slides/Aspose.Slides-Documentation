---
title: Python でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/python-net/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダーの設定
- フッターの設定
- 配布資料
- ノート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加およびカスタマイズし、プロフェッショナルな外観を実現します。"
---

## **概要**

Aspose.Slides for Python を使用すると、プレゼンテーション全体にわたってヘッダーおよびフッタープレースホルダーを正確なスコープで制御できます。フッターテキスト、日付/時刻、スライド番号はマスターレベルで管理され、全体に適用したりスライドごとに調整したりできます。ヘッダーはノートおよび配布資料でサポートされ、マスターノートスライドまたは個々のノートスライド上の専用ヘッダー＆フッターマネージャーを使用して、表示の切り替えやヘッダー、フッター、日付/時刻、ページ番号のテキスト設定が可能です。本稿では、これらのプレースホルダーを更新し、デッキ全体に一貫して変更を反映させるための主要パターンを概説します。

## **ヘッダーとフッターテキストの管理**

このセクションでは、プレゼンテーション内のヘッダーおよびフッターコンテンツの管理方法—フッター、日付と時刻、スライド番号の有効化または変更—について学びます。設定の適用スコープ（プレゼンテーション全体、個々のスライド、ノート/配布資料ビュー）を簡潔に説明し、Aspose.Slides API を使用してそれらを迅速かつ一貫して更新する方法を示します。

以下のコード例は、プレゼンテーションを開き、フッターテキストを有効化して設定し、マスターノートスライド上のヘッダーテキストを更新し、ファイルを保存します。

```py
import aspose.slides as slides

# ヘッダーのテキストを設定する関数。
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# プレゼンテーションを読み込む。
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

## **ノートスライド上のヘッダーとフッターの管理**

このセクションでは、Aspose.Slides においてノートスライド専用のヘッダーとフッターを管理する方法を学びます。対象プレースホルダーの有効化、フッター・日付/時刻・ページ番号のテキスト設定、およびこれらの変更をノートマスターと個々のノートページ全体に一貫して適用する手順を解説します。

以下の手順に従ってください。

1. プレゼンテーション ファイルを読み込む。  
1. マスターノートスライドとその[ヘッダー＆フッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/)を取得する。  
1. マスターノートスライド上で、ヘッダー、フッター、スライド番号、日付/時刻の表示をマスターとすべての子ノートスライドで有効にする。  
1. マスターノートスライド上で、ヘッダー、フッター、日付/時刻のテキストをマスターとすべての子ノートスライドで設定する。  
1. 最初のプレゼンテーション スライドに対応するノートスライドとその[ヘッダー＆フッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/)を取得する。  
1. この最初のノートスライドだけで、ヘッダー、フッター、スライド番号、日付/時刻が表示されていることを確認する（オフになっているものはオンにする）。  
1. この最初のノートスライドだけで、ヘッダー、フッター、日付/時刻のテキストを設定する。  
1. プレゼンテーションを PPTX 形式で保存する。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # マスターノートスライドとすべての子ヘッダー、フッター、スライド番号、日付/時刻プレースホルダーを表示可能にする。
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # マスターノートスライドとすべての子ヘッダー、フッター、日付/時刻プレースホルダーにテキストを設定する。
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 最初のノートスライドだけのヘッダー、フッター、スライド番号、日付/時刻設定を変更する。
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # ヘッダー、フッター、スライド番号、日付/時刻プレースホルダーが表示されていることを保証する。
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # ノートスライドのヘッダー、フッター、日付/時刻プレースホルダーにテキストを設定する。
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # プレゼンテーションを保存。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートと配布資料にのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号がサポートされます。Aspose.Slides でも同様の制限があり、ヘッダーはノート/配布資料専用、スライド上ではフッター・日付/時刻・スライド番号が利用可能です。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー／フッターマネージャーで可視性を確認し、必要に応じて有効化してください。これらの API インジケータとメソッドは、プレースホルダーが存在しないか非表示の場合に備えて設計されています。

**スライド番号を 1 以外の値から開始したい場合はどうすればよいですか？**

プレゼンテーションの[最初のスライド番号](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/)を設定します。その後、すべての番号付けが再計算されます。たとえば 0 や 10 から開始し、タイトルスライドの番号を非表示にすることも可能です。

**PDF/画像/HTML にエクスポートした際、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページ上で要素が表示されていれば、出力フォーマットでも他のコンテンツと同様に表示されます。