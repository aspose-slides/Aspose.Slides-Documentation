---
title: Presentaties exporteren naar XAML in Java
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in Java met Aspose.Slides—snelle, Office-vrije oplossing die uw layout intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat naar XAML met standaardinstellingen, en laat zien hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen met betrekking tot fallback‑lettertypen, XAML‑stackcompatibiliteit en het gedrag bij export van verborgen dia's.

## **Over XAML**

XAML is een op XML gebaseerd opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de markup rechtstreeks schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Het volgende Java‑voorbeeld toont hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

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

Standaard worden de geëxporteerde dia's opgeslagen in een `pres`‑submap van de huidige werkmap van het proces, verkregen uit een leeg pad met [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-). De map wordt automatisch aangemaakt en alle benodigde afbeeldingen worden daar eveneens opgeslagen.

De naam van de uitvoermap wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` krijgen de uitvoerbestanden de namen `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als u een absoluut pad opgeeft voor de invoerpresentatie, wordt de uitvoermap relatief ten opzichte van de huidige werkmap aangemaakt, niet naast het invoerbestand.

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloptions/) interface om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de uitvoer op een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) en geeft u een instantie van uw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) methode van [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/).

Om verborgen dia's op te nemen in de XAML‑uitvoer, roept u [setExportHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) aan met `true`, zoals getoond in het volgende Java‑voorbeeld:

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

## **Alle gegenereerde XAML‑artefacten vastleggen**

Een XAML‑export kan een XAML‑document produceren voor elke geëxporteerde dia plus afzonderlijke afbeeldingen en ondersteunende resources. Ken een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/) toe aan [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) om deze artefacten te ontvangen in plaats van de standaard bestandsysteem‑saver. Start de export met de XAML‑specifieke [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) overload die XAML‑opties accepteert.

### **Begrijp de callback‑levenscyclus**

De exporter roept [IXamlOutputSaver.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) afzonderlijk aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML resources kan refereren met relatieve paden.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire resources mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het behouden of opslaan van de data voordat deze wordt geretourneerd. De voorbeelden kopiëren elk byte‑array naar door de applicatie eigen geheugen.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑opslaoperatie terugkeert en elke callback succesvol is afgerond. Sluit opslagfouten niet stilletjes uit en start geen onwaargenomen achtergrondschrijvingen. Als persistentie later plaatsvindt, rapporteer dan het algehele succes pas nadat die stap ook geslaagd is.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) geldt ook voor een aangepaste saver. De standaardwaarde, `false`, sluit XAML‑documenten van verborgen dia's uit. Door `true` door te geven, worden ze en alle benodigde resources voor hun export opgenomen. Het aantal resources hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artefact in een [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), en drukt de naam, het type en het aantal bytes af. Het behoudt de opgegeven namen exact. Dubbele namen maken de collectie ongeldig in plaats van stilletjes een artefact te overschrijven. Het voorbeeld controleert dit voordat de resultaten worden gebruikt.

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

    // Decode alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Extensietests zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende resource‑typen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik de [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) met UTF-8 alleen voor XAML die tekstverwerking vereist.

### **Verzamelde artefacten verpakken in een ZIP‑archief**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen, en schrijft de oorspronkelijke bytes naar een ZIP‑archief. Een unieke archiefnaam scheidt gelijktijdige exporttaken. ZIP‑entries gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie botsen, laten het volledige pakket afwijzen vóór het wordt weggeschreven.

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

    // De ZIP-directory is afgerond door te sluiten voordat het succes wordt gemeld.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Het voorbeeld gebruikt [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor externe opslag vervangt u de archief‑schrijffase door uploads van de verzamelde byte‑arrays. Gebruik een export‑taak‑identifier plus de volledige relatieve artefactnaam als blob‑sleutel, of sla de taak‑identifier, relatieve naam en binaire data op in een databaseregel. Publiceer de taak pas nadat alle uploads voltooid zijn of de database‑transactie is gecommit. Ruim gedeeltelijke uitvoer op als persistentie faalt.

Voor grote presentaties kan een aangepaste saver elk artefact direct naar toepassingsopslag schrijven om te voorkomen dat een extra kopie van de volledige export in het geheugen wordt gehouden. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer pas nadat de bestemming de bytes heeft aanvaard, en laat fouten doorsluipen naar de aanroeper.

### **Resource‑namen behouden en verwijzingen verifiëren**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dit vereist, maar behoud relatieve mappen. Gebruik niet alleen [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) tenzij elke gegenereerde naam gegarandeerd uniek is en resource‑referenties geldig blijven.
- Pas bestemmingsspecifieke naamvalidatie toe. Bij het schrijven van losse bestanden, wijs rooted‑paden en traversalsegmenten af, los de bestemming op met [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), en controleer dat deze onder de beoogde exportmap blijft, inclusief de map‑scheidingsteken in de containment‑check. Gebruik een door de applicatie gecontroleerde map zonder symbolische links die schrijfsrichtingen kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke exporttaak. Detecteer botsingen na normalisatie van scheidingstekens en volgens de hoofdlettergevoeligheidsregels van de bestemming.
- Voordat u publiceert, parseer elk XAML‑document als XML en inspecteer de bestand‑gebaseerde resource‑referenties, zoals afbeelding `Source` of `ImageSource` attributen. Los elke relatieve URI op tegen de directory van het omvattende XAML‑artefact, normaliseer de resulterende opslagnaam, en bevestig dat de bijbehorende map‑sleutel, ZIP‑entry of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` refereert aan `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` bewaren zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde structuur onder de taak‑prefix en maakt u die resource‑URL’s toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om entry‑namen en resource‑bytes te verifiëren, en laad representatieve dia's in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgelost.

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het oorspronkelijke lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) aan in [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/) — dit wordt gebruikt als fallback‑lettertype tijdens de export wanneer het origineel ontbreekt. Dit garandeert niet dat de gegenereerde XAML het fallback‑lettertype referereert of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de lettertypen die door de XAML worden gerefereerd aanwezig zijn in de omgeving waarin deze wordt weergegeven.

**Is de geëxporteerde XAML uitsluitend bedoeld voor WPF, of kan deze ook worden gebruikt in andere XAML‑stacks?**

Aspose.Slides exporteert WPF‑XAML via zijn openbare API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, wordt niet gegarandeerd. Test de gegenereerde markup in uw doelomgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet opgenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/) — laat het uitgeschakeld wanneer u ze niet hoeft te exporteren.