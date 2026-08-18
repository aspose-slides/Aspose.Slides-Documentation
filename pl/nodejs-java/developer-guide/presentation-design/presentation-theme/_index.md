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
description: "Twórz, dostosowuj i konwertuj pliki PowerPoint w JavaScript z Aspose.Slides dla Node.js, zarządzając głównymi motywami prezentacji i zapewniając spójną identyfikację wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych wspólnych definicji zamiast przechowywania każdej właściwości wizualnej jako stałej wartości, więc zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getmastertheme/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseoverridethememanager/). W praktyce skuteczny motyw dla slajdu jest rozwiązywany w następującej kolejności dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Elementy motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzenie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/mastertheme/). Sprawdzenie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów mogą się różnić.

Poniższy przykład odczytuje główne właściwości motywu i raportuje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj przepływu pracy z efektywnym motywem przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/colorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, są rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy kompleksowy przykład tworzy kształt używający `Accent4`, zmienia kolor motywu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Ponieważ prostokąt pozostaje połączony z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użycie kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty wyprodukowane z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów na bazie `Accent4`, stosuje transformacje luminancji do pięciu z nich i zapisuje wynik:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Warianty te pozostają oparte na kolorze motywu. Jeśli `Accent4` zostanie później zmieniony, przeliczone kolory zostaną zaktualizowane na nową wartość `Accent4`.

### **Mapowanie wartości `SchemeColor` na pozycje `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [ColorScheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/colorscheme/) udostępnia te same pozycje motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych pozycji motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera główny zestaw czcionek dla nagłówków oraz poboczny zestaw czcionek dla tekstu podstawowego. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontscheme/) i [FontScheme.getMinor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontscheme/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka podstawowa Latin (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka Latin (Major Latin Font)
* `+mn-ea` – Czcionka podstawowa East Asian (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka East Asian (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin oraz jedną linię tekstu podstawowego używającą pobocznej czcionki Latin. Następnie zmienia czcionki motywu i zapisuje wynik:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nagłówek korzysta z czcionki głównej, a tekst podstawowy z czcionki pobocznej. Tekst, który ma explicite określoną nazwę czcionki zamiast identyfikatora motywu, nie zostanie automatycznie przełączony po zmianie schematu czcionek motywu.

{{% alert color="info" title="Tip" %}}
Więcej informacji o czcionkach w prezentacjach znajdziesz w [PowerPoint Fonts](/slides/pl/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motywu**

Istnieją dwa typowe przepływy pracy, które rozwiązują różne problemy.

### **Zachowanie motywu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny wygląd, sklonuj master źródłowy do prezentacji docelowej za pomocą [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslidecollection/), a następnie sklonuj slajd za pomocą [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) i sklonowanego mastera. Dzięki temu master, jego układy i powiązany motyw zostaną przeniesione razem.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Jest to zalecany przepływ, gdy slajd źródłowy musi wyglądać identycznie w miejscu docelowym. Proste sklonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Zmiana ta wpływa na motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/overridetheme/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można użyć poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową stylistykę, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko w rzeczywistych wyjątkach. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/formatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba fizycznie przechowywanych definicji w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję i bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia z motywu; wartości dodatnie są odwołaniami do stylów tła motywu. Jest to inne niż indeksowanie kolekcji JavaScript, gdzie indeks `0` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje dostępny licznik wypełnień tła, przypisuje odwołanie do stylu tła motywu pierwszemu masterowi i zapisuje prezentację:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Widoczny rezultat zależy od wpisu motywu, do którego odwołuje się master oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu kolekcji zerowego. Unikaj również twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał ten sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/nodejs-java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów, udostępniane poprzez [FormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/formatscheme/) i [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/formatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę elementów.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Gdy uzyskujesz dostęp do tych kolekcji w JavaScript, indeks kolekcji jest zerowy: indeks `0` to pierwszy zapisany styl, a indeks `2` to trzeci. Indeksy odniesień stylu kształtu to odrębna koncepcja, udostępniona poprzez [ShapeStyle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wizualny rezultat nadal zależy od tego, które sloty stylu każdy kształt odwołuje oraz czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Odczyt skutecznych wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/).

Poniższy przykład odczytuje skuteczny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor");
        }
    }
} finally {
    presentation.dispose();
}
```

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzisz tylko [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getmastertheme/), możesz pominąć master, układ, slajd lub nadpisanie kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**  
Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**  
Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj master źródłowy do miejsca docelowego i sklonuj slajd z tym masterem, używając [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslidecollection/) oraz [SlideCollection.addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/). Dzięki temu master, układy i motyw pozostaną razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**  
Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseoverridethememanager/) dla motywu slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatu, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/). Te API zwracają rozwiązane wartości po zastosowaniu dziedziczenia i nadpisań.