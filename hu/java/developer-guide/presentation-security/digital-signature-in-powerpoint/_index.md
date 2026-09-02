---
title: Digitális aláírások hozzáadása prezentációkhoz Java-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és az Aspose.Slides for Java segítségével ellenőrizni vagy eltávolítani a digitális aláírásokat."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy az aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus igazolvány, amely egy személyazonosságot egy nyilvános kulccsal kapcsolja össze. Egy megbízható tanúsítványkiadó (CA) adhat ki tanúsítványt, vagy egy szervezet használhat önaláírt tanúsítványt belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítja a forrást és a sértetlenséget; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy egy felhasználó meg tudja-e nyitni vagy módosítani a prezentációt. Ez különálló a digitális aláírástól, és a [Jelszóval védett prezentációk](/java/password-protected-presentation/) leírásában található.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüpont alatt kínálja.

![PowerPoint Protect Presentation menü, ahol a Add a Digital Signature ki van emelve](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely közli, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) metódussal teszi elérhetővé az aláírásokat, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/) interfészt valósítják meg. Egy prezentáció több aláírást is tartalmazhat.

## **A PFX tanúsítványok és jelszavak megértése**

A PFX fájl, más néven PKCS#12 fájl, gyakran `.pfx` vagy `.p12` kiterjesztéssel, egy X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot tartalmazhatja. A privát kulcs teszi lehetővé a tulajdonos számára, hogy aláírást hozzon létre. Egy tanúsítvány privát kulcs nélkül nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** a prezentáció megnyitásához vagy szerkesztéséhez szükséges jelszó. Ne kötelező fájlokban vagy jelszavakban tárolja a PFX fájlokat vagy azok jelszavait a forráskódban. Éles környezetben korlátozza a tanúsítványfájl hozzáférését, és a jelszót titkos tárolóból vagy más védett konfigurációs forrásból szerezze be. Az alábbi példák csak környezeti változót használnak, hogy elkerüljék a jelszó kódban való beágyazását.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valós aláírási munkafolyamat esetén töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/java/com.aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX fájlba.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. Az [IDigitalSignature.setComments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) által beállított érték leírja az aláírás célját; ez nem biztonsági vezérlő.

## **Digitális aláírások ellenőrzése**

Aláírt PPTX fájl betöltésekor vizsgálja meg minden, a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott elemet. Az [IDigitalSignature.isValid](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#isValid--) metódus jelzi, hogy a beágyazott aláírás érvényes‑e az aktuális prezentációtartalomra nézve.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy aláírási adatai módosultak az aláírás után, vagy a fájl megsérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzékeny munkafolyamatnak ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ezt a validitási eredményt nem szabad teljes tanúsítvány‑bizalmi döntésként kezelni. Biztonsági irányelveitől függően alkalmazásának előfordulhat, hogy fel kell építenie és ellenőriznie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi időszakát és visszavonási állapotát, megerősítenie a várt alany vagy ujjlenyomat meglétét, ellenőriznie kell a kulcsfelhasználást, és ki kell értékelnie egy megbízható időbélyeget. Az [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#getSignTime--) értéke önmagában nem bizonyíték megbízható időbélyeg‑szolgáltatótól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, az összes aláírást eltávolítja a [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/#clear--) metódussal, majd egy aláíratlan másolatot ment.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyetlen aláírás eltávolításához hívja meg a [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metódust a nulla‑alapú indexével. Mentse új fájlba, hacsak nem szándékosan írja felül az eredeti aláírt fájlt a munkafolyamat részeként.

## **Szerkesztési és formátum szempontok**

- Egy aláírás nem teszi a prezentációt csak‑olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes kívánt módosítást az aláírás előtt. Ha a prezentációt módosítani kell, mentse a módosított változatot, és írja alá azt újra.
- Tartsa meg a végső kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem adja át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- Kezelje a tanúsítvány privát kulcsát érzékeny adatként. Aki megszerezte a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek a tanúsítvány tulajdonosától származnak.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött példányt, ha a dokumentumtartási szabályzat ezt megköveteli.

## **GYIK**

**Titkosítja-e a digitális aláírás a prezentációt?**

Nem. A digitális aláírás bizonyítékot nyújt a forrásra és a sértetlenségre, de a prezentáció tartalma olvasható marad, hacsak külön titkosítás nincs alkalmazva. Használja a [jelszóvédelet](/java/password-protected-presentation/), ha a tartalom hozzáférését korlátozni kell.

**Ugyanaz a jelszó, mint a prezentáció jelszava?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldásához szükséges. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag igen, ha az tartalmaz elérhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Általános vagy szervezetek közötti munkafolyamatok általában megbízható CA‑tól származó tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**

Az aláírt prezentáció tartalmának vagy az aláírási adatoknak az aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat sikertelen ellenőrzést. Ha minden aláírást eltávolítanak, a prezentáció aláíratlan marad, nem pedig hibás aláírást tartalmaz.

**Érvényes aláírás azt jelenti, hogy megbízhatok a aláírón?**

Magától nem. Az aláírás integritása és a aláíró megbízhatósága külön döntések. Egy éles környezetben alkalmazott ellenőrzési szabályzatnak továbbá ellenőriznie kell a tanúsítványláncot, érvényességi időszakot, visszavonási állapotot, a várt személyazonosságot, kulcsfelhasználást és esetleges megbízható időbélyeg‑követelményeket.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás továbbra is elfogadható‑e, a szabályzatától és attól függ, hogy egy megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne támaszkodjon kizárólag a megjelenített aláírási időre megbízható időbélyegként.

**Módosítható egy aláírt prezentáció?**

Igen. Az aláírás nem zárolja a fájlt. A aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá a végső változatot.

**Tartalmazhat-e egy prezentáció több aláírást?**

Igen. Adja hozzá minden aláírást a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott gyűjteményhez mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátumra vonatkozóan támogatja a leírt digitális‑aláírási műveleteket. A PPT és az OpenDocument prezentációs formátumok nincsenek támogatva ezen API‑munkafolyamatban.

**Eltávolítható egy aláírás anélkül, hogy a diák megváltoznának?**

Igen. Eltávolíthat egy aláírást vagy kiürítheti az egész gyűjteményt, majd elmentheti a prezentációt. A diák tartalma megmarad, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.