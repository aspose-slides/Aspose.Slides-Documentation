---
title: Prezentációk mentése csak olvasás módjában Androidon
linktitle: Olvasásvédett prezentáció
type: docs
weight: 30
url: /hu/androidjava/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasás módban az Aspose.Slides for Android via Java segítségével, pontos diavetítéseket kínálva anélkül, hogy megváltoztatná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezetett egy **Always Open Read-Only** beállítást, amely a felhasználók által a bemutatók védelmére használható opciók egyike. Ezt az Olvasásvédett beállítást akkor érdemes használni, amikor

- Meg akarja akadályozni a véletlen szerkesztéseket, és meg szeretné őrizni a bemutató tartalmát. 
- Szeretné jelezni a felhasználóknak, hogy az általad biztosított bemutató a végleges verzió. 

Miután kiválasztotta a **Always Open Read-Only** opciót egy bemutatóhoz, a felhasználók a bemutató megnyitásakor a **Read-Only** javaslatot látják, és egy ilyen üzenetet is megjeleníthetnek: *A véletlen módosítások elkerülése érdekében a szerző beállította a fájlt csak olvasásra.*

A Read-Only javaslat egy egyszerű, de hatékony elriasztó, amely a szerkesztést visszatartja, mivel a felhasználóknak egy feladatot kell végrehajtaniuk a javaslat eltávolításához, mielőtt szerkeszthetnék a bemutatót. Ha nem szeretné, hogy a felhasználók módosítsák a bemutatót, és ezt udvariasan szeretné közölni velük, akkor a Read-Only javaslat jó opciónak bizonyulhat. 

> Ha egy **Read-Only** védelmmel ellátott bemutatót egy régebbi Microsoft PowerPoint alkalmazásban nyitnak meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** javaslat figyelmen kívül marad (a bemutató normál módon nyílik meg).

## **Olvasásvédett mód alkalmazása**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy bemutatót **Read-Only** állapotba állítson, ami azt jelenti, hogy a felhasználók (a bemutató megnyitása után) a **Read-Only** javaslatot látják. Ez a mintakód bemutatja, hogyan állítható be egy bemutató **Read-Only** módba Java-ban az Aspose.Slides használatával:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Megjegyzés**: A **Read-Only** javaslat egyszerűen arra szolgál, hogy elriassza a szerkesztést vagy megakadályozza a felhasználókat a véletlen változtatásokban a PowerPoint bemutatóban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a bemutatót, könnyen eltávolíthatja az Olvasásvédett beállítást. Ha valóban meg kell akadályoznia a jogosulatlan szerkesztést, jobb, ha [szigorúbb védelmet alkalmaz, amely titkosítást és jelszavakat tartalmaz](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **GYIK**

### Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl olvasásvédett módban történő megnyitására, és könnyen megkerülhető. A [Password protection](/slides/hu/androidjava/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági szabályozásra van szükség.

### Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztására?

Igen. A javaslat kombinálható [watermarks](/slides/hu/androidjava/watermark/) vizuális elriasztóval; különálló mechanizmusok, amelyek jól működnek együtt.

### Módosíthatja még egy makró vagy külső eszköz a fájlt, amikor a javaslat engedélyezve van?

Igen. A javaslat nem blokkolja a programozott változtatásokat. Az automatizált szerkesztés megakadályozásához használjon [passwords and encryption](/slides/hu/androidjava/password-protected-presentation/).

### Hogyan kapcsolódik a 'Read-Only recommended' a 'isEncrypted' és 'isWriteProtected' metódusokhoz?

Ezek különböző jelzések. A 'Read-Only recommended' egy lágy, opcionális figyelmeztetés; a [isWriteProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) és a [isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) tényleges írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavaktól vagy titkosítástól függenek.