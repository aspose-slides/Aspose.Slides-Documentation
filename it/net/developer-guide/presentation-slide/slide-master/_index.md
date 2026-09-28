---
title: Gestisci i master delle diapositive della presentazione in .NET
linktitle: Master diapositiva
type: docs
weight: 80
url: /it/net/slide-master/
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
- .NET
- C#
- Aspose.Slides
description: "Gestisci i master delle diapositive in Aspose.Slides per .NET: accedi, modifica, clona, confronta e rimuovi i master delle diapositive in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di progettazione condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per .NET supporta lo stesso modello. Una presentazione può contenere una o più slide master e ogni slide master può contenere diverse slide di layout. Le diapositive normali di solito non si riferiscono direttamente a una slide master. Invece, una diapositiva normale utilizza una slide di layout, e quella slide di layout appartiene a una slide master.

La gerarchia è:

1. **Slide master** - definisce il design e il tema condivisi.  
1. **Layout slide** - definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto effettivo della presentazione e utilizza una slide di layout.

![La gerarchia di slide master, slide di layout e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, uno slide master è rappresentato dall'interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/). Tutte le slide master in una presentazione sono disponibili tramite la collezione [Presentation.Masters](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/masters/), che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, il livello più specifico prevale. Per esempio, se uno slide master e una slide di layout definiscono entrambi uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle slide di layout, vedere [Apply or Change Slide Layouts](/slides/it/net/slide-layout/).
{{% /alert %}}

## **Accesso alle Slide Master**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda View di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usare la collezione `Masters` per accedere alle slide master:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

È anche possibile ottenere la slide master usata da una diapositiva normale attraverso il suo layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Cosa contiene uno Slide Master**

Uno slide master è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà delle diapositive utilizzate da diapositive normali e di layout. I membri specifici del master sono elencati nella pagina API di [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/).

I membri di slide master più comunemente usati includono:

| Membro | Scopo |
| --- | --- |
| `Background` | Imposta lo sfondo della diapositiva a livello master. |
| `Shapes` | Memorizza le forme posizionate sul master, come loghi, riquadri immagine e testo condiviso. |
| `LayoutSlides` | Memorizza le slide di layout appartenenti al master. |
| `ThemeManager` | Fornisce l'accesso alle API del tema master. |
| `HeaderFooterManager` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `GetDependingSlides` | Restituisce le diapositive normali che dipendono dal master attraverso i loro layout. |

## **Aggiungere un'immagine a uno Slide Master**

Quando si aggiunge un'immagine a una slide master, essa appare sulle diapositive che usano layout da quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L'esempio seguente aggiunge un logo alla prima slide master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Per ulteriori informazioni sui riquadri immagine, vedere [Picture Frame](/slides/it/net/picture-frame/).

## **Controllare la visibilità della grafica del master**

Usare [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/showmastershapes/) per nascondere la grafica ereditata dal master, come loghi o forme decorative, senza eliminarla dal master. Impostare [Slide.ShowMasterShapes](https://reference.aspose.com/slides/it/net/aspose.slides/slide/showmastershapes/) su `false` sulla diapositiva che dovrebbe omettere quelle grafiche e mantenerlo `true` su quelle che dovrebbero visualizzarle.

L'esempio autonomo seguente crea una banda decorativa blu su un master e due diapositive che usano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposti propri della diapositiva iniziale.

### **Scegliere l'ambito dell'impostazione**

Una diapositiva normale utilizza il suo master attraverso [ISlide.LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/layoutslide/) e [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/masterslide/). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Impostare [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide/showmastershapes/) su `false` nasconde le grafiche del master per le diapositive che usano quel layout condiviso, anche se la loro impostazione è `true`. Per nascondere le grafiche su una sola diapositiva, modificare la proprietà della diapositiva e lasciare invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sulla slide master stessa. Su un master restituisce sempre `false`, e assegnare `true` genera `NotSupportedException`. Applicarla a una diapositiva normale o a un layout invece.

### **Distinguere la grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondi la grafica del master | Controlla la visibilità delle forme ereditate dal master senza eliminarle o modificare le forme della diapositiva. |
| Modifica il riempimento dello sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine dello sfondo. La grafica del master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedi [Sfondo della presentazione](/slides/it/net/presentation-background/). |
| Elimina una forma dal master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per alcuna diapositiva che usa quel master. |

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti su slide di layout. La slide master fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi per i segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare con la slide di layout che appartiene al master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

È anche possibile formattare le forme segnaposto già esistenti su una slide master. L'esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/slides/it/net/manage-placeholder/) e [Text Formatting](/slides/it/net/text-formatting/).

## **Modificare lo sfondo di uno Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L'esempio seguente imposta un colore di sfondo solido per la prima slide master:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Per argomenti correlati, vedere [Sfondo della presentazione](/slides/it/net/presentation-background/) e [Tema della presentazione](/slides/it/net/presentation-theme/).

## **Clonare uno Slide Master in un'altra presentazione**

Usare [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/) per copiare una slide master in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Se è necessario clonare le diapositive normali insieme al loro master, vedere [Clona diapositive](/slides/it/net/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più slide master. Questo è utile quando diverse sezioni richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire slide master](slide-master_9.jpg)

L'esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Confrontare le Slide Master**

Le slide master possono essere confrontate con il metodo `Equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come ID delle diapositive, o valori dinamici di segnaposti, come la data corrente.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Per ulteriori informazioni, vedere [Confronta diapositive della presentazione](/slides/it/net/compare-slides/).

## **Impostare la visualizzazione Slide Master come visualizzazione predefinita**

Usare la proprietà `LastView` su [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. L'esempio seguente apre la presentazione in visualizzazione Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Per altre impostazioni di visualizzazione, vedere [Salva presentazione](/slides/it/net/save-presentation/).

## **Rimuovere le Slide Master non utilizzate**

Le presentazioni a volte contengono slide master che non sono più utilizzate da alcuna diapositiva normale. Rimuovere i master non usati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Usare [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/it/net/aspose.slides/masterslidecollection/removeunused/) per rimuovere i master non usati dalla collezione `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

È anche possibile utilizzare il metodo low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual è la differenza tra uno slide master e una slide di layout?**

Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una slide di layout appartiene a uno slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale usa una slide di layout, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi slide master?**

Sì. Una presentazione può contenere diversi slide master. Utilizzare più master quando sezioni diverse richiedono sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a una slide master o a una slide di layout?**

Nella maggior parte dei casi, aggiungere i segnaposti alle slide di layout. Mettere gli elementi visivi condivisi e la formattazione comune sul master, poi posizionare i segnaposti di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare una slide master ancora in uso?**

No. Una slide master che ha diapositive dipendenti non può essere rimossa in modo sicuro. Prima spostare quelle diapositive su layout sotto un altro master, oppure utilizzare un metodo di pulizia dei master non usati che rimuove solo i master che non sono in uso.