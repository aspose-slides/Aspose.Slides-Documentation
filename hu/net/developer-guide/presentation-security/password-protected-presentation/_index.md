---
title: Jelszóval védett prezentációk .NET-ben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/net/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszó validálása
- prezentáció jelszó ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Titkosítsa, detektálja, validálja, nyissa meg, és visszafejti a jelszóval védett PowerPoint PPT és PPTX prezentációkat C#-ban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A nyitó jelszó titkosítja a prezentációt. A helyes jelszó szükséges a prezentáció tartalmának betöltéséhez és megtekintéséhez, így ez a védelem bizalmasságot biztosít.

A nyitó jelszó eltér a írásvédelem jelszavától. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséhez tekintse meg az [Írásvédelem a prezentációkhoz](/slides/hu/net/write-protected-presentation/).

Az alábbi munkafolyamatok PPT és PPTX prezentációkra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és az adatfolyam‑alapú viselkedés fontos.

## **Titkosítsa a prezentációt nyitó jelszóval**

Használja az IProtectionManager.Encrypt metódust nyitó jelszó hozzárendeléséhez. Ezután használja az IPresentation.Save metódust a titkosított prezentáció mentéséhez.

A következő példa egy PPTX prezentációt titkosít:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Titkosított prezentáció betöltése**

Állítsa be a LoadOptions.Password értékét a nyitó jelszóra, és adja át az opciókat a Presentation‑nek a fájl betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Munkáljon a visszafejtett prezentációval.
```

## **Titkosítás eltávolítása egy prezentációból**

Betöltse a prezentációt a nyitó jelszavával, hívja meg az IProtectionManager.RemoveEncryption metódust, majd mentse az eredményt. A mentett prezentáció ezután jelszó nélkül is betölthető.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használja az IPresentationFactory.GetPresentationInfo metódust az IPresentationInfo megszerzéséhez anélkül, hogy teljes prezentációs példányt hozna létre. Ellenőrizze az IPresentationInfo.IsPasswordProtected értéket, mielőtt jelszó kérést vagy ellenőrzést végezne. Ha védelem van, validálja a megadott értéket az IPresentationInfo.CheckPassword metódussal.

### **Fájlelérési út Munkafolyamat**

Az alábbi példa egy PPTX fájl nyitó jelszavát ellenőrzi, átadja a validált értéket a LoadOptions.Password‑nek, majd betölti a teljes prezentációt:

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

### **Adatfolyam Munkafolyamat**

Az IPresentationFactory.GetPresentationInfo adatfolyam‑túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza egy kereshető adatfolyam pozícióját, mielőtt betöltené a teljes prezentációt abból az adatfolyamból.

Az alábbi példa egy PPT fájlt használ:

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

Az IPresentationInfo.CheckPassword csak akkor ad vissza `true` értéket, ha a prezentáció nyitó jelszóval védett és a megadott jelszó helyes. Minden egyes alábbi esetben `false` értéket ad vissza:

- A jelszó helytelen.
- A prezentációnak nincs nyitó jelszója.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX prezentációknál egyforma.

## **Ellenőrizze, hogy a betöltött prezentáció titkosított-e**

Miután egy prezentációt helyes jelszóval betöltött, ellenőrizze az IProtectionManager.IsEncrypted értékét, hogy megerősítse a forrásprezentáció titkosítását. A nyitó jelszó védelem betöltés előtti felismeréséhez használja az IPresentationInfo.IsPasswordProtected értéket, ahogyan fentebb bemutattuk.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Biztonság" %}}
Ne naplózza a nyitó jelszavakat, és ne tartalmazza őket diagnosztikai üzenetekben. Kerülje a felesleges ismételt ellenőrzési kísérleteket, a jelszavakat csak a szükséges időtartamra tartsa memóriában, és használja újra a sikeres ellenőrzés eredményét, ha azonnal betölti a prezentációt.
{{% /alert %}}

## **Prezentáció jelszóval védése online**

1. Nyissa meg az Aspose.Slides Lock alkalmazást.
1. Válassza ki vagy töltse fel a prezentációt.
1. Adjon meg egy jelszót a megtekintési védelemhez.
1. Opcionálisan adjon meg egy külön jelszót a szerkesztési védelemhez.
1. Alkalmazza a védelmet, majd töltse le a keletkezett fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Írásvédelem a prezentációkhoz](/slides/hu/net/write-protected-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a prezentációt, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetem a nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze meg a prezentáció információit, ellenőrizze, hogy van‑e nyitó jelszó védelem, majd validálja a jelszót a teljes prezentáció létrehozása előtt.

**A jelszó‑ellenőrző munkafolyamatok támogatják mind a PPT, mind a PPTX formátumot?**

Igen. A fájl‑alapú és az adatfolyam‑alapú jelszó‑detektálás és validálás ugyanúgy működik PPT és PPTX prezentációknál.