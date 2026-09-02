---
title: Digitális aláírások hozzáadása prezentációkhoz .NET környezetben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet meglévő PPTX prezentációkat aláírni PFX tanúsítványokkal, és az Aspose.Slides for .NET-et használni a digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írt alá egy prezentációt, és hogy az aláírt tartalom megváltozott-e. Három kapcsolódó biztonsági fogalom fontos itt:

- **digitális tanúsítvány** – egy elektronikus hitelesítő adat, amely egy identitást egy nyilvános kulccsal kapcsol össze. Egy megbízható tanúsítványkibocsátó (CA) kiadhat tanúsítványt, vagy egy szervezet használhat önaláírt tanúsítványt belső munkafolyamatokhoz.
- **digitális aláírás** – a prezentáció tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsa ezután az aláírás ellenőrzésére használható. Egy aláírás eredet és integritás bizonyítékát nyújtja; nem titkosítja a prezentációt.
- **jelszóvédelem** szabályozza, hogy egy felhasználó megnyithatja vagy módosíthatja-e a prezentációt. Ez különálló a digitális aláírástól, és a [Jelszóval védett prezentációk](/net/password-protected-presentation/) leírásában található.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** alatt biztosítja.

![PowerPoint Protect Presentation menü, ahol a Add a Digital Signature ki van emelve](add-digital-signature-in-powerpoint.png)

Miután egy aláírt prezentációt megnyitnak, a PowerPoint megjeleníthet egy aláírási állapotértesítést.

![PowerPoint értesítés, amely azt jelzi, hogy a prezentáció érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides a digitális aláírásokat a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/digitalsignatures/), egy [IDigitalSignatureCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignaturecollection/) amelynek elemei [IDigitalSignature](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignature/) megvalósítják, teszi elérhetővé. Egy prezentáció több aláírást tartalmazhat.

## **A PFX tanúsítványok és jelszavak megértése**

A PFX fájl, amelyet PKCS#12 fájlnak is neveznek, és általában `.pfx` vagy `.p12` kiterjesztéssel rendelkezik, tartalmazhat X.509 tanúsítványt, annak privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé, hogy a tulajdonos aláírást hozzon létre. Egy tanúsítvány, amelyhez nem férhető hozzá a privát kulcs, nem használható a prezentáció aláírására.

A PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. Nem **jelszó** a prezentáció megnyitásához vagy szerkesztéséhez. Ne mentse a PFX fájlokat vagy azok jelszavait a forráskódkezelőbe. Gyártásban korlátozza a tanúsítványfájl hozzáférését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák csak környezeti változót használnak, hogy elkerüljék a jelszó kódban történő beágyazását.

## **Digitális aláírás hozzáadása egy prezentációhoz**

Egy valós prezentáció aláírási folyamatához töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature](https://reference.aspose.com/slides/hu/net/aspose.slides/digitalsignature/) objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a prezentáció gyűjteményéhez, és mentse PPTX fájlba.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Az eredmény új néven történő mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.Comments](https://reference.aspose.com/slides/hu/net/aspose.slides/digitalsignature/comments/) érték leírja az aláírás célját; nem biztonsági vezérlő.

## **Digitális aláírások ellenőrzése**

Amikor betölt egy aláírt PPTX fájlt, ellenőrizze minden elemet a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/digitalsignatures/) gyűjteményben. A [IDigitalSignature.IsValid](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignature/isvalid/) tulajdonság azt jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi prezentáció tartalmára vonatkozóan.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Az érvénytelen eredmény általában azt jelenti, hogy az aláírt prezentáció tartalma vagy az aláírási adatok a aláírás után megváltoztak, vagy a fájl megsérült. Az összes aláírás eltávolítása aláíratlan prezentációt eredményez, így csak az elemek érvényességének ellenőrzése nem elegendő: egy biztonság‑érzékeny munkafolyamatnak ellenőriznie kell a várt aláírások számát és a várt aláírók személyazonosságát is.

Ez az érvényességi eredmény nem tekinthető teljes tanúsítvány‑bizalom döntésnek. A biztonsági policy‑tól függően az alkalmazásnak elő kell készítenie és érvényesítenie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcshasználatot, és értékelnie kell egy megbízható időbélyeget. A [IDigitalSignature.SignTime](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignature/signtime/) értéke önmagában nem bizonyíték egy megbízható időbélyeg‑szolgáltatótól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a prezentáció biztonsági állapotát. Az alábbi példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást a [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignaturecollection/clear/) metódussal, és elment egy aláíratlan másolatot.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Egyetlen aláírás eltávolításához hívja meg az [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignaturecollection/removeat/) metódust a nullához viszonyított indexével. Mentse egy új fájlba, hacsak nem a munkafolyamat része a aláírt eredeti felülírása.

## **Szerkesztési és formátumbi figyelembevételek**

- Egy aláírás nem teszi a prezentációt csak‑olvashatóvá. A felhasználók és az alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom módosítása általában érvénytelenné teszi a meglévő aláírást.
- Végezze el az összes kívánt módosítást a aláírás előtt. Ha a prezentációt módosítani kell, mentse el az átdolgozott változatot, és aláírja azt újra.
- Tartsa meg a végső kimenetet PPTX formátumban. Egy aláírt prezentáció más formátumba konvertálása nem továbbítja az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- Kezelje a tanúsítvány privát kulcsát érzékeny adatként. Aki hozzájut a privát kulcshoz és annak jelszavához, az képes olyan aláírásokat létrehozni, amelyek a tanúsítvány tulajdonosától származónak látszanak.
- Tartsa meg az aláíratlan forrást vagy egy másik kontrollált példányt, ha a dokumentum‑megőrzési szabályzat ezt megköveteli.

## **GYIK**

**A digitális aláírás titkosítja a prezentációt?**

Nem. A digitális aláírás eredet és integritás bizonyítékát nyújtja, de a prezentáció tartalma olvasható marad, hacsak külön titkosítás nincs alkalmazva. Használja a [jelszóvédelmet](/net/password-protected-presentation/) amikor a tartalomhoz való hozzáférést korlátozni kell.

**A PFX jelszó ugyanaz, mint a prezentáció jelszava?**

Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem szabályozza, hogy ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag egy önaláírt tanúsítvány használható, ha tartalmaz hozzáférhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni benne, hacsak azt a tanúsítványt nem adták hozzá kifejezetten a megbízható környezetükhöz. Publikus vagy kereszt‑szervezeti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi érvénytelennek az aláírást?**

A aláírt prezentáció tartalmának vagy az aláírási adatoknak a aláírás után történő módosítása érvénytelenítheti az aláírást. Fájl‑sérülés is okozhat hibás ellenőrzést. Ha az összes aláírást eltávolítják, a prezentáció aláíratlan marad, nem pedig hibás aláírással rendelkező fájl.

**Jelenti-e egy érvényes aláírás, hogy bízhatok a feladóban?**

Nem önmagában. Az aláírás integritása és a feladó megbízhatósága külön döntés. Egy termelési ellenőrzési szabályzatnak ellenőriznie kell a tanúsítványláncot, a tanúsítvány érvényességi időszakát, a visszavonási állapotot, a várt személyazonosságot, a kulcshasználatot és esetleges megbízható időbélyeg‑követelményeket.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárta nem módosítja a prezentáció bájtjait, de befolyásolja a tanúsítvány‑bizalom értékelését. Az, hogy egy aláírás továbbra is elfogadható-e, a policy‑tól és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényességi időszakában történt. Ne bízzon kizárólag a megjelenített aláírási időben megbízható időbélyegként.

**Módosítható marad egy aláírt prezentáció?**

Igen. Az aláírás nem zárja le a fájlt. A aláírt tartalom módosítása általában érvényteleníti a meglévő aláírást, ezért először fejezze be a prezentációt, majd írja alá a végleges változatot.

**Tartalmazhat egy prezentáció több aláírást is?**

Igen. Adja hozzá minden aláírást az [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/digitalsignatures/) gyűjteményhez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges aláíró jelen van.

**Mely prezentációformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátumban támogatja a leírt digitális‑aláírási műveleteket. A PPT és az OpenDocument prezentációformátumok nem támogatottak ezen API‑munkafolyamatban.

**Eltávolíthatok aláírást anélkül, hogy érinteném a diákat?**

Igen. Eltávolíthat egy aláírást vagy törölheti az egész gyűjteményt, majd elmentheti a prezentációt. A diák tartalma megmarad, de a mentett fájl már nem hordozza a eltávolított aláírás bizonyítékát.