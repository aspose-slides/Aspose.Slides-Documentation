---
title: "Applicare effetti forma nelle presentazioni usando Java"
linktitle: "Effetto forma"
type: docs
weight: 30
url: /it/java/shape-effect/
keywords:
- "effetto forma"
- "effetto ombra"
- "effetto riflesso"
- "effetto bagliore"
- "effetto bordi morbidi"
- "formato effetto"
- "PowerPoint"
- "presentazione"
- "Java"
- "Aspose.Slides"
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per Java—crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre le effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/java/shape-formatting/#gradient-fill) o bordi. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti hanno un aspetto migliore di altre. Per questo motivo, PowerPoint fornisce opzioni sotto **Preimpostazione**. Le opzioni Preimpostazione sono combinazioni di due o più effetti noti per avere un buon aspetto. In questo modo, selezionando una preimpostazione, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Aspose.Slides per Java supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adattarle al design della presentazione.

### **Applicare un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello sullo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per adattarli all'illuminazione e allo stile del modello.

Questo codice Java mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) a un rettangolo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto ombra](shadow_effect.png)

### **Applicare un'ombra interna**

Quando si riproduce lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende all'esterno della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), poi configura l'ombra restituita da [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Valori più alti del raggio di sfocatura producono bordi più morbidi.

Questo esempio Java crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX. La direzione dell'ombra è 225 gradi, la distanza è 7 punti e il raggio di sfocatura è 6 punti:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) sul formato effetti della forma.

## **Applicare un effetto riflesso**

Per applicare un effetto riflesso in Aspose.Slides per Java, è possibile aggiungere un riflesso simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle presentazioni conferendo alle forme un aspetto più curato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice Java mostra come applicare l'[effetto di riflesso](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto riflesso](reflection_effect.png)

## **Applicare un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per Java, è possibile aggiungere un'aura morbida e luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente alla presentazione. È facile da implementare con codice minimo, migliorando l'aspetto complessivo delle diapositive.

Questo codice Java mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) a una forma:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto bagliore](glow_effect.png)

## **Applicare un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per Java, è possibile creare una transizione sfumata e delicata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più sottile e raffinato, perfetto per design che richiedono un aspetto più delicato. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su diverse forme nella presentazione.

Questo codice Java mostra come applicare l'[effetto bordi morbidi](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflesso e bagliore, su un'unica forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, inclusi autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.