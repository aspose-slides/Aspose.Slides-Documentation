---
title: Hatékonyan egyesítse a prezentációkat Androidon
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
description: "Ismerje meg, hogyan egyesítheti a PowerPoint és OpenDocument prezentációkat Androidon dia klónozással, a mesterek és elrendezések szabályozásával, a dia tartalom átméretezésével, a szekciók megőrzésével, valamint a védett vagy nagy fájlok kezelése révén."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java prezentációkat egyesíti a diák másolásával az egyik [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) egy másikba. A fő művelet a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), amely megőrizheti a forrásdia formázását, vagy a klónozott diát egy mesterhez vagy elrendezéshez csatolhatja a célprezentációban.

Ez a cikk a leggyakoribb egyesítési munkafolyamatokat tárgyalja:

- az összes dia egyesítése a forrásformázás megőrzése mellett;
- kijelölt diák egyesítése;
- a célprezentáció egy mesterének alkalmazása;
- a célprezentáció egy konkrét elrendezésének alkalmazása;
- az eltérő dia méretek normalizálása egyesítés előtt;
- a klónozott diák hozzáadása egy szekcióhoz;
- több prezentáció egyesítése egy átfogó munkafolyamatban;
- a mesterek, erőforrások, jegyzetek, megjegyzések, média, betűtípusok, jelszavak, nagy fájlok és több szálas feldolgozás kezelése.

## **A dia klónozása hatása a mesterekre és elrendezésekre**

Egy dia megjelenésének nagy részét az elrendezés és a mester határozza meg. Emiatt a választott klónozási felülterhelés dönti el, hogyan kerül be a egyesített dia a célprezentációba.

Használja a [ISlideCollection.addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) egyik változatát az alábbi módokon:

- `addClone(sourceSlide)` — megőrzi a forrásdia elrendezését és formázását. Szükség esetén a forrásmester automatikusan klónozható a célprezentációba. Az Aspose.Slides automatikusan klónozott mestereket nyomon követ, így ugyanazt a mestert használó ismétlődő diák nem okoznak többszöri klónozást.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — a klónozott diát egy konkrét cél [IMasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslide/) alá csatolja. Az Aspose.Slides a mester alatt a layout típus vagy név alapján keres egyező elrendezést.
- `addClone(sourceSlide, destinationLayout)` — a klónozott diát közvetlenül egy konkrét cél [ILayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslide/) alá csatolja.

Az `addClone` felülterhelésnek átadott mesternek vagy elrendezésnek a **cél** prezentációhoz kell tartoznia, nem a forráshoz.

## **Teljes prezentációk egyesítése és a forrás formázásának megőrzése**

A legegyszerűbb egyesítés minden diát átmásol a forrás prezentációból a cél prezentációba. Ez a megfelelő választás, ha a importált diáknak meg kell őrizniük eredeti témájukat, mesterüket és elrendezéskapcsolataikat.

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

Az eredményes prezentáció több mestert tartalmazhat, ha a forrás és a cél különböző terveket használ. Ez várható, ha a forrásformázás szándékosan megmarad.

## **Kijelölt diák egyesítése**

Nem szükséges minden diát klónozni. Az alábbi példa csak a forrás prezentáció kiválasztott diaindexeit importálja.

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

Érvényesítse a diaindexeket a klónozás előtt, ha felhasználói bemenetből vagy külső konfigurációból származnak.

## **Diák egyesítése célmesterrel**

Használja a [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) felülterhelést, ha az importált diáknak egy már a célprezentációban lévő mesterhez kell illeszkedniük.

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

Az Aspose.Slides a megadott mester alatt a forrás elrendezés típusának vagy nevének megfelelő elrendezést választja. Ha nincs megfelelő elrendezés és az `allowCloneMissingLayout` **true**, a forráselrendezés klónozódik, így a dia hozzáadható. Ha **false**, [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) keletkezik.

Használja a **false** értéket, ha inkább azt akarja, hogy az egyesítés hibára fusson, ahelyett, hogy további elrendezést hozna létre a célmesterben.

## **Diák egyesítése konkrét célelrendezéssel**

Használja a [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) felülterhelést, ha pontosan tudja, melyik célelrendezést kell az importált diáknak használniuk.

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

A célelrendezés alkalmazása megváltoztatja az örökölt elrendezéskapcsolatot; a forrásdia tartalma nem kerül újratervezésre. Ha a forrás- és célelrendezések különböző helyőrző struktúrával rendelkeznek, ellenőrizze az eredményt, hogy az örökölt formázás és a helyőrző viselkedés megfelelő-e.

## **Prezentációk egyesítése eltérő dia méretekkel**

Eltérő dia mérettel rendelkező prezentációk egyesíthetők, de egy dia klónozása egy másik mérettel rendelkező prezentációba nem alakítja át automatikusan a tartalmat az új vászonra. Ennek következtében alakzatok eltolódhatnak, váratlanul méreteződhetnek, vagy a látható dia területén kívülre kerülhetnek.

Gyakorlati megoldásként a forrás prezentációt méretezze át a klónozás előtt. A [SlideSize.setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) metódus méretezheti a meglévő tartalmat, miközben a dia mérete változik. A [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) a tartalmat a kért mérethez igazítja.

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

A méretezés a forrás prezentáció objektumot módosítja a memóriában. Ha az eredeti forrás prezentációt más műveletekhez változatlanul kell hagyni, nyisson egy külön példányt az egyesítéshez.

## **Diák egyesítése egy prezentáció szekciójába**

Az alapvető dia-klónozási ciklus nem hozza létre a forrás prezentáció szekcióhierarchiáját. Ha a szekciók fontosak a kimenetben, hozzon létre vagy válasszon ki szekciókat a cél prezentációban, és a diákot explicite klónozza bele a [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metódussal.

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

A klónozott diák a megadott cél szekció végére kerülnek. Több forrás szekció megőrzéséhez hozza létre ezeket a szekciókat a célban, és térképezze a forrás diát a megfelelő cél szekcióra.

## **Több prezentáció biztonságos egyesítése**

Az alábbi végponttól végpontig terjedő példa az első prezentációt használja célként, normalizálja az egyes további források dia méretét, minden forrást csak a másolás ideje alatt nyit meg, és a végleges fájlt egyszer menti.

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

Ez egy hasznos kiindulási pont a forrásformázás megőrzéséhez. Ha a kimenetnek egyetlen cél témát kell használnia, cserélje le az egyszerű `addClone(slide)` hívást a korábban bemutatott megfelelő célmester vagy célelrendezés felülterhelésre.

## **Gyakorlati megfontolások**

### **Mesterek, elrendezések és a formázás pontossága**

Az alapértelmezett dia-klónozás automatikusan behozhat egy szükséges forrás mestert a cél prezentációba. Az Aspose.Slides belső regisztert vezet az automatikusan klónozott mesterek számára, hogy elkerülje ugyanazon mester többszöri klónozását. A manuálisan klónozott mestereket ez a regiszter nem követi, ezért kerüljük a mesterek előzetes klónozását, hacsak nem szükséges a mester struktúrájának explicit irányítása.

Ne feltételezzük, hogy két azonos névű mester vagy elrendezés vizuálisan ekvivalens. Ha egy vállalati sablonnak kell irányítania a végső megjelenést, válasszon explicit cél mestert vagy elrendezést, és ellenőrizze az eredményt az egyesítés után.

### **Jegyzetek és megjegyzések**

Az előadói jegyzetek és a dia megjegyzések a dia tartalmához kapcsolódnak, és a dia klónozásakor másolódnak. Az Aspose.Slides dedikált API‑kat is biztosít a [presentation notes](https://docs.aspose.com/slides/hu/androidjava/presentation-notes/) és a [presentation comments](https://docs.aspose.com/slides/hu/androidjava/presentation-comments/) kezelésére.

Ha a notes‑oldal formázása fontos, ellenőrizze az egyesített prezentációt, mert a notes mesterek prezentáció‑szintű objektumok, és forrás fájlok között eltérhetnek. Felülvizsgálati folyamatoknál ellenőrizze a megjegyzés szerzőket és a szálas megjegyzéseket is, ha különböző szerzők vagy sablonok fájljait egyesíti.

### **Képek, hang, videó, OLE objektumok és külső hivatkozások**

A diák hivatkozhat prezentáció‑szintű erőforrásokra, például képekre, beágyazott hangra, beágyazott videóra és OLE adatokra. Klónozza magát a diát, ne csak a látható alakzatokat, hogy az Aspose.Slides megőrizhesse a dia erőforráskapcsolatait.

A beágyazott és a hivatkozott erőforrásokat külön kell kezelni. Egy hivatkozott hang, videó, OLE objektum vagy hiperhivatkozás továbbra is külső célra támaszkodik; a dia klónozása nem alakítja át a külső hivatkozást beágyazott tartalommá. Tesztelje a hivatkozott erőforrások útvonalait és URL‑jeit abban a környezetben, ahol az egyesített prezentációt megnyitják.

Az Aspose.Slides automatikusan klónozott mestereket nyomon követ, de ez nem jelent általános garanciát arra, hogy az unrelated forrás prezentációkból származó azonos bináris erőforrások mindig deduplikálódnak. Ha a kimeneti fájlméret fontos, vizsgálja meg az egyesített csomagot és mérje le a méretet ahelyett, hogy implicit deduplikációra támaszkodna.

### **Beágyazott betűtípusok és betűtípus‑elérhetőség**

A betűtípusok a prezentáció szintjén kezelhetők. Ha a tipográfiának gépek között konzisztensnek kell maradnia, ne feltételezze, hogy a dia klónozása egyedül garantálja a szükséges betűtípusok meglétét a cél környezetben. A beágyazott betűtípusokat a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) metódussal ellenőrizheti, és a [Embed Fonts in Presentations](https://docs.aspose.com/slides/hu/androidjava/embedded-font/) útmutatóban leírt módon kezelheti a beágyazást.

Ellenőrizze továbbá, hogy jogosult‑e a forrás fájlokban használt betűtípusok beágyazására. A betűtípus‑licencek korlátozhatják a beágyazást.

### **Jelszó‑védett prezentációk**

A jelszó‑védett forrást sikeresen meg kell nyitni, mielőtt a diái klónozhatók. A jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) metódussal adja meg.

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

A titkosított forrás megnyitása nem alkalmaz automatikusan ugyanazt a védelmet a cél prezentációra. A kimeneti védelem beállítása külön kell, ha szükséges.

### **Nagy prezentációk és memóriahasználat**

Nagy prezentációk, amelyek nagy felbontású képeket, hangot, videót vagy egyéb nagy bináris objektumokat tartalmaznak, jelentős memóriát fogyaszthatnak. A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) lehetőséget kínál a BLOB‑kezelés és a temporary‑file használat szabályozására. Lásd a [Manage Presentation BLOBs](https://docs.aspose.com/slides/hu/androidjava/manage-blob/) anyagot a nagy fájlokra vonatkozó stratégiákról.

Nagy fájlok esetén részesítse előnyben a fájlúton való betöltést, amint lehetséges, szabadítsa fel minden forrás prezentációt, amint az be lett másolva, és kerülje el a köztes eredmények ismételt mentését, hacsak a munkafolyamat nem igényel ellenőrző pontokat.

### **Szálbiztonság**

Ne töltsön be, módosítson, mentse vagy klónozza ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt párhuzamosan több szálról. Tartsa az egyes prezentációs példányokat egyetlen egyesítési művelethez. Ha független feladatokat párhuzamosít, használjon független prezentációs példányokat, és kövesse az [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/hu/androidjava/multithreading/) útmutatót.

## **GYIK**

**Hogyan tarthatom meg minden forrás prezentáció eredeti dizájnját?**

Használja a [`addClone(sourceSlide)`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) hívást a célmester vagy –elrendezés megadása nélkül. Az Aspose.Slides automatikusan klónozhatja a forrás mestert, ha a importált diához szükség van rá.

**Hogyan tudom, hogy az importált diák a cél téma szerint legyen formázva?**

Használja azt a felülterhelést, amely egy cél mestert fogad. Adjon át egy mestert a cél prezentációból, nem a forrásból. Az Aspose.Slides megpróbálja minden forrásdiát a megfelelő elrendezéshez rendelni a megadott mester alatt.

**Mikor kell konkrét célelrendezést használni a célmester helyett?**

Használjon konkrét elrendezést, ha minden importált diának egy ismert elrendezést kell használnia. Használjon mestert, ha azt akarja, hogy az Aspose.Slides a forrás elrendezés típus vagy név alapján válasszon a mester elrendezései közül.

**Egyesíthetők-e különböző dia mérettel rendelkező prezentációk?**

Igen, de a dia tartalma nem kerül automatikusan újratervezésre a cél méretekhez. Méretezze át a forrás prezentációt először, például a [SlideSize.setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) és a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) használatával.

**Egyesíthetek-e PPT, PPTX és ODP prezentációkat egy fájlba?**

Igen. Töltsön be minden forrás prezentációt, klónozza a szükséges diákot egy célba, és mentse a célt egy támogatott kimeneti formátumban. Mivel a prezentációformátumok nem támogatják pontosan ugyanazt a funkciókészletet, ellenőrizze a bonyolult tartalmat a kereszt‑formátumú egyesítések után. Lásd a [Supported File Formats](https://docs.aspose.com/slides/hu/androidjava/supported-file-formats/).

**Automatikusan megmaradnak-e a forrás szekciók?**

Nem egy egyszerű ciklus, amely csak diákot klónoz, nem őrzi meg a szekciókat. Hozza létre a szükséges szekciókat a célban, és használja a [addClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) szekció‑felülterhelést, ha a szekcióstruktúrát meg kell őrizni.

**Megmaradnak‑e az előadói jegyzetek és megjegyzések?**

Másolódnak a klónozott diával együtt. Az olyan munkafolyamatok esetén, amelyek a notes‑master stílusra, a megjegyzés‑szerzőkre vagy a szálas felülvizsgálati adatokra támaszkodnak, ellenőrizze az egyesített eredményt, mert ezek a forgatókönyvek prezentáció‑szintű struktúrákat is érintenek.

**Mi történik a hanggal, videóval, OLE objektumokkal és hiperhivatkozásokkal?**

A beágyazott tartalom a klónozott dia erőforrás‑kapcsolatához tartozik. A külső hivatkozások továbbra is külsőek, ezért a cél fájloknak vagy URL‑eknek elérhetőnek kell maradniuk az egyesítés után.

**Garantált‑e, hogy minden forrásból származó beágyazott betűtípus elérhető lesz az egyesített prezentációban?**

Ne hagyatkozzon kizárólag a dia‑klónozásra a betűtípus‑telepítéshez. Ellenőrizze a cél beágyazott betűtípusait, és szükség esetén explicit módon kezelje a betűtípus‑beágyazást vagy a külső betűtípus‑elérhetőséget, ha a tipográfia fontos.

**Hogyan egyesíthetek jelszó‑védett fájlt?**

Nyissa meg a megfelelő [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) használatával, majd a diákat a szokásos módon klónozza. A kimeneti védelem külön konfigurálandó.

**Hogyan kezeljem a nagyon nagy prezentációkat?**

Használja a BLOB‑kezelést, ha nagy bináris objektumok dominálják a memóriahasználatot, részesítse előnyben a fájl‑útvonalas betöltést nagyon nagy fájlok esetén, szabadítsa fel a forrás prezentációkat időben, és csak a végső eredményt mentse el, amikor szükséges.

**Klónozhatok‑e diákot több szálról?**

Ne használjon egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt párhuzamosan több szálról. Tartsa minden egyes egyesítési műveletet egy saját prezentációs példányhoz.