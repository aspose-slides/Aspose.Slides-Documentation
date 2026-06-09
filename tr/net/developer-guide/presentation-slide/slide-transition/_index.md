---
title: .NET'te Sunumlarda Slayt Geçişlerini Yönetme
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
description: "Aspose.Slides for .NET'te slayt geçişlerini nasıl özelleştireceğinizi keşfedin; PowerPoint ve OpenDocument sunumları için adım adım rehberlik."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Geçiş türlerini slaytlara uygulamayı, tıklamayla ya da belirli bir süreden sonra ilerleme gibi geçiş davranışlarını yapılandırmayı, otomatik ilerlemeyi kontrol etmeyi ve devre dışı bırakmayı, Morph geçişini ve türlerini kullanmayı ve geçiş efekti seçeneklerini ayarlamayı gösterir. Örnekler, bir sunumu nasıl yükleyeceğinizi veya oluşturacağınızı, seçili slaytlar için geçiş ayarlarını nasıl değiştireceğinizi ve sonucu PPTX dosyası olarak nasıl kaydedeceğinizi gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayta uygulanması ve bir slaytta şu anda ayarlı olan geçişin kontrol edilmesi gibi yaygın sorulara yanıt verir.

## **Slayt Geçişi Ekle**
Anlamayı kolaylaştırmak için, Aspose.Slides for .NET'in basit slayt geçişlerini yönetmek için kullanımını gösterdik. Geliştiriciler yalnızca farklı slayt geçiş efektlerini slaytlara uygulayamaz, aynı zamanda bu geçiş efektlerinin davranışını da özelleştirebilirler. Basit bir slayt geçiş efekti oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Aspose.Slides for .NET tarafından sunulan geçiş efektlerinden birini TransitionType enumu aracılığıyla slayta bir Slayt Geçişi Tipi uygulayın.
1. Değiştirilmiş sunum dosyasını yazın.

```c#
 // Kaynak sunum dosyasını yüklemek için Presentation sınıfının bir örneğini oluşturun
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     // 1. slayta daire tipi geçiş uygula
     presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

     // 2. slayta tarama tipi geçiş uygula
     presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

     // Sunumu diske kaydet
     presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde sadece basit bir geçiş efekti uyguladık. Şimdi bu basit geçiş efektini daha iyi ve kontrol edilebilir hâle getirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Aspose.Slides for .NET tarafından sunulan geçiş efektlerinden birini slayta bir Slayt Geçişi Tipi uygulayın.
1. Geçişi Tıklamayla İlerleme, belirli bir süre sonunda İlerleme veya her ikisi olarak da ayarlayabilirsiniz.
1. Slayt geçişi Tıklamayla İlerleme olarak ayarlanmışsa, geçiş yalnızca birisi fareye tıkladığında ilerleyecektir. Ayrıca, Advance After Time özelliği ayarlanmışsa, belirtilen süre geçtikten sonra geçiş otomatik olarak ilerleyecektir.
1. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```c#
 // Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun
 using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
 {

     // 1. slayta daire tipi geçiş uygula
     pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


     // Geçiş süresini 3 saniye olarak ayarla
     pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

     // 2. slayta tarama tipi geçiş uygula
     pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


     // Geçiş süresini 5 saniye olarak ayarla
     pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

     // 3. slayta yakınlaştırma tipi geçiş uygula
     pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


     // Geçiş süresini 7 saniye olarak ayarla
     pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

     // Sunumu diske kaydet
     pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

Ayrıca, [AdvanceAfter](https://reference.aspose.com/slides/tr/net/aspose.slides/islideshowtransition/advanceafter/) özelliğini kullanarak bir slayt geçişinin bir sonraki slayta geçecek şekilde yapılandırılıp yapılandırılmadığını veya ayarın devre dışı bırakılıp bırakılmadığını kontrol edebilirsiniz.

Bu C# kodu işlemi göstermektedir:

```c#
 // Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
 using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
 {
     foreach (ISlide slide in pres.Slides)
     {
         // Slayt geçişini alır
         ISlideShowTransition slideTransition = slide.SlideShowTransition;

         // Advance After Time ayarının etkin olup olmadığını kontrol eder
         if (slideTransition.AdvanceAfter)
         {
             // Advance After Time değerini yazar
             Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
         }

         // AdvanceAfterTime değeri 2 saniyeden büyükse belirli bir süreden sonra geçişi devre dışı bırakır
         if (slideTransition.AdvanceAfterTime > 2000)
         {
             slideTransition.AdvanceAfter = false;
         }
     }
 }
```

## **Morph Geçişi**
Aspose.Slides for .NET artık [Morph Transition](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/imorphtransition) desteklemektedir. Bunlar, PowerPoint 2019'da tanıtılan yeni bir morph geçişidir. Morph geçişi, bir slayttan sonraki slayta sorunsuz bir hareket animasyonu yapmanıza olanak tanır. Bu makale kavramı ve Morph geçişinin nasıl kullanılacağını açıklamaktadır. Morph geçişini etkili bir şekilde kullanmak için en az bir ortak nesne içeren iki slayta ihtiyacınız olacaktır. En kolay yol, slaytı kopyalamak ve ikinci slaytta nesneyi farklı bir yere taşımaktır.

Aşağıdaki kod parçacığı, sunuma bir metin içeren slaytın bir kopyasını eklemeyi ve ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) geçişi ayarlamayı göstermektedir.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph Geçişi Türleri**
Yeni [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionmorphtype) enumu eklendi. Bu, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enumu üç üye içerir:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler bazında aktararak gerçekleşir.
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler bazında aktararak gerçekleşir.

Aşağıdaki kod parçacığı, bir slayta morph geçişi ayarlamayı ve morph türünü değiştirmeyi göstermektedir:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Geçiş Efektlerini Ayarla**
Aspose.Slides for .NET, siyah üzerinden, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.

Aşağıda verilen örnekte geçiş efektlerini ayarladık.

```c#
// Presentation sınıfının bir örneğini oluştur
Presentation presentation = new Presentation("AccessSlides.pptx");

// Etkiyi ayarla
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Sunumu diske kaydet
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [Speed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/speed/) özelliğini [TransitionSpeed](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/transitionspeed/) ayarıyla (ör. slow/medium/fast) ayarlayın.

**Bir geçişe ses ekleyebilir ve bunu döngüye alabilir miyim?**

Evet. Geçiş için bir ses gömebilir ve ses modu ve döngü gibi ayarlarla davranışı kontrol edebilirsiniz (ör. [Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/soundloop/), ayrıca [SoundIsBuiltIn](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) ve [SoundName](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/soundname/) gibi meta veriler).

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

İstenen geçiş tipini her slaytın geçiş ayarlarında yapılandırın; geçişler slayt başına depolandığı için aynı tipi tüm slaytlara uygulamak tutarlı bir sonuç verir.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [transition settings](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide/slideshowtransition/) incelen ve [transition type](https://reference.aspose.com/slides/tr/net/aspose.slides.slideshow/slideshowtransition/type/) okunarak hangi etkinin uygulandığı anlaşılır.