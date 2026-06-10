---
title: Prezentációk mentése csak olvasási módban .NET-ben
linktitle: Olvasás‑csak prezentáció
type: docs
weight: 30
url: /hu/net/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Töltse be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasási módban az Aspose.Slides for .NET segítségével, pontos diavakolatot biztosítva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, mint a felhasználók által a bemutatók védelmére használható lehetőségek egyikét. Ezt a Read‑Only módot a következő esetekben érdemes használni a bemutató védelmére, ha

- Meg akarja előzni a véletlen szerkesztéseket, és a bemutató tartalmát biztonságban tartani. 
- Szeretné jelezni a felhasználóknak, hogy a megadott bemutató a végleges verzió. 

Miután kiválasztotta a **Always Open Read-Only** opciót egy bemutatóhoz, a felhasználók a bemutató megnyitásakor láthatják a **Read-Only** ajánlást, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások megelőzése érdekében a szerző úgy állította be a fájlt, hogy csak olvasásra legyen megnyitva.*

A **Read-Only** ajánlás egy egyszerű, ugyanakkor hatékony elriasztó, amely a szerkesztést visszatartja, mivel a felhasználóknak fel kell egy feladatot végrehajtaniuk a javaslat eltávolításához, mielőtt szerkeszthetnék a bemutatót. Ha nem szeretné, hogy a felhasználók változtatásokat hajtsanak végre a bemutatón, és ezt udvarias módon szeretné jelezni, akkor a **Read-Only** ajánlás jó lehetőség lehet. 

> Ha egy **Read-Only** védelemmel ellátott bemutatót egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg — amely nem támogatja a nemrég bevezetett funkciót — a **Read-Only** ajánlást figyelmen kívül hagyják (a bemutató normál módon nyílik meg).

## **Olvasás‑csak mód alkalmazása**

Az Aspose.Slides for .NET lehetővé teszi, hogy egy bemutatót **Read-Only** módra állítson, ami azt jelenti, hogy a felhasználók (a bemutató megnyitása után) látják a **Read-Only** ajánlást. Ez a példakód bemutatja, hogyan állítható be egy bemutató **Read-Only** módra C#‑ban az Aspose.Slides használatával:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen a szerkesztés visszatartását vagy a felhasználók véletlen módosításainak megállítását szolgálja egy PowerPoint‑bemutatóban. Ha egy motivált személy — aki tudja, mit csinál — szerkeszteni szeretné a bemutatót, könnyedén eltávolíthatja a Read‑Only beállítást. Ha valóban meg kell akadályozni az illetéktelen szerkesztést, jobb, ha [szigorúbb védelmet használ, amely titkosítást és jelszavakat foglal magában](https://docs.aspose.com/slides/hu/net/password-protected-presentation/). 

{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl olvasás‑csak módban történő megnyitására, és könnyen megkerülhető. [Jelszóvédelem](/slides/hu/net/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további visszatartása érdekében?**

Igen. Az ajánlást párosíthatja [vízjelekkel](/slides/hu/net/watermark/) vizuális elriasztóként; különálló mechanizmusok, amelyek jól együtt működnek.

**Módosíthat még egy makró vagy külső eszköz a fájlt, ha az ajánlás be van kapcsolva?**

Igen. Az ajánlás nem akadályozza a programozott módosításokat. Az automatikus szerkesztés megakadályozásához használjon [jelszavakat és titkosítást](/slides/hu/net/password-protected-presentation/).

**Hogyan kapcsolódik a 'Read-Only recommended' a 'IsEncrypted' és az 'IsWriteProtected' jelzőkhöz?**

Eltérő jelek. A 'Read-Only recommended' egy enyhe, opcionális felkérés; az [IsWriteProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/iswriteprotected/) és az [IsEncrypted](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/isencrypted/) tényleges írási vagy olvasási korlátozásra utal, amelyek jelszavaktól vagy titkosítástól függenek.