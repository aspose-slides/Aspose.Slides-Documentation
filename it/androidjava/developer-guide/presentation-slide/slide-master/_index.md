---
title: Gestire i master delle diapositive della presentazione su Android
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/androidjava/slide-master/
keywords:
- master diapositiva
- diapositiva master
- diapositiva master PPT
- diapositive master multiple
- confronta diapositive master
- sfondo
- segnaposto
- clona diapositiva master
- copia diapositiva master
- duplica diapositiva master
- diapositiva master inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: Gestisci i master delle diapositive in Aspose.Slides per Android via Java: accedi, modifica, clona, confronta e rimuovi i master delle diapositive nelle presentazioni PowerPoint e OpenDocument.
---
## **Panoramica**

Un **master delle diapositive** definisce impostazioni di progettazione condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un master delle diapositive è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Android via Java supporta lo stesso modello. Una presentazione può contenere una o più diapositive master e ogni diapositiva master può contenere diverse diapositive layout. Le diapositive normali di solito non fanno riferimento direttamente a un master. Invece, una diapositiva normale utilizza una diapositiva layout, e quella diapositiva layout appartiene a un master.

La gerarchia è:

1. **Slide master** - definisce il design condiviso e il tema.  
1. **Layout slide** - definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto effettivo della presentazione e utilizza una diapositiva layout.

![La gerarchia delle diapositive master, layout e normali](slide-master_2.jpg)

In Aspose.Slides, un master delle diapositive è rappresentato dall'interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslide/). Tutti i master delle diapositive in una presentazione sono disponibili tramite la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getMasters--) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/). Per l'intera superficie API Android via Java, vedere il riferimento API [com.aspose.slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}

Quando la stessa proprietà è definita a più di un livello, vince il livello più specifico. Per esempio, se un master e un layout definiscono entrambi uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sui layout delle diapositive, vedere [Apply or Change Slide Layouts](/slides/it/androidjava/slide-layout/).

{{% /alert %}}

## **Access Slide Masters**

In PowerPoint, è possibile aprire la visualizzazione Master delle diapositive da **Visualizza** > **Master diapositiva**.

![Il comando Master diapositiva nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizzare la collezione `getMasters()` per accedere ai master delle diapositive:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

È inoltre possibile ottenere il master della diapositiva usato da una diapositiva normale attraverso il suo layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **What a Slide Master Contains**

Un master delle diapositive è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà delle diapositive usate da diapositive normali e layout.

I membri del master più comunemente usati includono:

| Member | Purpose |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes()` | Contiene le forme posizionate sul master, come loghi, cornici immagine e testo condiviso. |
| `getLayoutSlides()` | Contiene le diapositive layout appartenenti al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema del master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Add an Image to a Slide Master**

Quando si aggiunge un'immagine a un master delle diapositive, essa appare nelle diapositive che usano layout da quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo al primo master delle diapositive:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori informazioni sulle cornici immagine, vedere [Picture Frame](/slides/it/androidjava/picture-frame/).

## **Work with Placeholders**

I segnaposti sono normalmente definiti sui layout. Il master fornisce lo stile e il tema condivisi che tali layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono collocati.

In PowerPoint, i comandi per i segnaposti sono disponibili nella visualizzazione Master delle diapositive.

![Il comando Inserisci segnaposto nella visualizzazione Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sul layout che appartiene al master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

È anche possibile formattare le forme segnaposto già presenti su un master. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/slides/it/androidjava/manage-placeholder/) e [Text Formatting](/slides/it/androidjava/text-formatting/).

## **Change a Slide Master Background**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master delle diapositive:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/androidjava/presentation-background/) e [Presentation Theme](/slides/it/androidjava/presentation-theme/).

## **Clone a Slide Master to Another Presentation**

Usare [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) per copiare un master delle diapositive in un'altra presentazione. Il master copiato può poi essere usato da layout e diapositive nella presentazione di destinazione.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Se è necessario clonare diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/androidjava/clone-slides/).

## **Add Multiple Slide Masters**

Una presentazione può contenere più master delle diapositive. È utile quando sezioni diverse richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire master delle diapositive](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Compare Slide Masters**

I master delle diapositive possono essere confrontati con il metodo `equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/androidjava/compare-slides/).

## **Set Slide Master View as the Default View**

Usare il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. Il seguente esempio apre la presentazione nella visualizzazione Master delle diapositive:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per altre impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/androidjava/save-presentation/).

## **Remove Unused Master Slides**

Le presentazioni a volte contengono master delle diapositive che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione del modello.

Usare `removeUnused` per rimuovere i master inutilizzati dalla collezione `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

È inoltre possibile utilizzare il metodo low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra un master delle diapositive e un layout?**

Un master delle diapositive definisce impostazioni di progettazione condivise come tema, sfondo, forme comuni e stili di testo. Un layout appartiene a un master e definisce una disposizione specifica di segnaposti. Una diapositiva normale usa un layout, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi master delle diapositive?**

Sì. Una presentazione può contenere diversi master. Usare più master quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a un master o a un layout?**

Nella maggior parte dei casi, aggiungere i segnaposti ai layout. Inserire elementi visivi condivisi e formattazione condivisa nel master, quindi posizionare i segnaposti di contenuto nei layout che le diapositive normali utilizzeranno.

**Posso eliminare un master delle diapositive ancora in uso?**

No. Un master che ha diapositive dipendenti non può essere rimosso in modo sicuro. Spostare prima quelle diapositive su layout di un altro master, oppure utilizzare un metodo di pulizia dei master non utilizzati che rimuove solo i master senza dipendenze.