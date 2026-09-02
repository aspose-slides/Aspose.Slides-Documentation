---
title: Hogyan futtassuk az Aspose.Slides-t Dockerben
linktitle: Aspose.Slides Dockerben
type: docs
weight: 150
url: /hu/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides Dockerben
- Docker konténer
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- betűtípusok
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET futtatása Dockerben: egy működő Dockerfile, a csomag által igényelt natív könyvtárak, betűtípus beállítás és licencelés egy konténeren belül."
---
## **Áttekintés**

Aspose.Slides for Python via .NET Linux konténerekben fut, de a csomag egy Python burkoló a csomagolt .NET Core 3.1 futtatókörnyezet köré. Ennek a futtatókörnyezetnek három natív könyvtárra van szüksége, amelyeket a karcsú Python képek nem szállítanak, és verzióra vonatkozóan is szigorú. Ez a cikk egy Dockerfile‑t ad, amely működik, elmagyarázza, miért van minden függőség, és megmutatja, hogyan lehet betűtípusokat és licencet hozzáadni.

## **Egy működő Dockerfile**

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

## **Miért a báziskép Debian 11**

A `aspose.slides` kerék **.NET Core 3.1** futtatókörnyezetet tartalmaz, amely régebbi, mint a jelenlegi Debian kiadások által szállított könyvtárverziók. Debian 12‑n és 13‑on a konténer sikeresen felépül, de az első `Presentation()` hívásnál hibázik:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Az üzenet félrevezető — az ICU telepítve van ezekben a képekben, de ICU 72 vagy 76 van, míg a .NET Core 3.1 csak a régebbi főverziókat ismeri fel. A Debian 12 továbbá OpenSSL 3‑at szállít, ami egy második hibához vezet:

```
No usable version of libssl was found
```

A `python:3.11-slim-bullseye` Debian 11, amely mindkét verziót tartalmazza, amit a csomagolt futtatókörnyezet elvár:

| Csomag | Verzió a Debian 11-en | Miért szükséges |
|---|---|---|
| `libgdiplus` | 6.0.4 | GDI+ megvalósítás a formák, szöveg és képek rendereléséhez |
| `libicu67` | 67.1 | Nemzetköziesítési adatok. Az újabb főverziókat a .NET Core 3.1 nem ismeri fel |
| `libssl1.1` | 1.1.1w | Kriptográfia. Előre telepítve a Debian 11-en; hiányzik a Debian 12+-tól |
| `libfontconfig1` | — | Betűtípus-felfedezés |

`libssl1.1` már jelen van a bázisképen, ezért nem kell szerepeltetni az `apt-get install` listában.

Ha újabb bázisképet kell használni, állítsd be a `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` változót az ICU követelmény megkerüléséhez. Ez letiltja a kultúraspecifikus formázást, és **nem** oldja meg az OpenSSL problémát, így a Debian 11 marad a egyszerűbb választás.

## **Betűtípusok**

A karcsú képek egyáltalán nem tartalmaznak betűtípusokat. Ha legalább egy betűtípus sincs telepítve, a szöveg PDF‑ben, képekben és HTML‑ben üres négyzetként jelenik meg. A `fonts-dejavu-core` egy kis általános célú kiindulási pont.

A prezentáció kívánt megjelenésének megfelelően másold be a használt betűtípusokat a képre, és irányítsd rájuk az Aspose.Slides‑t:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licencelés egy konténeren belül**

Ne építsd be a licencfájlt a képre — akárki, aki lehúzza a képet, megkapja a licencet. Csatold fel futtatáskor:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Licenc nélkül a könyvtár értékelő módban fut, amely vízjelet ad és korlátozza a feldolgozott diák számát. Részletekért lásd a [Licensing](/slides/hu/python-net/licensing/) oldalt.

## **Memória**

A PDF‑ vagy képrenderelés több memóriát igényel, mint a fájl beolvasása. A szoros memóriahatárral rendelkező konténereket az OOM killer leállíthatja egy konverzió közepén, ami általában úgy jelenik meg, hogy a folyamat eltűnik Python‑nyomkövetés nélkül. Ha ez történik, növeld a konténer memóriahatárát, mielőtt a kódban keresnél további problémákat.