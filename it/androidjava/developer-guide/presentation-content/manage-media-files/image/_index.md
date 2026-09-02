---
title: Ottimizzare la gestione delle immagini nelle presentazioni su Android
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/androidjava/image/
keywords:
- aggiungi immagine
- aggiungi foto
- sostituisci immagine
- raccolta di immagini
- frame immagine
- immagine collegata
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android via Java."
---
## **Introduzione**

Aspose.Slides for Android via Java offre diversi modi per lavorare con le immagini, ognuno dei quali serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un picture frame, usarla come sfondo della diapositiva, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate all'interno di una presentazione. Per ritaglio, trasparenza, effetti, stiramento e altre formattazioni applicate a un singolo picture frame, vedere [Picture Frame](/slides/it/androidjava/picture-frame/).

## **Comprendere il modello di immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [presentation image collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Utilizzare [ImageCollection.addImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imagecollection/) per aggiungere dati immagine e ottenere una risorsa [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/).
- Un [picture frame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Utilizzare [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo della diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come un picture frame.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) sostituisce una risorsa immagine. Se diversi elementi della presentazione usano quella risorsa, tutti utilizzano la sostituzione.
- Convertire un SVG in forme crea forme modificabili della diapositiva. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un tipico flusso di lavoro è quindi: aggiungere dati immagine alla image collection, ricevere un [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/), e quindi usare quella risorsa in uno o più picture frame o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, caricare il file, aggiungerla alla image collection e creare un picture frame che utilizzi l'`IPPImage` restituito.

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

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dalla disponibilità continuata del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scaricare i byte, aggiungerli alla presentation image collection e utilizzare la risorsa immagine restituita nello stesso modo di un'immagine locale.

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

In applicazioni a lunga durata, riutilizzare un client HTTP o una strategia di gestione delle connessioni appropriata piuttosto che creare ripetutamente infrastrutture di rete non necessarie. Inoltre, convalidare gli URL remoti, le dimensioni della risposta e i tipi di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungerla alla presentazione una sola volta e riutilizzare l'[IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) restituito quando si creano picture frame aggiuntivi. Questo evita di caricare ripetutamente gli stessi dati sorgente e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per grafiche che devono apparire automaticamente su molte diapositive, come il logo aziendale, considerare di posizionare il picture frame su uno [slide master](/slides/it/androidjava/slide-master/) o su un layout anziché aggiungere una forma equivalente a ogni diapositiva.

## **Utilizzare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo è assegnata al riempimento della diapositiva; non viene aggiunta come forma picture‑frame. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto della diapositiva.

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

Per ulteriori opzioni di sfondo, incluse quelle per master e layout, vedere [Presentation Background](/slides/it/androidjava/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e quelle collegate presentano diversi compromessi di portabilità e dimensione del file:

- **Immagine incorporata:** i dati immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o URL esterno tramite [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidespicture/) anziché incorporare i dati immagine.

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

Utilizzare le immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono solitamente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che devono scalare senza perdere dettagli come le immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come sorgente per forme modificabili della diapositiva.

### **Aggiungere un SVG come immagine**

Creare un [SvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgimage/), aggiungerlo alla image collection e posizionare la risorsa immagine risultante in un picture frame.

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

Un SVG può fare riferimento a immagini, fogli di stile o font esterni. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgimage/) fornisce costruttori che accettano un [IExternalResourceResolver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iexternalresourceresolver/) e un URI di base. Il resolver può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il resolver rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorporare le risorse necessarie direttamente nell'SVG, ad esempio usando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limitare gli schemi, le posizioni dei file e gli host a cui il resolver può accedere. I resolver di rete dovrebbero inoltre applicare timeout, limiti di dimensione della risposta e convalida del contenuto.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme modificabili della diapositiva, analogo al comando corrispondente di PowerPoint.

![Menu a comparsa di PowerPoint](img_01_01.png)

Utilizzare la sovraccarica di [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) che accetta un [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) per eseguire la conversione.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usare la conversione SVG‑to‑shapes quando è necessario modificare singoli elementi vettoriali come forme di PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita la creazione di molte forme separate.

## **Sostituire una risorsa immagine esistente**

Utilizzare [IPPImage.replaceImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) quando si desidera sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come loghi.

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

Se più picture frame, sfondi, master o layout usano la stessa risorsa immagine, la sostituzione di quella risorsa aggiorna tutti gli utilizzi. Se deve cambiare solo un picture frame, assegnare un'immagine diversa a quel frame invece di sostituire la risorsa condivisa.

`replaceImage` fornisce anche sovraccariche che accettano un array di byte o un altro [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare le dimensioni della presentazione**

Le immagini raster di grandi dimensioni possono rendere una presentazione inutilmente pesante. Utilizzare immagini sorgente con dimensioni appropriate per la visualizzazione prevista, riutilizzare risorse immagine condivise quando possibile ed evitare di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per le immagini raster già inserite in picture frame, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) può ridurre i dati immagine in base alla risoluzione e alle impostazioni di ritaglio selezionate. Questa è un'elaborazione a livello di picture‑frame, non di gestione della image collection, quindi consultare [Picture Frame](/slides/it/androidjava/picture-frame/) per le operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portabile perché tutti i dati immagine richiesti viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Utilizzare i collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, utilizzare una singola risorsa immagine e riutilizzarla. Se la grafica appartiene al design della presentazione più che al contenuto delle diapositive, posizionarla su un master o layout in modo che sia ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file o risorse di rete esterne. Quando possibile, incorporare le risorse richieste prima di importare l'SVG. Convertire SVG in forme solo quando è necessario modificare i singoli elementi vettoriali.

### **Utilizzare l'API immagine moderna e cross‑platform**

Per nuovo codice Android via Java, utilizzare le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/images/) invece della legacy API pubblica basata su `android.graphics.Bitmap`. Vedere [Modern API](/slides/it/androidjava/modern-api/) per le linee guida di migrazione.

WMF e EMF richiedono considerazioni speciali. Quando questi formati vengono passati attraverso un [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imagecollection/) converte il metafile in una rappresentazione raster PNG prima dell'inserimento. Se è importante conservare i dati del metafile, utilizzare la sovraccarica basata su stream di [ImageCollection.addImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imagecollection/). Generare contenuti EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato e non è coperto da questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione di immagini e un picture frame?**

La collezione di immagini memorizza risorse immagine riutilizzabili. Un picture frame è una forma della diapositiva che visualizza una di quelle risorse e fornisce formattazioni specifiche per le immagini, come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituire quella risorsa con [IPPImage.replaceImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un picture collegato dipende dal suo file o URL esterno. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata può non essere disponibile. Incorporare l'immagine quando la presentazione deve essere autonomamente contenuta.

**Un SVG inserito può essere modificato come forme di PowerPoint?**

Sì. Convertire l'SVG con [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/); il gruppo risultante contiene forme di diapositiva modificabili anziché un'unica immagine SVG.

**Come posso mantenere le presentazioni con molte immagini più leggere?**

Riutilizzare risorse immagine condivise, evitare sorgenti raster inutilmente grandi, comprimere le immagini raster appropriate quando opportuno, tenere il branding ripetuto su master o layout e utilizzare immagini collegate solo quando una dipendenza esterna è accettabile.