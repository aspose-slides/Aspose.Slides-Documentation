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
- geçiş tipi
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile slayt geçişlerini uygulayın, otomatik slayt ilerlemeyi yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for C++ ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklamasıyla ya da zamanlayıcıyla yapılandırabilir ve bir efekti özel ayarlarla ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, tam geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için C++ örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına kaydedilmesini gösterir.

## **Slayt Geçişi Ekleme**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfıyla yükleyin ve bir slaydın geçiş ayarlarına [get_SlideShowTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitiontype/) enumarasyonundan bir değerle [set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_type/) çağırın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi, ikinci slayta ise Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Gelişmiş Slayt Geçişi Ekleme**

Bir slaydın ekranda ne kadar uzun kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [set_AdvanceAfter](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceafter/) otomatik ilerlemeyi etkinleştirir.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) otomatik ilerlemeden önceki gecikmeyi milisaniye cinsinden belirtir.

Hem tıklamayı hem de zamanlayıcıyı etkinleştirerek izleyicinin ister tıklayarak ister zamanlayıcıyı bekleyerek ilerlemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [set_AdvanceOnClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) metodunu `false` ile çağırın. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [get_AdvanceAfter](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_advanceafter/) metodunu çağırın. Saklanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Aşağıdaki örnek, yukarıda kaydedilen dosyayı açar, etkin olan her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmesi olan slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

## **Geçiş Zamanlamasını Kesinlikle Kontrol Etme**

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [set_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_duration/) kullanın. Slaydın [get_SlideShowTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metodu bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/) üzerinden sunar:

| Metod | Amaç |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_duration/) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Slaydın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [set_AdvanceAfter](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ile `true` çağırın. |
| [set_Speed](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_speed/) | [TransitionSpeed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionspeed/) enumarasyonundan bir ön tanımlı hız kategorisi seçer: Slow, Medium veya Fast. Kesin bir süre belirtilmediğinde kullanılır. |

[set_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_duration/) yalnızca geçiş efektini kontrol eder; slaydın ekranda ne kadar uzun kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [get_Speed](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_speed/) tarafından döndürülen değere göre effect süresini belirler.

### **Her Slayta Aynı Süreyi Uygulama**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5 000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

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

    // Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandırın.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Bireysel Slaytlar İçin Farklı Süreler Belirleme**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaydında kısa bir geçiş, bölüm girişinde daha uzun bir geçiş kullanılabilir. Bu örnek, ilk slayta 500 milisaniye, ikinci slayta 1 200 milisaniye süre ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Geçişleri Animasyonlu Çıktıyla Koordine Etme**

[animated GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/cpp/export-to-html5/) veya [video](/slides/tr/cpp/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce kesin geçiş sürelerini ayarlayarak istenen temposu eşleştirin. Örneğin, sahneler arasında 600 milisaniyelik bir solma efekti kullanın ve her slaydın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım ya da içerik süresine yer verin.

GIF ve video için, efekt süresiyle çerçeve hızını koordine edin: 600 milisaniye, saniyede 30 karede 18 kareye eşittir. HTML5’te dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efektleri ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Okuma**

Geçişi değiştirmeden önce [get_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_duration/) çağırarak açıkça saklanmış bir değer olup olmadığını kontrol edin. `-1` değeri, açık bir süre ayarlanmamış demektir; sıfır ve üzeri bir değer milisaniye cinsinden saklanan süreyi gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [get_Speed](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_speed/) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlar üzerindeki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı kopyalayın, kopya üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Böylece geçiş, ilgili nesnelerin orijinal ve değiştirilmiş halleri arasında animasyon sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayd için [TransitionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitiontype/) enumarasyonundan Morph seçer. Morph destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak efektin slayt gösterisi sırasında çalışmasını görebilirsiniz.

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

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionmorphtype/) enumarasyonu, Morph’un içeriği nasıl eşleştireceğini ve canlandıracağını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionmorphtype/) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Morph seçtikten sonra [get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_value/) metodunu çağırın. Bu değer, [IMorphTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/imorphtransition/) arayüzünü sağlar; bu arayüzdeki [set_MorphType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) metodu eşleme modunu seçer.

Bu örnek, bir önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

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

## **Geçiş Efektleri Ayarlama**

Bazı geçişler ek yön ya da efektin kara ekrandan başlaması gibi ek seçenekler sunar. Kullanılabilir seçenekler, seçilen geçiş tipine bağlıdır. Önce tipi ayarlayın, ardından [get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_value/) tarafından döndürülen uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [IOptionalBlackTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/ioptionalblacktransition/) aracılığıyla [set_FromBlack](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) metodunu `true` olarak çağırır; böylece geçiş kara ekrandan başlar.

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

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [set_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_duration/) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionspeed/) (Slow, Medium veya Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [set_Speed](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_speed/) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [set_Sound](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_sound/) ile gömülü ses atayın, [set_SoundMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_soundmode/) ile [TransitionSoundMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionsoundmode/) enumarasyonundan StartSound seçin ve [set_SoundLoop](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_soundloop/) ile döngüyü etkinleştirin. Ses, slayt gösterisinde bir sonraki ses olayına kadar döner.

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

Sunumun [get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slides/) metodu tarafından döndürülen koleksiyon üzerinde döngü oluşturun ve her slaydın geçişi için aynı değeri kullanarak [set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/set_type/) metodunu çağırın. Zamanlama ve efekt seçeneklerini aynı döngüde ayarlayarak davranışı slaytlar arasında tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaydın [get_SlideShowTransition](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metodundan alınan geçiş üzerinde [get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideshowtransition/get_type/) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitiontype/) enumarasyonundan bir değer döndürür; None, hiçbir geçiş etkisinin uygulanmadığını gösterir.