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
description: "Alkalmazza, kezelje és hárítsa el a licenceket az Aspose.Slides for .NET-ben. Biztosítsa a teljes funkcionalitáshoz való zavartalan hozzáférést lépésről lépésre szóló licencelési útmutatónkkal."
---
## **Áttekintés**

Aspose.Slides értékelő módban vagy érvényes licenccel használható. Az értékelő verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de hozzáad egy értékelő vízjelet a prezentációk megnyitásakor vagy mentésekor, és korlátozza a szövegkinyerést egy diára.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides‑ben, és hogyan kell licencet alkalmazni a könyvtár használata előtt. A licenc betölthető egy fájlból, adatfolyamból vagy beágyazott erőforrásból a `License` osztály használatával. A cikk azt is bemutatja, hogyan lehet ellenőrizni, hogy a licenc helyesen lett‑e alkalmazva.

## **Aspose.Slides értékelése**
{{% alert color="primary" %}} 

Letöltheti az **Aspose.Slides for NET** értékelő verzióját [a NuGet letöltőoldaláról](https://www.nuget.org/packages/Aspose.Slides.NET/). Az értékelő verzió ugyanazokat a funkciókat biztosítja, mint a termék licencelt verziója. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő verzió egyszerűen licencelté válik, miután néhány kódsort hozzáad (a licenc alkalmazásához).

Miután elégedett az **Aspose.Slides** értékelésével, [licencet vásárolhat](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a különböző előfizetési típusokat. Ha kérdése van, lépjen kapcsolatba az Aspose értékesítési csapatával.

Minden Aspose licenc egyéves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakon belül megjelenő új verziókhoz vagy javításokhoz. A licencelt termékekkel vagy akár az értékelő verziókkal is a felhasználók ingyenes és korlátlan technikai támogatást kapnak.

{{% /alert %}} 

**Az értékelő verzió korlátai**

* Míg az Aspose.Slides értékelő verziója (licenc nélkül) teljes termékfunkcionalitást nyújt, megnyitáskor és mentéskor a dokumentum tetejére egy értékelő vízjelet helyez el.
* A szövegek kinyerése során legfeljebb egy diára vagy korlátozva.

{{% alert color="primary" %}} 

Aspose.Slides korlátok nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [Ideiglenes licenc beszerzése](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides‑ben**
* Egy értékelő verzió licencelté válik, miután licencet vásárol, és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML‑fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát és egyéb adatokat.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egy véletlenül beillesztett sortörés is érvénytelenné teheti.
* Aspose.Slides for .NET általában a licencet a következő helyeken keresi:
  * Kifejezett útvonal
  * A komponens DLL‑jét tartalmazó mappa (az Aspose.Slides‑ben szerepel)
  * A komponens DLL‑jét meghívó assembly‑t tartalmazó mappa (az Aspose.Slides‑ben szerepel)
  * A belépő assembly‑t (a .exe‑t) tartalmazó mappa
  * A komponens DLL‑jét meghívó assembly‑ben beágyazott erőforrás (az Aspose.Slides‑ben szerepel).
* Az értékelő verzió korlátainak elkerülése érdekében licencet kell beállítani az Aspose.Slides használata előtt. Az alkalmazáson vagy folyamaton belül csak egyszer kell beállítani a licencet.

{{% alert color="primary" %}} 

Érdemes lehet megnézni a [Mérő licencelést](https://docs.aspose.com/slides/hu/net/metered-licensing/).

{{% /alert %}} 


## **Licenc alkalmazása**
A licenc betölthető **fájlból**, **adatfolyamból** vagy **beágyazott erőforrásból**. 

{{% alert color="primary" %}}

Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/net/aspose.slides/license) osztályt biztosítja a licencelési műveletekhez.

{{% /alert %}} 

{{% alert color="warning" %}} 

Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatják az Aspose.Slides‑t. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.

{{% /alert %}}

### **Fájl**
A licenc beállításának legegyszerűbb módja, ha a licencfájlt a komponens DLL‑jét (az Aspose.Slides‑ben) tartalmazó mappában helyezi el, és csak a fájlnevet adja meg útvonal nélkül.

Ez a C# kód megmutatja, hogyan kell beállítani egy licencfájlt:

``` csharp
// Létrehozza a License osztályt 
Aspose.Slides.License license = new Aspose.Slides.License();

// Beállítja a licencfájl elérési útját
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódus hívásakor a megadott kifejezett útvonal végén megadott licencfájl névnek meg kell egyeznie a licencfájl nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.lic.xml*-re. Ezután a kódban át kell adnia a fájl elérési útját (a *Aspose.Slides.lic.xml*-re végződve) a [SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/#setlicense_1) metódusnak.

{{% /alert %}}

### **Adatfolyam**
Licencet betölthet adatfolyamból. Ez a C# kód megmutatja, hogyan kell licencet alkalmazni adatfolyamból:

``` csharp
// Példányosítja a License osztályt 
Aspose.Slides.License license = new Aspose.Slides.License();

// Beállítja a licencet adatfolyam segítségével
license.SetLicense(myStream);
```

### **Beágyazott erőforrás**
A licencet beágyazott erőforrásként csomagolhatja az alkalmazásával (hogy ne vesszen el), ha a licencet egy, a komponens DLL‑t meghívó assembly‑be beágyazott erőforrásként adja hozzá (az Aspose.Slides‑ben).

Így adhatja hozzá a licencfájlt beágyazott erőforrásként:

1. A Visual Studio‑ban adja a licenc (.lic) fájlt a projekthez a következő módon: menjen a **File** > **Add Existing Item** > **Add** menüpontra. 
2. Válassza ki a fájlt a **Solution Explorer**‑ben.
3. A **Properties** ablakban állítsa a **Build Action** értékét **Embedded Resource**‑re.
4. Az assembly‑ben beágyazott licenc eléréséhez adja a licencfájlt beágyazott erőforrásként a projekthez, majd adja át a licencfájl nevét a `SetLicense` metódusnak. 


A `License` osztály automatikusan megtalálja a licencfájlt a beágyazott erőforrásokban. Nem szükséges meghívni a `System.Reflection.Assembly` osztály `GetExecutingAssembly` és `GetManifestResourceStream` metódusait a Microsoft .NET Framework‑ben.

``` csharp
// Példányosítja a License osztályt
Aspose.Slides.License license = new Aspose.Slides.License();

// Átadja az assembly-ben beágyazott licencfájl nevét
license.SetLicense("Aspose.Slides.lic");
```

## **Licenc ellenőrzése**
Annak ellenőrzésére, hogy a licenc megfelelően lett‑e beállítva, ellenőrizheti azt. Ez a C# kód megmutatja, hogyan lehet ellenőrizni egy licencet:

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

A [license.SetLicense](https://reference.aspose.com/slides/hu/net/aspose.slides/license/setlicense/) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell meghívni, érdemes szinkronizációs primitíveket (például lock‑ot) használni a problémák elkerülése érdekében. 

{{% /alert %}}

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?**

Igen. A licenc ellenőrzése helyben, a licencfájl segítségével történik; internetkapcsolat nem szükséges.

**Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?**

Nem. A licenc örökös: a feliratkozási dátum előtt kiadott verziókat továbbra is használhatja; csak a megújítás nélkül nem lesz jogosult az újabb kiadásokra.