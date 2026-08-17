---
title: .NET'te Slayt Düzenlerini Uygula veya Değiştir
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
- alt bilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
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
description: "Aspose.Slides for .NET içinde slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve alt bilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken her slaytın kendi içeriğini barındırmasına izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlar için kullanışlıdır.

## **Düzen Kalıtımını Anlama**

Bir sunumun üç ilgili seviyesi vardır:

1. Bir [ana slayt](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/) bir ana slayta aittir ve belirli bir yer tutucu düzenini tanımlar.
1. Bir [normal slayt](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Normal bir slayt temayı ve biçimlendirmeyi düzeninden devralır ve düzen de ana slayttan devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçili düzenden üretilir; bu yer tutuculara girilen içerik ise normal slayta aittir.

Kaydırılardan slayt oluşturulmadan önce bir düzene gerekli yer tutucular eklenmelidir. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzende devralınan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımdaki bir düzeni düzenlemeden önce, bağlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt hâlâ kullandığı bir düzen silinemez. Önce bağlı slaytları başka bir düzene yeniden atayın ya da yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slayt Master](/slides/tr/net/slide-master/) bölümüne bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını takip ediyorsa bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden kaynak şablonu kontrol etmiyorsanız ad‑temelli seçim daha az güvenilirdir.

Aşağıdaki örnek, ilk ana slaytta **Başlık ve İçerik** arar. Bu düzen mevcut değilse kasıtlı olarak **Boş** a geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen daha sonra ilk normal slayta [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) özelliği aracılığıyla uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenmiş olağan şekilleri kaldırmaz. Ancak yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden çok farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; yeni bir tane oluşturmaz. Bir düzen oluşturmak için hedef ana slaydın düzen koleksiyonunda [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/tr/net/aspose.slides/masterlayoutslidecollection/add/) yöntemini çağırın.

Aşağıdaki örnek her zaman `Rapor Başlığı ve İçeriği` adında yeni bir **Başlık ve İçerik** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Sadece şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktan kaçının; bunun yerine mevcut düzeni seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleme**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/placeholdermanager/) özelliği, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucusu | `ILayoutPlaceholderManager` Yöntemi |
| ----------------------- | ----------------------------------- |
| ![İçerik](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![İçerik (Dikey)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Metin](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Metin (Dikey)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Resim](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafik](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tablo](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medya](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Aşağıdaki örnek **Boş** düzeninin var olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıralama kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekillerini üretebilir.

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

{{% alert color="warning" title="Uyarı" %}}
Devralınan biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak geri doldurulmaz. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini kullanarak hiçbir normal slayt tarafından referans edilmeyen düzenleri kaldırın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Belirli bir düzeni kaldırmak için önce [HasDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/hasdependingslides/) özelliğini ya da [GetDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/getdependingslides/) yöntemini kullanın. [ILayoutSlide.Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/remove/) metodunu çağırmadan önce bağlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) fırlatır.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/headerfootermanager/) özelliğini kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

Aşağıdaki örnek bir düzeni güvenli bir şekilde seçer ve alt bilgi öğelerini görünür kılar:

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

## **Bir Ana Slayt ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir ana slayt hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/headerfootermanager/) özelliğini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslideheaderfootermanager/) sınıfının yayma yöntemleri, ana slayt, ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

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

**Bir Ana Slayt ile Bir Düzen Slaytı Arasındaki Fark Nedir?**

Ana slayt sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir düzen slaytı ana slayta aittir ve bir kez kullanılabilir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona [AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/globallayoutslidecollection/addclone/) yöntemiyle bir kopya ekleyin. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Kullanımdaki Bir Düzeni Değiştirirsem Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenmiş biçimlendirme veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil birçok slaytta bir anda değişebilir. Düzen üzerinde değişiklik yapmadan önce etkilenen slaytları belirlemek için [GetDependingSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/getdependingslides/) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception/) fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini kullanın.