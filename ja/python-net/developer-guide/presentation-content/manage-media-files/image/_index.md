---
title: Python を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/python-net/image/
keywords:
- 画像を追加
- ピクチャーを追加
- 画像を置き換える
- 画像コレクション
- ピクチャーフレーム
- リンク画像
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- SVG をシェイプに変換
- 外部 SVG リソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションでラスター画像および SVG 画像を追加、再利用、リンク、置き換え、管理する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Python via .NET は、画像を扱うためのさまざまな方法を提供し、それぞれが異なる目的に使用されます。画像をプレゼンテーションに格納したり、ピクチャーフレームで表示したり、スライドの背景として使用したり、外部画像へのリンクを設定したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能なシェイプに変換したりできます。

この記事では画像リソースとそれらがプレゼンテーション全体でどのように使用されるかに焦点を当てます。個別のピクチャーフレームに適用されるクロップ、透過、エフェクト、伸縮、その他の書式設定については、[ピクチャーフレーム](/slides/ja/python-net/picture-frame/) を参照してください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、互換性はありません。

- [プレゼンテーション画像コレクション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) は、プレゼンテーションで使用される画像リソースを格納します。画像データを追加し、[IPPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/) リソースを取得するには、[ImageCollection.add_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/add_image/) を使用します。
- [ピクチャーフレーム](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipictureframe/) は、スライド、レイアウト、またはマスタ上に画像を表示するシェイプです。画像リソースをスライド上に配置するには、[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) を使用します。
- スライドの背景は、シェイプではなくスライドの塗りの一部として画像を使用します。そのため、ピクチャーフレームのようには振る舞いません。
- [IPPImage.replace_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/replace_image/) は画像リソースを置き換えます。複数のプレゼンテーション要素がそのリソースを使用している場合、すべてが置き換え後の画像を使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後は、コンテンツは単一の画像リソースとしては管理されなくなります。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[IPPImage] を受け取り、そのリソースを 1 つ以上のピクチャーフレームまたは塗りに使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み取り、そのデータを画像コレクションに追加し、返された `IPPImage` を使用するピクチャーフレームを作成します。

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、元の画像ファイルが利用できなくても結果のファイルは問題なく動作します。

### **Web から画像を追加**

画像が HTTP または HTTPS 経由で取得可能な場合、バイト列をダウンロードし、プレゼンテーション画像コレクションに追加し、ローカル画像と同様に返された画像リソースを使用します。

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

長時間実行するアプリケーションでは、リクエストごとに新しい接続を作成するのではなく、適切に HTTP クライアントまたは接続プールを再利用してください。また、信頼できないソースの場合は、リモート URL、レスポンスサイズ、コンテンツタイプを検証することが重要です。

## **スライド間で画像を再利用**

同じ画像を複数回使用する必要がある場合は、プレゼンテーションに一度だけ画像を追加し、追加のピクチャーフレームを作成するときに返された [IPPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/) を再利用します。これにより同一ソースデータの繰り返し読み込みが防止され、共有画像リソースとその使用箇所との関係が明示的になります。

多くのスライドで自動的に表示すべきロゴなどのグラフィックは、各スライドに同等のシェイプを追加する代わりに、[スライドマスター](/slides/ja/python-net/slide-master/) またはレイアウト上にピクチャーフレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像はスライドの塗りに割り当てられ、ピクチャーフレームのシェイプとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されない場合に便利です。

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

マスタやレイアウトの背景オプションを含む詳細は、[プレゼンテーション背景](/slides/ja/python-net/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は、可搬性とファイルサイズの面で異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内に格納されます。プレゼンテーションは自己完結型になりますが、ファイルサイズに画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。これによりプレゼンテーションのサイズは削減できますが、外部リソースが開くまたはレンダリング時にアクセス可能である必要があります。

外部パスまたは URL を埋め込まずに設定するには、[ISlidesPicture.link_path_long](https://reference.aspose.com/slides/ja/python-net/aspose.slides/islidespicture/link_path_long/) を使用してリンク画像を作成します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

外部リソースに確実にアクセスできるデプロイ環境でのみリンク画像を使用してください。オフラインでも動作させる必要がある、またはシステム間で移動させるプレゼンテーションでは、埋め込み画像の方が安全です。

## **SVG 画像の取り扱い**

SVG はベクターフォーマットであり、アイコンや図表など、ラスタ画像と比べて詳細を失わずに拡大縮小できるグラフィックに適しています。Aspose.Slides は SVG を画像リソースとして、また編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) を作成し、画像コレクションに追加して、結果の画像リソースをピクチャーフレームに配置します。

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は、SVG を編集可能なスライドシェイプのグループに変換できます。これは PowerPoint の対応コマンドと同等です。

![PowerPoint Popup Menu](img_01_01.png)

[ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_group_shape/) のオーバーロードで、[ISvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/isvgimage/) を受け取って変換を実行します。

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

SVG の個々のベクター要素を PowerPoint のシェイプとして編集する必要がある場合に、SVG からシェイプへの変換を使用してください。表示だけでよい場合は、画像として保持する方がシンプルで、複数のシェイプを生成する手間が省けます。

## **既存の画像リソースを置き換える**

[IPPImage.replace_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/replace_image/) を使用すると、既存の画像リソースを置き換えることができます。ロゴなどの共有グラフィックを差し替える際に特に便利です。

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

複数のピクチャーフレーム、背景、マスタ、レイアウトが同じ画像リソースを使用している場合、リソースを置き換えるだけでそれらすべての表示が更新されます。1 つのピクチャーフレームだけを変更したい場合は、共有リソースを置き換えるのではなく、そのフレームに別の画像を割り当ててください。

`replace_image` には、[IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) または別の [IPPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/) を受け取るオーバーロードも用意されています。

## **実践的な画像管理ガイダンス**

### **プレゼンテーションサイズの制御**

大きなラスタ画像はプレゼンテーションを不必要に肥大化させます。表示目的に適した解像度のソース画像を使用し、可能な限り共有画像リソースを再利用し、同一の高解像度画像を埋め込みで繰り返さないようにしてください。

既にピクチャーフレームに配置されているラスタ画像については、[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/compress_image/) を使用して、選択された解像度およびクロップ設定に基づき画像データを圧縮できます。これは画像コレクションの管理ではなくピクチャーフレームの処理なので、関連する書式操作については[ピクチャーフレーム](/slides/ja/python-net/picture-frame/) を参照してください。

### **埋め込みコンテンツとリンクコンテンツの選択**

埋め込みはすべての画像データがファイルに同梱されるため、プレゼンテーションの可搬性が高まります。リンクはファイルサイズを削減できますが、外部依存が発生します。外部依存が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴ、透かし、装飾グラフィックなど繰り返し使用する画像は、1 つの画像リソースにまとめて再利用します。これらのグラフィックがスライドコンテンツではなくデザイン要素である場合は、マスタまたはレイアウトに配置して、対象スライドに継承させると効果的です。

### **SVG リソースの可搬性維持**

自己完結型の SVG は、外部ファイルやネットワークリソースに依存しないため、移動や一貫したレンダリングが容易です。可能な限り必要なリソースを埋め込んでから SVG をインポートし、個々のベクター要素を編集する必要があるときだけシェイプへの変換を検討してください。

### **最新のクロスプラットフォーム画像 API の使用**

新規の Python via .NET コードでは、非推奨の `aspose.pydrawing.Image` や `aspose.pydrawing.Bitmap` の代わりに、Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) および [Images](https://reference.aspose.com/slides/ja/python-net/aspose.slides/images/) API を使用してください。移行ガイダンスは[モダン API](/slides/ja/python-net/modern-api/) を参照してください。

WMF と EMF は特別な考慮が必要です。これらの形式が [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を介して渡された場合、[ImageCollection.add_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/add_image/) はメタファイルをラスタ PNG に変換して挿入します。メタファイルデータを保持したい場合は、ストリームベースの [ImageCollection.add_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/add_image/) オーバーロードを使用してください。スプレッドシートなどから EMF コンテンツを生成することは別途の統合ワークフローであり、本記事の範囲外です。

## **FAQ**

**画像コレクションとピクチャーフレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを格納します。ピクチャーフレームはそのリソースのうちの 1 つを表示し、クロップやエフェクトなど画像固有の書式設定を提供するスライドシェイプです。

**ロゴを全スライドで同じように置き換える最良の方法は何ですか？**

ロゴが既に 1 つの画像リソースとして共有されている場合は、[IPPImage.replace_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ippimage/replace_image/) でそのリソースを置き換えます。プレゼンテーション全体のブランディングの場合は、ロゴをマスタまたはレイアウトに配置すると、スライドごとの重複を減らすことができます。

**リンク画像が別のコンピュータで消えてしまうのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。そのリソースにアクセスできない環境でプレゼンテーションを開くと、リンク画像は表示されません。自己完結型が必要な場合は画像を埋め込んでください。

**挿入した SVG は PowerPoint のシェイプとして編集できますか？**

はい。[ShapeCollection.add_group_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_group_shape/) を使用して SVG を変換すると、結果のグループは SVG 画像ではなく編集可能なスライドシェイプで構成されます。

**画像が多数あるプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不要に大きなラスタソースを避け、適切な場合はラスタ画像を圧縮し、繰り返し使用するブランディングはマスタやレイアウトに配置し、外部依存が許容できるときだけリンク画像を使用してください。