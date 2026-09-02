---
title: Zarządzanie motywami prezentacji na Androidzie
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
- Zewnętrzny motyw
- THMX
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla Androida za pomocą Javy, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome tematu odwołują się do tych wspólnych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides, motyw na poziomie prezentacji jest dostępny poprzez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterthememanager/), podczas gdy układ lub pojedynczy slajd może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). W praktyce skuteczny motyw dla slajdu jest określany poprzez łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Składniki motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: sprawdzanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisów.

## **Sprawdź motyw**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatowania motywu za pośrednictwem [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/). Sprawdzanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i zgłasza, ile stylów tła, wypełnienia, linii i efektów jest zapisanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj scenariusza skutecznego motywu opisanego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmień kolory motywu**

Wypełnienia, linie i tekst świadome tematu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/), wszystkie obiekty nadal odwołujące się do tego koloru motywu są rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie ulegają zmianie w wyniku aktualizacji koloru motywu.

Poniższy przykład end-to-end tworzy kształt używający `Accent4`, zmienia kolor motywu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje połączony z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint wyprowadza jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje za pośrednictwem wyliczenia [ColorTransformOperation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/colortransformoperation/).

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

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zostanie zmieniony później, przeliczone kolory są wyliczane ponownie na podstawie nowej wartości `Accent4`.

### **Mapuj wartości `SchemeColor` na gniazda `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/) udostępnia te same gniazda motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych gniazd motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmień czcionki motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw czcionek pobocznych dla tekstu głównego. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` - Czcionka tekstu głównego łaciński (Minor Latin Font)
* `+mj-lt` - Czcionka nagłówka łaciński (Major Latin Font)
* `+mn-ea` - Czcionka tekstu głównego wschodnioazjatycka (Minor East Asian Font)
* `+mj-ea` - Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki łacińskiej motywu oraz jedną linię tekstu głównego używającą pobocznej czcionki łacińskiej. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek korzysta z czcionki głównej, a tekst główny z czcionki pobocznej. Tekst, który ma explicite określoną nazwę czcionki zamiast identyfikatora tematu, nie zostanie automatycznie zmieniony po zmianie schematu czcionek motywu.

Zbiory czcionek głównej i pobocznej mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby sprawdzić, dodać, zamienić lub usunąć te mapowania, zobacz [Script-Specific Theme Fonts](/slides/pl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Aby uzyskać więcej informacji o czcionkach w prezentacji, zobacz [Czcionki PowerPoint](/slides/pl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopiuj lub zastosuj motyw**

Poniższe scenariusze rozwiązują różne problemy związane z motywami.

### **Zastosuj zewnętrzny motyw do slajdów zależnych od Mastera**

Użyj [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz zmienić styl każdego slajdu zależnego od konkretnego mastera. Wybierz mastera z kolekcji [Presentation.getMasters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:
1. Tworzy nowy slajd master na podstawie wybranego mastera.
1. Zastosowuje zewnętrzny motyw do nowego mastera.
1. Przypisuje nowy master do wszystkich slajdów, które wcześniej zależały od wybranego mastera.
1. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów, które zależą od pierwszego mastera, i zapisuje prezentację:

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

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxReadException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxreadexception/). Waliduj ścieżki podane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przydzielane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome tematu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami dziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku wykonywania. Aby zapewnić spójne renderowanie i eksport, zainstaluj wymagane czcionki, udostępnij je poprzez [custom font sources](/slides/pl/androidjava/custom-font/) lub skonfiguruj [font substitution](/slides/pl/androidjava/font-substitution/).

Jest to bezpośredni scenariusz na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosuj różne zewnętrzne motywy w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu za pośrednictwem [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) i [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/). Przechowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do innych masterów nie są ponownie stylizowane.

### **Zachowaj źródłowy motyw przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj źródłowy master do prezentacji docelowej za pomocą [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd za pomocą [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

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

Jest to preferowany scenariusz, gdy źródłowy slajd musi wyglądać identycznie w miejscu docelowym. Proste klonowanie treści na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) kopiują trzy główne elementy motywu do nadpisania.

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

To zmienia motyw używany przez ten slajd, nie zmieniając motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można użyć poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić ten sam podstawowy projekt, nadpisania układu, gdy rodzina jednego układu wymaga innego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze przewidywanie globalnych zmian motywu.

## **Aktualizuj style tła motywu**

Wypełnienia tła motywu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła sprawdź przechowywaną kolekcję i bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/). Indeks stylu równy `0` oznacza brak wypełnienia tematycznego; wartości dodatnie są odwołaniami do stylów tła motywu. Jest to inne niż indeksowanie kolekcji Java bezpośrednio, gdzie `get_Item(0)` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład zgłasza liczbę dostępnych wypełnień tła, przypisuje odniesienie do tematycznego tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu motywu odwoływanego przez master oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie wpłynąć na ten slajd. Użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu zerowego. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie wyglądał tak samo w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Aby sformatować tło bezpośrednio i zarządzać dziedziczeniem tła, zobacz [Presentation Background](/slides/pl/androidjava/presentation-background/).
{{% /alert %}}

## **Aktualizuj efekty motywu**

Schemat formatowania motywu zawiera osobne kolekcje stylów wypełnień, linii i efektów, udostępniane poprzez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/) i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Delikatne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Gdy uzyskujesz dostęp do tych kolekcji w Javie, indeks kolekcji jest zerowy: `get_Item(0)` to pierwszy zapisany styl, a `get_Item(2)` to trzeci. Indeksy odwołań stylu kształtu to odrębna koncepcja, udostępniana przez [IShapeStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym leśnym, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wygląd nadal zależy od tego, które sloty stylu każdy kształt odwołuje i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Odczytaj skuteczne wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na konkretnym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/).

Poniższy przykład odczytuje skuteczny motyw, tło oraz pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych skutecznych do diagnostyki renderingu, walidacji i porównań. Jeśli sprawdzasz tylko [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), możesz przegapić master, układ, slajd lub nadpisanie kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) przepisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują istniejące motywy.

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Przy przenoszeniu slajdu i zachowaniu jego oryginalnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/) oraz [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/). Dzięki temu master, układy i motyw pozostają razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/) dla slajdu lub układu oraz odpowiednich metod skutecznych danych dla obiektów formatu, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/). Te API zwracają wartości po rozwiązaniu dziedziczenia i nadpisań.