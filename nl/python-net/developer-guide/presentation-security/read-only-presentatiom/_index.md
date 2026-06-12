---
title: "Presentaties opslaan in alleen-lezen modus met Python"
linktitle: "Alleen-lezen presentatie"
type: docs
weight: 30
url: /nl/python-net/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "PowerPoint-bestanden (PPT, PPTX) laden en opslaan in alleen-lezen modus met Aspose.Slides voor Python via .NET, waardoor nauwkeurige dia-voorbeelden worden aangeboden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Altijd openen als alleen-lezen** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. Je wilt deze alleen-lezen‑instelling wellicht gebruiken om een presentatie te beveiligen wanneer

- Je per ongeluk bewerken wilt voorkomen en de inhoud van je presentatie veilig wilt houden.  
- Je wilt aangeven dat de presentatie die je hebt verstrekt de definitieve versie is.  

Nadat je de optie **Altijd openen als alleen-lezen** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de aanbeveling **Alleen-lezen** en kan er een bericht verschijnen in de volgende vorm: *Om onbedoelde wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te worden geopend.*

De aanbeveling **Alleen-lezen** is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt, omdat gebruikers eerst een handeling moeten uitvoeren om de aanbeveling te verwijderen voordat ze de presentatie mogen bewerken. Als je niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een nette manier wilt communiceren, dan kan de aanbeveling **Alleen-lezen** een goede optie voor je zijn.

> Als een presentatie met **Alleen-lezen**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑applicatie – die de recent geïntroduceerde functie niet ondersteunt – wordt de aanbeveling **Alleen-lezen** genegeerd (de presentatie wordt normaal geopend).

## **Alleen-lezen‑modus toepassen**

Aspose.Slides for Python via .NET stelt je in staat om een presentatie **Alleen-lezen** te maken, waardoor gebruikers (nadat ze de presentatie hebben geopend) de aanbeveling **Alleen-lezen** zien. Deze voorbeeldcode laat zien hoe je een presentatie **Alleen-lezen** maakt in Python met Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Opmerking**: De aanbeveling **Alleen-lezen** is uitsluitend bedoeld om bewerken te ontmoedigen of om gebruikers te weerhouden van onbedoelde wijzigingen in een PowerPoint‑presentatie. Als een gemotiveerd persoon – die weet wat hij doet – besluit je presentatie te bewerken, kan hij de alleen-lezen‑instelling eenvoudig verwijderen. Als je werkelijk ongeautoriseerd bewerken moet voorkomen, kun je beter [striktere beveiligingen die encryptie en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Hoe verschilt ‘Alleen-lezen aanbevolen’ van volledige wachtwoordbeveiliging?**

‘Alleen-lezen aanbevolen’ toont alleen een suggestie om het bestand in alleen-lezen‑modus te openen en is makkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/python-net/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer je echte beveiligingsmaatregelen nodig hebt.

**Kan ‘Alleen-lezen aanbevolen’ worden gecombineerd met watermerken om bewerkingen nog meer te ontmoedigen?**

Ja. De aanbeveling kan worden gecombineerd met [watermerken](/slides/nl/python-net/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om geautomatiseerde bewerkingen te voorkomen, gebruik je [wachtwoorden en encryptie](/slides/nl/python-net/password-protected-presentation/).

**Hoe verhoudt ‘Alleen-lezen aanbevolen’ zich tot de vlaggen ‘is_encrypted’ en ‘is_write_protected’?**

Het zijn verschillende signalen. ‘Alleen-lezen aanbevolen’ is een zachte, optionele prompt; [is_write_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/is_write_protected/) en [is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/is_encrypted/) geven daadwerkelijke schrijf‑ of leesbeperkingen weer die afhankelijk zijn van wachtwoorden of encryptie.