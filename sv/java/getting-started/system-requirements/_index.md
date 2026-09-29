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
description: "Kontrollera vad Aspose.Slides for Java behöver innan du installerar det: de stödda Java-versionerna och operativsystemen, samt teckensnittsbiblioteket och teckensnitten som Linux kräver."
---
## **Introduktion**

Aspose.Slides for Java är ett fristående bibliotek: det kräver varken Microsoft PowerPoint eller Microsoft Office. Det är en enda JAR‑fil som publiceras i Asposes Maven‑arkiv. JAR‑filen innehåller bara Java‑klasser och resurser, utan inhemska bibliotek, och den deklarerar inga beroenden på andra bibliotek. Samma fil kör därför på alla operativsystem och processorer som har en stödjande Java‑runtime tillgänglig.

Den här artikeln listar de Java‑versioner och operativsystem som stöds samt teckensnittsbiblioteket och teckensnitten som Linux behöver, och avslutas med ett kort program som kontrollerar din installation. För att lägga till biblioteket i ett projekt, se [Installation](/slides/sv/java/installation/).

## **Stödda Java‑versioner**

Aspose.Slides for Java körs på Java 8 eller senare, med en JDK eller en JRE. Detta inkluderar långtidssupport‑versionerna Java 8, 11, 17, 21 och 25, samt senare versioner som Java 26 och Java 27. Java‑runtime kan komma från valfri leverantör, till exempel Eclipse Temurin, Amazon Corretto, Oracle eller OpenJDK‑paketen i en Linux‑distribution.

Aspose.Slides kräver inga JVM‑alternativ, såsom `--add-opens`, på någon av dessa versioner. På Java 11 skriver JVM ut en varning som börjar med “WARNING: An illegal reflective access operation has occurred”; varningen påverkar inte resultatet.

{{% alert color="warning" title="Warning" %}}
Java 6 och Java 7 är föråldrade. Aspose.Slides for Java 26.9 körs fortfarande på dem men skriver en avskrivningsvarning. Från och med version 26.10 är Java 8 minimum, och Java 6 och Java 7 stöds inte längre.
{{% /alert %}}

Maven‑projektet och kommandona i [Installation](/slides/sv/java/installation/) kräver JDK 11 eller senare. Med Java 8 kompilerar och kör du ditt program som visas i [Kontrollera din konfiguration](#check-your-setup).

## **Stödda operativsystem**

Eftersom JAR‑filen saknar inhemsk kod kör Aspose.Slides for Java på Windows, Linux och macOS, på alla processorarkitekturer som Java‑runtime stödjer, såsom x64 och ARM64. Java‑runtime är det enda kravet på Windows. På Linux kräver Java:s teckensnittsstöd också teckensnittsbiblioteket och teckensnitten som beskrivs i [Linux](#linux).

## **Linux**

Aspose.Slides for Java lägger ut och ritar text med teckensnittsstödet i Java‑runtime. På Linux kräver detta stöd teckensnittsbiblioteket fontconfig och minst ett installerat teckensnitt. Officiella container‑bilder för Linux‑distributioner har ofta ingen av dem. Utan dem misslyckas det första exemplet i [Create Presentations](/slides/sv/java/create-presentation/) när det sparar presentationen, lämnar en tom fil och rapporterar följande fel:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

De officiella `eclipse-temurin`‑container‑bilderna, för Ubuntu och för Alpine Linux, innehåller redan fontconfig och DejaVu‑teckensnitten, så inget behöver installeras på dem. På andra system installerar du paketen nedan. Debian‑, Ubuntu‑ och Red Hat‑kommandona använder `sudo`; i en Dockerfile kör du dem i en `RUN`‑instruktion utan `sudo`. DejaVu‑teckensnitten räcker för att Aspose.Slides ska fungera; de teckensnitt som dina presentationer använder täcks i [Typsnitt](#fonts).

### **Debian och Ubuntu**

Om du installerar Java från Debian‑ eller Ubuntu‑paketen med standardinställningarna för `apt-get`, som kommandot i [Installation](/slides/sv/java/installation/#linux) gör, installerar Java‑paketen också fontconfig‑biblioteket, DejaVu‑teckensnitten och HarfBuzz‑biblioteket som dessa Java‑paket behöver, och inget annat krävs.

Med en Java‑runtime från en annan källa, till exempel ett Eclipse Temurin‑arkiv, installerar du fontconfig och DejaVu‑teckensnitten:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

En Dockerfile installerar ofta Debian‑ eller Ubuntu‑Java‑paketen, såsom `openjdk-21-jdk-headless` eller `default-jdk-headless`, med flaggan `--no-install-recommends`, vilket hoppar över alla tre. Installera fontconfig och DejaVu‑teckensnitten med kommandot ovan, och installera även HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Utan HarfBuzz skriver dessa Java‑paket `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, och sparande misslyckas med ett `UnsatisfiedLinkError` som rapporterar att `libharfbuzz.so.0` inte kan öppnas.

### **Red Hat Enterprise Linux**

`java-<version>-openjdk-headless`‑paketen i Red Hat Enterprise Linux installerar inte fontconfig‑biblioteket. Installera det tillsammans med DejaVu‑teckensnitten:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

De fullständiga `java-<version>-openjdk`‑paketen installerar fontconfig och teckensnitt som beroenden, och det gör även Amazon Corretto‑paketen i Amazon Linux 2023, till exempel `java-21-amazon-corretto-headless`.

### **Alpine Linux**

I en Dockerfile baserad på Alpine Linux installerar du fontconfig och DejaVu‑teckensnitten:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

I aktuella Alpine‑utgåvor installerar `ttf-dejavu` paketet `font-dejavu`. Installera Java med paketet `openjdk<version>-jre` eller `openjdk<version>-jdk`, till exempel `openjdk25-jdk`. `openjdk<version>-jre-headless`‑paketen i Alpine Linux innehåller inte Java:s teckensnittsbibliotek, så med dem misslyckas programmet med `UnsatisfiedLinkError: no fontmanager in system library path`, även om teckensnitten är installerade.

### **Typsnitt**

För att text ska renderas med rätt teckensnitt och mått måste de teckensnitt som dina presentationer använder, eller lämpliga ersättningar, vara installerade på systemet eller laddas av din applikation. Se [Deploy Fonts](/slides/sv/java/deploy-fonts/), [Font Substitution](/slides/sv/java/font-substitution/) och [Custom Fonts](/slides/sv/java/custom-font/).

## **Kontrollera din konfiguration**

För att kontrollera att biblioteket och dess krav är på plats kör du ett program som sparar en presentation och renderar en bild på en bildruta. Sparande och rendering använder teckensnittsstödet i Java‑runtime, vilket är vad Linux‑kraven ovan tillhandahåller.

Spara koden nedan som *CheckSetup.java* i mappen som innehåller Aspose.Slides‑JAR‑filen. För att ladda ner JAR‑filen, se [Use the JAR File without Maven](/slides/sv/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Lägg till en rektangel med text på den första bilden och spara presentationen.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Rendera bilden med en pixel per punkt och spara bilden.
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

Med JDK 11 eller senare kör du programmet i den mappen med kommandot nedan. Om din JAR‑fil har ett annat namn, ändra namnet i kommandona.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Med Java 8, eller på ett system som bara har en JRE, kompilera programmet med `javac` från en JDK och kör sedan den kompilerade klassen. På Linux och macOS kör du:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

På Windows kör du samma `javac`‑kommando och kör sedan klassen med ett semikolon som klassvägsavgränsare. Behåll citationstecken så att PowerShell inte behandlar semikolonet som kommandoavslut: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Programmet lägger till en rektangel med text på den första bilden och sparar presentationen som *hello.pptx* med metoden [save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Det renderar sedan bilden med [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getImage-float-float-) och sparar resultatet som *hello.png* med [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/#save-java.lang.String-int-) i formatet [ImageFormat.Png](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/). Skalfaktorerna 1 renderar en pixel per punkt, så standardbilden 720 × 540 punkter blir en 720 × 540‑pixel‑bild med texten synlig i rektangeln. Utan licens har båda filerna även ett utvärderingsvattenstämpel; se [Licensing](/slides/sv/java/licensing/). Om ett krav saknas avbryts programmet med ett av felen som beskrivs i [Linux](#linux).

## **Utvecklingsverktyg**

Du kan bygga applikationer som använder Aspose.Slides med vilken JDK som helst för en stödjande Java‑version. Använd Apache Maven med Asposes Maven‑arkiv, enligt beskrivningen i [Installation](/slides/sv/java/installation/), eller vilket annat byggverktyg som kan använda ett Maven‑arkiv. Du kan också lägga till JAR‑filen i klassvägen för din IDE eller ditt byggverktyg själv.

## **Vanliga frågor**

**Behöver jag ha Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte. Aspose.Slides är en fristående motor för [creating](/slides/sv/java/create-presentation/), modifiering, [converting](/slides/sv/java/convert-presentation/) och [rendering](/slides/sv/java/convert-powerpoint-to-png/) av presentationer.

**Behöver Aspose.Slides for Java en skärm eller en skrivbordsmiljö på en Linux‑server?**

Nej. Aspose.Slides behöver ingen X‑server eller skärm, så det körs på servrar och i containers. På Linux krävs bara teckensnittsbiblioteket och teckensnitten som beskrivs i [Linux](#linux).

**Vilka teckensnitt behövs för korrekt rendering?**

De teckensnitt som används i presentationen, eller lämpliga [substitutes](/slides/sv/java/font-substitution/), måste finnas tillgängliga. På Linux och macOS installerar du teckensnittspaketen som dina presentationer behöver för att få enhetlig rendering.

**Varför renderas ett anpassat teckensnitt som en reserv eller saknad text på Linux?**

Om teckensnittsfilen har inkonsekventa eller korrupta namn‑tabell‑poster kan Linux‑stacken för teckensnittsmatchning (FreeType/fontconfig) välja en ogiltig post, vilket gör att teckensnittet blir olöst. Att använda en teckensnittsversion med korrigerade namn‑tabell‑poster eller installera ett konsekvent ersättnings‑teckensnitt löser problemet.