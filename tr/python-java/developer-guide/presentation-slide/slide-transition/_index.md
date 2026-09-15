---
title: Python aracılığıyla Java kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/python-java/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- Morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Python via Java ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması ya da zamanlayıcı ile yapılandırabilir ve bir eﬀekte özgü seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini belirlemek, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Python örneklerini kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, bir sunumu [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getSlideShowTransition) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitiontype/) enumarasyonundan bir değerle [setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fareye tıklayarak ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerlemeden önceki gecikmeyi milisaniye cinsinden belirtir.

Hem tıklama hem de zamanlı ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile ilerlemesini ya da zamanlayıcıyı beklemesini sağlayabilirsiniz. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metoduna `False` geçin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini belirlemez.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) çağırın. Saklanan bir gecikme yalnız başına zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin olan her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Geçiş Zamanlamasını Kesin Olarak Kontrol Et**

[setDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setDuration) kullanarak bir geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtebilirsiniz. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/) üzerinden sunar:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) metoduna `True` geçin. |
| [setSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionspeed/) enumarasyonundan önceden tanımlı bir hız kategorisi seçer: Slow, Medium veya Fast. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration] yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipinden ve [getSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getSpeed) değerinden etki süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitiontype/) üzerinden Fade'ı seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş ve bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayt için 500 milisaniye ve ikinci slayt için 1.200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Animasyonlu Çıktı ile Geçişleri Koordine Et**

Bir [animated GIF](/slides/tr/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/python-java/export-to-html5/) veya [video](/slides/tr/python-java/convert-powerpoint-to-video/) hazırlarken, hedeflenen tempoya uygun olarak dışa aktarmadan önce kesin geçiş sürelerini ayarlayın. Örneğin, sahneler arasında 600 milisaniyelik bir fade kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatımına veya içeriğine zaman tanıyın.

GIF ve video için, çıktı kare hızını efekt süresiyle koordine edin: 600 milisaniye, 30 fps'de 18 kareye eşittir. HTML5'te dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı önizleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getDuration) metodunu çağırarak açık bir değerin saklanıp saklanmadığını belirleyin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise saklanan sürenin milisaniye cinsinden olduğunu gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides, geçiş tipini ve [getSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getSpeed) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph etkisi oluşturmak için bir slaytı kopyalayın, kopyadaki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Bu, geçişin ilgili nesneleri orijinal ve değiştirilmiş durumları arasında canlandırmasını sağlar.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı kopyalar ve kopyadaki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitiontype/) enumarasyonundan Morph'ı seçer. Kaydedilen dosyayı Morph'u destekleyen bir sunum görüntüleyicide açarak slayt gösterisi sırasında efekti görebilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionmorphtype/) enumarasyonu, Morph'un içeriği nasıl eşleştirdiğini ve canlandırdığını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionmorphtype/#ByWord) metni, mümkün olduğunda kelimeleri eşleştirerek canlandırır.
- [ByChar](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionmorphtype/#ByChar) metni, mümkün olduğunda karakterleri eşleştirerek canlandırır.

[setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setType) metodunu Morph seçmek için, [getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getValue) metoduna erişmeden önce kullanın. Bu değer, [MorphTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/morphtransition/) sınıfının bir örneği olur ve onun [setMorphType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/morphtransition/#setMorphType) metodu eşleşme modunu seçer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler, yön gibi ek seçenekler ya da etkinin siyah bir ekrandan başlayıp başlamadığını ortaya çıkarır. Mevcut seçenekler, [setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. İlk önce tipi ayarlayın, ardından [getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getValue) üzerinden uygun sınıfı kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlaması için [OptionalBlackTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/optionalblacktransition/) üzerinden [setFromBlack](https://reference.aspose.com/slides/tr/python-java/aspose.slides/optionalblacktransition/#setFromBlack) metodunu çağırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setDuration) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionspeed/) (Slow, Medium veya Fast) kategorisi yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setSpeed) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [setSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setSound) ile atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitionsoundmode/) enumarasyonundan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setSoundMode) metoduna geçirin ve [setSoundLoop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setSoundLoop) metodunu `True` ile etkinleştirin. Ses, slayt gösterisinde bir sonraki ses olayına kadar döngüde çalar.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) koleksiyonunu döngüye alıp, her slaytın geçişi için aynı değeri [setType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#setType) ile çağırın. Zamanlama ve efekt seçeneklerini aynı döngüde ayarlayarak davranışın slaytlar arasında tutarlı kalmasını sağlayın.

**Bir slaytta şu anda hangi geçişin ayarlandığını nasıl kontrol edebilirim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getSlideShowTransition) sonucunda [getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideshowtransition/#getType) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/transitiontype/) enumarasyonundan bir değer döndürür; None_ değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.