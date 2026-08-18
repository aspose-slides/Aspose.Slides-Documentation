---
title: Zarządzanie motywami prezentacji na Androidzie
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/androidjava/presentation-theme/
keywords:
- motyw PowerPoint
- motyw prezentacji
- motyw slajdu
- ustaw motyw
- zmień motyw
- zarządzaj motywem
- kolor motywu
- dodatkowa paleta
- czcionka motywu
- styl motywu
- efekt motywu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla Androida w Javie, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z jednolitą identyfikacją wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, więc zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny przez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterthememanager/), podczas gdy układ lub pojedynczy slajd może nadpisać odziedziczony motyw przez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). W praktyce skuteczny motyw dla slajdu jest rozwiązywany poprzez ten łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Składniki motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdź motyw**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/). Sprawdzanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości motywu i podaje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj workflowu skutecznego motywu przedstawionego później w tym artykule, gdy mogą wystąpić nadpisania układu lub slajdu.

## **Zmień kolory motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy przykładowy kod end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` motywu na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Ponieważ prostokąt pozostał połączony z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje przez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty utworzone z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje transformacje luminancji do pięciu z nich i zapisuje wynik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zmieni się później, przekształcone kolory zostaną przeliczone na podstawie nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmień czcionki motywu**

Schemat czcionek motywu zawiera główny zestaw czcionek dla nagłówków oraz drugorzędny zestaw czcionek dla tekstu podstawowego. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPointem można używać w formatowaniu tekstu:

* `+mn-lt` – Czcionka podstawowa łacińska (Minor Latin Font)  
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)  
* `+mn-ea` – Czcionka podstawowa wschodnio‑azjatycka (Minor East Asian Font)  
* `+mj-ea` – Czcionka nagłówka wschodnio‑azjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu ciała używającą drugorzędnej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nagłówek korzysta z czcionki głównej, a tekst podstawowy z czcionki drugorzędnej. Tekst, który ma wyraźnie określoną nazwę czcionki zamiast identyfikatora motywu, nie zmieni się automatycznie po zmianie schematu czcionek motywu.

{{% alert color="info" title="Tip" %}}
Po więcej informacji o czcionkach w prezentacjach zobacz [PowerPoint Fonts](/slides/pl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopiuj lub zastosuj motyw**

Istnieją dwa typowe workflowy, które rozwiązują różne problemy.

### **Zachowaj źródłowy motyw przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny wygląd, sklonuj źródłowy master do docelowej prezentacji przy użyciu [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd przy użyciu [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Jest to preferowany workflow, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu na podstawie źródłowego motywu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

To zmienia motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową konstrukcję, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko w przypadku rzeczywistych wyjątków. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze globalne zmiany motywu.

## **Zaktualizuj style tła motywu**

Wypełnienia tła motywu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPointa dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję i bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/). Indeks stylu równy `0` oznacza brak wypełnienia tematycznego; wartości dodatnie to odwołania do stylów tła motywu. To różni się od indeksowania samej kolekcji Java, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie do motywu tła pierwszemu masterowi i zapisuje prezentację:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Widoczny rezultat zależy od wpisu motywu odwoływanego przez master oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu kolekcji zerowego. Unikaj także twardego kodowania numeru stylu pochodzącego z jednego pliku i zakładania, że będzie wyglądał tak samo w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
W kwestii bezpośredniego formatowania tła i dziedziczenia tła zobacz [Presentation Background](/slides/pl/androidjava/presentation-background/).
{{% /alert %}}

## **Zaktualizuj efekty motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów udostępniane przez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/) i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). Typowe tematy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Gdy uzyskujesz dostęp do tych kolekcji w Javie, indeks kolekcji jest zerowy: `get_Item(0)` to pierwszy zapisany styl, a `get_Item(2)` to trzeci. Indeksy odwołań stylu w kształcie to odrębna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, zmienia trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny efekt wizualny nadal zależy od tego, które sloty stylu są używane przez każdy kształt i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Odczytaj skuteczne wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, czego faktycznie używa slajd lub kształt po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/).

Poniższy przykład odczytuje skuteczny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz tylko [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), możesz pominąć master, układ, slajd lub nadpisanie kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego motyw nadpisania. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Przy przenoszeniu slajdu i zachowywaniu jego pierwotnego wyglądu, sklonuj źródłowy master do miejsca docelowego i sklonuj slajd z tym masterem przy użyciu [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/) oraz [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/). To zachowuje master, układy i motyw razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/) dla motywu slajdu lub układu oraz odpowiednich metod skutecznych danych dla obiektów formatu, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/). Te API zwracają rozwiązane wartości po zastosowaniu dziedziczenia i nadpisań.