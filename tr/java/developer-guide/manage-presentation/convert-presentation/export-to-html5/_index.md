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
- PPTX'den HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı ve şekil animasyonları ile slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünüm modunda HTML5 çıktısı nasıl oluşturulacağını açıklar ve dışa aktarılan belgede yorumları düzenlerini yapılandırarak nasıl ekleyeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu Java kodu, bir sunumu web uzantıları ve bağımlılıklar olmadan HTML5'e nasıl dışa aktaracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Bu durumda temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları bu şekilde belirlemek isteyebilirsiniz:

```java
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

## **PowerPoint'i HTML'e Dışa Aktar**

Bu Java, standart PowerPoint‑to‑HTML sürecini gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu durumda, sunum içeriği aşağıdaki gibi bir biçimde SVG aracılığıyla render edilir:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Not" color="warning" %}} 
Bu yöntemi kullanarak PowerPoint'i HTML'e dışa aktardığınızda, SVG render'ı nedeniyle stil uygulayamaz veya belirli öğeleri animasyonla hareket ettiremezsiniz. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktar**

**Aspose.Slides**, slaytların slayt görünüm modunda sunulduğu bir HTML5 belgesine PowerPoint sunumunu dönüştürmenizi sağlar. Bu durumda, oluşturulan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu web sayfasında slayt görünüm modunda görürsünüz.

Bu Java kodu, PowerPoint'ten HTML5 Slayt Görünümü dışa aktarım sürecini gösterir:

```java
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

## **Sunumları Yorumlarla HTML5 Belgelere Dönüştür**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına notlar veya geri bildirim bırakmasına olanak tanıyan bir araçtır. Özellikle birden fazla kişinin ana içeriği değiştirmeden belirli slayt öğelerine öneri veya not ekleyebildiği işbirlikli projelerde faydalıdır. Her yorum, yazarın adını gösterir, böylece yorumu kimin bıraktığını takip etmek kolaylaşır.

Diyelim ki aşağıdaki PowerPoint sunumu "sample.pptx" dosyasında kaydedilmiş.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, yorumların çıktı belgesine dahil edilip edilmeyeceğini kolayca belirtebilirsiniz. Bunu yapmak için, yorumların görüntüleme parametrelerini [Html5Options](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/) sınıfının `getNotesCommentsLayouting` metodunda belirtmeniz gerekir.

Aşağıdaki kod örneği, sunumu slaytların sağ tarafında yorumlar gösterilecek şekilde bir HTML5 belgesine dönüştürür.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [shape animations](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slide transitions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

**Yorum çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [layout settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin slaytın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağrısı yapan bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [setting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) vardır. Bu, katı güvenlik politikalarına uymaya yardımcı olur.