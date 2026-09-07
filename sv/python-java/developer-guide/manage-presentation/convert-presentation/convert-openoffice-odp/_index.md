---
title: Konvertera OpenDocument-presentationer i Python
linktitle: Konvertera OpenDocument
type: docs
weight: 10
url: /sv/python-java/convert-openoffice-odp/
keywords:
- konvertera ODP
- ODP till PDF
- ODP till HTML
- ODP till TIFF
- ODP till PPT
- ODP till PPTX
- ODP till XPS
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Konvertera OpenDocument (ODP)-presentationer till PDF, HTML och andra format med Aspose.Slides för Python via Java, utan att installera OpenOffice eller LibreOffice."
---
## **Introduktion**

Aspose.Slides for Python via Java låter dig konvertera OpenDocument (ODP)-presentationer till format som PDF, HTML, TIFF, XPS, PPT och PPTX. ODP‑konvertering använder samma API som PowerPoint‑konvertering: ladda källfilen med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och välj output‑formatet med [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/).

## **Konvertera ODP till PDF**

Följ [installationsinstruktionerna](/slides/sv/python-java/installation/) innan du kör exemplet. Placera en ODP-presentation med namnet `pres.odp` i arbetskatalogen. Följande kod startar JVM om det behövs, laddar presentationen och sparar den som `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **OpenDocument-presentation i olika program**

En ODP-presentation kan se annorlunda ut i PowerPoint och LibreOffice/OpenOffice Impress eftersom dessa program stödjer olika presentationsfunktioner och renderingsbeteenden. Granska konverterade presentationer när deras layout beror på komplex formatering.

Kompatibilitetsskillnader kan påverka:

- Tabeller, inklusive deras staplingsordning i förhållande till andra former och stöd för bildfyllningar.
- Textrotation och justering.
- Bild‑, gradient‑ och mönsterfyllningar som appliceras på text.
- Numrerade och punktlistor.

Bilden nedan visar en lista skapad i LibreOffice Impress:

![ODP-listexempel i LibreOffice Impress](odp-list-example.png)

Aspose.Slides sparar ODP-listor för kompatibilitet med LibreOffice/OpenOffice Impress.

För detaljer om funktionskompatibilitet, se [Microsofts guide till OpenDocument Presentation-formatet](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Vad händer om formateringen av min ODP‑fil ändras efter konvertering?**

ODP och PowerPoint använder olika presentationsmodeller. Tabeller, teckensnitt och fyllningsstilar kan renderas olika. Kontrollera att nödvändiga teckensnitt finns tillgängliga, granska resultatet och justera layout eller formatering om det behövs.

**Behöver jag ha OpenOffice eller LibreOffice installerat för att konvertera ODP‑filer?**

Nej. Aspose.Slides för Python via Java bearbetar presentationer utan någon av dessa program. En kompatibel Java‑runtime och Python‑paketet krävs.

**Kan jag anpassa PDF‑utdata när jag konverterar en ODP‑presentation?**

Ja. Använd [PdfOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/) för att konfigurera PDF‑exportinställningar, såsom bildkvalitet och komprimering.

**Kan jag konvertera ODP‑presentationer på en server eller i en container?**

Ja. Installera Python‑paketet, en kompatibel Java‑runtime och de teckensnitt som dina presentationer kräver i målmiljön. Ingen kontorsapplikation behövs.