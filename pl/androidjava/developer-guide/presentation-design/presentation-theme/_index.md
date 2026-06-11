---
title: Zarządzanie motywami prezentacji w Androidzie
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/androidjava/presentation-theme/
keywords:
- Motyw PowerPoint
- Motyw prezentacji
- Motyw slajdu
- Ustaw motyw
- Zmień motyw
- Zarządzaj motywem
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- Prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj motywami prezentacji w Aspose.Slides dla Androida przy użyciu Javy, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z spójną identyfikacją wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje właściwości elementów projektu. Wybierając motyw prezentacji, w zasadzie wybierasz określony zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw składa się z kolorów, [czcionek](/slides/pl/androidjava/powerpoint-fonts/), [stylów tła](/slides/pl/androidjava/presentation-background/) i efektów.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli nie podoba Ci się kolorystyka, możesz zmienić je, stosując nowe kolory w motywie. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SchemeColor).

Ten kod Java pokazuje, jak zmienić kolor akcentu w motywie:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Możesz określić efektywną wartość powstałego koloru w ten sposób:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Aby lepiej zademonstrować operację zmiany koloru, tworzymy kolejny element i przypisujemy mu kolor akcentu (z początkowej operacji). Następnie zmieniamy kolor w motywie:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Nowy kolor jest stosowany automatycznie w obu elementach.

### **Ustaw kolor motywu z dodatkowej palety**

Gdy stosujesz transformacje luminancji do głównego koloru motywu(1), powstają kolory z dodatkowej palety(2). Następnie możesz ustawiać i pobierać te kolory motywu.

![additional-palette-colors](additional-palette-colors.png)

**1** - Główne kolory motywu

**2** - Kolory z dodatkowej palety.

Ten kod Java demonstruje operację, w której kolory dodatkowej palety są uzyskiwane z głównego koloru motywu i używane w kształtach:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcent 4, jaśniejszy o 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, jaśniejszy o 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, jaśniejszy o 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, ciemniejszy o 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, ciemniejszy o 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapuj `SchemeColor` na kolory `IColorScheme`**

Pracując z [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/), możesz zauważyć, że zawiera następujące wartości kolorów motywu:

`Background1`, `Background2`, `Text1`, and `Text2`.

Jednakże `Presentation.getMasterTheme().getColorScheme()` zwraca [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/), który udostępnia odpowiadające kolory jako:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Ta różnica dotyczy jedynie nazewnictwa. Wartości odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nie ma dynamicznej konwersji między `Text`/`Background` a `Dark`/`Light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

Różnica w nazewnictwie pochodzi od terminologii Microsoft Office. Starsze wersje Office używały `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, podczas gdy nowsze wersje interfejsu wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa następujących specjalnych identyfikatorów (podobnych do tych stosowanych w PowerPoint):

* **+mn-lt** - Czcionka tekstu podstawowego (Latin) (Minor Latin Font)
* **+mj-lt** - Czcionka nagłówka (Latin) (Major Latin Font)
* **+mn-ea** - Czcionka tekstu podstawowego (East Asian) (Minor East Asian Font)
* **+mj-ea** - Czcionka nagłówka (East Asian) (Major East Asian Font)

Ten kod Java pokazuje, jak przypisać czcionkę łacińską do elementu motywu:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Ten kod Java pokazuje, jak zmienić czcionkę motywu prezentacji:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Czcionka we wszystkich polach tekstowych zostanie zaktualizowana.

{{% alert color="primary" title="Wskazówka" %}} 
Możesz chcieć zobaczyć [czcionki PowerPoint](/slides/pl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie aplikacja PowerPoint udostępnia 12 wstępnie zdefiniowanych teł, ale w typowej prezentacji zapisywane są tylko 3 z tych 12 teł.

![todo:image_alt_text](presentation-design_8.png)

Na przykład, po zapisaniu prezentacji w aplikacji PowerPoint, możesz uruchomić ten kod Java, aby dowiedzieć się, ile wstępnie zdefiniowanych teł znajduje się w prezentacji:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Używając właściwości [BackgroundFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) z klasy [FormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme), możesz dodać lub uzyskać dostęp do stylu tła w motywie PowerPoint.
{{% /alert %}} 

Ten kod Java pokazuje, jak ustawić tło dla prezentacji:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Przewodnik po indeksach**: 0 oznacza brak wypełnienia. Indeks zaczyna się od 1.

{{% alert color="primary" title="Wskazówka" %}} 
Możesz chcieć zobaczyć [tło PowerPoint](/slides/pl/androidjava/presentation-background/).
{{% /alert %}}

## **Zmień efekt motywu**

Motyw PowerPoint zazwyczaj zawiera 3 wartości dla każdej tablicy stylów. Tablice te są łączone w 3 efekty: subtelny, umiarkowany i intensywny. Na przykład, oto wynik, gdy efekty są zastosowane do konkretnego kształtu:

![todo:image_alt_text](presentation-design_10.png)

Używając 3 właściwości ([FillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) z klasy [FormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FormatScheme) możesz zmienić elementy w motywie (jeszcze elastyczniej niż opcje w PowerPoint).

Ten kod Java pokazuje, jak zmienić efekt motywu, modyfikując części elementów:

```java
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

Powstałe zmiany w kolorze wypełnienia, typie wypełnienia, efekcie cienia itp.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, zachowując niezmieniony motyw główny (za pośrednictwem [SlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidethememanager/)).

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

[Klonuj slajdy](/slides/pl/androidjava/clone-slides/) wraz z ich masterem do docelowej prezentacji. To zachowuje oryginalny master, układy oraz powiązany motyw, dzięki czemu wygląd pozostaje spójny.

**Jak mogę zobaczyć „efektywne” wartości po wszystkich dziedziczeniach i nadpisaniach?**

Użyj widoków „efektywnych” API [/slides/pl/androidjava/shape-effective-properties/](/slides/pl/androidjava/shape-effective-properties/) dla motywu/koloru/czcionki/efektu. Zwracają one rozstrzygnięte, ostateczne właściwości po zastosowaniu mastera oraz wszelkich lokalnych nadpisań.