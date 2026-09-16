---
title: Presentaties exporteren naar XAML op Android
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in Java met Aspose.Slides voor Android—snelle, Office‑vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides voor Android via Java. Het bevat een korte introductie tot XAML, toont hoe u een presentatie kunt opslaan naar XAML met standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, XAML‑stackcompatibiliteit en het gedrag bij export van verborgen dia's.

## **Over XAML**

XAML is een XML‑gebaseerde opmaaktaal die wordt gebruikt om gebruikersinterfaces te beschrijven in frameworks zoals WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin.Forms.

U kunt met XAML‑bestanden werken in een visuele ontwerper of de opmaak direct schrijven en bewerken.

## **Exporteren van presentaties naar XAML met standaardopties**

Dit volgende Java‑voorbeeld toont hoe u een presentatie naar XAML exporteert met de standaardinstellingen:

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

Standaard worden de geëxporteerde dia's opgeslagen in een `pres`‑submap van de huidige werkmap van het proces. De map wordt automatisch aangemaakt en eventuele vereiste afbeeldingen worden daar ook opgeslagen.

De naam van de outputmap wordt afgeleid van de bestandsnaam van de bron zonder extensie. Voor `pres.pptx` worden de outputbestanden genoemd `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, enzovoort. Zelfs als u een absoluut pad opgeeft voor de invoerpresentatie, wordt de outputmap relatief aan de huidige werkmap aangemaakt, in plaats van naast het invoerbestand.

Op Android moet u een invoerbestand gebruiken dat toegankelijk is voor uw app. De huidige werkmap is mogelijk niet beschrijfbaar; gebruik een aangepaste output‑saver om de export in het geheugen te behouden of naar de app‑opslag te schrijven, zoals hieronder getoond. De gegenereerde WPF‑XAML is bedoeld voor een compatibele consument en is geen Android layoutresource.

## **Exporteren van presentaties naar XAML met aangepaste opties**

Gebruik de [IXamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ixamloptions/) interface om te bepalen hoe Aspose.Slides een presentatie exporteert naar XAML.

Om de output op een aangepaste locatie op te slaan, implementeert u [IXamlOutputSaver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ixamloutputsaver/) en geeft u een instantie van uw implementatie door aan de [setOutputSaver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-)‑methode van [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/).

Om verborgen dia's op te nemen in de XAML‑output, roept u [setExportHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) aan met `true`, zoals getoond in het volgende Java‑voorbeeld:

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

Een XAML‑export kan een XAML‑document voor elke geëxporteerde dia opleveren, plus afzonderlijke afbeeldingen en ondersteunende bronnen. Wijs een aangepaste [IXamlOutputSaver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ixamloutputsaver/) toe aan [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) om deze artefacten te ontvangen in plaats van de standaard bestandsysteem‑saver te gebruiken. Start de export met de XAML‑specifieke [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑overload die XAML‑opties accepteert.

### **Begrijp de callback‑levenscyclus**

De exporter roept [IXamlOutputSaver.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) apart aan voor elk gegenereerd artefact:

- `path` identificeert het artefact en kan relatieve mappen bevatten. Bewaar deze informatie omdat XAML mogelijk bronnen via relatieve paden verwijst.
- `data` bevat de bytes van het artefact. Afbeeldingen en andere binaire bronnen mogen niet als tekst worden gedecodeerd.
- De saver is verantwoordelijk voor het behouden of opslaan van de data voordat deze terugkeert. De voorbeelden kopiëren elke byte‑array naar geheugen dat eigendom is van de applicatie.
- Beschouw de export als geslaagd alleen wanneer de presentatie‑save‑operatie terugkeert en elke callback succesvol is afgerond. Negeer geen opslagfouten of start geen ongeobserveerde achtergrondschrijvingen. Als persistatie later gebeurt, rapporteer dan het totale succes pas nadat die stap ook geslaagd is.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) geldt ook voor een aangepaste saver. De standaardinstelling, `false`, sluit XAML‑documenten van verborgen dia's uit. Het doorgeven van `true` neemt ze op, evenals alle bronnen die nodig zijn voor hun export. Het aantal bronnen hangt af van de presentatie; ga niet uit van één callback per dia of een vaste callback‑volgorde.

### **Exporteren naar geheugen en de artefacten inspecteren**

Dit volledige voorbeeld laadt `pres.pptx`, verzamelt elk artefact in een [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), en drukt de naam, het type en het aantal bytes af. Het behoudt de opgegeven namen precies. Dubbele namen markeren de verzameling als ongeldig in plaats van stilletjes een artefact te overschrijven. Het voorbeeld controleert dit voordat de resultaten worden gebruikt.

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

    // Decodeer alleen XAML, en alleen wanneer tekstuele inspectie nodig is.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Extensietesten zijn nuttig voor inspectie; bewaar alle artefacten, inclusief onbekende type bronnen. Laat de bytes ongewijzigd wanneer u ze opslaat of verzendt. Gebruik de [String‑constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) met UTF‑8 alleen voor XAML dat tekstuele verwerking vereist.

### **Verzamelde artefacten verpakken in een ZIP‑archief**

Dit zelfstandige voorbeeld verzamelt de export, valideert de namen en schrijft de originele bytes naar een ZIP‑archief. Vervang `/path/to/app/files` door het pad dat wordt geretourneerd door de [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir())‑methode van uw Android‑context. Een unieke archiefnaam scheidt gelijktijdige exporttaken. ZIP‑entries gebruiken schuine strepen en behouden relatieve mappen. Onveilige namen of namen die na normalisatie botsen, verwerpen het gehele pakket voordat het wordt geschreven.

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

    // De ZIP-directory is afgerond door te sluiten voordat succes wordt gemeld.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Het voorbeeld gebruikt [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) om één lokaal archief te schrijven; de exporter zelf schrijft geen losse XAML‑ of afbeeldingsbestanden. Voor externe opslag vervangt u de archief‑schrijffase door uploads van de verzamelde byte‑arrays. Gebruik een export‑job‑identifier plus de volledige relatieve artefactnaam als blob‑sleutel, of sla het job‑identifier, de relatieve naam en de binaire data op in een database‑rij. Publiceer de job pas nadat alle uploads voltooid zijn of de databasetransactie gecommit is. Ruim gedeeltelijke output op als persistatie faalt.

Voor grote presentaties kan een aangepaste saver elk artefact direct in de applicatie‑opslag opslaan om te voorkomen dat een extra kopie van de volledige export in het geheugen wordt bewaard. Houd elke callback synchroon vanuit het perspectief van de exporter: retourneer alleen nadat de bestemming de bytes heeft geaccepteerd, en laat fouten naar de aanroeper doorgaan.

### **Behoud resource‑namen en verifieer referenties**

- Normaliseer pad‑scheidingstekens wanneer de bestemming dit vereist, maar bewaar relatieve mappen. Gebruik niet alleen [File.getName](https://developer.android.com/reference/java/io/File#getName()) tenzij elke gegenereerde naam bekend uniek is en resource‑referenties geldig blijven.
- Pas bestemmingsspecifieke naamaanvalidatie toe. Bij het schrijven van losse bestanden, verwerp absolute paden en traversalsegmenten, los de bestemming op met [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), en verifieer dat deze onder de beoogde export‑directory blijft, inclusief de map‑scheidingsteken in de containment‑check. Gebruik een door de applicatie beheerde directory zonder symbolische links die schrijven kunnen omleiden.
- Gebruik een aparte saver en opslag‑namespace voor elke export‑job. Detecteer botsingen na normalisatie van scheidingstekens en volgens de hoofdlettergevoeligheidsregels van de bestemming.
- Parseer vóór publicatie elk XAML‑document als XML en inspecteer de bestand‑gebaseerde resource‑referenties, zoals image `Source`‑ of `ImageSource`‑attributen. Los elke relatieve URI op ten opzichte van de map van het bijbehorende XAML‑artefact, normaliseer de resulterende opslagnaam, en bevestig dat de corresponderende map‑sleutel, ZIP‑entry of opgeslagen object bestaat. Behandel externe URI’s en XAML‑markup‑expressies apart van relatieve bestandsnamen.

Bijvoorbeeld, als `pres/Slide_1.xaml` verwijst naar `images/image1.png`, moet de opgeslagen resource beschikbaar zijn als `pres/images/image1.png`. Alleen `image1.png` behouden zou die relatie verbreken. Voor object‑opslag behoudt u dezelfde structuur onder de job‑prefix en maakt u die resource‑URL’s toegankelijk voor de XAML‑consument. Open het voltooide ZIP‑archief opnieuw om entry‑namen en resource‑bytes te verifiëren, en laad representatieve dia's in de doel‑XAML‑omgeving om te bevestigen dat afbeeldingen correct worden opgelost.

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Roep [setDefaultRegularFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) aan in [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/) — het wordt gebruikt als fallback‑lettertype tijdens export wanneer het originele lettertype ontbreekt. Dit garandeert niet dat de gegenereerde XAML naar het fallback‑lettertype verwijst of dat het lettertype beschikbaar is op de doelmachine. Zorg ervoor dat de lettertypen waarnaar de XAML verwijst beschikbaar zijn in de omgeving waarin deze wordt weergegeven.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

Aspose.Slides exporteert WPF‑XAML via zijn publieke API. Compatibiliteit met andere XAML‑stacks, zoals UWP en Xamarin.Forms, is niet gegarandeerd. Test de gegenereerde markup in uw doelomgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/) — houd het uitgeschakeld als u ze niet hoeft te exporteren.