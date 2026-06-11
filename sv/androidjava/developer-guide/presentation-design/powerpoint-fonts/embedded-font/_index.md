---
title: Bädda in typsnitt i presentationer på Android
linktitle: Inbäddning av typsnitt
type: docs
weight: 40
url: /sv/androidjava/embedded-font/
keywords:
- lägga till typsnitt
- bädda in typsnitt
- typsnitts inbäddning
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Bädda in TrueType-typsnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java, vilket säkerställer korrekt rendering på alla plattformar."
---
## **Introduktion**

**Inbäddade typsnitt i PowerPoint** är användbara när du vill att din presentation ska visas korrekt när den öppnas på vilket system eller enhet som helst. Om du använde ett tredjeparts‑ eller icke‑standardtypsnitt eftersom du var kreativ med ditt arbete, har du ännu fler skäl att bädda in ditt typsnitt. Annars (utan inbäddade typsnitt) kan texter eller siffror på dina bilder, layouten, formateringen osv. ändras eller förvandlas till förvirrande rektanglar. 

Klassen [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager) klass, [FontData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontdata/) klass, [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/) klass, och deras gränssnitt innehåller de flesta egenskaper och metoder du behöver för att arbeta med inbäddade typsnitt i PowerPoint‑presentationer.

## **Hämta och ta bort inbäddade typsnitt**

Aspose.Slides tillhandahåller metoden [getEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exponerad av klassen [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager)) för att låta dig hämta (eller ta reda på) de typsnitt som är inbäddade i en presentation. För att ta bort typsnitt används metoden [removeEmbeddedFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposerad av samma klass).

Den här Java‑koden visar hur du hämtar och tar bort inbäddade typsnitt från en presentation:

```java
// Instansierar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderar ett bildspel som innehåller en textruta som använder inbäddad "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Sparar bilden till disk i JPEG-format
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Hämtar alla inbäddade typsnitt
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Hittar typsnittet "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Tar bort typsnittet "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderar presentationen; typsnittet "Calibri" ersätts med ett befintligt
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Sparar bilden till disk i JPEG-format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Sparar presentationen utan inbäddat "Calibri"-typsnitt till disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till inbäddade typsnitt**

Genom att använda enum‑typen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/embedfontcharacters/) och två överlagringar av metoden [addEmbeddedFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) kan du välja din föredragna (inbäddnings‑)regel för att bädda in typsnitten i en presentation. Den här Java‑koden visar hur du bäddar in och lägger till typsnitt i en presentation:

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

## **Komprimera inbäddade typsnitt**

För att låta dig komprimera de typsnitt som är inbäddade i en presentation och minska dess filstorlek, tillhandahåller Aspose.Slides metoden [compressEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exponerad av klassen [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/)).

Den här Java‑koden visar hur du komprimerar inbäddade PowerPoint‑typsnitt:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Hur kan jag se att ett specifikt typsnitt i presentationen fortfarande kommer att ersättas vid rendering trots inbäddning?**

Kontrollera [substitutionsinformation](/slides/sv/androidjava/font-substitution/) i font‑hanteraren och [reserv‑/substitutionsregler](/slides/sv/androidjava/fallback-font/): om typsnittet är otillgängligt eller begränsat, kommer en reserv att användas.

**Är det värt att bädda in "system"-typsnitt som Arial/Calibri?**

Vanligtvis nej – de är nästan alltid tillgängliga. Men för full portabilitet i "tunna" miljöer (Docker, en Linux‑server utan förinstallerade typsnitt) kan inbäddning av systemtypsnitt eliminera risken för oväntade ersättningar.