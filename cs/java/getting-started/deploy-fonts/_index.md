---
title: Nasazení písem pro Aspose.Slides pro Java na Linuxu a v Dockeru
linktitle: Nasadit písma
type: docs
weight: 155
url: /cs/java/deploy-fonts/
keywords:
  - nasazení písem
  - instalace písem
  - písma v Dockeru
  - písma na Linuxu
  - chybějící písma
  - náhrada písma
  - Microsoft core fonts
  - ttf‑mscorefonts‑installer
  - vlastní písma
  - výchozí písmo
  - server
  - kontejner
  - převod do PDF
  - prezentace
  - Java
  - Aspose.Slides
description: "Nasazení písem pro Aspose.Slides pro Java na Linuxových serverech a v Docker kontejnerech: zjistěte, která písma jsou nahrazována, nainstalujte balíčky písem na Debianu, Ubuntu a Alpine, přidejte vlastní soubory písem a nastavte výchozí písmo."
---
## **Přehled**

Aspose.Slides vykresluje text pomocí písem, která jsou k dispozici při renderování prezentace, například při převodu snímků do PDF nebo do obrázků. Na pracovním stole Windows jsou obvykle nainstalována písma, která prezentace používají. Na serverech a kontejnerech Linuxu je obvykle jen málo písem, takže Aspose.Slides vykresluje text náhradním písmem. Náhrada má jiné tvary a šířky znaků, takže se řádky mohou zalamovat jinak a text může přesahovat svůj rámec a znaky, které náhrada postrádá, se nevykreslí správně. Pokud není žádné písmo nainstalováno, podpora písem v Javě se nespustí a Aspose.Slides skončí chybou.

Tento článek ukazuje, jak zjistit, která písma Aspose.Slides nahrazuje, jak nainstalovat písma na Debianu, Ubuntu a Alpine Linux, jak přidat vlastní soubory písem a jak nastavit písmo, které se použije, když písmo chybí. Příklady běží v Dockeru na oficiálních obrazech Eclipse Temurin, jako v [Spustit Aspose.Slides pro Java v Dockeru](/slides/cs/java/how-to-run-aspose-slides-in-docker/). Příkazy balíčků jsou instrukce Dockerfile; na Linuxovém serveru je spusťte jako root.

Pro samotné API písem, například vkládání písem do prezentace a pravidla pro náhradu a záložní písma, viz [Písma PowerPoint](/slides/cs/java/powerpoint-fonts/).

## **Zkontrolujte, která písma jsou nahrazována**

Níže uvedený Maven projekt hlásí písma, která Aspose.Slides nahrazuje v aktuálním prostředí. Vytvořte složku pojmenovanou *font-check* a přidejte do ní následující soubory.

*`pom.xml`* je ten samý jako v [Spustit Aspose.Slides pro Java v Dockeru](/slides/cs/java/how-to-run-aspose-slides-in-docker/#create-the-project), jen s ID artefaktu a názvem JAR souboru změněnými na *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>font-check</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

`src/main/java/FontCheck.java` přidává na snímek jeden textový rámeček pro každé jméno písma a přiřazuje písmo metodou [setLatinFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Jména písem jsou předávána z příkazové řádky; pokud nejsou zadány žádné argumenty, program kontroluje Calibri, Arial a Times New Roman. Vypisuje složky, ve kterých Aspose.Slides hledá písma ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--)), vykreslí snímek do *output/fonts.pdf* a vypíše náhrady vrácené metodou [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Dva volitelné kroky na začátku, načtení složky *fonts* a přečtení proměnné `DEFAULT_FONT`, jsou vysvětleny později v tomto článku.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Písma k ověření: argumenty příkazové řádky nebo tři běžná písma Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Načíst soubory písem ze složky fonts v pracovním adresáři, pokud existuje.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Použít písmo pojmenované v proměnné prostředí DEFAULT_FONT, pokud je nastaveno, pro text, jehož písmo chybí.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` může vrátit stejnou složku vícekrát, takže program nejprve shromažďuje složky do množiny, než je vypíše.

*.dockerignore* udržuje lokální výstupy mimo kontext sestavení:

```text
target/
output/
```

*Dockerfile* sestavuje program pomocí Maven obrazu a spouští jej na obrazu Eclipse Temurin Java, který již obsahuje fontconfig a písma DejaVu. [Spustit Aspose.Slides pro Java v Dockeru](/slides/cs/java/how-to-run-aspose-slides-in-docker/) popisuje každou instrukci.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Sestavte obraz a spusťte kontrolu:

```bash
docker build -t font-check .
docker run --rm font-check
```

Obraz obsahuje jen písma DejaVu, takže všechna tři písma jsou nahrazena písmeny DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Chcete-li zkontrolovat písma ve vlastních prezentacích, předáte jejich názvy jako argumenty, například `docker run --rm font-check "Segoe UI" Consolas`. Chcete-li z kontejneru zkopírovat *output/fonts.pdf*, použijte příkazy v [Zkopírovat výstup na váš počítač](/slides/cs/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalace písem na Debian a Ubuntu**

### **Microsoft Core Fonts**

Balíček `ttf-mscorefonts-installer` stahuje a instaluje základní písma Microsoftu pro web, mezi nimiž jsou Arial, Times New Roman, Courier New, Verdana, Georgia a Trebuchet MS. Písma jsou licencována pod licenční smlouvou Microsoftu (EULA) a balíček je nainstaluje jen po přijetí EULA. Dockerový build nedokáže na výzvu odpovědět, takže instalační program odmítne EULA a neinstaluje žádná písma, zatímco `apt-get install` i tak hlásí úspěch. Přijměte EULA pomocí `debconf-set-selections` **před** instalací balíčku. Přijetí v pozdější instrukci nepomůže: balíček už bude nainstalován a apt již instalační program nespustí.

Přidejte tento příkaz do runtime fáze *Dockerfile*, hned po řádku `FROM`, aby běžel jako root, před instrukcí `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Sestavte obraz a znovu spusťte kontrolu stejnými dvěma příkazy. Arial a Times New Roman jsou nyní nainstalovány:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, výchozí písmo prezentace, kterou Aspose.Slides vytvoří, není součástí základních písem, takže je stále nahrazováno. Viz [Nastavit výchozí písmo pro chybějící písma](#set-a-default-font-for-missing-fonts).

Obrazy Eclipse Temurin založené na Ubuntu povolují `multiverse`, komponentu Ubuntu, která obsahuje tento balíček. Na Debianu je balíček v komponentě `contrib`, kterou Debianové obrazy nepovolují. V runtime fázi založené na Debianu, například ve [Použít jiný základní obraz](/slides/cs/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), povolte `contrib` ve stejné instrukci:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Další balíčky písem**

Debian a Ubuntu také nabízejí volně licencovaná písma, například:

| Balíček | Písma |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif a Mono, se stejnými metrikami jako Arial, Times New Roman a Courier New |
| `fonts-crosextra-carlito` | Carlito, se stejnými metrikami jako Calibri |
| `fonts-crosextra-caladea` | Caladea, se stejnými metrikami jako Cambria |

Instalujte je pomocí `apt-get install` v `RUN` instrukci runtime fáze, stejným způsobem jako Microsoft Core Fonts. Aspose.Slides pro Java nevyužívá aliasy písem z konfigurace Linuxu: i po instalaci `fonts-liberation` se text v Ariali stále vykresluje obecným náhradním písmem, ne Liberation Sans. Chcete‑li místo chybějícího písma použít metricky kompatibilní písmo, nastavte jej jako [výchozí písmo](#set-a-default-font-for-missing-fonts) nebo přidejte [pravidlo nahrazení písma](/slides/cs/java/font-substitution/).

## **Přidejte vlastní soubory písem**

Písma, která distribuce nebalí, jako jsou firemní písma nebo jiné licence, můžete přidat jako soubory písem. Umístěte soubory písem, například *.ttf* soubory, do složky *fonts* uvnitř složky *font-check*. Níže uvedené příklady používají soubory Carlito, písmo se stejnými metrikami jako Calibri, které můžete stáhnout z [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalujte písma do systémové složky písem**

Aspose.Slides čte písma ve složkách uvedených na řádku `Font folders`. Chcete‑li nainstalovat svá písma pro všechny aplikace v obrazu, zkopírujte je do */usr/local/share/fonts*, složky pro lokálně instalovaná písma. Přidejte tuto instrukci do runtime fáze *Dockerfile*, po `RUN` instrukci, která instalovala Microsoft Core Fonts:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Znovu sestavte obraz a pak zkontrolujte Calibri a Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito už není nahrazováno:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Načtěte písma ze složky aplikace**

Místo instalace písem do systémové složky je můžete balit s aplikací a načíst pomocí [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Pak jsou písma dostupná jen pro Aspose.Slides a jsou nasazena spolu s aplikací. *FontCheck* to provádí: když jeho pracovní adresář */app* v kontejneru obsahuje složku *fonts*, program před vytvořením prezentace předá tuto složku metodě `loadExternalFonts`. [Vlastní písmo](/slides/cs/java/custom-font/) popisuje další způsoby, jak písma dodat, například načtením z paměti.

V *Dockerfile* odstraňte instrukci `COPY fonts/ /usr/local/share/fonts/` a přidejte tuto po instrukci, která kopíruje složku *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Znovu sestavte obraz a spusťte kontrolu stejnými dvěma příkazy. Složka aplikace se nyní objeví mezi složkami písem a Carlito stále není nahrazováno:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` přidává písma k nainstalovaným, ale podpora písem v Javě stále vyžaduje alespoň jedno nainstalované písmo. V obrazu bez jakéhokoli písma `loadExternalFonts` selže s chybou „Fontconfig head is null, check your fonts or fonts configuration“.

## **Nastavit výchozí písmo pro chybějící písma**

Když písmo chybí, Aspose.Slides použije náhradní písmo, které si zvolí samo. Chcete‑li si jej zvolit sami, předávejte název písma metodě [setDefaultRegularFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) třídy [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) a předávejte tyto možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). *FontCheck* čte název písma z proměnné prostředí `DEFAULT_FONT`. S načteným Carlitem jej použijte pro chybějící písma:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri je nyní vykresleno s Carlitem, jehož znaky mají stejné šířky jako u Calibri, takže text zachovává své zalomení řádků:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Výchozí písmo nahrazuje každé chybějící písmo. Chcete‑li mapovat jednotlivá písma, například Arial na Liberation Sans a Calibri na Carlito, použijte [pravidla nahrazení písma](/slides/cs/java/font-substitution/). Pravidla mění vykreslený výstup, ale `getSubstitutions` je neodráží, takže písma kontrolujte v souboru výstupu. Pro asijské texty také zavolejte [setDefaultAsianFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); viz [Výchozí písmo](/slides/cs/java/default-font/).

## **Instalace písem na Alpine Linux**

Obraz založený na Alpine v Eclipse Temurin také obsahuje písma DejaVu; [Spustit na Alpine Linux](/slides/cs/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) popisuje jeho runtime fázi. Chcete‑li na něm také nainstalovat Microsoft Core Fonts, nahraďte runtime fázi *Dockerfile* pro *font-check* následujícím:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` stáhne a nainstaluje stejná Microsoft Core Fonts jako balíček pro Debian a Ubuntu a jejich EULA se uplatňuje stejným způsobem. `fc-cache` aktualizuje fontcache fontconfigu. Sestavte obraz a spusťte kontrolu dvěma příkazy z [Zkontrolujte, která písma jsou nahrazována](#check-which-fonts-are-substituted). Vypíše:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Další kroky na této stránce fungují na Alpine stejně: zkopírujte složku *fonts* do */usr/local/share/fonts* nebo do složky aplikace a nastavte `DEFAULT_FONT` pro výběr výchozího písma. Image Alpine nemá složku */usr/local/share/fonts*, takže se tato složka objeví na řádku `Font folders` až po `COPY` instrukci, která ji vytvoří.

## **Často kladené otázky**

**Proč se prezentace na serveru po konverzi liší?**

Server nemá písma, která prezentace používá, takže Aspose.Slides vykresluje text náhradním písmem, jehož znaky mají jiné šířky. Spusťte *FontCheck* s názvy písem z prezentace, abyste zjistili, která písma jsou nahrazována, a poté tato písma nainstalujte nebo načtěte ze složky aplikace.

**Instalace balíčku ttf‑mscorefonts‑installer proběhla, ale Arial se stále nahrazuje. Proč?**

EULA nebyla přijata před instalací balíčku, takže instalační program písma přeskočil. Umístěte příkaz `debconf-set-selections` před `apt-get install` v instrukci, která balíček instaluje, jak je ukázáno v sekci [Microsoft Core Fonts](#microsoft-core-fonts), a obraz znovu sestavte.

**Potřebuje počítač, který otevírá PDF, mít nainstalovaná písma?**

Ne. V těchto příkladech PDF obsahuje písma, která byla použita k vykreslení textu, takže se soubor zobrazí stejně na jakémkoli počítači. Písma jsou potřebná jen tam, kde Aspose.Slides renderuje prezentaci.