---
title: Slide master
type: docs
weight: 30
url: /it/java/examples/elements/master-slide/
keywords:
- esempio di codice
- slide master
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esplora gli esempi di slide master di Aspose.Slides per Java: crea, modifica e stile master, segnaposti e temi in PPT, PPTX e ODP con codice Java chiaro."
---
Le master slide costituiscono il livello superiore della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **master slide** definisce gli elementi di design comuni, come sfondi, loghi e formattazione del testo. Le **layout slide** ereditano dalle master slide, e le **normal slide** ereditano dalle layout slide.

Questo articolo dimostra come creare, modificare e gestire le master slide utilizzando Aspose.Slides per Java.

## **Aggiungere una master slide**

Questo esempio mostra come creare una nuova master slide clonando quella predefinita. Quindi aggiunge un banner con il nome dell'azienda a tutte le diapositive tramite l'ereditarietà del layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Clona la master slide predefinita.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Aggiungi un banner con il nome dell'azienda nella parte superiore della master slide.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Assegna la nuova master slide a una layout slide.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Assegna la layout slide alla prima slide della presentazione.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Le master slide offrono un modo per applicare un branding coerente o elementi di design condivisi su tutte le diapositive. Qualsiasi modifica apportata alla master slide si rifletterà automaticamente sulle layout e sulle diapositive normali dipendenti.
> 
> 💡 **Nota 2:** Qualsiasi forma o formattazione aggiunta a una master slide è ereditata dalle layout slide e, a loro volta, da tutte le diapositive normali che utilizzano quei layout.
> L'immagine sottostante illustra come una casella di testo aggiunta su una master slide venga automaticamente renderizzata sulla diapositiva finale.

![Master Inheritance Example](master-slide-banner.png)

## **Accedere a una master slide**

È possibile accedere alle master slide utilizzando la collezione master della presentazione. Ecco come recuperarle e lavorare con esse:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Modifica il tipo di sfondo.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere una master slide**

Le master slide possono essere rimosse sia per indice che per riferimento.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Rimuovi una master slide per indice.
        presentation.getMasters().removeAt(0);

        // Rimuovi una master slide per riferimento.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere le master slide non utilizzate**

Alcune presentazioni contengono master slide non utilizzate. Rimuovere queste slide può contribuire a ridurre la dimensione del file.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Rimuovi tutte le master slide inutilizzate (anche quelle contrassegnate come Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```