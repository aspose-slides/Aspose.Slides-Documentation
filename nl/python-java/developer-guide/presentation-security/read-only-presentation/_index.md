---
title: Presentaties opslaan in alleen-lezen modus met Python
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/python-java/read-only-presentation/
keywords:
- alleen lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Laad en sla PowerPoint‑bestanden (PPT, PPTX) op in alleen‑lezen modus met Aspose.Slides for Python via Java, en bied precieze dia‑previews zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beveiligen. U wilt deze Read-Only‑instelling misschien gebruiken om een presentatie te beschermen wanneer:

- U wilt per ongeluk bewerken voorkomen en de inhoud van uw presentatie veilig houden. 
- U wilt mensen waarschuwen dat de door u geleverde presentatie de definitieve versie is. 

Nadat u de optie **Always Open Read-Only** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de **Read-Only**‑aanbeveling en mogelijk de volgende boodschap: *Om per ongeluk wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen‑lezen te openen.*

De Read-Only‑aanbeveling is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt, omdat gebruikers een stap moeten uitvoeren om deze te verwijderen voordat ze een presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een hoffelijke manier wilt communiceren, kan de Read-Only‑aanbeveling een goede optie voor u zijn. 

> Als een presentatie met de **Read-Only**‑beveiliging wordt geopend in een oudere Microsoft PowerPoint‑applicatie — die de recent geïntroduceerde functie niet ondersteunt — wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read-Only-modus toepassen**

Aspose.Slides for Python via Java stelt u in staat om een presentatie op **Read-Only** in te stellen, wat betekent dat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe u een presentatie op **Read-Only** zet in Python met behulp van Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}} 

De **Read-Only**‑aanbeveling is bedoeld om bewerken te ontmoedigen of gebruikers te weerhouden van per ongeluk wijzigingen aan te brengen in een PowerPoint‑presentatie. Als een gemotiveerde persoon — die weet wat hij doet — besluit uw presentatie te bewerken, kan hij de Read-Only‑instelling gemakkelijk verwijderen. Als u echt ongeoorloofd bewerken moet voorkomen, kunt u beter gebruikmaken van [more stringent protections that involve encryption and passwords](/slides/nl/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Veelgestelde vragen**

**Hoe verschilt 'Read-Only recommended' van volledige wachtwoordbeveiliging?**  
'Read-Only recommended' toont alleen een suggestie om het bestand in alleen‑lezen modus te openen en is gemakkelijk te omzeilen. [Password protection](/slides/nl/python-java/password-protected-presentation/) beperkt daadwerkelijke opening of bewerking en is geschikt wanneer u echte beveiligingscontroles nodig heeft.

**Kan 'Read-Only recommended' gecombineerd worden met watermerken om bewerkingen verder te ontmoedigen?**  
Ja. De aanbeveling kan gecombineerd worden met [watermarks](/slides/nl/python-java/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**  
Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om geautomatiseerde bewerkingen te voorkomen, gebruikt u [passwords and encryption](/slides/nl/python-java/password-protected-presentation/).

**Hoe verhoudt 'Read-Only recommended' zich tot de methoden [isEncrypted](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isEncrypted) en [isWriteProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
Het zijn verschillende signalen. 'Read-Only recommended' is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isWriteProtected) en [isEncrypted](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isEncrypted) duiden op daadwerkelijke schrijf‑ of leesbeperkingen die afhangen van wachtwoorden of encryptie.