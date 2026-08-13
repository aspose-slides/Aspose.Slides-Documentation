---
title: Prezentációk mentése csak olvasásra nyitott módban .NET-ben
linktitle: Csak olvasásra nyitott prezentáció
type: docs
weight: 30
url: /hu/net/read-only-presentation/
keywords:
- csak olvasásra
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Töltsön be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasásra nyitott módban az Aspose.Slides for .NET segítségével, pontos diavázlatokat biztosítva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019‑ben a Microsoft bevezetett egy **Mindig olvasásra nyitott** beállítást, amely a felhasználók által a bemutatók védelmére használt lehetőségek egyike. Érdemes lehet ezt az Olvasásra nyitott beállítást használni egy bemutató védelmére, ha

- Szeretné elkerülni a véletlen szerkesztéseket, és a bemutató tartalmát biztonságban tartani. 
- Szeretné jelezni a felhasználóknak, hogy a megadott bemutató a végleges verzió. 

Miután kiválasztja a **Mindig olvasásra nyitott** lehetőséget egy bemutatóhoz, a felhasználók a bemutató megnyitásakor a **Olvasásra nyitott** ajánlást látják, és megjelenhet egy üzenet ebben a formában: *A véletlen módosítások elkerülése érdekében a szerző beállította, hogy a fájl olvasásra nyitott módon nyílik meg.*

Az Olvasásra nyitott ajánlás egy egyszerű, mégis hatékony elriasztó, amely megakadályozza a szerkesztést, mivel a felhasználóknak egy lépést kell végrehajtaniuk annak eltávolításához, mielőtt szerkeszthetnék a bemutatót. Ha nem szeretné, hogy a felhasználók módosítsák a bemutatót, és ezt udvariasan szeretné közölni, akkor az Olvasásra nyitott ajánlás jó lehetőség lehet. 

> Ha egy **Olvasásra nyitott** védelmet tartalmazó bemutatót egy régebbi Microsoft PowerPoint alkalmazásban nyitnak meg – amely nem támogatja a legújabb funkciót – a **Olvasásra nyitott** ajánlást figyelmen kívül hagyják (a bemutató normál módon nyílik meg).

## **Olvasásra nyitott mód alkalmazása**

Az Aspose.Slides for .NET lehetővé teszi, hogy egy bemutatót **Olvasásra nyitott** módba állítson, ami azt jelenti, hogy a felhasználók (miután megnyitották a bemutatót) a **Olvasásra nyitott** ajánlást látják. Ez a mintakód megmutatja, hogyan állítható be egy bemutató **Olvasásra nyitott** módba C#‑ban az Aspose.Slides használatával:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
**Megjegyzés**: A **Olvasásra nyitott** ajánlás egyszerűen arra szolgál, hogy elriassza a szerkesztést vagy megakadályozza a felhasználókat a véletlen módosításokban egy PowerPoint bemutatóban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a bemutatót, könnyen eltávolíthatja az Olvasásra nyitott beállítást. Ha komolyan meg kell előznie az illetéktelen szerkesztést, jobb, ha [szigorúbb védelmet használ, amely titkosítást és jelszavakat is tartalmaz](https://docs.aspose.com/slides/hu/net/password-protected-presentation/). 
{{% /alert %}} 

## **GYIK**

### Hogyan különbözik az 'Olvasásra nyitott ajánlás' a teljes jelszóvédelemtől?
`Olvasásra nyitott ajánlás` csak egy javaslatot jelenít meg a fájl olvasásra nyitott módban történő megnyitására, és könnyen megkerülhető. [Jelszóvédelem](/slides/hu/net/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

### Kombinálható-e az 'Olvasásra nyitott ajánlás' vízjelekkel a szerkesztés további elriasztására?
Igen. Az ajánlás kombinálható [vízjelekkel](/slides/hu/net/watermark/) vizuális elriasztóként; különálló mechanizmusok, és jól működnek együtt.

### Módosíthatja még egy makró vagy külső eszköz a fájlt, ha az ajánlás engedélyezve van?
Igen. Az ajánlás nem akadályozza a programozott módosításokat. Az automatizált szerkesztések megelőzéséhez használjon [jelszavakat és titkosítást](/slides/hu/net/password-protected-presentation/).

### Hogyan kapcsolódik az 'Olvasásra nyitott ajánlás' az 'IsEncrypted' és 'IsWriteProtected' jelzőkhöz?
Eltérő jelzések. Az 'Olvasásra nyitott ajánlás' egy puha, opcionális figyelmeztetés; [IsWriteProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/iswriteprotected/) és [IsEncrypted](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/isencrypted/) tényleges írási vagy olvasási korlátozásokat jelölnek, amelyek jelszavaktól vagy titkosítástól függenek.