---
title: Gestire i master slide della presentazione in .NET
linktitle: Master slide
type: docs
weight: 80
url: /it/net/slide-master/
keywords:
- master slide
- master slide
- slide master PPT
- master slide multipli
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide non utilizzato
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per .NET: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce le impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo abituale per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per .NET supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali non fanno solitamente riferimento direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, che appartiene a una master slide.

La gerarchia è:

1. **Slide master** - definisce il design condiviso e il tema.  
1. **Layout slide** - definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di master slide, layout slide e normal slide](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dall'interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) . Tutte le master slide in una presentazione sono disponibili tramite la collezione [Presentation.Masters](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/masters/) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Ad esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/net/slide-layout/) .
{{% /alert %}}

## **Accesso ai master slide**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **Visualizza** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizza la collezione `Masters` per accedere ai master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

È anche possibile ottenere il master slide usato da una diapositiva normale tramite il suo layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Cosa contiene un master slide**

Un master slide è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/) , quindi espone molte delle stesse proprietà delle diapositive usate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) .

I membri del master slide usati più frequentemente includono:

| Member | Scopo |
| --- | --- |
| `Background` | Imposta lo sfondo della diapositiva a livello di master. |
| `Shapes` | Memorizza le forme posizionate sul master, come loghi, cornici per immagini e testo condiviso. |
| `LayoutSlides` | Memorizza le layout slide che appartengono al master. |
| `ThemeManager` | Fornisce l'accesso alle API del tema del master. |
| `HeaderFooterManager` | Gestisce intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `GetDependingSlides` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'immagine a un master slide**

Quando aggiungi un'immagine a un master slide, essa appare sulle diapositive che utilizzano i layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo al primo master slide:

```csharp
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

Per ulteriori informazioni sulle cornici immagine, vedere [Picture Frame](/slides/it/net/picture-frame/) .

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove vengono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavora con la layout slide che appartiene al master:

```csharp
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

Puoi anche formattare le forme segnaposto che esistono già su un master slide. Il seguente esempio trova il segnaposto titolo e applica un riempimento a gradiente lineare:

```csharp
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

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/slides/it/net/manage-placeholder/) e [Text Formatting](/slides/it/net/text-formatting/) .

## **Modificare lo sfondo di un master slide**

Uno sfondo master è ereditato dai layout e dalle diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/net/presentation-background/) e [Presentation Theme](/slides/it/net/presentation-theme/) .

## **Clonare un master slide in un'altra presentazione**

Usa [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/) per copiare un master slide in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Se devi clonare le diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/net/clone-slides/) .

## **Aggiungere più master slide**

Una presentazione può contenere più master slide. Questo è utile quando sezioni diverse richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea una layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```csharp
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

## **Confrontare i master slide**

I master slide possono essere confrontati con il metodo `Equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/) . Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, o valori dinamici dei segnaposti, come la data corrente.

```csharp
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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/net/compare-slides/) .

## **Impostare la visualizzazione Slide Master come visualizzazione predefinita**

Usa la proprietà `LastView` su [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. Il seguente esempio apre la presentazione in visualizzazione Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Per ulteriori impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/net/save-presentation/) .

## **Rimuovere i master slide non utilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione del modello.

Usa [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/it/net/aspose.slides/masterslidecollection/removeunused/) per rimuovere i master non usati dalla collezione `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Puoi anche usare il metodo low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual è la differenza tra un slide master e una layout slide?**

Un slide master definisce le impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a un master slide e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Usa più master quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere i segnaposti a un master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungi i segnaposti alle layout slide. Metti gli elementi visivi condivisi e la formattazione comune sul master slide, poi inserisci i segnaposti di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare un master slide che è ancora in uso?**

No. Un master slide che ha diapositive dipendenti non può essere rimosso in modo sicuro. Prima sposta quelle diapositive su layout di un altro master, o usa un metodo di pulizia dei master non usati che rimuove solo i master privi di dipendenze.