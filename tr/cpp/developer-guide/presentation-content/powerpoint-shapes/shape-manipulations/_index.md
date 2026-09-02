---
title: "C++'ta Sunum Şekillerini Yönetme"
linktitle: "Şekil Manipülasyonu"
type: docs
weight: 40
url: /tr/cpp/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil ayar noktası
- önceden tanımlı şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- Şekil SVG olarak
- Şekli SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon hem şekilleri bulup değiştirdiğiniz yer hem de yığın sırasının kaynağıdır: `0` indeksi en arka şekildir, son indeks ise en ön şekildir.

Bu makale o modele dayanır. Önce bir şekli güvenilir bir şekilde nasıl tanımlayıp önceden ayarlanmış şekil ayar noktalarını değiştireceğinizi, ardından şekilleri nasıl klonlayıp, kaldırıp, gizleyip ve yeniden sıralayacağınızı açıklar. Son bölümler ise düzen seviyesindeki biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece iş akışınızın gerektirdiği işlemleri tek başına kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken uygundur, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak ya da yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve bakıldığına göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) geliştirici kontrolündeki şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; kod bu isimlere bağlıysa bir adlandırma konvansiyonu oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_alternativetext/) bir erişilebilirlik açıklaması ya da yazarın sağladığı bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılara görünür, yerelleştirilebilir ya da erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_officeinteropshapeid/) okunabilir bir tanımlayıcıdır, bir slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Klonlanmış ya da yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı dış anahtar olarak görülmemelidir. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek `Name` ile arama yapar ve slayt kapsamındaki interop kimliğini raporlar. Şablon beklenen şekli içermiyorsa kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil tipine özgüyse, tip‑özel üyelere erişmeden önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

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

## **Önceden Tanımlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden tanımlı geometrik şekiller köşe boyutu, ok oranları ya da yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bu noktalara yalnızca okunabilir [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igeometryshape/get_adjustments/) koleksiyonu aracılığıyla erişilir. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/) değiştirilebilen bir değer içerir.

Yalnızca sabit bir koleksiyon indeksine güvenmeyin. Ayarları dolaşın ve yalnızca okunabilir [IAdjustValue::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_type/) özelliğini inceleyin; bu özellik, [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeadjustmenttype/) değeriyle ayarın neyi kontrol ettiğini açıklar. Yalnızca okunabilir [IAdjustValue::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/get_name/) özelliği ek kimlik bilgisi sağlar ve aynı anlamsal tipe sahip birden fazla ayar içeren önceden tanımlı şekillerde özellikle yararlıdır.

Ayara karşılık gelen değer özelliğini kullanın:

| Ayarlama türü | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [RawValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `RawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `RawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `RawValue` |
| `StartAngle` | Dilim ya da yay başlangıç açısı | [AngleValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Dilim ya da yay bitiş açısı | `AngleValue` |

`Type` ve `Name` atanamaz. `RawValue` önceden tanımlı şeklin yerel geometri birimlerinde okunabilir/yazılabilir bir tamsayıdır, `AngleValue` ise derece cinsinden okunabilir/yazılabilir bir açıdır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı önceden tanımlı [ShapeType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igeometryshape/get_shapetype/) değerine bağlıdır. Bir önceden tanımlı için geçerli bir değer, başka bir önceden tanımlı için geçersiz olabilir ya da farklı bir etki yaratabilir.

`Type` `ShapeAdjustmentType::Custom` olduğunda API standart bir anlamsal anlam tanımaz. `Name`, önceden tanımlı tip ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tipler için bile aynı tip birden fazla kez göründüğünde bir değer seçmeden önce kontrol edin. [Connector](/slides/tr/cpp/connector/) makalesi bu durumu bağlayıcı bükme ayarlarıyla gösterir.

Aşağıdaki tam örnek, üç önceden tanımlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı dolaşır, `Name` ve `Type` değerlerini raporlar, boyutla ilgili değerleri `RawValue` ile, açıları `AngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlatılmış dikdörtgeni, dört yönlü oku ve dilimi gösterir.

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

// Varsayılan ve ayarlanmış şekil sütunları için başlıkları ekler.
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

Değiştirmeden önce anlamsal tipi kontrol etmek, kodun amacını açıklığa kavuşturur ve aynı koleksiyon indeksinin farklı önceden tanımlı şekillerde aynı anlama geldiğini varsaymayı önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, klonla, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Klonlama**

[AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirli bir z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler klonu boyutunu değiştirmeden taşırken, genişlik ve yükseklik kabul eden aşırı yüklemeler yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne klonlar ve ikinci klonu arkaya ekler. Her iki klona yapılan değişiklikler kaynak şekli etkilemez.

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

Klonlama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa klona yeni mantıksal kimlikler atayın. Karmaşık şekiller tarafından kullanılan kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi ve yeni bir şekil kimliği alır.

### **Şekilleri Kaldırma**

[Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. Birden fazla eşleşmeyi indeksli döngü sırasında kaldırırken, kalan indekslerin geçerli kalması için sondan başlanarak dolaşın.

Bu örnek, belirlenmiş bir isimle her şekli kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indeksli şekli okur ve şekli gereksiz yere dönüştürmez.

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

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye referans verebilecek bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_hidden/) değerini `true` olarak ayarlamak şekli koleksiyonda tutar ancak normal gösterimde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği kod tarafından hâlâ erişilebilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme silme ya da güvenlik değildir. Nesne hâlâ bir kullanıcı ya da kod tarafından bulunabilir ve gizliliği kaldırılabilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Order Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre çizilir. [Reorder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/reorder/) mevcut bir şekli klonlamadan hedef indekse taşır. `0` indeksi arka, `Count - 1` indeksi ön demektir.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşınması onu öne getirir. Tüm ilgili şekiller eklenip/klonlandıktan sonra z‑order’ı sonlandırın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, aynı konumda bir normal slayttaki şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_lineformat/) özelliklerini, her şeklin bir `AutoShape` olduğu varsayımına dayanılmadan okur.

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

Bir düzeni düzenlemek, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirilmeden önce normal bir slaydın nesneyi devralıp devralmadığını ya da yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[WriteAsSvg](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/writeassvg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, tüm slayt arka planı ya da komşu şekiller yerine yalnızca şekli içerir.

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

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ile resimler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Çağıran akımı yönetir ve kapatmalı ya da dispose etmelidir.

## **Şekilleri Hizalama**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirlerine göre hizalanır.

Bu örnek üç şekli slaydın üst kenarına hizalar. Döndürülen şekil referansları hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑order’ı etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirirken, yatay ya da dikey dağıtım yeterli boşluk tanımlamak için yeterli sayıda şekil gerekir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüşü saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) kullanır: `True` çeviriyi etkinleştirir, `False` devre dışı bırakır ve `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu tek bir çevirilmemiş şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek her diğer çerçeve değerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_frame/) atanması tüm çerçeveyi değiştirir.

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

Kaydedilen şekil konum, boyut ve dönüşünü korurken yatay ve dikey olarak aynalanır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksini şekil tanımlayıcısı olarak kullanmalı mıyım?**

İndeks yalnızca koleksiyonun işlem sırasında değişmeyeceği kısa vadeli senaryolarda kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` konvansiyonu, slayt kapsamlı interop çalışmaları için ise `OfficeInteropShapeId` tercih edilmelidir.

**Bir şekli gizlemek z‑order’dan çıkarır mı?**

Hayır. Gizli bir şekil aynı indeksle koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir ya da tekrar görünür hâle getirilebilir.

**Klonlanan bir şekil neden başka bir şeklin önünde göründü?**

`AddClone` klonu koleksiyonun sonuna ekler; bu da z‑order’ın ön kısmıdır. İlk indeksi seçmek için `InsertClone` kullanın ya da tüm şekiller eklendikten sonra `Reorder` ile konumlandırın.

**Önceden tanımlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece kesin önceden tanımlı ve koleksiyon düzeni doğrulandıysa kullanılabilir. `IGeometryShape::get_Adjustments` içinde dolaşıp `IAdjustValue::get_Type` kontrol etmeyi tercih edin; aynı anlamsal tip birden fazla kez göründüğünde ek bilgi için `IAdjustValue::get_Name` kullanın.