---
title: Zarządzanie motywami prezentacji w Javie
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla Javy umożliwiają tworzenie, dostosowywanie i konwertowanie plików PowerPoint z jednolitą identyfikacją wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, więc zmiana motywu może zaktualizować wiele obiektów jednocześnie.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny przez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw przez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/). W praktyce skuteczny motyw dla slajdu jest rozwiązywany w łańcuchu dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt wartości efektywnych po rozwiązaniu dziedziczenia i nadpisań.

## **Przeglądanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatu motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/). Przeglądanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i raportuje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam efektywny motyw. Przeglądnij master powiązany ze slajdem i użyj workflowu efektywnego motywu przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icolorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiążone względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

Poniższy przykład end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor `Accent4` motywu na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje efektywny kolor wypełnienia:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie wpłyną już na to wypełnienie.

### **Użycie kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty pochodzące od głównych kolorów motywu.

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

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, natomiast [IColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pomocniczych czcionek dla tekstu podstawowego. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek tematycznych zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka podstawowa łacińska (Minor Latin Font)  
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)  
* `+mn-ea` – Czcionka podstawowa wschodnioazjatycka (Minor East Asian Font)  
* `+mj-ea` – Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki tematycznej oraz jedną linię tekstu podstawowego używającą pomocniczej łacińskiej czcionki tematycznej. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek korzysta z głównej czcionki, a tekst podstawowy z czcionki pomocniczej. Tekst, który ma wyraźnie określoną nazwę czcionki zamiast identyfikatora tematu, nie przełączy się automatycznie po zmianie schematu czcionek motywu.

Zbiór głównych i pomocniczych czcionek może także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zamieniać lub usuwać te mapowania, zobacz [Script‑Specific Theme Fonts](/slides/pl/java/script-specific-font-mappings/).

{{% alert color="info" title="Porada" %}}
Więcej informacji o czcionkach w prezentacjach znajdziesz w [PowerPoint Fonts](/slides/pl/java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motywu**

Istnieją dwa typowe scenariusze i rozwiązują one różne problemy.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do docelowej prezentacji za pomocą [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd za pomocą [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/) i sklonowanego mastera. Dzięki temu master, jego układy i powiązany motyw zostaną przeniesione razem.

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

Jest to zalecany sposób, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste sklonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane motywem.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Zmienia to motyw używany przez ten slajd bez wpływu na motyw dziedziczony przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów korzystających z tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Używaj motywu mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję projektową; nadpisanie układu, gdy jedna rodzina układów wymaga odmiennego stylowania; oraz nadpisanie slajdu tylko dla rzeczywistych wyjątków. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, przejrzyj przechowywaną kolekcję i aktualny [Background.getStyleIndex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/). Indeks stylu równy `0` oznacza brak tematycznego wypełnienia; wartości dodatnie wskazują referencje do stylów tła motywu. To różni się od indeksowania samej kolekcji Java, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje dostępny licznik wypełnień tła, przypisuje tematyczną referencję tła do pierwszego mastera i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu motywu odwołanego przez master oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie traktuj indeksu stylu jako indeksu zerowego w kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Porada" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów, udostępniane przez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/) i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/). Typowe tematy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien przeglądać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty tematyczne zastosowane do tego samego kształtu](presentation-design_10.png)

Podczas dostępu do tych kolekcji w Javie indeks kolekcji jest zerowy: `get_Item(0)` to pierwszy zapisany styl, a `get_Item(2)` to trzeci. Indeksy referencji stylów w kształcie to osobna koncepcja, udostępniona przez [IShapeStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapestyle/). Modyfikacja stylu tematu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla kształtów, które odwołują się do tych slotów, pierwszy styl linii tematu staje się czerwony, trzeci styl wypełnienia tematu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień z odległością 10 punktów. Dokładny wizualny rezultat nadal zależy od tego, które sloty stylu odwołuje każdy kształt i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Odczyt efektywnych wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Efektywne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/).

Poniższy przykład odczytuje efektywny motyw, tło oraz pierwsze wypełnienie kształtu ze slajdu:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Używaj danych efektywnych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz wyłącznie [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), możesz przeoczyć master, układ, slajd lub nadpisanie kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego motyw nadpisujący. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal będą dziedziczyć swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/) i [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/). Dzięki temu master, układy i motyw pozostaną razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/) dla motywu slajdu lub układu oraz odpowiednich metod zwracających efektywne dane dla obiektów formatowania, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/). Te API zwracają rozstrzygnięte wartości po zastosowaniu dziedziczenia i nadpisań.