---
title: Gestire i temi di presentazione in .NET
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/net/presentation-theme/
keywords:
- tema PowerPoint
- tema della presentazione
- tema della diapositiva
- imposta tema
- cambia tema
- gestire tema
- tema esterno
- THMX
- colore del tema
- tavolozza aggiuntiva
- carattere del tema
- stile del tema
- effetto del tema
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i temi master delle presentazioni in Aspose.Slides per .NET per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce un insieme coordinato di colori, caratteri, stili di sfondo, riempimenti, linee ed effetti. Gli oggetti sensibili al tema fanno riferimento a queste definizioni condivise invece di memorizzare ogni proprietà visiva come valore fisso, così una modifica del tema può aggiornare molti oggetti contemporaneamente.

In Aspose.Slides, il tema a livello di presentazione è disponibile tramite la proprietà [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/). Una presentazione può anche contenere sovrascritture del tema a livelli inferiori. Un master può sovrascrivere il tema della presentazione tramite [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/masterthememanager/overridetheme/), un layout può sovrascrivere il tema ereditato tramite [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), e una singola diapositiva può fare lo stesso. In pratica, il tema effettivo per una diapositiva è risolto tramite questa catena di ereditarietà: tema della presentazione, sovrascrittura del master, sovrascrittura del layout e sovrascrittura della diapositiva.

![Componenti del tema: colori, caratteri, stili di sfondo ed effetti](theme-constituents.png)

Le sezioni seguenti mostrano i flussi di lavoro più comuni relativi ai temi: ispezionare un tema, modificare colori e caratteri, copiare o applicare un tema, aggiornare gli stili di sfondo ed effetti, e leggere i valori effettivi dopo che ereditarietà e sovrascritture sono state risolte.

## **Ispezionare un Tema**

L'oggetto [MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/) espone lo [ColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/colorscheme/), lo [FontScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/fontscheme/) e lo [FormatScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/mastertheme/formatscheme/). Ispezionare queste raccolte prima di modificarle è particolarmente utile quando una presentazione proviene da una fonte esterna, poiché il numero e il contenuto delle voci di stile possono variare.

L'esempio seguente legge le proprietà principali del tema e riporta quanti stili di sfondo, riempimento, linea ed effetto sono memorizzati nel tema:

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

Se un file utilizza più master, non dare per scontato che ogni diapositiva abbia lo stesso tema effettivo. Ispeziona il master associato alla diapositiva e utilizza il flusso di lavoro del tema effettivo mostrato più avanti in questo articolo quando potrebbero essere presenti sovrascritture di layout o diapositiva.

## **Modificare i Colori del Tema**

I riempimenti, le linee e il testo sensibili al tema possono fare riferimento a un colore logico dell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/). Quando cambi la voce corrispondente nello [IColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/icolorscheme/) del tema, tutti gli oggetti che fanno ancora riferimento a quel colore del tema vengono risolti rispetto al nuovo valore. Gli oggetti che usano un colore RGB diretto non vengono modificati da un aggiornamento del colore del tema.

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

Poiché il rettangolo resta collegato a `Accent4`, il suo colore visibile diventa rosso dopo la modifica del tema. Se sostituisci il colore di schema con un colore diretto sulla forma, le modifiche successive a `Accent4` non influenzeranno più quel riempimento.

### **Usare i Colori della Tavolozza Aggiuntiva**

PowerPoint genera varianti più chiare e più scure da un colore del tema applicando trasformazioni di colore. Aspose.Slides espone queste trasformazioni tramite [ColorTransformOperation](https://reference.aspose.com/slides/it/net/aspose.slides/colortransformoperation/).

![Colori principali del tema e colori più chiari e più scuri generati dalla tavolozza aggiuntiva](additional-palette-colors.png)

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

Queste varianti rimangono basate sul colore del tema. Se `Accent4` cambia in seguito, i colori trasformati vengono ricalcolati dal nuovo valore `Accent4`.

### **Mappare i Valori `SchemeColor` agli Slot `IColorScheme`**

L'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/) utilizza `Text1`, `Background1`, `Text2` e `Background2`, mentre [IColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/icolorscheme/) espone gli stessi slot del tema come `Dark1`, `Light1`, `Dark2` e `Light2`. La mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Questi sono nomi alternativi per gli stessi slot del tema; non sono valori convertiti dinamicamente da una forma all'altra.

## **Modificare i Caratteri del Tema**

Uno schema di caratteri del tema contiene un set di caratteri principali per le intestazioni e un set minore per il corpo del testo. Le proprietà [FontScheme.Major](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/major/) e [FontScheme.Minor](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/minor/) espongono tali set.

Gli identificatori di caratteri del tema compatibili con PowerPoint possono essere usati nella formattazione del testo:

* `+mn-lt` - Carattere del Corpo Latin (Minor Latin Font)
* `+mj-lt` - Carattere dell'Intestazione Latin (Major Latin Font)
* `+mn-ea` - Carattere del Corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Carattere dell'Intestazione East Asian (Major East Asian Font)

L'esempio seguente crea un'intestazione che utilizza il carattere Latin principale del tema e una riga di corpo che utilizza il carattere Latin minore del tema. Poi cambia i caratteri del tema e salva il risultato:

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

L'intestazione segue il carattere principale e il corpo del testo segue il carattere minore. Un testo che ha un nome di carattere esplicito invece di un identificatore del tema non cambierà automaticamente quando lo schema dei caratteri del tema varia.

Le raccolte di caratteri principali e secondari possono contenere anche mappature di caratteri per sistemi di scrittura individuali, come cirillico, arabo, giapponese, georgiano e thaana. Per ispezionare, aggiungere, sostituire o rimuovere queste mappature, vedere [Caratteri del Tema Specifici per Script](/slides/it/net/script-specific-font-mappings/).

{{% alert color="info" title="Suggerimento" %}}
Per ulteriori informazioni sui caratteri di presentazione, vedere [Caratteri PowerPoint](/slides/it/net/powerpoint-fonts/).
{{% /alert %}}

## **Copiare o Applicare un Tema**

I flussi di lavoro seguenti risolvono diversi problemi legati ai temi.

### **Applicare un Tema Esterno alle Diapositive Dipendenti da un Master**

Usa [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) quando disponi di un file tema PowerPoint (`.thmx`) e vuoi ridisegnare ogni diapositiva che dipende da un master specifico. Seleziona il master dalla raccolta [Presentation.Masters](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/masters/), che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/), e passa il percorso del file tema al metodo.

Il metodo esegue le seguenti operazioni:

1. Crea una nuova diapositiva master basata sul master selezionato.  
1. Applica il tema esterno al nuovo master.  
1. Assegna il nuovo master a tutte le diapositive che in precedenza dipendevano dal master selezionato.  
1. Restituisce il nuovo [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/).

L'esempio seguente applica un tema esterno alle diapositive che dipendono dal primo master, salva la presentazione e riapre il risultato:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Un tema non valido, corrotto o non supportato può generare [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/) o una delle sue sottoclassi legate al formato. Valida i percorsi forniti dagli utenti, gestisci i fallimenti di accesso al file system e salva la presentazione solo dopo che il tema è stato applicato correttamente.

Solo le diapositive che dipendevano dal master selezionato vengono riassegnate. Le diapositive associate ad altri master mantengono i loro master e temi esistenti. I colori, i caratteri, i riempimenti, le linee, gli sfondi e gli effetti sensibili al tema sono risolti rispetto al tema esterno. I formati assegnati direttamente (colori, caratteri, riempimenti e altre formattazioni esplicite) possono rimanere invariati. Le sovrascritture a livello di layout e diapositiva possono anche avere precedenza sui valori ereditati dal nuovo master.

Il tema può fare riferimento a caratteri non disponibili nell'ambiente di runtime. Per una resa coerente ed esportazione, installa i caratteri richiesti, fornisci font tramite [font personalizzati](/slides/it/net/custom-font/), o configura la [sostituzione di caratteri](/slides/it/net/font-substitution/).

Questo è un flusso di lavoro a livello di master diretto: il metodo accetta il percorso di un file `.thmx` e non richiede di creare manualmente sovrascritture di tema a livello di layout o diapositiva.

### **Applicare Temi Esterni Differenti in una Presentazione Multi‑Master**

Quando il master rilevante non è noto in anticipo, ottienilo da una diapositiva rappresentativa tramite [ISlide.LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/layoutslide/) e [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/masterslide/). Conserva i riferimenti ai master originali prima di applicare qualsiasi tema perché ogni chiamata crea un nuovo master nella presentazione.

L'esempio seguente utilizza diapositive di due sezioni per localizzare i loro master e applica un tema esterno diverso a ciascun gruppo:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

La prima chiamata interessa solo le diapositive che dipendevano da `firstGroupMaster`, e la seconda solo quelle che dipendevano da `secondGroupMaster`. Le diapositive appartenenti a qualsiasi altro master non vengono ridisegnate.

### **Conservare il Tema di Origine Quando si Spostano Diapositive**

Se vuoi spostare una diapositiva in un'altra presentazione e preservarne il design originale, clona il master di origine nella presentazione di destinazione con [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/), quindi clona la diapositiva con [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) e il master clonato. In questo modo il master, i suoi layout e il tema associato vengono trasferiti insieme.

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

Questo è il flusso di lavoro consigliato quando la diapositiva di origine deve apparire identica nella destinazione. Clonare semplicemente il contenuto su un master di destinazione non correlato può modificare i colori, i caratteri, gli sfondi e gli effetti guidati dal tema.

### **Applicare i Valori del Tema a una Diapositiva Esistente**

Se la diapositiva di destinazione deve rimanere sul suo master e layout attuali, inizializza una sovrascrittura a livello di diapositiva dal tema di origine. I metodi [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initfontschemefrom/) e [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copiano i tre componenti principali del tema nella sovrascrittura.

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

Questo modifica il tema usato da quella diapositiva senza cambiare il tema ereditato dalle altre diapositive. Per rimuovere la sovrascrittura locale e tornare ai valori ereditati, chiama [OverrideTheme.Clear](https://reference.aspose.com/slides/it/net/aspose.slides.theme/overridetheme/clear/).

### **Applicare una Sovrascrittura del Tema a un Layout**

Una sovrascrittura a livello di layout si applica alle diapositive che usano quel layout, salvo che una diapositiva specifica abbia una propria sovrascrittura. Gli stessi metodi di inizializzazione possono essere usati tramite il [LayoutSlideThemeManager](https://reference.aspose.com/slides/it/net/aspose.slides.theme/layoutslidethememanager/) del layout:

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

Usa un tema a livello di master o presentazione quando molti layout e diapositive devono condividere lo stesso design di base, una sovrascrittura del layout quando una famiglia di layout richiede uno stile diverso, e una sovrascrittura della diapositiva solo per eccezioni reali. Un eccesso di sovrascritture a livello di diapositiva rende più difficile prevedere i cambiamenti globali del tema.

## **Aggiornare gli Stili di Sfondo del Tema**

Gli sfondi del tema sono memorizzati in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint può presentare più scelte di sfondo nella sua interfaccia rispetto al numero di definizioni di riempimento realmente memorizzate in questa raccolta, perché l'interfaccia può combinare riempimenti del tema con colori del tema e altri riferimenti di stile.

![Galleria di stili di sfondo di PowerPoint per un tema di presentazione](presentation-design_8.png)

Prima di usare uno stile di sfondo, ispeziona la raccolta memorizzata e il valore corrente di [Background.StyleIndex](https://reference.aspose.com/slides/it/net/aspose.slides/background/styleindex/). `StyleIndex` usa `0` per nessun riempimento tematico; i valori positivi sono riferimenti a stili di sfondo del tema. Questo è diverso dall'indicizzazione diretta della raccolta .NET, dove `[0]` indica il primo elemento memorizzato. Non presumere che ogni presentazione contenga lo stesso numero di stili di riempimento di sfondo.

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

Il risultato visibile dipende dall'entrata del tema a cui fa riferimento il master e da eventuali sovrascritture di sfondo a livello di layout o diapositiva. Se una diapositiva usa il proprio sfondo, modificare solo lo sfondo del master potrebbe non influenzare quella diapositiva. Usa [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/) quando hai bisogno di conoscere lo sfondo finale dopo l'applicazione dell'eredità.

{{% alert color="warning" title="Avviso" %}}
Non trattare `StyleIndex` come un indice di raccolta basato su zero. Evita inoltre di codificare un numero di stile da un file e presumere che abbia la stessa apparenza in un altro file; le definizioni di stile del tema sono specifiche della presentazione.
{{% /alert %}}

{{% alert color="info" title="Suggerimento" %}}
Per la formattazione diretta dello sfondo e l'eredità dello sfondo, vedere [Sfondo della Presentazione](/slides/it/net/presentation-background/).
{{% /alert %}}

## **Aggiornare gli Effetti del Tema**

Uno schema di formato del tema contiene collezioni separate di [FillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/linestyles/) e [EffectStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/effectstyles/). I temi tipici di Office spesso contengono tre voci di stile principali che corrispondono visivamente a formattazioni sottile, moderata e intensa, ma il codice dovrebbe ispezionare ogni raccolta invece di presumere un conteggio fisso.

![Effetti tematici sottili, moderati e intensi applicati alla stessa forma](presentation-design_10.png)

Quando accedi a queste collezioni in C#, l'indice è basato su zero: `[0]` è il primo stile memorizzato e `[2]` è il terzo. Gli indici di riferimento di stile di una forma sono un concetto separato, esposto tramite [IShapeStyle](https://reference.aspose.com/slides/it/net/aspose.slides/ishapestyle/). Modificare uno stile del tema influisce sulle forme che lo riferiscono; le forme con formattazione diretta possono rimanere inalterate.

L'esempio seguente verifica che le voci di stile richieste esistano, modifica il primo stile di linea, modifica il terzo stile di riempimento, attiva un'ombreggiatura esterna nel terzo stile di effetto e salva il risultato:

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

Per le forme che fanno riferimento a questi slot, il primo stile di linea del tema diventa rosso, il terzo stile di riempimento del tema diventa verde foresta solido, e il terzo stile di effetto aggiunge un'ombreggiatura esterna con una distanza di 10 punti. Il risultato visivo preciso dipende ancora da quali slot di stile ogni forma riferisce e se una formattazione diretta sovrascrive il tema.

![Stili di effetto del tema dopo la modifica di linea, riempimento e ombreggiatura](presentation-design_11.png)

## **Determinare se un Riempimento Solido Effettivo Usa un Colore del Tema**

Un riempimento può essere memorizzato direttamente su un oggetto o ereditato da un paragrafo, layout, master, stile del tema o un altro livello di formattazione. Chiama [IFillFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformat/geteffective/) per risolvere quella gerarchia in un [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/) immutabile. Prima controlla [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/filltype/). Solo quando è `FillType.Solid` dovresti leggere le proprietà del riempimento solido.

Per un riempimento solido, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) restituisce il valore RGB finale renderizzato dopo l'eredità, la ricerca nel tema e le trasformazioni di colore applicate. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) restituisce lo slot logico corrispondente di [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/), come `Text1` o `Accent6`. Un valore `SchemeColor.NotDefined` indica che il riempimento solido effettivo non si basa su un colore di schema. In un flusso di lavoro dove i riempimenti sono o colori del tema o colori RGB diretti, questo valore identifica un riempimento RGB diretto.

Non usare il valore locale [IColorFormat.SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/icolorformat/schemecolor/) da solo per classificare un riempimento. Ad esempio, una porzione di testo può non avere un colore di schema definito localmente, quindi il suo valore locale è `NotDefined`, mentre il suo riempimento effettivo ereditato proviene da un colore tematico e risolve a `Text1` o `Accent6`. Al contrario, `SolidFillSchemeColor` ti dice quale slot logico del tema ha prodotto il colore effettivo, ma non indica da quale livello (oggetto, paragrafo, layout, master o altro) lo slot provenga.

L'esempio seguente carica una presentazione, controlla i riempimenti di forma e di porzione di testo, stampa ogni valore RGB finale e il colore di schema associato, e segnala i riempimenti solidi che non seguiranno le modifiche ai colori del tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Il ramo `NotDefined` fornisce un elenco di audit di riempimenti solidi che non risponderanno alle modifiche negli slot di colore del tema. Revisiona quegli oggetti quando una presentazione deve aderire a una nuova tavolozza di marca. Il valore RGB segnalato mostra comunque l'aspetto attuale, mentre il valore di schema spiega se quell'aspetto è collegato al tema.

Gli oggetti di formato effettivo sono istantanee. Dopo aver modificato il tema della presentazione, una sovrascrittura del tema o qualsiasi formattazione ereditata, chiama nuovamente `GetEffective` e leggi un nuovo oggetto `IFillFormatEffectiveData` prima di confrontare o riportare i colori.

## **Leggere i Valori Effettivi del Tema**

Gli oggetti tema grezzi ti dicono cosa è definito a un livello specifico. I valori effettivi ti dicono cosa usa effettivamente una diapositiva o una forma dopo che ereditarietà e sovrascritture locali sono state risolte. Per una diapositiva, chiama [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Per uno sfondo, usa [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/), e per un riempimento usa [FillFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/geteffective/).

L'esempio seguente legge il tema effettivo, lo sfondo e il primo riempimento della forma da una diapositiva:

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

Usa i dati effettivi per diagnostica di rendering, convalida e confronti. Se ispezioni solo [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/), potresti perdere una sovrascrittura di master, layout, diapositiva o forma che cambia l'aspetto finale.

## **FAQ**

**L'applicazione di un tema esterno influisce su ogni diapositiva della presentazione?**

No. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) riassegna solo le diapositive che dipendono dal master selezionato. Le diapositive che usano altri master mantengono i loro temi esistenti.

**Posso applicare un tema a una singola diapositiva senza cambiare il master?**

Sì. Usa il [SlideThemeManager](https://reference.aspose.com/slides/it/net/aspose.slides.theme/slidethememanager/) della diapositiva e inizializza il suo tema di sovrascrittura. La modifica rimane locale a quella diapositiva; le altre diapositive continuano a ereditare i loro temi esistenti.

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

Quando sposti una diapositiva e ne conservi l'aspetto di origine, clona il master di origine nella destinazione e clona la diapositiva con quel master usando [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/). Questo mantiene insieme master, layout e tema.

**Come posso vedere i valori effettivi dopo ereditarietà e sovrascritture?**

Usa [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/it/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) per una diapositiva o un tema di layout e i metodi corrispondenti di dati effettivi per gli oggetti di formato come [Background.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/background/geteffective/) e [FillFormat.GetEffective](https://reference.aspose.com/slides/it/net/aspose.slides/fillformat/geteffective/). Queste API restituiscono i valori risolti dopo che ereditarietà e sovrascritture sono state applicate.