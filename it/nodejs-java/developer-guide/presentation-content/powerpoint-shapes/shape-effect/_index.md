---
title: Applica effetti di forma alle presentazioni usando JavaScript
linktitle: Effetto forma
type: docs
weight: 30
url: /it/nodejs-java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando JavaScript e Aspose.Slides per Node.js—crea diapositive impressionanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, sono diversi da [riempimenti](/slides/it/nodejs-java/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere la luce di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti appaiono migliori di altre. Per questo motivo, PowerPoint fornisce opzioni sotto **Preset**. Le opzioni Preset sono combinazioni di due o più effetti noti per apparire bene. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto di ombra**

Aspose.Slides per Node.js tramite Java supporta ombre esterne e interne per le forme. È possibile personalizzare il loro colore, direzione, distanza e raggio di sfocatura per adattarli al design della presentazione.

### **Applicare un'ombra esterna**

Utilizza un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per adattarli all'illuminazione e allo stile del tuo modello.

Questo codice JavaScript mostra come applicare l'[effetto di ombra esterna](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rettangolo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto ombra](shadow_effect.png)

### **Applicare un'ombra interna**

Quando si riproduce lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende all'esterno della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), quindi configura l'ombra restituita da [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Valori più alti del raggio di sfocatura producono bordi più morbidi.

Questo esempio JavaScript crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX. La direzione dell'ombra è di 225 gradi, la sua distanza è di 7 punti e il raggio di sfocatura è di 6 punti:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) sul formato effetti della forma.

## **Applicare un effetto di riflessione**

Per applicare un effetto di riflessione in Aspose.Slides per Node.js tramite Java, è possibile aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle tue presentazioni conferendo alle forme un aspetto più raffinato e sofisticato. È facile da implementare con un codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice JavaScript mostra come applicare l'[effetto di riflessione](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto riflessione](reflection_effect.png)

## **Applicare un effetto di bagliore**

Per applicare un effetto di bagliore a una forma in Aspose.Slides per Node.js tramite Java, è possibile aggiungere un'aura morbida e luminosa intorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente e accattivante alla tua presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle tue diapositive.

Questo codice JavaScript mostra come applicare l'[effetto di bagliore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto bagliore](glow_effect.png)

## **Applicare un effetto di bordi morbidi**

Per applicare un effetto di bordi morbidi in Aspose.Slides per Node.js tramite Java, è possibile creare una transizione liscia e sfocata intorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per progetti che richiedono un aspetto morbido e delicato. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice JavaScript mostra come applicare l'[effetto di bordi morbidi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applicare un effetto di sfocatura**

Utilizza la sfocatura della forma per ammorbidire il riempimento e il contorno di una forma mantenendola modificabile. Chiama [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) sul formato effetti della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, con valori più alti che producono una sfocatura più intensa. Un raggio pari a zero mantiene l'aspetto invariato.

La impostazione [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è limitata ai limiti originali dipinti, includendo il contorno. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

La comparazione sotto utilizza lo stesso riempimento, contorno e dimensioni della forma per tutti i casi. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio JavaScript crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi lo aggiorna a una sfocatura di 15 punti chiamando nuovamente [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Salva entrambi gli stati sfocati, poi chiama [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) e salva la forma senza sfocatura.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La sfocatura della forma influisce sia sul riempimento che sul contorno. Un effetto di bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione dell'immagine operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetti della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su un'unica forma per creare un aspetto più dinamico.

**Quali forme posso utilizzare per applicare gli effetti?**

È possibile applicare effetti a varie forme, tra cui autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.