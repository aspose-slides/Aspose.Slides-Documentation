---
title: "Zarządzanie motywami prezentacji na Androidzie"
linktitle: "Motyw prezentacji"
type: docs
weight: 10
url: /pl/androidjava/presentation-theme/
keywords:
- "Motyw PowerPoint"
- "Motyw prezentacji"
- "Motyw slajdu"
- "Ustawienie motywu"
- "Zmiana motywu"
- "Zarządzanie motywem"
- "Kolor motywu"
- "Dodatkowa paleta"
- "Czcionka motywu"
- "Styl motywu"
- "Efekt motywu"
- "PowerPoint"
- "OpenDocument"
- "Prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Zarządzaj motywami prezentacji w Aspose.Slides dla Androida przy użyciu Javy, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje właściwości elementów projektowych. Wybierając motyw prezentacji, zasadniczo wybierasz konkretny zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw składa się z kolorów, [fonts](/slides/pl/androidjava/powerpoint-fonts/), [background styles](/slides/pl/androidjava/presentation-background/) i efektów.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli nie podobają Ci się kolory, zmieniasz je, stosując nowe kolory dla motywu. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SchemeColor).

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Możesz w ten sposób określić efektywną wartość uzyskanego koloru:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Aby dodatkowo zilustrować operację zmiany koloru, tworzymy kolejny element i przypisujemy mu kolor akcentu (z początkowej operacji). Następnie zmieniamy kolor w motywie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Nowy kolor jest stosowany automatycznie w obu elementach.

### **Ustaw kolor motywu z dodatkowej palety**

Kiedy stosujesz przekształcenia luminancji do głównego koloru motywu(1), powstają kolory z dodatkowej palety(2). Następnie możesz ustawiać i pobierać te kolory motywu.

![additional-palette-colors](additional-palette-colors.png)

**1** – Główne kolory motywu

**2** – Kolory z dodatkowej palety.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcent 4, jaśniejszy 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, jaśniejszy 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, jaśniejszy 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, ciemniejszy 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, ciemniejszy 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapuj `SchemeColor` na kolory `IColorScheme`**

Podczas pracy z [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/), możesz zauważyć, że zawiera on następujące wartości kolorów motywu:

`Background1`, `Background2`, `Text1` i `Text2`.

Jednak `Presentation.getMasterTheme().getColorScheme()` zwraca [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/), który udostępnia odpowiadające kolory jako:

`Dark1`, `Dark2`, `Light1` i `Light2`.

Różnica polega wyłącznie na nazewnictwie. Te wartości odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nie ma dynamicznej konwersji między `Text`/`Background` a `Dark`/`Light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

To różnica w nazewnictwie pochodzi od terminologii Microsoft Office. Starsze wersje Office używały nazw `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, podczas gdy nowsze interfejsy wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa tych specjalnych identyfikatorów (podobnych do tych używanych w PowerPoint):

* **+mn-lt** – Czcionka tekstu podstawowego łacińska (Minor Latin Font)
* **+mj-lt** – Czcionka nagłówka łacińska (Major Latin Font)
* **+mn-ea** – Czcionka tekstu podstawowego wschodnioazjatycka (Minor East Asian Font)
* **+mj-ea** – Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Czcionka we wszystkich polach tekstowych zostanie zaktualizowana.

{{% alert color="info" title="TIP" %}} 
Możesz chcieć zobaczyć [PowerPoint fonts](/slides/pl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie aplikacja PowerPoint udostępnia 12 predefiniowanych teł, ale w typowej prezentacji zapisane są tylko 3 z tych 12 teł.

![todo:image_alt_text](presentation-design_8.png)

Na przykład po zapisaniu prezentacji w aplikacji PowerPoint możesz uruchomić ten kod Java, aby sprawdzić liczbę predefiniowanych teł w prezentacji:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Korzystając z właściwości [BackgroundFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) klasy [FormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme), możesz dodać lub uzyskać dostęp do stylu tła w motywie PowerPoint.
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Przewodnik po indeksach**: 0 oznacza brak wypełnienia. Indeks zaczyna się od 1.

{{% alert color="info" title="TIP" %}} 
Możesz chcieć zobaczyć [PowerPoint Background](/slides/pl/androidjava/presentation-background/).
{{% /alert %}}

## **Zmień efekt motywu**

Motyw PowerPoint zazwyczaj zawiera 3 wartości dla każdej tablicy stylów. Te tablice są łączone w 3 efekty: subtelny, umiarkowany i intensywny. Na przykład, oto rezultat po zastosowaniu efektów do konkretnego kształtu:

![todo:image_alt_text](presentation-design_10.png)

Korzystając z 3 właściwości ([FillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) klasy [FormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme) możesz zmieniać elementy w motywie (nawet bardziej elastycznie niż opcje w PowerPoint).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Otrzymane zmiany w kolorze wypełnienia, typie wypełnienia, efekcie cienia itp.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?

Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, zachowując niezmieniony motyw master (przez [SlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidethememanager/)).

### Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?

[Clone slides](/slides/pl/androidjava/clone-slides/) razem z ich masterem do docelowej prezentacji. Zachowuje to oryginalny master, układy i powiązany motyw, dzięki czemu wygląd pozostaje spójny.

### Jak mogę zobaczyć „efektywne” wartości po wszystkich dziedziczeniach i nadpisaniach?

Użyj widoków „effective” API [/slides/pl/androidjava/shape-effective-properties/](/slides/pl/androidjava/shape-effective-properties/) dla motywu/koloru/czcionki/efektu. Zwracają one rozwiązane, końcowe właściwości po zastosowaniu mastera oraz wszelkich lokalnych nadpisów.