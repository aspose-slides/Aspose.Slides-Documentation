---
title: Digitális aláírások hozzáadása prezentációkhoz Java-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan írhat alá meglévő PPTX prezentációkat PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for Java-t a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus igazolvány, amely egy személyazonosságot társít egy nyilvános kulccsal. Egy megbízható tanúsítványkiadó (CA) kiadhat tanúsítványt, vagy egy szervezet használhat önaláírt tanúsítványt belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Egy aláírás az eredet és a integritás bizonyítékát nyújtja; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy egy felhasználó megnyithat-e vagy módosíthat-e egy prezentációt. Ez különálló a digitális aláírástól, és a [Password-Protected Presentations](/slides/hu/java/password-protected-presentation/) című dokumentumban van leírva.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüpont alatt biztosítja.

![PowerPoint Protect Presentation menü, az Add a Digital Signature kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás-állapot értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides az aláírásokat a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) segítségével teszi elérhetővé, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/) interfészt valósítják meg. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és gyakran `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára aláírás létrehozását. A privát kulcs nélküli tanúsítvány nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne tárolja a PFX fájlokat vagy azok jelszavait a forráskódban. Éles környezetben korlátozza a hozzáférést a tanúsítványfájlhoz, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák csak környezeti változót használnak a jelszó beágyazásának elkerülése érdekében.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valódi prezentáció aláírásához töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/java/com.aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció kollekciójához, és mentse PPTX fájlba.

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

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. Az [IDigitalSignature.setComments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) által beállított érték leírja az aláírás célját; ez nem biztonsági szabályozás.

## **Digitális aláírások érvényesítése**

Amikor egy aláírt PPTX fájlt tölt be, vizsgálja meg a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott minden elemet. Az [IDigitalSignature.isValid](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#isValid--) metódus azt jelzi, hogy a beágyazott aláírás érvényes-e a jelenlegi prezentáció tartalmához.

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

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírás adatai a aláírás után megváltoztak, vagy a fájl sérült. Az összes aláírás eltávolítása aláíratlan prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzékeny munkafolyamatnak továbbá ellenőriznie kell, hogy a várt számú aláírás és a várt aláírók személyazonossága jelen van-e.

Ezt az érvényességi eredményt nem szabad teljes tanúsítvány-bizalmi döntésnek tekinteni. A biztonsági irányelvtől függően az alkalmazásnak meg kell építenie és érvényesítenie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie kell a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcs használatát, és kiértékelnie egy megbízható időbélyeget. Az [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignature/#getSignTime--) értéke önmagában nem bizonyíték egy megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa beolvas egy aláírt PPTX fájlt, az összes aláírást eltávolítja a [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/#clear--) segítségével, és elment egy aláíratlan másolatot.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyetlen aláírás eltávolításához hívja meg a [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metódust a nullával kezdődő indexével. Mentsen új fájlba, kivéve ha a aláírt eredeti felülírása kifejezett része a munkafolyamatnak.

## **Szerkesztési és formátumra vonatkozó szempontok**

- Egy aláírás nem teszi a prezentációt csak olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes tervezett szerkesztést aláírás előtt. Ha a prezentációt módosítani kell, mentse el a módosított változatot, és írja alá újra.
- Tartsa a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- Tekintse a tanúsítvány privát kulcsát érzékenynek. Aki hozzájut a privát kulcshoz és annak jelszavához, aláírásokat hozhat létre, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik kontrollált másolatot, ha a dokumentum-megőrzési szabályzat ezt megköveteli.

## **GYIK**

**A digitális aláírás titkosítja a prezentációt?**

Nem. A digitális aláírás bizonyítja az eredetet és az integritást, de a prezentáció tartalma olvasható marad, hacsak nem alkalmaznak külön titkosítást. Használja a [password protection](/slides/hu/java/password-protected-presentation/) lehetőséget, ha a tartalomhoz való hozzáférést korlátozni kell.

**A PFX jelszó megegyezik a prezentáció jelszavával?**

Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag az önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek azonban nem trustolják automatikusan, hacsak a tanúsítványt nem adják hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy szervezetek közötti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**

Az aláírt prezentáció tartalmának vagy az aláírás adatainak aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl korrupciója is okozhat hibát az ellenőrzésben. Ha az összes aláírás eltávolításra kerül, a prezentáció aláíratlan lesz, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Egy érvényes aláírás azt jelenti, hogy megbízhatok a aláírónak?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben alkalmazott validációs szabálynak továbbá ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs használatát és minden megbízható időbélyegző követelményt.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány-bizalom értékelését. Az, hogy egy aláírás még elfogadható-e, a szabályzattól és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja-e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne támaszkodjon kizárólag a megjelenített aláírási időre megbízható időbélyegként.

**Még szerkeszthető egy aláírt prezentáció?**

Igen. Az aláírás nem zárja le a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá a végleges változatot.

**Tartalmazhat egy prezentáció több aláírást is?**

Igen. Minden aláírást adjon hozzá a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott kollekcióhoz a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy az összes szükséges aláíró jelen van.

**Mely prezentációformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátumra támogatja a leírt digitális aláírási műveleteket. A PPT és az OpenDocument prezentációformátumok nincsenek támogatva ebben az API-munkafolyamatban.

**Eltávolíthatok egy aláírást anélkül, hogy a diákra hatással lenne?**

Igen. Eltávolíthat egy aláírást vagy törölheti az egész kollekciót, majd elmentheti a prezentációt. A diák tartalma megmarad, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.