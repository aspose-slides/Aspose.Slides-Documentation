---
title: C++でプレゼンテーションに透かしを追加する
linktitle: 透かし
type: docs
weight: 40
url: /ja/cpp/watermark/
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
- PPTからの透かし削除
- PPTXからの透かし削除
- ODPからの透かし削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++でPowerPointおよびOpenDocumentプレゼンテーションのテキストと画像の透かしを管理し、ドラフト、機密情報、著作権などを示します。"
---

## **概要**

**透かし**は、スライドまたはプレゼンテーション全体のスライドに使用されるテキストまたは画像のスタンプです。通常、透かしはプレゼンテーションが草稿であること（例: 「Draft」透かし）や機密情報を含むこと（例: 「Confidential」透かし）を示したり、所属企業を指定したり（例: 「Company Name」透かし）、作成者を識別したりするために使用されます。透かしは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防止するのに役立ちます。透かしは PowerPoint と OpenOffice のプレゼンテーション形式の両方で使用できます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP のファイル形式に透かしを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、PowerPoint または OpenOffice 文書に透かしを作成し、そのデザインや動作を変更するさまざまな方法が用意されています。共通点として、テキスト透かしを追加する場合は [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) インターフェイスを使用し、画像透かしを追加する場合は [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) クラスを使用するか、透かし形状に画像を塗りつぶします。`PictureFrame` は [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを実装しているため、形状オブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` は形状ではなく設定が限られているため、[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) オブジェクトにラップされます。

透かしの適用方法は 2 通りあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスタを使用すると、透かしをすべてのスライドに適用できます。透かしはスライドマスタに追加され、そこで完全にデザインされた後、個々のスライドの透かし編集権限に影響を与えずにすべてのスライドに適用されます。

透かしは通常、他のユーザーが編集できないように設定されます。透かし（正確には透かしの親形状）が編集されないようにするため、Aspose.Slides は形状ロック機能を提供します。特定の形状は通常のスライドまたはスライドマスタ上でロックできます。スライドマスタ上で透かし形状がロックされると、すべてのプレゼンテーションスライドでロックされます。

透かしに名前を設定すれば、将来削除したい場合にスライドの形状コレクションから名前で検索できます。

透かしのデザインは自由ですが、一般的には中央揃え、回転、前面表示などの共通特徴があります。以下の例でこれらの使い方を説明します。

## **テキスト透かし**

### **スライドにテキスト透かしを追加する**

PPT、PPTX、または ODP にテキスト透かしを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) から継承されておらず、透かしの位置を柔軟に設定するためのプロパティが豊富です。そのため、[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) オブジェクトにラップされます。形状に透かしテキストを追加するには、以下のように [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) メソッドを使用します。
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="参照" %}} 
- [TextFrame クラスの使用方法](/slides/ja/cpp/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキスト透かしを追加する**

プレゼンテーション全体（すべてのスライド）にテキスト透かしを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドに透かしを追加する場合と同じで、[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) オブジェクトを作成し、[AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) メソッドで透かしを追加します。
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="参照" %}} 
- [スライドマスタの使用方法](/slides/ja/cpp/slide-master/)
{{% /alert %}}

### **透かし形状の透明度を設定する**

デフォルトでは、矩形形状は塗りつぶしと線の色が設定されています。次のコード行で形状を透明にします。
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **テキスト透かしのフォントを設定する**

以下のようにテキスト透かしのフォントを変更できます。
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **透かしテキストの色を設定する**

透かしテキストの色を設定するには、次のコードを使用します。
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **テキスト透かしを中央に配置する**

透かしをスライドの中央に配置するには、以下の手順を実行します。
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


下の画像は最終結果を示しています。

![テキスト透かし](text_watermark.png)

## **画像透かし**

### **プレゼンテーションに画像透かしを追加する**

プレゼンテーションスライドに画像透かしを追加するには、次の手順を実行します。
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **透かしの編集ロック**

透かしの編集を防止する必要がある場合は、形状に対して [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) メソッドを使用します。このプロパティにより、形状の選択、サイズ変更、再配置、他の要素とのグループ化、テキストの編集ロックなどが可能になります。
```cpp
// 透かし形状の変更をロックする
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **透かしを前面に持ってくる**

Aspose.Slides では、形状の Z オーダーを [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) メソッドで設定できます。このメソッドはプレゼンテーションのスライドリストから呼び出し、形状参照と順序番号を渡します。これにより、形状を前面または背面に移動できます。透かしをスライドの前面に配置したい場合に便利です。
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **透かしの回転を設定する**

透かしをスライド全体に対して対角線上に配置するための回転調整コード例は次のとおりです。
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **透かしに名前を設定する**

Aspose.Slides では形状に名前を設定できます。形状名を使用すると、将来その形状にアクセスして変更または削除できます。透かし形状の名前を設定するには、[IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) メソッドに割り当てます。
```cpp
watermarkShape->set_Name(u"watermark");
```


## **透かしを削除する**

透かし形状を削除するには、[IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) メソッドでスライドの形状コレクションから名前を検索し、[IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) メソッドに透かし形状を渡します。
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **ライブ例**

**Aspose.Slides 無料** のオンラインツール [Add Watermark](https://products.aspose.app/slides/watermark) と [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) を試してみてください。

![透かしの追加と削除のオンラインツール](online_tools.png)

## **FAQ**

**透かしとは何ですか、なぜ使用すべきですか？**

透かしはスライドに適用されるテキストまたは画像のオーバーレイで、知的財産を保護したり、ブランド認知度を高めたり、プレゼンテーションの不正使用を防止したりします。

**プレゼンテーションのすべてのスライドに透かしを追加できますか？**

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションの各スライドに透かしを追加できます。すべてのスライドをループして個別に透かし設定を適用できます。

**透かしの透明度はどう調整しますか？**

形状の塗りつぶし設定（[FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)）を変更することで、透かしの透明度を調整できます。これにより、透かしを控えめにし、スライド内容の妨げにならないようにできます。

**透かしでサポートされている画像形式は何ですか？**

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などさまざまな画像形式をサポートしています。

**テキスト透かしのフォントやスタイルはカスタマイズできますか？**

はい、プレゼンテーションのデザインやブランドの一貫性に合わせて、任意のフォント、サイズ、スタイルを選択できます。

**透かしの位置や向きはどう変更しますか？**

形状の座標、サイズ、回転プロパティをプログラムで変更することで、透かしの位置や向きを調整できます。