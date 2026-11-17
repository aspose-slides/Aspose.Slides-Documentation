---
title: Python ile Sunumlarda Slayt Geçişlerini Yönetin
linktitle: Slayt Geçişi
type: docs
weight: 90
url: /tr/python-net/slide-transition/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for Python via .NET ile her slayt için bir geçiş efekti seçebilir, fare tıklaması veya zamanlayıcıyla ilerlemeyi yapılandırabilir ve bir efekte özgü seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, tam geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Python örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) özelliğine erişin. Özelliğin [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listesinden bir değer olarak ayarlayın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle (Daire) geçişi ve ikinci slayta Comb (Tarama) geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Tekerlek Geçişi**

[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) sınıfının [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) özelliği, hedef slaytı ortaya çıkaran radyal bölümler sayısını kontrol eder. Slaytın geçiş [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) özelliğini [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listesinden WHEEL olarak ayarlayın ve ardından [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) üzerinden [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) nesnesine erişin.

Bu örnek, iki adet aynı slayt çiftini oluşturur: siyah bir slayt ve ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar 1 ve 8 spoke (çubuk) sayısı kullanır; aynı [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ve 8.000 milisaniye açıkça belirtilmiş bir [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ile farkın kolayca gözlemlenmesi sağlanır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Çıktı sunumunu PowerPoint’te açın ve slayt gösterisini çalıştırın. 1. slayttan 2. slayta, ardından 3. slayttan 4. slayta ilerleyin. PowerPoint oynatımında, 1 spoke sayısı slaytı tek bir saat yönünde süpürme ile ortaya çıkar; 8 spoke sayısı aynı anda sekiz radyal bölümle ortaya çıkarır. Hedef içerik ve geçiş zamanlaması aynıdır, dolayısıyla fark ortaya çıkma bölümlerinin sayısıdır.

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki özellikler bu davranışı kontrol eder:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) izleyicinin fareye tıklayarak ilerlemesini sağlar.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) otomatik ilerlemeyi etkinleştirir.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) otomatik ilerleme öncesindeki gecikmeyi milisaniye cinsinden belirler.

İzleyicinin bir tıklama ile ilerlemesini ya da zamanlayıcıyı beklemesini sağlamak için hem tıklamayı hem de zamanlı ilerlemeyi etkinleştirin. Yalnızca zamanlayıcıyı kullanmak için [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) özelliğini `False` olarak ayarlayın. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini belirler; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Zamanlayıcıyla ilerlemenin etkin olup olmadığını kontrol etmek için [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) özelliğini okuyun. Saklanan bir gecikme yalnızca bir zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden büyük gecikmesi olan slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Geçiş Zamanlamasını Kesin Olarak Kontrol Et**

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) kullanın. Slaytın [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) özelliği bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) üzerinden sunar:

| Özellik | Amaç |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) özelliğini açın. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) listesinden SLOW, MEDIUM veya FAST gibi önceden tanımlı bir hız kategorisi seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak ayarlayın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre etki süresini belirler.

<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar 750 ms geçiş süresini ve 5 000 ms otomatik ilerleme ayarını gösterir.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Paylaşılan örnek her slayta 750 ms Fade geçişi verir ve otomatik ilerlemeyi 5 000 ms'de ayrı olarak etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme ne zaman slayttan çıkılacağını kontrol eder. Bu çubuklar ölçülmüş birleşik bir zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listesinden Fade seçer ve her geçişe 750 milisaniye süre verir. Otomatik ilerlemeyi 5 000 milisaniye sonra ayrı olarak etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Bireysel Slaytlar İçin Farklı Süreler Belirle**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş ve bölüm tanıtımı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayt için 500 milisaniye ve ikinci slayt için 1 200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Animasyonlu Çıktıyla Geçişleri Koordine Et**

[animasyonlu GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/), [HTML5 sunumu](/slides/tr/python-net/export-to-html5/) veya [video](/slides/tr/python-net/convert-powerpoint-to-video/) hazırlarken, istenen tempoya uygun olması için dışa aktarmadan önce tam geçiş sürelerini ayarlayın. Örneğin, sahneler arasında 600 milisaniyelik bir fade kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik için zaman tanıyın.

GIF ve video için, çıktı kare hızıyla efekt süresini eşleştirin: 600 milisaniye, 30 kare/saniye hızında 18 kareye denk gelir. HTML5'te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) değerini okuyarak açık bir değer depolanıp depolanmadığını belirleyin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise saklanan sürenin milisaniye cinsinden olduğunu gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş türü ve [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre bu süreyi belirler. Bir geçiş türü ayarlamak bir süreyi başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph Geçişi**

Morph geçişi, art arda gelen slaytlardaki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı çoğaltın, kopyadaki bir nesneyi taşıyın veya yeniden boyutlandırın ve Morph geçişini ikinci slayta uygulayın. Bu, geçişin ilgili nesneleri orijinal ve değiştirilmiş durumlar arasında canlandırmasını sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı çoğaltır ve kopyadaki dikdörtgenin konumunu ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listesinden Morph seçer. Morph destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açın ve slayt gösterisi sırasında efekti görün.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) listesi, Morph'un içeriği nasıl eşleştirip canlandıracağını belirler:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) her şekli bütün bir nesne olarak ele alır.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Geçişin [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini Morph olarak ayarlayın, ardından [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) üzerinden erişin. Bu değer, eşleştirme modunu seçen [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) özelliğine sahip [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) nesnesini sağlar.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek seçenekler ortaya çıkarır; örneğin yön veya efektin siyah bir ekrandan başlaması gibi. Kullanılabilir seçenekler seçilen geçiş [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerine bağlıdır. İlk olarak türü ayarlayın, ardından [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) üzerinden uygun geçiş nesnesini kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut (Kesme) geçişi uygular. Geçişin siyah bir ekrandan başlamasını sağlamak için [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) üzerinden [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) ayarını yapar.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **SSS**

**Slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (SLOW, MEDIUM veya FAST) yeterli olduğunda ve açık bir süre ayarlanmamışsa [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü ses dosyasını [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) özelliğine atayın, [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) listesinden START_SOUND olarak [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) ayarlayın ve [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) özelliğini etkinleştirin. Ses, sonraki ses olayı gelene kadar döngüde çalar.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) koleksiyonunda döngü oluşturun ve her slaytın geçiş [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini aynı değere ayarlayın. Aynı döngü içinde zamanlama ve efekt seçeneklerini de ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) özelliğinden [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini okuyun. Bu, [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listesinden bir değer döndürür; NONE değeri geçiş etkisinin uygulanmadığını gösterir.