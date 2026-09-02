---
title: PowerPoint Şekillerini C++'ta Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/cpp/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- bağlantı stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3B koni efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine efektler ekleyerek veya değiştirerek biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![biçim-şekli-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linestyle/) özelliğini ayarlayın.  
1. Çizgi genişliğini ayarlayın.  
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linedashstyle/) özelliğini ayarlayın.  
1. Şekil için çizgi rengini ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape`'i nasıl biçimlendireceğinizi gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
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

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [IShape::get_LineFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_lineformat/) , eskiz ayarlarına erişmek için [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformat/get_sketchformat/) ve [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformat/set_sketchtype/) aracılığıyla [LineSketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) enum'ından bir değer seçin.

Aşağıdaki C++ kodu, bir [LineSketchType::Curved](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType::None](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

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

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformat/get_sketchtype/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaydından devralınabiliyorsa, [ILineFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) erişin ve [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) değerini okuyun. Etkin değer, devralmanın çözüldükten sonra aslında uygulanan biçimlendirmeyi yansıtır:

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

İşte üç bağlantı tipi seçeneği:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıyla (örneğin bir şeklin köşesinde) birleştirdiğinde **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlantı stili](join-style-powerpoint.png)

Aşağıdaki C++ kodu, yukarıdaki resimde gösterildiği gibi Miter, Bevel ve Round bağlantı tipi ayarları kullanılarak üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde üç otomatik şekil ekleyin.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Her dikdörtgen şeklinin doldurma rengini ayarlayın.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Çizgi kalınlığını ayarlayın.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Her dikdörtgenin çizgi rengini ayarlayın.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Bağlantı stilini ayarlayın.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Her dikdörtgene metin ekleyin.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX dosyasını diske kaydedin.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Degrade Doldurma**

PowerPoint'te Degrade Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir rengin yavaşça diğerine karıştığı iki veya daha fazla rengi uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.  
1. [IGradientFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igradientformat/) arayüzünün sunduğu degrade durak koleksiyonu üzerindeki `Add` metodlarıyla konumları tanımlı iki tercih ettiğiniz rengi ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir elipse degrade doldurma etkisi nasıl uygulanır gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Elips tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Elipse degrade biçimlendirmesini uygulayın.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Degrade yönünü ayarlayın.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// İki degrade durak ekleyin.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Degrade doldurmalı elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarımı (örneğin nokta, çizgi, çapraz çizgi veya kare) bir şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra hâlâ kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.  
1. Ön tanımlı seçeneklerden bir desen stili seçin.  
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_backcolor/) özelliğini ayarlayın.  
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_forecolor/) özelliğini ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene desen doldurma nasıl uygulanır gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Doldurma tipini Pattern olarak ayarlayın.
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

PowerPoint'te Resim Doldurma, bir şekil içine bir görsel yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece görsel şeklin arka planı olarak kullanılır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.  
1. Resim doldurma modunu `Tile` (veya başka bir tercih edilen mod) olarak ayarlayın.  
1. Kullanmak istediğiniz görselden bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun.  
1. Görseli `ISlidesPicture.set_Image` metoduna geçirin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Diyelim ki aşağıdaki görseli içeren bir **lotus.png** dosyamız var:

![Lotus resmi](lotus.png)

Aşağıdaki C++ kodu, bir şekli resim ile doldurmanın nasıl yapılacağını gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Doldurma tipini Picture olarak ayarlayın.
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

![Resim doldurmalı şekil](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Karo bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [set_PictureFillMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Resim doldurma modunu `Tile` ya da `Stretch` olarak ayarlar.  
- [set_TileAlignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Şekil içinde döşemelerin hizalanmasını belirtir.  
- [set_TileFlip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilemeyeceğini kontrol eder.  
- [set_TileOffsetX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Döşemenin şeklin orijinalinden yatay ofsetini (puan cinsinden) ayarlar.  
- [set_TileOffsetY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Döşemenin şeklin orijinalinden düşey ofsetini (puan cinsinden) ayarlar.  
- [set_TileScaleX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [set_TileScaleY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Döşemenin düşey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline döşemeli resim doldurma eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto firstSlide = presentation->get_Slide(0);

// Bir dikdörtgen otomatik şekil ekleyin.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Şeklin doldurma tipini Picture olarak ayarlayın.
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

PowerPoint'te Düz Renk Doldurma, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, degrade, doku veya desen olmaksızın uygulanır.

Aspose.Slides ile bir şekle düz renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. Şekle tercih ettiğiniz doldurma rengini atayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C++ kodu, bir PowerPoint slaytındaki dikdörtgene düz renk doldurma nasıl uygulanır gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Doldurma tipini Solid olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Doldurma rengini ayarlayın.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydedin.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düz renk doldurmalı şekil](solid-color-fill.png)

## **Şeffaflığı Ayarlama**

PowerPoint'te bir şekle düz renk, degrade, resim ya da doku doldurması uyguladığınızda, doldurmanın saydamlık seviyesini ayarlayarak dolgunun opaklığını kontrol edebilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin arka planını veya altındaki nesneleri kısmen görünebilir kılar.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. `Color` kullanarak şeffaflık içeren bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir dikdörtgene şeffaf dolgu rengi nasıl uygulanır gösterir:

```cpp
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

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimleriyle konumlandırırken yararlı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin döndürme özelliğini istenen açıya ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekli 5 derece döndürmeyi gösterir:

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Şekli 5 derece döndürün.
shape->set_Rotation(5);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Koni Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B koni efektleri uygulamanıza olanak tanır.

Bir şekle 3B koni efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini koni ayarlarını tanımlayacak şekilde yapılandırın.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3B koni efektleri nasıl uygulanır gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![3B koni efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
1. 3B döndürmeyi tanımlamak için [set_CameraType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icamera/set_cameratype/) ve [set_LightType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrig/set_lighttype/) metodlarını kullanın.  
1. Sunumu kaydedin.

Aşağıdaki C++ kodu, bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

```cpp
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

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C++ kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konumunu, boyutunu ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Düzen üzerindeki yer tutucusu bulunan slayttaki her şekli sıfırla.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Yalnızca çok az. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur; renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan şekilleri bir slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, ileride stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine veya .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri çoğaltın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.