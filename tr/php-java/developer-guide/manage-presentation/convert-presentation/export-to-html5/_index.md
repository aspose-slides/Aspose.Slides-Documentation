---  
title: PHP'de Sunumları HTML5'e Dönüştür  
linktitle: Sunumu HTML5'e  
type: docs  
weight: 40  
url: /tr/php-java/export-to-html5/  
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
- PHP  
- Aspose.Slides  
description: "Aspose.Slides for PHP ile Java üzerinden PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."  
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides kullanarak HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı, ayrıca şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünümü modunda HTML5 çıktısı oluşturmayı açıklar ve yorumların yerleşimini yapılandırarak dışa aktarılan belgede nasıl dahil edileceğini demonstrasyonla gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu PHP kodu, bir sunumu web uzantıları ve bağımlılıklar olmadan HTML5'e nasıl dışa aktaracağınızı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Bu durumda temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları bu şekilde belirtebilirsiniz:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint'i HTML'e Dışa Aktar**

Bu Java kodu standart PowerPoint‑to‑HTML sürecini gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu durumda, sunum içeriği SVG aracılığıyla aşağıdaki gibi işlenir:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

"output.html" belgesi aşağıdaki görselde gösterilmiştir.

![HTML5 çıktısındaki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 ayrı seçenekler sunar ve [şekil animasyonlarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimateshapes/) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimatetransitions/) etkinleştirebilir veya devre dışı bırakabilirsiniz.

**Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [düzen ayarları](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) üzerinden (örneğin slaytın sağında) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) vardır. Bu, katı güvenlik politikalarına uyum sağlamaya yardımcı olur.