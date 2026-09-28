---
title: ".NET'te Slayt Düzenlerini Uygula veya Değiştir"
linktitle: "Slayt Düzeni"
type: docs
weight: 60
url: /tr/net/slide-layout/
keywords:
- "slayt düzeni"
- "içerik düzeni"
- "yer tutucu"
- "sunum tasarımı"
- "slayt tasarımı"
- "kullanılmayan düzen"
- "alt bilgi görünürlüğü"
- "başlık slaytı"
- "başlık ve içerik"
- "bölüm başlığı"
- "iki içerik"
- "karşılaştırma"
- "sadece başlık"
- "boş düzen"
- "başlık açıklamalı içerik"
- "başlık açıklamalı resim"
- "başlık ve dikey metin"
- "dikey başlık ve metin"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Aspose.Slides for .NET'te slayt düzenlerini uygulama, oluşturma ve düzenleme, yer tutucular ekleme, kullanılmayan düzenleri kaldırma ve alt bilgi görünürlüğünü kontrol etme."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken, her bir slaytın kendi içeriğini içermesine olanak tanır.

En yaygın düzenler şunlardır:

- **Title Slide**: Başlık ve alt başlık yer tutucularını içerir.
- **Title and Content**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Blank**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda faydalıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilgili seviyeye sahiptir:

1. A [ana slayt](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. A [düzen slaytı](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/) bir ana slayta aittir ve yer tutucuların belirli bir düzenlemesini tanımlar.
1. A [normal slayt](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) bir düzen kullanır ve bu slayt için girilen içeriği saklar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden devralır ve düzen de kendi ana slaytından devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir; bu yer tutuculara girilen içerik normal slayta aittir.

Bir slayt yaratmadan önce düzene gerekli yer tutucuları ekleyin. Daha sonra düzene yeni bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki devralınan biçimlendirme ya da mevcut yer tutucu geometrisinin değiştirilmesi, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanılan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce ilgili slaytları başka bir düzene yeniden atayın ya da yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst düzeyi hakkında daha fazla bilgi için [Slayt Ana](/slides/tr/net/slide-master/) bölümüne bakın.

Bir slaytta ya da ortak bir düzende devralınan logoları ya da dekoratif ana şekilleri gizlemek için [Ana Grafiklerin Görünürlüğünü Kontrol Et](/slides/tr/net/slide-master/) bölümüne bakın. Örnek, aynı ana slaytı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçin ve Uygulayın**

Sunum standart PowerPoint düzen tanımlarını izliyorsa bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle ad temelli seçim, kaynak şablonu kontrol etmiyorsanız daha az güvenilir olur.

Aşağıdaki örnek, ilk ana slaytta **Title and Content** düzenini arar. Bu düzen bulunamazsa kasıtlı olarak **Blank** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen daha sonra [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) özelliği üzerinden ilk normal slayta uygulanır.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı kontrol edin.

## **Bir Düzen Slaytı Ekleyin**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için hedef ana slaydın düzen koleksiyonunda [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/masterlayoutslidecollection/add/) metodunu çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Title and Content** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Bir şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucu Ekleyin**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/placeholdermanager/) özelliği, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu               | `ILayoutPlaceholderManager` Yöntemi |
| ----------------------------------- | ----------------------------------- |
| ![İçerik](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![İçerik (Dikey)](contentV.png)    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Metin](text.png)                  | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Metin (Dikey)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Resim](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafik](chart.png)                | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tablo](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medya](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Aşağıdaki örnek, **Blank** düzeninin varlığını doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıralama kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slayt için karşılık gelen yer tutucu şekillerini üretebilir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Devralınan biçimlendirme ya da mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geriye doğru doldurulmaz. Düzen değişikliklerini bir sunum kopyasında test edin ve her bağlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırın**

[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metodunu kullanarak hiçbir normal slayt tarafından referans edilmeyen düzenleri kaldırın. Metod, hâlâ kullanılan düzenleri olduğu gibi bırakır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Belirli bir düzeni kaldırmak için önce onun [HasDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/hasdependingslides/) özelliğini veya [GetDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/getdependingslides/) metodunu kullanın. Bağlı slaytları yeniden atamadan önce [ILayoutSlide.Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/remove/) metodunu çağırmayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) ortaya çıkarır.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Edin**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/headerfootermanager/) özelliğini kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin göstermemesi gerektiğinde faydalıdır.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Bir Ana ve Çocuk Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Edin**

Bir ana hiyerarşisi genelinde tutarlı alt bilgi ayarları uygulamak için [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/headerfootermanager/) özelliğini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslideheaderfootermanager/) kapsam yöntemleri, ana slayt ve ona bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **SSS**

**Ana Slayt ve Düzen Slaytı Arasındaki Fark Nedir?**

Ana slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Düzen slaytı bir ana slayta aittir ve yer tutucuların yeniden kullanılabilir bir düzenini belirler. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği saklar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/globallayoutslidecollection/addclone/) metodunu kullanın. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı fontları, temaları, görüntüleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenen biçimlendirmeyi ya da nesneleri geçersiz kılmazlarsa, düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil, birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenebilecek slaytları belirlemek için [GetDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/getdependingslides/) metodunu kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metodunu kullanın.