---
title: Digitális aláírások hozzáadása prezentációkhoz Pythonban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/python-net/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- prezentáció biztonság
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és az Aspose.Slides for Python via .NET‑et használni a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írása aláírta a prezentációt és hogy a aláírt tartalom megváltozott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digital certificate** egy elektronikus igazolvány, amely egy azonosítót társít egy nyilvános kulccsal. Egy megbízható tanúsítványkiadó (CA) kiadhat egy tanúsítványt, vagy egy szervezet használhat önaláírt tanúsítványt belső munkafolyamatokhoz.
- A **digital signature** egy prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítékot nyújt a származásra és az integritásra; nem titkosítja a prezentációt.
- **Password protection** szabályozza, hogy egy felhasználó megnyithatja vagy módosíthatja‑e a prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/).

A PowerPoint a **Add a Digital Signature** parancsot kínálja a **File > Info > Protect Presentation** menüben.

![PowerPoint "Protect Presentation" menü, amely a "Add a Digital Signature" elemet emeli ki](add-digital-signature-in-powerpoint.png)

Miután egy aláírt prezentációt megnyitnak, a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely közli, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) segítségével teszi elérhetővé az aláírásokat, egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/), amelyben az elemek [DigitalSignature](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) objektumok. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amely PKCS#12 fájlként is ismert, és általában `.pfx` vagy `.p12` kiterjesztést kap, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára, hogy aláírást hozzon létre. Egy tanúsítvány, amelyhez nincs hozzáférhető privát kulcs, nem használható prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne helyezzen PFX fájlokat vagy azok jelszavait verziókezelőbe. Éles környezetben korlátozza a hozzáférést a tanúsítványfájlhoz, és a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból szerezze be. Az alábbi példák környezeti változót használnak kizárólag a jelszó kódba ágyazásának elkerülése érdekében.

## **Digitális aláírás hozzáadása egy prezentációhoz**

Egy valódi prezentáció aláírásához töltse be a meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse el PPTX fájlba.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.comments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/comments/) érték leírja az aláírás célját; ez nem biztonsági ellenőrzés.

## **Digitális aláírások ellenőrzése**

Amikor egy aláírt PPTX fájlt tölt be, vizsgálja meg a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) minden elemét. A [DigitalSignature.is_valid](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/is_valid/) tulajdonság jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentáció tartalmához.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírás adatai megváltoztak az aláírás után, vagy hogy a fájl sérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, így csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonság‑érzékeny munkafolyamatnak ellenőriznie kell továbbá, hogy a várt számú aláírás és a várt aláírók azonosítói jelen vannak‑e.

A [DigitalSignature.certificate](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/certificate/) tulajdonság a tanúsítvány adatát byte‑tömbként adja vissza. A példa kiszámítja a SHA‑256 ujjlenyomatát, hogy egy alkalmazás össze tudja hasonlítani a várt aláíró tanúsítvány ujjlenyomatával.

Ezt az érvényességi eredményt nem szabad teljes tanúsítvány‑bizalom döntésként kezelni. A biztonsági politika függvényében az alkalmazásnak elő kell készítenie és érvényesítenie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcs felhasználását, és ki kell értékelnie egy megbízható időbélyeget. A [DigitalSignature.sign_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/sign_time/) érték önmagában nem bizonyíték egy megbízható időbélyeg‑hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/clear/) segítségével, és elment egy aláíratlan másolatot.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Egyetlen aláírás eltávolításához hívja meg a [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/remove_at/) metódust a nullától kezdődő indexével. Mentse új fájlba, hacsak a megváltoztatott aláírt eredeti felülírása nem része a munkafolyamatnak.

## **Szerkesztési és formátummal kapcsolatos megfontolások**

- Az aláírás nem teszi a prezentációt csak‑olvasásra. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Tegye meg a tervezett szerkesztéseket aláírás előtt. Ha a prezentációt módosítani kell, mentse el az átdolgozott változatot, és aláírja azt újra.
- Tartsa a végső kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát érzékenynek tekintse. Aki megszerzi a privát kulcsot és annak jelszavát, az képes lehet olyan aláírásokat létrehozni, amelyek azt a tanúsítvány tulajdonosától származónak látszanak.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött példányt, ha a dokumentummegőrzési szabályzat ezt előírja.

## **FAQ**

**A digitális aláírás titkosítja a prezentációt?**

Nem. A digitális aláírás bizonyítékot nyújt a származásra és az integritásra, de a prezentáció tartalma olvasható marad, hacsak külön titkosítás nem kerül alkalmazásra. Használja a [jelszóvédelmet](/slides/hu/python-net/password-protected-presentation/), ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a PFX jelszó, mint a prezentáció jelszója?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldására szolgál. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag egy önaláírt tanúsítvány használható, ha tartalmazza a hozzáférhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni, hacsak a tanúsítványt nem adták hozzá expliciten a megbízható környezetükhöz. Nyilvános vagy szervezetek közötti munkafolyamatok általában egy megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**

Az aláírt prezentáció tartalmának vagy az aláírás adatainak aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat hibát az ellenőrzés során. Ha az összes aláírás eltávolításra kerül, a prezentáció aláíratlan lesz, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Egy érvényes aláírás azt jelenti, hogy megbízhatom az aláírón?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben alkalmazott ellenőrzési szabálynak ellenőriznie kell továbbá a tanúsítványláncot, az érvényességi időszakot, a visszavonás állapotát, a várt azonosítót, a kulcs felhasználását, és bármilyen megbízható időbélyeg‑követelményt.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás még elfogadható‑e, a szabályzatától és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi időszakában történt. Ne csak a megjelenített aláírási időre támaszkodjon megbízható időbélyegként.

**Módosítható továbbra is egy aláírt prezentáció?**

Igen. Az aláírás nem zárolja a fájlt. A aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd aláírja a végső változatot.

**Tartalmazhat egy prezentáció több aláírást is?**

Igen. Minden aláírást adjon a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) gyűjteményhez mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy az összes szükséges aláírót tartalmazza.

**Mely prezentációformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátumra támogatja a leírt digitális aláírási műveleteket. A PPT és az OpenDocument prezentációformátumok nem támogatottak ezzel az API‑munkafolyammal.

**Eltávolíthatok aláírást a diákra hatás nélkül?**

Igen. Egy aláírást eltávolíthat vagy kiürítheti az egész gyűjteményt, majd elmentheti a prezentációt. A diákat továbbra is elérhetőek maradnak, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.