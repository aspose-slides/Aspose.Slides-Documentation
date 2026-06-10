---
title: Prezentációk mentése olvasásvédett módban PHP segítségével
linktitle: Olvasásvédett prezentáció
type: docs
weight: 30
url: /hu/php-java/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Töltsön be és mentse a PowerPoint fájlokat (PPT, PPTX) olvasásvédett módban az Aspose.Slides for PHP segítségével, pontos diavetítéseket kínálva anélkül, hogy módosítaná a prezentációit."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, amely az egyik lehetőség, amelyet a felhasználók használhatnak prezentációik védelmére. Ezt a Read-Only beállítást a következő esetekben szeretné használni a prezentáció védelmére, amikor

- Meg szeretné akadályozni a véletlen szerkesztéseket, és megőrizni a prezentáció tartalmát biztonságban. 
- Szeretné jelezni a felhasználóknak, hogy a megadott prezentáció a végleges verzió. 

Miután kiválasztja a **Always Open Read-Only** lehetőséget egy prezentációhoz, a felhasználók a prezentáció megnyitásakor látják a **Read-Only** ajánlást, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások megelőzése érdekében a szerző úgy állította be ezt a fájlt, hogy csak olvasásra nyitható legyen.*

A Read-Only ajánlás egy egyszerű, de hatékony elriasztó, amely megakadályozza a szerkesztést, mivel a felhasználóknak egy feladatot kell elvégezniük a megszüntetéséhez, mielőtt szerkeszthetik a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvarias módon szeretné közölni, akkor a Read-Only ajánlás jó megoldás lehet. 

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normál módon nyílik meg).

## **Olvasásvédett mód alkalmazása**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egy prezentációt **Read-Only** módba állítson, ami azt jelenti, hogy a felhasználók (miután megnyitják a prezentációt) látják a **Read-Only** ajánlást. Ez a példa kód megmutatja, hogyan állíthat be egy prezentációt **Read-Only** módba az Aspose.Slides használatával:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen azt szolgálja, hogy elriassza a szerkesztést vagy megakadályozza a felhasználók véletlen módosításait egy PowerPoint prezentációban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyedén eltávolíthatja a Read-Only beállítást. Ha komolyan szeretné megakadályozni az illetéktelen szerkesztést, jobb, ha [szigorúbb védelmet, amely titkosítást és jelszavakat foglal magában](https://docs.aspose.com/slides/hu/php-java/password-protected-presentation/).

{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl olvasásvédett módban történő megnyitására, és könnyen megkerülhető. [Jelszóvédelem](/slides/hu/php-java/password-protected-presentation/) ténylegesen korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztásához?**

Igen. Az ajánlás párosítható a [vízjelekkel](/slides/hu/php-java/watermark/) vizuális elriasztóként; különálló mechanizmusok, és jól együttműködnek.

**Módosíthatja egy makró vagy külső eszköz a fájlt, ha az ajánlás engedélyezve van?**

Igen. Az ajánlás nem blokkolja a programozott változtatásokat. Az automatizált szerkesztések megakadályozásához használjon [jelszavakat és titkosítást](/slides/hu/php-java/password-protected-presentation/).

**Hogyan kapcsolódik a 'Read-Only recommended' az 'isEncrypted' és 'isWriteProtected' módszerekhez?**

Ezek különböző jelek. A 'Read-Only recommended' egy lágy, opcionális figyelmeztetés; az [isWriteProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/iswriteprotected/) és az [isEncrypted](https://reference.aspose.com/slides/hu/php-java/aspose.slides/protectionmanager/isencrypted/) a tényleges írási vagy olvasási korlátozásokat jelzik, amelyek jelszavaktól vagy titkosítástól függenek.