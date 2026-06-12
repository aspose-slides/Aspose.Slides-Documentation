---
title: Lettertypen insluiten in presentaties met Java
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Insluit TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java, waardoor nauwkeurige weergave op alle platformen wordt gegarandeerd."
---
## **Inleiding**

**Ingesloten lettertypen in PowerPoint** zijn handig wanneer je wilt dat je presentatie er correct uitziet op elk systeem of apparaat. Als je een lettertype van een derde partij of een niet‑standaard lettertype hebt gebruikt omdat je creatief was met je werk, heb je nog meer redenen om je lettertype in te sluiten. Anders (zonder ingesloten lettertypen) kunnen de teksten of cijfers op je dia’s, de lay‑out, de opmaak, enz. wijzigen of veranderen in verwarrende rechthoeken. 

De [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager)‑klasse, de [FontData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontdata/)‑klasse, de [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑klasse en hun interfaces bevatten het grootste deel van de eigenschappen en methoden die je nodig hebt om met ingesloten lettertypen in PowerPoint‑presentaties te werken. 

## **Ingesloten lettertypen ophalen en verwijderen**

Aspose.Slides biedt de [getEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)‑methode (beschikbaar via de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager)‑klasse) zodat je de in een presentatie ingesloten lettertypen kunt ophalen (of achterhalen). Om lettertypen te verwijderen, wordt de [removeEmbeddedFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)‑methode (beschikbaar via dezelfde klasse) gebruikt.

Deze Java‑code laat zien hoe je ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```java
// Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderen van een dia die een tekstframe bevat dat het ingesloten "FunSized" gebruikt
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Sla de afbeelding op schijf in JPEG-formaat
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Haalt alle ingesloten lettertypen op
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Zoekt het "Calibri"-lettertype
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Verwijdert het "Calibri"-lettertype
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderen van de presentatie; het "Calibri"-lettertype wordt vervangen door een bestaand lettertype
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Sla de afbeelding op schijf in JPEG-formaat
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Slaat de presentatie zonder ingesloten "Calibri"-lettertype op schijf
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ingesloten lettertypen toevoegen**

Door gebruik te maken van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedfontcharacters/)‑enum en twee overloads van de [addEmbeddedFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)‑methode, kun je de door jou gewenste (insluit‑)regel kiezen om de lettertypen in een presentatie in te sluiten. Deze Java‑code laat zien hoe je lettertypen kunt insluiten en toevoegen aan een presentatie:

```java
// Laadt de presentatie
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

    // Slaat de presentatie op schijf
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ingesloten lettertypen comprimeren**

Om je in staat te stellen de in een presentatie ingesloten lettertypen te comprimeren en de bestandsgrootte te verkleinen, biedt Aspose.Slides de [compressEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)‑methode (beschikbaar via de [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑klasse).

Deze Java‑code laat zien hoe je ingesloten PowerPoint‑lettertypen kunt comprimeren:

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

**Hoe kan ik zien dat een specifiek lettertype in de presentatie nog steeds wordt vervangen tijdens het renderen ondanks insluiten?**

Controleer de [substitution information](/slides/nl/java/font-substitution/) in de font‑manager en de [fallback/substitution rules](/slides/nl/java/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt er een fallback gebruikt.

**Is het de moeite waard om systeemlettertypen zoals Arial/Calibri in te sluiten?**

Meestal nee – ze zijn bijna altijd beschikbaar. Maar voor volledige draagbaarheid in ‘dunne’ omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen), kan het insluiten van systeemlettertypen het risico op onverwachte substituties wegnemen.