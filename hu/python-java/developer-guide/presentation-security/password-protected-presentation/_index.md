---
title: Prezentációk jelszóval való védelme Pythonban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/python-java/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszavának ellenőrzése
- prezentáció jelszó ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- Python
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg és fejtse fel a jelszóval védett PowerPoint PPT és PPTX prezentációkat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A nyitó jelszó titkosítja a prezentációt. A helyes jelszó szükséges a prezentáció tartalmának betöltéséhez és megtekintéséhez, így ez a védelem a bizalmasságot biztosítja.

A nyitó jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséről lásd a [Write-Protect Presentations](/slides/hu/python-java/write-protected-presentation/).

Az alábbi munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és stream‑alapú viselkedés fontos.

## **Prezentáció titkosítása nyitó jelszóval**

A nyitó jelszó hozzárendeléséhez használd a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#encrypt) metódust. Ezután a titkosított prezentáció mentéséhez használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust.

A következő példa titkosít egy PPTX prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dokumentumtulajdonságok nyilvános megtartása**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belevonja a prezentáció titkosításába. A [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódus ezt a viselkedést a dia‑tartalom titkosításától függetlenül szabályozza. Ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a nyitó jelszó nélkül kell olvasnia a metaadatokat, akkor a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#encrypt) hívása előtt add át a `False` értéket.

A következő példa egy titkosított PPTX prezentációt hoz létre, miközben a beépített dokumentumtulajdonságait nyilvánosként hagyja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A `False` érték átadása a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak nem teszi nyilvánossá a diákat, master‑diákat, elrendezéseket, alakzatokat, médiát vagy a prezentáció egyéb tartalmát. Csak a dokumentumtulajdonságokra van hatással. A titkosított tartalom betöltése nélkül történő olvasáshoz lásd a [Manage Presentation Properties](/slides/hu/python-java/presentation-properties/).

## **Titkosított prezentáció betöltése**

Állítsd a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) értékét a nyitó jelszóra, és a fájl betöltésekor add át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Munka a visszafejtett prezentációval.
    pass
finally:
    presentation.dispose()
```

## **Titkosítás eltávolítása egy prezentációból**

Töltsd be a prezentációt a nyitó jelszóval, hívd meg a [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#removeEncryption) metódust, majd mentsd el az eredményt. A mentett prezentáció ezután jelszó nélkül betölthető.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) segítségével szerezz [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) objektumot anélkül, hogy teljes prezentációpéldányt hoznál létre. Jelszó kérése vagy ellenőrzése előtt ellenőrizd a [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#isPasswordProtected) állapotát. Ha védelem van, a megadott értéket a [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#checkPassword) metódussal ellenőrizd.

### **Fájlútvonal munkafolyamat**

A következő példa ellenőrzi egy PPTX fájl nyitó jelszavát, átadja az ellenőrzött értéket a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) metódusnak, majd betölti a teljes prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Stream munkafolyamat**

A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) stream‑túlterhelése ugyanazt a munkafolyamatot biztosítja. A teljes prezentáció stream‑ből való betöltése előtt állítsd vissza egy kereshető stream pozícióját.

A következő példa egy PPT fájlt használ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword visszatérési értékek**

A [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#checkPassword) `True` értéket ad csak akkor, ha a prezentációnak nyitó jelszava van, és a megadott jelszó helyes. `False` értéket ad az alábbi esetekben:

- A jelszó helytelen.
- A prezentációnak nincs nyitó jelszava.
- A megadott jelszó `None` vagy üres.

A viselkedés ugyanaz PPT és PPTX prezentációk esetén.

## **Ellenőrizd, hogy a betöltött prezentáció titkosított-e**

A megfelelő jelszóval betöltött prezentáció után vizsgáld meg a [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isEncrypted) állapotát, hogy megerősítsd, a forrás prezentáció titkosított volt. A nyitó jelszó védelem betöltés előtti észleléséhez használd a fent bemutatott [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#isPasswordProtected) metódust.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Security" %}}
Ne naplózd a nyitó jelszavakat, és ne tüntesd fel őket diagnosztikai üzenetekben. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, a jelszavakat csak a szükséges időtartamra tartsd a memóriában, és használd újra a sikeres ellenőrzés eredményét a prezentáció azonnali betöltésekor.

A nyilvános dokumentumtulajdonságok felfedhetik a szerzők neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket, még akkor is, ha a prezentáció tartalma titkosított. Titkosítsd az érzékeny metaadatokat a prezentációval együtt. A tulajdonságok nyilvános meghagyása kifejezett döntés legyen, csak akkor, amikor a rendszereknek indexelni, osztályozni, keresni vagy kezelni kell a fájlt nyitó jelszó nélkül.
{{% /alert %}}

## **Prezentáció jelszóval való védelme online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válaszd ki vagy töltsd fel a prezentációt.
3. Adj meg egy jelszót a megtekintés védelméhez.
4. Opcionálisan adj meg egy külön jelszót a szerkesztési védelemhez.
5. Alkalmazd a védelmet, és töltsd le a keletkezett fájlt.

{{% alert color="info" title="See also" %}}
- [Prezentációk írásvédelme](/slides/hu/python-java/write-protected-presentation/)
- [Digitális aláírás PowerPoint‑ban](/slides/hu/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy titkosítaná a tartalmat.

**Ellenőrizhetem a nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezd meg a prezentáció információit, ellenőrizd, hogy nyitó jelszó védelem jelen van‑e, és validáld a jelszót a teljes prezentációpéldány létrehozása előtt.

**Olvashat egy alkalmazás metaadatokat nyitó jelszó nélkül?**

Igen, de csak akkor, ha a prezentációt a dokumentumtulajdonságok titkosítása letiltásával titkosították. Ebben az esetben az alkalmazásnak a [Manage Presentation Properties](/slides/hu/python-java/presentation-properties/) leírásában szereplő dokumentumtulajdonságokra korlátozott betöltési módot kell használnia.

**Támogatja a jelszó‑ellenőrzési munkafolyamat a PPT és PPTX formátumokat is?**

Igen. A fájlútvonal és stream alapú jelszódetektálás és ellenőrzés egyformán működik PPT és PPTX prezentációk esetén.