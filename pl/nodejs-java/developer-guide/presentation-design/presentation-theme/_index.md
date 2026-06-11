---
title: Zarządzanie motywami prezentacji w JavaScript
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj motywy prezentacji w JavaScript przy użyciu Aspose.Slides dla Node.js, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje właściwości elementów projektowych. Wybierając motyw prezentacji, zasadniczo wybierasz konkretny zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw składa się z kolorów, [czcionek](/slides/pl/nodejs-java/powerpoint-fonts/), [stylów tła](/slides/pl/nodejs-java/presentation-background/) oraz efektów.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli nie podoba Ci się zestaw kolorów, możesz je zmienić, stosując nowe kolory w motywie. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SchemeColor).

Ten kod JavaScript pokazuje, jak zmienić kolor akcentu w motywie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Możesz określić efektywną wartość powstałego koloru w ten sposób:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Aby dodatkowo zademonstrować operację zmiany koloru, tworzymy kolejny element i przypisujemy mu kolor akcentu (z początkowej operacji). Następnie zmieniamy kolor w motywie:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Nowy kolor jest stosowany automatycznie w obu elementach.

### **Ustaw kolor motywu z dodatkowej palety**

Kiedy stosujesz transformacje luminancji do głównego koloru motywu(1), powstają kolory z dodatkowej palety(2). Następnie możesz ustawiać i odczytywać te kolory motywu. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Główne kolory motywu  
**2** - Kolory dodatkowej palety.

Ten kod JavaScript demonstruje operację, w której kolory dodatkowej palety są uzyskiwane z głównego koloru motywu i później używane w kształtach:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Akcent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Akcent 4, jaśniejszy 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Akcent 4, jaśniejszy 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Akcent 4, jaśniejszy 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Akcent 4, ciemniejszy 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Akcent 4, ciemniejszy 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Mapowanie `SchemeColor` na kolory `ColorScheme`**

Podczas pracy z [SchemeColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/schemecolor/) możesz zauważyć, że zawiera on następujące wartości kolorów motywu:

`Background1`, `Background2`, `Text1` i `Text2`.

Jednak `Presentation.getMasterTheme().getColorScheme()` zwraca [ColorScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/colorscheme/), który udostępnia odpowiadające kolory jako:

`Dark1`, `Dark2`, `Light1` i `Light2`.

Różnica dotyczy jedynie nazewnictwa. Wartości te odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nie istnieje dynamiczna konwersja między `Text`/`Background` a `Dark`/`Light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

Różnica w nazewnictwie wynika z terminologii Microsoft Office. Starsze wersje Office używały nazw `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, podczas gdy nowsze wersje interfejsu wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa następujących specjalnych identyfikatorów (podobnych do tych stosowanych w PowerPoint):

* **+mn-lt** - Czcionka ciała łacińska (Minor Latin Font)
* **+mj-lt** - Czcionka nagłówka łacińska (Major Latin Font)
* **+mn-ea** - Czcionka ciała wschodnioazjatycka (Minor East Asian Font)
* **+mj-ea** - Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Ten kod JavaScript pokazuje, jak przypisać czcionkę łacińską do elementu motywu:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Ten kod JavaScript pokazuje, jak zmienić czcionkę motywu prezentacji:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Czcionka we wszystkich polach tekstowych zostanie zaktualizowana.

{{% alert color="primary" title="Wskazówka" %}} 
Możesz chcieć zobaczyć [czcionki PowerPoint](/slides/pl/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie aplikacja PowerPoint udostępnia 12 predefiniowanych teł, ale w typowej prezentacji zapisane są tylko 3 z tych 12 tła. 

![todo:image_alt_text](presentation-design_8.png)

Na przykład, po zapisaniu prezentacji w aplikacji PowerPoint, możesz uruchomić ten kod JavaScript, aby ustalić liczbę predefiniowanych tła w prezentacji:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Używając właściwości [BackgroundFillStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) z klasy [FormatScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme), możesz dodać lub uzyskać dostęp do stylu tła w motywie PowerPoint.
{{% /alert %}} 

Ten kod JavaScript pokazuje, jak ustawić tło dla prezentacji:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Przewodnik po indeksie**: 0 oznacza brak wypełnienia. Indeks zaczyna się od 1.

{{% alert color="primary" title="Wskazówka" %}} 
Możesz chcieć zobaczyć [tło PowerPoint](/slides/pl/nodejs-java/presentation-background/).
{{% /alert %}}

## **Zmień efekt motywu**

Motyw PowerPoint zazwyczaj zawiera 3 wartości dla każdej tablicy stylów. Tablice te są łączone w te 3 efekty: subtelny, umiarkowany i intensywny. Na przykład, tak wygląda rezultat po zastosowaniu efektów do konkretnego kształtu:

![todo:image_alt_text](presentation-design_10.png)

Używając 3 właściwości ([FillStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) z klasy [FormatScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FormatScheme) możesz zmieniać elementy w motywie (nawet elastyczniej niż opcje w PowerPoint).

Ten kod JavaScript pokazuje, jak zmienić efekt motywu, modyfikując części elementów:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Wynikowe zmiany w kolorze wypełnienia, typie wypełnienia, efekcie cienia itp.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**  
Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, pozostawiając motyw mastera niezmieniony (poprzez [SlideThemeManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidethememanager/)).

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**  
[Klony slajdów](/slides/pl/nodejs-java/clone-slides/) wraz z ich masterem do docelowej prezentacji. To zachowuje oryginalny master, układy i powiązany motyw, dzięki czemu wygląd pozostaje spójny.

**Jak mogę zobaczyć „efektywne” wartości po wszystkich dziedziczeniach i nadpisaniach?**  
Użyj widoków API o nazwie ["effective"](/slides/pl/nodejs-java/shape-effective-properties/) dla motywu/koloru/czcionki/efektu. Zwracają one rozstrzygnięte, ostateczne właściwości po zastosowaniu mastera oraz wszelkich lokalnych nadpisów.