---
title: Python aracılığıyla Java ile Not Sayfası Boyutunu ve Yönünü Değiştir
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/python-java/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları veya el ilanlarını PDF ve görüntülere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getNotesSize) kullanın. Bu, sayfa boyutlarını ayarlayan [setSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notessize/#setSize) metoduna sahip bir [NotesSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notessize/) nesnesi döndürür. Ayar nesnesi değiştirilemese de, bu metod aracılığıyla yeni boyutlar atayabilirsiniz.

Genişlik ve yükseklik **nokta** cinsinden belirtilir; bir inçte 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar, bireysel bir slaytın notlarından ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getNotesSize) | Not sayfası boyutlarını ve el ilanı dışa aktarımı için kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlideSize) | Normal sunum slaytı boyutlarını [SlideSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/) aracılığıyla kontrol eder. |

Her iki ayarın değiştirilmesi diğerini otomatik olarak değiştirmez. Not sayfası yönünün değiştirilmesi normal slaytları da döndürmez. Normal slaytların boyutlandırılması için [Slide Size](/slides/tr/python-java/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarım örnekleri için konuşmacı notları içeren en az bir slaytı olan bir sunum kullanın. Her örnek bağımsız olarak çalıştırılabilir.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişlik ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay, daha uzun bir sayfa dikey, eşit boyutlar kare sayfa tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan gerçek boyutları nokta cinsinden yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Kağıt Boyutunu Değiştirmeden Yatay Hale Geçiş**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği birbirleriyle değiştirin. Bu, özel bir kağıt boyutu dahil olmak üzere her iki kenarın uzunluğunu korur. Aşağıdaki koşul, zaten yatay olan bir sayfanın tekrar dikeye çevrilmesini önler ve kare bir sayfayı değiştirmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dikey yön için, `size.getWidth() > size.getHeight()` olduğunda aynı atamayı kullanın. Kağıt boyutunu da değiştirmek istemediğiniz sürece A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutu Ayarlama ve Doğrulama**

İki boyutu birlikte atayın, ardından sunumu kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) kullanın. Bu örnek, 900 × 600 noktalık bir yatay sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı yeniden açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Beklenen sonuç `900.0 x 600.0 points` ve `Size preserved: True` dır. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içindeki ayarları değil, kaydedilen dosyayı da doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için kullanılabilir alanı tanımlar. Tek başına bu düzenleri etkinleştirmezler; dışa aktarım seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı, slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG'ye Dışa Aktarma**

PDF'de notları dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) öğesini [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)'a atayın. Bu örnek ayrıca, ilk slaytı notlarıyla birlikte PNG'ye render etmek için [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ve [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/) kullanır.

[BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/) modu notları tek bir sayfada tutar; sığmayan notlar kesilebilir. PDF, 900 × 600 noktalık sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; boyutlar ayrıca render ölçeğine bağlıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Uzun notlarla PDF dışa aktarımı için [BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/) gerektiğinde ek sayfalara izin verir. Yukarıdaki tek slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Yeniden boyutlandırdıktan sonra, kesilmiş notlar ve mevcut notes-master nesnelerinin yerleşimi için çıktıyı inceleyin; sadece sayfa boyutlarını değiştirmek, tüm içeriğin sığacağı garantisi olarak görülmemelidir. Not dışa aktarımı hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/python-java/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF'ye Dışa Aktarma**

Tek bir sayfada birden çok slayt minik görüntüsü için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek 900 × 600 noktalık bir sayfa ayarlar ve sayfa başına dört slayta kadar düzenlemek için [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handouttype/) kullanır. Yatay ön ayar slayt sıralamasını kontrol eder; sayfa yönü genişlik ve yüksekliğinden elde edilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Sayfa boyutunu değiştirmek, kaynak slaytların boyutunu değiştirmeden el ilanı ızgarası için kullanılabilir alanı değiştirir. El ilanı görüntüleri için, tek bir slaytın görüntü metodunu değil, el ilanı düzeniyle birlikte [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) kullanın. Aspose.Slides'ta, sunum düzeyinde el ilanı renderi not sayfası boyutlarını kullanırken, tek slayt görüntü çağrısı el ilanı sayfası üretmez. Düzen seçenekleri için [Handout Mode](/slides/tr/python-java/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Baskıda Sayfa Boyutu**

Kaydedilen sunum boyutu, dışa aktarılan sayfa boyutu ve yazdırılan kağıt boyutu birbirinden ayrı tutulmalıdır:

- **Presentation viewers:** Bir görüntüleyici, notları kendi düzen kurallarını kullanarak görüntüleyebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, yeniden açın ve boyutları tekrar kontrol edin; o uygulamanın format dönüşümü bunları normalleştirebilir.
- **Export formats:** Yukarıdaki not ve el ilanı PDF örnekleri yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tam sayı piksel boyutları ve bir render ölçeği kullanır, bu nedenle kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Printer drivers:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF'de depolanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarıyla eşleşin ve baskı önizlemesini inceleyin.

## **SSS**

**Tek bir slayt için not boyutunu ayarlayabilir miyim?**

Not sayfası boyutu, sunum düzeyinde bir ayardır. Tek tek slaytların farklı not içeriği olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Neden not yönünü değiştirmek slaytlarımı etkilemedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde normal slayt boyutu ayarlarını kullanın.

**Kaydedilen veya yazdırılan sonucum farklı bir boyutta neden?**

Önce kaydedilen sunumu yeniden açın ve not boyutlarını karşılaştırın. Eğer değişmişse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirip değiştirmediğini kontrol edin. Değişmediyse, dışa aktarım düzenini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimlerini kontrol edin.