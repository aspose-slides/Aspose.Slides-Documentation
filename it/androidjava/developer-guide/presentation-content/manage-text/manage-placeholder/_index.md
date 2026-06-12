---
title: Gestire i segnaposto della presentazione su Android
linktitle: Gestire i segnaposto
type: docs
weight: 10
url: /it/androidjava/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto di grafico
- testo di prompt
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci facilmente i segnaposto in Aspose.Slides per Android via Java: sostituisci il testo, personalizza i prompt e imposta la trasparenza delle immagini in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides ti consente di gestire i segnaposto delle presentazioni in modo programmatico. Questo articolo spiega come trovare i segnaposto nelle diapositive e modificarne il testo, impostare un testo di prompt personalizzato per i layout dei segnaposto e regolare la trasparenza di un’immagine usata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposto di base e forma locale, spiega come le modifiche ai segnaposto possono essere applicate tramite layout o master, e indica la gestione dei segnaposto di intestazione e piè di pagina.

## **Modifica testo in un segnaposto**
Utilizzando [Aspose.Slides per Android via Java](/slides/it/androidjava/), puoi trovare e modificare i segnaposto nelle diapositive delle presentazioni. Aspose.Slides ti permette di apportare modifiche al testo di un segnaposto.

**Prerequisito**: Hai bisogno di una presentazione che contenga un segnaposto. Puoi creare una tale presentazione nell’app standard Microsoft PowerPoint.

Ecco come usare Aspose.Slides per sostituire il testo nel segnaposto di quella presentazione:

1. Istanzia la classe [`Presentation`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e passa la presentazione come argomento.  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Itera attraverso le forme per individuare il segnaposto.  
4. Esegui il cast della forma segnaposto a un [`AutoShape`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AutoShape) e modifica il testo usando il [`TextFrame`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextFrame) associato al [`AutoShape`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AutoShape).  
5. Salva la presentazione modificata.

Questo codice Java mostra come cambiare il testo in un segnaposto:

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
            // Modifica il testo in ogni segnaposto
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Salva la presentazione su disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta testo di prompt in un segnaposto**
I layout standard e predefiniti contengono testi di prompt per i segnaposto come ***Fare clic per aggiungere un titolo*** o ***Fare clic per aggiungere un sottotitolo***. Con Aspose.Slides, puoi inserire i tuoi testi di prompt preferiti nei layout dei segnaposto.

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
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Aggiunge il sottotitolo
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

## **Imposta trasparenza immagine del segnaposto**

Aspose.Slides ti consente di impostare la trasparenza dell’immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell’immagine in tale cornice, puoi far risaltare il testo o l’immagine (a seconda dei colori del testo e dell’immagine).

Questo codice Java mostra come impostare la trasparenza per lo sfondo di un’immagine (all’interno di una forma):

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

**Che cos’è un segnaposto di base e in che modo differisce da una forma locale su una diapositiva?**

Un segnaposto di base è la forma originale su un layout o master da cui la forma della diapositiva eredita—tipo, posizione e parte della formattazione provengono da esso. Una forma locale è indipendente; se non esiste un segnaposto di base, l’ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in un’intera presentazione senza iterare su ogni diapositiva?**

Modifica il segnaposto corrispondente sul layout o sul master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come controllo i segnaposto standard di intestazione/piè di pagina—data & ora, numero diapositiva e testo del piè di pagina?**

Usa i gestori HeaderFooter allo scopo appropriato (diapositive normali, layout, master, note/handout) per attivare o disattivare quei segnaposto e impostarne il contenuto.