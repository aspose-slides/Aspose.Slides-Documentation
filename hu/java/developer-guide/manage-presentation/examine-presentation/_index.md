---
title: Prezentáció információinak lekérése és frissítése Java-ban
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok átalakítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban Java használatával a gyorsabb betekintés és az okosabb tartalom auditok érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy bemutató formátumát és olvasni a dokumentum metaadatait anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt készíteni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a bemutató tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/) és [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) segítségével, valamint a célzott frissítéseket a [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) használatával.

## **Ellenőrizze a bemutató formátumát**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust a fájl ellenőrzéséhez anélkül, hogy létrehozná a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt. Az [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódus jelzi a felismerett formátumot, például PPTX, PPT vagy ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Készítsen egy könnyű bemutató leltárt**

Amikor sok bemutató fájlt dolgoz fel, szüksége lehet egy kompakt leltárra ellenőrzéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) objektum létrehozásához, majd hívja az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust a dokumentum metaadatok olvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell bejárását.

A [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltári értékeket tartalmazzák:

| Módszer | Leltári érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSlides--) | A diák teljes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getNotes--) | Azon diák száma, amelyek jegyzeteket tartalmaznak. |
| [getParagraphs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | A bekezdések teljes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getWords--) | A szavak teljes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Az audio és videó klippek teljes száma. |

Az alábbi példa ezeket az értékeket olvassa be anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat. Emellett kombinálja a [getHeadingPairs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) metódust a [getTitlesOfParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) metódussal, hogy megjelenítse a tartalomcsoportokat, például betűtípusok, témák és diacímek.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iheadingpair/) csoportnevet és a csoportban lévő elemek számát biztosítja. Az [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) egy lapos, rendezett tömböt ad vissza, ezért a sorozatos címek számát a megfelelő heading pair határozza meg.

### **Tárolt metaadatok és formátumkorlátok**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott leltári tulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy újraszámolja ezeket az értékeket a hívás során. A hiányzó tulajdonságok alapértelmezett értékkel jelennek meg, a tárolt értékek pedig elavulhatnak, ha az utoljára mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a dia, jegyzet, rejtett dia, bekezdés, szó és multimédia számlálókhoz, valamint a heading pair‑ekhez és részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum tárolhat megfelelő dokumentum‑összefoglaló tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissítette a dokumentum előállítója, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, a diák alapján nem számítja újra.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat nyújtanak, mint például oldal, bekezdés és szó számlálók, de ezek az értékek nem térnek le minden PowerPoint‑specifikus kiterjesztett tulajdonságra. A rejtett dia, jegyzet dia, multimédia, heading‑pair és részcím metaadatok lehet, hogy nem érhetők el, és a leltári tulajdonságok alapértelmezett értéket adhatnak vissza. Ne tekintse a nulla értéket vagy egy üres tömböt tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a bemutatót és ellenőrizze élő objektummodelljét, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges bemutató tartalmát kell ellenőrizni.

## **Frissítse a bemutató tulajdonságait**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt hoznának létre. Alkalmazza a módosításokat az [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódussal, majd írja ki a kötött bemutatót az [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) segítségével.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja a PowerPoint bemutatóban.

![Az eredeti dokumentumtulajdonságok a PowerPoint bemutatóban](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Az alábbi kép a módosított dokumentumtulajdonságokat mutatja a PowerPoint bemutatóban.

![Módosított dokumentumtulajdonságok a PowerPoint bemutatóban](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzésekért és védelmi beállításokért tekintse meg a következő cikkeket:

- [Jelszóval védett bemutatók](/slides/hu/java/password-protected-presentation/)
- [Írásvédett bemutatók](/slides/hu/java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getFontsManager--) metódust. Hívja a [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a beágyazott betűtípusok lekéréséhez, valamint a [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFonts--) metódust a bemutató által használt betűtípusokhoz. Hasonlítsa össze a két eredményt, hogy megtalálja a megjelenítéshez szükséges, de nem beágyazott betűtípusokat.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz‑e rejtett diákot, és ha igen, hány darabot?**

Amikor a tárolt dokumentum‑metaadat elegendő, olvassa a [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) értéket a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével. Ez alkalmas egy könnyű leltárra. Ha a bemutató memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy ha élő értékeket kell ellenőrizni, járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjteményt, és vizsgálja meg minden dia [ISlide.getHidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getHidden--) metódusát.

**Felismerhetem‑e, hogy egyedi dia méret és tájolás van‑e használatban, és eltér‑e‑nek az alapértelmezett beállításoktól?**

Igen. Töltse be a bemutatót, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlideSize--) metódust. Használja az [ISlideSize.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getType--), az [ISlideSize.getSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getSize--) és az [ISlideSize.getOrientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getOrientation--) metódusokat az aktuális beállítások összehasonlításához az elvárt előre definiált méretekkel és orientációval.

**Van‑e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/) elemet, és hívja a [IChartData.getDataSourceType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getDataSourceType--) metódust. Külső munkafüzet esetén hívja a [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metódust. Az adatforrás típusa és útvonala jelzi a külső hivatkozást, de a cél elérhetőségének ellenőrzése külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen komplexitási tulajdonság. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjteményt és minden dia [IBaseSlide.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getShapes--) kollekcióját. Használjon alakzat‑számot és nagy képek, effektusok, animációk vagy multimédiák jelenlétét jelző szűrőjelet, és mérje egy reprezentatív renderelést vagy exportot, mielőtt a diát megerősített teljesítmény‑szűkítőnek nyilvánítaná.