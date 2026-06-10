---
title: Prezentációk mentése csak olvasási módban Python segítségével
linktitle: Csak olvasásra szánt prezentáció
type: docs
weight: 30
url: /hu/python-net/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Töltsön be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasási módban az Aspose.Slides for Python via .NET segítségével, pontos diákelőnézetet biztosítva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, mint egyet azok közül az opciók közül, amelyet a felhasználók a prezentációik védelmére használhatnak. Ezt a Read-Only beállítást akkor érdemes használni, ha

- meg akarja akadályozni a véletlen szerkesztéseket, és meg szeretné őrizni a prezentáció tartalmát.  
- jelezni akarja a felhasználóknak, hogy a megadott prezentáció a végleges verzió.

Miután kiválasztotta a **Always Open Read-Only** lehetőséget egy prezentációhoz, a felhasználók a prezentáció megnyitásakor a **Read-Only** ajánlást látják, és egy ilyen üzenetet kaphatnak: *A véletlen módosítások megelőzése érdekében a szerző read‑only módban nyitotta meg ezt a fájlt.*

A **Read-Only** ajánlás egy egyszerű, de hatékony elriasztó, amely a szerkesztést nehezíti, mivel a felhasználóknak lépést kell tenniük a megszüntetéséhez, mielőtt szerkeszthetnék a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvarias módon szeretné közölni, a **Read-Only** ajánlás jó megoldás lehet.

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely még nem támogatja a nemrég bevezetett funkciót –, a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normál módon nyílik meg).

## **Read-Only mód alkalmazása**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy egy prezentációt **Read-Only** módra állítson, ami azt jelenti, hogy a felhasználók (miután megnyitják a prezentációt) a **Read-Only** ajánlást látják. Ez a példakód megmutatja, hogyan állítható be egy prezentáció **Read-Only** módra Pythonban az Aspose.Slides használatával:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Megjegyzés**: A **Read-Only** ajánlás egyszerűen azért van, hogy elriassza a szerkesztést vagy megakadályozza a felhasználók véletlen változtatásait egy PowerPoint prezentációban. Ha egy motivált személy – aki tudja, mit csinál – úgy dönt, hogy módosítja a prezentációt, könnyen eltávolíthatja a **Read-Only** beállítást. Ha komolyan meg kell akadályoznia az illetéktelen szerkesztést, jobb, ha [szigorúbb védelemre, amely titkosításokat és jelszavakat tartalmaz](https://docs.aspose.com/slides/hu/python-net/password-protected-presentation/) támaszkodik. 

{{% /alert %}} 

## **FAQ**

**Mi a különbség a „Read-Only recommended” és a teljes jelszóvédelem között?**

A „Read-Only recommended” csak javaslatként jelenik meg, hogy a fájlt csak olvasásra nyissák meg, és könnyen megkerülhető. A [Jelszóvédelem](/slides/hu/python-net/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.

**A „Read-Only recommended” kombinálható‑e vízjelekkel a szerkesztés további elriasztására?**

Igen. Az ajánlás kombinálható a [vízjelekkel](/slides/hu/python-net/watermark/) vizuális elriasztásként; külön mechanizmusok, amelyek jól működnek együtt.

**Még makró vagy külső eszköz módosíthatja a fájlt, ha az ajánlás be van kapcsolva?**

Igen. Az ajánlás nem blokkolja a programozott változtatásokat. Az automatizált szerkesztés megakadályozásához használjon [jelszavakat és titkosítást](/slides/hu/python-net/password-protected-presentation/).

**Hogyan kapcsolódik a „Read-Only recommended” a „is_encrypted” és „is_write_protected” jelzőkhöz?**

Eltérő jelek. A „Read-Only recommended” egy puha, opcionális felhívás; a [is_write_protected](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/is_write_protected/) és a [is_encrypted](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/is_encrypted/) tényleges írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavak vagy titkosítás függvényei.