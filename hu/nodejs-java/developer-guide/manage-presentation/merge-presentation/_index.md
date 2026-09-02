---
title: Hatékony prezentációk egyesítése JavaScriptben
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan egyesítheti a PowerPoint és OpenDocument prezentációkat JavaScriptben dia klónozással, a mesterek és elrendezések szabályozásával, diatartalom átméretezésével, szekciók megőrzésével, valamint a védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java prezentációkat egyesít úgy, hogy diák másolásával (cloning) helyezi át egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) másikba. A fő művelet a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) metódus, amely megőrizheti a forrás dia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a célprezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat taglalja:

- az összes dia egyesítése a forrás formázásának megtartásával;
- kiválasztott diák egyesítése;
- egy mester alkalmazása a célprezentációból;
- egy konkrét elrendezés alkalmazása a célprezentációból;
- a különböző dia méretek normalizálása egyesítés előtt;
- klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy végponttól végpontig terjedő munkafolyamatban;
- mesterek, erőforrások, jegyzetek, megjegyzések, média, betűtípusok, jelszavak, nagy fájlok és több szálas kérdések kezelése.

## **Hogyan befolyásolja a dia klónozása a mestereket és az elrendezéseket**

Egy dia megjelenésének nagy részét az elrendezése és a mestere adja. Emiatt a választott klónozási túlterhelés (overload) határozza meg, hogyan integrálódik az egyesített dia a célprezentációba.

Használja a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) egyik változatát a következő módokon:

- `addClone(sourceSlide)` — a forrás dia elrendezését és formázását megőrzi. Szükség esetén a forrás mester automatikusan klónozható a célprezentációba. Az Aspose.Slides automatikusan klónozott mestereket nyilvántart, így ugyanazt a forrás mestert használó ismételt diák nem okozzák a mester többszöri klónozását.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy konkrét cél [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/)-hez csatolja. Az Aspose.Slides a megadott mester alatt a layout típus vagy név alapján keres megfelelő elrendezést.
- `addClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy konkrét cél [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/)-hez csatolja.

Az `addClone` túlterheléshez megadott mester vagy elrendezés a **cél** prezentációhoz kell, hogy tartozzon, ne a forrás prezentációhoz.

## **Teljes prezentációk egyesítése és a forrás formázásának megtartása**

A legegyszerűbb egyesítés minden dia másolását jelenti a forrás prezentációból a célprezentációba. Ez a megfelelő választás, ha az importált diáknak meg kell őrizniük eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A keletkezett prezentáció több mestert tartalmazhat, ha a forrás és a cél különböző terveket használ. Ez várható, amikor szándékosan megőrzik a forrás formázását.

## **Kiválasztott diák egyesítése**

Nem szükséges minden diát klónozni. Az alábbi példa csak a kiválasztott diaindexek importálását mutatja a forrás prezentációból.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Érvényesítse a diaindexeket a klónozás előtt, ha azok felhasználói bemenetből vagy külső konfigurációból származnak.

## **Dia egyesítése a célmesterrel**

Használja a [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) túlterhelést, ha az importált diáknak egy már a célprezentációba tartozó mesterhez kell igazodniuk.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Az Aspose.Slides a megadott mester alatt egy megfelelő elrendezést választ ki a forrás elrendezés típusának vagy nevének egyezésével. Ha nincs megfelelő elrendezés, és az `allowCloneMissingLayout` `true`, akkor a forrás elrendezés klónozódik, így a dia hozzáadható. Ha `false`, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kerül dobásra.

Használja a `false` értéket, ha azt szeretné, hogy az egyesítés hibára fusson ahelyett, hogy egy további elrendezést adna a célmesterhez.

## **Dia egyesítése egy konkrét célelrendezéssel**

Használja a [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) túlterhelést, ha pontosan tudja, melyik célelrendezést kell az importált diáknak használniuk.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A célelrendezés alkalmazása megváltoztatja a örökölt elrendezéskapcsolatot; nem tervezi át a forrás dia tartalmát. Ha a forrás és a cél elrendezések különböző helyőrzőstruktúrával rendelkeznek, ellenőrizze az eredményt, hogy az örökölt formázás és a helyőrző viselkedés megfelelő legyen.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik dia mérettel rendelkező prezentációba nem alakítja át automatikusan a tartalmat az új vászonra. Ennek következtében a alakzatok eltolódhatnak, váratlanul skálázódhatnak, vagy a látható dia területén kívül jelenhetnek meg.

Gyakorlati megközelítés a forrás prezentáció átméretezése a klónozás előtt. A [SlideSize.setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) metódus méretezheti a meglévő tartalmat, miközben megváltoztatja a dia méreteit. A [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Az átméretezés a forrás prezentáció objektumot módosítja a memóriában. Ha az eredeti forrást változatlanul szeretné megtartani további műveletekhez, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése egy prezentációszekcióba**

Az alapvető dia-klónozási ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozza létre vagy válassza ki a szekciókat a célprezentációban, és klónozza a diákot kifejezetten a [addClone(Slide, Section)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) metódussal.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A klónozott diák a megadott cél szekcióhoz lesz hozzáfűzve. Több forrás szekció megtartásához hozza létre ezeket a szekciókat a célban, és map-olja az egyes forrás diát a megfelelő cél szekcióhoz.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól végpontig terjedő példa az első prezentációt használja célként, normalizálja az egyes további források dia méretét, csak a másolás ideje alatt tartja nyitva a forrásokat, és egyszer menti a végleges fájlt.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Ez egy hasznos alapvonal a forrás formázás megtartásához az importált diák esetén. Ha a kimenetnek egyetlen cél téma kell, cserélje a egyszerű `addClone(sourceSlide)` hívást a korábban bemutatott megfelelő célmester vagy célelrendezés túlterhelésre.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és a formázás hűsége**

Az alapértelmezett dia klónozás automatikusan behozhat egy szükséges forrás mestert a célprezentációba. Az Aspose.Slides egy belső nyilvántartást vezet az automatikusan klónozott mesterekhez, hogy elkerülje ugyanaznak a mesternek a többszöri klónozását. Kézzel klónozott mestereket ez a nyilvántartás nem követi, ezért kerüljük a mesterek előzetes klónozását, hacsak nem szükséges a mesterstruktúra kifejezett vezérlése.

Ne feltételezze, hogy két azonos nevű mester vagy elrendezés vizuálisan egyenértékű. Ha egy vállalati sablonnak kell irányítania a végső megjelenést, válasszon egy cél mestert vagy elrendezést kifejezetten, és ellenőrizze az egyesítés eredményét.

### **Jegyzetek és megjegyzések**

Az előadói jegyzetek és a dia megjegyzések a dia tartalmához kapcsolódnak, és a dia klónozásakor másolódnak. Az Aspose.Slides dedikált API-kat is kínál a [presentation notes](https://docs.aspose.com/slides/hu/nodejs-java/presentation-notes/) és a [presentation comments](https://docs.aspose.com/slides/hu/nodejs-java/presentation-comments/) kezelésére.

Ha a jegyzetoldal formázása fontos, ellenőrizze az egyesített prezentációt, mivel a jegyzet mesterek prezentációszintű objektumok, és forrásfájlok között eltérhetnek. Felülvizsgálati munkafolyamatoknál ellenőrizze a megjegyzés szerzőket és a szálas megjegyzéseket is, miután különböző szerzők vagy sablonok fájljait egyesítette.

### **Képek, hang, videó, OLE objektumok és külső linkek**

A diák hivatkozhat prezentációszintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozza a diát magát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat külön kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is külső célra támaszkodik; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommal. Tesztelje a hivatkozott erőforrás útvonalait és URL-jeit abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides automatikusan klónozott mestereket nyilvántart, de ez nem jelent általános garanciát arra, hogy a különböző forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, ellenőrizze a csomagot, és mérje az eredményt ahelyett, hogy az implicit deduplikálásra támaszkodna.

### **Beágyazott betűtípusok és a betűtípusok elérhetősége**

A betűtípusok a prezentáció szintjén vannak kezelve. Ha a tipográfia állandó maradása kritikus a gépek között, ne feltételezze, hogy a diák klónozása önmagában garantálja, hogy minden szükséges betűtípus elérhető a célkörnyezetben. Az [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) segítségével ellenőrizheti a beágyazott betűtípusokat, és a [Embed Fonts in Presentations](https://docs.aspose.com/slides/hu/nodejs-java/embedded-font/) útmutató szerint kezelheti a beágyazást.

Ellenőrizze azt is, hogy engedélyezve van‑e a forrásfájlok által használt betűtípusok beágyazása. A betűtípus licencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

A jelszóval védett forrást sikeresen meg kell nyitni, mielőtt a diák klónozhatók. Adja meg a jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) metódussal.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Dolgozz a visszafejtett prezentációval.
} finally {
    source.dispose();
}
```

A titkosított forrás megnyitása nem alkalmazza automatikusan ugyanazt a védelmet a célprezentációra. A kimeneti védelem beállítása külön kell, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

Nagy prezentációk, amelyek nagy felbontású képeket, hangot, videót vagy más nagy bináris objektumokat tartalmaznak, jelentős memóriát fogyaszthatnak. A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) vezérli a BLOB kezelését és az ideiglenes fájlok használatát. Lásd a [Manage Presentation BLOBs](https://docs.aspose.com/slides/hu/nodejs-java/manage-blob/) útmutatót a nagy fájlok stratégiáihoz.

Nagy fájlok esetén részesítse előnyben a fájlútvonalról történő betöltést, amennyiben lehetséges, és a forrás prezentációkat a beolvasás után azonnal szabadítsa fel, valamint kerülje a köztes eredmények ismételt mentését, hacsak a munkafolyamat nem igényli a checkpoint‑okat.

### **Szálbiztonság**

Ne töltsön be, mentse vagy klónozza egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt több szálon. Ezek a műveletek nem támogatottak több szálas használat esetén. Ha párhuzamos, független egyesítési feladatokra van szükség, használjon több egy‑szálas folyamatot, mindegyik saját prezentációs példánnyal, és kövesse az [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/hu/nodejs-java/multithreading/) útmutatót.

## **GYIK**

**Hogyan őrizhetem meg minden forrás prezentáció eredeti tervezését?**

Használja a [`addClone(sourceSlide)`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) metódust, anélkül, hogy cél mestert vagy elrendezést adna meg. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha az szükséges az importált diához.

**Hogyan használjam a cél téma beállításait az importált diákhoz?**

Használja azt a túlterhelést, amelyik egy cél mestert fogad el. Adjunk meg egy mestert a célprezentációból, ne a forrásból. Az Aspose.Slides megpróbálja minden forrás diát a megfelelő elrendezéshez rendelni a megadott mester alatt.

**Mikor válasszak konkrét cél elrendezést a célmester helyett?**

Válasszon konkrét elrendezést, ha minden importált diáknak egy ismert elrendezést kell használnia. Válasszon mestert, ha azt szeretné, hogy az Aspose.Slides a forrás elrendezés típusának vagy nevének megfelelően válasszon a mester elrendezései közül.

**Egyesíthetők-e a különböző dia méretekkel rendelkező prezentációk?**

Igen, de a dia tartalma nem lesz automatikusan újratervezve a cél méretekhez. Módosítsa a forrás prezentációt először, ha a prediktív elhelyezés szükséges, például a [SlideSize.setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) és a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesizescaletype/) segítségével.

**Egyesíthetek PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Töltsön be minden forrás prezentációt, klónozza a szükséges diákot egyetlen célba, és mentse a célt egy támogatott kimeneti formátumban. Mivel a prezentációs formátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a komplex tartalmat a formátumok közötti egyesítések után. Lásd a [Supported File Formats](https://docs.aspose.com/slides/hu/nodejs-java/supported-file-formats/) oldalt.

**Megmaradnak-e automatikusan a forrás szekciók?**

Nem egy egyszerű ciklus, amely csak a diák klónozásával foglalkozik. Hozza létre a szükséges szekciókat a célban, és használja a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) szekció túlterhelését, ha a szekciós struktúrát meg kell őrizni.

**Megmaradnak-e a hangjegyzetek és a megjegyzések?**

Másolásra kerülnek a klónozott diákkal együtt. Olyan munkafolyamatoknál, amelyek a notes‑master stílusra, a megjegyzés szerzőkre vagy a szálas felülvizsgálati adatokra támaszkodnak, ellenőrizze az egyesített eredményt, mivel ezek a helyzetek prezentáció‑szintű struktúrákat is érintenek a dia‑szintű tartalom mellett.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforrás‑kapcsolatai részeként kerül át. A külső hivatkozások továbbra is külsőek maradnak, így azok célfájljainak vagy URL‑jeinek továbbra is elérhetőnek kell lenniük az egyesítés után.

**Garantált, hogy minden forrás beágyazott betűtípusa rendelkezésre áll az egyesített prezentációban?**

Ne támaszkodjon kizárólag a dia klónozására a betűtípus‑telepítéshez. Ellenőrizze a cél beágyazott betűtípusait, és kezelje a betűtípus‑beágyazást vagy a külső betűtípus‑elérhetőséget kifejezetten, ha a tipográfia fontos.

**Hogyan egyesítem a jelszóval védett fájlt?**

Nyissa meg a megfelelő [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) segítségével, majd klónozza a diákat a szokásos módon. A kimeneti védelem külön beállítható.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használja a BLOB‑kezelést, ha nagy bináris objektumok dominálják a memóriahasználatot, részesítse előnyben a fájl‑útvonal‑betöltést nagyon nagy fájlok esetén, gyorsan szabadítsa fel a forrás prezentációkat, és csak akkor mentse a végleges eredményt, ha szükséges.

**Klónozhatom-e a diákot több szálon?**

Ne töltsön be, mentse vagy klónozza a prezentáció példányokat több szálon. Párhuzamos egyesítési feladatokhoz használjon különálló egy‑szálas folyamatokat és független prezentációs példányokat.