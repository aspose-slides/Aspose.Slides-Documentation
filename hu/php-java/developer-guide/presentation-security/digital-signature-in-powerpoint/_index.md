---
title: Digitális aláírások hozzáadása prezentációkhoz PHP-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és az Aspose.Slides for PHP via Java segítségével ellenőrizni vagy eltávolítani a digitális aláírásokat."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írását aláírta egy prezentációnak, és hogy az aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus igazolvány, amely egy személyazonosságot egy publikus kulccsal kapcsolja össze. Egy megbízható tanúsítványkiadó (CA) kiadhat tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány publikus kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítja a származást és az integritást; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy a felhasználó megnyithatja vagy módosíthatja-e a prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Password-Protected Presentations](/php-java/password-protected-presentation/) oldalon.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüpont alatt biztosítja.

![PowerPoint „Protect Presentation” menü, a „Add a Digital Signature” kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírási állapot értesítést.

![PowerPoint értesítés, amely közli, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides az aláírásokat ezen keresztül teszi elérhetővé: [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures), amely egy [DigitalSignatureCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/) visszaad, amelynek elemei [DigitalSignature](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/) objektumok. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és általában `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat egy X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára az aláírás létrehozását. Egy tanúsítvány, amelyhez nincs hozzáférhető privát kulcs, nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** a prezentáció megnyitásához vagy szerkesztéséhez szükséges jelszó. Ne kötelezd be PFX fájlokat vagy azok jelszavait a forráskód-kezelőbe. Éles környezetben korlátozd a tanúsítványfájl elérését, és a jelszót titkos tárolóból vagy más védett konfigurációs forrásból szerezd be. Az alábbi példák környezeti változót használnak, hogy elkerüljék a jelszó kódban való beágyazását.

## **Digitális aláírás hozzáadása a prezentációhoz**

A valódi prezentáció aláírási folyamatához tölts be egy meglévő PPTX fájlt, hozz létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítvány és annak jelszava alapján, add hozzá az aláírást a prezentáció gyűjteményéhez, és mentsd el PPTX fájlként.

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

Az eredmény új néven történő mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature::setComments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/setcomments/) által beállított érték leírja az aláírás célját; ez nem biztonsági vezérlő.

## **Digitális aláírások ellenőrzése**

Amikor egy aláírt PPTX fájlt töltesz be, vizsgáld meg a [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures) által visszaadott összes elemet. A [DigitalSignature::isValid](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/isvalid/) metódus jelzi, hogy a beágyazott aláírás érvényes-e a jelenlegi prezentáció tartalmához.

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

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírás adatai a aláírás után megváltoztak, vagy hogy a fájl sérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, így csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzékeny munkafolyamatnak továbbá ellenőriznie kell, hogy a kívánt számú aláírás és a várt aláírók azonosítói jelen vannak-e.

Ezt az érvényességi eredményt nem szabad a tanúsítványteljes bizalom döntésének tekinteni. A biztonsági irányelvedtől függően az alkalmazásnak fel kell építenie és ellenőriznie kell az X.509 tanúsítványláncot, a tanúsítvány érvényesítési dátumait és visszavonási állapotát, megerősítenie a várt alanyt vagy ujjlenyomatot, ellenőriznie a kulcs használatát, és értékelnie a megbízható időbélyeget. A [DigitalSignature::getSignTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignature/getsigntime/) érték önmagában nem bizonyíték megbízható időbélyeg-kiadótól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása módosítja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/clear/) segítségével, és ment egy aláíratlan másolatot.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Egyetlen aláírás eltávolításához hívd meg a [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/removeat/) metódust a nulla alapú indexével. Ments egy új fájlt, hacsak a felülírása az aláírt eredetinek nem része a munkafolyamatodnak.

## **Szerkesztés és formátumfontosságú szempontok**

- Az aláírás nem teszi a prezentációt csak olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom változtatása általában érvényteleníti a meglévő aláírást.
- Végezd el az összes tervezett módosítást aláírás előtt. Ha a prezentációt módosítani kell, mentsd el a javított verziót, és aláírásra küldd azt a revíziót.
- Tartsd meg a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát tekintsd érzékeny adatnak. Bárki, aki megszerzi a privát kulcsot és jelszavát, képes aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsd meg az aláíratlan forrást vagy egy másik ellenőrzött másolatot, ha a dokumentummegőrzési szabályzat ezt megköveteli.

## **GYIK**

**A digitális aláírás titkosítja a prezentációt?**  
Nem. A digitális aláírás bizonyítékot nyújt a származásra és az integritásra, de a prezentáció tartalma olvasható marad, hacsak külön titkosítás nem kerül alkalmazásra. Használd a [password protection](/php-java/password-protected-presentation/) lehetőséget, ha a tartalom hozzáférését korlátozni kell.

**Ugyanaz a PFX jelszó, mint a prezentáció jelszava?**  
Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**  
Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. A nyilvános vagy szervezetek közötti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi érvénytelenül az aláírást?**  
Az aláírt prezentáció tartalmának vagy az aláírás adatainak a aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat hibás ellenőrzést. Ha minden aláírás eltávolításra kerül, a prezentáció aláíratlan, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Érvényes aláírás azt jelenti, hogy bízhatok az aláíróban?**  
Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy termelési ellenőrzési szabályzatnak továbbá ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs használatát, valamint a megbízható időbélyeg követelményeit.

**Mi történik, ha a tanúsítvány lejár?**  
A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány megbízhatóságának értékelését. Az, hogy egy aláírás továbbra is elfogadható-e, a szabályzatodtól és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja-e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne csak a megjelenített aláírási időre támaszkodj megbízható időbélyegként.

**Szerkeszthető továbbra is egy aláírt prezentáció?**  
Igen. Az aláírás nem zárolja a fájlt. A aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezd be a prezentációt, majd írd alá a végső revíziót.

**Tartalmazhat egy prezentáció több aláírást?**  
Igen. Minden aláírást add hozzá a [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getDigitalSignatures) által visszaadott gyűjteményhez a mentés előtt. Érvényesítés során vizsgáld meg minden aláírást, és erősítsd meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációformátumok támogatják ezeket a műveleteket?**  
Az Aspose.Slides csak a PPTX formátum esetén támogatja a leírt digitális aláírási műveleteket. A PPT és az OpenDocument prezentációs formátumok nem támogatottak ezen API munkafolyamat keretében.

**Eltávolíthatok aláírást anélkül, hogy a diákra hatással lenne?**  
Igen. Egy aláírást eltávolíthatsz vagy kiürítheted az egész gyűjteményt, majd elmentheted a prezentációt. A diák tartalma megmarad, de a mentett fájl már nem tartalmazza a eltávolított aláírás bizonyítékát.