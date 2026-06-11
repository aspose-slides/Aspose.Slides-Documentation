---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu JavaScript
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/nodejs-java/shape-animation/
keywords:
- kształt
- animacja
- efekt
- animowany kształt
- animowany tekst
- dodaj animację
- pobierz animację
- wyodrębnij animację
- dodaj efekt
- pobierz efekt
- wyodrębnij efekt
- dźwięk efektu
- zastosuj animację
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js via Java. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje są efektami wizualnymi, które można zastosować do tekstów, obrazów, kształtów lub [diagramów](/slides/pl/nodejs-java/animated-charts/). Ożywiają prezentacje lub ich elementy.

## **Dlaczego używać animacji w prezentacjach?**

* kontrolować przepływ informacji  
* podkreślać ważne punkty  
* zwiększać zainteresowanie lub uczestnictwo odbiorców  
* uczynić treść łatwiejszą do przeczytania, przyswojenia lub przetworzenia  
* przyciągać uwagę czytelników lub widzów do ważnych części prezentacji  

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **entrance**, **exit**, **emphasis** i **motion paths**.

## **Animacje w Aspose.Slides**

* Aspose.Slides dostarcza klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw `Aspose.Slides.Animation`,  
* Aspose.Slides udostępnia ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttype). Efekty te są w zasadzie takie same (lub równoważne) jak te używane w PowerPoint.

## **Zastosowanie animacji do TextBox**

Aspose.Slides dla Node.js via Java umożliwia zastosowanie animacji do tekstu w kształcie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj `rectangle` [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape).  
4. Dodaj tekst przy użyciu [AutoShape.addTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).  
5. Pobierz główną sekwencję efektów.  
6. Dodaj efekt animacji do [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape).  
7. Wywołaj metodę `TextAnimation.setBuildType` z wartością z wyliczenia `BuildType`.  
8. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod Javascript pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Dodaje nowy AutoShape z tekstem
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Pobiera główną sekwencję slajdu.
    var sequence = sld.getTimeline().getMainSequence();
    // Dodaje efekt animacji zanikania (Fade) do kształtu
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animuje tekst kształtu według akapitów pierwszego poziomu
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Zapisuje plik PPTX na dysku
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Oprócz stosowania animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph). Zobacz [**Animowany tekst**](/slides/pl/nodejs-java/animated-text/).

{{% /alert %}} 

## **Zastosowanie animacji do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe) na slajdzie.  
4. Pobierz główną sekwencję efektów.  
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe).  
6. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod Javascript pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
var pres = new aspose.slides.Presentation();
try {
    // Wczytuje obraz, który ma być dodany do kolekcji obrazów w prezentacji
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje ramkę obrazu do slajdu
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Pobiera główną sekwencję slajdu.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Dodaje efekt animacji Fly od lewej do ramki obrazu
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Zapisuje plik PPTX na dysku
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastosowanie animacji do Shape**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj `rectangle` [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape).  
4. Dodaj `Bevel` [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape). (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).  
5. Utwórz sekwencję efektów na kształcie bevel.  
6. Utwórz niestandardowy `UserPath`.  
7. Dodaj polecenia przemieszczania do `UserPath`.  
8. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod Javascript pokazuje, jak zastosować efekt `PathFootball` (ścieżka piłkarska) do kształtu:

```javascript
// Utwórz klasę Presentation, która reprezentuje plik PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Dodaje efekt animacji PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Tworzy rodzaj "przycisku".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Tworzy sekwencję efektów dla tego przycisku.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt będzie przemieszczał się dopiero po kliknięciu przycisku.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Dodaje polecenia ruchu, ponieważ utworzona ścieżka jest pusta.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Uzyskanie efektów animacji zastosowanych do kształtu**

Poniższe przykłady pokazują, jak użyć metody `getEffectsByShape` z klasy [Sequence](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/) aby uzyskać wszystkie efekty animacji zastosowane do kształtu.

**Przykład 1: Uzyskanie efektów animacji zastosowanych do kształtu na normalnym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak pobrać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Pobiera główną sekwencję animacji slajdu.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Pobiera pierwszy kształt na pierwszym slajdzie.
    var shape = firstSlide.getShapes().get_Item(0);

    // Pobiera efekty animacji zastosowane do kształtu.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Przykład 2: Uzyskanie wszystkich efektów animacji, w tym dziedziczonych z elementów zastępczych**

Jeśli kształt na normalnym slajdzie ma elementy zastępcze umieszczone na slajdzie układu i/lub slajdzie głównym, a do tych elementów zostały dodane efekty animacji, wszystkie efekty kształtu będą odtwarzane podczas prezentacji, w tym te dziedziczone z elementów zastępczych.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" i zastosowanym efektem **Random Bars**.

![Efekt animacji kształtu slajdu](slide-shape-animation.png)

Załóżmy również, że efekt **Split** jest zastosowany do elementu zastępczego stopki na slajdzie **layout**.

![Efekt animacji kształtu układu](layout-shape-animation.png)

I w końcu, efekt **Fly In** jest zastosowany do elementu zastępczego stopki na slajdzie **master**.

![Efekt animacji kształtu głównego slajdu](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak użyć metody `getBasePlaceholder` z klasy [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) aby uzyskać dostęp do elementów zastępczych kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym te dziedziczone z elementów zastępczych znajdujących się na slajdach układu i głównym.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Lot, dół
Type: 134, subtype: 45            // Podział, pionowo
Type: 126, subtype: 22            // Losowe paski, poziomo
```

## **Zmiana właściwości synchronizacji efektu animacji**

Aspose.Slides dla Node.js via Java umożliwia zmianę właściwości Timing efektu animacji.

To jest panel Synchronizacji Animacji w Microsoft PowerPoint:

![przykład_panelu_animacji](shape-animation.png)

Odpowiedniki pomiędzy PowerPoint Timing a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Effect#getTiming--) są następujące:

- Lista rozwijana PowerPoint Timing **Start** odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Timing#getTriggerType--).  
- PowerPoint Timing **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Timing#getDuration--). Czas trwania animacji (w sekundach) to całkowity czas potrzebny na wykonanie jednego cyklu animacji.  
- PowerPoint Timing **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).  

Tak zmieniasz właściwości Synchronizacji efektu:

1. [Apply](#apply-animation-to-shape) lub pobierz efekt animacji.  
2. Ustaw nowe wartości dla właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Effect#getTiming--) które są potrzebne.  
3. Zapisz zmodyfikowany plik PPTX.  

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Pobiera główną sekcję slajdu.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Pobiera pierwszy efekt z głównej sekcji.
    var effect = sequence.get_Item(0);
    // Zmienia TriggerType efektu na start po kliknięciu
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Zmienia czas trwania efektu
    effect.getTiming().setDuration(3.0);
    // Zmienia TriggerDelayTime efektu
    effect.getTiming().setTriggerDelayTime(0.5);
    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia te właściwości, aby umożliwić pracę z dźwiękami w efektach animacji: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Dodanie dźwięku efektu animacji**

Ten kod Javascript pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Dodaje dźwięk do kolekcji dźwięków prezentacji
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Pobiera główną sekwencję slajdu.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Pobiera pierwszy efekt z głównej sekwencji
    var firstEffect = sequence.get_Item(0);
    // Sprawdza, czy efekt nie ma dźwięku
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Dodaje dźwięk do pierwszego efektu
        firstEffect.setSound(effectSound);
    }
    // Pobiera pierwszą interaktywną sekwencję slajdu.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Ustawia flagę "Stop previous sound" efektu
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Wyodrębnienie dźwięku efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Pobierz główną sekwencję efektów.  
4. Wyodrębnij wbudowany [setSound(IAudio value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) do każdego efektu animacji.  

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Pobiera główną sekwencję slajdu.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Wyodrębnia dźwięk efektu jako tablicę bajtów
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Po animacji**

Aspose.Slides dla Node.js via Java umożliwia zmianę właściwości After animation efektu animacji.

To jest panel Efektu Animacji oraz rozszerzone menu w Microsoft PowerPoint:

![przykład_panelu_efektu_animacji](shape-after-animation.png)

Lista rozwijana PowerPoint Effect **After animation** odpowiada następującym właściwościom: 

- Metoda [setAfterAnimationType(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) opisuje typ After animation;  
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#Color).  
  * PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (domyślny typ after animation).  
  * PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Metoda [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) definiuje format koloru po animacji. Metoda ta współdziała z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#Color). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.  

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Pobiera pierwszy efekt z głównej sekwencji
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Zmienia typ animacji po zakończeniu na Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Ustawia kolor przyciemnienia po animacji
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Zapisuje plik PPTX na dysku
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animowanie tekstu**

Aspose.Slides udostępnia te właściwości, aby umożliwić pracę z blokiem *Animate text* efektu animacji:

- Metoda [setAnimateTextType(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) opisuje typ animacji tekstu efektu. Tekst kształtu może być animowany:  
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/animatetexttype/#ByWord))  
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/animatetexttype/#ByLetter))  
- Metoda [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) ustawia opóźnienie między częściami animowanego tekstu (słowami lub literami). Dodatnia wartość określa procent czasu trwania efektu, ujemna – opóźnienie w sekundach.  

Tak możesz zmienić właściwości Effect Animate text:

1. [Apply](#apply-animation-to-shape) lub pobierz efekt animacji.  
2. Ustaw metodę [setBuildType(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/buildtype/#AsOneObject), aby wyłączyć tryb animacji *By Paragraphs*.  
3. Ustaw nowe wartości dla metod [setAnimateTextType(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) oraz [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).  
4. Zapisz zmodyfikowany plik PPTX.  

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Pobiera pierwszy efekt z głównej sekwencji
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Zmienia typ animacji tekstu efektu na "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Zmienia typ animacji tekstu na "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Ustawia opóźnienie między słowami na 20% czasu trwania efektu
    firstEffect.setDelayBetweenTextParts(20.0);
    // Zapisuje plik PPTX na dysku
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mogę zapewnić zachowanie animacji przy publikowaniu prezentacji w internecie?**

[Export to HTML5](/slides/pl/nodejs-java/export-to-html5/) i włącz opcje odpowiedzialne za animacje [shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/setanimateshapes/) i [transition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/setanimatetransitions/). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

**Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?**

Kolejność animacji i kolejność rysowania są niezależne: efekt kontroluje moment i typ pojawiania/znika elementu, a [z-order](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getzorderposition/) określa, co co zasłania. Widoczny rezultat zależy od ich kombinacji. (Tak działa PowerPoint; model Aspose.Slides efekty‑i‑kształty podąża za tą samą logiką.)

**Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?**

Ogólnie [animacje są obsługiwane](/slides/pl/nodejs-java/convert-powerpoint-to-video/), ale rzadkie przypadki lub konkretne efekty mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów i wersji biblioteki.