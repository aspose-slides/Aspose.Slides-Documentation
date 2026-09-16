---
title: Exportera presentationer till XAML i JavaScript
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/nodejs-java/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i JavaScript med Aspose.Slides—snabb, Office-fri lösning som bevarar din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur man exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur man sparar en presentation till XAML med standardinställningar och demonstrerar hur man anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservteckensnitt, XAML‑stackkompatibilitet och exportbeteende för dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Det följande JavaScript‑exemplet visar hur man exporterar en presentation till XAML med standardinställningar:

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

Som standard sparas de exporterade bilderna i en `input`‑undermapp i processens aktuella arbetskatalog. Mappen skapas automatiskt, och eventuella nödvändiga bilder sparas där också.

Utdatamappens namn tas från källfilens namn utan dess filändelse. I Aspose.Slides för Node.js via Java 26.8 ger export av `input.pptx` en nästlad sökväg som `input/input/Slide_1.xaml`. Behåll de fullständiga genererade sökvägarna när du hanterar utdata. Standardutdata är relativ till den aktuella arbetskatalogen, snarare än nödvändigtvis bredvid indatafilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata till en anpassad plats implementerar du [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) och passerar en instans av din implementation till metoden [setOutputSaver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) i [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utdata, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `true`, som visas i följande JavaScript‑exempel:

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

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan generera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödjande resurser. Tilldela en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) till [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) för att ta emot dessa artefakter i stället för standard‑fil‑system‑spararen. Påbörja exporten med den XAML‑specifika overloaden av [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) som accepterar XAML‑alternativ.

I Node.js implementerar du Java‑gränssnittet med `java.newProxy` från `java`‑paketet som används av Aspose.Slides. Håll proxyn tillgänglig tills exporten är klar.

### **Förstå återuppringningslivscykeln**

Exportören anropar [IXamlOutputSaver.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera resurser med relativa sökvägar.
- `data` innehåller artefaktens byte‑data. Bilder och andra binära resurser får inte avkodas som text.
- Spararen ansvarar för att behålla eller persistera datan innan den returneras. Exemplen kopierar varje Java‑byte‑array till en Node.js‑buffer som ägs av applikationen.
- Betrakta exporten som lyckad endast när presentations‑save‑operationen har återvänt och varje återuppringning har slutförts framgångsrikt. Svälj inte lagringsfel eller starta oobserverade bakgrundsskrivningar. Om persisteringen sker efteråt, rapportera totala framgången först när även detta steg lyckas.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) gäller även för en anpassad sparare. Standardinställningen, `false`, utesluter XAML‑dokument för dolda bilder. Att ange `true` inkluderar dem samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller en fast ordning på återuppringningarna.

### **Exportera till minne och inspektera artefakter**

Detta fullständiga exempel laddar `input.pptx`, samlar varje artefakt i en JavaScript‑karta över namn till buffrar och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubblettnamn markerar samlingen som ogiltig i stället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

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

        // Avkoda bara XAML, och endast när textuell inspektion behövs.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Filnamnssuffixkontroller är användbara för inspektion; bevara alla artefakter, inklusive ovanliga resurstyp­er. Lämna byte‑värdena oförändrade vid lagring eller överföring. Använd UTF‑8‑avkodning endast för XAML som behöver textuell behandling.

### **Packa samlade artefakter i ett ZIP‑arkiv**

Detta oberoende exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena till ett ZIP‑arkiv med hjälp av Java‑bron. ZIP‑filen byggs i minnet innan den sparas till disk. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder framåtsnedstreck och bevarar relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

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

    // Stängning slutför ZIP-katalogen innan arkivet sparas.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Exemplet använder [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steget som skriver arkivet med uppladdning av de insamlade byte‑arrayerna. Använd ett export‑job‑identifierare plus det fullständiga relativa artefaktnamnet som blob‑nyckel, eller lagra job‑identifieraren, relativt namn och binärdata i en databastrad. Publicera jobbet först när alla uppladdningar är slutförda eller databastransaktionen har begåtts. Rensa partiell utdata om persisteringen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i applikationsminnet. Behåll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationen har accepterat byten, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsseparatorer när destinationen kräver det, men bevara relativa kataloger. Använd inte bara basnamnet om inte varje genererat namn är känt för att vara unikt och resursreferenserna förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, avvisa rotade sökvägar och traverseringssegment, lös destinationen till en absolut sökväg och verifiera att den förblir under den avsedda exportkatalogen, inklusive katalogseparator i innehållskontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje export‑job. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skift‑känslighetsregler.
- Innan publicering, pars varje XAML‑dokument som XML och inspektera dess fil‑baserade resurreferenser, såsom bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den omgivande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande karta‑nyckel, ZIP‑post eller lagrat objekt existerar. Behandla externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `input/Slide_1.xaml` refererar `images/image1.png`, måste den lagrade resursen finnas som `input/images/image1.png`. Att enbart behålla `image1.png` skulle bryta den relationen. För objektlagring, bevara samma layout under jobb‑prefixet och gör dessa resur‑URL:er tillgängliga för XAML‑konsumenten. öppna det färdiga ZIP‑arkivet igen för att verifiera postnamn och resurs‑byte, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löser korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara typsnitt om det ursprungliga typsnittet inte finns på maskinen?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/) — det används som reservtypsnitt under export när originalet saknas. Detta garanterar inte att den genererade XAML‑en refererar till reservtypsnittet eller att typsnittet finns på målmaskinen. Säkerställ att de typsnitt som XAML refererar till finns i den miljö där den visas.

**Är den exporterade XAML‑en bara avsedd för WPF, eller kan den användas i andra XAML‑stackar också?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din mål‑miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) i [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.