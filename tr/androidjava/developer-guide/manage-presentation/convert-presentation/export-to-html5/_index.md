---
title: Android'de Sunumları HTML5'e Dönüştür
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
description: "PowerPoint ve OpenDocument sunumlarını Java aracılığıyla Android için Aspose.Slides ile duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı ve şekil animasyonları ile slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint'ten HTML'e dışa aktarma sürecini gösterir, slayt görünümü modunda HTML5 çıktısı oluşturmayı açıklar ve yorumların yerleşimini yapılandırarak dışa aktarılan belgede yorumları nasıl dahil edebileceğinizi gösterir.

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
Bu durumda, temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları bu şekilde belirtmek isteyebilirsiniz:

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

Bu Java kodu, standart PowerPoint'ten HTML'e süreci gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu durumda, sunum içeriği aşağıdaki gibi bir SVG aracılığıyla render edilir:

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
Bu yöntemi PowerPoint'i HTML'e dışa aktarmak için kullandığınızda, SVG render'ı nedeniyle stil uygulayamaz veya belirli öğeleri animasyonlayamazsınız. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüyle Dışa Aktar**

**Aspose.Slides**, bir PowerPoint sunumunu slaytların slayt görünümü modunda sunulduğu bir HTML5 belgesine dönüştürmenizi sağlar. Bu durumda, ortaya çıkan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu bir web sayfasında slayt görünümü modunda görürsünüz. 

Bu Java kodu, PowerPoint'ten HTML5 Slayt Görünümü dışa aktarma sürecini gösterir:

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

## **Yorumlarla Bir PowerPoint Sunusunu HTML5 Belgesine Dönüştür**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına not veya geri bildirim bırakmasını sağlayan bir araçtır. Özellikle birden çok kişinin ana içeriği değiştirmeden belirli slayt öğelerine öneri veya not ekleyebildiği iş birliği projelerinde faydalıdır. Her yorum, yazarın adını gösterir, bu da kimin not bıraktığını kolayca takip etmeyi sağlar.

Örneğin, "sample.pptx" dosyasında aşağıdaki PowerPoint sunumunun kaydedildiğini varsayalım.

![Sunum slaytında iki yorum](two_comments_pptx.png)

Bir PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, çıktıda sunum yorumlarını dahil edip etmeyeceğinizi kolayca belirtebilirsiniz. Bunu yapmak için, [Html5Options](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/) sınıfının `getNotesCommentsLayouting` metodunda yorumların görüntüleme parametrelerini belirtmeniz gerekir.

Aşağıdaki kod örneği, yorumların slaytların sağ tarafında gösterildiği bir HTML5 belgesine sunumu dönüştürür.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" belgesi aşağıdaki görüntüde gösterilmiştir.

![HTML5 çıktısındaki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

**Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [yerleşim ayarları](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aracılığıyla (örneğin slaytın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) vardır. Bu, katı güvenlik politikalarına uymaya yardımcı olur.