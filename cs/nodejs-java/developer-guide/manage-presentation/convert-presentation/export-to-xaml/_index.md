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
description: "Převod snímků PowerPoint a OpenDocument do XAML v JavaScriptu pomocí Aspose.Slides—rychlé řešení bez Office, které zachovává rozvržení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik běžných otázek týkajících se náhradních písem, kompatibility XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je jazyk značkování založený na XML, který se používá k popisu uživatelských rozhraní v rámci jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

S soubory XAML můžete pracovat ve vizuálním návrháři nebo psát a upravovat značky přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Následující příklad v JavaScript ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

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

Ve výchozím nastavení jsou exportované snímky uloženy v podadresáři `input` aktuálního pracovního adresáře procesu. Tento adresář je vytvořen automaticky a všechny potřebné obrázky jsou také uloženy zde.

Název výstupního adresáře je odvozen od názvu zdrojového souboru bez přípony. V Aspose.Slides pro Node.js přes Java 26.8 export `input.pptx` vytváří vnoženou cestu například `input/input/Slide_1.xaml`. Při zpracování výstupu zachovejte kompletní vygenerované cesty. Výchozí výstup je relativní k aktuálnímu pracovnímu adresáři, nikoli nutně vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Pro řízení toho, jak Aspose.Slides exportuje prezentaci do XAML, použijte rozhraní [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/).

Chcete‑li uložit výstup na vlastní umístění, implementujte [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) a předáte instanci vaší implementace metodě [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) třídy [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do výstupu XAML zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `true`, jak je ukázáno v následujícím příkladu v JavaScriptu:

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

## **Zachycení všech vygenerovaných artefaktů XAML**

Export do XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) metodě [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver), abyste tyto artefakty získali místo výchozího ukládání do souborového systému. Zahajte export pomocí XAML‑specifického přetížení [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save), které přijímá XAML možnosti.

V Node.js implementujte Java rozhraní pomocí `java.newProxy` z balíčku `java`, který používá Aspose.Slides. Udržujte proxy dostupné až do dokončení exportu.

### **Pochopení životního cyklu zpětných volání**

Exportér volá [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) samostatně pro každý vygenerovaný artefakt:

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Ukládač je zodpovědný za uchování nebo perzistenci dat před návratem. Příklady kopírují každý Java pole bajtů do bufferu Node.js vlastněného aplikací.
- Považujte export za úspěšný pouze tehdy, když operace ukládání prezentace vrátí a všechny zpětné volání úspěšně dokončily. Neskrývejte chyby úložiště ani nezapínejte nepozorované zápisy na pozadí. Pokud perzistence nastane později, hlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) také platí pro vlastní ukládač. Výchozí nastavení, `false`, vylučuje XAML dokumenty skrytých snímků. Při předání `true` jsou zahrnuty i všechny potřebné zdroje pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden zpětný volání na snímek ani pevně dané pořadí volání.

### **Export do paměti a kontrola artefaktů**

Tento úplný příklad načte `input.pptx`, shromáždí každý artefakt do mapy JavaScript pojmenované na buffery a vypíše jeho název, typ a počet bajtů. Zachovává přesně dodané názvy. Duplicitní názvy označují sbírku jako neplatnou místo tichého přepsání artefaktu. Příklad tuto situaci před použitím výsledků kontroluje.

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

Kontroly přípon jsou užitečné pro inspekci; uchovávejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. Používejte dekódování UTF‑8 pouze pro XAML, který vyžaduje textové zpracování.

### **Zabalte shromážděné artefakty do ZIP archivu**

Tento nezávislý příklad shromáždí export, ověří jeho názvy a zapíše původní bajty do ZIP archivu pomocí Java mostu. ZIP je sestaven v paměti před uložením na disk. Jedinečný název archivu odděluje souběžné úlohy exportu. ZIP položky používají dopředná lomítka a zachovávají relativní adresáře. Nebezpečné názvy nebo názvy, které po normalizaci kolidují, odmítnou celý balíček před zápisem.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Zavření dokončuje adresář ZIP před uložením archivu.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Příklad používá [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) k zápisu jednoho místního archivu; samotný exportér nezapisuje volné XAML ani soubory obrázků. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráním shromážděných pole bajtů. Použijte identifikátor úlohy exportu plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení transakce databáze. Vyčistěte částečný výstup, pokud perzistence selže.

U velkých prezentací může vlastní ukládač perzistovat každý artefakt přímo do úložiště aplikace, čímž se vyhnete držení další kopie celého exportu v paměti aplikace. Uchovávejte každé zpětné volání synchronní z pohledu exportéra: vraťte se až poté, co cíl přijme bajty, a nechte chyby proniknout až k volajícímu.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Nepoužívejte pouze základní název, pokud není každé vygenerované jméno unikátní a odkazy na zdroje zůstávají platné.
- Použijte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte ukotvené cesty a segmenty pro navigaci výš, převeďte cíl na absolutní cestu a ověřte, že zůstává pod zamýšleným výstupním adresářem, včetně oddělovače v kontrolním testu. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Pro každou úlohu exportu použijte oddělený ukládač a jmenný prostor úložiště. Detekujte kolize po normalizaci oddělovačů a podle pravidel rozlišování velkých a malých písmen cíle.
- Před zveřejněním parsujte každý XAML dokument jako XML a kontrolujte jeho souborové odkazy na zdroje, například atributy `Source` nebo `ImageSource` u obrázků. Rozresolve každé relativní URI vůči adresáři obsahujícího XAML artefakt, normalizujte výsledný název úložiště a potvrďte, že odpovídající klíč v mapě, ZIP položka nebo uložený objekt existuje. Zpracovávejte externí URI a XAML markup výrazy odděleně od relativních souborových názvů.

Například pokud `input/Slide_1.xaml` odkazuje na `images/image1.png`, musí být uložený zdroj dostupný jako `input/images/image1.png`. Uchování pouze `image1.png` by toto propojení zlomilo. Pro objektové úložiště zachovejte stejnou strukturu pod prefixem úlohy a zpřístupněte tyto URL zdrojů pro XAML spotřebitele. Znovu otevřete dokončený ZIP pro ověření názvů položek a bajtů zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, abyste potvrdili správné rozlišení obrázků.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelná písma, pokud původní písmo není na stroji dostupné?**

Zavolejte [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — toto je použito jako záložní písmo během exportu, když původní chybí. To však nezaručuje, že vygenerovaný XAML bude odkazovat na záložní písmo nebo že písmo bude dostupné na cílovém počítači. Ujistěte se, že písma uvedená v XAML jsou dostupná v prostředí, kde se zobrazují.

**Je exportovaný XAML zamýšlen pouze pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerované značky ve vašem cílovém prostředí.

**Jsou podporovány skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) v [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — ponechte jej vypnutý, pokud je nechcete exportovat.