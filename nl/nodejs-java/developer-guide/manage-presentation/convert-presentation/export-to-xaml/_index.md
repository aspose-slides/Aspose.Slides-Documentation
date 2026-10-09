---
title: Presentaties exporteren naar XAML in JavaScript
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

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat als XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, XAML‑stack‑compatibiliteit en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een XML‑gebaseerde opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende JavaScript‑voorbeeld laat zien hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

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

Standaard worden de geëxporteerde dia's opgeslagen in een submap `input` van de huidige werkmap van het proces. De map wordt automatisch aangemaakt en eventuele benodigde afbeeldingen worden daar ook opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bestandsnaam van de bron zonder extensie. In Aspose.Slides voor Node.js via Java 26.8 produceert het exporteren van `input.pptx` een geneste pad zoals `input/input/Slide_1.xaml`. Behoud de volledig gegenereerde paden bij het verwerken van de output. De standaardoutput is relatief ten opzichte van de huidige werkmap, en niet per se naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) interface om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de output op een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) en geeft u een instantie van uw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) methode van [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Om verborgen dia's in de XAML‑output op te nemen, roep u [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `true`, zoals getoond in het volgende JavaScript‑voorbeeld:

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

Een XAML‑export kan een XAML‑document voor elke geëxporteerde dia produceren, plus afzonderlijke afbeeldingen en ondersteunende resources. Wijs een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) toe aan [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) om deze artefacten te ontvangen in plaats van de standaard bestands‑saver te gebruiken. Start de export met de XAML‑specifieke [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) overload die XAML‑opties accepteert.

In Node.js implementeert u de Java‑interface met `java.newProxy` uit het `java`‑pakket dat door Aspose.Slides wordt gebruikt. Houd de proxy bereikbaar tot de export voltooid is.

### **Begrijp de callback‑levenscyclus**

De exporter roept [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) afzonderlijk aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML resources kan refereren via relatieve paden.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire resources mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het behouden of opslaan van de data voordat er wordt geretourneerd. De voorbeelden kopiëren elke Java‑byte‑array naar een door de applicatie beheerde Node.js‑buffer.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑save‑operatie terugkeert en iedere callback succesvol is afgerond. Slik geen opslag‑fouten weg en start geen ongeobserveerde achtergrond‑writes. Als persistentie later plaatsvindt, rapporteer dan het totale succes pas nadat die stap ook geslaagd is.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) is ook van toepassing op een aangepaste saver. De standaardinstelling, `false`, sluit verborgen‑dia XAML‑documenten uit. Het doorgeven van `true` neemt ze op, evenals alle resources die nodig zijn voor hun export. Het aantal resources hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `input.pptx`, verzamelt elk artefact in een JavaScript‑map van namen naar buffers, en drukt de naam, het type en het byte‑aantal af. Het behoudt de opgegeven namen exact. Dubbelle namen markeren de collectie als ongeldig in plaats van stilletjes een artefact te overschrijven. Het voorbeeld controleert dit voordat de resultaten worden gebruikt.

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
    const options = new aspose.slides.XtraOptions();
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

Extensie‑controles zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende resource‑types. Laat de bytes ongewijzigd wanneer ze worden opgeslagen of overgedragen. Gebruik UTF‑8‑decodering alleen voor XAML dat tekstueel moet worden verwerkt.

### **Verpak verzamelde artefacten in een ZIP‑archief**

Dit onafhankelijke voorbeeld verzamelt de export, valideert de namen en schrijft de originele bytes naar een ZIP‑archief via de Java‑bridge. Het ZIP‑archief wordt in geheugen opgebouwd voordat het naar schijf wordt weggeschreven. Een unieke archiefnaam scheidt gelijktijdige export‑taken. ZIP‑entries gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie botsen, leiden tot afwijzing van het volledige pakket voordat het wordt weggeschreven.

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

    // Sluiten finaliseert de ZIP-directory voordat het archief wordt weggeschreven.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Het voorbeeld gebruikt [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor externe opslag vervangt u de archief‑schrijffase door uploads van de verzamelde byte‑arrays. Gebruik een export‑taak‑identifier plus de volledige relatieve artefactnaam als blob‑sleutel, of sla de taak‑identifier, relatieve naam en binaire data op in een database‑rij. Publiceer de taak pas nadat alle uploads voltooid zijn of de databasetransactie is gecommit. Ruim gedeeltelijke output op als persistente falen.

Voor grote presentaties kan een aangepaste saver elk artefact rechtstreeks naar de applicatie‑opslag schrijven om te voorkomen dat er een extra kopie van de volledige export in het applicatie‑geheugen moet worden bewaard. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft geaccepteerd, en laat fouten bij de aanroeper terechtkomen.

### **Beheer resource‑namen en verifieer referenties**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dat vereist, maar behoud relatieve mappen. Gebruik niet alleen de basisnaam tenzij elke gegenereerde naam uniek is en resource‑referenties geldig blijven.
- Pas bestemmingsspecifieke naamvalidatie toe. Bij het schrijven van losse bestanden, wijs wortel‑paden en traversalsegmenten af, los de bestemming op naar een absoluut pad, en controleer dat het binnen de beoogde export‑directory blijft, inclusief het pad‑scheidingsteken in de containment‑check. Gebruik een door de applicatie gecontroleerde map zonder symbolische links die schrijven kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke export‑taak. Detecteer botsingen na normalisatie van scheidingstekens en volgens de hoofdletter‑gevoeligheidsregels van de bestemming.
- Voordat u publiceert, parseert u elk XAML‑document als XML en inspecteert u de bestands‑gebaseerde resource‑referenties, zoals afbeelding‑`Source` of `ImageSource` attributen. Los elke relatieve URI op tegen de map van het omvattende XAML‑artefact, normaliseer de resulterende opslag‑naam, en bevestig dat de overeenkomstige map‑sleutel, ZIP‑entry of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `input/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `input/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde map‑structuur onder de taak‑prefix en maakt u die resource‑URL’s toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om entry‑namen en resource‑bytes te verifiëren, en laad representatieve dia’s in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden geresolvd.

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) aan in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het originele lettertype ontbreekt. Dit garandeert niet dat de gegenereerde XAML naar het fallback‑lettertype verwijst of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de lettertypen waarnaar de XAML verwijst beschikbaar zijn in de omgeving waarin deze wordt weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn openbare API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in uw doelomgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet opgenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — houd het uitgeschakeld als u ze niet hoeft te exporteren.