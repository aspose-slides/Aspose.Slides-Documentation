---
title: Python でプレゼンテーションに透かしを追加する
linktitle: 透かし
type: docs
weight: 40
url: /ja/python-net/developer-guide/presentation-security/watermark/
keywords:
- 透かし
- テキスト透かし
- 画像透かし
- 透かしを追加
- 透かしを変更
- 透かしを削除
- 透かしを削除
- PPT に透かしを追加
- PPTX に透かしを追加
- ODP に透かしを追加
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
description: "Python で PowerPoint および OpenDocument のプレゼンテーションにテキストや画像の透かしを管理し、ドラフト、機密情報、著作権表示などを示す方法を学びます。"
---

## **透かしについて**

**透かし** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションがドラフトであること（例: 「Draft」透かし）や機密情報を含んでいること（例: 「Confidential」透かし）を示したり、所属企業名（例: 「Company Name」透かし）や作成者を明示したりするために使用されます。透かしは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防止する助けにもなります。透かしは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用されます。Aspose.Slides では、PowerPoint の PPT、PPTX、OpenOffice の ODP ファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/) では、PowerPoint または OpenOffice 文書に透かしを作成し、デザインや動作を変更するさまざまな方法が用意されています。共通点として、テキスト透かしを追加する場合は [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) クラスまたは透かしシェイプに画像を設定します。`PictureFrame` は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスを実装しているため、シェイプオブジェクトの柔軟な設定をすべて利用できます。`TextFrame` はシェイプではなく設定が限定的なため、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトにラップされます。

透かしの適用方法は 2 つあります。単一スライドに対して適用するか、プレゼンテーション全体のスライドに対して適用するかです。スライドマスターを使用すると、透かしをすべてのスライドに適用できます。透かしはスライドマスターに追加され、そこで完全にデザインされ、個々のスライドの透かし編集権限に影響を与えずにすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないように設定されます。透かし（正確には透かしの親シェイプ）が編集されないようにするために、Aspose.Slides はシェイプのロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスター上でロックできます。スライドマスター上で透かしシェイプがロックされている場合、すべてのプレゼンテーションスライドでロックが適用されます。

透かしに名前を付けておけば、将来削除したいときにスライドのシェイプ一覧から名前で検索して見つけやすくなります。

透かしのデザインは自由にできますが、中心揃え、回転、前面表示などの共通の特徴があります。以下の例でこれらの使い方を説明します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、ODP にテキスト透かしを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスで表されます。このクラスは [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) から継承されていないため、柔軟な位置設定プロパティがありません。そのため、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) オブジェクトは [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトにラップされます。シェイプに透かしテキストを追加するには、以下のように `add_text_frame` メソッドを使用します。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="関連項目" %}} 
- [TextFrame クラスの使用方法](/slides/ja/python-net/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト透かしを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) に追加します。単一スライドに追加するロジックと同様に、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを作成し、`add_text_frame` メソッドで透かしを追加します。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="関連項目" %}} 
- [スライドマスターの使用方法](/slides/ja/python-net/slide-master/)
{{% /alert %}}

### **透かしシェイプの透明度を設定する**

デフォルトでは矩形シェイプは塗りつぶしと線の色が設定されています。次のコードでシェイプを透明にします。

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

スライド上で透かしを中央に配置するには、次のようにします。

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

以下の画像に最終結果が示されています。

![テキスト透かし](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

プレゼンテーションスライドに画像透かしを追加するには、次のようにします。

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **透かしの編集ロック**

透かしの編集を防止する必要がある場合は、シェイプの [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) プロパティを使用します。このプロパティでシェイプの選択、サイズ変更、位置変更、グループ化、テキスト編集ロックなどを保護できます。

```py
# 透かしシェイプの変更をロック
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **透かしを前面に持ってくる**

Aspose.Slides では、シェイプの Z 順序を [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) メソッドで設定できます。このメソッドをプレゼンテーションのスライドリストから呼び出し、シェイプ参照と順序番号を渡します。これにより、シェイプを前面または背面に移動できます。透かしをスライドの前面に配置したい場合に便利です。

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **透かしの回転を設定する**

次のコード例は、透かしをスライドの対角線上に配置するための回転角度を計算して設定する方法を示しています。

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **透かしに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。名前を付けておくと、将来そのシェイプにアクセスして変更または削除できます。透かしシェイプの名前を設定するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) プロパティに代入します。

```py
watermark_shape.name = "watermark"
```

## **透かしを削除する**

透かしシェイプを削除するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) を使ってスライドのシェイプから名前で検索し、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) メソッドで削除します。

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **ライブ例**

**Aspose.Slides 無料** のオンラインツール **[Add Watermark](https://products.aspose.app/slides/watermark)** と **[Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark)** を試してみてください。

![透かしの追加と削除のオンラインツール](online_tools.png)

## **FAQ**

**透かしとは何ですか？また、なぜ使用すべきですか？**

透かしはスライドに重ねられるテキストまたは画像で、知的財産を保護したり、ブランド認知を高めたり、プレゼンテーションの不正使用を防止したりするために使用します。

**プレゼンテーションのすべてのスライドに透かしを追加できますか？**

はい、Aspose.Slides を使えばプレゼンテーションのすべてのスライドに透かしを追加できます。各スライドをループして個別に透かし設定を適用できます。

**透かしの透明度はどう調整しますか？**

シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）を変更して透明度を調整できます。これにより、透かしが目立ちすぎず、スライド内容の妨げになりません。

**透かしでサポートされている画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG など、さまざまな画像形式をサポートしています。

**テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい、好きなフォント、サイズ、スタイルを選択してプレゼンテーションのデザインやブランドと一致させることができます。

**透かしの位置や向きはどう変更しますか？**

シェイプの座標、サイズ、回転プロパティ（[shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)）を変更することで、透かしの位置や向きを調整できます。