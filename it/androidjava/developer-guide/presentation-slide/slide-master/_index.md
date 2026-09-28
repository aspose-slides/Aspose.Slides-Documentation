---
title: Gestisci i master slide della presentazione su Android
linktitle: Master slide
type: docs
weight: 70
url: /it/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per Android via Java: accedi, modifica, clona, confronta e rimuovi i master slide nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di progettazione condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides for Android via Java supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una master slide.

La gerarchia è:

1. **Slide master** - definisce il design e il tema condivisi.  
1. **Layout slide** - definisce una disposizione specifica di segnaposto e la formattazione a livello di layout.  
1. **Normal slide** - contiene il vero contenuto della presentazione e utilizza una layout slide.

![La gerarchia di master slide, layout slide e slide normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dall'interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslide/) . Tutti i master slide in una presentazione sono disponibili tramite la collezione [Presentation.getMasters](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getMasters--) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/). Per l'intera superficie API di Android via Java, vedere la [com.aspose.slides API reference](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/androidjava/slide-layout/).
{{% /alert %}}

## **Accesso ai Master Slide**

In PowerPoint, è possibile aprire la visualizzazione Slide Master dal menu **View** > **Slide Master**.

![Il comando Slide Master nella scheda View di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizzare la collezione `getMasters()` per accedere ai master slide:

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

È inoltre possibile ottenere la master slide utilizzata da una diapositiva normale tramite il suo layout:

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

## **Cosa contiene un Slide Master**

Un master slide è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà della diapositiva utilizzate dalle diapositive normali e di layout.

I membri più comunemente usati del master slide includono:

| Membro | Scopo |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes()` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `getLayoutSlides()` | Memorizza le layout slide che appartengono al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le diapositive normali che dipendono dal master attraverso i loro layout. |

## **Aggiungere un'Immagine a un Slide Master**

Quando aggiungi un'immagine a un master slide, essa appare sulle diapositive che utilizzano layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo al primo master slide:

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

Per ulteriori informazioni sulle cornici di immagine, vedere [Picture Frame](/slides/it/androidjava/picture-frame/).

## **Controllare la Visibilità della Grafica Master**

Usa [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) per nascondere la grafica master ereditata, come loghi o forme decorative, senza eliminarla dal master. Passa `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) sulla diapositiva che deve omettere quelle grafiche e mantienilo `true` sulle diapositive che devono visualizzarle.

Il seguente esempio autonomo crea una banda decorativa blu su un master e due diapositive che utilizzano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposto originali della diapositiva iniziale.

### **Scegliere l'Ambito dell'Impostazione**

Una diapositiva normale utilizza il suo master tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getLayoutSlide--) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) nasconde la grafica master per le diapositive che utilizzano quel layout condiviso, anche se la loro impostazione è `true`. Per nascondere le grafiche su una sola diapositiva, modificare la proprietà della diapositiva e lasciare invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sulla master slide stessa. Su un master, [getShowMasterShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) restituisce sempre `false`, e passare `true` a [setShowMasterShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) genera un'eccezione. Applicala invece a una diapositiva normale o a un layout.

### **Distinguere la Grafica dallo Sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondi la grafica master | Controlla la visibilità delle forme master ereditate senza cancellarle o modificare le forme proprie della diapositiva. |
| Modifica il riempimento dello sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine di sfondo. La grafica master è costituita da forme separate e può rimanere visibile su quello sfondo. Vedi [Presentation Background](/slides/it/androidjava/presentation-background/). |
| Elimina una forma dal master | Rimuove la forma di origine condivisa, così non è più disponibile per alcuna diapositiva che utilizza quel master. |

## **Lavorare con i Segnaposto**

I segnaposto sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposto sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposto sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci Segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposto con Aspose.Slides, lavorare con la layout slide che appartiene al master:

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

Puoi anche formattare le forme segnaposto già presenti su un master slide. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

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

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione dei segnaposto e del testo, vedere [Set Prompt Text in Placeholder](/slides/it/androidjava/manage-placeholder/) e [Text Formatting](/slides/it/androidjava/text-formatting/).

## **Modificare lo Sfondo di un Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master slide:

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

Per argomenti correlati, vedere [Presentation Background](/slides/it/androidjava/presentation-background/) e [Presentation Theme](/slides/it/androidjava/presentation-theme/).

## **Clonare un Slide Master in un'Altra Presentazione**

Usa [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) per copiare un master slide in un'altra presentazione. Il master copiato può poi essere utilizzato da layout e diapositive nella presentazione di destinazione.

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

Se è necessario clonare diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/androidjava/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. È utile quando sezioni diverse richiedono brand, struttura di pagina o impostazioni di tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **Confrontare i Slide Master**

I master slide possono essere confrontati con il metodo `equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/). Il confronto verifica la struttura e i contenuti statici, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, o valori dinamici dei segnaposto, come la data corrente.

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/androidjava/compare-slides/).

## **Impostare la Vista Slide Master come Vista Predefinita**

Utilizza il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. Il seguente esempio apre la presentazione nella vista Slide Master:

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

Per altre impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/androidjava/save-presentation/).

## **Rimuovere le Master Slide Inutilizzate**

Le presentazioni a volte contengono master slide che non sono più utilizzate da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Utilizza `removeUnused` per rimuovere i master inutilizzati dalla collezione `getMasters()`:

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

Puoi anche utilizzare il metodo a basso codice [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

**Qual è la differenza tra uno slide master e una layout slide?**

Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a uno slide master e definisce una disposizione specifica di segnaposto. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Utilizza più master quando sezioni diverse richiedono sistemi visivi o branding differenti.

**Dovrei aggiungere i segnaposto a un master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungi i segnaposto alle layout slide. Inserisci gli elementi visivi condivisi e la formattazione condivisa sul master slide, poi posiziona i segnaposto di contenuto sui layout che utilizzeranno le diapositive normali.

**Posso eliminare un master slide che è ancora in uso?**

No. Un master slide che ha diapositive dipendenti non può essere rimosso in modo sicuro direttamente. Prima sposta quelle diapositive su layout sotto un altro master, oppure utilizza un metodo di pulizia dei master inutilizzati che rimuove solo i master non in uso.