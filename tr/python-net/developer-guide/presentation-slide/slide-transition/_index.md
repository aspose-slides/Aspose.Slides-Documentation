---
title: Python Kullanarak Sunularda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 90
url: /tr/python-net/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş tipi
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt geçişlerini uygulayın, otomatik slayt ilerlemeyi yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for Python via .NET ile her slayt için bir geçiş efekti seçebilir, geçişin fare tıklamasıyla mı yoksa zamanlayıcıyla mı ilerleyeceğini yapılandırabilir ve efekti özel seçeneklerle ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Python örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekleme**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın [slide_show_transition](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/slide_show_transition/) özelliğine erişin. Özelliğin [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) enum'undan bir değere ayarlayın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi, ikinci slayta ise Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Gelişmiş Slayt Geçişi Ekleme**

Slaytun ekranda ne kadar kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki özellikler bu davranışı kontrol eder:

- [advance_on_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) izleyicinin fareyi tıklayarak ilerlemesini sağlar.
- [advance_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) otomatik ilerlemeyi etkinleştirir.
- [advance_after_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) otomatik ilerleme öncesi gecikmeyi milisaniye cinsinden belirtir.

İzleyicinin hem tıklama hem de zamanlayıcı ile ilerlemesine izin vermek için her iki seçeneği de etkinleştirin. Yalnızca zamanlayıcıyı kullanmak için [advance_on_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) değerini `False` olarak ayarlayın. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [advance_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) değerini okuyun. Yalnızca kaydedilmiş bir gecikme, zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin zamanlayıcıları raporlar ve iki saniyeden uzun bir gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamalarını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

## **Geçiş Zamanlamasını Kesin Olarak Kontrol Etme**

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) özelliğini kullanın. Slaytın [slide_show_transition](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/slide_show_transition/) özelliği, bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/) aracılığıyla açar:

| Özellik | Amaç |
| --- | --- |
| [duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [advance_after_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [advance_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) özelliğini etkinleştirin. |
| [speed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionspeed/) enum'undan bir ön tanımlı hız kategorisi seçer: SLOW, MEDIUM veya FAST. Kesin bir süre belirtilmediğinde kullanılır. |

[duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [speed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre efekt süresini belirler.

### **Her Slayta Aynı Süreyi Uygulama**

Tutarlı bir tempo için aynı efekti ve kesin süresi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Efekt süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarlama**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek ilk slayta 500 milisaniye, ikinci slayta 1.200 milisaniye süresi ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Geçişleri Animasyonlu Çıktıyla Koordine Etme**

[animasyonlu GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/), [HTML5 sunumu](/slides/tr/python-net/export-to-html5/) veya [video](/slides/tr/python-net/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce kesin geçiş sürelerini ayarlayarak istenen tempo ile eşleşmesini sağlayın. Örneğin sahneler arasında 600 milisaniyelik bir geçiş kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik için zaman tanıyın.

GIF ve video için, çıktı kare hızını efekt süresiyle eşleştirin: 600 milisaniye, 30 fps'de 18 kareye eşittir. HTML5'te, dışa aktarım ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarım formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı önizleyin.

### **Mevcut Bir Geçiş Süresini Okuma**

Geçişi değiştirmeden önce [duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) değerini okuyun; böylece açık bir değer saklanıp saklanmadığını anlayabilirsiniz. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden saklanan sürenin olduğunu gösterir. Bu ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides, geçiş tipine ve [speed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) değerine göre bu süreci belirler. Bir geçiş tipi ayarlamak bir süre başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri animasyonlu olarak gösterir. Basit bir Morph efekti oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Bu, orijinal ve değiştirilmiş durumlar arasında animasyon yapılacak nesneleri eşleştirir.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) enum'undan Morph seçer. Kaydedilen dosyayı Morph'u destekleyen bir sunum görüntüleyicide açtığınızda efekt slayt gösterisi sırasında görülecektir.

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

[TransitionMorphType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionmorphtype/) enum'ı, Morph'un içeriği nasıl eşleştireceğini ve animasyonlayacağını kontrol eder:

- [BY_OBJECT](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionmorphtype/) her şekli bütün bir nesne olarak ele alır.
- [BY_WORD](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda kelimeleri eşleştirerek metni animasyonlar.
- [BY_CHAR](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionmorphtype/) mümkün olduğunda karakterleri eşleştirerek metni animasyonlar.

Geçişin [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) özelliğini Morph olarak ayarlayın, ardından [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/value/) özelliğine erişin. Bu değer, [MorphTransition](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/morphtransition/) nesnesini sağlar; bu nesnenin [morph_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/morphtransition/morph_type/) özelliği eşleştirme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime temelli Morph animasyonu kullanacak şekilde yapılandırır.

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

## **Geçiş Efektleri Ayarlama**

Bazı geçişler yön gibi ek seçenekler sunar veya efektin siyah bir ekrandan başlayıp başlamadığını belirler. Kullanılabilir seçenekler seçilen geçişin [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerine bağlıdır. Önce türü ayarlayın, ardından [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/value/) üzerinden ilgili geçiş nesnesini kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [OptionalBlackTransition](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/optionalblacktransition/) üzerinden [from_black](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) özelliğini ayarlayarak geçişin siyah bir ekrandan başlamasını sağlar.

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

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) tercih edin. Ön tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionspeed/) (SLOW, MEDIUM veya FAST) yeterli olduğunda ve açık bir süre ayarlanmamışsa [speed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound/) özelliğine atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitionsoundmode/) enum'undan START_SOUND olarak [sound_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) ayarlayın ve [sound_loop](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) özelliğini etkinleştirin. Ses, slayt gösterisindeki bir sonraki ses olayı gerçekleşene kadar döngüde çalar.

**Her slayta aynı geçişi en hızlı nasıl uygularım?**

Sunumun [slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) koleksiyonunu döngüye alıp her slaytın geçiş [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) özelliğini aynı değere ayarlayın. Aynı döngü içinde zamanlama ve efekt seçeneklerini de ayarlayarak davranışın tüm slaytlarda tutarlı olmasını sağlayın.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol ederim?**

Slaytın [slide_show_transition](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/slide_show_transition/) özelliğinden [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/slideshowtransition/type/) değerini okuyun. Bu, [TransitionType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.slideshow/transitiontype/) enum'undan bir değer döndürür; NONE değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.