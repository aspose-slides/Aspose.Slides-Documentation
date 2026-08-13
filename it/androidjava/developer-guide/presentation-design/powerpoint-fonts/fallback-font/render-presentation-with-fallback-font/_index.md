---
title: Renderizzare presentazioni con font di fallback su Android
linktitle: Renderizzare presentazioni
type: docs
weight: 30
url: /it/androidjava/render-presentation-with-fallback-font/
keywords:
- font di fallback
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Renderizza le presentazioni con font di fallback in Aspose.Slides per Android - mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice Java passo-passo."
---
## **Panoramica**

Aspose.Slides consente di rendere le presentazioni utilizzando le regole di font di fallback. Questo articolo mostra come creare una raccolta di regole di font di fallback, modificare le sue regole rimuovendo o aggiungendo font di fallback e assegnare la raccolta utilizzando il metodo `FontsManager.setFontFallBackRulesCollection`.

Una volta che la raccolta di regole di font di fallback è assegnata al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come il salvataggio, il rendering e la conversione della presentazione. L'esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il suo salvataggio come immagine JPEG.

## **Renderizzare una diapositiva utilizzando le regole di font di fallback**

Il seguente esempio comprende questi passaggi:

1. Creiamo una [raccolta di regole di font di fallback](/slides/it/androidjava/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regola di font di fallback e [addFallBackFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a un'altra regola.
1. Impostare la raccolta di regole su [getFontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodo.
1. Con il metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) possiamo salvare la presentazione nello stesso formato o salvarla in un altro. Dopo che la raccolta di regole di font di fallback è impostata su [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager), queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```java
import com.aspose.slides.*;

// Crea una nuova istanza di una raccolta di regole
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// crea un numero di regole
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Prova a rimuovere il font di fallback "Tahoma" dalle regole caricate
    fallBackRule.remove("Tahoma");

    // E aggiornare le regole per l'intervallo specificato
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Inoltre possiamo rimuovere qualsiasi regola esistente dalla lista, mantenendo almeno una regola con cui renderizzare
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Assegnando una lista di regole preparata per l'uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering della miniatura usando la raccolta di regole inizializzata e salvataggio in JPEG
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
Leggi di più su [Converti PPT e PPTX in JPG su Android](/slides/it/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}