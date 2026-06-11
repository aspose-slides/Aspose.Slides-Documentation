---
title: Varför inte automatisering
type: docs
weight: 50
url: /sv/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Upptäck varför Office-automation är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare, snabbare bearbetning av presentationer för PowerPoint och OpenDocument."
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
- Varför är Aspose-komponenter ett mycket bättre alternativ än Microsoft Office Automation?

Det finns två frågor som vi hör oftast här på Aspose :

- Kräver era produkter att Microsoft Office är installerat för att de ska kunna köras?

Det korta enkla svaret är **NEJ**. Aspose och Aspose-komponenter är helt oberoende och är inte associerade med, eller godkända, sponsrade eller på annat sätt godkända av Microsoft Corporation.

- Varför bör vi använda Aspose-produkter istället för att använda Microsoft Office Automation?

Det kortaste svaret vi kan ge är att det finns många anledningar, där den främsta är att *Microsoft själva starkt avråder från Office Automation i mjukvarulösningar: [Microsoft Article

## **Säkerhet**
Följande är ett direkt citat från den ovan refererade Microsoft Article : 
*"Office-applikationer var aldrig avsedda för användning på serversidan och tar därför inte hänsyn till säkerhetsproblem som distribuerade komponenter ställs inför. Office autentiserar inte inkommande förfrågningar och skyddar dig inte mot att oavsiktligt köra makron eller starta en annan server som kan köra makron från din server‑sidokod. Öppna inte filer som laddas upp till servern från en anonym webb! Baserat på de säkerhetsinställningar som senast sattes kan servern köra makron under en Administratörs‑ eller Systemkontext med fulla rättigheter och äventyra ditt nätverk! Dessutom använder Office många klient‑sidokomponenter (såsom Simple MAPI, WinInet, MSDAIPP) som kan cachea klientautentiseringsinformation för att snabba upp bearbetningen. Om Office automatiseras på serversidan kan en instans betjäna mer än en klient, och eftersom autentiseringsinformationen har cachelagrats för den sessionen är det möjligt att en klient kan använda den cachelagrade inloggningen för en annan klient och på så sätt erhålla obehöriga åtkomsträttigheter genom att imitera andra användare."*

Aspose-produkter är mycket säkra. Därför utgör Aspose‑komponenter ingen potentiell risk för kritiska systemresurser. Dessutom, när ett dokument öppnas av en Aspose‑komponent, körs inte makron automatiskt. Aspose‑komponenter byggdes med målet att låta utvecklare skapa, manipulera och spara Office‑filer. Inga av de risker som är förknippade med Microsoft Office‑paketet är inneboende i Aspose‑komponenter .

## **Stabilitet**
Följande är ett direkt citat från den ovan refererade Microsoft Article : 
*"Office 2000, Office XP och Office 2003 använder Microsoft Windows Installer (MSI)-teknik för att göra installation och självreparation enklare för slutanvändaren. MSI introducerar konceptet \"install on first use\", vilket tillåter funktioner att installeras eller konfigureras dynamiskt vid körning (för systemet, eller oftare för en specifik användare). I en server‑sid miljö sänker detta både prestanda och ökar sannolikheten för att en dialogruta kan visas som ber användaren godkänna installationen eller tillhandahålla en lämplig installationsdisk. Även om det är avsett att öka Office:s motståndskraft som en slutanvändarprodukt, är Office:s implementering av MSI‑funktioner kontraproduktiv i en server‑sid miljö. Dessutom kan Office:s stabilitet i allmänhet inte garanteras när det körs på en server eftersom det inte har designats eller testats för en sådan användning. Att använda Office som en tjänstekomponent på en nätverksserver kan minska stabiliteten på den maskinen och som en följd hela ditt nätverk. Om du planerar att automatisera Office på en server, försök isolera programmet till en dedikerad dator som inte kan påverka kritiska funktioner och som kan startas om efter behov."*

Eftersom Aspose‑komponenter paketeras i en enda DLL kommer det aldrig att behövas installera några ytterligare delar eller komponenter för att de ska fungera. Aspose‑komponenter används endast av C++‑applikationer och det finns ingen del av komponentkoden som är avsedd att vänta på ett mänskligt svar. Aspose‑komponenter har testats grundligt och är extremt stabila. Aspose‑komponenter används av [Companies](https://about.aspose.com/customers) såsom: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** och många fler.

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från den ovan refererade Microsoft Article :
*"Server‑sidkomponenter måste vara starkt återinträde, flertrådade COM‑komponenter med minimal overhead och hög genomströmning för flera klienter. Office‑applikationer är i nästan alla avseenden exakt motsatsen. De är icke‑återinträde, STA‑baserade Automationsservrar som är avsedda att erbjuda diversifierad men resursintensiv funktionalitet för en enda klient. De erbjuder lite skalbarhet som en server‑sidlösning och har fasta gränser för viktiga element, såsom minne, som inte kan ändras via konfiguration. Dessutom använder de globala resurser (såsom minnesmappade filer, globala tillägg eller mallar samt delade Automationsservrar), vilket kan begränsa antalet instanser som kan köras samtidigt och leda till race‑förhållanden om de konfigureras i en miljö med flera klienter. Utvecklare som planerar att köra mer än en instans av någon Office‑applikation samtidigt måste överväga poolning eller seriell åtkomst till Office‑applikationen för att undvika potentiella dödlägen eller datakorruption."*

Aspose‑komponenter är mycket skalbara och blixtsnabba. Office‑applikationer var inte designade för att användas samtidigt av hundratals eller tusentals användare. Aspose‑komponenter är däremot avsedda just för det. Våra komponenter är en äkta C++‑lösning och fungerar felfritt både på en ensam server som driver en enstaka applikation eller på en lastbalanserad webbform som driver en företagsomfattande applikation.

## **Pris**
När en applikation använder Microsoft Office Automation, måste en kopia av Microsoft Office köpas för varje maskin som kör applikationen. Det finns många tillfällen då en applikation kan behöva skapa eller manipulera en Office‑fil utan att användaren behöver ha Microsoft Office. Aspose erbjuder en mycket [Cost Effective](https://purchase.aspose.com/) och royalty‑fri omdistributionslicens som möjliggör distribution till ett obegränsat antal användare utan licensproblem. När man skapar webb‑baserade applikationer är det viktigt att veta att Microsoft Office Automation‑komponenter varken prissätts eller licensieras för server‑sidlösningar; därför finns det ingen bra licenslösning för att distribuera webbapplikationer som använder Microsoft Office‑komponenter. Aspose erbjuder också en mycket [Cost Effective](https://purchase.aspose.com/) lösning för server‑baserade applikationer.

## **Funktioner**
Aspose‑komponenter tillhandahåller allt som behövs för att hantera Office‑filer och mer därtill. De är utformade med filosofin att låta utvecklare uppnå bästa resultat med så lite arbete som möjligt. Till skillnad från Office Automation erbjuder Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. Till exempel erbjuder [Aspose.Cells](https://products.aspose.com/cells/cpp/) utvecklare möjlighet att importera data från en **DataTable**‑ eller **DataView**‑struktur direkt till en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/net/) har en liknande funktion som låter utvecklare fylla i ett Word‑dokument (dvs. kopplad utskickning) direkt från vilket C++‑dataobjekt som helst. [Every Component](https://products.aspose.com/total/cpp/) i Aspose‑familjen erbjuder sin egen uppsättning unika och kraftfulla funktioner. Det bästa med att köpa en Aspose‑komponent är tillgången till våra utvecklingsteam. Våra team inser att om det finns en funktion som ditt företag behöver, så kommer sannolikt även andra företag att behöva den. Även om inte varje funktionsbegäran kan implementeras försöker våra team vara mycket öppna och flexibla när de ger stöd. Detta tänkesätt har gjort att Aspose‑komponenter har blivit så kraftfulla. Om det finns ytterligare funktioner du behöver från Office Automation‑objekt, är dina chanser att få dem tillagda mycket, mycket låga.

## **Slutsats**
{{% alert color="primary" %}} 

Medan den här artikeln har täckt många av de viktigaste anledningarna till varför Aspose‑komponenter är ett bättre val än Office Automation, finns det många, många fler. Den här artikeln fokuserar främst på de mest centrala punkterna. Alla de olika Aspose‑komponenterna erbjuder en riskfri, utan förpliktelse [Evaluation Version](https://downloads.aspose.com/slides/sv/cpp). Vi uppmuntrar dig att utnyttja den [Evaluation](https://downloads.aspose.com/slides/sv/cpp) för att bättre se vad Aspose kan göra för dina applikationer.