---
title: Gestire i frame immagine nelle presentazioni su Android
linktitle: Frame immagine
type: docs
weight: 10
url: /it/androidjava/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i frame immagine nelle presentazioni con Aspose.Slides per Android via Java."
---
## **Panoramica**

Un frame immagine è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) possiede risorse immagine incorporate tramite la sua [IImageCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimagecollection/), mentre un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) restituito e usa quella risorsa immagine quando crei i frame immagine.

I frame immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono inoltre fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce su portabilità, dimensione del file, estrazione e comportamento di esportazione, quindi è utile decidere come l'immagine debba essere memorizzata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e Formattare un'Immagine Incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un frame immagine con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea un frame alle dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

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

Il frame immagine controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni originali in pixel memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la Scala Relativa**

[IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) espone la scalatura relativa di larghezza e altezza per il frame tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Un valore di `1.0` corrisponde al 100 % della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.

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

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l'immagine incorporata.

## **Immagini Incorporate e Collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza una posizione esterna tramite il metodo [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) anziché incorporare i dati dell'immagine allo stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o renderizza la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via email, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'Immagine Collegata**

L'esempio seguente crea un frame immagine e lo punta a un file immagine locale. Si occupa solo del collegamento dell'immagine; il collegamento di video è un flusso di lavoro multimediale separato e non è mescolato intenzionalmente in questo esempio.

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

Usa i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre Immagini da Frame Immagine**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) e che contenga un'immagine incorporata. I frame immagine collegati potrebbero non contenere byte immagine estraibili allo stesso modo.

### **Estrarre un'Immagine Raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e non richiede il wrapper Java più vecchio. L'esempio seguente trova la prima immagine raster incorporata su una diapositiva e la salva come PNG:

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

Il salvataggio tramite [IImage.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) converte l'immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione invece di un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un'Immagine SVG**

Per un'immagine SVG, il [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) espone un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/). Questo consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione di diapositive in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non deve essere trattata come una copia byte‑per‑byte dell'SVG incorporato originale; usa i dati di [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/#getSvgData--) quando è richiesto il vettoriale originale.

## **Ritagliare un'Immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno del frame. I valori di ritaglio su [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

L'esempio seguente trova in modo sicuro un frame immagine e applica i valori di ritaglio:

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

Poiché i dati nascosti dell'immagine sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le aree ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i Dati Immagine Ritagliati**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo aver salvato la presentazione, i pixel rimossi non sono più disponibili per un'operazione di "uncrop" successiva.

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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche usata da altri frame immagine, quei frame hanno ancora bisogno della loro risorsa esistente, quindi la cancellazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere Immagini Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) riduce la risoluzione dell'immagine raster rispetto alla dimensione con cui l'immagine viene visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturescompression/) quando è sufficiente una risoluzione target standard:

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

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo flusso di lavoro di compressione raster. Ricorda anche che una risoluzione inferiore e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione più grande con cui l'immagine sarà realmente visualizzata o esportata, piuttosto che applicare il DPI più basso globalmente.

## **Gestire gli Effetti di Trasformazione dell'Immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni di colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedi [Image Transform Effects](/slides/it/androidjava/image-transform-effects/).

## **Bloccare la Geometria del Frame Immagine**

Le impostazioni di [IPictureFrameLock](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframelock/) controllano quali operazioni di modifica sono disabilitate per un frame immagine. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) preserva le proporzioni della forma mentre viene ridimensionata.

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

Il blocco si applica alla forma del frame immagine. Non forza la risorsa immagine sorgente a essere ricampionata o modificata permanentemente allo stesso rapporto d'aspetto.

## **Regolare i Valori StretchOffset**

Quando la modalità di riempimento immagine è stretch, i valori stretch‑offset su [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del frame immagine. Percentuali positive creano un'inserzione dal bordo, mentre percentuali negative creano un'esulenza.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento immagine visibile è stirato.

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

Usa gli offset di stretch per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine sorgente.

## **Considerazioni su Archiviazione, Dimensione del File ed Esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei frame immagine sono trattate separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano la dimensione del PPTX e l'uso della memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende da file esterni rimasti disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati fino a quando le aree ritagliate non vengono esplicitamente cancellate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione sorgente. Deve essere applicata dopo aver conosciuto la dimensione finale prevista sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la conservazione del vettoriale è importante. Estrai direttamente l'SVG incorporato quando ti serve la risorsa vettoriale stessa. Le esportazioni diapositive raster convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) esistente quando possibile invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando viene eseguita in modo selettivo: conserva loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando la modifica successiva non è necessaria e evita collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del progetto di distribuzione.

## **FAQ**

**Qual è la differenza tra un frame immagine e una risorsa immagine?**

Un [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza geometria e formattazione a livello di frame come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale mantenere i file immagine al di fuori del PPTX e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normale nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se potrebbero essere necessarie modifiche ad alta risoluzione in futuro.

**Come dovrebbero essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) incorporato può essere estratto direttamente. Il rendering di una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri leggendo diapositive esistenti?**

Verifica il tipo di forma prima di usare i membri specifici del frame immagine. Un controllo `instanceof` contro [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) evita cast invalidi e consente al codice di gestire le diapositive che non contengono frame immagine.