---
title: Installation
type: docs
weight: 70
url: /sv/python-net/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- macOS
- Python
description: "Lär dig hur du snabbt installerar Aspose.Slides för Python via .NET. Steg-för-steg-guide, systemkrav och kodexempel - börja arbeta med PowerPoint-presentationer idag!"
---
## **Översikt**

Aspose.Slides for Python via .NET-paketet levereras med alla nödvändiga .NET‑bibliotek inbakade, vilket innebär att du inte behöver installera .NET separat. Detta förenklar installationsprocessen och gör att utvecklare kan börja arbeta med presentationer direkt. Det är dock viktigt att notera att du, beroende på ditt operativsystem eller din miljö, fortfarande kan behöva installera vissa plattforms‑specifika beroenden som krävs av .NET. Dessutom måste vissa systemkrav uppfyllas för att säkerställa full kompatibilitet och korrekt funktion av paketet.

## **Windows**

**Systemkrav**

Kontrollera och bekräfta att din maskins specifikationer uppfyller eller överstiger [systemkraven](/slides/sv/python-net/system-requirements/).

### **Installera Aspose.Slides**

`pip` är det enklaste sättet att ladda ner och installera [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) på Windows.

För att installera Aspose.Slides, kör följande kommando:

```sh
pip install aspose-slides
```

**Använd Aspose.Slides**

Testa din Aspose.Slides‑installation genom att köra följande kod för att skapa en PowerPoint‑presentation:

```python
# Importera Aspose.Slides för Python via .NET-modulen.
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Systemkrav**

Kontrollera och bekräfta att din maskins specifikationer uppfyller eller överstiger [systemkraven](/slides/sv/python-net/system-requirements/).

### **Förutsättningar**

**Python med delade bibliotek**

Det finns flera sätt att installera Python på macOS, men vi rekommenderar starkt att använda [pyenv-verktyget](https://github.com/pyenv/pyenv#homebrew-in-macos).

Efter att ha installerat och konfigurerat **pyenv**, installera Python med delade bibliotek genom att köra följande kommandon i Terminal‑appen:

1. Installera Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Ställ in den som den globala Python‑versionen:

```sh
pyenv global 3.9.13
```

3. Ställ in den som den skal‑specifika Python‑versionen:

```sh
pyenv shell 3.9.13
```

4. Skapa en symbolisk länk för libpython‑biblioteket i en systembiblioteks‑katalog:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Obs: Python 3.5 eller högre krävs. Version 3.9.13 används här endast som exempel.

**Installera libgdiplus‑biblioteket**

Biblioteket **libgdiplus** är en Windows GDI+‑implementation för macOS och Linux som .NET förlitar sig på för grafisk funktionalitet på dessa plattformar.  
För att installera detta bibliotek på macOS, kör följande kommando:

```sh
brew install mono-libgdiplus
```

### **Installera Aspose.Slides**

`pip` är det enklaste sättet att ladda ner och installera [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) på macOS.

För att installera Aspose.Slides, kör följande kommando:

```sh
pip install aspose-slides
```

**Använd Aspose.Slides**

Testa din Aspose.Slides‑installation genom att köra följande kod för att skapa en PowerPoint‑presentation:

```python
# Importera Aspose.Slides för Python via .NET-modulen.
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag installera Aspose.Slides i en virtuell miljö?**

Ja, du kan installera det i vilken Python‑virtuell miljö som helst med `pip`. Se bara till att miljön har åtkomst till de nödvändiga inhemska beroendena beroende på ditt OS.

**Kan jag använda Aspose.Slides i Docker‑behållare?**

Ja, men du måste försäkra dig om att din Docker‑image innehåller de nödvändiga inhemska biblioteken (**libgdiplus**, typsnittspaket, etc.) och rätt version av Python.

**Finns det en gratis version eller provbegränsning?**

Ja, som standard kör Aspose.Slides i utvärderingsläge, vilket placerar vattenstämplar och kan ha andra begränsningar. För att ta bort restriktionerna måste du tillämpa en giltig [licens](/slides/sv/python-net/licensing/).