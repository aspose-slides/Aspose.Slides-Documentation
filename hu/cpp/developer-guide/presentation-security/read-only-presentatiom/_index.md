---
title: Prezentációk mentése csak olvasás módjában C++ használatával
linktitle: Olvasásra korlátozott prezentáció
type: docs
weight: 30
url: /hu/cpp/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Töltsön be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasás módban az Aspose.Slides for C++ segítségével, pontos diavetítéseket biztosítva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019‑ben a Microsoft bevezette az **Always Open Read-Only** beállítást, mint az egyik lehetőséget, amelyet a felhasználók a prezentációik védelmére használhatnak. Ezt a Read‑Only beállítást a következő esetekben érdemes használni a prezentáció védelmére:

- Meg szeretné akadályozni a véletlen szerkesztéseket, és a prezentáció tartalmát biztonságban tartani. 
- Szeretné jelezni a felhasználók felé, hogy a megadott prezentáció a végleges verzió. 

Miután kiválasztja a **Always Open Read-Only** lehetőséget egy prezentációhoz, a felhasználók a prezentáció megnyitásakor a **Read-Only** ajánlást látják, és egy ilyen üzenetet is megjelenhet: *A véletlen változtatások megelőzése érdekében a szerző beállította, hogy a fájl csak olvasásra legyen megnyitva.*

A Read‑Only ajánlás egyszerű, ám hatékony elriasztó, amely megnehezíti a szerkesztést, mivel a felhasználóknak egy lépést kell végrehajtaniuk a eltávolításához, mielőtt szerkeszthetik a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvarias módon szeretné közölni, akkor a Read‑Only ajánlás jó megoldás lehet. 

> Ha egy **Read-Only** védelmet tartalmazó prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** ajánlást figyelmen kívül hagyják (a prezentáció normál módon nyílik meg).

## **Read-Only mód alkalmazása**

Az Aspose.Slides for C++ lehetővé teszi, hogy egy prezentációt **Read-Only** módra állítson be, ami azt jelenti, hogy a felhasználók (miután megnyitották a prezentációt) a **Read-Only** ajánlást látják. Ez a mintakód bemutatja, hogyan állítható be egy prezentáció **Read-Only** módra C++‑ban az Aspose.Slides használatával:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen a szerkesztés elriasztására vagy a felhasználók véletlen módosításainak megakadályozására szolgál egy PowerPoint‑prezentációban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyedén eltávolíthatja a Read‑Only beállítást. Ha komolyan meg kell akadályoznia a jogosulatlan szerkesztést, jobban jár, ha [szigorúbb védelmet használ, amely titkosítást és jelszavakat foglal magában](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **GYIK**

### Hogyan különbözik a 'Read-Only recommended' a teljes jelszóvédelemtől?

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl csak olvasásra történő megnyitására, és könnyen megkerülhető. [Jelszóvédelem](/slides/hu/cpp/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és megfelelő, ha valódi biztonsági szabályozásra van szükség.

### Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztására?

Igen. Az ajánlás kombinálható [vízjelekkel](/slides/hu/cpp/watermark/) vizuális elriasztóként; különálló mechanizmusok, amelyek jól működnek együtt.

### Módosíthat még egy makró vagy külső eszköz a fájlt, ha az ajánlás engedélyezve van?

Igen. Az ajánlás nem akadályozza a programozott módosításokat. Az automatizált szerkesztés megakadályozásához használjon [jelszavakat és titkosítást](/slides/hu/cpp/password-protected-presentation/).

### Hogyan kapcsolódik a 'Read-Only recommended' a 'is encrypted' és 'is write protected' jelzőkhöz?

Eltérő jelek. A 'Read-Only recommended' egy enyhe, opcionális felkérés; [get_IsWriteProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) és [get_IsEncrypted](https://reference.aspose.com/slides/hu/cpp/aspose.slides/protectionmanager/get_isencrypted/) valós írási vagy olvasási korlátozásokat jelölnek, amelyek jelszavaktól vagy titkosítástól függnek.