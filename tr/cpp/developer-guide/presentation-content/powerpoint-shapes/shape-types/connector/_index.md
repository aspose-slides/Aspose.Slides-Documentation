---
title: C++ Kullanarak Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/cpp/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- bağlantı noktası
- ayarlama noktası
- şekilleri bağla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile düz, eğimli ve kıvrımlı PowerPoint bağlayıcılarını ekleme, bağlama, yönlendirme, ayarlama ve inceleme yöntemlerini öğrenin."
---
## **Genel Bakış**

Bağlayıcı, iki şekilden biri hareket ettiğinde bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint'te yeşil noktalarla gösterilen bağlantı noktalarına bağlanır. Bazı kıvrık ve eğimli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayarlama noktalarını ortaya çıkarır; bu noktalar bağlayıcının bireysel segmentlerinin konumunu kontrol eder.

Aspose.Slides, bağlayıcıları [IConnector](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/) arabirimi aracılığıyla temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlantı noktalarını seçebilir, yönlerini yeniden belirleyebilir ve ayarlama noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapetype/) enumerasyonu düz, eğimli ve kavisli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, mevcut bağlayıcı geometrilerini ve her ön ayarda tanımlı ayarlama noktalarının sayısını gösterir.

| Bağlayıcı | Görsel | Ayarlama noktalarının sayısı |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ayarlama noktalarının sayısı ve anlamı seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı tipinin aynı koleksiyon düzenini gösterdiğini varsaymayın.

## **İki Şekli Bağla**

Bir bağlayıcı eklemek için [IShapeCollection::AddConnector](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addconnector/) kullanın ve uçlarını bağlamak için [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) ve [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) çağırın. Her iki uç da bağlandıktan sonra, [IConnector::Reroute](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/reroute/) bağlayıcılar arasındaki kısa bir yolu seçer.

İşte aşağıdaki örnek, bir elips ile bir dikdörtgeni kıvrık bir bağlayıcıyla bağlar:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Uyarı" %}}
`IConnector::Reroute` çağrısı, [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) ve [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) değerlerini değiştirebilir. Bu noktaların sabit kalması gerekiyorsa, yönlendirme sonrasında belirli bağlantı noktalarını atayın.
{{% /alert %}}

## **Bağlantı Noktası Seçin**

Bağlanabilir her şekil, bağlantı noktası sayısını [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_connectionsitecount/) aracılığıyla raporlar. Bir bağlayıcı ucuna atamadan önce tercih edilen sıfır tabanlı yer indeksini doğrulayın; yer sayıları şeklin geometrisine göre değişir.

Bu örnek, elips üzerindeki belirli bir bağlantı noktasına (varsa) bağlayıcıyı bağlar:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **Bir Bağlayıcı Noktasını Ayarlama**

Ayarlama noktalarına sahip bağlayıcılar, bu noktaları [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igeometryshape/get_adjustments/) aracılığıyla ortaya çıkarır. Her bir [IAdjustValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/) inceleyin ve [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/set_rawvalue/) değiştirmeden önce [IAdjustValue::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_type/) değerini kontrol edin. Ön ayar şekil ayarlamalarını tanımlama kuralları, [Shape Manipulation](/slides/tr/cpp/shape-manipulations/) bölümünde açıklanmıştır.

Bağlayıcı ayarlamalarının sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. `IAdjustValue::get_Type` tarafından döndürülen tip yalnızca okunur, ham ayarlama değeri ise yazılabilir. Bağlayıcı aynı anlamsal tipe sahip birden fazla ayarlamaya sahip olduğunda, yalnızca okunur [IAdjustValue::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_name/) yöntemi ek tanımlama sağlar.

### **Bir Engel Çevresinde Yönlendirme**

Aşağıdaki yerleşimde, iki şekil arasındaki `ShapeType::BentConnector5` bağlayıcı, üçüncü bir şekilden geçer:

![connector-obstruction](connector-obstruction.png)

Bu kod, engellenmiş bağlayıcıyı oluşturur:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

Dikey bükülmenin hareket ettirilmesi, yönü değiştirerek bağlayıcının engeli atlatmasını sağlar:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Toplama indeksinin `1`'inin her zaman dikey bükülmeyi temsil ettiğini varsaymak yerine, bu örnek `ShapeAdjustmentType::ConnectorBendPositionY` öğesini arar ve yalnızca beklenen anlamsal tip mevcut olduğunda değiştirir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

`ShapeType::BentConnector5` iki `ShapeAdjustmentType::ConnectorBendPositionX` ayarlaması ve bir `ShapeAdjustmentType::ConnectorBendPositionY` ayarlaması içerir. İhtiyacınız olan tip birden fazla kez oluşuyorsa, seçim yapmadan önce `IAdjustValue::get_Name` ve o ön ayarın bilinen geometrisini inceleyin. Bir ayarlama `ShapeAdjustmentType::Custom` bildiriyorsa, anlamını ve aralığını ön ayara özgü olarak ele alın ve bu sözleşme bilinene kadar değiştirmeyin.

## **Ayarlama Değerlerini Bağlayıcı Geometrisiyle İlişkilendirme**

Eğimli bağlayıcılar için, ayarlama değerleri bireysel segmentlerin konumlarını tahmin etmekte kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özgüdür:

- `ShapeType::BentConnector4` genellikle bir `ShapeAdjustmentType::ConnectorBendPositionX` ve bir `ShapeAdjustmentType::ConnectorBendPositionY` ayarlaması gösterir.
- Bu bükülme konumları için `RawValue / 100000.0f`, aşağıdaki örneklerde kullanılan bağlayıcı çerçevesinin genişlik ya da yükseklik oranını üretir.
- Bir bağlayıcı çerçevesi döndürülebilir veya çevrilebilir; bu yüzden çerçeve koordinatları slayt koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce ayarlamaları tanımlamak için `IAdjustValue::get_Type` kullanır. Toplama indekslerini taşınabilir tanımlayıcılar olarak ele almazlar.

### **Döndürülmemiş Bağlayıcı**

İlk yerleşim, bir `ShapeType::BentConnector4` ile bağlanmış iki metin şekli içerir:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek, bağlayıcıyı inceler ve yatay ve dikey bükülme ayarlamalarını elde eder:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

Her iki bükülmeyi değiştirmek için, beklenen her tipi bulun ve her ikisi de bulunduktan sonra değerleri değiştirin:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

Sonuç, yatay ve dikey segmentleri hareket eden bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Anlamsal tipler belirlendikten sonra, değerler bağlayıcı-çerçeve koordinatlarına dönüştürülebilir. Bu örnek, iki bükülme ayarlamasıyla kontrol edilen dikey segmentin üzerine ince bir dikdörtgen çizer:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Kılavuz şekli, hesaplanan segmenti işaretler:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey yönlendirildiğinde, [IShape::get_Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapeframe/get_fliph/), ve [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapeframe/get_flipv/) değerleri, bağlayıcı-çerçeve koordinatlarından slayt koordinatlarına dönüşümü etkiler.

Bu örnek, dikey yönlendirilmiş bağlayıcıyı oluşturur ve ayarlar:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

Ayarlanmış bağlayıcı, şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Keyfi bir dönüş açısı `alpha` için, bir bağlayıcı-çerçeve noktasını `(x, y)` çerçeve merkezi `(x0, y0)` etrafında döndürün:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90 derece yönlendirmeyi ele alır ve ilgili bağlayıcı segmenti üzerine kırmızı bir kılavuz çizer:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Kırmızı kılavuz, koordinat dönüşümünden sonra hesaplanan segmenti işaretler:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller, örneklerde kullanılan ön ayarları tanımlar, evrensel bir bağlayıcı modeli değildir. Aynı hesabı farklı bir ön ayara uygulamadan önce ayarlama tiplerini, çerçeve yönlendirmesini ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bulma**

Düz bir bağlayıcının yönü, genişlik ve yükseklik değerlerinden, yatay ve dikey çevirmeler uygulandıktan sonra hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksenden saat yönünde açıyı rapor eder:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **SSS**

**Bir bağlayıcının bir şekle bağlanıp bağlanamayacağını nasıl anlayabilirim?**

`IShape::get_ConnectionSiteCount` değerini kontrol edin. Pozitif bir sayı, şeklin bağlantı noktalarını ortaya çıkardığını gösterir. Bağlayıcının herhangi bir ucuna atamadan önce seçilen site indeksini doğrulayın.

**Bir bağlayıcı ayarlamasını koleksiyon indeksine göre tanımlayabilir miyim?**

Bir indeks, yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Bir değeri değiştirmeden önce `IAdjustValue::get_Type` kontrol edin ve aynı anlamsal tip birden fazla kez ortaya çıktığında ek bilgi sağlamak için `IAdjustValue::get_Name` kullanın.

**Bağlı bir şekil silindiğinde ne olur?**

İlgili bağlayıcı ucu bağlantısız kalır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**

Bağlamalar, bağlı şekiller slayt ile birlikte kopyalandığında genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenen uç yeniden bağlanmalıdır.