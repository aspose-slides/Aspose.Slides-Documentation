---
title: Java'da Sunumları HTML5'e Dönüştür
linktitle: Sunumdan HTML5'e
type: docs
weight: 40
url: /tr/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Java için Aspose.Slides ile duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides kullanarak HTML5'e dönüştürmeyi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı, ayrıca şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünümü modunda HTML5 çıktısı oluşturmayı açıklar ve dışa aktarılan belgede yorumları yerleşimlerini yapılandırarak nasıl ekleyeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu Java kodu bir sunumu web uzantıları ve bağımlılıklar olmadan HTML5'e nasıl dışa aktaracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Bu durumda, temiz HTML elde edersiniz. 
{{% /alert %}}

Bu şekilde şekil animasyonları ve slayt geçişleri için ayarları belirtebilirsiniz:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint'i HTML'ye Dışa Aktar**

Bu Java kodu standart PowerPoint‑to‑HTML sürecini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu durumda, sunum içeriği aşağıdaki gibi bir SVG biçiminde işlenir:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Bu yöntemi PowerPoint'i HTML'ye dışa aktarmak için kullandığınızda, SVG renderlaması nedeniyle belirli öğelere stil uygulayamaz veya animasyon ekleyemezsiniz. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüyle Dışa Aktar**

**Aspose.Slides**, slaytların slayt görünümü modunda sunulduğu bir HTML5 belgesine PowerPoint sunumunu dönüştürmenizi sağlar. Bu durumda, oluşturulan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu bir web sayfasında slayt görünümü modunda görürsünüz. 

Bu Java kodu PowerPoint'i HTML5 Slayt Görünümü dışa aktarma sürecini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumları Yorumlu HTML5 Belgelerine Dönüştürme**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarında not veya geri bildirim bırakmasını sağlayan bir araçtır. Özellikle birden çok kişinin ana içeriği değiştirmeden belirli slayt öğelerine öneri veya açıklama ekleyebildiği işbirlikli projelerde faydalıdır. Her yorum, yazarın adını gösterir, böylece kimin eklediği kolayca izlenebilir.

Örneğin, "sample.pptx" dosyasında aşağıdaki PowerPoint sunumunun bulunduğunu varsayalım.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, çıktıda yorumların dahil edilip edilmeyeceğini kolayca belirtebilirsiniz. Bunu yapmak için yorumların görüntüleme parametrelerini `setSlidesLayoutOptions` metoduna [Html5Options](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/) sınıfı üzerinden geçirin.

Aşağıdaki kod örneği, yorumların slaytların sağına yerleştirildiği bir HTML5 belgesi oluşturur.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" belgesi aşağıdaki görüntüde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

### HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

### Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [yerleşim ayarları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

### Güvenlik veya CSP nedenleriyle JavaScript çağrısı yapan bağlantıları atlayabilir miyim?

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) vardır. Bu, katı güvenlik politikalarına uyum sağlamaya yardımcı olur.