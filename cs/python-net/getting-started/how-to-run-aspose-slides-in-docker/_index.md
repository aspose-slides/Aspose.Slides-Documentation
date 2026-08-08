---
title: Jak spustit Aspose.Slides v Dockeru
linktitle: Aspose.Slides v Dockeru
type: docs
weight: 150
url: /cs/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides v Dockeru
- Docker kontejner
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spusťte Aspose.Slides pro Python přes .NET v Dockeru: funkční Dockerfile, nativní knihovny, které balíček vyžaduje, nastavení písem a licencování uvnitř kontejneru."
---
## **Přehled**

Aspose.Slides pro Python pomocí .NET běží v Linuxových kontejnerech, ale balíček je Pythonovým obalem kolem zabaleného runtime .NET Core 3.1. Tento runtime vyžaduje tři nativní knihovny, které nechybí v úzkých (slim) Pythonových obrazech, a je citlivý na jejich verze. Tento článek poskytuje funkční Dockerfile, vysvětluje, proč je každá závislost potřebná, a ukazuje, jak přidat písma a licenci.

## **Funkční Dockerfile**

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

Sestavte a spusťte:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Proč je základní obraz Debian 11**

Kolečko (wheel) `aspose.slides` obsahuje runtime **.NET Core 3.1**, který je starší než verze knihoven dodávané v aktuálních vydáních Debianu. V Debianu 12 a 13 kontejner úspěšně sestaví, ale selže při prvním volání `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Zpráva je zavádějící — ICU *je* na těchto obrazech nainstalováno, ale jde o verzi ICU 72 nebo 76 a .NET Core 3.1 rozpoznává jen starší hlavní verze. Debian 12 také obsahuje OpenSSL 3, což způsobí druhé selhání:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` je Debian 11, který poskytuje oba verze, které zabalený runtime očekává:

| Balíček | Verze v Debianu 11 | Proč je potřeba |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementace GDI+ používaná pro vykreslování tvarů, textu a obrázků |
| `libicu67` | 67.1 | Data globalizace. Novější hlavní verze nejsou rozpoznány .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Kryptografie. Předinstalováno v Debianu 11; chybí v Debianu 12+ |
| `libfontconfig1` | — | Vyhledávání písem |

`libssl1.1` je již v základním obrazu přítomen, takže nemusí být uveden v `apt-get install`.

Pokud musíte použít novější základní obraz, nastavte `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`, abyste obešli požadavek na ICU. Tím se zakáže formátování specifické pro kulturu a **ne**vyřeší to problém s OpenSSL, takže Debian 11 zůstává jednodušší volbou.

## **Písma**

Úzké (slim) obrazy neobsahují žádná písma. Bez alespoň jednoho nainstalovaného písma se text v PDF, obrázku a HTML výstupu vykresluje jako prázdné rámečky. `fonts-dejavu-core` je malý obecný výchozí balíček.

Aby vzhled prezentace odpovídal zamýšlenému, zkopírujte písma, která používá, do obrazu a nasměrujte na ně Aspose.Slides:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licencování uvnitř kontejneru**

Nevkládejte licenční soubor do obrazu — kdokoliv, kdo obraz stáhne, získá licenci. Namísto toho ji připojte v době běhu:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Bez licence knihovna běží v evaluačním režimu, který přidává vodoznak a omezuje počet zpracovaných snímků. Podrobnosti najdete v [Licensing](/slides/cs/python-net/licensing/).

## **Paměť**

Vykreslování do PDF nebo obrázků spotřebovává více paměti než čtení souboru. Kontajnery s úzkými limity paměti mohou být během konverze ukončeny OOM killerem, což se obvykle projeví jako zmizení procesu bez Pythonového stack trace. Pokud se to stane, zvýšte limit paměti kontejneru, než začnete zkoumat kód.