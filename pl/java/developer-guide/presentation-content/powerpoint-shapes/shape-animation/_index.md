---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu Javy
linktitle: Animacja Kształtu
type: docs
weight: 60
url: /pl/java/shape-animation/
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
- Java
- Aspose.Slides
description: Odkryj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy. Wyróżnij się!
---
## **Wprowadzenie**

Animacje to efekty wizualne, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](https://docs.aspose.com/slides/pl/java/animated-charts/). Ożywiają prezentacje lub ich elementy. 

## **Dlaczego używać animacji w prezentacjach?**

Używając animacji, możesz 

* kontrolować przepływ informacji
* podkreślać ważne punkty
* zwiększać zainteresowanie lub uczestnictwo publiczności
* uczynić treść łatwiejszą do przeczytania, przyswojenia lub przetworzenia
* przyciągać uwagę czytelników lub widzów do ważnych części prezentacji

PowerPoint zapewnia wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **podkreślenia** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw `Aspose.Slides.Animation`,
* Aspose.Slides zapewnia ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effecttype). Efekty te są zasadniczo takie same (lub równoważne) jak te używane w PowerPoint.

## **Zastosowanie animacji do pola tekstowego**

Aspose.Slides dla Javy umożliwia zastosowanie animacji do tekstu w kształcie. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape). 
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Pobierz główną sekwencję efektów.
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape). 
7. Ustaw właściwość `TextAnimation.BuildType` na wartość z wyliczenia `BuildType`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

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

Oprócz stosowania animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph). Zobacz [**Animated Text**](/slides/pl/java/animated-text/).

{{% /alert %}} 

## **Zastosowanie animacji do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe) na slajdzie. 
4. Pobierz główną sekwencję efektów.
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe).
6. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation();
try {
    // Ładuje obraz do dodania w kolekcji obrazów prezentacji
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

    // Dodaje efekt animacji Fly z lewej do ramki obrazu
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosowanie animacji do kształtu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape). 
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape) (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).
5. Utwórz sekwencję efektów na kształcie bevel.
6. Utwórz własny `UserPath`.
7. Dodaj polecenia przemieszczania się do `UserPath`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod Java pokazuje, jak zastosować efekt `PathFootball` (ścieżka piłkarska) do kształtu:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Tworzy efekt PathFootball dla istniejącego kształtu od początku.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Dodaje efekt animacji PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tworzy pewnego rodzaju "przycisk".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tworzy sekwencję efektów dla tego przycisku.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt zostanie przesunięty dopiero po kliknięciu przycisku.
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

## **Pobranie efektów animacji zastosowanych do kształtu**

Poniższe przykłady pokazują, jak używać metody `getEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isequence/) w celu pobrania wszystkich efektów animacji zastosowanych do kształtu.

**Przykład 1: Pobranie efektów animacji zastosowanych do kształtu na normalnym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak pobrać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

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

Jeśli kształt na normalnym slajdzie ma placeholdery znajdujące się na slajdzie układu i/lub slajdzie głównym, a do tych placeholderów dodano efekty animacji, wówczas wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" i na kształt został zastosowany efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Załóżmy również, że efekt **Split** został zastosowany do placeholdera stopki na slajdzie **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Wreszcie, efekt **Fly In** został zastosowany do placeholdera stopki na slajdzie **master**.

![Master shape animation effect](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak używać metody `getBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) w celu uzyskania dostępu do placeholderów kształtu i pobrania efektów animacji zastosowanych do kształtu stopki, w tym dziedziczonych z placeholderów znajdujących się na slajdach layout i master.

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

Wyjście:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Zmiana właściwości czasu efektu animacji**

Aspose.Slides dla Javy pozwala zmienić właściwości Timing efektu animacji.

To jest panel Animation Timing w programie Microsoft PowerPoint:

![example1_image](shape-animation.png)

Oto odpowiedniki pomiędzy Timing w PowerPoint a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IEffect#getTiming--):

- Lista rozwijana **Start** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITiming#getTriggerType--). 
- Wartość **Duration** w PowerPoint Timing odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITiming#getDuration--) . Czas trwania animacji (w sekundach) to łączny czas potrzebny na zakończenie jednego cyklu animacji. 
- Wartość **Delay** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Tak zmieniasz właściwości Timing efektu:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw nowe wartości dla potrzebnych Ci właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IEffect#getTiming--).
3. Zapisz zmodyfikowany plik PPTX.

Ten kod Java demonstruje działanie:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Pobiera pierwszy efekt głównej sekwencji.
    IEffect effect = sequence.get_Item(0);

    // Zmienia TriggerType efektu, aby zaczynał się po kliknięciu
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Zmienia czas trwania efektu
    effect.getTiming().setDuration(3f);

    // Zmienia TriggerDelayTime efektu
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Dodanie dźwięku do efektu animacji**

Ten kod Java pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Dodaje dźwięk do kolekcji audio prezentacji
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Pobiera pierwszy efekt głównej sekwencji
    IEffect firstEffect = sequence.get_Item(0);

    // Sprawdza, czy efekt nie ma dźwięku
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Dodaje dźwięk do pierwszego efektu
        firstEffect.setSound(effectSound);
    }

    // Pobiera pierwszą interaktywną sekwencję slajdu.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Ustawia flagę „Stop previous sound” dla efektu
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Wyodrębnienie dźwięku efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Pobierz główną sekwencję efektów. 
4. Wyodrębnij wbudowany [setSound(IAudio value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) w każdy efekt animacji. 

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

        // Wyodrębnia dźwięk efektu jako tablicę bajtów
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Po animacji**

Aspose.Slides dla Javy pozwala zmienić właściwość After animation efektu animacji.

To jest panel Animation Effect oraz rozszerzone menu w programie Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Lista rozwijana **After animation** w PowerPoint Effect odpowiada następującym właściwościom: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) właściwość opisująca typ After animation:
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/java/com.aspose.slides/afteranimationtype/#Color);
  * Pozycja **Don't Dim** w PowerPoint odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/java/com.aspose.slides/afteranimationtype/#DoNotDim) (domyślny typ after animation);
  * Pozycja **Hide After Animation** w PowerPoint odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * Pozycja **Hide on Next Mouse Click** w PowerPoint odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) właściwość definiująca format koloru po animacji. Działa ona w połączeniu z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/java/com.aspose.slides/afteranimationtype/#Color). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.

Ten kod Java pokazuje, jak zmienić efekt po animacji:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera pierwszy efekt głównej sekwencji
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Zmienia typ animacji po zakończeniu na Color
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

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) opisuje typ animacji tekstu efektu. Tekst kształtu może być animowany:
  - Jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/java/com.aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/java/com.aspose.slides/animatetexttype/#ByWord) typ)
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ustawia opóźnienie pomiędzy częściami animowanego tekstu (słowami lub literami). Wartość dodatnia określa procent czasu trwania efektu. Wartość ujemna określa opóźnienie w sekundach.

Tak możesz zmienić właściwości Animate text efektu:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw właściwość [setBuildType(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextanimation/#setBuildType-int-) na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/buildtype/#AsOneObject) aby wyłączyć tryb animacji *By Paragraphs*.
3. Ustaw nowe wartości dla właściwości [setAnimateTextType(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) oraz [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Zapisz zmodyfikowany plik PPTX.

Ten kod Java demonstruje działanie:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera pierwszy efekt głównej sekwencji
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

### Jak mogę zapewnić, że animacje są zachowane przy publikowaniu prezentacji w sieci?

[Export to HTML5](/slides/pl/java/export-to-html5/) oraz włącz [opcje](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/) odpowiedzialne za animacje [kształtów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) i [przejść](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

### Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?

Kolejność animacji i rysowania są niezależne: efekt kontroluje czas i rodzaj pojawiania się/zanikania, podczas gdy [z-order](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getZOrderPosition--) określa, co co zasłania. Widoczny rezultat definiowany jest ich kombinacją. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides podąża za tą samą logiką.)

### Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?

Generalnie, [animacje są obsługiwane](/slides/pl/java/convert-powerpoint-to-video/), ale w rzadkich przypadkach lub przy konkretnych efektach mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów oraz wersji biblioteki.