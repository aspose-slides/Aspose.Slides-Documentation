---
title: Ottimizzare la gestione delle immagini nelle presentazioni con Java
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/java/image/
keywords:
- aggiungere immagine
- aggiungere foto
- sostituire immagine
- collezione di immagini
- riquadro immagine
- immagine collegata
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Java."
---
## **Introduzione**

Aspose.Slides per Java fornisce diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo di una diapositiva, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire il contenuto SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate all'interno di una presentazione. Per ritaglio, trasparenza, effetti, allungamento e altre formattazioni applicate a un singolo riquadro immagine, vedere [Riquadro immagine](/slides/it/java/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [collezione di immagini della presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Utilizzare [ImageCollection.addImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/imagecollection/) per aggiungere dati immagine e ottenere una risorsa [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/).
- Un [riquadro immagine](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Utilizzare [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo della diapositiva utilizza un'immagine come parte del riempimento della diapositiva piuttosto che come forma. Pertanto non si comporta come un riquadro immagine.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) sostituisce una risorsa immagine. Se diversi elementi della presentazione utilizzano quella risorsa, tutti useranno la sostituzione.
- La conversione di un SVG in forme crea forme di diapositiva modificabili. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un flusso di lavoro tipico è quindi: aggiungere dati immagine alla collezione di immagini, ricevere un [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/), e poi utilizzare tale risorsa in uno o più riquadri immagine o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, caricare il file, aggiungerla alla collezione di immagini e creare un riquadro immagine che utilizza il `IPPImage` restituito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dalla disponibilità del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scaricare i suoi byte, aggiungerli alla collezione di immagini della presentazione e utilizzare la risorsa immagine restituita nello stesso modo di un'immagine locale.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In applicazioni a lunga durata, riutilizzare un client HTTP o una strategia di gestione delle connessioni appropriata all'applicazione invece di creare ripetutamente infrastrutture di rete non necessarie. Inoltre, convalidare gli URL remoti, le dimensioni delle risposte e i tipi di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungerla alla presentazione una sola volta e riutilizzare il [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) restituito quando si creano ulteriori riquadri immagine. Ciò evita di caricare ripetutamente gli stessi dati di origine e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per elementi grafici che dovrebbero apparire automaticamente su molte diapositive, come il logo di un'azienda, considerare di posizionare il riquadro immagine su un [master diapositiva](/slides/it/java/slide-master/) o layout invece di aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo viene assegnata al riempimento della diapositiva; non è aggiunta come forma di riquadro immagine. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto della diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per opzioni di sfondo aggiuntive, inclusi sfondi di master e layout, vedere [Sfondo della presentazione](/slides/it/java/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e quelle collegate hanno diversi compromessi in termini di portabilità e dimensione del file:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o l'URL esterno tramite [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidespicture/) anziché incorporare i dati dell'immagine.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilizzare immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono solitamente più sicure.

## **Lavorare con le immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che dovrebbero essere scalate senza la stessa perdita di dettaglio delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come fonte per forme di diapositiva modificabili.

### **Aggiungere un SVG come immagine**

Creare un [SvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgimage/), aggiungerlo alla collezione di immagini e posizionare la risorsa immagine risultante in un riquadro immagine.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini, fogli di stile o font esterni. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgimage/) fornisce costruttori che accettano un [IExternalResourceResolver](https://reference.aspose.com/slides/it/java/com.aspose.slides/iexternalresourceresolver/) e un URI di base. Il risolutore può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il risolutore rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorporare le risorse necessarie nell'SVG stesso, ad esempio usando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limitare gli schemi, le posizioni dei file e gli host a cui il risolutore può accedere. I risolutori di rete dovrebbero inoltre applicare timeout, limiti di dimensione delle risposte e convalida del contenuto.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme di diapositiva modificabili, simile al comando corrispondente di PowerPoint.

![Menu a comparsa di PowerPoint](img_01_01.png)

Utilizzare la sovraccarico [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/) che accetta un [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) per eseguire la conversione.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilizzare la conversione da SVG a forme quando gli elementi vettoriali individuali devono essere modificati come forme di PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Utilizzare [IPPImage.replaceImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) quando si desidera sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafica condivisa come i loghi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se più riquadri immagine, sfondi, master o layout utilizzano la stessa risorsa immagine, sostituire tale risorsa aggiorna tutti quegli utilizzi. Se deve cambiare solo un riquadro immagine, assegnare un'immagine diversa a quel riquadro invece di sostituire la risorsa condivisa.

`replaceImage` fornisce inoltre sovraccarichi che accettano un array di byte o un altro [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare la dimensione della presentazione**

Le grandi immagini raster possono rendere una presentazione inutilmente grande. Utilizzare immagini sorgente con dimensioni appropriate per la dimensione di visualizzazione prevista, riutilizzare le risorse immagine condivise quando possibile e evitare di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per le immagini raster già inserite in riquadri immagine, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/) può ridurre i dati immagine in base alla risoluzione selezionata e alle impostazioni di ritaglio. Questo è un processamento di riquadro immagine piuttosto che una gestione della collezione di immagini, quindi vedere [Riquadro immagine](/slides/it/java/picture-frame/) per le operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporazione rende la presentazione portabile perché tutti i dati immagine necessari viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Utilizzare i collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, utilizzare una singola risorsa immagine e riutilizzarla. Se la grafica appartiene al design della presentazione piuttosto che al contenuto della diapositiva, posizionarla su un master o layout affinché sia ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file esterni o risorse di rete. Quando possibile, incorporare le risorse necessarie prima di importare l'SVG. Convertire SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Utilizzare l'API immagine moderna e multipiattaforma**

Per il nuovo codice Java, utilizzare le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/java/com.aspose.slides/images/) invece della vecchia API pubblica basata su `java.awt.image.BufferedImage`. Vedere [API moderna](/slides/it/java/modern-api/) per le indicazioni sulla migrazione.

WMF ed EMF richiedono considerazioni particolari. Quando questi formati vengono passati attraverso un [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/imagecollection/) converte il metafile in una rappresentazione PNG raster prima dell'inserimento. Se è importante preservare i dati del metafile, utilizzare invece una sovraccarico basata su stream di [ImageCollection.addImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/imagecollection/). Generare contenuti EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato e non rientra nell'ambito di questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione di immagini e un riquadro immagine?**

La collezione di immagini memorizza risorse immagine riutilizzabili. Un riquadro immagine è una forma della diapositiva che visualizza una di quelle risorse e fornisce formattazioni specifiche per l'immagine, come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituire quella risorsa con [IPPImage.replaceImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal suo file o URL esterno. Se quella risorsa non può essere raggiunta dall'altro computer, l'immagine collegata potrebbe non essere disponibile. Incorporare l'immagine quando la presentazione deve essere autonoma.

**È possibile modificare un SVG inserito come forme di PowerPoint?**

Sì. Convertire l'SVG con [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/); il gruppo risultante contiene forme di diapositiva modificabili anziché un'unica immagine SVG.

**Come posso mantenere più piccole le presentazioni con molte immagini?**

Riutilizzare le risorse immagine condivise, evitare sorgenti raster inutilmente grandi, comprimere le immagini raster appropriate quando opportuno, mantenere il branding ripetuto su master o layout e utilizzare immagini collegate solo quando una dipendenza esterna è accettabile.