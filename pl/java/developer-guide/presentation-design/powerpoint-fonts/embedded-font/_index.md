---
title: Osadzanie czcionek w prezentacjach w Javie
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w programie PowerPoint przy użyciu Aspose.Slides for Java. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy program wyświetlający obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w docelowym systemie. Pomaga to zachować podziały wierszy, odstępy tekstu i układ slajdów.

Aspose.Slides for Java umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/) zwracanego przez [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getFontsManager--). Można także zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, które nie są używane w prezentacji.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że jej licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [getEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aby wyświetlić listę czcionek zapisanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [removeEmbeddedFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), a następnie zapisz prezentację.

Poniższy przykład wyświetla listę osadzonych czcionek w pliku `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Usunięcie osadzonej czcionki usuwa zapisane dane czcionki; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w docelowym systemie, tekst może nadal jej używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/java/font-substitution/), co może wpłynąć na układ.

## **Sprawdzanie danych czcionki i uprawnień do osadzania**

Użyj interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/) aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [IFontsManager.getFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getFonts--) aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [IFontData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontstyletype/) do [IFontsManager.getFontBytes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoda zwraca dane binarne dla danego stylu czcionki lub `null`, gdy żądana czcionka lub styl nie są dostępne. Nie przekazuj wyniku `null` do [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), ponieważ ta metoda wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embeddinglevel/) jest wyliczeniem flag, które raportuje ograniczenia osadzania zapisane w czcionce:

- `Installable` zezwala na osadzanie i trwałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano pozwolenie od właściciela prawnego czcionki, gdy jest to jedyna flaga zezwolenia na użycie.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie oraz umożliwia edycję i zapis dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem zabraniającym osadzania tylko podzbioru glifów. Gdy ta flaga jest obecna, należy osadzić wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które zezwala na osadzanie wyłącznie bitmapowych wersji czcionki, nie danych konturów. Jeśli czcionka nie posiada bitmapowych wersji, nie może być osadzona.

Pierwsze cztery wartości opisują zezwolenie na użycie, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `Installable` ma wartość zero, maskuj bity zezwolenia na użycie i porównuj wynik z `Installable` zamiast sprawdzać go jako flagę. Aktualne czcionki powinny ustawiać co najwyżej jeden bit zezwolenia na użycie. Dla zgodności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocnik wybiera najmniej restrykcyjne zezwolenie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład przeprowadza audyt danych regularnych, pogrubionych, kursywnych i pogrubiono‑kursywnych dostępnych dla każdej czcionki zwróconej przez `getFonts`. Pomija style niedostępne, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i drukowania, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli jakikolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To sprawdzenie raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że uzyskałeś czcionkę legalnie, ani nie zastępuje sprawdzenia umowy licencyjnej czcionki przed rozpowszechnianiem osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [addEmbeddedFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) aby osadzić czcionkę. Jej przeciążenia akceptują albo obiekt [IFontData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontdata/) albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedfontcharacters/) kontroluje, które znaki zostaną uwzględnione:

- [All](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do podglądu.

Poniższy przykład używa [getFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getFonts--) aby pobrać czcionki użyte w pliku `Fonts.pptx` i osadza te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kompresowanie osadzonych czcionek**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) zmniejsza dane osadzonych czcionek, usuwając nieużywane znaki. Działa na czcionkach już osadzonych, więc redukcja rozmiaru zależy od ilości nieużywanych danych czcionki w prezentacji.

Poniższy przykład kompresuje czcionki w pliku `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą później potrzebować dodać tekst. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli początkowo osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka będzie nadal podstawiana podczas renderowania?**

Wywołaj [getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zamieni. Sprawdź także ustawienia [font substitution](/slides/pl/java/font-substitution/) oraz zasady [font fallback](/slides/pl/java/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których dana czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję należy podjąć w oparciu o środowisko docelowe. Jeśli wymagane czcionki są dostępne na każdym komputerze, który otwiera lub renderuje prezentację, ich osadzanie może zwiększyć niepotrzebnie rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, pod warunkiem że licencje na nie to umożliwiają.