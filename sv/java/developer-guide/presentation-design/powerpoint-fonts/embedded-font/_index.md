---
title: Bädda in teckensnitt i presentationer med Java
linktitle: Inbäddning av teckensnitt
type: docs
weight: 40
url: /sv/java/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- teckensnittsinbäddning
- hämta inbäddat teckensnitt
- lägg till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Bädda in TrueType-teckensnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java, vilket säkerställer korrekt rendering på alla plattformar."
---
## **Introduktion**

**Inbäddade teckensnitt i PowerPoint** är användbara när du vill att din presentation ska visas korrekt när den öppnas på vilket system eller enhet som helst. Om du använde ett tredjeparts‑ eller icke‑standardteckensnitt eftersom du var kreativ med ditt arbete, har du ännu fler anledningar att bädda in ditt teckensnitt. Annars (utan inbäddade teckensnitt) kan texter eller siffror på dina bilder, layouten, stilinställningarna osv. förändras eller förvandlas till förvirrande rektanglar. 

Klasserna [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontdata/), [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) och deras gränssnitt innehåller de flesta egenskaper och metoder du behöver för att arbeta med inbäddade teckensnitt i PowerPoint‑presentationer. 

## **Hämta och ta bort inbäddade teckensnitt**

Aspose.Slides tillhandahåller metoden [getEmbeddedFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exponerad av klassen [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager)) så att du kan hämta (eller ta reda på) de teckensnitt som är inbäddade i en presentation. För att ta bort teckensnitt används metoden [removeEmbeddedFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exponerad av samma klass).

Denna Java‑kod visar hur du hämtar och tar bort inbäddade teckensnitt från en presentation:

```java
// Instansierar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderar en bild som innehåller en textruta som använder inbäddade "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Spara bilden till disk i JPEG-format
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Hämtar alla inbäddade teckensnitt
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Söker efter teckensnittet "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Tar bort teckensnittet "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderar presentationen; teckensnittet "Calibri" ersätts med ett befintligt
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Spara bilden till disk i JPEG-format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Sparar presentationen utan inbäddat "Calibri"-teckensnitt till disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till inbäddade teckensnitt**

Genom att använda enumen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/embedfontcharacters/) och två överlagringar av metoden [addEmbeddedFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) kan du välja din föredragna (inbäddnings)regel för att bädda in teckensnitten i en presentation. Denna Java‑kod visar hur du bäddar in och lägger till teckensnitt i en presentation:

```java
// Laddar presentationen
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

    // Sparar presentationen till disk
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Komprimera inbäddade teckensnitt**

För att du ska kunna komprimera de inbäddade teckensnitten i en presentation och minska filstorleken, tillhandahåller Aspose.Slides metoden [compressEmbeddedFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exponerad av klassen [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/)).

Denna Java‑kod visar hur du komprimerar inbäddade PowerPoint‑teckensnitt:

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

**Hur kan jag se att ett specifikt teckensnitt i presentationen fortfarande kommer att bytas ut vid rendering trots inbäddning?**

Kontrollera [information om ersättning](/slides/sv/java/font-substitution/) i teckensnittshanteraren och [regler för reserv/ersättning](/slides/sv/java/fallback-font/): om teckensnittet är otillgängligt eller begränsat, kommer ett reservteckensnitt att användas.

**Är det värt att bädda in "system"-teckensnitt som Arial/Calibri?**

Vanligtvis nej – de är nästan alltid tillgängliga. Men för full portabilitet i "tunna" miljöer (Docker, en Linux‑server utan förinstallerade teckensnitt) kan inbäddning av systemteckensnitt eliminera risken för oväntade ersättningar.