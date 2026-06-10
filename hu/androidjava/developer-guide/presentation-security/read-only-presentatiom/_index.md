---
title: Prezentációk mentése csak olvasásra módon Androidon
linktitle: Csak olvasásra szánt prezentáció
type: docs
weight: 30
url: /hu/androidjava/read-only-presentation/
keywords:
- csak olvasásra
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasásra módon az Aspose.Slides for Android via Java használatával, pontos diavetítéseket kínálva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019‑ben a Microsoft bevezette a **Always Open Read-Only** beállítást, mint egyet azon lehetőségek közül, amelyeket a felhasználók a prezentációik védelmére használhatnak. Érdemes ezt a Read-Only beállítást alkalmazni egy prezentáció védelmére, amikor

- Meg akarja akadályozni a véletlen szerkesztéseket, és szeretné a prezentáció tartalmát biztonságban tartani. 
- Tájékoztatni akarja a felhasználókat arról, hogy a megadott prezentáció a végleges változat. 

Miután kiválasztja a **Always Open Read-Only** opciót egy prezentációhoz, a felhasználók a prezentáció megnyitásakor a **Read-Only** ajánlást látják, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások megelőzése érdekében a szerző beállította, hogy a fájl csak olvasásra legyen nyitva.*

A Read-Only ajánlás egy egyszerű, de hatékony elriasztó, amely a szerkesztést visszatartja, mivel a felhasználóknak egy feladatot kell elvégezniük a eltávolításához, mielőtt szerkeszthetnék a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvariasan szeretné közölni, akkor a Read-Only ajánlás jó megoldás lehet. 

> Ha egy **Read-Only** védelmet tartalmazó prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normál módon nyílik meg).

## **Read-Only mód alkalmazása**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy prezentációt **Read-Only** módra állítson, ami azt jelenti, hogy a felhasználók (a prezentáció megnyitása után) a **Read-Only** ajánlást látják. Ez a példa kód megmutatja, hogyan állíthat be egy prezentációt **Read-Only** módra Java‑ban az Aspose.Slides használatával:

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
**Megjegyzés**: A **Read-Only** ajánlás egyszerűen arra szolgál, hogy visszatartsa a szerkesztést, vagy megakadályozza a felhasználókat a véletlen módosításokban egy PowerPoint prezentációban. Ha egy motivált személy—aki tudja, mit csinál—úgy dönt, hogy szerkeszti a prezentációt, könnyedén eltávolíthatja a Read-Only beállítást. Ha komolyan meg kell akadályoznia a jogosulatlan szerkesztést, jobb, ha a [szigorúbb, titkosítást és jelszavakat is magában foglaló védelmeket](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/) használja.
{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**

A 'Read-Only recommended' csak egy javaslatot jelenít meg a fájl csak olvasásra nyitására, és könnyen megkerülhető. A [Password protection](/slides/hu/androidjava/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további visszatartására?**

Igen. Az ajánlás párosítható a [watermarks](/slides/hu/androidjava/watermark/) vizuális elriasztóval; külön mechanizmusok, és jól működnek együtt.

**Módosíthatja még makró vagy külső eszköz a fájlt, ha az ajánlás engedélyezve van?**

Igen. Az ajánlás nem akadályozza a programozott módosításokat. Az automatikus szerkesztés megelőzéséhez használja a [passwords and encryption](/slides/hu/androidjava/password-protected-presentation/) lehetőséget.

**Hogyan kapcsolódik a 'Read-Only recommended' a 'isEncrypted' és 'isWriteProtected' metódusokhoz?**

Eltérő jelekről van szó. A 'Read-Only recommended' egy enyhe, opcionális felugrás; a [isWriteProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) és a [isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) tényleges írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavakhoz vagy titkosításhoz kötöttek.