---
title: Applicare effetti di forma nelle presentazioni con PHP
linktitle: Effetto forma
type: docs
weight: 30
url: /it/php-java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per PHP via Java—crea diapositive accattivanti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/php-java/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti risultano migliori di altre. Per questo motivo, PowerPoint offre opzioni sotto **Preset**. Le opzioni Preset sono combinazioni di due o più effetti noti per avere un aspetto gradevole. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Aspose.Slides per PHP via Java supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adattarli al design della presentazione.

### **Applicare un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per adattarli all'illuminazione e allo stile del tuo modello.

Questo codice PHP mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rettangolo:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effetto ombra](shadow_effect.png)

### **Applicare un'ombra interna**

Quando si riproduce lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende al di fuori della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), quindi configura l'ombra restituita da [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Valori più grandi del raggio di sfocatura producono bordi più morbidi.

Questo esempio PHP crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX. La direzione dell'ombra è di 225 gradi, la sua distanza è di 7 punti e il raggio di sfocatura è di 6 punti:
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) sul formato effetto della forma.

## **Applicare un effetto riflessione**

Per applicare un effetto riflessione in Aspose.Slides per PHP via Java, è possibile aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle tue presentazioni conferendo alle forme un aspetto più curato e sofisticato. È facile da implementare con un codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice PHP mostra come applicare l'[effetto riflessione](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:
```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effetto riflessione](reflection_effect.png)

## **Applicare un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per PHP via Java, è possibile aggiungere un'aura morbida e luminosa intorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo accattivante e attraente alla tua presentazione. È facile da implementare con poco codice, migliorando l'aspetto generale delle tue diapositive.

Questo codice PHP mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) a una forma:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effetto bagliore](glow_effect.png)

## **Applicare un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per PHP via Java, è possibile creare una transizione liscia e sfocata intorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per design che richiedono un aspetto gentile e più morbido. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella tua presentazione.

Questo codice PHP mostra come applicare l'[effetto bordi morbidi](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applicare un effetto sfocatura**

Utilizza la sfocatura di forma per ammorbidire il riempimento e il contorno di una forma mantenendola modificabile. Chiama [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, con valori più grandi che producono una sfocatura più forte. Un raggio di zero mantiene l'aspetto invariato.

L'impostazione [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) controlla i limiti visibili dell'effetto. Con `false`, la sfocatura è ritagliata ai limiti originali dipinti, includendo il contorno. Con `true`, la sfocatura può estendersi oltre tali limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto qui sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutti i casi. La riga superiore usa `grow = false`; la riga inferiore usa `grow = true`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio PHP crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti, e poi lo aggiorna a una sfocatura di 15 punti chiamando nuovamente [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Salva entrambi gli stati sfocati, quindi chiama [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) e salva la forma senza sfocatura.
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La sfocatura di forma influisce contemporaneamente sul riempimento e sul contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su una singola forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

Puoi applicare effetti a varie forme, incluse autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.