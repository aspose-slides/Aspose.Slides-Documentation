---
title: .NET-ben a prezentációk jelszóval való védelme
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/net/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- megnyitási jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszó ellenőrzése
- prezentáció jelszó vizsgálata
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg és dekódolja a jelszóval védett PowerPoint PPT és PPTX prezentációkat C#-ban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosít egy prezentációt. A helyes jelszó szükséges a prezentáció tartalmának betöltéséhez és megtekintéséhez, ezért ez a védelem bizalmasságot biztosít.

A megnyitási jelszó eltér a írásvédelem jelszavától. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséről lásd a [Write-Protect Presentations](/slides/hu/net/write-protected-presentation/).

Az alábbi munkafolyamatok mind PPT, mind PPTX prezentációkra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és az adatfolyam‑alapú viselkedés fontos.

## **Prezentáció titkosítása megnyitási jelszóval**

Az [IProtectionManager.Encrypt](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/encrypt/) használatával állíthat be megnyitási jelszót. Ezután az [IPresentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/save/) segítségével mentse a titkosított prezentációt.

A következő példa egy PPTX prezentációt titkosít:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Dokumentumtulajdonságok nyilvánosak tartása**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belefoglalja a prezentáció titkosításába. Az [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) tulajdonság önállóan vezérli ezt a viselkedést a diatartalom titkosításától függetlenül. Állítsa `false`‑ra, mielőtt meghívná az [IProtectionManager.Encrypt](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/encrypt/) metódust, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a metaadatokat megnyitási jelszó nélkül kell olvasnia.

A következő példa egy titkosított PPTX prezentációt hoz létre, miközben a beépített dokumentumtulajdonságok nyilvánosak maradnak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Az `EncryptDocumentProperties` `false`‑ra állítása nem teszi a diák, a mester‑diák, elrendezések, alakzatok, média vagy egyéb prezentációs tartalmak nyilvánossá. Csak a dokumentumtulajdonságokra van hatással. A titkosított tartalom betöltése nélkül ezeknek a tulajdonságoknak az olvasásához lásd a [Manage Presentation Properties](/slides/hu/net/presentation-properties/) oldalt.

## **Titkosított prezentáció betöltése**

Állítsa a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) értékét a megnyitási jelszóra, és adja át az opciókat a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztálynak a fájl betöltésekor. A betöltés sikertelen, ha megnyitási jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Munkáljon a visszafejtett prezentációval.
```

## **Titkosítás eltávolítása egy prezentációból**

Töltse be a prezentációt a megnyitási jelszóval, hívja meg az [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/removeencryption/) metódust, majd mentse az eredményt. A mentett prezentáció ezután jelszó nélkül is betölthető.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Megnyitási jelszó ellenőrzése betöltés előtt**

Az [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationfactory/getpresentationinfo/) használatával szerezzen [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) objektumot anélkül, hogy teljes prezentációs példányt hozna létre. Ellenőrizze az [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/ispasswordprotected/) értékét, mielőtt jelszót kérne vagy ellenőrizne. Ha védelem van, a megadott értéket az [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/checkpassword/) metódussal ellenőrizze.

### **Fájlelérési munkafolyamat**

A következő példa egy PPTX fájl megnyitási jelszavát ellenőrzi, átadja az ellenőrzött értéket a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) paraméternek, majd betölti a teljes prezentációt:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Adatfolyam munkafolyamat**

Az [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationfactory/getpresentationinfo/) adatfolyam‑túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza egy kereshető adatfolyam pozícióját, mielőtt betöltené a teljes prezentációt az adatfolyamból.

A következő példa egy PPT fájlt használ:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword visszatérési értékek**

Az [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/checkpassword/) akkor ad vissza `true`‑t, ha a prezentáció rendelkezik megnyitási jelszóval, és a megadott jelszó helyes. `false`‑t ad a következő esetekben:

- A jelszó helytelen.
- A prezentáció nem rendelkezik megnyitási jelszóval.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX prezentációk esetén is ugyanaz.

## **Ellenőrizze, hogy a betöltött prezentáció titkosított-e**

A prezentáció helyes jelszóval történő betöltése után vizsgálja meg az [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/isencrypted/) értékét, hogy megerősítse, a forrás prezentáció titkosított volt-e. A megnyitási jelszavas védelem betöltés előtti észleléséhez használja a `IPresentationInfo.IsPasswordProtected` értéket, ahogyan fent bemutattuk.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Security" %}}
Ne naplózza a megnyitási jelszavakat, és ne tüntesse fel őket diagnosztikai üzenetekben. Kerülje a szükségtelen, ismételt ellenőrzési kísérleteket, a jelszavakat csak annyi ideig tartsa memóriában, amennyi szükséges, és használja újra a sikeres ellenőrzés eredményét, ha azonnal betölti a prezentációt.

A nyilvános dokumentumtulajdonságok felfedhetik a szerző nevét, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket, még ha a prezentáció tartalma titkosított is. Titkosítsa az érzékeny metaadatokat a prezentációval együtt. A tulajdonságok nyilvánosan hagyása csak akkor legyen kifejezett döntés, amikor a rendszereknek indexelni, osztályozni, keresni vagy kezelni kell a fájlt megnyitási jelszó nélkül.
{{% /alert %}}

## **Prezentáció jelszóvédelem online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
1. Válassza ki vagy töltse fel a prezentációt.
1. Adjon meg egy jelszót a megtekintés védelméhez.
1. Opcionálisan adjon meg külön jelszót a szerkesztés védelméhez.
1. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hu/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetem a megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze meg a prezentáció információit, ellenőrizze, hogy van‑e megnyitási jelszavas védelem, és ellenőrizze a jelszót, mielőtt teljes prezentációs példányt hozna létre.

**Olvashat-e egy alkalmazás metaadatokat a megnyitási jelszó nélkül?**

Igen, de csak akkor, ha a prezentáció titkosítása során az `EncryptDocumentProperties` `false`‑ra van állítva. Ilyenkor az alkalmazásnak a [Manage Presentation Properties](/slides/hu/net/presentation-properties/) leírásában szereplő csak dokumentumtulajdonságok betöltését kell használnia.

**Támogatja a jelszó‑ellenőrzési munkafolyamat a PPT és PPTX formátumokat is?**

Igen. A fájl‑elérési és adatfolyam‑alapú jelszó‑felderítés és ellenőrzés ugyanúgy működik PPT és PPTX prezentációk esetén.