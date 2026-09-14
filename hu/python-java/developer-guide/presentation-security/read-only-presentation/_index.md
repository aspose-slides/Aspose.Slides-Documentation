---
title: Prezentációk mentése csak olvasás módjában Python segítségével
linktitle: Csak olvasás módú prezentáció
type: docs
weight: 30
url: /hu/python-java/read-only-presentation/
keywords:
- csak olvasás
- prezentáció védelme
- szerkesztés megakadályozása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Töltsön be és mentse a PowerPoint fájlokat (PPT, PPTX) csak olvasás módjában az Aspose.Slides for Python via Java használatával, pontos diavetítéseket kínálva anélkül, hogy módosítaná a prezentációkat."
---
## **Bevezetés**

A PowerPoint 2019-ben a Microsoft bevezette a **Always Open Read-Only** beállítást, amely a felhasználók által a prezentációk védelmére használt lehetőségek egyike. Érdemes lehet ezt a Read-Only beállítást használni egy prezentáció védelmére, ha:

- Meg akarja akadályozni a véletlen szerkesztéseket, és biztonságban tartani a prezentáció tartalmát. 
- Szeretné jelezni a felhasználóknak, hogy az Ön által biztosított prezentáció a végső verzió. 

Miután kiválasztja a **Always Open Read-Only** beállítást egy prezentációhoz, a felhasználók a megnyitáskor a **Read-Only** ajánlást látják, és megjelenhet egy ilyen üzenet: *A véletlen módosítások elkerülése érdekében a szerző beállította, hogy ez a fájl csak olvasásra legyen nyitva.*

A Read-Only ajánlás egy egyszerű, de hatékony elriasztó, amely megakadályozza a szerkesztést, mivel a felhasználóknak feladatot kell elvégezniük annak eltávolításához, mielőtt szerkeszthetnék a prezentációt. Ha nem szeretné, hogy a felhasználók módosítsák a prezentációt, és ezt udvariasan szeretné jelezni, akkor a Read-Only ajánlás jó megoldás lehet. 

> Ha egy **Read-Only** védelemmel ellátott prezentációt egy régebbi Microsoft PowerPoint alkalmazásban nyitják meg – amely nem támogatja a nemrég bevezetett funkciót – a **Read-Only** ajánlás figyelmen kívül marad (a prezentáció normál módon nyílik meg).

## **Read-Only mód alkalmazása**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy egy prezentációt **Read-Only** módba állítson, ami azt jelenti, hogy a felhasználók (a prezentáció megnyitása után) a **Read-Only** ajánlást látják. Ez a mintakód bemutatja, hogyan állítható be egy prezentáció **Read-Only** módra Pythonban az Aspose.Slides használatával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}} 

A **Read-Only** ajánlás egyszerűen arra szolgál, hogy elriassa a szerkesztést vagy megakadályozza a felhasználókat a véletlen módosításokban egy PowerPoint prezentációban. Ha egy motivált személy – amelyik tudja, mit csinál – úgy dönt, hogy szerkeszti a prezentációt, könnyedén eltávolíthatja a Read-Only beállítást. Ha komolyan meg szeretné akadályozni az illetéktelen szerkesztést, akkor jobb, ha [szigorúbb védelmet használ, amely titkosítást és jelszavakat tartalmaz](/slides/hu/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **GYIK**

**Mi a különbség a 'Read-Only recommended' és a teljes jelszóvédelem között?**  
'Read-Only recommended' csak egy javaslatot jelenít meg a fájl read-only módban történő megnyitására, és könnyen megkerülhető. A [jelszóvédelem](/slides/hu/python-java/password-protected-presentation/) valójában korlátozza a megnyitást vagy a szerkesztést, és akkor megfelelő, ha valódi biztonsági ellenőrzésekre van szükség.  

**Kombinálható a 'Read-Only recommended' vízjelekkel a szerkesztés további elriasztására?**  
Igen. Az ajánlást kombinálhatja a [vízjelekkel](/slides/hu/python-java/watermark/) vizuális elriasztóként; ezek különálló mechanizmusok, és jól működnek együtt.  

**Módosíthatja egy makró vagy külső eszköz továbbra is a fájlt, ha az ajánlás engedélyezve van?**  
Igen. Az ajánlás nem akadályozza a programozott változtatásokat. Az automatizált szerkesztések megakadályozásához használjon [jelszavakat és titkosítást](/slides/hu/python-java/password-protected-presentation/).  

**Hogyan kapcsolódik a 'Read-Only recommended' a [isEncrypted](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isEncrypted) és [isWriteProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isWriteProtected) metódusokhoz?**  
Eltérő jelzésekről van szó. A 'Read-Only recommended' egy puha, opcionális felvetés; a [isWriteProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isWriteProtected) és a [isEncrypted](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isEncrypted) tényleges írási vagy olvasási korlátozásokat jeleznek, amelyek jelszavakon vagy titkosításon alapulnak.