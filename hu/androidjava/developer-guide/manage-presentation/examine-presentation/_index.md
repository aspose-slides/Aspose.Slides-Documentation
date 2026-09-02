---
title: Prezentáció információinak lekérése és frissítése Androidon
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/androidjava/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
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
description: "Fedezze fel a diák, a struktúra és a metaadatok elemzését PowerPoint és OpenDocument prezentációkban Java használatával a gyorsabb betekintés és intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát, és beolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt felépíteni, vagy a tulajdonságokat ellenőrizni szeretné, mielőtt eldöntené, hogy betölti-e és feldolgozza-e a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/) és a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) segítségével, valamint a célzott frissítéseket a [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) használatával.

## **Ellenőrizze a prezentáció formátumát**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Készítsen könnyű prezentációs leltárt**

Amikor sok prezentációs fájlt dolgoz fel, előfordulhat, hogy egy kompakt leltárra van szüksége érvényesítéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust egy [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) objektum előállításához, majd hívja a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) által nyújtott kiterjesztett tulajdonságok a következő leltárértékeket biztosítják:

| Módszer | Leltár értéke |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Az összes dia száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Azoknak a diákoknak a száma, amelyek tartalmaznak jegyzeteket. |
| [getParagraphs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Az összes bekezdés száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Az összes szó száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Az összes hang- és videoklip száma. |

A következő példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett egyesíti a [getHeadingPairs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) és a [getTitlesOfParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) hívásokat, hogy megjelenítse a tartalmi csoportokat, mint például a betűkészletek, témák és dia címek.

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

Minden [IHeadingPair](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iheadingpair/) egy csoportnevet és a csoportban lévő elemek számát adja meg. Az [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) egy lapos, rendezett tömböt ad vissza, ezért a fejlécpárok által meghatározott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott leltártulajdonságok tükrözik a forrásdokumentumban elérhető metaadatokat. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt, hogy újraszámolja ezeket az értékeket a hívás során. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha az utoljára fájlt mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számához, valamint a cípsor párokhoz és a részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum képes tárolni a megfelelő dokumentum-összefoglaló tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissítette a dokumentum előállítója, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza a diák alapján történő újraszámolás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldal-, bekezdés- és szószámot, de ezek az értékek nem térnek le minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett dia, a jegyzetdia, a multimédia, a cípsor-pár és a részcím metaadatok előfordulhatnak, vagy hiányozhatnak, és a leltártulajdonságok alapértelmezett értékkel térhetnek vissza. Ne tekintsen egy null értéket vagy egy üres tömböt autoritatív bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat-megoldást leltárakhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt, és ellenőrizze annak élő objektummodelljét, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges prezentációs tartalmat kell ellenőrizni.

## **Frissítse a prezentáció tulajdonságait**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt hoznának létre. Alkalmazza a változtatásokat az [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) segítségével, majd írja ki a kötött prezentációt az [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) metódussal.

![Az eredeti dokumentum tulajdonságai a PowerPoint prezentációban](input_properties.png)

A következő példa módosítja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

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

![Módosított dokumentum tulajdonságok a PowerPoint prezentációban](output_properties.png)

## **Hasznos hivatkozások**

A kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében tekintse meg a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/androidjava/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getFontsManager--) metódust. Hívja a [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a beágyazott betűkészletekhez, valamint a [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) metódust a prezentáció által használt betűkészletekhez. Hasonlítsa össze a két eredményt annak meghatározásához, hogy mely betűkészletek szükségesek a megjelenítéshez, de nincsenek beágyazva.

**Hogyan tudom gyorsan megmondani, hogy a fájl tartalmaz-e rejtett diát, és ha igen, hány darabot?**

Amikor a tárolt dokumentum metaadatai elegendőek, olvassa a [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) értéket a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével. Ez alkalmas egy könnyű leltárra. Ha a prezentáció memóriában módosult, a tárolt metaadatok hiányozhatnak vagy elavulhatnak, vagy ha élő értékeket akar ellenőrizni, járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) elemeit, és minden dia [ISlide.getHidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getHidden--) metódusát vizsgálja.

**Felderíthetem-e, hogy egyedi diamenet és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Töltse be a prezentációt, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideSize--) metódust. Használja az [ISlideSize.getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getSize--) és [ISlideSize.getOrientation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidesize/#getOrientation--) metódusokat a jelenlegi beállítások összehasonlításához az elvárt előre beállított értékekkel és méretekkel.

**Van gyors módja annak, hogy megtudjam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/) elemet, és hívja a [IChartData.getDataSourceType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) metódust. Külső munkafüzet esetén hívja a [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metódust. Az adatforrás típusa és az útvonal jelzi a külső hivatkozást, de annak elérhetőségét külön erőforrás‑ellenőrzéssel kell megvizsgálni.

**Hogyan értékelhetem a 'nehéz' diákokat, amelyek lassíthatják a renderelést vagy a PDF‑exportálást?**

Nincs egyetlen összetettségi tulajdonság sem. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) elemeit, valamint minden dia [IBaseSlide.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getShapes--) gyűjteményét. Használja a forma‑számokat és a nagy képek, effektusok, animációk vagy multimédia jelenlétét szűrőjelzőként, és mérjen egy reprezentatív renderelést vagy exportálást, mielőtt a diát végleges teljesítménybottleneck‑nek tekintené.