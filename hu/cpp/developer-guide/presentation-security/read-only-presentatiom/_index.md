---
title: "Prezentációk mentése csak olvasás módban C++ használatával"
linktitle: "Olvasásvédett prezentáció"
type: docs
weight: 30
url: /hu/cpp/read-only-presentation/
keywords:
- "csak olvasás"
- "prezentáció védelme"
- "szerkesztés megakadályozása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Töltsön be és mentsen PowerPoint fájlokat (PPT, PPTX) csak olvasás módban az Aspose.Slides for C++ segítségével, pontos dia előnézetet biztosítva anélkül, hogy megváltoztatná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, amely az egyik lehetőség, amelyet a felhasználók a prezentációik védelmére használhatnak. Érdemes lehet ezt a Read-Only beállítást használni egy prezentáció védelmében, amikor

- Meg szeretné akadályozni a véletlen szerkesztéseket, és biztonságban tartani a prezentáció tartalmát. 
- Tájékoztatni szeretné a felhasználókat arról, hogy az Ön által biztosított prezentáció a végleges verzió. 

Miután kiválasztja a **Always Open Read-Only** beállítást egy prezentációhoz, a felhasználók a prezentáció megnyitásakor láthatják a **Read-Only** ajánlást, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások elkerülése érdekében a szerző beállította, hogy ez a fájl csak olvasásra legyen megnyitva.*

A **Read-Only** ajánlás egy egyszerű, de hatékony elriasztó, amely megakadályozza a szerkesztést, mivel a felhasználóknak fel kell venniük a feladatot a szerkesztés engedélyezése előtt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és udvariasan szeretné ezt jelezni, a **Read-Only** ajánlás jó lehetőség lehet. 

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a legutóbb bevezetett funkciót – a **Read-Only** ajánlást figyelmen kívül hagyják (a prezentáció normál módon nyílik meg).

## **Olvasásvédett mód alkalmazása**

Az Aspose.Slides for C++ lehetővé teszi, hogy egy prezentációt **Read-Only** módban állítson be, ami azt jelenti, hogy a felhasználók (miután megnyitják a prezentációt) látják a **Read-Only** ajánlást. Ez a minta kód megmutatja, hogyan állíthat be egy prezentációt **Read-Only** módba C++‑ban az Aspose.Slides használatával:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen a szerkesztés elriasztására vagy a felhasználók véletlen módosításainak megállítására szolgál egy PowerPoint prezentációban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyen eltávolíthatja a Read-Only beállítást. Ha komolyan meg kell akadályoznia a jogosulatlan szerkesztést, jobb, ha [szigorúbb védelmet alkalmaz, amely titkosítást és jelszavakat tartalmaz](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**

'Read-Only recommended' csak egy javaslatot jelenít meg a fájl olvasásvédett módban történő megnyitására, és könnyen megkerülhető. [Password protection](/slides/hu/cpp/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, amikor valódi biztonsági irányításra van szükség.

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztására?**

Igen. Az ajánlás párosítható a [watermarks](/slides/hu/cpp/watermark/) vizuális elriasztójaként; különálló mechanizmusok, és jól együttműködnek.

**Módosíthat egy makró vagy külső eszköz még mindig a fájlt, ha az ajánlás engedélyezve van?**

Igen. Az ajánlás nem blokkolja a programozott módosításokat. Az automatikus szerkesztés megakadályozásához használjon [passwords and encryption](/slides/hu/cpp/password-protected-presentation/).

**Hogyan viszonyul a 'Read-Only recommended' a 'is encrypted' és 'is write protected' jelzőkhöz?**

Ezek különböző jelek. A 'Read-Only recommended' egy enyhe, opcionális figyelmeztetés; a [get_IsWriteProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) és a [get_IsEncrypted](https://reference.aspose.com/slides/hu/cpp/aspose.slides/protectionmanager/get_isencrypted/) valós írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavaktól vagy titkosítástól függnek.