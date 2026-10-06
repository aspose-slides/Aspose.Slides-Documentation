---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/java/system-requirements/
keywords:
- systeemvereisten
- ondersteunde platforms
- Java‑versies
- JDK
- JRE
- fontconfig
- fonts
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Controleer wat Aspose.Slides for Java nodig heeft voordat u het installeert: de ondersteunde Java‑versies en besturingssystemen, en de font‑bibliotheek en fonts die Linux vereist."
---
## **Inleiding**

Aspose.Slides for Java is een zelfstandige bibliotheek: het heeft geen Microsoft PowerPoint of Microsoft Office nodig. Het bestaat uit één enkel JAR‑bestand, gepubliceerd in de Maven‑repository van Aspose. Het JAR‑bestand bevat alleen Java‑klassen en resources, zonder native bibliotheken, en het heeft geen afhankelijkheden van andere bibliotheken. Hetzelfde bestand draait daarom op elk besturingssysteem en elke processor waarvoor een ondersteunde Java‑runtime beschikbaar is.

Dit artikel geeft een overzicht van de ondersteunde Java‑versies en besturingssystemen, de font‑bibliotheek en fonts die Linux nodig heeft, en eindigt met een kort programma dat uw installatie controleert. Zie voor het toevoegen van de bibliotheek aan een project [Installation](/slides/nl/java/installation/).

## **Ondersteunde Java‑versies**

Aspose.Slides for Java draait op Java 8 of hoger, met een JDK of een JRE. Dit omvat de long‑term support‑releases Java 8, 11, 17, 21 en 25, en latere releases zoals Java 26 en Java 27. De Java‑runtime kan van elke leverancier komen, bijvoorbeeld Eclipse Temurin, Amazon Corretto, Oracle, of de OpenJDK‑pakketten van een Linux‑distributie.

Aspose.Slides heeft geen JVM‑opties nodig, zoals `--add-opens`, op één van deze versies. Op Java 11 geeft de JVM een waarschuwing die begint met “WARNING: An illegal reflective access operation has occurred”; deze waarschuwing heeft geen invloed op het resultaat.

{{% alert color="warning" title="Waarschuwing" %}}
Java 6 en Java 7 zijn verouderd. Aspose.Slides for Java 26.9 draait nog wel op deze versies, maar geeft een deprecatiewaarschuwing. Vanaf versie 26.10 is Java 8 het minimum, en worden Java 6 en Java 7 niet meer ondersteund.
{{% /alert %}}

Het Maven‑project en de commando’s in [Installation](/slides/nl/java/installation/) vereisen JDK 11 of hoger. Met Java 8 kunt u uw programma compileren en uitvoeren zoals beschreven in [Check Your Setup](#check-your-setup).

## **Ondersteunde besturingssystemen**

Omdat het JAR‑bestand geen native code bevat, draait Aspose.Slides for Java op Windows, Linux en macOS, op elke processorarchitectuur die de Java‑runtime ondersteunt, zoals x64 en ARM64. De Java‑runtime is de enige vereiste op Windows. Op Linux heeft de font‑ondersteuning van Java ook de font‑bibliotheek en fonts nodig die in [Linux](#linux) worden beschreven.

## **Linux**

Aspose.Slides for Java layout en tekent tekst met de font‑ondersteuning van de Java‑runtime. Op Linux vereist die ondersteuning de fontconfig‑bibliotheek en minstens één geïnstalleerde font. Officiële container‑images van Linux‑distributies hebben vaak geen van beide. Zonder deze faalt het eerste voorbeeld in [Create Presentations](/slides/nl/java/create-presentation/) wanneer het de presentatie opslaat; er ontstaat een leeg bestand en de volgende fout wordt gerapporteerd:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

De officiële `eclipse‑temurin`‑container‑images, voor Ubuntu en voor Alpine Linux, bevatten al fontconfig en de DejaVu‑fonts, dus er hoeft niets geïnstalleerd te worden. Op andere systemen installeert u de onderstaande pakketten. De Debian, Ubuntu‑ en Red Hat‑commando’s gebruiken `sudo`; in een Dockerfile voert u ze uit in een `RUN`‑instructie zonder `sudo`. De DejaVu‑fonts zijn voldoende voor Aspose.Slides; de fonts die uw presentaties gebruiken, worden behandeld in [Fonts](#fonts).

### **Debian en Ubuntu**

Installeert u Java via de Debian‑ of Ubuntu‑pakketten met de standaard `apt‑get`‑instellingen, zoals het commando in [Installation](/slides/nl/java/installation/#linux) doet, dan installeren de Java‑pakketten ook de fontconfig‑bibliotheek, de DejaVu‑fonts en de HarfBuzz‑bibliotheek die deze Java‑pakketten nodig hebben; er is verder niets meer vereist.

Met een Java‑runtime uit een andere bron, bijvoorbeeld een Eclipse Temurin‑archief, installeert u fontconfig en de DejaVu‑fonts:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Een Dockerfile installeert vaak de Debian‑ of Ubuntu‑Java‑pakketten, zoals `openjdk-21-jdk-headless` of `default-jdk-headless`, met de optie `--no-install-recommends`, die alle drie overslaat. Installeer fontconfig en de DejaVu‑fonts met het bovenstaande commando, en installeer ook HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Zonder HarfBuzz geven deze Java‑pakketten de melding `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, en het opslaan faalt met een `UnsatisfiedLinkError` die aangeeft dat `libharfbuzz.so.0` niet kan worden geopend.

### **Red Hat Enterprise Linux**

De `java-<version>-openjdk-headless`‑pakketten van Red Hat Enterprise Linux installeren de fontconfig‑bibliotheek niet. Installeer deze samen met de DejaVu‑fonts:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

De volledige `java-<version>-openjdk`‑pakketten installeren fontconfig en fonts als afhankelijkheden, en dat geldt ook voor de Amazon Corretto‑pakketten van Amazon Linux 2023, zoals `java-21-amazon-corretto-headless`.

### **Alpine Linux**

In een Dockerfile gebaseerd op Alpine Linux installeert u fontconfig en de DejaVu‑fonts:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Op huidige Alpine‑releases installeert `ttf-dejavu` het pakket `font-dejavu`. Installeer Java met het pakket `openjdk<version>-jre` of `openjdk<version>-jdk`, bijvoorbeeld `openjdk25-jdk`. De `openjdk<version>-jre-headless`‑pakketten van Alpine Linux bevatten de Java‑font‑bibliotheek niet, waardoor het programma faalt met `UnsatisfiedLinkError: no fontmanager in system library path`, zelfs als de fonts wel geïnstalleerd zijn.

### **Fonts**

Om tekst correct weer te geven met de juiste fonts en metriek, moeten de fonts die uw presentaties gebruiken, of geschikte vervangingen, geïnstalleerd zijn op het systeem of geladen worden door uw applicatie. Zie [Deploy Fonts](/slides/nl/java/deploy-fonts/), [Font Substitution](/slides/nl/java/font-substitution/) en [Custom Fonts](/slides/nl/java/custom-font/).

## **Check Your Setup**

Om te controleren of de bibliotheek en de vereisten aanwezig zijn, voert u een programma uit dat een presentatie opslaat en een dia naar een afbeelding rendert. Opslaan en renderen maken gebruik van de font‑ondersteuning van de Java‑runtime, die door de bovenstaande Linux‑vereisten wordt geleverd.

Sla de onderstaande code op als *CheckSetup.java* in de map die het Aspose.Slides‑JAR‑bestand bevat. Voor het downloaden van het JAR‑bestand, zie [Use the JAR File without Maven](/slides/nl/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Voeg een rechthoek met tekst toe aan de eerste dia en sla de presentatie op.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Render de dia met één pixel per point en sla de afbeelding op.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Met JDK 11 of hoger voert u het programma in die map uit met het onderstaande commando. Als uw JAR‑bestand een andere naam heeft, wijzigt u de naam in de commando’s.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Met Java 8, of op een systeem dat alleen een JRE heeft, compileert u het programma met `javac` vanuit een JDK en voert u vervolgens de gecompileerde klasse uit. Op Linux en macOS voert u uit:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Op Windows voert u hetzelfde `javac`‑commando uit, en daarna de klasse met een puntkomma als scheidingsteken in de class‑path. Houd de aanhalingstekens, zodat PowerShell de puntkomma niet als einde van het commando beschouwt: `java -cp "aspose‑slides‑26.9‑jdk16.jar;." CheckSetup`.

Het programma voegt een rechthoek met tekst toe aan de eerste dia en slaat de presentatie op als *hello.pptx* met de [save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode. Vervolgens rendert het de dia met [getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getImage-float-float-) en slaat het resultaat op als *hello.png* met [IImage.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) in het [ImageFormat.Png](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/)‑formaat. Een schaalfactor van 1 rendert één pixel per point, dus de standaard 720 × 540‑point dia wordt een 720 × 540‑pixel afbeelding, met de tekst zichtbaar binnen de rechthoek. Zonder licentie bevatten beide bestanden een evaluatiewatermerk; zie [Licensing](/slides/nl/java/licensing/). Als er een vereiste ontbreekt, stopt het programma met een van de fouten die in [Linux](#linux) worden beschreven.

## **Development Tools**

U kunt applicaties bouwen die Aspose.Slides gebruiken met elke JDK van een ondersteunde Java‑versie. Gebruik Apache Maven met de Maven‑repository van Aspose, zoals beschreven in [Installation](/slides/nl/java/installation/), of een ander bouwgereedschap dat een Maven‑repository kan gebruiken. U kunt het JAR‑bestand ook handmatig aan het class‑path van uw IDE of build‑tool toevoegen.

## **FAQ**

**Moet Microsoft PowerPoint geïnstalleerd zijn voor conversies en rendering?**

Nee, PowerPoint is niet vereist. Aspose.Slides is een zelfstandige engine voor [creating](/slides/nl/java/create-presentation/), modifying, [converting](/slides/nl/java/convert-presentation/) en [rendering](/slides/nl/java/convert-powerpoint-to-png/) van presentaties.

**Heeft Aspose.Slides for Java een display of desktop‑omgeving nodig op een Linux‑server?**

Nee. Aspose.Slides heeft geen X‑server of display nodig, dus het werkt op servers en in containers. Op Linux heeft het alleen de font‑bibliotheek en fonts nodig die in [Linux](#linux) worden beschreven.

**Welke fonts zijn nodig voor correcte rendering?**

De fonts die in de presentatie worden gebruikt, of geschikte [substitutes](/slides/nl/java/font-substitution/), moeten beschikbaar zijn. Installeer op Linux en macOS de font‑pakketten die uw presentaties nodig hebben voor consistente weergave.

**Waarom wordt een aangepaste font op Linux als fallback of ontbrekende tekst weergegeven?**

Als het font‑bestand inconsistente of beschadigde name‑table‑records bevat, kan de Linux‑font‑matching‑stack (FreeType/fontconfig) een ongeldig record selecteren, waardoor het font niet wordt gevonden. Het gebruik van een font‑versie met gecorrigeerde name‑table‑records of het installeren van een consistente vervanging lost het probleem op.