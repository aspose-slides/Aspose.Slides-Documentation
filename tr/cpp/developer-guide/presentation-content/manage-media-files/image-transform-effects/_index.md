---
title: C++ ile Sunumlarda Görüntü Dönüştürme Efektlerini Yönet
linktitle: Görüntü Dönüştürme Efektleri
type: docs
weight: 11
url: /tr/cpp/image-transform-effects/
keywords:
- görüntü dönüştürme
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- çift ton
- tonlama
- HSL
- renk değiştirme
- bulanıklık
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile resim çerçeveleri için görüntü dönüştürme efektlerini uygula, zincirle, incele, kaldır ve doğrula."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını bir dizi görüntü dönüştürme işlemi olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/) erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) orijinal resim baytlarını yeniden yazmadan efekt eklemenize, listelemenize, incelemenize, kaldırmanıza ve temizlemenize olanak tanır.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX yuvarlak dönüş doğrulaması için eksiksiz bir iş akışı gösterir.

## **Etki Sahipliğini ve Görüntünün Yeniden Kullanımını Anlamak**

Bir görüntü kaynağı ve onu görüntüleyen resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans verir.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvurur; aynı zamanda görüntü dönüştürme koleksiyonunu saklar.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve düzeyindeki biçimlendirmeleri sahip olan slayt şeklidir.

Dolayısıyla, görüntü dönüştürme işlemleri [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` birden fazla kez [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/)&#39;e geçirildiğinde, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulamak diğer çerçeveleri gri tonlamaz; tüm çerçeveler aynı gömülü görüntü kaynağını yeniden kullanır.

Aynı `ISlidesPicture::get_ImageTransform` modeli, şekil ya da slayt arka planı gibi diğer resim doldurmalarında da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanmaktadır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Değerleri bu aralıklar içinde tutun; bir kütüphane sürümü hemen her out‑of‑range değerini reddetmese bile hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| Operasyon | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirilmeden bırakır. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Karanlık ve aydınlık pikseller için iki renk. `System::Drawing::Color` içindeki RGB ve alfa kanalları `0` ile `255` arasındadır. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Renk tonu `0` dahil, `360` dışında, derece; miktar `-100` ile `100` arasında, yüzde. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Renk tonu `0` dahil, `360` dışında, derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Değiştirilen renk kanallarını `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olmayan bir değerdir ve nokta cinsinden ölçülür; `grow` bulanık içeriğin orijinal sınırlardan dışarı taşmasını kontrol eder. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaf, `100` mevcut alfade korunur. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki değerler şeffaf, eşit veya üzerindekiler opak olur. |

Sabit alfa modülasyonu için, şeffaflık ve opaklık birbirini tamamlar. Örneğin, %35 şeffaflık, %65 alfa modülasyon miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) bir [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. `IBrightnessContrast::GetEffective` yöntemi, incelenebilecek veya kaydedilebilecek hesaplanmış yalnızca‑okunur değerleri döndürür.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑efekti uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilirdir. Parlaklık ve kontrastın PPTX yuvarlak dönüşten sonra düzenlenebilir kalması gerektiğinde, [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Format sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) iki bağımsız düzenlenebilir renk parametresi içerir: `get_Color1` koyu pikselleri, `get_Color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etkene örnek oluşturur.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini sabit bir renkle değiştirir ve alfabı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)&#39;den farklıdır.

### **Parlaklık Eşiği Uygulama**

Parlaklık eşiği, taranmış bir sayfadaki zayıf izleri arka plandan ayırmayı kolaylaştırabilir. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) ara gri tonları korur. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) parlaklığı siyah veya beyaza eşler, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ise opaklığa bir eşik uygular.

Parlaklık eşiği %0 ile %100 arasında, kapsayıcıdır. Eşiğin altındaki pikseller siyah, eşit veya üzerindeki pikseller beyaz olur. Eşiği yükseltmek daha fazla tonun siyah olmasına yol açar çünkü daha fazlası kesim noktasının altına düşer.

Download [grayscale-swatches.png](grayscale-swatches.png) to the working directory. Each label gives the original gray level on a scale from 0 to 255. The example places the original beside two copies and saves each copy's threshold in the presentation.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Open the output presentation in PowerPoint to compare the three frames. The swatch labeled 96 has about 38% luminance (96 out of 255). It turns white at the 20% threshold and black at the 60% threshold.

![Orijinal gri örnekler, %20 ve %60 luminans eşiklerinde siyah‑beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekle**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) tüm renk kanallarını, alfabı da dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` değerini `true` yapın.

Tekdüzen şeffaflık için `[AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)` kullanın. Bu, mevcut her alfa değerini çarpar, böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. `[AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/)` ise tüm piksellere tek bir alfa değeri atar. `[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)` alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Diğer parametresiz alfa işlemleri şunları içerir: `[AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)`, tüm sıfır olmayan alfalara %100 opaklık verir; `[AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)`, %100&#39;ün altındaki tüm alfalara tamamen şeffaflık verir; ve `[AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)`, alfabı `100% - alpha` olarak değiştirir.

## **Sıralı Bir Efekt Zinciri Oluşturma**

Her `Add...Effect` yöntemi koleksiyonun sonuna yeni bir işlem ekler. İşleyici koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0&#39;ın çıktısı işlem 1&#39;in girdisi olur, vb. Dolayısıyla aynı işlemler farklı sırada farklı bir görüntü üretebilir.

Örneğin, gri tonlama ardından tonlama önce renk bilgilerini kaldırır ve ardından parlaklığı renkler. Tonlama ardından gri tonlama tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bunların relatif farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, işlem türlerini ve sırasını kontrol eder ve yeniden açılan sonucu işler:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Koleksiyon, renk, alfa ve bulanıklık işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi zorlamaz. Birlikte kullanılabilir, fakat kombinasyonlar her zaman faydalı olmayabilir. Sabit renk değiştirme, önceki renk efektleri tarafından üretilen RGB varyasyonunu kaldırır; duotone sonrası gri tonlama iki seçilen rengi kaldırır; ve alfa tavan, taban, değiştirme veya iki seviyeli işlemler daha önce oluşturulan alfa detayını ortadan kaldırabilir. Zinciri istenen piksel işleme sırasına göre oluşturun, öğeleri sırasız biçimleme bayrakları gibi davranmayın.

<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra tonlamadan, ve tonlamadan sonra gri tonlamadan geçer. İki son gri tonlama görüntüsü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu gösterimsel Aspose.Slides for .NET 26.11 render'ında, %25&#39;te 220° tonlama gri tonlamalı görüntüyü değiştirmez. Aynı tonlamayı gri tonlamadan önce uygulamak farklı tonlar üretir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkin Değerleri İnceleme**

Düzenlenebilir bir işlem, `ISlidesPicture::get_ImageTransform` içinde saklanan nesnedir. Etkiye bağlı olarak doğrudan yazılabilir üyelere erişebilir. Örneğin, `[IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/)` `set_Radius` ve `set_Grow` öğelerini, `[IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/)` `set_Amount` öğesini ve `[IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/)` `set_Threshold` öğesini ortaya çıkarır. `[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/)` gibi renk efektleri, değiştirilebilir `[IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/)` nesnelerini ortaya çıkarır.

Bazı işlem arayüzleri, `[IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)`, `[IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/)`, `[ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/)` ve `[IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)` gibi, oluşturma skalerlerini yazılabilir özellikler olarak ortaya çıkarmaz. Bu ayarları değiştirmek için işlemi kaldırın ve gerekli konumda yeni bir işlem ekleyin.

`GetEffective()` tarafından döndürülen etkin veri, hesaplanmış ve yalnızca‑okunur bir değerdir. Tema bağımlı renkleri çözümlemek ve render'ın kullandığı normalleştirilmiş değerleri okumak için yararlıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sayar ve birkaç yaygın işlem için etkin değerleri inceler:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

`grayscale`, alfa tavan ve alfa ters gibi parametresiz efektler de bir etkin veri nesnesine sahiptir, ancak yazdırılacak skaler ayar yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

`[IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/)` kullanarak indeksle bir işlemi kaldırın. Kaldırma sonrası indeksler kayar, bu yüzden önce hedefi bulun ve saydırdıktan sonra kaldırın. `Clear()` metodunu kullanarak tüm zinciri temizleyin.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan `[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)` kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML'den gelir, bu yüzden PPTX efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Parlaklık, gri tonlama, duotone, tonlama, HSL, bulanıklık ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, PPTX yuvarlak dönüşünden sonra hayatta kalma ihtimali en yüksek olanlardır. Koruma bir gereklilik olduğunda, her zaman oluşturulan dosyayı tekrar açın ve koleksiyonu inceleyin.
- `[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/)` standart DrawingML parlaklık işleminden ziyade bir Office 2010 uzantısıdır. Bellek içi render için kullanılabilir, fakat PPTX kaydedilip açıldıktan sonra düzenlenebilir `[IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)` olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için `[AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)` tercih edin.
- İkili PPT formatı tam DrawingML efekt modelinden önce gelir. PPT olarak kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir altküme ile sınırlayabilir ya da görünümü yaklaşık olarak verebilir. Karmaşık düzenlenebilir bir zincir için PPT&#39;yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara render etmek, desteklenen zinciri render edilmiş görünüme uygular. Bu çıktılar, düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster formatlar sonucu piksellere döker, belge veya vektör dışa aktarımları kendi render temsilini tutar.
- Efektler, bağlı bir görüntüyü kendi içinde taşınabilir hâle getirmez. Bağlı bir resmin render edilmesi, sunum yüklendiğinde bağlı kaynağın mevcut olmasına hâlâ bağlıdır.

Farklı sunum tüketicileri kenar durumlarını farklı şekilde render edebilir, özellikle birden fazla alfa veya renk‑quantize işlemi birleştirildiğinde. Kritik çıktılar için, düzenlenebilir yuvarlak dönüşü ve nihai dışa aktarım formatını üretimde kullanılan aynı Aspose.Slides sürümüyle test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `ISlidesPicture`'a aittir. Altındaki `IPPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak, yinelenen görüntü verilerini önler, fakat her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklık ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Her bir işlemin önceki çıktıya ne yaptığını göz önünde bulundurun; çünkü değiştirme ve eşik işlemleri önceki renk veya alfa detaylarını ortadan kaldırabilir.

**Etkin değerler neden yalnızca‑okunur?**

Etkin veri, çözülmüş renkler de dahil olmak üzere render için kullanılan hesaplanmış değerleri temsil eder. Yazılabilir üyeleri olan dönüşüm koleksiyonundaki işlemi düzenleyin; aksi takdirde onu kaldırın ve yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML efekt modelini temsil edemez ve render edilmiş dışa aktarım formatları görünümü korur, düzenlenebilir dönüşüm işlemlerini değil.