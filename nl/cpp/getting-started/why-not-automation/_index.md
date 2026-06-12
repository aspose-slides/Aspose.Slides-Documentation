---
title: Waarom geen automatisering
type: docs
weight: 50
url: /nl/cpp/why-not-automation/
keywords:
- automatisering
- Microsoft Office
- vergelijken
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

Er zijn twee vragen die we hier bij Aspose het vaakst horen :

- Vereisen uw producten dat Microsoft Office op de machine is geïnstalleerd om te kunnen draaien?

Het korte, eenvoudige antwoord is **NIET**. Aspose en Aspose‑componenten zijn volledig onafhankelijk en staan niet verbonden met, noch geautoriseerd, gesponsord of op een andere manier goedgekeurd door Microsoft Corporation.

- Waarom zouden we Aspose‑producten gebruiken in plaats van Microsoft Office‑automatisering?

Het kortste antwoord dat we kunnen geven is dat er veel redenen zijn, waarvan de belangrijkste is dat *Microsoft zelf sterk afraadt Office‑automatisering vanuit softwareoplossingen: [Microsoft Article

## **Beveiliging**
Het volgende is een directe citaat uit het hierboven genoemde Microsoft‑artikel:  
*"Office‑applicaties zijn nooit bedoeld voor gebruik aan de serverzijde en houden daarom geen rekening met de beveiligingsproblemen waarmee gedistribueerde componenten te maken krijgen. Office valideert geen binnenkomende verzoeken en beschermt u niet tegen het per ongeluk uitvoeren van macro’s, of het starten van een andere server die macro’s kan uitvoeren, vanuit uw server‑side code. Open geen bestanden die via een anonieme website naar de server worden geüpload! Afhankelijk van de laatst ingestelde beveiligingsinstellingen kan de server macro’s uitvoeren onder een Administrator‑ of System‑context met volledige rechten en zo uw netwerk in gevaar brengen! Bovendien maakt Office gebruik van veel client‑side componenten (zoals Simple MAPI, WinInet, MSDAIPP) die client‑authenticatie‑informatie kunnen cachen om de verwerking te versnellen. Als Office server‑side wordt geautomatiseerd, kan één instantie meer dan één client bedienen, en doordat de authenticatie‑informatie voor die sessie is gecached, is het mogelijk dat één client de gecachte inloggegevens van een andere client kan gebruiken en zo onbevoegde toegangsrechten verkrijgt door zich voor te doen als andere gebruikers."*

Aspose‑producten zijn zeer veilig. Daarom vormen Aspose‑componenten geen potentieel risico voor vitale systeembronnen. Bovendien worden macro’s niet automatisch uitgevoerd wanneer een document wordt geopend door een Aspose‑component. Aspose‑componenten zijn gebouwd met het doel ontwikkelaars in staat te stellen Office‑bestanden te maken, manipuleren en opslaan. Geen van de risico’s die met het Microsoft Office‑pakket gepaard gaan, zijn inherent aan Aspose‑componenten .

## **Stabiliteit**
Het volgende is een directe citaat uit het hierboven genoemde Microsoft‑artikel:  
*"Office 2000, Office XP en Office 2003 gebruiken Microsoft Windows Installer (MSI)‑technologie om installatie en zelfreparatie makkelijker te maken voor de eindgebruiker. MSI introduceert het concept “install on first use”, waarmee functies dynamisch kunnen worden geïnstalleerd of geconfigureerd tijdens runtime (voor het systeem, of vaker voor een specifieke gebruiker). In een server‑side omgeving vertraagt dit zowel de prestaties als vergroot de kans dat er een dialoogvenster verschijnt dat de gebruiker vraagt de installatie goed te keuren of een geschikte installatie‑schijf te verschaffen. Hoewel het bedoeld is om de veerkracht van Office als eindgebruiker‑product te vergroten, is de implementatie van MSI‑mogelijkheden in Office tegenwerkend in een server‑side omgeving. Bovendien kan de stabiliteit van Office in het algemeen niet worden gegarandeerd wanneer het server‑side wordt uitgevoerd, omdat het niet is ontworpen of getest voor dit gebruik. Het gebruik van Office als een service‑component op een netwerksysteem kan de stabiliteit van die machine verminderen en daarmee van het gehele netwerk. Als u van plan bent Office server‑side te automatiseren, probeer het programma dan te isoleren op een toegewijde computer die geen kritieke functies kan beïnvloeden en die indien nodig kan worden herstart."*

Aangezien Aspose‑componenten verpakt zijn in één enkele DLL, zal er nooit behoefte zijn om extra onderdelen of stukken te installeren om ze te laten functioneren. Aspose‑componenten worden alleen gebruikt door C++‑applicaties en er is geen gedeelte van de componentcode dat is ontworpen om op een menselijke reactie te wachten. Aspose‑componenten zijn grondig getest en uiterst stabiel. Aspose‑componenten worden gebruikt door [Bedrijven](https://about.aspose.com/customers) zoals: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** en nog vele anderen.

## **Schaalbaarheid/Snelheid**
Het volgende is een directe citaat uit het hierboven genoemde Microsoft‑artikel:  

*"Server‑side componenten moeten sterk re‑entrant, multi‑threaded COM‑componenten zijn met minimale overhead en een hoge doorvoersnelheid voor meerdere clients. Office‑applicaties zijn in bijna alle opzichten precies het tegenovergestelde. Het zijn niet‑re‑entrant, STA‑gebaseerde automatiseringsservers die ontworpen zijn om diverse maar resource‑intensieve functionaliteit voor één client te bieden. Ze bieden weinig schaalbaarheid als server‑side oplossing en hebben vaste limieten voor belangrijke elementen, zoals geheugen, die niet via configuratie kunnen worden aangepast. Bovendien gebruiken ze globale bronnen (zoals memory‑mapped files, globale add‑ins of templates, en gedeelde automatiseringsservers), waardoor het aantal gelijktijdig draaiende exemplaren kan worden beperkt en race‑condities kunnen ontstaan als ze worden geconfigureerd in een multi‑client omgeving. Ontwikkelaars die van plan zijn meer dan één exemplaar van een Office‑applicatie tegelijk te draaien, moeten overwegen om pooling of serialisatie van de toegang tot de Office‑applicatie toe te passen om potentiële deadlocks of data‑corruptie te voorkomen”.*

Aspose‑componenten zijn zeer schaalbaar en razendsnel. Office‑applicaties zijn niet ontworpen om gelijktijdig door honderden of duizenden gebruikers te worden gebruikt. Aspose‑componenten daarentegen zijn juist daarvoor ontworpen. Onze componenten zijn een echte C++‑oplossing en presteren foutloos, zowel op een enkele server die één applicatie voedt als op een load‑balanced web‑form die een enterprise‑brede applicatie aandrijft.

## **Prijs**
Wanneer een applicatie Microsoft Office‑automatisering gebruikt, moet er voor elke machine die de applicatie draait een kopie van Microsoft Office worden aangeschaft. Er zijn vele situaties waarin een applicatie een Office‑bestand moet maken of manipuleren, maar de gebruiker niet Microsoft Office nodig heeft. Aspose biedt een zeer [kosten‑effectieve](https://purchase.aspose.com/) en royalty‑vrije redistributielicentie die implementatie op een onbeperkt aantal gebruikers toelaat zonder licentie‑zorgen. Bij het maken van web‑gebaseerde applicaties is het belangrijk te weten dat Microsoft Office‑automatiseringscomponenten niet geprijsd of gelicentieerd zijn voor server‑side oplossingen; er bestaat dus geen goede licentieoplossing voor het uitrollen van web‑applicaties die Microsoft Office‑componenten gebruiken. Aspose biedt eveneens een zeer [kosten‑effectieve](https://purchase.aspose.com/) oplossing voor server‑gebaseerde applicaties.

## **Functies**
Aspose‑componenten bieden alles wat nodig is voor het beheren van Office‑bestanden en nog veel meer. Ze zijn ontworpen met de filosofie ontwikkelaars in staat te stellen om de beste resultaten te behalen met zo min mogelijk inspanning. In tegenstelling tot Office‑automatisering bieden Aspose‑componenten veel krachtige en tijd‑besparende functies. Bijvoorbeeld, [Aspose.Cells](https://products.aspose.com/cells/cpp/) geeft ontwikkelaars de mogelijkheid om data uit een **DataTable** of **DataView** direct te importeren in een Excel‑bestand. [Aspose.Words](https://products.aspose.com/words/net/) biedt een vergelijkbare functie waarmee ontwikkelaars een Word‑document (Mail Merge) direct kunnen vullen vanuit elk C++‑data‑object. [Elke component](https://products.aspose.com/total/cpp/) in de Aspose‑familie biedt haar eigen unieke en krachtige functionaliteiten. Het beste van het aanschaffen van een Aspose‑component is de toegang tot onze ontwikkelingsteams. Onze teams beseffen dat als uw bedrijf een bepaalde functie nodig heeft, waarschijnlijk ook andere bedrijven die nodig hebben. Hoewel niet elk feature‑verzoek kan worden ingewilligd, proberen onze teams zeer open en flexibel te zijn bij het bieden van ondersteuning. Deze mentaliteit heeft ervoor gezorgd dat Aspose‑componenten zo krachtig zijn geworden. Als er extra functionaliteiten zijn die u nodig heeft van Office‑automatiseringsobjecten, zijn de kansen dat ze toegevoegd worden zeer, zeer klein.

## **Conclusie**
{{% alert color="primary" %}} 

Hoewel dit artikel veel van de belangrijkste redenen heeft behandeld waarom Aspose‑componenten een betere keuze zijn dan Office‑automatisering, zijn er nog veel meer. Dit artikel richt zich voornamelijk op de meest essentiële punten. Alle verschillende Aspose‑componenten bieden een risicovrije, vrijblijvende [Evaluatieversie](https://downloads.aspose.com/slides/nl/cpp). We moedigen u aan om gebruik te maken van die [Evaluatie](https://downloads.aspose.com/slides/nl/cpp) om beter te zien wat Aspose voor uw applicaties kan betekenen.