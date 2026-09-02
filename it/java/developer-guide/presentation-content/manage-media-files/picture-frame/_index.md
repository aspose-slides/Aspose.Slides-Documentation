---
title: Gestire i quadri immagine nelle presentazioni usando Java
linktitle: Quadro immagine
type: docs
weight: 10
url: /it/java/picture-frame/
keywords:
- quadro immagine
- aggiungere quadro immagine
- creare quadro immagine
- immagine incorporata
- immagine collegata
- estrarre immagine
- immagine raster
- immagine SVG
- ritagliare immagine
- eliminare aree ritagliate
- comprimere immagine
- StretchOffset
- formattazione quadro immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Creare, formattare, collegare, ritagliare, estrarre e comprimere i quadri immagine nelle presentazioni con Aspose.Slides per Java."
---
## **Panoramica**

Un quadro immagine è una forma diapositiva che visualizza un’immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) possiede risorse immagine incorporate tramite la sua [IImageCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimagecollection/), mentre un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di cornice.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l’immagine alla presentazione una sola volta, conserva il risultato restituito da [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/), e utilizza quella risorsa immagine quando crei i quadri immagine.

I quadri immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono inoltre fare riferimento a immagini collegate anziché memorizzare i byte dell’immagine nella presentazione. La scelta influisce su portabilità, dimensione del file, estrazione e comportamento di esportazione, quindi è utile decidere come deve essere archiviata l’immagine prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un’immagine incorporata**

Per un’immagine incorporata, aggiungi i dati immagine alla presentazione e crea un quadro immagine con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). L’immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

L’esempio seguente aggiunge un’immagine JPEG, crea una cornice alle dimensioni native dell’immagine e applica la formattazione della linea e la rotazione:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Il quadro immagine controlla la geometria visualizzata; modificare le dimensioni della cornice non cambia le dimensioni pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime l’immagine in seguito.

## **Utilizzare la scala relativa**

[IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) espone la scalatura relativa di larghezza e altezza per la cornice tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Un valore di `1.0` corrisponde al 100 % della dimensione originale dell’immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell’immagine sorgente invece di calcolare manualmente le dimensioni finali.

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

La scala relativa modifica le impostazioni di scala della cornice; non effettua il ricampionamento né la compressione dell’immagine incorporata.

## **Immagini incorporate e collegate**

Un’immagine incorporata memorizza i dati immagine all’interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un’immagine collegata memorizza una posizione esterna tramite il metodo [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) anziché incorporare i dati immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all’applicazione che apre o renderizza la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l’immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un’immagine collegata**

L’esempio seguente crea un quadro immagine e lo collega a un file immagine locale. Gestisce solo il collegamento dell’immagine; il collegamento video è un flusso multimediale separato e non è mescolato in questo esempio.

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

Usa i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è generalmente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai quadri immagine**

Prima di estrarre un’immagine da una presentazione esistente, verifica che una forma sia effettivamente un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) e che contenga un’immagine incorporata. I quadri immagine collegati potrebbero non contenere byte immagine estraibili nello stesso modo.

### **Estrarre un’immagine raster**

L’API immagine moderna utilizza [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) direttamente e non richiede il wrapper Java più vecchio. L’esempio seguente trova la prima immagine raster incorporata in una diapositiva e la salva come PNG:

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

Il salvataggio tramite [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/#save-java.lang.String-int-) converte l’immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione anziché di un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un’immagine SVG**

Per un’immagine SVG, il [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) espone un oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/). Questo consente di recuperare i dati SVG direttamente invece di rasterizzare l’immagine prima.

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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all’interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L’esportazione diapositive in PDF o SVG è anch’essa un’operazione di rendering, quindi la grafica esportata non deve essere trattata come una copia byte‑per‑byte dell’originale SVG incorporato; usa i dati forniti da [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/#getSvgData--) quando è richiesto il vettore originale.

## **Ritagliare un’immagine**

Il ritaglio modifica quale parte dell’immagine è visibile all’interno della cornice. I valori di ritaglio su [IPictureFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/) sono percentuali delle dimensioni dell’immagine di origine. Il ritaglio non elimina inizialmente i pixel nascosti dall’immagine incorporata; cambia solo la regione visibile.

L’esempio seguente trova in modo sicuro un quadro immagine e applica i valori di ritaglio:

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

Poiché i dati immagine nascosti sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati immagine ritagliati**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un’ottimizzazione distruttiva: dopo aver salvato la presentazione, i pixel rimossi non sono più disponibili per un’operazione di “uncrop”.

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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l’immagine originale è usata anche da altri quadri immagine, quei quadri necessitano ancora della loro risorsa esistente, quindi l’eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) riduce la risoluzione dell’immagine raster rispetto alle dimensioni con cui l’immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l’immagine è stata ridimensionata o ritagliata e `false` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/java/com.aspose.slides/picturescompression/) quando una risoluzione target standard è sufficiente:

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

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non è ridotto da questo flusso di compressione raster. Ricorda inoltre che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla più grande dimensione con cui l’immagine verrà effettivamente visualizzata o esportata, anziché applicare il DPI più basso a livello globale.

## **Gestire gli effetti di trasformazione dell’immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedi [Image Transform Effects](/java/image-transform-effects/).

## **Bloccare la geometria del quadro immagine**

Le impostazioni di [IPictureFrameLock](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframelock/) controllano quali operazioni di modifica sono disabilitate per un quadro immagine. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) preserva le proporzioni della forma durante il ridimensionamento.

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

Il blocco si applica alla forma del quadro immagine. Non forza la risorsa immagine sorgente a essere ricampionata o modificata permanentemente con lo stesso rapporto d’aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento immagine è “stretch”, i valori stretch‑offset su [IPictureFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro delimitante del quadro immagine. Percentuali positive creano un’inset da un bordo, mentre percentuali negative creano un’outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell’immagine sorgente è visibile; gli stretch offset modificano il rettangolo in cui il riempimento immagine visibile è allungato.

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

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l’obiettivo è nascondere i bordi dell’immagine sorgente.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali compromessi sono più facili da gestire quando l’archiviazione delle immagini e la formattazione dei quadri immagine sono trattate separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per condivisione e rendering lato server, ma le immagini raster di grandi dimensioni aumentano la dimensione del PPTX e l’uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati fino a quando le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione sorgente. Deve essere applicata dopo che è nota la dimensione finale sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la preservazione vettoriale è importante. Estrai l’SVG incorporato direttamente quando ti serve la risorsa vettoriale stessa. Le esportazioni raster diapositive convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) esistente quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l’ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: conserva loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione visualizzata, rimuovi i pixel ritagliati solo quando la modifica futura non è necessaria e evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un quadro immagine e una risorsa immagine?**

Un [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) è una forma su una diapositiva che visualizza un’immagine e memorizza geometria e formattazione a livello di cornice come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando tenere i file immagine fuori dal PPTX è intenzionale e le posizioni esterne possono essere mantenute in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non da solo. Le impostazioni di ritaglio normali nascondono parti dell’immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) o la compressione dell’immagine con rimozione delle aree ritagliate quando quei pixel possono essere scartati permanentemente.

**Posso ripristinare la qualità dell’immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata, e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l’immagine sorgente originale al di fuori della presentazione se in futuro potresti aver bisogno di modifiche ad alta risoluzione.

**Come devo gestire le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L’[ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) incorporato può essere estratto direttamente. Renderizzare una diapositiva in un formato raster come PNG o JPEG rasterizza l’SVG come parte dell’immagine della diapositiva.

**Come posso evitare cast non sicuri leggendo diapositive esistenti?**

Controlla il tipo di forma prima di utilizzare membri specifici del quadro immagine. Un controllo `instanceof` contro [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) evita cast invalidi e consente al codice di gestire diapositive che non contengono quadri immagine.