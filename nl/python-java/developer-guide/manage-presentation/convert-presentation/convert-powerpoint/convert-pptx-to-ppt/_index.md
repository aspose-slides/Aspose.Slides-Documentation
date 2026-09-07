---
title: Converteer PPTX naar PPT in Python
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPTX converteren
- PPTX naar PPT
- PPTX opslaan als PPT
- PPTX exporteren naar PPT
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Converteer PPTX naar het legacy PPT-formaat in Python met Aspose.Slides for Python via Java. Bevat een codevoorbeeld en aantekeningen over compatibiliteit en beveiligde bestanden."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat om een PPTX‑presentatie te converteren naar het verouderde PPT‑formaat dat wordt gebruikt door PowerPoint 97–2003, zonder dat Microsoft PowerPoint geïnstalleerd is. Laad het PPTX‑bestand en sla het op met het PPT‑uitvoerformaat, zoals hieronder weergegeven.

## **Converteer PPTX naar PPT**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)-klasse, roep vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) aan met het uitvoerpad en [SaveFormat.Ppt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Ppt).

Het volgende voorbeeld start de Java‑virtual machine indien nodig en converteert `template.pptx` naar `output.ppt` met de standaardopties. Vervang de paden door uw eigen bestandsnamen. Het `finally`‑blok geeft de presentatieresources vrij, zelfs als het opslaan mislukt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Laad de PPTX-presentatie.
presentation = Presentation("template.pptx")
try:
    # Sla de presentatie op in PPT-formaat.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Het argument [SaveFormat.Ppt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Ppt) selecteert het uitvoerformaat; alleen de bestandsextensie wijzigen zet een presentatie niet om. Bewaar het originele PPTX‑bestand zodat u ernaar kunt terugkeren als een nieuwere functie geen equivalent heeft in PPT.

## **Converteer PPTX naar andere formaten**

Aspose.Slides ondersteunt ook andere uitvoerformaten. Zie de bijbehorende artikelen voor formaat‑specifieke opties en voorbeelden:

- [Converteer PowerPoint naar PDF in Python](/slides/nl/python-java/convert-powerpoint-to-pdf/)
- [Converteer PowerPoint naar XPS in Python](/slides/nl/python-java/convert-powerpoint-to-xps/)
- [Converteer PowerPoint naar HTML in Python](/slides/nl/python-java/convert-powerpoint-to-html/)
- [Sla presentaties op als ODP in Python](/slides/nl/python-java/save-presentation/)
- [Converteer PowerPoint naar PNG in Python](/slides/nl/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Blijven alle PPTX‑effecten en -functies behouden bij conversie naar PPT?**

Niet altijd. Het verouderde PPT‑formaat ondersteunt niet elke functie die beschikbaar is in PPTX. Sommige effecten, objecten of gedragingen kunnen worden vereenvoudigd of anders worden weergegeven. Controleer de geconverteerde presentatie in de beoogde viewer, vooral wanneer deze nieuwere PowerPoint‑functies bevat.

**Kan ik alleen geselecteerde dia's naar PPT converteren?**

Opslaan naar PPT schrijft de volledige presentatie. Om alleen geselecteerde dia's te converteren, maakt u een nieuwe presentatie, verwijdert u de initiële lege dia, kloont u de benodigde dia's erin, en slaat u deze op als PPT. Zie [Kloon dia's in Python](/slides/nl/python-java/clone-slides/).

**Kan ik een met wachtwoord beveiligd PPTX‑bestand converteren?**

Ja, als u het correcte wachtwoord opgeeft bij het laden van de bronpresentatie. U kunt ook bescherming configureren voor het uitvoerbestand. Zie [Wachtwoordbeveiligde presentaties](/slides/nl/python-java/password-protected-presentation/).