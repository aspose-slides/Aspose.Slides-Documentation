---
title: Betűtípusok telepítése az Aspose.Slides for Java-hoz Linuxon és Dockerben
linktitle: Betűtípusok telepítése
type: docs
weight: 155
url: /hu/java/deploy-fonts/
keywords:
- betűtípusok telepítése
- betűtípusok telepítése
- betűtípusok Dockerben
- betűtípusok Linuxon
- hiányzó betűtípusok
- betűtípus helyettesítés
- Microsoft alaptípusok
- ttf-mscorefonts-installer
- egyedi betűtípusok
- alapértelmezett betűtípus
- szerver
- konténer
- PDF konvertálás
- prezentáció
- Java
- Aspose.Slides
description: "Betűtípusok telepítése az Aspose.Slides for Java-hoz Linux szervereken és Docker konténerekben: ellenőrizze, mely betűtípusok vannak helyettesítve, telepítse a betűtípus csomagokat Debianra, Ubuntura és Alpine-ra, adjon hozzá saját betűtípus fájlokat, és állítson be egy alapértelmezett betűtípust."
---
## **Áttekintés**

Aspose.Slides a prezentáció renderelésekor a rendelkezésére álló betűtípusokkal rajzolja meg a szöveget, például amikor a diák PDF‑re vagy képekre konvertálja őket. Egy Windows asztali gép általában tartalmazza a prezentációkban használt betűtípusokat. A Linux szervereken és konténerekben általában kevés betűtípus van, ezért az Aspose.Slides helyettesítő betűtípussal rajzolja a szöveget. A helyettesítő más betűalakokkal és szélességekkel rendelkezik, ezért a sorok másképp tördelődhetnek, a szöveg kilóghat a formájából, és a helyettesítőben hiányzó karakterek nem jelennek meg helyesen. Ha egyetlen betűtípus sem van telepítve, a Java betűtípus‑támogatása nem indul el, és az Aspose.Slides hibával leáll.

Ez a cikk bemutatja, hogyan ellenőrizhetjük, mely betűtípusokat helyettesíti az Aspose.Slides, hogyan telepíthetünk betűtípusokat Debianra, Ubuntura és Alpine Linuxra, hogyan adhatunk hozzá saját betűtípus‑fájlokat, és hogyan állíthatjuk be azt a betűtípust, amelyet hiányzó betűtípus esetén használ. A példák Dockerben futnak a hivatalos Eclipse Temurin képeken, ahogyan a [Run Aspose.Slides for Java in Docker](/slides/hu/java/how-to-run-aspose-slides-in-docker/) is mutatja. A csomagparancsok Dockerfile‑utasítások; Linux szerveren ugyanezeket a parancsokat root‑ként kell futtatni.

A betűtípust érintő API‑val kapcsolatban, például betűtípusok beágyazása egy prezentációba, illetve helyettesítési és visszalépési szabályok tekintetében lásd a [PowerPoint Fonts](/slides/hu/java/powerpoint-fonts/) cikket.

## **Mely betűtípusok vannak helyettesítve**

A következő Maven projekt jelenti, hogy az Aspose.Slides mely betűtípusokat helyettesíti a jelenlegi környezetben. Hozzon létre egy *font-check* nevű mappát, és helyezze el benne az alábbi fájlokat.

*pom.xml* a [Run Aspose.Slides for Java in Docker](/slides/hu/java/how-to-run-aspose-slides-in-docker/#create-the-project) egyike, módosítva az artefakt‑azonosítót és a JAR fájl nevét *font-check*-re:

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

*src/main/java/FontCheck.java* minden betűtípus‑névhez egy szövegdobozt ad egy diára, és a [setLatinFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) metódussal állítja be a betűtípust. A betűtípus‑nevek a parancssorból származnak; argumentumok nélkül a program a Calibria, Arial‑t és Times New Roman‑t ellenőrzi. Kiírja azokat a mappákat, ahol az Aspose.Slides betűtípusokat keres ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#getFontFolders--)), rendereli a diát a *output/fonts.pdf*-be, és kiírja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) által jelentett helyettesítéseket. A két opcionális lépés a kezdeti részben, egy *fonts* mappa betöltése és egy `DEFAULT_FONT` változó olvasása, később részletezve.

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
        // A vizsgálandó betűtípusok: a parancssori argumentumok, vagy három gyakori Office betűtípus.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Betöltse a betűtípusfájlokat a munkakönyvtárban lévő fonts mappából, ha létezik.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Használja a DEFAULT_FONT környezeti változóban megadott betűtípust, ha be van állítva, a hiányzó betűtípusú szöveghez.
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

`getFontFolders` egy mappát több alkalommal is visszaadhat, ezért a program egy halmazba gyűjti a mappákat, mielőtt kiírná őket.

*.dockerignore* helyi építési eredményeket tart távol a build kontextustól:

```text
target/
output/
```

*Dockerfile* a Maven képpel építi a programot, és az Eclipse Temurin Java futtatóképén futtatja, amely már tartalmazza a fontconfig‑ot és a DejaVu betűtípusokat. A [Run Aspose.Slides for Java in Docker](/slides/hu/java/how-to-run-aspose-slides-in-docker/) minden utasítást részletez.

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

Építse a képet és futtassa az ellenőrzést:

```bash
docker build -t font-check .
docker run --rm font-check
```

A kép csak a DejaVu betűtípusokat tartalmazza, ezért mindhárom betűtípus DejaVu Sans‑ra lesz cserélve:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Az Ön saját prezentációinak betűtípusainak ellenőrzéséhez adja meg neveiket argumentumként, például `docker run --rm font-check "Segoe UI" Consolas`. A *output/fonts.pdf* konténerből való kimásolásához használja a [Copy the Output to Your Machine](/slides/hu/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) cikkben szereplő parancsokat.

## **Betűtípusok telepítése Debianra és Ubuntura**

### **Microsoft Core betűtípusok**

`ttf-mscorefonts-installer` csomag letölti és telepíti a Microsoft alapvető web‑betűtípusait, köztük az Arial‑t, Times New Roman‑t, Courier New‑t, Verdana‑t, Georgia‑t és Trebuchet MS‑t. A betűtípusok a Microsoft felhasználói licencszerződése (EULA) alatt állnak, a csomag csak az EULA elfogadása után telepíti őket. A Docker‑építés nem tud válaszolni a felprompt, ezért a telepítő elutasítja az EULA‑t és egy betűtípust sem telepít, miközben az `apt-get install` még sikeresnek jelzi. Fogadja el az EULA‑t a `debconf-set-selections` segítségével **a** csomag telepítése **előtt**. Az későbbi utasításban történő elfogadás nem segít: addig a csomag már telepítve van, és az apt nem futtatja újra a telepítőt.

Adja hozzá ezt az utasítást a *Dockerfile* futási szakaszához, közvetlenül a `FROM` sor után, hogy root‑ként fusson, a `USER` utasítás előtt:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Építse a képet és futtassa újra az ellenőrzést a két korábbi paranccsal. Az Arial és a Times New Roman most már telepítve van:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Az Aspose.Slides által létrehozott prezentációk alapértelmezett betűtípusa a Calibri, amely nem része a core betűtípusoknak, ezért továbbra is helyettesítve lesz. Lásd a [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts) részt.

Az Ubuntu‑alapú Eclipse Temurin képek engedélyezik a `multiverse` tárolót, amely az Ubuntu komponense a csomag tartalmához. Debian esetén a csomag a `contrib` komponensben van, amit a Debian képek nem engedélyeznek. Debian‑alapú futási szakaszban, például a [Use Another Base Image](/slides/hu/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) példában, engedélyezze a `contrib`‑ot ugyanabban az utasításban:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Egyéb betűtípus csomagok**

Debian és Ubuntu is csomagolja a szabadon licencelt betűtípusokat, például:

| Csomag | Betűtípusok |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif és Mono, ugyanazzal a metrikával, mint az Arial, Times New Roman és Courier New |
| `fonts-crosextra-carlito` | Carlito, ugyanazzal a metrikával, mint a Calibri |
| `fonts-crosextra-caladea` | Caladea, ugyanazzal a metrikával, mint a Cambria |

Telepítse őket az `apt-get install` segítségével egy `RUN` utasításban a futási szakaszban, ugyanúgy, mint a Microsoft core betűtípusoknál. Az Aspose.Slides for Java nem alkalmazza a Linux betűtípus‑konfigurációjának betűtípus‑aliasait: a `fonts-liberation` telepítése után az Arial‑ban lévő szöveg továbbra is az általános helyettesítő betűtípussal jelenik meg, nem a Liberation Sans‑szal. Ahhoz, hogy egy metrikailag kompatibilis betűtípust használjon hiányzó helyett, állítsa be azt [alapértelmezett betűtípusként](#set-a-default-font-for-missing-fonts), vagy adjon hozzá egy [betűtípus‑helyettesítési szabályt](/slides/hu/java/font-substitution/).

## **Saját betűtípus‑fájlok hozzáadása**

Azok a betűtípusok, amelyeket a disztribúciók nem csomagolnak, például a szervezete betűtípusai vagy egyéb, a szerveren használatra licencelt betűtípusok, hozzáadhatók betűtípus‑fájlokként. Helyezze a betűtípus‑fájlokat, például *.ttf* fájlokat, egy *fonts* nevű mappába a *font-check* mappán belül. Az alábbi példák a Carlito betűtípus fájljait használják, amelynek metrikái megegyeznek a Calibri‑éval, letölthető a [Google Fonts](https://fonts.google.com/specimen/Carlito) oldalról.

### **Betűtípusok telepítése rendszer‑betűtípus mappába**

Aspose.Slides a `Font folders` sorban kiírt mappákat olvassa. A betűtípusok rendszerszintű telepítéséhez másolja őket a */usr/local/share/fonts* mappába, amely a helyileg telepített betűtípusok mappája. Adja hozzá ezt az utasítást a *Dockerfile* futási szakaszához, a Microsoft core betűtípusok telepítését végző `RUN` utasítás után:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Építse újra a képet, majd ellenőrizze a Calibria és a Carlito‑t:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito már nem helyettesített:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Betűtípusok betöltése az alkalmazás mappájából**

A betűtípusok rendszer‑mappába történő telepítése helyett csomagolhatja őket az alkalmazással, és a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) segítségével töltheti be őket. A betűtípusok ezután csak az Aspose.Slides számára lesznek elérhetők, és az alkalmazással együtt kerülnek telepítésre. A *FontCheck* ezt teszi: amikor a munkakönyvtára (* /app* a konténerben) tartalmaz egy *fonts* mappát, a program azt a mappát adja át a `loadExternalFonts`‑nek a prezentáció létrehozása előtt. A [Custom Font](/slides/hu/java/custom-font/) leírja a betűtípusok más szállítási módjait, például memóriából való betöltést.

Az *Dockerfile*-ban távolítsa el a `COPY fonts/ /usr/local/share/fonts/` utasítást, és ezt adja hozzá a *lib* mappát másoló utasítás után:

```dockerfile
COPY fonts/ ./fonts/
```

Építse újra a képet és futtassa az ellenőrzést a két korábbi paranccsal. Az alkalmazás mappa most megjelenik a betűtípus‑mappák között, és a Carlito továbbra sem lesz helyettesített:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` hozzáadja a betűtípusokat a telepített betűtípusokhoz, de a Java betűtípus‑támogatásnak még mindig szüksége van legalább egy telepített betűtípusra. Egy olyan képen, amelyben nincs egyetlen betűtípus sem, a `loadExternalFonts` a "Fontconfig head is null, check your fonts or fonts configuration" hibaüzenettel áll le.

## **Alapértelmezett betűtípus beállítása hiányzó betűtípusokhoz**

Ha egy betűtípus hiányzik, az Aspose.Slides egy saját helyettesítőt használ. Ahhoz, hogy ezt saját maga válassza ki, adja át a betűtípus nevét a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) metódusnak a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) konstruktorában, és adja át ezeket a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának. A *FontCheck* a `DEFAULT_FONT` környezeti változóból olvassa a betűtípus nevét. A Carlito betöltése esetén használja hiányzó betűtípusokhoz:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Most a Calibri a Carlito‑val van megrajzolva, amelynek karakterei ugyanazzal a szélességgel rendelkeznek, mint a Calibri, ezért a szöveg megtartja a sortöréseit:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Az alapértelmezett betűtípus minden hiányzó betűtípust felülír. Egyedi betűtípusok leképezéséhez, például az Arial‑t Liberation Sans‑ra és a Calibri‑t Carlito‑ra, használjon [betűtípus‑helyettesítési szabályokat](/slides/hu/java/font-substitution/). A szabályok megváltoztatják a renderelt kimenetet, de a `getSubstitutions` nem tükrözi ezeket, ezért ellenőrizze a betűtípusokat a kimeneti fájlban. Ázsiai szövegnél hívja meg a [setDefaultAsianFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) metódust is; lásd a [Default Font](/slides/hu/java/default-font/).

## **Betűtípusok telepítése Alpine Linuxon**

Az Alpine‑alapú Eclipse Temurin kép szintén tartalmazza a DejaVu betűtípusokat; a [Run on Alpine Linux](/slides/hu/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) leírja a futási szakaszát. A Microsoft core betűtípusok telepítéséhez cserélje ki a *font-check* Dockerfile‑jának futási szakaszát a következőre:

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

`update-ms-fonts` letölti és telepíti ugyanazokat a Microsoft core betűtípusokat, mint a Debian és Ubuntu csomag, és az EULA ugyanúgy érvényes. Az `fc-cache` frissíti a fontconfig betűtár‑gyorsítótárát. Építse a képet és futtassa az ellenőrzést a [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) cikkben szereplő két paranccsal. Ez kiírja:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

A többi lépés ezen az oldalon ugyanúgy működik Alpine‑on: másolja a *fonts* mappát a */usr/local/share/fonts* vagy az alkalmazás mappájába, és állítsa be a `DEFAULT_FONT`‑ot az alapértelmezett betűtípus kiválasztásához. Az Alpine képnek nincs */usr/local/share/fonts* mappája, ezért ez a mappa csak akkor jelenik meg a `Font folders` sorban, ha egy `COPY` utasítás létrehozza.

## **GYIK**

**Miért néz ki másképp egy prezentáció, amikor szerveren konvertálják?**

A szerveren nincsenek telepítve a prezentáció által használt betűtípusok, ezért az Aspose.Slides a szöveget egy helyettesítő betűtípussal rajzolja, amelynek betűei más szélességgel rendelkeznek. Futtassa a *FontCheck*-et a prezentáció betűtípusainak nevével, hogy megtudja, mely betűtípusok helyettesítettek, majd telepítse ezeket a betűtípusokat, vagy töltse be őket az alkalmazás mappájából.

**A build telepítette a ttf-mscorefonts-installer csomagot, de az Arial még mindig helyettesített. Miért?**

Az EULA nem volt elfogadva a csomag telepítése előtt, ezért a telepítő átugorja a betűtípusokat. Helyezze a `debconf-set-selections` parancsot az `apt-get install` előtt abban az utasításban, amelyik a csomagot telepíti, ahogy a [Microsoft Core betűtípusok](#microsoft-core-betűtípusok) részben látható, és építse újra a képet.

**A PDF‑et megnyitó számítógépnek szüksége van a betűtípusokra?**

Nem. Ezekben a példákban a PDF tartalmazza azokat a betűtípusokat, amelyekkel a szöveget megrajzolták, így bármely számítógépen ugyanúgy néz ki. A betűtípusok csak arra a gépre vannak szükség, ahol az Aspose.Slides rendereli a prezentációt.