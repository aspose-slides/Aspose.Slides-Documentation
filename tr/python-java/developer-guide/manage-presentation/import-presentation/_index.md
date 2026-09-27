---
title: Python üzerinden Java ile PDF veya HTML'den Sunumları İçe Aktarma
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/python-java/import-presentation/
keywords:
- sunumu içe aktar
- slaytı içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak PDF ve HTML içeriğini Python üzerinden Java ile PowerPoint sunumlarına nasıl içe aktaracağınızı ve sonuçları PPTX dosyaları olarak nasıl kaydedeceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan PDF sayfalarını veya HTML içeriğini PowerPoint slaytlarına dönüştürebilir. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) sınıfı, içe aktarılan içeriği bir sunuma eklemek için [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) ve [addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromHtml) sağlar.

HTML yerleşimi üzerinde daha fazla kontrol için, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) oluşturulan slaytları bir koleksiyon indeksine ekleyebilir veya mevcut bir slaytta kullanılabilir alanı doldurmaya başlayabilir. Uzun HTML otomatik olarak ek slaytlara bölünür, kaynak bir dize veya akış olarak sağlanabilir ve dış kaynaklar bir temel URI ile birlikte [ExternalResourceResolver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/externalresourceresolver/) üzerinden yüklenebilir. Döndürülen [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) dizisi, etkilenen ve yeni oluşturulan slaytları tanımlar.

## **PDF'ten İçeri Aktarma**

Bir PDF belgesini PowerPoint sunumuna dönüştürmek için, içeriğini slayt koleksiyonuna içe aktarın ve sonucu bir PPTX dosyası olarak kaydedin.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.
2. PDF dosyasının yolunu sağlayarak [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) metodunu çağırın.
3. Sunumu bir PPTX dosyasına yazmak için [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile çağırın.

Aşağıdaki Python örneği bir PDF belgesini içe aktarır ve oluşturulan slaytları bir PowerPoint sunumu olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İçe aktarma slaytları eklediği için varsayılan boş slayt sunumda kalır. Yalnızca içe aktarılan sayfaları tutmak istiyorsanız, içe aktarmadan önce slayt koleksiyonunu [SlideCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#clear) ile temizleyin.

[addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) yöntemi eklediği slaytları döndürür; bu, yalnızca içe aktarılan slaytları işlemeniz gerektiğinde kullanışlıdır.

{{% alert title="Tip" color="success" %}}
Ücretsiz [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasını deneyerek bu dönüşüm iş akışını canlı olarak görebilirsiniz.
{{% /alert %}}

## **HTML'den İçeri Aktarma**

Aspose.Slides, bir HTML belgesinden de slaytlar oluşturabilir. Kaynak HTML metni ya da bir akış olarak sağlanabilir. Aşağıdaki adımlar bir dosya akışı kullanır:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.
2. HTML dosyasını okuma kipinde açın ve akışı [addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromHtml) metoduna iletin.
3. Sonucu bir PPTX dosyasına yazmak için [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile çağırın.

Aşağıdaki Python örneği bir HTML belgesini içe aktarır ve oluşturulan slaytları bir PowerPoint sunumu olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML İçeriği Ekleme**

HTML tarafından oluşturulan slaytların eklenmek yerine belirli bir konuma yerleştirilmesi gerektiğinde [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) kullanın. İndeks sıfır tabanlıdır ve içe aktarmanın başlayacağı konumu belirler.

`useSlideWithIndexAsStart` argümanı, içe aktarıcının bu konumu nasıl kullanacağını denetler:

- `False` olduğunda, içe aktarıcı belirtilen indeksde yeni slaytlar oluşturur ve sonrasındaki slaytları kaydırır.
- `True` olduğunda, içe aktarıcı mevcut slayttaki kullanılabilir alanda içeriği yerleştirmeye başlar. HTML sığmazsa, Aspose.Slides bunu otomatik olarak bölerek başlangıç slaytının hemen sonrasına ek slaytlar ekler.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) bir [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnesi dizisi döndürür. Ekleme yeni slaytlarda başlarsa, döndürülen her öğe yeni oluşturulmuş olur. Mevcut bir slayt başlangıç olarak kullanılırsa, dizi önce o etkilenen slaytı ve ardından yeni taşma slaytlarını içerir. Bu diziyi inceleyerek, sunumun slayt sayısından etkilenmiş aralığı hesaplamaktan kaçınabilirsiniz.

### **HTML'yi Yeni Slaytlara Ekle**

Aşağıdaki örnek HTML'yi bir dize olarak sağlar ve oluşturulan slaytları koleksiyon indeksi `1`'de ekler. `False` geçmek, mevcut slaytları yer değiştirmeden bırakır; sadece boşluk açmak için kaydırma yapılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Varolan Bir Slaytta Başlat**

Sonraki örnek HTML'yi bir akış üzerinden sağlar. Mevcut şablon slaytındaki bir başlık şekli korunur, içe aktarım dolu alanın altından başlar ve uzun gövde yeni slaytlara devam eder.

HTML ayrıca göreli bir resim URL'si içerir. [ExternalResourceResolver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/externalresourceresolver/) kaynağı elde ederken, temel URI içe aktarıcıya `images/logo.png` öğesinin nasıl çözüleceğini söyler. Bu örnekte dosyanın `html-assets/images/logo.png` konumunda bulunması beklenir.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Sınırsız bir dış kaynak çözücüsü, HTML tarafından referans verilen yerel veya ağ kaynaklarını okuyabilir. Güvenilmeyen girişler için, içe aktarmadan önce kaynak URL'lerini izin verilen şema, dizin ve ana bilgisayarların bir allowlist'iyle doğrulayın ve temizleyin.
{{% /alert %}}

## **SSS**

**Aspose.Slides PDF içe aktarırken tabloları algılayabilir mi?**

Evet. Bir [PdfImportOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfimportoptions/) nesnesi oluşturun, `True` ile [setDetectTables](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfimportoptions/#setDetectTables) metodunu çağırın ve seçenekleri [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) metoduna aktarın. Tablo tanıma kalitesi, kaynak PDF'nin yapısına ve karmaşıklığına bağlıdır.

{{% alert title="Note" color="info" %}}
HTML'yi içe aktardıktan sonra slaytları [images](/slides/tr/python-java/convert-powerpoint-to-png/), [TIFF](/slides/tr/python-java/convert-powerpoint-to-tiff/) veya [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) formatlarına da dışa aktarabilirsiniz.
{{% /alert %}}