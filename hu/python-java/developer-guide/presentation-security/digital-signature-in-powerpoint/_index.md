---
title: Digitális aláírások hozzáadása a bemutatókhoz Pythonban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/python-java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- bemutató biztonság
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet meglévő PPTX bemutatókat aláírni PFX tanúsítványokkal, és használja az Aspose.Slides for Python via Java könyvtárat a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a bemutatót, és hogy a aláírt tartalom megváltozott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digital certificate** egy elektronikus hitelesítő adat, amely egy személyazonosságot egy nyilvános kulccsal kapcsol össze. Egy megbízható tanúsítványkibocsátó (CA) kiadhat tanúsítványt, vagy egy szervezet saját aláírt tanúsítványt használhat belső folyamatokhoz.
- A **digital signature** a bemutató tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás az eredet és az integritás bizonyítékát nyújtja; nem titkosítja a bemutatót.
- **Password protection** szabályozza, hogy a felhasználó megnyithat‑e vagy módosíthat‑e egy bemutatót. Ez különáll a digitális aláírástól, és a [Jelszóval védett bemutatók](/slides/hu/python-java/password-protected-presentation/) fejezetben van leírva.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüben biztosítja.

![PowerPoint "Védje a bemutatót" menü az "Digitális aláírás hozzáadása" kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt bemutató megnyitása után a PowerPoint megjelenítheti az aláírás‑állapotról szóló értesítést.

![PowerPoint értesítés, amely közli, hogy a bemutató érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a **Presentation.getDigitalSignatures** metódussal teszi elérhetővé az aláírásokat, amely egy **DigitalSignatureCollection**‑t ad vissza, amelynek elemei **DigitalSignature** példányok. Egy bemutató több aláírást is tartalmazhat.

## **A PFX tanúsítványok és jelszavak megértése**

A PFX fájl, más néven PKCS#12 fájl, általában `.pfx` vagy `.p12` kiterjesztéssel, tartalmazhat egy X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára az aláírás létrehozását. Egy tanúsítvány, amelyhez nem jár elérhető privát kulcs, nem használható a bemutató aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** a bemutató megnyitásához vagy szerkesztéséhez szükséges jelszó. Ne kötelezze el a PFX fájlokat vagy azok jelszavait a forráskódtárban. Gyártási környezetben korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy egy másik védett konfigurációs forrásból. Az alábbi példák egy környezeti változót használnak csak azért, hogy ne legyen a kódban beágyazva a jelszó.

## **Digitális aláírás hozzáadása a bemutatóhoz**

Egy valós bemutató aláírásához töltse be a meglévő PPTX fájlt, hozza létre a **DigitalSignature**‑t egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a bemutató gyűjteményéhez, majd mentse PPTX fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. A **DigitalSignature.setComments** metódussal beállított érték az aláírás célját írja le; ez nem biztonsági vezérlő.

## **Digitális aláírások ellenőrzése**

Aláírt PPTX fájl betöltésekor vizsgálja meg minden elemet, amelyet a **Presentation.getDigitalSignatures** visszaad. A **DigitalSignature.isValid** metódus jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi bemutató tartalomra nézve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt bemutató tartalma vagy az aláírási adatok a aláírás után megváltoztak, vagy a fájl sérült. Minden aláírás eltávolítása aláíratlan bemutatót eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságkritikus folyamatnak továbbá ellenőriznie kell, hogy a várt számú aláírás és a várt aláírók azonosítói jelen vannak‑e.

Ez az érvényességi eredmény nem tekinthető teljes tanúsítvány‑bizalmi döntésnek. A biztonságpolitikától függően az alkalmazásnak fel kell építenie és ellenőriznie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie kell a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcs‑használatot, valamint értékelnie kell a megbízható időbélyeget. A **DigitalSignature.getSignTime** értéke önmagában nem bizonyíték megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a bemutató biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a **DigitalSignatureCollection.clear** metódussal, és ment egy aláíratlan másolatot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egyetlen aláírás eltávolításához hívja meg a **DigitalSignatureCollection.removeAt**‑t a nullától kezdődő indexével. Mentse új fájlba, hacsak nem része a munkafolyamatnak a felülírásra szánt aláírt eredeti.

## **Szerkesztési és formátumra vonatkozó megfontolások**

- Egy aláírás nem teszi a bemutatót csak‑olvashatóvá. A felhasználók és az alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes kívánt módosítást az aláírás előtt. Ha a bemutatót módosítani kell, mentse a módosított változatot, és aláírja azt újra.
- Tartsa meg a végső kimenetet PPTX formátumban. Egy aláírt bemutató más formátumba történő konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát tekintse bizalmas információnak. Aki megszerzi a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött példányt, ha a dokumentum‑megőrzési szabályzat ezt előírja.

## **GYIK**

**A digitális aláírás titkosítja a bemutatót?**

Nem. A digitális aláírás az eredet és az integritás bizonyítékát nyújtja, de a bemutató tartalma olvasható marad, hacsak nem alkalmaz külön titkosítást. Használja a [jelszóval védett bemutatókat](/slides/hu/python-java/password-protected-presentation/), ha a tartalomhoz való hozzáférést korlátozni kell.

**A PFX jelszó megegyezik a bemutató jelszavával?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldására szolgál. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok saját aláírt tanúsítványt?**

Technikailag igen, ha a saját aláírt tanúsítvány tartalmaz elérhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Általános vagy kereszt‑szervezeti munkafolyamatok általában egy megbízható CA által kibocsátott tanúsítványt használnak.

**Mi teszi az aláírást érvénytelené?**

A aláírt bemutató tartalmának vagy az aláírási adatoknak a módosítása az aláírás érvénytelenítését eredményezi. A fájl sérülése is okozhat hibás ellenőrzést. Ha az összes aláírást eltávolítják, a bemutató aláíratlan, nem pedig érvénytelen aláírást tartalmaz.

**Érvényes aláírás azt jelenti, hogy megbízhatok az aláírón?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy gyártási ellenőrzési szabályzatnak továbbá ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs‑használatot és minden megbízható időbélyegző követelményt.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a bemutató bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás továbbra is elfogadható‑e, a szabályzattól és attól függ, hogy egy érvényes megbízható időbélyegző bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi időszaka alatt történt. Ne bízzon csak a megjelenített aláírási időben, mint megbízható időbélyegben.

**Egy aláírt bemutatót továbbra is szerkeszthetünk?**

Igen. Az aláírás nem zárolja a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a bemutatót, majd írja alá az utolsó változatot.

**Egy bemutató több aláírást is tartalmazhat?**

Igen. Adjon minden aláírást a **Presentation.getDigitalSignatures** által visszaadott gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely bemutatóformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátumban támogatja a leírt digitális‑aláírási műveleteket. A PPT és az OpenDocument bemutatóformátumok nem támogatottak ezen API‑munkafolyamatban.

**Eltávolíthatok egy aláírást anélkül, hogy a dia változna?**

Igen. Eltávolíthat egyetlen aláírást vagy kiürítheti az egész gyűjteményt, majd mentheti a bemutatót. A dia‑tartalom megmarad, de a mentett fájl már nem hordozza a eltávolított aláírás bizonyítékát.