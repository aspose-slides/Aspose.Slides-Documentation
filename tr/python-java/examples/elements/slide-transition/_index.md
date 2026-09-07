---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/python-java/examples/elements/slide-transition/
keywords:
- kod örneği
- slayt geçişi
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kod örnekleriyle PPT, PPTX ve ODP sunumları için slayt geçişlerini uygulayın ve kaldırın, ayrıca otomatik slayt ilerletme zamanlamalarını ayarlayın."
---
Bu makale, **Aspose.Slides for Python via Java** ile slayt geçiş efektleri ve zamanlamalarını uygulamayı gösterir.

Paketi, [Kurulum](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi yükleyin. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Slayt Geçişi Ekle**

İlk slayta bir solma geçiş efekti uygulayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Solma geçişi uygula.
finally:
    presentation.dispose()
```

## **Slayt Geçişine Eriş**

Bir slayta şu anda atanmış geçiş türünü okuyun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Geçiş türüne eriş.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Slayt Geçişini Kaldır**

Herhangi bir geçiş efektini temizleyin. JPype, `None` adlı Java sabitini Python'da rezerve edilmiş kelime olduğu için `None_` olarak sunar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Geçiş efektini kaldır.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Geçiş Süresini Ayarla**

Slaytın otomatik olarak ilerlemeden önce ne kadar süre görüntüleneceğini belirtin. Bu örnek iki saniye sonra ilerler ve ayrıca fare tıklamasıyla ilerlemeye izin verir. Bu zamanlama, geçiş efektinin hızını değil, slaytın ilerlemesini kontrol eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Milisaniye cinsinden.
finally:
    presentation.dispose()
```