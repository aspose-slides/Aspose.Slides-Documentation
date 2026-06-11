---
title: Zastosowanie animacji kształtów w prezentacjach na Androidzie
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
description: "Odkryj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje są efektami wizualnymi, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](https://docs.aspose.com/slides/pl/androidjava/animated-charts/). Ożywiają prezentacje i ich elementy.

## **Dlaczego używać animacji w prezentacjach?**

* kontrolować przepływ informacji  
* podkreślać ważne punkty  
* zwiększać zainteresowanie lub zaangażowanie publiczności  
* uczynić treść łatwiejszą do czytania, przyswajania lub przetwarzania  
* przyciągać uwagę czytelników lub widzów do ważnych części prezentacji  

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **podkreślenia** i **ścieżek ruchu**.

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw `Aspose.Slides.Animation`,  
* Aspose.Slides zapewnia ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttype). Efekty te są zasadniczo takie same (lub równoważne) jak używane w PowerPoint.

## **Zastosowanie animacji do TextBox**

Aspose.Slides dla Androida przy użyciu Java umożliwia zastosowanie animacji do tekstu w kształcie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).  
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Uzyskaj główną sekwencję efektów.  
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).  
7. Ustaw właściwość `TextAnimation.BuildType` na wartość z wyliczenia `BuildType`.  
8. Zapisz prezentację na dysk jako plik PPTX.  

Ten kod Java pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```java
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
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 
Poza stosowaniem animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph). Zobacz [**Animated Text**](/slides/pl/androidjava/animated-text/).
{{% /alert %}} 

## **Zastosowanie animacji do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe) na slajdzie.  
4. Uzyskaj główną sekwencję efektów.  
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe).  
6. Zapisz prezentację na dysk jako plik PPTX.  

Ten kod Java pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation();
try {
    // Wczytuje obraz, który ma zostać dodany do kolekcji obrazów prezentacji
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
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastosowanie animacji do kształtu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape).  
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape) (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).  
5. Utwórz sekwencję efektów na kształcie bevel.  
6. Utwórz niestandardowy `UserPath`.  
7. Dodaj polecenia przemieszczania do `UserPath`.  
8. Zapisz prezentację na dysk jako plik PPTX.  

Ten kod Java pokazuje, jak zastosować efekt `PathFootball` (path football) do kształtu:

```java
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

    // Tworzy pewnego rodzaju "przycisk".
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

## **Uzyskaj efekty animacji zastosowane do kształtu**

Poniższe przykłady pokazują, jak używać metody `getEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/) aby uzyskać wszystkie efekty animacji zastosowane do kształtu.

**Przykład 1: Uzyskaj efekty animacji zastosowane do kształtu na zwykłym slajdzie**

Poprzednio nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak uzyskać efekty zastosowane do pierwszego kształtu na pierwszym zwykłym slajdzie w prezentacji `AnimExample_out.pptx`.

```java
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

**Przykład 2: Uzyskaj wszystkie efekty animacji, w tym dziedziczone z placeholderów**

Jeśli kształt na zwykłym slajdzie posiada placeholdery znajdujące się na slajdzie układu i/lub slajdzie głównym, a do tych placeholderów dodano efekty animacji, wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" i efekt **Random Bars** jest zastosowany do tego kształtu.

![Slide shape animation effect](slide-shape-animation.png)

Załóżmy również, że efekt **Split** jest zastosowany do placeholdera stopki na slajdzie **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Na koniec, efekt **Fly In** jest zastosowany do placeholdera stopki na slajdzie **master**.

![Master shape animation effect](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak używać metody `getBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) aby uzyskać dostęp do placeholderów kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym dziedziczone z placeholderów znajdujących się na slajdach układu i głównych.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Pobierz efekty animacji kształtu na normalnym slajdzie.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Pobierz efekty animacji placeholdera na slajdzie układu.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Pobierz efekty animacji placeholdera na slajdzie master.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
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

## **Zmień właściwości czasowe efektu animacji**

Aspose.Slides dla Androida przy użyciu Java umożliwia zmianę właściwości Timing efektu animacji.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

- Lista rozwijana **Start** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- PowerPoint Timing **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getDuration--). Czas trwania animacji (w sekundach) to całkowity czas potrzebny na ukończenie jednego cyklu.  
- PowerPoint Timing **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Tak zmienisz właściwości Timing efektu:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.  
2. Ustaw nowe wartości dla potrzebnych właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IEffect#getTiming--).  
3. Zapisz zmodyfikowany plik PPTX.  

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Pobiera pierwszy efekt głównej sekwencji.
    IEffect effect = sequence.get_Item(0);

    // Zmienia TriggerType efektu na start przy kliknięciu
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

Aspose.Slides udostępnia następujące właściwości, aby umożliwić pracę z dźwiękami w efektach animacji: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Dodaj dźwięk efektu animacji**

Ten kod Java pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Dodaje dźwięk do kolekcji audio prezentacji
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Pobiera pierwszy efekt głównej sekwencji
    IEffect firstEffect = sequence.get_Item(0);

    // Sprawdza, czy efekt nie ma dźwięku ("No Sound")
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

### **Wyodrębnij dźwięk efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).  
2. Uzyskaj odwołanie do slajdu przez jego indeks.  
3. Uzyskaj główną sekwencję efektów.  
4. Wyodrębnij wbudowany w każdy efekt animacji [setSound(IAudio value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

```java
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

        // Wyodrębnia dźwięk efektu w tablicy bajtów
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Po animacji**

Aspose.Slides dla Androida przy użyciu Java umożliwia zmianę właściwości After animation efektu animacji.

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list matches these properties: 

- Właściwość [setAfterAnimationType(int value)] opisująca typ After animation:
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (domyślny typ po animacji);  
  * PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- Właściwość [setAfterAnimationColor(IColorFormat value)] definiująca format koloru po animacji. Działa w połączeniu z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.  

Ten kod Java pokazuje, jak zmienić efekt po animacji:

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Pobiera pierwszy efekt głównej sekwencji
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Zmienia typ po animacji na Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ustawia kolor przyciemnienia po animacji
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Zapisuje plik PPTX na dysku
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animuj tekst**

Aspose.Slides udostępnia następujące właściwości, aby umożliwić pracę z blokiem *Animate text* efektu animacji:

- Właściwość [setAnimateTextType(int value)] opisująca typ animacji tekstu efektu. Tekst kształtu może być animowany:
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) typ)  
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/animatetexttype/#ByWord) typ)  
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/animatetexttype/#ByLetter) typ)  
- Właściwość [setDelayBetweenTextParts(float value)] ustawia opóźnienie pomiędzy częściami animowanego tekstu (słowa lub litery). Pozytywna wartość określa procent czasu trwania efektu. Negatywna wartość określa opóźnienie w sekundach.  

Tak możesz zmienić właściwości Effect Animate text:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.  
2. Ustaw właściwość [setBuildType(int value)] na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/buildtype/#AsOneObject), aby wyłączyć tryb animacji *By Paragraphs*.  
3. Ustaw nowe wartości dla właściwości [setAnimateTextType(int value)] oraz [setDelayBetweenTextParts(float value)].  
4. Zapisz zmodyfikowany plik PPTX.  

```java
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
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

**Jak zapewnić, że animacje zostaną zachowane przy publikowaniu prezentacji w sieci?**

[Export to HTML5](/slides/pl/androidjava/export-to-html5/) i włącz [opcje](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/) odpowiedzialne za animacje [shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) oraz [transition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

**Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?**

Animacja i kolejność rysowania są niezależne: efekt kontroluje moment i typ pojawiania/zanikania, natomiast [z-order](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getZOrderPosition--) określa, co co zasłania. Widoczny rezultat jest określany przez ich połączenie. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides podąża za tym samym logiką.)

**Czy istnieją ograniczenia przy konwertowaniu animacji do wideo dla niektórych efektów?**

Ogólnie [animacje są obsługiwane](/slides/pl/androidjava/convert-powerpoint-to-video/), ale rzadkie przypadki lub specyficzne efekty mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów oraz wersji biblioteki.