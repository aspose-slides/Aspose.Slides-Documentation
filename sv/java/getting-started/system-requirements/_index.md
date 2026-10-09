---
title: Systemkrav
type: docs
weight: 60
url: /sv/java/system-requirements/
keywords:
- systemkrav
- stödda plattformar
- Java-versioner
- JDK
- JRE
- fontconfig
- teckensnitt
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Kontrollera vad Aspose.Slides for Java behöver innan du installerar det: de stödda Java-versionerna och operativsystemen samt teckensnittsbiblioteket och teckensnitten som Linux kräver."
---
## **Introduktion**

Aspose.Slides for Java är ett fristående bibliotek: det kräver inte Microsoft PowerPoint eller Microsoft Office. Det är en enda JAR‑fil, publicerad i Asposes Maven‑arkiv. JAR‑filen innehåller endast Java‑klasser och resurser, utan inhemska bibliotek, och deklarerar inga beroenden på andra bibliotek. Samma fil kör därför på alla operativsystem och processorer som har en stödd Java‑runtime tillgänglig.

Denna artikel listar de stödda Java‑versionerna och operativsystemen samt teckensnittsbiblioteket och teckensnitten som Linux behöver, och avslutas med ett kort program som kontrollerar din installation. För att lägga till biblioteket i ett projekt, se [Installation](/slides/sv/java/installation/).

## **Stödda Java‑versioner**

Aspose.Slides for Java körs på Java 8 eller senare, med en JDK eller en JRE. Detta inkluderar LTS‑utgåvorna Java 8, 11, 17, 21 och 25 samt senare versioner som Java 26 och Java 27. Java‑runtime kan komma från vilken leverantör som helst, till exempel Eclipse Temurin, Amazon Corretto, Oracle eller OpenJDK‑paketen från en Linux‑distribution.

Aspose.Slides kräver inga JVM‑alternativ, såsom `--add-opens`, i någon av dessa versioner. På Java 11 skriver JVM ut en varning som börjar med "WARNING: An illegal reflective access operation has occurred"; varningen påverkar inte resultatet.

{{% alert color="warning" title="Warning" %}}
Java 6 och Java 7 är föråldrade. Aspose.Slides for Java 26.9 kör fortfarande på dem men skriver en avskrivningsvarning. Från och med version 26.10 är Java 8 det lägsta kravet, och Java 6 och Java 7 stöds inte längre.
{{% /alert %}}

Maven‑projektet och kommandona i [Installation](/slides/sv/java/installation/) kräver JDK 11 eller senare. Med Java 8 kompilerar och kör du ditt program som visas i [Kontrollera din installation](#check-your-setup).

## **Stödda operativsystem**

Eftersom JAR‑filen inte innehåller någon inhemsk kod kör Aspose.Slides for Java på Windows, Linux och macOS, på vilken processorarkitektur som helst som Java‑runtime stödjer, såsom x64 och ARM64. Java‑runtime är det enda kravet på Windows. På Linux kräver Java:s teckensnittsstöd även teckensnittsbiblioteket och teckensnitten som beskrivs i [Linux](#linux).

## **Linux**

Aspose.Slides for Java placerar och ritar text med teckensnittsstödet i Java‑runtime. På Linux kräver det stödet fontconfig‑biblioteket och minst ett installerat teckensnitt. Officiella container‑bilder av Linux‑distributioner har ofta ingen av dem. Utan dem misslyckas det första exemplet i [Skapa presentationer](/slides/sv/java/create-presentation/) när det sparar presentationen, lämnar en tom fil och rapporterar detta fel:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

De officiella `eclipse-temurin`‑containerbilderna för Ubuntu och för Alpine Linux innehåller redan fontconfig och DejaVu‑teckensnitten, så inget behöver installeras på dem. På andra system installerar du paketen nedan. Debian‑, Ubuntu‑ och Red Hat‑kommandona använder `sudo`; i en Dockerfile kör du dem i en `RUN`‑instruktion utan `sudo`. DejaVu‑teckensnitten räcker för att Aspose.Slides ska fungera; de teckensnitt som dina presentationer använder behandlas i [Teckensnitt](#fonts).

### **Debian och Ubuntu**

Om du installerar Java från Debian‑ eller Ubuntu‑paketen med standardinställningarna för `apt-get`, som kommandot i [Installation](/slides/sv/java/installation/#linux) gör, installerar Java‑paketen också fontconfig‑biblioteket, DejaVu‑teckensnitten och HarfBuzz‑biblioteket som dessa Java‑paket behöver, och inget annat krävs.

Med en Java‑runtime från en annan källa, t.ex. ett Eclipse Temurin‑arkiv, installera fontconfig och DejaVu‑teckensnitten:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

En Dockerfile installerar ofta Debian‑ eller Ubuntu‑Java‑paket, såsom `openjdk-21-jdk-headless` eller `default-jdk-headless`, med flaggan `--no-install-recommends`, vilket hoppar över alla tre. Installera fontconfig och DejaVu‑teckensnitten med kommandot ovan, och installera även HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Utan HarfBuzz skriver dessa Java‑paket `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, och sparandet misslyckas med ett `UnsatisfiedLinkError` som rapporterar att `libharfbuzz.so.0` inte kan öppnas.

### **Red Hat Enterprise Linux**

`java-<version>-openjdk-headless`‑paketen för Red Hat Enterprise Linux installerar inte fontconfig‑biblioteket. Installera det tillsammans med DejaVu‑teckensnitten:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

De fullständiga `java-<version>-openjdk`‑paketen installerar fontconfig och teckensnitt som beroenden, liksom Amazon Corretto‑paketen för Amazon Linux 2023, såsom `java-21-amazon-corretto-headless`.

### **Alpine Linux**

I en Dockerfile baserad på Alpine Linux, installera fontconfig och DejaVu‑teckensnitten:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

På nuvarande Alpine‑utgåvor installerar `ttf-dejavu` paketet `font-dejavu`. Installera Java med paketet `openjdk<version>-jre` eller `openjdk<version>-jdk`, till exempel `openjdk25-jdk`. `openjdk<version>-jre-headless`‑paketen för Alpine Linux innehåller inte Java:s teckensnittsbibliotek, så med dem misslyckas programmet med `UnsatisfiedLinkError: no fontmanager in system library path`, även när teckensnitt är installerade.

### **Teckensnitt**

För att text ska renderas med rätt teckensnitt och mått måste de teckensnitt som dina presentationer använder, eller lämpliga ersättningar, vara installerade på systemet eller laddas av din applikation. Se [Distribuera teckensnitt](/slides/sv/java/deploy-fonts/), [Teckensnittsersättning](/slides/sv/java/font-substitution/), och [Anpassade teckensnitt](/slides/sv/java/custom-font/).

## **Kontrollera din installation**

För att kontrollera att biblioteket och dess krav är på plats, kör ett program som sparar en presentation och renderar en bild från en bildruta. Sparande och rendering använder Java‑runtime‑teckensnittsstödet, vilket är det som Linux‑kraven ovan tillhandahåller.

Spara koden nedan som *CheckSetup.java* i mappen som innehåller Aspose.Slides‑JAR‑filen. För att ladda ner JAR‑filen, se [Använd JAR‑filen utan Maven](/slides/sv/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Lägg till en rektangel med text på den första bildrutan och spara presentationen.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Rendera bildrutan med en pixel per punkt och spara bilden.
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

Med JDK 11 eller senare, kör programmet i den mappen med kommandot nedan. Om din JAR‑fil har ett annat namn, ändra namnet i kommandona.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Med Java 8, eller på ett system som bara har en JRE, kompilera programmet med `javac` från en JDK och kör sedan den kompilerade klassen. På Linux och macOS, kör:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

På Windows kör du samma `javac`‑kommando och sedan klassen med ett semikolon som klassvägsavgränsare. Behåll citationstecknen så att PowerShell inte behandlar semikolonet som kommandoavslut: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Programmet lägger till en rektangel med text på den första bildrutan och sparar presentationen som *hello.pptx* med [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑metoden. Det renderar sedan bildrutan med [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) och sparar resultatet som *hello.png* med [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) i formatet [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Skalningsfaktorn 1 renderar en pixel per punkt, så standardbildrutan på 720 × 540 punkter blir en bild på 720 × 540 pixlar, med texten synlig i rektangeln. Utan licens har båda filerna också ett utvärderingsvattenstämpel; se [Licensing](/slides/sv/java/licensing/). Om ett krav saknas stoppar programmet med ett av felen som beskrivs i [Linux](#linux).

## **Utvecklingsverktyg**

Du kan bygga applikationer som använder Aspose.Slides med vilken JDK som helst av en stödd Java‑version. Använd Apache Maven med Asposes Maven‑arkiv, enligt beskrivningen i [Installation](/slides/sv/java/installation/), eller något annat byggverktyg som kan använda ett Maven‑arkiv. Du kan också själv lägga till JAR‑filen i klassvägen för din IDE eller ditt byggverktyg.

## **FAQ**

**Behöver jag Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte. Aspose.Slides är en fristående motor för [skapa](/slides/sv/java/create-presentation/), modifiering, [konvertera](/slides/sv/java/convert-presentation/), och [rendera](/slides/sv/java/convert-powerpoint-to-png/) presentationer.

**Behöver Aspose.Slides for Java en display eller en skrivbordsmiljö på en Linux‑server?**

Nej. Aspose.Slides behöver ingen X‑server eller display, så det körs på servrar och i containrar. På Linux krävs endast teckensnittsbiblioteket och teckensnitten som beskrivs i [Linux](#linux).

**Vilka teckensnitt behövs för korrekt rendering?**

De teckensnitt som används i presentationen, eller lämpliga [ersättningar](/slides/sv/java/font-substitution/), måste finnas tillgängliga. På Linux och macOS installerar du de teckensnittspaket som dina presentationer behöver för att få konsekvent rendering.

**Varför renderas ett eget teckensnitt som en reserv eller saknad text på Linux?**

Om teckensnittsfilen har inkonsekventa eller korrupta namn‑tabellsposter kan Linux‑teckensnittsmatchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att teckensnittet blir olöst. Att använda en teckensnitts­version med korrigerade namn‑tabellsposter eller att installera en konsekvent ersättning löser problemet.