---
title: Prezentáció-információk lekérése és frissítése Androidon
linktitle: Prezentáció-információ
type: docs
weight: 30
url: /hu/androidjava/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel a diákat, a struktúrát és a metaadatokat a PowerPoint és OpenDocument prezentációkban Java használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy bemutató formátumát és beolvasni a dokumentum metaadatait anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, amikor fájlokat kell osztályozni, leltárt készíteni, vagy a tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a bemutató tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/) és [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) segítségével, valamint a célzott módosításokat az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) használatával.

## **Ellenőrizze a bemutató formátumát**

Ha már betöltött bemutatója van, lásd a [Határozza meg az eredeti bemutató formátumát](/slides/hu/androidjava/detect-presentation-source-format/) cikket a betöltés utáni detektáláshoz, valamint a régi PPT, PPS és POT adatfolyamok korlátaival kapcsolatban.

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust egy fájl ellenőrzéséhez a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány létrehozása nélkül. Az [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Készítsen könnyű bemutató leltárt**

Ha sok bemutatófájlt dolgoz fel, előfordulhat, hogy egy kompakt leltárra van szüksége érvényesítéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) objektum beszerzéséhez, majd hívja a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adják meg:

| Metódus | Leltár érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | A diák összes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | A jegyzettel ellátott diák száma. |
| [getParagraphs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | A bekezdések összes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | A szavak összes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Az audio- és videóklippek összes száma. |

A következő példa beolvassa ezeket az értékeket a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektum létrehozása nélkül, és egy kompakt leltárt jelenít meg. Emellett kombinálja a [getHeadingPairs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) és a [getTitlesOfParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) metódusokat a tartalomcsoportok, például betűkészletek, témák és dia címek megjelenítéséhez.

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

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iheadingpair/) egy csoportnevet és a csoportban lévő elemek számát adja meg. Az [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) egy lapos, rendezett tömböt ad vissza, ezért a sorozatos címek számát a megfelelő heading pair határozza meg.

### **Tárolt metaadatok és formátumkorlátok**

A [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy újraszámolja ezeket az értékeket ennél a hívásnál. A hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavultak lehetnek, ha a fájlt utoljára mentő alkalmazás nem frissítette a dokumentum tulajdonságait.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia elemek számlálásához, valamint a heading párok és részcímek tekintetében. Az elérhetőség a dokumentum előállítója által írt tulajdonságoktól függ.
- **PPT:** A bináris formátum képes tárolni a megfelelő dokumentum-összegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy a dokumentum előállítója nem frissítette, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, a diák alapján történő kiszámítás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat nyújtanak, például oldal-, bekezdés- és szószámokat, de ezek az értékek nem térképezhetők minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett diák, jegyzet-diák, multimédia, heading párok és részcím metaadatok hiányozhatnak, és a leltártulajdonságok alapértelmezett értékeket adhatnak vissza. Ne tekintse a null értéket vagy egy üres tömböt végleges bizonyítékként arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat megközelítést leltárokhoz és előzetes ellenőrzésekhez. Töltse be a bemutatót és ellenőrizze annak élő objektummodelljét, amikor az eredménynek a memóriában történt változásokat kell tükröznie, vagy amikor a tényleges bemutató tartalmát kell ellenőrizni.

## **Bemutató tulajdonságok frissítése**

A [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott tulajdonságok szintén módosíthatók a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány létrehozása nélkül. Alkalmazza a változtatásokat az [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódussal, majd írja ki a kapcsolt bemutatót az [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) metódussal.

A következő kép az eredeti dokumentum tulajdonságait mutatja.

![Az eredeti dokumentum tulajdonságai a PowerPoint bemutatóban](input_properties.png)

A következő példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

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

![Megváltozott dokumentum tulajdonságok a PowerPoint bemutatóban](output_properties.png)

## **Hasznos hivatkozások**

A kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd a következő cikkeket:

- [Jelszóval védett bemutatók](/slides/hu/androidjava/password-protected-presentation/)
- [Írásvédett bemutatók](/slides/hu/androidjava/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getFontsManager--) metódust. Hívja az [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a beágyazott betűkészletek lekéréséhez, és az [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) metódust a bemutató által használt betűkészletekhez. Hasonlítsa össze a két eredményt, hogy megtalálja azokat a betűkészleteket, amelyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákot, és hány darab van?**

Ha a tárolt dokumentum metaadatai elegendőek, olvassa el az [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) értékét a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével. Ez egy könnyű leltárra alkalmas. Ha a bemutató memóriában módosult, a tárolt metaadatok hiányozhatnak vagy elavultak lehetnek, vagy ha élő értékeket kell ellenőrizni, járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) kollekciót, és minden dia [ISlide.getHidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getHidden--) metódusát vizsgálja.

**Detektálhatom-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Töltse be a bemutatót, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideSize--) metódust. Használja az [ISlideSize.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getSize--) és [ISlideSize.getOrientation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getOrientation--) metódusokat az aktuális beállítások összehasonlításához az elvárt alapértelmezett méretekkel és orientációval.

**Van gyors módszer arra, hogy lássam, a diagramok külső adatforrásra hivatkoznak-e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/) elemet, és hívja az [IChartData.getDataSourceType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) metódust. Külső munkafüzet esetén hívja az [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metódust. Az adatforrás típusa és elérési útja azonosítja a külső hivatkozást, de annak elérhetőségének ellenőrzése külön erőforrás-ellenőrzést igényel.

**Hogyan értékelhetem a 'nehéz' diákot, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen összetettségi tulajdonság. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) és minden dia [IBaseSlide.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getShapes--) kollekcióját. Használja a alakzatok számát és a nagy képek, effektusok, animációk vagy multimédia jelenlétét szűrési jelzőként, és végezzen egy reprezentatív renderelést vagy exportot, mielőtt a diát megerősített teljesítménybottlenecknek tekintené.