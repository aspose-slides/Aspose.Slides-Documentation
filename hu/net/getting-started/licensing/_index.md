---
title: Licencelés
type: docs
weight: 80
url: /hu/net/licensing/
keywords:
- licenc
- ideiglenes licenc
- licenc beállítása
- licenc használata
- licenc ellenőrzése
- licencfájl
- értékelő verzió
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for .NET-ben. Biztosítsa a megszakítás nélküli hozzáférést a teljes funkciókhoz lépésről lépésre útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides használható értékelő módban vagy érvényes licenccel. Az értékelő változat ugyanazt a funkcionalitást biztosítja, mint a licencelt változat, de minden mentett prezentáció minden diájára értékelő vízjelet helyez, és levágja a kódból olvasott szöveget a prezentációkból.

Ez a cikk bemutatja, hogyan működik a licenckezelés az Aspose.Slides-ben, és hogyan kell licencet alkalmazni a könyvtár használata előtt. A licenc betölthető fájlból, folyamatról (stream) vagy beágyazott erőforrásból a `License` osztály használatával. A cikk szintén megmutatja, hogyan lehet ellenőrizni, hogy a licenc megfelelően lett-e alkalmazva.

## **Az Aspose.Slides kipróbálása**
{{% alert color="info" title="Note" %}}
Letöltheti az **Aspose.Slides for .NET** értékelő változatát a [nuget letöltési oldaláról](https://www.nuget.org/packages/Aspose.Slides.NET/). Az értékelő változat ugyanazokat a funkciókat biztosítja, mint a termék licencelt változata. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő változat egyszerűen licencet kap, ha néhány kódsort hozzáad (a licenc alkalmazásához).

Miután elégedett az **Aspose.Slides** értékelésével, megvásárolhatja a licencet a [licenc vásárlása](https://purchase.aspose.com/pricing/slides/hu/net/) oldalon. Javasoljuk, hogy tekintse át a különböző előfizetéstípusokat. Ha kérdése van, lépjen kapcsolatba az Aspose értékesítési csapatával.

Minden Aspose licenc egyéves előfizetéssel jár, amely ingyenes frissítéseket biztosít az előfizetési időszakon belül kiadott új verziókra vagy javításokra. A licencelt termékekkel vagy még az értékelő változatokkal rendelkező felhasználók ingyenes és korlátlan technikai támogatást kapnak.
{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Az értékelő verzió (licenc megadása nélkül) teljes termékfunkcionalitást biztosít, de minden mentett prezentáció minden diájára egy értékelő vízjel szövegdobozt helyez.
* A prezentációból a kód által olvasott szöveg az első néhány karakterre lesz levágva, amelyet egy értesítés követ az értékelő korlátozásról. A kód által írt szöveg teljes egészében mentésre kerül.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan kérhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licenckezelés az Aspose.Slides-ben**
* Az értékelő verzió licencessé válik, miután megvásárolta a licencet és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát és egyebeket.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egy véletlen sortörés hozzáadása is érvényteleníti.
* Az Aspose.Slides for .NET általában ezeken a helyeken próbálja meg megtalálni a licencet:
  * Kifejezett útvonal
  * A komponens DLL-jét tartalmazó mappa (Az Aspose.Slides-be beágyazva)
  * A komponens DLL-jét meghívó assembly-t tartalmazó mappa (Az Aspose.Slides-be beágyazva)
  * A belépő assembly-t (az .exe) tartalmazó mappa
  * Beágyazott erőforrás az assembly-ben, amely meghívta a komponens DLL-jét (Az Aspose.Slides-be beágyazva).
* Az értékelő verzióval járó korlátozások elkerüléséhez licencet kell beállítani az Aspose.Slides használata előtt. A licencet csak egyszer kell beállítani alkalmazáson vagy folyamatonként.

{{% alert color="info" title="Note" %}}
Érdemes megnézni a [Metered Licensing](/slides/hu/net/metered-licensing/) oldalt.
{{% /alert %}} 

## **Licenc alkalmazása**
A licenc betölthető **fájlból**, **folyamatról** vagy **beágyazott erőforrásból**. 

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/net/aspose.slides/license) osztályt biztosítja a licencelési műveletekhez.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatók az Aspose.Slides-ban. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**
A licenc beállításának legegyszerűbb módja, ha a licencfájlt ugyanabban a mappában helyezzük el, ahol a komponens DLL-je (Az Aspose.Slides-be beágyazva) található, és csak a fájlnevet adjuk meg útvonal nélkül.

Ez a C# kód bemutatja, hogyan állítható be egy licencfájl:

``` csharp
// Létrehozza a License osztályt 
Aspose.Slides.License license = new Aspose.Slides.License();

// Beállítja a licencfájl útvonalát
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
Ha a licencfájlt egy másik könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódus meghívásakor a megadott útvonal végén szereplő licencfájl nevének meg kell egyeznie a licencfájl nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.lic.xml*-re. Ezután a kódban a fájl elérési útját (amely *Aspose.Slides.lic.xml*-re végződik) kell átadni a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódusnak.
{{% /alert %}}

### **Folyamat**
Licencet betölthet egy folyamatról. Ez a C# kód bemutatja, hogyan alkalmazzon licencet egy folyamatról:

``` csharp
// Létrehozza a License osztályt
Aspose.Slides.License license = new Aspose.Slides.License();

// Megnyitja a licencfájlt folyamként
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Beállítja a licencet folyamon keresztül
license.SetLicense(licenseStream);
```

### **Beágyazott erőforrás**
A licencet beágyazott erőforrásként csomagolhatja az alkalmazásba (a elvesztés elkerülése érdekében), ha a licencet beágyazott erőforrásként hozzáadja a komponens DLL-jét meghívó egyik assembly-hez (Az Aspose.Slides-be beágyazva).

Ez a módja egy licencfájl beágyazott erőforrásként való hozzáadásának:
1. A Visual Studio-ban adja hozzá a licenc (.lic) fájlt a projekthez a következő módon: Menjen a **File** > **Add Existing Item** > **Add** menüpontokra. 
2. Válassza ki a fájlt a **Solution Explorer**-ben.
3. A **Properties** ablakban állítsa a **Build Action** értékét **Embedded Resource**-ra.
4. Az assembly-be beágyazott licenc eléréséhez adja hozzá a licencfájlt beágyazott erőforrásként a projekthez, majd adja át a licencfájl nevét a `SetLicense` metódusnak. 

A `License` osztály automatikusan megtalálja a licencfájlt a beágyazott erőforrások között. Nem szükséges a `GetExecutingAssembly` és a `GetManifestResourceStream` metódusokat meghívni a `System.Reflection.Assembly` osztályból a Microsoft .NET Framework-ben.

``` csharp
// Létrehozza a License osztályt
Aspose.Slides.License license = new Aspose.Slides.License();

// Átadja az assembly-ben beágyazott licencfájl nevét
license.SetLicense("Aspose.Slides.lic");
```

## **Licenc ellenőrzése**
Annak ellenőrzésére, hogy a licenc megfelelően be van-e állítva, ellenőrizheti azt. Ez a C# kód bemutatja, hogyan ellenőrizhető a licenc:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Szálbiztonság**
{{% alert color="warning" title="Warning" %}}
A [license.SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell hívni, célszerű szinkronizációs primitíveket (például lock) használni a problémák elkerülése érdekében. 
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?
Igen. A licenc ellenőrzése helyben, a licencfájl használatával történik; internetkapcsolat nem szükséges.

### Mi történik, amikor az egyéves előfizetés lejár? Leáll-e a könyvtár?
Nem. A licenc örökös: a feliratkozás lejárati dátuma előtt kiadott verziókat továbbra is használhatja; azonban az újabb kiadások használatához megújítás szükséges.