---
title: Varför inte automatisering
type: docs
weight: 170
url: /sv/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "Upptäck varför Office-automatisering är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare, snabbare presentationhantering för PowerPoint och OpenDocument."
---
## **Introduktion**

Det finns flera anledningar till att Aspose‑komponenter är ett bättre alternativ till automation. Några av de viktigaste anledningarna är:

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

Aspose‑komponenter är helt självständiga och är inte associerade med, auktoriserade av, sponsrade av eller på annat sätt godkända av Microsoft Corporation.

- Varför ska vi använda Aspose‑produkter istället för Microsoft Office Automation?

För det första finns det många [fördelar du får när du använder Aspose.Slides](/slides/sv/java/product-overview/).

För det andra avråder Microsoft själva starkt **från** att använda Office Automation i mjukvarulösningar.

## **Säkerhet**

Följande är ett direkt citat från en Microsoft‑artikel:

*"Office‑applikationer var aldrig avsedda för användning på serversidan och tar därför inte hänsyn till säkerhetsproblemen som distribuerade komponenter står inför. Office autentiserar inte inkommande förfrågningar och skyddar dig inte från att oavsiktligt köra makron eller starta en annan server som kan köra makron från din serversidokod. Öppna inte filer som laddas upp till servern från en anonym webb! Baserat på de säkerhetsinställningar som senast satts kan servern köra makron under en Administratörs‑ eller Systemkontext med fulla behörigheter och äventyra ditt nätverk! Dessutom använder Office många klient‑sidokomponenter (såsom Simple MAPI, WinInet, MSDAIPP) som kan cacha klientautentiseringsinformation för att påskynda bearbetning. Om Office automatiseras på serversidan kan en instans betjäna mer än en klient, och eftersom autentiseringsinformation har cachats för den sessionen är det möjligt att en klient kan använda den cachade referensen för en annan klient och därmed få otilldelade åtkomstbehörigheter genom att imitera andra användare."*

Aspose‑produkter är mycket säkra. Aspose‑komponenter utgör ingen potentiell risk för kritiska systemresurser. Dessutom, när ett dokument öppnas av en Aspose‑komponent, körs makron inte automatiskt. Aspose‑komponenter bygger på att låta utvecklare skapa, manipulera och spara Office‑filer. Inga av de risker som är förknippade med Microsoft Office‑paketet är inneboende i Aspose‑komponenter.

## **Stabilitet**
Följande är ett direkt citat från en Microsoft‑artikel:

*"Office 2000, Office XP och Office 2003 använder Microsoft Windows Installer (MSI)‑teknik för att göra installation och självreparation enklare för slutanvändaren. MSI introducerar konceptet ”install on first use”, vilket tillåter funktioner att installeras eller konfigureras dynamiskt vid körning (för systemet, eller oftare för en viss användare). I en server‑sidomiljö fördröjer detta både prestanda och ökar sannolikheten att en dialogruta kan visas som ber användaren godkänna installationen eller ange ett lämpligt installations‑disk. Även om det är avsett att öka Office‑produktens motståndskraft som ett slutanvändar‑program, är Office‑implementationen av MSI‑funktioner kontraproduktiv i en server‑sidomiljö. Vidare kan stabiliteten i Office i allmänhet inte garanteras när det körs på serversidan eftersom det inte har designats eller testats för detta användningssätt. Att använda Office som en tjänstekomponent på en nätverksserver kan minska stabiliteten på den maskinen och som en följd hela nätverket. Om du planerar att automatisera Office på serversidan, försök isolera programmet till en dedikerad dator som inte kan påverka kritiska funktioner och som kan startas om vid behov."*

Aspose‑komponenter har testats grundligt och är extremt stabila. Aspose‑komponenter används av [företag](https://about.aspose.com/customers/) såsom **Bank of America** och många fler.

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från en Microsoft‑artikel:

*"Server‑sidokomponenter måste vara högst återanvändbara, flertrådade COM‑komponenter med minimal overhead och hög genomströmning för flera klienter. Office‑applikationer är i nästan alla avseenden exakt motsatsen. De är icke‑återanvändbara, STA‑baserade automationsservrar som är designade för att tillhandahålla mångsidig men resursintensiv funktionalitet för en enskild klient. De erbjuder liten skalbarhet som en server‑sidolösning och har fasta begränsningar för viktiga element, såsom minne, som inte kan ändras via konfiguration. Dessutom använder de globala resurser (såsom minnes‑mappade filer, globala tillägg eller mallar, och delade automationsservrar), vilket kan begränsa antalet instanser som kan köras samtidigt och leda till race‑conditions om de konfigureras i en miljö med flera klienter. Utvecklare som planerar att köra mer än en instans av någon Office‑applikation samtidigt måste överväga ***Pooling*** eller ***Serializing Access*** till Office‑applikationen för att undvika potentiella ***Deadlocks*** eller ***Data Corruption***."*

Aspose‑komponenter är mycket skalbara och blixtsnabba. Office‑applikationer var inte designade för att användas samtidigt av hundratals eller tusentals användare. Aspose‑komponenter är däremot specifikt byggda för detta. Våra komponenter fungerar felfritt både på en enskild server, som drivkraft för en enda applikation, eller på en lastbalanserad webbserverfarm som driver en företagsomfattande applikation.

## **Pris**
När en applikation använder Microsoft Office Automation måste en kopia av Microsoft Office köpas för varje maskin som kör applikationen. Det finns många situationer där en applikation kan behöva skapa eller manipulera en Office‑fil utan att användaren behöver ha Microsoft Office. Aspose erbjuder en mycket [kostnadseffektiv](https://purchase.aspose.com/) och royalty‑fri omfördelningslicens som möjliggör distribution till ett obegränsat antal användare utan licensproblem.

När du skapar webbaserade applikationer är det viktigt att veta att Microsoft Office Automation‑komponenter varken är prissatta eller licensierade för server‑sidolösningar; därför finns ingen bra licenslösning för att distribuera webbapplikationer som använder Microsoft Office‑komponenter. Aspose erbjuder en mycket kostnadseffektiv lösning för server‑baserade applikationer också.

## **Funktioner**
Aspose‑komponenter tillhandahåller allt som behövs för att hantera Office‑filer samt mycket mer. De är designade med filosofin att låta utvecklare uppnå bästa resultat med minsta möjliga arbete. Till skillnad från Office Automation erbjuder Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. Till exempel erbjuder [Aspose.Cells](https://products.aspose.com/cells/java/) utvecklare möjlighet att importera data från en **DataTable** eller **DataView** direkt till en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/java/) erbjuder en liknande funktion som låter utvecklare fylla i ett Word‑dokument (det vill säga Mail Merge). [Varje komponent](https://products.aspose.com/total/java/) i Aspose‑familjen har sin egen uppsättning unika och kraftfulla funktioner.

Det bästa med att köpa en Aspose‑komponent (eller komponentpaket som [Aspose.Total](https://products.aspose.com/total/java/)) är tillgången till våra utvecklingsteam. Våra utvecklingsteam inser att om det finns en funktion som ditt företag behöver, så behövs den sannolikt även av andra företag. Även om inte alla funktionsförfrågningar kan genomföras, försöker våra team vara mycket öppna och flexibla när de ger stöd. Detta tankesätt har hjälpt Aspose‑komponenter att bli så kraftfulla som de är. Om det finns ytterligare funktioner du önskar från Office Automation‑objekt, är chansen att de blir tillagda mycket, mycket låg.

## **Slutsats**
{{% alert color="info" title="Obs" %}}

Medan den här artikeln har behandlat många av de viktigaste punkterna om varför Aspose‑komponenter är ett bättre val än Office Automation, finns det många, många fler. Den här artikeln fokuserar främst på de mest centrala punkterna. Alla de olika Aspose‑komponenterna erbjuder en riskfri, utan förpliktelse [Utvärderingsversion](https://releases.aspose.com/slides/sv/java/). Vi uppmuntrar dig att utnyttja den utvärderingen för att bättre se vad Aspose kan göra för dina applikationer.

{{% /alert %}}