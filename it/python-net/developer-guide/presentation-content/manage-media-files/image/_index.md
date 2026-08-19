---
title: Ottimizzare la gestione delle immagini nelle presentazioni con Python
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/python-net/image/
keywords:
- aggiungi immagine
- aggiungi foto
- sostituisci immagine
- collezione di immagini
- cornice immagine
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
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET."
---
## **Introduzione**

Aspose.Slides per Python via .NET offre diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in una cornice immagine, usarla come sfondo della diapositiva, collegarsi a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate all'interno di una presentazione. Per ritaglio, trasparenza, effetti, allungamento e altre formattazioni applicate a una singola cornice immagine, vedere [Picture Frame](/slides/it/python-net/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [collezione di immagini della presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Usa [ImageCollection.add_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/add_image/) per aggiungere i dati dell'immagine e ottenere una risorsa [IPPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/).
- Un [cornice immagine](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Usa [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo della diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come una cornice immagine.
- [IPPImage.replace_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/replace_image/) sostituisce una risorsa immagine. Se diversi elementi della presentazione usano quella risorsa, tutti utilizzano la sostituzione.
- La conversione di un SVG in forme crea forme modificabili della diapositiva. Dopo la conversione, il contenuto non è più gestito come una singola risorsa immagine.

Un tipico flusso di lavoro è quindi: aggiungere i dati dell'immagine alla collezione immagini, ricevere un [IPPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/), e quindi usare quella risorsa in una o più cornici immagine o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, leggi il file, aggiungi i suoi dati alla collezione immagini e crea una cornice immagine che utilizza il `IPPImage` restituito.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dalla disponibilità del file immagine originale.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scarica i byte, aggiungili alla collezione immagini della presentazione e usa la risorsa immagine restituita nello stesso modo di un'immagine locale.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

In applicazioni a lungo termine, riutilizza un client HTTP o un pool di connessioni dove opportuno anziché creare una nuova connessione per ogni richiesta. Valida anche gli URL remoti, le dimensioni delle risposte e i tipi di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più di una volta, aggiungila alla presentazione una sola volta e riutilizza il [IPPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/) restituito quando crei cornici immagine aggiuntive. Questo evita di caricare ripetutamente gli stessi dati di origine e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per elementi grafici che dovrebbero apparire automaticamente su molte diapositive, come il logo aziendale, considera di posizionare la cornice immagine su un [slide master](/slides/it/python-net/slide-master/) o layout invece di aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo della diapositiva**

Un'immagine di sfondo è assegnata al riempimento della diapositiva; non è aggiunta come forma cornice immagine. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto della diapositiva.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Per ulteriori opzioni di sfondo, inclusi sfondi di master e layout, vedere [Presentation Background](/slides/it/python-net/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e quelle collegate hanno diversi compromessi di portabilità e dimensione del file:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file comprende i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre le dimensioni della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o renderizzata.

Un'immagine collegata può essere creata assegnando il percorso o URL esterno tramite [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/it/python-net/aspose.slides/islidespicture/link_path_long/) anziché incorporare i dati dell'immagine.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Usa immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono solitamente più sicure.

## **Lavorare con le immagini SVG**

SVG è un formato vettoriale, perciò può essere utile per icone, diagrammi e altre grafiche che devono scalare senza perdere dettagli come le immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come origine per forme modificabili della diapositiva.

### **Aggiungere un SVG come immagine**

Crea un [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/), aggiungilo alla collezione immagini e posiziona la risorsa immagine risultante in una cornice immagine.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme modificabili della diapositiva, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Usa il sovraccarico [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_group_shape/) che accetta un [ISvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/isvgimage/) per eseguire la conversione.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Usa la conversione SVG‑in‑forme quando gli elementi vettoriali individuali devono essere modificati come forme PowerPoint. Se lo SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Usa [IPPImage.replace_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/replace_image/) quando desideri sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come i loghi.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Se più cornici immagine, sfondi, master o layout usano la stessa risorsa immagine, la sostituzione di quella risorsa aggiorna tutti gli utilizzi. Se deve cambiare solo una cornice immagine, assegna un'immagine diversa a quella cornice invece di sostituire la risorsa condivisa.

`replace_image` fornisce anche sovraccarichi che accettano un [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) o un altro [IPPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare le dimensioni della presentazione**

Le grandi immagini raster possono rendere una presentazione inutilmente grande. Usa immagini di origine con dimensioni appropriate per la visualizzazione prevista, riutilizza le risorse immagine condivise dove possibile e evita di incorporare copie ripetute della stessa grafica ad alta risoluzione.

Per immagini raster già inserite in cornici immagine, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/compress_image/) può ridurre i dati dell'immagine in base alla risoluzione e alle impostazioni di ritaglio selezionate. Questa è una lavorazione a livello di cornice immagine piuttosto che di collezione immagini, quindi vedi [Picture Frame](/slides/it/python-net/picture-frame/) per operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portatile perché tutti i dati immagine necessari viaggiano con il file. Il collegamento può ridurre le dimensioni del file, ma introduce una dipendenza esterna. Usa i collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, usa una sola risorsa immagine e riutilizzala. Se la grafica appartiene al design della presentazione piuttosto che al contenuto della diapositiva, posizionala su un master o layout così da essere ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Uno SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a uno SVG che dipende da file esterni o risorse di rete. Quando possibile, incorpora le risorse necessarie prima di importare lo SVG. Converti SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Utilizzare l'API immagine moderna e multipiattaforma**

Per nuovo codice Python via .NET, usa le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/python-net/aspose.slides/images/) invece delle deprecate API immagine `aspose.pydrawing.Image` o `aspose.pydrawing.Bitmap`. Vedi [Modern API](/slides/it/python-net/modern-api/) per le indicazioni di migrazione.

WMF e EMF richiedono considerazioni speciali. Quando questi formati vengono passati attraverso un [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/add_image/) converte il metafile in una rappresentazione raster PNG prima dell'inserimento. Se è importante preservare i dati del metafile, usa il sovraccarico basato su stream di [ImageCollection.add_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/add_image/). Generare contenuto EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato e non rientra nello scopo di questo articolo.

## **Domande frequenti**

**Qual è la differenza tra la collezione di immagini e una cornice immagine?**

La collezione di immagini memorizza risorse immagine riutilizzabili. Una cornice immagine è una forma della diapositiva che visualizza una di quelle risorse e fornisce formattazioni specifiche per l'immagine, come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituisci quella risorsa con [IPPImage.replace_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/ippimage/replace_image/). Per il branding a livello di presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal suo file o URL esterno. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata può risultare indisponibile. Incorpora l'immagine quando la presentazione deve essere autonoma.

**Un SVG inserito può essere modificato come forme PowerPoint?**

Sì. Converti lo SVG con [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_group_shape/); il gruppo risultante contiene forme modificabili della diapositiva anziché un'unica immagine SVG.

**Come posso mantenere le presentazioni con molte immagini più piccole?**

Riutilizza le risorse immagine condivise, evita sorgenti raster inutilmente grandi, comprimi le immagini raster appropriate quando opportuno, mantieni il branding ripetuto su master o layout e usa immagini collegate solo quando una dipendenza esterna è accettabile.