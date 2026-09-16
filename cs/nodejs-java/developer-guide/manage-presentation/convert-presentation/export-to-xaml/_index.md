---
title: Export prezentací do XAML v JavaScriptu
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v JavaScriptu pomocí Aspose.Slides - rychlé řešení bez Office, které zachovává rozvržení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozím nastavením, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek vztahujících se k náhradním fontům, kompatibilitě XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je jazyk založený na XML, který se používá k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S XAML soubory můžete pracovat ve vizuálním návrháři nebo psát a upravovat značkování přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad JavaScriptu ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Ve výchozím nastavení jsou exportované snímky uloženy v podsložce `input` pracovního adresáře procesu. Složka je vytvořena automaticky a všechny potřebné obrázky jsou také uloženy tam.

Název výstupní složky je odvozen od názvu zdrojového souboru bez přípony. V Aspose.Slides pro Node.js via Java 26.8 export `input.pptx` vytvoří vnořenou cestu jako `input/input/Slide_1.xaml`. Při práci s výstupem zachovejte kompletní vygenerované cesty. Výchozí výstup je relativní k aktuálnímu pracovnímu adresáři, nikoli nutně vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Pro uložení výstupu na vlastní umístění implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) a předávejte instanci vaší implementace metodě [setOutputSaver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) třídy [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do XAML výstupu zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `true`, jak je ukázáno v následujícím příkladu JavaScriptu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Zachycení všech vygenerovaných XAML artefaktů**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/) k metodě [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/#setOutputSaver), abyste tyto artefakty získali místo výchozího ukladače souborového systému. Spusťte export pomocí XAML‑specifické přetížení [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save), které přijímá XAML možnosti.

V Node.js implementujte Java rozhraní pomocí `java.newProxy` z balíčku `java` používaného Aspose.Slides. Udržujte proxy dosažitelný až do dokončení exportu.

### **Porozumění životnímu cyklu zpětných volání**

Exportér volá [IXamlOutputSaver.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukladač je zodpovědný za zachování nebo ukládání dat před návratem. Příklady kopírují každé Java pole bajtů do bufferu vlastněného aplikací v Node.js.
- Export považujte za úspěšný jen tehdy, když operace uložení prezentace vrátí a každé zpětné volání dokončí úspěšně. Nepodceňujte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se perzistence provádí později, hlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) také platí pro vlastní ukladač. Výchozí nastavení `false` vylučuje XAML dokumenty skrytých snímků. Předání `true` je zahrne a všechny zdroje potřebné pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden zpětný volací bod na snímek nebo pevné pořadí zpětných volání.

### **Export do paměti a kontrola artefaktů**

Tento kompletní příklad načte `input.pptx`, shromáždí každý artefakt do mapy JavaScriptu názvů na buffery a vypíše jeho název, typ a počet bajtů. Zachovává poskytnuté názvy přesně. Duplicitní názvy označují kolekci jako neplatnou místo tichého přepsání artefaktu. Příklad tuto situaci kontroluje před použitím výsledků.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Dekódujte pouze XAML a pouze když je potřeba textová inspekce.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Kontroly přípon jsou užitečné při inspekci; zachovejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. Používejte dekódování UTF-8 pouze pro XAML, který potřebuje textové zpracování.

### **Zabalit shromážděné artefakty do ZIP archivu**

Tento samostatný příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu pomocí Java mostu. ZIP je sestaven v paměti před uložením na disk. Jedinečný název archivu odděluje souběžné úlohy exportu. ZIP položky používají dopředná lomítka a zachovávají relativní adresáře. Neplatné názvy nebo názvy kolidující po normalizaci odmítnou celý balíček před jeho zápisem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Uzavření dokončuje adresář ZIP před tím, než je archiv uložen.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Příklad používá [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) k zápisu jednoho lokálního archivu; samotný exportér nezapisuje volné XAML nebo obrázkové soubory. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráváním shromážděných polí bajtů. Použijte identifikátor úlohy exportu plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení transakce v databázi. Vyčistěte částečný výstup, pokud perzistence selže.

Pro velké prezentace může vlastní ukladač perzistentně ukládat každý artefakt přímo do úložiště aplikace, aby se zabránilo držení další kopie celého exportu v paměti aplikace. Uchovávejte každé zpětné volání synchronní z perspektivy exportéru: vraťte se až poté, co cíl přijal bajty, a umožněte selhání dorazit k volajícímu.

### **Zachovat názvy zdrojů a ověřit odkazy**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovávejte relativní adresáře. Nepoužívejte pouze základní název, pokud není známo, že každý vygenerovaný název je jedinečný a odkazy na zdroje zůstávají platné.
- Použijte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte absolutní cesty a segmenty `..`, převeďte cíl na absolutní cestu a ověřte, že zůstává pod zamýšleným výstupním adresářem, včetně oddělovače adresáře v kontrole obsahu. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Používejte samostatný ukladač a jmenný prostor úložiště pro každou úlohu exportu. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikací parsujte každý XAML dokument jako XML a prověřte jeho odkazy na soubory zdrojů, například atributy `Source` nebo `ImageSource` obrázku. Rozřešte každé relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte vzniklý název úložiště a potvrďte, že odpovídající klíč v mapě, ZIP položka nebo uložený objekt existuje. Externí URI a XAML výrazové konstrukce zacházejte odděleně od relativních názvů souborů.

Například pokud `input/Slide_1.xaml` odkazuje na `images/image1.png`, musí být uložený zdroj dostupný jako `input/images/image1.png`. Pouze `image1.png` by narušilo tento vztah. Pro objektové úložiště zachovejte stejnou strukturu pod prefixem úlohy a zpřístupněte tyto URL zdrojům pro XAML spotřebitele. Po otevření dokončeného ZIP ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, aby se potvrdilo správné rozpoznání obrázků.

## **Často kladené otázky**

**Jak mohu zajistit predikovatelné fonty, pokud originální font není na stroji dostupný?**

Vyvolejte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/) — používá se jako náhradní font během exportu, když originál chybí. To však nezaručuje, že generovaný XAML bude odkazovat na náhradní font nebo že font bude dostupný na cílovém zařízení. Zajistěte, aby fonty odkazované XAML byly dostupné v prostředí, kde se zobrazuje.

**Je exportovaný XAML určen pouze pro WPF, nebo lze jej použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s ostatními XAML stacky, jako jsou UWP a Xamarin.Forms, není garantována. Otestujte vygenerované značkování v cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) v [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/) — ponechte jej zakázáno, pokud nepotřebujete skryté snímky exportovat.