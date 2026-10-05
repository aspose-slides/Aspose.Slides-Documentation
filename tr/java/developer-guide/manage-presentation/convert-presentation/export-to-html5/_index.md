---
title: Java'da Sunumları HTML5'e Dönüştür
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/java/export-to-html5/
keywords:
- PowerPoint'ten HTML5'e
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirmeyi, animasyonları ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarımı, şekil animasyonları ve slayt geçişlerinin kontrolünü ve yorum düzenini kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarımının SVG tabanlı çıktısıyla karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktar**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 biçiminde kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek animasyon oynatımını açıkça kontrol etmeyi gösterir. Girdi yolunu kendi sunumunuzun yolu ile değiştirin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
HTML belgesinin yanı sıra, dışa aktarma slayt stillendirmesi, animasyonlar, efektler ve gezinme için destekleyici CSS ve JavaScript dosyaları yazar. Bu dosyaları, çıktıyı taşırken veya yayınlarken HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonlarını veya slayt geçişlerini oynatmadan dışa aktarmak için, [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) içindeki [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) metodlarına `false` geçirin. Bu ayarlar bağımsızdır, bu yüzden birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, oluşturulan sayfada her iki animasyon türü de devre dışı bırakılarak sunumu dışa aktarır.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i HTML'e Dışa Aktar**

Standart HTML dışa aktarımı farklı bir render yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu render yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Aşağıdaki sadeleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi render edilmiş slayt içeriğini barındırır; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarım çıktısı değildir.

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
SVG tabanlı dışa aktarım, PowerPoint şekillerini ayrı HTML öğeleri olarak ortaya çıkmaz. Bu makalede gösterilen şekil‑animasyonu ve slayt‑geçişi seçeneklerine ihtiyacınız varsa HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktar**

HTML5 dışa aktarım, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa oluşturur. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdaki efektleri oynatabilmesi için [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) her ikisini de etkinleştirir.

Zaten şekil animasyonları ve slayt geçişleri içeren bir sunum kullanarak bu ayarların etkisini görebilirsiniz. Bu ayarları etkinleştirmek, hiç animasyonu olmayan slaytlara yeni efekt eklemez. Dışa aktardıktan sonra, destek dosyalarının mevcut olduğu bir tarayıcıda oluşturulan HTML5 belgesini açın.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Sunumu Yorumlarla Birlikte HTML5 Belgesine Dönüştür**

Mevcut slayt yorumlarını HTML5 çıktısına dahil edebilir, böylece okuyucular slayt içeriğinin yanındaki geri bildirimi görebilir. Bu bölümdeki örnek, kaynak sunumun aşağıda gösterildiği gibi yorumlar içerdiğini varsayar. Yorumları dışa aktarır; yeni yorum oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) nesnesini, [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) üzerindeki [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metoduna aktarın. Yorumları her slaydın sağ tarafına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) enum'undan `Right` seçmek üzere [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) metodunu kullanın.

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorumları olmayan bir sunumda görüntülenecek yorum metni olmaz.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Aşağıdaki resim, dışa aktarılan HTML5 belgesinde yorumların slayt yanında gösterildiğini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Bağlantılarını Hariç Tut**

`hyperlinks.pptx` dosyasının `javascript:alert('Hello')` hedefli bir bağlantılı metin ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. JavaScript bağlantısını dışa aktarma sırasında hariç tutmak için, [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) metoduna `true` geçirin. Varsayılan değer `false` olduğu için bu bağlantılar seçenek etkinleştirilmedikçe filtrelenmez.

Aşağıdaki örnek, çalışma dizininden sunumu yükler ve [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) kullanarak dışa aktarır:

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Dışa aktarılan dosya, JavaScript bağlantısını atlayarak metnini ve normal HTTPS bağlantısını korur. Kaynak sunum değişmeden kalır.

Bu seçenek JavaScript bağlantılarını filtreler; tüm betikleri veya diğer aktif içeriği kaldırmaz, ayrıca CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt gezinmesi ve animasyonları için gerekli betikleri içerir.

## **SSS**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarım, [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) seçeneklerini ayrı ayrı etkinleştirip devre dışı bırakmanıza olanak tanır.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ve yorumlar için [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin, slaytın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript tetikleyen bağlantıları atlayabilir miyim?**

Evet, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ayarı, kaydetme sırasında JavaScript çağrısı içeren bağlantıları atlamanızı sağlar. Varsayılan değer `false`. Bu ayarın kapsamı ve örnekleri için [Exclude JavaScript Hyperlinks During Export](/slides/tr/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) bölümüne bakın. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.