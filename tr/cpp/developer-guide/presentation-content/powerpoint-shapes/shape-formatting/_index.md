---
title: C++'ta PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/cpp/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- eskiz şekil çizgisi
- birleştirme stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil renderleme
- gri ölçekli şekil renderleme
- şekil döndürme
- 3B keskinleştirme efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te şekilleri kenarlıklarını, doldurmalarını ve efektlerini ayarlayarak biçimlendirin. Aspose.Slides for C++ bu ayarları programlı olarak kontrol etmenizi sağlar; şeffaflık, dönüş ve 3B biçimlendirme dahil.

![PowerPoint’te Şekil Biçimlendirme Seçenekleri](format-shape-powerpoint.png)

Aspose.Slides for C++ aynı seçenekleri PowerPoint’te bulunan biçimlendirme seçeneklerini kullanarak şekil biçimlendirmenize olanak tanıyan arabirimler ve yöntemler sağlar.

## **Çizgi Biçimlendirme**

[IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) kullanarak bir şeklin kenarlığını kontrol edin. Bu örnek doldurulmamış bir dikdörtgeni mavi, kesikli bir kenarlıkla oluşturur. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) kalın-ince bileşik bir çizgi seçerken, [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) genişliğini 7 puan olarak ayarlar ve [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) çizgi desenini seçer.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Sunumda biçimlendirilmiş çizgiler](formatted-lines.png)

### **Özel Çizgi Çizim Desenlerini Ayarlama**

Önceden tanımlı çizgi stilleri gerekli çizgi uzunlukları ve boşluklarını sunmuyorsa, örneğin marka kenarlıkları veya teknik diyagramlar için, [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) kullanın. Bir desen atanması, çizgi stilini otomatik olarak [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) olarak değiştirir.

Dizi girdileri çizgi ve boşluk uzunlukları arasında değişir ve bir çizgiyle başlar. Her değer, çizgi genişliğinin bir katıdır: `{ 4, 2 }` genişliği 3 puan olan bir çizgide 12 puanlık bir çizgi ve ardından 6 puanlık bir boşluk üretir. Tam çizgi‑boşluk segmentleri tanımlamak için sonlu, negatif olmayan değer çiftleri kullanın. Örnek, her çizgi ve boşluğun görünür olmasını sağlamak için pozitif değerler kullanır.

Bu örnek aynı uzunlukta ve düz uçlu beş mavi çizgi oluşturur. İlk üç çizgi desenini 3 puan genişlikte karşılaştırır. Dördüncüsü ilk deseni iki kat genişlikte (çizgi ve boşluk uzunlukları iki kat) tekrarlar. Beşincisi özel deseni katı bir çizgiye değiştirir.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Önceden tanımlı kesikli bir stile geri dönmek için, [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) yöntemine [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) parametresini geçirin. Seçilen stil çizginin görünümünü kontrol eder.

PowerPoint’te üstten alta doğru sonuç: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; ve **Solid, 3 pt**.

![Üç özel çizgi deseni, ilk deseni kullanan daha geniş bir çizgi ve PowerPoint’te katı bir çizgi](custom-dash-patterns.png)


### **Çizgi Uçlarını Ayarlama**

[ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) kullanarak açık bir çizginin uçlarını ayarlayın. [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) enumarasyonu üç açık uç stilini sağlar:

- `Flat`: Çizim uç noktasında durur.
- `Round`: Yarıçapı çizgi genişliğinin yarısı kadar olan yarım daire şekli uç noktasının ötesine uzanır.
- `Square`: Kare uç, çizgi genişliğinin yarısı kadar uç noktasının ötesine uzanır.

Enumarasyon ayrıca `NotDefined` değerini içerir; bu, herhangi bir uç stilinin açıkça atanmadığını gösterir.

Uçlar, çizgi uçlarına sembol ekleyen ok başlarından ve çizgi segmentleri arasındaki köşeleri kontrol eden birleşimlerden farklıdır. Bu örnek, sadece uç şekillerinin karşılaştırılmasını sağlamak için [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) ve [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) üzerinden ok başlarını devre dışı bırakır.

Aşağıdaki örnek, 20 puan genişliğinde, aksi takdirde aynı olan üç yatay çizgi oluşturur. Üstten alta doğru, düz, yuvarlak ve kare uçlar kullanılır. Uç noktalarının yatay koordinatları aynıdır; yuvarlak ve kare uçlar her uç noktasının 10 puan ötesine uzanır.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint’te üstten alta doğru sonuç: **Flat**, **Round** ve **Square**.

![PowerPoint’te aynı kalınlıktaki çizgilerde düz, yuvarlak ve kare uçlar](line-caps.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) ile çizgi ayarlarına, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) ile eskiz ayarlarına ve [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) ile [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) enumarasyonundan bir değer seçin.

Aşağıdaki C++ kodu, [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) tarafından döndürülen değer, doğrudan şekle atanan ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaytından devralınabiliyorsa, [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) ile erişin ve [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) değerini okuyun. Etkili değer, devralma çözüldükten sonra gerçekten uygulanan biçimlendirmeyi yansıtır. Bu örnek, ilk slaytında en az bir şekil bulunan mevcut bir sunumu gerektirir ve her iki değeri de yazdırır:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **Birleştirme Stillerini Biçimlendirme**

Aşağıda üç birleştirme tipi seçeneği bulunur:

* Round
* Miter
* Bevel

Birleştirme stili, iki kenarlık segmentinin bir köşede nasıl buluştuğunu kontrol eder. Yuvarlatılmış köşeler için **Round**, keskin köşeler için **Miter**, düzleştirilmiş köşeler için **Bevel** kullanın.

![Sunumda birleştirme stili](join-style-powerpoint.png)

Bu örnek, 15 puan genişliğinde mavi kenarlıklı üç siyah dikdörtgen oluşturur. [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) yöntemi sırasıyla [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) enumarasyonunun miter, bevel ve round değerlerine ayarlanır; böylece köşelerin nasıl çizildiği karşılaştırılır.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Keskin Köşelerde Miter Birleştirmelerini Sınırlandırma**

[ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) ve [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) yöntemini [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) ile birlikte kullanarak keskin bir köşenin ne kadar uzayabileceğini sınırlayın.

Limit, birleştirme iç ve dış köşeleri arasındaki mesafenin çizgi genişliğine oranıdır. Örneğin, `8` değeri, miter uzunluğunun çizgi genişliğinin sekiz katına kadar izin verir; bu bir puan ölçüsü değildir. Köşe limitin üstüne çıkarsa, PowerPoint o köşede bir keskinleştirilmiş (beveled) birleştirme kullanır. Daha büyük bir limit daha keskin noktalar sağlar. Ayar yalnızca miter birleştirmelerini etkiler ve köşe her iki limit içinde kalıyorsa görünür bir etkisi yoktur.

Bu örnek, 20 puan genişliğinde kenarlıklı iki aynı doldurulmamış üçgen oluşturur. Sol üçgen `2` limitini, sağ üçgen `8` limitini kullanır. Her üçgen 80 puan genişliğinde ve 160 puan yüksekliğindedir; üst köşesinin miter‑length‑to‑line‑width oranı yaklaşık `4.12` olur. Sonuç olarak, PowerPoint sol ucu keskinleştirir ve sağ ucunu korur.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint’te sonuç: **Miter limit 2** solda ve **miter limit 8** sağda.

![PowerPoint’te 2 limitli keskinleştirilmiş bir uç ve 8 limitli sivri bir uç](miter-limits.png)

## **Gradyan Doldurma**

Gradyan doldurma, bir şekil boyunca renkleri karıştırır. Bu örnek, bir elipsi kırmızıdan mor renge 45 derece açısıyla lineer gradyanla doldurur; bunun için [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/) kullanılır. [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) yöntemi renk duraklarını gradyanın başlangıcı (0) ve sonu (1) olarak yerleştirir. Mevcut durakların temizlenmesi, sadece bu iki rengin kullanılmasını sağlar.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gradyan dolu elips](gradient-fill.png)

Eğer bir gradyan dışa aktarılan bir görüntüde PowerPoint’te farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Gradyan doldurmasını sunumda değişmeden bir render stili seçebilirsiniz.

### **Lineer Gradyan Açısını Ayarlama**

[IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) ile bir [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) doldurmanın yönünü kontrol edin. Açıyı derece cinsinden ölçer ve saat yönünde artar: `0` soldan sağa, `90` üstten alta, `180` sağdan sola, `270` alttan üste. Kesirli açılar desteklenir. `[0, 360)` aralığı dışındaki sonlu açılar bir tura normalize edilir; örneğin `-45` → `315`, `360` → `0`.

Bu örnek, aynı kırmızı, yeşil ve mavi durakları `0`, `0.5` ve `1` konumlarında oluşturan altı dikdörtgen oluşturur. Ölçekleme devre dışı bırakılır, böylece açı dikdörtgenlerin oranlarından bağımsız olarak karşılaştırılabilir. Açılar soldan sağa doğru: ilk satırda `0`, `45`, `90`; ikinci satırda `135`, `180`, `270`.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint’te sonuç:

![Üst satırda 0, 45 ve 90 derece, alt satırda 135, 180 ve 270 derece lineer gradyanlar](linear-gradient-angles.png)

### **Şekille Lineer Gradyanı Ölçekleme**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) bir [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) değeri kabul eder. `False` olarak ayarlarsanız, şeklin oranları değişse bile geometrik gradyan açısı sabit kalır; `True` olarak ayarlarsanız, gradyan şeklin genişliği ve yüksekliğiyle ölçeklenir. Ölçekleme etkinleştirildiğinde, kare olmayan bir şekilde görülen açı atanmış açıdan farklı olabilir.

Aşağıdaki örnek, açı karşılaştırmasında kullanılan aynı renk duraklarıyla `45` derece açı kullanır. Sol sütun `False`; sağ sütun `True`. Her sütun geniş bir dikdörtgenin üstünde yüksek bir dikdörtgen içerir. İkincinin genişliği ve yüksekliği değiştirilerek, doldurmanın yeniden boyutlandırmaya nasıl yanıt verdiği gösterilir.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint’te sonuç, sol tarafta ölçekleme devre dışı, sağ tarafta etkin:

![Sol tarafta LinearGradientScaled False, sağ tarafta True olan geniş ve yüksek dikdörtgenler](linear-gradient-scaling.png)

Ölçekleme devre dışı bırakıldığında, diyagonal renk bantları her iki dikdörtgende aynı yönü korur. Ölçekleme etkinleştirildiğinde, bantlar şeklin oranlarıyla uzar. Bu, bir şablonun gradyanını farklı bir boyuta uyarlarken yeniden üretmeye yardımcı olur. Kare bir şekilde, ölçekleme etkinleştirilmesi bu `45` derece gradyanın görünümünü değiştirmez.

Hem açı hem de ölçekleme ayarları lineer gradyanlar için geçerlidir. [GradientShape::Radial] veya [GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) doldurmalarını kontrol etmezler.

### **Açıyı Gradyan Yönüyle Birleştirme**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) bir gradyan stilini [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) enumarasyonundan seçer; bu sayısal bir açı için bir alternatif değildir. Lineer bir gradyan için, köşe stilleri, [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) ile atanmış açıyı değiştirmeden renklerin dağıtıldığı alanı değiştirebilir. Açıyı veya ölçeklemeyi karşılaştırırken yönü aynı tutun.

Aşağıdaki örnek, aynı ayarları ters sırayla uygular. İki dikdörtgen aynı görünümü üretir: yönü açıdan önce veya sonra atamak sonucu etkilemez.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Desen Doldurma**

Desen doldurma, iki renkli bir tasarım (nokta, şerit veya dama gibi) uygular. Bu örnek, [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) ile bir ızgara deseni seçer. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) açık gri arka planı, [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) ise sarı desen rengini sağlar.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

Resim doldurma, bir şeklin içinde bir görüntü kullanır. Bu örnek yerel bir görüntü gerektirir ve [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) ile sunumun görüntü koleksiyonuna yükler. [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) özelliği döşeme (tile) moduna ayarlandığında görüntü dikdörtgen içinde tekrarlanır. Aşağıda kullanılan kaynak görüntü gösterilmiştir:

![Lotus resmi](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi Kullanma**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) sınıfı yöntemlerini kullanabilirsiniz:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Resim doldurma modunu `Tile` ya da `Stretch` olarak ayarlar.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Döşemelerin şekil içinde hizalanmasını belirler.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Döşemenin yatay, dikey ya da iki yönde ters çevrilip çevrilmeyeceğini kontrol eder.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Döşemenin yatay ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Döşemenin dikey ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Bu örnek yerel bir görüntü gerektirir ve [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) aracılığıyla orijinal boyutunun %50’si kadar tekrarlanacak şekilde ayarlar. `‑32` puan ofsetleri döşemeleri yatay ve dikey olarak kaydırır; sağ‑alt hizalama ve her iki yönde ters çevirme, tekrarlanan dokunun düzenlenişini belirler.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

Katı doldurma, bir şekle tek ve tekdüze bir renk verir. Bu örnek, [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) yöntemini katı doldurma moduna ayarlar ve [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) aracılığıyla sarı rengi atar; ardından dikdörtgeni bir sunuma kaydeder.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Slayt Arka Planını Şekil Doldurması Olarak Kullanma**

Bir şeklin slayt arka planıyla eşleşmesi gerektiğinde, örneğin bir sunum şablonunda, [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) kullanın. Öncelikle [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) metodunu [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) olarak ayarlayarak mevcut bir doldurmayı kaldırın. Bu kombinasyonla şekil, stil doldurması yerine slayt arka planını kullanır. Bayrağı yalnızca etkinleştirmek varolan bir doldurmayı kaldırmaz.

Bu, [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) seçeneğinden farklıdır: arka plan doldurması, şeklin arkasındaki nesneleri slayt arka planının karşılık gelen alanıyla kapatır, ancak dolgu olmaması bu nesneleri görünür bırakır. Bir gradyan, her şeklin içinde yeniden başlamaz; slaytla hizalanmış kalır.

Aşağıdaki örnek, slayt tarafından miras alınan bir ana arka plan oluşturur ve üç dikdörtgenin arkasına bir macenta şeridi yerleştirir. Sol dikdörtgen arka planı kullanır, orta dikdörtgen doldurmasızdır ve sağ dikdörtgen arka plan doldurmasından açık turuncu bir doldurmaya geçer.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Gradyanı master slayttan devral.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Bu nesneyi ilk ekleyin, böylece dikdörtgelerin arkasında görünür.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Arka plan doldurmasını devre dışı bırak, ardından açık bir doldurma uygula.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç, soldan sağa: **arka plan doldurması**, **doldurma yok** ve **açık doldurma**. Macenta şerit, sol ve sağ dikdörtgenler tarafından gizlenir ancak orta dikdörtgen aracılığıyla görünür kalır.

![Arka plan doldurması, doldurma yok ve açık turuncu doldurma üzerinde bir macenta şerit](background-fill.png)

Aynı davranış doğrudan slaytta tanımlanan veya bir yerleşimden miras alınan arka plan için de geçerlidir. Şekil, slaydın çözümlenmiş arka planını kullanır; örnek her iki slayt ve yerleşim arka planını tanımsız bırakır, böylece ana (master) sağlayıcı olur.

## **Şeffaflığı Ayarlama**

Katı bir doldurma için, rengin alfa bileşeni opaklığı kontrol eder: 0 tamamen şeffaf, 255 tamamen opaktır. Bu örnek, sarı bir dikdörtgene 128 alfa değeri verir; bu da yaklaşık %50 şeffaflık sağlar ve altındaki dikdörtgenin görünür kalmasını sağlar. Renk, [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) aracılığıyla atanır.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

[IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) kullanarak bir şekli slayt düzleminde döndürün. Açı derece cinsinden ölçülür; bu örnek bir dikdörtgeni saat yönünde 5 derece döndürür ve sunumu kaydeder.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şekil döndürme](shape-rotation.png)

## **3B Keskinleştirme Efektleri Ekleme**

[IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) kullanarak bir şekle derinlik ve keskin kenarlar verin. Bu örnek, yeşil bir elipsi turuncu bir kenarlıkla oluşturur, [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) değerini 4 puan olarak ayarlar ve [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) aracılığıyla 6 puan genişlik ve yükseklikte dairesel bir üst keskinleştirme uygular. Ön yüze bakan ortografik kamera ve üç noktalı aydınlatma keskinleştirmenin görünmesini sağlar.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![3B keskinleştirme efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Bir şeklin 3B görünümü kamera ayarlarıyla kontrol edilir. Bu örnek, [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) yöntemini enlemi, boylamı ve devrim açılarını sırasıyla 40, 35 ve 20 derece olarak ayarlar. [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) ile izometrik bir kamera, [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) ile dengeli aydınlatma seçilir ve biçimlendirilmiş dikdörtgen kaydedilir.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah‑Beyaz Renderlamayı Kontrol Etme**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) yöntemi, bir sunum siyah‑beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderlanacağını belirtir. Bu, yalnızca kendiliğinden siyah‑beyaz görüntülemeyi etkinleştirmez ve normal renk modunda şeklin doldurmasını, çizgisini veya diğer biçimlendirmesini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) enumarasyonundan bir değer seçerek istenen davranışı belirleyin. Örneğin, `Automatic` uygulamanın dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri tonlamayı, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek bir rengi, `Color` normal renklemeyi korur, `Hidden` ise siyah‑beyaz modunda şekli atar. `NotDefined` şekil‑düzeyinde bir mod atanmadığını gösterir.

Bu örnek turuncu bir dikdörtgen oluşturur ve [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) yöntemini griye ayarlar. Kaydedilen şekil normal renkli görüntüde turuncu dolgusunu korur ve siyah‑beyaz görüntüleme ayarlarını kullanan uygulamalardan gri renklemeyi talep eder:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Normal renk modunda dikdörtgen turuncu dolgusunu korur. Siyah‑beyaz görüntüleme iş akışında, modu `Gray` olduğundan gri renkleme kullanılır. Bu, tam renkli bir slaytı korurken baskı, ön izleme veya siyah‑beyaz görüntüleme ayarlarını onaylayan iş akışları için ayrı bir görünüm tanımlamanıza olanak verir.

## **Biçimlendirmeyi Sıfırlama**

[ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) kullanarak slayt yerleşimi yer tutucularının konum, boyut ve biçimlendirmesini, ilgili yerleşim yer tutucularından restore edin. Bu örnek, yerleşim‑bağlantılı yer tutucular içeren mevcut bir sunum gerektirir ve kaydetmeden önce her slaytı sıfırlar. Yerleşim yer tutucusu olmayan şekiller sıfırlanmaz.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Renkler, çizgi stilleri ve efekt ayarları, gömülü görüntüler ve medyaya göre çok az veri ekler. Resim doldurmaları, görüntüler sunumda depolandığı için dosya boyutunu artırabilir.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini (doldurma, çizgi, efekt ayarları) karşılaştırın. Tüm karşılık gelen değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyada kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine veya bir .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stillendirilmiş şekilleri kopyalayın ve gerektiği yerde biçimlendirmeyi yeniden uygulayın.