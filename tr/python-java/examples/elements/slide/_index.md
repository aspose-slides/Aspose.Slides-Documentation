---
title: Slayt
type: docs
weight: 10
url: /tr/python-java/examples/elements/slide/
keywords:
- kod örneği
- slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slaytları yönetin: PowerPoint ve OpenDocument sunumları için Python kod örnekleriyle slayt ekleyin, erişin, kopyalayın, yeniden sıralayın ve kaldırın."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak slayt ekleme, erişme, kopyalama, yeniden sıralama ve silme işlemlerini gösteren örnekler sunar.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` kütüphanesini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Slayt Ekle**

Yeni bir slayt eklemek için önce bir düzen seçin. Bu örnek, sunuma boş bir slayt eklemek amacıyla boş bir düzen kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Her slayt düzeni, genel tasarımı ve yer tutucu yapısını tanımlayan bir ana slayttan türetilir. Aşağıdaki resim, ana slaytların ve ilişkili düzenlerin PowerPoint'te nasıl organize edildiğini göstermektedir.
{{% /alert %}}

![Ana Slayt ve Düzen İlişkisi](master-layout-slide.png)

## **İndeks ile Slaytlara Erişim**

Slaytlara sıfır tabanlı indeksleriyle erişebilir veya bir referansa dayalı olarak bir slaytın indeksini bulabilirsiniz. Bu, belirli slaytlar üzerinde döngü oluşturmak veya değiştirmek için faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Başka bir boş slayt ekleyin.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Slaytlara indeksle erişin.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Bir referanstan slaytın indeksini al, ardından indeksle eriş.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Slaytı Kopyala**

Mevcut bir slaytı kopyalayın. Kopyalanan slayt, slayt koleksiyonunun sonuna otomatik olarak eklenir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Slaytları Yeniden Sırala**

Bir slaytı yeni bir indekse taşıyarak slaytların sırasını değiştirin. Bu örnek, kopyalanan bir slaytı ilk konuma taşır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Slaytı Kaldır**

Bir slaytı, referansını slayt koleksiyonuna geçirerek kaldırın. Bu örnek ikinci bir slayt ekler ve ardından orijinali kaldırarak sadece yenisini bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```