---
title: Slide master
type: docs
weight: 30
url: /it/nodejs-java/examples/elements/master-slide/
keywords:
- esempio di codice
- slide master
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esplora gli esempi di slide master di Aspose.Slides per Node.js: crea, modifica e stila master, segnaposti e temi in PPT, PPTX e ODP con codice chiaro."
---
Le master slide costituiscono il livello superiore della gerarchia di ereditarietà delle slide in PowerPoint. Una **master slide** definisce elementi di design comuni, come sfondi, loghi e formattazione del testo. Le **layout slide** ereditano dalle master slide, e le **normal slide** ereditano dalle layout slide.

Questo articolo dimostra come creare, modificare e gestire le master slide usando Aspose.Slides per Node.js tramite Java.

## **Aggiungere una Master Slide**

Questo esempio mostra come creare una nuova master slide clonando quella predefinita. Successivamente aggiunge un banner con il nome dell'azienda a tutte le slide tramite l'ereditarietà del layout.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Clona la master slide predefinita.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Aggiungi un banner con il nome dell'azienda nella parte superiore della master slide.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Assegna la nuova master slide a una layout slide.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Assegna la layout slide alla prima slide della presentazione.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Le master slide forniscono un modo per applicare un branding coerente o elementi di design condivisi a tutte le slide. Qualsiasi modifica apportata alla master verrà automaticamente riflessa sulle slide layout e normali dipendenti.

> 💡 **Nota 2:** Qualsiasi forma o formattazione aggiunta a una master slide viene ereditata dalle layout slide e, a loro volta, da tutte le slide normali che utilizzano quei layout.
> L'immagine seguente illustra come una casella di testo aggiunta su una master slide venga automaticamente resa sulla slide finale.

![Esempio di ereditarietà del master](master-slide-banner.png)

## **Accedere a una Master Slide**

È possibile accedere alle master slide usando la collezione master della presentazione. Ecco come recuperarle e lavorare con esse:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Cambia il tipo di sfondo.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere una Master Slide**

Le master slide possono essere rimosse sia per indice che per riferimento.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Rimuovi una master slide per indice.
        presentation.getMasters().removeAt(0);

        // Rimuovi una master slide per riferimento.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere le Master Slide non utilizzate**

Alcune presentazioni contengono master slide non utilizzate. Rimuovere queste slide può contribuire a ridurre la dimensione del file.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Rimuovi tutte le master slide inutilizzate (anche quelle contrassegnate come Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```