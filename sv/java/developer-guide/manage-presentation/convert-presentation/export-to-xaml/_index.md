---
title: Exportera presentationer till XAML i Java
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i Java med Aspose.Slides - en snabb, Office-fri lösning som behåller din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur man exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur man sparar en presentation till XAML med standardinställningar och demonstrerar hur man anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor om fallback‑teckensnitt, XAML‑stack‑kompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markeringen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande Java‑exempel visar hur man exporterar en presentation till XAML med standardinställningar:

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

Som standard sparas de exporterade bilderna i en `pres`‑underkatalog till processens aktuella arbetskatalog, löst från en tom sökväg med [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-). Katalogen skapas automatiskt och eventuella nödvändiga bilder sparas där också.

Utmatningskatalogens namn hämtas från källfilens namn utan dess filtillägg. För `pres.pptx` får du filerna `pres/Slide_1.xaml`, `pres/Slide_2.xaml` osv. Även om du anger en absolut sökväg till inmatningspresentationen skapas utmatningskatalogen relativt den aktuella arbetskatalogen, inte bredvid indatafilen.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata på en anpassad plats, implementera [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) och skicka en instans av din implementation till metoden [setOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) på [XamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utmatningen, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) med `true`, som visas i följande Java‑exempel:

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

## **Fånga alla genererade XAML‑artefakter**

En XAML‑export kan producera ett XAML‑dokument för varje exporterad bild samt separata bilder och stödresurser. Tilldela en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/) till [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) för att ta emot dessa artefakter i stället för standard‑filsystemspararen. Starta exporten med den XAML‑specifika [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑överladdningen som accepterar XAML‑alternativ.

### **Förstå återuppringningslivscykeln**

Exportören anropar [IXamlOutputSaver.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera resurser med relativa sökvägar.
- `data` innehåller artefaktens byte‑array. Bilder och andra binära resurser får inte avkodas som text.
- Spararen ansvarar för att behålla eller persistera data innan den returneras. Exemplen kopierar varje byte‑array till minne som ägs av applikationen.
- Betrakta exporten som lyckad först när presentationssparningsoperationen returnerar och varje återuppringning har slutförts utan fel. Tappa inte bort lagringsfel eller påbörja osynliga bakgrundsskrivningar. Om persistensen sker senare ska den totala framgången rapporteras först när även detta steg lyckas.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) gäller även för en anpassad sparare. Standardinställningen, `false`, utesluter XAML‑dokument för dolda bilder. Att skicka `true` inkluderar dem samt alla resurser som krävs för deras export. Antalet resurser beror på presentationen; anta inte ett återuppringningsanrop per bild eller en fast återuppringningsordning.

### **Exportera till minne och inspektera artefakterna**

Detta fullständiga exempel laddar `pres.pptx`, samlar varje artefakt i en [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) och skriver ut dess namn, typ och byte‑antal. Det bevarar de angivna namnen exakt. Dubblettnamn markerar samlingen som ogiltig i stället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

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

    // Dekoda endast XAML, och endast när textuell inspektion behövs.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, även okända resurstypers. Låt inte byte‑värdena ändras vid lagring eller överföring. Använd [String‑konstruktorn](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) med UTF‑8 enbart för XAML som kräver textuell behandling.

### **Packa samlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar dess namn och skriver de ursprungliga bytena till ett ZIP‑arkiv. Ett unikt arkivnamn separerar samtidiga exportjobb. ZIP‑poster använder snedstreck och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering förkastas innan paketet skrivs.

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

    // ZIP-katalogen har finaliserats genom att stängas innan framgång rapporteras.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Exemplet använder [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring, ersätt steget för arkivskrivning med uppladdning av de samlade byte‑arrayerna. Använd ett export‑jobb‑identifierare plus det fullständiga relativa artefaktnamnet som blob‑nyckel, eller lagra jobb‑identifieraren, relativa namnet och binärdata i en databastrad. Publicera jobbet endast efter att alla uppladdningar slutförts eller databas‑transaktionen har begåtts. Rensa partiell utdata om persistensen misslyckas.

För stora presentationer kan en anpassad sparare persistera varje artefakt direkt till applikationslagring för att undvika att hålla en extra kopia av hela exporten i minnet. Håll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationssystemet har accepterat bytena och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte bara [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) såvida inte varje genererat namn är känt att vara unikt och resurssreferenser förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, förkasta rotade sökvägar och traversalsegment, lös destinationen med [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), och verifiera att den förblir under den avsedda exportkatalogen, inklusive katalogavgränsaren i kontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat sparare och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, analysera varje XAML‑dokument som XML och inspektera dess filbaserade resursreferenser, såsom bild‑`Source`‑ eller `ImageSource`‑attribut. Lös varje relativ URI mot den innehållande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande karta‑nyckel, ZIP‑post eller lagrat objekt finns. Behandla externa URI‑er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `pres/Slide_1.xaml` refererar till `images/image1.png`, måste den lagrade resursen finnas som `pres/images/image1.png`. Att bara lagra `image1.png` bryter relationen. För objektlagring, bevara samma struktur under jobb‑prefixet och gör dessa resurs‑URL:er åtkomliga för XAML‑konsumenten. Återöppna det färdiga ZIP‑arkivet för att verifiera postnamn och resurs‑byte, och ladda representativa bilder i målmiljön för att bekräfta att bilderna löser korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte är tillgängligt på maskinen?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) i [XamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/) — den används som fallback‑teckensnitt under export när originalet saknas. Detta garanterar inte att den genererade XAML‑referensen faktiskt använder fallback‑teckensnittet eller att teckensnittet finns på målmaskinen. Säkerställ att de teckensnitt som XAML refererar till finns i den miljö där den visas.

**Är den exporterade XAML endast avsedd för WPF, eller kan den också användas i andra XAML‑stackar?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) i [XamlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.