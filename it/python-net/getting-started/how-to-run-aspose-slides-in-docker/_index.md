---
title: Come eseguire Aspose.Slides in Docker
linktitle: Aspose.Slides in Docker
type: docs
weight: 150
url: /it/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides in Docker
- Contenitore Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Esegui Aspose.Slides per Python via .NET in Docker: un Dockerfile funzionante, le librerie native necessarie al pacchetto, configurazione dei font e licenza all'interno di un contenitore."
---
## **Panoramica**

Aspose.Slides for Python via .NET funziona nei container Linux, ma il pacchetto è un wrapper Python attorno a un runtime .NET Core 3.1 incluso. Questo runtime richiede tre librerie native che le image Python slim non includono, ed è esigente riguardo alle loro versioni. Questo articolo fornisce un Dockerfile che funziona, spiega perché ciascuna dipendenza è presente e mostra come aggiungere font e una licenza.

## **Un Dockerfile funzionante**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Compila ed esegui:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Perché l'immagine di base è Debian 11**

Il wheel `aspose.slides` include un runtime **.NET Core 3.1**, e quel runtime è antecedente alle versioni delle librerie fornite dalle attuali release di Debian. Su Debian 12 e 13 il container si costruisce correttamente ma poi fallisce alla prima chiamata `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Il messaggio è fuorviante — ICU *è* installato su quelle immagini, ma è ICU 72 o 76, e .NET Core 3.1 riconosce solo versioni principali più vecchie. Debian 12 inoltre fornisce OpenSSL 3, il che genera un secondo errore:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` è Debian 11, che fornisce entrambe le versioni attese dal runtime incluso:

| Pacchetto | Versione su Debian 11 | Perché è necessario |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementazione GDI+ usata per il rendering di forme, testo e immagini |
| `libicu67` | 67.1 | Dati di internazionalizzazione. Le versioni principali più recenti non sono riconosciute da .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Crittografia. Preinstallato su Debian 11; assente su Debian 12+ |
| `libfontconfig1` | — | Rilevamento dei font |

`libssl1.1` è già presente nell'immagine di base, quindi non è necessario elencarlo in `apt-get install`.

Se devi usare un'immagine di base più recente, imposta `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` per aggirare il requisito di ICU. Questo disabilita la formattazione specifica della cultura e **non** risolve il problema di OpenSSL, quindi Debian 11 rimane la scelta più semplice.

## **Font**

Le immagini slim non contengono affatto font. Senza almeno un font installato, il testo viene visualizzato come riquadri vuoti in PDF, immagini e output HTML. `fonts-dejavu-core` è un piccolo punto di partenza di uso generale.

Per corrispondere all'aspetto previsto di una presentazione, copia i font che utilizza nell'immagine e indica ad Aspose.Slides di usarli:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licenze all'interno di un container**

Non includere il file di licenza nell'immagine — chiunque scarichi l'immagine otterrà la licenza. Montala invece al momento dell'esecuzione:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Senza una licenza la libreria funziona in modalità di valutazione, che aggiunge una filigrana e limita il numero di diapositive elaborate. Vedi [Licensing](/slides/it/python-net/licensing/) per i dettagli.

## **Memoria**

Il rendering in PDF o immagini richiede più memoria rispetto alla lettura di un file. I container con limiti di memoria ristretti possono essere terminati dall'OOM killer a metà di una conversione, il che di solito si manifesta come la scomparsa del processo senza un traceback Python. Se ciò accade, aumenta il limite di memoria del container prima di analizzare il codice.