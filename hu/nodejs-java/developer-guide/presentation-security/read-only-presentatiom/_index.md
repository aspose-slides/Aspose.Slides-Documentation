---
title: Prezentációk mentése csak olvasásra módban JavaScript segítségével
linktitle: Csak olvasásra szánt prezentáció
type: docs
weight: 30
url: /hu/nodejs-java/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Töltsön be és mentsen PowerPoint fájlokat csak olvasásra módban az Aspose.Slides for Node.js via Java segítségével, pontos diavetítéseket kínálva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, mint az egyik lehetőséget, amelyet a felhasználók a prezentációik védelmére használhatnak. Ezt a csak olvasásra nyitás beállítást a következő esetekben érdemes használni:

- Meg akarja akadályozni a véletlen szerkesztéseket, és meg szeretné óvni a prezentációja tartalmát. 
- Szeretné jelezni a felhasználók számára, hogy a megadott prezentáció a végleges verzió. 

Miután kiválasztotta a **Always Open Read-Only** opciót egy prezentációhoz, a felhasználók a prezentáció megnyitásakor látják a **Read-Only** ajánlást, és megjelenhet egy ilyen üzenet: *A véletlen módosítások elkerülése érdekében a szerző beállította, hogy a fájl csak olvasásra nyíljon.*

Az Read-Only ajánlás egy egyszerű, de hatékony gát, amely megakadályozza a szerkesztést, mivel a felhasználóknak meg kell tenniük egy lépést a eltávolításához, mielőtt szerkeszthetnék a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvariasan szeretné közölni, akkor az Read-Only ajánlás jó lehetőség lehet. 

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normálisan nyílik meg).

## **Olvasásvédett mód alkalmazása**

Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy prezentációt **Read-Only** állapotba állítson, ami azt jelenti, hogy a felhasználók (miután megnyitják a prezentációt) látják a **Read-Only** ajánlást. Ez a mintakód megmutatja, hogyan állítható be egy prezentáció **Read-Only** módba JavaScriptben az Aspose.Slides használatával:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen arra szolgál, hogy elriassza a szerkesztést vagy megakadályozza a felhasználókat, hogy véletlenül módosítsák a PowerPoint prezentációt. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyen eltávolíthatja a Read-Only beállítást. Ha komolyan meg akarja akadályozni az illetéktelen szerkesztést, akkor jobb, ha a [szigorúbb védelmek, amelyek titkosítást és jelszavakat tartalmaznak](https://docs.aspose.com/slides/hu/nodejs-java/password-protected-presentation/) használja.

{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**

A 'Read-Only recommended' csak egy javaslatot jelenít meg a fájl csak olvasásra nyitására, és könnyen megkerülhető. A [Jelszóvédelem](/slides/hu/nodejs-java/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valós biztonsági ellenőrzésekre van szükség.

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztására?**

Igen. Az ajánlás kombinálható a [vízjelek](/slides/hu/nodejs-java/watermark/) vizuális elriasztóval; külön mechanizmusok, amelyek jól működnek együtt.

**Módosíthat egy makró vagy külső eszköz még mindig a fájlt, amikor az ajánlás engedélyezve van?**

Igen. Az ajánlás nem blokkolja a programozott változtatásokat. Az automatikus szerkesztés megakadályozásához használja a [jelszavak és titkosítás](/slides/hu/nodejs-java/password-protected-presentation/)-t.

**Hogyan kapcsolódik a 'Read-Only recommended' az 'IsEncrypted' és 'IsWriteProtected' jelzőkhöz?**

Ezek különböző jelzések. A 'Read-Only recommended' egy enyhe, opcionális figyelmeztetés; az [isWriteProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) és az [isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/isencrypted/) tényleges írási vagy olvasási korlátozásokat jelölnek, amelyek jelszavakon vagy titkosításon alapulnak.