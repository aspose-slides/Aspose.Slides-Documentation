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
- písma
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
description: "Zkontrolujte, co Aspose.Slides for Java potřebuje před instalací: podporované verze Javy a operační systémy a knihovna písem a písma, která Linux vyžaduje."
---
## **Úvod**

Aspose.Slides for Java je samostatná knihovna: nepotřebuje Microsoft PowerPoint ani Microsoft Office. Jedná se o jediný soubor JAR, který je publikován v Maven repozitáři společnosti Aspose. Soubor JAR obsahuje pouze třídy a zdroje v jazyce Java, neobsahuje nativní knihovny a nevyžaduje žádné závislosti na jiných knihovnách. Tento soubor tedy běží na každém operačním systému a procesoru, pro který je k dispozici podporované prostředí Java.

Tento článek uvádí podporované verze Javy a operační systémy a knihovnu písem a písma, která Linux potřebuje, a končí krátkým programem, který kontroluje vaše nastavení. Pro přidání knihovny do projektu viz [Instalace](/slides/cs/java/installation/).

## **Podporované verze Javy**

Aspose.Slides for Java běží na Java 8 nebo novější, s JDK nebo JRE. To zahrnuje verze s dlouhodobou podporou Java 8, 11, 17, 21 a 25 a novější verze jako Java 26 a 27. Java runtime může pocházet od libovolného dodavatele, například Eclipse Temurin, Amazon Corretto, Oracle nebo balíčky OpenJDK v Linuxové distribuci.

Aspose.Slides nevyžaduje žádné možnosti JVM, jako je `--add-opens`, v žádné z těchto verzí. V Javě 11 JVM vypíše varování, které začíná textem "WARNING: An illegal reflective access operation has occurred"; varování neovlivňuje výsledek.

{{% alert color="warning" title="Warning" %}}
Java 6 a Java 7 jsou zastaralé. Aspose.Slides for Java 26.9 na nich stále běží, ale vypisuje varování o zastaralosti. Od verze 26.10 je minimální verzí Java 8 a Java 6 a Java 7 již nejsou podporovány.
{{% /alert %}}

Projekt Maven a příkazy v [Instalace](/slides/cs/java/installation/) vyžadují JDK 11 nebo novější. S Javou 8 zkompilujte a spusťte svůj program podle návodu v [Zkontrolujte nastavení](#check-your-setup).

## **Podporované operační systémy**

Protože soubor JAR neobsahuje nativní kód, Aspose.Slides for Java běží na Windows, Linuxu a macOS, na jakékoli architektuře procesoru, kterou podporuje Java runtime, například x64 a ARM64. Požadavkem na Windows je pouze Java runtime. Na Linuxu podporu písem Java rovněž vyžaduje knihovnu písem a písma popsaná v [Linux](#linux).

## **Linux**

Aspose.Slides for Java vykresluje a kreslí text pomocí podpory písem Java runtime. Na Linuxu tato podpora vyžaduje knihovnu fontconfig a alespoň jedno nainstalované písmo. Oficiální kontejnery Linuxových distribucí často neobsahují žádné z nich. Bez nich první příklad v [Vytvoření prezentací](/slides/cs/java/create-presentation/) selže při ukládání prezentace, vytvoří prázdný soubor a vypíše tuto chybu:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Oficiální kontejnery `eclipse-temurin` pro Ubuntu i Alpine Linux již obsahují fontconfig a písma DejaVu, takže není třeba nic instalovat. Na ostatních systémech nainstalujte balíčky uvedené níže. Příkazy pro Debian, Ubuntu a Red Hat používají `sudo`; v Dockerfile je spusťte v instrukci `RUN` bez `sudo`. Písma DejaVu jsou dostačující pro běh Aspose.Slides; písma, která vaše prezentace používají, jsou pokryta v sekci [Písma](#fonts).

### **Debian a Ubuntu**

Pokud instalujete Javu z balíčků Debian nebo Ubuntu s výchozím nastavením `apt-get`, jak ukazuje příkaz v [Instalace](/slides/cs/java/installation/#linux), nainstalují se také knihovna fontconfig, písma DejaVu a knihovna HarfBuzz, které tyto balíčky Javy potřebují, a nic dalšího není vyžadováno.

Při použití Java runtime z jiného zdroje, například archiv Eclipse Temurin, nainstalujte fontconfig a písma DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile často instaluje balíčky Debian nebo Ubuntu Java, například `openjdk-21-jdk-headless` nebo `default-jdk-headless`, s volbou `--no-install-recommends`, která všechny tři vynechá. Nainstalujte fontconfig a písma DejaVu pomocí výše uvedeného příkazu a také HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Bez HarfBuzz tyto balíčky Javy vypisují `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` a ukládání selže s `UnsatisfiedLinkError`, který hlásí, že `libharfbuzz.so.0` nelze otevřít.

### **Red Hat Enterprise Linux**

Balíčky `java-<version>-openjdk-headless` v Red Hat Enterprise Linux neinstalují knihovnu fontconfig. Nainstalujte ji spolu s písmy DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Plné balíčky `java-<version>-openjdk` instalují fontconfig a písma jako závislosti a totéž platí pro balíčky Amazon Corretto v Amazon Linux 2023, např. `java-21-amazon-corretto-headless`.

### **Alpine Linux**

V Dockerfile založeném na Alpine Linux nainstalujte fontconfig a písma DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

V aktuálních verzích Alpine `ttf-dejavu` instaluje balíček `font-dejavu`. Instalujte Javu pomocí balíčku `openjdk<version>-jre` nebo `openjdk<version>-jdk`, například `openjdk25-jdk`. Balíčky `openjdk<version>-jre-headless` v Alpine neobsahují knihovnu písem Javy, takže s nimi program selže s `UnsatisfiedLinkError: no fontmanager in system library path`, i když jsou písma nainstalována.

### **Písma**

Aby text byl vykreslen se správnými písmy a metrikami, musí být písma používaná ve vašich prezentacích nebo vhodné náhrady nainstalována v systému nebo načtena vaší aplikací. Viz [Nasazení písem](/slides/cs/java/deploy-fonts/), [Substituce písem](/slides/cs/java/font-substitution/) a [Vlastní písma](/slides/cs/java/custom-font/).

## **Zkontrolujte nastavení**

Pro ověření, že knihovna a její požadavky jsou v pořádku, spusťte program, který uloží prezentaci a vykreslí snímek do obrázku. Ukládání a vykreslování používají podporu písem Java runtime, kterou výše uvedené požadavky pro Linux poskytují.

Uložte kód níže jako *CheckSetup.java* do složky, která obsahuje soubor Aspose.Slides JAR. Pro stažení souboru JAR viz [Použití souboru JAR bez Maven](/slides/cs/java/installation/#use-the-jar-file-without-maven).

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

S JDK 11 nebo novějším spusťte program ve stejné složce pomocí níže uvedeného příkazu. Pokud má váš soubor JAR jiný název, změňte jej v příkazech.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

S Javou 8 nebo na systému, který má pouze JRE, zkompilujte program pomocí `javac` z JDK a poté spusťte zkompilovanou třídu. Na Linuxu a macOS spusťte:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Na Windows spusťte stejný příkaz `javac` a poté třídu se středníkem jako oddělovačem cest. Zachovejte uvozovky, aby PowerShell neinterpretoval středník jako konec příkazu: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Program přidá obdélník s textem na první snímek a uloží prezentaci jako *hello.pptx* pomocí metody [uložit](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Poté vykreslí snímek pomocí [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) a výsledek uloží jako *hello.png* metodou [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ve formátu [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Škálovací faktor 1 vykreslí jeden pixel na bod, takže výchozí snímek 720 × 540 bodů se stane obrázkem 720 × 540 pixelů, přičemž text je viditelný uvnitř obdélníku. Bez licence oba soubory obsahují hodnotný vodoznak; viz [Licencování](/slides/cs/java/licensing/). Pokud některý požadavek chybí, program skončí jednou z chyb popsaných v [Linux](#linux).

## **Nástroje pro vývoj**

Můžete vytvářet aplikace používající Aspose.Slides s libovolným JDK podporované verze Javy. Použijte Apache Maven s Maven repozitářem Aspose, jak je popsáno v [Instalace](/slides/cs/java/installation/), nebo jakýkoli jiný nástroj, který dokáže pracovat s Maven repozitářem. Soubor JAR můžete také přidat do class path vašeho IDE nebo build toolu ručně.

## **FAQ**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a vykreslování?**

Ne, PowerPoint není vyžadován. Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/java/create-presentation/), úpravy, [převod](/slides/cs/java/convert-presentation/) a [renderování](/slides/cs/java/convert-powerpoint-to-png/) prezentací.

**Vyžaduje Aspose.Slides for Java na Linuxovém serveru displej nebo desktopové prostředí?**

Ne. Aspose.Slides nevyžaduje X server ani displej, takže běží na serverech i v kontejnerech. Na Linuxu potřebuje pouze knihovnu písem a písma popsaná v [Linux](#linux).

**Která písma jsou nutná pro správné vykreslení?**

Písma použitá v prezentaci nebo vhodné [náhrady](/slides/cs/java/font-substitution/) musí být k dispozici. Na Linuxu a macOS nainstalujte balíčky písem, které vaše prezentace vyžadují, aby byl zajištěn konzistentní výstup.

**Proč se vlastní písmo na Linuxu vykreslí jako zástupné nebo chybějící text?**

Pokud má soubor písma neúplné nebo poškozené záznamy v tabulce názvů, Linuxový stack pro výběr písem (FreeType/fontconfig) může vybrat neplatný záznam, což vede k nevyřešenému písmu. Použití verze písma s opravenými záznamy nebo instalace konzistentní náhrady problém vyřeší.