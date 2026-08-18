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
description: "Główne motywy prezentacji w Aspose.Slides dla Javy, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z jednolitą identyfikacją marki."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/). W praktyce efektywny motyw dla slajdu jest rozwiązywany według tego łańcucha dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze przepływy pracy z motywem: sprawdzenie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt efektywnych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzenie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/mastertheme/). Sprawdzenie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów mogą się różnić.

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam efektywny motyw. Sprawdź master powiązany ze slajdem i użyj przepływu pracy z efektywnym motywem przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icolorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

Poniższy przykład end‑to‑end tworzy kształt używający `Accent4`, zmienia kolor motywu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje efektywny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użycie kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** - Główne kolory motywu.  
**2** - Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów motywu.

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

Te warianty nadal opierają się na kolorze motywu. Jeśli `Accent4` zmieni się później, przekształcone kolory zostaną ponownie przeliczone z nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pobocznych czcionek dla tekstu ciała. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn‑lt` – czcionka ciała łacińska (Minor Latin Font)
* `+mj‑lt` – czcionka nagłówka łacińska (Major Latin Font)
* `+mn‑ea` – czcionka ciała wschodnioazjatycka (Minor East Asian Font)
* `+mj‑ea` – czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki łacińskiej motywu oraz jedną linię tekstu ciała używającą pobocznej czcionki łacińskiej. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za główną czcionką, a tekst ciała za czcionką poboczną. Tekst posiadający explicite nazwę czcionki zamiast identyfikatora motywu nie zostanie automatycznie przełączony po zmianie schematu czcionek motywu.

{{% alert color="info" title="Tip" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacji, zobacz [Czcionki PowerPoint](/slides/pl/java/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motywu**

Istnieją dwa typowe przepływy pracy, które rozwiązują różne problemy.

### **Zachowanie motywu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do prezentacji docelowej przy użyciu [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd przy użyciu [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

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

Jest to preferowany sposób, gdy slajd źródłowy ma wyglądać identycznie w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na swoim bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

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

Nadpisanie na poziomie układu dotyczy slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można wykorzystać poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslidethememanager/):

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

Użyj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów powinno współdzielić ten sam podstawowy projekt, nadpisania układu, gdy rodzina jednego układu wymaga odmiennego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze przewidywanie globalnych zmian motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba fizycznie zapisanych definicji w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję oraz bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia motywu; dodatnie wartości to odniesienia do stylów tła motywu. Jest to inne niż indeksowanie kolekcji Java, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje dostępną liczbę wypełnień tła, przypisuje odwołanie do motywu tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny wynik zależy od wpisu motywu odwoływanego przez master oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/) gdy potrzebujesz poznać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako zerowego indeksu kolekcji. Unikaj również twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał identyczny wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów udostępniane przez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/) i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iformatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w Javie, indeks kolekcji jest zerowy: `get_Item(0)` to pierwszy zapisany styl, a `get_Item(2)` to trzeci. Indeksy odniesień stylu kształtu to odrębna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu stanie się czerwony, trzeci styl wypełnienia motywu stanie się jednolitym zielonym lasem, a trzeci styl efektu zyska zewnętrzny cień o odległości 10 punktów. Dokładny rezultat wizualny wciąż zależy od tego, które sloty stylu odwołuje każdy kształt i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie ustawień linii, wypełnienia i cienia](presentation-design_11.png)

## **Odczyt efektywnych wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Efektywne wartości mówią, czego rzeczywiście używa slajd lub kształt po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/).

Poniższy przykład odczytuje efektywny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych efektywnych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz wyłącznie [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), możesz przegapić master, układ, slajd lub nadpisanie kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslidecollection/) oraz [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/). Dzięki temu master, układy i motyw pozostają razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseoverridethememanager/) dla motywu slajdu lub układu oraz odpowiednich metod efektywnych danych dla obiektów formatu, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/). Te API zwracają rozwiązane wartości po zastosowaniu dziedziczenia i nadpisań.