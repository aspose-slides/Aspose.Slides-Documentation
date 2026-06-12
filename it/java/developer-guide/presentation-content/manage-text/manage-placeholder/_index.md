---
title: Gestisci i segnaposti di presentazione in Java
linktitle: Gestisci segnaposti
type: docs
weight: 10
url: /it/java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di prompt
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci facilmente i segnaposti in Aspose.Slides per Java: sostituisci testo, personalizza i prompt e imposta la trasparenza dell'immagine in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides ti consente di gestire i segnaposti di presentazione programmaticamente. Questo articolo spiega come trovare i segnaposti nelle diapositive e modificarne il testo, impostare testi di prompt personalizzati per i layout dei segnaposti e regolare la trasparenza di un’immagine usata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposti di base e forme locali, spiega come le modifiche ai segnaposti possano essere applicate tramite layout o master e indica la gestione dei segnaposti di intestazione e piè di pagina.

## **Modifica il testo in un segnaposto**
Utilizzando [Aspose.Slides for Java](/slides/it/java/), puoi trovare e modificare i segnaposti nelle diapositive delle presentazioni. Aspose.Slides ti consente di apportare modifiche al testo di un segnaposto.

**Prerequisito**: è necessaria una presentazione che contenga un segnaposto. Puoi creare una tale presentazione nell'app Microsoft PowerPoint standard.

Ecco come utilizzare Aspose.Slides per sostituire il testo nel segnaposto di quella presentazione:

1. Istanzia la classe `Presentation` e passa la presentazione come argomento.
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Itera tra le forme per trovare il segnaposto.
4. Esegui il cast della forma segnaposto a `AutoShape` e modifica il testo usando il `TextFrame` associato al `AutoShape`.
5. Salva la presentazione modificata.

Questo codice Java mostra come modificare il testo in un segnaposto:

```java
// Istanzia una classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Itera attraverso le forme per trovare il segnaposto
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Modifica il testo in ciascun segnaposto
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Salva la presentazione su disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta il testo di prompt in un segnaposto**
I layout standard e predefiniti contengono testi di prompt per i segnaposti come ***Fai clic per aggiungere un titolo*** o ***Fai clic per aggiungere un sottotitolo***. Utilizzando Aspose.Slides, puoi inserire i testi di prompt desiderati nei layout dei segnaposti.

Questo codice Java mostra come impostare il testo di prompt in un segnaposto:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itera attraverso la diapositiva
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint visualizza "Click to add title" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Aggiunge sottotitolo
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la trasparenza dell'immagine del segnaposto**

Aspose.Slides ti consente di impostare la trasparenza dell’immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell’immagine in tale cornice, puoi far risaltare il testo o l’immagine (a seconda dei colori del testo e dell’immagine).

Questo codice Java mostra come impostare la trasparenza per un’immagine di sfondo (all'interno di una forma):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Cos'è un segnaposto di base e in che cosa differisce da una forma locale in una diapositiva?**

Un segnaposto di base è la forma originale su un layout o master da cui eredita la forma della diapositiva: tipo, posizione e parte della formattazione provengono da esso. Una forma locale è indipendente; se non esiste un segnaposto di base, l'ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in una presentazione senza iterare su ogni diapositiva?**

Modifica il segnaposto corrispondente nel layout o nel master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come posso controllare i segnaposti standard di intestazione/piè di pagina—data e ora, numero diapositiva e testo del piè di pagina?**

Utilizza i gestori HeaderFooter nello scopo appropriato (diapositive normali, layout, master, note/dispense) per attivare o disattivare quei segnaposti e impostare il loro contenuto.