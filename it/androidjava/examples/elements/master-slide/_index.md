---
title: Slide master
type: docs
weight: 30
url: /it/androidjava/examples/elements/master-slide/
keywords:
- esempio di codice
- slide master
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora esempi di slide master di Aspose.Slides per Android: crea, modifica e personalizza master, segnaposti e temi in PPT, PPTX e ODP con codice Java chiaro."
---
Le master slide costituiscono il livello più alto della gerarchia di ereditarietà delle slide in PowerPoint. Una **master slide** definisce elementi di design comuni, come sfondi, loghi e formattazione del testo. Le **layout slide** ereditano dalle master slide, e le **normal slides** ereditano dalle layout slide.

Questo articolo dimostra come creare, modificare e gestire le master slide utilizzando Aspose.Slides per Android tramite Java.

## **Aggiungi una master slide**

Questo esempio mostra come creare una nuova master slide clonando quella predefinita. Quindi aggiunge un banner con il nome dell'azienda a tutte le slide tramite l'ereditarietà del layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Clona la slide master predefinita.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Aggiungi un banner con il nome dell'azienda nella parte superiore della slide master.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Assegna la nuova slide master a una slide di layout.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Assegna la slide di layout alla prima slide nella presentazione.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Le master slide offrono un modo per applicare un branding coerente o elementi di design condivisi su tutte le slide. Qualsiasi modifica apportata alla master sarà automaticamente riflessa sulle slide di layout e su quelle normali dipendenti.

> 💡 **Note 2:** Qualsiasi forma o formattazione aggiunta a una master slide viene ereditata dalle layout slide e, a loro volta, da tutte le slide normali che utilizzano quei layout.  
> L'immagine qui sotto illustra come una casella di testo aggiunta a una master slide venga automaticamente resa nella diapositiva finale.

![Esempio di ereditarietà della master](master-slide-banner.png)

## **Accedi a una master slide**

Puoi accedere alle master slide utilizzando la collezione master della presentazione. Ecco come recuperarle e lavorare con esse:

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

## **Rimuovi una master slide**

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

## **Rimuovi le master slide inutilizzate**

Alcune presentazioni contengono master slide che non sono in uso. Rimuovere queste slide può contribuire a ridurre le dimensioni del file.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Rimuovi tutte le slide master inutilizzate (anche quelle contrassegnate come Preserva).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```