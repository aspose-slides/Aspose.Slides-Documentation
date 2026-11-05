---
title: Formattare le forme PowerPoint in Python
linktitle: Formattazione delle forme
type: docs
weight: 20
url: /it/python-net/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea forma schizzo
- stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Python usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

Formatta le forme in PowerPoint regolando i loro contorni, riempimenti e effetti. Aspose.Slides per Python tramite .NET consente di controllare queste impostazioni programmaticamente, inclusi trasparenza, rotazione e formattazione 3D.

![Opzioni di formattazione delle forme in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per Python tramite .NET fornisce classi e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Usa [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) per controllare il contorno di una forma. Questo esempio crea un rettangolo senza riempimento con un contorno blu tratteggiato. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) seleziona una linea composta spessa-sottile, mentre [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) imposta la sua larghezza a 7 punti e [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) seleziona il modello di tratteggio.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

### **Impostare modelli di tratteggio delle linee personalizzati**

Usa [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) quando gli stili di linea predefiniti non offrono le lunghezze di tratto e gli spazi necessari, ad esempio per contorni aziendali o diagrammi tecnici. L'assegnazione di un modello imposta automaticamente [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) su [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Le voci dell'elenco alternano lunghezze di tratto e spazi, iniziando con un tratto. Ogni valore è un multiplo della larghezza della linea: `[4, 2]` a una larghezza di 3 punti produce un tratto di 12 punti seguito da uno spazio di 6 punti. Usa coppie di valori finiti e non negativi per definire segmenti completi di tratto e spazio. L'esempio utilizza valori positivi per mantenere visibili tutti i tratti e gli spazi.

Questo esempio crea cinque linee blu con la stessa lunghezza e estremità piatte. Le prime tre confrontano i modelli a una larghezza di 3 punti. La quarta ripete il primo modello al doppio della larghezza, raddoppiando sia le lunghezze dei tratti che degli spazi. La quinta passa da un modello personalizzato a una linea solida.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Riporta l'ultima linea a uno stile solido.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Per tornare invece a uno stile tratteggiato predefinito, assegna [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Lo stile selezionato controlla l'aspetto della linea.

Il risultato in PowerPoint, da alto a basso: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Tre modelli di tratteggio personalizzati, una linea più larga che utilizza il primo modello e una linea solida in PowerPoint](custom-dash-patterns.png)

### **Impostare le estremità della linea**

Usa [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) per impostare le estremità di una linea aperta. L'enumerazione [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) fornisce tre stili di estremità espliciti:

- `FLAT`: The stroke stops at the endpoint.
- `ROUND`: A semicircular cap extends beyond the endpoint by half the line width.
- `SQUARE`: A square cap extends beyond the endpoint by half the line width.

L'enumerazione include anche `NOT_DEFINED`, che significa che nessuno stile di estremità è assegnato esplicitamente.

Le estremità sono diverse dalle punte delle frecce, che aggiungono simboli alle estremità della linea, e dalle giunzioni, che controllano gli angoli tra i segmenti di linea. Questo esempio disabilita le punte delle frecce tramite [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) e [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) così che vengano confrontate solo le forme delle estremità.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato in PowerPoint, da alto a basso: **Flat**, **Round**, e **Square**.

![Estremità piatte, arrotondate e quadrate su linee spesse identiche in PowerPoint](line-caps.png)

## **Applicare effetti di schizzo alle linee delle forme**

Un effetto di schizzo fa apparire una linea di forma come disegnata a mano. Usa [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) per accedere alle impostazioni della linea, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) per accedere alle impostazioni dello schizzo e [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

La seguente codice Python mostra come applicare un effetto [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Il valore restituito da [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), accedi a [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) e leggi [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'eredità. Questo esempio richiede una presentazione esistente con almeno una forma nella prima diapositiva e stampa entrambi i valori:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Round
* Miter
* Bevel

La giunzione controlla come due segmenti di contorno si incontrano in un angolo. Usa **Round** per angoli arrotondati, **Miter** per angoli appuntiti o **Bevel** per angoli appiattiti.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Questo esempio crea tre rettangoli neri con contorni blu spessi 15 punti. Imposta [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) sui valori miter, bevel e round di [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), rispettivamente, per confrontare come vengono disegnati gli angoli.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Limitare le giunzioni a mitra negli angoli appuntiti**

Usa [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) con [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) impostato su [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) per limitare quanto può estendersi un angolo appuntito.

Il limite è un rapporto tra la distanza tra gli angoli interno ed esterno della giunzione e la larghezza della linea. Ad esempio, un valore di `8` consente una lunghezza di mitra fino a otto volte la larghezza della linea; non è una misura in punti. Se l'angolo superasse il limite, PowerPoint utilizza una giunzione smussata in quel punto. Un limite più grande consente punte più acute. L'impostazione influisce solo sulle giunzioni a mitra e non ha effetto visibile quando l'angolo rimane entro entrambi i limiti.

Questo esempio crea due triangoli identici non riempiti con contorni spessi 20 punti. Il triangolo sinistro utilizza un limite di `2`, e quello destro `8`. Ogni triangolo è largo 80 punti e alto 160 punti, dando al suo angolo superiore un rapporto lunghezza-mitra/larghezza linea di circa `4.12`. Di conseguenza, PowerPoint smussa l'apice sinistro e mantiene l'apice destro.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato in PowerPoint: **Limite mitra 2** a sinistra e **limite mitra 8** a destra.

![Un apice smussato con limite mitra 2 e un apice appuntito con limite mitra 8 in PowerPoint](miter-limits.png)

## **Riempimento a gradiente**

Un riempimento a gradiente mescola i colori su una forma. Questo esempio riempie un'ellisse con un gradiente lineare a 45 gradi da rosso a viola usando [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Il metodo [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) posiziona le fermate di colore a 0 e 1, l'inizio e la fine del gradiente. Cancellare le fermate esistenti garantisce che vengano usati solo questi due colori.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'ellisse con riempimento a gradiente](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, vedi [Choose a Gradient Rendering Style](/slides/it/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puoi selezionare uno stile di rendering senza modificare il riempimento a gradiente memorizzato nella presentazione.

### **Impostare l'angolo del gradiente lineare**

Usa [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) per controllare l'orientamento di un riempimento [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). L'angolo è misurato in gradi e aumenta in senso orario: `0` va da sinistra a destra, `90` dall'alto verso il basso, `180` da destra a sinistra e `270` dal basso verso l'alto. Sono supportati angoli frazionari. Angoli finiti al di fuori di `[0, 360)` vengono normalizzati a una rotazione completa; ad esempio, `-45` diventa `315` e `360` diventa `0`.

Questo esempio crea sei rettangoli con fermate di colore rosso, verde e blu identiche nelle posizioni `0`, `0.5` e `1`. La scala è disabilitata in modo che l'angolo possa essere confrontato indipendentemente dalle proporzioni dei rettangoli. Gli angoli, da sinistra a destra, sono `0`, `45` e `90` nella prima riga, e `135`, `180` e `270` nella seconda riga.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato in PowerPoint:

![Gradienti lineari a 0, 45 e 90 gradi nella riga superiore, e 135, 180 e 270 gradi nella riga inferiore](linear-gradient-angles.png)

### **Ridimensionare un gradiente lineare con la forma**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) accetta un valore [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Impostalo esplicitamente su `FALSE` per mantenere l'angolo geometrico del gradiente mentre le proporzioni della forma cambiano, o su `TRUE` per ridimensionare il gradiente con la larghezza e l'altezza della forma. Con il ridimensionamento abilitato, l'angolo visibile può differire dall'angolo assegnato su una forma non quadrata.

L'esempio seguente utilizza un angolo di `45` gradi e le stesse fermate di colore della comparazione degli angoli. La colonna sinistra usa `FALSE`; la colonna destra usa `TRUE`. Ogni colonna contiene un rettangolo largo sopra un rettangolo alto. Entrambi iniziano con le stesse dimensioni larghe; modificare larghezza e altezza del secondo rettangolo dimostra come il riempimento risponde al ridimensionamento senza cambiare le impostazioni del gradiente.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato in PowerPoint, con il ridimensionamento disabilitato a sinistra e abilitato a destra:

![Rettangoli larghi e alti con un gradiente a 45 gradi, confrontando linear_gradient_scaled FALSE a sinistra con TRUE a destra](linear-gradient-scaling.png)

Con il ridimensionamento disabilitato, le bande di colore diagonali mantengono la stessa orientazione in entrambi i rettangoli. Con il ridimensionamento abilitato, le bande si allungano con le proporzioni della forma. Questo aiuta a riprodurre il gradiente di un modello quando si adatta una forma a una dimensione diversa. Su una forma quadrata, abilitare il ridimensionamento non cambia l'aspetto di questo gradiente a `45` gradi.

Sia l'angolo che le impostazioni di ridimensionamento si applicano ai gradienti lineari. Non controllano i riempimenti [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Combinare l'angolo con la direzione del gradiente**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) seleziona uno stile di gradiente dall'enumerazione [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); non è un sostituto di un angolo numerico. Per un gradiente lineare, gli stili degli angoli possono modificare l'area su cui i colori sono distribuiti senza cambiare [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Mantieni la direzione invariata quando confronti angoli o ridimensionamento.

L'esempio seguente applica le stesse impostazioni in ordine inverso. I due rettangoli hanno lo stesso aspetto: assegnare la direzione prima o dopo l'angolo non cambia il risultato.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Riempimento a motivo**

Un riempimento a motivo applica un disegno bicolore, come punti, strisce o scacchi. Questo esempio usa [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) per selezionare un motivo a rete. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) fornisce lo sfondo grigio chiaro, e [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) fornisce il colore giallo del motivo.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

Un riempimento immagine utilizza un'immagine all'interno di una forma. Questo esempio richiede un'immagine locale e usa [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) per caricarla nella collezione di immagini della presentazione. Impostare [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) sulla modalità affiancata ripete l'immagine all'interno del rettangolo. L'immagine sorgente usata qui è mostrata sotto:

![L'immagine del loto](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Affiancare immagine come texture**

Se desideri impostare un'immagine affiancata come texture e personalizzare il comportamento dell'affiancamento, puoi utilizzare le seguenti proprietà della classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Imposta la modalità di riempimento dell'immagine — `TILE` o `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Specifica l'allineamento delle piastrelle all'interno della forma.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o in entrambi i modi.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Imposta lo spostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Imposta lo spostamento verticale della piastrella (in punti) dall'origine della forma.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definisce la scala orizzontale della piastrella in percentuale.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definisce la scala verticale della piastrella in percentuale.

Questo esempio richiede un'immagine locale e configura [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) per ripeterla al 50% della sua dimensione originale. Gli offset di −32 punti spostano le piastrelle orizzontalmente e verticalmente; l'allineamento in basso a destra e il capovolgimento in entrambe le direzioni determinano come viene disposto il pattern ripetuto.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le opzioni di piastrellatura](tile-options.png)

## **Riempimento a colore solido**

Un riempimento a colore solido conferisce a una forma un unico colore uniforme. Questo esempio imposta [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sulla modalità di riempimento solido e assegna il giallo tramite [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), quindi salva il rettangolo in una presentazione.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

### **Copiare i colori mantenendo i riferimenti al tema**

Usa [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) per copiare una definizione di colore, incluso il suo tipo di colore, il riferimento al tema e le trasformazioni. Questo è utile quando si trasferisce un colore di riempimento tra forme che dovrebbero continuare a seguire il tema della presentazione. Il metodo copia solo il colore: non copia il tipo di riempimento, il contorno o altre formattazioni della forma. Imposta esplicitamente il [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) della destinazione.

Questo esempio crea tre rettangoli, da sinistra a destra: la sorgente, una copia consapevole del tema e una copia RGB fissa. La sorgente utilizza [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) per riferire il primo colore di accento e aggiunge una tinta tramite [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). La copia RGB utilizza il colore di riempimento effettivo della sorgente, così tutti e tre inizialmente appaiono identici. Assegnare [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) imposta un valore RGB fisso e cancella eventuali trasformazioni di colore esistenti.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # I riferimenti al tema seguono il nuovo colore di accento; il valore RGB fisso no.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Prima della modifica del tema, tutti e tre i riempimenti corrispondono:

![Sorgente, destinazione copy_from e destinazione RGB fissa con riempimenti blu identici](color-copy-before.png)

Dopo la modifica del tema, la sorgente e la copia consapevole del tema seguono il nuovo colore di accento e mantengono la loro tinta. La copia RGB fissa rimane blu:

![Sorgente e destinazione copy_from con riempimenti arancioni, mentre la destinazione RGB fissa rimane blu](color-copy-after.png)

La definizione copiata è indipendente dalla sorgente. Modificare successivamente il riferimento al tema della sorgente, assegnare un altro colore o aggiungere o rimuovere le sue trasformazioni non modifica la destinazione. Una modifica al tema influisce ancora su entrambe le forme perché ciascuna fa riferimento in modo indipendente allo stesso colore del tema.

Salvare e riaprire il PPTX preserva il [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), il riferimento al tema e la collezione [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) del colore copiato; non appiattisce la definizione in RGB.

Quando si copia tra diversi contesti tematici, come presentazioni con palette di accenti differenti, il riferimento copiato viene risolto rispetto al tema della destinazione. Lo stesso riferimento e le stesse trasformazioni possono quindi produrre un colore visibile diverso. Vedi [Presentation Theme](/slides/it/python-net/presentation-theme/) per ulteriori informazioni sulla configurazione dei colori del tema.

## **Usare lo sfondo della diapositiva come riempimento della forma**

Usa [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) quando una forma deve corrispondere allo sfondo della diapositiva, ad esempio in un modello di presentazione. Imposta [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) su [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) per rimuovere qualsiasi riempimento esplicito. Con questa combinazione, la forma utilizza lo sfondo della diapositiva invece del riempimento di stile. Abilitare il flag da solo non rimuove un riempimento esplicito esistente.

Ciò differisce da [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): il riempimento di sfondo copre gli oggetti dietro la forma con l'area corrispondente dello sfondo della diapositiva, mentre nessun riempimento lascia visibili quegli oggetti. Un gradiente rimane allineato con la diapositiva invece di ricominciare all'interno di ogni forma.

L'esempio seguente crea uno sfondo master ereditato dalla diapositiva e posiziona una banda magenta dietro tre rettangoli. Il rettangolo sinistro usa lo sfondo, il rettangolo centrale non ha riempimento e il rettangolo destro passa dal riempimento di sfondo a un riempimento arancione esplicito.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Eredita il gradiente dal master.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Aggiungi prima questo oggetto così appare dietro i rettangoli.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Disattiva il riempimento di sfondo prima di applicare un riempimento esplicito.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultante, da sinistra a destra: **riempimento di sfondo**, **nessun riempimento** e **riempimento esplicito**. La banda magenta è nascosta dai rettangoli sinistro e destro ma rimane visibile attraverso il rettangolo centrale.

![Riempimento di sfondo, nessun riempimento e riempimento arancione esplicito sopra una banda magenta](background-fill.png)

Lo stesso comportamento si applica a uno sfondo definito direttamente sulla diapositiva o ereditato da un layout. La forma utilizza lo sfondo risolto della diapositiva; l'esempio lascia indefiniti sia lo sfondo della diapositiva sia quello del layout in modo che il master lo fornisca.

## **Impostare la trasparenza**

Per un riempimento solido, il componente alfa del colore controlla l'opacità: 0 è completamente trasparente e 255 è completamente opaco. Questo esempio utilizza un valore alfa di 128 per un rettangolo giallo, rendendolo circa il 50% trasparente così che il rettangolo sottostante rimanga visibile. Il colore è assegnato tramite [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Usa [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) per ruotare una forma nel piano della diapositiva. L'angolo è misurato in gradi; questo esempio ruota un rettangolo di 5 gradi in senso orario e salva la presentazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Usa [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) per dare a una forma profondità e bordi smussati. Questo esempio crea un'ellisse verde con un contorno arancione, imposta [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) a 4 punti e applica una smussatura superiore circolare con larghezza e altezza di 6 punti tramite [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Una fotocamera ortografica frontale e un'illuminazione a tre punti rendono la smussatura visibile.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![L'effetto di smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

La vista 3D di una forma è controllata dalle impostazioni della sua fotocamera. Questo esempio usa [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) con angoli di latitudine, longitudine e rivoluzione di 40, 35 e 20 gradi, rispettivamente. Seleziona una fotocamera isometrica tramite [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) e un'illuminazione bilanciata tramite [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), quindi salva il rettangolo formattato.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare la resa in bianco e nero per le forme**

La proprietà [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) specifica come una singola forma viene resa quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero da sola e non modifica il riempimento, la linea o altre formattazioni della forma in modalità colore normale.

Usa un valore dell'enumerazione [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `AUTOMATIC` consente all'applicazione di rendering di scegliere la conversione, `GRAY` e `LIGHT_GRAY` usano la colorazione in grigio, `BLACK_WHITE` usa solo nero e bianco, `BLACK` e `WHITE` forzano un colore unico, `COLOR` preserva la colorazione normale e `HIDDEN` omette la forma in modalità bianco e nero. `NOT_DEFINED` indica che non è stato assegnato alcun modo a livello di forma.

Questo esempio crea un rettangolo arancione e imposta [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) su gray. La forma salvata conserva il riempimento arancione per la visualizzazione a colori normale e richiede la colorazione grigia dalle applicazioni che rispettano le impostazioni di visualizzazione in bianco e nero:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché il suo modo è impostato su `GRAY`. Questo consente di preservare una diapositiva a colori completa definendo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Ripristinare la formattazione**

Usa [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) per ripristinare la posizione, le dimensioni e la formattazione dei segnaposto della diapositiva dai loro corrispondenti segnaposto del layout. Questo esempio richiede una presentazione esistente con segnaposto collegati al layout e ripristina ogni diapositiva prima di salvare. Le forme senza segnaposto corrispondente nel layout non vengono ripristinate.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

I colori, gli stili di linea e le impostazioni degli effetti aggiungono generalmente pochi dati rispetto a immagini e media incorporati. I riempimenti immagine possono aumentare la dimensione del file poiché le loro immagini sono memorizzate nella presentazione.

**Come posso rilevare le forme su una diapositiva che condividono una formattazione identica per poterle raggruppare?**

Confronta le principali proprietà di formattazione di ogni forma — riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili identici e raggruppa logicamente quelle forme, semplificando la gestione degli stili successiva.

**Posso salvare un insieme di stili di forme personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Memorizza le forme di esempio con gli stili desiderati in un mazzo di diapositive modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme formattate di cui hai bisogno e riapplica la loro formattazione dove necessario.