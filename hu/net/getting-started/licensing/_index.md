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
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for .NET-ben. Biztosítsa a folyamatos hozzáférést a teljes funkcionalitáshoz részletes, lepesrol-lepesre utmutatonnal."
---
## **Áttekintés**

Az Aspose.Slides használható értékelő módban vagy érvényes licenccel. Az értékelő verzió ugyanazt a funkcionalitást nyújtja, mint a licencelt verzió, de egy értékelő vízjelet helyez el a prezentáció megnyitásakor vagy mentésekor, és a szövegkivonást egy diára korlátozza.

Ez a cikk leírja, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan alkalmazzunk licencet a könyvtár használata előtt. Licencet fájlból, streamből vagy beágyazott erőforrásból lehet betölteni a `License` osztály használatával. A cikk bemutatja azt is, hogyan validálhatjuk, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**
{{% alert color="info" %}} 

Letöltheti a **Aspose.Slides for NET** értékelő verzióját a [NuGet letöltési oldaláról](https://www.nuget.org/packages/Aspose.Slides.NET/). Az értékelő verzió ugyanazokat a funkciókat biztosítja, mint a termék licencelt verziója. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő verzió egyszerűen licencelté válik, miután néhány kódsort hozzáad (a licenc alkalmazásához).

Miután elégedett a **Aspose.Slides** értékelésével, [vásárolhat licencet](https://purchase.aspose.com/buy). Ajánljuk, hogy tekintse át a különböző előfizetéstípusokat. Kérdések esetén lépjen kapcsolatba az Aspose értékesítési csapatával.

Minden Aspose licenc egyéves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakban kiadott új verziókra vagy javításokra. A licencelt termékek vagy akár az értékelő verziók felhasználói ingyenes és korlátlan technikai támogatást kapnak.
{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Míg az Aspose.Slides értékelő verziója (licenc megadása nélkül) teljes termékfunkcionalitást nyújt, egy értékelő vízjelet helyez a dokumentum tetejére megnyitáskor és mentéskor.
* A szövegek kivonása a prezentációdiákból egy diára van korlátozva.

{{% alert color="info" %}} 

Aspose.Slides korlátok nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan lehet ideiglenes licencet kérni](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**
* Az értékelő verzió licencelté válik, miután megvásárol egy licencet, és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb.
* A licencfájl digitálisan alá van írva, ezért azt nem szabad módosítani. Még egy felesleges sortörés hozzáadása a fájl tartalmához is érvényteleníti azt.
* Az Aspose.Slides for .NET általában a következő helyeken keres licencet:
  * Kifejezett útvonal
  * A komponens DLL-jét tartalmazó mappa (az Aspose.Slides része)
  * Az a mappa, amely a komponens DLL-jét meghívó assembly-t tartalmazza (az Aspose.Slides része)
  * Az belépő assembly-t (az Ön .exe) tartalmazó mappa
  * Beágyazott erőforrás az assembly-ben, amely a komponens DLL-jét meghívja (az Aspose.Slides része).
* Az értékelő verzióval járó korlátozások elkerülése érdekében a használat előtt licencet kell beállítani az Aspose.Slides-ben. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatként.
{{% alert color="info" %}} 
Érdemes megnézni a [Metered Licensing](https://docs.aspose.com/slides/hu/net/metered-licensing/) oldalt.
{{% /alert %}} 

## **Licenc alkalmazása**
Egy licenc betölthető **fájlból**, **streamből** vagy **beágyazott erőforrásból**. 

{{% alert color="info" %}}
Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/net/aspose.slides/license) osztályt biztosítja a licencelési műveletekhez.
{{% /alert %}} 

{{% alert color="warning" %}} 
Az új licencek csak a 21.4-es vagy későbbi verzióval aktiválhatók az Aspose.Slides-ben. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**
A licenc beállításának legegyszerűbb módja, ha a licencfájlt ugyanabban a mappában helyezi el, ahol a komponens DLL-je (az Aspose.Slides része) található, és csak a fájlnevet adja meg az útvonal nélkül.

Ez a C# kód megmutatja, hogyan állíthat be licencfájlt:
``` csharp
// Létrehozza a License osztályt 
Aspose.Slides.License license = new Aspose.Slides.License();

// Beállítja a licencfájl útvonalát
license.SetLicense("Aspose.Slides.lic");
```
{{% alert color="warning" %}} 
Ha a licencfájlt más könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódus hívásakor a megadott explicit útvonal végén szereplő licencfájl neve meg kell egyezzen a licencfájl nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.lic.xml*-ra. Ezután a kódban a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódusnak meg kell adnia a fájl útvonalát (amely *Aspose.Slides.lic.xml*-ra végződik).
{{% /alert %}}

### **Stream**
Licencet betölthet streamből. Ez a C# kód megmutatja, hogyan alkalmazzon licencet streamből:
``` csharp
// Létrehozza a License osztályt
Aspose.Slides.License license = new Aspose.Slides.License();

// Megnyitja a licencfájlt streamként
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Beállítja a licencet streamen keresztül
license.SetLicense(licenseStream);
```

### **Beágyazott erőforrás**
Beágyazott erőforrásként hozzáadhatja a licencet az alkalmazásához (hogy ne vesszen el), a licencet a komponens DLL-jét meghívó egyik assembly-be ágyazva (az Aspose.Slides része).

Így adhatja hozzá a licencfájlt beágyazott erőforrásként:
1. A Visual Studio-ban adja a licenc (.lic) fájlt a projekthez a következő módon: nyissa meg a **File** > **Add Existing Item** > **Add** menüt. 
2. Válassza ki a fájlt a **Solution Explorer**-ben.
3. A **Properties** ablakban állítsa a **Build Action**-t **Embedded Resource** értékre.
4. Az assembly-ben beágyazott licenc eléréséhez adja a licencfájlt beágyazott erőforrásként a projekthez, majd adja át a licencfájl nevét a `SetLicense` metódusnak. 

A `License` osztály automatikusan megtalálja a licencfájlt a beágyazott erőforrásokban. Nem szükséges meghívni a `GetExecutingAssembly` és a `GetManifestResourceStream` metódusokat a `System.Reflection.Assembly` osztályból a Microsoft .NET Framework-ön.

Ez a C# kód megmutatja, hogyan állítson be licencet beágyazott erőforrásként:
``` csharp
// Létrehozza a License osztályt
Aspose.Slides.License license = new Aspose.Slides.License();

// Átadja a beágyazott licencfájl nevét az assembly-ben
license.SetLicense("Aspose.Slides.lic");
```

## **Licenc ellenőrzése**
Annak ellenőrzésére, hogy a licenc megfelelően lett-e beállítva, validálhatja azt. Ez a C# kód megmutatja, hogyan validálja a licencet:
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
{{% alert title="Note" color="warning" %}} 
A [license.SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell hívni, érdemes szinkronizációs primitíveket (például zárat) használni a problémák elkerülése érdekében. 
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?
Igen. A licencvalidálás helyileg történik a licencfájl használatával; internetkapcsolat nem szükséges.

### Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?
Nem. A licenc időhatáros: továbbra is használhatja a feliratkozási dátuma előtt kiadott verziókat; azonban új kiadások használatához megújítás szükséges.