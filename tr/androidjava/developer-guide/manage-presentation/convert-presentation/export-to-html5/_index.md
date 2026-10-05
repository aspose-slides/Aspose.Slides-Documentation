---
title: Android'de Sunumları HTML5'e Dönüştürme
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını, Android için Aspose.Slides ile Java aracılığıyla duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşim korunur."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarını HTML5'e dönüştürmeyi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ve yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmasının SVG tabanlı çıktısıyla karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek animasyon çalımını açıkça kontrol etmeyi gösterir. Girdi yolunu kendi sunumunuzun yolu ile değiştirin.

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
HTML belgesinin yanında dışa aktarma, slayt stillendirme, animasyonlar, efektler ve gezinme için destekleyici CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayımlarken bu dosyaları HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js dosyalarını ortak CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonlarını veya slayt geçişlerini oynatmamak için `false` değerini [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) yöntemlerine, [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) içinde aktarın. Bu ayarlar bağımsızdır; birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türünün de devre dışı bırakıldığı bir sayfa üretir.

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

## **PowerPoint'i HTML'e Dışa Aktarma**

Standart HTML dışa aktarma farklı bir işleme yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu işleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Aşağıdaki basitleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi render edilmiş slayt içeriğini barındırır; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarma çıktısı değildir.

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
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı HTML öğeleri olarak göstermez. Bu makalede gösterilen şekil‑animasyonu ve slayt‑geçişi seçeneklerine ihtiyaç duyduğunuzda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktarma**

HTML5 dışa aktarma, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdaki efektleri oynatabilmesi için hem [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) hem de [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) seçeneklerini etkinleştirir.

Şekil animasyonları ve slayt geçişleri zaten bulunan bir sunumu kullanarak bu ayarların etkisini görebilirsiniz. Bu seçeneklerin etkinleştirilmesi, içinde hiç animasyon bulunmayan slaytlara yeni efekt eklemez. Dışa aktarma sonrası, destekleyici dosyaları mevcut olduğunda tarayıcıda oluşturulan HTML5 belgesini açın.

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

## **Sunumu Yorumlarla Birlikte HTML5 Belgesine Dönüştürme**

Mevcut slayt yorumlarını HTML5 çıktısına dahil edebilir, okuyucuların yorumları slayt içeriğinin yanında görmesini sağlayabilirsiniz. Bu bölümdeki örnek, kaynak sunumun yorum içerdiğini varsayar; aşağıda gösterildiği gibi. Yorumları dışa aktarır; yeni yorum oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) nesnesini, [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) sınıfının [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yöntemine aktarın. [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) metodunu kullanarak [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) sınıfından `Right` değerini seçin ve yorumları her slaydın sağ tarafına yerleştirin.

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorum içermeyen bir sunumda görüntülenecek yorum metni olmayacaktır.

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

Aşağıdaki resim, yorumların slayt yanına yerleştirildiği dışa aktarılmış HTML5 belgesini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarma Sırasında JavaScript Bağlantılarını Hariç Tutma**

`hyperlinks.pptx` dosyasının içinde `javascript:alert('Hello')` hedefli bir bağlantı metni ve normal bir `https://example.com/` bağlantısı olduğunu varsayalım. JavaScript bağlantısını dışa aktarırken hariç tutmak için [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) yöntemine `true` değerini aktarın. Varsayılan değer `false` olduğundan bu bağlantılar, seçeneği etkinleştirmediğiniz sürece filtrelenmez.

Aşağıdaki örnek, çalışma dizininden sunumu yükler ve [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) kullanarak dışa aktarır:

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

Dışa aktarılan dosya, JavaScript bağlantısını metniyle birlikte korurken normal HTTPS bağlantısını tutar. Kaynak sunum değişmeden kalır.

Bu seçenek JavaScript bağlantılarını filtreler; tüm betikleri veya diğer aktif içeriği kaldırmaz, ayrıca CSP uyumluluğu garantilemez. Örneğin, HTML5 çıktısı hâlâ slayt gezinmesi ve animasyonları için betikler içerir.

## **SSS**

**HTML5 içinde nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarma, [şekil animasyonlarını](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slayt geçişlerini](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) ayrı ayrı etkinleştirme veya devre dışı bırakma seçenekleri sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve [düzen ayarları](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin slaydın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ayarı, kaydetme sırasında JavaScript çağıran bağlantıları atlamanızı sağlar. Varsayılan değer `false`dır. Örnek ve filtre kapsamı için **[Exclude JavaScript Hyperlinks During Export](/slides/tr/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export)** bölümüne bakın. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.