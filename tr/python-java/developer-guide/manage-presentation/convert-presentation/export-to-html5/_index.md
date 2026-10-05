---
title: Sunumları Python üzerinden Java ile HTML5'e Dönüştür
linktitle: Sunumdan HTML5'e
type: docs
weight: 40
url: /tr/python-java/export-to-html5/
keywords:
- PowerPoint'tan HTML5'e
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimlilik korunur."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides for Python via Java kullanarak HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ve yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmanın SVG tabanlı çıktısıyla karşılaştırır.

Örnekler, Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanını gerektirir. Giriş sunumlarını geçerli çalışma dizinine yerleştirin. Her örnek, JVM zaten çalışıyorsa başlatmaz, sadece çalışmıyorsa başlatır.

## **PowerPoint'i HTML5'e Dışa Aktar**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek, animasyon oynatımını açıkça nasıl kontrol edeceğinizi gösterir. Giriş yolunu kendi sunumunuzun yolu ile değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
HTML belgesinin yanı sıra, dışa aktarma slayt stilizasyonu, animasyonlar, efektler ve navigasyon için destekleyici CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayınlarken bu dosyaları HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt navigasyonu ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonları veya slayt geçişleri çalmadan dışa aktarmak için, [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) ve [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) metodlarına `False` değeri verin [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) içinde. Bu ayarlar birbirinden bağımsızdır, bu yüzden birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türünün de devre dışı bırakıldığı bir sunumu oluşturulan sayfada dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint'i HTML'e Dışa Aktar**

Standart HTML dışa aktarımı farklı bir renderleme yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Aşağıdaki sadeleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi, renderlenmiş slayt içeriğini barındırır; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarma çıktısı değildir.

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
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı ayrı HTML öğeleri olarak ortaya koymaz. Bu makalede gösterilen şekil animasyonu ve slayt geçişi seçeneklerine ihtiyacınız olduğunda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktar**

HTML5 dışa aktarma, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumda bulunan efektleri oynatabilmesi için hem [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) hem de [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) öğelerini etkinleştirir.

Bu ayarların etkisini görmek için zaten şekil animasyonları ve slayt geçişleri içeren bir sunum kullanın. Bunları etkinleştirmek, hiç efekti olmayan slaytlara yeni efekt eklemez. Dışa aktardıktan sonra, destekleyici dosyalar mevcutken oluşturulan HTML5 belgesini bir tarayıcıda açın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Sunumu Yorumlarla Birlikte HTML5 Belgesine Dönüştür**

Mevcut slayt yorumlarını HTML5 çıktısına dahil edebilirsiniz, böylece okuyucular slayt içeriğinin yanında geri bildirimi görebilir. Bu bölümdeki örnek, kaynak sunumun aşağıda gösterildiği gibi yorumlar içermesini bekler. Bu yorumları dışa aktarır; yeni yorum oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

Bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) içinde [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) metoduna geçirin. Yorumları her slaydın sağ tarafına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) enumarasyonundan `Right` seçmek üzere [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) kullanın.

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorum içermeyen bir sunumda gösterilecek yorum metni olmayacaktır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Aşağıdaki görüntü, dışa aktarılan HTML5 belgesinde yorumların slaydın yanında gösterildiğini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Hipermetin Bağlantılarını Hariç Tut**

`hyperlinks.pptx` dosyasının, `javascript:alert('Hello')` hedefli bir bağlantı metni ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. Dışa aktarma sırasında JavaScript bağlantısını hariç tutmak için, [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) metoduna `True` değerini geçirin. Varsayılan değer `False` olduğu için, bu bağlantılar seçeneği etkinleştirildiğinde filtrelenir.

Aşağıdaki örnek, sunumu çalışma dizininden yükler ve [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) kullanarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Dışa aktarılan dosya, JavaScript bağlantısını atlayıp metnini ve normal HTTPS bağlantısını korur. Kaynak sunum değişmeden kalır.

Bu seçenek JavaScript bağlantılarını filtreler; tüm scriptleri veya diğer aktif içerikleri kaldırmaz, ayrıca CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt navigasyonu ve animasyonlar için scriptler içerir.

## **FAQ**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarma, [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) ve [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) ayrı ayrı etkinleştirme veya devre dışı bırakma seçenekleri sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ile yorumlar için [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) aracılığıyla (örneğin slaydın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ayarı, kaydetme sırasında JavaScript çağrısı içeren hiperbağlantıları atlamanıza izin verir. Varsayılan değer `False`'tır. Bir HTML5 dışa aktarma örneği ve filtrenin kapsamı için [Exclude JavaScript Hyperlinks During Export](/slides/tr/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) bölümüne bakın. Bu ayar, HTML5 görüntüleyicide navigasyon ve animasyonlar için kullanılan JavaScript'i kaldırmaz.