---
title: C++でプレゼンテーションにウォーターマークを追加する
linktitle: ウォーターマーク
type: docs
weight: 40
url: /ja/cpp/watermark/
keywords:
- ウォーターマーク
- テキストウォーターマーク
- 画像ウォーターマーク
- ウォーターマークの追加
- ウォーターマークの変更
- ウォーターマークの削除
- ウォーターマークの削除
- PPTへのウォーターマーク追加
- PPTXへのウォーターマーク追加
- ODPへのウォーターマーク追加
- PPTからのウォーターマーク削除
- PPTXからのウォーターマーク削除
- ODPからのウォーターマーク削除
- PPTからのウォーターマーク削除
- PPTXからのウォーターマーク削除
- ODPからのウォーターマーク削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++でPowerPointおよびOpenDocumentのプレゼンテーションにテキストや画像のウォーターマークを管理し、ドラフト、機密情報、著作権などを示します。"
---
## **はじめに**

**ウォーターマーク** は、プレゼンテーションのスライド上または全スライドに使用されるテキストまたは画像のスタンプです。通常、ウォーターマークはプレゼンテーションがドラフトであること（例: “Draft” ウォーターマーク）や機密情報を含むこと（例: “Confidential” ウォーターマーク）を示したり、所属企業（例: “Company Name” ウォーターマーク）を示したり、作成者を特定したりするために使用されます。ウォーターマークは、コピーすべきでないことを示すことで著作権侵害の防止にも役立ちます。ウォーターマークは PowerPoint と OpenOffice の両プレゼンテーション形式で使用できます。Aspose.Slides では、PowerPoint PPT、PPTX、OpenOffice ODP のファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/ja/cpp/) では、PowerPoint や OpenOffice のドキュメントにウォーターマークを作成し、デザインや動作を変更するさまざまな方法が用意されています。共通点として、テキストウォーターマークを追加するには [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) インターフェイスを使用し、画像ウォーターマークを追加するには [PictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pictureframe/) クラスを使用するか、ウォーターマーク形状を画像で塗りつぶします。`PictureFrame` は [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) インターフェイスを実装しているため、形状オブジェクトの柔軟な設定をすべて利用できます。`ITextFrame` は形状ではなく設定が限定的なため、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) オブジェクトにラップされます。

ウォーターマークの適用方法は 2 つあります。単一スライドに適用するか、プレゼンテーション全体のスライドに適用するかです。スライドマスタを使用すると、ウォーターマークをすべてのスライドに適用できます。ウォーターマークはスライドマスタに追加され、そこで完全にデザインされ、個々のスライドの編集権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーが編集できないように設定されます。ウォーターマーク（正確には親形状）が編集されないようにするため、Aspose.Slides は形状ロック機能を提供します。特定の形状は通常のスライドまたはスライドマスタ上でロックできます。スライドマスタ上でウォーターマーク形状がロックされている場合、すべてのスライドでロック状態になります。

将来的にウォーターマークを削除したい場合に備えて、名前を設定しておくとスライド上の形状から名前で検索して削除できます。

ウォーターマークのデザインは自由に構成できますが、中心揃え、回転、前面配置など共通の特徴があります。以下の例でこれらの使い方を確認します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、ODP にテキストウォーターマークを追加するには、まずスライドに形状を追加し、その形状にテキストフレームを追加します。テキストフレームは [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) インターフェイスで表されます。この型は [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) から継承されておらず、柔軟な位置設定プロパティがありません。そのため、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) オブジェクトは [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) オブジェクトにラップされます。形状にテキストウォーターマークを追加するには、以下のように [AddTextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/addtextframe/) メソッドを使用します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="参照" %}} 
- [テキストフレーム クラスの使用方法](/slides/ja/cpp/text-formatting/)
{{% /alert %}}

### **プレゼンテーション全体にテキストウォーターマークを追加する**

プレゼンテーション全体（すべてのスライド）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/masterslide/) に追加します。残りのロジックは単一スライドに追加する場合と同じです。まず [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) オブジェクトを作成し、次に [AddTextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/addtextframe/) メソッドでウォーターマークを追加します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="参照" %}} 
- [スライドマスタの使用方法](/slides/ja/cpp/slide-master/)
{{% /alert %}}

### **ウォーターマーク形状の透明度を設定する**

デフォルトでは、長方形形状は塗りと線の色が設定されています。次のコード行で形状を透過させます。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **テキストウォーターマークのフォントを設定する**

以下のようにテキストウォーターマークのフォントを変更できます。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **ウォーターマークテキストの色を設定する**

テキストの色を設定するコードは次のとおりです。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **テキストウォーターマークを中央に配置する**

ウォーターマークをスライドの中央に配置するには、次の操作を行います。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

以下の画像は最終結果を示しています。

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションのスライドに画像ウォーターマークを追加するには、次の手順を実行します。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **ウォーターマークの編集ロック**

ウォーターマークの編集を防止する必要がある場合は、形状に対して [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/get_autoshapelock/) メソッドを使用します。このプロパティを利用すると、形状の選択、サイズ変更、再配置、他の要素とのグループ化、テキストの編集ロックなどを保護できます。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// ウォーターマーク形状を編集できないようにロックする
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **ウォーターマークを前面に持ってくる**

Aspose.Slides では、[IShapeCollection::Reorder](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/reorder/) メソッドで形状の Z 順序を設定できます。このメソッドをプレゼンテーションのスライドコレクションから呼び出し、形状参照と目的の順序番号を渡すことで、形状を前面または背面に移動できます。ウォーターマークをスライドの前面に配置したい場合に便利です。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定する**

以下は、ウォーターマークをスライド全体の対角線上に配置するために回転角度を調整するコード例です。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **ウォーターマークに名前を設定する**

Aspose.Slides では形状に名前を設定できます。形状名を使用すると、後でその形状にアクセスして変更または削除できます。ウォーターマーク形状に名前を設定するには、[IAutoShape::set_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_name/) メソッドを呼び出します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **ウォーターマークを削除する**

ウォーターマーク形状を削除するには、[IAutoShape::get_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_name/) メソッドでスライド内の形状を検索し、見つけた形状を [IShapeCollection::Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/remove/) メソッドに渡します。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **ライブ例**

**Aspose.Slides 無料** のオンラインツールである [ウォーターマークの追加](https://products.aspose.app/slides/ja/watermark) と [ウォーターマークの削除](https://products.aspose.app/slides/ja/watermark/remove-watermark) をご確認ください。

![ウォーターマークの追加と削除のオンラインツール](online_tools.png)

## **よくある質問**

### ウォーターマークとは何で、なぜ使用すべきですか？

ウォーターマークはスライドに重ねて表示されるテキストまたは画像で、知的財産の保護、ブランド認知の向上、プレゼンテーションの不正使用防止に役立ちます。

### プレゼンテーションのすべてのスライドにウォーターマークを追加できますか？

はい、Aspose.Slides を使用すると、プログラムでプレゼンテーションの各スライドにウォーターマークを追加できます。すべてのスライドをループして個別に設定できます。

### ウォーターマークの透明度はどう調整できますか？

形状の塗り設定（[FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/get_fillformat/)）を変更することで、ウォーターマークの透明度を調整できます。これにより、目立ちすぎずスライドの内容を妨げないようにできます。

### ウォーターマークでサポートされている画像形式は何ですか？

Aspose.Slides は PNG、JPEG、GIF、BMP、SVG などさまざまな画像形式をサポートしています。

### テキストウォーターマークのフォントやスタイルをカスタマイズできますか？

はい、フォント、サイズ、スタイルを自由に選択して、プレゼンテーションのデザインやブランドガイドラインに合わせることができます。

### ウォーターマークの位置や向きはどう変更しますか？

形状の座標、サイズ、回転プロパティをプログラムで変更することで、ウォーターマークの位置や向きを調整できます。