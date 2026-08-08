---
title: Hur du kör Aspose.Slides i Docker
linktitle: Aspose.Slides i Docker
type: docs
weight: 150
url: /sv/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides i Docker
- Docker-behållare
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Kör Aspose.Slides för Python via .NET i Docker: en fungerande Dockerfile, de inhemska bibliotek som paketet behöver, teckensnittskonfiguration och licensiering i en behållare."
---
## **Översikt**

Aspose.Slides for Python via .NET körs i Linux-containrar, men paketet är ett Python‑wrapper runt en medföljande .NET Core 3.1‑runtime. Den runtime:n kräver tre inhemska bibliotek som de slimmade Python‑bilderna inte levereras med, och den är noga med deras versioner. Denna artikel ger en Dockerfile som fungerar, förklarar varför varje beroende finns och visar hur man lägger till teckensnitt och en licens.

## **En fungerande Dockerfile**

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

Build and run:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Varför basavbilden är Debian 11**

`aspose.slides`‑hjulet paketerar en **.NET Core 3.1**‑runtime, och den runtime:n föregår de biblioteksversioner som levereras med nuvarande Debian‑utgåvor. På Debian 12 och 13 byggs containern framgångsrikt men misslyckas sedan vid det första anropet `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Meddelandet är missvisande — ICU *är* installerat på dessa bilder, men det är ICU 72 eller 76, och .NET Core 3.1 känner bara igen äldre huvudversioner. Debian 12 levererar dessutom OpenSSL 3, vilket ger ett andra fel:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` är Debian 11, som tillhandahåller båda versionerna som den medförda runtime:n förväntar sig:

| Paket | Version på Debian 11 | Varför det behövs |
|---|---|---|
| `libgdiplus` | 6.0.4 | GDI+-implementation som används för rendering av former, text och bilder |
| `libicu67` | 67.1 | Globaliseringsdata. Nyare huvudversioner känns inte igen av .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Kryptografi. Förinstallerat på Debian 11; saknas på Debian 12+ |
| `libfontconfig1` | — | Upptäckt av teckensnitt |

`libssl1.1` finns redan i basavbilden, så den behöver inte listas i `apt-get install`.

Om du måste använda en nyare basavbild, sätt `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` för att kringgå ICU‑kravet. Detta inaktiverar kulturspecifik formatering och löser **inte** OpenSSL‑problemet, så Debian 11 förblir det enklare valet.

## **Teckensnitt**

Slimma bilder innehåller inga teckensnitt alls. Utan minst ett installerat teckensnitt renderas text som tomma rutor i PDF-, bild- och HTML‑utdata. `fonts-dejavu-core` är en liten allmän startpunkt.

För att matcha en presentationens avsedda utseende, kopiera teckensnitten den använder till avbilden och peka Aspose.Slides på dem:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licensiering i en container**

Bygg inte licensfilen i avbilden — vem som helst som drar avbilden får licensen. Montera den istället vid körning:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Utan licens körs biblioteket i evalueringsläge, vilket lägger till ett vattenstämpel och begränsar antalet bearbetade bilder. Se [Licensiering](/slides/sv/python-net/licensing/) för detaljer.

## **Minne**

Renderning till PDF eller bilder kräver mer minne än att läsa en fil. Containrar med strikta minnesgränser kan avslutas av OOM‑killern mitt i en konvertering, vilket vanligtvis visar sig som att processen försvinner utan någon Python‑stackspårning. Om det händer, höj containerns minnesgräns innan du undersöker koden.