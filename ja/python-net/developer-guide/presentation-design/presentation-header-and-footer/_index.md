---
title: Pythonでプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/python-net/presentation-header-and-footer/
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
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加およびカスタマイズし、プロフェッショナルな外観を実現します。"
---

## **概要**

Aspose.Slides for Python を使用すると、プレゼンテーション全体のヘッダーおよびフッター プレースホルダーを正確なスコープで制御できます。フッター テキスト、日付/時刻、スライド番号はマスター レベルで管理され、全体に適用することも、スライドごとに調整することもできます。ヘッダーはノートと配布資料でサポートされており、マスターノート スライドまたは個々のノート スライド上の専用ヘッダー と フッターマネージャーを使用して、可視性の切り替えやヘッダー、フッター、日付/時刻、ページ番号のテキスト設定が行えます。本記事では、これらのプレースホルダーを更新し、デッキ全体に一貫して変更を伝播させるための主要パターンを概説します。

## **ヘッダーとフッター テキストの管理**

このセクションでは、プレゼンテーション内のヘッダーとフッター コンテンツの管理方法—フッター、日付と時刻、スライド番号の有効化または変更—について学びます。設定を適用する対象のスコープ（プレゼンテーション全体、個別スライド、ノート/配布資料ビュー）を簡潔に説明し、Aspose.Slides API を使用してそれらを迅速かつ一貫して更新する方法を示します。

以下のコード例は、プレゼンテーションを開き、フッターテキストを有効化して設定し、マスターノート スライド上のヘッダーテキストを更新し、ファイルを保存します。
```py
import aspose.slides as slides

# ヘッダーテキストを設定する関数。
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# プレゼンテーションを読み込む。
with slides.Presentation("sample.pptx") as presentation:
    # フッターを設定する。
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # ヘッダーにアクセスして更新する。
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # プレゼンテーションを保存する。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **ノート スライド上のヘッダーとフッターの管理**

このセクションでは、Aspose.Slides におけるノート スライド専用のヘッダーとフッターの管理方法を学びます。関連するプレースホルダーの有効化、フッター、日付/時刻、ページ番号のテキスト設定、そしてこれらの変更をノート マスターと個々のノート ページ全体に一貫して適用する方法を取り上げます。

以下の手順に従ってください。

1. プレゼンテーション ファイルを読み込みます。  
1. マスターノート スライドとその[ヘッダーとフッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/)を取得します。  
1. マスターノート スライド上で、マスターとすべての子ノート スライドに対してヘッダー、フッター、スライド番号、日付/時刻の可視性を有効にします。  
1. マスターノート スライド上で、マスターとすべての子ノート スライドに対してヘッダー、フッター、日付/時刻のテキストを設定します。  
1. 最初のプレゼンテーション スライドのノート スライドとその[ヘッダーとフッターマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/)を取得します。  
1. この最初のノート スライドだけに対して、ヘッダー、フッター、スライド番号、日付/時刻が可視になるようにします（オフになっているものはオンにします）。  
1. この最初のノート スライドだけに対して、ヘッダー、フッター、日付/時刻のテキストを設定します。  
1. プレゼンテーションを PPTX 形式で保存します。  
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # マスターノートスライドとすべての子ヘッダー、フッター、スライド番号、日付/時刻プレースホルダーを表示します。
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # マスターノートスライドとすべての子ヘッダー、フッター、日付/時刻プレースホルダーにテキストを設定します。
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 最初のノートスライドのみのヘッダー、フッター、スライド番号、日付/時刻設定を変更します。
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # ヘッダー、フッター、スライド番号、日付/時刻プレースホルダーが表示されていることを確認します。
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # ノートスライドのヘッダー、フッター、日付/時刻プレースホルダーにテキストを設定します。
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # プレゼンテーションを保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では「ヘッダー」はノートと配布資料にのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号がサポートされる要素です。Aspose.Slides でも同じ制限が適用され、ヘッダーはノート/配布資料専用で、スライド上ではフッター/日付/時刻/スライド番号が利用可能です。

**レイアウトにフッター領域がない場合、可視化を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効化します。これらの API 指標とメソッドは、プレースホルダーが欠落または非表示の場合に対応できるよう設計されています。

**スライド番号を 1 以外の値から開始させるにはどうすればよいですか？**

プレゼンテーションの[最初のスライド番号](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/)を設定します。その後、すべての番号付けが再計算されます。たとえば 0 や 10 から開始し、タイトル スライドの番号を非表示にすることができます。

**PDF/画像/HTML にエクスポートした場合、ヘッダー/フッターはどうなりますか？**

ヘッダー/フッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノート ページ上で要素が可視であれば、出力形式でも他のコンテンツと同様に表示されます。