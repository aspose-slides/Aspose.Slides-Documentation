---
title: JavaScript ile Sunumları HTML5'e Dönüştür
linktitle: Sunumdan HTML5'e
type: docs
weight: 40
url: /tr/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı ve şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünüm modunda HTML5 çıktısı oluşturmayı açıklar ve dışa aktarılan belgede yorumları yerleşimlerini yapılandırarak nasıl ekleyeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu JavaScript kodu, bir sunumu web uzantıları ve bağımlılıklar olmadan HTML5'e nasıl dışa aktaracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Bu durumda temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları bu şekilde belirtebilirsiniz:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint'i HTML'e Dışa Aktar**

Bu JavaScript, standart PowerPoint‑to‑HTML sürecini gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu durumda, sunum içeriği SVG aracılığıyla şu şekilde render edilir:

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
Bu yöntemi PowerPoint'i HTML'e dışa aktarmak için kullandığınızda, SVG render edilmesi nedeniyle stilleri uygulayamayacak veya belirli öğeleri animasyonlayamayacaksınız. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktar**

**Aspose.Slides**, bir PowerPoint sunumunu slaytların slayt görünümü modunda sunulduğu bir HTML5 belgesine dönüştürmenizi sağlar. Bu durumda, oluşan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu bir web sayfasında slayt görünüm modunda görürsünüz. 

Bu JavaScript kodu PowerPoint'ten HTML5 Slayt Görünümü dışa aktarım sürecini gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yorumlarla Birlikte PowerPoint Sunumunu HTML5 Belgesine Dönüştür**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına notlar veya geri bildirim bırakmalarını sağlayan bir araçtır. Özellikle birden çok kişinin ana içeriği değiştirmeden belirli slayt elemanlarına öneri veya görüş ekleyebildiği ortak çalışma projelerinde çok faydalıdır. Her yorum, yazarın adını gösterir ve bu sayede yorumu kimin bıraktığını takip etmek kolaylaşır.

Örneğin, "sample.pptx" dosyasında aşağıdaki PowerPoint sunumunun kaydedildiğini varsayalım.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, çıktıda yorumların dahil edilip edilmeyeceğini kolayca belirtebilirsiniz. Bunu yapmak için, yorumların gösterim parametrelerini `notes_comments_layouting` özelliği ile [Html5Options](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/) sınıfında belirtmeniz gerekir.

Aşağıdaki kod örneği, bir sunumu slaytların sağ tarafında yorumlar görüntülenecek şekilde HTML5 belgesine dönüştürür.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

`output.html` belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [shape animations](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/setanimateshapes/) ve [slide transitions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/setanimatetransitions/) özelliklerini etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

**Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilirler?**

Evet, yorumlar HTML5'te eklenebilir ve (örneğin slaytın sağ tarafına) [layout settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) aracılığıyla konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [setting](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) vardır. Bu, katı güvenlik politikalarına uyumu kolaylaştırır.