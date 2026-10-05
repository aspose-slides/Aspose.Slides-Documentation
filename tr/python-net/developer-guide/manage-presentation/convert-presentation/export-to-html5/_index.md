---
title: Python'da Sunumları HTML5'e Dönüştür
linktitle: Sunumdan HTML5'e
type: docs
weight: 40
url: /tr/python-net/export-to-html5/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarını responsive HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarma, şekil animasyonları ve slayt geçişlerinin kontrolü ve yorum düzeni konularını kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmanın SVG tabanlı çıktısı ile karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktar**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; sonraki örnek, animasyon oynatımını açıkça nasıl kontrol edeceğinizi gösterir. Giriş yolunu sunumunuzun yolu ile değiştirin.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Not" %}}
HTML belgesine ek olarak, dışa aktarma slayt stillendirme, animasyonlar, efektler ve gezinme için destekleyici CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayımlarken bu dosyaları HTML belgesiyle birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonları veya slayt geçişleri oynatılmadan dışa aktarmak için, [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) ve [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) ayarlarını [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) içinde `False` olarak ayarlayın. Bu ayarlar bağımsızdır, böylece birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türünün de devre dışı bırakıldığı bir sunumu oluşturulan sayfada dışa aktarır.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **PowerPoint'i HTML'e Dışa Aktar**

Standart HTML dışa aktarma farklı bir renderleme yaklaşımı kullanır: slayt içeriği bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Aşağıdaki basitleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi renderlenen slayt içeriğini içerir; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarma çıktısı değildir.

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
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı HTML öğeleri olarak ortaya çıkarmaz. Bu makalede gösterilen şekil‑animasyonu ve slayt‑geçişi seçeneklerine ihtiyaç duyduğunuzda HTML5 dışa aktarmayı kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktar**

HTML5 dışa aktarma, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdan efektleri oynatabilmesi için hem [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) hem de [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) seçeneklerini etkinleştirir.

Bu ayarların etkisini görmek için zaten şekil animasyonları ve slayt geçişleri içeren bir sunum kullanın. Bunları etkinleştirmek, hiç efekti olmayan slaytlara yeni efekt eklemez. Dışa aktarmadan sonra, oluşturulan HTML5 belgesini destek dosyaları mevcutken bir tarayıcıda açın.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Sunumu Yorumlarla Birlikte HTML5 Belgesine Dönüştür**

Mevcut slayt yorumlarını HTML5 çıktısına dahil ederek okuyucuların yorumları slayt içeriğiyle birlikte görmesini sağlayabilirsiniz. Bu bölümdaki örnek, kaynak sunumda aşağıda gösterildiği gibi yorumların bulunmasını bekler. Yorumları dışa aktarır; yeni yorumlar oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

Bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) sınıfının [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) özelliğine atayın. Yorumları her slaydın sağına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) enum'ından `RIGHT` değerine sahip [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) ayarlayın.

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorumları olmayan bir sunumda görüntülenecek yorum metni bulunmaz.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![HTML5 çıktısındaki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Bağlantılarını Hariç Tut**

`hyperlinks.pptx` dosyasının `javascript:alert('Hello')` hedefli bir bağlanmış metin ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. Dışa aktarım sırasında JavaScript bağlantısını hariç tutmak için [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) ayarını `True` olarak ayarlayın. Varsayılan değer `False` olduğundan, bu bağlantılar seçenek etkinleştirilmedikçe filtrelenmez.

Aşağıdaki örnek, sunumu çalışma dizininden yükler ve [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) kullanarak dışa aktarır:

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Dışa aktarılan dosya, JavaScript bağlantısını metni ve normal HTTPS bağlantısını koruyarak dışarı çıkar. Kaynak sunum değişmeden kalır.

Bu seçenek JavaScript bağlantılarını filtreler; tüm betikleri veya diğer aktif içerikleri kaldırmaz, ayrıca CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt gezinmesi ve animasyonlar için betikler içerir.

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarma, [şekil animasyonları](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) ve [slayt geçişleri](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) seçeneklerini ayrı ayrı etkinleştirmenize veya devre dışı bırakmanıza imkan tanır.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ve yorumlar için [düzen ayarları](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) ayarı, kaydetme sırasında JavaScript çağrısı içeren bağlantıları atlamanızı sağlar. Varsayılan değer `False`'tır. Bir HTML5 dışa aktarma örneği ve filtrenin kapsamı için [JavaScript Bağlantılarını Dışa Aktarım Sırasında Hariç Tut](/slides/tr/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) bölümüne bakın. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.