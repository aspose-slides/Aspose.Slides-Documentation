---
title: C++ ile Sunumlarda Görüntü Dönüşüm Efektlerini Yönet
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/cpp/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- ikili ton
- renk tonu
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
description: "Aspose.Slides for C++ ile resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/get_imagetransform/) öğesine erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/) size efektleri ekleme, enumerate etme, inceleme, kaldırma ve temizleme imkanı verir, orijinal görüntü baytlarını yeniden yazmadan.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX turu doğrulaması için tam bir iş akışını gösterir.

## **Efekt Sahipliğini ve Resim Yeniden Kullanımını Anlayın**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans verir.
- [ISlidesPicture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/) bir resim doldurmasına aittir ve bir resim kaynağına başvururken görüntü dönüşüm koleksiyonunu saklar.
- [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ilgili resim doldurmasını, geometrisini, kırpma ayarlarını ve diğer çerçeve‑seviyesi biçimlendirmeyi sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` birden fazla kez [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addpictureframe/) yöntemine geçirildiğinde, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulanması, diğer çerçevelerin gri tonlamasını etkilemez; tüm çerçeveler aynı gömülü görüntü kaynağını kullanır.

Aynı `ISlidesPicture::get_ImageTransform` modeli, bir şekil veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanmaktadır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanın**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her dışarıdaki değeri reddetmese bile, değerleri bu aralıkta tutun; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz veriyi normalize, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Koyu ve açık pikseller için iki renk. `System::Drawing::Color` içindeki RGB ve alfa kanalları `0` ile `255` arasındadır. |
| [AddTintEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Ton `0` dahil `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [AddHSLEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Ton `0` dahil `360` hariç derece cinsinden; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Değiştirme rengi kanal değerleri `0` ile `255` arasındadır. Mevcut alfa değerleri değişmez. |
| [AddBlurEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına uzanıp uzanmayacağını kontrol eder. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaftır, `100` mevcut alfanın korunmasını sağlar. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki pikseller şeffaf, eşit veya üzerindekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık tamamlayıcıdır. Örneğin, %35 şeffaflık alfa modülasyonu %65 miktarıyla eşdeğerdir.

## **Parlaklık ve Kontrast Uygulayın**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) bir [IBrightnessContrast](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. `IBrightnessContrast::GetEffective` yöntemi, incelenebilen veya kaydedilebilen yalnızca‑okunur hesaplanmış değerleri döndürür.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir önizleme oluşturur:

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

[BrightnessContrast](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık etkisine göre daha az taşınabilirdir. Parlaklık ve kontrastın bir PPTX turu sonrasında da düzenlenebilir kalması gerektiğinde, [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulayın**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `get_Color1` koyu pikselleri, `get_Color2` ise açık pikselleri haritalar. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğundan yararlı bir örnek oluşturur.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini sabit bir renkle değiştirirken alfabı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [AddColorChangeEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) metodundan farklıdır.

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekleyin**

[AddBlurEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` parametresini `true` olarak ayarlayın.

Tekdüzen şeffaflık için [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) kullanın. Bu, mevcut alfa değerlerinin hepsini çarpar; böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) ise tüm piksellere tek bir alfa değeri atar. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ise alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

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

Parametresiz diğer alfa işlemleri şunlardır: [AddAlphaCeilingEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) – sıfır olmayan her alfa değeri tamamen opak hâle gelir; [AddAlphaFloorEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) – %100’den düşük alfa tamamen şeffaf hâle gelir; ve [AddAlphaInverseEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) – alfabı `100% - alpha` şeklinde tersine çevirir.

## **Sıralı Bir Efekt Zinciri Oluşturun**

Her `Add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir işlem hattı gibi kullanır: işlem 0 çıktısı işlem 1 girdisi olur, vb. Bu nedenle aynı işlemler farklı bir sırada yürütüldüğünde farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından tonlama önce renk bilgilerini kaldırır, ardından parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama ise tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bu değerlerin göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, işlem türlerini ve sırasını kontrol eder ve yeniden açılan sonucu renderlar:

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

Koleksiyon, renk, alfa ve bulanıklık işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilirler, ancak kombinasyonlar her zaman faydalı olmayabilir. Sabit bir renk değiştirme, önceki renk efektleriyle üretilen RGB varyasyonunu ortadan kaldırır; duotone sonrası gri tonlama iki seçili rengi kaldırır; ve alfa tavan, zemin, değiştirme veya iki‑seviyeli işlemler daha önce oluşturulan alfa detayını yok edebilir. Zinciri, öğeleri sırasız biçimlendirme bayrakları gibi düşünmek yerine, istenen piksel‑işleme sırasına göre oluşturun.

## **Düzenlenebilir ve Etkili Değerleri İnceleyin**

Düzenlenebilir bir işlem, `ISlidesPicture::get_ImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan ortaya çıkabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iblur/) `set_Radius` ve `set_Grow` expose eder, [IAlphaModulateFixed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ialphamodulatefixed/) `set_Amount` expose eder, ve [IAlphaBiLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ialphabilevel/) `set_Threshold` expose eder. [IDuotone](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iduotone/) gibi renk efektleri değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icolorformat/) nesneleri expose eder.

[IBrightnessContrast](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/ialphareplace/) gibi bazı işlem arabirimleri, oluşturma skalerlerini yazılabilir özellik olarak expose etmez. Bu ayarları değiştirmek için işlemi kaldırın ve gerekli konumda bir yenisi ekleyin.

`GetEffective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağlı renkleri çözmek ve renderlayıcının kullandığı normalleştirilmiş değerleri okumak için faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri enumerate eder ve birkaç yaygın işlem için etkili değerleri inceler:

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

Gri tonlama, alfa tavan ve alfa tersine çevirme gibi parametresiz efektler de bir etkili‑veri nesnesine sahiptir, ancak yazdırılacak skaler ayarları yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırın veya Temizleyin**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) kullanın. Kaldırma sonrası indeksler kaydığı için önce hedefi bulup enumerate ettikten sonra kaldırın. Tüm zinciri kaldırmak için `Clear()` kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünün**

Görüntü dönüşümleri DrawingML’den kaynaklanır; bu nedenle efekt zincirleri için tercih edilen düzenlenebilir biçim PPTX’dir. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX turunda hayatta kalma şansı en yüksek olandır. Kalıcı olma gereği varsa, oluşturulan dosyayı yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/brightnesscontrast/) bir Office 2010 uzantısıdır; standart DrawingML luminance işlemine göre daha az taşınabilirdir. Bellek içinde renderlama için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast] olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [AddLuminanceEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) tercih edin.
- Eski PPT biçimi tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak verebilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama biçimi olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılar desteklenen zinciri renderlanmış görünüme uygular. Bu çıktılar düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster biçimler sonucu piksellere düzleştirir, belge veya vektör dışa aktarımları kendi render temsillerini saklar.
- Efektler, bir bağlanmış (linked) görüntünün kendi içinde tümleşik olmasını sağlamaz. Bağlanmış bir resmi renderlamak, sunum yüklendiğinde bağlanmış kaynağın mevcut olmasını gerektirir.

Farklı sunum tüketicileri kenar durumlarını farklı şekilde renderlayabilir, özellikle birden fazla alfa veya renk‑kuantizasyon işlemi bir arada kullanıldığında. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle düzenlenebilir tur ve son dışa aktarma biçimini test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verisini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `ISlidesPicture` a aittir. Altındaki `IPPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanılabilirliği veri çoğaltmayı önler, ancak her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklık ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon bu efektleri tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısına ne yaptığını dikkate alın; değiştirme ve eşik işlemleri önceki renk veya alfa detayını yok edebilir.

**Etkili değerler neden yalnızca‑okunur?**

Etkili veri, renderlama sırasında kullanılan hesaplanmış değerleri (çözülen renkler gibi) temsil eder. Yazılabilir üyeleri olan işlem nesnesini doğrudan düzenleyin; aksi takdirde işlemi kaldırın ve yeni oluşturma parametreleriyle bir yenisi ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Legacy PPT, tam DrawingML efekt modelini temsil edemez; renderlanan dışa aktarma biçimleri ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini saklamaz.