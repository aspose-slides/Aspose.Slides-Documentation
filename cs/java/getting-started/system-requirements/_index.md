---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/java/system-requirements/
keywords:
- systémové požadavky
- podporované platformy
- verze Javy
- JDK
- JRE
- fontconfig
- fonty
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zkontrolujte, co Aspose.Slides for Java potřebuje před instalací: podporované verze Javy a operační systémy, a knihovnu fontů a fonty, které Linux vyžaduje."
---
## **Úvod**

Aspose.Slides for Java je samostatná knihovna: nevyžaduje Microsoft PowerPoint ani Microsoft Office. Jedná se o jeden soubor JAR, publikovaný v Maven repozitáři Aspose. Soubor JAR obsahuje jen Java třídy a zdroje, bez nativních knihoven, a nevyžaduje žádné závislosti na dalších knihovnách. Stejný soubor tedy běží na každém operačním systému a procesoru, pro který je k dispozici podporované Java runtime.

V tomto článku jsou uvedeny podporované verze Javy a operační systémy a knihovna fontů a fonty, které Linux potřebuje, a na závěr je krátký program, který zkontroluje vaše nastavení. Pro přidání knihovny do projektu viz [Installation](/slides/cs/java/installation/).

## **Podporované verze Javy**

Aspose.Slides for Java běží na Java 8 nebo novější, s JDK či JRE. To zahrnuje dlouhodobě podporované verze Java 8, 11, 17, 21 a 25 a pozdější verze jako Java 26 a Java 27. Java runtime může pocházet od libovolného dodavatele, například Eclipse Temurin, Amazon Corretto, Oracle nebo balíčků OpenJDK v Linuxové distribuci.

Aspose.Slides nevyžaduje žádné JVM možnosti, jako `--add-opens`, na žádné z těchto verzí. Na Java 11 JVM vypíše varování, které začíná “WARNING: An illegal reflective access operation has occurred”; varování neovlivní výsledek.

{{% alert color="warning" title="Warning" %}}
Java 6 a Java 7 jsou zastaralé. Aspose.Slides for Java 26.9 na nich stále běží, ale vypisuje varování o zastarání. Od verze 26.10 je minimální požadovanou verzí Java 8 a Java 6 a Java 7 již nejsou podporovány.
{{% /alert %}}

Projekt Maven a příkazy v [Installation](/slides/cs/java/installation/) vyžadují JDK 11 nebo novější. S Java 8 můžete svůj program kompilovat a spouštět podle návodu v [Check Your Setup](#check-your-setup).

## **Podporované operační systémy**

Protože soubor JAR neobsahuje nativní kód, Aspose.Slides for Java běží na Windows, Linuxu a macOS, na libovolné architektuře procesoru, kterou podporuje Java runtime, například x64 a ARM64. Na Windows je jedinou podmínkou Java runtime. Na Linuxu Java také potřebuje knihovnu fontů a fonty popsané v [Linux](#linux).

## **Linux**

Aspose.Slides for Java vykresluje text s pomocí fontové podpory Java runtime. Na Linuxu tato podpora vyžaduje knihovnu fontconfig a alespoň jeden nainstalovaný font. Oficiální kontejnerové obrazy Linuxových distribucí často nic z toho neobsahují. Bez nich první příklad v [Create Presentations](/slides/cs/java/create-presentation/) selže při ukládání prezentace, vytvoří prázdný soubor a vypíše tuto chybu:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Oficiální kontejnerové obrazy `eclipse-temurin` pro Ubuntu i pro Alpine Linux již obsahují fontconfig a fonty DejaVu, takže na nich není nic potřeba instalovat. Na ostatních systémech nainstalujte balíčky uvedené níže. Příkazy pro Debian, Ubuntu a Red Hat používají `sudo`; v Dockerfile je spusťte v instrukci `RUN` bez `sudo`. Fonty DejaVu stačí k běhu Aspose.Slides; fonty, které vaše prezentace používají, jsou popsány v [Fonts](#fonts).

### **Debian a Ubuntu**

Pokud instalujete Javu z Debian nebo Ubuntu balíčků s výchozím nastavením `apt-get`, jak udává příkaz v [Installation](/slides/cs/java/installation/#linux), balíčky Javy také instalují knihovnu fontconfig, fonty DejaVu a knihovnu HarfBuzz, kterou tyto balíčky potřebují, a nic dalšího není vyžadováno.

Při použití Java runtime z jiného zdroje, například archivu Eclipse Temurin, nainstalujte fontconfig a fonty DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile často instaluje Debian nebo Ubuntu Java balíčky, jako `openjdk-21-jdk-headless` nebo `default-jdk-headless`, s volbou `--no-install-recommends`, která všechny tři vynechá. Nainstalujte fontconfig a fonty DejaVu pomocí výše uvedeného příkazu a také HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Bez HarfBuzz tyto Java balíčky vypisují `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` a ukládání selže s `UnsatisfiedLinkError`, který hlásí, že `libharfbuzz.so.0` nelze otevřít.

### **Red Hat Enterprise Linux**

Balíčky `java-<version>-openjdk-headless` v Red Hat Enterprise Linux neinstalují knihovnu fontconfig. Nainstalujte ji spolu s fonty DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Úplné balíčky `java-<version>-openjdk` instalují fontconfig a fonty jako závislosti a totéž platí pro balíčky Amazon Corretto v Amazon Linux 2023, například `java-21-amazon-corretto-headless`.

### **Alpine Linux**

V Dockerfile založeném na Alpine Linux nainstalujte fontconfig a fonty DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

V aktuálních Alpine verzích `ttf-dejavu` instaluje balíček `font-dejavu`. Nainstalujte Javu pomocí balíčku `openjdk<version>-jre` nebo `openjdk<version>-jdk`, například `openjdk25-jdk`. Balíčky `openjdk<version>-jre-headless` v Alpine Linux neobsahují fontovou knihovnu Javy, takže s nimi program selže s `UnsatisfiedLinkError: no fontmanager in system library path`, i když jsou fonty nainstalovány.

### **Fonty**

Aby se text vykresloval správnými fonty a metrikami, musí být na systému nainstalovány fonty, které vaše prezentace používají, nebo vhodné náhrady, nebo je musí načíst vaše aplikace. Viz [Deploy Fonts](/slides/cs/java/deploy-fonts/), [Font Substitution](/slides/cs/java/font-substitution/) a [Custom Fonts](/slides/cs/java/custom-font/).

## **Zkontrolujte své nastavení**

Pro ověření, že knihovna a její požadavky jsou splněny, spusťte program, který uloží prezentaci a vykreslí snímek do obrázku. Ukládání a vykreslování používají fontovou podporu Java runtime, kterou výše uvedené požadavky pro Linux poskytují.

Uložte níže uvedený kód jako *CheckSetup.java* do složky, která obsahuje soubor Aspose.Slides JAR. Pro stažení souboru JAR viz [Use the JAR File without Maven](/slides/cs/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Přidejte obdélník s textem na první snímek a uložte prezentaci.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Vykreslete snímek s jedním pixelem na bod a uložte obrázek.
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

S JDK 11 nebo novějším spusťte program v té složce pomocí následujícího příkazu. Pokud má váš soubor JAR jiný název, změňte jej v příkazech.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

S Java 8 nebo na systému, kde je jen JRE, program nejprve zkompilujte pomocí `javac` z JDK a pak spusťte zkompilovanou třídu. Na Linuxu a macOS spusťte:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Na Windows spusťte stejný příkaz `javac` a pak třídu s­emikolónem jako oddělovačem cest. Zachovejte uvozovky, aby PowerShell neinterpretoval středník jako konec příkazu: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Program přidá na první snímek obdélník s textem a uloží prezentaci jako *hello.pptx* pomocí metody [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Pak vykreslí snímek pomocí [getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-float-float-) a výsledek uloží jako *hello.png* pomocí [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ve formátu [ImageFormat.Png](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/). Škálovací faktor 1 vykresluje jeden pixel na bod, takže výchozí snímek 720 × 540 bodů se stane obrázkem 720 × 540 pixelů, přičemž text je viditelný uvnitř obdélníku. Bez licence oba soubory nesou vodotisk evaluační verze; viz [Licensing](/slides/cs/java/licensing/). Pokud chybí některý požadavek, program skončí jednou z chyb popsaných v [Linux](#linux).

## **Vývojové nástroje**

Můžete vytvářet aplikace používající Aspose.Slides s libovolným JDK podporované verze Javy. Použijte Apache Maven s Aspose Maven repozitářem, jak je popsáno v [Installation](/slides/cs/java/installation/), nebo jakýkoli jiný nástroj, který umí pracovat s Maven repozitářem. Můžete také ručně přidat soubor JAR do classpath vašeho IDE či build nástroje.

## **FAQ**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a vykreslování?**

Ne, PowerPoint není vyžadován. Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/java/create-presentation/), úpravy, [konverzi](/slides/cs/java/convert-presentation/) a [vykreslování](/slides/cs/java/convert-powerpoint-to-png/) prezentací.

**Vyžaduje Aspose.Slides for Java na Linuxovém serveru displej nebo desktopové prostředí?**

Ne. Aspose.Slides nevyžaduje X server ani displej, takže běží na serverech i v kontejnerech. Na Linuxu potřebuje jen knihovnu fontů a fonty popsané v [Linux](#linux).

**Jaké fonty jsou potřeba pro správné vykreslení?**

Musí být dostupné fonty použité v prezentaci nebo vhodné [náhrady](/slides/cs/java/font-substitution/). Na Linuxu a macOS nainstalujte fontové balíčky, které vaše prezentace potřebují, aby bylo zajištěno konzistentní vykreslování.

**Proč se vlastní font na Linuxu vykresluje jako náhradní nebo chybějící text?**

Pokud soubor fontu obsahuje nekonzistentní nebo poškozené záznamy v tabulce názvů, může Linuxová vrstva pro přiřazování fontů (FreeType/fontconfig) vybrat neplatný záznam, což způsobí, že font nebude rozpoznán. Použití verze fontu s opravenými záznamy tabulky názvů nebo instalace konzistentní náhrady problém vyřeší.