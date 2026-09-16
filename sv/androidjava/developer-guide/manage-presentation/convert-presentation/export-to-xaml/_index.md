---
title: Exportera presentationer till XAML på Android
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i Java med Aspose.Slides för Android - en snabb, Office-fri lösning som bevarar din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint‑presentationer till XAML med Aspose.Slides för Android via Java. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor om reservteckensnitt, XAML‑stack‑kompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett XML‑baserat markeringsspråk som används för att beskriva användargränssnitt i ramverk som WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin.Forms.

Du kan arbeta med XAML‑filer i en visuell designer eller skriva och redigera markupen direkt.

## **Exportera presentationer till XAML med standardalternativ**

Följande Java‑exempel visar hur du exporterar en presentation till XAML med standardinställningar:

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

Som standard sparas de exporterade bilderna i en `pres`‑undermapp i processens aktuella arbetskatalog. Mappen skapas automatiskt och eventuella erforderliga bilder sparas där också.

Utgångsmappens namn tas från källfilens namn utan dess filändelse. För `pres.pptx` får utdatafilerna namnen `pres/Slide_1.xaml`, `pres/Slide_2.xaml` och så vidare. Även om du anger en absolut sökväg till inmatningspresentationen skapas utgångsmappen relativt till den aktuella arbetskatalogen, inte bredvid inmatningsfilen.

På Android använder du en inmatningsfil som är åtkomlig för din app. Den aktuella arbetskatalogen kanske inte är skrivbar; använd en anpassad output‑saver för att behålla exporten i minnet eller skriva den till appens lagring, som visas nedan. Den genererade WPF‑XAML‑koden är avsedd för en kompatibel konsument och är inte en Android‑layout‑resurs.

## **Exportera presentationer till XAML med anpassade alternativ**

Använd gränssnittet [IXamlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ixamloptions/) för att styra hur Aspose.Slides exporterar en presentation till XAML.

För att spara utdata på en anpassad plats, implementera [IXamlOutputSaver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ixamloutputsaver/) och skicka en instans av din implementation till metoden [setOutputSaver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) i [XamlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/).

För att inkludera dolda bilder i XAML‑utdata, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) med `true`, som visas i följande Java‑exempel:

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

En XAML‑export kan skapa ett XAML‑dokument för varje exporterad bild samt separata bilder och stödjande resurser. Tilldela en anpassad [IXamlOutputSaver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ixamloutputsaver/) till [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) för att ta emot dessa artefakter istället för standard‑filsystem‑saver. Starta exporten med den XAML‑specifika [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑överladdningen som accepterar XAML‑alternativ.

### **Förstå återuppringningslivscykeln**

Exportören anropar [IXamlOutputSaver.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separat för varje genererad artefakt:

- `path` identifierar artefakten och kan innehålla relativa kataloger. Behåll denna information eftersom XAML kan referera resurser med relativa sökvägar.
- `data` innehåller artefaktens byte‑array. Bilder och andra binära resurser får inte avkodas som text.
- Saver‑implementeringen ansvarar för att behålla eller bestå data innan den returneras. Exemplen kopierar varje byte‑array till minne som ägs av applikationen.
- Betrakta exporten som lyckad endast när presentations‑spara‑operationen har returnerat och varje återuppringning har slutförts utan fel. Undvik att svälja lagringsfel eller starta oövervakade bakgrundsskrivningar. Om bestående sker i efterhand, rapportera total framgång först när även detta steg lyckas.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) gäller även för en anpassad saver. Standardvärdet, `false`, exkluderar XAML‑dokument för dolda bilder. Att ange `true` inkluderar dem samt alla resurser som krävs för deras export. Resursantalet beror på presentationen; anta inte en återuppringning per bild eller ett fast återuppringningsordning.

### **Exportera till minne och inspektera artefakter**

Detta kompletta exempel laddar `pres.pptx`, samlar varje artefakt i en [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) och skriver ut namn, typ och byte‑antal. Det bevarar exakt de angivna namnen. Dubblettnamn gör samlingen ogiltig i stället för att tyst skriva över en artefakt. Exemplet kontrollerar detta innan resultaten används.

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

Filändelsekontroller är användbara för inspektion; behåll alla artefakter, även ovanliga resurstypers. Lämna byte‑värdena oförändrade vid lagring eller överföring. Använd [String‑konstruktorn](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) med UTF‑8 enbart för XAML som behöver textuell bearbetning.

### **Packa samlade artefakter i ett ZIP‑arkiv**

Detta fristående exempel samlar exporten, validerar namnen och skriver de ursprungliga bytena till ett ZIP‑arkiv. Ersätt `/path/to/app/files` med sökvägen som returneras av din Android‑kontexts [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir())‑metod. Ett unikt arkivnamn skiljer samtidiga exportjobb. ZIP‑poster använder framåtsnedstreck och behåller relativa kataloger. Osäkra namn eller namn som kolliderar efter normalisering förkastas innan paketet skrivs.

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

    // ZIP-katalogen har slutförts genom att stängas innan framgång rapporteras.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Exemplet använder [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) för att skriva ett lokalt arkiv; exportören själv skriver inte lösa XAML‑ eller bildfiler. För fjärrlagring ersätt arkiv‑skrivningssteget med uppladdningar av de samlade byte‑arrayerna. Använd ett export‑jobb‑identifierare plus det fullständiga relativa artefaktnamnet som blob‑nyckel, eller lagra jobb‑identifieraren, relativt namn och binär data i en databasrad. Publicera jobbet först när alla uppladdningar är klara eller databas‑transaktionen har kommit. Rensa delvis utdata om beståndet misslyckas.

För stora presentationer kan en anpassad saver bestå varje artefakt direkt i applikationslagring för att undvika att hålla en extra kopia av hela exporten i minnet. Håll varje återuppringning synkron från exportörens perspektiv: returnera först när destinationen har accepterat bytena, och låt fel nå anroparen.

### **Bevara resursnamn och verifiera referenser**

- Normalisera sökvägsavgränsare när destinationen kräver det, men bevara relativa kataloger. Använd inte bara [File.getName](https://developer.android.com/reference/java/io/File#getName/) om inte varje genererat namn är garanterat unikt och resursreferenser förblir giltiga.
- Tillämpa destinationsspecifik namnvalidering. När du skriver lösa filer, förkasta rotade sökvägar och traversalsegment, lös destinationen med [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath/) och verifiera att den ligger under den avsedda exportkatalogen, inklusive katalogavgränsaren i innehållskontrollen. Använd en applikationsstyrd katalog utan symboliska länkar som kan omdirigera skrivningar.
- Använd en separat saver och lagrings‑namnrymd för varje exportjobb. Upptäck kollisioner efter separator‑normalisering och enligt destinationens skiftlägeskänsliga regler.
- Innan publicering, pars varje XAML‑dokument som XML och inspektera dess filbaserade resursreferenser, t.ex. bild‑`Source` eller `ImageSource`‑attribut. Lös varje relativ URI mot den omgivande XAML‑artefaktens katalog, normalisera det resulterande lagringsnamnet och bekräfta att motsvarande nyckel i kartan, ZIP‑post eller lagrad objekt finns. Hantera externa URI:er och XAML‑markup‑uttryck separat från relativa filnamn.

Till exempel, om `pres/Slide_1.xaml` refererar `images/image1.png`, måste den lagrade resursen finnas som `pres/images/image1.png`. Att bara behålla `image1.png` skulle bryta relationen. För objektlagring, bevara samma struktur under jobb‑prefixet och gör dessa resurs‑URL:er tillgängliga för XAML‑konsumenten. Öppna det färdiga ZIP‑arkivet för att verifiera postnamn och resurs‑byten, och ladda representativa bilder i mål‑XAML‑miljön för att bekräfta att bilderna löses korrekt.

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om originalteckensnittet saknas på maskinen?**

Anropa [setDefaultRegularFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) i [XamlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/) — den används som reservteckensnitt vid export när originalet saknas. Detta garanterar inte att den genererade XAML‑filen refererar reservteckensnittet eller att teckensnittet finns på målmaskinen. Se till att teckensnitten som XAML‑filen refererar till är tillgängliga i den miljö där den visas.

**Är den exporterade XAML‑filen avsedd enbart för WPF, eller kan den användas i andra XAML‑stackar också?**

Aspose.Slides exporterar WPF‑XAML via sitt publika API. Kompatibilitet med andra XAML‑stackar, såsom UWP och Xamarin.Forms, är inte garanterad. Testa den genererade markupen i din målmiljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) i [XamlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.