---
title: Installation
type: docs
weight: 70
url: /sv/python-java/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- installation av Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installera Aspose.Slides för Python via Java på Windows, Linux eller macOS, konfigurera Java och JPype och verifiera installationen med ett fungerande exempel."
---
Aspose.Slides för Python via Java körs på Windows, Linux och macOS. Det använder JPype för att få åtkomst till Java-biblioteket från Python. Microsoft PowerPoint krävs inte.

## **Förutsättningar**

Innan du installerar Python-paketen, installera Python och en JDK som uppfyller [System Requirements](/slides/sv/python-java/system-requirements/). Den sidan listar kompatibla versioner, arkitekturkrav och eventuella beroenden som behövs för att bygga JPype från källkod.

Ställ in `JAVA_HOME` till JDK‑installationskatalogen, inte dess `bin`‑undermapp, och lägg till JDK:s `bin`‑katalog i `PATH`. Öppna en ny terminal efter att du ändrat miljövariablerna.

## **Installera från PyPI**

Kör följande kommandon i en terminal, inte i Pythons interaktiva prompt. Skapa en projektkatalog och en virtuell miljö för att hålla paketen separerade från andra projekt.

### **Windows**

När din valda Python‑tolk är tillgänglig som `python` i `PATH`, kör följande kommandon i Kommandotolken:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux och macOS**

När din valda Python‑version är tillgänglig som `python3`, kör följande kommandon i Bash eller zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

På Debian eller Ubuntu, om skapandet av miljön misslyckas eftersom `ensurepip` inte är tillgängligt, installera paketet `python3-venv` med `sudo apt-get install python3-venv` och upprepa sedan kommandot för att skapa miljön. En separat installerad Python‑version kan behöva motsvarande versionsspecifika `venv`‑paket.

### **Installera paketen**

När den virtuella miljön är aktiv, installera JPype och Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Genom att använda `python -m pip` säkerställer du att paketen installeras för den tolk som används för att köra din applikation.

För att uppdatera en befintlig Aspose.Slides‑installation, kör `python -m pip install --upgrade aspose-slides-java` i samma miljö.

## **Installera från ett ZIP‑arkiv**

Du kan också använda biblioteket från [Aspose.Slides nedladdningssida](https://releases.aspose.com/slides/python-java/):

1. Installera Python och Java enligt [Förutsättningar](#prerequisites).
2. Skapa och aktivera en virtuell miljö med hjälp av instruktionerna ovan.
3. Installera JPype med `python -m pip install JPype1`.
4. Ladda ner och extrahera Aspose.Slides för Python via Java ZIP‑arkivet.
5. Hitta den extraherade `asposeslides`‑paketkatalogen. Behåll dess innehåll, inklusive `lib`‑katalogen och JAR‑filen, tillsammans.
6. Placera `example.py` från nästa avsnitt bredvid `asposeslides`‑katalogen så att Python kan importera paketet. Arkivet har redan sin egen `example.py` bredvid `asposeslides`; ersätt den med den nedanstående.

## **Verifiera installationen**

Spara följande kod som `example.py`. Den skapar en presentation med en textruta och sparar den som `out.pptx` i den aktuella arbetskatalogen.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

När den virtuella miljön är aktiv, kör exemplet från katalogen som innehåller `example.py`:

```sh
python example.py
```

`asposeslides`‑importen registrerar det medföljande Java‑biblioteket innan JVM startas. Importera `asposeslides.api` efter att JVM har startat, och frigör presentationsresurser innan den stängs av.

{{% alert color="info" title="Note" %}}
Utan en licens innehåller utskriften ett utvärderingsvattenmärke. Se [Evaluate Aspose.Slides](/slides/sv/python-java/evaluate-aspose-slides/) för begränsningar i utvärderingen och information om temporär licens.
{{% /alert %}}

## **FAQ**

**Varför rapporterar Python att JVM inte kan hittas eller laddas?**

Kontrollera att `JAVA_HOME` pekar på en JDK som är kompatibel med din Python‑ och JPype‑installation, enligt [System Requirements](/slides/sv/python-java/system-requirements/). Se [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) för ytterligare kontroller.

**Varför rapporterar Python att `asposeslides` saknas efter installation?**

Paketet kan ha installerats för en annan Python‑tolk. Aktivera den virtuella miljö som användes för installationen och kör `python -m pip show aspose-slides-java`. För en ZIP‑installation, säkerställ att `asposeslides`‑katalogen ligger bredvid ditt skript eller annars är tillgänglig på Pythons modulsökväg.

**Kan jag köra exemplet upprepade gånger i en notebook?**

Exemplet är avsett för en fristående Python‑process. Innan du anpassar det för upprepad körning i en notebook, se [Limitations and API Differences](/slides/sv/python-java/limitations-and-api-differences/#import-the-library) för information om JVM‑livscykel och notebook‑vägledning.

**Varför misslyckas pip med `CERTIFICATE_VERIFY_FAILED`?**

Om ditt nätverk använder en HTTPS‑inspektionsproxy måste pip lita på dess certifikatutfärdare. Konfigurera det betrodda CA‑paketet med pip‑alternativet `--cert` eller miljövariabeln `PIP_CERT`, enligt [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Den erforderliga konfigurationen beror på ditt nätverk och pip‑version.