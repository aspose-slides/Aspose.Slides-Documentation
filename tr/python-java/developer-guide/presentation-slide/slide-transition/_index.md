---
title: Python via Java Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
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

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Python via Java ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması veya zamanlayıcıyla yapılandırabilir ve efekti özel seçeneklerle ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Python örneklerini kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için bir sunumu [Sunum](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile yükleyin ve slaydın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) üzerinden erişin. [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) yöntemini [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) enum'undan bir değerle kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle (Daire) geçişi ve ikinci slayta Comb (Tarak) geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Wheel (Tekerlek) Geçişi**

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) ile [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) üzerinden Wheel (Tekerlek) seçin. Ardından [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) ile [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) ayarlarına erişin. [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) yöntemi, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder.

Örnek iki aynı slayt çiftini oluşturur. Her çift, siyah bir slaytla başlar ve tam bir altın dikdörtgenle sona erer. Her iki hedef slayt da aynı yavaş hızda ([setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) ile ayarlanmış) ve [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ile 8.000 milisaniye açık bir süreyle kullanılır. Sadece spoke (odun) sayısı değişir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`wheel-transitions.pptx` dosyasını PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta ilerleyerek altın dikdörtgenin saat yönünde tek bir süpürme ile ortaya çıkmasını izleyin. Ardından 3. slayttan 4. slayta ilerleyerek sekiz radyal sektörün aynı dikdörtgeni eşzamanlı olarak ortaya çıkarmasını izleyin.

## **Fade Through Black (Siyah Üzerinden Açıklama) ile Reveal (Göster) Geçişi**

Hedef slaydın geçiş türünü Reveal olarak ayarlayın, ardından [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) ayarları üzerinde [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) metodunu çağırın. Örnek, turkuaz bir kaynak slayt ve mercan bir hedef slayt oluşturur, ardından her ikisini de klonlar. Her çift aynı iki saniyelik Reveal geçişini kullanır. Sadece ikinci çift siyah üzerinden geçiş yapar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`reveal-transitions.pptx` dosyasını PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta ilerleyerek turkuazın doğrudan mercana geçmesini izleyin. Ardından 3. slayttan 4. slayta ilerleyin. Ekran, mercan slayt görünmeden önce kısa bir süre neredeyse kara kararmış olur. Her iki slayd da özgün arka plan renklerini korur.

Aşağıdaki satırlar, yarım saniyelik aralıklarla PowerPoint’ten alınan çerçeveleri gösterir. Her satırdaki orta çerçeveyi karşılaştırarak efekti gözlemleyin.

![PowerPoint oynatımı sırasında siyah üzerinden geçiş devre dışı (üst) ve etkin (alt) olduğu gösterilir. Sadece alt satır neredeyse siyah üzerinden geçer.](reveal-through-black.png)

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaydın ekranda ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki metodlar bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerlemeden önceki gecikmeyi milisaniye cinsinden belirler.

Her iki tıklama ve zamanlanmış ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesine ya da zamanlayıcıyı beklemesine izin verin. Sadece zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metoduna `False` gönderin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metodunu çağırın. Saklanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlarda otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

## **Geçiş Zamanlamasını Kesintisiz Kontrol Et**

Geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirlemek için [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metodunu kullanın. Slaydın [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi, bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) üzerinden ortaya çıkarır:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaydın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) metoduna `True` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) enum'undan önceden tanımlı bir hız kategorisini (Slow, Medium veya Fast) seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) yalnızca geçiş efektini kontrol eder; slaydın ekranda ne kadar uzun süre kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) değerine göre efekt süresini belirler.

<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar 750 ms geçiş süresini ve 5.000 ms otomatik ilerleme ayarını gösterir.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ortak örnek, her slayta 750 ms Fade (Solma) geçişi verir ve ayrıca otomatik ilerlemeyi 5.000 ms’de etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme slayttan ne zaman çıkılacağını belirler. Bu çubuklar ölçülen bir birleştirilmiş zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Tüm Slaytlara Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süresi verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

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

        # Efekt süresinden bağımsız olarak otomatik ilerlemeyi yapılandırın.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bireysel Slaytlar İçin Farklı Süreler Belirle**

Farklı slaytlar farklı geçiş süreleri kullanabilir. Örneğin, bir başlık slaytı için kısa bir geçiş ve bir bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayta 500 milisaniye, ikinci slayta 1.200 milisaniye süre ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Animasyonlu Çıktıyla Geçişleri Koordine Et**

[animasyonlu GIF](/slides/tr/python-java/convert-powerpoint-to-animated-gif/), [HTML5 sunumu](/slides/tr/python-java/export-to-html5/) veya [video](/slides/tr/python-java/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce kesin geçiş sürelerini ayarlayarak istenen tempoya uyum sağlayın. Örneğin, sahneler arasına 600 milisaniyelik bir solma ekleyin ve her slaydın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik süresine yer verin.

GIF ve video için, efekt süresiyle uyumlu kare hızını koordine edin: 600 milisaniye, 30 fps’de 18 kareye eşittir. HTML5’te, dışa aktarım ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarım biçiminin desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) metodunu çağırarak açık bir değer saklanıp saklanmadığını belirleyin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden saklanan süreyi gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides, geçiş türü ve [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) değerini kullanarak bu süreyi belirler. Bir geçiş türü ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlar arasındaki nesnelerdeki değişiklikleri canlandırır. Basit bir Morph etkisi oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişini uygulayın. Böylece geçiş, aynı nesnelerin orijinal ve değiştirilmiş hallerini canlandırır.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayd için [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) enum'undan Morph seçer. Morph’u destekleyen bir sunum görüntüleyicide kaydedilmiş dosyayı açarak slayt gösterisi sırasında efekti görün.

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

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) enum'ı, Morph’un içerikle nasıl eşleşip canlandırılacağını belirler:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) ile Morph seçildikten sonra [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) metoduna erişilir. Dönen değer, [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) sınıfının bir örneğidir ve [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) yöntemi eşleşme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

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

Bazı geçişler ek seçenekler sunar; örneğin yön veya efektin siyah bir ekrandan başlayıp başlamadığı gibi. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. Önce tipi ayarlayın, ardından [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) aracılığıyla uygun sınıfı kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaydına Cut (Kes) geçişi uygular. [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) üzerinden [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) metodunu çağırarak geçişin siyah bir ekrandan başlamasını sağlar.

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

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde **[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration)** yöntemini tercih edin. Önceden tanımlı bir **[TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)** (Slow, Medium veya Fast) kategorisi yeterli olduğunda ve açık bir süre ayarlanmamışsa **[setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed)** yöntemini kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. **[setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound)** ile gömülü sesi atayın, **[TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/)** enum'undan **StartSound** değerini **[setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode)** metoduna gönderin ve **[setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop)** ile `True` ayarlayarak sesi döngüye alın. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döner.

**Her slayta aynı geçişi en hızlı şekilde nasıl uygularım?**

Sunumun **[getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)** koleksiyonunda döngü oluşturun ve her slaydın geçişi için aynı değerle **[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType)** metodunu çağırın. Zamanlama ve efekt seçeneklerini aynı döngüde ayarlayarak tutarlılığı sağlayın.

**Bir slaytta şu anda ayarlı geçişi nasıl kontrol edebilirim?**

Slaydın **[getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition)** sonucunda **[getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType)** metodunu çağırın. Bu, **[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)** enum'undan bir değer döndürür; **None_** değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.