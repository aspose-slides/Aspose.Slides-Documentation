---
title: Python でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/python-net/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- ツーコンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET 経由）でスライドレイアウトの管理とカスタマイズ方法を学びます。レイアウトの種類、プレースホルダーの制御、フッターの表示、レイアウト操作を Python のコード例で探ります。"
---

## **概要**

スライドレイアウトは、プレースホルダーボックスの配置とスライド上のコンテンツの書式設定を定義します。利用可能なプレースホルダーとその表示位置を制御します。スライドレイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPoint で最も一般的なスライドレイアウトは次のとおりです。

**Title Slide layout** – タイトル用プレースホルダーとサブタイトル用プレースホルダーの 2 つが含まれます。

**Title and Content layout** – 上部に小さなタイトルプレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメインコンテンツ用の大きなプレースホルダーが配置されます。

**Blank layout** – プレースホルダーがなく、スライドをゼロからデザインするためのフルコントロールが得られます。

スライドレイアウトはスライドマスターの一部であり、スライドマスターはプレゼンテーション全体のレイアウトスタイルを定義する最上位スライドです。スライドマスターを介してレイアウトスライドにアクセスし、タイプ、名前、または一意の ID で変更できます。あるいは、プレゼンテーション内で特定のレイアウトスライドを直接編集することも可能です。

Aspose.Slides for Python でスライドレイアウトを操作するには、次のものを使用できます。

- [Presentation] クラスの下にある [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) や [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) などのプロパティ
- [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/)、[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作方法の詳細については、[Manage PowerPoint Slide Masters in Python](/slides/ja/python-net/slide-master/) 記事をご確認ください。
{{% /alert %}}

## **スライドレイアウトをプレゼンテーションに追加する**

スライドの外観や構造をカスタマイズするために、プレゼンテーションに新しいレイアウトスライドを追加する必要がある場合があります。Aspose.Slides for Python は、特定のレイアウトが既に存在するかどうかを確認し、必要に応じて新規作成し、そのレイアウトに基づいてスライドを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/) にアクセスします。
1. コレクション内に目的のレイアウトスライドが既に存在するか確認します。存在しない場合は、必要なレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

以下の Python コードは、PowerPoint プレゼンテーションにスライドレイアウトを追加する方法を示しています:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    # レイアウトスライドの種類を順に調べて、レイアウトスライドを選択します。
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # プレゼンテーションにすべてのレイアウトタイプが含まれていない状態です。
        # プレゼンテーションファイルには Blank と Custom のレイアウトタイプだけが含まれています。
        # ただし、カスタムタイプのレイアウトスライドは認識しやすい名前が付いている場合があります、
        # 例えば "Title", "Title and Content" などで、レイアウトスライドの選択に使用できます。
        # プレースホルダー シェイプの種類に基づいて判断することもできます。
        # 例として、Title スライドは Title プレースホルダーだけを持つべきです、など。
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # 追加したレイアウトスライドを使って空のスライドを追加します。
    presentation.slides.insert_empty_slide(0, layout_slide)

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **未使用のレイアウトスライドを削除する**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスの [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) メソッドを提供し、不要で未使用のレイアウトスライドを削除できます。

以下の Python コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドレイアウトにプレースホルダーを追加する**

Aspose.Slides は、[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/) プロパティを提供し、レイアウトスライドに新しいプレースホルダーを追加できます。

このマネージャーは、次のプレースホルダータイプに対応するメソッドを含んでいます:

| PowerPoint プレースホルダー | [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) メソッド |
| --------------------------- | ------------------------------------------------------------ |
| ![コンテンツ](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![コンテンツ（縦）](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![テキスト](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![テキスト（縦）](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![画像](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![チャート](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![表](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![スマートアート](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![メディア](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![オンライン画像](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

以下の Python コードは、Blank レイアウトスライドに新しいプレースホルダーシェイプを追加する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Blank レイアウトスライドを取得します。
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # レイアウトスライドのプレースホルダーマネージャーを取得します。
    placeholder_manager = layout.placeholder_manager

    # Blank レイアウトスライドにさまざまなプレースホルダーを追加します。
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Blank レイアウトで新しいスライドを追加します。
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

## **レイアウトスライドのフッター表示を設定する**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素をレイアウトに応じて表示・非表示にできます。Aspose.Slides for Python は、これらフッタープレースホルダーの表示可否を制御できます。特定のレイアウトでフッター情報を表示し、他のレイアウトはシンプルに保ちたい場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでレイアウトスライドの参照を取得します。
1. スライドフッタープレースホルダーを表示に設定します。
1. スライド番号プレースホルダーを表示に設定します。
1. 日付時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Python コードは、スライドフッターの表示可否を設定し、関連タスクを実行する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **子スライドのフッター表示を設定する**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素をマスタースライドレベルで制御し、すべてのレイアウトスライドで一貫性を保つことができます。Aspose.Slides for Python は、マスタースライド上のフッタープレースホルダーの表示と内容を設定し、これらの設定をすべての子レイアウトスライドに伝搬させることができます。この方法により、プレゼンテーション全体で統一されたフッター情報が実現します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでマスタースライドの参照を取得します。
1. マスターとすべての子フッタープレースホルダーを表示に設定します。
1. マスターとすべての子スライド番号プレースホルダーを表示に設定します。
1. マスターとすべての子日付時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Python コードは、この操作を実演します:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドは全体的なテーマとデフォルトの書式設定を定義し、レイアウトスライドは異なるコンテンツタイプ向けにプレースホルダーの具体的な配置を定義します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい、あるプレゼンテーションの [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) コレクションからレイアウトスライドをクローンし、`add_clone` メソッドを使用して別のプレゼンテーションに挿入できます。

**使用中のスライドが参照しているレイアウトスライドを削除するとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドがまだ参照しているレイアウトスライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) をスローします。これを回避するには、[remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) を使用して、使用されていないレイアウトスライドだけを安全に削除してください。