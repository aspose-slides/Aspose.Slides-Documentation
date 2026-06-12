---
title: Incorpora Font nelle Presentazioni su Android
linktitle: Incorporazione Font
type: docs
weight: 40
url: /it/androidjava/embedded-font/
keywords:
- aggiungi font
- incorpora font
- incorporamento font
- ottieni font incorporato
- aggiungi font incorporato
- rimuovi font incorporato
- comprimi font incorporato
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Incorpora font TrueType in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android via Java, garantendo un rendering accurato su tutte le piattaforme."
---
## **Introduzione**

**Font incorporati in PowerPoint** sono utili quando vuoi che la tua presentazione appaia correttamente su qualsiasi sistema o dispositivo. Se hai usato un font di terze parti o non standard perché hai voluto essere creativo nel tuo lavoro, allora hai ancora più motivi per incorporare il tuo font. Altrimenti (senza font incorporati), il testo o i numeri nelle tue diapositive, il layout, lo stile, ecc. possono cambiare o trasformarsi in rettangoli confusi. 

La classe [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) e le loro interfacce contengono la maggior parte delle proprietà e dei metodi di cui hai bisogno per lavorare con i font incorporati nelle presentazioni PowerPoint.

## **Ottenere e rimuovere i font incorporati**

Aspose.Slides fornisce il metodo [getEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (esposto dalla classe [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager)) per consentirti di ottenere (o scoprire) i font incorporati in una presentazione. Per rimuovere i font, viene utilizzato il metodo [removeEmbeddedFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (esposto dalla stessa classe).

Questo codice Java mostra come ottenere e rimuovere i font incorporati da una presentazione:

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderizza una diapositiva contenente un frame di testo che utilizza il font incorporato "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Save l'immagine su disco in formato JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Recupera tutti i font incorporati
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Trova il font "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Rimuove il font "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderizza la presentazione; il font "Calibri" viene sostituito con uno esistente
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Save l'immagine su disco in formato JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Salva la presentazione senza il font "Calibri" incorporato su disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere font incorporati**

Utilizzando l’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/embedfontcharacters/) e due overload del metodo [addEmbeddedFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puoi selezionare la regola di incorporamento preferita per includere i font in una presentazione. Questo codice Java mostra come incorporare e aggiungere font a una presentazione:

```java
// Carica la presentazione
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

    // Salva la presentazione su disco
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Comprimi i font incorporati**

Per consentirti di comprimere i font incorporati in una presentazione e ridurne la dimensione del file, Aspose.Slides fornisce il metodo [compressEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (esposto dalla classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/)).

Questo codice Java mostra come comprimere i font PowerPoint incorporati:

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

**Come posso capire se un font specifico nella presentazione verrà comunque sostituito durante il rendering nonostante sia incorporato?**

Controlla le [informazioni di sostituzione](/slides/it/androidjava/font-substitution/) nel gestore dei font e le [regole di fallback/sostituzione](/slides/it/androidjava/fallback-font/): se il font non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i font di "sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una portabilità totale in ambienti "leggeri" (Docker, un server Linux senza font preinstallati), incorporare i font di sistema può eliminare il rischio di sostituzioni inaspettate.