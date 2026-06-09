---
title: Python'da Sunumları HTML5'e Dönüştür
linktitle: HTML5'e Dışa Aktar
type: docs
weight: 40
url: /tr/python-net/export-to-html5/
keywords:
- PowerPoint'ten HTML5'e
- OpenDocument'ten HTML5'e
- sunumdan HTML5'e
- slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'ten HTML5'e
- ODP'den HTML5'e
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- HTML5 dışa aktarımı
- sunumu dışa aktar
- slaytı dışa aktar
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını, .NET üzerinden Python için Aspose.Slides ile duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarımını, şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarım sürecini gösterir, slayt görünüm modunda HTML5 çıktısı oluşturmayı açıklar ve dışa aktarılan belgede yorumları düzenleyerek nasıl dahil edileceğini gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu python kodu, web uzantıları ve bağımlılıklar olmadan bir sunumu HTML5'e nasıl dışa aktaracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
Bu durumda temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları şu şekilde belirtebilirsiniz:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **PowerPoint'i HTML'e Dışa Aktar**

Bu python kodu, standart PowerPoint‑to‑HTML sürecini gösterir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

Bu durumda, sunum içeriği aşağıdaki gibi bir biçimde SVG aracılığıyla işlenir:

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
Bu yöntemi kullanarak PowerPoint'i HTML'e dışa aktardığınızda, SVG işleme nedeniyle stil uygulayamaz veya belirli öğeleri canlandıramazsınız. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktar**

**Aspose.Slides**, slaytların slayt görünüm modunda sunulduğu bir HTML5 belgesine PowerPoint sunumunu dönüştürmenizi sağlar. Bu durumda, oluşturulan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu bir web sayfasında slayt görünüm modunda görebilirsiniz. 

Bu Python kodu, PowerPoint'i HTML5 Slayt Görünümü dışa aktarım sürecini gösterir:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Slayt geçişleri, animasyonlar ve şekil animasyonları içeren bir sunumu HTML5'e dışa aktar
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Sunumu kaydet
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Sunumu Yorumlu Bir HTML5 Belgesine Dönüştür**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına not veya geri bildirim bırakmasını sağlayan bir araçtır. Özellikle birden fazla kişinin belirli slayt öğelerine öneri veya açıklama ekleyebildiği işbirlikli projelerde çok faydalıdır; ana içeriği değiştirmeden. Her yorum, yazarın adını gösterdiği için kimin yorum bıraktığını takip etmek kolaydır.

Örneğin aşağıdaki PowerPoint sunumumuz "sample.pptx" dosyasında kaydedilmiştir.

![Sunum slaytında iki yorum](two_comments_pptx.png)

PowerPoint sunumunu bir HTML5 belgesine dönüştürürken, çıktıda yorumların dahil edilip edilmeyeceğini kolayca belirtebilirsiniz. Bunu yapmak için, yorumların görüntüleme parametrelerini `notes_comments_layouting` özelliği aracılığıyla [Html5Options](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/) sınıfında belirtmeniz gerekir.

Aşağıdaki kod örneği, yorumların slaytların sağına yerleştirildiği bir HTML5 belgesine sunumu dönüştürür.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

"Anaçık.html" belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_shapes/) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_transitions/) etkinleştirme veya devre dışı bırakma için ayrı seçenekler sunar.

**Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ile yorumlar için [düzen ayarları](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/notes_comments_layouting/) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/skip_java_script_links/) mevcuttur. Bu, katı güvenlik politikalarına uymaya yardımcı olur.