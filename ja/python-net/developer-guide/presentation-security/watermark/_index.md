---
title: "Pythonでプレゼンテーションに透かしを追加する"
linktitle: "透かし"
type: docs
weight: 40
url: /ja/python-net/watermark/
keywords:
- "透かし"
- "テキスト透かし"
- "画像透かし"
- "透かしの追加"
- "透かしの変更"
- "透かしの削除"
- "透かしの削除"
- "PPTへの透かし追加"
- "PPTXへの透かし追加"
- "ODPへの透かし追加"
- "PPTからの透かし削除"
- "PPTXからの透かし削除"
- "ODPからの透かし削除"
- "PPTから透かしを削除"
- "PPTXから透かしを削除"
- "ODPから透かしを削除"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "PythonでPowerPointおよびOpenDocumentのプレゼンテーションにテキストと画像の透かしを管理し、ドラフト、機密情報、著作権などを示す方法を学びます。"
---

## **透かしについて**

**透かし** は、プレゼンテーションのスライド上または全スライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションがドラフトであること（例: "Draft" 透かし）、機密情報が含まれていること（例: "Confidential" 透かし）、所属会社を示すこと（例: "Company Name" 透かし）、作成者を特定することなどに使用されます。透かしは、プレゼンテーションをコピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。透かしは PowerPoint と OpenOffice の両方のプレゼンテーション形式で使用されます。Aspose.Slides では、PowerPoint の PPT、PPTX、OpenOffice の ODP ファイル形式に透かしを追加できます。

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)、PowerPointやOpenOfficeドキュメントで透かしを作成し、そのデザインや動作を変更するさまざまな方法があります。テキスト透かしを追加するには[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)クラスを使用し、画像透かしを追加するには[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)クラスまたは透かしシェイプに画像を設定します。`PictureFrame`は[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)クラスを実装しており、シェイプオブジェクトの柔軟な設定すべてを利用できます。`TextFrame`はシェイプではなく設定が限定的なため、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)オブジェクトにラップされます。

透かしの適用方法は、単一のスライドに適用するか、プレゼンテーション全体のスライドに適用するかの2通りがあります。Slide Master を使用すると、すべてのスライドに透かしを適用できます。透かしは Slide Master に追加され、そこで完全にデザインされ、個々のスライドの透かし編集権限に影響を与えずにすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないものと見なされます。透かし（正確には透かしの親シェイプ）の編集を防止するために、Aspose.Slides はシェイプのロック機能を提供しています。特定のシェイプは通常のスライドまたは Slide Master 上でロックできます。Slide Master 上で透かしシェイプがロックされると、プレゼンテーション全体のスライドでロックされます。

透かしに名前を設定すれば、将来削除したいときにスライドのシェイプ一覧から名前で検索して見つけることができます。

透かしは自由にデザインできますが、通常は中心揃え、回転、前面表示などの共通の特徴があります。以下の例でそれらの使い方を検討します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、または ODP にテキスト透かしを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)クラスで表されます。この型は[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)から継承されておらず、透かしの位置を柔軟に設定するための豊富なプロパティがあります。そのため、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)オブジェクトは[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)オブジェクトにラップされます。シェイプに透かしテキストを追加するには、以下のように[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)メソッドを使用します。

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

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)に追加します。残りのロジックは単一スライドに透かしを追加する場合と同じです。まず[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)オブジェクトを作成し、[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)メソッドで透かしを追加します。

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

デフォルトでは矩形シェイプに塗りつぶしと線の色が設定されています。以下のコードでシェイプを透明にします。

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

透かしテキストの色を設定するには、以下のコードを使用します。

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **テキスト透かしを中央揃えする**

スライド上で透かしを中央に配置することができ、以下のように実装できます。

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

![テキスト透かし](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

プレゼンテーションのスライドに画像透かしを追加するには、以下の手順を実行します。

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **透かしの編集ロック**

透かしの編集を防止する必要がある場合は、シェイプの[AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/)プロパティを使用します。このプロパティにより、シェイプの選択・サイズ変更・位置変更・他の要素とのグループ化・テキストの編集ロックなどを保護できます。

```py
# 透かしシェイプの変更をロックする
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **透かしを前面に持ってくる**

Aspose.Slides では、シェイプの Z オーダーは[ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape)メソッドで設定できます。このメソッドはプレゼンテーションのスライドリストから呼び出し、シェイプ参照と順序番号を渡します。これにより、シェイプを前面に持ってくるまたは背面に送ることが可能です。この機能は、透かしをプレゼンテーションの前面に配置したい場合に特に有用です。

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **透かしの回転を設定する**

以下は透かしの回転角度を調整し、スライド全体に対して対角線上に配置するコード例です。

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **透かしに名前を設定する**

Aspose.Slides ではシェイプに名前を設定できます。名前を使用すれば、将来そのシェイプにアクセスして変更または削除できます。透かしシェイプの名前を設定するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)プロパティに割り当てます。

```py
watermark_shape.name = "watermark"
```

## **透かしを削除する**

透かしシェイプを削除するには、[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)メソッドでスライドのシェイプから名前で検索し、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape)メソッドに透かしシェイプを渡します。

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **実例**

**Aspose.Slides 無料** の[Add Watermark](https://products.aspose.app/slides/watermark) と[Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) オンラインツールをご確認ください。

![透かしの追加と削除のオンラインツール](online_tools.png)

## **よくある質問**

**透かしとは何か、なぜ使用すべきか？**  
透かしはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

**プレゼンテーションのすべてのスライドに透かしを追加できますか？**  
はい、Aspose.Slides を使用すると、プレゼンテーションのすべてのスライドに透かしを追加できます。スライドをすべて走査し、個別に透かし設定を適用できます。

**透かしの透明度はどのように調整できますか？**  
シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）を変更することで透かしの透明度を調整できます。これにより、透かしが控えめになり、スライドコンテンツの妨げになりません。

**透かしにサポートされている画像形式は何ですか？**  
Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などさまざまな画像形式をサポートしています。

**テキスト透かしのフォントやスタイルをカスタマイズできますか？**  
はい、任意のフォント、サイズ、スタイルを選択してプレゼンテーションのデザインやブランドの一貫性に合わせることができます。

**透かしの位置や向きを変更するにはどうすればよいですか？**  
シェイプの座標、サイズ、回転プロパティを変更することで、透かしの位置や向きを調整できます。