---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/python-net/examples/elements/header-footer/
keywords:
- ヘッダー フッター
- ヘッダーとフッターを追加
- ヘッダーとフッターを更新
- 日付と時刻を設定
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python でヘッダーとフッターを制御します：日付/時刻、スライド番号、フッターテキストを追加または編集し、PPT、PPTX、ODP でプレースホルダーの表示/非表示を切り替えます。"
---
**Aspose.Slides for Python via .NET** を使用して、フッターの追加と日付と時刻のプレースホルダーの更新方法を示します。

## **フッターを追加**

スライドのフッター領域にテキストを追加し、表示できるようにします。

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **日付と時刻を更新**

スライド上の日付と時刻のプレースホルダーを変更します。

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```