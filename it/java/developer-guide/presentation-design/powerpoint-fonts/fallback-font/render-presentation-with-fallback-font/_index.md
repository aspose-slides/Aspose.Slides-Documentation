---
title: Esegui il rendering di presentazioni con caratteri di riserva in Java
linktitle: Render Presentazioni
type: docs
weight: 30
url: /it/java/render-presentation-with-fallback-font/
keywords:
- carattere di riserva
- renderizzare PowerPoint
- renderizzare presentazione
- renderizzare diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esegui il rendering delle presentazioni con caratteri di riserva in Aspose.Slides per Java – mantieni il testo coerente tra PPT, PPTX e ODP con esempi di codice Java passo-passo."
---
## **Panoramica**

Aspose.Slides consente di rendere le presentazioni utilizzando regole di caratteri di riserva. Questo articolo mostra come creare una raccolta di regole di caratteri di riserva, modificare le sue regole rimuovendo o aggiungendo caratteri di riserva, e assegnare la raccolta mediante il metodo `FontsManager.setFontFallBackRulesCollection`.

Una volta assegnata la raccolta di regole di caratteri di riserva al `FontsManager` della presentazione, le regole vengono applicate durante operazioni come salvataggio, rendering e conversione della presentazione. L’esempio dimostra come utilizzare le regole configurate durante il rendering di una miniatura di diapositiva e il suo salvataggio come immagine PNG.

## **Renderizzare una diapositiva utilizzando le regole di caratteri di riserva**

L’esempio seguente comprende questi passaggi:

1. Creiamo una [raccolta di regole di caratteri di riserva](/slides/it/java/create-fallback-fonts-collection/).
2. [Rimuovi](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una regola di carattere di riserva e [addFallBackFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a un’altra regola.
3. Imposta la raccolta di regole su [getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
4. Con il metodo [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) possiamo salvare la presentazione nello stesso formato o in un altro. Dopo che la raccolta di regole di caratteri di riserva è stata impostata su [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager), queste regole vengono applicate durante qualsiasi operazione sulla presentazione: salvataggio, rendering, conversione, ecc.

```java
// Crea una nuova istanza di una raccolta di regole
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Tentativo di rimuovere il font di riserva "Tahoma" dalle regole caricate
    fallBackRule.remove("Tahoma");

    //E aggiornare le regole per l'intervallo specificato
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Possiamo anche rimuovere qualsiasi regola esistente dalla lista
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Assegnazione di una lista di regole preparata per l'uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering della miniatura utilizzando la raccolta di regole inizializzata e salvataggio in JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Salva l'immagine su disco in formato JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Scopri di più su come [Convertire PPT e PPTX in JPG in Java](/slides/it/java/convert-powerpoint-to-jpg/).
{{% /alert %}}