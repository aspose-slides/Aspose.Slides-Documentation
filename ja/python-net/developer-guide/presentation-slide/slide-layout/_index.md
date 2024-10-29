---
title: スライドレイアウト
type: docs
weight: 60
url: /ja/python-net/slide-layout/
keyword: "スライドサイズの設定、スライドオプションの設定、スライドサイズの指定、フッターの可視性、子フッター、コンテンツのスケーリング、ページサイズ、Python、Aspose.Slides"
description: "PythonでPowerPointスライドのサイズとオプションを設定する"
---

スライドレイアウトは、スライド上に表示されるすべてのコンテンツのためのプレースホルダーボックスとフォーマット情報を含んでいます。レイアウトは、利用可能なコンテンツプレースホルダーとそれらが配置される場所を決定します。

スライドレイアウトを使用すると、プレゼンテーションを迅速に作成およびデザインできます（シンプルなものでも複雑なものでも）。これらは、PowerPointプレゼンテーションで使用される最も人気のあるスライドレイアウトのいくつかです：

* **タイトルスライドレイアウト**。このレイアウトは、2つのテキストプレースホルダーで構成されています。1つはタイトル用、もう1つはサブタイトル用です。
* **タイトルとコンテンツレイアウト**。このレイアウトには、上部に比較的小さなプレースホルダーがタイトル用に、コアコンテンツ（グラフ、段落、箇条書き、番号付きリスト、画像など）用に大きなプレースホルダーがあります。
* **空白レイアウト**。このレイアウトにはプレースホルダーがないため、ゼロから要素を作成することができます。

スライドマスターは、スライドレイアウトに関する情報を保存する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、それらを変更することができます。レイアウトスライドには、タイプまたは名前でアクセスできます。同様に、すべてのスライドには一意のIDがあり、それを使用してアクセスできます。

あるいは、プレゼンテーション内の特定のスライドレイアウトに直接変更を加えることもできます。

* スライドレイアウト（マスタースライド内のものを含む）を操作できるように、Aspose.Slidesは[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスの下で`layout_slides`や`masters`のようなプロパティを提供しています。
* 関連タスクを実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/)など、多くの他のタイプを提供しています。

{{% alert title="情報" color="info" %}}

特にマスタースライドの操作に関する詳細は、[スライドマスター](https://docs.aspose.com/slides/python-net/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを確認して、必要なレイアウトスライドがLayout Slideコレクションにすでに存在するかどうかを確認します。そうでなければ、追加したいレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このPythonコードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成する
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # レイアウトスライドタイプを通過する
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # プレゼンテーションがいくつかのレイアウトタイプを含まない状況。
        # プレゼンテーションファイルは空白とカスタムレイアウトタイプのみを含む。
        # しかし、カスタムタイプのレイアウトスライドには異なるスライド名があり、
        # "タイトル"、"タイトルとコンテンツ"などの名前をレイアウトスライドの選択に使用できます。
        # プレースホルダー形状タイプのセットを使用することもできます。例えば、
        # タイトルスライドはタイトルプレースホルダータイプのみを持つべきです、など。
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Title and Object":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Title":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # 追加されたレイアウトスライドで空のスライドを追加する
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # プレゼンテーションをディスクに保存する
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **未使用のレイアウトスライドを削除する**

Aspose.Slidesは、不要で未使用のレイアウトスライドを削除するための[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)クラスから`remove_unused_layout_slides`メソッドを提供しています。このPythonコードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドレイアウトのサイズとタイプを設定する**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスから`type`および`size`プロパティを提供します。このPythonは、その操作を示しています：

```python
import aspose.slides as slides

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する 
# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # 生成されるプレゼンテーションのスライドサイズをソースのものに設定する
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # プレゼンテーションをディスクに保存する
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **スライド内のフッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します。
1. スライドフッタープレースホルダーを可視化します。
1. 日付と時刻のプレースホルダーを可視化します。
1. プレゼンテーションを保存します。

このPythonコードは、スライドフッターの可視性を設定する方法を示しています（および関連するタスクを実行します）：

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # property is_footer_visible は、スライドフッタープレースホルダーが不足していることを指定するために使用されます
    if not headerFooterManager.is_footer_visible: 
        # メソッド set_footer_visibility は、スライドフッタープレースホルダーを可視化するために使用されます
        headerFooterManager.set_footer_visibility(True) 
        # property is_slide_number_visible は、スライドページ番号プレースホルダーが不足していることを指定するために使用されます
    if not headerFooterManager.is_slide_number_visible:  
        # メソッド set_slide_number_visibility は、スライドページ番号プレースホルダーを可視化するために使用されます
        headerFooterManager.set_slide_number_visibility(True) 
        # property is_date_time_visible は、スライド日付と時刻プレースホルダーが不足していることを指定するために使用されます
    if not headerFooterManager.is_date_time_visible: 
        # メソッド set_date_time_visibility は、スライド日付と時刻プレースホルダーを可視化するために使用されます 
        headerFooterManager.set_date_time_visibility(True)

    # メソッド set_footer_text は、スライドフッタープレースホルダーにテキストを設定するために使用されます 
    headerFooterManager.set_footer_text("フッターテキスト") 
    # メソッド set_date_time_text は、スライド日付と時刻プレースホルダーにテキストを設定するために使用されます。
    headerFooterManager.set_date_time_text("日付と時刻のテキスト") 

    # プレゼンテーションをディスクに保存する
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **スライド内の子フッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介してマスタースライドの参照を取得します。 
1. マスタースライドとすべての子フッタープレースホルダーを可視化します。
1. マスタースライドとすべての子フッタープレースホルダーにテキストを設定します。 
1. マスタースライドとすべての子日時プレースホルダーにテキストを設定します。 
1. プレゼンテーションを保存します。

このPythonコードは、その操作を示しています：

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # メソッド set_footer_and_child_footers_visibility は、マスタースライドとすべての子フッタープレースホルダーを可視化するために使用されます
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # メソッド set_slide_number_and_child_slide_numbers_visibility は、マスタースライドとすべての子ページ番号プレースホルダーを可視化するために使用されます
    manager.set_date_time_and_child_date_times_visibility(True) # メソッド set_date_time_and_child_date_times_visibility は、マスタースライドとすべての子日時プレースホルダーを可視化するために使用されます

    manager.set_footer_and_child_footers_text("フッターテキスト") # メソッド set_footer_and_child_footers_text は、マスタースライドとすべての子フッタープレースホルダーのテキストを設定するために使用されます
    manager.set_date_time_and_child_date_times_text("日付と時刻のテキスト") # メソッド set_date_time_and_child_date_times_text は、マスタースライドとすべての子日時プレースホルダーのテキストを設定するために使用されます
```

## **コンテンツスケーリングに関するスライドサイズを設定する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、サイズを設定したいスライドを含むプレゼンテーションを読み込みます。
1. 新しいプレゼンテーションを生成するために別の[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介して（最初のプレゼンテーションから）スライドの参照を取得します。
1. スライドフッタープレースホルダーを可視化します。 
1. 日付と時刻のプレースホルダーを可視化します。 
1. プレゼンテーションを保存します。 

このPythonは、その操作を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # 生成されるプレゼンテーションのスライドサイズをソースのものに設定する
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # メソッド set_size は、コンテンツに合わせてフィットすることを保証するためにスライドサイズを設定するために使用されます
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # メソッド set_size は、最大コンテンツサイズでスライドサイズを設定するために使用されます
                
        # プレゼンテーションをディスクに保存する
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **PDF生成時のページサイズを設定する**

特定のプレゼンテーション（ポスターのようなもの）は、しばしばPDFドキュメントに変換されます。PowerPointをPDFに変換してベストな印刷およびアクセシビリティオプションにアクセスしたい場合、PDFドキュメントに適したサイズ（たとえばA4）にスライドを設定する必要があります。

Aspose.Slidesは、[SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/)クラスを提供し、スライドの希望設定を指定できるようにします。このPythonコードは、プレゼンテーション内のスライドに特定の用紙サイズを設定するために`type`プロパティを使用する方法を示します：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する  
with slides.Presentation() as presentation:
    # SlideSize.Typeプロパティを設定する 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # PDFオプションの異なるプロパティを設定する
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # プレゼンテーションをディスクに保存する
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```