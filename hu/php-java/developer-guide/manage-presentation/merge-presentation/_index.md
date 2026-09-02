---
title: Hatékony prezentációk egyesítése PHP-ben
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/php-java/merge-presentation/
keywords:
- PowerPoint egyesítése
- prezentációk egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint kombinálása
- prezentációk kombinálása
- diák kombinálása
- PPT kombinálása
- PPTX kombinálása
- ODP kombinálása
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan egyesíthet PowerPoint és OpenDocument prezentációkat PHP-ben diák klónozásával, a mesterek és elrendezések szabályozásával, a dia tartalom átméretezésével, szekciók megőrzésével, valamint védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java prezentációkat egyesíti úgy, hogy diák másolásával egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) bemásolja egy másikba. A fő művelet a [SlideCollection::addClone()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/), amely megőrizheti a forrás dia formázását vagy a klónozott diát egy mesterhez vagy elrendezéshez csatlakoztathatja a cél prezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat mutatja be:

- összes dia egyesítése a forrás formázásának megőrzésével;
- kiválasztott diák egyesítése;
- cél prezentáció egy mesterének alkalmazása;
- cél prezentáció egy adott elrendezésének alkalmazása;
- különböző dia méretek normalizálása a egyesítés előtt;
- klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy végponttól‑végpontig tartó munkafolyamatban;
- mester, erőforrás, jegyzet, megjegyzés, média, betűkészlet, jelszó, nagy fájlok és többszálas kérdések kezelése.

## **Hogyan befolyásolja a dia klónozása a mestereket és elrendezéseket**

Egy dia megjelenésének nagy részét az elrendezés és a mester adja. Emiatt a választott klónozási túlterhelés határozza meg, hogy a egyesített dia hogyan integrálódik a cél prezentációba.

Használja a [SlideCollection::addClone()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) egyik következő módon:

- `addClone(sourceSlide)` — megőrzi a forrás dia elrendezését és formázását. Szükség esetén a forrás mester automatikusan klónozható a cél prezentációba. Az Aspose.Slides nyomon követi az automatikusan klónozott mestereket, így az ugyanazt a forrás mestert használó ismétlődő diák nem klónozzák újra a mestert.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy konkrét cél [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) alá csatolja. Az Aspose.Slides a megadott mester alatt a layout típus vagy név alapján keres megfelelő elrendezést.
- `addClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy konkrét cél [LayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) alá csatolja.

A `addClone` túlterheléshez átadott mesternek vagy elrendezésnek a **cél** prezentációhoz kell tartoznia, nem a forrás prezentációhoz.

## **Az egész prezentációk egyesítése és a forrás formázásának megőrzése**

A legegyszerűbb egyesítés minden diát átmásol a forrás prezentációból a célba. Ez akkor megfelelő, ha az importált diáknak meg kell tartaniuk eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Az eredményül kapott prezentáció több mestert is tartalmazhat, ha a forrás és a cél különböző tervezéseket használ. Ez várható, amikor a forrás formázás szándékosan megőrződik.

## **Kiválasztott diák egyesítése**

Nem kell minden diát klónozni. Az alábbi példa csak a forrás prezentáció kiválasztott diaindexeit importálja.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Érvényesítse a dia indexeket a klónozás előtt, ha azok felhasználói bemenetről vagy külső konfigurációból származnak.

## **Diák egyesítése cél mester használatával**

Használja a [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) túlterhelést, ha az importált diáknak egy már a cél prezentációban létező mesterhez kellene tartozniuk.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Az Aspose.Slides a megadott mester alatt a forrás elrendezés típusa vagy neve alapján választ megfelelő elrendezést. Ha nincs megfelelő elrendezés, és az `allowCloneMissingLayout` **true**, a forrás elrendezés klónozódik, így a dia hozzáadható. Ha **false**, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) kerül dobásra.

Használja a **false** értéket, ha azt szeretné, hogy az egyesítés hibával végződjön ahelyett, hogy további elrendezést hozna létre a cél mesterben.

## **Diák egyesítése konkrét cél elrendezés használatával**

Használja a [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) túlterhelést, ha pontosan tudja, melyik cél elrendezést kell az importált diáknak használniuk.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

A cél elrendezés alkalmazása megváltoztatja az örökölt elrendezéskapcsolatot; nem tervez újra a forrás dia tartalmát. Ha a forrás és a cél elrendezések eltérő helykitöltő struktúrával rendelkeznek, ellenőrizze az eredményt, hogy a örökölt formázás és helykitöltő viselkedés megfelelő legyen.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik dia méretű prezentációba nem tervez újra automatikusan a tartalmat az új vászonra. Így a formák eltolódhatnak, váratlanul átméreteződhetnek, vagy a látható dia területen kívülre kerülhetnek.

Gyakorlati megközelítés a forrás prezentáció átméretezése a klónozás előtt. A [SlideSize::setSize()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/setsize/) metódus méretezheti a meglévő tartalmat a dia méretének módosítása közben. A [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Az átméretezés a forrás prezentáció objektumot a memóriában módosítja. Ha az eredeti forrás prezentációt más műveletekhez változatlanul szeretné megtartani, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése prezentáció szekcióba**

Az alap dia‑klónozó ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a kimenetben fontosak a szekciók, hozzon létre vagy válasszon ki szekciókat a cél prezentációban, és klónozza a diákat kifejezetten a [addClone(Slide, Section)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódussal.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

A klónozott diák a megadott cél szekcióhoz lesznek hozzáfűzve. Több forrás szekció megőrzéséhez írja be a [Presentation::getSections](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getSections) listáját, szerezze be minden forrás szekció aktuális diáit a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Section/#getSlidesListOfSection) segítségével, hozza létre a szekciókat a célban, és klónozza az egyes visszaadott diát a megfelelő cél szekcióba. Lásd a [Manage Slide Sections](/slides/hu/php-java/slide-section/) cikket a teljes szekció‑enumerációs példáért, beleértve az üres szekciókat és a strukturális változásokat.

## **Több prezentáció biztonságos egyesítése**

Az alábbi vég‑vég példában az első prezentáció lesz a cél, a további források dia méretét normalizálja, minden forrást csak a másolás ideje alatt nyit nyitva, és a végső fájlt egyszer menti.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Ez egy hasznos kiindulópont a forrás formázás megőrzéséhez az importált diák esetén. Ha a kimenetnek egyetlen cél témát kell használnia, cserélje le az egyszerű `addClone($slide)` hívást a korábban bemutatott megfelelő cél‑mester vagy cél‑elrendezés túlterhelésre.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és a formázás pontossága**

Az alapdia‑klónozás automatikusan behozhat egy szükséges forrás mestert a cél prezentációba. Az Aspose.Slides egy belső nyilvántartást vezet az automatikusan klónozott mesterekhez, hogy elkerülje ugyanannak a mesternek a többszöri klónozását. A kézzel klónozott mestereket ez a nyilvántartás nem követi, ezért kerüljük a mesterek előzetes klónozását, hacsak nem szükséges a mesterstruktúra explicit vezérlése.

Ne feltételezzük, hogy két azonos nevű mester vagy elrendezés vizuálisan egyenértékű. Ha egy vállalati sablonnak kell irányítania a végső megjelenést, válasszon explicit módon egy cél mestert vagy elrendezést, és ellenőrizze az egyesítés eredményét.

### **Jegyzetek és megjegyzések**

Az előadói jegyzetek és a dia megjegyzések a dia tartalmához kapcsolódnak, és másolódnak a dia klónozásakor. Az Aspose.Slides külön API‑kat is biztosít a [presentation notes](/slides/hu/php-java/presentation-notes/) és a [presentation comments](/slides/hu/php-java/presentation-comments/) kezelésére.

Ha a jegyzetoldal formázása fontos, ellenőrizze az egyesített prezentációt, mert a notes‑master prezentáció‑szintű objektum, és a forrásfájlok között eltérhet. Felülvizsgálati munkafolyamatoknál ellenőrizze a megjegyzés szerzőit és a szálas megjegyzéseket is, ha különböző szerzők vagy sablonok fájljait kombinálja.

### **Képek, hang, videó, OLE objektumok és külső hivatkozások**

A diák hivatkozhat prezentáció‑szintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozza a diát magát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat másképp kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is a külső célra függ; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommá. Tesztelje a hivatkozott erőforrás útvonalait és URL‑jeit abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides kifejezetten nyomon követi az automatikusan klónozott mestereket, de ez nem jelent általános garanciát arra, hogy a független forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, ellenőrizze az egyesített csomagot és mérje az eredményt, ahelyett, hogy feltételezné a rejtett deduplikálást.

### **Beágyazott betűkészletek és a betűkészlet elérhetősége**

A betűkészletek a prezentáció‑szinten kezelődnek. Ha a tipográfiának gépek között konzisztensnek kell maradnia, ne feltételezze, hogy a dia‑klónozás önmagában garantálja, hogy minden szükséges betűkészlet elérhető a cél környezetben. A beágyazott betűkészleteket a [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getembeddedfonts/) segítségével ellenőrizheti, és a [Embed Fonts in Presentations](/slides/hu/php-java/embedded-font/) leírás szerint kezelheti a beágyazást explicit módon.

Ellenőrizze továbbá, hogy jogosult‑e a forrásfájlokban használt betűkészletek beágyazására. A betűkészlet‑licencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

Egy jelszóval védett forrást sikeresen meg kell nyitni, mielőtt a diái klónozhatók lennének. Adja meg a jelszót a [LoadOptions::setPassword()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/setpassword/) segítségével.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Dolgozz a visszafejtett prezentációval.
} finally {
    $source->dispose();
}
```

A titkosított forrás megnyitása nem alkalmazza automatikusan ugyanazt a védelmet a cél prezentációra. A kimeneti védelem beállítását külön kell elvégezni, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

Nagy felbontású képeket, hangot, videót vagy egyéb nagy bináris objektumokat tartalmazó prezentációk jelentős memóriát fogyaszthatnak. A [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) BLOB‑kezelési és ideiglenes fájl‑használati beállításokat biztosít. Lásd a [Open Presentations](/slides/hu/php-java/open-presentation/#open-large-presentations) cikket egy PHP via Java nagy‑fájl példáért.

Nagy fájlok esetén előnyben részesítse a fájl‑útvonalból való betöltést, amennyiben lehetséges, a forrás prezentációkat a beolvasás után azonnal szabadítsa fel, és kerülje a köztes eredmények ismételt mentését, hacsak a munkafolyamat nem igényel ellenőrzőpontokat.

### **Szálbiztonság**

Ne töltsön be, módosítson, mentse vagy klónozzon [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányokat több szálon. Ezek a műveletek nem támogatottak többszálas használat esetén PHP via Java környezetben. Ha párhuzamos egyesítési feladatokra van szükség, futtassa őket külön szál‑független folyamatokban, minden folyamat saját prezentáció‑példányokkal, és kövesse az [Aspose.Slides multithreading guidance](/slides/hu/php-java/multithreading/) útmutatót.

## **GYIK**

**Hogyan tudom megtartani minden forrás prezentáció eredeti dizájnját?**  
Használja a [SlideCollection::addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) metódust, anélkül, hogy cél mestert vagy elrendezést adna meg. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha az importált diának szüksége van rá.

**Hogyan használhatom a cél témát az importált diákra?**  
Használja azt a túlterhelést, amely cél mestert fogad paraméterként. Adjon meg egy mestert a cél prezentációból, ne a forrásból. Az Aspose.Slides megpróbálja a forrás diát egy megfelelő elrendezéshez rendelni a megadott mester alatt.

**Mikor kell konkrét cél elrendezést használni a cél mester helyett?**  
Használjon konkrét elrendezést, ha minden importált diának egy ismert elrendezést kell használnia. Használjon mestert, ha azt szeretné, hogy az Aspose.Slides a forrás elrendezés típus vagy neve alapján válasszon a mester elrendezései közül.

**Egyesíthetők a különböző dia méretű prezentációk?**  
Igen, de a dia tartalma nem kerül automatikusan újratervezésre a cél méretekhez. A forrás prezentációt előbb méretezze át, ha kiszámítható elhelyezésre van szükség, például a [SlideSize::setSize()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesize/setsize/) és a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesizescaletype/) segítségével.

**Egyesíthetek PPT, PPTX és ODP prezentációkat egy fájlba?**  
Igen. Töltse be minden forrás prezentációt, klónozza a szükséges diákat egy célba, és mentse a célt egy támogatott kimeneti formátumban. Mivel a prezentáció‑formátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a komplex tartalmat a formátumok közti egyesítés után. Lásd a [Supported File Formats](/slides/hu/php-java/supported-file-formats/) cikket.

**Automatikusan megmaradnak a forrás szekciók?**  
Nem egy egyszerű ciklus, amely csak diákat klónoz, automatikusan. Hozza létre a szükséges szekciókat a célban, és használja a [addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/addclone/) szekció‑túlterhelését, ha a szekció‑struktúrát meg kell őrizni.

**Megmaradnak a felhasználói jegyzetek és megjegyzések?**  
A klónozott diákkal együtt másolódnak. Olyan munkafolyamatoknál, amelyek a notes‑master stílusra, a megjegyzés‑szerzőkre vagy a szálas felülvizsgálati adatokra támaszkodnak, ellenőrizze az egyesített eredményt, mert ezek a forgatókönyvek prezentáció‑szintű struktúrákat és dia‑szintű tartalmat is érintenek.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**  
A beágyazott tartalom a klónozott dia erőforrás‑kapcsolatainak részeként kerül továbbításra. A külső hivatkozások külső maradnak, így a célfájloknak vagy URL‑eknek továbbra is elérhetőnek kell lenniük az egyesítés után.

**Garantált, hogy minden forrás beágyazott betűkészlete elérhető legyen az egyesített prezentációban?**  
Ne támaszkodjon kizárólag a dia‑klónozásra a betűkészletek telepítéséhez. Ellenőrizze a cél beágyazott betűkészleteit, és kezelje a betűkészlet‑beágyazást vagy a külső betűkészlet‑elérhetőséget explicit módon, ha a tipográfia fontos.

**Hogyan egyesítek jelszóval védett fájlt?**  
Nyissa meg a megfelelő [LoadOptions::setPassword()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/setpassword/) segítségével, majd a diákat normálisan klónozza. A kimeneti védelem külön konfigurálható.

**Hogyan kezeljem a nagyon nagy prezentációkat?**  
Használjon BLOB‑kezelést, ha nagy bináris objektumok dominálják a memóriahasználatot, előnyben részesítse a fájl‑útvonal‑betöltést nagyon nagy fájlok esetén, szabadítsa fel a forrás‑prezentációkat a lehető leghamarabb, és csak szükség esetén mentse el a végleges eredményt.

**Egyesíthetek diákot több szálból?**  
A prezentációk betöltése, mentése vagy klónozása több szálon nem támogatott PHP via Java környezetben. Párhuzamos munkához használjon külön szál‑független folyamatokat, és minden folyamatban tartsa elkülönítve a prezentáció‑példányokat.