---
title: Gestire i Fotogrammi Immagine nelle Presentazioni su Android
linktitle: Fotogramma Immagine
type: docs
weight: 10
url: /it/androidjava/picture-frame/
keywords:
- fotogramma immagine
- aggiungi fotogramma immagine
- crea fotogramma immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione fotogramma immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i fotogrammi immagine nelle presentazioni con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Un fotogramma immagine è una forma della diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) possiede risorse immagine incorporate tramite la sua [IImageCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimagecollection/), mentre un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di fotogramma.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva l'[IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) restituito, e utilizza quella risorsa immagine quando crei i fotogrammi immagine.

I fotogrammi immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche riferirsi a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, sulla dimensione del file, sull'estrazione e sul comportamento di esportazione, quindi è utile decidere come l'immagine debba essere memorizzata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un'immagine incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un fotogramma immagine con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

Il seguente esempio aggiunge un'immagine JPEG, crea un fotogramma con le dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il fotogramma immagine controlla la geometria visualizzata; modificare le dimensioni del fotogramma non cambia le dimensioni in pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Utilizzare la scala relativa**

[IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) espone la scala relativa di larghezza e altezza per il fotogramma tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Un valore di `1.0` corrisponde al 100% della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La scala relativa modifica le impostazioni di scala del fotogramma; non ricampiona né comprime l'immagine incorporata.

## **Immagini incorporate e collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione e perciò è la scelta più sicura per la portabilità e un rendering prevedibile. Un'immagine collegata memorizza un percorso esterno tramite il metodo [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) invece di incorporare i dati dell'immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via email, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'immagine collegata**

Il seguente esempio crea un fotogramma immagine e lo collega a un file immagine locale. Si occupa solo del collegamento delle immagini; il collegamento dei video è un flusso di lavoro multimediale separato e non è intenzionalmente mescolato in questo esempio.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilizza i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze di immagine interrotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai fotogrammi immagine**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) e che contenga un'immagine incorporata. I fotogrammi immagine collegati potrebbero non contenere byte dell'immagine che possano essere estratti allo stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e non richiede il wrapper immagine Java più vecchio. Il seguente esempio trova la prima immagine raster incorporata in una diapositiva e la salva come PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Il salvataggio tramite [IImage.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) converte l'immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione piuttosto che di un file raster convertito, usa invece i dati binari della risorsa immagine.

### **Estrarre un'immagine SVG**

Per un'immagine SVG, il [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) espone un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/). Questo consente di recuperare i dati SVG direttamente invece di rasterizzare prima l'immagine.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione della diapositiva in PDF o SVG è anche un'operazione di rendering, quindi la grafica esportata non dovrebbe essere trattata come una copia byte per byte dell'SVG incorporato originale; utilizza i dati [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/#getSvgData--) incorporati quando è richiesta la risorsa vettoriale originale.

## **Ritagliare un'immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno del fotogramma. I valori di ritaglio su [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

Il seguente esempio trova in modo sicuro un fotogramma immagine e applica i valori di ritaglio:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poiché i dati dell'immagine nascosta sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati di immagine ritagliati**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per una successiva operazione di annullamento del ritaglio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche utilizzata da altri fotogrammi immagine, questi fotogrammi necessitano ancora della loro risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Ritagliare contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Utilizza un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturescompression/) quando è sufficiente una risoluzione target standard:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

È possibile passare un valore DPI positivo personalizzato al posto di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo flusso di lavoro di compressione raster. Ricorda inoltre che la risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione più grande in cui l'immagine verrà effettivamente visualizzata o esportata, invece di applicare il DPI più basso a livello globale.

## **Ispezionare effetti immagine**

Gli effetti immagine sono memorizzati sull'immagine utilizzata dal fotogramma. La collezione di trasformazioni dell'immagine può contenere effetti come modulazione alfa fissa per la trasparenza e luminanza per luminosità e contrasto. L'esempio qui sotto legge in modo sicuro entrambi i tipi di effetti dal primo fotogramma immagine in una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Questi effetti modificano il modo in cui l'immagine è renderizzata nel fotogramma; non riscrivono i byte originali dell'immagine incorporata.

## **Bloccare la geometria del fotogramma immagine**

Le impostazioni di [IPictureFrameLock](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframelock/) controllano quali operazioni di modifica sono disabilitate per un fotogramma immagine. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) preserva le proporzioni della forma mentre viene ridimensionata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il blocco si applica alla forma del fotogramma immagine. Non costringe l'immagine sorgente a essere ricampionata o permanentemente cambiata allo stesso rapporto d'aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento dell'immagine è stretch, i valori stretch-offset su [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del fotogramma immagine. Le percentuali positive creano un rientro dal bordo, mentre le percentuali negative creano un'estensione.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento dell'immagine visibile viene allungato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine sorgente.

## **Considerazioni su archiviazione, dimensione del file e esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei fotogrammi immagine vengono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le immagini raster di grandi dimensioni aumentano la dimensione del PPTX e l'uso della memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzati.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione originale. Dovrebbe essere applicata dopo aver conosciuto la dimensione prevista sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere come SVG quando la conservazione del vettoriale è importante. Estrai direttamente l'SVG incorporato quando hai bisogno della risorsa vettoriale stessa. Le esportazioni raster delle diapositive convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage] esistente quando possibile invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando viene eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando non è necessaria una modifica successiva, ed evita collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un fotogramma immagine e una risorsa immagine?**

Un [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria e la formattazione a livello di fotogramma come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine al di fuori del PPTX è intenzionale e le posizioni esterne possono essere mantenute in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normali nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere scartati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata, e la rimozione delle regioni ritagliate elimina i dati dell'immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se in futuro potrà essere necessaria una modifica ad alta risoluzione.

**Come dovrebbero essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) incorporato può essere estratto direttamente. Renderizzare una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri quando leggo diapositive esistenti?**

Verifica il tipo di forma prima di utilizzare membri specifici dei fotogrammi immagine. Un controllo `instanceof` su [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) evita cast non validi e permette al codice di gestire le diapositive che non contengono fotogrammi immagine.