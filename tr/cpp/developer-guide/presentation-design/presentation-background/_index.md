---
title: C++'ta Sunum Arka Planlarını Yönetmek
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/cpp/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- degrade renk
- görsel arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planların nasıl ayarlanacağını öğrenin, sunumlarınızı güçlendirecek kod ipuçlarıyla."
---
## **Giriş**

Katı renkler, degradeler ve görseller genellikle slayt arka planları için kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **ana slayt** (birçok slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Bir Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı bir rengi arka plan olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullanıyor olsa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerindeki [get_SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_solidfillcolor/) metodunu kullanarak katı arka plan rengini belirtin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, normal bir slayt için mavi katı renk arka planının nasıl ayarlanacağını gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Slaytın arka plan rengini mavi olarak ayarlayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sunumu diske kaydedin.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ana Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slayt için katı bir rengi arka plan olarak ayarlamanıza izin verir. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle, ana slaytın arka planı için katı bir renk seçtiğinizde bu, tüm slaytlara uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın ( `get_Masters` aracılığıyla) [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [get_SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_solidfillcolor/) metodunu kullanarak katı arka plan rengini belirtin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, ana slayt için orman yeşili katı rengin nasıl arka plan olarak ayarlanacağını gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Ana slaytın arka plan rengini Orman Yeşili olarak ayarlayın.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Sunumu diske kaydedin.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Slayt İçin Degrade Arka Planı Ayarlama**

Degrade, renklerin kademeli olarak değişmesiyle oluşan bir grafik etkidir. Slayt arka planı olarak kullanıldığında, degradeler sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için degrade renk arka planı ayarlamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerindeki [get_GradientFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_gradientformat/) metodunu kullanarak istediğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, bir slayt için degrade rengin nasıl arka plan olarak ayarlanacağını gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Arka plana bir degrade etkisi uygulayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Sunumu diske kaydedin.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Slayt İçin Görseli Arka Plan Olarak Ayarlama**

Katı ve degrade doldurmaların yanı sıra, Aspose.Slides görselleri slayt arka planı olarak kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görseli yükleyin.
5. Görseli sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerindeki [get_PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_picturefillformat/) metodunu kullanarak görseli arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, bir slayt için görselin nasıl arka plan olarak ayarlanacağını gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Arka plan görüntüsü özelliklerini ayarlayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Görüntüyü yükleyin.
auto image = Images::FromFile(u"Tulips.jpg");
// Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Sunumu diske kaydedin.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aşağıdaki kod örneği, arka plan doldurma tipini döşeli bir görsele ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
Daha fazla bilgi edinin: [**Tile Picture As Texture**](/slides/tr/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görselinin Şeffaflığını Değiştirme**

Bir slaytın arka plan görselinin şeffaflığını ayarlamak isteyebilirsiniz; bu, slayt içeriğinin daha belirgin olmasını sağlar. Aşağıdaki C++ kodu, bir slayt arka plan görselinin şeffaflığının nasıl değiştirileceğini gösterir:

```cpp
auto transparencyValue = 30; // Örneğin.

 // Resim dönüşüm işlemleri koleksiyonunu alın.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

 // Mevcut bir sabit yüzde şeffaflık etkisi bulun.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Yeni şeffaflık değerini ayarlayın.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Slayt Arka Plan Değerini Almak**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkili [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseslide/) sınıfının `get_Background` metodunu kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki C++ örneği, bir slaytın etkili arka plan değerinin nasıl alınacağını gösterir:

```cpp
// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Üst, düzen ve temayı dikkate alarak etkili arka planı alın.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **SSS**

**Özel bir arka planı sıfırlayıp tema/layout arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel doldurmasını kaldırın; arka plan, ilgili [layout](/slides/tr/cpp/slide-layout/)/[master](/slides/tr/cpp/slide-master/) slaytından (yani [tema arka planı](/slides/tr/cpp/presentation-theme/)) yeniden devralınır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Bir slaytın kendi doldurması varsa değişmez. Arka plan, [layout](/slides/tr/cpp/slide-layout/)/[master](/slides/tr/cpp/slide-master/) üzerinden devredilmişse, yeni temaya göre güncellenir.