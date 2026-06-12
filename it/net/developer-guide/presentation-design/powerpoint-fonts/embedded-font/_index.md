---
title: Incorporare i font nelle presentazioni in .NET
linktitle: Incorporamento Font
type: docs
weight: 40
url: /it/net/embedded-font/
keywords:
- aggiungi font
- incolla font
- incorporamento di font
- ottieni font incorporato
- aggiungi font incorporato
- rimuovi font incorporato
- comprimi font incorporato
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Incorpora font TrueType in presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET, garantendo una resa accurata su tutte le piattaforme."
---
## **Introduzione**

**Incorporare i font in PowerPoint** garantisce che la tua presentazione mantenga l'aspetto previsto su sistemi diversi. Che tu utilizzi font unici per la creatività o standard, l'incorporamento dei font evita interruzioni di testo e layout.

Se hai utilizzato un font di terze parti o non standard perché sei stato creativo con il tuo lavoro, hai ancora più motivi per incorporare il font. Altrimenti (senza font incorporati), i testi o i numeri nelle tue diapositive, il layout, lo stile, ecc. potrebbero cambiare o trasformarsi in rettangoli incomprensibili. 

Utilizza le classi [FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/it/net/aspose.slides/fontdata/) e [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) per gestire i font incorporati.

## **Recupera e rimuovi i font incorporati**

Recupera o rimuovi i font incorporati da una presentazione senza sforzo con i metodi [GetEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts) e [RemoveEmbeddedFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/removeembeddedfont).

Questo codice C# mostra come recuperare e rimuovere i font incorporati da una presentazione:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Esegue il rendering di una diapositiva contenente un frame di testo che utilizza il font incorporato "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Trova il font "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Rimuove il font "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Esegue il rendering della presentazione; il font "Calibri" viene sostituito con uno esistente
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Salva la presentazione senza il font "Calibri" incorporato su disco
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Aggiungi font incorporati**

Utilizzando l'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedfontcharacters/) e le due sovraccariche del metodo [AddEmbeddedFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/addembeddedfont/), puoi selezionare la regola di (incorporamento) preferita per incorporare i font in una presentazione. Questo codice C# mostra come incorporare e aggiungere font a una presentazione:

```c#
// Carica la presentazione
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Salva la presentazione su disco
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Comprimi font incorporati**

Ottimizza le dimensioni del file comprimendo i font incorporati usando [CompressEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Codice di esempio per la compressione:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Come posso capire se un font specifico nella presentazione verrà comunque sostituito durante il rendering nonostante l'incorporamento?**

Controlla le [informazioni sulla sostituzione](/slides/it/net/font-substitution/) nel gestore dei font e le [regole di fallback/sostituzione](/slides/it/net/fallback-font/): se il font non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i font "di sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una piena portabilità in ambienti "leggeri" (Docker, un server Linux senza font preinstallati), incorporare i font di sistema può eliminare il rischio di sostituzioni inaspettate.