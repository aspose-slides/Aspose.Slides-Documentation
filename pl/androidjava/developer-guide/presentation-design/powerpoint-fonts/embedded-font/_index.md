---
title: Osadzanie czcionek w prezentacjach na Androidzie
linktitle: Osadzanie czcionki
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
- skomprymuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w języku Java, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

**Czcionki osadzone w PowerPoint** są przydatne, gdy chcesz, aby Twoja prezentacja wyświetlała się poprawnie na każdym systemie lub urządzeniu. Jeśli użyłeś czcionki firm trzecich lub niestandardowej, ponieważ kreatywnie podszedłeś do swojej pracy, masz jeszcze więcej powodów, aby osadzić czcionkę. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylizacja itp. mogą się zmienić lub przekształcić w mylące prostokąty. 

Klasa [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager), klasa [FontData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontdata/), klasa [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/) oraz ich interfejsy zawierają większość właściwości i metod, których potrzebujesz do pracy z osadzonymi czcionkami w prezentacjach PowerPoint.

## **Pobieranie i usuwanie osadzonych czcionek**

Aspose.Slides udostępnia metodę [getEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (udostępnioną przez klasę [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager)), aby umożliwić pobranie (lub sprawdzenie) czcionek osadzonych w prezentacji. Aby usunąć czcionki, używana jest metoda [removeEmbeddedFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (udostępniona przez tę samą klasę).

Ten kod w Javie pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderuje slajd zawierający ramkę tekstową używającą osadzonej czcionki "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Zapisuje obraz na dysku w formacie JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Pobiera wszystkie osadzone czcionki
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Wyszukuje czcionkę "Calibri"
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

    // Renderuje prezentację; "Calibri" font is replaced with an existing one
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Zapisuje obraz na dysku w formacie JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Zapisuje prezentację bez osadzonej "Calibri" font to disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodawanie osadzonych czcionek**

Korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/embedfontcharacters/) oraz dwóch przeciążeń metody [addEmbeddedFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), możesz wybrać preferowaną zasadę (osadzania) do osadzenia czcionek w prezentacji. Ten kod w Javie pokazuje, jak osadzić i dodać czcionki do prezentacji:

```java
// Ładuje prezentację
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

    // Zapisuje prezentację na dysku
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kompresja osadzonych czcionek**

Aby umożliwić kompresję czcionek osadzonych w prezentacji i zmniejszyć rozmiar pliku, Aspose.Slides udostępnia metodę [compressEmbeddedFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (udostępnioną przez klasę [Compress](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/)).

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

**How can I tell that a specific font in the presentation will still be substituted during rendering despite embedding?**

Sprawdź [substitution information](/slides/pl/androidjava/font-substitution/) w menedżerze czcionek oraz [fallback/substitution rules](/slides/pl/androidjava/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyta czcionka zastępcza.

**Is it worth embedding "system" fonts like Arial/Calibri?**

Zazwyczaj nie — są prawie zawsze dostępne. Jednak w celu pełnej przenośności w „cienkich” środowiskach (Docker, serwer Linux bez wstępnie zainstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych podstawień.