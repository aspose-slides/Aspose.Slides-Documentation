---
title: Gestisci i temi di presentazione in .NET
linktitle: Tema presentazione
type: docs
weight: 10
url: /it/net/presentation-theme/
keywords:
- tema PowerPoint
- tema della presentazione
- tema diapositiva
- impostazione tema
- modifica tema
- gestione tema
- colore tema
- tavolozza aggiuntiva
- font tema
- stile tema
- effetto tema
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i temi di presentazione in Aspose.Slides per .NET per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà degli elementi di design. Quando selezioni un tema di presentazione, scegli essenzialmente un insieme specifico di elementi visivi e le loro proprietà.

In PowerPoint, un tema comprende colori, [font](/slides/it/net/powerpoint-fonts/), [stili di sfondo](/slides/it/net/presentation-background/), ed effetti.

![componenti-del-tema](theme-constituents.png)

## **Modifica colore del tema**

Un tema PowerPoint utilizza un set specifico di colori per i diversi elementi di una diapositiva. Se non ti piacciono i colori, li cambi applicando nuovi colori al tema. Per consentirti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/).

Questo codice C# mostra come modificare il colore di accento per un tema:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Puoi determinare il valore effettivo del colore risultante in questo modo:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Colore [A=255, R=128, G=100, B=162])
}
```

Per dimostrare ulteriormente l'operazione di cambio colore, creiamo un altro elemento e gli assegniamo il colore di accento (dall'operazione iniziale). Quindi cambiamo il colore nel tema:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Il nuovo colore viene applicato automaticamente su entrambi gli elementi.

### **Imposta colore del tema da una tavolozza aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema (1), vengono generati i colori dalla tavolozza aggiuntiva (2). Puoi quindi impostare e ottenere questi colori del tema.

![colori-della-tavolozza-aggiuntiva](additional-palette-colors.png)

**1** - Colori principali del tema  
**2** - Colori dalla tavolozza aggiuntiva.

Questo codice C# dimostra un'operazione in cui i colori della tavolozza aggiuntiva vengono ottenuti dal colore principale del tema e poi utilizzati nelle forme:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accento 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accento 4, più chiaro 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accento 4, più chiaro 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accento 4, più chiaro 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accento 4, più scuro 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accento 4, più scuro 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mappa `SchemeColor` a colori `IColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/net/aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema: `Background1`, `Background2`, `Text1` e `Text2`.

Tuttavia, `Presentation.MasterTheme.ColorScheme` restituisce [IColorScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/icolorscheme/), che espone i colori corrispondenti come: `Dark1`, `Dark2`, `Light1` e `Light2`.

Questa differenza è solo nel nome. Questi valori si riferiscono alle stesse slot di colore del tema e la mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Non esiste una conversione dinamica tra `Text`/`Background` e `Dark`/`Light`. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni più vecchie di Office usavano `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, mentre le versioni UI più recenti mostrano le stesse slot come `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Modifica carattere del tema**

Per consentirti di selezionare font per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli usati in PowerPoint):

* **+mn-lt** - Font corpo Latin (Font Latin minore)
* **+mj-lt** - Font intestazione Latin (Font Latin maggiore)
* **+mn-ea** - Font corpo East Asian (Font East Asian minore)
* **+mj-ea** - Font corpo East Asian (Font East Asian minore)

Questo codice C# mostra come assegnare il font Latin a un elemento del tema:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Questo codice C# mostra come modificare il font del tema della presentazione:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Il font in tutte le caselle di testo verrà aggiornato.

{{% alert color="info" title="SUGGERIMENTO" %}} 
Potresti voler vedere i [font di PowerPoint](/slides/it/net/powerpoint-fonts/).
{{% /alert %}}

## **Modifica stile di sfondo del tema**

Per impostazione predefinita, l'app PowerPoint fornisce 12 sfondi predefiniti, ma solo 3 di questi 12 sfondi vengono salvati in una presentazione tipica.

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione nell'app PowerPoint, puoi eseguire questo codice C# per scoprire il numero di sfondi predefiniti nella presentazione:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Utilizzando la proprietà [BackgroundFillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) della classe [FormatScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/) è possibile aggiungere o accedere allo stile di sfondo in un tema PowerPoint. 
{{% /alert %}}

Questo codice C# mostra come impostare lo sfondo per una presentazione:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Guida indice**: 0 è usato per nessuna riempimento. L'indice inizia da 1.

{{% alert color="info" title="SUGGERIMENTO" %}} 
Potresti voler vedere lo [sfondo di PowerPoint](/slides/it/net/presentation-background/).
{{% /alert %}}

## **Modifica effetto del tema**

Un tema PowerPoint solitamente contiene 3 valori per ogni array di stile. Quegli array sono combinati in questi 3 effetti: sottile, moderato e intenso. Per esempio, questo è il risultato quando gli effetti sono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando 3 proprietà ([FillStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme/effectstyles)) della classe [FormatScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/formatscheme) è possibile modificare gli elementi in un tema (in modo ancora più flessibile rispetto alle opzioni in PowerPoint).

Questo codice C# mostra come modificare un effetto del tema alterando parti degli elementi:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Le modifiche risultanti in colore di riempimento, tipo di riempimento, effetto ombra, ecc:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Posso applicare un tema a una singola diapositiva senza modificare il master?

Sì. Aspose.Slides supporta sovrascritture del tema a livello di diapositiva, quindi puoi applicare un tema locale solo a quella diapositiva mantenendo intatto il tema master (tramite il [SlideThemeManager](https://reference.aspose.com/slides/it/net/aspose.slides.theme/slidethememanager/)).

### Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?

[Clona diapositive](/slides/it/net/clone-slides/) insieme al loro master nella presentazione di destinazione. Questo preserva il master originale, i layout e il tema associato, così l'aspetto rimane coerente.

### Come posso vedere i valori "effettivi" dopo tutte le ereditarietà e sovrascritture?

Utilizza le ["visualizzazioni effettive"](/slides/it/net/shape-effective-properties/) dell'API per tema/colore/font/effetto. Queste restituiscono le proprietà risolte e finali dopo l'applicazione del master più eventuali sovrascritture locali.