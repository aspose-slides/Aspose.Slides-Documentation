---
title: ウォーターマーク
type: docs
weight: 40
url: /python-net/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキストウォーターマーク
- 画像ウォーターマーク
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides for Python via .NET
description: "PythonでPowerPointプレゼンテーションにテキストおよび画像ウォーターマークを追加します"
---

## **ウォーターマークについて**

プレゼンテーションにおける**ウォーターマーク**は、スライドまたはすべてのプレゼンテーションスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークは、プレゼンテーションが草案であることを示すため（例: "草案"ウォーターマーク）、機密情報が含まれていることを示すため（例: "機密"ウォーターマーク）、どの会社に属するかを指定するため（例: "会社名"ウォーターマーク）、プレゼンテーションの作成者を特定するためなどに使用されます。ウォーターマークは、プレゼンテーションがコピーされるべきではないことを示すことで著作権の侵害を防ぐのに役立ちます。ウォーターマークは、PowerPointおよびOpenOfficeのプレゼンテーション形式の両方で使用されます。Aspose.Slidesを使用すると、PowerPointのPPT、PPTX、およびOpenOfficeのODPファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/)では、PowerPointまたはOpenOffice文書にウォーターマークを作成し、デザインや動作を変更するためのさまざまな方法があります。共通点は、テキストウォーターマークを追加するには[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)クラスを使用し、画像ウォーターマークを追加するには[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)クラスを使用するか、ウォーターマーク形状を画像で埋める必要があることです。`PictureFrame`は[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)クラスを実装しており、形状オブジェクトのすべての柔軟な設定を使用できます。`TextFrame`は形状ではなく、その設定は制限されているため、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)オブジェクトにラップされています。

ウォーターマークは、単一のスライドに適用するか、すべてのプレゼンテーションスライドに適用することができます。スライドマスターを使用してすべてのプレゼンテーションスライドにウォーターマークを適用します — ウォーターマークはスライドマスターに追加され、そこで完全にデザインされ、個々のスライドでウォーターマークを変更する権限に影響を与えることなく、すべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーによる編集ができないと見なされます。ウォーターマーク（またはむしろウォーターマークの親形状）が編集されるのを防ぐために、Aspose.Slidesは形状ロック機能を提供します。特定の形状は通常のスライドまたはスライドマスターでロックできます。ウォーターマーク形状がスライドマスターでロックされている場合、それはすべてのプレゼンテーションスライドでロックされます。

将来的に削除したい場合に、ウォーターマークの名前を設定することができます。その場合、スライドの形状を名前で見つけることができます。

ウォーターマークを任意の方法でデザインできますが、通常、ウォーターマークには中央揃え、回転、前面位置などの共通の特徴があります。以下の例でこれらを使用する方法について考察します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、またはODPにテキストウォーターマークを追加するには、最初にスライドに形状を追加し、次にこの形状にテキストフレームを追加できます。テキストフレームは[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)クラスによって表されます。このタイプは、ウォーターマークを柔軟に配置するための広範なプロパティを持つ[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)から継承されていないため、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)オブジェクトは[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)オブジェクトにラップされます。形状にウォーターマークテキストを追加するには、以下のように[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)メソッドを使用します。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="参照" %}} 
- [TextFrameクラスの使用方法](/slides/python-net/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（すなわち、すべてのスライドを一度に）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)に追加します。残りのロジックは、単一のスライドにウォーターマークを追加する場合と同じです — [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)オブジェクトを作成し、[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)メソッドを使用してそれにウォーターマークを追加します。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="参照" %}} 
- [スライドマスターの使用方法](/slides/python-net/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定する**

デフォルトでは、長方形形状は塗りつぶしと線の色でスタイル設定されています。次のコード行は、形状を透明にします。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **テキストウォーターマークのフォントを設定する**

以下のようにして、テキストウォーターマークのフォントを変更できます。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、このコードを使用します：

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **テキストウォーターマークを中央に配置する**

ウォーターマークをスライドの中央に配置することが可能で、そのためには次のようにします：

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

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションスライドに画像ウォーターマークを追加するには、次のようにします：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **ウォーターマークの編集をロックする**

ウォーターマークが編集されるのを防ぐ必要がある場合は、形状に対して[AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/)プロパティを使用します。このプロパティを使用すると、形状を選択できなくしたり、サイズを変更できなくしたり、再配置できなくしたり、他の要素とグループ化できなくしたり、テキストが編集されるのをロックしたり、その他多くのことが可能です：

```py
# ウォーターマーク形状を変更できないようにロックする
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **ウォーターマークを前面に持ってくる**

Aspose.Slidesでは、形状のZオーダーは[ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape)メソッドを介して設定できます。これを行うには、プレゼンテーションスライドリストからこのメソッドを呼び出し、形状参照とその順序番号をメソッドに渡す必要があります。このようにして、形状を前面に持って行ったり、スライドの背面に送ったりできます。この機能は、プレゼンテーションの前面にウォーターマークを配置する必要がある場合に特に便利です：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **ウォーターマークの回転を設定する**

ウォーターマークを斜めに配置するための回転を調整する方法のコード例は以下の通りです：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **ウォーターマークの名前を設定する**

Aspose.Slidesでは、形状の名前を設定できます。形状名を使用することで、将来的にそれにアクセスして変更または削除できます。ウォーターマーク形状の名前を設定するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)プロパティに割り当てます：

```py
watermark_shape.name = "watermark"
```

## **ウォーターマークを削除する**

ウォーターマーク形状を削除するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)メソッドを使用してスライドと形状で見つけます。次に、ウォーターマーク形状を[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape)メソッドに渡します：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **ライブ例**

**Aspose.Slides無料**の[ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)オンラインツールをチェックアウトすることをお勧めします。

![ウォーターマークの追加と削除のためのオンラインツール](online_tools.png)