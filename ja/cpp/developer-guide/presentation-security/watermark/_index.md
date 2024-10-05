---
title: ウォーターマーク
type: docs
weight: 40
url: /cpp/watermark/
keywords:
- ウォーターマーク
- ウォーターマークを追加
- テキスト ウォーターマーク
- 画像 ウォーターマーク
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: "C++でPowerPointプレゼンテーションにテキストおよび画像のウォーターマークを追加"
---

## **ウォーターマークについて**

**ウォーターマーク**は、プレゼンテーションで使用されるテキストまたは画像のスタンプで、スライドやすべてのプレゼンテーションスライドにわたって使用されます。通常、ウォーターマークはプレゼンテーションがドラフトであること（例：「ドラフト」ウォーターマーク）、機密情報が含まれていること（例：「機密」ウォーターマーク）、どの会社に属するかを指定すること（例：「会社名」ウォーターマーク）、プレゼンテーションの著者を識別するためなどに使用されます。ウォーターマークは、プレゼンテーションがコピーされるべきでないことを示すことで著作権侵害を防ぐ助けになります。ウォーターマークはPowerPointおよびOpenOfficeのプレゼンテーション形式の両方で使用されます。Aspose.Slidesでは、PowerPoint PPT、PPTX、OpenOffice ODPファイル形式にウォーターマークを追加できます。

[**Aspose.Slides**](https://products.aspose.com/slides/cpp/)では、PowerPointまたはOpenOfficeドキュメントでウォーターマークを作成し、そのデザインや動作を変更するさまざまな方法があります。共通の側面は、テキストウォーターマークを追加するには[ ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)インターフェイスを使用し、画像ウォーターマークを追加するには[PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)クラスを使用するか、ウォーターマークシェイプを画像で塗りつぶす必要があるということです。`PictureFrame`は[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)インターフェイスを実装しており、シェイプオブジェクトのすべての柔軟な設定を使用できます。`ITextFrame`はシェイプではなく、その設定が制限されているため、[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)オブジェクトにラップされます。

ウォーターマークを適用する方法は二つあり、単一スライドまたはすべてのプレゼンテーションスライドに適用できます。スライドマスターはすべてのプレゼンテーションスライドにウォーターマークを適用するために使用されます。ウォーターマークはスライドマスターに追加され、完全にデザインされ、個々のスライドのウォーターマークを修正する権限に影響を与えることなくすべてのスライドに適用されます。

ウォーターマークは通常、他のユーザーによる編集が不可能であると見なされます。ウォーターマーク（またはむしろウォーターマークの親シェイプ）が編集されるのを防ぐために、Aspose.Slidesはシェイプロック機能を提供します。特定のシェイプは、通常のスライドまたはスライドマスターでロックできます。スライドマスターでウォーターマークシェイプがロックされている場合、それはすべてのプレゼンテーションスライドでロックされます。

将来的にウォーターマークを削除したい場合に備えて、その名前を設定することができます。

ウォーターマークは任意の方法でデザインできますが、通常、中央揃え、回転、前面位置などの共通の特徴があります。これらを以下の例で使用する方法を考察します。

## **テキストウォーターマーク**

### **スライドにテキストウォーターマークを追加する**

PPT、PPTX、またはODPにテキストウォーターマークを追加するには、まずスライドにシェイプを追加し、その後このシェイプにテキストフレームを追加します。テキストフレームは[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)インターフェイスによって表されます。このタイプは、ウォーターマークの位置決めのための広範なプロパティを持つ[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)からは継承されません。したがって、[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)オブジェクトは[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)オブジェクトにラップされます。ウォーターマークのテキストをシェイプに追加するには、以下に示すように[AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/)メソッドを使用します。

```cpp
auto watermarkText = u"機密";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="参照" %}} 
- [TextFrameクラスの使用方法](/slides/cpp/text-formatting/)
{{% /alert %}}

### **プレゼンテーションにテキストウォーターマークを追加する**

プレゼンテーション全体（つまり、すべてのスライドに一度に）にテキストウォーターマークを追加したい場合は、[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)に追加します。残りのロジックは、単一スライドにウォーターマークを追加する場合と同じです。 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)オブジェクトを作成し、次に[AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/)メソッドを使用してそれにウォーターマークを追加します。

```cpp
auto watermarkText = u"機密";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="参照" %}} 
- [スライドマスターの使用方法](/slides/cpp/slide-master/)
{{% /alert %}}

### **ウォーターマークシェイプの透明度を設定する**

デフォルトでは、長方形のシェイプは塗りつぶしと線の色でスタイルが設定されています。以下のコード行は、シェイプを透明にします。

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **テキストウォーターマークのフォントを設定する**

テキストウォーターマークのフォントを以下のように変更できます。

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **ウォーターマークテキストの色を設定する**

ウォーターマークテキストの色を設定するには、次のコードを使用します。

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **テキストウォーターマークを中央揃えにする**

ウォーターマークをスライドの中央に配置することができ、そのためには以下のようにします。

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

![テキストウォーターマーク](text_watermark.png)

## **画像ウォーターマーク**

### **プレゼンテーションに画像ウォーターマークを追加する**

プレゼンテーションスライドに画像ウォーターマークを追加するには、次のようにします。

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **ウォーターマークを編集からロックする**

ウォーターマークが編集されるのを防ぐ必要がある場合は、シェイプの[IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/)メソッドを使用します。このプロパティを使用して、シェイプを選択できなくしたり、サイズ変更や移動、他の要素とのグループ化を無効にしたり、テキストの編集をロックしたりすることができます。

```cpp
// ウォーターマークシェイプを修正からロックする
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **ウォーターマークを前面に持ってくる**

Aspose.Slidesでは、シェイプのZ順序を[IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/)メソッドを介して設定できます。これを行うには、このメソッドをプレゼンテーションスライドリストから呼び出し、シェイプの参照とその順序番号をメソッドに渡す必要があります。この方法で、シェイプを前面に持っていったり、スライドの後方に送ったりできます。この機能は、プレゼンテーションの前面にウォーターマークを配置する必要があるときに特に便利です。

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **ウォーターマークの回転を設定する**

ウォーターマークの回転を調整して、スライドに斜めに配置されるようにするコード例は以下の通りです。

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **ウォーターマークの名前を設定する**

Aspose.Slidesでは、シェイプの名前を設定することができます。シェイプ名を使用することで、将来的にそれを修正または削除するためにアクセスできます。ウォーターマークシェイプの名前を設定するには、[IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/)メソッドに割り当てます。

```cpp
watermarkShape->set_Name(u"watermark");
```

## **ウォーターマークを削除する**

ウォーターマークシェイプを削除するには、[IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/)メソッドを使用してスライドシェイプの中からそれを見つけます。その後、ウォーターマークシェイプを[IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/)メソッドに渡します。

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

**Aspose.Slides無料**の[ウォーターマークを追加](https://products.aspose.app/slides/watermark)および[ウォーターマークを削除](https://products.aspose.app/slides/watermark/remove-watermark)オンラインツールをご覧になると良いでしょう。

![ウォーターマークを追加および削除するためのオンラインツール](online_tools.png)