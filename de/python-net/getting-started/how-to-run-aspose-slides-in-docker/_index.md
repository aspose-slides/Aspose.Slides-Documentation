---
title: Wie man Aspose.Slides in Docker ausführt
linktitle: Aspose.Slides in Docker
type: docs
weight: 150
url: /de/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides in Docker
- Docker-Container
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- Schriftarten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET in Docker ausführen: ein funktionierendes Dockerfile, die nativen Bibliotheken, die das Paket benötigt, Schriftartkonfiguration und Lizenzierung innerhalb eines Containers."
---
## **Übersicht**

Aspose.Slides for Python via .NET läuft in Linux‑Containern, aber das Paket ist ein Python‑Wrapper um eine mitgelieferte .NET‑Core‑3.1‑Runtime. Diese Runtime benötigt drei native Bibliotheken, die in schlanken Python‑Images nicht enthalten sind, und sie ist picky bezüglich ihrer Versionen. Dieser Artikel liefert ein funktionierendes Dockerfile, erklärt, warum jede Abhängigkeit vorhanden ist, und zeigt, wie man Schriftarten und eine Lizenz hinzufügt.

## **Ein funktionierendes Dockerfile**

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

Erstellen und ausführen:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Warum das Basis‑Image Debian 11 ist**

Das `aspose.slides`‑Wheel enthält eine **.NET‑Core‑3.1**‑Runtime, und diese Runtime ist älter als die Bibliotheksversionen, die in den aktuellen Debian‑Veröffentlichungen enthalten sind. Auf Debian 12 und 13 wird der Container erfolgreich gebaut, schlägt jedoch beim ersten Aufruf von `Presentation()` fehl:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Die Meldung ist irreführend – ICU ist auf diesen Images zwar installiert, aber es handelt sich um ICU 72 bzw. 76, und .NET Core 3.1 erkennt nur ältere Hauptversionen. Debian 12 liefert außerdem OpenSSL 3, was zu einem zweiten Fehler führt:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` ist Debian 11, das beide Versionen bereitstellt, die die mitgelieferte Runtime erwartet:

| Paket | Version auf Debian 11 | Warum es benötigt wird |
|---|---|---|
| `libgdiplus` | 6.0.4 | GDI+-Implementierung, die zum Rendern von Formen, Text und Bildern verwendet wird |
| `libicu67` | 67.1 | Globalisierungsdaten. Neuere Hauptversionen werden von .NET Core 3.1 nicht erkannt |
| `libssl1.1` | 1.1.1w | Kryptografie. Auf Debian 11 vorinstalliert; fehlt bei Debian 12+ |
| `libfontconfig1` | — | Schriftartensuche |

`libssl1.1` ist bereits im Basis‑Image vorhanden, daher muss es nicht in `apt-get install` aufgeführt werden.

Wenn Sie ein neueres Basis‑Image verwenden müssen, setzen Sie `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`, um die ICU‑Anforderung zu umgehen. Dies deaktiviert kulturabhängige Formatierung und löst das OpenSSL‑Problem **nicht**, sodass Debian 11 die einfachere Wahl bleibt.

## **Schriftarten**

Schlanke Images enthalten überhaupt keine Schriftarten. Ohne mindestens eine installierte Schriftart wird Text in PDF-, Bild- und HTML‑Ausgaben als leere Kästchen dargestellt. `fonts-dejavu-core` ist ein kleiner, allgemeiner Ausgangspunkt.

Um das beabsichtigte Erscheinungsbild einer Präsentation zu erhalten, kopieren Sie die verwendeten Schriftarten in das Image und verweisen Sie Aspose.Slides darauf:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Lizenzierung in einem Container**

Bauen Sie die Lizenzdatei nicht in das Image ein – jeder, der das Image zieht, erhält die Lizenz. Binden Sie sie stattdessen zur Laufzeit ein:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Ohne Lizenz läuft die Bibliothek im Evaluierungsmodus, der ein Wasserzeichen hinzufügt und die Anzahl der verarbeiteten Folien einschränkt. Siehe [Licensing](/slides/de/python-net/licensing/) für Details.

## **Speicher**

Das Rendern zu PDF oder Bildern verbraucht mehr Speicher als das Lesen einer Datei. Container mit engen Speicherlimits können vom OOM‑Killer mitten während einer Konvertierung beendet werden, was sich meist dadurch äußert, dass der Prozess ohne Python‑Traceback verschwindet. Wenn das passiert, erhöhen Sie das Speicherlimit des Containers, bevor Sie den Code untersuchen.