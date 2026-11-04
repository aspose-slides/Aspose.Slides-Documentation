---
title: Applicare effetti di forma nelle presentazioni con Java
linktitle: Effetto forma
type: docs
weight: 30
url: /it/java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflesso
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per Java—crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/java/shape-formatting/#gradient-fill) o contorni. Usando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere l'aura di una forma, ecc.

![Shape effect](shape-effect.png)

PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti hanno un aspetto migliore di altre. Per questo motivo, PowerPoint fornisce opzioni sotto **Preset**. Le opzioni Preset sono combinazioni di due o più effetti che sono noti per avere un buon aspetto. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Aspose.Slides per Java supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adattarli al design della presentazione.

### **Applicare un'ombra esterna**

Utilizza un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per corrispondere all'illuminazione e allo stile del tuo modello.

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

![Shadow effect](shadow_effect.png)

### **Applicare un'ombra interna**

Quando si riproduce lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende al di fuori della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) sul formato effetto della forma.

## **Applicare un effetto riflesso**

Per applicare un effetto di riflesso in Aspose.Slides per Java, è possibile aggiungere un riflesso simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle presentazioni conferendo alle forme un aspetto più raffinato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

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

![Reflection effect](reflection_effect.png)

## **Applicare un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per Java, è possibile aggiungere un'aura morbida e luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente e accattivante alla presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle diapositive.

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

![Glow effect](glow_effect.png)

## **Applicare un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per Java, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per progetti che richiedono un aspetto gentile e più morbido. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

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

![Soft edges effect](soft_edges_effect.png)

## **Applicare un effetto sfocatura**

Usa la sfocatura della forma per ammorbidire il riempimento e il contorno di una forma mantenendola modificabile. Chiama [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, i valori più alti producono una sfocatura più intensa. Un raggio pari a zero mantiene l'aspetto invariato.

L'impostazione [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è ritagliata ai confini originali dipinti, includendo il contorno. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutti i casi. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Questo esempio Java crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi la aggiorna a 15 punti chiamando nuovamente [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Salva entrambi gli stati sfocati, poi chiama [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) e salva la forma senza sfocatura.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La sfocatura della forma influisce sia sul riempimento che sul contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare effetti diversi, come ombra, riflesso e bagliore, su una singola forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare effetti a diverse forme, incluse autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare gli effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.