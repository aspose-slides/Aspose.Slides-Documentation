---
title: Incorporare i caratteri nelle presentazioni con Java
linktitle: Incorporamento del carattere
type: docs
weight: 40
url: /it/java/embedded-font/
keywords:
- aggiungere carattere
- incorporare carattere
- incorporamento del carattere
- ottenere carattere incorporato
- aggiungere carattere incorporato
- rimuovere carattere incorporato
- comprimere carattere incorporato
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Incorpora i caratteri TrueType nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Java, garantendo una resa accurata su tutte le piattaforme."
---
## **Introduzione**

**I caratteri incorporati in PowerPoint** sono utili quando vuoi che la tua presentazione appaia correttamente su qualsiasi sistema o dispositivo. Se hai utilizzato un carattere di terze parti o non standard perché sei stato creativo nel tuo lavoro, allora hai ancora più motivi per incorporare il carattere. Altrimenti (senza caratteri incorporati), i testi o i numeri nelle tue diapositive, il layout, lo stile, ecc. possono cambiare o trasformarsi in rettangoli incomprensibili. 

La classe [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) e le loro interfacce contengono la maggior parte delle proprietà e dei metodi di cui hai bisogno per lavorare con i caratteri incorporati nelle presentazioni PowerPoint. 

## **Ottenere e rimuovere i caratteri incorporati**

Aspose.Slides fornisce il metodo [getEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (esposto dalla classe [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager)) per consentirti di ottenere (o scoprire) i caratteri incorporati in una presentazione. Per rimuovere i caratteri, si utilizza il metodo [removeEmbeddedFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (esposto dalla stessa classe).

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renderizza una diapositiva contenente un frame di testo che utilizza il carattere incorporato "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Save l'immagine su disco in formato JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Ottiene tutti i caratteri incorporati
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Trova il carattere "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Rimuove il carattere "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renderizza la presentazione; il carattere "Calibri" è sostituito con uno esistente
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Save l'immagine su disco in formato JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Salva la presentazione senza il carattere "Calibri" incorporato su disco
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere caratteri incorporati**

Utilizzando l'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/java/com.aspose.slides/embedfontcharacters/) e due overload del metodo [addEmbeddedFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), puoi scegliere la regola di incorporamento preferita per incorporare i caratteri in una presentazione. Questo codice Java ti mostra come incorporare e aggiungere caratteri a una presentazione:

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

## **Comprimere i caratteri incorporati**

Per consentirti di comprimere i caratteri incorporati in una presentazione e ridurne la dimensione del file, Aspose.Slides fornisce il metodo [compressEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (esposto dalla classe [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/)).

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

**Come posso capire se un carattere specifico nella presentazione verrà ancora sostituito durante il rendering nonostante sia incorporato?**

Controlla le [informazioni sulla sostituzione](/slides/it/java/font-substitution/) nel gestore dei caratteri e le [regole di fallback/sostituzione](/slides/it/java/fallback-font/): se il carattere non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i caratteri "di sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una piena portabilità in ambienti "leggeri" (Docker, un server Linux senza caratteri preinstallati), incorporare i caratteri di sistema può eliminare il rischio di sostituzioni inattese.