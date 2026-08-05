---
title: Digitális aláírások hozzáadása prezentációkhoz C++-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/cpp/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PKCS#12
- aláírás érvényesítése
- PowerPoint
- PPTX
- prezentáció biztonság
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for C++-t a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, hogy ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus bizonyítvány, amely egy azonosítót társít egy nyilvános kulccsal. Egy megbízható tanúsítvány kibocsátó (CA) kiadhat tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután felhasználható az aláírás ellenőrzésére. Az aláírás eredet és integritás bizonyítékát szolgáltatja; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy a felhasználó megnyithatja vagy módosíthatja-e a prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Jelszóval védett prezentációk](/cpp/password-protected-presentation/) cikkben.

A PowerPoint a **Digitális aláírás hozzáadása** parancsot biztosítja a **Fájl > Információ > Prezentáció védelme** menüpont alatt.

![PowerPoint Prezentáció védelme menü, a Digitális aláírás hozzáadása kiemelve](add-digital-signature-in-powerpoint.png)

Miután egy aláírt prezentációt megnyitnak, a PowerPoint megjeleníthet egy aláírás-állapot értesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) metóduson keresztül teszi elérhetővé az aláírásokat, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/) típusúak. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és általában `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé, hogy a tulajdonos aláírást hozzon létre. A privát kulcs nélkül elérhető tanúsítványt nem lehet használni a prezentáció aláírásához.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a prezentáció megnyitásához vagy szerkesztéséhez. Ne kötelezze el a PFX fájlokat vagy jelszavukat a verziókezelőben. Éles környezetben korlátozza a tanúsítványfájl elérését, és a jelszót titkos tárolóból vagy más védett konfigurációs forrásból szerezze. Az alábbi példák csak környezeti változót használnak, hogy elkerüljék a jelszó kódba ágyazását.

## **Digitális aláírás hozzáadása a prezentációhoz**

Egy valós prezentációs munkafolyamat aláírásához töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/cpp/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, és mentse PPTX fájlként.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény új név alatt történő mentése megőrzi a nem aláírt forrásfájlt. Az [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/set_comments/) érték leírja az aláírás célját; ez nem biztonsági vezérlés.

## **Digitális aláírások ellenőrzése**

Amikor betölt egy aláírt PPTX fájlt, vizsgálja meg a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) által visszaadott minden elemet. Az [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/get_isvalid/) metódus azt jelzi, hogy a beágyazott aláírás érvényes-e a jelenlegi prezentáció tartalmára.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírás adatai megváltoztak aláírás után, vagy hogy a fájl sérült. Minden aláírás eltávolítása egy nem aláírt prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságkritikus munkafolyamatnak további ellenőrzéseket kell végeznie a várt aláírások számáról és a várt aláírók személyazonosságáról.

Ezt az érvényességi eredményt nem szabad teljes tanúsítvány-bizalom döntésnek tekinteni. A biztonsági politikától függően az alkalmazásnak létre kell hoznia és érvényesítenie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcshasználatot, és értékelnie kell a megbízható időbélyeget. Az [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/get_signtime/) érték önmagában nem bizonyíték egy megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példában betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/clear/) metódussal, és elment egy nem aláírt másolatot.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ha csak egy aláírást szeretne eltávolítani, hívja a [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/removeat/) metódust a nulla-alapú indexével. Mentse új fájlba, hacsak az aláírt eredet felülírása nem része a munkafolyamatának.

## **Szerkesztési és formátum szempontok**

- Az aláírás nem teszi a prezentációt csak olvashatóvá. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el a tervezett szerkesztéseket az aláírás előtt. Ha a prezentációt módosítani kell, mentse el az átdolgozott változatot, és aláírja azt újra.
- Tartsa a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát érzékeny adatként kezelje. Aki hozzájut a privát kulcshoz és annak jelszavához, aláírásokat hozhat létre, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg a nem aláírt forrást vagy egy másik ellenőrzött másolatot, ha a dokumentummentési politika ezt előírja.

## **GYIK**

**Titkosítja-e a digitális aláírás a prezentációt?**

Nem. A digitális aláírás bizonyítékot nyújt az eredetre és az integritásra, de a prezentáció tartalma olvasható marad, hacsak külön titkosítást nem alkalmaznak. Használja a [jelszóvédelmet](/cpp/password-protected-presentation/), ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a PFX jelszó, mint a prezentáció jelszava?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldására szolgál. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Publikus vagy szervezetek közötti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi tesz egy aláírást érvénytelené?**

Az aláírt prezentáció tartalmának vagy az aláírás adatainak aláírás után történő módosítása érvénytelenítheti az aláírást. Fájlkorruptság is okozhatja a validáció hibáját. Ha az összes aláírás eltávolításra kerül, a prezentáció nem aláírt, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Jelent-e egy érvényes aláírás, hogy megbízhatok az aláírón?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben alkalmazott validációs politikának ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcshasználatot, és esetleg a megbízható időbélyegző követelményeket.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem változtatja meg a prezentáció bájtjait, de befolyásolja a tanúsítvány-bizalom kiértékelését. Az aláírás elfogadhatósága a politikától és attól függ, hogy egy érvényes megbízható időbélyegző bizonyítja-e, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne bízzon kizárólag a megjelenített aláírási időben megbízható időbélyegzőként.

**Lehet-e még szerkeszteni egy aláírt prezentációt?**

Igen. Az aláírás nem zárolja a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá az végleges változatot.

**Tartalmazhat-e egy prezentáció több aláírást?**

Igen. Minden aláírást adjon hozzá a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) által visszaadott gyűjteményhez mentés előtt. Érvényesítéskor ellenőrizze az összes aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak PPTX formátumban támogatja a leírt digitális aláírási műveleteket. A PPT és OpenDocument prezentációs formátumok nem támogatottak ebben az API munkafolyamatban.

**Eltávolíthatok-e aláírást a diák érintése nélkül?**

Igen. Eltávolíthat egy aláírást vagy kiürítheti az egész gyűjteményt, majd mentheti a prezentációt. A diák tartalma megmarad, de a mentett fájl már nem tartalmazza az eltávolított aláírás bizonyítékát.