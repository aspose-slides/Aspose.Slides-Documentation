---
title: .NET'te Sunumları HTML5'e Dönüştür
linktitle: Sunumdan HTML5'e
type: docs
weight: 40
url: /tr/net/export-to-html5/
keywords:
- PowerPoint'tan HTML5'e
- OpenDocument'tan HTML5'e
- sunumdan HTML5'e
- slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'den HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Aspose.Slides for .NET ile duyarlı HTML5'e dışa aktarın. Biçimlendirmeyi, animasyonları ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ve yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmanın SVG tabanlı çıktısıyla karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktar**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek animasyon oynatımını açıkça nasıl kontrol edeceğinizi gösterir. Giriş yolunu sunumunuzun yolu ile değiştirin.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
HTML belgesinin yanı sıra, dışa aktarma slayt stilizasyonu, animasyonlar, efektler ve gezinme için destekleyici CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayınlarken bu dosyaları HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonlarını veya slayt geçişlerini oynatmadan dışa aktarmak için, [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) ve [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) ayarlarını [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) içinde `false` olarak belirleyin. Bu ayarlar bağımsızdır, bu nedenle birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türü de devre dışı bırakılmış şekilde sunumu oluşturulmuş sayfaya dışa aktarır.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint'i HTML'e Dışa Aktar**

Standart HTML dışa aktarma farklı bir renderleme yöntemi kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yöntemini kullanarak bir sunumu HTML belgesine dönüştürür.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Aşağıdaki basitleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi renderlenmiş slayt içeriğini içerir; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarma çıktısı değildir.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı ayrı HTML öğeleri olarak ortaya çıkmaz. Bu makalede gösterilen şekil animasyonu ve slayt geçişi seçeneklerine ihtiyaç duyduğunuzda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktar**

HTML5 dışa aktarma, tarayıcıda sunum slaytlarını görüntülemek ve gezmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdan efektleri oynatabilmesi için hem [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) hem de [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) öğelerini etkinleştirir. Bu ayarların etkisini görmek için içinde zaten şekil animasyonları ve slayt geçişleri bulunan bir sunum kullanın. Bunları etkinleştirmek, hiç efekti olmayan slaytlara yeni efekt eklemez. Dışa aktarma sonrasında, destekleyici dosyaları mevcut olduğu bir tarayıcıda oluşturulan HTML5 belgesini açın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Sunumu Yorumlarla Birlikte HTML5 Belgesine Dönüştür**

Mevcut slayt yorumlarını HTML5 çıktısına ekleyebilir, böylece okuyucular slayt içeriğiyle birlikte geri bildirimi görebilir. Bu bölümdeki örnek, kaynak sunumun aşağıda gösterildiği gibi yorumlar içerdiğini varsayar. Yorumları dışa aktarır; yeni yorumlar oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

Bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) içindeki [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) özelliğine atayın. Yorumları her slaydın sağına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) enumarasyonundan [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) değerini `Right` olarak ayarlayın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorum içermeyen bir sunumda görüntülenecek yorum metni bulunmaz.

Aşağıdaki görsel, yorumların slayt yanında gösterildiği dışa aktarılan HTML5 belgesini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Hiperlinklerini Hariç Tut**

`hyperlinks.pptx` dosyasının `javascript:alert('Hello')` hedefli bir bağlantılı metin ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. Dışa aktarım sırasında JavaScript hiperlinkini hariç tutmak için [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ayarını `true` olarak belirleyin. Varsayılan değer `false` olduğundan, bu bağlantılar seçeneği etkinleştirene kadar filtrelenmez.

Aşağıdaki örnek, sunumu çalışma dizininden yükler ve [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) kullanarak dışa aktarır:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Dışa aktarılan dosya, JavaScript hiperlinkini metni ve normal HTTPS bağlantısını koruyarak dışarı bırakır. Kaynak sunum değişmez.

Bu seçenek JavaScript hiperlinklerini filtreler; tüm scriptleri veya diğer aktif içeriği kaldırmaz ve CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt gezinmesi ve animasyonlar için scriptler içerir.

## **SSS**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**  
Evet, HTML5 dışa aktarma, [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) ve [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) öğelerini ayrı ayrı etkinleştirmek veya devre dışı bırakmak için seçenekler sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilirler?**  
Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ve yorumlar için [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çalıştıran bağlantıları atlayabilir miyim?**  
Evet, [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ayarı, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanıza olanak tanır. Varsayılan değer `false`. Basit bir HTML, HTML5 ve PDF dışa aktarma örneği ve filtrenin kapsamı için [Dışa Aktarım Sırasında JavaScript Hiperlinklerini Hariç Tut](/slides/tr/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) sayfasına bakın. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.