---
title: Gestire intestazioni e piè di pagina della presentazione in Java
linktitle: Intestazione e piè di pagina
type: docs
weight: 140
url: /it/java/presentation-header-and-footer/
keywords:
- intestazione
- testo intestazione
- piè di pagina
- testo piè di pagina
- imposta intestazione
- imposta piè di pagina
- dispensa
- note
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Java per aggiungere e personalizzare intestazioni e piè di pagina nelle presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides consente di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Le intestazioni e i piè di pagina vengono gestiti a livello del master della presentazione e l'API fornisce metodi per impostare il testo del piè di page, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nelle diapositive master delle note.

È inoltre possibile gestire le intestazioni e i piè di pagina per le diapositive di handout e note. Ciò include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora per il master delle note, tutte le diapositive figlie delle note o una singola diapositiva delle note.

## **Gestire intestazioni e piè di pagina in una presentazione**

Le note di una diapositiva specifica possono essere rimosse come mostrato nell'esempio seguente:

```java
// Carica presentazione
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Impostazione piè di pagina
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Accesso e aggiornamento intestazione
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Salva presentazione
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metodo per impostare il testo di intestazione/piè di pagina
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Gestire intestazioni e piè di pagina su diapositive di handout e note**

Aspose.Slides for Java supporta Intestazione e Piè di pagina su diapositive di handout e note. Si prega di seguire i passaggi seguenti:

- Carica una [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente un video.
- Modifica le impostazioni di Intestazione e Piè di pagina per il master delle note e tutte le diapositive delle note.
- Imposta i segnaposto Piè di pagina del master delle note e di tutte le diapositive figlie visibili.
- Imposta i segnaposto Data e ora del master delle note e di tutte le diapositive figlie visibili.
- Modifica le impostazioni di Intestazione e Piè di pagina solo per la prima diapositiva delle note.
- Imposta il segnaposto Intestazione della diapositiva delle note visibile.
- Imposta il testo del segnaposto Intestazione della diapositiva delle note.
- Imposta il testo del segnaposto Data-ora della diapositiva delle note.
- Scrivi il file di presentazione modificato.

Snippet di codice fornito nell'esempio seguente.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rende visibile la diapositiva master delle note e tutti i segnaposto Footer figli
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rende visibile la diapositiva master delle note e tutti i segnaposto Header figli
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rende visibile la diapositiva master delle note e tutti i segnaposto Numero diapositiva figli
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rende visibile la diapositiva master delle note e tutti i segnaposto Data e ora figli

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // imposta il testo sulla diapositiva master delle note e tutti i segnaposto Header figli
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // imposta il testo sulla diapositiva master delle note e tutti i segnaposto Footer figli
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // imposta il testo sulla diapositiva master delle note e tutti i segnaposto Data e ora figli
    }

    // Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva delle note
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // rende visibile il segnaposto Header di questa diapositiva delle note

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // rende visibile il segnaposto Footer di questa diapositiva delle note

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // rende visibile il segnaposto Numero diapositiva di questa diapositiva delle note

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rende visibile il segnaposto Data-ora di questa diapositiva delle note

        headerFooterManager.setHeaderText("New header text"); // imposta il testo sul segnaposto Header della diapositiva delle note
        headerFooterManager.setFooterText("New footer text"); // imposta il testo sul segnaposto Footer della diapositiva delle note
        headerFooterManager.setDateTimeText("New date and time text"); // imposta il testo sul segnaposto Data-ora della diapositiva delle note
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso aggiungere un "intestazione" alle diapositive normali?**

In PowerPoint, "Header" esiste solo per le note e gli handout; sulle diapositive normali, gli elementi supportati sono il piè di pagina, data/ora e il numero della diapositiva. In Aspose.Slides ciò corrisponde alle stesse limitazioni: intestazione solo per Notes/Handout e, sulle diapositive, Piè di pagina/DataOra/NumeroDiapositiva.

**Cosa succede se il layout non contiene un'area di piè di pagina—posso "attivare" la sua visibilità?**

Sì. Verifica la visibilità tramite il gestore intestazione/piè di pagina e abilitala se necessario. Questi indicatori e metodi dell'API sono progettati per i casi in cui il segnaposto sia mancante o nascosto.

**Come posso far iniziare il numero della diapositiva da un valore diverso da 1?**

Imposta il [primo numero diapositiva](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) della presentazione; a partire da allora, tutta la numerazione viene ricalcolata. Ad esempio, puoi iniziare da 0 o 10 e nascondere il numero nella diapositiva titolo.

**Cosa accade alle intestazioni/piè di pagina durante l'esportazione in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Ovvero, se gli elementi sono visibili su diapositive/pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.