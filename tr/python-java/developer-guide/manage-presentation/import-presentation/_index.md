---
title: PDF veya HTML'den Sunumları Python ile Java Üzerinden İçe Aktarma
linktitle: Sunum İçe Aktar
type: docs
weight: 60
url: /tr/python-java/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
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
description: "Aspose.Slides kullanarak PDF ve HTML içeriğini Python ile Java üzerinden PowerPoint sunumlarına nasıl içe aktaracağınızı ve sonuçları PPTX dosyaları olarak nasıl kaydedeceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan PDF sayfalarını veya HTML içeriğini PowerPoint slaytlarına dönüştürebilir. [SlideCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/) sınıfı, içe aktarılan içeriği bir sunuma eklemek için [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) ve [addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromHtml) sağlar.

HTML yerleşimi üzerinde daha fazla kontrol için, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) oluşturulan slaytları bir koleksiyon indeksine ekleyebilir veya mevcut bir slaytta kullanılabilir boşluğu doldurmaya başlayabilir. Uzun HTML otomatik olarak ek slaytlara bölünür, kaynak bir dizge ya da akış olarak sağlanabilir ve harici varlıklar bir temel URI ile birlikte [ExternalResourceResolver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/externalresourceresolver/) aracılığıyla yüklenebilir. Döndürülen [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) dizisi etkilenen ve yeni oluşturulan slaytları tanımlar.

## **PDF'den İçe Aktarma**

Bir PDF belgesini PowerPoint sunumuna dönüştürmek için içeriğini slayt koleksiyonuna aktarın ve sonucu PPTX dosyası olarak kaydedin.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.  
2. PDF dosyasının yolunu belirterek [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) metodunu çağırın.  
3. Sunumu PPTX dosyasına yazmak için [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile kullanın.

Aşağıdaki Python örneği bir PDF belgesini içe aktarır ve oluşturulan slaytları PowerPoint sunumu olarak kaydeder:

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

İçe aktarma slayt eklediği için varsayılan boş slayt sunumda kalır. Yalnızca içe aktarılan sayfaları tutmak istiyorsanız, içe aktarmadan önce [SlideCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#clear) ile slayt koleksiyonunu temizleyin.

[addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) yöntemi eklediği slaytları döndürür; bu, yalnızca içe aktarılan slaytları işlemek istediğinizde faydalıdır.

{{% alert title="İpucu" color="success" %}}
Bu dönüşüm akışını denemek için ücretsiz [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasını kullanın.
{{% /alert %}}

## **HTML'den İçe Aktarma**

Aspose.Slides, bir HTML belgesinden de slayt oluşturabilir. Kaynak HTML metni ya da bir akış olarak sağlanabilir. Aşağıdaki adımlar bir dosya akışı kullanır:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.  
2. HTML dosyasını okuma modunda açın ve akışı [addFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromHtml) metoduna geçirin.  
3. Sonucu PPTX dosyasına yazmak için [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile kullanın.

Aşağıdaki Python örneği bir HTML belgesini içe aktarır ve oluşturulan slaytları PowerPoint sunumu olarak kaydeder:

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

HTML‑tarafından oluşturulan slaytların eklenmesi yerine belirli bir konuma yerleştirilmesi gerektiğinde [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) kullanılmalıdır. İndeks sıfır‑tabanlıdır ve içe aktarmanın başladığı konumu gösterir.

`useSlideWithIndexAsStart` bağımsız değişkeni, içe aktarıcının bu konumu nasıl kullanacağını belirler:

- `False` olduğunda, içe aktarıcı belirtilen indekste yeni slaytlar oluşturur ve sonrasındaki slaytları kaydırır.  
- `True` olduğunda, içe aktarıcı mevcut slayttaki boş alanı doldurmaya başlar. HTML sığmazsa, Aspose.Slides otomatik olarak sayfalar ve başlangıç slaytının hemen ardından ek slaytlar ekler.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#insertFromHtml) bir [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnesi dizisi döndürür. Ekleme yeni slaytlarda başlarsa, döndürülen her öğe yenidir. Başlangıçta mevcut bir slayt kullanılırsa, dizi önce o slaytı, ardından ortaya çıkan taşma slaytlarını içerir. Bu diziyi inceleyerek, sunumun slayt sayısından etkilenen aralığı hesaplamanıza gerek kalmaz.

### **Yeni Slaytlar Olarak HTML Ekleme**

Aşağıdaki örnek HTMLʼi bir dizge olarak verir ve oluşturulan slaytları koleksiyon indeksi `1`‑de ekler. `False` geçilmesi, mevcut slaytları kaydırarak yer açar, ancak içeriği değiştirmez.

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

### **Mevcut Bir Slaytta Başlatma**

Sonraki örnek HTMLʼi bir akış olarak sağlar. Mevcut şablon slaydındaki bir başlık şekli korunur, içe aktarma doldurulmuş alanın altından başlar ve uzun gövde yeni slaytlara devam eder.

HTML ayrıca göreceli bir resim URLʼsi içerir. Bir [ExternalResourceResolver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/externalresourceresolver/) bu kaynağı alırken, temel URI içe aktarıcıya `images/logo.png` adresinin nasıl çözüleceğini söyler. Bu örnekte dosyanın `html-assets/images/logo.png` konumunda bulunması beklenir.

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

{{% alert title="Uyarı" color="warning" %}}
Kısıtlaması olmayan bir harici kaynak çözücüsü, HTML tarafından başvurulan yerel veya ağ kaynaklarını okuyabilir. Güvenilmeyen girişler için, HTMLʼi içe aktarmadan önce kaynak URLʼlerini izin verilen şema, dizin ve ana bilgisayar listesine karşı doğrulayın ve temizleyin.
{{% /alert %}}

## **SSS**

**Aspose.Slides PDF içe aktarırken tabloları algılayabilir mi?**

Evet. Bir [PdfImportOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfimportoptions/) nesnesi oluşturun, `True` ile [setDetectTables](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfimportoptions/#setDetectTables) metodunu çağırın ve seçenekleri [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf) metoduna geçirin. Tablo tanıma kalitesi, kaynak PDFʼnin yapısına ve karmaşıklığına bağlıdır.

{{% alert title="Not" color="info" %}}
HTML içe aktardıktan sonra slaytları [images](/slides/tr/python-java/convert-powerpoint-to-png/), [TIFF](/slides/tr/python-java/convert-powerpoint-to-tiff/), veya [SVG](/slides/tr/python-java/render-slide-as-svg/) formatlarına da dışa aktarabilirsiniz.
{{% /alert %}}