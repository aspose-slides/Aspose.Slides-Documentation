---
title: Export prezentací do XAML v PHP
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Převést snímky PowerPoint a OpenDocument do XAML pomocí Aspose.Slides pro PHP přes Java — rychlé řešení bez Office, které zachová váš rozvržení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik často kladených otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je jazyk založený na XML, který se používá k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním návrháři nebo psát a upravovat značkovací jazyk přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad v PHP ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními. Inicializujte PHP Java Bridge a načtěte `aspose.slides.php` před spuštěním příkladů v tomto článku. Umístěte `pres.pptx` do pracovního adresáře serveru Java Bridge, nebo uveďte absolutní cestu přístupnou pro tento server.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Ve výchozím nastavení jsou exportované snímky uloženy do podsložky `pres` aktuálního pracovního adresáře serveru Java Bridge. Složka je vytvořena automaticky a všechny potřebné obrázky jsou do ní také uloženy.

Název výstupního adresáře je odvozen od názvu vstupního souboru bez jeho přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když zadáte absolutní cestu k vstupní prezentaci, výstupní adresář je vytvořen relativně k aktuálnímu pracovnímu adresáři serveru Java Bridge, nikoli vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Pro uložení výstupu na vlastní umístění poskytněte Java proxy implementující [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) a předávejte instanci vaší implementace metodě [setOutputSaver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/#setOutputSaver) rozhraní [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do XAML výstupu zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `true`, jak ukazuje následující příklad v PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Zachyťte všechny vygenerované XAML artefakty**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podporující zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) k [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/#setOutputSaver), abyste tyto artefakty získali místo výchozího souborového ukladače. Spusťte export pomocí XAML‑specifického přetížení [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save), které přijímá XAML možnosti.

Funkce `java_closure` v PHP Java Bridge zpřístupňuje PHP objekt jako Java rozhraní. Uchovávejte jak PHP ukladač, tak jeho proxy aktivní, dokud export nedokončí. Odkazy rozhraní ukazují na Java API implementované proxy.

### **Pochopte životní cyklus zpětných volání**

Exportér volá [IXamlOutputSaver::save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukladač je zodpovědný za zachování nebo trvalé uložení dat před návratem. Příklady převádějí každý Java byte array do PHP binárního řetězce vlastněného aplikací.
- Export považujte za úspěšný jen tehdy, když operace uložení prezentace vrátí a všechny zpětné volání skončí úspěšně. Neschopnost ukládání nesmí být potlačena ani nesmí se spouštět nepozorované zápisy na pozadí. Pokud se trvalé uložení provede později, celkový úspěch hlaste až po úspěšném dokončení i tohoto kroku.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) se vztahuje i na vlastní ukladač. Výchozí nastavení `false` vylučuje XAML dokumenty skrytých snímků. Předáním hodnoty `true` je zahrnete i všechny zdroje potřebné pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden zpětný volání na snímek ani pevně dané pořadí volání.

### **Exportujte do paměti a prohlédněte artefakty**

Tento kompletní příklad načte `pres.pptx`, shromáždí každý artefakt do PHP asociativního pole binárních řetězců a vytiskne jeho název, typ a počet bajtů. Přesně zachovává dodané názvy. Duplicitní názvy označují kolekci jako neplatnou místo tichého přepsání artefaktu. Příklad tuto situaci kontroluje před použitím výsledků.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Pouze XAML je považován za UTF-8 text pro volitelnou inspekci.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Kontroly přípon jsou užitečné při inspekci; uchovávejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. PHP řetězce dokážou uchovat binární data, včetně nulových bajtů. Řetězec považujte za UTF‑8 text pouze při inspekci XAML; nekódujte obrázky ani zdroje.

### **Zabalte shromážděné artefakty do ZIP archivu**

Tento nezávislý příklad shromažďuje export, ověřuje názvy a zapisuje původní bajty do ZIP archivu. Exkluzivně vytvořený adresář úlohy odděluje souběžné exportní úlohy. Příklad vyžaduje PHP rozšíření Phar s podporou ZIP. ZIP položky používají dopředná lomítka a zachovávají relativní adresáře. Neplatné názvy nebo názvy kolidující po normalizaci odmítají celý balík před jeho zápisem.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Příklad používá [PharData](https://www.php.net/manual/en/class.phardata.php) k zápisu jednoho lokálního ZIP archivu v pracovním adresáři PHP procesu; samotný exportér neukládá volné XAML nebo obrázkové soubory. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním shromážděných binárních řetězců. Použijte identifikátor export‑úlohy plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Úlohu publikujte až po dokončení všech nahrávek nebo po potvrzení transakce v databázi. Při selhání perzistence odstraňte částečný výstup.

U velkých prezentací může vlastní ukladač trvale uložit každý artefakt přímo do úložiště aplikace, aby se předešlo držení další kopie celého exportu v paměti aplikace. Zachovejte každé zpětné volání synchronní z pohledu exportéra: vraťte se až poté, co cíl přijal bajty, a nechte chyby dopadnout až k volajícímu.

### **Zachovejte názvy zdrojů a ověřte odkazy**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Nepoužívejte pouze [basename](https://www.php.net/manual/en/function.basename.php), pokud není jisté, že každý vygenerovaný název je jedinečný a odkazy na zdroje zůstávají platné.
- Aplikujte ověření názvů specifické pro cíl. Při zápisu volných souborů odmítejte kořenové cesty a úseky vedoucí mimo adresář, převeďte cíl na absolutní cestu a ověřte, že zůstává pod zamýšleným exportním adresářem, včetně oddělovače adresáře při kontrole obsahu. Používejte adresář řízený aplikací, bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Používejte samostatný ukladač a jmenný prostor úložiště pro každou exportní úlohu. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikováním analyzujte každý XAML dokument jako XML a prohlédněte jeho souborové odkazy na zdroje, například atributy `Source` nebo `ImageSource`. Vyřešte každé relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte výsledný název úložiště a potvrďte, že odpovídající klíč mapy, ZIP položka nebo uložený objekt existuje. Zpracovávejte externí URI a XAML výrazové konstrukce odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, musí být uložený zdroj dostupný jako `pres/images/image1.png`. Pouze `image1.png` by vztah narušilo. Pro objektové úložiště zachovejte stejnou strukturu pod předponou úlohy a zpřístupněte tyto URL zdrojům XAML spotřebiteli. Otevřete znovu vytvořený ZIP a ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, aby se potvrdilo správné rozpoznání obrázků.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelná písma, pokud originální písmo není na počítači k dispozici?**

Zavolejte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/) — používá se jako náhradní písmo během exportu, když originál chybí. To však nezaručuje, že vygenerovaný XAML bude odkazovat na náhradní písmo nebo že písmo bude na cílovém počítači k dispozici. Zajistěte, aby písma odkazovaná v XAML byla dostupná v prostředí, kde je XAML zobrazován.

**Je exportovaný XAML určen jen pro WPF, nebo ho lze použít i v jiných XAML stackách?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerovaný značkovací jazyk ve svém cílovém prostředí.

**Jsou podporovány skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) v [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/) — nechte jej zakázaný, pokud je nechcete exportovat.