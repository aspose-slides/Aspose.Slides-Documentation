---
title: C++ Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/cpp/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile slayt geçişlerini uygulayın, otomatik slayt ilerlemeyi yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for C++ ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması veya zamanlayıcıyla yapılandırabilir ve bir efekte özgü seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için C++ örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile bir sunum yükleyin ve bir slaytın geçiş ayarlarına [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) aracılığıyla erişin. [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enum değerlerinden birini kullanarak [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) çağırın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slayt içeren bir `input.pptx` dosyası kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Wheel Geçişi**

[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) sınıfının [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) yöntemi, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enum'undan Wheel ile [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) çağırın, ardından [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) olarak [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) erişin.

Bu örnek, iki aynı slayt çifti oluşturur: bir siyah slayt ve ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar 1 ve 8 spoke sayısı kullanır; aynı hız [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) ile ayarlanır ve farkı gözlemlemek kolay olsun diye [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ile 8.000 milisaniye kesin bir süre belirlenir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Çıktı sunumunu PowerPoint'te açın ve slayt gösterisini çalıştırın. 1. slayttan 2. slayta, ardından 3. slayttan 4. slayta ilerleyin. PowerPoint oynatımında, doğrulanmış 1 spoke count slaytı tek saat yönünde süpürme ile gösterir; 8 doğrulanmış spoke count sekiz radyal sektörü aynı anda gösterir. Hedef içerik ve geçiş zamanlaması aynı olduğundan fark, ortaya çıkış sektörlerinin sayısıdır.

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar süre kalacağını ve bir fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) otomatik ilerlemeyi etkinleştirir.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) otomatik ilerleme öncesi gecikmeyi milisaniye cinsinden belirler.

Hem tıklamayı hem de zamanlanmış ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesini veya zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) metodunu `false` ile çağırın. Gecikme slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini belirlemez.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Bu slaytlar fare tıklamalarıyla da ilerleyebilir. En az üç slayt içeren bir `input.pptx` dosyası kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) metodunu çağırın. Saklanan gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytların otomatik ilerlemesini devre dışı bırakır. Bu slaytlar için fare tıklamalarını etkinleştirir ve güncellenmiş ayarları kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Geçiş Zamanlamasını Hassas Bir Şekilde Kontrol Et**

Geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtmek için [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) kullanın. Slaytın [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) yöntemi bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) üzerinden ortaya çıkarır:

| Yöntem | Amaç |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ile `true` çağırın. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Önceden tanımlı bir hız kategorisini [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) enum'undan seçer: Slow, Medium veya Fast. Kesin bir süre belirtilmediğinde kullanılır. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) yalnızca geçiş efektini kontrol eder; slaytın ekranda kalma süresini belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Kesin bir süre ayarlanmamışsa, Aspose.Slides geçiş tipinden ve [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) tarafından döndürülen değerden etkilerin süresini hesaplar.

<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar 750 ms geçiş süresini ve 5.000 ms otomatik ilerleme ayarını gösterir.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Paylaşılan örnek, her slayta 750 ms Fade geçişi verir ve ayrıca 5.000 ms'de otomatik ilerlemeyi etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme ise slayttan ne zaman ayrılacağını belirler. Bu çubuklar ölçülen bir birleşik zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca 5.000 milisaniyede otomatik ilerlemeyi ayrı olarak etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Efekt süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, bir başlık slaytı için kısa bir geçiş, bir bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek ilk slayta 500 milisaniye, ikinci slayta 1.200 milisaniye ayarlar. En az iki slayt içeren bir `input.pptx` dosyası kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Geçişleri Animasyonlu Çıktı ile Koordine Et**

Bir [animated GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/cpp/export-to-html5/) veya [video](/slides/tr/cpp/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce kesin geçiş sürelerini belirleyerek istenen tempoyu eşleştirin. Örneğin, sahneler arasında 600 milisaniyelik bir solma efekti kullanın ve her slaytın ilerleme gecikmesini ayrı olarak ayarlayarak anlatım veya içerik için zaman tanıyın.

GIF ve video için, kare hızıyla efekt süresini eşleştirin: 600 milisaniye, 30 fps'de 18 kareye eşittir. HTML5'te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu onaylamak için çıktıyı ön izleyin.

### **Mevcut Geçiş Süresini Oku**

Geçişi değiştirmeden önce bir değer saklanıp saklanmadığını belirlemek için [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) çağırın. `-1` değeri, açık bir süre ayarlanmamış olduğunu gösterir; negatif olmayan bir değer milisaniye cinsinden saklanan süreyi belirtir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) tarafından döndürülen değeri kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlar arasındaki nesnelerdeki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya boyutlandırın ve ikinci slayta Morph geçişini uygulayın. Bu, orijinal ve değiştirilmiş durumlar arasında karşılık gelen nesneleri animasyonla gösterir.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konumunu ve boyutunu değiştirir. Daha sonra ikinci slayt için [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enum'undan Morph seçer. Morph'ı destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak slayt gösterisi sırasında efekti görün.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph Geçiş Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) enum'ı, Morph'un içeriği nasıl eşleştirdiğini ve canlandırdığını belirler:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

[set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ile Morph seçin, ardından [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) erişin. Bu değer, [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) arayüzünü sağlar; [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) yöntemi eşleşme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek yön seçenekleri veya efektin siyah ekrandan başlaması gibi ek seçenekler sunar. Mevcut seçenekler seçilen geçiş tipine bağlıdır. Önce tipi ayarlayın, ardından [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) tarafından döndürülen uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) aracılığıyla [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) metodunu `true` ile çağırarak geçişin siyah bir ekrandan başlamasını sağlar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) kategorisi (Slow, Medium veya Fast) yeterli olduğunda ve kesin bir süre ayarlanmamışsa [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) ile gömülü ses atayın, [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) enum'undan StartSound ile [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) çağırın ve [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) ile döngüyü etkinleştirin. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döngüde kalır.

**Tüm slaytlara aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) yöntemiyle dönen koleksiyon üzerinden döngü yapın ve her slaytın geçişi için aynı değeri kullanarak [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) çağırın. Aynı döngü içinde tüm zamanlama ve efekt seçeneklerini ayarlayarak davranışın slaytlar arasında tutarlı kalmasını sağlayın.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) yöntemiyle alınan geçiş üzerinde [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enum'undan bir değer döndürür; None değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.