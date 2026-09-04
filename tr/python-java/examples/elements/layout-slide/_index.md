---
title: Yerleşim Slaytı
type: docs
weight: 20
url: /tr/python-java/examples/elements/layout-slide/
keywords:
- kod örneği
- yerleşim slaytı
- yerleşim slaytı ekle
- yerleşim slaytına eriş
- yerleşim slaytını kaldır
- kullanılmayan yerleşim slaytı
- yerleşim slaytını kopyala
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile yerleşim slaytlarını yönetin: PowerPoint ve OpenDocument sunumlarında slaytları ekleyin, erişin, kaldırın, temizleyin ve kopyalayın."
---
Bu makale, Aspose.Slides for Python via Java kullanarak **yerleşim slaytları** ile nasıl çalışılacağını gösterir. Bir yerleşim slaytı, normal slaytlar tarafından devralınan tasarımı ve biçimlendirmeyi tanımlar. Yerleşim slaytlarını ekleyebilir, erişebilir, kopyalayabilir ve kaldırabilir, ayrıca sunum boyutunu azaltmak için kullanılmayanları temizleyebilirsiniz.

Paketi, [Kurulum](/slides/tr/python-java/installation/) bölümünde açıklandığı şekilde kurun. Her örnek, JVM başlatılmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API’yi içe aktarır.

## **Yerleşim Slaytı Ekle**

Yeniden kullanılabilir biçimlendirme tanımlamak için özel bir yerleşim slaytı oluşturun. Aşağıdaki örnek, yeni bir yerleşime bir metin kutusu ekler ve ardından bu yerleşimi kullanan iki slayt oluşturur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Boş bir yerleşim tipi ve özel bir adla bir yerleşim slaytı oluştur.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Yerleşim slaytına bir metin kutusu ekle.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Yerleşimden metni miras alan iki slayt ekle.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Not 1:** Yerleşim slaytları, tek tek slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slayt içinde yeniden kullanabilirsiniz.

> 💡 **Not 2:** Bir yerleşim slaytına şekil veya metin eklediğinizde, o yerleşime dayanan tüm slaytlar paylaşılan içeriği otomatik olarak gösterir.
> Aşağıdaki ekran görüntüsü, aynı yerleşim slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Yerleşim İçeriği Miras Alan Slaytlar](layout-slide-result.png)

## **Yerleşim Slaytı Erişimi**

Yerleşim slaytlarına indeks veya boş, başlık, bölüm başlığı gibi yerleşim türleriyle erişin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Dizine göre bir yerleşim slaytına eriş.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Türüne göre bir yerleşim slaytına eriş.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Yerleşim Slaytını Kaldır**

Artık ihtiyaç duyulmadığında belirli bir yerleşim slaytını kaldırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Kullanılmayan Yerleşim Slaytlarını Kaldır**

Hiçbir normal slayt tarafından kullanılmayan yerleşim slaytlarını kaldırarak sunum boyutunu küçültün.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Yerleşim Slaytını Kopyala**

Bir yerleşim slaytını çoğaltın ve kopyasını yerleşim slaytı koleksiyonunun sonuna ekleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Özet:** Yerleşim slaytları, bir sunumda tutarlı biçimlendirmeyi korumaya yardımcı olur. Aspose.Slides, yerleşimleri ihtiyaç duyulduğunda oluşturmanıza, yönetmenize, yeniden kullanmanıza ve temizlemenize olanak tanır.