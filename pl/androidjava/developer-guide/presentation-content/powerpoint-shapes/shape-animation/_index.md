---
title: Zastosuj animacje kształtów w prezentacjach na Androidzie
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu Aspose.Slides for Android via Java. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje to efekty wizualne, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](https://docs.aspose.com/slides/pl/androidjava/animated-charts/). Ożywiają one prezentacje lub ich elementy.

## **Dlaczego używać animacji w prezentacjach?**

* kontrolować przepływ informacji
* podkreślać ważne punkty
* zwiększać zainteresowanie lub zaangażowanie publiczności
* ułatwiać czytanie, przyswajanie lub przetwarzanie treści
* przyciągać uwagę czytelników lub widzów do istotnych części prezentacji

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentu** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw `Aspose.Slides.Animation`,
* Aspose.Slides udostępnia ponad **150 efektów animacji** w enumeracji [EffectType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttype). Efekty te są zasadniczo takie same (lub równoważne) jak te używane w programie PowerPoint.

## **Zastosowanie animacji do pola tekstowego**

Aspose.Slides for Android via Java umożliwia zastosowanie animacji do tekstu w kształcie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Uzyskaj główną sekwencję efektów.
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).
7. Ustaw właściwość `TextAnimation.BuildType` na wartość z enumeracji `BuildType`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `Fade` do AutoShape oraz ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaje nowy AutoShape z tekstem
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Dodaje efekt animacji Fade do kształtu
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje tekst kształtu według akapitów pierwszego poziomu
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Poza zastosowaniem animacji do tekstu, możesz także stosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph). Zobacz [**Animated Text**](/slides/pl/androidjava/animated-text/).

{{% /alert %}} 

## **Zastosowanie animacji do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe) na slajdzie.
4. Uzyskaj główną sekwencję efektów.
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe).
6. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation();
try {
    // Wczytuje obraz, który zostanie dodany do kolekcji obrazów prezentacji
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Dodaje efekt animacji Fly od lewej do ramki obrazu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosowanie animacji do kształtu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape). (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).
5. Utwórz sekwencję efektów na kształcie bevel.
6. Utwórz własny `UserPath`.
7. Dodaj polecenia przemieszczania do `UserPath`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `PathFootball` (path football) do kształtu:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Dodaje efekt animacji PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tworzy rodzaj "przycisku".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tworzy sekwencję efektów dla tego przycisku.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt będzie przesuwany dopiero po kliknięciu przycisku.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Dodaje polecenia ruchu, ponieważ utworzona ścieżka jest pusta.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pobieranie efektów animacji zastosowanych do kształtu**

Poniższe przykłady pokazują, jak używać metody `getEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/).

**Przykład 1: Pobranie efektów animacji zastosowanych do kształtu na normalnym slajdzie**

Poprzednio nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak pobrać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Pobiera główną sekwencję animacji slajdu.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Pobiera pierwszy kształt na pierwszym slajdzie.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Pobiera efekty animacji zastosowane do kształtu.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Przykład 2: Pobranie wszystkich efektów animacji, w tym dziedziczonych z placeholderów**

Jeśli kształt na normalnym slajdzie ma placeholdery położone na slajdzie układu i/lub szablonu, a do tych placeholderów dodano efekty animacji, wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" i zastosowanym efektem **Random Bars**.

![Efekt animacji kształtu slajdu](slide-shape-animation.png)

Załóżmy również, że efekt **Split** jest zastosowany do placeholdera stopki na slajdzie **układu**.

![Efekt animacji kształtu układu](layout-shape-animation.png)

Na koniec, efekt **Fly In** jest zastosowany do placeholdera stopki na slajdzie **szablonu**.

![Efekt animacji kształtu szablonu](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak używać metody `getBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) do uzyskania placeholderów kształtu i pobrania efektów animacji zastosowanych do kształtu stopki, w tym tych dziedziczonych z placeholderów znajdujących się na slajdach układu i szablonu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Zmiana właściwości czasowych efektu animacji**

Aspose.Slides for Android via Java umożliwia zmianę właściwości Timing (czasowych) efektu animacji.

To jest panel Timing animacji w programie Microsoft PowerPoint:

![przykład1_obraz](shape-animation.png)

- Lista rozwijana **Start** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- PowerPoint Timing **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getDuration--). Czas trwania animacji (w sekundach) to całkowity czas, jaki animacja potrzebuje, aby ukończyć jeden cykl.
- PowerPoint Timing **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Oto jak zmienić właściwości Timing efektu:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.
2. Ustaw nowe wartości potrzebnych właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IEffect#getTiming--).
3. Zapisz zmodyfikowany plik PPTX.

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Pobiera pierwszy efekt z głównej sekwencji.
    IEffect effect = sequence.get_Item(0);

    // Zmienia typ wyzwalania efektu na rozpoczęcie po kliknięciu
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Zmienia czas trwania efektu
    effect.getTiming().setDuration(3f);

    // Zmienia opóźnienie wyzwalania efektu
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Dodanie dźwięku do efektu animacji**

Ten kod Java pokazuje, jak dodać dźwięk efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Dodaje audio do kolekcji dźwięków prezentacji
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Pobiera pierwszy efekt z głównej sekwencji
    IEffect firstEffect = sequence.get_Item(0);

    // Sprawdza efekt pod kątem "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Dodaje dźwięk do pierwszego efektu
        firstEffect.setSound(effectSound);
    }

    // Pobiera pierwszą interaktywną sekwencję slajdu.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Ustawia flagę "Stop previous sound" efektu
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Wyodrębnienie dźwięku efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Uzyskaj główną sekwencję efektów. 
4. Wyodrębnij wbudowany [setSound(IAudio value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) w każdy efekt animacji.

Ten kod Java pokazuje, jak wyodrębnić dźwięk wbudowany w efekt animacji:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Wyodrębnia dźwięk efektu w tablicę bajtów
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Po animacji**

Aspose.Slides for Android via Java umożliwia zmianę właściwości After animation (po animacji) efektu animacji.

To jest panel efektu animacji i rozwinięte menu w programie Microsoft PowerPoint:

![przykład1_obraz](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list matches these properties:

- Właściwość [setAfterAnimationType(int value)] opisuje typ After animation:
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (domyślny typ po animacji);
  * PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Właściwość [setAfterAnimationColor(IColorFormat value)] definiuje format koloru po animacji. Działa ona w połączeniu z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.

Ten kod Java pokazuje, jak zmienić efekt po animacji:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera pierwszy efekt z głównej sekwencji
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Zmienia typ po animacji na kolor
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ustawia kolor przyciemnienia po animacji
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animowanie tekstu**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z blokiem *Animate text* efektu animacji:

- Właściwość [setAnimateTextType(int value)] opisuje typ animacji tekstu efektu. Tekst kształtu może być animowany:
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce] typ)
  - Po słowach ([AnimateTextType.ByWord] typ)
  - Po literach ([AnimateTextType.ByLetter] typ)
- Właściwość [setDelayBetweenTextParts(float value)] ustawia opóźnienie między częściami animowanego tekstu (słowami lub literami). Wartość dodatnia określa procent czasu trwania efektu. Wartość ujemna określa opóźnienie w sekundach.

Oto jak możesz zmienić właściwości Animate text efektu:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.
2. Ustaw właściwość [setBuildType(int value)] na wartość [BuildType.AsOneObject], aby wyłączyć tryb animacji *By Paragraphs*.
3. Ustaw nowe wartości właściwości [setAnimateTextType(int value)] oraz [setDelayBetweenTextParts(float value)].
4. Zapisz zmodyfikowany plik PPTX.

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera pierwszy efekt z głównej sekwencji
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Zmienia typ animacji tekstu efektu na "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Zmienia typ animacji tekstu efektu na "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Ustawia opóźnienie między słowami na 20% czasu trwania efektu
    firstEffect.setDelayBetweenTextParts(20f);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Jak zapewnić, że animacje są zachowane przy publikowaniu prezentacji w sieci?

[Export to HTML5](/slides/pl/androidjava/export-to-html5/) i włącz [options](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/) odpowiedzialne za animacje [shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [transition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

### Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?

Kolejność animacji i rysowania są niezależne: efekt kontroluje czas i typ pojawiania/zanikania, podczas gdy [z-order](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getZOrderPosition--) określa, co co zasłania. Widoczny rezultat definiowany jest przez ich kombinację. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides podąża za tą samą logiką.)

### Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?

Ogólnie [animacje są obsługiwane](/slides/pl/androidjava/convert-powerpoint-to-video/), ale w rzadkich przypadkach lub przy konkretnych efektach mogą być renderowane inaczej. Zaleca się przetestować używane efekty oraz wersję biblioteki.