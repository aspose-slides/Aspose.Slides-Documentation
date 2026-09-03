---
title: .NET'te Sunumlarda Slayt Geçişlerini Yönet
linktitle: Slayt Geçişi
type: docs
weight: 90
url: /tr/net/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- Morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for .NET ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması veya zamanlayıcı ile yapılandırabilir ve bir efekti özel seçeneklerini ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için C# örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile bir sunum yükleyin ve slaytın [SlideShowTransition](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/slideshowtransition/) özelliğine erişin. [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/type/) özelliğini [TransitionType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitiontype/) enum'undan bir değer olarak ayarlayın, ardından sunumu kaydedin.

Aşağıdaki örnek, birinci slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki özellikler bu davranışı kontrol eder:

- [AdvanceOnClick](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceonclick/) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [AdvanceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceafter/) otomatik ilerlemeyi etkinleştirir.
- [AdvanceAfterTime](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceaftertime/) otomatik ilerlemeden önceki gecikmeyi milisaniye cinsinden belirtir.

İzleyicinin bir tıklama ile ilerlemesini veya zamanlayıcıyı beklemesini sağlamak için hem tıklama hem de zamanlı ilerlemeyi etkinleştirin. Yalnızca zamanlayıcıyı kullanmak için [AdvanceOnClick](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceonclick/) özelliğini `false` olarak ayarlayın. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [AdvanceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceafter/) özelliğini okuyun. Depolanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Geçiş Zamanlamasını Hassas Bir Şekilde Kontrol Et**

[Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/duration/) kullanarak bir geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtebilirsiniz. Slaytın [SlideShowTransition](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/slideshowtransition/) özelliği bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/) aracılığıyla sunar:

| Özellik | Amaç |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/duration/) | Geçiş efektinin süresini milisaniye cinsinden ayarlar. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [AdvanceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceafter/) özelliğini etkinleştirin. |
| [Speed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/speed/) | Bir önceden tanımlı hız kategorisini [TransitionSpeed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionspeed/) (Yavaş, Orta, Hızlı) içinden seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[Duration] yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [Speed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre efekt süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Efekt süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Bireysel Slaytlar için Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş ve bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek birinci slayt için 500 milisaniye, ikinci slayt için 1.200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Geçişleri Hareketli Çıktıyla Koordine Et**

Bir [animated GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/net/export-to-html5/) ya da [video](/slides/tr/net/convert-powerpoint-to-video/) hazırlarken, istediğiniz tempo ile eşleşecek şekilde dışa aktarmadan önce kesin geçiş sürelerini ayarlayın. Örneğin, sahneler arasında 600 milisaniyelik bir solma (fade) kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içeriği için zaman tanıyın.

GIF ve video için, çıktı kare hızını efekt süresiyle koordine edin: 600 milisaniye, 30 fps'de 18 kareye eşittir. HTML5'te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı önizleyin.

### **Mevcut Bir Geçiş Süresini Oku**

[Duration] değerini geçişi değiştirmeden önce okuyarak açık bir değerin depolanıp depolanmadığını belirleyin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise depolanan sürenin milisaniye cinsinden olduğunu gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [Speed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/speed/) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlar arasındaki nesnelerdeki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı kopyalayın, kopyadaki bir nesneyi taşıyın veya yeniden boyutlandırın ve Morph geçişini ikinci slayta uygulayın. Bu, geçişin ilgili nesneleri özgün ve değiştirilmiş durumları arasında canlandırmasını sağlar.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı kopyalar ve kopyadaki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitiontype/) enum'undan Morph seçer. Kaydedilen dosyayı Morph destekleyen bir sunum görüntüleyicide açarak slayt gösterisi sırasında efekti görün.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph Geçiş Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionmorphtype/) enum'u, Morph'un içeriği nasıl eşleyeceğini ve canlandıracağını belirler:

- [ByObject](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionmorphtype/) Her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionmorphtype/) Metni mümkün olduğunda kelimelerle eşleştirerek canlandırır.
- [ByChar](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionmorphtype/) Metni mümkün olduğunda karakterlerle eşleştirerek canlandırır.

Geçişin [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/type/) özelliğini Morph olarak ayarlayın, ardından [Value](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/value/) özelliğine erişin. Bu değer, [IMorphTransition](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/imorphtransition/) arayüzünü sağlar; bu arayüzün [MorphType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/imorphtransition/morphtype/) özelliği eşleştirme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler, yön gibi ek seçenekler ya da etkinin siyah ekrandan başlayıp başlamadığı gibi seçenekler sunar. Kullanılabilir seçenekler seçilen geçişin [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/type/) özelliğine bağlıdır. Önce tipi ayarlayın, ardından [Value](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/value/) aracılığıyla uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah ekrandan başlamasını sağlamak için [IOptionalBlackTransition](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/ioptionalblacktransition/) aracılığıyla [FromBlack](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) ayarını yapar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/duration/) kullanın. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionspeed/) (Yavaş, Orta, Hızlı) kategorisi yeterli olduğunda ve açık bir süre ayarlanmamışsa [Speed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/speed/) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [Sound](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/sound/) özelliğine atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionsoundmode/) enum'undan StartSound olarak [SoundMode](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/soundmode/) ayarlayın ve [SoundLoop](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/soundloop/) özelliğini etkinleştirin. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döngüde çalar.

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

Sunumun [Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonunda döngü oluşturup her slaydın geçiş [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/type/) özelliğini aynı değere ayarlayın. Zamanlama ve efekt seçeneklerini aynı döngü içinde ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaydın [SlideShowTransition](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/slideshowtransition/) özelliğinden [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/type/) değerini okuyun. Bu, [TransitionType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitiontype/) enum'undan bir değer döndürür; None değeri hiçbir geçiş efektinin uygulanmadığını gösterir.