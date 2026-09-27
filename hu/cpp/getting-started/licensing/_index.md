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
- licenc érvényesítése
- licenc fájl
- értékelő verzió
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for C++-ban. Biztosítsa a teljes funkcionalitás megszakítás nélküli elérését lépésről lépésre útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides használható értékelő módban vagy érvényes licencsel. Az értékelő verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de minden mentett prezentáció minden diájára értékelő vízjelet helyez, és csonkolja a kódból beolvasott szöveget a prezentációkból.

Ez a cikk ismerteti, hogyan működik a licencelés az Aspose.Slides-ban, és hogyan alkalmazhatunk licencet a könyvtár használata előtt. Licencet egy **fájlból** vagy egy **áramról** tölthetünk be a `License` osztály használatával. A cikk azt is bemutatja, hogyan ellenőrizhetjük, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="info" title="Note" %}}
Letöltheti a **Aspose.Slides for C++** értékelő verzióját a [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.Cpp/) vagy ZIP csomagként a [download page](https://releases.aspose.com/slides/cpp/) oldalról. Az értékelő verzió ugyanazt a funkcionalitást kínálja, mint a licencelt termék. Valójában az értékelő csomag azonos a megvásárolt verzióval – egyszerűen licencelté válik, ha néhány kódsort hozzáad a licenc alkalmazásához.

Miután elégedett az **Aspose.Slides** értékelésével, [purchase a license](https://purchase.aspose.com/pricing/slides/cpp/). Ajánljuk, hogy tekintse át a rendelkezésre álló előfizetéstípusokat. Ha kérdése van, forduljon nyugodtan az Aspose értékesítési csapatához.

Minden Aspose licenc egyéves előfizetést tartalmaz ingyenes frissítésekhez, beleértve az adott időszakban kiadott új verziókat és hibajavításokat. Legyen szó licencelt vagy értékelő verzióról, ingyenes és korlátlan technikai támogatást kap.
{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Az értékelő verzió (licenc megadása nélkül) a termék teljes funkcionalitását nyújtja, de minden mentett prezentáció minden diájára egy értékelő vízjel szövegdobozát helyezi.
* A prezentációból beolvasott szöveg az első néhány karakterre csonkolódik, majd egy értesítés követi az értékelési korlátról. Az írt szöveg teljes egészében mentésre kerül.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet egy **30 napos ideiglenes licencet**. További információkért lásd a [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licencelés az Aspose.Slides-ban**

* Az értékelő verzió licencelté válik, miután megvásárolta a licencet, és néhány kódsor hozzáadásával alkalmazza.
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát és egyebeket.
* A licencfájl digitálisan alá van írva, ezért nem módosítható. Még egy véletlen változtatás – például egy sortörés hozzáadása – érvényteleníti a fájlt.
* Ha fájlnevet ad meg mappának megadása nélkül, az Aspose.Slides for C++ csak az aktuális munkakönyvtárban keresi a licencfájlt. Nem keres a futtatható állomány vagy az Aspose.Slides könyvtár mappájában, ezért adja meg a teljes elérési utat, ha a licencfájl máshol van.
* Az értékelő verzió korlátozásainak elkerülése érdekében a licencet a Aspose.Slides használata előtt kell beállítani. A licencet egy alkalmazásra vagy folyamatra egyszer kell beállítani.

## **Licenc alkalmazása**

A licenc **fájlból** vagy **áramról** tölthető be.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) osztályt biztosítja a licencelési műveletekhez.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatók. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**

A legegyszerűbb módja a licenc beállításának, ha a licencfájlt a program munkakönyvtárába helyezi, és csak a fájlnevet adja meg, az elérési út nélkül. Ellenkező esetben adja meg a teljes elérési utat a fájlhoz.

A következő C++ kód alkalmazza a *Aspose.Slides.lic* licencfájlt a program munkakönyvtárából:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Ha a licenc érvényes, a [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) visszatér, és a program kimenet nélkül befejeződik; ezután az Aspose.Slides a értékelő korlátozások nélkül működik. Ha a fájl nincs a munkakönyvtárban, a metódus egy [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) kivételt dob a *License "Aspose.Slides.lic" doesn't exist or access is restricted* üzenettel. A példa nem kezeli a kivételt, ezért a program leáll.

{{% alert color="warning" title="Warning" %}}
Ha a licencfájlt másik könyvtárba helyezi, akkor a [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) metódusának meghívásakor a megadott kifejezett út végén lévő fájlnévnek pontosan meg kell egyeznie a licencfájl nevével.

Például, ha a licencfájlt *Aspose.Slides.lic.xml*-re nevezte át, a teljes útnak *Aspose.Slides.lic.xml*-re kell végződnie a [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) metódus meghívásakor a kódban.
{{% /alert %}}

### **Áram**

Töltsön be egy licencet egy áramról, ha a program nem tárolja a licencet fájlként, például adatbázisból olvasva. A [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) bármely [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) objektumot elfogad, amely a licencet tartalmazza. A példát röviden tartva, a következő C++ kód megnyitja a *Aspose.Slides.lic*-et a munkakönyvtárban a [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) segítségével, és az áramról alkalmazza a licencet:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Érvényes licenc ugyanazt az eredményt adja, mint a fájl példa. Ha a fájl nem létezik, a [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) egy [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) kivételt dob, mielőtt a licenc alkalmazásra kerülne, és a program leáll.

## **Licenc ellenőrzése**

Annak ellenőrzéséhez, hogy a licenc megfelelően be van-e állítva, hívja a [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/) metódust. `true` értéket ad csak akkor, ha egy érvényes licenc lett alkalmazva, egyébként `false`. A következő C++ kód a licencfájlt a munkakönyvtárból alkalmazza, majd ellenőrzi:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Érvényes licenc esetén a program kiírja *License is good!* üzenetet. Ha a fájl hiányzik vagy nem licencfájl, a [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) kivételt dob a ellenőrzés előtt, és a program leáll anélkül, hogy bármit nyomtatna. Ha a fájl olyan licenc, amelynek aláírása nem egyezik (például szerkesztés miatt), a SetLicense hibamentesen visszatér, de az `IsLicensed` `false` értéket ad, így semmi sem jelenik meg, és az Aspose.Slides értékelő módban marad.

## **Szálbiztonság**

{{% alert color="warning" title="Warning" %}}
A [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) metódus **nem szálbiztos**. Ha több szálból kell egyszerre meghívni ezt a metódust, ajánlott szinkronizációs primitíveket (például zárat) használni a lehetséges problémák elkerülése érdekében.
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?

Igen. A licenc érvényesítése helyileg történik a licencfájl használatával; internetkapcsolat nem szükséges.

### Mi történik, ha az egy éves előfizetés lejár? Leáll a könyvtár?

Nem. A licenc örökös: a feliratkozási dátum előtti kiadott verziókat továbbra is használhatja; csak az újabb kiadások használatához megújítás szükséges.