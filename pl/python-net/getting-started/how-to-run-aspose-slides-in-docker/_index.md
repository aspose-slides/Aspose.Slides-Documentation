---
title: Jak uruchomić Aspose.Slides w Dockerze
linktitle: Aspose.Slides w Dockerze
type: docs
weight: 150
url: /pl/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides w Dockerze
- kontener Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Uruchom Aspose.Slides for Python via .NET w Dockerze: działający Dockerfile, natywne biblioteki wymagane przez pakiet, konfiguracja czcionek oraz licencjonowanie w kontenerze."
---
## **Przegląd**

Aspose.Slides for Python via .NET działa w kontenerach Linux, ale pakiet jest nakładką Pythona na dołączony runtime .NET Core 3.1. Ten runtime wymaga trzech natywnych bibliotek, których slim obrazy Pythona nie zawierają, i jest wymagający co do ich wersji. Ten artykuł zawiera działający Dockerfile, wyjaśnia, dlaczego każda zależność jest potrzebna, oraz pokazuje, jak dodać czcionki i licencję.

## **Działający Dockerfile**

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

Budowanie i uruchamianie:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Dlaczego obraz bazowy to Debian 11**

`aspose.slides` wheel zawiera runtime **.NET Core 3.1**, a ten runtime jest starszy niż wersje bibliotek dostarczane w aktualnych wydaniach Debiana. Na Debianie 12 i 13 kontener buduje się pomyślnie, ale następnie zawodzi przy pierwszym wywołaniu `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Komunikat jest mylący — ICU *jest* zainstalowane w tych obrazach, ale jest to ICU 72 lub 76, a .NET Core 3.1 rozpoznaje tylko starsze wersje główne. Debian 12 dodatkowo dostarcza OpenSSL 3, co powoduje drugi błąd:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` to Debian 11, który dostarcza oba wersje oczekiwane przez dołączony runtime:

| Pakiet | Wersja w Debianie 11 | Dlaczego jest potrzebny |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementacja GDI+ używana do renderowania kształtów, tekstu i obrazów |
| `libicu67` | 67.1 | Dane globalizacyjne. Nowsze wersje główne nie są rozpoznawane przez .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Kryptografia. Preinstalowane w Debianie 11; nieobecne w Debianie 12+ |
| `libfontconfig1` | — | Wykrywanie czcionek |

`libssl1.1` jest już obecny w obrazie bazowym, więc nie trzeba go wymieniać w `apt-get install`.

Jeśli musisz używać nowszego obrazu bazowego, ustaw `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`, aby pominąć wymóg ICU. Wyłącza to formatowanie zależne od kultury i **nie** rozwiązuje problemu z OpenSSL, dlatego Debian 11 pozostaje prostszym wyborem.

## **Czcionki**

Obrazy typu slim nie zawierają żadnych czcionek. Bez przynajmniej jednej zainstalowanej czcionki tekst renderuje się jako puste pola w wyjściach PDF, obrazu i HTML. `fonts-dejavu-core` to mały, uniwersalny punkt wyjścia.

Aby dopasować wygląd prezentacji do zamierzonego, skopiuj używane przez nią czcionki do obrazu i wskaż je Aspose.Slides:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licencjonowanie w kontenerze**

Nie wbudowuj pliku licencji w obraz — każdy, kto pobierze obraz, otrzyma licencję. Zamontuj go w czasie uruchomienia:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Bez licencji biblioteka działa w trybie ewaluacyjnym, co dodaje znak wodny i ogranicza liczbę przetwarzanych slajdów. Zobacz [Licensing](/slides/pl/python-net/licensing/) po szczegóły.

## **Pamięć**

Renderowanie do PDF lub obrazów wymaga więcej pamięci niż odczyt pliku. Kontenery z ograniczonym przydziałem pamięci mogą zostać zakończone przez OOM killera w trakcie konwersji, co zazwyczaj objawia się zniknięciem procesu bez śladu błędu w Pythonie. Jeśli tak się stanie, zwiększ limit pamięci kontenera przed analizą kodu.