---
title: C++ ile PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/cpp/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- bağlama stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekil döndürme
- 3D keskinlik efekti
- 3D döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++ içinde PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![biçimlendirme-şekli-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ , PowerPoint'te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve metodlar sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linestyle/) ayarını belirleyin.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [çizgi dash stili](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linedashstyle/) ayarını belirleyin.
1. Şekil için çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape` nasıl biçimlendirileceğini gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Sunum dosyasını temsil eden Presentation sınıfını başlat.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Dikdörtgen şeklinin dolgu rengini ayarla.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Dikdörtgenin çizgilerine biçimlendirme uygula.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Dikdörtgenin çizgi rengini ayarla.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX dosyasını diske kaydet.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisini el çizimi gibi gösterir. Çizgi ayarlarına erişmek için [IShape::get_LineFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_lineformat/) , eskiz ayarlarına erişmek için [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformat/get_sketchformat/) ve [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformat/set_sketchtype/) ile [LineSketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) enum'ından bir değer seçin.

Aşağıdaki C++ kodu, bir [LineSketchType::Curved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağını, açıkça atanmış değeri nasıl okuyacağını ve [LineSketchType::None](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) ile etkiyi nasıl kaldıracağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformat/get_sketchtype/) tarafından döndürülen değer, şekle doğrudan atanan ayarı temsil eder. Çizgi biçimi bir tema, ana slayt veya yerleşim slaytından devralınabiliyorsa, [ILineFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) erişin ve [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) değerini okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekten uygulanan biçimlendirmeyi yansıtır:

```cpp
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

## **Bağlantı Stilleri Biçimlendirme**

İşte üç bağ türü seçeneği:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlama stili](join-style-powerpoint.png)

Aşağıdaki C++ kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round bağ türü ayarları kullanılarak nasıl oluşturulduğunu gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde üç otomatik şekil ekle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Her dikdörtgen şeklinin dolgu rengini ayarla.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Çizgi kalınlığını ayarla.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Her dikdörtgenin çizgi rengini ayarla.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Bağlama stilini ayarla.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Her dikdörtgene metin ekle.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX dosyasını diske kaydet.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradyan Dolgu**

PowerPoint'te Gradyan Dolgu, bir şekle sürekli bir renk geçişi uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin yavaşça diğerine karıştığı bir şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igradientformat/) arayüzünün sunduğu gradyan durak koleksiyonunun `Add` metodlarını kullanarak iki tercih ettiğiniz rengi tanımlı konumlarla ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir elipse gradyan dolgu etkisi nasıl uygulanır gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Ellipse tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Elipseye gradyan biçimlendirmesi uygula.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Gradyanın yönünü ayarla.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// İki gradyan durak ekle.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX dosyasını diske kaydet.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Gradyan dolgulu elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint'te Desen Dolgu, nokta, çizgi, çapraz çizgi veya damga gibi iki renkli bir tasarımı şekle uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini istediğiniz gibi seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir desen seçtikten sonra, yine de kullanılacak tam renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_backcolor/) (arka plan rengi) ayarını yapın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_forecolor/) (ön plan rengi) ayarını yapın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dolgu türünü Pattern olarak ayarla.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Desen stilini ayarla.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Desenin arka plan ve ön plan renklerini ayarla.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydet.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Desenli dolgu ile dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'te Resim Dolgu, bir şeklin içine bir görüntü yerleştirmenize olanak tanıyan bir biçimlendirme seçeneğidir; böylece görüntü şeklin arka planı gibi davranır.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya başka bir tercih edilen modu) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.set_Image` metoduna geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Örneğin, aşağıdaki “lotus.png” dosyasını kullanalım:

![Lotus resmi](lotus.png)

Aşağıdaki C++ kodu, bir şekli resimle doldurmanın nasıl yapılacağını gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Dolgu türünü Picture olarak ayarla.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Resim dolgu modunu ayarla.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Bir görüntü yükle ve sunum kaynaklarına ekle.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Resmi ayarla.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX dosyasını diske kaydet.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Resim dolgulu şekil](picture-fill.png)

### **Döşeme Resmi Doku Olarak**

Döşeme resmi bir doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillformat/) sınıfının metodlarını kullanabilirsiniz:

- [set_PictureFillMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Resim dolgu modunu ayarlar—`Tile` veya `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Şekil içinde döşemelerin hizalanmasını belirtir.
- [set_TileFlip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [set_TileOffsetX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Şeklin başlangıcından döşemenin yatay offsetini (puan cinsinden) ayarlar.
- [set_TileOffsetY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Şeklin başlangıcından döşemenin dikey offsetini (puan cinsinden) ayarlar.
- [set_TileScaleX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [set_TileScaleY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeme resmi dolgu ile bir dikdörtgen şekil eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto firstSlide = presentation->get_Slide(0);

// Bir dikdörtgen otomatik şekil ekle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Şeklin dolgu türünü Picture olarak ayarla.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Görüntüyü yükle ve sunum kaynaklarına ekle.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Görüntüyü şekle ata.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Resim dolgu modunu ve döşeme özelliklerini yapılandır.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX dosyasını diske kaydet.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Dolgu**

PowerPoint'te Düz Renk Dolgu, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradyan, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle istediğiniz dolgu rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir PowerPoint slaydındaki dikdörtgene düz renk dolgu nasıl uygulanır gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dolgu türünü Solid olarak ayarla.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Dolgu rengini ayarla.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydet.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Düz renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'te bir şekle düz renk, gradyan, resim veya doku dolgu uyguladığınızda, dolgunun opaklığını kontrol etmek için şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha çok geçişli olmasını sağlar; arka plan veya alttaki nesneler kısmen görülür.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflığa sahip bir renk tanımlayın (alfa bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene şeffaf dolgu rengi nasıl uygulanır gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Katı bir dikdörtgen otomatik şekil ekle.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX dosyasını diske kaydet.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli bir hizalama veya tasarım ihtiyacıyla konumlandırmak için kullanışlıdır.

Bir slayt üzerindeki bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin dönüş açısı özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekli 5 derece döndürmenin nasıl yapılacağını gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaytı al.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Şekli 5 derece döndür.
shape->set_Rotation(5);

// PPTX dosyasını diske kaydet.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Şekil döndürme](shape-rotation.png)

## **3D Keskinlik Efektleri Ekleme**

Aspose.Slides, şekillere 3D keskinlik efektleri uygulamanıza olanak tanır; bunun için [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırabilirsiniz.

Bir şekle 3D keskinlik efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliğini keskinlik ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3D keskinlik efektleri nasıl uygulanır gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Slayta bir şekil ekle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Şeklin ThreeDFormat özelliklerini ayarla.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Sunumu PPTX dosyası olarak kaydet.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D keskinlik efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere 3D döndürme efektleri uygulamanıza olanak tanır; bunun için [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırabilirsiniz.

Bir şekle 3D döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) slayta ekleyin.
1. 3D döndürmeyi tanımlamak için [set_CameraType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icamera/set_cameratype/) ve [set_LightType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrig/set_lighttype/) metodlarını kullanın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3D döndürme efektleri nasıl uygulanır gösterir:

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
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation sınıfının bir örneğini oluştur.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Sunumu PPTX dosyası olarak kaydet.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D döndürme efekti](3D-rotation-effect.png)

## **Şekiller için Siyah-Beyaz İşleme Kontrolü**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_blackwhitemode/) metodu, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl render edileceğini belirtir. Tek başına siyah-beyaz görüntülenmeyi etkinleştirmez ve normal renk modunda şeklin dolgu, çizgi veya diğer biçimlendirmesini değiştirmez.

İstediğiniz davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/blackwhitemode/) enum'undan bir değer kullanın. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri tonlamayı kullanır, `BlackWhite` sadece siyah ve beyazı kullanır, `Black` ve `White` tek bir renk zorlar, `Color` normal renklemeyi korur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` şekil seviyesinde bir mod atanmadığını gösterir.

Aşağıdaki C++ kodu, renkli bir şekil oluşturur ve siyah-beyaz görüntüleme modunda gri görünmesini sağlar:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Renk modunda turuncu dolguyu koru, ancak siyah-beyaz modunda şekli gri renkle renderla.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Normal renk modunda, dikdörtgen turuncu dolgusunu korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olarak ayarlandığı için gri renkle gösterilir. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah-beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanızı sağlar.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C++ kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Düzen üzerindeki bir yer tutucuya sahip slayttaki her şekli sıfırla.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosyasının boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur; renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan şekilleri bir slaytta tespit edip gruplamak nasıl yapılır?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir kümesini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt dosyası veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri kopyalayın ve gerekli yerlerde biçimlendirmeyi yeniden uygulayın.