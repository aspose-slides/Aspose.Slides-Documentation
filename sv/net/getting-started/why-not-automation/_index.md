---
title: Varför inte automatisering
type: docs
weight: 40
url: /sv/net/why-not-automation/
keywords:
- automatisering
- Microsoft Office
- jämförelse
- säkerhet
- stabilitet
- skalbarhet
- funktioner
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck varför Office-automatisering är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare och snabbare presentationbearbetning för PowerPoint och OpenDocument."
---
## **Introduktion**

Det finns flera anledningar till att Aspose‑komponenter är ett bättre alternativ till automatisering. Några av de viktigaste anledningarna är:

- Säkerhet
- Stabilitet
- Skalbarhet/Hastighet
- Pris
- Funktioner

Nedan följer en mer detaljerad förklaring av varje viktig punkt.

## **Viktiga frågor**

Det finns två frågor vi ofta får på Aspose:

- Kräver era produkter att Microsoft Office är installerat för att kunna köras?

Det korta, enkla svaret är **NEJ**.

Aspose‑komponenter är helt oberoende och är inte knutna till, auktoriserade av, sponsrade av eller på annat sätt godkända av Microsoft Corporation.

- Varför ska vi använda Aspose‑produkter istället för Microsoft Office‑automatisering?

Först finns det många [fördelar du får när du använder Aspose.Slides](/slides/sv/net/product-overview/).

För det andra avråder Microsoft starkt **från** att använda Office‑automatisering i mjukvarulösningar.

## **Säkerhet**
Följande är ett direkt citat från en Microsoft‑artikel: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose‑produkter är mycket **säker**. Aspose‑komponenter körs i samma användarkontext som alla ASP.NET‑applikationer (under ASPNET‑användaren). Därför utgör Aspose‑komponenter **inte** någon säkerhetsrisk. De förbrukar inte heller kritiska systemresurser. Vidare, när en Aspose‑komponent öppnar ett dokument körs makron inte automatiskt. Aspose‑komponenter är byggda för att låta utvecklare skapa, manipulera och spara Office‑filer. 

{{% alert color="info" %}} 

Ingen av de risker som är förknippade med Microsoft Office‑paketet gäller för Aspose‑komponenter.

{{% /alert %}} 

## **Stabilitet**
Denna text är ett direkt citat från den tidigare refererade Microsoft‑artikeln: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Eftersom Aspose‑komponenter pakkas i en enda DLL behöver deras användare aldrig installera ytterligare delar för att de ska fungera. Aspose‑komponenter används endast av .NET‑applikationer och ingen del av komponentkoden är avsedd att vänta på mänsklig respons. 

{{% alert color="info" %}} 

Aspose‑komponenter har testats grundligt och bekräftats vara mycket stabila. Aspose‑komponenter används av [företag](http://www.aspose.com/Corporate/Aspose/Customerlist.html) såsom **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** och många andra ledande organisationer inom flera branscher och områden. 

{{% /alert %}} 

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från en Microsoft‑artikel: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose‑komponenter är otroligt skalbara och blixtsnabba. Office‑applikationer var inte avsedda att användas samtidigt av hundratals eller tusentals användare, men Aspose‑komponenter är exakt designade för det. Våra komponenter är en sann .NET‑lösning. 

{{% alert color="info" %}} 

Aspose‑komponenternas prestanda är felfri på en enskild server (driver en enskild applikation) eller på en lastbalanserad webbform (driver en företagsomfattande applikation).

{{% /alert %}} 

## **Pris**
När en applikation använder Microsoft Office‑automatisering måste en kopia av Microsoft Office köpas för varje maskin som kör appen. Det finns många tillfällen då en applikation kan behöva skapa eller manipulera en Office‑fil, men processen kräver inte Microsoft Office. 

{{% alert color="info" %}} 

Aspose tillhandahåller en mycket [kostnadseffektiv](https://purchase.aspose.com/) och royaltyfri omdistributionslicens som möjliggör distribution till ett obegränsat antal användare utan licensbekymmer. 

{{% /alert %}} 

När man skapar webb‑baserade applikationer är det viktigt att komma ihåg att Microsoft Office‑automatiseringskomponenter varken är prissatta eller licensierade för server‑sides lösningar. Därför finns ingen bra licensieringslösning för distribution av webbapplikationer som använder Microsoft Office‑komponenter. Aspose, å andra sidan, erbjuder en mycket [kostnadseffektiv](https://purchase.aspose.com/) lösning för server‑baserade applikationer också.

## **Funktioner**
Aspose‑komponenter erbjuder allt som behövs för att hantera Office‑filer och mycket mer. Vi har designat dem utifrån vår filosofi att hjälpa utvecklare att uppnå största möjliga resultat med minsta möjliga ansträngning. 

{{% alert color="info" %}} 

Till skillnad från Office‑automatisering erbjuder Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. 

{{% /alert %}} 

Till exempel ger [Aspose.Cells](https://products.aspose.com/cells/net/) utvecklare möjlighet att importera data från en **DataTable** eller **DataView** direkt till en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/net/) erbjuder en liknande funktion som låter utvecklare fylla i ett Word‑dokument (dvs. Mail Merge) direkt från vilket .NET‑dataobjekt som helst. [Varje komponent](https://products.aspose.com/total/net/) i Aspose‑familjen erbjuder sin egen uppsättning unika och kraftfulla funktioner. 

Det bästa med att köpa en Aspose‑komponent är att få tillgång till våra utvecklingsteam. Till exempel, om du använder Office‑automatiseringsobjekt och behöver vissa funktioner, är chansen att de läggs till mycket, mycket liten. Med Aspose‑komponenter är situationen annorlunda. 

{{% alert color="info" %}} 

Våra utvecklingsteam förstår att om det finns en funktion som ditt företag behöver, finns det en stor chans att andra företag också behöver samma funktion. Även om vi vet att vi inte kan implementera varje begärd funktion, strävar vi efter att lägga till så många funktioner som möjligt baserat på återkoppling från våra kunder. 

{{% /alert %}} 

Våra team är alltid öppna och flexibla när de erbjuder hjälp – och det är orsaken till att Aspose‑komponenter har vuxit till att bli så kraftfulla som de är idag. 

## **Slutsats**
{{% alert color="info" %}} 

Medan den här artikeln behandlade några av de viktigaste punkterna om varför Aspose‑komponenter är ett bättre val än Office‑automatisering, måste du förstå att det finns många, många fler fördelar. Vi gick bara igenom några av de största fördelarna. 

Dessutom erbjuder alla Aspose‑produkter och -komponenter en risk‑fri, utan förpliktelse [Utvärderingsversion](https://downloads.aspose.com/slides/sv/net). Vi uppmuntrar dig att utnyttja utvärderingen för att se vad Aspose kan göra för dina applikationer eller ditt företag. 

{{% /alert %}}