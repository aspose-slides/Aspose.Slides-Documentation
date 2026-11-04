---
title: Formattare forme PowerPoint in Java
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di giunzione
- riempimento sfumato
- riempimento a trama
- riempimento immagine
- riempimento texture
- riempimento a tinta unita
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Java usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT e PPTX con precisione e controllo totale."
---
## **Introduzione**

Formato le forme in PowerPoint regolando i loro contorni, riempimenti e effetti. Aspose.Slides per Java consente di controllare queste impostazioni in modo programmatico, inclusi trasparenza, rotazione e formattazione 3D.

![Opzioni di formattazione delle forme in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per Java fornisce interfacce e metodi che consentono di formattare le forme usando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Usa [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) per controllare il contorno di una forma. Questo esempio crea un rettangolo non riempito con un contorno blu e tratteggiato. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) seleziona una linea composta spessa-sottile, mentre [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) imposta la sua larghezza a 7 punti e [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) seleziona lo schema di tratteggio.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

### **Imposta schemi di tratteggio personalizzati per le linee**

Usa [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) quando gli stili di linea predefiniti non offrono le lunghezze di tratto e gli spazi necessari, ad esempio per contorni aziendali o diagrammi tecnici. L'assegnazione di un modello cambia automaticamente lo stile di tratteggio della linea in [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Le voci dell'array alternano tra lunghezze di tratto e di spazio, iniziando con un tratto. Ogni valore è un multiplo della larghezza della linea: `{ 4, 2 }` a una larghezza di 3 punti produce un tratto di 12 punti seguito da uno spazio di 6 punti. Usa coppie di valori finiti e non negativi per definire segmenti completi di tratto e spazio. L'esempio utilizza valori positivi per mantenere visibili tutti i tratti e gli spazi.

Questo esempio crea cinque linee blu con la stessa lunghezza e estremità piatte. Le prime tre confrontano gli schemi a una larghezza di 3 punti. La quarta ripete il primo schema al doppio della larghezza, raddoppiando sia le lunghezze dei tratti sia degli spazi. La quinta passa da uno schema personalizzato a una linea solida.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Restituire l'ultima linea a uno stile solido.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per tornare a uno stile tratteggiato predefinito, passa [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) a [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Lo stile selezionato controlla l'aspetto della linea.

Il risultato in PowerPoint, dall'alto al basso: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Tre schemi di tratteggio personalizzati, una linea più larga che usa il primo schema e una linea solida in PowerPoint](custom-dash-patterns.png)

### **Imposta estremità della linea**

Usa [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) per impostare le estremità di una linea aperta. La classe [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) fornisce tre stili di estremità espliciti:

- `Flat`: Il tratto si ferma al punto finale.
- `Round`: Un'estremità semicircolare si estende oltre il punto finale di metà larghezza della linea.
- `Square`: Un'estremità quadrata si estende oltre il punto finale di metà larghezza della linea.

La classe include anche `NotDefined`, che indica che non è stato assegnato alcun stile di estremità.

Le estremità sono diverse dalle punte delle frecce, che aggiungono simboli alle estremità della linea, e dalle giunzioni, che controllano gli angoli tra i segmenti di linea. Questo esempio disabilita le punte delle frecce tramite [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) e [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) in modo che vengano confrontate solo le forme delle estremità.

L'esempio seguente crea tre linee orizzontali altrimenti identiche, larghe 20 punti. Dall'alto al basso, usano rispettivamente estremità flat, round e square. I loro punti finali hanno le stesse coordinate orizzontali; le estremità round e square si estendono di 10 punti oltre ciascun punto finale.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato in PowerPoint, dall'alto al basso: **Flat**, **Round**, e **Square**.

![Estremità flat, round e square su linee spesse identiche in PowerPoint](line-caps.png)

## **Applica effetti schizzo alle linee delle forme**

Un effetto schizzo rende una linea di forma simile a un disegno a mano libera. Usa [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) per accedere alle impostazioni della linea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) per accedere alle impostazioni dello schizzo e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) per selezionare un valore dalla classe [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Il seguente codice Java mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), accedi a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), e leggi [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Il valore efficace riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà. Questo esempio richiede una presentazione esistente con almeno una forma nella prima diapositiva e stampa entrambi i valori:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di giunzione:

* Round
* Miter
* Bevel

Lo stile di giunzione controlla come due segmenti di contorno si incontrano a un angolo. Usa **Round** per angoli arrotondati, **Miter** per angoli acuti o **Bevel** per angoli smussati.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Questo esempio crea tre rettangoli neri con contorni blu larghi 15 punti. Usa [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) per impostare rispettivamente i valori miter, bevel e round di [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), al fine di confrontare il modo in cui vengono disegnati gli angoli.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Limita le giunzioni a spigolo nei punti acuti**

Usa [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) con [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) impostato su [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) per limitare quanto può estendersi un angolo acuto.

Il limite è un rapporto tra la distanza tra gli angoli interno ed esterno della giunzione e la larghezza della linea. Per esempio, un valore di `8` consente una lunghezza di spigolo fino a otto volte la larghezza della linea; non è una misura in punti. Se l'angolo supererebbe il limite, PowerPoint utilizza una giunzione smussata in quel punto. Un limite più grande permette punte più acute. L'impostazione influisce solo sulle giunzioni a spigolo e non ha effetto visibile quando l'angolo rimane entro entrambi i limiti.

Questo esempio crea due triangoli non riempiti identici, con contorni larghi 20 punti. Il triangolo sinistro usa un limite di `2`, quello destro un limite di `8`. Ogni triangolo è largo 80 punti e alto 160 punti, dando al suo angolo superiore un rapporto lunghezza-spigolo / larghezza linea di circa `4.12`. Di conseguenza, PowerPoint smussa l'apice sinistro e preserva l'apice destro.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato in PowerPoint: **Miter limit 2** a sinistra e **miter limit 8** a destra.

![Un apice smussato con limite di spigolo 2 e un apice appuntito con limite di spigolo 8 in PowerPoint](miter-limits.png)

## **Riempimento sfumato**

Un riempimento sfumato sfuma i colori su una forma. Questo esempio riempie un'ellisse con un gradiente lineare a 45 gradi dal rosso al viola usando [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Il metodo [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) posiziona le fermate di colore a 0 e 1, rispettivamente all'inizio e alla fine del gradiente. La cancellazione delle fermate esistenti garantisce che siano usati solo questi due colori.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'ellisse con riempimento sfumato](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, vedi [Choose a Gradient Rendering Style](/slides/it/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puoi selezionare uno stile di rendering senza modificare il gradiente memorizzato nella presentazione.

### **Imposta l'angolo del gradiente lineare**

Usa [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) per controllare l'orientamento di un riempimento [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). L'angolo è misurato in gradi e aumenta in senso orario: `0` va da sinistra a destra, `90` da alto a basso, `180` da destra a sinistra e `270` da basso a alto. Sono supportati angoli frazionari. Angoli finiti al di fuori dell’intervallo `[0, 360)` vengono normalizzati a una rivoluzione; per esempio, `-45` diventa `315` e `360` diventa `0`.

Questo esempio crea sei rettangoli con fermate rosse, verdi e blu identiche alle posizioni `0`, `0.5` e `1`. La scala è disabilitata così l'angolo può essere confrontato indipendentemente dalle proporzioni dei rettangoli. Gli angoli, da sinistra a destra, sono `0`, `45` e `90` nella prima riga, e `135`, `180` e `270` nella seconda riga.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato in PowerPoint:

![Gradienti lineari a 0, 45 e 90 gradi nella prima riga, e 135, 180 e 270 gradi nella seconda riga](linear-gradient-angles.png)

### **Scala un gradiente lineare con la forma**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) accetta un valore [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Impostalo esplicitamente su `False` per mantenere l'angolo geometrico del gradiente mentre le proporzioni della forma cambiano, o su `True` per scalare il gradiente con la larghezza e l'altezza della forma. Con la scala attiva, l'angolo visibile può differire dall'angolo assegnato su una forma non quadrata.

L'esempio seguente usa un angolo di `45` gradi e le stesse fermate di colore dell'esempio di confronto degli angoli. La colonna di sinistra usa `False`; la colonna di destra usa `True`. Ogni colonna contiene un rettangolo largo sopra un rettangolo alto. Entrambi partono dalle stesse dimensioni larghe; modificare la larghezza e l'altezza del secondo rettangolo dimostra come il riempimento risponde al ridimensionamento senza cambiare le impostazioni del gradiente.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato in PowerPoint, con la scala disabilitata a sinistra e abilitata a destra:

![Rettangoli larghi e alti con un gradiente a 45 gradi, confrontando LinearGradientScaled False a sinistra con True a destra](linear-gradient-scaling.png)

Con la scala disabilitata, le bande di colore diagonali mantengono la stessa orientazione in entrambi i rettangoli. Con la scala abilitata, le bande si allungano con le proporzioni della forma. Questo aiuta a riprodurre il gradiente di un modello quando si adatta una forma a dimensioni diverse. Su un quadrato, abilitare la scala non cambia l'aspetto di questo gradiente a `45` gradi.

Sia l'angolo sia le impostazioni di scala si applicano ai gradienti lineari. Non controllano i riempimenti [GradientShape.Radial o GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Combina l'angolo con la direzione del gradiente**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) seleziona uno stile di gradiente dalla classe [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); non è un sostituto di un angolo numerico. Per un gradiente lineare, gli stili di angolo possono cambiare l'area su cui i colori sono distribuiti senza modificare l'angolo impostato tramite [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Mantieni la direzione invariata quando confronti angoli o scala.

L'esempio seguente applica le stesse impostazioni in ordine inverso. I due rettangoli hanno lo stesso aspetto: assegnare la direzione prima o dopo l'angolo non cambia il risultato.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riempimento a trama**

Un riempimento a trama applica un disegno a due colori, come punti, strisce o quadretti. Questo esempio usa [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) per selezionare un motivo a rete. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) fornisce lo sfondo grigio chiaro, e [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) fornisce il colore giallo del motivo.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a trama](pattern-fill.png)

## **Riempimento immagine**

Un riempimento immagine utilizza un'immagine all'interno di una forma. Questo esempio richiede un'immagine locale e usa [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) per caricarla nella collezione di immagini della presentazione. Impostare [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) sulla modalità tiled ripete l'immagine all'interno del rettangolo. L'immagine di origine utilizzata qui è mostrata sotto:

![L'immagine del fiore di loto](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Affianca immagine come trama**

Se vuoi impostare un'immagine tiled come trama e personalizzare il comportamento del tassellamento, puoi usare i seguenti metodi dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definisce la scala orizzontale della tessera come percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definisce la scala verticale della tessera come percentuale.

Questo esempio richiede un'immagine locale e configura [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) per ripeterla al 50 % della sua dimensione originale. Gli offset di −32 punti spostano le tessere orizzontalmente e verticalmente; l'allineamento in basso a destra e il ribaltamento in entrambi i sensi determinano come la trama ripetuta è disposta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le opzioni di tassellamento](tile-options.png)

## **Riempimento a tinta unita**

Un riempimento solido assegna alla forma un unico colore uniforme. Questo esempio usa [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) per impostare la modalità di riempimento solido e assegna il giallo tramite [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), quindi salva il rettangolo nella presentazione.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento a tinta unita](solid-color-fill.png)

## **Usa lo sfondo della diapositiva come riempimento della forma**

Usa [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) quando una forma deve corrispondere allo sfondo della diapositiva, ad esempio in un modello di presentazione. Usa [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) per impostare [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) prima di rimuovere eventuali riempimenti espliciti. Con questa combinazione, la forma utilizza lo sfondo della diapositiva invece del suo riempimento di stile. Attivare solo il flag non rimuove un riempimento esplicito esistente.

Questo differisce da [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): il riempimento di sfondo copre gli oggetti dietro la forma con l'area corrispondente dello sfondo della diapositiva, mentre nessun riempimento lascia visibili quegli oggetti. Un gradiente rimane allineato con la diapositiva piuttosto che ricominciare all'interno di ogni forma.

L'esempio seguente crea uno sfondo master ereditato dalla diapositiva e posiziona una banda magenta dietro tre rettangoli. Il rettangolo sinistro usa lo sfondo, quello centrale è senza riempimento e quello destro passa dallo sfondo a un riempimento arancione esplicito.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Eredita il gradiente dal master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Aggiungi questo oggetto per primo in modo che appaia dietro i rettangoli.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Disabilita il riempimento di sfondo prima di applicare un riempimento esplicito.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato, da sinistra a destra: **riempimento di sfondo**, **nessun riempimento**, e **riempimento esplicito**. La banda magenta è nascosta dai rettangoli sinistro e destro ma rimane visibile attraverso quello centrale.

![Riempimento di sfondo, nessun riempimento e riempimento arancione esplicito su una banda magenta](background-fill.png)

Lo stesso comportamento si applica a uno sfondo definito direttamente sulla diapositiva o ereditato da un layout. La forma utilizza lo sfondo risolto della diapositiva; l'esempio lascia sia lo sfondo della diapositiva sia quello del layout non definiti in modo che il master lo fornisca.

## **Imposta trasparenza**

Per un riempimento solido, il componente alfa del colore controlla l'opacità: 0 è completamente trasparente e 255 è completamente opaco. Questo esempio usa un valore alfa di 128 per un rettangolo giallo, rendendolo approssimativamente al 50 % trasparente così che il rettangolo sottostante rimanga visibile. Il colore è assegnato tramite [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruota le forme**

Usa [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) per ruotare una forma nel piano della diapositiva. L'angolo è misurato in gradi; questo esempio ruota un rettangolo di 5 gradi in senso orario e salva la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungi effetti di smusso 3D**

Usa [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) per dare a una forma profondità e bordi smussati. Questo esempio crea un'ellisse verde con un contorno arancione, usa [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) per impostare la profondità a 4 punti e applica uno smusso superiore circolare con larghezza e altezza di 6 punti tramite [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Una telecamera ortografica frontale e un'illuminazione a tre punti rendono visibile lo smusso.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungi effetti di rotazione 3D**

La vista 3D di una forma è controllata dalle impostazioni della telecamera. Questo esempio usa [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) con angoli di latitudine, longitudine e rivoluzione rispettivamente di 40, 35 e 20 gradi. Seleziona una telecamera isometrica tramite [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) e un'illuminazione bilanciata tramite [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), quindi salva il rettangolo formattato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controlla la resa in bianco e nero per le forme**

Il metodo [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specifica come una singola forma viene resa quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non attiva la visualizzazione in bianco e nero da solo e non modifica il riempimento, il contorno o altra formattazione della forma in modalità colore normale.

Usa un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Per esempio, `Automatic` lascia all'applicazione di rendering la scelta della conversione, `Gray` e `LightGray` usano la colorazione in grigio, `BlackWhite` usa solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` preserva la colorazione normale, e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` significa che non è stato assegnato alcun modo a livello di forma.

Questo esempio crea un rettangolo arancione e usa [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) per impostare la modalità su `Gray`. La forma salvata mantiene il riempimento arancione per la visualizzazione a colori normale e richiede una colorazione grigia dalle applicazioni che rispettano le impostazioni di visualizzazione in bianco e nero:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché la sua modalità è impostata su `Gray`. Questo consente di preservare una diapositiva a colori completa definendo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Ripristina formattazione**

Usa [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) per ripristinare la posizione, le dimensioni e la formattazione dei segnaposto delle diapositive dai corrispondenti segnaposto del layout. Questo esempio richiede una presentazione esistente con segnaposto collegati al layout e ripristina ogni diapositiva prima di salvare. Le forme senza segnaposto corrispondente nel layout non vengono ripristinate.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file di presentazione?**

Colori, stili di linea e impostazioni degli effetti aggiungono generalmente pochi dati rispetto a immagini e media incorporati. I riempimenti immagine possono aumentare la dimensione del file perché le loro immagini sono memorizzate nella presentazione.

**Come posso rilevare le forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, tratta i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Memorizza le forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.