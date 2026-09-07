---
title: ODP naar PPTX converteren in Python
linktitle: ODP naar PPTX
type: docs
weight: 10
url: /nl/python-java/convert-odp-to-pptx/
keywords:
- OpenDocument converteren
- presentatie converteren
- dia converteren
- ODP converteren
- OpenDocument naar PPTX
- ODP naar PPTX
- ODP opslaan als PPTX
- ODP exporteren naar PPTX
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: ODP-presentaties converteren naar PPTX met Aspose.Slides voor Python via Java. Gebruik een volledig Python-voorbeeld zonder PowerPoint of LibreOffice te installeren.
---
## **Overzicht**

Dit artikel legt uit hoe u een OpenDocument (ODP)-presentatie naar PowerPoint (PPTX)-formaat kunt converteren met Aspose.Slides voor Python via Java.

## **ODP naar PPTX converteren**

De [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse kan een ODP‑bestand rechtstreeks laden. Sla de geladen presentatie op in PPTX‑formaat met behulp van [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/).

Volg de [installatie‑instructies](/slides/nl/python-java/installation/) voordat u het voorbeeld uitvoert. Plaats een ODP‑presentatie met de naam `AccessOpenDoc.odp` in de werkmap. De volgende code start de JVM indien nodig, opent het ODP‑bestand en slaat het op als `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Sla de ODP-presentatie op in PPTX-formaat.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live‑voorbeeld**

Probeer de webapp [Aspose.Slides Conversion](https://products.aspose.app/slides/nl/conversion/) om de ODP‑naar‑PPTX-conversie aangedreven door Aspose.Slides te zien.

## **FAQ**

**Moet ik Microsoft PowerPoint of LibreOffice installeren om ODP naar PPTX te converteren?**

Nee. Aspose.Slides voor Python via Java kan presentatie‑bestanden lezen en schrijven zonder een van beide toepassingen. U hebt alleen het Python‑pakket en een compatibele Java‑runtime nodig.

**Worden master‑dia's, lay‑outs en thema’s bewaard tijdens de conversie?**

Aspose.Slides zet de structuur en opmaak van de bronpresentatie om naar PPTX. ODP‑ en PPTX‑formaten ondersteunen echter verschillende functies, waardoor sommige elementen er na de conversie anders uit kunnen zien. Zorg dat de benodigde lettertypen beschikbaar zijn en controleer presentaties met complexe opmaak. Zie [OpenDocument conversion](/slides/nl/python-java/convert-openoffice-odp/) voor compatibiliteits‑overwegingen.

**Kan ik wachtwoord‑beveiligde ODP‑bestanden converteren?**

Ja, wanneer u het wachtwoord opgeeft dat nodig is om het bestand te openen. Zie [password-protected presentations](/slides/nl/python-java/password-protected-presentation/) voor details over het laden van beveiligde bestanden voordat ze in een ander formaat worden opgeslagen.

**Is Aspose.Slides geschikt voor cloud‑ of REST‑gebaseerde conversiediensten?**

Ja. U kunt Aspose.Slides voor Python via Java in uw back‑end gebruiken met de vereiste Java‑runtime. Voor een REST‑API, zie [Aspose.Slides Cloud](https://products.aspose.cloud/slides/nl/family/).