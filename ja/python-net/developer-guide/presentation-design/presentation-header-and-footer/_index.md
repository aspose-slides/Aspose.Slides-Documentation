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

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/python-net/)は、スライドマスターレベルで実際に管理されているスライドのヘッダーとフッターテキストを操作するサポートを提供します。

{{% /alert %}} 

[Aspose.Slides for Python via .NET](/slides/ja/python-net/)は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターレベルで管理されています。
## **ヘッダーとフッターテキストを管理する**
特定のスライドの注釈を以下の例のように更新することができます：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# ヘッダー/フッターテキストを設定するメソッド
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "こんにちは新しいヘッダー"

# プレゼンテーションをロード
with slides.Presentation("combined_with_master.pptx") as pres:
    # フッターを設定
    pres.header_footer_manager.set_all_footers_text("私のフッターテキスト")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # ヘッダーにアクセスして更新
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # プレゼンテーションを保存
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **ハンドアウトとノートスライドのヘッダーとフッターを管理する**
Aspose.Slides for Python via .NETは、ハンドアウトとノートスライドのヘッダーとフッターをサポートしています。以下の手順に従ってください：

- 動画を含む[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)をロードします。
- ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示します。
- マスターノートスライドとすべての子の日時プレースホルダーを表示します。
- 最初のノートスライドのみのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日時プレースホルダーにテキストを設定します。
- 修正されたプレゼンテーションファイルを書き込みます。

コードスニペットは以下の例に示されています。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# マスターノートスライドとすべての子フッタープレースホルダーを表示
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# マスターノートスライドとすべての子のヘッダープレースホルダーにテキストを設定
		headerFooterManager.set_header_and_child_headers_text("ヘッダーテキスト") 
		headerFooterManager.set_footer_and_child_footers_text("フッターテキスト") 
		headerFooterManager.set_date_time_and_child_date_times_text("日時テキスト") 

	# 最初のノートスライドのみヘッダーとフッター設定を変更
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# ノートスライドのヘッダープレースホルダーを表示

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# ノートスライドのヘッダープレースホルダーにテキストを設定
		headerFooterManager.set_header_text("新しいヘッダーテキスト") 
		headerFooterManager.set_footer_text("新しいフッターテキスト") 
		headerFooterManager.set_date_time_text("新しい日時テキスト") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```