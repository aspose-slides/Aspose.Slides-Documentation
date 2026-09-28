---
title: Gestire i master delle diapositive della presentazione in Java
linktitle: Master slide
type: docs
weight: 70
url: /it/java/slide-master/
keywords:
- master diapositiva
- master diapositiva
- master diapositiva PPT
- master diapositiva multipli
- confrontare master diapositiva
- sfondo
- segnaposto
- clonare master diapositiva
- copiare master diapositiva
- duplicare master diapositiva
- master diapositiva non utilizzata
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestire i master slide in Aspose.Slides per Java: accedere, modificare, clonare, confrontare e rimuovere i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare uno slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides for Java supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non si riferiscono direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una master slide.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.
1. **Normal slide** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di master slide, layout slide e normal slide](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dall'interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) . Tutte le master slide in una presentazione sono disponibili attraverso la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasters--) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/java/slide-layout/) .
{{% /alert %}}

## **Accesso alle Slide Master**

In PowerPoint, è possibile aprire la vista Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda View di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizzare la collezione `getMasters()` per accedere alle master slide:

```java
import com.aspose.slides.*;

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

È anche possibile ottenere la master slide usata da una diapositiva normale attraverso il suo layout:

```java
import com.aspose.slides.*;

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

## **Cosa contiene una Slide Master**

Una master slide è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà della diapositiva usate da diapositive normali e layout. I membri specifici della master sono elencati nella pagina API [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) .

I membri più comunemente usati di una master slide includono:

| Membro | Scopo |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes()` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `getLayoutSlides()` | Memorizza le layout slide che appartengono al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema del master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'immagine a una Slide Master**

Quando si aggiunge un'immagine a una master slide, essa appare nelle diapositive che utilizzano layout da quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo alla prima master slide:

```java
import com.aspose.slides.*;

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

Per ulteriori informazioni sui cornici immagine, vedere [Picture Frame](/slides/it/java/picture-frame/) .

## **Controllare la visibilità della grafica del master**

Utilizzare [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) per nascondere la grafica ereditata dal master, come loghi o forme decorative, senza eliminarla dal master. Passare `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) sulla diapositiva che deve omettere tali grafiche e mantenerlo `true` sulle diapositive che devono visualizzarle.

Il seguente esempio autonomo crea una banda decorativa blu su un master e due diapositive che utilizzano lo stesso layout vuoto. La banda è visibile nella prima diapositiva e nascosta nella seconda. Non è necessaria alcuna presentazione o immagine di input.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Scegliere l'ambito dell'impostazione**

Una diapositiva normale utilizza il suo master tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getLayoutSlide--) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) nasconde la grafica del master per le diapositive che usano quel layout condiviso, anche se la loro impostazione è `true`. Per nascondere la grafica in una sola diapositiva, modificare la proprietà della diapositiva e lasciare invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sulla master slide stessa. Su un master, [getShowMasterShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterslide/#getShowMasterShapes--) restituisce sempre `false`, e passare `true` a [setShowMasterShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) genera un'eccezione. Applicarla invece a una diapositiva normale o a un layout.

### **Distinguere la grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondere la grafica del master | Controlla la visibilità delle forme ereditate dal master senza eliminarle o modificare le forme proprie della diapositiva. |
| Modificare il riempimento dello sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine di sfondo. La grafica del master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedere [Presentation Background](/slides/it/java/presentation-background/). |
| Eliminare una forma dal master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per nessuna diapositiva che utilizza quel master. |

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sui layout slide. La master slide fornisce lo stile e il tema condivisi che questi layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella vista Slide Master.

![Il comando Inserisci segnaposto nella vista Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare con il layout slide che appartiene al master:

```java
import com.aspose.slides.*;

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

È anche possibile formattare le forme segnaposto già presenti su una master slide. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Segnaposto del titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione dei segnaposti e del testo, vedere [Set Prompt Text in Placeholder](/slides/it/java/manage-placeholder/) e [Text Formatting](/slides/it/java/text-formatting/) .

## **Modificare lo sfondo di una Slide Master**

Uno sfondo del master è ereditato dai layout e dalle diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per la prima master slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Per argomenti correlati, vedere [Presentation Background](/slides/it/java/presentation-background/) e [Presentation Theme](/slides/it/java/presentation-theme/) .

## **Clonare una Slide Master in un'altra presentazione**

Utilizzare [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) per copiare una master slide in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```java
import com.aspose.slides.*;

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

Se è necessario clonare le diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/java/clone-slides/) .

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. È utile quando diverse sezioni richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire le master slide](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Confrontare le Slide Master**

Le master slide possono essere confrontate con il metodo `equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/). Il confronto verifica la struttura e i contenuti statici, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta gli identificatori unici, come gli ID delle diapositive, né i valori dinamici dei segnaposti, come la data corrente.

```java
import com.aspose.slides.*;

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/java/compare-slides/) .

## **Impostare la vista Slide Master come vista predefinita**

Utilizzare il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/) per controllare la vista che PowerPoint apre per prima. Il seguente esempio apre la presentazione nella vista Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori impostazioni della vista, vedere [Save Presentation](/slides/it/java/save-presentation/) .

## **Rimuovere le Master Slide non utilizzate**

Le presentazioni a volte contengono master slide che non sono più usate da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Utilizzare `removeUnused` per rimuovere i master inutilizzati dalla collezione `getMasters()` :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

È inoltre possibile utilizzare il metodo low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una slide master e una layout slide?**

Una slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a una slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dalla master.

**Una presentazione può contenere diverse slide master?**

Sì. Una presentazione può contenere diverse slide master. Utilizzare più master quando diverse sezioni richiedono sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a una master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposti alle layout slide. Posizionare gli elementi visivi condivisi e la formattazione condivisa sulla master slide, quindi inserire i segnaposti di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare una master slide che è ancora in uso?**

No. Una master slide che ha diapositive dipendenti non può essere rimossa in modo sicuro direttamente. Spostare prima quelle diapositive su layout sotto un altro master, oppure utilizzare un metodo di pulizia dei master inutilizzati che rimuove solo i master non in uso.