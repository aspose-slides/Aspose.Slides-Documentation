---
title: Gestire i temi di presentazione in .NET
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/net/presentation-theme/
keywords:
  - Tema PowerPoint
  - Tema della presentazione
  - Tema della diapositiva
  - Imposta tema
  - Modifica tema
  - Gestisci tema
  - Colore del tema
  - Palette aggiuntiva
  - Carattere del tema
  - Stile del tema
  - Effetto del tema
  - PowerPoint
  - OpenDocument
  - Presentazione
  - .NET
  - C#
  - Aspose.Slides
description: "Temi master di presentazione in Aspose.Slides per .NET per creare, personalizzare e convertire file PowerPoint con branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così una modifica del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite la proprietà [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/masterthememanager/overridetheme/), un layout può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), e una diapositiva individuale può fare lo stesso. In pratica, il tema effettivo per una diapositiva viene risolto attraverso questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni sul tema: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che l'ereditarietà e le sovrascritture sono state risolte.

## **Ispezionare un Tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/) espone il [ColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/colorscheme/), il [FontScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/fontscheme/) e il [FormatScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/formatscheme/) del tema. Ispezionare queste collezioni prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna perché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e riporta quante voci di stile di sfondo, riempimento, linea ed effetto sono memorizzate nel tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Se un file utilizza più master, non presumere che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e usa il flusso di lavoro del tema effettivo mostrato più avanti in questo articolo quando potrebbero esserci sovrascritture di layout o diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/). Quando si cambia la voce corrispondente nello [IColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/icolorscheme/) del tema, tutti gli oggetti che fanno ancora riferimento a quel colore del tema vengono risolti rispetto al nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

L'esempio end‑to‑end seguente crea una forma che utilizza `Accent4`, cambia il colore `Accent4` del tema in rosso, salva la presentazione, la riapre e stampa il colore di riempimento effettivo:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Poiché il rettangolo rimane collegato a `Accent4`, il suo colore visibile diventa rosso dopo che il tema è stato modificato. Se sostituisci il colore dello schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Usare i Colori dalla Palette Aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite [ColorTransformOperation](https://reference.aspose.com/slides/it/net/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla palette aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema.  
**2** - Varianti più chiare e più scure prodotte dai colori principali del tema.

L'esempio seguente crea sei rettangoli basati su `Accent4`, applica trasformazioni di luminanza a cinque di essi e salva il risultato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia successivamente, i colori trasformati vengono ricalcolati dal nuovo valore di `Accent4`.

### **Mappare i Valori `SchemeColor` negli Slot `IColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre [IColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/icolorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set di caratteri principale per i titoli e un set di caratteri secondario per il testo del corpo. Le proprietà [FontScheme.Major](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/major/) e [FontScheme.Minor](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/minor/) espongono questi set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` - Carattere del corpo Latin (Carattere Latin Minore)
* `+mj-lt` - Carattere del titolo Latin (Carattere Latin Maggiore)
* `+mn-ea` - Carattere del corpo East Asian (Carattere East Asian Minore)
* `+mj-ea` - Carattere del titolo East Asian (Carattere East Asian Maggiore)

L'esempio seguente crea un titolo che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin secondario del tema. Poi modifica i caratteri del tema e salva il risultato:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Il titolo segue il carattere principale e il testo del corpo segue il carattere secondario. Il testo che ha un nome di carattere esplicito invece di un identificatore di tema non cambierà automaticamente quando lo schema di caratteri del tema cambia.

{{% alert color="info" title="Suggerimento" %}}
Per ulteriori informazioni sui caratteri della presentazione, vedere [PowerPoint Fonts](/slides/it/net/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o Applicare un Tema**

Esistono due flussi di lavoro comuni, e risolvono problemi diversi.

### **Preservare un Tema Sorgente Quando Si Spostano Diapositive**

Se vuoi spostare una diapositiva in un'altra presentazione e preservare il suo design originale, clona il master sorgente nella presentazione di destinazione con [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/), quindi clona la diapositiva con [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) e il master clonato. Questo porta con sé il master, i suoi layout e il tema associato.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Questo è il flusso di lavoro preferito quando la diapositiva sorgente deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare i colori, i caratteri, gli sfondi e gli effetti guidati dal tema.

### **Applicare i Valori del Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema sorgente. I metodi [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initfontschemefrom/), e [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copiano i tre componenti principali del tema nella sovrascrittura.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Ciò cambia il tema utilizzato da quella diapositiva senza modificare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.Clear](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/clear/).

### **Applicare una Sovrascrittura di Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, a meno che una diapositiva specifica non abbia una propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati attraverso il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/net/aspose.slides.theme/layoutslidethememanager/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Usa un tema a livello di master o di presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura di layout quando una famiglia di layout necessita di uno stile diverso, e una sovrascrittura di diapositiva solo per eccezioni reali. Un eccesso di sovrascritture a livello di diapositiva rende più difficile prevedere le modifiche globali successive al tema.

## **Aggiornare gli Stili di Sfondo del Tema**

I riempimenti di sfondo del tema sono memorizzati in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento effettivamente memorizzate in questa collezione perché l'interfaccia può combinare i riempimenti del tema con i colori del tema e altri riferimenti di stile.

![Galleria stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la collezione memorizzata e l'attuale [Background.StyleIndex](https://reference.aspose.com/slides/it/net/aspose.slides/background/styleindex/). `StyleIndex` utilizza `0` per nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo tematici. Questo è diverso dall'indicizzare direttamente la collezione .NET, dove `[0]` indica il primo elemento memorizzato. Non presumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

L'esempio seguente riporta il conteggio dei riempimenti di sfondo disponibili, assegna un riferimento di sfondo tematico al primo master e salva la presentazione:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Il risultato visibile dipende dall'entrata del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva usa il proprio sfondo, modificare solo lo sfondo del master potrebbe non cambiare quella diapositiva. Usa [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/) quando devi conoscere lo sfondo finale dopo l'applicazione dell'ereditarietà.

{{% alert color="warning" title="Attenzione" %}}
Non trattare `StyleIndex` come un indice di collezione a base zero. Evita inoltre di codificare in modo rigido un numero di stile da un file e presumere che abbia lo stesso aspetto in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Suggerimento" %}}
Per la formattazione diretta dello sfondo e l'ereditarietà dello sfondo, vedere [Presentation Background](/slides/it/net/presentation-background/).
{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formattazione del tema contiene collezioni separate di [FillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/linestyles/), e [EffectStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/effectstyles/) . I temi tipici di Office spesso contengono tre voci principali di stile che corrispondono visivamente a una formattazione sottile, moderata e intensa, ma il codice dovrebbe ispezionare ogni collezione invece di presumere un conteggio fisso.

![Effetti del tema sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in C#, l'indice della collezione è a base zero: `[0]` è il primo stile memorizzato e `[2]` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [IShapeStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che fanno riferimento a quello stile; le forme con formattazione diretta possono rimanere inalterate.

L'esempio seguente verifica che le voci di stile richieste esistano, cambia il primo stile di linea, cambia il terzo stile di riempimento, abilita un'ombra esterna nel terzo stile di effetto e salva il risultato:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto ottiene un'ombra esterna con una distanza di 10 punti. Il risultato visivo esatto dipende ancora da quali slot di stile ogni forma fa riferimento e se la formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linee, riempimenti e impostazioni dell'ombra](presentation-design_11.png)

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi ti dicono cosa è definito a un determinato livello. I valori effettivi ti indicano cosa una diapositiva o forma utilizza effettivamente dopo che l'ereditarietà e le sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Per uno sfondo, usa [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/), e per un riempimento, usa [FillFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/geteffective/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento di forma da una diapositiva:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Usa i dati effettivi per diagnostica di rendering, validazione e confronti. Se ispezioni solo [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/), potresti perdere una sovrascrittura di master, layout, diapositiva o forma che modifica l'aspetto finale.

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/net/aspose.slides.theme/slidethememanager/) della diapositiva e inizializza il suo tema di sovrascrittura. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando si sposta una diapositiva preservandone l'aspetto originale, clona il master sorgente nella destinazione e clona la diapositiva con quel master usando [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/). Questo mantiene insieme il master, i layout e il tema.

**Come posso vedere i valori effettivi dopo l'ereditarietà e le sovrascritture?**

Usa [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) per una diapositiva o un tema di layout e i metodi corrispondenti di dati effettivi per oggetti di formato come [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/) e [FillFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/geteffective/). Queste API restituiscono i valori risolti dopo l'applicazione dell'ereditarietà e delle sovrascritture.