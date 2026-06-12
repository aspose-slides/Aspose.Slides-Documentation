---
title: Gestisci i master slide della presentazione in Java
linktitle: Master slide
type: docs
weight: 70
url: /it/java/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- master slide multipli
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide inutilizzato
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Java: accedi, modifica, clona, confronta e rimuovi i master slide nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Java supporta lo stesso modello. Una presentazione può contenere una o più slide master, e ogni slide master può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una slide master. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una slide master.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Diapositiva normale** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di slide master, layout slide e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dall’interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/). Tutti i master slide in una presentazione sono disponibili tramite la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasters--) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Ad esempio, se un master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/java/slide-layout/).
{{% /alert %}}

## **Accesso ai Slide Master**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **Visualizza** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usare la collezione `getMasters()` per accedere ai master slide:

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

È inoltre possibile ottenere il master slide utilizzato da una diapositiva normale tramite il suo layout:

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

## **Cosa contiene un Slide Master**

Un master slide è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà di diapositiva usate dalle diapositive normali e di layout. I membri specifici del master sono elencati nella pagina API di [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/).

I membri più comunemente usati del master slide includono:

| Membro | Scopo |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes()` | Contiene le forme posizionate sul master, come loghi, cornici di immagine e testo condiviso. |
| `getLayoutSlides()` | Contiene le layout slide che appartengono al master. |
| `getThemeManager()` | Fornisce l’accesso alle API del tema del master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le diapositive normali che dipendono dal master attraverso i loro layout. |

## **Aggiungere un’immagine a un Slide Master**

Quando si aggiunge un’immagine a un master slide, essa appare sulle diapositive che usano layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L’esempio seguente aggiunge un logo al primo master slide:

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

Per ulteriori informazioni sui frame immagine, vedere [Picture Frame](/slides/it/java/picture-frame/).

## **Lavorare con i Segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ciascun layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi per i segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci Segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sulla layout slide che appartiene al master:

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

È inoltre possibile formattare le forme segnaposto già presenti su un master slide. L’esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/slides/it/java/manage-placeholder/) e [Text Formatting](/slides/it/java/text-formatting/).

## **Modificare lo Sfondo di un Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L’esempio seguente imposta un colore di sfondo solido per il primo master slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/java/presentation-background/) e [Presentation Theme](/slides/it/java/presentation-theme/).

## **Clonare un Slide Master in un’Altra Presentazione**

Utilizzare [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) per copiare un master slide in un’altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

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

Se è necessario clonare le diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/java/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. Ciò è utile quando sezioni diverse richiedono branding, struttura pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

L’esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, crea una layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Confrontare Slide Master**

I master slide possono essere confrontati con il metodo `equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/java/compare-slides/).

## **Impostare la Visualizzazione Slide Master come Visualizzazione Predefinita**

Utilizzare il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. L’esempio seguente apre la presentazione in visualizzazione Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/java/save-presentation/).

## **Rimuovere i Master Slide Inutilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione del modello.

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

È anche possibile utilizzare il metodo low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Qual è la differenza tra un slide master e una layout slide?**

Un slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a un slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Utilizzare più master quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere i segnaposti a un master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposti alle layout slide. Inserire gli elementi visivi condivisi e la formattazione condivisa nel master slide, quindi posizionare i segnaposti di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare un master slide che è ancora in uso?**

No. Un master slide con diapositive dipendenti non può essere rimosso in modo sicuro direttamente. Spostare prima quelle diapositive su layout sotto un altro master, oppure utilizzare un metodo di pulizia dei master non utilizzati che rimuove solo i master non in uso.