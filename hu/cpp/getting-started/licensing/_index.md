---
title: Licencelés
type: docs
weight: 120
url: /hu/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Licenc alkalmazása, kezelése és hibaelhárítása az Aspose.Slides for C++-ban. Biztosítsa a teljes funkciók megszakítás nélküli elérését lépésről lépésre útmutatónkkal."
---
## **Áttekintés**

Aspose.Slides használható értékelő módban vagy érvényes licencszel. Az értékelő verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt változat, de értékelő vizesjelet helyez a prezentációk megnyitásakor vagy mentésekor, és a szövegkivonatolást egy diára korlátozza.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan alkalmazzunk licencet a könyvtár használata előtt. A licenc betölthető fájlból, streamből vagy beágyazott erőforrásból a `License` osztály segítségével. A cikk bemutatja továbbá, hogyan ellenőrizhetjük, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="primary" %}} 
Letöltheti a **Aspose.Slides for C++** értékelő verzióját [a NuGet letöltési oldaláról](https://www.nuget.org/packages/Aspose.Slides.CPP/). Az értékelő verzió ugyanazt a funkcionalitást kínálja, mint a licencelt termék. Valójában az értékelő csomag azonos a megvásárolttal – csak néhány kódsor hozzáadásával válik licencelté.

Miután elégedett a **Aspose.Slides** értékelésével, [licencet vásárolhat](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a rendelkezésre álló előfizetési típusokat. Ha kérdése van, nyugodtan lépjen kapcsolatba az Aspose értékesítési csapatával.

Minden Aspose licenc egyéves előfizetést tartalmaz ingyenes frissítésekkel, beleértve az ebben az időszakban kiadott új verziókat és hibajavításokat. Akár licencelt, akár értékelő verziót használ, ingyenes és korlátlan technikai támogatást kap.
{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Míg az Aspose.Slides értékelő verziója (licenc hiányában) a termék teljes funkcionalitását biztosítja, megnyitás és mentés közben a dokumentum tetejére értékelő vizesjelet helyez.
* Szövegkivonatolás egy diára korlátozódik az értékelő verzió használata esetén.

{{% alert color="primary" %}} 
Az Aspose.Slides korlátok nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért lásd a [Temporary License beszerzése](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelő verzió licencelté válik, miután licencet vásárol és néhány kódsorral alkalmazza.
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza például a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát és egyebeket.
* A licencfájl digitálisan aláírt, ezért nem módosítható. Még egy véletlen változtatás – például egy sortörés hozzáadása – érvényteleníti a fájlt.
* Az Aspose.Slides for C++ általában a licencfájlt a következő helyeken keresi:
  * A kódban explicit módon megadott útvonal
  * A komponens DLL-t (az Aspose.Slides-ben) tartalmazó mappa
  * Az a mappa, amely a komponens DLL-t meghívó assembly-t tartalmazza
* Az értékelő verzió korlátozásainak elkerülése érdekében be kell állítania a licencet az Aspose.Slides használata előtt. A licencet csak egyszer kell beállítani alkalmazáson vagy folyamatonként.

## **Licenc alkalmazása**

A licenc betölthető **fájlból**, **streamből** vagy **beágyazott erőforrásból**.

{{% alert color="primary" %}}
Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.license/) osztályt biztosítja a licencelési műveletekhez.
{{% /alert %}} 

{{% alert color="warning" %}}
Az új licenc csak a 21.4 vagy újabb verzióval aktiválható az Aspose.Slides-ben. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt a komponens DLL-jével (az Aspose.Slides-ben) azonos mappába helyezzük, és csak a fájlnevet adjuk meg, az útvonal nélkül.

A következő C++ kód bemutatja, hogyan kell beállítani egy licencfájlt:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 
Ha a licencfájlt más könyvtárba helyezi, akkor a [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódus hívásakor a megadott explicit útvonal végén szereplő fájlnévnek pontosan meg kell egyeznie a licencfájl nevével.

Például, ha a licencfájlt *Aspose.Slides.lic.xml*-re nevezik át, a kódban a [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódusnak a teljes, *Aspose.Slides.lic.xml*-re végződő elérési utat kell átadni.
{{% /alert %}}

### **Adatfolyam**

A licencet betöltheti egy adatfolyamból. A következő C++ kód bemutatja, hogyan kell licencet alkalmazni adatfolyamból:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Licenc ellenőrzése**

Annak ellenőrzésére, hogy a licenc megfelelően lett-e beállítva, validálhatja azt. A következő C++ kód bemutatja, hogyan kell licencet ellenőrizni:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Szálbiztonság**

{{% alert title="Note" color="warning" %}} 
A [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódus **nem szálbiztos**. Ha ezt a metódust egyszerre több szálból akarja hívni, ajánlott szinkronizációs primitíveket (például lock-ot) használni a lehetséges problémák elkerülése érdekében.
{{% /alert %}}

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?**

Igen. A licenc ellenőrzése helyben történik a licencfájl használatával; internetkapcsolat nem szükséges.

**Mi történik, amikor az egyéves előfizetés lejár? Leáll a könyvtár működése?**

Nem. A licenc örökös: továbbra is használhatja az előfizetés vége előtti kiadott verziókat; csak az újabb kiadásokat nem vehetik igénybe megújítás nélkül.