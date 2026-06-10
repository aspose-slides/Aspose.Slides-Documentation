---
title: Hogyan futtassuk a háttérfeladatokat az ASP.NET Core-ban
type: docs
weight: 300
url: /hu/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- háttérfeladat
- háttérfeldolgozás
- hosztolt szolgáltatás
- háttérmunkavégző
- feladat sor
- aszinkron feladatütemezés
- szerveroldali fájlfeldolgozás
- előrehaladás nyomon követése
- állapot lekérdezés
- SignalR értesítések
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- skálázható architektúra
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Futtass háttérfeladatokat az ASP.NET Core-ban Hosztolt Szolgáltatásokkal, feladatsorokkal és állapotfrissítésekkel – dolgozd fel és konvertáld a PPT, PPTX és ODP fájlokat az Aspose.Slides használatával."
---
## **Bevezetés**

A fájlfeldolgozás (peldaul egy bemutató exportálása PDF-be) tipikus kiszolgalooldali feladat. Ha a kérések kezelőjében (amíg a kliens vár) hajtjuk végre, a következő hátrányokkal jár:

- *Gyenge felhasználói felület.* Az oldal lefagy, a felhasználónak a végeredményre kell várnia. Az oldal újratöltése megszakítja a feladatot.
- *Műveleti időkorlátok.* Nem garantálható, hogy a feldolgozás egy meghatározott időn belül befejeződik, ezért a felhasználó gyakran "operation timeout" üzenetet lát.
- *Alacsony áteresztőképesség és skálázhatóság.* Az ASP.NET Core úgy lett tervezve, hogy sok kérést aszinkron módon tudjon kezelni. CPU-intenzív, hosszú futású feladatok blokkolják a szálakat, csökkentve a szerver áteresztőképességét.
- *Gyenge hibatűrés.* Ha valami hiba történik egy hosszú futású feladat közben (peldaul kapcsolódási hiba), a feldolgozás sikertelen, és újra kell kezdeni a teljes folyamatot.

Egy [jobb megközelítés](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) az, hogy a feladatot aszinkron módon ütemezzük, a háttérben dolgozzuk fel, és a kész eredményt adjuk vissza.

Ebben a modellben a felhasználó láthatja az aktuális állapotot (és elhagyhatja vagy újratöltheti az oldalt), a szerver erőforrásait hatékonyan lehet skálázni és rugalmasan hangolni, valamint alkalmazható egy újrapróbálkozási szabály.

Egy tipikus háttérfeldolgozási megoldás tartalmazza:

1. Egy API-t a feladat ütemezéséhez.
1. Egy API-t a feladat állapotának nyomon követéséhez.
1. Egy háttérmunkavégzőt az ütemezett feladatok feldolgozásához.
1. Egy API-t az eredmény tárolásához és lekérdezéséhez.

## **Háttérfeladat példa**

Ennek a megközelítésnek a bemutatásához tekintsük meg a [minta ASP.NET Core 3.1 webalkalmazást](./BackgroundJobDemo.zip). Az alkalmazás egy oldalt tartalmaz, ahol a felhasználó feltölthet egy bemutatót, majd a **Export to PDF** gombra kattintva a bemutató feltöltődik és egy háttérmunkavégző PDF-be alakítja.

## **Webalkalmazás**

A mintaprojekt (*BackgroundJobDemo* projekt) tartalmazza:

- Fájlfeltöltő oldal (Razor oldal "Upload").
- Folyamatkövető oldal (Razor oldal "Progress" néhány JavaScript-függvénnyel, amelyek ellenőrzik és megjelenítik az állapotot).
- Kontroller (`JobStatusController`), amely a feldolgozási állapotot szolgáltatja (`api/status/{jobId}`).
- Kontroller (`JobResultController`), amely a kiexportált PDF-fájlt adja vissza (`api/result/{id}`).
- Háttérmunkavégző az ASP.NET Core hosting szolgáltatás alapján (lásd a `WorkerService` osztályt).

A Razor oldalak, kontrollerek és a háttérmunkavégző a tényleges munkát a *BackgroundJobDemo.Common* projektben definiált interfészeken keresztül delegálják. A feladatkezelés és -feldolgozás konkrét megvalósításai külön projektekben (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* stb.) találhatók, és a `Startup.ConfigureServices` metódusban cserélhetők ki.

Demo célokra a "Upload" oldal pufferelt modellkötést használ, de nagy fájlok esetén a pufferelés nélküli streaming [ajánlott](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Éles környezetben vegyük figyelembe a megfelelő [biztonsági szempontokat](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). A "Progress" oldal JavaScript-ben kétmásodpercenként (ez az intervallum konfigurálható) kérdezi le az ütemezett feladat állapotát. A lekérdezés gyakori, de összetettebb esetekben valós idejű értesítésekre lehet szükség WebSocketeken keresztül (valós idejű kommunikációk kívül esnek ennek a cikknek a hatókörén). A [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) egyszerű, mégis erőteljes eszköz a valós idejű kommunikációhoz.

A háttérmunkavégző szerverfolyamatban történő futtatása kényelmes egyszerű alkalmazásoknál, de [hátrányokkal](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx) jár. Egy robosztusabb és skálázhatóbb megoldás a munkavégző külön folyamatban való futtatása (lásd például a *BackgroundJobDemo.Worker* konzolalkalmazást).

## **Alap megvalósítás**

A *BackgroundJobDemo.Local* projekt egyszerű feladatkezelő megvalósítást nyújt SQLite adatbázissal (az adatbázis útvonalát a `LocalConfig.DbFilePath` állítja be; lásd a `Startup.ConfigureServices`-t). A feltöltött és feldolgozott fájlok a fájlrendszeren tárolódnak (a tároló mappa útvonalát a `LocalConfig.FileStorageFolderPath` adja meg; lásd a `Startup.ConfigureServices`-t). A valóságos alkalmazásokban a jobb hibatűrés és teljesítmény érdekében a feladatütemezést üzenetsorokon keresztül (peldaul RabbitMQ, AWS SQS, Azure Storage Queue) kell megvalósítani.

## **Elosztott megvalósítás Amazon Web Services alapján**

A *BackgroundJobDemo.Aws* projekt az AWS-en történő feladatfeldolgozást valósítja meg, és egy horizontálisan skálázható elosztott architektúrát demonstrál. A következő komponenseket tartalmazza:

- Webalkalmazás - a felhasználóval interakcióba lép és ütemezi a PPTX-PDF exportfeladatokat stb.
- Worker - feldolgozza az exportokat (in-process, out-of-process vagy AWS Lambda).
- Üzenetsor - a feldolgozandó feladatok tárolására szolgál (Amazon SQS).
- Fájl tároló - a feltöltött és feldolgozott fájlok tárolására (Amazon S3).
- Kulcs-érték tároló - a feladat feldolgozási állapotának nyilvántartására (Amazon DynamoDB).

Egy tipikus elosztott architektúra a [üzenetsorokra](https://aws.amazon.com/message-queue/) támaszkodik: a webalkalmazás háttérfeladatokat helyez el a sorba; egy háttérmunkavégző lekéri a feladatokat a sorból és elvégzi a szükséges munkát. Ez szétválasztja a komponenseket, és aszinkron, megbízható feldolgozást tesz lehetővé. A sor garantálja a kézbesítést, és *visibility timeout*-ot használ: amikor egy munkavégző lekér egy üzenetet, az láthatatlan lesz a többi munkavégző számára; csak a feldolgozó munkavégző távolítja el a befejezéskor. Ha a feldolgozás nem fejeződik be a visibility timeout alatt (peldaul hiba vagy hálózati probléma miatt), a feldolgozatlan üzenet újra láthatóvá válik.

A megvalósításunk az [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) teljesen kezelt üzenetsort használ mikro-szolgáltatásokhoz, elosztott rendszerekhez és server-lessz alkalmazásokhoz.

Az üzenetsorok könnyű üzenetekre (peldaul az SQS üzenetméret-korlátja 256 KB) lettek tervezve, ezért egy üzenetnek csak a feladat leírását kell tartalmaznia. A nehéz adatokat (peldaul a feldolgozandó fájlokat) külön kell tárolni, és az üzenetben hivatkozni rájuk. Az [Amazon S3](https://aws.amazon.com/s3/) szolgál a feltöltött és feldolgozott fájlok tárolására.

A feladat eredményeinek ID-s szerinti megőrzéséhez és lekérdezéséhez kulcs-érték tároló szükséges. A példa az [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)-t használja, amely gyors és rugalmas NoSQL adatbázis-szolgáltatás.

Az AWS-es demó futtatásához:

1. Azonos AWS régióban hozzon létre és konfiguráljon:
   1. egy SQS sort,
   1. egy S3 bucketet,
   1. egy DynamoDB táblát.
1. Kapcsolja a webalkalmazást ezekhez a szolgáltatásokhoz a `Startup.ConfigureServices`-ban lévő *AddAws* hívásával, megadva az SQS sor URL-jét, az S3 bucket nevét, a DynamoDB tábla nevét és az AWS régiót.

## **Hivatkozások**

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Real-time ASP.NET with SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Message Queues](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)