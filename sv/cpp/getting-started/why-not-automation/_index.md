---
title: Varför inte automation
type: docs
weight: 50
url: /sv/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Upptäck varför Office-automation är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare, snabbare bearbetning av presentationer för PowerPoint och OpenDocument."
---
## **Introduktion**

Det finns flera anledningar till att Aspose‑komponenter är ett bättre alternativ till automation. Några av de viktigaste anledningarna är:

- Säkerhet
- Stabilitet
- Skalbarhet/Hastighet
- Pris
- Funktioner

Nedan följer en mer detaljerad förklaring av varje huvudpunkt.

## **Viktiga frågor**
- Varför är Aspose‑komponenter ett mycket bättre alternativ än Microsoft Office Automation?

Det finns två frågor som vi hör oftast här på Aspose:

- Kräver era produkter att Microsoft Office är installerat för att de ska kunna köras?

Det korta, enkla svaret är **NEJ**. Aspose och Aspose‑komponenter är helt oberoende och är inte anslutna till, eller auktoriserade, sponsrade eller på annat sätt godkända av Microsoft Corporation.

- Varför ska vi använda Aspose‑produkter istället för att utnyttja Microsoft Office Automation?

Det kortaste svaret vi kan ge är att det finns många anledningar, där den viktigaste är att *Microsoft själva starkt avråder från Office Automation i mjukvarulösningar: [Microsoft Article

## **Säkerhet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln :

*"Office‑programvaror var aldrig avsedda för server‑sida, och tar därför inte hänsyn till de säkerhetsproblem som distribuerade komponenter möter. Office autentiserar inte inkommande förfrågningar och skyddar dig inte från oavsiktlig körning av makron, eller att starta en annan server som kan köra makron, från din server‑sidokod. Öppna inte filer som laddas upp till servern från en anonym webb! Baserat på de säkerhetsinställningar som senast satts kan servern köra makron under en Administratörs‑ eller Systemkontext med fulla privilegier och kompromettera ditt nätverk! Dessutom använder Office många klient‑sidokomponenter (såsom Simple MAPI, WinInet, MSDAIPP) som kan cacha autentiseringsinformation för att snabba upp bearbetningen. Om Office automatiseras på serversidan kan en instans betjäna mer än en klient, och eftersom autentiseringsinformation har cachats för den sessionen, är det möjligt att en klient kan använda den cachade kredentialen från en annan klient och därigenom erhålla åtkomstbehörigheter som inte beviljats genom att imitera andra användare."*

Aspose‑produkter är mycket säkra. Därför utgör inte Aspose‑komponenter någon potentiell risk för viktiga systemresurser. Dessutom körs makron inte automatiskt när ett dokument öppnas av en Aspose‑komponent. Aspose‑komponenter byggdes med målet att låta utvecklare skapa, manipulera och spara Office‑filer. Inga av de risker som är förknippade med Microsoft Office‑paketet är inneboende i Aspose‑komponenter .

## **Stabilitet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln :

*"Office 2000, Office XP och Office 2003 använder Microsoft Windows Installer (MSI)-teknik för att göra installation och självreparation enklare för slutanvändaren. MSI introducerar konceptet ”install on first use”, vilket gör att funktioner kan installeras eller konfigureras dynamiskt vid körning (för systemet, eller oftare för en viss användare). I en server‑sidomiljö sänker detta både prestandan och ökar sannolikheten att en dialogruta kan visas som ber användaren godkänna installationen eller tillhandahålla en lämplig installations‑disk. Även om den är avsedd att öka Office‑produktens motståndskraft för slutanvändare, är Office‑implementeringen av MSI‑funktioner kontraproduktiv i en server‑sidomiljö. Dessutom kan inte Office‑s stabilitet i allmänhet garanteras när det körs på servrar eftersom det inte har designats eller testats för sådan användning. Att använda Office som en tjänstekomponent på en nätverksserver kan minska stabiliteten hos den maskinen och därmed hela ditt nätverk. Om du planerar att automatisera Office på serversidan, försök isolera programmet till en dedikerad dator som inte kan påverka kritiska funktioner och som kan startas om vid behov."*

Eftersom Aspose‑komponenter paketeras i en enda DLL kommer det aldrig att behövas någon ytterligare installation för att de ska fungera. Aspose‑komponenter används endast av C++‑applikationer och det finns ingen del av komponentkoden som är avsedd att vänta på ett mänskligt svar. Aspose‑komponenter har testats noggrant och är extremt stabila. Aspose‑komponenter används av [Companies](https://about.aspose.com/customers) såsom: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** och många, många fler.

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln :

*"Server‑sidokomponenter behöver vara starkt återanropbara, flertrådade COM‑komponenter med minimal overhead och hög genomströmning för flera klienter. Office‑applikationer är i nästan alla avseenden exakt motsatsen. De är icke‑återanropbara, STA‑baserade automatiseringsservrar som är designade för att tillhandahålla mångsidig men resursintensiv funktionalitet för en enda klient. De erbjuder liten skalbarhet som en server‑sidolösning och har fasta begränsningar för viktiga element, såsom minne, som inte kan ändras via konfiguration. Dessutom använder de globala resurser (såsom minnesmappade filer, globala tillägg eller mallar och delade automatiseringsservrar), vilket kan begränsa antalet instanser som kan köras samtidigt och leda till race‑condition‑problem om de konfigureras i en fler‑klientmiljö. Utvecklare som planerar att köra mer än en instans av någon Office‑applikation samtidigt måste överväga poolning eller seriell åtkomst till Office‑applikationen för att undvika potentiella dödlägen eller datakorruption."*

Aspose‑komponenter är mycket skalbara och blixtsnabba. Office‑applikationer var inte designade för att samtidigt användas av hundratals eller tusentals användare. Aspose‑komponenter är däremot byggda för just detta. Våra komponenter är en äkta C++‑lösning och presterar felfritt både på en enskild server som driver en enda applikation eller på en belastningsutjämnad Web‑Form som driver en företagsomfattande applikation.

## **Pris**
När en applikation använder Microsoft Office Automation måste en kopia av Microsoft Office köpas för varje maskin som kör applikationen. Det finns många tillfällen då en applikation kan behöva skapa eller manipulera en Office‑fil utan att användaren behöver ha Microsoft Office. Aspose erbjuder en mycket [Cost Effective](https://purchase.aspose.com/) och royalty‑fri omdistributionslicens som möjliggör distribution till ett obegränsat antal användare utan licensproblem. När du skapar webb‑baserade applikationer är det viktigt att veta att Microsoft Office Automation‑komponenter inte är prissatta eller licensierade för server‑sidolösningar; därför finns ingen bra licenslösning för distribution av webbapplikationer som använder Microsoft Office‑komponenter. Aspose erbjuder också en mycket [Cost Effective](https://purchase.aspose.com/) lösning för serverbaserade applikationer.

## **Funktioner**
Aspose‑komponenter tillhandahåller allt som behövs för att hantera Office‑filer plus mycket mer. De är designade med filosofin att låta utvecklare uppnå bästa resultat med minst möjliga arbete. Till skillnad från Office Automation erbjuder Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. Till exempel erbjuder [Aspose.Cells](https://products.aspose.com/cells/cpp/) utvecklare möjlighet att importera data från en **DataTable** eller **DataView** direkt till en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/net/) erbjuder en liknande funktion som låter utvecklare fylla i ett Word‑dokument (det vill säga mail‑merge) direkt från vilket C++‑dataobjekt som helst. [Every Component](https://products.aspose.com/total/cpp/) i Aspose‑familjen erbjuder sina egna unika och kraftfulla funktioner. Det bästa med att köpa en Aspose‑komponent är tillgången till våra utvecklingsteam. Våra team inser att om det finns en funktion som ditt företag behöver, så kommer sannolikt andra företag också att behöva den. Även om inte varje funktionsförfrågan kan läggas till försöker våra team vara mycket öppna och flexibla när de ger stöd. Detta tankesätt har gjort att Aspose‑komponenter har blivit så kraftfulla som de är. Om det finns ytterligare funktioner du behöver från Office Automation‑objekt, är dina chanser att få dem tillagda mycket, mycket låga.

## **Slutsats**
{{% alert color="primary" %}} 
Medan den här artikeln har täckt många av de viktigaste anledningarna till varför Aspose‑komponenter är ett bättre val än Office Automation, finns det många, många fler. Denna artikel behandlar främst endast de mest centrala punkterna. Alla de olika Aspose‑komponenterna erbjuder en riskfri, utan förpliktelse [Evaluation Version](https://downloads.aspose.com/slides/sv/cpp). Vi uppmuntrar dig att dra nytta av den [Evaluation](https://downloads.aspose.com/slides/sv/cpp) för att bättre se vad Aspose kan göra för dina applikationer.
{{% /alert %}}