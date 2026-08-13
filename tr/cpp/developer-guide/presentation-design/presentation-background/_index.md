---
title: C++'da Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/cpp/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- gradyan renk
- görsel arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planlar nasıl ayarlanır, sunumlarınızı güçlendirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Katı renkler, degradeler ve görüntüler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **ana slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Bir Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı bir rengi arka plan olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerinde [get_SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_solidfillcolor/) metodunu kullanarak katı arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, normal bir slayt için mavi katı rengi arka plan olarak nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
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

// Slaydın arka plan rengini mavi olarak ayarlayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sunumu diske kaydedin.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ana Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slaytın arka planını katı bir renk olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu yüzden ana slaytın arka planı için katı bir renk seçtiğinizde bu, her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) (`get_Masters` aracılığıyla) özelliğini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirlemek için [get_SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_solidfillcolor/) metodunu kullanın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, ana slayt için katı bir renk (ormangrisi) arka plan olarak nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

Degrade, rengin kademeli değişimiyle oluşturulan bir grafik efekttir. Slayt arka planı olarak kullanıldığında, degrade sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için arka plan olarak bir degrade renk ayarlamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerinde [get_GradientFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_gradientformat/) metodunu kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, bir slayt için degrade renk arka planını nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Arka plana bir degrade efekti uygulayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Sunumu diske kaydedin.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Slayt Arka Planı Olarak Görüntü Ayarlama**

Katı ve degrade dolgu seçeneklerine ek olarak, Aspose.Slides slayt arka planı olarak görüntüler kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/) üzerinde [get_PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fillformat/get_picturefillformat/) metodunu kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki C++ örneği, bir slayt için görüntüyü arka plan olarak nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Arka plan görüntüsü özelliklerini ayarlayın.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Görüntüyü yükle.
auto image = Images::FromFile(u"Tulips.jpg");
// Görüntüyü sunumun görüntü koleksiyonuna ekle.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Sunumu diske kaydedin.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aşağıdaki kod örneği, arka plan dolgu tipini döşenmiş bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert color="info" %}}
Daha fazla oku: [**Tile Picture As Texture**](/slides/tr/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slayt arka planı görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz, böylece slayt içeriği daha belirgin olur. Aşağıdaki C++ kodu, bir slayt arka planı görüntüsü için şeffaflığı nasıl değiştireceğinizi gösterir:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Örneğin.

// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Save the presentation to disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slayt Arka Plan Değerini Almak**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkili [FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseslide/) sınıfının `get_Background` metodunu kullanarak bir slayt için etkili arka planı elde edebilirsiniz.

Aşağıdaki C++ örneği, bir slaytın etkili arka plan değerini nasıl alacağınızı gösterir:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Presentation sınıfının bir örneğini oluşturun.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Ana slayt, yerleşim ve temayı dikkate alarak etkili arka planı alın.
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

### Özel bir arka planı sıfırlayıp tema/yerleşim arka planını eski haline getirebilir miyim?

Evet. Slaytın özel dolgusunu kaldırın, böylece arka plan yeniden ilgili [layout](/slides/tr/cpp/slide-layout/)/[master](/slides/tr/cpp/slide-master/) slaytından (yani [theme background](/slides/tr/cpp/presentation-theme/)) miras alınır.

### Sunumun temasını daha sonra değiştirirsem arka plan ne olur?

Eğer bir slaytın kendi dolgu ayarı varsa, bu değişmez. Arka plan [layout](/slides/tr/cpp/slide-layout/)/[master](/slides/tr/cpp/slide-master/) üzerinden miras alınıyorsa, yeni [theme](/slides/tr/cpp/presentation-theme/) ile eşleşecek şekilde güncellenir.