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
- értékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Licencek alkalmazása, kezelése és hibák elhárítása az Aspose.Slides for C++‑ban. Biztosítsa a folyamatos hozzáférést a teljes funkciókhoz lépésről‑lépésre útmutatónkkal a licenceléshez."
---
## **Áttekintés**

Az Aspose.Slides használható értékelési módban vagy érvényes licenccel. Az értékelési verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de egy értékelési vízjelet helyez a prezentációk megnyitásakor vagy mentésekor, és a szövegkivonást egy diára korlátozza.

Ez a cikk bemutatja, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan alkalmazhat licencet a könyvtár használata előtt. Licencet betölthet fájlból, adatfolyamból vagy beágyazott erőforrásból a `License` osztály használatával. A cikk azt is megmutatja, hogyan ellenőrizheti, hogy a licenc megfelelően alkalmazásra került-e.

## **Értékelje az Aspose.Slides**

{{% alert color="info" %}} 

Letöltheti az **Aspose.Slides for C++** értékelési verzióját a [nuget letöltési oldaláról](https://www.nuget.org/packages/Aspose.Slides.CPP/). Az értékelési verzió ugyanazt a funkcionalitást kínálja, mint a licencelt termék. Valójában az értékelési csomag azonos a megvásároltal – egyszerűen csak licencelt lesz, ha néhány sor kóddal alkalmazza a licencet.

Ha elégedett az **Aspose.Slides** értékelésével, akkor [licencet vásárolhat](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a rendelkezésre álló előfizetéstípusokat. Ha kérdése van, forduljon az Aspose értékesítési csapatához.

Minden Aspose licenc egyéves előfizetést tartalmaz ingyenes frissítésekhez, beleértve az ebben az időszakban kiadott új verziókat és hibajavításokat. Legyen szó licencelt vagy értékelési verzióról, ingyenes és korlátlan műszaki támogatást kap.

{{% /alert %}} 

**Az értékelési verzió korlátozásai**

* Míg az Aspose.Slides értékelési verziója (amikor nincs licenc alkalmazva) a teljes termékfunkcionalitást biztosítja, egy értékelési vízjelet helyez a dokumentum tetejére a megnyitási és mentési műveletek során.
* A szövegkivonás egy diára korlátozott az értékelési verzió használatakor.

{{% alert color="info" %}} 

A korlátok nélküli teszteléshez kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [Ideiglenes licenc beszerzése](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelési verzió licencelté válik, miután megvásárolta a licencet, és néhány sor kóddal alkalmazza.
* A licenc egy egyszerű szöveges XML fájl, amely olyan adatokat tartalmaz, mint a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma és egyebek.
* A licencfájlt digitálisan aláírják, ezért azt nem szabad módosítani. Még egy véletlen sortörés is érvényteleníti a fájlt.
* Az Aspose.Slides for C++ általában a licencfájlt a következő helyeken keresi:
  * Kódban kifejezetten megadott útvonal
  * A komponens DLL‑jét tartalmazó mappa (az Aspose.Slides-ben)
  * Az a mappa, amely a komponens DLL‑jét meghívó assembly‑t tartalmazza
* Az értékelési verzió korlátozásainak elkerülése érdekében a licencet a Aspose.Slides használata előtt kell beállítani. Egy licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatonként.

## **Licenc alkalmazása**

A licenc betölthető **fájlból**, **adatfolyamból** vagy **beágyazott erőforrásból**.

{{% alert color="info" %}}

Az Aspose.Slides biztosítja a [License](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.license/) osztályt a licencelési műveletekhez.

{{% /alert %}} 

{{% alert color="warning" %}}

Új licencek csak a 21.4 vagy újabb verzióval aktiválhatók az Aspose.Slides-ben. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.

{{% /alert %}}

### **Fájl**

A legegyszerűbb módja a licenc beállításának, ha a licencfájlt a komponens DLL‑jét tartalmazó mappában helyezi el (az Aspose.Slides-ben), és csak a fájlnevet adja meg, útvonal nélkül.

Az alábbi C++ kód bemutatja, hogyan állítsuk be a licencfájlt:

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

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, akkor a [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódus meghívásakor a megadott explicit útvonal utolsó részének pontosan meg kell egyeznie a licencfájl nevével.

Például, ha a licencfájlt *Aspose.Slides.lic.xml* névre változtatja, akkor a [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódusnak a teljes, *Aspose.Slides.lic.xml*-re végződő útvonalat kell átadnia a kódban.

{{% /alert %}}

### **Adatfolyam**

Betölthet licencet egy adatfolyamból. Az alábbi C++ kód bemutatja, hogyan alkalmazzon licencet adatfolyamból:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Licenc ellenőrzése**

Annak ellenőrzéséhez, hogy a licenc helyesen lett-e beállítva, validálhatja azt. Az alábbi C++ kód mutatja, hogyan validálja a licencet:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

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

A [License::SetLicense](https://reference.aspose.com/slides/hu/cpp/aspose.slides/license/setlicense/) metódus **nem szálbiztos**. Ha ezt a metódust egyszerre több szálból kell meghívni, ajánlott szinkronizációs primitíveket (például lockot) használni a lehetséges problémák elkerülése érdekében.

{{% /alert %}}

## **FAQ**

### Alkalmazhatom-e a licencet teljesen offline környezetben (internetkapcsolat nélkül)?

Igen. A licenc ellenőrzése helyben, a licencfájl használatával történik; internetkapcsolatra nincs szükség.

### Mi történik, ha az egyéves előfizetés lejár?

Nem. A licenc örökös: a feliratkozás befejeződése előtt kiadott verziókat továbbra is használhatja; csak az újabb kiadásokhoz újra kell vásárolnia a licencet.