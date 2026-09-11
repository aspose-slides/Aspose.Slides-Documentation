---
title: Python üzerinden Java ile Sunumlara Elips Ekleme
linktitle: Elips
type: docs
weight: 30
url: /tr/python-java/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides'te elips şekillerini oluşturmayı, biçimlendirmeyi ve düzenlemeyi öğrenin; PPT ve PPTX sunumları için örnek Python kodları dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips yaratmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elipsin konumu ve boyutu ile çalışma, yığın sırasını kontrol etme ve animasyon efektleri uygulama gibi ilgili sorulara da değinir.

## **Elips Oluşturma**

Sunumun seçilen bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
- İndisine göre bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesinin [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak bir elips ekleyin.
- Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, ilk slayta bir elips ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir elips şekli ekle.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # PPTX dosyasını diske yaz.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Biçimlendirilmiş Elips Oluşturma**

Bir slayta biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
- İndisine göre bir slayta referans alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) nesnesinin [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak bir elips ekleyin.
- Elipsin doldurma tipini katı olarak ayarlayın.
- Elipsin doldurma rengi, [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) nesnesine bağlı [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) nesnesi üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getSolidFillColor) yöntemiyle ayarlanır.
- Elipsin kontur rengini ayarlayın.
- Elipsin kontur genişliğini ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, sunumun ilk slaytına biçimlendirilmiş bir elips ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir elips şekli ekle.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Elipsin dolgusunu biçimlendir.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Elipsin konturunu biçimlendir.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # PPTX dosyasını diske yaz.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Bir elipsin konumunu ve boyutunu slayt birimlerine göre nasıl kesin olarak ayarlarım?**

Koordinatlar ve boyutlar genellikle **puan cinsinden** belirtilir. Öngörülebilir sonuçlar için, hesaplamalarınızı slayt boyutuna göre yapın ve değerleri atamadan önce gerekli milimetre veya inçleri puana çevirin.

**Bir elipsi diğer nesnelerin üstüne ya da altına nasıl yerleştiririm (yığın sırasını kontrol etme)?**

Nesnenin çizim sırasını öne getirilerek ya da arkaya gönderilerek ayarlayın. Bu, elipsin diğer nesnelerin üzerine gelmesini veya altındakileri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Uygula](/slides/tr/python-java/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle uygulayın ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını düzenleyin.