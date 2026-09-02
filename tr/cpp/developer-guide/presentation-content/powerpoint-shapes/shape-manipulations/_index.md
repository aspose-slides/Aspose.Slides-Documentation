---
title: C++'ta Sunum Şekillerini Yönetme
linktitle: Şekil İşlemleri
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
- şekil yerleşim formatları
- şekil SVG olarak
- şekli SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum şekillerini tanımlamayı, klonlamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) olarak temsil eder. Bu koleksiyon, şekilleri bulup değiştirebileceğiniz yer olduğu gibi, yığılma sırasının da kaynağıdır: `0` indeksi arka taraftaki şekli, son indeks ise ön taraftaki şekli gösterir.

Bu makale bu modeli izler. Öncelikle bir şekli güvenilir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri kopyalama, kaldırma, gizleme ve yeniden sıralama işlemlerini gösterir. Son bölümler ise düzen düzeyinde biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır; bu sayede yalnızca iş akışınızda ihtiyaç duyduğunuz işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosyayı işlerken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak ya da yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğu ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) geliştirici kontrolündeki şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu yüzden koda bağımlıysanız bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_alternativetext/) bir erişilebilirlik açıklaması ya da yazarın eklediği bir etiket zaten şekli tanımlıyorsa yararlıdır. Kullanıcılara görünür, yerelleştirilebilir ya da erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_officeinteropshapeid/) yalnızca okuma amaçlı bir tanımlayıcıdır, bir slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile entegrasyon yaparken ya da bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda bunu kullanın. Kopyalanan ya da yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı harici bir anahtar olarak ele alınmamalıdır. Uzun vadeli kimlik çok önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ var olduğunu doğrulayın.

Aşağıdaki örnek `Name` değerine göre arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablonda beklenen şekil bulunmadığında kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgüyse, tip‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, yalnızca isimli nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ise metin ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekleme, klonlama, kaldırma ve yeniden sıralama yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştirirse, o işlemden önce yakalanan indekslere güvenmeye devam etmeyin.

### **Bir Şekli Klonlamak**

[AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑sırasındaki indekse yerleştirir. Koordinatları kabul eden aşırı yüklemeler klonu boyutlandırmadan taşırken, genişlik ve yükseklik alan aşırı yüklemeler yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne klonlar ve ikinci bir klonu arka tarafa ekler. Her iki klon üzerinde yapılan değişiklikler kaynak şekli etkilemez.

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

Klonlama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi ve yeni bir şekil kimliğiyle gelir.

### **Şekilleri Kaldırmak**

[Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden çok eşleşme kaldırılırken, kalan indekslerin geçerli kalması için sondan başlanarak dolaşın.

Bu örnek, belirli bir ada sahip tüm şekilleri kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indeksli şekli okur ve şekli gereksiz yere tip dönüşümü yapmaz.

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

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye referans veren bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaytın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizlemek**

[Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_hidden/) özelliğini `true` yapmak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ erişilebilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme, silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; aynı zamanda sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirmek**

Üst üste binen şekiller koleksiyon sırasına göre boyanır. [Reorder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/reorder/) bir şekli klonlamadan hedef indekse taşır. `0` indeksi arka, `Count - 1` indeksi ön taraftır.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasındadır. Son indekse taşındığında ön tarafta yer alır. Tüm ilgili şekiller eklendikten veya klonlandıktan sonra z‑sırasını kesin, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, aynı konumda normal bir slayttaki şekil ile aynı nesne değildir. Düzenin sağladığı biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_lineformat/) özelliklerini okur; her şeklin `AutoShape` olduğu varsayılmaz.

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

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slaytın nesneyi devralıp devralmadığını ya da yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG’ye Dışa Aktarmak**

[WriteAsSvg](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/writeassvg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını ya da komşu şekilleri içermez.

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

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ve görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akımı çağıran taraf sahip olur ve kapatmalı ya da yok etmelidir.

## **Şekilleri Hizalamak**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapesalignmenttype/) kenarı, merkez hattını veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirlerine göre hizalanır.

Bu örnek üç şekli slaytın üst kenarına hizalar. Döndürme işleminden hemen önce döndürülen şekil referansları mevcut indekslerine çevrilir.

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

Hizalama konumları değiştirir, z‑sırasını değil. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay ya da dikey dağıtım ise boşluk tanımlamak için yeterli şekil sayısı ister. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüşü saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu tek bir çevirilmemiş şekil içerir.

![Şekil çevirilmeden önce](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_frame/) atanması çerçevenin tamamını değiştirir.

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

Kaydedilen şekil yatay ve dikey olarak aynalanmış olur; konumu, boyutu ve dönüşü aynı kalır.

![Şekil çevirildikten sonra](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mıyım?**

Sadece koleksiyonun indeks kullanılmadan önce değişmeyeceği kısa ömürlü işlemler için. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` kuralı, slayt kapsamlı interop çalışmaları için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir ya da tekrar görünür hâle getirilebilir.

**Klonlanan bir şekil neden başka bir şeklin önünde belirdi?**

`AddClone` klonu koleksiyonun sonuna ekler; bu z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `InsertClone` kullanın ya da tüm şekiller eklendikten sonra `Reorder` ile konumlandırın.