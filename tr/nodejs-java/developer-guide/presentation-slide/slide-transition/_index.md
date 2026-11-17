---
title: JavaScript Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ile diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Node.js via Java ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması veya zamanlayıcı ile yapılandırabilir ve effect'e özgü seçenekleri ayarlayabilirsiniz. Bu makale, JavaScript örnekleri kullanarak geçişleri uygulamayı, kesin geçiş sürelerini ayarlamayı, slayt zamanlamasını yönetmeyi ve iki slayt arasında bir Morph geçişi oluşturmayı gösterir. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini de gösterir.

## **Slayt Geçişi Ekleme**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfıyla yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) enum'undan bir değerle [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slayta sahip bir `input.pptx` dosyası kullanın.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Wheel Geçişi**

[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) sınıfının [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) yöntemi, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) üzerinden [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ile slaytın geçiş tipini Wheel olarak ayarladıktan sonra, [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) olarak [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) alın.

Bu örnek iki aynı slayt çifti oluşturur: siyah bir slayt, ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar 1 ve 8 spoke sayılarına sahiptir; aynı hız [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) ile ayarlanmış ve 8.000 milisaniye açıkça [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ile ayarlanmıştır, böylece fark gözle görülür.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı sunumunu PowerPoint’te açın ve slayt gösterisini çalıştırın. 1. slayttan 2. slayta, ardından 3. slayttan 4. slayta ilerleyin. PowerPoint oynatımında, 1 spoke sayısı saat yönünde tek bir süpürme ile slaytı ortaya çıkarırken; 8 spoke sayısı aynı anda sekiz radyal sektörle ortaya çıkarır. Hedef içerik ve geçiş zamanlaması aynı olduğundan, fark ortaya çıkan sektör sayısındadır.

## **Gelişmiş Slayt Geçişi Ekleme**

Bir slaytun ekranda ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerlemeden önceki gecikmeyi milisaniye olarak belirtir.

Hem tıklama hem de zamanlı ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesini veya zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) yöntemine `false` gönderin. Gecikme slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slayta sahip bir `input.pptx` dosyası kullanın.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) çağırın. Saklanan bir gecikme sadece zamanlayıcının aktif olduğu anlamına gelmez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geçiş Zamanlamasını Hassas Bir Şekilde Kontrol Etme**

Geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) üzerinden açığa çıkar:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin kendisinin süresini milisaniye olarak ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye olarak ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ile `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) enum'undan önceden tanımlı bir hız kategorisi (Slow, Medium veya Fast) seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar süre kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açıkça bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) değerine göre etki süresini belirler.


<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ortak örnek, her slayta 750 ms Fade geçişi verir ve ayrıca otomatik ilerlemeyi 5 000 ms’de etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme slayttan çıkma zamanını kontrol eder. Bu çubuklar ölçülen bir zaman çizelgesi değil, taslak ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Her Slayta Aynı Süreyi Uygulama**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir, fare tıklamasıyla ilerlemeyi devre dışı bırakır ve sonucu PPTX olarak kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarlama**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayt için 500 ms, ikinci slayt için 1 200 ms ayarlar. En az iki slayta sahip bir `input.pptx` dosyası kullanın.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Animasyonlu Çıktı ile Geçişleri Koordine Etme**

Bir [animated GIF](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/) , [HTML5 presentation](/slides/tr/nodejs-java/export-to-html5/) veya [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce tam geçiş sürelerini ayarlayarak istenen tempoyu eşleştirin. Örneğin, sahneler arasında 600 ms geçiş fade’i kullanın ve her slaydın anlatım veya içeriği için yeterli zaman tanımak amacıyla ilerleme gecikmesini ayrı ayrı ayarlayın.

GIF ve video için, etki süresiyle eşleşecek kare hızıyla koordinasyon sağlayın: 600 ms, 30 fps’de 18 kareye denk gelir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma biçiminin desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı önizleyin.

### **Mevcut Geçiş Süresini Okuma**

Geçişi değiştirmeden önce açık bir değer depolanıp depolanmadığını belirlemek için [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) çağırın. `-1` değeri açık bir süre ayarlanmadığını gösterir; negatif olmayan bir değer milisaniye cinsinden depolanmış süreyi belirtir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden orijinal ayarları önce inceleyin.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi**

Morph geçişi, art arda gelen slaytlardaki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı kopyalayın, kopya üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişini uygulayın. Bu, orijinal ve değiştirilmiş durumlar arasında animasyon yapılacak ilgili nesneleri sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı kopyalar ve kopyadaki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) enum'undan Morph seçer. Kaydedilen dosyayı Morph’u destekleyen bir sunum görüntüleyicide açarak slayt gösterisi sırasında efekti görün.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) enum'ı, Morph’un içeriği nasıl eşleyeceğini ve canlandıracağını belirler:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Morph seçmek için [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) alın. Bu değer bir [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) nesnesi sağlar; bunun [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) yöntemi eşleşme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Geçiş Efektlerini Ayarlama**

Bazı geçişler ek seçenekler sunar; örneğin yön veya efektin siyah bir ekrandan başlaması gibi. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. İlk önce tipi ayarlayın, ardından [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) aracılığıyla uygun geçiş nesnesini kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlamasını sağlamak için [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) üzerinden [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) çağırır.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir etki süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (Slow, Medium veya Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) kullanın. Bu ayarlar, geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) ile gömülü ses atayın, [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) enum'undan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) ile gönderin ve [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) ile `true` ayarlayın. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döngüye girer.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) koleksiyonunu döngüye alın ve her slaydın geçişi için aynı değerle [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) çağırın. Aynı döngü içinde zamanlama ve efekt seçeneklerini ayarlayarak davranışı slaytlar arasında tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaydın [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) sonucunda [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) enum'undan bir değer döndürür; None, hiçbir geçiş efektinin uygulanmadığını gösterir.