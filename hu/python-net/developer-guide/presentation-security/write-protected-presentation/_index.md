---
title: Írásvédelem a PowerPoint prezentációkban Python nyelven
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/python-net/write-protected-presentation/
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
description: "Állíts be, észleld, ellenőrizd és távolítsd el az írásvédelmi jelszavakat PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for Python használatával."
---
## **Bevezetés**

A írásvédelmi jelszó korlátozza a prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók a jelszó nélkül betölthetik és megtekinthetik az írásvédett prezentációt. Az alkalmazástól függően szerkeszthetik is a tartalmat, és más néven menthetik, ezért az írásvédelmet nem szabad titoktartási mechanizmusnak tekinteni.

A nyitó jelszó más célra szolgál: titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. A prezentáció titkosításához vagy a nyitó jelszó ellenőrzéséhez lásd a [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/).

A cikkben bemutatott munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák PPTX fájlokat használnak; PPT-re mentéskor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Írásvédelem beállítása egy prezentáción**

Használd a [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/set_write_protection/) metódust a prezentáció módosításához szükséges jelszó megadásához. A prezentáció mentése megőrzi a védelmi beállítást.

A következő példában írásvédelmet állítunk be egy PPTX prezentáción:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Írásvédett prezentáció betöltése**

Mivel az írásvédelem nem titkosítja a prezentáció tartalmát, a prezentáció betöltéséhez nem szükséges jelszó. A jelszó csak akkor releváns, ha a védett prezentáció módosítási engedélyét ellenőrizzük.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Ne add meg az írásvédelmi jelszót a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) tulajdonságnak. Ez a tulajdonság a titkosított tartalomhoz nyitó jelszót fogad el. Ha egy prezentáció mindkét védelem típussal rendelkezik, add meg a nyitó jelszót a betöltéshez, és az írásvédelmi jelszót külön kezeld.

## **Írásvédelem eltávolítása egy prezentációból**

Használd a [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/remove_write_protection/) metódust a módosítási korlátozás eltávolításához, majd mentsd a prezentációt.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ellenőrzés, hogy a prezentáció írásvédett-e**

A fájl ellenőrzéséhez anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hoznánk létre, hívd a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust, és ellenőrizd a [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/is_write_protected/) tulajdonságot. A tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/) típust használja, és `NullableBool.TRUE` értéket ad vissza, ha írásvédettséget észlel.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

A [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) adatfolyam‑túlterhelése ugyanazt az információt adja egy adatfolyamként megadott prezentációról.

## **Írásvédelmi jelszó ellenőrzése**

Használd a [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_write_protection/) metódust a módosítási jelszó ellenőrzéséhez a teljes prezentáció betöltése nélkül. Először ellenőrizd a [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/is_write_protected/) tulajdonságot, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha írásvédelem van jelen.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_write_protection/) csak az írásvédelmi jelszót ellenőrzi. Nem ellenőrzi a nyitó jelszót, és nem határozza meg, hogy a titkosított tartalom betölthető‑e. Ezzel szemben a [PresentationInfo.check_password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_password/) csak a nyitó jelszót ellenőrzi. Ha egy teljes prezentáció már be lett töltve, a [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/check_write_protection/) ugyanazt az írásvédelmi ellenőrzést biztosít a védelmi menedzserén keresztül.

Éles alkalmazásokban ne naplózd a jelszavakat, és ne tüntesd fel őket diagnosztikai üzenetekben. Kerüld a felesleges ismételt ellenőrzési kísérleteket, és a jelszavakat a memóriában csak a szükséges ideig tartsd.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/)
- [Csak olvasható prezentációk](/slides/hu/python-net/read-only-presentation/)
- [Digitális aláírás a PowerPointban](/slides/hu/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e a írásvédelem a prezentációt?**

Nem. Korlátozza a módosítást, de a prezentáció tartalma továbbra is betölthető és megtekinthető.

**Szükséges-e az írásvédelmi jelszó a prezentáció megnyitásához?**

Nem. Csak a nyitó jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet egy prezentációnak egyszerre nyitó és írásvédelmi jelszója?**

Igen. A nyitó jelszót a betöltési beállításokban add meg a titkosított prezentáció megnyitásához, és az írásvédelmi jelszót külön ellenőrizd, ha a módosítási jogosultságra van szükség.