---
title: Python aracılığıyla Java üzerinden Sunumları HTML5'e Dönüştür
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/python-java/export-to-html5/
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
- PPT'yi HTML5'e aktar
- PPTX'i HTML5'e aktar
- ODP'yi HTML5'e aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Ek web uzantıları olmadan temel HTML5 dışa aktarmayı, şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünüm modunda HTML5 çıktısı oluşturmayı açıklar ve dışa aktarılan belgede yorumları düzenlerini yapılandırarak nasıl dahil edeceğinizi gösterir.

Örnekler, Python için Java üzerinden Aspose.Slides ve uyumlu bir Java çalışma zamanına ihtiyaç duyar. `pres.pptx` (yorum örneği için `sample.pptx`) dosyasını geçerli çalışma dizinine yerleştirin. Her örnek, JVM zaten çalışıyorsa yeniden başlatmaz.

## **PowerPoint'i HTML5'e Dışa Aktar**

Ek web uzantıları olmadan bir sunumu dışa aktarmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) ile [SaveFormat.Html5](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Html5) kullanın:

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

{{% alert color="info" title="Not" %}} 
HTML5 dışa aktarıcı, tarayıcıda görüntülenebilecek HTML içeriği oluşturur. 
{{% /alert %}}

Dışa aktarmayı yapılandırmak için [Html5Options](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/) kullanın. Şekil animasyonlarını ve slayt geçişlerini devre dışı bırakmak için `False` ile [setAnimateShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateShapes) ve [setAnimateTransitions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateTransitions) çağırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint'i HTML'e Dışa Aktar**

Standart HTML dışa aktarma için [SaveFormat.Html](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Html) kullanın. Daha fazla seçenek için [Convert PowerPoint to HTML](/slides/tr/python-java/convert-powerpoint-to-html/) sayfasına bakın:

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

Bu durumda, sunum içeriği aşağıdaki gibi SVG aracılığıyla işlenir:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Uyarı" color="warning" %}} 
Standart HTML dışa aktarma, slayt içeriğini SVG ile render eder ve HTML5 şekil‑animasyonu ve slayt‑geçişi seçeneklerini sağlamaz. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktar**

**Aspose.Slides**, bir PowerPoint sunumunu slaytların slayt görünümü modunda sunulduğu bir HTML5 belgesine dönüştürmenizi sağlar. Bu dosyayı bir tarayıcıda açtığınızda, web sayfasında sunumu slayt görünümü modunda görürsünüz. 

Bu Python kodu, PowerPoint'ten HTML5 Slayt Görünümü dışa aktarma sürecini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Sunumları Yorumlarla HTML5 Belgelerine Dönüştür**

PowerPoint'teki yorumlar, sunum slaytlarına not veya geri bildirim eklemeyi sağlayan bir araçtır. Özellikle birden fazla kişinin belirli slayt öğelerine öneri veya açıklama ekleyebildiği iş birliği projelerinde çok faydalıdır. Her yorum, yazarın adını gösterir, böylece kimin yorum yaptığını kolayca izleyebilirsiniz.

Aşağıdaki PowerPoint sunumunun "sample.pptx" dosyasında saklandığını varsayalım.

![Sunum slaytında iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürürken, çıktıya yorumları dahil edip etmeyeceğinizi kolayca belirtebilirsiniz. Bunu yapmak için [Html5Options](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/) sınıfının [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) yöntemine yorumların görüntülenme parametrelerini gönderin.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) ve [setCommentsPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) ile [CommentsPositions.Right](https://reference.aspose.com/slides/tr/python-java/aspose.slides/commentspositions/#Right) kullanın. Aşağıdaki kod örneği, yorumların slaytların sağ tarafında gösterildiği bir HTML5 belgesi oluşturur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

"output.html" belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [shape animations](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateShapes) ve [slide transitions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateTransitions) seçeneklerini ayrı ayrı etkinleştirip devre dışı bırakmanıza izin verir.

**Yorumlar dışa aktarılabilir mi ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve [layout settings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) aracılığıyla (örneğin slaytın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [setting](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) vardır. Bu ayar, bu tür hiperlinkleri kaldırır; ancak tüm oluşturulan HTML5 betiklerinin sitenin İçerik Güvenliği Politikası'nı (CSP) karşılayacağını tek başına garanti etmez.