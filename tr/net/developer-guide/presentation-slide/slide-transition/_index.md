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
- morf geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ile diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for .NET ile her slayt için bir geçiş efekti seçebilir, geçişin fare tıklamasıyla mı yoksa zamanlayıcıyla mı ilerleyeceğini yapılandırabilir ve efekti özel seçeneklerle ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş süreleri ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için C# örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) özelliğine erişin. [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) özelliğini [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enum’undan bir değerle ayarlayın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Tekerlek Geçişi**

[IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) arayüzünün [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) özelliği, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. Geçişin [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) özelliğini [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) içinde Wheel olarak ayarlayın, ardından [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) özelliğine [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) olarak erişin.

Bu örnek iki aynı slayt çifti oluşturur: bir siyah slayt ve ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar 1 ve 8 spoke sayısıyla, aynı [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) ve 8.000 milisaniye olarak belirlenmiş açık bir [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ile oluşturulur, böylece fark gözlemlenebilir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Çıktı sunumunu PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta, ardından 3. slayttan 4. slayta geçin. PowerPoint oynatımında, 1 spoke sayısı saat yönünde tek bir süpürme ile slaytı ortaya çıkarırken, 8 spoke sayısı aynı anda sekiz radyal sektörle ortaya çıkarır. Hedef içerik ve geçiş zamanlaması aynıdır; fark, ortaya çıkış sektörlerinin sayısıdır.

## **Reveal Geçişiyle Siyah Üzerinden Solma**

Hedef slaytın geçiş türünü Reveal olarak ayarlayın, ardından [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) aracılığıyla [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/) özelliğini belirleyin. Örnek, bir turkuaz kaynak slaytı ve bir mercan hedef slaytı oluşturur, ardından her ikisini de klonlayarak iki saniyelik geçişi kapalı ve açık halde karşılaştırmanıza olanak tanır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

PowerPoint slayt gösterisinde, 1. slayttan 2. slayta ilerleyin. Turkuaz doğrudan mercana geçer. Ardından 3. slayttan 4. slayta ilerleyin. Ekran, mercan slaytı görünmeden önce kısa bir süre neredeyse siyaha karartılır. Her iki slayt da özgün arka plan renklerini korur.

Aşağıdaki satırlar PowerPoint’te yarım saniyelik aralıklarla alınan kareleri gösterir. Etkilenen ayarı görmek için her satırın orta karesine bakın.

![PowerPoint oynatımında ThroughBlack devre dışı (üst) ve etkin (alt) olduğu durum. Yalnızca alt satır neredeyse siyaha geçiş yapar.](reveal-through-black.png)

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar kalacağını ve fare tıklamasıyla mı yoksa zamanlayıcıyla mı ilerleyeceğini yapılandırabilirsiniz. Aşağıdaki özellikler bu davranışı kontrol eder:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) otomatik ilerlemeyi etkinleştirir.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) otomatik ilerleme öncesi gecikmeyi milisaniye olarak belirtir.

Hem tıklama hem de zamanlayıcı ilerlemesini etkinleştirerek izleyicinin tıklama yaparak ya da zamanlayıcıyı bekleyerek ilerlemesine izin verin. Yalnızca zamanlayıcıyı kullanmak için [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) özelliğini `false` yapın. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini belirler; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlayıcı ilerlemesinin etkin olup olmadığını kontrol etmek için [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) değerini okuyun. Depolanan gecikme yalnızca bir zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmesi olan slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) kullanın. Slaytın [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) özelliği bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) aracılığıyla ortaya koyar:

| Özellik | Amaç |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Geçiş efektinin kendisinin süresini milisaniye olarak ayarlar. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye olarak ayarlar. Bu zamanlayıcıyı etkinleştirmek için [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) özelliğini kullanın. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) enum’undan yavaş, orta veya hızlı gibi ön tanımlı bir hız kategorisi seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre etki süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) içerisinden Fade seçer ve her bir geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından PPTX olarak kaydeder.

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

    // Geçiş süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek ilk slayta 500 milisaniye, ikinci slayta 1.200 milisaniye süresi ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Animasyonlu Çıktı ile Geçişleri Koordine Et**

[animated GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/net/export-to-html5/) veya [video](/slides/tr/net/convert-powerpoint-to-video/) hazırlarken, dışa aktarımdan önce kesin geçiş süreleri belirleyerek istenen tempoya uyun. Örneğin sahneler arasında 600 milisaniyelik bir solma kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik süresine yer açın.

GIF ve video için, çerçeve hızını efekt süresiyle eşleştirin: 600 milisaniye 30 fps’de 18 kareye denk gelir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçili dışa aktarım formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) değerini okuyarak açık bir değer depolanıp depolanmadığını belirleyin. `-1` değeri açık bir sürenin ayarlanmadığını, negatif olmayan bir değer ise milisaniye cinsinden depolanmış süreyi gösterir. Ayarlanmamış değer, oynatma süresinin hesaplanmış hali değildir: Aspose.Slides geçiş tipi ve [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) kullanılarak bu süre belirlenir. Bir geçiş türü ayarlamak, bir süreyi başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri animasyonlaştırır. Basit bir Morph efekti oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Böylece geçiş, nesnelerin orijinal ve değiştirilmiş durumları arasında animasyon sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enum’undan Morph seçer. Morph’u destekleyen bir sunum görüntüleyicide kaydedilmiş dosyayı açın ve slayt gösterisi sırasında etkisini izleyin.

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

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) enum’u, Morph’un içeriği nasıl eşleştireceğini ve animasyonlayacağını belirler:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda kelimelere göre metni animasyonlandırır.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda karakterlere göre metni animasyonlandırır.

Geçişin [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) özelliğini Morph olarak ayarlayın, ardından [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) üzerinden [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) arayüzünü alın; bu arayüzün [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) özelliği eşleşme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime temelli Morph animasyonu kullanacak şekilde yapılandırır.

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


<!-- visual-explanation:slide-transition:start -->
[![Morph eşleşme birimleri bütün şekil, ayrı ayrı kelimeler ve ayrı ayrı karakterler olarak gösterilir.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph, mümkün olduğunda bütün şekilleri, kelimeleri veya karakterleri eşleştirebilir. Bu kutular, gözlemlenen hareket yerine eşleşen birimleri tanımlar. Örnek, ikinci slaytta ByWord seçer.*
<!-- visual-explanation:slide-transition:end -->

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek yön seçenekleri veya efekti siyah bir ekrandan başlatma gibi ek ayarlar sunar. Kullanılabilir seçenekler, seçilen geçişin [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) değerine bağlıdır. Önce türü ayarlayın, ardından [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) üzerinden uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) aracılığıyla [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) ayarlayarak geçişin siyah bir ekrandan başlamasını sağlar.

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

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) kategorisinin (Slow, Medium veya Fast) yeterli olduğu ve açık bir süre ayarlanmamışsa [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) kullanın. Bu ayarlar, otomatik ilerleme gecikmesinden bağımsız olarak geçiş efektini kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) özelliğine atayın, [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) enum’undan StartSound seçerek [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) ayarlayın ve [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) özelliğini etkinleştirin. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döngüde devam eder.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) koleksiyonunda döngü oluşturun ve her slaydın geçiş [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) özelliğini aynı değere ayarlayın. Aynı döngü içinde zamanlama ve efekt seçeneklerini de ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaydın [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) özelliğinden [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) değerini okuyun. Bu değer, [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enum’undan bir değer döndürür; None değeri, hiçbir geçiş etkisinin uygulanmadığını gösterir.