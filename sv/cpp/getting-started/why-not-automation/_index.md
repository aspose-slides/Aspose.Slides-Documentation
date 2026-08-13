---
title: Varför inte automatisering
type: docs
weight: 50
url: /sv/cpp/why-not-automation/
keywords:
- automatisering
- Microsoft Office
- jämföra
- säkerhet
- stabilitet
- skalbarhet
- funktioner
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck varför Office-automation är riskabelt för servrar och tjänster, och se hur Aspose.Slides erbjuder säkrare, snabbare presentationer för PowerPoint och OpenDocument."
---
## **Introduktion**

Det finns flera anledningar till att Aspose‑komponenter är ett bättre alternativ till automation. Några av de viktigaste anledningarna är:

- Säkerhet
- Stabilitet
- Skalbarhet/Hastighet
- Pris
- Funktioner

Nedan följer en mer detaljerad förklaring av varje nyckelpunkt.

## **Viktiga frågor**
- Varför är Aspose‑komponenter ett mycket bättre alternativ än Microsoft Office Automation?

Det finns två frågor som vi hör oftast här på Aspose :

- Kräver era produkter att Microsoft Office är installerat för att de ska kunna köras?

Det korta enkla svaret är **NEJ**. Aspose och Aspose‑komponenter är helt oberoende och är inte associerade med, eller auktoriserade, sponsrade eller på annat sätt godkända av Microsoft Corporation.

- Varför ska vi använda Aspose‑produkter istället för att utnyttja Microsoft Office Automation?

Det kortaste svaret vi kan ge är att det finns många anledningar, där den främsta är att *Microsoft själva starkt avråder från Office Automation i mjukvarulösningar: [Microsoft Article

## **Säkerhet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln:

*"Office-applikationer var aldrig avsedda för användning på server-sidan och tar därför inte hänsyn till de säkerhetsproblem som distribuerade komponenter möter. Office autentiserar inte inkommande begäran och skyddar dig inte från att oavsiktligt köra makron, eller starta en annan server som kan köra makron, från din server‑sidokod. Öppna inte filer som laddas upp till servern från en anonym webb! Baserat på de säkerhetsinställningar som senast sattes kan servern köra makron under en administratörs‑ eller systemkontext med fulla rättigheter och kompromettera ditt nätverk! Dessutom använder Office många klient‑sidokomponenter (såsom Simple MAPI, WinInet, MSDAIPP) som kan cacha klientautentiseringsinformation för att snabba upp bearbetningen. Om Office automatiseras på server-sidan kan en instans betjäna mer än en klient, och eftersom autentiseringsinformationen har cachats för den sessionen, är det möjligt att en klient kan använda den cachade credentialen från en annan klient och därigenom få icke‑beviljade åtkomsträttigheter genom att imitera andra användare."*

Aspose‑produkter är mycket säkra. Därför utgör Aspose‑komponenter ingen potentiell risk för kritiska systemresurser. Vidare, när ett dokument öppnas av en Aspose‑komponent körs makron inte automatiskt. Aspose‑komponenter är byggda med målet att låta utvecklare skapa, manipulera och spara Office‑filer. Inga av riskerna som är förknippade med Microsoft Office‑paketet är inneboende i Aspose‑komponenter.

## **Stabilitet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln:

*"Office 2000, Office XP och Office 2003 använder Microsoft Windows Installer (MSI)‑teknik för att göra installation och själv‑reparation enklare för slutanvändaren. MSI introducerar konceptet ”install on first use”, vilket möjliggör att funktioner installeras eller konfigureras dynamiskt vid körning (för systemet, eller oftare för en specifik användare). I en server‑sidomiljö fördröjer detta både prestanda och ökar sannolikheten för att en dialogruta kan visas som ber användaren godkänna installationen eller tillhandahålla en lämplig installations‑disk. Även om det är designat för att öka Office‑produkten resiliency som en slutanvändarprodukt, är Office‑implementeringen av MSI‑funktioner kontraproduktiv i en server‑sidomiljö. Dessutom kan stabiliteten för Office i allmänhet inte garanteras när den körs på server‑sidon eftersom den inte är designad eller testad för detta bruk. Att använda Office som en tjänstekomponent på en nätverksserver kan minska stabiliteten för den maskinen och i förlängningen hela ditt nätverk. Om du planerar att automatisera Office på server‑sidon, försök isolera programmet till en dedikerad dator som inte kan påverka kritiska funktioner, och som kan startas om vid behov."*

Eftersom Aspose‑komponenter paketeras i en enda DLL kommer det aldrig att behövas någon ytterligare installation. Aspose‑komponenter används endast av C++‑applikationer och det finns ingen del av komponentkoden som väntar på mänsklig respons. Aspose‑komponenter har testats grundligt och är extremt stabila. Aspose‑komponenter används av[Företag](https://about.aspose.com/customers) såsom **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** och många fler.

## **Skalbarhet/Hastighet**
Följande är ett direkt citat från den ovan refererade Microsoft‑artikeln:

*"Server‑sidokomponenter måste vara starkt återanvändbara, flertrådade COM‑komponenter med minimal overhead och hög genomströmning för flera klienter. Office‑applikationer är i nästan alla avseenden exakt motsatsen. De är icke‑återanvändbara, STA‑baserade automatiseringsservrar som är designade för att tillhandahålla varierande men resursintensiv funktionalitet för en enda klient. De erbjuder liten skalbarhet som en server‑sidolösning och har fasta gränser för viktiga element, såsom minne, som inte kan ändras via konfiguration. Dessutom använder de globala resurser (såsom minnes‑mappade filer, globala tillägg eller mallar, och delade automatiseringsservrar), vilket kan begränsa antalet instanser som kan köras samtidigt och leda till race‑condition‑problem i en fler‑klient‑miljö. Utvecklare som planerar att köra mer än en instans av någon Office‑applikation samtidigt måste överväga poolning eller seriell åtkomst till Office‑applikationen för att undvika potentiella dödlägen eller datakorruption."*

Aspose‑komponenter är mycket skalbara och blixtsnabba. Office‑applikationer var inte designade för att samtidigt användas av hundratals eller tusentals användare. Aspose‑komponenter är däremot byggda för just detta. Våra komponenter är en sann C++‑lösning och fungerar felfritt både på en enskild server som driver en enda applikation och på en last‑balanserad webb‑form som driver en företagsomfattande applikation.

## **Pris**
När en applikation använder Microsoft Office Automation måste en kopia av Microsoft Office köpas för varje maskin som kör applikationen. Det finns många fall där en applikation behöver skapa eller manipulera en Office‑fil men inte kräver att användaren har Microsoft Office. Aspose erbjuder en mycket [Kostnadseffektiv](https://purchase.aspose.com/) och royalty‑fri omdistributionslicens som möjliggör distribution till ett obegränsat antal användare utan licensbekymmer. Vid skapande av webb‑baserade applikationer är det viktigt att veta att Microsoft Office Automation‑komponenter varken är prissatta eller licensierade för server‑sidolösningar; därför finns det ingen bra licenslösning för att distribuera webbapplikationer som använder Microsoft Office‑komponenter. Aspose erbjuder en mycket [Kostnadseffektiv](https://purchase.aspose.com/) lösning för server‑baserade applikationer också.

## **Funktioner**
Aspose‑komponenter tillhandahåller allt som behövs för att hantera Office‑filer plus mycket mer. De är designade med filosofin att låta utvecklare uppnå största möjliga resultat med minsta möjliga arbete. Till skillnad från Office Automation erbjuder Aspose‑komponenter många kraftfulla och tidsbesparande funktioner. Till exempel erbjuder [Aspose.Cells](https://products.aspose.com/cells/cpp/) utvecklare möjligheten att importera data från en **DataTable** eller **DataView** direkt in i en Excel‑fil. [Aspose.Words](https://products.aspose.com/words/net/) erbjuder en liknande funktion som låter utvecklare fylla ett Word‑dokument (Mail Merge) direkt från ett godtyckligt C++‑dataobjekt. [Every Component](https://products.aspose.com/total/cpp/) i Aspose‑familjen erbjuder sina egna unika och kraftfulla funktioner. Det bästa med att köpa en Aspose‑komponent är tillgången till våra utvecklingsteam. Våra team inser att om det finns en funktion som ditt företag behöver, är det mycket sannolikt att andra företag också kommer att behöva den. Även om inte varje funktionsbegäran kan implementeras, försöker våra team vara mycket öppna och flexibla när de erbjuder stöd. Detta tankesätt har hjälpt Aspose‑komponenter bli så kraftfulla som de är. Om det finns ytterligare funktioner du behöver från Office Automation‑objekt, är sannolikheten att de läggs till mycket, mycket låg.

## **Slutsats**
{{% alert color="info" %}} 

Medan denna artikel har täckt många av de viktigaste punkterna varför Aspose‑komponenter är ett bättre val än Office Automation, finns det många, många fler. Artikeln fokuserar främst på de mest centrala punkterna. Alla de olika Aspose‑komponenterna erbjuder en risk‑fri, utan förpliktelse [Utvärderingsversion](https://downloads.aspose.com/slides/sv/cpp). Vi uppmuntrar dig att utnyttja den [Utvärdering](https://downloads.aspose.com/slides/sv/cpp) för att bättre se vad Aspose kan göra för dina applikationer.
{{% /alert %}}