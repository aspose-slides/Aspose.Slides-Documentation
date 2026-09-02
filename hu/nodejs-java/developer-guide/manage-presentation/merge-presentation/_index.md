---
title: "Hatékony prezentációk egyesítése JavaScript-ben"
linktitle: "Prezentációk egyesítése"
type: docs
weight: 40
url: /hu/nodejs-java/merge-presentation/
keywords:
- "PowerPoint egyesítése"
- "prezentációk egyesítése"
- "diák egyesítése"
- "PPT egyesítése"
- "PPTX egyesítése"
- "ODP egyesítése"
- "PowerPoint kombinálása"
- "prezentációk kombinálása"
- "diák kombinálása"
- "PPT kombinálása"
- "PPTX kombinálása"
- "ODP kombinálása"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Ismerje meg, hogyan egyesítheti a PowerPoint és OpenDocument prezentációkat JavaScript-ben dia klónozással, mesterek és elrendezések szabályozásával, diatartalom átméretezésével, szekciók megőrzésével, valamint védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java prezentációkat egyesíti, úgy, hogy diákat klónoz egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) egy másikba. A fő művelet a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) , amely megőrizheti a forrás dia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a cél prezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat mutatja be:

- az összes dia egyesítése a forrás formázásának megőrzése mellett;
- kiválasztott diák egyesítése;
- egy mester alkalmazása a cél prezentációból;
- egy meghatározott elrendezés alkalmazása a cél prezentációból;
- a különböző dia méretek normalizálása egyesítés előtt;
- klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy végponttól végpontig tartó munkafolyamatban;
- mesterek, erőforrások, jegyzetek, megjegyzések, média, betűk, jelszavak, nagy fájlok és több szálas szempontok kezelése.

## **A dia klónozás hatása a mesterekre és elrendezésekre**

A dia megjelenésének nagy részét a saját elrendezése és mesterje adja. Ezért az általad választott klónozási túlterhelés határozza meg, hogy a beillesztett dia hogyan integrálódik a cél prezentációba.

Használd a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) egyik változatát:

- `addClone(sourceSlide)` — megőrzi a forrás dia elrendezését és formázását. Szükség esetén a forrás mester automatikusan klónozható a cél prezentációba. Az Aspose.Slides automatikusan klónozott mestereket nyomon követ, így a ugyanazt a forrás mestert használó ismételt diák nem eredményeznek többszöri klónozást.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy adott cél [MasterSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslide/) alá csatolja. Az Aspose.Slides a megadott mester alatt megpróbál illeszkedő elrendezést találni típus vagy név alapján.
- `addClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy adott cél [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) alá csatolja.

Az `addClone` túlterhelésnek átadott mester vagy elrendezés a **cél** prezentációhoz kell, hogy tartozzon, nem a forrás prezentációhoz.

## **Teljes prezentációk egyesítése és a forrás formázásának megőrzése**

A legegyszerűbb egyesítés minden diát átmásol a forrás prezentációból a cél prezentációba. Ez a megfelelő választás, ha a importált diáknak meg kell tartaniuk eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

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

Az eredményül kapott prezentáció több mestert is tartalmazhat, ha a forrás és a cél különböző tervezéseket használ. Ez várható, ha szándékosan megőrzöd a forrás formázását.

## **Kiválasztott diák egyesítése**

Nem szükséges minden diát klónozni. Az alábbi példa csak a forrás prezentáció egyes megadott diaindexeit importálja.

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

Az indexek ellenőrzése a klónozás előtt akkor fontos, ha felhasználói bemenetről vagy külső konfigurációból származnak.

## **Diák egyesítése célmester használatával**

Használd a [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) túlterhelést, ha az importált diáknak egy olyan mesterhez kell tartozniuk, amely már a cél prezentációban van.

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

Az Aspose.Slides a megadott mester alatt egy megfelelő elrendezést választ ki a forrás elrendezés típus vagy név egyezése alapján. Ha nincs megfelelő elrendezés, és az `allowCloneMissingLayout` értéke `true`, akkor a forrás elrendezés klónozódik, így a dia hozzáadható. Ha `false`, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kerül feldobásra.

Használd a `false` értéket, ha azt szeretnéd, hogy az egyesítés hibával álljon le ahelyett, hogy további elrendezést hozna létre a célmesterben.

## **Diák egyesítése meghatározott cél elrendezés használatával**

Használd a [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) túlterhelést, ha pontosan tudod, melyik cél elrendezést kell az importált diáknak használniuk.

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

Egy cél elrendezés alkalmazása csak a örökölt elrendezési kapcsolatot változtatja meg; a forrás dia tartalma nem kerül újratervezésre. Ha a forrás és a cél elrendezések különböző helyőrző struktúrával rendelkeznek, ellenőrizd az eredményt, hogy a formázás és a helyőrző viselkedés megfelelő legyen.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik méretű prezentációba nem alakítja át automatikusan a tartalmát az új vászonra. Ennek következtében a alakzatok eltolódhatnak, váratlanul átméreteződhetnek vagy a látható dia területén kívül kerülhetnek.

A gyakorlati megoldás az, hogy a forrás prezentációt átméretezed a klónozás előtt. A [SlideSize.setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) metódus az existing tartalmat skálázhatja, miközben a dia méreteket módosítja. A [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

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

Az átméretezés a forrás prezentáció objektumot a memóriában módosítja. Ha a későbbi műveletekhez változatlanul szeretnéd megtartani a forrást, nyiss egy külön példányt az egyesítéshez.

## **Diák egyesítése prezentáció szekcióba**

Az alapvető dia‑klónozási ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozz létre vagy válassz szekciókat a cél prezentációban, és a diák klónozását kifejezetten a [addClone(Slide, Section)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) metódussal végezd.

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

A klónozott diák a megadott cél szekcióhoz lesznek hozzáadva. Több forrás szekció megőrzéséhez iteráld a [Presentation.getSections](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSections) eredményét, a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSlidesListOfSection) segítségével szerezd meg az egyes szekciók diáit, hozd létre a szekciókat a célban, és klónozd minden diát a megfelelő cél szekcióba. Lásd a [Manage Slide Sections](/slides/hu/nodejs-java/slide-section/) oldalon a teljes szekció‑enumerációs példát, beleértve az üres szekciókat és a struktúrváltozásokat.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól végpontig tartó példa az első prezentációt használja célként, normalizálja minden további forrás dia méretét, csak a másolás alatt tartja nyitva a forrást, és a végén egyetlen alkalommal menti a fájlt.

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

Ez egy hasznos kiindulási pont a forrás formázás megőrzéséhez. Ha a kimenetednek egyetlen cél témát kell használnia, cseréld le az egyszerű `addClone(sourceSlide)` hívást a korábban bemutatott megfelelő cél‑mester vagy cél‑elrendezés túlterhelésre.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és formázási hűség**

Az alapértelmezett dia‑klónozás automatikusan behozhat egy szükséges forrás mestert a cél prezentációba. Az Aspose.Slides egy belső regisztert tart a automatikusan klónozott mesterekhez, hogy elkerülje ugyanannak a mesternek a többszöri klónozását. A manuálisan klónozott mestereket ez a regiszter nem követi, ezért kerüld a mesterek előzetes klónozását, hacsak nem szükséges explicit kontroll a mester struktúrája felett.

Ne tégy feltevést, hogy két azonos nevű mester vagy elrendezés vizuálisan ekvivalens. Ha egy vállalati sablonnak kell szabályoznia a végső megjelenést, válassz kifejezetten egy cél mestert vagy elrendezést, és ellenőrizd az egyesítést követően a végeredményt.

### **Jegyzetek és megjegyzések**

A prezentációs előadói jegyzetek és dia‑megjegyzések a dia tartalmához kapcsolódnak, és a dia klónozásakor másolódnak. Az Aspose.Slides külön API‑kat is biztosít a [presentation notes](/slides/hu/nodejs-java/presentation-notes/) és a [presentation comments](/slides/hu/nodejs-java/presentation-comments/) kezelésére.

Ha a notes‑page formázása fontos, ellenőrizd az egyesített prezentációt, mert a notes‑masterek prezentáció‑szintű objektumok, és forrásfájlok között eltérhetnek. Az átnézési munkafolyamatok esetén ellenőrizd a megjegyzés‑szerzőket és a szálas megjegyzéseket is, ha különböző szerzők vagy sablonok fájljait egyesíted.

### **Képek, hang, video, OLE objektumok és külső hivatkozások**

A diák hivatkozhat prezentáció‑szintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozd a diát magát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforrás‑kapcsolatait.

A beágyazott és hivatkozott erőforrásokat külön kell kezelni. A hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is függ a külső céltól; egy dia klónozása nem alakítja beágyazottá a külső linket. Teszteld a hivatkozott erőforrás‑útvonalakat és URL‑eket abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides automatikusan klónozott mestereket követ, de ez nem jelent általános garanciát arra, hogy a nem kapcsolódó forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, vizsgáld meg a csomagot, és mérd le a végeredményt a feltételezett deduplikáció helyett.

### **Beágyazott betűk és betűk elérhetősége**

A betűk a prezentáció szintjén kerülnek kezelésre. Ha a tipográfiának minden gépen konzisztensnek kell lennie, ne feltételezd, hogy csak a diák klónozása biztosítja a szükséges betűk rendelkezésre állását a cél környezetben. A beágyazott betűket ellenőrizheted a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) segítségével, és a beágyazást explicit módon kezelheted a [Embed Fonts in Presentations](/slides/hu/nodejs-java/embedded-font/) útmutatóban leírtak szerint.

Ellenőrizd azt is, hogy engedélyezett‑e a forrás fájlokban használt betűk beágyazása. A betűlicencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

Egy jelszóval védett forrást csak akkor lehet megnyitni, ha a jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) segítségével adod meg.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Dolgozz a feloldott prezentációval.
} finally {
    source.dispose();
}
```

Egy titkosított forrás megnyitása nem alkalmazza automatikusan ugyanazt a védelmet a cél prezentációra. A kimeneti védelmet külön kell konfigurálni, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

A nagy felbontású képeket, hangot, videót vagy egyéb nagy bináris objektumokat tartalmazó prezentációk jelentős memóriát fogyaszthatnak. A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) lehetővé teszi a BLOB kezelés és az ideiglenes fájlok használatának szabályozását. Lásd a [Manage Presentation BLOBs](/slides/hu/nodejs-java/manage-blob/) oldalt a nagy fájlokra vonatkozó stratégiákért.

Nagy fájlok esetén előnyös a fájl útvonalból való betöltés, amint csak lehetséges, a forrás prezentációkat a beillesztés után azonnal eldobni, és elkerülni a köztes eredmények többszöri mentését, hacsak a munkafolyamat nem igényel ellenőrzőpontokat.

### **Szálbiztonság**

Ne tölts be, ments vagy klónozz egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt több szálon. Ezek a műveletek nem támogatottak több szálon. Ha független egyesítési feladatokat kell párhuzamosan végrehajtani, használj több egyszálú folyamatot, mindegyik saját prezentáció‑példánnyal, és kövesd az [Aspose.Slides multithreading guidance](/slides/hu/nodejs-java/multithreading/) útmutatót.

## **GYIK**

**Hogyan tudom megőrizni minden forrás prezentáció eredeti dizájnját?**

Használd az [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) metódust destination master vagy layout megadása nélkül. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha az importált diáknak szüksége van rá.

**Hogyan tehetem úgy, hogy az importált diák a cél témát használják?**

Használd azt a túlterhelést, amely egy cél mestert fogad el. Adj meg egy mestert a cél prezentációból, nem a forrásból. Az Aspose.Slides megpróbál minden forrás diát a megfelelő elrendezéshez map‑olni a megadott mester alatt.

**Mikor érdemes konkrét cél elrendezést használni a célmester helyett?**

Használj konkrét elrendezést, ha minden importált diának egy ismert elrendezést kell használnia. Használj mestert, ha azt szeretnéd, hogy az Aspose.Slides a forrás elrendezés típusa vagy neve alapján válasszon a mester elrendezései közül.

**Egyesíthetők-e különböző dia méretű prezentációk?**

Igen, de a dia tartalma nem kerül automatikusan újratervezésre a céldimenziókhoz. A forrás prezentációt előbb méretezd át, ha kiszámítható elhelyezkedésre van szükség, például a [SlideSize.setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) és a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesizescaletype/) segítségével.

**Egyesíthetek-e PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Tölts be minden forrás prezentációt, klónozd a szükséges diákat egyetlen célba, és mentsd a célt egy támogatott kimeneti formátumban. Mivel a formátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizd a bonyolult tartalmat a kereszt‑formátumú egyesítések után. Lásd a [Supported File Formats](/slides/hu/nodejs-java/supported-file-formats/).

**Megmaradnak-e automatikusan a forrás szekciók?**

Nem egy egyszerű ciklus, amely csak diák klónozását végzi. Hozd létre a szükséges szekciókat a célban, és használd a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) szekció‑túlterhelését, ha a szekció struktúráját meg kell őrizni.

**Megmaradnak-e a speaker notes és a megjegyzések?**

A klónozott diákkal együtt másolódnak. Olyan munkafolyamatok esetén, amelyek a notes‑master stílusra, a megjegyzés‑szerzőkre vagy a szálas felülvizsgálati adatokra támaszkodnak, ellenőrizd az egyesített eredményt, mert ezek a szcenáriók prezentáció‑szintű struktúrákat is érintenek.

**Mi a helyzet a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforrás‑kapcsolatai részeként kerül továbbításra. A külső hivatkozások továbbra is külsőek maradnak, így a cél fájloknak vagy URL‑eknek elérhetőnek kell lenniük az egyesítés után.

**Garantált-e, hogy minden forrásból származó beágyazott betű elérhető lesz az egyesített prezentációban?**

Ne támaszkodj csak a dia‑klónozásra a betűk telepítéséhez. Ellenőrizd a cél beágyazott betűit, és kezeljed explicit módon a betű beágyazást vagy a külső betűk rendelkezésre állását, ha a tipográfia fontos.

**Hogyan egyesítem a jelszóval védett fájlt?**

Nyisd meg a megfelelő [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) segítségével, majd klónozd a diákat a szokásos módon. A kimeneti védelem külön konfigurálható.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használd a BLOB‑kezelést, amikor nagy bináris objektumok dominálják a memóriahasználatot, előnyben részesítsd a fájl‑útvonal‑alapú betöltést a nagyon nagy fájlok esetén, a forrás prezentációkat azonnal zárd le a beillesztés után, és csak akkor mentsd a végleges eredményt, amikor ténylegesen szükséges.

**Klónozhatok‑e diákot több szálról?**

Ne tölts be, ments vagy klónozz egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt több szálon. Ha párhuzamos egyesítési feladatok szükségesek, használj különálló egyszálú folyamatokat, mindegyik saját prezentáció‑példánnyal, és kövesd az [Aspose.Slides multithreading guidance](/slides/hu/nodejs-java/multithreading/) útmutatót.