---
title: Aspose.Slides for .NET'te Slayt Düzenlerini Uygula veya Değiştir
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/net/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- altbilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- yalnızca başlık
- boş düzen
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET'te slayt düzenlerini yönetin ve özelleştirin. Düzen tiplerini, yer tutucu kontrolünü ve altbilgi görünürlüğünü C# kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki içerik için yer tutucu kutuların düzenini ve biçimlendirmeyi tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede görüneceklerini kontrol eder. Slayt düzenleri, ister basit ister daha karmaşık bir şey oluşturuyor olun, sunuları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'te en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – İçerik iki metin yer tutucusu içerir: biri başlık, diğeri alt başlık için.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında metin, madde işaretleri, grafikler, resimler ve daha fazlası gibi ana içerik için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Hiç yer tutucu içermez; slaytı tamamen sıfırdan tasarlamanıza olanak tanır.

Slayt düzenleri, sunum için düzen stillerini tanımlayan üst düzey slayt olan slayt ana temasının bir parçasıdır. Slayt ana teması aracılığıyla düzen slaytlarına erişebilir ve bunları değiştirebilirsiniz—tipine, adına veya benzersiz kimliğine göre. Alternatif olarak, belirli bir düzen slaytını doğrudan sunu içinde düzenleyebilirsiniz.

Aspose.Slides for .NET içinde slayt düzenleriyle çalışmak için şunları kullanabilirsiniz:

- Özellikler, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı altında bulunan [LayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/layoutslides/) ve [Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) gibi.
- Türler, [ILayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutplaceholdermanager/), ve [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslideheaderfootermanager/) gibi.

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışmak hakkında daha fazla bilgi edinmek için [Slide Master](/slides/tr/net/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunulara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için sunuya yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for .NET, belirli bir düzenin zaten mevcut olup olmadığını kontrol etmenizi, gerekirse yeni bir tane eklemenizi ve bu düzeni temel alarak slayt eklemenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterlayoutslidecollection/)’e erişin.  
3. İstenen düzen slaytının koleksiyonda zaten bulunup bulunmadığını kontrol edin. Yoksa, ihtiyacınız olan düzen slaytını ekleyin.  
4. Yeni düzen slaytına dayalı boş bir slayt ekleyin.  
5. Sunuyu kaydedin.

```cs
// PowerPoint dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Bir düzen slaytı seçmek için düzen slaytı tipleri arasında geçiş yapın.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Sunumun tüm düzen tiplerini içermediği bir durum.
        // Sunum dosyası yalnızca Boş ve Özel düzen tiplerini içerir.
        // Ancak, özel tiplerdeki düzen slaytları tanınabilir isimlere sahip olabilir,
        // örneğin "Title", "Title and Content" gibi, bu isimler düzen slaytı seçimi için kullanılabilir.
        // Ayrıca bir dizi yer tutucu şekil tipine dayanabilirsiniz.
        // Örneğin, bir Başlık slaytı yalnızca Title yer tutucu tipine sahip olmalıdır, vb.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Sunumu diske kaydedin.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan düzen slaytlarını silmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) sınıfındaki [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metodunu sunar.

Aşağıdaki C# kodu, bir PowerPoint sunusundan düzen slaytını nasıl kaldıracağınızı gösterir:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Slayt Düzenlerine Yer Tutucu Ekleme**

Aspose.Slides, bir düzen slaytına yeni yer tutucular eklemenizi sağlayan [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/placeholdermanager/) özelliğini sunar.

Bu yönetici, aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutplaceholdermanager/) Method |
| --------------------- | ------------------------------------------------------------ |
| ![İçerik](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![İçerik (Dikey)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Metin](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Metin (Dikey)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Resim](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafik](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tablo](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medya](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Çevrimiçi Resim](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki C# kodu, Boş düzen slaytına yeni yer tutucu şekilleri nasıl ekleyeceğinizi gösterir:

```cs
using (var presentation = new Presentation())
{
    // Boş düzen slaytını alın.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Düzen slaytının yer tutucu yöneticisini alın.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Boş düzen slaytına farklı yer tutucular ekleyin.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Boş düzen ile yeni bir slayt ekleyin.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Düzen slaytındaki yer tutucular](add_placeholders.png)

## **Bir Düzen Slaytı İçin Altbilgi Görünürlüğü Ayarlama**

PowerPoint sunularında, tarih, slayt numarası ve özel metin gibi altbilgi öğeleri slayt düzenine bağlı olarak gösterilebilir veya gizlenebilir. Aspose.Slides for .NET, bu altbilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu, belirli düzenlerin altbilgi bilgilerini göstermesini, diğerlerinin ise temiz ve sade kalmasını istediğinizde kullanışlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle bir düzen slaytı referansı alın.  
3. Slayt altbilgi yer tutucusunu görünür olarak ayarlayın.  
4. Slayt numarası yer tutucusunu görünür olarak ayarlayın.  
5. Tarih‑saat yer tutucusunu görünür olarak ayarlayın.  
6. Sunuyu kaydedin.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Bir Slayt İçin Alt Slayt Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunularında, tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, tüm düzen slaytlarında tutarlılığı sağlamak için ana slayt seviyesinde kontrol edilebilir. Aspose.Slides for .NET, bu altbilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sununuz boyunca tutarlı altbilgi bilgilerinin olmasını sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle ana slayta bir referans alın.  
3. Ana slaydın ve tüm alt slaytların altbilgi yer tutucularını görünür olarak ayarlayın.  
4. Ana slaydın ve tüm alt slaytların slayt numarası yer tutucularını görünür olarak ayarlayın.  
5. Ana slaydın ve tüm alt slaytların tarih‑saat yer tutucularını görünür olarak ayarlayın.  
6. Sunuyu kaydedin.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Ana slayt ile düzen slaytı arasındaki fark nedir?**

Ana slayt, genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için yer tutucuların belirli düzenlemelerini tanımlar.

**Bir düzen slaytını bir sunudan başka bir sunuya kopyalayabilir miyim?**

Evet, bir sununun [LayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/layoutslides/) koleksiyonundan bir düzen slaytını klonlayabilir ve `AddClone` yöntemiyle başka birine ekleyebilirsiniz.

**Bir slayt tarafından hâlâ kullanılan bir düzen slaytını silersem ne olur?**

Eğer bir sunuda en az bir slayt tarafından hâlâ referans edilen bir düzen slaytını silmeye çalışırsanız, Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenli bir şekilde kaldıran [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini kullanın.