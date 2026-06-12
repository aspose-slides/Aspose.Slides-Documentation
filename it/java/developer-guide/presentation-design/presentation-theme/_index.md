---
title: Gestire i temi delle presentazioni in Java
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/java/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Modifica tema
- Gestire tema
- Colore del tema
- Palette aggiuntiva
- Font del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- Presentazione
- Java
- Aspose.Slides
description: "Gestisci i temi principali della presentazione in Aspose.Slides per Java per creare, personalizzare e convertire file PowerPoint con un'identità di marca coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà degli elementi di design. Quando selezioni un tema di presentazione, stai essenzialmente scegliendo un insieme specifico di elementi visivi e le loro proprietà.

In PowerPoint, un tema comprende colori, [fonts](/slides/it/java/powerpoint-fonts/), [background styles](/slides/it/java/presentation-background/), ed effetti.

![theme-constituents](theme-constituents.png)

## **Modifica colore del tema**

Un tema di PowerPoint utilizza un insieme specifico di colori per i diversi elementi di una diapositiva. Se non ti piacciono i colori, li cambi applicando nuovi colori al tema. Per consentirti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/SchemeColor).

Questo codice Java mostra come modificare il colore accentato per un tema:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Puoi determinare il valore effettivo del colore risultante in questo modo:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Per dimostrare ulteriormente l'operazione di cambiamento del colore, creiamo un altro elemento e gli assegniamo il colore accentato (dall'operazione iniziale). Poi cambiamo il colore nel tema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Il nuovo colore viene applicato automaticamente a entrambi gli elementi.

### **Imposta colore del tema da una palette aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema(1), si formano colori dalla palette aggiuntiva(2). Puoi quindi impostare e recuperare questi colori del tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colori principali del tema  
**2** - Colori della palette aggiuntiva.

Questo codice Java dimostra un'operazione in cui i colori della palette aggiuntiva vengono ottenuti dal colore principale del tema e poi utilizzati nelle forme:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accento 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accento 4, più chiaro 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accento 4, più chiaro 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accento 4, più chiaro 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accento 4, più scuro 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accento 4, più scuro 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mappa `SchemeColor` su colori `IColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema:

`Background1`, `Background2`, `Text1`, and `Text2`.

Tuttavia, `Presentation.getMasterTheme().getColorScheme()` restituisce [IColorScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/icolorscheme/), che espone i colori corrispondenti come:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Questa differenza è solo di denominazione. Questi valori si riferiscono alle stesse slot di colore del tema e la mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Non esiste una conversione dinamica tra `Text`/`Background` e `Dark`/`Light`. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni più vecchie di Office usavano `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, mentre le versioni UI più recenti mostrano le stesse slot come `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Modifica font del tema**

Per consentirti di selezionare i font per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli usati in PowerPoint):

* **+mn-lt** - Font corpo Latin (Minor Latin Font)
* **+mj-lt** - Font intestazione Latin (Major Latin Font)
* **+mn-ea** - Font corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Font corpo East Asian (Major East Asian Font)

Questo codice Java mostra come assegnare il font Latin a un elemento del tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Questo codice Java mostra come modificare il font del tema della presentazione:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Il font in tutte le caselle di testo sarà aggiornato.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [PowerPoint fonts](/slides/it/java/powerpoint-fonts/).
{{% /alert %}}

## **Modifica stile di sfondo del tema**

Per impostazione predefinita, l'app PowerPoint fornisce 12 sfondi predefiniti ma solo 3 di questi 12 sfondi vengono salvati in una presentazione tipica.

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione nell'app PowerPoint, puoi eseguire questo codice Java per scoprire il numero di sfondi predefiniti nella presentazione:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Utilizzando la proprietà [BackgroundFillStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) della classe [FormatScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme), è possibile aggiungere o accedere allo stile di sfondo in un tema PowerPoint. 
{{% /alert %}} 

Questo codice Java mostra come impostare lo sfondo per una presentazione:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guida agli indici**: 0 è usato per nessun riempimento. L'indice parte da 1.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [PowerPoint Background](/slides/it/java/presentation-background/).
{{% /alert %}}

## **Modifica effetto del tema**

Un tema PowerPoint solitamente contiene 3 valori per ogni array di stile. Quegli array sono combinati in questi 3 effetti: sottile, moderato e intenso. Per esempio, questo è il risultato quando gli effetti sono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando 3 proprietà ([FillStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme#getEffectStyles--)) della classe [FormatScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/FormatScheme) è possibile modificare gli elementi di un tema (in modo ancora più flessibile rispetto alle opzioni di PowerPoint).

Questo codice Java mostra come modificare un effetto del tema alterando parti degli elementi:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Le modifiche risultanti nel colore di riempimento, tipo di riempimento, effetto ombra, ecc:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**  
Sì. Aspose.Slides supporta le sovrascritture di tema a livello di diapositiva, così puoi applicare un tema locale solo a quella diapositiva mantenendo intatto il tema master (tramite [SlideThemeManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidethememanager/)).

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**  
[Clone slides](/slides/it/java/clone-slides/) insieme al loro master nella presentazione di destinazione. Questo preserva il master originale, i layout e il tema associato in modo che l'aspetto rimanga coerente.

**Come posso vedere i valori "effettivi" dopo tutta l'eredità e le sovrascritture?**  
Utilizza le ["visualizzazioni effettive"](/slides/it/java/shape-effective-properties/) dell'API per tema/colore/font/effetto. Queste restituiscono le proprietà risolte e finali dopo l'applicazione del master più eventuali sovrascritture locali.