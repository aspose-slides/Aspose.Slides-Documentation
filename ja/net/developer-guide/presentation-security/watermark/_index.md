---
title: C# でプレゼンテーションに透かしを追加する
linktitle: 透かし
type: docs
weight: 40
url: /ja/net/watermark/
keywords:
- 透かし
- テキスト透かし
- 画像透かし
- 透かしを追加
- 透かしを変更
- 透かしを削除
- 透かしを削除
- プレゼンテーションに透かしを追加
- PPT に透かしを追加
- PPTX に透かしを追加
- ODP に透かしを追加
- プレゼンテーションから透かしを削除
- PPT から透かしを削除
- PPTX から透かしを削除
- ODP から透かしを削除
- プレゼンテーションから透かしを削除
- PPT から透かしを削除
- PPTX から透かしを削除
- ODP から透かしを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# で PowerPoint および OpenDocument のプレゼンテーションにテキストと画像の透かしを追加し、ドラフト、機密情報、著作権などを示す方法を学びます。"
---

## **概要**

**プレゼンテーションの透かし** は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはドラフトであること（例: 「Draft」透かし）や機密情報が含まれていること（例: 「Confidential」透かし）を示したり、どの会社に属するか（例: 「Company Name」透かし）を明示したり、プレゼンテーション作成者を特定したりするために使用されます。透かしは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防止するのに役立ちます。透かしは PowerPoint と OpenDocument のプレゼンテーション形式の両方で使用できます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenDocument ODP のファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/net/) では、PowerPoint や OpenDocument ドキュメントに透かしを作成し、そのデザインや動作を変更するさまざまな方法が用意されています。共通点は、テキスト透かしを追加する場合は [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) インターフェイスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) クラスまたは透かしシェイプに画像を塗りつぶすことです。`PictureFrame` は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) インターフェイスを実装しているため、シェイプオブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` はシェイプではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) オブジェクトにラップされます。

透かしの適用方法は 2 通りあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。すべてのスライドに透かしを適用する場合はスライドマスタを使用します。透かしはスライドマスタに追加され、そこで完全にデザインされ、個々のスライドの透かし編集権限に影響を与えることなくすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないように設定されます。透かし（正確には透かしの親シェイプ）の編集を防止するために、Aspose.Slides はシェイプのロック機能を提供します。特定のシェイプは通常のスライドまたはスライドマスタ上でロックできます。スライドマスタ上で透かしシェイプがロックされている場合、すべてのスライドでロックされた状態になります。

透かしに名前を付けておくと、将来削除したいときにスライドのシェイプ一覧から名前で検索して見つけやすくなります。

透かしは任意のデザインで作成できますが、一般的には中央揃え、回転、前面配置などの共通特徴があります。以下の例でこれらの使い方を検討します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、ODP でテキスト透かしを追加するには、まずスライドにシェイプを追加し、そのシェイプにテキストフレームを追加します。テキストフレームは [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) を継承しておらず、透かしの位置を柔軟に設定するためのプロパティが豊富です。そのため、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) オブジェクトにラップされます。シェイプに透かしテキストを追加するには、以下に示すように [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) メソッドを使用します。
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// スライドに透かしを追加します。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="See also" %}} 
- [TextFrame クラスの使用方法](/slides/ja/net/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト透かしを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドへの透かし追加と同じです。まず [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) オブジェクトを作成し、次に [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) メソッドで透かしを追加します。
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// マスタースライドに透かしを追加します。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="See also" %}} 
- [スライドマスタの使用方法](/slides/ja/net/slide-master/)
{{% /alert %}}

### **透かしシェイプの透明度を設定する**

デフォルトでは、矩形シェイプには塗りつぶしと線色が設定されています。これにより、透かしが追加されたときに背景や枠が実線で表示され、スライドの内容の妨げになる可能性があります。透かしを目立たせず、プレゼンテーションのビジュアルデザインに干渉しないようにするには、シェイプを完全に透明にします。

次のコードは、塗りつぶし色と線色の両方を削除してシェイプを透明にします。
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **テキスト透かしのフォントを設定する**

スライドにテキスト透かしを適用する前に、その外観をカスタマイズしてプレゼンテーション全体のデザインと調和させることが重要です。フォント種別とサイズを変更することで、透かしが読みやすく美しくなります。フォントをカスタマイズすると、ブランドアイデンティティの強化やプレゼンテーションスタイルへの一致にも役立ちます。

以下のコードスニペットは、特定のラテンフォントを選択し、適切なフォント高さを設定して透かしのフォント設定を調整する方法を示しています。
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **透かしテキストの色を設定する**

透かしを適用する前に、テキストカラーを適切に設定してスライド内容と調和させ、過度に目立たないようにすることが重要です。アルファ（透明度）と赤・緑・青の各成分を調整することで、微妙で半透明の透かしを作成できます。このアプローチにより、メインのプレゼンテーションに集中しつつコンテンツを保護できます。

透かしテキストの色を設定するには、次のコードを使用します。
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **テキスト透かしを中央に配置する**

テキスト透かしを正しく中央揃えにすると、スライドのサイズに関係なく透かしが対称的に配置され、全体的な美観が向上します。この方法は、スライドにプロフェッショナルな印象を与えるだけでなく、透かしがメインコンテンツの邪魔にならないようにします。

以下のコードスニペットは、スライドの中心位置を計算し、テキスト透かしをその位置に配置する方法を示しています。
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


下の画像は最終結果を示しています。

![The text watermark](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

多くの場合、画像透かしはテキスト透かしに代わるユニークなブランディング要素や視覚的に魅力的な代替手段となります。透かしを追加する前に、画像ファイル（例: 透過 PNG）が用意されていることを確認してください。以下の例は、ファイルシステムから画像を読み込み、プレゼンテーションに追加し、シェイプの塗りつぶしプロパティを使用して透かしとして適用する方法を示しています。
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **透かしの編集をロックする**

透かしの編集を防止する必要がある場合は、シェイプの [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) プロパティを使用します。このプロパティにより、シェイプの選択、サイズ変更、位置変更、他要素とのグループ化、テキスト編集のロックなど、さまざまな操作からシェイプを保護できます。
```cs
// 透かしシェイプの変更をロックします。
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **透かしを前面に持ってくる**

Aspose.Slides では、シェイプの Z 順序を [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) メソッドで設定できます。このメソッドをプレゼンテーションのスライドコレクションから呼び出し、シェイプ参照と順序番号を渡すことで、シェイプを前面または背面に移動できます。この機能は、透かしをプレゼンテーションの前面に配置したい場合に特に便利です。
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **透かしの回転を設定する**

透かしの回転を調整すると、プレゼンテーションの視覚的インパクトと控えめさが大幅に向上します。たとえば斜めの透かしは、目立ちすぎずに不正使用からの保護効果を提供します。以下の例は、スライドの寸法に基づいて適切な角度を計算し、透かしを対角線上に配置する方法を示しています。この動的計算により、スライドサイズが異なる場合でも透かしの効果が維持されます。
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **透かしに名前を付ける**

Aspose.Slides ではシェイプに名前を設定できます。シェイプ名を使用すると、将来そのシェイプを検索して変更または削除できます。透かしシェイプに名前を付けるには、[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) プロパティに設定します。
```cs
watermarkShape.Name = "watermark";
```


## **透かしを削除する**

透かしシェイプを削除するには、[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) プロパティでスライドのシェイプ一覧から名前を検索し、該当シェイプを [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) メソッドに渡します。
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

**Aspose.Slides 無料** のオンラインツール [Add Watermark](https://products.aspose.app/slides/watermark) と [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) を試してみてください。

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**透かしとは何ですか？また、なぜ使用すべきですか？**

透かしはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

**プレゼンテーションのすべてのスライドに透かしを追加できますか？**

はい。Aspose.Slides を使用すると、プログラムでプレゼンテーションのすべてのスライドに透かしを追加できます。スライドをループし、個別に透かし設定を適用します。

**透かしの透明度はどのように調整しますか？**

シェイプの塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)）を変更することで透明度を調整できます。これにより、透かしが控えめになり、スライド内容の妨げになりません。

**透かしに使用できる画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などのさまざまな画像形式をサポートしています。

**テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい。任意のフォント、サイズ、スタイルを選択して、プレゼンテーションのデザインやブランド一貫性に合わせることができます。

**透かしの位置や方向はどう変更しますか？**

シェイプの座標、サイズ、回転プロパティをプログラムで変更することで、透かしの位置や向きを調整できます。