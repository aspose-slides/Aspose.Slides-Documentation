---
title: Waarom geen automatisering
type: docs
weight: 50
url: /nl/cpp/why-not-automation/
keywords:
- automatisering
- Microsoft Office
- vergelijking
- beveiliging
- stabiliteit
- schaalbaarheid
- functies
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek waarom Office-automatisering riskant is voor servers en services, en zie hoe Aspose.Slides veiligere, snellere presentatieverwerking biedt voor PowerPoint en OpenDocument."
---
## **Introductie**

Er zijn verschillende redenen waarom Aspose‑componenten een beter alternatief zijn voor automatisering. Enkele van de belangrijkste redenen zijn:

- Beveiliging
- Stabiliteit
- Schaalbaarheid/Snelheid
- Prijs
- Functies

Hieronder volgt een meer gedetailleerde uitleg van elk belangrijk punt.

## **Belangrijke vragen**
- Waarom zijn Aspose‑componenten een veel betere optie dan Microsoft Office‑automatisering?

Er zijn twee vragen die we hier bij Aspose het vaakst horen:

- Vereisen uw producten dat Microsoft Office geïnstalleerd moet zijn om te kunnen draaien?

Het korte, eenvoudige antwoord is **NEE**. Aspose en Aspose‑componenten zijn volledig onafhankelijk en staan niet in verband met, noch zijn ze geautoriseerd, gesponsord of anderszins goedgekeurd door Microsoft Corporation.

- Waarom zouden we Aspose‑producten gebruiken in plaats van Microsoft Office‑automatisering?

Het kortst mogelijke antwoord is dat er veel redenen zijn, waarvan de belangrijkste is dat *Microsoft zelf sterk afraden om Office‑automatisering vanuit software‑oplossingen te gebruiken: [Microsoft Article]*

## **Beveiliging**
Het volgende is een directe quote uit het hierboven genoemde Microsoft‑artikel :

*"Office‑toepassingen waren nooit bedoeld voor gebruik server‑side, en houden daarom geen rekening met de beveiligingsproblemen die zich voordoen bij gedistribueerde componenten. Office authenticeert geen inkomende verzoeken en beschermt u niet tegen het onbedoeld uitvoeren van macro’s, of het starten van een andere server die macro’s kan uitvoeren, vanuit uw server‑side code. Open geen bestanden die naar de server zijn geüpload door een anonieme webgebruiker! Afhankelijk van de laatst ingestelde beveiligingsinstellingen kan de server macro’s uitvoeren onder een Administrator‑ of System‑context met volledige rechten en uw netwerk compromitteren! Bovendien gebruikt Office veel client‑side componenten (zoals Simple MAPI, WinInet, MSDAIPP) die client‑authenticatie‑informatie kunnen cachen om de verwerking te versnellen. Als Office server‑side wordt geautomatiseerd, kan één instantie meer dan één client bedienen, en omdat authenticatie‑informatie voor die sessie is gecached, is het mogelijk dat één client de gecachede inloggegevens van een andere client kan gebruiken en zo toegang krijgt die niet is verleend door zich voor te doen als een andere gebruiker."*

Aspose‑producten zijn zeer veilig. Daarom vormen Aspose‑componenten geen potentieel risico voor cruciale systeembronnen. Bovendien worden macro’s niet automatisch uitgevoerd wanneer een document wordt geopend door een Aspose‑component. Aspose‑componenten zijn ontwikkeld met als doel ontwikkelaars in staat te stellen Office‑bestanden te maken, te bewerken en op te slaan. Geen van de risico’s die verbonden zijn aan het Microsoft‑Office‑pakket zijn inherent aan Aspose‑componenten.

## **Stabiliteit**
Het volgende is een directe quote uit het hierboven genoemde Microsoft‑artikel :

*"Office 2000, Office XP en Office 2003 gebruiken Microsoft Windows Installer (MSI)‑technologie om installatie en zelfherstel voor de eindgebruiker gemakkelijker te maken. MSI introduceert het concept van “install on first use”, waardoor functies dynamisch kunnen worden geïnstalleerd of geconfigureerd tijdens runtime (voor het systeem, of vaker voor een specifieke gebruiker). In een server‑side omgeving vertraagt dit zowel de prestaties als de kans dat een dialoogvenster verschijnt waarin de gebruiker wordt gevraagd de installatie goed te keuren of een geschikte installatieschijf te verschaffen. Hoewel het ontworpen is om de veerkracht van Office als eindgebruikersproduct te vergroten, is de implementatie van MSI‑mogelijkheden door Office contraproductief in een server‑side omgeving. Bovendien kan de stabiliteit van Office in het algemeen niet worden gegarandeerd wanneer het server‑side wordt uitgevoerd, omdat het niet is ontworpen of getest voor dit type gebruik. Het gebruik van Office als service‑component op een netwerkschijf kan de stabiliteit van die machine en daarmee uw gehele netwerk verminderen. Als u Office server‑side wilt automatiseren, probeer het programma dan te isoleren op een dedicated computer die geen kritieke functies kan beïnvloeden en die indien nodig kan worden herstart."*

Aangezien Aspose‑componenten in één enkele DLL worden verpakt, is er nooit een extra deel nodig om te installeren. Aspose‑componenten worden alleen gebruikt door C++‑toepassingen en er is geen onderdeel van de componentcode dat wacht op een menselijke reactie. Aspose‑componenten zijn grondig getest en zeer stabiel. Aspose‑componenten worden gebruikt door [Bedrijven](https://about.aspose.com/customers) zoals **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** en nog veel meer.

## **Schaalbaarheid/Snelheid**
Het volgende is een directe quote uit het hierboven genoemde Microsoft‑artikel :

*"Server‑side componenten moeten sterk re‑entrant, multi‑threaded COM‑componenten zijn met minimale overhead en een hoge doorvoersnelheid voor meerdere clients. Office‑toepassingen zijn in bijna alle opzichten het exacte tegenovergestelde. Ze zijn non‑re‑entrant, STA‑gebaseerde automatiseringsservers die zijn ontworpen om diverse maar resource‑intensieve functionaliteit voor één client te leveren. Ze bieden weinig schaalbaarheid als server‑side oplossing en hebben vaste limieten voor cruciale elementen, zoals geheugen, die niet via configuratie kunnen worden aangepast. Belangrijker nog, ze gebruiken globale bronnen (zoals memory‑mapped bestanden, globale add‑ins of templates, en gedeelde automatiseringsservers), waardoor het aantal instanties dat gelijktijdig kan draaien beperkt wordt en race‑conditions kunnen ontstaan in een multi‑client omgeving. Ontwikkelaars die van plan zijn meer dan één instantie van een Office‑toepassing tegelijk uit te voeren, moeten overwegen om pooling of serialising van de toegang tot de Office‑toepassing toe te passen om mogelijke deadlocks of datacorruptie te voorkomen."*

Aspose‑componenten zijn zeer schaalbaar en bliksemsnel. Office‑toepassingen zijn niet ontworpen om gelijktijdig door honderden of duizenden gebruikers te worden gebruikt. Aspose‑componenten zijn echter juist daarvoor ontworpen. Onze componenten zijn een echte C++‑oplossing en presteren foutloos, zowel op één enkele server die één applicatie ondersteunt als op een load‑balanced web‑form die een organisatie‑brede applicatie aandrijft.

## **Prijs**
Wanneer een applicatie Microsoft Office‑automatisering gebruikt, moet voor elke machine waarop de applicatie draait een kopie van Microsoft Office worden aangekocht. Er zijn veel situaties waarin een applicatie een Office‑bestand moet creëren of bewerken zonder dat de gebruiker Microsoft Office nodig heeft. Aspose biedt een zeer [Kosteneffectieve](https://purchase.aspose.com/) en royalty‑vrije distributielicentie die implementatie op een onbeperkt aantal gebruikers zonder licentiezorgen mogelijk maakt. Bij het ontwikkelen van web‑gebaseerde applicaties is het belangrijk te weten dat Microsoft Office‑automatiseringscomponenten niet geprijsd of gelicentieerd zijn voor server‑side oplossingen; er bestaat dan ook geen goede licentieoplossing voor het uitrollen van web‑applicaties die Microsoft Office‑componenten gebruiken. Aspose biedt een zeer [Kosteneffectieve](https://purchase.aspose.com/) oplossing voor server‑gebaseerde applicaties.

## **Functies**
Aspose‑componenten bieden alles wat nodig is voor het beheren van Office‑bestanden én veel meer. Ze zijn ontworpen met de filosofie ontwikkelaars in staat te stellen de grootste resultaten te behalen met de minste inspanning. In tegenstelling tot Office‑automatisering bieden Aspose‑componenten tal van krachtige en tijdbesparende functies. Zo biedt [Aspose.Cells](https://products.aspose.com/cells/cpp/) ontwikkelaars de mogelijkheid om gegevens rechtstreeks vanuit een **DataTable** of **DataView** in een Excel‑bestand te importeren. [Aspose.Words](https://products.aspose.com/words/net/) biedt een vergelijkbare functionaliteit waarmee ontwikkelaars een Word‑document (Mail‑Merge) rechtstreeks vanuit elk C++‑data‑object kunnen vullen. [Elke Component](https://products.aspose.com/total/cpp/) in de Aspose‑familie biedt zijn eigen unieke en krachtige functies. Het beste van het aanschaffen van een Aspose‑component is de toegang tot onze ontwikkelingsteams. Onze teams realiseren zich dat als uw bedrijf een bepaalde functie nodig heeft, andere bedrijven dat waarschijnlijk ook nodig hebben. Hoewel niet elke functieverzoek kan worden toegevoegd, proberen onze teams zeer open‑geest en flexibel te zijn bij het verlenen van ondersteuning. Deze mentaliteit heeft Aspose‑componenten zo krachtig gemaakt. Als er extra functionaliteit nodig is die Office‑automatiseringsobjecten bieden, is de kans dat deze wordt toegevoegd zeer, zeer klein.

## **Conclusie**
{{% alert color="primary" %}} 

Hoewel dit artikel veel van de belangrijkste redenen behandelt waarom Aspose‑componenten een betere keuze zijn dan Office‑automatisering, zijn er nog veel meer. Dit artikel behandelt uitsluitend de meest cruciale punten. Alle verschillende Aspose‑componenten bieden een risicovrije, vrijblijvende [Evaluatieversie](https://downloads.aspose.com/slides/nl/cpp). We moedigen u aan om van die [Evaluatie](https://downloads.aspose.com/slides/nl/cpp) gebruik te maken om beter te zien wat Aspose voor uw applicaties kan betekenen. 
{{% /alert %}}