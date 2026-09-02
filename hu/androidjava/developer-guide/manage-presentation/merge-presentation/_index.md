---
title: Hatékonyan egyesíts prezentációkat Androidon
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan egyesíthet PowerPoint és OpenDocument prezentációkat Androidon diák klónozásával, a mesterek és elrendezések szabályozásával, a dia tartalom átméretezésével, a szekciók megőrzésével, valamint a védett vagy nagy fájlok kezelésével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java prezentációkat egyesíti úgy, hogy diák másolatát egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/)-ból egy másikba klónozza. A fő művelet a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), amely megőrizheti a forrásdia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a célprezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat mutatja be:

- az összes dia egyesítése a forrás formázásának megőrzésével;
- kiválasztott diák egyesítése;
- egy mester alkalmazása a célprezentációból;
- egy adott elrendezés alkalmazása a célprezentációból;
- a különböző dia méretek normalizálása egyesítés előtt;
- klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy végponttól végpontig folyamatban;
- mesterek, erőforrások, jegyzetek, megjegyzések, média, betűtípusok, jelszavak, nagy fájlok és több szálas kérdések kezelése.

## **Hogyan befolyásolja a dia klónozása a mestereket és az elrendezéseket**

Egy dia megjelenésének nagy részét a saját elrendezése és mestere határozza meg. Ezért a választott klónozási metódus határozza meg, hogyan integrálódik az egyesített dia a célprezentációba.

Használja a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) metódust az alábbi módok egyikével:

- `addClone(sourceSlide)` — megőrzi a forrásdia elrendezését és formázását. Szükség esetén a forrásmester automatikusan klónozható a célprezentációba. Az Aspose.Slides automatikusan klónozott mestereket nyomon követ, így az ugyanazt a forrásmestert használó ismétlődő diák nem okozzák a mester többszöri klónozását.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy adott cél-[IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/)-hez csatolja. Az Aspose.Slides a megfelelő elrendezést keresi az adott mester alatt elrendezéstípus vagy név alapján.
- `addClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy adott cél-[ILayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/)-hez csatolja.

Az `addClone` metódusnak átadott mesternek vagy elrendezésnek a **cél** prezentációhoz kell tartoznia, nem a forráshez.

## **Teljes prezentációk egyesítése és a forrás formázásának megőrzése**

A legegyszerűbb egyesítés minden diát átmásol a forrásprezentációból a célprezentációba. Ez a megfelelő választás, ha a importált diáknak meg kell tartaniuk eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A keletkezett prezentáció több mestert is tartalmazhat, ha a forrás és a cél különböző tervezéseket használ. Ez várható, ha a forrás formázását szándékosan megőrzik.

## **Kiválasztott diák egyesítése**

Nem kell minden diát klónozni. Az alábbi példa csak a forrásprezentáció kiválasztott diaindexeit importálja.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Ellenőrizze a diaindexeket a klónozás előtt, ha azok felhasználói bemenetből vagy külső konfigurációból származnak.

## **Diák egyesítése egy célmesterrel**

Használja a [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódust, ha az importált diáknak egy már a célprezentációhoz tartozó mesterhez kell illeszkedniük.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Az Aspose.Slides a megadott mester alatt egy megfelelő elrendezést választ ki a forrás elrendezés típusának vagy nevének egyezése alapján. Ha nincs megfelelő elrendezés és az `allowCloneMissingLayout` **true**, akkor a forráselrendezés klónozódik, hogy a dia hozzáadható legyen. Ha **false**, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kerül dobásra.

Használja a **false** értéket, ha azt szeretné, hogy az egyesítés hibával leálljon ahelyett, hogy további elrendezést hozna létre a célmesterben.

## **Diák egyesítése egy adott célelrendezéssel**

Használja a [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) metódust, ha pontosan tudja, melyik célelrendezést kell az importált diák használniuk.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A célelrendezés alkalmazása megváltoztatja az örökölt elrendezéskapcsolatot; a forrásdia tartalmát nem alakítja át. Ha a forrás és a cél elrendezések különböző helyőrző struktúrával rendelkeznek, ellenőrizze az eredményt, hogy az örökölt formázás és helyőrző viselkedés megfelelő legyen.

## **Prezentációk egyesítése különböző dia méretekkel**

Különböző dia méretekkel rendelkező prezentációk egyesíthetők, de egy dia klónozása másik dia méretű prezentációba nem alakítja át automatikusan a tartalmat az új vászonra. Ennek következtében az alakzatok eltolódhatnak, méreteződhetnek váratlanul vagy a látható dia területén kívülre kerülhetnek.

Egy gyakorlati megközelítés, hogy a forrásprezentációt átméretezzük klónozás előtt. A [SlideSize.setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) metódus skálázhatja a meglévő tartalmat a dia méretének megváltoztatása közben. A [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Az átméretezés megváltoztatja a forrásprezentáció objektumát a memóriában. Ha az eredeti forrásprezentációnak változatlanul kell maradnia további műveletekhez, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése egy prezentáció szekciójába**

Az alap dia‑klónozó ciklus nem hozza létre a forrásprezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozzon létre vagy válasszon ki szekciókat a célprezentációban, és klónozza a diákot kifejezetten a [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metódussal.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A klónozott diák a megadott cél szekcióhoz lesz hozzáfűzve. Több forrás szekció megőrzéséhez iterálja végig a [Presentation.getSections](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSections--) metódust, szerezze be minden forrás szekció aktuális diáit a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) segítségével, hozza létre a szekciókat a célban, és klónozza az egyes diát a megfelelő cél szekcióba. Lásd a [Manage Slide Sections](/slides/hu/androidjava/slide-section/) oldalt a komplett szekció‑enumerációs példáért, beleértve az üres szekciókat és a struktúraváltozásokat.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól‑végpontig példában az első prezentációt használja célként, normalizálja minden további forrás dia méretét, minden forrást csak a másolás ideje alatt nyit nyitva, és a végén egyszer menti a fájlt.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Ez egy hasznos alapvonal a forrás formázásának megőrzéséhez az importált diák esetén. Ha a kimenetnek egyetlen cél téma kell, cserélje le az egyszerű `addClone(slide)` hívást a korábban bemutatott megfelelő cél‑mester vagy cél‑elrendezés overloadra.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és a formázási hűség**

Az alap dia‑klónozás automatikusan behozhat egy szükséges forrásmestert a célprezentációba. Az Aspose.Slides egy belső regisztert vezet az automatikusan klónozott mesterek nyomon követésére, hogy ugyanaz a mester ne legyen többször klónozva. A manuálisan klónozott mestereket ez a regiszter nem követi, ezért kerüljük a mesterek előzetes klónozását, hacsak nem szükséges a mester struktúra explicit irányítása.

Ne tételezzük fel, hogy két azonos nevű mester vagy elrendezés vizuálisan egyenértékű. Ha egy vállalati sablonnak kell határoznia a végső megjelenést, válasszon explicit célmestert vagy elrendezést, és ellenőrizze az egyesítés utáni eredményt.

### **Jegyzetek és megjegyzések**

A előadói jegyzetek és dia megjegyzések a dia tartalmához kapcsolódnak, és másolásra kerülnek, amikor egy diát klónoznak. Az Aspose.Slides dedikált API‑kat is kínál a [presentation notes](/slides/hu/androidjava/presentation-notes/) és a [presentation comments](/slides/hu/androidjava/presentation-comments/) kezeléséhez.

Ha a jegyzetoldal formázása fontos, ellenőrizze az egyesített prezentációt, mert a jegyzetmesterek prezentáció‑szintű objektumok, és különbözhetnek a forrásfájlok között. Áttekintési munkafolyamatoknál ellenőrizze a megjegyzés szerzőket és a szálas megjegyzéseket is különböző szerzők vagy sablonok kombinálása után.

### **Képek, hang, videó, OLE objektumok és külső hivatkozások**

A diák hivatkozhatnak prezentáció‑szintű erőforrásokra, mint képek, beágyazott hang, beágyazott videó és OLE adatok. Klónozza a teljes diát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat külön kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hyperlink továbbra is a külső célra támaszkodik; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommá. Tesztelje a hivatkozott erőforrások útvonalait és URL‑jeit abban a környezetben, ahol az egyesített prezentációt meg fogják nyitni.

Az Aspose.Slides nyomon követi az automatikusan klónozott mestereket, de ez nem jelent általános garanciát arra, hogy az egymástól független forrásprezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, ellenőrizze a csomagot és mérje az eredményt, ahelyett, hogy a rejtett deduplikálásra támaszkodna.

### **Beágyazott betűtípusok és betűtípus elérhetőség**

A betűtípusok a prezentáció‑szinten vannak kezelve. Ha a tipográfiának gépek között konzisztensnek kell maradnia, ne feltételezze, hogy a diák klónozása önmagában garantálja, hogy minden szükséges betűtípus elérhető a célkörnyezetben. Ellenőrizheti a beágyazott betűtípusokat a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) segítségével, és kezelheti a beágyazást a [Embed Fonts in Presentations](/slides/hu/androidjava/embedded-font/) útmutató szerint.

Ellenőrizze továbbá, hogy jogosult-e beágyazni a forrásfájlok által használt betűtípusokat. A betűtípus licencek korlátozhatják a beágyazást.

### **Jelszóval védett prezentációk**

A jelszóval védett forrást sikeresen meg kell nyitni, mielőtt a diák klónozhatók. Adja meg a jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) segítségével.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Dolgozz a feloldott prezentációval.
} finally {
    source.dispose();
}
```

A titkosított forrás megnyitása nem alkalmazza automatikusan ugyanazt a védelmet a célprezentációra. A kimeneti védekezést külön kell konfigurálni, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

Nagy prezentációk, amelyek nagy felbontású képeket, hangot, videót vagy egyéb nagy bináris objektumokat tartalmaznak, jelentős memóriát fogyaszthatnak. A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) beállítások vezérlik a BLOB kezelését és az ideiglenes fájlok használatát. Lásd a [Manage Presentation BLOBs](/slides/hu/androidjava/manage-blob/) oldalt a nagy fájlokra vonatkozó stratégiákért.

Nagy fájlok esetén részesítsen előnyben a fájlúton történő betöltést, ha lehetséges, és a forrásprezentációkat azonnal bontsa le, miután azok egyesítésre kerültek. Kerülje a köztes eredmények ismételt mentését, hacsak a munkafolyamat nem igényel ellenőrző pontokat.

### **Szálbiztonság**

Ne töltsön be, módosítson, mentessen vagy klónozzon ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt párhuzamosan több szálról. Tartsa minden prezentáció példányt egyetlen egyesítési műveleten belül. Ha független feladatokat párhuzamosít, használjon különálló prezentáció példányokat, és kövesse az [Aspose.Slides több szálas irányelveit](/slides/hu/androidjava/multithreading/).

## **GYIK**

**Hogyan őrizhetem meg minden forrásprezentáció eredeti dizájnját?**

Használja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) metódust, anélkül, hogy célmestert vagy elrendezést adna meg. Az Aspose.Slides automatikusan klónozhatja a forrásmestert, ha az importált diáknak szüksége van rá.

**Hogyan tehetem, hogy az importált diák a cél téma szerint jelenjenek meg?**

Használja azt a overloadot, amely egy célmestert fogad. Adjunk meg egy mestert a célprezentációból, nem a forrásból. Az Aspose.Slides minden forrásdiát megpróbál a megfelelő elrendezéshez társítani az adott mester alatt.

**Mikor használjak konkrét célelrendezést a célmester helyett?**

Használjon konkrét elrendezést, ha minden importált diáknak egy ismert elrendezést kell használnia. Használjon mestert, ha azt akarja, hogy az Aspose.Slides a forrás elrendezés típusának vagy nevének megfelelően válasszon elrendezést a mesterből.

**Egyesíthetők-e különböző dia méretekkel rendelkező prezentációk?**

Igen, de a dia tartalma nem kerül automatikusan újratervezésre a cél méretekhez. Átméretezze a forrásprezentációt, ha előre meghatározott elhelyezkedésre van szükség, például a [SlideSize.setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) és a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) használatával.

**Egyesíthetek-e PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Töltse be minden forrásprezentációt, klónozza a szükséges diákat egy célba, és mentse a célt egy támogatott kimeneti formátumban. Mivel a prezentációformátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a bonyolult tartalmat a formátumok közti egyesítések után. Lásd a [Supported File Formats](/slides/hu/androidjava/supported-file-formats/) oldalt.

**Megmaradnak-e automatikusan a forrás szekciók?**

Nem egy egyszerű ciklus, amely csak diákot klónoz, nem. Hozza létre a szükséges szekciókat a célban, és használja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) szekció overloadot, amikor a szekció struktúra megőrzése szükséges.

**Megmaradnak-e a beszélői jegyzetek és megjegyzések?**

Másolásra kerülnek a klónozott diákkal együtt. Azoknál a munkafolyamatoknál, amelyek a jegyzetmester stílusát, a megjegyzés szerzőket vagy a szálas felülvizsgálati adatokat érintik, ellenőrizze az egyesített eredményt, mivel ezek a scenáriók prezentáció‑szintű struktúrákat is érintenek a dia‑szintű tartalom mellett.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforráskapcsolatainak részévé válik. A külső hivatkozások továbbra is külsőek maradnak, ezért a célfájloknak vagy URL‑eknek elérhetőnek kell maradniuk az egyesítés után.

**Garantált-e, hogy minden forrás beágyazott betűtípusa elérhető lesz az egyesített prezentációban?**

Ne támaszkodjon csak a dia‑klónozásra a betűtípus‑telepítéshez. Ellenőrizze a cél beágyazott betűtípusait, és kezelje kifejezetten a betűtípus‑beágyazást vagy a külső betűtípus‑elérhetőséget, ha a tipográfia fontos.

**Hogyan egyesíthetek egy jelszóval védett fájlt?**

Nyissa meg a megfelelő [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) használatával, majd klónozza a diákot a szokásos módon. A kimeneti védelem külön van beállítva.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használja a BLOB kezelést, amikor nagy bináris objektumok dominálják a memóriahasználatot, részesítse előnyben a fájl‑úton történő betöltést nagyon nagy fájlok esetén, gyorsan bontsa le a forrásprezentációkat, és csak akkor mentse a végleges eredményt, amikor szükséges.

**Klónozhatok‑e diákot több szálról?**

Ne használjon egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt egyszerre több szálról. Tartsa minden egyes egyesítési műveletet elkülönített prezentáció‑példányokon.