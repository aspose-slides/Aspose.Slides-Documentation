---
title: Gestisci gli sfondi delle presentazioni in JavaScript
linktitle: Sfondo della diapositiva
type: docs
weight: 20
url: /it/nodejs-java/presentation-background/
keywords:
- sfondo della presentazione
- sfondo della diapositiva
- colore solido
- colore gradiente
- sfondo immagine
- trasparenza dello sfondo
- proprietà dello sfondo
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument usando Aspose.Slides per Node.js, con suggerimenti di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, i gradienti e le immagini sono comunemente usati per gli sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o per una **diapositiva master** (vale per più diapositive contemporaneamente).

![PowerPoint background](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione, anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) su [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio JavaScript mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Imposta il colore di sfondo della diapositiva su blu.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Salva la presentazione su disco.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta uno sfondo a colore solido per la diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master funge da modello che controlla la formattazione di tutte le diapositive, quindi quando scegli un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/backgroundtype/) della diapositiva master (tramite `getMasters`) su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) dello sfondo della diapositiva master su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio JavaScript mostra come impostare un colore solido (verde) come sfondo per una diapositiva master:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Imposta il colore di sfondo della diapositiva Master su verde foresta.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Salva la presentazione su disco.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta uno sfondo a gradiente per una diapositiva**

Un gradiente è un effetto grafico creato da una variazione graduale di colore. Quando viene usato come sfondo di una diapositiva, i gradienti possono rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore a gradiente come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Gradient`.
4. Utilizza il metodo [getGradientFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getGradientFormat) su [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/) per configurare le impostazioni del gradiente desiderate.
5. Salva la presentazione modificata.

Il seguente esempio JavaScript mostra come impostare un colore a gradiente come sfondo per una diapositiva:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Applica un effetto gradiente allo sfondo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salva la presentazione su disco.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre alle riempiture solide e a gradiente, Aspose.Slides consente di utilizzare immagini come sfondo delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine che desideri utilizzare come sfondo della diapositiva.
5. Aggiungi l'immagine alla raccolta di immagini della presentazione.
6. Utilizza il metodo [getPictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) su [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio JavaScript mostra come impostare un'immagine come sfondo per una diapositiva:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Imposta le proprietà dell'immagine di sfondo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Carica l'immagine.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Aggiungi l'immagine alla raccolta immagini della presentazione.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Salva la presentazione su disco.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento dello sfondo a un'immagine affiancata e modificare le proprietà di affiancamento:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Imposta l'immagine usata per il riempimento di sfondo.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Imposta la modalità di riempimento dell'immagine su Tile e regola le proprietà del tassello.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Leggi di più: [**Tile Picture As Texture**](/slides/it/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare il contenuto della diapositiva. Il seguente codice JavaScript mostra come modificare la trasparenza di un'immagine di sfondo della diapositiva:

```js
var transparencyValue = 30; // Ad esempio.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Ottieni il valore dello sfondo della diapositiva**

Aspose.Slides fornisce la classe `BackgroundEffectiveData` per recuperare i valori effettivi dello sfondo di una diapositiva. Questa classe espone i [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/) e [EffectFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effectformat/) effettivi.

Utilizzando il metodo `getBackground` della classe [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/), è possibile ottenere lo sfondo effettivo per una diapositiva.

Il seguente esempio JavaScript mostra come ottenere il valore effettivo dello sfondo di una diapositiva:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Recupera lo sfondo effettivo, tenendo conto di master, layout e tema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso reimpostare uno sfondo personalizzato e ripristinare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dalla diapositiva [layout](/slides/it/nodejs-java/slide-layout/)/[master](/slides/it/nodejs-java/slide-master/) corrispondente (cioè dallo [sfondo del tema](/slides/it/nodejs-java/presentation-theme/)).

**Cosa succede allo sfondo se cambio in seguito il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/nodejs-java/slide-layout/)/[master](/slides/it/nodejs-java/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/nodejs-java/presentation-theme/).