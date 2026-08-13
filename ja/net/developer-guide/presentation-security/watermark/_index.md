---
title: .NET でプレゼンテーションにウォーターマークを追加
linktitle: ウォーターマーク
type: docs
weight: 40
url: /ja/net/watermark/
keywords:
- ウォーターマーク
- テキストウォーターマーク
- 画像ウォーターマーク
- ウォーターマークを追加
- ウォーターマークを変更
- ウォーターマークを削除
- ウォーターマークを削除
- PPT にウォーターマークを追加
- PPTX にウォーターマークを追加
- ODP にウォーターマークを追加
- PPT からウォーターマークを削除
- PPTX からウォーターマークを削除
- ODP からウォーターマークを削除
- PPT からウォーターマークを削除
- PPTX からウォーターマークを削除
- ODP からウォーターマークを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint および OpenDocument プレゼンテーションのテキストおよび画像ウォーターマークを管理し、ドラフトや機密情報、著作権などを示します。"
---
## **イントロダクション**

**ウォーターマーク**は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、ドラフトであること（例: 「Draft」ウォーターマーク）や機密情報が含まれていること（例: 「Confidential」ウォーターマーク）を示す、所属企業を表す（例: 「Company Name」ウォーターマーク）やプレゼンテーションの作成者を識別するなどの目的で使用されます。ウォーターマークは、コピーすべきでないことを示すことで著作権侵害を防止するのに役立ちます。ウォーターマークは PowerPoint と OpenDocument のプレゼンテーション形式の両方で使用できます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenDocument ODP のファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/ja/net/) では、PowerPoint または OpenDocument ドキュメントにウォーターマークを作成し、そのデザインや動作を変更するさまざまな方法があります。共通点として、テキストウォーターマークを追加する場合は [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) インターフェイスを使用し、画像ウォーターマークを追加する場合は [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/pictureframe/) クラスまたは画像でウォーターマークシェイプを塗りつぶす方法があります。`PictureFrame` は [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape) インターフェイスを実装しているため、シェイプオブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` はシェイプではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 通りあります。単一のスライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスタは、すべてのスライドにウォーターマークを適用するために使用されます。ウォーターマークはスライドマスタに追加され、そこで完全にデザインされ、個々のスライドの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないように設定されます。ウォーターマーク（正確にはウォーターマークの親シェイプ）を編集できないようにするため、Aspose.Slides はシェイプのロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスタ上でロックできます。スライドマスタ上でウォーターマークシェイプがロックされている場合、すべてのスライドでロックされます。

将来ウォーターマークを削除したいときに名前で検索できるよう、ウォーターマークに名前を付けることができます。

ウォーターマークのデザインは自由に構成できますが、一般的には中央揃え、回転、前面表示などの共通要素があります。以下の例でこれらの使い方を説明します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、または ODP にテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) から継承されておらず、柔軟な位置決めのためのプロパティが豊富です。そのため、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) オブジェクトにラップされます。シェイプにテキストウォーターマークを追加するには、以下のように [AddTextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/methods/addtextframe) メソッドを使用します。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// スライドにウォーターマークを追加します。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="参照" %}} 
- [How to Use the TextFrame Class?](/slides/ja/net/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキストウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドにウォーターマークを追加する場合と同じです。まず [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) オブジェクトを作成し、次に [AddTextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/methods/addtextframe) メソッドでウォーターマークを追加します。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// マスタースライドにウォーターマークを追加します。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="参照" %}} 
- [How to Use the Slide Master?](/slides/ja/net/slide-master/)
{{% /alert %}}

### **ウォーターマークシェイプの透明度を設定する**

デフォルトでは、矩形シェイプには塗りつぶしと線の色が設定されています。これにより、ウォーターマークが背景や枠線で目立ってしまう可能性があります。ウォーターマークを目立たせず、プレゼンテーションのデザインを損なわないようにするには、シェイプを完全に透明にします。

以下のコードは、塗りつぶし色と枠線色の両方を削除してシェイプを透明にします。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **テキストウォーターマークのフォントを設定する**

テキストウォーターマークをスライドに適用する前に、全体のデザインに調和するよう外観をカスタマイズすることが重要です。フォントの種類やサイズを変更して、読みやすく美しく仕上げます。フォントのカスタマイズは、ブランドイメージを強化したり、プレゼンテーションのスタイルに合わせたりするのにも役立ちます。

以下のコードスニペットは、特定のラテンフォントを選択し、適切なフォントサイズを設定してウォーターマークのフォントを調整する方法を示しています。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークを適用する前に、テキスト色がスライドの内容と調和し、過度に目立たないように設定することが重要です。赤・緑・青の各成分に加えてアルファ（透明度）を調整することで、控えめで半透明のウォーターマークを作成できます。この方法は、コンテンツの保護はしつつ、プレゼンテーションの焦点を維持します。

ウォーターマークテキストの色を設定するには、以下のコードを使用します。

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **テキストウォーターマークを中央に配置する**

テキストウォーターマークを適切に中央揃えにすると、スライドサイズに関係なく対称的に配置でき、プレゼンテーション全体の美観が向上します。この手法は、プロフェッショナルな外観を提供し、メインコンテンツの妨げにならないようにします。

以下のコードスニペットは、スライドの中心座標を算出し、テキストウォーターマークをその位置に配置する方法を示しています。

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

以下の画像は最終結果を示しています。

![The text watermark](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

画像ウォーターマークは、ブランド要素をユニークに表現したり、テキストウォーターマークより視覚的に魅力的な代替手段を提供したりします。ウォーターマークを追加する前に、画像ファイル（例: 透過 PNG）が使用可能であることを確認してください。以下の例は、ファイルシステムから画像を読み込み、プレゼンテーションに追加し、シェイプの塗りつぶしプロパティを使用してウォーターマークとして適用する方法を示しています。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **ウォーターマークの編集ロック**

ウォーターマークの編集を防止する必要がある場合は、シェイプの [IAutoShape.ShapeLock](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/properties/shapelock) プロパティを使用します。このプロパティを使うと、シェイプの選択・サイズ変更・再配置・他要素とのグループ化・テキスト編集ロックなどを保護できます。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// ウォーターマークシェイプの変更をロックします。
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **ウォーターマークを前面に持ってくる**

Aspose.Slides では、シェイプの Z オーダーを [IShapeCollection.Reorder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/reorder/#reorder) メソッドで設定できます。このメソッドをプレゼンテーションのスライドコレクションから呼び出し、シェイプ参照と順序番号を渡すことで、シェイプを前面または背面に移動できます。ウォーターマークをスライドの前面に配置したい場合に便利です。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定する**

ウォーターマークの回転を調整すると、プレゼンテーションの視覚的インパクトと控えめさが向上します。たとえば対角線上のウォーターマークは、目立ちすぎずに不正使用から保護できます。以下の例は、スライド寸法に基づいて適切な角度を計算し、スライド全体に対角線で配置する方法を示しています。スライドサイズが異なっても効果的に機能します。

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **ウォーターマークに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。シェイプ名を使用すれば、将来そのシェイプを検索・変更・削除できます。ウォーターマークシェイプに名前を付けるには、[IAutoShape.Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/name) プロパティに代入します。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **ウォーターマークを削除する**

ウォーターマークシェイプを削除するには、[IAutoShape.Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/properties/name) プロパティでシェイプを検索し、見つけたシェイプを [IShapeCollection.Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/remove/) メソッドに渡します。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **ライブ例**

**Aspose.Slides free** のオンラインツール **[Add Watermark](https://products.aspose.app/slides/ja/watermark)** と **[Remove Watermark](https://products.aspose.app/slides/ja/watermark/remove-watermark)** を試してみてください。

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### ウォーターマークとは何ですか？また、なぜ使用すべきですか？

ウォーターマークはスライドに重ねて表示されるテキストまたは画像で、知的財産を保護したり、ブランド認知を高めたり、プレゼンテーションの不正使用を防止したりします。

### プレゼンテーション全体のスライドにウォーターマークを追加できますか？

はい。Aspose.Slides を使用すれば、プログラムからプレゼンテーション内のすべてのスライドにウォーターマークを追加できます。各スライドをループして個別に設定します。

### ウォーターマークの透明度はどのように調整しますか？

シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/fillformat/)）を変更することで透明度を調整できます。これにより、ウォーターマークが控えめになり、スライドの内容を妨げません。

### ウォーターマークに使用できる画像形式は何ですか？

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG など、さまざまな画像形式をサポートしています。

### テキストウォーターマークのフォントやスタイルはカスタマイズできますか？

はい。フォント、サイズ、スタイルを自由に選択して、プレゼンテーションのデザインやブランドの一貫性に合わせることができます。

### ウォーターマークの位置や向きはどう変更しますか？

シェイプの座標、サイズ、回転プロパティをプログラムから変更することで、ウォーターマークの位置や向きを調整できます。