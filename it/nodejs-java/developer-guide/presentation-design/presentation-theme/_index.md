---
title: Gestisci i temi delle presentazioni in JavaScript
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/nodejs-java/presentation-theme/
keywords:
- tema PowerPoint
- tema della presentazione
- tema diapositiva
- imposta tema
- cambia tema
- gestisci tema
- colore tema
- palette aggiuntiva
- font tema
- stile tema
- effetto tema
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i temi principali delle presentazioni in JavaScript con Aspose.Slides per Node.js per creare, personalizzare e convertire file PowerPoint con un brand coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà degli elementi di design. Quando selezioni un tema di presentazione, scegli essenzialmente un insieme specifico di elementi visivi e le loro proprietà.

In PowerPoint, un tema comprende colori, [caratteri](/slides/it/nodejs-java/powerpoint-fonts/), [stili di sfondo](/slides/it/nodejs-java/presentation-background/), ed effetti.

![theme-constituents](theme-constituents.png)

## **Modifica colore del tema**

Un tema PowerPoint utilizza un insieme specifico di colori per i diversi elementi di una diapositiva. Se non ti piacciono i colori, li modifichi applicando nuovi colori al tema. Per consentirti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SchemeColor).

Questo codice JavaScript mostra come modificare il colore di accento per un tema:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Puoi determinare il valore effettivo del colore risultante in questo modo:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Per dimostrare ulteriormente l'operazione di modifica del colore, creiamo un altro elemento e gli assegniamo il colore di accento (dalla operazione iniziale). Poi cambiamo il colore nel tema:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Il nuovo colore viene applicato automaticamente su entrambi gli elementi.

### **Imposta colore del tema da palette aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema(1), si generano colori dalla palette aggiuntiva(2). Puoi quindi impostare e ottenere quei colori del tema. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Colori principali del tema

**2** - Colori dalla palette aggiuntiva.

Questo codice JavaScript dimostra un'operazione in cui i colori della palette aggiuntiva vengono ottenuti dal colore principale del tema e poi utilizzati nelle forme:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accento 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accento 4, 80% più chiaro
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accento 4, 60% più chiaro
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accento 4, 40% più chiaro
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accento 4, 25% più scuro
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accento 4, 50% più scuro
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Mappa `SchemeColor` a colori `ColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema:

``Background1``, ``Background2``, ``Text1`` e ``Text2``.

Tuttavia, `Presentation.getMasterTheme().getColorScheme()` restituisce [ColorScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/colorscheme/), che espone i colori corrispondenti come:

``Dark1``, ``Dark2``, ``Light1`` e ``Light2``.

Questa differenza è solo nella denominazione. Questi valori si riferiscono alle stesse posizioni di colore del tema e la mappatura è fissa:

* ``Text1`` = ``Dark1``
* ``Background1`` = ``Light1``
* ``Text2`` = ``Dark2``
* ``Background2`` = ``Light2``

Non esiste una conversione dinamica tra ``Text``/``Background`` e ``Dark``/``Light``. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni più vecchie di Office usavano ``Dark 1``, ``Light 1``, ``Dark 2`` e ``Light 2``, mentre le versioni UI più recenti mostrano le stesse posizioni come ``Text 1``, ``Background 1``, ``Text 2`` e ``Background 2``.

## **Modifica carattere del tema**

Per consentirti di selezionare i caratteri per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli usati in PowerPoint):

* **+mn-lt** - Carattere corpo Latin (Minor Latin Font)
* **+mj-lt** - Carattere intestazione Latin (Major Latin Font)
* **+mn-ea** - Carattere corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Carattere corpo East Asian (Major East Asian Font)

Questo codice JavaScript mostra come assegnare il carattere Latin a un elemento del tema:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Questo codice JavaScript mostra come modificare il carattere del tema della presentazione:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Il carattere in tutte le caselle di testo verrà aggiornato.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [font PowerPoint](/slides/it/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Modifica stile di sfondo del tema**

Per impostazione predefinita, l'app PowerPoint fornisce 12 sfondi predefiniti ma solo 3 di questi 12 sfondi vengono salvati in una presentazione tipica. 

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione nell'app PowerPoint, puoi eseguire questo codice JavaScript per scoprire il numero di sfondi predefiniti nella presentazione:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Utilizzando la proprietà [BackgroundFillStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) della classe [FormatScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme), puoi aggiungere o accedere allo stile di sfondo in un tema PowerPoint.
{{% /alert %}} 

Questo codice JavaScript mostra come impostare lo sfondo per una presentazione:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guida all'indice**: 0 è usato per nessun riempimento. L'indice inizia da 1.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [sfondo PowerPoint](/slides/it/nodejs-java/presentation-background/).
{{% /alert %}}

## **Modifica effetto del tema**

Un tema PowerPoint di solito contiene 3 valori per ciascun array di stile. Quegli array sono combinati in questi 3 effetti: sottile, moderato e intenso. Ad esempio, questo è il risultato quando gli effetti sono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando 3 proprietà ([FillStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) della classe [FormatScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FormatScheme) puoi modificare gli elementi in un tema (anche più flessibilmente rispetto alle opzioni in PowerPoint).

Questo codice JavaScript mostra come modificare un effetto del tema alterando parti degli elementi:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Le modifiche risultanti nel colore di riempimento, tipo di riempimento, effetto ombra, ecc.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Aspose.Slides supporta le sovrascritture di tema a livello di diapositiva, così puoi applicare un tema locale solo a quella diapositiva mantenendo intatto il tema master (tramite il [SlideThemeManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidethememanager/)).

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

[Clona diapositive](/slides/it/nodejs-java/clone-slides/) together with their master into the target presentation. This preserves the original master, layouts, and the associated theme so the appearance remains consistent.

**Come posso vedere i valori "effettivi" dopo tutta l'ereditarietà e le sovrascritture?**

Usa le ["effective" views](/slides/it/nodejs-java/shape-effective-properties/) dell'API per tema/colore/carattere/effetto. Queste restituiscono le proprietà risolte e finali dopo l'applicazione del master più eventuali sovrascritture locali.