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
- Motyw zewnętrzny
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
description: "Główne motywy prezentacji w Aspose.Slides dla Androida przy użyciu Javy, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji marki."
---
## **Wprowadzenie**

Temat prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome tematu odwołują się do tych współdzielonych definicji zamiast przechowywania każdej właściwości wizualnej jako stałej wartości, dzięki czemu zmiana tematu może zaktualizować wiele obiektów jednocześnie.

W Aspose.Slides temat na poziomie prezentacji jest dostępny poprzez [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Prezentacja może również zawierać nadpisania tematu na niższych poziomach. Master może nadpisać temat prezentacji poprzez [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterthememanager/), natomiast układ lub pojedynczy slajd może nadpisać odziedziczony temat poprzez [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). W praktyce skuteczny temat slajdu jest rozwiązywany w następującym łańcuchu dziedziczenia: temat prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty tematu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z tematem: przeglądanie tematu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie tematu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązywaniu dziedziczenia i nadpisań.

## **Przeglądanie tematu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) udostępnia schemat kolorów, schemat czcionek i schemat formatowania tematu poprzez [MasterTheme.getColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/) i [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/mastertheme/). Przeglądanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi z zewnętrznego źródła, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości tematu i podaje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w temacie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam skuteczny temat. Przejrzyj master powiązany ze slajdem i użyj przepływu pracy ze skutecznym tematem przedstawionego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów tematu**

Wypełnienia, linie i tekst świadome tematu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/), wszystkie obiekty, które nadal odwołują się do tego koloru tematu, zostaną rozwiązane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru tematu.

Poniższy przykład end‑to‑end tworzy kształt korzystający z `Accent4`, zmienia kolor tematu `Accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie tematu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty z koloru tematu, stosując przekształcenia kolorów. Aspose.Slides udostępnia te przekształcenia poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/colortransformoperation/).

![Główne kolory tematu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory tematu.  
**2** – Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów tematu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje przekształcenia luminancji do pięciu z nich i zapisuje wynik:

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

Warianty te pozostają oparte na kolorze tematu. Jeśli `Accent4` zmieni się później, przekształcone kolory zostaną ponownie obliczone na podstawie nowej wartości `Accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/) używa nazw `Text1`, `Background1`, `Text2` i `Background2`, podczas gdy [IColorScheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorscheme/) udostępnia te same sloty tematu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów tematu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek tematu**

Schemat czcionek tematu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pomocniczych czcionek dla treści. Metody [IFontScheme.getMajor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) i [IFontScheme.getMinor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontscheme/) udostępniają te zestawy.

Identyfikatory czcionek tematu zgodne z PowerPoint można używać w formatowaniu tekstu:

* `+mn-lt` – Czcionka ciała tekstu Latin (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka Latin (Major Latin Font)
* `+mn-ea` – Czcionka ciała tekstu East Asian (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka East Asian (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin i jedną linię tekstu ciała używającą pomocniczej czcionki Latin. Następnie zmienia czcionki tematu i zapisuje wynik:

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

Nagłówek korzysta z głównej czcionki, a tekst ciała z pomocniczej czcionki. Tekst, który ma explicite podaną nazwę czcionki zamiast identyfikatora tematu, nie przełączy się automatycznie po zmianie schematu czcionek tematu.

Zbiory głównych i pomocniczych czcionek mogą również zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zamieniać lub usuwać te mapowania, zobacz [Script‑Specific Theme Fonts](/slides/pl/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Więcej informacji o czcionkach w prezentacjach znajdziesz w [PowerPoint Fonts](/slides/pl/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie tematu**

Poniższe przepływy rozwiązuja różne problemy związane z tematami.

### **Zastosowanie zewnętrznego tematu do slajdów zależnych od mastera**

Użyj [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) gdy masz plik tematu PowerPoint (`.thmx`) i chcesz przeformatować każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation.getMasters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/), i przekaż ścieżkę pliku tematu do metody.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny temat do nowego mastera.  
1. Przypisuje nowy master do wszystkich slajdów, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny temat do slajdów zależnych od pierwszego mastera i zapisuje prezentację:

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

Nieprawidłowy, uszkodzony lub nieobsługiwany temat może spowodować [PptxReadException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxreadexception/). Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu tematu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisywane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i tematy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome tematu są rozwiązywane względem zewnętrznego tematu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne wyraźne formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami dziedziczonymi z nowego mastera.

Temat może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je poprzez [custom font sources](/slides/pl/androidjava/custom-font/), lub skonfiguruj [font substitution](/slides/pl/androidjava/font-substitution/).

To bezpośredni przepływ na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań tematu na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych tematów w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu przy pomocy [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) i [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/). Przechowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek tematów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje inny zewnętrzny temat do każdej grupy:

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do jakiegokolwiek innego mastera nie są przeformatowywane.

### **Zachowanie tematu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do docelowej prezentacji przy pomocy [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/), a następnie sklonuj slajd przy pomocy [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/) i sklonowanego mastera. To przenosi master, jego układy i powiązany temat razem.

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

Jest to preferowany przepływ, gdy slajd źródłowy musi wyglądać identycznie w miejscu docelowym. Proste sklonowanie treści na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane tematem.

### **Zastosowanie wartości tematu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z tematu źródłowego. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) i [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/) kopiują trzy główne komponenty tematu do nadpisania.

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

Zmienia to temat używany przez ten slajd bez modyfikacji tematu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości odziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/overridetheme/).

### **Zastosowanie nadpisania tematu do układu**

Nadpisanie na poziomie układu dotyczy slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można używać poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Używaj tematu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję, nadpisania układu, gdy jedna rodzina układów potrzebuje innego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierne nadpisania na poziomie slajdu utrudniają późniejsze globalne zmiany tematu.

## **Aktualizacja stylów tła tematu**

Wypełnienia tła tematu są przechowywane w [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). PowerPoint może prezentować więcej wyborów tła w interfejsie niż liczba definicji wypełnień fizycznie przechowywanych w tej kolekcji, ponieważ UI może łączyć wypełnienia tematu z kolorami tematu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla tematu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła, przejrzyj przechowywaną kolekcję i bieżący [Background.getStyleIndex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/). Indeks stylu `0` oznacza brak wypełnienia tematycznego; dodatnie wartości są odwołaniami do stylów tła tematu. To różni się od indeksowania kolekcji Java, gdzie `get_Item(0)` oznacza pierwszy przechowywany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje referencję tematycznego tła do pierwszego mastera i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu tematu odwoływanego przez master oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj indeksu stylu jako indeksu zero‑based w kolekcji. Unikaj również twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał ten sam wygląd w innym pliku; definicje stylów tematu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Dla bezpośredniego formatowania tła i dziedziczenia tła zobacz [Presentation Background](/slides/pl/androidjava/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów tematu**

Schemat formatu tematu zawiera oddzielne kolekcje wypełnień, linii i efektów udostępniane poprzez [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/), i [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iformatscheme/). Typowe tematy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty tematu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w Javie, indeks kolekcji jest zero‑based: `get_Item(0)` jest pierwszym przechowywanym stylem, a `get_Item(2)` trzecim. Indeksy referencji stylu kształtu to odrębna koncepcja, ujawniona przez [IShapeStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapestyle/). Modyfikacja stylu tematu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylu istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii tematu staje się czerwony, trzeci styl wypełnienia tematu staje się jednolitym zielonym lasem, a trzeci styl efektu uzyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wizualny rezultat nadal zależy od tego, które sloty stylu każdy kształt odwołuje i czy bezpośrednie formatowanie nadpisuje temat.

![Style efektów tematu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Określenie, czy skuteczne wypełnienie jednolite używa koloru tematu**

Wypełnienie może być przechowywane bezpośrednio na obiekcie lub odziedziczone z akapitu, układu, mastera, stylu tematu lub innego poziomu formatowania. Wywołaj [IFillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformat/) aby rozwiązać tę hierarchię w niezmienny [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformateffectivedata/). Najpierw sprawdź [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformateffectivedata/). Tylko gdy jest `FillType.Solid` należy odczytywać właściwości wypełnienia jednolitego.

Dla wypełnienia jednolitego, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformateffectivedata/) zwraca ostateczną wartość RGB po zastosowaniu dziedziczenia, wyszukiwania w temacie i przekształceń kolorów. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformateffectivedata/) zwraca odpowiadający logiczny slot [SchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/schemecolor/), taki jak `Text1` lub `Accent6`. Wartość `SchemeColor.NotDefined` oznacza, że skuteczne wypełnienie jednolite nie opiera się na kolorze schematu. W przepływie, w którym wypełnienia są albo kolorami tematu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje bezpośrednie wypełnienie RGB.

Nie używaj wyłącznie lokalnej wartości [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icolorformat/) do klasyfikacji wypełnienia. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość jest `NotDefined`, podczas gdy jego skuteczne wypełnienie dziedziczy kolor tematu i rozwiązuje się do `Text1` lub `Accent6`. Natomiast `getSolidFillSchemeColor` informuje, który logiczny slot tematu wygenerował skuteczny kolor, ale nie mówi, z którego poziomu (obiekt, akapit, układ, master czy inny) pochodził.

Poniższy przykład ładuje prezentację, audytuje zarówno wypełnienia kształtów, jak i wypełnienia fragmentów tekstu, wypisuje każdą ostateczną wartość RGB i powiązany kolor schematu oraz oznacza wypełnienia jednolite, które nie będą śledzić zmian kolorów tematu:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

Gałąź `NotDefined` dostarcza listę audytu wypełnień jednolitych, które nie zareagują na zmiany w slotach kolorów tematu. Przejrzyj te obiekty, gdy prezentacja ma podążać za nową paletą marki. Zgłoszona wartość RGB nadal pokazuje bieżący wygląd, a wartość schematu wyjaśnia, czy ten wygląd jest połączony z tematem.

Obiekty formatu skutecznego są migawkami. Po zmianie tematu prezentacji, nadpisania tematu lub dowolnego formatowania odziedziczonego, wywołaj ponownie `getEffective` i odczytaj nowy obiekt `IFillFormatEffectiveData` przed porównaniem lub raportowaniem kolorów.

## **Odczyt skutecznych wartości tematu**

Surowe obiekty tematu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/). Dla tła użyj [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/), a dla wypełnienia [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/).

Poniższy przykład odczytuje skuteczny temat, tło i pierwsze wypełnienie kształtu ze slajdu:

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz wyłącznie [Presentation.getMasterTheme](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), możesz przegapić master, układ, slajd lub nadpisanie kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego tematu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) przypisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują istniejące tematy.

**Czy mogę zastosować temat do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidethememanager/) slajdu i zainicjuj jego nadpisanie tematu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące tematy.

**Jaki jest najbezpieczniejszy sposób przeniesienia tematu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslidecollection/) oraz [ISlideCollection.addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidecollection/). To utrzymuje master, układy i temat razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseoverridethememanager/) dla tematu slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatu, takich jak [Background.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/background/) i [FillFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/). Te API zwracają rozwiązane wartości po zastosowaniu dziedziczenia i nadpisań.