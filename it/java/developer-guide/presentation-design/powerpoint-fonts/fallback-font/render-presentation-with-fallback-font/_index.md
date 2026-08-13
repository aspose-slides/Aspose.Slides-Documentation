---
title: Visualizzare le presentazioni con caratteri di ripiego in Java
linktitle: Render Presentazioni
type: docs
weight: 30
url: /it/java/render-presentation-with-fallback-font/
keywords:
- carattere di ripiego
- render PowerPoint
- render presentazione
- render diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esegui il rendering delle presentazioni con caratteri di ripiego in Aspose.Slides per Java – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice Java passo-passo."
---
## **Panoramica**

Aspose.Slides consente di visualizzare presentazioni utilizzando regole di caratteri di ripiego. Questo articolo mostra come creare una raccolta di regole di caratteri di ripiego, modificare le sue regole rimuovendo o aggiungendo caratteri di ripiego e assegnare la raccolta utilizzando il metodo `FontsManager.setFontFallBackRulesCollection`.

Una volta che la raccolta di regole di caratteri di ripiego è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il salvataggio come immagine JPEG.

## **Eseguire il rendering di una diapositiva utilizzando regole di caratteri di ripiego**

1. [Creiamo la raccolta di regole di caratteri di ripiego](/slides/it/java/create-fallback-fonts-collection/).
2. [Rimuovere](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regola di carattere di ripiego e [addFallBackFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a un'altra regola.
3. Impostare la raccolta di regole su [getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodo.
4. Con il metodo [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) possiamo salvare la presentazione nello stesso formato o in un altro. Dopo che la raccolta di regole di caratteri di ripiego è impostata su [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager), queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```java
import com.aspose.slides.*;

// Crea una nuova istanza di una raccolta di regole
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Tentativo di rimuovere il carattere di ripiego "Tahoma" dalle regole caricate
    fallBackRule.remove("Tahoma");

    // E per aggiornare le regole per l'intervallo specificato
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Possiamo anche rimuovere tutte le regole esistenti dall'elenco, mantenendo almeno una regola per il rendering
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Assegnazione di una lista di regole preparata per l'uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering della miniatura utilizzando la raccolta di regole inizializzata e salvataggio in JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Salva l'immagine su disco in formato JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Leggi di più su come [Converti PPT e PPTX in JPG in Java](/slides/it/java/convert-powerpoint-to-jpg/).
{{% /alert %}}