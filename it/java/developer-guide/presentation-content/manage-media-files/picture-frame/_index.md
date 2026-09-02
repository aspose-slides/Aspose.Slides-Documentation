---
title: Gestire i picture frame nelle presentazioni con Java
linktitle: Frame immagine
type: docs
weight: 10
url: /it/java/picture-frame/
keywords:
- frame immagine
- aggiungi picture frame
- crea picture frame
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione picture frame
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime picture frame nelle presentazioni con Aspose.Slides per Java."
---
## **Panoramica**

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: un [Presentation] possiede risorse immagine incorporate tramite la sua [IImageCollection], mentre un [IPictureFrame] controlla la posizione, la dimensione, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di cornice.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [IPPImage] restituito e utilizza quella risorsa immagine quando crei i picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate anziché memorizzare i byte dell'immagine nella presentazione. La scelta influisce su portabilità, dimensione del file, estrazione e comportamento di esportazione, quindi è utile decidere come l'immagine debba essere memorizzata prima di applicare formattazione o ottimizzazione.

## **Aggiungere e Formattare un'Immagine Incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un picture frame con [IShapeCollection.addPictureFrame]. L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

Il seguente esempio aggiunge un'immagine JPEG, crea una cornice con le dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:
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

Il picture frame controlla la geometria visualizzata; modificare le dimensioni della cornice non cambia le dimensioni originali in pixel memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Utilizzare la Scala Relativa**

[IPictureFrame] espone la scalatura relativa di larghezza e altezza per la cornice tramite [setRelativeScaleWidth] e [setRelativeScaleHeight]. Un valore di `1.0` corrisponde al 100% della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con le dimensioni dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.
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

La scala relativa modifica le impostazioni di scala della cornice; non ricampiona né comprime l'immagine incorporata.

## **Immagini Incorporate e Collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e un rendering prevedibile. Un'immagine collegata memorizza una posizione esterna tramite il metodo [ISlidesPicture.setLinkPathLong] invece di incorporare i dati dell'immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via email, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'Immagine Collegata**

Il seguente esempio crea un picture frame e lo collega a un file immagine locale. Si occupa solo del collegamento di immagini; il collegamento di video è un flusso di lavoro multimediale separato e non è mescolato intenzionalmente in questo esempio.
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

Usa i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituti della compressione: un PPTX piccolo con dipendenze di immagine interrotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre Immagini dai Picture Frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [IPictureFrame] e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere byte immagine estraibili nello stesso modo.

### **Estrarre un'Immagine Raster**

L'API immagine moderna utilizza [IImage] direttamente e non richiede il wrapper immagine Java più vecchio. Il seguente esempio trova la prima immagine raster incorporata su una diapositiva e la salva come PNG:
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

Il salvataggio tramite [IImage.save] converte l'immagine estratta nel formato di output richiesto. Se ti servono i byte codificati memorizzati nella presentazione anziché un file raster convertito, utilizza i dati binari della risorsa immagine.

### **Estrarre un'Immagine SVG**

Per un'immagine SVG, il [IPPImage] espone un oggetto [ISvgImage]. Ciò consente di recuperare i dati SVG direttamente invece di rasterizzare prima l'immagine.
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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione di diapositive in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non dovrebbe essere trattata come una copia byte‑per‑byte dell'SVG incorporato originale; usa i dati dell'[ISvgImage.getSvgData] incorporati quando è richiesto il vettore originale.

## **Ritagliare un'Immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno della cornice. I valori di ritaglio su [IPictureFillFormat] sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

Il seguente esempio trova in modo sicuro un picture frame e applica i valori di ritaglio:
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

## **Rimuovere i Dati dell'Immagine Ritagliata**

[IPictureFillFormat.deletePictureCroppedAreas] rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un'operazione di "uncrop" successiva.
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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è usata anche da altri picture frame, quei frame hanno ancora bisogno della loro risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere Immagini Raster**

[IPictureFillFormat.compressImage] riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l'immagine è stata ridimensionata o ritagliata e `false` quando non era necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression] quando è sufficiente una risoluzione target standard:
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

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non è ridotto da questo flusso di lavoro di compressione raster. Ricorda anche che risoluzione più bassa e regioni ritagliate cancellate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla più grande dimensione alla quale l'immagine sarà effettivamente visualizzata o esportata, anziché applicare il DPI più basso a livello globale.

## **Gestire gli Effetti di Trasformazione dell'Immagine**

Per un flusso di lavoro completo che copre luminosità, contrasto, trasformazioni colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, vedere [Image Transform Effects](/slides/it/java/image-transform-effects/).

## **Bloccare la Geometria del Picture Frame**

Le impostazioni di [IPictureFrameLock] controllano quali operazioni di modifica sono disabilitate per un picture frame. Per esempio, [setAspectRatioLocked] preserva le proporzioni della forma mentre viene ridimensionata.
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

Il blocco si applica alla forma del picture frame. Non forza l'immagine sorgente a essere ricampionata o modificata permanentemente nello stesso rapporto d'aspetto.

## **Regolare i Valori StretchOffset**

Quando la modalità di riempimento immagine è stretch, i valori stretch‑offset su [IPictureFillFormat] definiscono il rettangolo di riempimento relativo al riquadro del picture frame. Le percentuali positive creano un rientro dal bordo, mentre le percentuali negative creano un'estensione.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli stretch offset modificano il rettangolo in cui il riempimento immagine visibile viene stirato.
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

## **Considerazioni su Archiviazione, Dimensione del File ed Esportazione**

I principali compromessi sono più facili da gestire quando lo storage delle immagini e la formattazione dei picture frame vengono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per condivisione e rendering lato server, ma le grandi immagini raster aumentano le dimensioni del PPTX e l'uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente le dimensioni del file per immagini raster sovradimensionate, ma sacrifica la risoluzione originale. Deve essere applicata dopo aver conosciuto la dimensione finale dell'immagine nella diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando è importante preservare il vettore. Estrai direttamente l'SVG incorporato quando ti serve la risorsa vettoriale stessa. Le esportazioni diapositive raster come PNG o JPEG convertono sempre l'SVG renderizzato in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [IPPImage] esistente quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando viene effettuata in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando una modifica futura non è necessaria e evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [IPPImage] rappresenta una risorsa immagine associata alla presentazione. Un [IPictureFrame] è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria e la formattazione a livello di cornice, come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza l'accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine fuori dal PPTX è intenzionale e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normali nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [IPictureFillFormat.deletePictureCroppedAreas] o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se in futuro potresti aver bisogno di editing ad alta risoluzione.

**Come devono essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[ISvgImage] incorporato può essere estratto direttamente. Renderizzare una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri quando leggo diapositive esistenti?**

Controlla il tipo di forma prima di utilizzare i membri specifici del picture frame. Un controllo `instanceof` contro [IPictureFrame] evita cast non validi e consente al codice di gestire le diapositive che non contengono picture frame.