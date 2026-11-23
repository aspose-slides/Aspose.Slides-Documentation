---
title: Java Kullanarak Sunularda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ile diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Java ile her slayt için bir geçiş efekti seçebilir, geçişi fare tıklaması ya da zamanlayıcıyla ilerletecek şekilde yapılandırabilir ve efektiyle ilgili seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında Morph geçişi oluşturmak için Java örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, bir sunumu [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfıyla yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) aracılığıyla erişin. [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum'ından bir değerle [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle (Daire) geçişi ve ikinci slayta Comb (Tarama) geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Tekerlek Geçişi**

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) arayüzünün [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) yöntemi, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. Geçiş türünü [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) üzerinden [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ile Wheel (Tekerlek) olarak ayarladıktan sonra, [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) üzerinden [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) erişin.

Bu örnek iki aynı slayt çiftini oluşturur: siyah bir slayt ve ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar 1 ve 8 spoke (çubuk) sayısı kullanır; aynı hız [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ile ayarlanır ve farkın kolay görülmesi için [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ile 8.000 milisaniye açık süre belirtilir.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı sunumunu PowerPoint’te açın ve slayt gösterisini çalıştırın. 1. slayttan 2. slayta, ardından 3. slayttan 4. slayta ilerleyin. PowerPoint oynatımında, 1 spoke doğrulanmış slayt tek saat yönünde bir sweep (tarama) ile ortaya çıkar; 8 spoke doğrulanmış slayt aynı anda sekiz radyal sektörle ortaya çıkar. Hedef içerik ve geçiş zamanlaması aynı olduğundan fark sadece ortaya çıkma sektörlerinin sayısıdır.

## **Karartmalı Geçiş ile Karartma Üzerinden Geçiş (Fade Through Black)**

Hedef slaytın geçiş türünü Reveal (Açığa Çıkarma) olarak ayarlayın, ardından [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) ayarları üzerinde [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) yöntemini çağırın. Örnek, bir teal (camgöbeği) kaynak slaytı ve bir coral (mercan) hedef slaytı oluşturur, ardından ikisini klonlar. Her çift aynı iki saniyelik Reveal geçişi kullanır. Yalnızca ikinci çift karartma üzerinden geçiş yapar.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunumu PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta ilerleyerek teal’in doğrudan coral’a geçişini görün. Ardından 3. slayttan 4. slayta ilerleyin. Ekran, coral slaytı görünmeden önce kısa bir süre neredeyse kararıma döner. Her iki slayt da orijinal arka plan renklerini korur.

Aşağıdaki satırlar, yarım saniyelik aralıklarla PowerPoint karelerini gösterir. Etkiyi görmek için her satırdaki orta kareyi karşılaştırın.

![PowerPoint oynatımı, geçişin karartma etkisi devre dışı (üst) ve etkin (alt) olduğu halde. Yalnızca alt satır neredeyse siyaha geçer.](reveal-through-black.png)

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) otomatik ilerleme öncesi gecikmeyi milisaniye cinsinden belirtir.

Hem tıklama hem de zamanlanmış ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile ilerlemesini ya da zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) yöntemine `false` gönderin. Gecikme slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve otomatik ilerlemeyi sırasıyla 3, 5 ve 7 saniye sonra etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) yöntemini çağırın. Saklanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmesi olan slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geçiş Zamanını Kesin Bir Şekilde Kontrol Et**

Geçiş efektinin tam süresini milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yöntemini kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) yöntemi bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) aracılığıyla açığa çıkar:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Geçiş efektinin kendisinin süresini milisaniye olarak ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye olarak ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) yöntemine `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) enum'ından önceden tanımlı bir hız kategorisini seçer: Slow, Medium veya Fast. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre süreci belirler.


<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar 750 ms geçiş süresini ve 5.000 ms otomatik ilerleme ayarını gösterir. Geçiş süresi efekti kontrol eder; ilerleme slayttan ne zaman çıkılacağını kontrol eder. Bu çubuklar ölçülmüş bir birleşik zaman çizelgesi değil, şematik ayarlardır.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ortak örnek, her slayta 750 ms Fade (Solma) geçişi verir ve ayrı olarak 5.000 ms’lik otomatik ilerlemeyi etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme slayttan ne zaman çıkılacağını kontrol eder. Bu çubuklar ölçülmüş bir birleşik zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için, aynı efekti ve kesin süreyi her slayta uygularsınız. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Geçiş süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı geçiş süreleri kullanabilir. Örneğin, bir başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanabilirsiniz. Bu örnek, ilk slayta 500 milisaniye, ikinci slayta 1.200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Animasyonlu Çıktı ile Geçişleri Koordine Et**

Bir [animated GIF](/slides/tr/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/java/export-to-html5/) veya [video](/slides/tr/java/convert-powerpoint-to-video/) hazırlarken, dışa aktarmadan önce kesin geçiş sürelerini belirleyerek istenen tempoyu eşleştirin. Örneğin, sahneler arasında 600 milisaniyelik bir solma kullanın ve her slaytın anlatım veya içeriği için yeterli zaman tanımak amacıyla ilerleme gecikmesini ayrı ayrı ayarlayın.

GIF ve video için, çerçeve hızını efekt süresiyle eşleştirin: 600 milisaniye, 30 fps’de 18 kareye denk gelir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarım formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu onaylamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) yöntemini çağırarak açık bir değerin saklanıp saklanmadığını öğrenin. `-1` değeri açık bir sürenin ayarlanmadığını, negatif olmayan bir değer ise milisaniye cinsinden saklanan süreyi gösterir. Ayarlanmamış değer, oynatma süresi olarak hesaplanan süre değildir: Aspose.Slides geçiş türü ve [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre bu süreci belirler. Geçiş türü ayarlandığında bir süre başlatılabilir, bu yüzden önce orijinal ayarları inceleyin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlar üzerindeki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph efekti oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişini uygulayın. Bu, orijinal ve değiştirilmiş durumlar arasında animasyonlanacak eşleşen nesneleri sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Daha sonra ikinci slayt için [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum'undan Morph seçilir. Morph’u destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak efektin slayt gösterisi sırasında nasıl göründüğünü inceleyin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) enum'ı, Morph’un içeriği nasıl eşleştirip canlandıracağını belirler:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak işler.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Morph’u seçmek için önce [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ile Morph belirlenir, ardından [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) ile [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) arayüzü elde edilir; bu arayüzün [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) yöntemi eşleşme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime tabanlı Morph animasyonu kullanacak şekilde yapılandırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek seçenekler sunar; örneğin yön veya efektin siyah bir ekrandan başlayıp başlamadığı. Bu ek seçenekler, [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ile seçilen geçişe bağlıdır. İlk olarak türü ayarlayın, ardından uygun arayüzü [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) üzerinden kullanın.

Aşağıdaki örnek, `input.pptx` dosyasındaki ilk slayta Cut (Kesme) geçişi uygular. [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) aracılığıyla [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) çağrısı yapılır ve geçişin siyah bir ekrandan başlaması sağlanır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) kategorisi (Slow, Medium veya Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ile gömülü ses atayın, [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) enum'undan StartSound göndererek [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) ayarlayın ve [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) yöntemine `true` göndererek sesi döngüye alın. Ses, slayt gösterisinde bir sonraki ses olayına kadar döngüde kalır.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) koleksiyonunu döngüyle gezip her slaytın geçişi için aynı değeri [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ile ayarlayın. Aynı döngü içinde zamanlama ve efekt seçeneklerini de ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) sonucunda [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum'ından bir değer döndürür; None (Hiçbiri) değeri, geçiş efektinin uygulanmadığını gösterir.