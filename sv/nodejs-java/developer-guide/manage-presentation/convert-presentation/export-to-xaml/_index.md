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
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i JavaScript med Aspose.Slides—snabb, Office-fri lösning som behåller din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint‑presentationer till XAML med hjälp av Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln besvarar också några vanliga frågor relaterade till reservteckensnitt, kompatibilitet med XAML‑stackar och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk såsom WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande JavaScript‑exempel visar hur du exporterar en presentation till XAML med standardinställningar:

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

Som standard sparas de exporterade bilderna i en `input`‑undermapp i processens aktuella arbetskatalog. Mappen skapas automatiskt, och eventuella nödvändiga bilder sparas också där.

Utdatamappens namn tas från källfilens namn utan dess filändelse. I Aspose.Slides för Node.js via Java 26.8 producerar export av `input.pptx` en inbäddad sökväg som `input/input/Slide_1.xaml`. Bevara de fullständiga genererade sökvägarna när du hanterar utdata. Standardutdata är relativ till den aktuella arbetskatalogen, snarare än nödvändigtvis bredvid inmatningsfilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata till en anpassad plats, implementera [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) och skicka en instans av din implementation till metoden [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) på [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utdata, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `true`, som visas i följande JavaScript‑exempel:

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

En XAML‑export kan producera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödjande resurser. Tilldela en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) till [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) för att ta emot dessa artefakter i stället för att använda standardfil‑system‑spararen. Starta exporten med den XAML‑specifika överlagringen [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) som accepterar XAML‑alternativ.

I Node.js implementerar du Java‑gränssnittet med `java.newProxy` från `java`‑paketet som används av Aspose.Slides. Behåll proxyn åtkomlig tills exporten är klar.

### **Förstå återuppringningslivscykeln**

Exportören anropar [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera till resurser med relativa sökvägar.
- `data` innehåller artefaktens byte. Bilder och andra binära resurser får inte avkodas som text.
- Spararen ansvarar för att behålla eller persistera data innan den returneras. Exempen kopierar varje Java‑byte‑array till en av applikationen ägd Node.js‑buffer.
- Beträk exporten som lyckad endast när presentations‑spara‑operationen returnerar och varje återuppringning har slutförts utan fel. Undvik att dämpa lagringsfel eller starta oobserverade bakgrundsskrivningar. Om persistering sker senare, rapportera total framgång först när även det steget lyckas.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) gäller också för en anpassad sparare. Standardinställningen, `false`, exkluderar XAML‑dokument för dolda bilder. Att skicka `true` inkluderar dem samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller en fast återuppringningsordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `input.pptx`, samlar varje artefakt i en JavaScript‑karta med namn till buffrar och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubbla namn markerar samlingen som ogiltig i stället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

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

        // Avkoda endast XAML, och endast när textuell inspektion behövs.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, inklusive okända resurs‑typer. Lämna byten oförändrade vid lagring eller överföring. Använd UTF‑8‑avkodning endast för XAML som kräver textbearbetning.

### **Packa samlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena till ett ZIP‑arkiv med hjälp av Java‑bron. ZIP‑arkivet byggs upp i minnet innan det sparas till disk. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder snedstreck och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering avvisar hela paketet innan det skrivs.

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

    // Stängning slutför ZIP‑katalogen innan arkivet sparas.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Exemplet använder [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) för att skriva ett lokalt arkiv; exportören själv skriver inte lossiga XAML‑ eller bildfiler. För fjärrlagring, ersätt steget för arkivskrivning med uppladdningar av de samlade byte‑arrayerna. Använd en export‑jobbidentifierare plus det fullständiga relativa artefaktnamnet som blob‑nyckel, eller lagra jobb‑identifieraren, relativa namnet och binärdata i en databastrad. Publicera jobbet först när alla uppladdningar är klara eller databas‑transaktionen har begåtts. Rensa delvis utdata om persisteringen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i applikationsminnet. Håll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationen har accepterat bytena, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte bara basnamnet om inte varje genererat namn är känt för att vara unikt och resursreferenserna förblir giltiga.
- Applicera destinationsspecifik namnvalidering. Vid skrivning av lösa filer, avvisa rotade sökvägar och traverseringssegment, lös destinationen till en absolut sökväg och verifiera att den förblir under den avsedda exportkatalogen, inklusive katalogavgränsaren i kontrollen för innehåll. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Detektera kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, parsas varje XAML‑dokument som XML och inspekteras dess filbaserade resursreferenser, såsom bild‑`Source`‑ eller `ImageSource`‑attribut. Lös varje relativ URI mot den innehållande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande kartnyckel, ZIP‑post eller lagrad objekt finns. Behandla externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `input/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen vara tillgänglig som `input/images/image1.png`. Att bara behålla `image1.png` skulle bryta den relationen. För objektslagring, bevara samma layout under jobb‑prefixet och gör dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Öppna det färdiga ZIP‑arkivet igen för att verifiera postnamn och resurs‑byten, och ladda representativa bilder i målmiljön för XAML för att bekräfta att bilderna löser korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte finns på maskinen?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — den används som reservteckensnitt under export när det ursprungliga saknas. Detta garanterar inte att den genererade XAML‑referensen använder reservteckensnittet eller att teckensnittet är tillgängligt på målmaskinen. Se till att de teckensnitt som XAML refererar till är tillgängliga i den miljö där den visas.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den även användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt offentliga API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan kontrollera detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) i [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.