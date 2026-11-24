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
- motyw zewnętrzny
- THMX
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
description: "Główne motywy prezentacji w Aspose.Slides dla Java do tworzenia, dostosowywania i konwertowania plików PowerPoint z jednolitą identyfikacją marki."
---
## **Wstęp**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych wspólnych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny za pośrednictwem [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/), podczas gdy układ lub pojedynczy slajd może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). W praktyce efektywny motyw dla slajdu jest rozwiązywany przez ten łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt efektywnych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Sprawdzanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatów motywu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). Sprawdzanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości motywu i zgłasza, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam efektywny motyw. Sprawdź master powiązany ze slajdem i użyj scenariusza efektywnego motywu przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiadający wpis w [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru motywu, są rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

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

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zastąpisz kolor schematu bezpośrednim kolorem na kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint wyprowadza jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/).

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

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zmieni się później, przeliczone kolory zostaną obliczone na nowo z nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na gniazda `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, natomiast [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) udostępnia te same gniazda motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych gniazd motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera główny zestaw czcionek dla nagłówków oraz poboczny zestaw czcionek dla tekstu podstawowego. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek motywu zgodne z PowerPoint można używać w formatowaniu tekstu:

* `+mn-lt` - Czcionka tekstu podstawowego łacińska (Minor Latin Font)
* `+mj-lt` - Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` - Czcionka tekstu podstawowego wschodnioazjatycka (Minor East Asian Font)
* `+mj-ea` - Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)
* `+mn-cs` - Czcionka tekstu podstawowego skryptu złożonego (Minor Complex Script Font)
* `+mj-cs` - Czcionka nagłówka skryptu złożonego (Major Complex Script Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu podstawowego używającą pobocznej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za główną czcionką, a tekst podstawowy podąża za czcionką poboczną. Tekst, który ma explicite nazwę czcionki zamiast identyfikatora motywu, nie przełączy się automatycznie, gdy schemat czcionek motywu ulegnie zmianie.

Główne i poboczne kolekcje czcionek mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby sprawdzić, dodać, zastąpić lub usunąć te mapowania, zobacz [Czcionki motywu specyficzne dla skryptów](/slides/pl/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacji, zobacz [Czcionki PowerPoint](/slides/pl/java/powerpoint-fonts/).
{{% /alert %}}

### **Rozwiązywanie odwołań do czcionek motywu**

Podczas sprawdzania tekstu [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) może zwrócić odwołanie do motywu, takie jak `+mn-lt`, zamiast nazwy rodziny czcionki. Wywołaj [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) z odpowiednimi [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/), aby rozwiązać to odwołanie. Prefiksy `+mj` i `+mn` wybierają odpowiednio główny i poboczny zestaw czcionek; przyrostki `-lt`, `-ea` i `-cs` wybierają ich łacińskie, wschodnioazjatyckie i skrypty złożone.

Uzyskaj efektywny motyw poprzez [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) na obiekcie, którego motyw ma zastosowanie do sprawdzanego tekstu. Dla zwykłego tekstu na slajdzie wywołaj tę metodę na slajdzie, aby kontekst obejmował dziedziczony motyw slajdu i lokalne nadpisania. Podczas sprawdzania układu lub samego mastera użyj jego własnego efektywnego motywu. Nie zakładaj, że motyw pierwszego mastera ma zastosowanie do każdego slajdu.

Poniższy przykład tworzy fragment tekstu, który explicite odwołuje się do pobocznej łacińskiej czcionki. Inicjalizuje schemat czcionek slajdu poprzez [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) i ustawia rodziny łacińskie głównej i pobocznej czcionki na `Arial` i `Calibri`, co sprawia, że wynik jest odtwarzalny bez pliku wejściowego.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Wyjściem jest `+mn-lt -> Calibri` a następnie `Verdana -> Verdana`. Przechowywane odwołanie pozostaje niezmienione, podczas gdy explicite nazwa rodziny jest zwracana bez zmian. Gdyby fragment używał `+mj-lt`, rozwiązałby się do `Arial` w tym motywie.

Rozwiązywanie odwołania do motywu identyfikuje rodzinę czcionki określoną przez motyw. Nie sprawdza dostępności czcionki ani nie określa pliku czcionki ostatecznie używanego po podstawieniu lub fallbacku glifów podczas renderowania. Zobacz [Sekwencję wyboru czcionki](/slides/pl/java/font-selection-sequence/) i [Podstawianie czcionek](/slides/pl/java/font-substitution/) dla tych oddzielnych kroków.

## **Kopiowanie lub zastosowanie motywu**

Poniższe scenariusze rozwiązują różne problemy związane z motywem.

### **Zastosowanie zewnętrznego motywu do slajdów zależnych od mastera**

Użyj [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz przeformatować każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku z motywem metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master oparty na wybranym masterze.
2. Stosuje zewnętrzny motyw do nowego mastera.
3. Przypisuje nowy master wszystkim slajdom, które wcześniej zależały od wybranego mastera.
4. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);

    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");
    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/). Waliduj ścieżki podane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy, które zależały od wybranego mastera, są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadomości motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je poprzez [niestandardowe źródła czcionek](/slides/pl/java/custom-font/), lub skonfiguruj [podstawianie czcionek](/slides/pl/java/font-substitution/).

Jest to bezpośredni scenariusz na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych motywów w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu poprzez [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) i [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). Przechowaj oryginalne odwołania do masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do innego mastera nie są przestylizowane.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do docelowej prezentacji przy pomocy [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd przy użyciu [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) i sklonowanego mastera. To przenosi master, jego układy oraz powiązany motyw razem.

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

Jest to preferowany scenariusz, gdy źródłowy slajd musi wyglądać identycznie w miejscu docelowym. Proste klonowanie treści na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane motywem.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na swoim bieżącym masterze i układzie, zainicjalizuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) kopiują trzy główne komponenty motywu do nadpisania.

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

Zmienia to motyw używany przez ten slajd bez zmiany motywu odziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości odziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową konstrukcję, nadpisania układu, gdy jedna rodzina układów wymaga odmiennego stylu, oraz nadpisania slajdu tylko w rzeczywistych wyjątkach. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze globalne zmiany motywu.

<!-- visual-explanation:presentation-theme:start -->
[![Motyw mastera zasila dwa układy; nadpisanie układu wpływa na jego slajdy, z wyjątkiem slajdu z bardziej lokalnym nadpisaniem.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

* Nadpisanie układu ma zastosowanie do slajdów używających tego układu, chyba że slajd dostarcza własne nadpisanie. Wartości oparte na motywie podążają za rozwiązanym schematem; obiekty explicite sformatowane mogą zachować lokalny wygląd. Trzymaj nadpisania tak wąsko, jak zamierzony wyjątek projektowy. *
<!-- visual-explanation:presentation-theme:end -->

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). PowerPoint może prezentować więcej opcji tła w interfejsie niż liczba definicji wypełnień fizycznie przechowywanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję oraz bieżącą [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia opartego na motywie; wartości dodatnie są odwołaniami do stylu tła motywu. To różni się od indeksowania samej kolekcji w Javie, gdzie `get_Item(0)` oznacza pierwszy przechowywany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnienia tła.

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

Widoczny wynik zależy od wpisu motywu, na który odwołuje się master, oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana wyłącznie tła mastera może nie zmieni tego slajdu. Użyj [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu zero‑based w kolekcji. Unikaj również twardego kodowania numeru stylu z jednego pliku i zakładania, że ma on ten sam wygląd w innym pliku; definicje stylu motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Aby sformatować tło bezpośrednio i zarządzać dziedziczeniem tła, zobacz [Tło prezentacji](/slides/pl/java/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje stylów wypełnień, linii i efektów udostępniane poprzez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Gdy uzyskujesz dostęp do tych kolekcji w Javie, indeks kolekcji jest zero‑based: `get_Item(0)` to pierwszy przechowywany styl, a `get_Item(2)` to trzeci. Indeksy referencji stylu kształtu to odrębna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wizualny wynik nadal zależy od tego, które sloty stylu każdy kształt odwołuje i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Wybór stylów wypełnienia i linii motywu dla kształtu**

Kształt może niezależnie wybrać wypełnienie i kontur poprzez [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) i [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Dla obu metod indeks `1` wybiera pierwszy wpis w odpowiedniej kolekcji motywu (`get_Item(0)`), a indeks `2` wybiera drugi (`get_Item(1)`).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Początkowe style | Zmień prawy kontur | Edytuj pierwsze wypełnienie motywu |
|:---:|:---:|:---:|
| ![Złote i niebieskie niebo prostokąty z dopasowanymi cienkimi ciemnoniebieskimi obramowaniami](theme-style-initial.png) | ![Niebieski niebo prostokąt ma teraz grube ciemnoczerwone obramowanie](theme-style-line-changed.png) | ![Lewy prostokąt jest teraz zielony, a oba obramowania niezmienione](theme-style-fill-changed.png) |

Wybór innego stylu linii zmienia tylko obramowanie prawego prostokąta. Edycja pierwszego wypełnienia motywu aktualizuje każdy kształt, który go używa. Tutaj tylko lewy prostokąt staje się zielony.

Na istniejącym kształcie lokalny kolor wypełnienia, kolor linii lub szerokość linii mogą nadpisać tę część stylu motywu. Jeśli zmiana indeksu stylu nie wywołuje widocznego efektu, sprawdź [bezpośrednie formatowanie](/slides/pl/java/shape-formatting/).

## **Określenie, czy efektywne wypełnienie jednolite używa koloru motywu**

Wypełnienie może być przechowywane bezpośrednio na obiekcie lub odziedziczone z akapitu, układu, mastera, stylu motywu lub innego poziomu formatowania. Wywołaj [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) aby rozwiązać tę hierarchię w niezmienny [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Najpierw sprawdź [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Tylko gdy jest `FillType.Solid`, czytaj właściwości wypełnienia jednolitego.

Dla wypełnienia jednolitego, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) zwraca ostateczną wyświetloną wartość RGB po dziedziczeniu, wyszukiwaniu w motywie i zastosowaniu transformacji kolorów. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) zwraca odpowiadające logiczne gniazdo [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/), takie jak `Text1` lub `Accent6`. Wartość `SchemeColor.NotDefined` oznacza, że efektywne wypełnienie jednolite nie opiera się na kolorze schematu. W scenariuszu, w którym wypełnienia są albo kolorami motywu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje wypełnienie bezpośrednie RGB.

Nie używaj lokalnej wartości [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) samodzielnie do klasyfikacji wypełnienia. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość to `NotDefined`, podczas gdy jego efektywne wypełnienie odziedzicza kolor motywu i rozwiązuje się do `Text1` lub `Accent6`. Natomiast `getSolidFillSchemeColor` informuje, które logiczne gniazdo motywu wygenerowało efektywny kolor, ale nie mówi, czy to gniazdo pochodzi od obiektu, akapitu, układu, mastera czy innego poziomu hierarchii formatowania.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gałąź `NotDefined` dostarcza listę audytu wypełnień jednolitych, które nie będą reagować na zmiany w slotach kolorów motywu. Przejrzyj te obiekty, gdy prezentacja musi podążać za nową paletą marki. Zgłoszona wartość RGB nadal pokazuje bieżący wygląd, a wartość schematu wyjaśnia, czy ten wygląd jest połączony z motywem.

Obiekty formatu efektywnego są migawkami. Po zmianie motywu prezentacji, nadpisania motywu lub jakiegokolwiek odziedziczonego formatowania, wywołaj ponownie `getEffective` i odczytaj nowy obiekt `IFillFormatEffectiveData` przed porównaniem lub raportowaniem kolorów.

## **Odczyt efektywnych wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Efektywne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), a dla wypełnienia użyj [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

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

Używaj danych efektywnych do diagnostyki renderowania, walidacji i porównań. Jeśli sprawdzasz tylko [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), możesz pominąć master, układ, slajd lub nadpisanie kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) ponownie przypisuje tylko slajdy, które zależą od wybranego mastera. Slajdy korzystające z innych masterów zachowują istniejące motywy.

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal będą dziedziczyć swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem przy użyciu [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) oraz [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). To utrzymuje master, układy i motyw razem.

**Jak mogę zobaczyć efektywne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) dla slajdu lub układu oraz odpowiednich metod danych efektywnych dla obiektów formatów, takich jak [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.