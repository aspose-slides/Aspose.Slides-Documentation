---
title: Prezentációk mentése Olvasásvédett módban Java-val
linktitle: Olvasásvédett prezentáció
type: docs
weight: 30
url: /hu/java/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "A PowerPoint fájlok (PPT, PPTX) betöltése és mentése csak olvasásra módban az Aspose.Slides for Java segítségével, pontos diavetítéseket biztosítva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette az **Always Open Read-Only** beállítást, amely a felhasználók által a prezentációk védelmére használható lehetőségek egyike. Érdemes lehet ezt az Olvasásvédett beállítást használni egy prezentáció védelmére, ha

- meg akarod akadályozni a véletlen szerkesztéseket, és a prezentáció tartalmát biztonságban szeretnéd tartani.  
- szeretnéd jelezni a felhasználóknak, hogy a megadott prezentáció a végleges változat.

Miután kiválasztottad a **Always Open Read-Only** opciót egy prezentációhoz, a felhasználók a prezentáció megnyitásakor a **Read-Only** ajánlást látják, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások elkerülése érdekében a szerző ezt a fájlt csak olvasásra állította be.*

A **Read-Only** ajánlás egy egyszerű, de hatékony elrettentő eszköz, amely megakadályozza a szerkesztést, mivel a felhasználóknak fel kell oldaniuk azt, mielőtt szerkeszthetnék a prezentációt. Ha nem szeretnéd, hogy a felhasználók változtatásokat hajtsanak végre, és ezt udvariasan szeretnéd közölni, a **Read-Only** ajánlás jó lehetőség lehet számodra.  

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitnak meg – amely nem támogatja a legújabb funkciót – a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normál módon nyílik meg).

## **Olvasásvédett mód alkalmazása**

Az Aspose.Slides for Java lehetővé teszi, hogy egy prezentációt **Read-Only** állapotba állíts, ami azt jelenti, hogy a felhasználók (a prezentáció megnyitása után) a **Read-Only** ajánlást látják. Az alábbi példa kódrészlet megmutatja, hogyan állítható be egy prezentáció **Read-Only** módra Java‑ban az Aspose.Slides használatával:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
**Megjegyzés**: A **Read-Only** ajánlás csupán arra szolgál, hogy elriassza a szerkesztést vagy megakadályozza a véletlen módosításokat egy PowerPoint‑prezentációban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyen eltávolíthatja az Olvasásvédett beállítást. Ha komolyan meg kell akadályoznod a jogosulatlan szerkesztést, jobb, ha [szigorúbb védelmet alkalmazol, amely titkosítást és jelszavakat is tartalmaz](https://docs.aspose.com/slides/hu/java/password-protected-presentation/). 
{{% /alert %}} 

## **Gyakran ismételt kérdések**

**Miért különbözik a „Read-Only recommended” a teljes jelszavas védelemtől?**

A „Read-Only recommended” csak egy javaslatot jelenít meg a fájl olvasásvédett módban történő megnyitására, és könnyen megkerülhető. A [jelszavas védelem](/slides/hu/java/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

**A „Read-Only recommended” kombinálható-e vízjelekkel a szerkesztés további elriasztására?**

Igen. Az ajánlás párosítható a [vízjelekkel](/slides/hu/java/watermark/) vizuális elrettentőként; különálló mechanizmusok, amelyek jól együttműködnek.

**Még egy makró vagy külső eszköz módosíthatja a fájlt, ha az ajánlás be van kapcsolva?**

Igen. Az ajánlás nem akadályozza a programozott módosításokat. Az automatizált szerkesztések megakadályozásához használd a [jelszavakat és titkosítást](/slides/hu/java/password-protected-presentation/).

**Hogyan viszonyul a „Read-Only recommended” az `isEncrypted` és `isWriteProtected` metódusokhoz?**

Más jelzések. A „Read-Only recommended” egy lágy, opcionális felhívás; a [isWriteProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/protectionmanager/#isWriteProtected--) és a [isEncrypted](https://reference.aspose.com/slides/hu/java/com.aspose.slides/protectionmanager/#isEncrypted--) tényleges írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavakon vagy titkosításon alapulnak.