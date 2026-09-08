---
title: Ottimizza la gestione delle immagini nelle presentazioni usando Python
linktitle: Gestisci le immagini
type: docs
weight: 10
url: /it/python-java/image/
keywords:
- aggiungi immagine
- aggiungi foto
- sostituisci immagine
- collezione di immagini
- riquadro immagine
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
- Python
- Java
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via Java."
---
## **Introduzione**

Aspose.Slides per Python tramite Java offre diversi metodi per lavorare con le immagini, ognuno dei quali ha uno scopo differente. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo della diapositiva, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate in una presentazione. Per ritaglio, trasparenza, effetti, allungamento e altre formattazioni applicate a un singolo riquadro immagine, vedere [Riquadro immagine](/slides/it/python-java/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [collezione di immagini della presentazione](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Usa [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) per aggiungere dati immagine e ottenere una risorsa [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/).
- Un [riquadro immagine](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Usa [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addPictureFrame) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo della diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come un riquadro immagine.
- [PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage) sostituisce una risorsa immagine. Se più elementi della presentazione utilizzano quella risorsa, tutti utilizzeranno la sostituzione.
- Convertire un SVG in forme crea forme modificabili nella diapositiva. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un tipico flusso di lavoro è quindi: aggiungere dati immagine alla collezione di immagini, ricevere un [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/), e quindi usare quella risorsa in uno o più riquadri immagine o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, carica il file, aggiungila alla collezione di immagini e crea un riquadro immagine che utilizza il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) restituito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultato non dipende dal mantenimento disponibile del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scarica i suoi byte, aggiungili alla collezione di immagini della presentazione e usa la risorsa immagine restituita allo stesso modo di un'immagine locale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In applicazioni a lungo termine, riutilizza un client HTTP o una strategia di gestione delle connessioni appropriata all'applicazione anziché creare ripetutamente infrastrutture di rete non necessarie. Convalida inoltre gli URL remoti, le dimensioni delle risposte e i tipi di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungila alla presentazione una sola volta e riutilizza il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) restituito quando crei ulteriori riquadri immagine. Questo evita di caricare ripetutamente gli stessi dati sorgente e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per grafica che deve comparire automaticamente su molte diapositive, ad esempio un logo aziendale, considera di posizionare il riquadro immagine su un [master della diapositiva](/slides/it/python-java/slide-master/) o layout anziché aggiungere una forma equivalente su ogni diapositiva.

## **Usare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo viene assegnata al riempimento della diapositiva; non viene aggiunta come forma di riquadro immagine. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto della diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per ulteriori opzioni di sfondo, inclusi sfondi di master e layout, vedere [Sfondo della presentazione](/slides/it/python-java/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e le immagini collegate hanno diversi compromessi di portabilità e dimensione del file:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o l'URL esterno tramite [Picture.setLinkPathLong](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#setLinkPathLong) anziché incorporare i dati dell'immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono solitamente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che devono scalare senza la stessa perdita di dettagli delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come origine per forme diapositive modificabili.

### **Aggiungere un SVG come immagine**

Crea un [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/), aggiungilo alla collezione di immagini e posiziona la risorsa immagine risultante in un riquadro immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini esterne, fogli di stile o font. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) fornisce costruttori che accettano un [ExternalResourceResolver](https://reference.aspose.com/slides/it/python-java/aspose.slides/externalresourceresolver/) e un URI base. Il risolutore può mappare un URI relativo a un URI assoluto consentito e restituire un flusso per la risorsa richiesta.

Il risolutore rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorpora le risorse necessarie direttamente nell'SVG, ad esempio utilizzando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limita gli schemi, le posizioni dei file e gli host a cui il risolutore può accedere. I risolutori di rete dovrebbero inoltre applicare timeout, limiti di dimensione della risposta e validazione del contenuto.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme diapositive modificabili, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Usa il sovraccarico [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addGroupShape) che accetta un [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) per eseguire la conversione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa la conversione SVG‑in‑forme quando i singoli elementi vettoriali devono essere modificati come forme PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Usa [PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage) quando desideri sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come i loghi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se più riquadri immagine, sfondi, master o layout utilizzano la stessa risorsa immagine, la sostituzione di quella risorsa aggiorna tutti gli utilizzi. Se deve cambiare solo un riquadro immagine, assegna un'immagine diversa a quel riquadro invece di sostituire la risorsa condivisa.

[PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage) fornisce anche sovraccarichi che accettano un array di byte o un altro [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare le dimensioni della presentazione**

Immagini raster di grandi dimensioni possono rendere una presentazione inutilmente grande. Usa immagini sorgente con dimensioni appropriate per la visualizzazione prevista, riutilizza le risorse immagine condivise quando possibile e evita di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per immagini raster già inserite in riquadri immagine, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#compressImage) può ridurre i dati immagine in base alla risoluzione e alle impostazioni di ritaglio selezionate. Questo è un'elaborazione del riquadro immagine piuttosto che della collezione di immagini, quindi consultare [Riquadro immagine](/slides/it/python-java/picture-frame/) per le operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portabile perché tutti i dati immagine richiesti viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Usa i collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ricorrenti, usa una singola risorsa immagine e riutilizzala. Se la grafica appartiene al design della presentazione più che al contenuto delle diapositive, posizionala su un master o layout in modo che venga ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file esterni o risorse di rete. Quando possibile, incorpora le risorse necessarie prima di importare l'SVG. Converti SVG in forme solo quando i singoli elementi vettoriali devono essere modificati.

### **Usare l'API immagine moderna cross‑platform**

Per nuovo codice Python tramite Java, utilizza gli oggetti immagine cross‑platform di Aspose.Slides e le API [Images](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/) invece della vecchia API pubblica basata su `java.awt.image.BufferedImage`. Vedere [Modern API](/slides/it/python-java/modern-api/) per le indicazioni di migrazione.

WMF ed EMF richiedono considerazioni speciali. Quando questi formati vengono passati attraverso un oggetto immagine cross‑platform, [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) converte il metafile in una rappresentazione raster PNG prima dell'inserimento. Se è importante preservare i dati del metafile, utilizza il sovraccarico basato su stream di [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) invece. Generare contenuti EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato e non rientra nell'ambito di questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione di immagini e un riquadro immagine?**

La collezione di immagini memorizza risorse immagine riutilizzabili. Un riquadro immagine è una forma della diapositiva che visualizza una di queste risorse e fornisce formattazioni specifiche dell'immagine come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituisci quella risorsa con [PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal suo file esterno o URL. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata può non essere disponibile. Incorpora l'immagine quando la presentazione deve essere autonoma.

**Un SVG inserito può essere modificato come forme PowerPoint?**

Sì. Converti l'SVG con [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addGroupShape); il gruppo risultante contiene forme diapositive modificabili anziché un'unica immagine SVG.

**Come posso mantenere più piccole le presentazioni con molte immagini?**

Riutilizza le risorse immagine condivise, evita sorgenti raster inutilmente grandi, comprimi le immagini raster adeguate quando opportuno, mantieni il branding ripetuto su master o layout e usa immagini collegate solo quando una dipendenza esterna è accettabile.