---
title: Osadzanie czcionek w prezentacjach w JavaScript
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/nodejs-java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides dla Node.js via Java. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Kiedy program wyświetlający obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w docelowym systemie. Pomaga to zachować podziały wierszy, odstępy tekstu oraz układ slajdów.

Aspose.Slides for Node.js via Java umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem klasy [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/) zwracanej przez [Presentation.getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Można również zmniejszyć rozmiar danych osadzonej czcionki, usuwając znaki, które nie są używane w prezentacji.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane czcionki są dostępne dla Aspose.Slides i że jej licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) aby wyświetlić listę czcionek zapisanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), a następnie zapisz prezentację.

Poniższy przykład wyświetla osadzone czcionki w `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Usunięcie osadzonej czcionki usuwa jej zapisane dane czcionki; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w docelowym systemie, tekst może nadal ją używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/nodejs-java/font-substitution/), co może wpłynąć na układ.

## **Sprawdzanie danych czcionki i uprawnień do osadzania**

Użyj klasy [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/), aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [FontsManager.getFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [FontData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontstyletype/) do [FontsManager.getFontBytes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Metoda zwraca dane binarne dla tego stylu czcionki lub `null`, gdy żądana czcionka lub styl są niedostępne. Nie przekazuj wyniku `null` do [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), ponieważ ta metoda wymaga tablicy bajtów. W Node.js przekonwertuj zwróconą tablicę JavaScript na tablicę bajtów Java przy użyciu `java.newArray` przed przekazaniem jej do `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/embeddinglevel/) raportuje ograniczenia osadzania zapisane w czcionce jako zestaw flag:

- `Installable` zezwala na osadzanie i trwałą instalację na innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano zezwolenie od prawnego właściciela czcionki, gdy jest jedyną flagą zezwalającą na użycie.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie oraz pozwala na edycję i zapis dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem, które zabrania osadzania tylko podzbioru glifów. Gdy ta flaga jest obecna, należy osadzić wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które zezwala tylko na osadzenie bitmapowych wersji czcionki, a nie danych konturów. Jeśli czcionka nie posiada wersji bitmapowych, nie może być osadzona.

Początkowe cztery wartości opisują zezwolenie na użycie, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory operacjami bitowymi. Ponieważ `Installable` ma wartość zero, maskuj bity zezwolenia na użycie i porównuj wynik z `Installable` zamiast sprawdzać go jako flagę. Obecne czcionki powinny ustawiać co najwyżej jeden bit zezwolenia na użycie. Dla zgodności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocnik wybiera najmniej restrykcyjne zezwolenie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład audytuje regularne, pogrubione, kursywą i pogrubione‑kursywą dane dostępne dla każdej czcionki zwróconej przez `getFonts`. Pomija style niedostępne, czcionki ograniczone, czcionki tylko‑bitmapowe, czcionki ograniczone do podglądu i drukowania, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli którykolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ten przegląd raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że czcionka została pozyskana legalnie, ani nie zastępuje sprawdzania umowy licencyjnej czcionki przed rozpowszechnieniem osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/), aby osadzić czcionkę. Jej przeciążenia akceptują albo obiekt [FontData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontdata/), albo tablicę bajtów zawierającą dane czcionki. [EmbedFontCharacters](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/embedfontcharacters/) kontroluje, które znaki są dołączane:

- `All` osadza wszystkie znaki czcionki. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- `OnlyUsed` osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do przeglądania.

Poniższy przykład używa [FontsManager.getFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby pobrać czcionki użyte w `Fonts.pptx` i osadzi te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje aktualne zestawy znaków.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kompresowanie osadzonych czcionek**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/compressembeddedfonts/) zmniejsza dane osadzonej czcionki, usuwając nieużywane znaki. Działa na czcionkach, które już są osadzone, więc stopień zmniejszenia zależy od ilości nieużywanych danych czcionki zawartych w prezentacji.

Poniższy przykład kompresuje czcionki w `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą potrzebować później dodać tekst. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli pierwotnie osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka zostanie nadal zastąpiona podczas renderowania?**

Wywołaj [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zastąpi. Sprawdź także ustawienia [font substitution](/slides/pl/nodejs-java/font-substitution/) oraz reguły [font fallback](/slides/pl/nodejs-java/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje problemu znaków, których czcionka sama nie zawiera.

**Czy powinienem osadzać powszechne czcionki, takie jak Arial i Calibri?**

Podstaw decyzję na docelowym środowisku. Jeśli wymagane czcionki są dostępne na każdym komputerze otwierającym lub renderującym prezentację, ich osadzanie może niepotrzebnie zwiększyć rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, o ile licencje na te czcionki na to zezwalają.