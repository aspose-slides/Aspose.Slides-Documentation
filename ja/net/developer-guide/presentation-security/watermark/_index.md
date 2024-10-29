---
title: ウォーターマーク
type: docs
weight: 40
url: /ja/net/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキストウォーターマーク
- 画像ウォーターマーク
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションにテキストおよび画像ウォーターマークを追加する"
---

## **ウォーターマークについて**

プレゼンテーションにおける**ウォーターマーク**は、スライドまたはすべてのプレゼンテーションスライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークはプレゼンテーションがドラフトであることを示すため（例：「ドラフト」ウォーターマーク）、機密情報が含まれていることを示すため（例：「機密」ウォーターマーク）、どの会社に属するかを指定するため（例：「会社名」ウォーターマーク）、プレゼンテーションの著者を識別するためなどに使用されます。ウォーターマークは、プレゼンテーションがコピーされてはならないことを示すことによって著作権侵害を防ぐのに役立ちます。ウォーターマークは、PowerPointおよびOpenOfficeのプレゼンテーションフォーマットの両方で使用されます。Aspose.Slidesでは、PowerPointのPPT、PPTX、およびOpenOfficeのODPファイルフォーマットにウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/net/)では、PowerPointまたはOpenOfficeドキュメントでウォーターマークを作成し、そのデザインや動作を変更するためのさまざまな方法があります。共通の点は、テキストのウォーターマークを追加するには[ ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)インターフェイスを使用し、画像のウォーターマークを追加するには[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)クラスを使用するか、ウォーターマークのシェイプを画像で塗りつぶす必要があることです。`PictureFrame`は[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)インターフェイスを実装しているため、シェイプオブジェクトのすべての柔軟な設定を使用できます。`ITextFrame`はシェイプではなく、その設定は制限されているため、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)オブジェクトにラップされています。

ウォーターマークを適用する方法は2つあります：1つのスライドに適用するか、すべてのプレゼンテーションスライドに適用するかです。スライドマスターを使用して、すべてのプレゼンテーションスライドにウォーターマークを適用します。ウォーターマークはスライドマスターに追加され、そこで完全にデザインされ、個々のスライドでのウォーターマークの修正権限に影響を与えることなく、すべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーによる編集ができないと見なされます。ウォーターマーク（あるいはむしろウォーターマークの親シェイプ）が編集されないようにするために、Aspose.Slidesはシェイプロック機能を提供しています。特定のシェイプは、通常のスライドまたはスライドマスターでロックできます。ウォーターマークのシェイプがスライドマスターでロックされている場合、それはすべてのプレゼンテーションスライドでもロックされます。

ウォーターマークに名前を設定することができるので、将来的に削除したい場合、スライドのシェイプの中から名前で見つけることができます。

ウォーターマークは任意の方法でデザインできますが、通常、中央揃え、回転、前面位置など、ウォーターマークには一般的な機能があります。以下の例でこれらの使用方法を考察します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、またはODPにテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、次にこのシェイプにテキストフレームを追加します。テキストフレームは[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe)インターフェイスによって表現されます。このタイプは[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)から継承されていないため、ウォーターマークを柔軟に配置するための広範なプロパティセットを持っています。したがって、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe)オブジェクトは[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)オブジェクトにラップされます。シェイプにウォーターマークテキストを追加するには、下記のように[AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe)メソッドを使用します。

```cs
string watermarkText = "機密";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="関連情報" %}} 
- [TextFrameクラスの使用方法](/slides/ja/net/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（つまり、すべてのスライドに一度に）にテキストウォーターマークを追加したい場合は[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)に追加します。残りのロジックは、単一のスライドにウォーターマークを追加する場合と同じです — [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)オブジェクトを作成し、次に[AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe)メソッドを使用してそれにウォーターマークを追加します。

```cs
string watermarkText = "機密";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="関連情報" %}} 
- [スライドマスターの使用方法](/slides/ja/net/slide-master/)
{{% /alert %}}

### **ウォーターマークシェイプの透明度を設定する**

デフォルトでは、長方形シェイプは塗りつぶしと線の色でスタイルが設定されています。以下のコード行はシェイプを透明にします。

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **テキストウォーターマークのフォントを設定する**

以下のようにテキストウォーターマークのフォントを変更できます。

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、次のコードを使用します：

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **テキストウォーターマークを中央に配置する**

スライドのウォーターマークを中央に配置することができます。そのためには、次のようにします：

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

画像は最終結果を示しています。

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションスライドに画像ウォーターマークを追加するには、次のようにします：

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **ウォーターマークの編集をロックする**

ウォーターマークの編集を防ぐ必要がある場合は、シェイプの[IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock)プロパティを使用します。このプロパティを使用すると、シェイプが選択されたり、サイズ変更されたり、位置変更されたり、他の要素とグループ化されたり、テキストが編集できないようにロックしたりすることができます：

```cs
// ウォーターマークシェイプの変更をロック
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **ウォーターマークを前面に移動する**

Aspose.Slidesでは、形状のZ順序を[IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder)メソッドを介して設定できます。これを行うには、プレゼンテーションのスライドリストからこのメソッドを呼び出し、シェイプの参照とその順序番号をメソッドに渡します。これにより、シェイプを前面に移動したり、スライドの背面に送信したりすることができます。この機能は、プレゼンテーションの前面にウォーターマークを配置する必要がある場合に特に便利です：

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定する**

ウォーターマークをスライドを斜めに横切って配置するために回転を調整する方法の例は次のとおりです：

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **ウォーターマークの名前を設定する**

Aspose.Slidesでは、シェイプに名前を設定できます。シェイプの名前を使用することで、将来それにアクセスし、修正または削除することができます。ウォーターマークシェイプの名前を設定するには、[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name)プロパティに割り当てます：

```cs
watermarkShape.Name = "watermark";
```

## **ウォーターマークを削除する**

ウォーターマークシェイプを削除するには、[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name)プロパティを使用して、スライドシェイプの中から見つけます。その後、ウォーターマークシェイプを[IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/)メソッドに渡します：

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **ライブ例**

**Aspose.Slides無料**の[ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)のオンラインツールをチェックしてみてください。

![ウォーターマークの追加と削除のためのオンラインツール](online_tools.png)