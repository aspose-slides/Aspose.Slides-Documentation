---
title: PHP'de Sunumları HTML5'e Dönüştür
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/php-java/export-to-html5/
keywords:
- PowerPoint'tan HTML5'e
- OpenDocument'ten HTML5'e
- sunumdan HTML5'e
- slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'ten HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Java aracılığıyla PHP için Aspose.Slides ile duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşim korunur."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ve yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmanın SVG tabanlı çıktısı ile karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek ise animasyon oynatımını açıkça nasıl kontrol edebileceğinizi gösterir. Girdi yolunu sunumunuzun yoluyle değiştirin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML belgesinin yanı sıra, dışa aktarım slayt stilizasyonu, animasyonlar, efektler ve navigasyon için destekleyici CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayınlarken bu dosyaları HTML belgesi ile birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt navigasyonu ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonlarını veya slayt geçişlerini oynatmadan dışa aktarmak için, [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) içinde [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) ve [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) yöntemlerine `false` gönderin. Bu ayarlar bağımsızdır, bu yüzden birini etkinleştirip diğerini devre dışı bırakabilirsiniz. Örnek, oluşturulan sayfada her iki animasyon türünün de devre dışı bırakıldığı şekilde sunumu dışa aktarır.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint'i HTML'e Dışa Aktarma**

Standart HTML dışa aktarımı farklı bir renderleme yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki sadeleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi renderlenen slayt içeriğini içerir; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarma çıktısı değildir.

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
SVG tabanlı dışa aktarım, PowerPoint şekillerini bireysel HTML öğeleri olarak ortaya çıkarmaz. Bu makalede gösterilen şekil animasyonu ve slayt geçişi seçeneklerine ihtiyaç duyduğunuzda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktarma**

HTML5 dışa aktarımı, sunum slaytlarını bir tarayıcıda görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdaki efektleri oynatabilmesi için [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) ve [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) yöntemlerini etkinleştirir.

Bu ayarların etkisini görmek için zaten şekil animasyonları ve slayt geçişleri içeren bir sunum kullanın. Bunları etkinleştirmek, hiçbir efekti olmayan slaytlara yeni efekt eklemez. Dışa aktarmadan sonra, oluşturulan HTML5 belgesini destek dosyaları mevcutken bir tarayıcıda açın.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Yorumlarla Birlikte Sunumu HTML5 Belgesine Dönüştürme**

Mevcut slayt yorumlarını HTML5 çıktısına dahil edebilirsiniz, böylece okuyucular slayt içeriğinin yanında geri bildirimleri görebilir. Bu bölümdeki örnek, kaynak sunumun aşağıda gösterildiği gibi yorum içerdiğini varsayar. Yorumları dışa aktarır; yeni yorum oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

Bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) sınıfının [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) metoduna geçirin. Yorumları her slaydın sağına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) enum'undan `Right` değerini seçmek üzere [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) kullanın.

Aşağıdaki örnek, sunumu bu yorum düzeniyle HTML5'e dışa aktarır. Yorum içermeyen bir sunumda gösterilecek yorum metni olmayacaktır.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Hiperlinklerini Hariç Tutma**

`hyperlinks.pptx` dosyasının `javascript:alert('Hello')` hedefi olan bir bağlanmış metin ve normal bir `https://example.com/` linki içerdiğini varsayalım. Dışa aktarım sırasında JavaScript hiperlinkini hariç tutmak için [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) yöntemine `true` gönderin. Varsayılan değer `false` olduğu için bu linkler, seçeneği etkinleştirene kadar filtrelenmez.

Aşağıdaki örnek, sunumu çalışma dizininden yükler ve [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) kullanarak dışa aktarır:

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Dışa aktarılan dosya, metni ve normal HTTPS linkini korurken JavaScript hiperlinkini atlar. Kaynak sunum değişmemiştir.

Bu seçenek JavaScript hiperlinklerini filtreler; tüm betikleri veya diğer aktif içerikleri kaldırmaz ve CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt navigasyonu ve animasyonlar için betikler içerir.

## **SSS**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarımı, [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) ve [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) ayrı ayrı etkinleştirme veya devre dışı bırakma seçenekleri sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ile yorumlar için [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) aracılığıyla (örneğin, slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran linkleri atlayabilir miyim?**

Evet, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ayarı, kaydetme sırasında JavaScript çağıran hiperlinkleri atlamanızı sağlar. Varsayılan `false`'tur. Bir HTML5 dışa aktarım örneği ve filtrenin kapsamı için [Dışa Aktarım Sırasında JavaScript Hiperlinklerini Hariç Tutma](/slides/tr/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) bölümüne bakın. Bu ayar, HTML5 görüntüleyicisinin navigasyon ve animasyonlar için kullandığı JavaScript'i kaldırmaz.