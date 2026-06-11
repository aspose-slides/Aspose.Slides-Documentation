---
title: Osadzanie czcionek w prezentacjach przy użyciu JavaScript
linktitle: Osadzanie czcionki
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
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js poprzez Java, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

Czcionki osadzone w PowerPoint są przydatne, gdy chcesz, aby Twoja prezentacja wyświetlała się prawidłowo na każdym systemie lub urządzeniu. Jeśli użyłeś czcionki zewnętrznej lub niestandardowej, bo byłeś kreatywny w swojej pracy, masz jeszcze więcej powodów, aby osadzić tę czcionkę. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylizacja itp. mogą się zmienić lub zamienić w nieczytelne prostokąty. 

Klasa [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager), klasa [FontData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontdata/) oraz klasa [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/) i ich klasy zawierają większość właściwości i metod potrzebnych do pracy z osadzonymi czcionkami w prezentacjach PowerPoint.

## **Pobieranie lub usuwanie osadzonych czcionek z prezentacji**

Aspose.Slides udostępnia metodę [getEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (udostępnianą przez klasę [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager)), aby umożliwić pobranie (lub sprawdzenie) czcionek osadzonych w prezentacji. Aby usunąć czcionki, używana jest metoda [removeEmbeddedFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (udostępniana przez tę samą klasę).

Ten kod JavaScript pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```javascript
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderuje slajd zawierający ramkę tekstową, która używa osadzonej "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Zapisuje obraz na dysku w formacie JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Pobiera wszystkie osadzone czcionki
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Znajduje czcionkę "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Usuwa czcionkę "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renderuje prezentację; czcionka "Calibri" zostaje zastąpiona istniejącą
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Zapisuje obraz na dysku w formacie JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Zapisuje prezentację bez osadzonej czcionki "Calibri" na dysku
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie osadzonych czcionek do prezentacji**

Korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/embedfontcharacters/) oraz dwóch przeciążeń metody [addEmbeddedFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), możesz wybrać preferowaną zasadę (osadzania), aby osadzić czcionki w prezentacji. Ten kod JavaScript pokazuje, jak osadzić i dodać czcionki do prezentacji:

```javascript
// Wczytuje prezentację
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Zapisuje prezentację na dysk
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kompresja osadzonych czcionek**

Aby umożliwić kompresję czcionek osadzonych w prezentacji i zmniejszyć jej rozmiar, Aspose.Slides udostępnia metodę [compressEmbeddedFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (udostępnianą przez klasę [Compress](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/)).

Ten kod JavaScript pokazuje, jak skompresować osadzone czcionki PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mogę sprawdzić, czy konkretna czcionka w prezentacji będzie nadal podstawiana podczas renderowania pomimo osadzenia?**

Sprawdź [informacje o podstawianiu](/slides/pl/nodejs-java/font-substitution/) w menedżerze czcionek oraz [zasady zastępowania/podstawiania](/slides/pl/nodejs-java/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zastępcza.

**Czy warto osadzać czcionki systemowe, takie jak Arial/Calibri?**

Zazwyczaj nie — są one prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych podstawień.