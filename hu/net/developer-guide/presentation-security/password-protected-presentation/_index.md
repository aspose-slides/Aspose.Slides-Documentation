---
title: Prezentációk védelme jelszóval .NET-ben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/net/password-protected-presentation/
keywords:
- PowerPoint zárolása
- bemutató zárolása
- PowerPoint feloldása
- bemutató feloldása
- PowerPoint védelme
- bemutató védelme
- jelszó beállítása
- jelszó hozzáadása
- PowerPoint titkosítása
- bemutató titkosítása
- PowerPoint visszafejtése
- bemutató visszafejtése
- írásvédelem
- PowerPoint biztonság
- bemutató biztonság
- jelszó eltávolítása
- védelem eltávolítása
- titkosítás eltávolítása
- jelszó letiltása
- védelem letiltása
- írásvédelem eltávolítása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan zárolhat és oldhat fel egyszerűen jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides for .NET segítségével. Biztosítsa a prezentációi védelmét."
---
## **Bevezetés**

Amikor egy bemutatót jelszóval védünk, egy jelszót állítunk be, amely bizonyos korlátozásokat vezet be a bemutatóba. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett bemutatót lezárt bemutatónak tekintjük.

Általában beállíthatja a jelszót, hogy ezeket a korlátozásokat a bemutatóra alkalmazza:

- **Módosítás**

Ha csak bizonyos felhasználók módosíthassák a bemutatót, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók módosítsák, változtassák vagy másolják a bemutató elemeit, hacsak nem adják meg a jelszót.

Azonban a jelszó nélkül a felhasználó továbbra is hozzáférhet és megnyithatja a dokumentumot. Olvasási módban a felhasználó megtekintheti a tartalmat – beleértve a hiperhivatkozásokat, animációkat, effekteket és egyéb elemeket – a bemutatóban, de nem másolhat elemeket, és nem mentheti el a bemutatót.

- **Megnyitás**

Ha csak bizonyos felhasználók nyithassák meg a bemutatót, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy bárki megtekintse a bemutató tartalmát, hacsak nem adja meg a jelszót.

Technikailag a megnyitási korlátozás megakadályozza a felhasználókat a bemutató módosításában is – ha valaki nem tudja megnyitni a bemutatót, nem tudja módosítani vagy változtatni rajta.

**Megjegyzés:** Amikor jelszóval véd egy bemutatót a megnyitás megakadályozása érdekében, a bemutató fájl titkosított lesz.

## **Jelszóvédelem az Aspose.Slides-ben**

**Támogatott formátumok**

Az Aspose.Slides jelszóvédelmet, titkosítást és hasonló műveleteket támogat a következő formátumú bemutatók esetén:

- PPTX és PPT – Microsoft PowerPoint bemutatók
- ODP – OpenDocument bemutatók
- OTP – OpenDocument bemutató sablonok

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi a jelszóvédelem használatát a bemutatók módosításának megakadályozására a következő módon:

- Bemutató titkosítása
- Írásvédettség beállítása a bemutatón

**Egyéb műveletek**

Az Aspose.Slides további, jelszóvédelemmel és titkosítással kapcsolatos feladatok végrehajtását teszi lehetővé:

- Bemutató visszafejtése; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása a bemutatóból
- Titkosított bemutató tulajdonságainak lekérdezése
- Annak ellenőrzése, hogy a bemutató jelszóval van-e védve a betöltés előtt
- Annak ellenőrzése, hogy a bemutató titkosított-e
- Annak ellenőrzése, hogy a bemutató jelszóval van-e védve

## **Bemutató védelme jelszóval**

A bemutatót titkosíthatja egy jelszó beállításával. Ezután a lezárt bemutató módosításához a felhasználónak meg kell adnia a jelszót.

A bemutató titkosításához (vagy jelszóval való védelméhez) használja a `Encrypt` metódust a [ProtectionManager](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager) osztályból. Adja át a jelszót az `Encrypt` metódusnak, majd a `Save` metódussal mentse el a most már titkosított bemutatót.

Ez a mintakód megmutatja, hogyan titkosíthat egy bemutatót:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Írásvédelem beállítása a bemutatón** 

Hozzáadhat egy „Ne módosítsa” jelzést a bemutatóhoz. Ez azt jelzi a felhasználóknak, hogy nem kívánja, hogy módosítsák a bemutatót.

**Megjegyzés:** Az írásvédelmi folyamat nem titkosítja a bemutatót. Ezért a felhasználók – ha úgy döntenek – módosíthatják a bemutatót, de a módosítások mentéséhez másik néven kell elmenteniük.

Az írásvédelem beállításához használja a `SetWriteProtection` metódust. Ez a mintakód megmutatja, hogyan állíthat be írásvédelmet egy bemutatón:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Titkosított bemutató betöltése**

Az Aspose.Slides lehetővé teszi egy titkosított bemutató betöltését a megfelelő jelszó megadásával. Ez a mintakód megmutatja, hogyan tölthet be egy titkosított bemutatót:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Dolgozz a visszafejtett prezentációval.
}
```

## **Titkosítás eltávolítása a bemutatóból**

Eltávolíthatja a titkosítást vagy a jelszóvédelmet a bemutatóból, így a felhasználók korlátozás nélkül férhetnek hozzá vagy módosíthatják azt.

A titkosítás vagy a jelszóvédelem eltávolításához hívja meg a [RemoveEncryption](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/methods/removeencryption) metódust. Ez a mintakód megmutatja, hogyan távolítható el a titkosítás egy bemutatóból:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Írásvédelem eltávolítása a bemutatóból**

Az Aspose.Slides segítségével eltávolíthatja az írásvédelmet egy bemutatófájlból. Így a felhasználók szabadon módosíthatják azt, és nem kapnak figyelmeztetést az ilyen műveletek során.

Az írásvédettség eltávolításához használja a [RemoveWriteProtection](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/methods/removewriteprotection) metódust. Ez a mintakód megmutatja, hogyan távolítható el az írásvédelem egy bemutatóról:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Titkosított bemutató tulajdonságainak lekérdezése**

Általában a felhasználók nehezen tudják lekérdezni egy titkosított vagy jelszóval védett bemutató dokumentumtulajdonságait. Az Aspose.Slides azonban olyan mechanizmust kínál, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben a felhasználók továbbra is hozzáférhetnek a tulajdonságokhoz.

**Megjegyzés:** Alapértelmezés szerint, amikor az Aspose.Slides titkosít egy bemutatót, a bemutató dokumentumtulajdonságai is jelszóval védettek. Ha a titkosítás után is elérhetővé szeretné tenni a dokumentumtulajdonságokat, az Aspose.Slides pontosan ezt teszi lehetővé.

Ha azt szeretné, hogy a felhasználók a titkosított bemutató tulajdonságait is elérjék, állítsa az [IProtectionManager](https://reference.aspose.com/slides/hu/net/aspose.slides/iprotectionmanager/) `EncryptDocumentProperties` tulajdonságát `false`-ra. Ez a mintakód megmutatja, hogyan titkosíthat egy bemutatót úgy, hogy a felhasználók továbbra is hozzáférhetnek a dokumentumtulajdonságokhoz:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Csak a dokumentumtulajdonságok betöltése egy titkosított bemutatóból**

A titkosított bemutató metaadatainak vizsgálatához anélkül, hogy a diák vagy egyéb tartalom betöltődne, hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, és állítsa az [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) értékét `true`-ra. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentumtulajdonságokat tölti be.

Az alábbi kódrészlet beolvassa a beépített és egyedi dokumentumtulajdonságokat a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/documentproperties/) segítségével:

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Ez a munkafolyamat csak akkor működik, ha a dokumentumtulajdonságok titkosítás nélkül (nyilvános) maradtak a bemutató titkosítása közben. Ha a dokumentumtulajdonságok titkosítva vannak, a `OnlyLoadDocumentProperties` `true` értékre állítása kivételt eredményez, mivel ebben a módban a jelszó figyelmen kívül marad. Titkosított dokumentumtulajdonságok eléréséhez vagy a teljes bemutató (diák és egyéb tartalom) betöltéséhez adja meg a megfelelő `Password` értéket a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumban.

## **Ellenőrzés, hogy a bemutató jelszóval védett-e**

Mielőtt betöltene egy bemutatót, lehet, hogy ellenőrizni szeretné, hogy nincs-e jelszóval védve. Ez segít elkerülni a hibákat és az ehhez hasonló problémákat, amelyek akkor merülnek fel, amikor egy jelszóval védett bemutatót helytelen jelszóval próbálnak betölteni.

Ez a C# kód megmutatja, hogyan vizsgálhatja meg egy bemutatót, hogy jelszóval védett-e, anélkül hogy ténylegesen betöltené:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Ellenőrzés, hogy a bemutató titkosított-e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató titkosított‑e. Ehhez használja az [IsEncrypted](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/properties/isencrypted) tulajdonságot, amely `true`‑t ad vissza, ha a bemutató titkosított, és `false`‑t, ha nem.

Ez a mintakód megmutatja, hogyan ellenőrizhető, hogy egy bemutató titkosított‑e:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Ellenőrzés, hogy a bemutató írásvédett‑e**

Az Aspose.Slides lehetővé teszi annak ellenőrzését, hogy egy bemutató írásvédett‑e. Ehhez használja az [IsWriteProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/protectionmanager/properties/iswriteprotected) tulajdonságot, amely `true`‑t ad vissza, ha a bemutató írásvédett, és `false`‑t, ha nem.

Ez a mintakód megmutatja, hogyan ellenőrizhető, hogy egy bemutató írásvédett‑e:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **A bemutató jelszóhasználatának ellenőrzése**

Lehet, hogy ellenőrizni és megerősíteni szeretné, hogy egy adott jelszót felhasználtak-e a bemutató dokumentum védelmére. Az Aspose.Slides lehetővé teszi a jelszó validálását.

Ez a mintakód megmutatja, hogyan validálhat egy jelszót:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Ellenőrizze, hogy a jelszó egyezik-e.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

A metódus `true`‑t ad vissza, ha a bemutatót a megadott jelszóval titkosították; egyébként `false`‑t.

{{% alert color="info" title="Lásd még" %}} 
- [Digitális aláírás PowerPointban](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Bemutató jelszóval való védése online**

1. Látogasson el a **[Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock)** oldalra. 
1. Kattintson a **„Dobja vagy töltse fel a fájlokat”** gombra.
1. Válassza ki a számítógépéről a jelszóval védeni kívánt fájlt. 
1. Adja meg a szerkesztésvédelmi jelszót és a megtekintési jelszót.
1. Ha azt szeretné, hogy a felhasználók a bemutatót végleges példányként lássák, jelölje be a **„Megjelölés véglegesnek”** jelölőnégyzetet.
1. Kattintson a **PROTECT NOW.** gombra. 
1. Kattintson a **DOWNLOAD NOW.** gombra.

![Password protect PowerPoint presentations](slides-lock.png)

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, többek között AES‑alapú algoritmusokat, ezzel magas szintű adatbiztonságot biztosítva a bemutatók számára.

**Mi történik, ha hibás jelszót adnak meg a bemutató megnyitásakor?**

Kivétel keletkezik, ha hibás jelszót használnak, jelezve, hogy a bemutatóhoz való hozzáférés megtagadva. Ez megakadályozza a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli hatások, amikor jelszóval védett bemutatókkal dolgozunk?**

A titkosítási és visszafejtési folyamat némi többletterhet okozhat a megnyitás és mentés során. A legtöbb esetben ez a teljesítménybeli hatás elhanyagolható, és nem befolyásolja jelentősen a bemutatófeldolgozási feladatok általános időtartamát.