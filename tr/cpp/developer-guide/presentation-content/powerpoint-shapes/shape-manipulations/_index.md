---
title: C++'ta Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/cpp/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil klonlama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil ayar noktası
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- şekil SVG olarak
- şekili SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum şekillerini tanımlama, ayarlama, klonlama, kaldırma, gizleme, yeniden sıralama, dışa aktarma, hizalama ve çevirme konusunda öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) olarak temsil eder. Bu koleksiyon, şekilleri bulup değiştirmenizi sağlayan ve yığılma sırasının kaynağıdır: `0` indeksi en arka şekildir, son indeks ise en ön şekildir.

Bu makale bu modeli izler. Önce bir şekli güvenilir şekilde nasıl tanımlayacağınızı ve önceden ayarlanmış şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri klonlama, kaldırma, gizleme ve yeniden sıralama konularını gösterir. Son bölümler düzen seviyesi biçimlendirme, SVG dışa aktarımı, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece iş akışınız için gerekli işlemleri yalnızca kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğu ve yönetildiğine göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) geliştirici kontrolündeki şablonlar için faydalıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; kod bu isimlere dayanıyorsa bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_alternativetext/) bir erişilebilirlik açıklaması veya yazar‑tarafından sağlanan bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_officeinteropshapeid/) yalnızca okuma izni olan bir tanımlayıcıdır, bir slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca belirsiz olmayan bir referansa ihtiyacınız olduğunda kullanın. Klonlanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik kritikse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Alternatif metin başlığı ve açıklamasını okuma ve güncelleme konusunda pratik bir örnek için [Manage Alternative Text Titles and Descriptions](/slides/tr/cpp/presentation-accessibility/) bölümüne bakın. Alternatif metni, görselin anlamını okuyuculara açıklamak için kullanın ve kodun şekilleri bulmak için kullandığı şekil adlarından ayrı tutun.

Aşağıdaki örnek `Name` üzerinden arama yapar ve slayt‑kapsamlı interop kimliğini raporlar. Şablonda beklenen şekil bulunmadığında, kod yanlış nesneyle devam etmek yerine bu sonucu bildirir.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ise metin ve alternatif metni günceller.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Önceden Ayarlanmış Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden ayarlanmış geometrik şekiller köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bu noktalara, yalnızca okuma izni olan [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igeometryshape/get_adjustments/) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/) değiştirilebilen bir değer içerir.

Sabit bir koleksiyon indeksine sadece güvenmeyin. Ayarları döngüyle gezerek yalnızca okuma izni olan [IAdjustValue::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_type/) özelliğini inceleyin; bu özelliğin [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini tanımlar. Okuma izni olan [IAdjustValue::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_name/) özelliği ek kimlik bilgisi sağlar ve aynı anlamsal türde birden fazla ayar bulunduğunda özellikle kullanışlıdır.

Ayarlamanın anlamına uyan değer özelliğini kullanın:

| Ayar türü | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [RawValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `RawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `RawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `RawValue` |
| `StartAngle` | Pasta ya da yay başlangıç açısı | [AngleValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Pasta ya da yay bitiş açısı | `AngleValue` |

`Type` ve `Name` atanamaz. `RawValue`, önceden ayarlanmış şeklin yerel geometri birimlerinde okuma/yazma tamsayıdır; `AngleValue` ise derece cinsinden okuma/yazma açıdır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igeometryshape/get_shapetype/) değerine bağlıdır. Bir önceden ayarlanmış için geçerli olan bir değer, başka bir önceden ayarlanmışta geçersiz olabilir veya farklı etki gösterebilir.

`Type` `ShapeAdjustmentType::Custom` olduğunda API standart bir anlamsal anlam tanımaz. `Name`, önceden ayarlanmış tür ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan türler için bile aynı tür birden fazla kez ortaya çıkıyorsa, bir değer seçmeden önce kontrol edin. [Connector](/slides/tr/cpp/connector/) makalesi, bağlayıcı kıvrım ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı döngüyle gezerek `Name` ve `Type` rapor eder, boyutla ilgili değerleri `RawValue` ile, açıları `AngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi; sağ sütun ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve pastayı gösterir.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Varsayılan ve ayarlanmış şekil sütunları için başlıklar ekler.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Değeri değiştirmeden önce anlamsal türü kontrol etmek, kodun niyetini açık hâle getirir ve aynı koleksiyon indeksinin farklı önceden ayarlanmış şekillerde aynı anlama gelmesini varsaymaktan kaçınır.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, klonla, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştirirse, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Klonlama**

[AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinat kabul eden aşırı yüklemeler klonu boyutunu değiştirmeden taşırken, genişlik‑yükseklik kabul edenler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni ön tarafa klonlar ve ikinci bir klonu arka tarafa ekler. Her iki klon üzerindeki değişiklikler kaynak şekli etkilemez.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Klonlama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de kapsar. Bu değerlerin benzersiz olması gerekiyorsa klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldırma**

[Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden çok eşleşmeyi kaldırırken, her kalan indeksin geçerli kalmasını sağlamak için sondan itibaren dolaşın.

Bu örnek, belirli bir isim taşıyan tüm şekilleri kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indeksli şekli okur ve şekli gereksiz yere cast etmez.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kaldırma sonrası, şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmemiş şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca bağlayıcılar, animasyonlar ve kaldırılan nesneye referans verebilecek diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_hidden/) değerini `true` yapmak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimi ve içeriği kod için hâlâ ulaşılabilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Gizleme, silme veya güvenlik değildir. Nesne hâlâ keşfedilebilir, kullanıcı ya da kod tarafından gizlilik kaldırılabilir ve sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [Reorder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/reorder/) mevcut bir şekli klonlamadan hedef indekse taşır. `0` indeksi arka, `Count - 1` indeksi ön taraftır.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında yer alır. Son indekse taşındığında ön tarafa gelir. Tüm ilgili şekiller eklendikten veya klonlandıktan sonra z‑sırasını kesin, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, normal bir slaytta aynı konumda bulunan şekil ile aynı nesne değildir. Düzenin sağladığı biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_lineformat/) özelliklerini okur; her şeklin bir `AutoShape` olduğunu varsaymaz.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Bir düzeni düzenlemek, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu, yerel bir geçersiz kılma var mı belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[WriteAsSvg](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/writeassvg/) bir şeklin render edilmiş içeriğini akıma yazar. Sonuçta yalnızca şekil bulunur, tüm slayt arka planı veya komşu şekiller dahil edilmez.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akımı çağıran taraf sahiplenir ve kapatmalı veya yok etmelidir.

## **Şekilleri Hizalama**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirine göre hizalanır.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce geçerli indekslerine dönüştürülür.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hizalama konumları değiştirir, z‑sırasını etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise boşluk tanımlamak için yeterli sayıda şekil gerekir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve döndürmeyi saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevirilmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir; yeni bir [Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_frame/) atamak çerçevenin tamamını değiştirir.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kaydedilen şekil, konum, boyut ve döndürme korunarak yatay ve dikey olarak aynalanır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksi şekil tanımlayıcısı olarak kullanılmalı mı?**

Sadece koleksiyon değişmeyecek kısa vadeli işlemelerde kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` veya `AlternativeText` konvansiyonu, slayt‑kapsamlı interop çalışması için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek z‑sırasını kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden bir klon şekil başka bir şeklin önüne çıktı?**

`AddClone` klonu koleksiyonun sonuna ekler; bu z‑sırasının ön kısmıdır. Başlangıç indeksi seçmek için `InsertClone` kullanın veya tüm şekiller eklendikten sonra `Reorder` yapın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Yalnızca tam olarak aynı önceden ayarlanmış ve koleksiyon düzeni doğrulandıysa. `IGeometryShape::get_Adjustments` üzerinden döngüyle geçmeyi ve `IAdjustValue::get_Type` kontrol etmeyi tercih edin; aynı anlamsal tür birden çok kez ortaya çıkıyorsa ek bilgi olarak `IAdjustValue::get_Name` kullanın.