---
title: Presentaties opslaan in alleen-lezen-modus met C++
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/cpp/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "PowerPoint-bestanden (PPT, PPTX) laden en opslaan in alleen-lezen-modus met Aspose.Slides voor C++, met nauwkeurige dia-voorbeelden zonder uw presentaties te wijzigen."
---
## **Introductie**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. U wilt deze Read-Only‑instelling mogelijk gebruiken om een presentatie te beschermen wanneer

- U wilt per ongeluk bewerken voorkomen en de inhoud van uw presentatie veilig houden. 
- U wilt mensen laten weten dat de presentatie die u hebt aangeleverd de definitieve versie is. 

Nadat u de optie **Always Open Read-Only** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de **Read-Only**‑aanbeveling en kunnen ze een bericht in deze vorm zien: *Om onbedoelde wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen‑lezen te worden geopend.*

De **Read-Only**‑aanbeveling is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt, omdat gebruikers een handeling moeten uitvoeren om deze te verwijderen voordat ze een presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier aan hen wilt communiceren, kan de **Read-Only**‑aanbeveling een goede optie voor u zijn. 

> Als een presentatie met de **Read-Only**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑applicatie—die de recent geïntroduceerde functie niet ondersteunt—wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read-Only-modus toepassen**

Aspose.Slides for C++ stelt u in staat om een presentatie op **Read-Only** te zetten, wat betekent dat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode toont hoe u een presentatie op **Read-Only** zet in C++ met behulp van Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Opmerking**: De **Read-Only**‑aanbeveling is simpelweg bedoeld om bewerken af te schrikken of gebruikers te voorkomen dat ze per ongeluk wijzigingen in een PowerPoint‑presentatie aanbrengen. Als een gemotiveerde persoon—die weet wat hij doet—beslist uw presentatie te bewerken, kan hij de Read-Only‑instelling gemakkelijk verwijderen. Als u echt ongeautoriseerd bewerken moet voorkomen, bent u beter af met [Wachtwoordbeveiliging](https://docs.aspose.com/slides/nl/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Hoe verschilt 'Read-Only recommended' van volledige wachtwoordbeveiliging?**

'Read-Only recommended' toont alleen een suggestie om het bestand in alleen‑lezen‑modus te openen en is gemakkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/cpp/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer u echte beveiligingscontroles nodig heeft.

**Kan 'Read-Only recommended' worden gecombineerd met watermerken om verdere bewerkingen af te schrikken?**

Ja. De aanbeveling kan worden gecombineerd met [watermerken](/slides/nl/cpp/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling ingeschakeld is?**

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om geautomatiseerde bewerkingen te voorkomen, gebruikt u [wachtwoorden en encryptie](/slides/nl/cpp/password-protected-presentation/).

**Hoe verhoudt 'Read-Only recommended' zich tot de vlaggen 'is encrypted' en 'is write protected'?**

Het zijn verschillende signalen. 'Read-Only recommended' is een zachte, optionele prompt; [get_IsWriteProtected](https://reference.aspose.com/slides/nl/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) en [get_IsEncrypted](https://reference.aspose.com/slides/nl/cpp/aspose.slides/protectionmanager/get_isencrypted/) geven daadwerkelijke schrijfs‑ of leesbeperkingen aan die afhankelijk zijn van wachtwoorden of encryptie.