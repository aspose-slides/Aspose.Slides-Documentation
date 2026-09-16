---
title: "Prezentációk exportálása XAML‑ba Java‑ban"
linktitle: "Prezentáció XAML‑ba"
type: docs
weight: 30
url: /hu/java/export-to-xaml/
keywords:
- "PowerPoint exportálása"
- "OpenDocument exportálása"
- "prezentáció exportálása"
- "PowerPoint konvertálása"
- "OpenDocument konvertálása"
- "prezentáció konvertálása"
- "PowerPoint XAML‑ba"
- "OpenDocument XAML‑ba"
- "prezentáció XAML‑ba"
- "PPT XAML‑ba"
- "PPTX XAML‑ba"
- "ODP XAML‑ba"
- "PPT mentése XAML‑ként"
- "PPTX mentése XAML‑ként"
- "ODP mentése XAML‑ként"
- "PPT exportálása XAML‑ba"
- "PPTX exportálása XAML‑ba"
- "ODP exportálása XAML‑ba"
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument diákat konvertál XAML‑ba Java‑ban az Aspose.Slides használatával – gyors, Office‑független megoldás, amely megőrzi a megjelenést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat XAML formátumba exportálni az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑ba, megmutatja, hogyan menthető egy prezentáció XAML‑ba alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/), beleértve a rejtett diák exportálását is. A cikk néhány gyakori kérdésre is válaszol a tartalék betűtípusokkal, a XAML‑verem kompatibilitással és a rejtett diák exportálásának viselkedésével kapcsolatban.

## **A XAML‑ról**

A XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML‑fájlokkal vizuális tervezőben dolgozhatsz, vagy a jelölést közvetlenül írhatod és szerkesztheted.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Az alábbi Java‑példa megmutatja, hogyan exportálható egy prezentáció XAML‑ba alapértelmezett beállításokkal:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Alapértelmezés szerint az exportált diákat egy `pres` almappába menti a folyamat aktuális munkakönyvtárában, amely egy üres útból kerül feloldásra a [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) segítségével. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek mentésre.

A kimeneti mappa neve a forrásfájl névéről származik kiterjesztés nélkül. A `pres.pptx` esetén a kimeneti fájlok neve `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút útvonalat adsz meg a bemeneti prezentációhoz is, a kimeneti mappa az aktuális munkakönyvtárhoz relatív módon jön létre, nem a bemeneti fájl mellett.

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

Használd az [IXamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloptions/) interfészt annak vezérlésére, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.

A kimenet egyéni helyre mentéséhez valósítsd meg az [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/) interfészt, és add át az implementációdat a [setOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/)‑on keresztül.

A rejtett diák XAML‑kimenetbe való belefoglalásához hívd meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) metódust `true` értékkel, ahogyan az alábbi Java‑példa mutatja:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Minden generált XAML‑eszköz összegyűjtése**

Egy XAML‑exportálás minden exportált diáról XAML dokumentumot, valamint külön képeket és segédforrásokat hozhat létre. Rendelj egy egyedi [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/)‑t a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-)‑nek, hogy ezeket az eszközöket a alapértelmezett fájlrendszer‑mentő helyett kapd meg. Indítsd az exportálást a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) metódussal, amely XAML‑beállításokat fogad.

### **A visszahívási életciklus megértése**

Az exportáló külön meghívja a [IXamlOutputSaver.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metódust minden generált eszközre:

- `path` azonosítja az eszközt, és tartalmazhat relatív almappákat. Őrizd meg ezt az információt, mert a XAML relatív útvonalakkal hivatkozhat erőforrásokra.
- `data` az eszköz bájtjait tartalmazza. A képeket és egyéb bináris erőforrásokat ne dekódold szövegként.
- A mentő feladata, hogy a visszatérés előtt megtartsa vagy elmentse az adatot. A példák minden bájt‑tömböt alkalmazás‑tulajdonú memóriába másolnak.
- Az exportot csak akkor tekintsd sikeresnek, ha a prezentáció mentése visszatér, és minden visszahívás sikeresen befejeződik. Ne nyelj el tárolási hibákat, és ne indíts megfigyelés nélküli háttér‑írásokat. Ha a tartósítás később történik, az összesített sikert csak akkor jelentsd, ha az a lépés is sikeres.

A [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ugyanúgy érvényes egy egyéni mentőre is. Az alapértelmezett érték, `false`, kizárja a rejtett diák XAML dokumentumait. `true` megadása belefoglalja őket és minden exporthoz szükséges erőforrást. Az erőforrás‑szám a prezentációtól függ; ne feltételezd, hogy diánként egy visszahívás vagy fix sorrend van.

### **Exportálás memóriába és az eszközök vizsgálata**

Ez a teljes példa betölti a `pres.pptx`‑t, minden eszközt egy [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)‑ba gyűjt, és kiírja a nevét, típusát és bájtszámát. Pontosan megőrzi a megadott neveket. Az ismétlődő nevek a gyűjteményt érvénytelennek jelzik a csendes felülírás helyett. A példa ezt ellenőrzi a használat előtt.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Csak XAML-t dekódolj, és csak akkor, ha szöveges ellenőrzés szükséges.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

A kiterjesztés‑ellenőrzések hasznosak a vizsgálathoz; tartsd meg az összes eszközt, beleértve az ismeretlen típusú erőforrásokat is. A bájtokat változtatás nélkül tárold vagy továbbítsd. Csak XAML‑szöveg feldolgozásához használd a [String konstruktorát](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) UTF‑8‑kal.

### **Gyűjtött eszközök csomagolása ZIP‑archívumban**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és az eredeti bájtokat egy ZIP‑archívumba írja. Egy egyedi archívum‑név választja el a párhuzamos export‑feladatokat. A ZIP‑bejegyzések előre‑húzott perjeleket használnak, és megtartják a relatív almappákat. Nem biztonságos nevek vagy a normalizálás után ütköző nevek a teljes csomag írása előtt elutasításra kerülnek.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // A ZIP könyvtár a siker jelentése előtt a lezárással lett befejezve.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

A példa a [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html)‑t használja egy helyi archívum írásához; maga az exportáló nem ír laza XAML‑ vagy képfájlokat. Távoli tároláshoz cseréld le az archívum‑írást a gyűjtött bájt‑tömbök feltöltésére. Használj export‑feladat‑azonosítót és a teljes relatív eszköz‑nevet blob‑kulcsként, vagy tárold a feladat‑azonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor tedd közzé, ha minden feltöltés befejeződött vagy a tranzakció elköteleződött. Ha a tartósítás meghiúsul, tisztítsd meg a részleges kimenetet.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás‑tárolóba mentheti az egyes eszközöket, így elkerülve a teljes export másolatának memóriában tartását. Tartsd a visszahívásokat szinkronban az exportáló nézőpontjából: csak akkor térj vissza, ha a célpont elfogadta a bájtokat, és engedd, hogy a hibák eljussanak a hívóhoz.

### **Erőforrás‑nevek megőrzése és hivatkozások ellenőrzése**

- Normalizáld az útvonal‑elválasztókat a cél igényei szerint, de tartsd meg a relatív almappákat. Ne csak a [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--)‑t használd, kivéve ha minden generált név egyedi és a hivatkozások érvényesek.
- Alkalmazz cél‑specifikus név‑validálást. Laza fájlok írásakor vedd el a gyökér‑útvonalakat és a navigációs szegmenseket, oldd fel a célt a [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--)‑val, és ellenőrizd, hogy az a tervezett export‑könyvtár alatt marad‑e, beleértve a könyvtár‑elválasztót a tartalmazási ellenőrzésben. Használj olyan alkalmazás‑vezérelt könyvtárat, amelynek nincsenek szimbolikus linkjei, amelyek átirányíthatják az írásokat.
- Minden export‑feladathoz használj külön mentőt és tárolási névtér‑prefixet. Detektáld az ütközéseket a szeparátor‑normalizálás után és a cél‑eset‑érzékenységi szabályok szerint.
- Közzététel előtt elemezd minden XAML‑dokumentumot XML‑ként, és vizsgáld meg a fájl‑alapú erőforrás‑hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútumait. Oldd fel minden relatív URI‑t a tartalmazó XAML‑eszköz könyvtárához képest, normalizáld a kapott tárolási nevet, és ellenőrizd, hogy a megfelelő map‑kulcs, ZIP‑bejegyzés vagy tárolt objektum létezik‑e. Kezelj külön a külső URI‑kat és a XAML‑mark-up kifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, akkor a tárolt erőforrásnak `pres/images/image1.png`‑ként kell elérhetőnek lennie. Ha csak `image1.png` marad, a kapcsolat megszakad. Objektumtárolás esetén tartsd meg ugyanazt a struktúrát a feladat‑előtag alatt, és tedd elérhetővé ezeket a URL‑eket a XAML‑fogyasztó számára. Nyisd meg újra a kész ZIP‑et a bejegyzés‑nevek és erőforrás‑bájtok ellenőrzéséhez, és tölts be reprezentatív diákat a cél‑XAML‑környezetben, hogy megerősítsd a képek helyes feloldását.

## **GYIK**

**Hogyan biztosítható, hogy a betűtípusok kiszámíthatóak legyenek, ha az eredeti betűtípus nem érhető el a gépen?**

Hívd meg a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/)-on – ez a fallback betűtípusként kerül használatra az export során, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a fallback betűtípust hivatkozza, vagy hogy a betűtípus elérhető legyen a célgépen. Biztosítsd, hogy a XAML által hivatkozott betűtípusok jelen legyenek a megjelenítő környezetben.

**Az exportált XAML csak WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

Az Aspose.Slides a WPF XAML‑t exportálja a nyilvános API‑ján keresztül. Más XAML‑veremekkel, például az UWP‑vel vagy a Xamarin.Forms‑szal való kompatibilitás nincs garantálva. Teszteld a generált jelölést a cél környezetben.

**Támogatottak a rejtett diák, és hogyan lehet megakadályozni, hogy alapértelmezés szerint exportálásra kerüljenek?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) segítségével szabályozhatod a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/)‑ban – tartsd letiltva, ha nincs szükséged a exportálásukra.