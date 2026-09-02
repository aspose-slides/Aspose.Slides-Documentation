---
title: Digitális aláírások hozzáadása bemutatókhoz .NET-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/net/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsító hatóság
- PFX tanúsítvány
- PKCS#12
- aláírás ellenőrzése
- PowerPoint
- PPTX
- bemutató biztonság
- .NET
- C#
- Aspose.Slides
description: "Megtanulhatja, hogyan írhat alá meglévő PPTX bemutatókat PFX tanúsítványokkal, és hogyan használhatja az Aspose.Slides for .NET-et digitális aláírások ellenőrzésére vagy eltávolítására."
---
## **Áttekintés**

A digitális aláírás segít a címzettnek meghatározni, ki írta alá a bemutatót és hogy a aláírt tartalom változott‑e. Három kapcsolódó biztonsági fogalom fontos itt:

- A **digital certificate** egy elektronikus igazolvány, amely egy személyazonosságot társít egy nyilvános kulccsal. Egy megbízható tanúsító rendszer (CA) kiadhat egy tanúsítványt, vagy egy szervezet önaláírt tanúsítványt használhat belső munkafolyamatokhoz.
- A **digital signature** a bemutató tartalmából és a tanúsítvány tulajdonosának privát kulcsából jön létre. A tanúsítvány nyilvános kulcsával ezután ellenőrizhető az aláírás. Az aláírás bizonyítékot nyújt a forrásra és a sértetlenségre; nem titkosítja a bemutatót.
- **Password protection** szabályozza, hogy egy felhasználó megnyithatja‑e vagy módosíthatja a bemutatót. Ez különálló a digitális aláírástól, és le van írva a [Jelszóval védett bemutatók](/slides/hu/net/password-protected-presentation/) oldalon.

A PowerPoint a **Add a Digital Signature** parancsot a **File > Info > Protect Presentation** menüpont alatt biztosítja.

![PowerPoint Protect Presentation menü, az Add a Digital Signature kiemelve](add-digital-signature-in-powerpoint.png)

Aláírt bemutató megnyitása után a PowerPoint megjeleníthet egy aláírás‑állapot értesítést.

![PowerPoint értesítés, amely szerint a bemutató érvényes aláírásokat tartalmaz](digital-signature-status-in-powerpoint.png)

Az Aspose.Slides az aláírásokat a [IPresentation.DigitalSignatures]... segítségével teszi elérhetővé, egy [IDigitalSignatureCollection]... objektumon keresztül, amelynek elemei a [IDigitalSignature]... implementálják. Egy bemutató több aláírást is tartalmazhat.

## **PFX Tanúsítványok és Jelszavak megértése**

Az PFX fájl, más néven PKCS#12 fájl, amely általában a `.pfx` vagy `.p12` kiterjesztést kapja, tartalmazhat X.509 tanúsítványt, a privát kulcsát és a tanúsítványláncot. A privát kulcs teszi lehetővé, hogy a tulajdonos aláírást készítsen. A privát kulcs nélkül elérhető tanúsítvány nem használható a bemutató aláírására.

Az PFX jelszó védi a tanúsítványcsomagot és a privát kulcsot. **Nem** jelszó a bemutató megnyitásához vagy szerkesztéséhez. Ne adja hozzá a PFX fájlokat vagy azok jelszavait a forráskódkezelőhöz. Éles környezetben korlátozza a tanúsítványfájl elérését, és szerezze be a jelszót egy titkos tárolóból vagy más védett konfigurációs forrásból. Az alábbi példák csak környezeti változót használnak, hogy elkerüljék a jelszó kódban való beágyazását.

## **Digitális aláírás hozzáadása egy bemutatóhoz**

Egy valódi bemutató aláírásához töltsön be egy meglévő PPTX fájlt, hozzon létre egy [DigitalSignature]... objektumot egy PFX tanúsítványból és annak jelszavából, adja hozzá az aláírást a bemutató gyűjteményéhez, majd mentse PPTX fájlba.

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

A végeredmény új név alatt történő mentése megőrzi az aláíratlan forrásfájlt. A [DigitalSignature.Comments]... érték leírja az aláírás célját; ez nem biztonsági ellenőrzés.

## **Digitális aláírások ellenőrzése**

Amikor betölt egy aláírt PPTX fájlt, ellenőrizze az összes elemet a [IPresentation.DigitalSignatures]... gyűjteményben. Az [IDigitalSignature.IsValid]... tulajdonság azt jelzi, hogy a beágyazott aláírás érvényes‑e a jelenlegi bemutató tartalmához.

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

Egy érvénytelen eredmény általában azt jelenti, hogy az aláírt bemutató tartalma vagy az aláírás adatai a aláírás után megváltoztak, vagy hogy a fájl sérült. Minden aláírás eltávolítása aláíratlan bemutatót eredményez, ezért csak az elemek érvényességének ellenőrzése nem elegő: egy biztonságérzékeny munkafolyamatnak továbbá ellenőriznie kell, hogy a várt számú aláírás és a várt aláírók személyazonossága jelen van‑e.

Ezt az érvényességi eredményt nem szabad teljes tanúsítványbizalom döntésnek tekinteni. A biztonsági szabályzatától függően az alkalmazásnak le kell építenie és ellenőriznie kell az X.509 tanúsítványláncot, ellenőriznie kell a tanúsítvány érvényességi dátumait és visszavonási állapotát, megerősítenie a várt alanyt vagy ujjlenyomatot, ellenőriznie kell a kulcs használatát, és értékelnie kell egy megbízható időbélyeget. Az [IDigitalSignature.SignTime]... érték önmagában nem bizonyíték egy megbízható időbélyegző hatóságtól.

## **Digitális aláírások eltávolítása**

Az aláírások eltávolítása megváltoztatja a bemutató biztonsági állapotát. A következő példa betölt egy aláírt PPTX fájlt, eltávolítja az összes aláírást az [IDigitalSignatureCollection.Clear]... használatával, és elment egy aláíratlan másolatot.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Egyetlen aláírás eltávolításához hívja meg az [IDigitalSignatureCollection.RemoveAt]... metódust a nulla‑alapú indexével. Mentse új fájlba, hacsak a felülírása az eredeti aláírt fájlnak nem része a munkafolyamatának.

## **Szerkesztési és formátum szempontok**

- Az aláírás nem teszi a bemutatót írásvédetté. A felhasználók és alkalmazások továbbra is szerkeszthetik a fájlt, de a aláírt tartalom megváltoztatása általában érvényteleníti a meglévő aláírást.
- Végezze el az összes tervezett módosítást aláírás előtt. Ha a bemutatót módosítani kell, mentse a módosított verziót, és írja alá újra azt.
- Tartsa a végső kimenetet PPTX formátumban. Egy aláírt bemutató más formátumba konvertálása nem továbbítja az eredeti PPTX aláírást érvényes aláírásként a konvertált fájlra.
- A tanúsítvány privát kulcsát érzékeny adatként kezelje. Aki megszerzi a privát kulcsot és annak jelszavát, képes lehet olyan aláírásokat létrehozni, amelyek úgy tűnnek, mintha a tanúsítvány tulajdonosától származnának.
- Tartsa meg az aláíratlan forrást vagy egy másik szabályozott másolatot, ha a dokumentummegőrzési szabályzata ezt megköveteli.

## **GYIK**

**A digitális aláírás titkosítja a bemutatót?**

Nem. A digitális aláírás bizonyítékot nyújt a forrásra és a sértetlenségre, de a bemutató tartalma olvasható marad, hacsak nem alkalmazunk külön titkosítást. Használja a [jelszóvédelem](/slides/hu/net/password-protected-presentation/) lehetőséget, ha a tartalomhoz való hozzáférést korlátozni kell.

**Ugyanaz a PFX jelszó, mint a bemutató jelszava?**

Nem. A PFX jelszó feloldja a tanúsítványcsomagban tárolt privát kulcsot. Nem szabályozza, ki nyithatja meg vagy szerkesztheti a PPTX fájlt.

**Használhatok önaláírt tanúsítványt?**

Technikailag egy önaláírt tanúsítvány használható, ha tartalmazza az elérhető privát kulcsot. A címzettek azonban nem fogják automatikusan megbízni benne, hacsak a tanúsítványt nem adják hozzá kifejezetten a megbízható környezetükhöz. Nyilvános vagy szervezetek közötti munkafolyamatok általában megbízható CA által kiadott tanúsítványt használnak.

**Mi teszi érvénytelené az aláírást?**

Az aláírt bemutató tartalmának vagy az aláírás adatainak aláírás után történő módosítása érvénytelenítheti az aláírást. A fájl sérülése is okozhat sikertelen ellenőrzést. Ha az összes aláírás eltávolításra kerül, a bemutató aláíratlan lesz, nem pedig egy érvénytelen aláírást tartalmazó fájl.

**Egy érvényes aláírás azt jelenti, hogy megbízhatok az aláírón?**

Nem önmagában. Az aláírás integritása és az aláíró megbízhatósága külön döntések. Egy éles környezetben végzett ellenőrzési szabálynak ellenőriznie kell a tanúsítványláncot, az érvényességi időszakot, a visszavonási állapotot, a várt személyazonosságot, a kulcs használatát, valamint minden megbízható időbélyeg követelményt.

**Mi történik, ha a tanúsítvány lejár?**

A tanúsítvány lejárata nem módosítja a bemutató bájtjait, de befolyásolja a tanúsítványbizalom értékelését. Az, hogy egy aláírás továbbra is elfogadható‑e, a szabályzattól és attól függ, hogy egy érvényes megbízható időbélyeg bizonyítja‑e, hogy az aláírás a tanúsítvány érvényessége alatt történt. Ne támaszkodjon csak a megjelenített aláírási időre megbízható időbélyegként.

**Módosítható még egy aláírt bemutató?**

Igen. Az aláírás nem zárja le a fájlt. Az aláírt tartalom szerkesztése általában érvényteleníti a meglévő aláírást, ezért először fejezze be a bemutatót, majd írja alá a végső változatot.

**Tartalmazhat egy bemutató egynél több aláírást?**

Igen. Minden aláírást adjon hozzá a [IPresentation.DigitalSignatures]...‑hez a mentés előtt. Az ellenőrzés során vizsgálja meg minden aláírást, és erősítse meg, hogy minden szükséges alírót jelen van.

**Mely bemutatóformátumok támogatják ezeket a műveleteket?**

Az Aspose.Slides csak a PPTX formátum esetén támogatja a leírt digitális aláírási műveleteket. A PPT és az OpenDocument bemutató formátumok nincsenek támogatva ebben az API munkafolyamatban.

**Eltávolíthatok aláírást anélkül, hogy a diákra hatással lenne?**

Igen. Egy aláírást eltávolíthat, vagy törölheti az egész gyűjteményt, majd mentheti a bemutatót. A diák tartalma megmarad, de a mentett fájl többé már nem tartalmazza a eltávolított aláírás bizonyítékát.