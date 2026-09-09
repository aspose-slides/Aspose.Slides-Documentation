---
title: Python üzerinden Java ile Slayt Gösterilerini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/python-java/manage-slide-show/
keywords:
- gösteri tipi
- konuşmacı tarafından sunulan
- bireysel olarak incelenen
- kiosk'ta incelenen
- gösteri seçenekleri
- sürekli döngü
- anlatım olmadan göster
- animasyon olmadan göster
- kalem rengi
- slaytları göster
- özel gösteri
- slaytları ilerlet
- manuel olarak
- zamanlamaları kullanarak
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolaylıkla kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'un **Set Up Show** seçenekleri, gösteri tipini seçmenize, döngüyü etkinleştirmenize, slaytları seçmenize ve slaytların nasıl ilerleyeceğini kontrol etmenize olanak tanır. Aspose.Slides for Python via Java ile bu seçenekleri programlı olarak yapılandırabilir ve bir sunum dosyasına kaydedebilirsiniz.

The [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlideShowSettings) yöntemi, bu seçenekleri kontrol eden bir [SlideShowSettings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/) nesnesi döndürür. Aşağıdaki örnekler Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanı gerektirir. Her örnek gerektiğinde JVM'yi başlatır ve tamamlandığında sunumu serbest bırakır.

## **Gösteri Tipini Seç**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setSlideShowType) slayt gösterisi tipini tanımlar; bu, aşağıdaki sınıfların bir örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/python-java/aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/python-java/aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri tipini "Browsed by an individual" olarak ayarlar; kaydırma çubuğu gösterilmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gösteri Seçeneklerini Etkinleştir**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setLoop) slayt gösterisinin elle durdurulana kadar bir döngüde tekrar edip etmeyeceğini belirler. Bu, sürekli çalışması gereken otomatik sunumlar için faydalıdır. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setShowNarration) slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler. Bu, izleyicilere sesli rehberlik içeren otomatik sunumlar için yararlıdır. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setShowAnimation) slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için kullanışlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gösterilecek Slaytları Seç**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setSlides) yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenize olanak tanır. Bu, tüm slaytları göstermek yerine sadece bir kısmını göstermek istediğinizde faydalıdır. Aşağıdaki kod örneği dokuz slayttan oluşan bir sunum oluşturur ve 2 ila 9 arasındaki slaytları seçer. Aralık, bir tabanlı slayt numaraları kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Seçilen aralık mevcut olması için dokuz slayt oluştur.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slayt İlerlemesini Kontrol Et**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setUseTimings) yöntemi, her slayt için önceden belirlenmiş zamanlamaların kullanımını etkinleştirmenize veya devre dışı bırakmanıza izin verir. Bu, önceden tanımlı gösterim süreleriyle slaytların otomatik olarak gösterilmesi için faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Medya Kontrollerini Göster**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) yöntemi, multimedya içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, durdur gibi) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımını kontrol etme imkanı vermek istediğinizde yararlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slayt gösterisi modunda başlatılır. Aspose.Slides'te, ilgili kaydetme formatını [export sırasında](/slides/tr/python-java/save-presentation/) seçin.

**Dosyadan silmeden bireysel slaytları gösteriden hariç tutabilir miyim?**

Evet. Bir slaytı [hidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#setHidden) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekranda canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma ise PowerPoint gibi bir görüntüleyici uygulama tarafından gerçekleştirilir.