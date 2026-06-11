---
title: Varför inte automation
type: docs
weight: 40
url: /sv/net/why-not-automation/
keywords:
- automation
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
description: "Upptäck varför Office-automation är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare, snabbare presentationhantering för PowerPoint och OpenDocument."
---
## **Introduktion**

Det finns flera anledningar till att Aspose-komponenter är ett bättre alternativ till automation. Några av de viktigaste anledningarna är:

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

Aspose-komponenter är helt oberoende och är inte fästa vid, auktoriserade av, sponsrade av eller på annat sätt godkända av Microsoft Corporation.

- Varför ska vi använda Aspose-produkter istället för Microsoft Office Automation?

Först finns det många [fördelar du får när du använder Aspose.Slides](/slides/sv/net/product-overview/).

För det andra avråder Microsoft själva starkt från att använda Office Automation i mjukvarulösningar.

## **Säkerhet**
Följande är ett direkt citat från en Microsoft-artikel: 

> "Office-program var aldrig avsedda för användning på server-sidan och tar därför inte hänsyn till de säkerhetsproblem som distribuerade komponenter möter. Office autentiserar inte inkommande förfrågningar och skyddar dig inte mot oavsiktligt körning av makron eller att starta en annan server som kan köra makron från din server‑sidokod. Öppna inte filer som har laddats upp till servern från en anonym webb! Baserat på de säkerhetsinställningar som senast sattes kan servern köra makron under en Administratörs‑ eller System‑kontext med fulla behörigheter och äventyra ditt nätverk! Dessutom använder Office många klient‑sidokomponenter (såsom Simple MAPI, WinInet, MSDAIPP) som kan cachelagra klientens autentiseringsinformation för att snabba upp bearbetningen. Om Office automatiseras på server‑sidan kan en instans betjäna mer än en klient, och eftersom autentiseringsinformationen har cachelagrats för den sessionen är det möjligt att en klient kan använda den cachade autentiseringsinformationen från en annan klient och därigenom få åtkomstbehörigheter som inte beviljats genom att utge sig för en annan användare."

Aspose-produkter är mycket **säkra**. Aspose‑komponenter körs i samma användarkontext som alla ASP.NET‑applikationer (under ASPNET‑användaren). Därför utgör Aspose‑komponenter **inte** någon säkerhetsrisk. De förbrukar inte heller kritiska systemresurser. Dessutom, när en Aspose‑komponent öppnar ett dokument, körs makron inte automatiskt. Aspose‑komponenter är byggda för att möjliggöra för utvecklare att skapa, manipulera och spara Office‑filer. 

{{% alert color="primary" %}} 

Inga av riskerna som är förknippade med Microsoft Office-paketet gäller för Aspose‑komponenter.

{{% /alert %}} 

## **Stabilitet**
Denna text är ett direkt citat från den tidigare refererade Microsoft‑artikeln: 

> "Office 2000, Office XP och Office 2003 använder Microsoft Windows Installer (MSI)-teknik för att göra installation och självreparation enklare för slutanvändaren. MSI introducerar konceptet ”installera vid första användning”, vilket möjliggör att funktioner kan installeras eller konfigureras dynamiskt vid körning (för systemet, eller oftare för en specifik användare). I en server‑sidomiljö sänker detta både prestandan och ökar sannolikheten för att en dialogruta kan dyka upp som ber användaren godkänna installationen eller tillhandahålla en lämplig installations‑disk. Även om det är avsett att öka Office‑produktens motståndskraft för slutanvändare, är Office‑implementeringen av MSI‑funktioner kontraproduktiv i en server‑sidomiljö. Dessutom kan Office:s stabilitet generellt inte garanteras när den körs på server‑sidan eftersom den inte har designats eller testats för detta bruk. Att använda Office som en tjänstekomponent på en nätverksserver kan minska stabiliteten på den maskinen och som en följd hela ditt nätverk. Om du planerar att automatisera Office på server‑sidan, försök att isolera programmet till en dedikerad dator som inte kan påverka kritiska funktioner och som kan startas om vid behov."

Eftersom Aspose‑komponenter paketeras i en enda DLL måste deras användare aldrig installera ytterligare delar för att de ska fungera. Aspose‑komponenter används endast av .NET‑applikationer och det finns ingen del av komponentkoden som är avsedd att vänta på en mänsklig respons. 

{{% alert color="primary" %}} 

Aspose‑komponenter har testats noggrant och bekräftats vara mycket stabila. Aspose‑komponenter används av [företag](http://www.aspose.com/Corporate/Aspose/Customerlist.html) såsom **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** och många andra ledande organisationer inom flera branscher och områden. 

{{% /alert %}} 

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från en Microsoft‑artikel: 

> "Komponenter på server‑sidan måste vara mycket återanvändbara, multitrådade COM‑komponenter med minimal overhead och hög genomströmning för flera klienter. Office‑program är i nästan alla avseenden exakt motsatsen. De är icke‑återanvändbara, STA‑baserade automationsservrar som är designade för att tillhandahålla diverse men resursintensiv funktionalitet för en enskild klient. De erbjuder liten skalbarhet som en server‑sidolösning och har fasta begränsningar för viktiga element, såsom minne, som inte kan ändras via konfiguration. Dessutom använder de globala resurser (såsom minnesmappade filer, globala tillägg eller mallar, och delade automationsservrar) vilket kan begränsa antalet instanser som kan köras samtidigt och leda till race‑förhållanden om de konfigureras i en miljö med flera klienter. Utvecklare som planerar att köra mer än en instans av något Office‑program samtidigt måste överväga poolning eller seriell åtkomst till Office‑programmet för att undvika potentiella dödlägen eller datakorruption."

Aspose‑komponenter är otroligt skalbara och blixtsnabba. Office‑program var inte designade för att användas samtidigt av hundratals eller tusentals användare, men Aspose‑komponenter är exakt skapade för det. Våra komponenter är en äkta .NET‑lösning. 

{{% alert color="primary" %}} 

Aspose‑komponenters prestanda är felfri på en enda server (drivande en enskild applikation) eller på en lastbalanserad webbform (drivande en företagsomfattande applikation).

{{% /alert %}} 

## **Pris**
När en applikation använder Microsoft Office Automation måste en kopia av Microsoft Office köpas för varje maskin som kör appen. Det finns många tillfällen då en applikation kan behöva skapa eller manipulera en Office‑fil, men processen kräver inte Microsoft Office. 

{{% alert color="primary" %}} 

Aspose erbjuder en mycket [kostnadseffektiv](https://purchase.aspose.com/) och royalty‑fri omdistributionslicens som möjliggör distribution till ett obegränsat antal användare utan licensbekymmer. 

{{% /alert %}} 

Vid skapande av webb‑baserade applikationer är det viktigt att komma ihåg att Microsoft Office Automation‑komponenter varken är prissatta eller licensierade för server‑sidolösningar. Därför finns det ingen bra licenslösning för distribution av webbapplikationer som använder Microsoft Office‑komponenter. Aspose, å andra sidan, erbjuder en mycket [kostnadseffektiv](https://purchase.aspose.com/) lösning även för serverbaserade applikationer. 

## **Funktioner**
Aspose‑komponenter erbjuder allt som behövs för att hantera Office‑filer och mycket mer. Vi designade dem baserat på vår filosofi att hjälpa utvecklare att uppnå bästa möjliga resultat med minst möjliga ansträngning. 

{{% alert color="primary" %}} 

Till skillnad från Office Automation tillhandahåller Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. 

{{% /alert %}} 

Till exempel ger [Aspose.Cells](https://products.aspose.com/cells/net/) utvecklare möjlighet att importera data från en **DataTable** eller **DataView** direkt till en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/net/) erbjuder en liknande funktion som låter utvecklare fylla i ett Word‑dokument (det vill säga Mail Merge) direkt från ett .NET‑datobjekt. [Varje komponent](https://products.aspose.com/total/net/) i Aspose‑familjen erbjuder sin egen uppsättning unika och kraftfulla funktioner. 

Det bästa med att köpa en Aspose‑komponent är att få tillgång till våra utvecklingsteam. Till exempel, om du använder Office Automation‑objekt och behöver vissa funktioner, är chansen att dessa funktioner läggs till mycket, mycket liten. Med Aspose‑komponenter är dock situationen annorlunda. 

{{% alert color="primary" %}} 

Våra utvecklingsteam förstår att om det finns en funktion som ditt företag behöver, är det stor sannolikhet att andra företag också behöver samma funktion. Även om vi vet att vi inte kan implementera varje begärd funktion, strävar vi efter att lägga till så många funktioner som möjligt baserat på feedback från våra kunder. 

{{% /alert %}} 

Våra team är alltid öppna och flexibla när de ger hjälp – och detta är anledningen till att Aspose‑komponenter har utvecklats till att bli så kraftfulla som de är idag. 

## **Slutsats**
{{% alert color="primary" %}} 

Även om den här artikeln tog upp några av de viktigaste punkterna varför Aspose‑komponenter är ett bättre val än Office Automation, måste du förstå att det finns många, många fler fördelar. Vi gick bara igenom några av de största fördelarna. 

Dessutom erbjuder alla Aspose‑produkter och komponenter en riskfri, utan förpliktelse [utvärderingsversion](https://downloads.aspose.com/slides/sv/net). Vi uppmuntrar dig att utnyttja utvärderingen för att se vad Aspose kan göra för dina applikationer eller ditt företag. 

{{% /alert %}}