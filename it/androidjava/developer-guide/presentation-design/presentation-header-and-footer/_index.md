---
title: Gestisci intestazioni e piè di pagina della presentazione su Android
linktitle: Intestazione & Piè di pagina
type: docs
weight: 140
url: /it/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Utilizza Aspose.Slides per Android via Java per aggiungere e personalizzare intestazioni e piè di pagina nelle presentazioni PowerPoint e OpenDocument per un aspetto professionale."
---
## **Panoramica**

Aspose.Slides consente di gestire le impostazioni di intestazione e piè di pagina nelle presentazioni PowerPoint. Le intestazioni e i piè di pagina vengono gestiti a livello del master della presentazione e l'API fornisce metodi per impostare il testo del piè di pagina, modificare la visibilità del piè di pagina e aggiornare il testo dell'intestazione nelle diapositive master delle note.

È inoltre possibile gestire intestazioni e piè di pagina per le diapositive di handout e per le diapositive delle note. Ciò include la modifica della visibilità e del testo dei segnaposto di intestazione, piè di pagina, numero diapositiva e data/ora per il master delle note, tutte le diapositive note figlie o una singola diapositiva nota.

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
Aspose.Slides per Android via Java supporta Intestazione e Piè di pagina nelle diapositive di handout e note. Segui i passaggi seguenti:

- Carica una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente un video.
- Modifica le impostazioni di Header e Footer per il master delle note e tutte le diapositive delle note.
- Imposta tutti i segnaposto Footer del master delle note e dei figli visibili.
- Imposta tutti i segnaposto Date e time del master delle note e dei figli visibili.
- Modifica le impostazioni di Header e Footer solo per la prima diapositiva delle note.
- Imposta il segnaposto Header della diapositiva delle note visibile.
- Imposta il testo del segnaposto Header della diapositiva delle note.
- Imposta il testo del segnaposto Date-time della diapositiva delle note.
- Scrivi il file della presentazione modificata.

Snippet di codice fornito nell'esempio seguente.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Modifica le impostazioni di intestazione e piè di pagina per il master delle note e tutte le diapositive delle note
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rendi visibile la diapositiva master delle note e tutti i segnaposti Footer figlio
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rendi visibile la diapositiva master delle note e tutti i segnaposti Header figlio
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rendi visibile la diapositiva master delle note e tutti i segnaposti SlideNumber figlio
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rendi visibile la diapositiva master delle note e tutti i segnaposti Date e time figlio

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // imposta il testo per la diapositiva master delle note e tutti i segnaposti Header figlio
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // imposta il testo per la diapositiva master delle note e tutti i segnaposti Footer figlio
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // imposta il testo per la diapositiva master delle note e tutti i segnaposti Date e time figlio
    }

    // Modifica le impostazioni di intestazione e piè di pagina solo per la prima diapositiva delle note
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // rendi visibile il segnaposto Header di questa diapositiva delle note

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // rendi visibile il segnaposto Footer di questa diapositiva delle note

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // rendi visibile il segnaposto SlideNumber di questa diapositiva delle note

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rendi visibile il segnaposto Date-time di questa diapositiva delle note

        headerFooterManager.setHeaderText("New header text"); // imposta il testo sul segnaposto Header della diapositiva delle note
        headerFooterManager.setFooterText("New footer text"); // imposta il testo sul segnaposto Footer della diapositiva delle note
        headerFooterManager.setDateTimeText("New date and time text"); // imposta il testo sul segnaposto Date-time della diapositiva delle note
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso aggiungere un "header" alle diapositive normali?**

In PowerPoint, "Header" esiste solo per le note e gli handout; sulle diapositive regolari, gli elementi supportati sono il footer, date/time e slide number. In Aspose.Slides ciò corrisponde alle stesse limitazioni: header solo per Notes/Handout e sulle diapositive—Footer/DateTime/SlideNumber.

**Cosa succede se il layout non contiene un'area piè di pagina—posso "attivare" la sua visibilità?**

Sì. Verifica la visibilità tramite il gestore header/footer e abilitala se necessario. Questi indicatori e metodi dell'API sono progettati per i casi in cui il segnaposto è mancante o nascosto.

**Come posso fare in modo che il numero della diapositiva inizi da un valore diverso da 1?**

Imposta il [primo numero della diapositiva](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); dopo di che tutta la numerazione viene ricalcolata. Ad esempio, puoi iniziare da 0 o 10 e nascondere il numero nella diapositiva del titolo.

**Cosa succede a intestazioni/piè di pagina quando si esporta in PDF/immagini/HTML?**

Vengono renderizzati come normali elementi di testo della presentazione. Cioè, se gli elementi sono visibili nelle diapositive/pagine delle note, appariranno anche nel formato di output insieme al resto del contenuto.