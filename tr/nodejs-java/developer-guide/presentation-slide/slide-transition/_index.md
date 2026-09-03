---
title: Sunumlarda JavaScript ile Slayt Geçişlerini Yönetme
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

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Node.js via Java ile her slayt için bir geçiş efekti seçebilir, fare tıklaması veya zamanlayıcı ile ilerlemeyi yapılandırabilir ve bir efekti özel seçeneklerle ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, tam geçiş süresini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için JavaScript örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) aracılığıyla erişin. [TransitionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitiontype/) listesinden bir değerle [setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fareyi tıklayarak ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerleme öncesindeki gecikmeyi milisaniye olarak belirler.

Hem tıklamayı hem de zamanlayıcıyı etkinleştirerek izleyicinin tıklama ile devam etmesini veya zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) yöntemine `false` gönderin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) yöntemini çağırın. Saklanan gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

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

## **Geçiş Zamanlamasını Hassas Bir Şekilde Kontrol Et**

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setDuration) yöntemini kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/) aracılığıyla ortaya çıkarır:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) yöntemine `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionspeed/) listesinden önceden tanımlı bir hız kategorisi (Yavaş, Orta veya Hızlı) seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration] yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar süre kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [getSpeed] değerine göre efekt süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitiontype/) listesinden Fade seçer ve her geçişe 750 milisaniye süresi verir. Ayrıca otomatik ilerlemeyi 5 000 milisaniye sonra etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Otomatik ilerlemeyi, efekt süresinden bağımsız olarak yapılandır.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin bir başlık slaytı için kısa bir geçiş, bölüm tanıtımı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayta 500 milisaniye, ikinci slayta 1 200 milisaniye süresi ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Geçişleri Animasyonlu Çıktıyla Koordine Et**

[animated GIF](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/nodejs-java/export-to-html5/) veya [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) hazırlarken dışa aktarmadan önce kesin geçiş sürelerini ayarlayın, böylece istenen tempoyu yakalarsınız. Örneğin sahneler arasında 600 milisaniyelik bir solma efekti kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik süresine yer açın.

GIF ve video için, efekt süresine göre kare hızını ayarlayın: 600 milisaniye, 30 fps’de 18 kareye eşittir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarım biçiminin desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için önizleme yapın.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#getDuration) yöntemini çağırarak saklı bir değer olup olmadığını öğrenin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden saklanan süreyi gösterir. Ayarlanmamış değer, oynatma süresi olarak hesaplanan değeri göstermez: Aspose.Slides geçiş türü ve [getSpeed] değerine göre bu süreyi belirler. Bir geçiş türü ayarlandığında bir süre başlatılabilir, bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, art arda gelen slaytlardaki nesneler arasındaki değişiklikleri animasyonlu olarak gösterir. Basit bir Morph etkisi oluşturmak için bir slaytı kopyalayın, kopyada bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Bu, orijinal ve değiştirilmiş durumlar arasında animasyon yapılacak nesneleri eşleştirir.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı kopyalar ve kopyadaki dikdörtgenin konum ve boyutunu değiştirir. İkinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitiontype/) listesinden Morph seçer. Morph’u destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak efekti slayt gösterisinde izleyin.

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

## **Morph Geçiş Tipleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionmorphtype/) sayımı, Morph’un içeriği nasıl eşleştirdiğini ve animasyonladığını belirler:

- [ByObject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak işler.
- [ByWord](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni animasyonlu hâle getirir.
- [ByChar](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni animasyonlu hâle getirir.

Morph’u seçmek için önce [setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setType) ile Morph ayarlayın, ardından [getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#getValue) ile bir [MorphTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/morphtransition/) nesnesi elde edin ve bu nesnenin [setMorphType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/morphtransition/#setMorphType) yöntemiyle eşleştirme modunu seçin.

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

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek yön seçenekleri veya efektin siyah bir ekrandan başlayıp başlamadığı gibi ek ayarlar sunar. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. Önce türü ayarlayın, ardından [getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/#getValue) üzerinden uygun geçiş nesnesini kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [OptionalBlackTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/optionalblacktransition/) aracılığıyla [setFromBlack](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) metodunu çağırarak geçişin siyah bir ekrandan başlamasını sağlar.

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

**Slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration] yöntemini tercih edin. Kesin bir süre ayarlanmamış ve önceden tanımlı bir [TransitionSpeed] (Yavaş, Orta veya Hızlı) kategorisi yeterli olduğunda ise [setSpeed] yöntemini kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [setSound] yöntemiyle gömülü ses atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionsoundmode/) listesinden StartSound değerini [setSoundMode] yöntemine gönderin ve [setSoundLoop] yöntemine `true` vererek sesin döngüye alınmasını sağlayın. Ses, slayt gösterisindeki bir sonraki ses olayına kadar döngüde çalmaya devam eder.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSlides) koleksiyonunda döngü oluşturun ve her slaytın geçişi için aynı değerle [setType] yöntemini çağırın. Zamanlama ve efekt seçeneklerini aynı döngü içinde ayarlayarak davranışın tüm slaytlarda tutarlı olmasını sağlayın.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaydın [getSlideShowTransition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) sonucunda [getType] yöntemini çağırın. Bu yöntem, [TransitionType] listesinden bir değer döndürür; None değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.