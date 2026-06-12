---
title: Ottenere le Callback di Avviso per la Sostituzione dei Caratteri
type: docs
weight: 90
url: /it/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback di avviso
- sostituzione dei caratteri
- processo di rendering
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Impara a ottenere le callback di avviso per la sostituzione dei caratteri in Aspose.Slides per Java e visualizzare correttamente le presentazioni PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per Java consente di ricevere callback di avviso per la sostituzione dei caratteri quando un carattere richiesto non è disponibile sulla macchina durante il rendering. Queste callback aiutano a diagnosticare problemi relativi a caratteri mancanti o non accessibili.

## **Abilitare le Callback di Avviso**

Aspose.Slides per Java fornisce API semplici per ricevere callback di avviso durante il rendering delle diapositive della presentazione. Segui questi passaggi per configurare le callback di avviso:

1. Crea una classe callback personalizzata che implementa l’interfaccia [IWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarningcallback/) per gestire gli avvisi.
1. Imposta la callback di avviso utilizzando classi di opzioni come [RenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/htmloptions/), e altre.
1. Carica una presentazione che utilizza un carattere non disponibile sulla macchina di destinazione.
1. Genera una miniatura della diapositiva o esporta la presentazione per osservare l’effetto.

**Classe Callback di Avviso Personalizzata:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Esempio di output:
//
// Il carattere verrà sostituito da XYZ a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Genera una Miniatura della Diapositiva:**

```java
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante il rendering delle diapositive.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Carica la presentazione dal percorso file specificato.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Genera un'immagine miniatura per ogni diapositiva nella presentazione.
    for (ISlide slide : presentation.getSlides()) {
        // Ottieni l'immagine miniatura della diapositiva usando le opzioni di rendering specificate.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Esporta in Formato PDF:**

```java
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Carica la presentazione dal percorso file specificato.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Esporta la presentazione in PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Esporta in Formato HTML:**

```java
// Configura una callback di avviso per gestire gli avvisi relativi ai caratteri durante l'esportazione HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Carica la presentazione dal percorso file specificato.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Esporta la presentazione in formato HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```