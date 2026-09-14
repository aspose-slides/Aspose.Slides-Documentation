---
title: Írásvédett prezentációk Pythonban
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/python-java/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- módosítási jelszó
- prezentáció szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Állítsa be, észlelje, ellenőrizze és távolítsa el az írásvédelmi jelszavakat PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Bevezetés**

A módosításvédelmi jelszó korlátozza egy prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók jelszó nélkül betölthetik és megtekinthetik a módosításvédett prezentációt. Az alkalmazástól függően szerkeszthetik is a tartalmat, és elmenthetik egy másik néven, így a módosításvédelem nem tekinthető titoktartási mechanizmusnak.

A nyitó jelszó más célra szolgál: titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. A prezentáció titkosításához vagy egy nyitó jelszó érvényesítéséhez lásd a [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/).

A cikkben bemutatott munkafolyamatok a PPT és PPTX prezentációkra egyaránt vonatkoznak. A példák PPTX fájlokat használnak; PPT-re mentéskor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Módosításvédelem beállítása egy prezentáción**

A [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#setWriteProtection) segítségével adhatunk meg jelszót a prezentáció módosításához. A prezentáció mentése megőrzi a védelmi beállítást.

Az alábbi példa módosításvédelmet állít be egy PPTX prezentáción:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Módosításvédett prezentáció betöltése**

Mivel a módosításvédelem nem titkosítja a prezentáció tartalmát, a betöltéshez nem szükséges jelszó. A jelszó csak akkor releváns, amikor a védett prezentáció módosítási jogosultságának ellenőrzése történik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Ne adjon meg módosításvédelmi jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) metódusnak. Ez a metódus titkosított tartalomhoz nyitó jelszót vár. Ha egy prezentáció mindkét védelmi típust tartalmazza, a nyitó jelszót adja meg a betöltéshez, a módosításvédelmi jelszót pedig külön kezelje.

## **Módosításvédelem eltávolítása egy prezentációból**

A [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#removeWriteProtection) segítségével távolítható el a módosítási korlátozás, majd mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ellenőrzés, hogy a prezentáció módosításvédett-e**

Egy fájl vizsgálatához anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hoznánk létre, hívja meg a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, és ellenőrizze a [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#isWriteProtected) tulajdonságot. A metódus a [NullableBool](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/) típust használja, és `NullableBool.True_` értéket ad vissza, ha módosításvédelem van jelen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) adatfolyam‑túlterhelése ugyanazt az információt adja egy adatfolyamként megadott prezentáció esetén.

## **Módosításvédelmi jelszó ellenőrzése**

A [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#checkWriteProtection) metódussal ellenőrizhető egy módosítási jelszó anélkül, hogy a teljes prezentációt betöltené. Előbb ellenőrizze a [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#isWriteProtected) állapotot, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha módosításvédelem van.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

A [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#checkWriteProtection) csak a módosításvédelmi jelszót ellenőrzi. Nem ellenőrzi a nyitó jelszót, és nem állapítja meg, hogy titkosított tartalom betölthető-e. Ezzel szemben a [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#checkPassword) csak a nyitó jelszót ellenőrzi. Ha a teljes prezentáció már be van töltve, a [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#checkWriteProtection) a védelmenedzsere révén ugyanazt a módosításvédelmi ellenőrzést biztosítja.

Éles alkalmazásokban ne naplózzák a jelszavakat, és ne szerepeltessék őket diagnosztikai üzenetekben. Kerülje a felesleges, ismételt ellenőrzési kísérleteket, és a jelszavakat csak a szükséges ideig tartsák a memóriában.

{{% alert color="info" title="Lásd még" %}}
- [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/hu/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e a módosításvédelem a prezentációt?**

Nem. A módosításvédelmi jelszó korlátozza a módosítást, de a prezentáció tartalma elérhető a betöltéshez és megtekintéshez.

**A módosításvédelmi jelszó szükséges a prezentáció megnyitásához?**

Nem. Csak egy nyitó jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet egy prezentációnak egyszerre nyitó jelszava és módosításvédelmi jelszava is?**

Igen. A nyitó jelszót a betöltési beállításokkal adja meg a titkosított prezentáció megnyitásához, a módosításvédelmi jelszót pedig külön ellenőrizze, amikor a módosítási jogosultságot kell ellenőrizni.