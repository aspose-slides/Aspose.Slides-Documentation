---
title: Írásvédett prezentációk .NET környezetben
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/net/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- jelszó a módosításhoz
- prezentáció szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Állítsa be, észlelje, ellenőrizze és távolítsa el az írásvédelmi jelszavakat PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for .NET használatával."
---
## **Bevezetés**

A írásvédelmi jelszó korlátozza egy prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók a jelszó nélkül is betölthetik és megtekinthetik az írásvédett prezentációt. Az alkalmazástól függően szerkeszthetik is a tartalmat, és más néven elmenthetik, ezért az írásvédelmet nem szabad bizalmasági mechanizmusként kezelni.

A nyitó jelszó más célra szolgál: titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. A prezentáció titkosításához vagy egy nyitó jelszó ellenőrzéséhez tekintse meg a [Jelszóval védett prezentációk](/slides/hu/net/password-protected-presentation/) oldalt.

A cikkben szereplő munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák PPTX fájlokat használnak; PPT formátumba mentéskor használja a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot.

## **Írásvédelem beállítása a prezentáción**

Az [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/setwriteprotection/) használatával adhat meg jelszót a prezentáció módosításához. A prezentáció mentése megőrzi a védelmi beállítást.

Az alábbi példa írásvédelmet állít be egy PPTX prezentáción:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Írásvédett prezentáció betöltése**

Mivel az írásvédelem nem titkosítja a prezentáció tartalmát, a prezentáció betöltéséhez nem szükséges jelszó. A jelszó csak akkor releváns, amikor a védett prezentáció módosítási jogosultságát ellenőrizni kell.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Ne adjon meg írásvédelmi jelszót a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) tulajdonságnak. Ez a tulajdonság titkosított tartalomhoz nyitó jelszót vár. Ha egy prezentáció mindkét védelmet tartalmazza, adja meg a nyitó jelszót a betöltéshez, és az írásvédelmi jelszót külön kezelje.

## **Írásvédelem eltávolítása egy prezentációból**

Az [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/removewriteprotection/) használatával távolítsa el a módosítási korlátozást, majd mentse a prezentációt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Ellenőrzés, hogy a prezentáció írásvédett-e**

Egy fájl vizsgálatához anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hozna létre, hívja meg az [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust, és ellenőrizze az [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/iswriteprotected/) tulajdonságot. A tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) típust használja, és `NullableBool.True` értéket ad vissza, ha írásvédelmet észlel.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Az [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationfactory/getpresentationinfo/) stream túlterhelése ugyanazt az információt adja egy streamként megadott prezentáció esetén.

## **Írásvédelmi jelszó ellenőrzése**

Az [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/checkwriteprotection/) használatával ellenőrizhet egy módosítási jelszót a teljes prezentáció betöltése nélkül. Először ellenőrizze az [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/iswriteprotected/) tulajdonságot, hogy az alkalmazás csak írásvédelem esetén kérjen vagy ellenőrizzen jelszót.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/checkwriteprotection/) csak az írásvédelmi jelszót ellenőrzi. Nem ellenőriz nyitó jelszót, illetve nem határozza meg, hogy a titkosított tartalom betölthető-e. Ezzel ellentétben a [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/checkpassword/) csak egy nyitó jelszót ellenőriz. Ha a teljes prezentáció már be van töltve, az [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/checkwriteprotection/) ugyanazt az írásvédelmi ellenőrzést biztosít a védelmi menedzserén keresztül.

Éles alkalmazásokban ne naplózza a jelszavakat, és ne vegye bele őket a diagnosztikai üzenetekbe. Kerülje a felesleges, ismétlődő ellenőrzési kísérleteket, és a jelszavakat csak a szükséges ideig tartsa memóriában.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval védett prezentációk](/slides/hu/net/password-protected-presentation/)
- [Csak olvasható prezentációk](/slides/hu/net/read-only-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e a írásvédelem a prezentációt?**

Nem. Korlátozza a módosítást, de a prezentáció tartalma továbbra is betölthető és megtekinthető.

**Szükséges-e az írásvédelmi jelszó a prezentáció megnyitásához?**

Nem. Csak egy nyitó jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet-e egy prezentációnak egyszerre nyitó és írásvédelmi jelszava?**

Igen. A nyitó jelszót a betöltési beállításokban adja meg a titkosított prezentáció megnyitásához, az írásvédelmi jelszót pedig külön ellenőrizze, amikor a módosítási jogosultságra van szükség.