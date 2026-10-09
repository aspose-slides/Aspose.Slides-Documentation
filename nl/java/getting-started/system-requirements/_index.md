---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/java/system-requirements/
keywords:
- systeemvereisten
- ondersteunde platformen
- Java‑versies
- JDK
- JRE
- fontconfig
- lettertypen
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
description: "Controleer wat Aspose.Slides for Java nodig heeft voordat u het installeert: de ondersteunde Java‑versies en besturingssystemen, en de lettertype‑bibliotheek en lettertypen die Linux vereist."
---
## **Inleiding**

Aspose.Slides for Java is een zelfstandige bibliotheek: hij heeft geen Microsoft PowerPoint of Microsoft Office nodig. Het is één enkel JAR‑bestand, gepubliceerd in de Maven‑repository van Aspose. Het JAR‑bestand bevat alleen Java‑klassen en resources, zonder native bibliotheken, en verklaart geen afhankelijkheden van andere bibliotheken. Hetzelfde bestand draait daardoor op elk besturingssysteem en elke processor waarvoor een ondersteunde Java‑runtime beschikbaar is.

Dit artikel geeft een overzicht van de ondersteunde Java‑versies en besturingssystemen en van de lettertype‑bibliotheek en lettertypen die Linux nodig heeft, en eindigt met een kort programma dat uw installatie controleert. Om de bibliotheek aan een project toe te voegen, zie [Installatie](/slides/nl/java/installation/).

## **Ondersteunde Java‑versies**

Aspose.Slides for Java draait op Java 8 of later, met een JDK of een JRE. Dit omvat de long‑term support‑releases Java 8, 11, 17, 21 en 25, en latere releases zoals Java 26 en Java 27. De Java‑runtime kan van elke leverancier komen, bijvoorbeeld Eclipse Temurin, Amazon Corretto, Oracle, of de OpenJDK‑pakketten van een Linux‑distributie.

Aspose.Slides heeft geen JVM‑opties nodig, zoals `--add-opens`, in een van deze versies. Onder Java 11 geeft de JVM een waarschuwing die begint met "WARNING: An illegal reflective access operation has occurred"; deze waarschuwing heeft geen invloed op het resultaat.

{{% alert color="warning" title="Warning" %}}
Java 6 en Java 7 zijn verouderd. Aspose.Slides for Java 26.9 draait nog steeds op deze versies, maar geeft een verouderingswaarschuwing. Vanaf versie 26.10 is Java 8 het minimum, en Java 6 en Java 7 worden niet langer ondersteund.
{{% /alert %}}

Het Maven‑project en de opdrachten in [Installatie](/slides/nl/java/installation/) hebben JDK 11 of later nodig. Met Java 8 compileert en voert u uw programma uit zoals getoond in [Controleer uw installatie](#check-your-setup).

## **Ondersteunde besturingssystemen**

Omdat het JAR‑bestand geen native code bevat, draait Aspose.Slides for Java op Windows, Linux en macOS, op elke processorarchitectuur die de Java‑runtime ondersteunt, zoals x64 en ARM64. De Java‑runtime is de enige vereiste op Windows. Op Linux heeft de lettertype‑ondersteuning van Java ook de lettertype‑bibliotheek en lettertypen nodig die beschreven staan in [Linux](#linux).

## **Linux**

Aspose.Slides for Java legt tekst op en tekent deze met de lettertype‑ondersteuning van de Java‑runtime. Op Linux vereist die ondersteuning de fontconfig‑bibliotheek en minstens één geïnstalleerd lettertype. Officiële container‑images van Linux‑distributies hebben vaak geen van beide. Zonder deze faalt het eerste voorbeeld in [Presentaties maken](/slides/nl/java/create-presentation/) wanneer het de presentatie opslaat, laat het een leeg bestand achter en meldt deze fout:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

De officiële `eclipse-temurin`‑container‑images, voor Ubuntu en voor Alpine Linux, bevatten al fontconfig en de DejaVu‑lettertypen, zodat er niets op moet worden geïnstalleerd. Op andere systemen installeert u de onderstaande pakketten. De Debian‑, Ubuntu‑ en Red‑Hat‑opdrachten gebruiken `sudo`; in een Dockerfile voert u ze uit in een `RUN`‑instructie zonder `sudo`. De DejaVu‑lettertypen zijn voldoende voor Aspose.Slides om te draaien; de lettertypen die uw presentaties gebruiken staan beschreven in [Lettertypen](#fonts).

### **Debian en Ubuntu**

Als u Java installeert vanuit de Debian‑ of Ubuntu‑pakketten met de standaard `apt-get`‑instellingen, zoals de opdracht in [Installatie](/slides/nl/java/installation/#linux) doet, installeren de Java‑pakketten ook de fontconfig‑bibliotheek, de DejaVu‑lettertypen en de HarfBuzz‑bibliotheek die deze Java‑pakketten nodig hebben, en is er niets anders vereist.

Met een Java‑runtime uit een andere bron, zoals een Eclipse‑Temurin‑archief, installeert u fontconfig en de DejaVu‑lettertypen:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Een Dockerfile installeert vaak de Debian‑ of Ubuntu‑Java‑pakketten, zoals `openjdk-21-jdk-headless` of `default-jdk-headless`, met de `--no-install-recommends`‑optie, waardoor alle drie worden overgeslagen. Installeer fontconfig en de DejaVu‑lettertypen met de bovenstaande opdracht, en installeer ook HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Zonder HarfBuzz geven deze Java‑pakketten `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` weer, en slaagt het opslaan niet met een `UnsatisfiedLinkError` die meldt dat `libharfbuzz.so.0` niet kan worden geopend.

### **Red Hat Enterprise Linux**

De `java-<version>-openjdk-headless`‑pakketten van Red Hat Enterprise Linux installeren de fontconfig‑bibliotheek niet. Installeer deze samen met de DejaVu‑lettertypen:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

De volledige `java-<version>-openjdk`‑pakketten installeren fontconfig en lettertypen als afhankelijkheden, en dat doen ook de Amazon Corretto‑pakketten van Amazon Linux 2023, zoals `java-21-amazon-corretto-headless`.

### **Alpine Linux**

In een Dockerfile gebaseerd op Alpine Linux installeert u fontconfig en de DejaVu‑lettertypen:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Op huidige Alpine‑releases installeert `ttf-dejavu` het pakket `font-dejavu`. Installeer Java met het pakket `openjdk<version>-jre` of `openjdk<version>-jdk`, zoals `openjdk25-jdk`. De `openjdk<version>-jre-headless`‑pakketten van Alpine Linux bevatten niet de lettertype‑bibliotheek van Java, waardoor het programma met hen faalt met `UnsatisfiedLinkError: no fontmanager in system library path`, zelfs wanneer lettertypen geïnstalleerd zijn.

### **Lettertypen**

Om tekst met de juiste lettertypen en metrics weer te geven, moeten de lettertypen die uw presentaties gebruiken, of geschikte vervangingen, op het systeem geïnstalleerd of door uw applicatie geladen worden. Zie [Lettertypen implementeren](/slides/nl/java/deploy-fonts/), [Lettertype‑substitutie](/slides/nl/java/font-substitution/), en [Aangepaste lettertypen](/slides/nl/java/custom-font/).

## **Controleer uw installatie**

Om te controleren of de bibliotheek en de vereisten aanwezig zijn, voert u een programma uit dat een presentatie opslaat en een dia rendert naar een afbeelding. Opslaan en renderen maken gebruik van de lettertype‑ondersteuning van de Java‑runtime, hetgeen de hierboven genoemde Linux‑vereisten leveren.

Sla de onderstaande code op als *CheckSetup.java* in de map die het Aspose.Slides‑JAR‑bestand bevat. Om het JAR‑bestand te downloaden, zie [Gebruik het JAR‑bestand zonder Maven](/slides/nl/java/installation/#use-the-jar-file-without-maven).

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

            // Render de dia met één pixel per punt en sla de afbeelding op.
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

Met JDK 11 of later voert u het programma in die map uit met de onderstaande opdracht. Als uw JAR‑bestand een andere naam heeft, wijzig dan de naam in de opdrachten.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Met Java 8, of op een systeem dat alleen een JRE heeft, compileert u het programma met `javac` vanuit een JDK en voert u vervolgens de gecompileerde klasse uit. Op Linux en macOS voert u uit:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Op Windows voert u dezelfde `javac`‑opdracht uit, en vervolgens de klasse met een puntkomma als scheidingsteken voor het classpath. Houd de aanhalingstekens, zodat PowerShell de puntkomma niet als einde van de opdracht beschouwt: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Het programma voegt een rechthoek met tekst toe aan de eerste dia en slaat de presentatie op als *hello.pptx* met de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) methode. Vervolgens rendert het de dia met [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) en slaat het resultaat op als *hello.png* met [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) in het [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) formaat. De schaalfactoren van 1 renderen één pixel per punt, zodat de standaard dia van 720 × 540 punten een afbeelding van 720 × 540 pixels wordt, met de tekst zichtbaar binnen de rechthoek. Zonder licentie bevatten beide bestanden ook een evaluatiewatermerk; zie [Licensing](/slides/nl/java/licensing/). Als een vereiste ontbreekt, stopt het programma met een van de foutmeldingen die in [Linux](#linux) worden beschreven.

## **Ontwikkelhulpmiddelen**

U kunt applicaties bouwen die Aspose.Slides gebruiken met elke JDK van een ondersteunde Java‑versie. Gebruik Apache Maven met de Maven‑repository van Aspose, zoals beschreven in [Installatie](/slides/nl/java/installation/), of een ander build‑tool dat een Maven‑repository kan gebruiken. U kunt het JAR‑bestand ook zelf toevoegen aan het class‑path van uw IDE of build‑tool.

## **FAQ**

**Heb ik Microsoft PowerPoint geïnstalleerd nodig voor conversies en rendering?**

Nee, PowerPoint is niet vereist. Aspose.Slides is een zelfstandige engine voor [maken](/slides/nl/java/create-presentation/), wijzigen, [converteren](/slides/nl/java/convert-presentation/), en [renderen](/slides/nl/java/convert-powerpoint-to-png/) van presentaties.

**Heeft Aspose.Slides for Java een beeldscherm of een desktop‑omgeving nodig op een Linux‑server?**

Nee. Aspose.Slides heeft geen X‑server of beeldscherm nodig, dus het draait op servers en in containers. Op Linux heeft het alleen de lettertype‑bibliotheek en lettertypen nodig die beschreven staan in [Linux](#linux).

**Welke lettertypen zijn nodig voor correcte weergave?**

De in de presentatie gebruikte lettertypen, of geschikte [substituten](/slides/nl/java/font-substitution/), moeten beschikbaar zijn. Op Linux en macOS installeert u de lettertype‑pakketten die uw presentaties nodig hebben om consistente weergave te verkrijgen.

**Waarom wordt een aangepast lettertype op Linux weergegeven als fallback of ontbrekende tekst?**

Als het lettertype‑bestand inconsistente of beschadigde name‑table‑vermeldingen heeft, kan de Linux‑lettertype‑matching‑stack (FreeType/fontconfig) een ongeldige vermelding selecteren, waardoor het lettertype niet wordt herkend. Het gebruik van een lettertype‑versie met gecorrigeerde name‑table‑vermeldingen of het installeren van een consistente vervanging lost het probleem op.