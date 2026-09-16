---
title: Export Presentaties naar XAML in JavaScript
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/nodejs-java/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in JavaScript met Aspose.Slides - een snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat als XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia’s. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, XAML‑stack‑compatibiliteit en het gedrag bij het exporteren van verborgen dia’s.

## **Over XAML**

XAML is een op XML gebaseerd opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende JavaScript‑voorbeeld toont hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

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

Standaard worden de geëxporteerde dia’s opgeslagen in een `input`‑submap van de huidige werkmap van het proces. De map wordt automatisch aangemaakt en alle vereiste afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bronbestandsnaam zonder extensie. In Aspose.Slides for Node.js via Java 26.8 resulteert het exporteren van `input.pptx` in een geneste padstructuur zoals `input/input/Slide_1.xaml`. Bewaar de volledige gegenereerde paden bij het verwerken van de uitvoer. De standaarduitvoer is relatief ten opzichte van de huidige werkmap, en niet noodzakelijk naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloptions/)‑interface om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de uitvoer naar een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) en geeft u een instantie van uw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)‑methode van [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/).

Om verborgen dia’s op te nemen in de XAML‑uitvoer, roept u [setExportHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `true`, zoals in het volgende JavaScript‑voorbeeld:

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

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan voor elke geëxporteerde dia een XAML‑document produceren, plus afzonderlijke afbeeldingen en ondersteunende resources. Ken een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) toe aan [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) om deze artefacten te ontvangen in plaats van de standaard bestandsopslaafunctie. Start de export met de XAML‑specifieke overload van [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) die XAML‑opties accepteert.

In Node.js implementeert u de Java‑interface met `java.newProxy` uit het `java`‑pakket dat door Aspose.Slides wordt gebruikt. Houd de proxy toegankelijk tot de export is voltooid.

### **Begrijp de levenscyclus van de callback**

De exporter roept [IXamlOutputSaver.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) afzonderlijk aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML resources kan refereren via relatieve paden.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire resources mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het behouden of persisteren van de data voordat deze wordt geretourneerd. De voorbeelden kopiëren elk Java‑byte‑array naar een door de toepassing beheerde Node.js‑buffer.
- Beschouw de export als geslaagd slechts wanneer de presentatie‑save‑operatie terugkeert en elke callback succesvol is afgerond. Negeer geen opslagfouten en start geen onopgemerkte achtergrond‑schrijfbewerkingen. Als persistatie later plaatsvindt, rapporteer dan alleen algehele succes nadat die stap ook geslaagd is.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) is ook van toepassing op een aangepaste saver. De standaardwaarde, `false`, sluit XAML‑documenten van verborgen dia’s uit. Door `true` te passen, worden ze inclusief alle benodigde resources opgenomen. Het aantal resources hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `input.pptx`, verzamelt elk artefact in een JavaScript‑map van namen naar buffers, en drukt de naam, het type en het byte‑aantal af. Het behoudt de opgegeven namen exact. Dubbele namen maken de collectie ongeldig in plaats van stilletjes een artefact te overschrijven. Het voorbeeld controleert dit voordat de resultaten worden gebruikt.

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

        // Decodeer alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Extensie‑controles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende resource‑typen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik UTF‑8‑decodering alleen voor XAML die tekstueel moet worden verwerkt.

### **Verzamelde artefacten in een ZIP‑archief verpakken**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen en schrijft de oorspronkelijke bytes naar een ZIP‑archief via de Java‑bridge. Het ZIP‑archief wordt eerst in het geheugen opgebouwd voordat het naar schijf wordt weggeschreven. Een unieke archiefnaam scheidt gelijktijdige export‑taken. ZIP‑entries gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie met elkaar botsen, leiden tot afwijzing van het volledige pakket vóór het schrijven.

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

    // Afsluiten finaliseert de ZIP‑directory voordat het archief wordt opgeslagen.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Het voorbeeld maakt gebruik van [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor externe opslag vervangt u de archief‑schrijffase door uploads van de verzamelde byte‑arrays. Gebruik een export‑taak‑identificator plus de volledige relatieve artefactnaam als blob‑sleutel, of sla de taak‑identificator, relatieve naam en binaire data op in een databaseregel. Publiceer de taak pas nadat alle uploads zijn voltooid of de databasetransactie is gecommit. Ruim gedeeltelijke uitvoer op als persisteren mislukt.

Voor grote presentaties kan een aangepaste saver elk artefact direct naar de toepassingsopslag persisteren om te voorkomen dat een extra kopie van de volledige export in het geheugen moet worden gehouden. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft geaccepteerd, en laat fouten naar de aanroeper doorsluizen.

### **Resource‑namen behouden en referenties verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dat vereist, maar behoud relatieve mappen. Gebruik niet alleen de basisnaam tenzij elke gegenereerde naam gegarandeerd uniek is en resource‑referenties geldig blijven.
- Pas bestemming‑specifieke naam‑validatie toe. Bij het schrijven van losse bestanden, keur wortel‑paden en traversalsegmenten af, los de bestemming op naar een absoluut pad en controleer dat het binnen de beoogde export‑map blijft, inclusief de map‑scheidingsteken‑controle. Gebruik een door de toepassing beheerde map zonder symbolische links die de schrijfacties kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace per export‑taak. Detecteer botsingen na normalisatie van scheidingstekens volgens de case‑sensitivity‑regels van de bestemming.
- Voordat u publiceert, parseert u elk XAML‑document als XML en inspecteert u de bestands‑gebaseerde resource‑referenties, zoals `Source`‑ of `ImageSource`‑attributen. Los elke relatieve URI op tegen de map van het bijbehorende XAML‑artefact, normaliseer de resulterende opslagnaam en bevestig dat de corresponderende map‑sleutel, ZIP‑entry of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `input/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `input/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde mapstructuur onder de taak‑prefix en maakt u die resource‑URL’s toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om entry‑namen en resource‑bytes te verifiëren, en laad representatieve dia’s in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgezocht.

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) aan in [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het origineel ontbreekt. Dit garandeert niet dat het gegenereerde XAML het fallback‑lettertype verwijst of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de door het XAML verwijzende lettertypen aanwezig zijn in de omgeving waarin het wordt weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn publieke API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in uw doelsysteem.

**Worden verborgen dia’s ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia’s niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/) — houd het uitgeschakeld als u ze niet wilt exporteren.