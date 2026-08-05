---
title: Digitális aláírások hozzáadása prezentációkhoz Androidon
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/androidjava/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítványkiadó
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- prezentációbiztonság
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és az Aspose.Slides for Android Java használatával ellenőrizni vagy eltávolítani a digitális aláírásokat."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott-e. Itt három kapcsolódó biztonsági fogalom fontos.

- A **digitális tanúsítvány** egy elektronikus igazolvány, amely egy személyazonosságot egy nyilvános kulccsal társít. Egy megbízható tanúsítványkiadó (CA) kiadhat tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Egy aláírás bizonyítja a forrást és az integritást; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy egy felhasználó megnyithatja-e vagy módosíthatja-e a prezentációt. Ez elkülönül a digitális aláírástól, és a [Password-Protected Presentations](/androidjava/password-protected-presentation/) című cikkben van leírva.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüben biztosítja.

![PowerPoint Protect Presentation menü, a Add a Digital Signature kiemelve](add-digital-signature-in-powerpoint.png)

Miután egy aláírt prezentációt megnyitnak, a PowerPoint megjeleníthet aláírási állapot értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) metóduson keresztül teszi elérhetővé az aláírásokat, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/) felületet valósítják meg. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek és gyakran `.pfx` vagy `.p12` kiterjesztést kap, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé, hogy a tulajdonos aláírást készítsen. Egy tanúsítvány, amelynek privát kulcsa nem érhető el, nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** a prezentáció megnyitásához vagy szerkesztéséhez szükséges jelszó. Ne küldje be a PFX fájlokat vagy azok jelszavait forráskód‑kezelőbe. Éles környezetben korlátozza a tanúsítványfájl elérését, és a jelszót titkos tárolóból vagy más védett konfigurációs forrásból szerezze be. Az alábbi példák csak egy környezeti változót használnak, hogy ne legyen a jelszó a kódban.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valós aláírási munkafolyamat során töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX fájlba.

```java
import com.aspose.slides.*;

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

Az eredmény új néven történő mentése megőrzi az aláíratlan forrásfájlt. A [IDigitalSignature.setComments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) által beállított érték leírja az aláírás célját; ez nem biztonsági vezérlő.

## **Digitális aláírások ellenőrzése**

Amikor aláírt PPTX fájlt tölt be, vizsgálja meg minden elemet, amelyet a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) visszaad. A [IDigitalSignature.isValid](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#isValid--) metódus jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentációtartalomra nézve.

```java
import com.aspose.slides.*;

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

A hibás eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírási adatok a aláírás után megváltoztak, vagy hogy a fájl sérült. Az összes aláírás eltávolítása aláíratlan prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonság‑érzékeny munkafolyamatnak ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ezt a validitási eredményt nem szabad teljes tanúsítvány‑megbízhatósági döntésnek tekinteni. A biztonsági politika függvényében az alkalmazásnak esetleg fel kell építenie és validálnia kell az X.509 tanúsítványláncot, ellenőrizni kell a tanúsítvány érvényességi időszakát és visszavonási állapotát, megerősíteni a várt alanyt vagy ujjlenyomatot, ellenőrizni a kulcs használatát, és értékelni egy megbízható időbélyeget. A [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) értéke önmagában nem bizonyíték megbízható időbélyeg‑szolgáltatótól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) metódussal, és elment egy aláíratlan másolatot.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy aláírást szeretne eltávolítani, hívja meg a [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metódust a nulla‑bázisú indexével. Mentse új fájlba, hacsak a felülírás a folyamat szándékos része nem.

## **Szerkesztési és formátum‑szempontok**

- Egy aláírás nem teszi a prezentációt csak‑olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el a kívánt szerkesztéseket aláírás előtt. Ha a prezentációt módosítani kell, mentse el a módosított változatot, és aláírja azt újra.
- Tartsa a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem adja át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát tekintse érzékeny adatnak. Aki megszerzi a privát kulcsot és annak jelszavát, aláírásokat hozhat létre, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik kontrollált másolatot, ha a dokumentum‑megőrzési politika ezt megköveteli.

## **GYIK**

**A digitális aláírás titkosítja a prezentációt?**

Nem. A digitális aláírás bizonyítja a forrást és az integritást, de a prezentáció tartalma olvasható marad, hacsak külön nem titkosítják. Használja a [password protection](/androidjava/password-protected-presentation/) funkciót, ha a hozzáférést korlátozni kell.

**A PFX jelszó ugyanaz, mint a prezentáció jelszója?**

Nem. A PFX jelszó a tanúsítvány csomagban tárolt privát kulcs feloldásához szükséges. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag igen, ha a tanúsítvány tartalmaz hozzáférhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak nem adták hozzá expliciten a megbízható környezetükhöz. Publikus vagy kereszt‑szervezeti munkafolyamatok általában megbízható CA‑tól kiadott tanúsítványt használnak.

**Mi teszi az aláírást érvénytelenül?**

Az aláírt prezentáció tartalmának vagy az aláírási adatoknak a módosítása az aláírást érvényteleníti. A fájl sérülése is okozhat hibás ellenőrzést. Ha minden aláírást eltávolítanak, a prezentáció aláíratlan, nem pedig hibás aláírású lesz.

**Egy érvényes aláírás azt jelenti, hogy megbízhatok az alírón?**

Nem egyedül. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben a validációs szabályzatnak a tanúsítványlánc, az érvényességi időszak, a visszavonási állapot, a várt személyazonosság, a kulcs használat, és a megbízható időbélyeg követelményei is ellenőrzésre kell kerüljenek.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány‑megbízhatóság értékelését. Hogy egy aláírás továbbra is elfogadható‑e, az politikától és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne csak a megjelenített aláírási időt tekintse megbízható időbélyegnek.

**Egy aláírt prezentáció szerkeszthető marad?**

Igen. Az aláírás nem zárja le a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért a prezentációt előbb készítsük el, majd írjuk alá a végső változatot.

**Egy prezentáció tartalmazhat több aláírást?**

Igen. Minden aláírást adjon a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott gyűjteményhez mentés előtt. Validáció során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláírót megtalálunk.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides a leírt digitális‑aláírás műveleteket csak PPTX formátumra támogatja. PPT és OpenDocument prezentációs formátumok nem támogatottak ezen API‑munkafolyamatban.

**Eltávolíthatok egy aláírást anélkül, hogy a diákra hatna?**

Igen. Egy aláírást eltávolíthat, vagy törölheti az egész gyűjteményt, majd mentheti a prezentációt. A dia‑tartalom megmarad, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.