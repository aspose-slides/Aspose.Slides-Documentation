---
title: Gestisci gli sfondi della presentazione su Android
linktitle: Sfondo della diapositiva
type: docs
weight: 20
url: /it/androidjava/presentation-background/
keywords:
- sfondo della presentazione
- sfondo della diapositiva
- colore solido
- colore sfumato
- sfondo immagine
- trasparenza dello sfondo
- proprietà dello sfondo
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come impostare sfondi dinamici nei file PowerPoint e OpenDocument utilizzando Aspose.Slides per Android tramite Java, con consigli di codice per migliorare le tue presentazioni."
---
## **Introduzione**

I colori solidi, le sfumature e le immagini sono comunemente usati per gli sfondi delle diapositive. È possibile impostare lo sfondo per una **diapositiva normale** (una singola diapositiva) o una **diapositiva master** (applica a più diapositive contemporaneamente).

![Sfondo PowerPoint](powerpoint-background.png)

## **Imposta uno sfondo a colore solido per una diapositiva normale**

Aspose.Slides consente di impostare un colore solido come sfondo per una diapositiva specifica in una presentazione—anche se la presentazione utilizza una diapositiva master. La modifica si applica solo alla diapositiva selezionata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) dello sfondo della diapositiva su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) su [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio Java mostra come impostare un colore solido blu come sfondo per una diapositiva normale:

```java
// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Imposta il colore di sfondo della diapositiva a blu.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Salva la presentazione su disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta uno sfondo a colore solido per una diapositiva master**

Aspose.Slides consente di impostare un colore solido come sfondo per la diapositiva master in una presentazione. La diapositiva master funge da modello che controlla la formattazione di tutte le diapositive, quindi quando si sceglie un colore solido per lo sfondo della diapositiva master, questo viene applicato a ogni diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/backgroundtype/) della diapositiva master (tramite `getMasters`) su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) dello sfondo della diapositiva master su `Solid`.
4. Utilizza il metodo [getSolidFillColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) per specificare il colore di sfondo solido.
5. Salva la presentazione modificata.

Il seguente esempio Java mostra come impostare un colore solido (verde) come sfondo per una diapositiva master:

```java
// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Imposta il colore di sfondo per la diapositiva Master a Verde foresta.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Salva la presentazione su disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta uno sfondo sfumato per una diapositiva**

Una sfumatura è un effetto grafico creato da un cambiamento graduale di colore. Quando viene usata come sfondo di una diapositiva, la sfumatura può rendere le presentazioni più artistiche e professionali. Aspose.Slides consente di impostare un colore sfumato come sfondo per le diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) dello sfondo della diapositiva su `Gradient`.
4. Utilizza il metodo [getGradientFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) su [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/) per configurare le impostazioni della sfumatura preferite.
5. Salva la presentazione modificata.

Il seguente esempio Java mostra come impostare un colore sfumato come sfondo per una diapositiva:

```java
// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Applica un effetto gradiente allo sfondo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Salva la presentazione su disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta un'immagine come sfondo della diapositiva**

Oltre a riempimenti solidi e sfumati, Aspose.Slides consente di utilizzare immagini come sfondi delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Imposta il [BackgroundType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/backgroundtype/) della diapositiva su `OwnBackground`.
3. Imposta il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) dello sfondo della diapositiva su `Picture`.
4. Carica l'immagine che desideri utilizzare come sfondo della diapositiva.
5. Aggiungi l'immagine alla raccolta di immagini della presentazione.
6. Utilizza il metodo [getPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) su [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fillformat/) per assegnare l'immagine come sfondo.
7. Salva la presentazione modificata.

Il seguente esempio Java mostra come impostare un'immagine come sfondo per una diapositiva:

```java
// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Imposta le proprietà dell'immagine di sfondo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Carica l'immagine.
    IImage image = Images.fromFile("Tulips.jpg");
    // Aggiungi l'immagine alla raccolta immagini della presentazione.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Salva la presentazione su disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il seguente esempio di codice mostra come impostare il tipo di riempimento dello sfondo a un'immagine affiancata (tiled) e modificare le proprietà di affiancamento:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Imposta l'immagine usata per il riempimento dello sfondo.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Imposta la modalità di riempimento dell'immagine su Tile e regola le proprietà delle piastrelle.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Leggi di più: [**Immagine affiancata come texture**](/slides/it/androidjava/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Modifica la trasparenza dell'immagine di sfondo**

Potresti voler regolare la trasparenza dell'immagine di sfondo di una diapositiva per far risaltare il contenuto della diapositiva. Il seguente codice Java mostra come modificare la trasparenza di un'immagine di sfondo della diapositiva:

```java
int transparencyValue = 30; // Per esempio.

// Ottieni la raccolta delle operazioni di trasformazione dell'immagine.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Trova un effetto di trasparenza a percentuale fissa esistente.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Imposta il nuovo valore di trasparenza.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Recupera il valore dello sfondo della diapositiva**

Aspose.Slides fornisce l'interfaccia [IBackgroundEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibackgroundeffectivedata/) per recuperare i valori effettivi dello sfondo di una diapositiva. Questa interfaccia espone il [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) e il [EffectFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) effettivi.

Utilizzando il metodo `getBackground` della classe [BaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslide/), è possibile ottenere lo sfondo effettivo per una diapositiva.

Il seguente esempio Java mostra come ottenere il valore effettivo dello sfondo di una diapositiva:

```java
// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Recupera lo sfondo effettivo, tenendo conto di master, layout e tema.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso ripristinare uno sfondo personalizzato e recuperare lo sfondo del tema/layout?**

Sì. Rimuovi il riempimento personalizzato della diapositiva e lo sfondo verrà nuovamente ereditato dalla diapositiva [layout](/slides/it/androidjava/slide-layout/)/[master](/slides/it/androidjava/slide-master/) corrispondente (cioè dallo [sfondo del tema](/slides/it/androidjava/presentation-theme/)).

**Cosa succede allo sfondo se cambio più tardi il tema della presentazione?**

Se una diapositiva ha un proprio riempimento, rimarrà invariato. Se lo sfondo è ereditato dal [layout](/slides/it/androidjava/slide-layout/)/[master](/slides/it/androidjava/slide-master/), verrà aggiornato per corrispondere al [nuovo tema](/slides/it/androidjava/presentation-theme/).