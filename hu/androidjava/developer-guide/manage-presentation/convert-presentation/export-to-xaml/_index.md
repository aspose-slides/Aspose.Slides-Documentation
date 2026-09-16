---
title: Prezentációk exportálása XAML-be Androidon
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/androidjava/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument diákot XAML-be Java-ban az Aspose.Slides for Android segítségével—gyors, Office-mentes megoldás, amely megőrzi a layoutot."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók a PowerPoint‑prezentációk XAML formátumba az Aspose.Slides for Android Java‑n keresztül. Tartalmaz egy rövid bevezetést a XAML‑be, megmutatja, hogyan menthető a prezentáció XAML‑be alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk válaszol néhány gyakori kérdésre is, amelyek a helyettesítő betűtípusokra, a XAML verem kompatibilitására és a rejtett diák export viselkedésére vonatkoznak.

## **A XAML‑ról**

A XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML fájlokkal dolgozhat vizuális tervezőben, vagy közvetlenül írhatja és szerkesztheti a jelölőt.

## **Prezentációk exportálása XAML‑be alapértelmezett beállításokkal**

Az alábbi Java példa megmutatja, hogyan exportáljon egy prezentációt XAML‑be alapértelmezett beállításokkal:

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

Alapértelmezés szerint az exportált diák a folyamat jelenlegi munkakönyvtárának `pres` almappájába kerülnek mentésre. A mappa automatikusan létrejön, és a szükséges képek is oda mentődnek.

A kimeneti mappa neve a forrásfájl neve kiterjesztés nélkül kerül meghatározásra. A `pres.pptx` esetén a kimeneti fájlok neve `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút elérési utat ad is a bemeneti prezentációhoz, a kimeneti mappa a jelenlegi munkakönyvtárhoz képest relatív módon jön létre, nem a bemeneti fájl mellett.

Androidon használjon olyan bemeneti fájlt, amely elérhető az alkalmazás számára. A jelenlegi munkakönyvtár nem feltétlenül írható; használjon egy egyéni kimeneti mentőt, hogy a exportot memóriában tartsa vagy az alkalmazás tárolójába írja, ahogy az alább látható. A generált WPF XAML kompatibilis fogyasztó számára készült, és nem Android elrendezés erőforrás.

## **Prezentációk exportálása XAML‑be egyedi beállításokkal**

Használja az [IXamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ixamloptions/) interfészt annak szabályozására, hogy az Aspose.Slides hogyan exportálja a prezentációt XAML‑be.

A kimenet egyedi helyre mentéséhez valósítsa meg az [IXamlOutputSaver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ixamloutputsaver/) interfészt, és adja át a példányát a [setOutputSaver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/) objektumban.

A rejtett diák XAML kimenetbe való belefoglalásához hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) metódust `true` értékkel, ahogyan az alábbi Java példában látható:

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

## **Minden generált XAML‑artefaktum rögzítése**

Egy XAML export minden exportált dia számára egy XAML dokumentumot, valamint különálló képeket és támogató erőforrásokat hozhat létre. Rendelj egy egyéni [IXamlOutputSaver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ixamloutputsaver/) példányt a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) metódushoz, hogy ezeket az artefaktumokat megkapja az alapértelmezett fájlrendszer‑mentő helyett. Indítsa el az exportot a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) overloaddal, amely XAML beállításokat fogad.

### **A visszahívás életciklusának megértése**

Az exportáló a [IXamlOutputSaver.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metódust külön hívja meg minden generált artefaktumra:

- `path` azonosítja az artefaktumot, és tartalmazhat relatív könyvtárakat. Tartsuk meg ezt az információt, mivel a XAML relatív útvonalakkal hivatkozhat erőforrásokra.
- `data` az artefaktum bájtjait tartalmazza. A képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- A mentő felelős az adatok megtartásáért vagy tartós tárolásért, mielőtt visszatér. A példák minden bájt tömböt az alkalmazás által birtokolt memóriába másolnak.
- Az exportot csak akkor tekintse sikeresnek, ha a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyomjon el tárolási hibákat, és ne indítson észrevétlen háttérírásokat. Ha a tartósítás később történik, az összesített sikert csak akkor jelentse, ha ez a lépés is sikeres.

A [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) szintén egyéni mentőre vonatkozik. Az alapértelmezett beállítás, `false`, kizárja a rejtett diák XAML dokumentumait. A `true` átadása belefoglalja őket és minden exportáláshoz szükséges erőforrást. Az erőforrások száma a prezentációtól függ; ne feltételezze, hogy minden diához egy visszahívás vagy fix visszahívási sorrend tartozik.

### **Exportálás memóriába és az artefaktumok ellenőrzése**

Ez a komplett példa betölti a `pres.pptx` fájlt, összegyűjti az összes artefaktumot egy [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) struktúrába, és kiírja a nevét, típusát és bájt számlálóját. Pontosan megőrzi a megadott neveket. A duplikált nevek érvénytelennek jelölik a gyűjteményt ahelyett, hogy csendben felülírnák az artefaktumot. A példa ezt ellenőrzi, mielőtt az eredményeket használná.

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

    // Dekódolja csak a XAML-t, és csak akkor, ha szöveges ellenőrzésre van szükség.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

A kiterjesztés‑ellenőrzések hasznosak az ellenőrzéshez; tartsuk meg az összes artefaktumot, beleértve az ismeretlen erőforrás típusokat is. A bájtokat változatlanul kell hagyni tárolás vagy továbbítás során. Az [String konstruktor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) csak UTF‑8 kódolással használható olyan XAML esetén, amely szöveges feldolgozást igényel.

### **Az összegyűjtött artefaktumok csomagolása ZIP archívumba**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és az eredeti bájtokat egy ZIP archívumba írja. Cserélje le a `/path/to/app/files` útvonalat az Android kontextus [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) metódusa által visszaadott útvonalra. Egy egyedi archívumnév elválasztja a párhuzamos export feladatokat. A ZIP bejegyzések perjeleket használnak, és megtartják a relatív könyvtárakat. A nem biztonságos nevek vagy a normalizálás után ütköző nevek elutasítják a teljes csomagot, mielőtt az íródna.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // A ZIP könyvtár a siker jelentése előtt a lezárással lett finalizálva.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

A példa a [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) osztályt használja egy helyi archívum írásához; az exportáló maga nem ír szétválasztott XAML vagy kép fájlokat. Távoli tároláshoz cserélje le az archívum‑írási lépést a gyűjtött bájt tömbök feltöltésére. Használjon export feladat azonosítót plusz a teljes relatív artefaktum nevet blob kulcsként, vagy tárolja a feladat azonosítót, relatív nevet és bináris adatot egy adatbázis sorban. A feladatot csak akkor tegye közzé, ha minden feltöltés befejeződött vagy az adatbázis tranzakció commit‑olt. Tisztítsa meg a részleges kimenetet, ha a tartósítás meghiúsul.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás tárolójába írhatja az egyes artefaktumokat, elkerülve ezzel a teljes export további másolatának tárolását az alkalmazás memóriájában. Tartsa minden visszahívást szinkronnak az exportáló szemszögéből: csak akkor térjen vissza, ha a célpont elfogadta a bájtokat, és engedje, hogy a hibák eljussanak a hívóhoz.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizálja az útvonal‑elválasztókat, ha a célpont ezt igényli, de tartsa meg a relatív könyvtárakat. Ne használja kizárólag a [File.getName](https://developer.android.com/reference/java/io/File#getName()) metódust, kivéve ha minden generált név egyedi és az erőforrás hivatkozások érvényesek.
- Alkalmazzon célpont‑specifikus névvalidációt. Szétválasztott fájlok írásakor utasítsa el a gyökér‑útvonalakat és a traverszálás szegmenseket, oldja fel a célhelyet a [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) segítségével, és ellenőrizze, hogy a kívánt export könyvtár alatt marad‑e, beleértve a könyvtár elválasztót a tartalmazás ellenőrzésben. Használjon alkalmazás által vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatják az írásokat.
- Minden export feladathoz használjon külön mentőt és tárolási névteret. Ütközéseket a szeparátor normalizálása után és a célpont kis‑ és nagybetű érzékenységi szabályai szerint detektáljon.
- Közzététel előtt elemezze minden XAML dokumentumot XML‑ként, és ellenőrizze a fájl‑alapú erőforrás hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútumokat. Oldja fel minden relatív URI‑t a tartalmazó XAML artefaktum könyvtárához képest, normalizálja a kapott tárolási nevet, és erősítse meg, hogy a megfelelő térkép kulcs, ZIP bejegyzés vagy tárolt objektum létezik. Kezelje külön a külső URI‑kat és a XAML jelölő kifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png` képre hivatkozik, a tárolt erőforrásnak `pres/images/image1.png` néven kell elérhetőnek lennie. Csak az `image1.png` megtartása megszakítaná ezt a kapcsolatot. Objektumtárolás esetén őrizze meg ugyanazt a felépítést a feladat előtag alatt, és tegye ezeket az erőforrás URL‑eket elérhetővé a XAML fogyasztó számára. Nyissa újra a befejezett ZIP‑et a bejegyzésnevek és erőforrás bájtok ellenőrzéséhez, és töltsön be példadiákat a cél XAML környezetben, hogy megerősítse a képek helyes feloldását.

## **GYIK**

**Hogyan biztosítható a prediktív betűtípus, ha az eredeti betűtípus nem érhető el a gépen?**

Hívja meg a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/) objektumban — ez a hiányzó eredeti betűtípus helyett használatos visszalépő betűtípus exportáláskor. Ez nem garantálja, hogy a generált XAML a visszalépő betűtípust hivatkozza, vagy hogy a betűtípus elérhető legyen a célgépen. Győződjön meg róla, hogy a XAML által hivatkozott betűtípusok rendelkezésre állnak a megjelenítő környezetben.

**Az exportált XAML csak WPF‑hez szánt, vagy használható más XAML stackekkel is?**

Az Aspose.Slides a nyilvános API‑ján keresztül WPF XAML‑t exportál. Más XAML stackekkel, például az UWP‑vel vagy a Xamarin.Forms‑szal való kompatibilitás nem garantált. Tesztelje a generált jelölőt a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan lehet megakadályozni, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) metódussal a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/) objektumban szabályozhatja — hagyja tiltva, ha nem szükséges az exportálásuk.