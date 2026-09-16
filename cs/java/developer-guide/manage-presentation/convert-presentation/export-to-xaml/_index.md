---
title: Export prezentací do XAML v Javě
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/java/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentace do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v Javě pomocí Aspose.Slides—rychlé řešení bez Office, které zachová vaši rozvržení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik běžných otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je jazyk pro popisování uživatelských rozhraní založený na XML, používaný v rámci frameworků jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním návrháři nebo přímo zapisovat a upravovat značky.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad v jazyce Java ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

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

Ve výchozím nastavení jsou exportované snímky uloženy do podsložky `pres` v aktuálním pracovním adresáři procesu, který je určen z prázdné cesty pomocí [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-). Složka je vytvořena automaticky a požadované obrázky jsou také uloženy zde.

Název výstupní složky je odvozen od názvu zdrojového souboru bez jeho přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dál. I když zadáte absolutní cestu ke vstupní prezentaci, výstupní složka je vytvořena relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Pro uložení výstupu na vlastní místo implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) a předávejte instanci vaší implementace metodě [setOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) rozhraní [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do XAML výstupu zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) s hodnotou `true`, jak je ukázáno v následujícím příkladu v jazyce Java:

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

Export do XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) k metodě [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) a získáte tyto artefakty místo použití výchozího ukládání do souborového systému. Spusťte export pomocí XAML‑specifické přetížené metody [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) která přijímá XAML možnosti.

### **Pochopení životního cyklu zpětných volání**

Exportér volá [IXamlOutputSaver.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Zachovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukládací komponenta je zodpovědná za uchování nebo trvalé uložení dat před návratem. Příklady kopírují každé pole bajtů do paměti vlastněné aplikací.
- Export považujte za úspěšný jen tehdy, když operace uložení prezentace skončí a všechny zpětné volání byly úspěšně dokončeny. Neskrývejte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se trvalé uložení provede později, hlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) se také vztahuje na vlastní ukládací komponentu. Výchozí nastavení `false` vylučuje XAML dokumenty skrytých snímků. Předáním hodnoty `true` je zahrnete spolu se všemi zdroji potřebnými pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden callback na snímek ani pevný pořadí callbacků.

### **Export do paměti a inspekce artefaktů**

Tento kompletní příklad načte `pres.pptx`, shromáždí každý artefakt do [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), a vypíše jeho název, typ a počet bajtů. Přesně zachovává poskytnuté názvy. Duplicitní názvy označují sbírku jako neplatnou místo tiše přepisovat artefakt. Příklad to ověří před použitím výsledků.

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

Kontroly rozšíření jsou užitečné pro inspekci; zachovejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. Použijte [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) s UTF‑8 pouze pro XAML, který vyžaduje textové zpracování.

### **Zabalení shromážděných artefaktů do ZIP archivu**

Tento samostatný příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu. Jedinečný název archivu odděluje souběžné exportní úlohy. ZIP položky používají dopředná lomítka a zachovávají relativní adresáře. Ne bezpečné názvy nebo názvy, které po normalizaci kolidují, odmítají celý balík před jeho zápisem.

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

    // ZIP adresář byl dokončen uzavřením před hlášením úspěchu.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Příklad používá [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) k zápisu jednoho lokálního archivu; exportér sám neukládá volné XAML nebo soubory s obrázky. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním shromážděných polí bajtů. Použijte identifikátor exportního úkolu plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úkolu, relativní název a binární data do řádku v databázi. Publikujte úkol až po dokončení všech nahrávek nebo po potvrzení transakce v databázi. Vyčistěte částečný výstup, pokud selže trvalé uložení.

U velkých prezentací může vlastní ukládací komponenta přímo ukládat každý artefakt do úložiště aplikace, aby se zabránilo zachování další kopie celého exportu v paměti aplikace. Udržujte každý callback synchronní z pohledu exportéru: vraťte se pouze po přijetí bajtů cílem a nechte chyby dorazit k volajícímu.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Nepoužívejte pouze [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) pokud není každé vygenerované jméno jedinečné a odkazy na zdroje zůstávají platné.
- Použijte specifickou validaci názvů pro cíl. Při zápisu volných souborů odmítejte kořenové cesty a segmenty pro průchod (../), vyřešte cíl pomocí [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), a ověřte, že zůstává pod zamýšleným exportním adresářem, včetně adresářového oddělovače v kontrole obsahování. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovávat zápisy.
- Použijte samostatný ukládací komponent a jmenný prostor úložiště pro každý exportní úkol. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikací analyzujte každý XAML dokument jako XML a prohlédněte jeho souborové odkazy na zdroje, jako jsou atributy obrázku `Source` nebo `ImageSource`. Vyřešte každé relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte výsledný název úložiště a potvrďte, že odpovídající klíč v mapě, ZIP položka nebo uložený objekt existuje. Zacházejte s externími URI a XAML výrazovými značkami odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být dostupný jako `pres/images/image1.png`. Zachování pouze `image1.png` by vztah narušilo. Pro objektové úložiště zachovejte stejnou strukturu pod prefixem úkolu a učinte tyto URL zdrojů přístupné pro XAML spotřebitele. Znovu otevřete dokončený ZIP a ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, aby bylo potvrzeno, že obrázky se správně vyřeší.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud originální font není na počítači dostupný?**

Zavolejte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/) . Používá se jako náhradní font během exportu, když originální chybí. To však nezaručuje, že vygenerovaný XAML bude odkazovat na náhradní font nebo že bude font dostupný na cílovém počítači. Ujistěte se, že fonty, na které XAML odkazuje, jsou v prostředí, kde je zobrazován, dostupné.

**Je exportovaný XAML určen pouze pro WPF, nebo lze jej použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerovaný značkový kód ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení jsou skryté snímky zahrnuty. Můžete toto chování řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) v [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/) . Nechte jej zakázáno, pokud nepotřebujete skryté snímky exportovat.