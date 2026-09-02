---
title: Digitális aláírások hozzáadása prezentációkhoz Androidon
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/androidjava/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó hatóság
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- prezentáció biztonsága
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for Android-et Java segítségével a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus hitelesítő adat, amely egy azonosítót egy nyilvános kulccsal kapcsol össze. Egy megbízható tanúsító hatóság (CA) kiadhat egy tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítja a forrást és az integritást; nem titkosítja a prezentációt.
- A **jelszóvédelem** szabályozza, hogy egy felhasználó megnyithatja vagy módosíthatja-e a prezentációt. Különálló a digitális aláírástól, és le van írva a [Jelszóval védett prezentációk](/slides/hu/androidjava/password-protected-presentation/).

A PowerPoint a **Digitális aláírás hozzáadása** parancsot a **Fájl > Infó > Prezentáció védelme** menüpont alatt biztosítja.

![PowerPoint Prezentáció védelme menü, kiemelve a Digitális aláírás hozzáadása](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás-állapot értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) segítségével teszi elérhetővé az aláírásokat, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/) interfészt valósítják meg. Egy prezentáció több aláírást is tartalmazhat.

## **A PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és általában `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára az aláírás létrehozását. Egy tanúsítvány, amelyhez nincs hozzáférhető privát kulcs, nem használható prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** a prezentáció megnyitásához vagy szerkesztéséhez használt jelszó. Ne küldje el PFX fájlokat vagy azok jelszavait a forráskód-kezelő rendszerbe. Éles környezetben korlátozza a hozzáférést a tanúsítványfájlhoz, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák csak egy környezeti változót használnak, hogy elkerüljék a jelszó beágyazását a kódban.

## **Digitális aláírás hozzáadása a prezentációhoz**

A valódi prezentáció aláírásához töltse be a meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, és mentse PPTX fájlként.

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

Az eredmény új néven való mentése megőrzi az aláíratlan forrásfájlt. Az [IDigitalSignature.setComments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) által beállított érték leírja az aláírás célját; ez nem biztonsági szabályozás.

## **Digitális aláírások érvényesítése**

Amikor betölt egy aláírt PPTX fájlt, ellenőrizze az [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott minden elemet. Az [IDigitalSignature.isValid](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#isValid--) metódus azt jelzi, hogy a beágyazott aláírás érvényes-e a jelenlegi prezentációtartalomra nézve.

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

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírási adatok az aláírás után megváltoztak, vagy a fájl megsérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, így csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzékeny munkafolyamatnak további ellenőrzéseket kell végeznie a várt aláírások számának és a várt aláírók személyazonosságának meglétéről.

Ezt az érvényességi eredményt nem szabad teljes tanúsítvány-megbízhatósági döntésként kezelni. A biztonsági szabályzatától függően az alkalmazásnak esetleg fel kell építenie és érvényesítenie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie kell a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcs használatát, és meg kell vizsgálnia egy megbízható időbélyeget. Az [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) értéke önmagában nem bizonyíték megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) segítségével, és elment egy aláíratlan másolatot.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyetlen aláírás eltávolításához hívja meg a [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metódust a nullától induló indexével. Mentse új fájlba, hacsak az aláírt eredeti felülírása nem része a munkafolyamatnak.

## **Szerkesztési és formátumbeli megfontolások**

- Egy aláírás nem teszi a prezentációt csak olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezzük el az összes tervezett módosítást az aláírás előtt. Ha a prezentációt módosítani kell, mentsük el a módosított változatot, és aláírjuk azt újra.
- Tartsa a végső kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát érzékeny adatként kezelje. Aki megszerzi a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek a tanúsítványtulajdonos nevében látszanak.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött másolatot, ha a dokumentum-tartási szabályzat ezt előírja.

## **FAQ**

**A digitális aláírás titkosítja a prezentációt?**  
Nem. A digitális aláírás bizonyítékot nyújt a forrásra és az integritásra, de a prezentáció tartalma olvasható marad, hacsak nem alkalmaz külön titkosítás. Használja a [jelszóvédelmet](/slides/hu/androidjava/password-protected-presentation/), ha a tartalom hozzáférését korlátozni kell.

**A PFX jelszó megegyezik a prezentáció jelszavával?**  
Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem irányítja, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**  
Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy szervezetek közötti munkafolyamatok általában egy megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi az aláírást érvénytelenül?**  
Az aláírt prezentáció tartalmának vagy az aláírási adatok módosítása az aláírás után érvénytelenítheti azt. A fájl sérülése is okozhat sikertelen érvényesítést. Ha az összes aláírás eltávolításra kerül, a prezentáció aláíratlan, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Jelent-e egy érvényes aláírás, hogy megbízhatok a aláírón?**  
Nem önmagában. Az aláírás integritása és a feladóra való bizalom külön döntések. Egy éles környezetben alkalmazott érvényesítési szabálynak továbbá ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs használatát, és bármely megbízható időbélyegző követelményt.

**Mi történik, ha a tanúsítvány lejár?**  
A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány-megbízhatósági értékelést. Az, hogy egy aláírás továbbra is elfogadható-e, az Ön szabályzatától és attól függ, hogy egy érvényes megbízható időbélyegző bizonyítja-e, hogy az aláírás a tanúsítvány érvényességi időszaka alatt történt. Ne csak a megjelenített aláírási időpontra hagyatkozzon megbízható időbélyegzőként.

**Szerkeszthető marad egy aláírt prezentáció?**  
Igen. Az aláírás nem zárolja a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd aláírja a végső változatot.

**Tartalmazhat egy prezentáció több aláírást is?**  
Igen. Adjon minden aláírást a [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) által visszaadott gyűjteményhez a mentés előtt. Az érvényesítés során ellenőrizze minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációformátumok támogatják ezeket a műveleteket?**  
Az Aspose.Slides a leírt digitális aláírási műveleteket csak a PPTX formátumra támogatja. A PPT és az OpenDocument prezentációformátumok nem támogatottak ezzel az API munkafolyamattal.

**Eltávolíthatok aláírást anélkül, hogy a diákra hatással lenne?**  
Igen. Eltávolíthat egy aláírást vagy kiürítheti az egész gyűjteményt, majd mentheti a prezentációt. A dia tartalma megmarad, de a mentett fájl már nem hordozza az eltávolított aláírás bizonyítékát.