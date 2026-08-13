---
title: Prezentációk mentése csak olvasási módban Java használatával
linktitle: Csak olvasásra szóló prezentáció
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
description: "Töltse be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasási módban az Aspose.Slides for Java segítségével, pontos diavetítéseket kínálva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, mint egyet azok közül a lehetőségek közül, amelyeket a felhasználók a bemutatóik védelmére használhatnak. Érdemes lehet ezt a csak olvasható beállítást használni egy bemutató védelmére, ha

- Meg szeretné akadályozni a véletlen szerkesztéseket, és a bemutató tartalmát biztonságban tartani. 
- Tájékoztatni szeretné a felhasználókat arról, hogy a biztosított bemutató a végleges változat. 

Miután a **Always Open Read-Only** lehetőséget kiválasztja egy bemutatóhoz, a felhasználók a bemutató megnyitásakor a **Read-Only** javaslatot látják, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások megelőzése érdekében a szerző beállította a fájlt csak olvasásra.*

A **Read-Only** javaslat egy egyszerű, mégis hatékony elriasztó, amely megakadályozza a szerkesztést, mivel a felhasználóknak egy feladatot kell elvégezniük a javaslat eltávolításához, mielőtt szerkeszthetnék a bemutatót. Ha nem szeretné, hogy a felhasználók módosítsák a bemutatót, és ezt udvariasan szeretné jelezni, a **Read-Only** javaslat jó lehetőség lehet. 

> Ha egy **Read-Only** védelemmel ellátott bemutatót egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** javaslat figyelmen kívül marad (a bemutató normál módon nyílik meg).

## **Csak olvasás mód alkalmazása**

Az Aspose.Slides for Java lehetővé teszi, hogy egy bemutatót **Read-Only** állapotba állítson, ami azt jelenti, hogy a felhasználók (miután megnyitják a bemutatót) a **Read-Only** javaslatot látják. Ez a példa kód bemutatja, hogyan állítható be egy bemutató **Read-Only** módba Java-ban az Aspose.Slides használatával:

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

**Megjegyzés**: A **Read-Only** javaslat egyszerűen arra szolgál, hogy elriassza a szerkesztést vagy megakadályozza a felhasználókat a véletlen változtatásokban egy PowerPoint bemutatóban. Ha egy motivált személy—aki tudja, mit csinál—úgy dönt, hogy szerkeszti a bemutatót, könnyen eltávolíthatja a csak olvasás beállítást. Ha komolyan meg kell akadályoznia a jogosulatlan szerkesztést, jobb, ha [szigorúbb védelmek, amelyek titkosítást és jelszavakat tartalmaznak](https://docs.aspose.com/slides/hu/java/password-protected-presentation/). 

{{% /alert %}} 

## **GYIK**

### Hogyan különbözik a 'Read-Only recommended' a teljes jelszóvédelemtől?

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl csak olvasás módú megnyitására, és könnyen megkerülhető. [Jelszóvédelem](/slides/hu/java/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

### Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további megakadályozására?

Igen. A javaslat párosítható a [vízjelek](/slides/hu/java/watermark/) vizuális elriasztóval; különálló mechanizmusok, amelyek jól együtt működnek.

### Módosíthat egy makró vagy külső eszköz a fájlt, ha a javaslat engedélyezve van?

Igen. A javaslat nem akadályozza a programozott változtatásokat. Az automatizált szerkesztés megakadályozásához használja a [jelszavak és titkosítás](/slides/hu/java/password-protected-presentation/). 

### Hogyan kapcsolódik a 'Read-Only recommended' az 'isEncrypted' és 'isWriteProtected' metódusokhoz?

Ezek különböző jelek. A 'Read-Only recommended' egy puha, opcionális felkérdezés; [isWriteProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/protectionmanager/#isWriteProtected--) és [isEncrypted](https://reference.aspose.com/slides/hu/java/com.aspose.slides/protectionmanager/#isEncrypted--) valós írási vagy olvasási korlátozásokat jelölnek, amelyek jelszavaktól vagy titkosítástól függenek.