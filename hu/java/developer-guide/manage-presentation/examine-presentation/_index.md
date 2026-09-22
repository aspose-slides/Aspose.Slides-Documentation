---
title: Prezentációs információ lekérése és frissítése Java-ban
linktitle: Prezentációs információ
type: docs
weight: 30
url: /hu/java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok beolvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel a diák, a felépítést és a metaadatokat PowerPoint és OpenDocument prezentációkban Java használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Aspose.Slides képes azonosítani egy prezentáció formátumát, és beolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez hasznos, ha fájlokat kell osztályozni, készíteni egy leltárt, vagy vizsgálni a tulajdonságokat, mielőtt eldöntené, hogy betölti-e és feldolgozza a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/) és az [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) segítségével, valamint a célzott frissítéseket az [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) használatával.

## **Ellenőrizze a prezentáció formátumát**

Ha már betöltött prezentációja van, lásd a [Determine the Original Presentation Format](/slides/hu/java/detect-presentation-source-format/) cikket a betöltés utáni meghatározáshoz és a régi PPT, PPS és POT folyamok korlátozásaihoz.

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust egy fájl ellenőrzéséhez anélkül, hogy a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt hozna létre. Az [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódus jelenti a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Könnyű prezentációs leltár felépítése**

Ha sok prezentációs fájlt dolgoz fel, szüksége lehet egy kompakt leltárra az érvényesítéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, hogy megszerezze az [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) objektumot, majd hívja a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltár értékeket adják:

| Módszer | Leltár érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSlides--) | A diák összes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getNotes--) | Megjegyzéseket tartalmazó diák száma. |
| [getParagraphs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | A bekezdések összes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getWords--) | A szavak összes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Az audio- és videoklipek összes száma. |

A következő példa ezeknek az értékeknek a beolvasását mutatja be anélkül, hogy a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat. Emellett kombinálja a [getHeadingPairs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) és a [getTitlesOfParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) használatát a tartalmi csoportok, például betűtípusok, sablonok és diacímek megjelenítéséhez.

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

Minden [IHeadingPair] egy csoportnevet és a csoportban lévő elemek számát adja meg. Az [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) egy lapos, rendezett tömböt ad vissza, ezért a csoportonként megadott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott leltár tulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt ezeknek az értékeknek az újraszámításához ebben a hívásban. A hiányzó tulajdonságokat alapértelmezett értékek képviselik, és a tárolt értékek elavultak lehetnek, ha az utoljára fájlt mentő alkalmazás nem frissítette a dokumentumtulajdonságait.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, megjegyzések, rejtett diák, bekezdések, szavak és multimédia számához, valamint a cípcsoportokhoz és a részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum képes tárolni a megfelelő dokumentum-összegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissítette a dokumentum előállítója, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, nem számolja ki a diák alapján.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldalak, bekezdések és szavak számát, de ezek az értékek nem térképezhetők minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett diák, megjegyzések, multimédia, cípcsoport és részcím metaadatai előfordulhatnak, hogy nem állnak rendelkezésre, és a leltár tulajdonságok alapértelmezett értéket adhatnak vissza. Ne tekintse a nulla értéket vagy egy üres tömböt bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat-kezelési megközelítést leltárak és előzetes ellenőrzések esetén. Töltse be a prezentációt, és ellenőrizze annak élő objektummodelljét, ha az eredménynek a memóriában lévő változásoknak is tükröződnie kell, vagy ha a tényleges prezentációs tartalmat kell ellenőriznie.

## **Prezentáció tulajdonságainak frissítése**

Az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) által visszaadott tulajdonságok szintén megváltoztathatók anélkül, hogy a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt létrehozná. Alkalmazza a változtatásokat az [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódussal, majd írja ki a kötött prezentációt az [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) metódussal.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

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

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd az alábbi cikkeket:

- [Password-Protect Presentations](/slides/hu/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Töltsd be a prezentációt, és használd a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getFontsManager--) metódust. Hívd meg az [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) metódust a beágyazott betűtípusok lekéréséhez, illetve az [IFontsManager.getFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getFonts--) metódust a prezentáció által használt betűtípusokhoz. Hasonlítsd össze a két eredményt, hogy megtaláld azokat a betűtípusokat, amelyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákat tartalmaz-e, és hány darabot?**

Ha a tárolt dokumentum metaadatai elegendőek, olvasd a [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) metódust a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével. Ez alkalmas egy könnyű leltárra. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy ha élő értékeket kell ellenőrizned, járd be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjteményt, és vizsgáld meg minden dia [ISlide.getHidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getHidden--) metódusát.

**Detektálhatom-e, hogy egyedi dia méret és orientáció van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Töltsd be a prezentációt, és hívd meg a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlideSize--) metódust. Használd az [ISlideSize.getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getSize--) és [ISlideSize.getOrientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#getOrientation--) metódusokat az aktuális beállítások összehasonlításához a várt előre beállított értékekkel és méretekkel.

**Van-e gyors módja annak, hogy megtudjam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keress minden [Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/) elemet, és hívd meg az [IChartData.getDataSourceType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getDataSourceType--) metódust. Külső munkafüzet esetén hívd meg az [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metódust. A adatforrás típusa és útvonala jelzi a külső hivatkozást, de annak elérhetőségének ellenőrzése külön erőforrásellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitási tulajdonság. Járd be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjteményt, és minden dia [IBaseSlide.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getShapes--) kollekcióját. Használj alakzat-számlálásokat, nagy képeket, effektusokat, animációkat vagy multimédiát szűrőjelzőként, és végezz egy reprezentatív renderelést vagy exportot, mielőtt a diát megerősített teljesítménybottlenecknek tekintenéd.