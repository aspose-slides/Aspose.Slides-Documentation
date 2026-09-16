---
title: Export Prezentací do XAML na Androidu
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/androidjava/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentaci do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- Android
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v Java pomocí Aspose.Slides pro Android — rychlé řešení bez Office, které zachová rozložení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides pro Android přes Java. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je jazyk založený na XML používaný k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním návrháři nebo psát a upravovat značky přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad v jazyce Java ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

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

Ve výchozím nastavení jsou exportované snímky uloženy v podsložce `pres` aktuálního pracovního adresáře procesu. Složka je vytvořena automaticky a všechny potřebné obrázky jsou tam také uloženy.

Název výstupní složky je odvozen od názvu zdrojového souboru bez přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když zadáte absolutní cestu k vstupní prezentaci, výstupní složka je vytvořena relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

Na Androidu použijte vstupní soubor, který je přístupný vaší aplikaci. Aktuální pracovní adresář nemusí být zapisovatelný; použijte vlastní výstupní ukladač, aby export zůstal v paměti nebo se zapsal do úložiště aplikace, jak je ukázáno níže. Vygenerovaný WPF XAML je určen pro kompatibilního spotřebitele a není zdrojem rozvržení pro Android.

## **Export prezentací do XAML s vlastními možnostmi**

Použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ixamloptions/) k řízení, jak Aspose.Slides exportuje prezentaci do XAML.

Pro uložení výstupu na vlastní umístění implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ixamloutputsaver/) a předáte instance své implementace metodě [setOutputSaver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) třídy [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do XAML výstupu zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) s hodnotou `true`, jak je ukázáno v následujícím příkladu v jazyce Java:

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

## **Zachycení všech vygenerovaných XAML artefaktů**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ixamloutputsaver/) metodě [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) abyste tyto artefakty získali místo výchozího ukladače souborového systému. Spusťte export pomocí specifické přetížení [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) , které přijímá XAML možnosti.

### **Pochopení životního cyklu zpětných volání**

Exportér volá [IXamlOutputSaver.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) odděleně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukladač je zodpovědný za zachování nebo trvalé uložení dat před návratem. Příklady kopírují každé pole bajtů do paměti vlastněné aplikací.
- Považujte export za úspěšný pouze tehdy, když operace uložení prezentace vrátí a každé zpětné volání dokončí úspěšně. Nezatajujte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se trvalé uložení provádí později, nahlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) se vztahuje také na vlastní ukladač. Výchozí nastavení, `false`, vylučuje XAML dokumenty skrytých snímků. Předání hodnoty `true` je zahrnuje i všechny zdroje potřebné pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jedno zpětné volání na snímek ani pevné pořadí volání.

### **Export do paměti a inspekce artefaktů**

Tento úplný příklad načítá `pres.pptx`, shromažďuje každý artefakt do [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), a vypisuje jeho název, typ a počet bajtů. Přesně zachovává poskytnuté názvy. Duplicitní názvy označují sbírku jako neplatnou místo tichého přepsání artefaktu. Příklad tuto podmínku kontroluje před použitím výsledků.

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

    // Dekódujte pouze XAML a pouze když je potřeba textová inspekce.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Kontroly přípon jsou užitečné pro inspekci; uchovejte všechny artefakty, včetně neznámých typů zdrojů. Nechte bajty beze změny při ukládání nebo přenosu. Používejte konstruktor [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) s UTF-8 pouze pro XAML, který vyžaduje textové zpracování.

### **Zabalení shromážděných artefaktů do ZIP archivu**

Tento nezávislý příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu. Nahraďte `/path/to/app/files` cestou vrácenou metodou [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) vašeho Android kontextu. Jedinečný název archivu odděluje souběžné exportní úlohy. Záznamy ZIP používají dopředná lomítka a zachovávají relativní adresáře. Nebezpečné názvy nebo názvy, které kolidují po normalizaci, odmítají celý balíček před zápisem.

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

    // Adresář ZIP byl dokončen uzavřením před oznámením úspěchu.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Příklad používá [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html), aby zapsal jeden místní archiv; samotný exportér neukládá volné XAML ani soubory obrázků. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním sesbíraných polí bajtů. Použijte identifikátor exportní úlohy plus celý relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávání nebo po zapsání transakce databáze. Vyčistěte částečný výstup, pokud ukládání selže.

U velkých prezentací může vlastní ukladač ukládat každý artefakt přímo do úložiště aplikace, aby se předešlo držení další kopie celého exportu v paměti aplikace. Udržujte každé zpětné volání synchronní z pohledu exportéra: vraťte se až poté, co cíl přijal bajty, a nechte selhání dosáhnout volajícího.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Nepoužívejte pouze [File.getName](https://developer.android.com/reference/java/io/File#getName()) , pokud není známo, že každý vygenerovaný název je jedinečný a odkazy na zdroje zůstávají platné.
- Použijte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte kořenové cesty a segmenty procházející adresáře, vyřešte cíl pomocí [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), a ověřte, že zůstává pod zamýšleným exportním adresářem, včetně oddělovače adresáře v kontrole obsahu. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Používejte samostatný ukladač a jmenný prostor úložiště pro každou exportní úlohu. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikováním analyzujte každý XAML dokument jako XML a kontrolujte jeho souborové reference na zdroje, například atributy `Source` nebo `ImageSource` obrázku. Vyřešte každé relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte vzniklý název úložiště a potvrďte, že odpovídající klíč v mapě, záznam ZIP nebo uložený objekt existuje. Zacházejte s externími URI a XAML značkovacími výrazy odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být k dispozici jako `pres/images/image1.png`. Zachování jen `image1.png` by vztah porušilo. Pro objektové úložiště zachovejte stejnou strukturu pod předponou úlohy a zpřístupněte tyto URL zdrojů pro XAML spotřebitele. Znovu otevřete dokončený ZIP a ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, aby bylo potvrzeno, že obrázky se správně resolve.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud původní font není na stroji dostupný?**

Zavolejte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/) — používá se jako náhradní font během exportu, když původní chybí. To nezaručuje, že vygenerovaný XAML bude odkazovat na náhradní font nebo že font bude k dispozici na cílovém stroji. Ujistěte se, že fonty odkazované v XAML jsou dostupné v prostředí, kde je zobrazeno.

**Je exportovaný XAML určen pouze pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerované značky ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) v [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/) — nechte jej vypnutý, pokud je nemusíte exportovat.