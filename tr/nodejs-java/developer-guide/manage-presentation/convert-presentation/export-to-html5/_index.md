---
title: JavaScript'te Sunumları HTML5'e Dönüştürme
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/nodejs-java/export-to-html5/
keywords:
- PowerPoint'ten HTML5'e
- OpenDocument'ten HTML5'e
- Sunumdan HTML5'e
- Slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'den HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirmeyi, animasyonları ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ile yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarımının SVG tabanlı çıktısı ile karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükleyip HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; sonraki örnek ise animasyon çalımını açıkça nasıl kontrol edeceğinizi gösterir. Giriş yolunu sunumunuzun yolu ile değiştirin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML belgesi dışında, dışa aktarma slayt stillendirmesi, animasyonlar, efektler ve gezinme için destekleyici CSS ve JavaScript dosyaları da yazar. Çıktıyı taşırken veya yayınlarken bu dosyaları HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js dosyalarını genel CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonlarını veya slayt geçişlerini oynatmadan dışa aktarmak için `false` değerini [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) ve [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) metodlarına, [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) içinde geçirin. Bu ayarlar bağımsızdır; birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türünün de devre dışı bırakıldığı bir sayfa üretir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i HTML'ye Dışa Aktarma**

Standart HTML dışa aktarma, farklı bir renderleme yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Aşağıdaki sadeleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi renderlenmiş slayt içeriğini barındırır; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarım çıktısı değildir.

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
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı ayrı HTML öğeleri olarak ortaya çıkarmaz. Bu makalede gösterilen şekil‑animasyonu ve slayt‑geçişi seçeneklerine ihtiyaç duyduğunuzda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktarma**

HTML5 dışa aktarma, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdaki efektleri oynatabilmesi için hem [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) hem de [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) seçeneklerini etkinleştirir.

Şekil animasyonları ve slayt geçişleri içeren bir sunumu kullanarak bu ayarların etkisini görün. Bu ayarları etkinleştirmek, hiç animasyonu olmayan slaytlara yeni efekt eklemez. Dışa aktarmadan sonra, oluşturulan HTML5 belgesini destekleyici dosyalar mevcut iken bir tarayıcıda açın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Yorumlarla Bir HTML5 Belgesi Olarak Sunumu Dönüştürme**

Mevcut slayt yorumlarını HTML5 çıktısına dahil ederek okuyucuların yorumları slayt içeriğinin yanında görmesini sağlayabilirsiniz. Bu bölümdeki örnek, kaynak sunumun yorumlar içerdiğini varsayar (aşağıda gösterildiği gibi). Yorumları dışa aktarır; yeni yorum oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) metoduna, [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) üzerinden geçirin. Yorumları her slaytın sağına yerleştirmek için [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) metodunu kullanarak `Right` değerini [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) enumundan seçin.

Aşağıdaki örnek, bu yorum yerleşimiyle sunumu HTML5'e dışa aktarır. Yorum içermeyen bir sunumda gösterilecek yorum metni olmaz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Aşağıdaki görüntü, yorumların slaytın yanında gösterildiği dışa aktarılmış HTML5 belgesini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Bağlantılarını Hariç Tut**

`hyperlinks.pptx` dosyasının, `javascript:alert('Hello')` hedefli bir bağlantı metni ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. JavaScript bağlantısını dışa aktarmadan hariç tutmak için [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) metoduna `true` değerini geçirin. Varsayılan değer `false` olduğundan, bu seçenek etkinleştirilmediği sürece bağlantılar filtrelenmez.

Aşağıdaki örnek, çalışma dizininden sunumu yükler ve [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) kullanarak dışa aktarır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Dışa aktarılan dosya, JavaScript bağlantısını metniyle birlikte tutarken normal HTTPS bağlantısını korur. Kaynak sunum değişmez.

Bu seçenek JavaScript bağlantılarını filtreler; tüm script'leri veya diğer aktif içeriği kaldırmaz, ayrıca CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt gezintisi ve animasyonları için script'ler içerir.

## **SSS**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarma, [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) için ayrı ayrı etkinleştirme veya devre dışı bırakma seçenekleri sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ayarı, kaydetme sırasında JavaScript çağrısı içeren bağlantıların atlanmasını sağlar. Varsayılan değer `false`dır. **[Dışa Aktarım Sırasında JavaScript Bağlantılarını Hariç Tut](/slides/tr/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export)** bölümünde bir HTML5 dışa aktarma örneği ve filtre kapsamı bulunur. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.