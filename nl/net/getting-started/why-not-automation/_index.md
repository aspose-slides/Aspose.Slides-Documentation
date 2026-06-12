---
title: "Waarom geen automatisering"
type: docs
weight: 40
url: /nl/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek waarom Office-automatisering riskant is voor servers en services, en zie hoe Aspose.Slides veiliger en sneller presentaties verwerkt voor PowerPoint en OpenDocument."
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

Er zijn twee vragen die we vaak horen bij Aspose:

- Vereisen uw producten dat Microsoft Office geïnstalleerd is om te kunnen draaien?

Het korte, eenvoudige antwoord is **NEE**.

Aspose‑componenten zijn volledig onafhankelijk en zijn niet geaffilieerd met, geautoriseerd door, gesponsord door of anderszins goedgekeurd door Microsoft Corporation.

- Waarom zouden we Aspose‑producten gebruiken in plaats van Microsoft Office‑automatisering?

Ten eerste zijn er veel [benefits you enjoy when you use Aspose.Slides](/slides/nl/net/product-overview/).

Ten tweede raadt Microsoft zelf sterk **af** om Office‑Automatisering te gebruiken vanuit software‑oplossingen.

## **Beveiliging**
Het volgende is een rechtstreeks citaat uit een Microsoft‑artikel: 

> "Office‑applications waren nooit bedoeld voor gebruik aan de serverzijde, en houden daarom geen rekening met de beveiligingsproblemen waarmee gedistribueerde componenten te maken hebben. Office authenticatieert geen inkomende verzoeken en beschermt u niet tegen het onbedoeld uitvoeren van macro’s, of het starten van een andere server die macro’s zou kunnen uitvoeren, vanuit uw server‑side code. Open geen bestanden die geüpload zijn naar de server vanaf een anonieme web! Op basis van de laatst ingestelde beveiligingsinstellingen kan de server macro’s uitvoeren onder een Administrator‑ of System‑context met volledige rechten en uw netwerk compromitteren! Daarnaast gebruikt Office veel client‑side componenten (zoals Simple MAPI, WinInet, MSDAIPP) die client‑authenticatie‑informatie kunnen cachen om de verwerking te versnellen. Als Office server‑side geautomatiseerd wordt, kan één instantie meer dan één client bedienen, en omdat authenticatie‑informatie voor die sessie is gecached, is het mogelijk dat één client de gecachete referenties van een andere client gebruikt, en daardoor onbevoegde toegangsrechten verkrijgt door zich voor te doen als andere gebruikers."

Aspose‑producten zijn zeer **veilig**. Aspose‑componenten draaien in dezelfde gebruikerscontext als alle ASP.NET‑toepassingen (onder de ASPNET‑gebruiker). Daarom vormen Aspose‑componenten **geen** beveiligingsrisico. Ze verbruiken ook geen kritieke systeembronnen. Bovendien, wanneer een Aspose‑component een document opent, worden macro’s niet automatisch uitgevoerd. Aspose‑componenten zijn gebouwd om ontwikkelaars in staat te stellen Office‑bestanden te maken, te manipuleren en op te slaan. 

{{% alert color="primary" %}} 

Geen van de risico’s die verbonden zijn aan het Microsoft‑Office‑pakket zijn van toepassing op Aspose‑componenten.

{{% /alert %}} 

## **Stabiliteit**
Deze tekst is een rechtstreeks citaat uit het eerder genoemde Microsoft‑artikel: 

> "Office 2000, Office XP en Office 2003 gebruiken Microsoft Windows Installer (MSI)‑technologie om installatie en zelfherstel voor de eindgebruiker te vergemakkelijken. MSI introduceert het concept van “install on first use”, waardoor functies dynamisch kunnen worden geïnstalleerd of geconfigureerd tijdens runtime (voor het systeem, of vaker voor een specifieke gebruiker). In een server‑side omgeving vertraagt dit zowel de prestaties als de kans dat een dialoogvenster verschijnt waarin de gebruiker wordt gevraagd de installatie goed te keuren of een geschikt installatieschijfje te leveren. Hoewel het bedoeld is om de veerkracht van Office als eindgebruikersproduct te vergroten, is de implementatie van MSI‑mogelijkheden door Office contraproductief in een server‑side omgeving. Bovendien kan de stabiliteit van Office in het algemeen niet worden gegarandeerd wanneer het server‑side wordt uitgevoerd, omdat het niet is ontworpen of getest voor dit type gebruik. Het gebruik van Office als service‑component op een netwerk‑server kan de stabiliteit van die machine en daarmee uw hele netwerk verminderen. Als u van plan bent Office server‑side te automatiseren, probeer het programma dan te isoleren op een toegewijde computer die geen kritieke functies kan beïnvloeden en die indien nodig herstart kan worden."

Aangezien Aspose‑componenten verpakt zijn in één enkele DLL, hoeven hun gebruikers nooit extra onderdelen te installeren om ze te laten functioneren. Aspose‑componenten worden uitsluitend gebruikt door .NET‑toepassingen en er is geen deel van de componentcode dat wacht op een menselijke reactie. 

{{% alert color="primary" %}} 

Aspose‑componenten zijn grondig getest en bewezen zeer stabiel te zijn. Aspose‑componenten worden gebruikt door [companies](http://www.aspose.com/Corporate/Aspose/Customerlist.html) zoals **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** en vele andere toonaangevende organisaties in diverse sectoren en vakgebieden. 

{{% /alert %}} 

## **Schaalbaarheid/Snelheid**
Het volgende is een rechtstreeks citaat uit een Microsoft‑artikel: 

> "Server‑side componenten moeten sterk her‑entrant, multi‑threaded COM‑componenten zijn met minimaal overhead en hoog doorvoervermogen voor meerdere clients. Office‑applications zijn in bijna alle opzichten precies het tegenovergestelde. Het zijn niet‑her‑entrant, STA‑gebaseerde Automation‑servers die ontworpen zijn om diverse maar resource‑intensieve functionaliteit te leveren voor één client. Ze bieden weinig schaalbaarheid als server‑side oplossing, en hebben vaste limieten voor belangrijke elementen, zoals geheugen, die niet via configuratie gewijzigd kunnen worden. Belangrijker nog, ze gebruiken globale bronnen (zoals geheugen‑gemapte bestanden, globale add‑ins of sjablonen, en gedeelde Automation‑servers), die het aantal instanties dat gelijktijdig kan draaien kunnen beperken en tot race‑conditions kunnen leiden als ze geconfigureerd zijn in een multi‑client omgeving. Ontwikkelaars die van plan zijn meer dan één instantie van een Office‑application tegelijk te draaien, moeten overwegen om pooling of serializing access to the Office Application toe te passen om potentiële deadlocks of datacorruption te voorkomen."

Aspose‑componenten zijn ongelooflijk schaalbaar en razendsnel. Office‑applications zijn niet ontworpen om gelijktijdig door honderden of duizenden gebruikers gebruikt te worden, maar Aspose‑componenten zijn precies voor dat scenario gebouwd. Onze componenten zijn een echte .NET‑oplossing. 

{{% alert color="primary" %}} 

De prestaties van Aspose‑componenten zijn foutloos op één enkele server (die één applicatie aandrijft) of op een load‑balanced web‑form (die een enterprise‑wide applicatie aandrijft).

{{% /alert %}} 

## **Prijs**
Wanneer een applicatie Microsoft Office Automation gebruikt, moet voor elke machine die de app draait een exemplaar van Microsoft Office worden aangeschaft. Er zijn vele gevallen waarin een applicatie een Office‑bestand moet maken of manipuleren, maar het proces vereist geen Microsoft Office. 

{{% alert color="primary" %}} 

Aspose biedt een zeer [cost-effective](https://purchase.aspose.com/) en royalty‑vrije redistributielicentie die inzet op een onbeperkt aantal gebruikers zonder licentie‑zorgen mogelijk maakt. 

{{% /alert %}} 

Bij het maken van web‑gebaseerde applicaties is het belangrijk te onthouden dat Microsoft Office Automation‑componenten noch geprijsd noch gelicentieerd zijn voor server‑side oplossingen. Daarom bestaat er geen goede licentie‑oplossing voor de uitrol van web‑applicaties die Microsoft Office‑componenten gebruiken. Aspose biedt daarentegen een zeer [cost-effective](https://purchase.aspose.com/) oplossing voor server‑gebaseerde applicaties.

## **Functies**
Aspose‑componenten bieden alles wat nodig is voor het beheren van Office‑bestanden en nog veel meer. We hebben ze ontworpen volgens onze filosofie om ontwikkelaars te helpen de best mogelijke resultaten te behalen met de minste inspanning. 

{{% alert color="primary" %}} 

In tegenstelling tot Office Automation bieden Aspose‑componenten vele krachtige en tijdbesparende functies. 

{{% /alert %}} 

Zo geeft [Aspose.Cells](https://products.aspose.com/cells/net/) ontwikkelaars de mogelijkheid om data direct vanuit een **DataTable** of **DataView** in een Excel‑bestand te importeren. [Aspose.Words](https://products.aspose.com/words/net/) biedt een vergelijkbare functie waarmee ontwikkelaars een Word‑document (bijvoorbeeld Mail Merge) direct vanuit elk .NET‑data‑object kunnen vullen. [Every component](https://products.aspose.com/total/net/) in de Aspose‑familie biedt zijn eigen reeks unieke en krachtige kenmerken. 

Het beste van het aanschaffen van een Aspose‑component is de toegang tot onze ontwikkelteams. Als u bijvoorbeeld Office Automation‑objecten gebruikt en bepaalde functies nodig heeft, is de kans dat deze functies worden toegevoegd zeer, zeer klein. Met Aspose‑componenten is het echter anders. 

{{% alert color="primary" %}} 

Onze ontwikkelteams begrijpen dat als er een functie is die uw bedrijf nodig heeft, er een goede kans is dat andere bedrijven dezelfde functie nodig hebben. Hoewel we weten dat we niet elke gevraagde functie kunnen implementeren, streven we ernaar om zoveel mogelijk functies toe te voegen op basis van feedback van onze klanten. 

{{% /alert %}} 

Onze teams staan altijd open, flexibel en behulpzaam – en dat is de reden waarom Aspose‑componenten zo krachtig zijn geworden.

## **Conclusie**
{{% alert color="primary" %}} 

Hoewel dit artikel enkele van de belangrijkste punten behandelt waarom Aspose‑componenten een betere keuze zijn dan Office Automation, moet u begrijpen dat er nog veel meer voordelen zijn. We hebben slechts een deel van de belangrijkste voordelen belicht. 

Bovendien bieden alle Aspose‑producten en -componenten een risicovrije, vrijblijvende [Evaluation Version](https://downloads.aspose.com/slides/nl/net). We moedigen u aan om gebruik te maken van de evaluatie om te zien wat Aspose voor uw applicaties of bedrijf kan betekenen. 

{{% /alert %}}