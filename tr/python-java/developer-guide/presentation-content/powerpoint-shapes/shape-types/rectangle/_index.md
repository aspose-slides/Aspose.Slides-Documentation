---
title: Java aracılığıyla Python’da Sunumlara Dikdörtgen Ekleme
linktitle: Dikdörtgen
type: docs
weight: 80
url: /tr/python-java/rectangle/
keywords:
- dikdörtgen ekle
- dikdörtgen oluştur
- dikdörtgen şekli
- basit dikdörtgen
- biçimlendirilmiş dikdörtgen
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile dikdörtgen ekleyerek PowerPoint sunumlarınızı güçlendirin—şekilleri kolayca tasarlayın ve programlama yoluyla değiştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına dikdörtgen şekilleri eklemeyi gösterir. Basit bir dikdörtgen oluşturmayı, biçimlendirilmiş bir dikdörtgen oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar.

Ayrıca, katı dolgu rengi, çizgi rengi ve çizgi genişliği gibi temel dikdörtgen biçimlendirmelerinin nasıl uygulanacağını da göreceksiniz. Bunun yanı sıra, makalenin SSS bölümü yuvarlatılmış köşeler, resim dolgu, görsel efektler, köprüler, şekil kilitleri, dışa aktarım seçenekleri ve etkili özellikler gibi ilgili dikdörtgen görevlerine işaret eder.

## **Bir Slayda Dikdörtgen Ekle**

Bir sunumun seçili slaytına basit bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İndeksiyle bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak dikdörtgen türünde bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına basit bir dikdörtgen eklenmiştir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX dosyasını temsil eden Presentation sınıfını başlat.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir dikdörtgen şekli ekle.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # PPTX dosyasını diske kaydet.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Biçimlendirilmiş Bir Dikdörtgeni Slayta Ekle**

Bir slayta biçimlendirilmiş bir dikdörtgen eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İndeksiyle bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak dikdörtgen türünde bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ekleyin.
- Dikdörtgenin [fill type](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) özelliğini katı olarak ayarlayın.
- [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) nesnesinin katı dolgu renginde bulunan [setColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/colorformat/#setColor) metodunu kullanarak dikdörtgenin rengini ayarlayın.
- Dikdörtgenin kenarının rengini ayarlayın.
- Dikdörtgenin kenarının genişliğini ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlar aşağıda verilen örnekte uygulanmıştır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# PPTX dosyasını temsil eden Presentation sınıfını örnekle.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir dikdörtgen şekli ekle.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Dikdörtgenin dolgusunu biçimlendir.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Dikdörtgenin dış çizgisini biçimlendir.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # PPTX dosyasını diske kaydet.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Köşeleri yuvarlatılmış bir dikdörtgen nasıl eklerim?**  
Yuvarlatılmış köşe [shape type](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/) kullanın ve şeklin özelliklerinde köşe yarıçapını ayarlayın; yuvarlatma ayrıca geometri ayarlamalarıyla köşeye göre uygulanabilir.

**Bir dikdörtgeni resim (doku) ile nasıl doldururum?**  
Resim [fill type](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) seçin, resim kaynağını sağlayın ve [stretching/tiling modes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillmode/) yapılandırın.

**Bir dikdörtgenin gölgesi ve parlaması olabilir mi?**  
Evet. Ayarlanabilir parametrelerle [outer/inner shadow, glow ve soft edges](/slides/tr/python-java/shape-effect/) kullanılabilir.

**Bir dikdörtgeni köprü içeren bir düğmeye dönüştürebilir miyim?**  
Evet. Şekil tıklamasına (slayta, dosyaya, web adresine veya e‑postaya gitmek) [Assign a hyperlink](/slides/tr/python-java/manage-hyperlinks/) ekleyebilirsiniz.

**Bir dikdörtgeni hareketten ve değişikliklerden koruyabilir miyim?**  
[Use shape locks](/slides/tr/python-java/applying-protection-to-presentation/): hareketi, yeniden boyutlandırmayı, seçimi veya metin düzenlemeyi engelleyerek düzeni koruyabilirsiniz.

**Bir dikdörtgeni raster görüntüye veya SVG’ye dönüştürebilir miyim?**  
Evet. Şekli belirli bir boyut/ölçekle bir görüntüye [render the shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) ya da vektör kullanım için [export it as SVG](/slides/tr/python-java/create-shape-thumbnails/) olarak dışa aktarabilirsiniz.

**Tema ve kalıtımı göz önüne alarak bir dikdörtgenin gerçek (etkili) özelliklerini hızlıca nasıl alırım?**  
[Use the shape’s effective properties](/slides/tr/python-java/shape-effective-properties/): API, tema stilleri, yerleşim ve yerel ayarları hesaba katan hesaplanmış değerleri döndürür, böylece biçimlendirme analizini basitleştirir.