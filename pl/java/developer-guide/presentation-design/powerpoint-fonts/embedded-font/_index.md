---
title: Embed Fonts in Presentations Using Java
linktitle: Embedding Font
type: docs
weight: 40
url: /pl/java/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- skompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Osadzaj czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

**Czcionki osadzone w programie PowerPoint** są przydatne, gdy chcesz, aby Twoja prezentacja wyświetlała się poprawnie na dowolnym systemie lub urządzeniu. Jeśli użyłeś czcionki firmowej lub niestandardowej, ponieważ wykazałeś się kreatywnością w swojej pracy, masz jeszcze więcej powodów, aby ją osadzić. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylowanie itp. mogą ulec zmianie lub zamienić się w mylące prostokąty. 

Klasy [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontdata/), [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/) oraz ich interfejsy zawierają większość właściwości i metod potrzebnych do pracy z osadzonymi czcionkami w prezentacjach PowerPoint. 

## **Pobieranie i usuwanie osadzonych czcionek**

Aspose.Slides udostępnia metodę [getEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (dostępną w klasie [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager)), która umożliwia pobranie (lub sprawdzenie), jakie czcionki są osadzone w prezentacji. Do usuwania czcionek używana jest metoda [removeEmbeddedFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) dostępna w tej samej klasie.

Ten kod w Javie pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderuje slajd zawierający ramkę tekstową, która używa osadzonej czcionki "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Zapisz obraz na dysku w formacie JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Pobiera wszystkie osadzone czcionki
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Znajduje czcionkę "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Usuwa czcionkę "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderuje prezentację; czcionka "Calibri" jest zastąpiona istniejącą
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Zapisz obraz na dysku w formacie JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Zapisuje prezentację bez osadzonej czcionki "Calibri" na dysk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodawanie osadzonych czcionek**

Korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/java/com.aspose.slides/embedfontcharacters/) oraz dwóch przeciążeń metody [addEmbeddedFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), możesz wybrać preferowaną regułę (osadzania), aby osadzić czcionki w prezentacji. Ten kod w Javie pokazuje, jak osadzić i dodać czcionki do prezentacji:

```java
// Wczytuje prezentację
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Zapisuje prezentację na dysk
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kompresja osadzonych czcionek**

Aby umożliwić kompresję czcionek osadzonych w prezentacji i zmniejszyć jej rozmiar, Aspose.Slides udostępnia metodę [compressEmbeddedFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) dostępną w klasie [Compress](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/).

Ten kod w Javie pokazuje, jak skompresować osadzone czcionki PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że określona czcionka w prezentacji będzie nadal podstawiana podczas renderowania, pomimo osadzenia?**

Sprawdź [informacje o podstawianiu](/slides/pl/java/font-substitution/) w menedżerze czcionek oraz [zasady zastępowania/podstawiania](/slides/pl/java/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zastępcza.

**Czy warto osadzać czcionki „systemowe”, takie jak Arial/Calibri?**

Zazwyczaj nie — są prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych podstawień.