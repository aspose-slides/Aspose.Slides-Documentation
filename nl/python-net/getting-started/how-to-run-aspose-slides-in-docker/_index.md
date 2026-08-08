---
title: Hoe Aspose.Slides in Docker uit te voeren
linktitle: Aspose.Slides in Docker
type: docs
weight: 150
url: /nl/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides in Docker
- Dockercontainer
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- lettertypen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Aspose.Slides voor Python via .NET uitvoeren in Docker: een werkende Dockerfile, de native bibliotheken die het pakket nodig heeft, lettertypeconfiguratie en licenties binnen een container."
---
## **Overzicht**

Aspose.Slides for Python via .NET draait in Linux‑containers, maar het pakket is een Python‑wrapper rond een meegeleverde .NET Core 3.1‑runtime. Die runtime heeft drie native bibliotheken nodig die niet aanwezig zijn in slanke Python‑images, en hij is kieskeurig wat de versies betreft. Dit artikel biedt een werkende Dockerfile, legt uit waarom elke afhankelijkheid nodig is, en toont hoe u lettertypen en een licentie kunt toevoegen.

## **Een werkende Dockerfile**

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

Bouwen en uitvoeren:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Waarom de basis‑image Debian 11 is**

Het `aspose.slides`‑wheel bevat een **.NET Core 3.1**‑runtime, en die runtime is ouder dan de bibliotheekversies die bij de huidige Debian‑releases worden meegeleverd. Op Debian 12 en 13 wordt de container wel succesvol gebouwd, maar mislukt bij de eerste `Presentation()`‑aanroep:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

De melding is misleidend — ICU *is* geïnstalleerd op die images, maar het is ICU 72 of 76, en .NET Core 3.1 herkent alleen oudere major‑versies. Debian 12 levert bovendien OpenSSL 3 mee, wat een tweede fout veroorzaakt:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` is Debian 11, die beide versies levert die de meegeleverde runtime verwacht:

| Pakket | Versie op Debian 11 | Waarom het nodig is |
|---|---|---|
| `libgdiplus` | 6.0.4 | GDI+‑implementatie gebruikt voor het renderen van vormen, tekst en afbeeldingen |
| `libicu67` | 67.1 | Globaliseringsdata. Nieuwere major‑versies worden niet herkend door .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Cryptografie. Voorgeïnstalleerd op Debian 11; afwezig op Debian 12+ |
| `libfontconfig1` | — | Lettertype‑detectie |

`libssl1.1` zit al in de basis‑image, dus hoeft het niet vermeld te worden bij `apt-get install`.

Als u een nieuwer basis‑image moet gebruiken, stel dan `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` in om de ICU‑vereiste te omzeilen. Dit schakelt cultuur‑specifieke opmaak uit en lost het OpenSSL‑probleem **niet** op, dus blijft Debian 11 de eenvoudigere keuze.

## **Lettertypen**

Slanke images bevatten helemaal geen lettertypen. Zonder ten minste één geïnstalleerd lettertype wordt tekst weergegeven als lege vakjes in PDF-, afbeelding‑ en HTML‑output. `fonts-dejavu-core` is een klein, algemeen bruikbaar startpunt.

Om de beoogde weergave van een presentatie te behouden, kopieert u de gebruikte lettertypen naar de image en wijst u Aspose.Slides erop:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licenties binnen een container**

Compileer het licentiebestand niet in de image — iedereen die de image download, krijgt de licentie. Koppel het in plaats daarvan tijdens runtime:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Zonder licentie draait de bibliotheek in evaluatiemodus, waarbij een watermerk wordt toegevoegd en het aantal verwerkte dia's wordt beperkt. Zie [Licensing](/slides/nl/python-net/licensing/) voor details.

## **Geheugen**

Renderen naar PDF of afbeeldingen vergt meer geheugen dan het lezen van een bestand. Containers met strakke geheugenlimieten kunnen halverwege een conversie door de OOM‑killer worden beëindigd, wat zich meestal uit als een verdwijnde process zonder Python‑stacktrace. Als dat gebeurt, verhoog dan de geheugenlimiet van de container voordat u de code onderzoekt.