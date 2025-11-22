---
title: Pythonでプレゼンテーションのシェイプをリサイズする
linktitle: シェイプのリサイズ
type: docs
weight: 130
url: /ja/python-net/re-sizing-shapes-on-slide/
keywords:
- シェイプをリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）を使用して、PowerPoint と OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---

## **概要**

Aspose.Slides for Python のお客様から最も頻繁に寄せられる質問のひとつは、スライドのサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、そのやり方を示します。

## **シェイプのサイズ変更**

スライドのサイズが変更されたときにシェイプがずれないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。
```py
import aspose.slides as slides

# プレゼンテーションファイルを読み込む。
with slides.Presentation("sample.pptx") as presentation:
    # 元のスライドサイズを取得する。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 既存のシェイプをスケーリングせずにスライドサイズを変更する。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 新しいスライドサイズを取得する。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # すべてのスライドでシェイプのサイズと位置を変更する。
    for slide in presentation.slides:
        for shape in slide.shapes:
            # シェイプのサイズをスケールする。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # シェイプの位置をスケールする。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合、テーブルの各セルをサイズ変更する必要があります。
{{% /alert %}} 

テーブルを含むスライドのサイズを変更するには、以下のコードを使用してください。テーブルの場合、幅や高さを設定するのは特別なケースです。テーブル全体のサイズを変更するには、個々の行の高さと列の幅を調整する必要があります。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 元のスライドサイズを取得する。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 既存のシェイプをスケーリングせずにスライドサイズを変更する。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 新しいスライドサイズを取得する。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # シェイプのサイズをスケールする。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # シェイプの位置をスケールする。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # シェイプのサイズをスケールする。
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # シェイプの位置をスケールする。
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # シェイプのサイズをスケールする。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # シェイプの位置をスケールする。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドのサイズを変更すると、シェイプはスケールが明示的に変更されない限り元の位置とサイズのままです。そのため、コンテンツが切り取られたりシェイプがずれたりすることがあります。

**提供されたコードはすべてのシェイプタイプで動作しますか？**

基本的な例はほとんどのシェイプタイプ（テキストボックス、画像、チャートなど）で動作します。ただし、テーブルの場合はセルごとのサイズで高さと幅が決まるため、行と列を個別に処理する必要があります。

**スライドのサイズ変更時にテーブルをどのようにサイズ変更すればよいですか？**

テーブルのすべての行と列をループし、2番目のコード例に示すように高さと幅を比例して変更する必要があります。

**このサイズ変更はマスタースライドやレイアウトスライドでも機能しますか？**

はい、ただし [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) と [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) もループし、同じスケーリングロジックをシェイプに適用してプレゼンテーション全体の一貫性を保つ必要があります。

**スライドの向き（縦向き/横向き）をサイズ変更と同時に変更できますか？**

はい。`presentation.slide_size.orientation` を使用して向きを変更できます。レイアウトを維持するために、スケーリングロジックをそれに合わせて設定してください。

**設定できるスライドサイズに上限はありますか？**

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を及ぼす可能性があります。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

スケーリング前にシェイプの `aspect_ratio_locked` プロパティを確認してください。ロックされている場合は、幅や高さを個別にスケールするのではなく、比例して調整します。