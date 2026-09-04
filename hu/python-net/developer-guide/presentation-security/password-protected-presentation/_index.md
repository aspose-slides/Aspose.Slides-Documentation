---
title: Jelszóval védett prezentációk Pythonban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/python-net/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszavának ellenőrzése
- prezentáció jelszavának ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- Python
- Aspose.Slides
description: "Titkosítsa, ismerje fel, ellenőrizze, nyissa meg és dekódolja a jelszóval védett PowerPoint PPT és PPTX prezentációkat Pythonban az Aspose.Slides segítségével."
---
## **Áttekintés**

A nyitó jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, így ez a védelem bizalmasságot biztosít.

A nyitó jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, illetve nem akadályozza a bemutató betöltését. A bemutatók módosításához használt jelszavak kezeléséről lásd a [Write-Protect Presentations](/slides/hu/python-net/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok mind a PPT, mind a PPTX bemutatókra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl- és adatfolyam-alapú viselkedés lényeges.

## **Nyitó jelszóval titkosított bemutató**

Használja a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/encrypt/) metódust a nyitó jelszó hozzárendeléséhez. Ezután használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a titkosított bemutató mentéséhez.

A következő példa egy PPTX bemutatót titkosít:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **A dokumentumtulajdonságok nyilvánosak maradnak**

Alapértelmezés szerint az Aspose.Slides belefoglalja a dokumentumtulajdonságokat a bemutató titkosításába. A [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) tulajdonság ezt a viselkedést a dia-tartalom titkosításától függetlenül szabályozza. Állítsa `False`-ra a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/encrypt/) meghívása előtt, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a nyitó jelszó nélkül kell olvasnia a metaadatokat.

A következő példa egy titkosított PPTX bemutatót hoz létre, miközben a beépített dokumentumtulajdonságait nyilvánosnak hagyja:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Az `encrypt_document_properties` `False`-ra állítása nem teszi a diákat, mesterlapokat, elrendezéseket, alakzatokat, médiát vagy egyéb bemutatótartalmakat nyilvánossá. Csak a dokumentumtulajdonságokra van hatással. A titkosított tartalom betöltése nélkül ezeknek a tulajdonságoknak az olvasásáról lásd a [Manage Presentation Properties](/slides/hu/python-net/presentation-properties/) oldalt.

## **Titkosított bemutató betöltése**

Állítsa a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) értékét a nyitó jelszóra, és adja át az opciókat a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának a fájl betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Dolgozz a visszafejtett prezentációval.
    pass
```

## **Titkosítás eltávolítása a bemutatóból**

Töltse be a bemutatót a nyitó jelszavával, hívja meg a [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/remove_encryption/) metódust, majd mentse el az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) lekérdezéséhez teljes bemutatóobjektum létrehozása nélkül. Ellenőrizze a [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/is_password_protected/) értékét, mielőtt jelszót kérne vagy validálná. Ha védelem van jelen, a megadott értéket a [PresentationInfo.check_password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_password/) metódussal ellenőrizze.

### **Fájl-útvonal munkafolyamat**

A következő példa egy PPTX fájl nyitó jelszavát ellenőrzi, átadja a validált értéket a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) paraméternek, majd betölti a teljes bemutatót:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Adatfolyam munkafolyamat**

A [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) adatfolyam túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza egy kereshető adatfolyam pozícióját, mielőtt az egész bemutatót betöltené az adatfolyamból.

A következő példa egy PPT fájlt használ:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword visszatérési értékek**

Az [PresentationInfo.check_password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_password/) csak akkor ad `True` értéket, ha a bemutató nyitó jelszóval védett, és a megadott jelszó helyes. `False`-t ad minden alábbi esetben:

- A jelszó helytelen.
- A bemutatónak nincs nyitó jelszava.
- A megadott jelszó `None` vagy üres.

A viselkedés PPT és PPTX bemutatók esetén egyforma.

## **Ellenőrizze, hogy a betöltött bemutató titkosított-e**

A bemutató helyes jelszóval történő betöltése után ellenőrizze a [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/is_encrypted/) metódust, hogy megerősítse, a forrásbemutató titkosított volt. A nyitó jelszavas védelem betöltés előtti felismeréséhez használja a `PresentationInfo.is_password_protected` értéket, ahogyan fent látható.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Security" %}}
Ne naplózza a nyitó jelszavakat, és ne szerepeltesse őket diagnosztikai üzenetekben. Kerülje a szükségtelen ismételt ellenőrzési kísérleteket, tartsa a jelszavakat a memóriában csak annyi ideig, amennyi szükséges, és használja újra a sikeres ellenőrzés eredményét, ha azonnal betölti a bemutatót.

A nyilvános dokumentumtulajdonságok felfedhetik a szerző nevét, a címeket, a tárgyakat, a kulcsszavakat, a céginformációkat, a megjegyzéseket és egyedi értékeket is akkor is, ha a bemutató tartalma titkosított. Titkosítsa az érzékeny metaadatokat együtt a bemutatóval. A tulajdonságok nyilvánosan hagyása csak akkor legyen kifejezett döntés, ha a rendszereknek indexelni, osztályozni, keresni vagy kezelni kell a fájlt nyitó jelszó nélkül.
{{% /alert %}}

## **Bemutató jelszóval való védelme online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válassza ki vagy töltse fel a bemutatót.
3. Adjon meg egy jelszót a megtekintés védelemhez.
4. Opcionálisan adjon meg egy külön jelszót a szerkesztés védelemhez.
5. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hu/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a bemutatót, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy titkosítaná a tartalmat.

**Ellenőrizhetem a nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezzen be prezentációs információkat, ellenőrizze, hogy nyitó jelszavas védelem van-e, és validálja a jelszót a teljes bemutatópéldány létrehozása előtt.

**Olvashat egy alkalmazás metaadatokat nyitó jelszó nélkül?**

Igen, de csak akkor, ha a bemutató titkosítása során az `encrypt_document_properties` `False` értékre van állítva. Ebben az esetben az alkalmazásnak a [Manage Presentation Properties](/slides/hu/python-net/presentation-properties/) leírásában szereplő csak dokumentumtulajdonságok betöltése módot kell használnia.

**Támogatják a jelszó-ellenőrző munkafolyamatok a PPT és PPTX formátumokat is?**

Igen. A fájlútvonal- és adatfolyam-alapú jelszófelismerés és validáció egyformán működik PPT és PPTX bemutatók esetén.