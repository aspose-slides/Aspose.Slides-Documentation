---
title: Digitális aláírások hozzáadása prezentációkhoz JavaScript-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- prezentációbiztonság
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet meglévő PPTX prezentációkat aláírni PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for Node.js‑t Java‑ban a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Overview**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy az aláírt tartalom megváltozott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digital certificate** egy elektronikus hitelesítő, amely egy azonosítót összekapcsol egy nyilvános kulccsal. Egy megbízható tanúsítvány kibocsátó (CA) kiadhat tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digital signature** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Egy aláírás bizonyítja a származást és az integritást; nem titkosítja a prezentációt.
- **Password protection** szabályozza, hogy a felhasználó megnyithat‑e vagy módosíthat‑e egy prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Password-Protected Presentations](/nodejs-java/password-protected-presentation/)-ben.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüben kínálja.

![PowerPoint Protect Presentation menü, ahol a Digitális aláírás hozzáadása ki van emelve](add-digital-signature-in-powerpoint.png)

Egy aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely szerint a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Aspose.Slides a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) segítségével teszi elérhetővé az aláírásokat, amely egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/)‑t ad vissza, benne [DigitalSignature](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) objektumokkal. Egy prezentáció több aláírást is tartalmazhat.

## **Értse meg a PFX tanúsítványokat és jelszavakat**

Egy PFX fájl, más néven PKCS#12 fájl, gyakran .pfx vagy .p12 kiterjesztéssel, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára az aláírás létrehozását. Egy tanúsítvány, amelyhez nem férhető hozzá privát kulcs, nem használható prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne adja hozzá a PFX fájlokat vagy jelszavaikat a forráskód‑kezelőhöz. Éles környezetben korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák csak környezeti változót használnak, hogy elkerüljék a jelszó kódban való beágyazását.

## **Digitális aláírás hozzáadása egy prezentációhoz**

Egy valós aláírási munkafolyamatban töltse be a meglévő PPTX fájlt, hozza létre a [DigitalSignature](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítvány és annak jelszava alapján, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX‑ként.

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

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.setComments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) által beállított érték leírja az aláírás célját; ez nem biztonsági ellenőrzés.

## **Digitális aláírások ellenőrzése**

Aláírt PPTX fájl betöltésekor vizsgálja meg minden elemet, amelyet a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) visszaad. A [DigitalSignature.isValid](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) módszer jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentáció tartalmához képest.

A következő példa a Node.js `X509Certificate` osztályt is használja, hogy kiolvassa az alany nevét minden beágyazott tanúsítványból.

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

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírás adatcsomagja megváltozott az aláírás után, vagy a fájl sérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, így csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzetes munkafolyamatnak ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ez az érvényességi eredmény nem tekinthető teljes tanúsítvány‑bizalom döntésnek. Biztonsági politikájától függően alkalmazásának esetleg fel kell építenie és ellenőriznie az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősíteni a várt alanyt vagy ujjlenyomatot, ellenőrizni a kulcshasználatot, valamint értékelni egy megbízható időbélyeget. A [DigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignature/) értéke önmagában nem bizonyíték megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) segítségével, majd elment egy aláíratlan másolatot.

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

Csak egy aláírás eltávolításához hívja meg a [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) metódust a nulla‑alapú indexével. Mentse egy új fájlba, hacsak nem szándékosan felülírja az eredeti aláírt fájlt a munkafolyamat részeként.

## **Szerkesztés és formátum‑szempontok**

- Egy aláírás nem teszi a prezentációt csak‑olvasásra. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes kívánt szerkesztést aláírás előtt. Ha a prezentációt módosítani kell, mentse el a módosított változatot, és írja alá újra.
- Tartsa meg a végső kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem adja át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- Kezelje a tanúsítvány privát kulcsát érzékeny információként. Akárki, aki megszerzi a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik kontrollált példányt, ha a dokumentumtartási politikája ezt megköveteli.

## **GYIK**

**Titkosítja a digitális aláírás a prezentációt?**

Nem. A digitális aláírás bizonyítékot nyújt a származásra és az integritásra, de a prezentáció tartalma olvasható marad, hacsak nem alkalmaznak külön titkosítást. Használja a [password protection](/nodejs-java/password-protected-presentation/) lehetőséget, ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a jelszó, mint a prezentáció jelszava?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldásához szükséges. Nem szabályozza, hogy ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz elérhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adják hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy kereszt‑szervezeti munkafolyamatok általában megbízható CA‑tól kiállított tanúsítványt használnak.

**Mi tesz egy aláírást érvénytelené?**

Az aláírt prezentáció tartalmának vagy az aláírás adatának módosítása az aláírás után érvénytelenítheti azt. A fájl sérülése is okozhat sikertelen ellenőrzést. Ha az összes aláírást eltávolítják, a prezentáció aláíratlan lesz, nem egy érvénytelen aláírást tartalmazó fájl.

**Jelenti-e egy érvényes aláírás, hogy megbízhatok az aláírón?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben használt ellenőrzési szabályzatnak ellenőriznie kell a tanúsítványláncot, érvényességi időszakot, visszavonási állapotot, várt személyazonosságot, kulcshasználatot és minden megbízható időbélyegző‑követelményt.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem változtatja meg a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás még elfogadható‑e, a szabályzattól és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényes időszaka alatt történt. Ne csak a megjelenített aláírási időt tekintse megbízható időbélyegnek.

**Módosítható még egy aláírt prezentáció?**

Igen. Az aláírás nem zárolja a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá a végső verziót.

**Tartalmazhat egy prezentáció több aláírást?**

Igen. Adja hozzá minden aláírást a [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) által visszaadott gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak PPTX formátumban támogatja a leírt digitális‑aláírási műveleteket. A PPT és OpenDocument prezentációs formátumok nincsenek támogatva ezzel az API‑val.

**Eltávolíthatok egy aláírást anélkül, hogy a diákra hatással lenne?**

Igen. Eltávolíthat egy aláírást vagy kiürítheti az egész gyűjteményt, majd mentheti a prezentációt. A diákkönyvtár tartalma megmarad, de a mentett fájl már nem tartalmazza a eltávolított aláírás bizonyítékát.