---
title: Applicare effetti di forma nelle presentazioni su Android
linktitle: Effetto Forma
type: docs
weight: 30
url: /it/androidjava/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando Aspose.Slides per Android via Java—crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono dai [riempimenti](/slides/it/androidjava/shape-formatting/#gradient-fill) o dai contorni. Usando gli effetti di PowerPoint, puoi creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Shape effect](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti appaiono migliori di altre. Per questo motivo, PowerPoint offre opzioni sotto **Preset**. Le opzioni Preset sono combinazioni di due o più effetti noti per avere un aspetto gradevole. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Aspose.Slides per Android via Java supporta ombre esterne e interne per le forme. È possibile personalizzare il colore, la direzione, la distanza e il raggio di sfocatura per adattarli al design della tua presentazione.

### **Applicare un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola il colore, la direzione, la distanza e il raggio di sfocatura per adattarli all'illuminazione e allo stile del tuo modello.

Questo codice Java mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) a un rettangolo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Applicare un'ombra interna**

Quando riproduci lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende fuori dalla forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) e poi configura l'ombra restituita da [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Valori più alti del raggio di sfocatura producono bordi più morbidi.

Questo esempio Java crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX. La direzione dell'ombra è 225 gradi, la distanza è 7 punti e il raggio di sfocatura è 6 punti:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) sul formato effetto della forma.

## **Applicare un effetto riflessione**

Per applicare un effetto di riflessione in Aspose.Slides per Android via Java, puoi aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle tue presentazioni dando alle forme un aspetto più raffinato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice Java mostra come applicare l'[effetto riflessione](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) a una forma:

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

Per applicare un effetto bagliore a una forma in Aspose.Slides per Android via Java, puoi aggiungere un'aura soffusa e luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta le forme a risaltare e aggiunge un elemento visivo attraente e accattivante alla tua presentazione. È facile da implementare con un minimo di codice, migliorando l'aspetto complessivo delle diapositive.

Questo codice Java mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) a una forma:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Per applicare un effetto bordi morbidi in Aspose.Slides per Android via Java, puoi creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per design che richiedono un aspetto più gentile e soffice. Puoi facilmente regolare parametri come il raggio per ottenere l'effetto desiderato su varie forme nella tua presentazione.

Questo codice Java mostra come applicare l'[effetto bordi morbidi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) a una forma:

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

Usa la sfocatura della forma per ammorbidire il riempimento e il contorno della forma mantenendola modificabile. Chiama [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): utilizza un valore non negativo, con valori più alti che producono una sfocatura più forte. Un raggio pari a zero lascia l'aspetto invariato.

L'impostazione [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è limitata ai limiti originali dipinti, compreso il contorno. Con `true`, la sfocatura può estendersi oltre quei limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto qui sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutto. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Questo esempio Java crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi la aggiorna a 15 punti chiamando nuovamente [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Salva entrambi gli stati sfocati, poi chiama [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) e salva la forma senza sfocatura.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

La sfocatura della forma influisce contemporaneamente su riempimento e contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, puoi combinare effetti diversi, come ombra, riflessione e bagliore, su un'unica forma per creare un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

Puoi applicare effetti a varie forme, inclusi autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare effetti a forme raggruppate?**

Sì, puoi applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.