---
title: Lettertypen insluiten in presentaties op Android
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "Lettertypen in TrueType-formaat insluiten in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java, zodat de weergave op alle platformen nauwkeurig is."
---
## **Inleiding**

**Embedded fonts in PowerPoint** zijn nuttig wanneer u wilt dat uw presentatie er correct uitziet wanneer deze op elk systeem of apparaat wordt geopend. Als u een derde‑partij of niet‑standaard lettertype hebt gebruikt omdat u creatief bent geweest met uw werk, hebt u nog meer redenen om het lettertype in te sluiten. Anders (zonder ingesloten lettertypen) kunnen de tekst of getallen op uw dia’s, de lay‑out, opmaak, enz. veranderen of in verwarrende rechthoeken worden omgezet. 

De klasse [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager), de klasse [FontData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontdata/), de klasse [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) en hun interfaces bevatten de meeste eigenschappen en methoden die u nodig heeft om met ingesloten lettertypen in PowerPoint‑presentaties te werken.

## **Ingesloten lettertypen ophalen en verwijderen**

Aspose.Slides biedt de methode [getEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (beschikbaar via de klasse [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager)) waarmee u de ingesloten lettertypen in een presentatie kunt ophalen (of achterhalen). Om lettertypen te verwijderen, wordt de methode [removeEmbeddedFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (beschikbaar via dezelfde klasse) gebruikt.

Deze Java‑code toont hoe u ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```java
// Maakt een Presentation-object aan dat een presentatiedocument voorstelt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Render een dia die een tekstkader bevat dat de ingebedde "FunSized" gebruikt
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Sla de afbeelding op schijf in JPEG-formaat
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Haalt alle ingebedde lettertypen op
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Vindt het lettertype "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Verwijdert het lettertype "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Rendert de presentatie; het lettertype "Calibri" wordt vervangen door een bestaand lettertype
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Sla de afbeelding op schijf in JPEG-formaat
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Slaat de presentatie zonder ingebed "Calibri"-lettertype op schijf
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ingesloten lettertypen toevoegen**

Met de enum [EmbedFontCharacters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/embedfontcharacters/) en twee overloads van de methode [addEmbeddedFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) kunt u uw gewenste (insluit‑)regel selecteren om de lettertypen in een presentatie in te sluiten. Deze Java‑code toont hoe u lettertypen in een presentatie kunt insluiten en toevoegen:

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

Om u in staat te stellen de ingesloten lettertypen in een presentatie te comprimeren en de bestandsgrootte te verkleinen, biedt Aspose.Slides de methode [compressEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (beschikbaar via de klasse [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/)).

Deze Java‑code toont hoe u ingesloten PowerPoint‑lettertypen kunt comprimeren:

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

**Hoe kan ik zien dat een specifiek lettertype in de presentatie nog steeds vervangen zal worden tijdens het renderen ondanks het insluiten?**

Bekijk de [substitution information](/slides/nl/androidjava/font-substitution/) in de font‑manager en de [fallback/substitution rules](/slides/nl/androidjava/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt een fallback gebruikt.

**Is het de moeite waard om “systeem”‑lettertypen zoals Arial/Calibri in te sluiten?**

Meestal niet – ze zijn bijna altijd beschikbaar. Maar voor volledige draagbaarheid in “dunne” omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeem‑lettertypen het risico op onverwachte substituties wegnemen.