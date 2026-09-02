---
title: Digitális aláírások hozzáadása bemutatókhoz JavaScript-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítványkiadó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- bemutató biztonság
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX bemutatókat PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for Node.js-t Java segítségével a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a bemutatót, és hogy a aláírt tartalom megváltozott-e. Itt három kapcsolódó biztonsági fogalom fontos:

- A **digitális tanúsítvány** egy elektronikus hitelesítő adat, amely egy személyazonosságot köt egy nyilvános kulcshoz. Egy megbízható tanúsítványkibocsátó (CA) kibocsáthat tanúsítványt, vagy egy szervezet használhat önaláírt tanúsítványt belső munkafolyamatokhoz.
- A **digitális aláírás** a bemutató tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsával ezután ellenőrizhető az aláírás. Az aláírás a származás és az integritás bizonyítékát nyújtja; nem titkosítja a bemutatót.
- **Jelszóvédelem** szabályozza, hogy egy felhasználó megnyithatja vagy módosíthatja a bemutatót. Ez különálló a digitális aláírástól, és le van írva a [Jelszóval védett bemutatók](/slides/hu/nodejs-java/password-protected-presentation/) részben.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüben biztosítja.

![PowerPoint Védje a bemutatót menü, a Add a Digital Signature kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt bemutató megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a bemutató érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a aláírásokat a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) metódussal teszi elérhetővé, amely egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/) objektumot ad vissza, benne [DigitalSignature](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) objektumokkal. Egy bemutató több aláírást is tartalmazhat.

## **A PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és általában `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat egy X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára a aláírás létrehozását. Egy tanúsítvány, amelyhez nem férhető hozzá a privát kulcs, nem használható bemutató aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a bemutató megnyitásához vagy szerkesztéséhez. Ne helyezze a PFX fájlokat vagy azok jelszavait forráskód‑kezelő rendszerbe. Éles környezetben korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák környezeti változót használnak csak azért, hogy a jelszó ne legyen kódban ágyazva.

## **Digitális aláírás hozzáadása egy bemutatóhoz**

Egy valódi bemutató aláírásához töltse be a meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a bemutató kollekciójához, majd mentse PPTX fájlba.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.setComments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) által beállított érték leírja az aláírás célját; nem biztonsági szabályozás.

## **Digitális aláírások ellenőrzése**

Aláírt PPTX fájl betöltésekor vizsgálja meg minden elemet, amelyet a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) visszaad. A [DigitalSignature.isValid](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) metódus jelzi, hogy a beágyazott aláírás érvényes‑e az aktuális bemutató tartalmához képest.

Az alábbi példa a Node.js `X509Certificate` osztályt is használja, hogy kiolvassa minden beágyazott tanúsítvány alanynevet.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Egy érvénytelen eredmény általában azt jelenti, hogy az aláírt bemutató tartalma vagy az aláírás adatcsomagja az aláírás után megváltozott, vagy a fájl sérült. Minden aláírás eltávolítása aláíratlan bemutatót eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságkritikus munkafolyamatnak továbbá ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ez az érvényességi eredmény nem tekinthető teljes tanúsítvány‑bizalmi döntésnek. Biztonsági házirendjétől függően az alkalmazásának fel kell tudnia építeni és ellenőrizni az X.509 tanúsítványláncot, ellenőrizni a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősíteni a várt alanyt vagy ujjlenyomatot, ellenőrizni a kulcs felhasználását, valamint értékelni egy megbízható időbélyeget. A [DigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) értéke önmagában nem bizonyíték megbízható időbélyeg‑hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a bemutató biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, az összes aláírást eltávolítja a [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) metódussal, és elment egy aláíratlan másolatot.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyetlen aláírás eltávolításához hívja meg a [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) metódust a nulla‑bázisú indexével. Mentse új fájlba, hacsak nem szándékosan írja felül az eredeti aláírt fájlt a munkafolyamat részeként.

## **Szerkesztési és formátum szempontok**

- Egy aláírás nem teszi a bemutatót csak‑olvasásra. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes kívánt módosítást az aláírás előtt. Ha a bemutatót módosítani kell, mentse el a javított változatot, és írja alá újra azt a verziót.
- Tartsa a végső kimenetet PPTX formátumban. Egy aláírt bemutató más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát kezelje bizalmas információnak. Akárki, aki megszerzi a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött másolatot, ha a dokumentum‑megtartási szabályzat ezt megköveteli.

## **GYIK**

**Titkosítja-e a digitális aláírás a bemutatót?**

Nem. A digitális aláírás a származásról és az integritásról ad bizonyítékot, de a bemutató tartalma olvasható marad, ha külön titkosítás nem kerül alkalmazásra. Használja a [jelszóvédelmet](/slides/hu/nodejs-java/password-protected-presentation/), ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a jelszó, mint a bemutató jelszava?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldására szolgál. Nem szabályozza, hogy ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag igen, ha a tanúsítvány tartalmaz egy elérhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezethez. Nyilvános vagy szervezetek közötti munkafolyamatok általában megbízható CA‑tól kiállított tanúsítványt használnak.

**Mi tesz egy aláírást érvénytelené?**

Az aláírt bemutató tartalmának vagy az aláírás adatainak az aláírás után történt módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat sikertelen ellenőrzést. Ha az összes aláírás eltávolításra kerül, a bemutató aláíratlan, nem pedig egy érvénytelen aláírást tartalmazó fájl lesz.

**Jelent-e egy érvényes aláírás, hogy megbízhatok a feladóban?**

Nem önmagában. Az aláírás integritása és a feladó megbízhatósága külön döntések. Egy éles környezetben alkalmazott ellenőrzési házirendnek továbbá ellenőriznie kell a tanúsítványláncot, a lejárati időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs felhasználását, valamint a megbízható időbélyeg‑követelményeket.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem változtatja meg a bemutató bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás továbbra is elfogadható‑e, a házirendtől és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne támaszkodjon kizárólag a megjelenített aláírási időre megbízható időbélyegként.

**Módosítható-e egy aláírt bemutató?**

Igen. Az aláírás nem zárja le a fájlt. Az aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást, ezért előbb fejezze be a bemutatót, majd írja alá a végleges revíziót.

**Tartalmazhat-e egy bemutató több aláírást?**

Igen. Adja hozzá az egyes aláírásokat a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) által visszaadott kollekcióhoz a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely bemutatóformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides itt leírt digitális‑aláírás műveleteket csak PPTX formátumra támogatja. A PPT és az OpenDocument bemutatóformátumok nem támogatottak ezen API‑munkafolyamatban.

**Eltávolítható-e egy aláírás anélkül, hogy a diákra hatással lenne?**

Igen. Eltávolíthat egyetlen aláírást, vagy kiürítheti az egész kollekciót, majd elmentheti a bemutatót. A diák tartalma megmarad, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.