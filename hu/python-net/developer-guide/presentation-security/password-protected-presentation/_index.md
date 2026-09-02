---
title: Jelszóval védett bemutatók Pythonban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/python-net/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- bemutató jelszó érvényesítése
- bemutató jelszó ellenőrzése
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- Python
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg, és fejtsa vissza a jelszóval védett PowerPoint PPT és PPTX bemutatókat Pythonban az Aspose.Slides segítségével."
---
## **Áttekintés**

Az nyitó jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, ezért ez a védelem titkosságot biztosít.

Az nyitó jelszó különbözik a írásvédelmi jelszóktól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza a bemutató betöltését. A bemutatók módosításához szükséges jelszavak kezeléséhez lásd [Write-Protect Presentations](/slides/hu/python-net/write-protected-presentation/).

Az alábbi munkafolyamatok a PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formát használják, ahol a fájl alapú és a folyam alapú viselkedés fontos.

## **Nyitó jelszóval való bemutató titkosítása**

Használja a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/encrypt/) függvényt nyitó jelszó hozzárendeléséhez. Ezután használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a titkosított bemutató mentéséhez.

A következő példa egy PPTX bemutatót titkosít:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Titkosított bemutató betöltése**

Állítsa be a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) értékét a nyitó jelszóra, és adja át a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának a betöltési opciókat. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Dolgozz a visszafejtett bemutatóval.
    pass
```

## **Titkosítás eltávolítása egy bemutatóból**

Töltse be a bemutatót a nyitó jelszóval, hívja meg a [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/remove_encryption/) metódust, majd mentse az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) függvényt a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) lekérdezéséhez anélkül, hogy teljes bemutató példányt hozna létre. Ellenőrizze a [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/is_password_protected/) értékét, mielőtt jelszót kérne vagy validálná azt. Ha védelem van jelen, validálja a megadott értéket a [PresentationInfo.check_password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_password/) segítségével.

### **Fájlúton végzett munkafolyamat**

A következő példa egy PPTX fájl nyitó jelszavát ellenőrzi, a validált értéket átadja a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) beállításnak, majd betölti a teljes bemutatót:

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

### **Folam alapú munkafolyamat**

A [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) folyam túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza egy kereshető (seekable) folyam pozícióját, mielőtt a teljes bemutatót betöltené a folyamról.

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

A [PresentationInfo.check_password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/check_password/) `True` értéket ad vissza csak akkor, ha a bemutató rendelkezik nyitó jelszóval, és a megadott jelszó helyes. `False` értéket ad a következő esetekben:

- A jelszó helytelen.
- A bemutató nem rendelkezik nyitó jelszóval.
- A megadott jelszó `None` vagy üres.

A viselkedés PPT és PPTX bemutatók esetén is ugyanaz.

## **Ellenőrizze, hogy a betöltött bemutató titkosított-e**

A megfelelő jelszóval betöltött bemutató után vizsgálja meg a [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/is_encrypted/) állapotát, hogy megerősítse, a forrás bemutató titkosítva volt-e. A nyitó jelszavas védelem betöltés előtti észleléséhez használja a `PresentationInfo.is_password_protected`-t, ahogyan fentebb látható.

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
Ne naplózza a nyitó jelszavakat, és ne tartalmazza őket diagnosztikai üzenetekben. Kerülje a felesleges ismételt ellenőrzési kísérleteket, csak a szükséges időtartamig tartsa a jelszavakat a memóriában, és használja újra a sikeres ellenőrzés eredményét, amikor azonnal betölti a bemutatót.
{{% /alert %}}

## **Bemutató jelszóval való védelme online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
1. Válassza ki vagy töltse fel a bemutatót.
1. Adjon meg egy jelszót a megtekintési védelemhez.
1. Opcionálisan adjon meg külön jelszót a szerkesztési védelemhez.
1. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hu/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

Az nyitó jelszó titkosítja a bemutatót, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy titkosítaná a tartalmat.

**Érvényesíthetek nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze be a bemutató információit, ellenőrizze, hogy van-e nyitó jelszavas védelem, és validálja a jelszót, mielőtt teljes bemutató példányt hozna létre.

**Támogatják a jelszó-ellenőrző munkafolyamatok a PPT és PPTX formátumokat is?**

Igen. A fájlúton és a folyam alapú jelszódetektálás és validálás ugyanúgy működik PPT és PPTX bemutatók esetén.