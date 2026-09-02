---
title: Digitális aláírások hozzáadása prezentációkhoz PHP-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet meglévő PPTX prezentációkat aláírni PFX tanúsítványokkal, és használni az Aspose.Slides for PHP Java-ön keresztül a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus hitelesítő, amely egy személyazonosságot egy nyilvános kulccsal kapcsolja össze. Egy megbízható tanúsító hatóság (CA) kiadhat tanúsítványt, vagy egy szervezet saját aláírású tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsát ezután fel lehet használni az aláírás ellenőrzésére. Egy aláírás bizonyítja a forrást és a sértetlenséget; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy egy felhasználó megnyithat‑e vagy módosíthat‑e egy prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Password‑Protected Presentations](/slides/hu/php-java/password-protected-presentation/) témában.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüpont alatt kínálja.

![PowerPoint Védelem a prezentációnál menü, kiemelve az Add a Digital Signature opciót](add-digital-signature-in-powerpoint.png)

Miután egy aláírt prezentációt megnyitnak, a PowerPoint megjeleníthet egy aláírás‑állapotról szóló értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures) metóduson keresztül teszi elérhetővé az aláírásokat, amely egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/) objektumot ad vissza, melynek elemei [DigitalSignature](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/) objektumok. Egy prezentáció több aláírást is tartalmazhat.

## **Ismerje meg a PFX tanúsítványokat és jelszavakat**

A PFX fájl, amelyet PKCS#12‑nek is hívnak, és gyakran `.pfx` vagy `.p12` kiterjesztést kap, tartalmazhat egy X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé, hogy a tulajdonos aláírjon. Egy tanúsítvány, amelyhez nincs hozzáférhető privát kulcs, nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** egy jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne köteleződjön el PFX fájlok vagy jelszavak verziókezelésben. Éles környezetben korlátozza a tanúsítványfájl elérését, és a jelszót titkos tárolóból vagy más védett konfigurációs forrásból szerezze be. Az alábbi példák csak egy környezeti változót használnak, hogy elkerüljék a jelszó kódban való beágyazását.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valós prezentációs munkafolyamat aláírásához töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX‑ként.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az eredmény új néven való mentése megőrzi a nem aláírt forrásfájlt. A [DigitalSignature::setComments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/setcomments/) által beállított érték leírja az aláírás célját; ez nem biztonsági szabályozás.

## **Digitális aláírások ellenőrzése**

Amikor egy aláírt PPTX‑t tölt be, vizsgálja meg a [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures) által visszaadott minden elemet. A [DigitalSignature::isValid](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/isvalid/) metódus jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentációtartalomra nézve.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírási adatok megváltoztak az aláírás után, vagy a fájl sérült. Az összes aláírás eltávolítása egy aláíratlan prezentációt eredményez, ezért csak az elemek validitásának ellenőrzése nem elegendő: egy biztonság‑érzékeny munkafolyamatnak továbbá ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ez a validitási eredmény nem tekinthető teljes tanúsítvány‑bizalmi döntésnek. Biztonsági irányelveitől függően az alkalmazásnak akár fel kell építenie és ellenőriznie a X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi időszakát és visszavonási állapotát, megerősíteni a várt alanyt vagy ujjlenyomatot, ellenőrizni a kulcshasználatot, és értékelni egy megbízható időbélyeget. A [DigitalSignature::getSignTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/getsigntime/) értéke önmagában nem bizonyíték egy megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX‑t, eltávolítja az összes aláírást a [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/clear/) segítségével, és elment egy aláíratlan másolatot.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha csak egy aláírást szeretne eltávolítani, hívja meg a [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/removeat/) metódust a null‑indexelt pozícióval. Mentse új fájlba, hacsak nem az eredeti aláírt fájl felülírása nem része kifejezetten a munkafolyamatnak.

## **Szerkesztési és formátumukra vonatkozó szempontok**

- Egy aláírás nem teszi a prezentációt csak‑olvasásra. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el a kívánt szerkesztéseket az aláírás előtt. Ha a prezentációt módosítani kell, mentse a módosított változatot, és írja alá újra.
- Tartsa meg a végleges kimenetet PPTX formátumban. A aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát tekintse érzékeny információnak. Akinek hozzáférése van a privát kulcshoz és annak jelszavához, aláírásokat hozhat létre, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg a nem aláírt forrást vagy egy másik ellenőrzött példányt, ha a dokumentum‑megőrzési szabályzata ezt előírja.

## **FAQ**

**A digitális aláírás titkosítja a prezentációt?**  
Nem. A digitális aláírás bizonyítja a forrást és a sértetlenséget, de a prezentáció tartalma olvasható marad, hacsak külön titkosítás nincs alkalmazva. Használja a [jelszóvédelmet](/slides/hu/php-java/password-protected-presentation/), ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a PFX jelszó, mint a prezentáció jelszója?**  
Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**  
Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adják hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy szervezetek közti munkafolyamatok általában egy megbízható CA‑tól kiállított tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**  
Az aláírt prezentáció tartalmának vagy az aláírási adatoknak az aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat sikertelen ellenőrzést. Ha az összes aláírást eltávolítják, a prezentáció aláíratlan, nem egy érvénytelen aláírást tartalmazó fájl.

**Egy érvényes aláírás azt jelenti, hogy megbízhatok a aláírón?**  
Nem önmagában. Az aláírás integritása és a aláíró megbízhatósága külön döntések. Egy éles környezetben a validációs politika további ellenőrzéseket is tartalmazhat: tanúsítványlánc, érvényességi időszak, visszavonási állapot, várt személyazonosság, kulcshasználat és esetleges megbízható időbélyegigény.

**Mi történik, ha a tanúsítvány lejár?**  
A tanúsítvány lejárta nem változtatja meg a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom kiértékelését. Az, hogy egy aláírás továbbra is elfogadható‑e, a politikától és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényessége közben történt. Ne csak a megjelenített aláírási időre támaszkodjon megbízható időbélyegként.

**Egy aláírt prezentáció még szerkeszthető?**  
Igen. Az aláírás nem zárja le a fájlt. A aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért előbb fejezze be a prezentációt, majd írja alá a végleges változatot.

**Tartalmazhat egy prezentáció több aláírást is?**  
Igen. Minden aláírást adjon hozzá a [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures) által visszaadott gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és győződjön meg róla, hogy minden szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**  
Az Aspose.Slides csak a PPTX formátum számára támogatja a leírt digitális‑aláírási műveleteket. A PPT és az OpenDocument prezentációs formátumok nem támogatottak ezzel az API‑munkafolyamattal.

**Eltávolíthatok aláírást anélkül, hogy befolyásolnám a diákot?**  
Igen. Eltávolíthat egy aláírást vagy kiürítheti az egész gyűjteményt, majd elmentheti a prezentációt. A diák tartalma továbbra is elérhető, de a mentett fájl már nem hordozza a eltávolított aláírás bizonyítékát.