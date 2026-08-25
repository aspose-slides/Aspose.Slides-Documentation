---
title: Digitális aláírások hozzáadása prezentációkhoz C++-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet aláírni meglévő PPTX prezentációkat PFX tanúsítványokkal, és az Aspose.Slides for C++ segítségével ellenőrizni vagy eltávolítani a digitális aláírásokat."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a prezentációt, és hogy a aláírt tartalom megváltozott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digitális tanúsítvány** egy elektronikus igazolvány, amely egy személyazonosságot összekapcsol egy nyilvános kulccsal. Egy megbízható tanúsítványkiadó (CA) kiadhat tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digitális aláírás** a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezt követően felhasználható az aláírás ellenőrzésére. Az aláírás bizonyítja a forrást és az integritást; nem titkosítja a prezentációt.
- **Jelszóvédelem** szabályozza, hogy a felhasználó megnyithat‑e vagy módosíthat‑e egy prezentációt. Ez különálló a digitális aláírástól, és le van írva a [Password-Protected Presentations](/slides/hu/cpp/password-protected-presentation/).

A PowerPoint a **Digitális aláírás hozzáadása** parancsot a **Fájl > Információ > Prezentáció védelme** menüpont alatt biztosítja.

![PowerPoint Prezentáció védelme menü, a Digitális aláírás hozzáadása kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt prezentáció megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely kimondja, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a aláírásokat a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) metóduson keresztül teszi elérhetővé, amely egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/) objektumot ad vissza, amelynek elemei a [IDigitalSignature](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/) interfészt valósítják meg. Egy prezentáció több aláírást is tartalmazhat.

## **PFX tanúsítványok és jelszavak megértése**

Egy PFX fájl, más néven PKCS#12 fájl, amelyet általában `.pfx` vagy `.p12` kiterjesztéssel látnak el, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé a tulajdonos számára, hogy aláírást hozzon létre. Egy tanúsítvány privát kulcs nélkül nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. Ez **nem** a prezentáció megnyitásához vagy szerkesztéséhez használt jelszó. Ne helyezze a PFX fájlokat vagy jelszavaikat verziókezelés alá. Éles környezetben korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák környezeti változót használnak csak azért, hogy a jelszó ne legyen a kódban beágyazva.

## **Digitális aláírás hozzáadása egy prezentációhoz**

Egy valós aláírási munkafolyamat során töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/cpp/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítvány és annak jelszava alapján, adja hozzá az aláírást a prezentáció gyűjteményéhez, majd mentse PPTX fájlba.

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

Az eredmény új néven történő mentése megőrzi az aláíratlan forrásfájlt. Az [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/set_comments/) értéke leírja az aláírás célját; ez nem biztonsági ellenőrzés.

## **Digitális aláírások ellenőrzése**

Amikor betölt egy aláírt PPTX fájlt, ellenőrizze a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) által visszaadott minden elemet. A [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/get_isvalid/) metódus jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentációtartalomhoz képest.

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

Egy érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentációtartalom vagy az aláírásadatok megváltoztak az aláírás után, vagy hogy a fájl sérült. Minden aláírás eltávolítása aláíratlan prezentációt eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonságérzékeny munkafolyamatnak továbbá ellenőriznie kell, hogy a várt számú aláírás és a várt aláíróidentitások jelen vannak‑e.

Ezt a validálási eredményt nem szabad teljes tanúsítvány‑bizalmi döntésnek tekinteni. A biztonsági irányelvétől függően az alkalmazásnak szüksége lehet az X.509 tanúsítványlánc felépítésére és ellenőrzésére, a tanúsítvány érvényességi dátumainak és visszavonási állapotának ellenőrzésére, a várt tárgy vagy ujjlenyomat megerősítésére, a kulcshasználat ellenőrzésére, valamint egy megbízható időbélyeg értékelésére. Az [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignature/get_signtime/) értéke önmagában nem bizonyíték megbízható időbélyeg‑kiadótól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, minden aláírást eltávolít a [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/clear/) metódussal, és egy aláíratlan másolatot ment.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Egyetlen aláírás eltávolításához hívja meg az [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idigitalsignaturecollection/removeat/) metódust a nulla‑alapú indexével. Mentse új fájlba, hacsak a felülírás nem része a munkafolyamatnak.

## **Szerkesztési és formátum szempontok**

- Egy aláírás nem teszi a prezentációt csak‑olvasásra. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes kívánt módosítást az aláírás előtt. Ha a prezentációt később módosítani kell, mentse a módosított változatot, és írja alá újra.
- Tartsuk a végleges kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem viszi át az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- Tekintse a tanúsítvány privát kulcsát érzékeny adatként. Aki megszerzi a privát kulcsot és annak jelszavát, az aláírásokat hozhat létre, mintha a tanúsítvány tulajdonosa lenne.
- Tartsa meg az aláíratlan forrást vagy egy másik ellenőrzött másolatot, ha a dokumentum‑megőrzési szabályzat ezt megköveteli.

## **GYIK**

**Titkosítja‑e a digitális aláírás a prezentációt?**

Nem. A digitális aláírás bizonyítja a forrást és az integritást, de a prezentáció tartalma olvasható marad, hacsak külön titkosítást nem alkalmazunk. Használja a [password protection](/slides/hu/cpp/password-protected-presentation/) funkciót, ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a PFX jelszó, mint a prezentáció jelszava?**

Nem. A PFX jelszó a tanúsítványcsomagban tárolt privát kulcs feloldására szolgál. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok‑e önaláírt tanúsítványt?**

Technikailag igen, ha a tanúsítvány tartalmaz egy elérhető privát kulcsot. A címzettek nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Publikus vagy keresztszervezeti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi az aláírást érvénytelenivé?**

A aláírt prezentáció tartalmának vagy az aláírás adatainak aláírás után történő módosítása érvényteleníti az aláírást. A fájl‑sérülés is okozhat sikertelen ellenőrzést. Ha minden aláírást eltávolítanak, a prezentáció aláíratlan marad, nem pedig egy érvénytelen aláírással rendelkező fájl.

**Jelent‑e egy érvényes aláírás, hogy megbízhatok az aláírón?**

Nem önmagában. Az aláírás integritása és az aláírónak a megbízhatósága külön döntések. Egy éles környezetben használt ellenőrzési szabályzatnak további ellenőrzéseket is kell tartalmaznia: a tanúsítványlánc, a lejárati idő, a visszavonási állapot, a várt identitás, a kulcshasználat és bármely megbízható időbélyeg‑követelmény.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem változtatja meg a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás még elfogadható‑e, a szabályzattól és attól függ, hogy van‑e egy érvényes megbízható időbélyeg, amely bizonyítja, hogy az aláírás a tanúsítvány érvényességi ideje alatt történt. Ne csak a megjelenített aláírási időt használja megbízható időbélyegként.

**Szerkeszthető‑e továbbra is egy aláírt prezentáció?**

Igen. Az aláírás nem zárja le a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá a végleges változatot.

**Tartalmazhat‑e egy prezentáció több aláírást?**

Igen. Minden aláírást adjon hozzá a [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_digitalsignatures/) által visszaadott gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációs formátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak PPTX formátumban támogatja a leírt digitális‑aláírási műveleteket. A PPT és az OpenDocument prezentációs formátumok nem támogatottak ezzel az API‑munkafolyammal.

**Eltávolítható‑e egy aláírás anélkül, hogy a diák érintettek lennének?**

Igen. Egy aláírást eltávolíthat, vagy kiürítheti az egész gyűjteményt, majd mentheti a prezentációt. A dia‑tartalom megmarad, de a mentett fájl már nem hordozza az eltávolított aláírás bizonyítékát.