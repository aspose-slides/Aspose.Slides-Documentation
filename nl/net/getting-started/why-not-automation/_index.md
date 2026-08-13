---
title: Waarom geen automatisering
type: docs
weight: 40
url: /nl/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek waarom Office-automatisering riskant is voor servers en diensten, en zie hoe Aspose.Slides veiligere, snellere presentatieverwerking biedt voor PowerPoint en OpenDocument."
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

Aspose‑componenten zijn volledig onafhankelijk en zijn niet gelieerd aan, geautoriseerd door, gesponsord door of anderszins goedgekeurd door Microsoft Corporation.

- Waarom zouden we Aspose‑producten gebruiken in plaats van Microsoft Office Automation?

Ten eerste zijn er veel [voordelen die u krijgt wanneer u Aspose.Slides gebruikt](/slides/nl/net/product-overview/).

Ten tweede raadt Microsoft zelf sterk **af** om Office Automation vanuit softwareoplossingen te gebruiken.

## **Beveiliging**
Het volgende is een directe quote uit een Microsoft‑artikel: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose‑producten zijn zeer **beveiligd**. Aspose‑componenten draaien in dezelfde gebruikerscontext als alle ASP.NET‑toepassingen (onder de ASPNET‑gebruiker). Daarom vormen Aspose‑componenten **geen** beveiligingsrisico. Ze verbruiken ook geen kritieke systeembronnen. Bovendien, wanneer een Aspose‑component een document opent, worden macro’s niet automatisch uitgevoerd. Aspose‑componenten zijn ontwikkeld om ontwikkelaars in staat te stellen Office‑bestanden te maken, te manipuleren en op te slaan. 

{{% alert color="info" %}} 

Geen van de risico’s die gepaard gaan met het Microsoft‑Office‑pakket zijn van toepassing op Aspose‑componenten.

{{% /alert %}} 

## **Stabiliteit**
Deze tekst is een directe quote uit het eerder genoemde Microsoft‑artikel: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Aangezien Aspose‑componenten in één enkele DLL zijn verpakt, hoeven hun gebruikers nooit extra onderdelen te installeren om ze te laten functioneren. Aspose‑componenten worden uitsluitend gebruikt door .NET‑toepassingen en er is geen deel van de componentcode dat wacht op een menselijke reactie. 

{{% alert color="info" %}} 

Aspose‑componenten zijn grondig getest en bewezen zeer stabiel te zijn. Aspose‑componenten worden gebruikt door [bedrijven](http://www.aspose.com/Corporate/Aspose/Customerlist.html) zoals **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** en vele andere toonaangevende organisaties in verschillende sectoren en vakgebieden. 

{{% /alert %}} 

## **Schaalbaarheid/Snelheid**
Het volgende is een directe quote uit een Microsoft‑artikel: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose‑componenten zijn enorm schaalbaar en bliksemsnel. Office‑applicaties waren niet bedoeld om gelijktijdig door honderden of duizenden gebruikers gebruikt te worden, maar Aspose‑componenten zijn juist daarvoor ontworpen. Onze componenten vormen een echte .NET‑oplossing. 

{{% alert color="info" %}} 

De prestaties van Aspose‑componenten zijn foutloos op een enkele server (die één applicatie voedt) of op een load‑balanced web‑form (die een ondernemingsbrede applicatie ondersteunt).

{{% /alert %}} 

## **Prijs**
Wanneer een applicatie Microsoft Office Automation gebruikt, moet voor elke machine die de applicatie draait een exemplaar van Microsoft Office worden aangeschaft. Een applicatie kan talloze keren een Office‑bestand aanmaken of manipuleren, maar dit proces vereist geen Microsoft Office. 

{{% alert color="info" %}} 

Aspose biedt een zeer [kosteneffectieve](https://purchase.aspose.com/) en royalty‑vrije redistributielicentie die inzet op een onbeperkt aantal gebruikers zonder licentiezorgen mogelijk maakt. 

{{% /alert %}} 

Bij het ontwikkelen van web‑gebaseerde applicaties moet men zich realiseren dat Microsoft Office Automation‑componenten noch geprijsd noch gelicentieerd zijn voor server‑side oplossingen. Er bestaat dus geen goede licentieoplossing voor de inzet van web‑applicaties die Microsoft Office‑componenten gebruiken. Aspose daarentegen biedt een zeer [kosteneffectieve](https://purchase.aspose.com/) oplossing voor server‑gebaseerde applicaties.

## **Functies**
Aspose‑componenten bieden alles wat nodig is voor het beheren van Office‑bestanden en nog veel meer. We hebben ze ontworpen volgens onze filosofie om ontwikkelaars te helpen de best mogelijke resultaten te behalen met zo min mogelijk inspanning. 

{{% alert color="info" %}} 

In tegenstelling tot Office Automation bieden Aspose‑componenten tal van krachtige en tijdbesparende functies. 

{{% /alert %}} 

Zo geeft [Aspose.Cells](https://products.aspose.com/cells/net/) ontwikkelaars de mogelijkheid om gegevens uit een **DataTable** of **DataView** rechtstreeks in een Excel‑bestand te importeren. [Aspose.Words](https://products.aspose.com/words/net/) biedt een vergelijkbare functie waarmee ontwikkelaars een Word‑document (bijv. een mail‑merge) direct vanuit elk .NET‑data‑object kunnen vullen. [Elke component](https://products.aspose.com/total/net/) in de Aspose‑familie biedt zijn eigen set unieke en krachtige functionaliteiten. 

Het beste van het kopen van een Aspose‑component is de toegang tot onze ontwikkelingsteams. Als u Office Automation‑objecten gebruikt en bepaalde functies nodig heeft, is de kans dat die functies worden toegevoegd zeer, zeer klein. Met Aspose‑componenten is dat anders. 

{{% alert color="info" %}} 

Onze ontwikkelingsteams begrijpen dat als een functie nodig is voor uw bedrijf, er een grote kans is dat andere bedrijven diezelfde functie nodig hebben. Hoewel we weten dat we niet elke aangevraagde functie kunnen implementeren, streven we ernaar zoveel mogelijk functies toe te voegen op basis van feedback van onze klanten. 

{{% /alert %}} 

Onze teams staan altijd open en flexibel bij het bieden van ondersteuning – en dat is de reden waarom Aspose‑componenten inmiddels zo krachtig zijn geworden. 

## **Conclusie**
{{% alert color="info" %}} 

Hoewel dit artikel enkele van de belangrijkste redenen behandelt waarom Aspose‑componenten een betere keuze zijn dan Office Automation, moet u weten dat er nog veel meer voordelen bestaan. We hebben alleen een aantal van de grootste voordelen belicht. 

Bovendien bieden alle Aspose‑producten en -componenten een risico‑vrije, vrijblijvende [Evaluatieversie](https://downloads.aspose.com/slides/nl/net). We moedigen u aan om de evaluatie te gebruiken om te zien wat Aspose voor uw applicaties of bedrijf kan betekenen. 

{{% /alert %}}