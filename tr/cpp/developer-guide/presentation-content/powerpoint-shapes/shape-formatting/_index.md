---
title: C++'ta PowerPoint Şekillerini Biçimlendir
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/cpp/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- taslak efekti
- şekil çizgi taslak efekti
- eklem stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekli döndür
- 3B kırma efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, çevrelerine (çerçevelerine) etkiler uygulayarak veya değiştirerek biçimlendirebilirsiniz. Ayrıca şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![biçimlendirilmiş-şekil-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ şekilleri PowerPoint'te bulunan aynı seçenekleri kullanarak biçimlendirmenizi sağlayan arabirimler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel çizgi stili belirtebilirsiniz. Aşağıdaki adımlar işlemi özetler:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape`'ı nasıl biçimlendireceğinizi gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Dikdörtgen şeklinin doldurma rengini ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Dikdörtgenin çizgilerine biçimlendirme uygulayın.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Dikdörtgenin çizgi rengini ayarlayın.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX dosyasını diske kaydedin.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Taslak Efektleri Uygulama**

Bir taslak efekti, şekil çizgisini el çizimi gibi gösterir. Çizgi ayarlarına erişmek için [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) kullanın, taslak ayarlarına erişmek için [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) ve [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) enum'ından bir değer seçmek için [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) kullanın.

Aşağıdaki C++ kodu, bir [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) etkisi uygulamayı, açıkça atanmış değeri okumayı ve [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) ile efekti kaldırmayı gösterir:

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

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir tema, ana slayt veya yerleşim slaytından devralınabiliyorsa, [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) erişin ve [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) okuyun. Etkili değer, devralma çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Eklem Stilleri Biçimlendirme**

İşte üç eklem tipi seçeneği:

* Yuvarlak
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Yuvarlak** ayarını kullanır. Ancak keskin açılarla bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki eklem stili](join-style-powerpoint.png)

Aşağıdaki C++ kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Yuvarlak eklem tipi ayarları kullanılarak üç dikdörtgenin nasıl oluşturulduğunu gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde üç otomatik şekil ekleyin.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Her bir dikdörtgen şeklinin doldurma rengini ayarlayın.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Çizgi genişliğini ayarlayın.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Her bir dikdörtgenin çizgi rengini ayarlayın.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Eklem stilini ayarlayın.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Her bir dikdörtgene metin ekleyin.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX dosyasını diske kaydedin.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gradyan Doldurma**

PowerPoint'te Gradyan Doldurma, bir şekle sürekli bir renk geçişi uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Örneğin, bir rengin diğerine yavaşça karıştığı iki ya da daha fazla renk uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) arabirimi tarafından sunulan gradyan durak koleksiyonunun `Add` yöntemleriyle tanımlı konumlarda iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir elipse gradyan doldurma efekti nasıl uygulanır gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Ellipse türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Elipseye gradyan biçimlendirmesi uygulayın.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Gradyanın yönünü ayarlayın.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// İki gradyan durak ekleyin.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gradyan doldurmalı elips](gradient-fill.png)

Bir gradyan, dışa aktarılan bir görüntüde PowerPoint'tekinden farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan doldurmayı değiştirmeden bir işleme stili seçebilirsiniz.

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarımı—nokta, çizgi, çapraz çizgi veya kare gibi—şekle uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renkleri için özel renkler seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Arka Plan Rengi](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) ayarlayın.
1. Desenin [Ön Plan Rengi](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene desen doldurma nasıl uygulanır gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Doldurma türünü Pattern olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Desen stilini ayarlayın.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Desenin arka plan ve ön plan renklerini ayarlayın.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydedin.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Desenli doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Resim Doldurma, bir şeklin içine bir resim yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece resmi şeklin arka planı gibi kullanırsınız.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.set_Image` yöntemine iletin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Şöyle bir "lotus.png" dosyamız olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki C++ kodu, bir şekli resimle doldurmanın yolunu gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Doldurma türünü Picture olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Resim doldurma modunu ayarlayın.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Resmi ayarlayın.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Desen Olarak Döşeme Resmi**

Döşeme resmini doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Resim doldurma modunu — `Tile` ya da `Stretch` — ayarlar.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Döşemelerin şekil içinde nasıl hizalanacağını belirler.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Döşemenin şeklin orijininden yatay ofsetini (nokta olarak) ayarlar.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Döşemenin şeklin orijininden dikey ofsetini (nokta olarak) ayarlar.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline döşemeli resim doldurma ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto firstSlide = presentation->get_Slide(0);

// Bir dikdörtgen otomatik şekil ekleyin.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Şeklin doldurma türünü Picture olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Görüntüyü şekle atayın.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint'te Düz Renk Doldurma, bir şekli tek, eşit renkle dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradyan, doku ya da desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. İstediğiniz doldurma rengini şekle atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir PowerPoint slaydındaki dikdörtgene düz renk doldurma nasıl uygulanır gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Doldurma türünü Solid olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Doldurma rengini ayarlayın.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydedin.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düz renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'te bir şekle düz renk, gradyan, resim ya da doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha çok görünür olmasını sağlar; arka plan ya da alt nesneler kısmen görünür hâle gelir.

Aspose.Slides, doldurma için kullanılan rengin alfa bileşenini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte yapmanız gerekenler:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflığı olan bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene şeffaf doldurma rengi uygulamayı gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Katı bir dikdörtgen otomatik şekil ekleyin.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX dosyasını diske kaydedin.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım gereksinimlerine göre konumlandırırken yararlı olabilir.

Bir slaytta şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekli 5 derece döndürmeyi gösterir:

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

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle türünde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Şekli 5 derece döndürün.
shape->set_Rotation(5);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şekil döndürme](shape-rotation.png)

## **3B Kırma Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kırma efektleri uygulamanıza olanak tanır.

Bir şekle 3B kırma efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) özelliğini yapılandırarak kırma ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3B kırma efektleri nasıl uygulanır gösterir:

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

// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Slayta bir şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Şeklin ThreeDFormat özelliklerini ayarlayın.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Sunumu PPTX dosyası olarak kaydedin.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![3B kırma efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) ve [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) kullanın.
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

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

// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Sunumu PPTX dosyası olarak kaydedin.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller için Siyah-Beyaz İşleme Kontrolü**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl işleneceğini belirler. Bu yöntem tek başına siyah-beyaz görüntüyü etkinleştirmez ve normal renk modundaki şeklin doldurmasını, çizgisini veya diğer biçimlendirmesini değiştirmez.

İstenilen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) enum'undan bir değer kullanın. Örneğin `Automatic` uygulama tarafından dönüşümün seçilmesini sağlar, `Gray` ve `LightGray` gri renkleme kullanır, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` ise şekil düzeyinde bir mod atanmadığını gösterir.

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

// Renk modunda turuncu doldurmayı koruyun, ancak siyah-beyaz modunda şekli gri renkle renderlayın.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Normal renk modunda dikdörtgen turuncu doldurmasını korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olarak ayarlandığı için gri renkle görüntülenir. Bu, tam renkli bir slaytı korurken baskı, ön izleme veya sunumun siyah-beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C++ kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konumunu, boyutunu ve biçimlendirmesini varsayılan ayarlara geri getirmeyi gösterir:

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
    // Yer tutucuya sahip düzenli slayttaki her şekli sıfırla.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Az bir etki vardır. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını kaplarken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir alan tüketmez.

**Bir slayttaki aynı biçimlendirmeye sahip şekilleri nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı kabul edip bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak için ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine ya da .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmeyi yeniden uygulayın.