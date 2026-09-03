---
title: Osadzanie czcionek w prezentacjach na Android
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/androidjava/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- skompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides dla Androida w Javie. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wstęp**

Osadzanie czcionek przechowuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są zainstalowane w systemie docelowym. Pomaga to zachować podziały wierszy, odstępy tekstu i układ slajdu.

Aspose.Slides for Android via Java umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/) zwracanego przez [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getFontsManager--). Można również zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [getEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) aby wyświetlić listę czcionek przechowywanych w prezentacji. Aby usunąć jedną, przekaż czcionkę z tej listy do [removeEmbeddedFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), a następnie zapisz prezentację.

Poniższy przykład wyświetla osadzone czcionki w `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:
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

Usunięcie osadzonej czcionki usuwa jej przechowywane dane; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w systemie docelowym, tekst może nadal jej używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/androidjava/font-substitution/), co może wpłynąć na układ.

## **Inspekcja danych czcionki i uprawnień do osadzania**

Użyj interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/) aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [IFontsManager.getFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [IFontData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontstyletype/) do [IFontsManager.getFontBytes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoda zwraca bajtowe dane dla tego stylu czcionki lub `null`, gdy żądana czcionka lub styl jest niedostępny. Nie przekazuj wyniku `null` do [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), ponieważ metoda wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embeddinglevel/) jest wyliczeniem flagowym, które raportuje ograniczenia osadzania przechowywane w czcionce:

- `Installable` zezwala na osadzanie i stałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zakazuje osadzania, chyba że uzyskano pozwolenie od prawnego właściciela czcionki, gdy jest to jedyna flaga zezwalająca na użycie.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie i pozwala na edycję oraz zapis dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem, które zakazuje osadzania tylko podzbioru glifów. Gdy ta flaga jest obecna, osadź wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które zezwala na osadzanie jedynie bitmapowych wariantów czcionki, a nie danych konturu. Jeśli czcionka nie ma bitmapowych wariantów, nie może być osadzona.

Pierwsze cztery wartości opisują uprawnienia do użycia, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `Installable` ma wartość zero, maskuj bity uprawnień do użycia i porównuj wynik z `Installable` zamiast sprawdzać go jako flagę. Aktualne czcionki powinny ustawiać najwyżej jeden bit uprawnienia do użycia. Dla kompatybilności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocnik wybiera najmniej restrykcyjne uprawnienie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład sprawdza dane regular, pogrubione, kursywa i pogrubiona‑italiczna dostępne dla każdej czcionki zwróconej przez `getFonts`. Pomija niedostępne style, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i drukowania, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli którykolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.
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

Ta inspekcja raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że uzyskałeś czcionkę legalnie, ani nie zastępuje sprawdzenia umowy licencyjnej czcionki przed dystrybucją osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [addEmbeddedFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) aby osadzić czcionkę. Przeciążenia akceptują albo obiekt [IFontData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontdata/), albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedfontcharacters/) kontroluje, które znaki są włączane:

- [All](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do podglądu.

Poniższy przykład używa [getFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) aby pobrać czcionki użyte w `Fonts.pptx` i osadza te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na urządzeniu z Androidem lub zarejestrowane w Aspose.Slides. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.
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

## **Kompresja osadzonych czcionek**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) zmniejsza dane osadzonych czcionek poprzez usunięcie nieużywanych znaków. Działa na czcionkach już osadzonych, więc redukcja rozmiaru zależy od tego, ile nieużywanych danych czcionki zawiera prezentacja.

Poniższy przykład kompresuje czcionki w `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:
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

Zachowaj oryginalny plik, jeśli odbiorcy mogą potrzebować później dodać tekst. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli początkowo osadziłeś wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka będzie nadal podstawiana podczas renderowania?**

Wywołaj [getSubstitutions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zamieni. Sprawdź także ustawienia [font substitution](/slides/pl/androidjava/font-substitution/) oraz reguły [font fallback](/slides/pl/androidjava/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzanie czcionki nie rozwiązuje znaków, których czcionka sama nie zawiera.

**Czy powinienem osadzać powszechne czcionki, takie jak Arial i Calibri?**

Decyzję opieraj na środowisku docelowym. Jeśli wymagane czcionki są dostępne na każdym urządzeniu, które otwiera lub renderuje prezentację, ich osadzanie może niepotrzebnie zwiększyć rozmiar pliku. Jeśli odbiorcy lub serwery mogą ich nie mieć, osadzenie może pomóc zachować zamierzony wygląd, o ile licencje na te czcionki na to pozwalają.