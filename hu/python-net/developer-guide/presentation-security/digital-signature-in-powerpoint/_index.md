---
title: Digitális aláírások hozzáadása prezentációkhoz Pythonban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/python-net/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítványkiadó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- prezentáció biztonság
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és a .NET-en keresztül elérhető Aspose.Slides for Python segítségével ellenőrizni vagy eltávolítani a digitális aláírásokat."
---
## **Áttekintés**

Egy digitális aláírás segít a címzettnek meghatározni, hogy ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági koncepció fontos itt:

- A **digital certificate** egy elektronikus hitelesítő, amely egy személyazonosságot társít egy nyilvános kulccsal. Egy megbízható tanúsítványkiadó (CA) kiadhat egy tanúsítványt, vagy egy szervezet saját aláírású tanúsítványt használhat belső folyamatokhoz.
- A **digital signature** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítja a forrást és az integritást; nem titkosítja a prezentációt.
- **Password protection** szabályozza, hogy egy felhasználó megnyithatja-e vagy módosíthatja a prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Jelszóval védett prezentációk](/python-net/password-protected-presentation/).

A PowerPoint biztosítja a **Digitális aláírás hozzáadása** parancsot a **Fájl > Info > Prezentáció védelme** menüpont alatt.

![PowerPoint Protect Presentation menü, ahol a Digitális aláírás hozzáadása ki van emelve](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, miszerint a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a digitális aláírásokat a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) segítségével teszi elérhetővé, amely egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/) elemei [DigitalSignature](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) objektumok. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is hívnak, és általában *.pfx* vagy *.p12* kiterjesztést kap, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára az aláírás létrehozását. Egy tanúsítvány, amelyhez nem férhető hozzá privát kulcs, nem használható prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne küldje el a PFX fájlokat vagy azok jelszavait forráskódban verziókezelésbe. Éles környezetben korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbiakban egy környezeti változót használnak csak azért, hogy a jelszó ne legyen beágyazva a kódban.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valós aláírási munkafolyamatban töltse be a meglévő PPTX fájlt, hozza létre a [DigitalSignature](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítvány és annak jelszava alapján, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX fájlként.

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

Az eredmény új néven mentve megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.comments](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/comments/) érték leírja az aláírás célját; nem biztonsági intézkedés.

## **Digitális aláírások ellenőrzése**

Amikor betölt egy aláírt PPTX fájlt, vizsgálja meg minden elemet a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/)-ben. A [DigitalSignature.is_valid](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/is_valid/) tulajdonság jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentációtartalomhoz képest.

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

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírási adatok megváltoztak az aláírás után, vagy hogy a fájl sérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elég: egy biztonság‑érzékeny munkafolyamatnak továbbá ellenőriznie kell, hogy a várt számú aláírás és a várt aláírói identitások jelen vannak‑e.

A [DigitalSignature.certificate](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/certificate/) tulajdonság a tanúsítvány adatát bájt­tömbként biztosítja. A példa kiszámítja a SHA‑256 ujjlenyomatát, hogy az alkalmazás össze tudja hasonlítani egy várt aláírói tanúsítvány ujjlenyomatával.

Ez az érvényességi eredmény nem tekinthető teljes tanúsítvány‑bizalmi döntésnek. Biztonsági irányelveitől függően az alkalmazásnak esetleg fel kell építenie és ellenőriznie az X.509 tanúsítványláncot, a tanúsítvány érvényességi dátumait és visszavonási állapotát, a várt alanyt vagy ujjlenyomatot, a kulcsfelhasználást, valamint egy megbízható időbélyeget. A [DigitalSignature.sign_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/sign_time/) értéke önmagában nem bizonyíték megbízható időbélyeg‑hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, az összes aláírást eltávolítja a [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/clear/) segítségével, majd egy aláíratlan másolatot ment.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Egyetlen aláírás eltávolításához hívja a [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/remove_at/) metódust a nulla‑bázisú indexszel. Mentsen új fájlba, hacsak nem szándékosan felülírja az eredeti aláírt fájlt a munkafolyamat részeként.

## **Szerkesztés és formátum megfontolások**

- Egy aláírás nem teszi a prezentációt csak olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el a kívánt módosításokat aláírás előtt. Ha a prezentációt módosítani kell, mentse el a módosított verziót, és aláírja azt újra.
- Tartsa a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát tekintse érzékenynek. Aki hozzájut a privát kulcshoz és annak jelszavához, képes lehet olyan aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött másolatot, ha dokumentumtartási szabályzata ezt előírja.

## **GYIK**

**Titkosítja-e a digitális aláírás a prezentációt?**

Nem. A digitális aláírás bizonyítja a forrást és az integritást, de a tartalom továbbra is olvasható, kivéve ha külön titkosítás került alkalmazásra. Használja a [jelszóvédelem](/python-net/password-protected-presentation/) lehetőséget, ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a jelszó, ami a PFX fájlt védi, a prezentáció jelszava is?**

Nem. A PFX jelszó a tanúsítvány csomagban tárolt privát kulcs feloldásához szükséges. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok‑e saját aláírású tanúsítványt?**

Technikailag igen, ha a saját aláírású tanúsítvány tartalmazza a hozzáférhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak nem adták hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy szervezetek közötti munkafolyamatok általában megbízható CA‑ által kiadott tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**

Az aláírt prezentáció tartalmának vagy az aláírási adatoknak az aláírás után történő módosítása érvényteleníti az aláírást. A fájl sérülése is okozhat hibás ellenőrzést. Ha az összes aláírást eltávolítják, a prezentáció egyszerűen aláíratlan lesz, nem pedig „érvénytelen aláírást” tartalmaz.

**Érvényes aláírás azt jelenti, hogy megbízhatok az aláíróban?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön‑külön döntések. Egy termelési ellenőrzési politika mellett a tanúsítványlánc, az érvényességi időszak, a visszavonási állapot, a várt azonosító, a kulcsfelhasználás és a megbízható időbélyeg is ellenőrizendő.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás még elfogadható‑e, a szabályzatától és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne csak a megjelenített aláírási időt használja megbízható időbélyegként.

**Szerkeszthető marad egy aláírt prezentáció?**

Igen. Az aláírás nem zárolja a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért előbb fejezze be a prezentációt, majd írja alá a végleges változatot.

**Tartalmazhat‑e egy prezentáció több aláírást?**

Igen. Minden aláírást adjon a [Presentation.digital_signatures](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy az összes szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak PPTX formátumban támogatja a leírt digitális‑aláírás műveleteket. A PPT és az OpenDocument prezentációs formátumok nincsenek támogatva ezzel az API‑val.

**Eltávolíthatok‑e aláírást anélkül, hogy a diákra hatással lenne?**

Igen. Egy aláírást eltávolíthat, vagy a teljes gyűjteményt kiürítheti, majd elmentheti a prezentációt. A dia‑tartalom megmarad, de a mentett fájl már nem hordozza az eltávolított aláírás bizonyítékát.