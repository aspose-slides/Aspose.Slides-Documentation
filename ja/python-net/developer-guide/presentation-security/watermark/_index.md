---
title: Pythonでプレゼンテーションに透かしを追加する
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
- PPTへの透かし追加
- PPTXへの透かし追加
- ODPへの透かし追加
- PPTからの透かし削除
- PPTXからの透かし削除
- ODPからの透かし削除
- PPTから透かしを削除
- PPTXから透かしを削除
- ODPから透かしを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PythonでPowerPointおよびOpenDocumentプレゼンテーションにテキストと画像の透かしを管理し、ドラフト、機密情報、著作権表示などを示す方法を学びます。"
---

## **透かしについて**

**透かし**は、スライド全体またはすべてのスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションがドラフト（例:「Draft」透かし）であることや機密情報を含むこと（例:「Confidential」透かし）を示したり、どの企業に属するか（例:「Company Name」透かし）を示したり、作成者を特定したりするために使用されます。透かしは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防止する助けにもなります。透かしはPowerPointとOpenOfficeの両方のプレゼンテーション形式で使用できます。Aspose.Slidesでは、PowerPoint PPT、PPTX、OpenOffice ODPファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/) では、PowerPoint や OpenOffice ドキュメントに透かしを作成し、そのデザインや動作を変更するさまざまな方法が用意されています。共通点として、テキスト透かしを追加する場合は [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) クラスまたは透かしシェイプに画像を塗りつぶす方法があります。`PictureFrame` は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを実装しているため、シェイプオブジェクトの柔軟な設定をすべて利用できます。`TextFrame` はシェイプではなく設定が限定的なため、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトにラップされます。

透かしの適用方法は 2 通りあります。単一スライドに適用するか、すべてのスライドに適用するかです。すべてのスライドに透かしを適用するにはスライドマスタを使用します。透かしはスライドマスタに追加され、そこで完全にデザインされ、個々のスライドの透かし編集権限に影響を与えることなくすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないように設定されます。透かし（正確には透かしの親シェイプ）が編集されないようにするため、Aspose.Slides はシェイプロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスタ上でロックできます。スライドマスタ上で透かしシェイプがロックされると、すべてのプレゼンテーションスライドでロックされます。

透かしに名前を付けておくと、将来削除したい場合にスライドのシェイプ一覧から名前で検索して見つけやすくなります。

透かしは任意のデザインで作成できますが、通常は中央揃え、回転、最前面表示などの共通特徴があります。以下のサンプルでこれらの使い方を説明します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、ODP にテキスト透かしを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを付加します。テキストフレームは [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスで表されます。この型は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) から継承されていないため、柔軟な位置指定プロパティが不足しています。そのため、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) オブジェクトは [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトにラップされます。テキスト透かしをシェイプに追加するには、以下のように [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) メソッドを使用します。

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

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) に追加します。以降のロジックは単一スライドに透かしを追加する場合と同じです。まず [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを作成し、[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) メソッドで透かしテキストを追加します。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [スライドマスタの使用方法](/slides/ja/python-net/slide-master/)
{{% /alert %}}

### **透かしシェイプの透明度を設定する**

デフォルトでは矩形シェイプに塗りつぶしと線色が設定されています。以下のコードでシェイプを透明にします。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **テキスト透かしのフォントを設定する**

テキスト透かしのフォントは次のように変更できます。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **透かしテキストの色を設定する**

透かしテキストの色を設定するには、次のコードを使用します。

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **テキスト透かしを中央に配置する**

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

以下の画像が最終結果です。

![テキスト透かし](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

スライドに画像透かしを追加するには、次のようにします。

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **透かしの編集ロック**

透かしの編集を防止したい場合は、シェイプの [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) プロパティを使用します。このプロパティにより、シェイプの選択、サイズ変更、位置変更、グループ化、テキスト編集ロックなどが可能です。

```py
# 透かしシェイプの変更をロック
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **透かしを最前面に持ってくる**

Aspose.Slides では、シェイプの Z オーダーを [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) メソッドで設定できます。プレゼンテーションのスライドリストからこのメソッドを呼び出し、シェイプ参照と順序番号を渡します。これにより、シェイプを最前面または最背面に移動できます。透かしをスライドの手前に配置したい場合に便利です。

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **透かしの回転を設定する**

以下は、透かしをスライドの対角線上に配置するために回転角度を調整するコード例です。

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **透かしに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。名前を付けておけば、将来そのシェイプを検索・変更・削除しやすくなります。透かしシェイプに名前を設定するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) プロパティに代入します。

```py
watermark_shape.name = "watermark"
```

## **透かしの削除**

透かしシェイプを削除するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) で名前を検索し、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) で削除します。

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **ライブ例**

**Aspose.Slides 無料** のオンラインツール **[Add Watermark](https://products.aspose.app/slides/watermark)** と **[Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark)** を試してみてください。

![透かしの追加・削除ツール](online_tools.png)

## **FAQ**

**透かしとは何ですか？また、なぜ使用すべきですか？**

透かしはスライドに重ねるテキストまたは画像で、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

**プレゼンテーション全体に透かしを追加できますか？**

はい、Aspose.Slides を使用すれば、プレゼンテーションのすべてのスライドに透かしを追加できます。すべてのスライドをループして個別に設定することも可能です。

**透かしの透明度はどのように調整しますか？**

シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）を変更することで、透かしの透明度を調整できます。これにより、透かしが控えめになり、スライドの内容を邪魔しません。

**透かしに使用できる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG など様々な画像形式をサポートしています。

**テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい、好きなフォント、サイズ、スタイルを選択してプレゼンテーションのデザインやブランドガイドラインに合わせることができます。

**透かしの位置や向きはどう変更しますか？**

シェイプの座標、サイズ、回転プロパティ（[shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)）を変更することで、透かしの位置や向きを調整できます。