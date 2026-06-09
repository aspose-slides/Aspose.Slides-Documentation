---
title: PowerPoint Şekillerini C++'ta Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/cpp/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- bağlantı stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3b kaldıraç efekti
- 3b döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya etkiler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içi nasıl doldurulacağını kontrol eden ayarları belirleyerek de şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++, PowerPoint'ta bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linestyle/) ayarını belirleyin.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/cpp/aspose.slides/linedashstyle/) ayarını belirleyin.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Dikdörtgen şeklinin dolgu rengini ayarlayın.
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

## **Bağlantı Stilleri Biçimlendirme**

İşte üç birleştirme türü seçeneği:

* Yuvarlak
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Round** ayarını kullanır. Ancak keskin açılara sahip bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde üç otomatik şekil ekleyin.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Her dikdörtgen şeklinin dolgu rengini ayarlayın.
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

// Birleştirme stilini ayarlayın.
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

## **Gradyan Doldurma**

PowerPoint'ta Gradyan Doldurma, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Gradyan doldurmayı bir şekle uygulamak için Aspose.Slides'ı şu şekilde kullanabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igradientformat/) arabiriminin gradient stop koleksiyonundaki `Add` metodlarıyla tanımlı konumlarda iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Elliipse tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Elliipse'e gradyan biçimlendirmesi uygulayın.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Gradyanın yönünü ayarlayın.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// İki gradyan durdu ekleyin.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Gradyan doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, iki renkli bir tasarım—nokta, çizgi, çapraz çizgi veya kareler gibi—şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Önceden tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirtebilirsiniz.

Desen doldurmayı bir şekle uygulamak için Aspose.Slides'ı şu şekilde kullanabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) değerini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_backcolor/) ayarını belirleyin.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipatternformat/get_forecolor/) ayarını belirleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dolgu tipini Pattern olarak ayarlayın.
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

PowerPoint'ta Resim Doldurma, bir resmi şeklin içine eklemenizi sağlayan bir biçimlendirme seçeneğidir; böylece resmi şeklin arka planı olarak kullanırsınız.

Resim doldurmayı bir şekle uygulamak için Aspose.Slides'ı şu şekilde kullanabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya başka bir tercih ettiğiniz modu) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.set_Image` metoduna aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Dolgu tipini Picture olarak ayarlayın.
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

### **Resmi Doku Olarak Döşeme**

Döşeli bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki yöntemleri [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillformat/) sınıfı üzerinden kullanabilirsiniz:

- [set_PictureFillMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Resim doldurma modunu ayarlar—`Tile` ya da `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Döşemelerin şekil içinde hizalanmasını belirler.
- [set_TileFlip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Döşemenin yatay, düşey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [set_TileOffsetX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Döşemenin şeklin orijinalinden yatay ofsetini (nokta cinsinden) ayarlar.
- [set_TileOffsetY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Döşemenin şeklin orijinalinden düşey ofsetini (nokta cinsinden) ayarlar.
- [set_TileScaleX](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [set_TileScaleY](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Döşemenin düşey ölçeğini yüzde olarak tanımlar.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto firstSlide = presentation->get_Slide(0);

// Bir dikdörtgen otomatik şekil ekleyin.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Şeklin dolgu tipini Picture olarak ayarlayın.
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

## **Katı Renk Doldurma**

PowerPoint'ta Katı Renk Doldurma, bir şekli tek, tekdüze bir renkle dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradyan, doku ya da desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurması uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
1. İstediğiniz doldurma rengini şekle atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Dolgu tipini Solid olarak ayarlayın.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Dolgu rengini ayarlayın.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX dosyasını diske kaydedin.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'ta bir şekle katı renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın şeffaflık seviyesini de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha çok görünür olmasını sağlar ve arka plan ya da alttaki nesnelerin kısmen görülmesine izin verir.

Aspose.Slides, doldurma rengi için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflığı olan bir renk tanımlayın (alfa bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

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

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken yararlı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin dönüş açısını istediğiniz değere ayarlayın.
1. Sunumu kaydedin.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// İlk slaytı alın.
auto slide = presentation->get_Slide(0);

// Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Şekli 5 derece döndürün.
shape->set_Rotation(5);

// PPTX dosyasını diske kaydedin.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Kaldıraç Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kaldıraç efektleri uygulamanıza imkan verir.

Bir şekle 3B kaldıraç efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini başlatın.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) ayarlarını yapılandırarak kaldıraç ayarlarını tanımlayın.
1. Sunumu kaydedin.

```cpp
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

![3B kaldıraç efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza imkan verir.

3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [set_CameraType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icamera/set_cameratype/) ve [set_LightType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrig/set_lighttype/) yöntemlerini kullanın.
1. Sunumu kaydedin.

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

Aşağıdaki C++ kodu, bir slaydın biçimlendirmesini sıfırlamanın ve [LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerindeki yer tutuculu tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmenin nasıl yapılacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Yer tutucuya sahip olan slaydın üzerindeki her şekli sıfırla.
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Şekil biçimlendirmesi, sunum dosyasının nihai boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosyanın çoğunu kaplarken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve ek boyut eklemez.

**Bir slaytta aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edebilirim, böylece onları gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler aynıysa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, daha sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini ayrı bir dosyada saklayıp başka sunumlarda yeniden kullanabilir miyim?**

Evet. İstenilen stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında depolayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stillendirilmiş şekilleri klonlayın ve gerektiğinde biçimlendirmelerini yeniden uygulayın.