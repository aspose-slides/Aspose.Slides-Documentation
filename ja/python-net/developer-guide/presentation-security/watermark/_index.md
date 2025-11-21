---
title: Python でプレゼンテーションに透かしを追加する
linktitle: 透かし
type: docs
weight: 40
url: /ja/python-net/watermark/
keywords:
- 透かし
- テキスト透かし
- 画像透かし
- 透かしの追加
- 透かしの変更
- 透かしの削除
- 透かしの削除
- PPT への透かし追加
- PPTX への透かし追加
- ODP への透かし追加
- PPT から透かしを削除
- PPTX から透かしを削除
- ODP から透かしを削除
- PPT から透かしを削除
- PPTX から透かしを削除
- ODP から透かしを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Python で PowerPoint および OpenDocument のプレゼンテーションにテキストと画像の透かしを追加し、ドラフトや機密情報、著作権表示などを示す方法を学びます。
---

## **透かしについて**

**透かし** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションがドラフトであること（例: 「Draft」透かし）や機密情報が含まれていること（例: 「Confidential」透かし）、所属企業名（例: 「Company Name」透かし）を示す、作成者を識別するなどの目的で使用されます。透かしは、コピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。透かしは PowerPoint と OpenOffice の両方のプレゼンテーション形式で使用できます。Aspose.Slides では、PowerPoint の PPT、PPTX および OpenOffice の ODP ファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/) では、PowerPoint または OpenOffice のドキュメントに透かしを作成し、そのデザインや動作を変更するさまざまな方法があります。共通点は、テキスト透かしを追加する場合は [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) クラスまたは透かしシェイプに画像を塗りつぶすことです。`PictureFrame` は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを実装しているため、シェイプオブジェクトの柔軟な設定をすべて利用できます。`TextFrame` はシェイプではなく設定が限られているため、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトにラップされています。

透かしの適用方法は 2 通りあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスターを使用すると、すべてのスライドに透かしを適用できます。透かしはスライドマスターに追加され、そこで完全にデザインされた後、個々のスライドの透かし編集権限に影響を与えることなくすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないように設定されます。透かし（正確には透かしの親シェイプ）が編集されないようにするため、Aspose.Slides はシェイプのロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスター上でロックできます。スライドマスター上で透かしシェイプがロックされている場合、すべてのプレゼンテーションスライドでロックされます。

透かしに名前を付けておくと、将来削除したい場合にスライドのシェイプ一覧から名前で検索して見つけることができます。

透かしは好きな形にデザインできますが、通常は中央揃え、回転、最前面表示などの共通の特徴があります。以下の例でこれらの使い方を紹介します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、または ODP にテキスト透かしを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスで表されます。この型は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) から継承されておらず、透かしの位置を柔軟に設定する多数のプロパティを持ちません。そのため、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) オブジェクトは [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトでラップされます。シェイプに透かしテキストを追加するには、以下のように [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) メソッドを使用します。
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="See also" %}} 
- [TextFrame クラスの使用方法](/slides/ja/python-net/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト透かしを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) に追加します。以降のロジックは単一スライドへの透かし追加と同じで、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを作成し、[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) メソッドで透かしを追加します。
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="See also" %}} 
- [スライドマスターの使用方法](/slides/ja/python-net/slide-master/)
{{% /alert %}}

### **透かしシェイプの透明度を設定する**

デフォルトでは、長方形シェイプは塗りつぶしと線の色が設定されています。次のコードでシェイプを透明にします。
```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```


### **テキスト透かしのフォントを設定する**

以下のようにテキスト透かしのフォントを変更できます。
```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```


### **透かしテキストの色を設定する**

透かしテキストの色を設定するコードは次のとおりです。
```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```


### **テキスト透かしを中央揃えにする**

透かしをスライドの中央に配置するには、次のようにします。
```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


以下の画像は最終結果を示しています。

![The text watermark](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

プレゼンテーションのスライドに画像透かしを追加するには、次の手順を実行します。
```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```


## **透かしの編集をロックする**

透かしの編集を防止する必要がある場合は、シェイプの [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) プロパティを使用します。このプロパティを使うと、シェイプの選択・サイズ変更・位置変更・他要素とのグループ化の禁止、テキスト編集のロックなど、さまざまな保護が可能です。
```py
# 透かしシェイプの変更をロックする
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```


## **透かしを最前面に持ってくる**

Aspose.Slides では、シェイプの Z 順序を [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、シェイプ参照と順序番号を渡すことで、シェイプを前面または背面に移動できます。透かしをスライドの前面に配置したい場合に特に有用です。
```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```


## **透かしの回転を設定する**

透かしをスライドの対角線上に配置するための回転設定例を以下に示します。
```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```


## **透かしに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。シェイプ名を使用すれば、将来そのシェイプにアクセスして変更または削除できます。透かしシェイプの名前を設定するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) プロパティに代入します。
```py
watermark_shape.name = "watermark"
```


## **透かしを削除する**

透かしシェイプを削除するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) でシェイプを検索し、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) メソッドに渡します。
```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```


## **ライブ例**

**Aspose.Slides 無料** のオンラインツール [Add Watermark](https://products.aspose.app/slides/watermark) と [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) をぜひお試しください。

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**透かしとは何ですか、なぜ使用すべきですか？**

透かしはスライドに重ねるテキストまたは画像で、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

**プレゼンテーションのすべてのスライドに透かしを追加できますか？**

はい、Aspose.Slides を使用すれば、プレゼンテーション内のすべてのスライドに透かしを追加できます。すべてのスライドをループし、個別に透かし設定を適用します。

**透かしの透明度はどのように調整できますか？**

シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）を変更することで、透かしの透明度を調整できます。これにより、透かしが目立ちすぎずスライド内容の妨げになりません。

**透かしに使用できる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などさまざまな画像形式をサポートしています。

**テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい、フォント、サイズ、スタイルを自由に選択してプレゼンテーションのデザインやブランドガイドラインに合わせることができます。

**透かしの位置や向きはどう変更しますか？**

シェイプ（[shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)）の座標、サイズ、回転プロパティを変更することで、透かしの位置や向きを調整できます。