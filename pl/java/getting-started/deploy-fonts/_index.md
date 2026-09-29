---
title: Wdrażanie czcionek dla Aspose.Slides for Java na Linuxie i w Dockerze
linktitle: Wdrażanie czcionek
type: docs
weight: 155
url: /pl/java/deploy-fonts/
keywords:
- wdrażanie czcionek
- instalowanie czcionek
- czcionki w Dockerze
- czcionki na Linuxie
- brakujące czcionki
- zastępowanie czcionek
- Podstawowe czcionki Microsoft
- ttf-mscorefonts-installer
- czcionki niestandardowe
- domyślna czcionka
- serwer
- kontener
- konwersja PDF
- prezentacja
- Java
- Aspose.Slides
description: "Wdrażaj czcionki dla Aspose.Slides for Java na serwerach Linux i w kontenerach Docker: sprawdź, które czcionki są zastępowane, zainstaluj pakiety czcionek na Debianie, Ubuntu i Alpine, dodaj własne pliki czcionek oraz ustaw domyślną czcionkę."
---
## **Przegląd**

Aspose.Slides rysuje tekst czcionkami, które są dostępne w czasie renderowania prezentacji, np. przy konwertowaniu slajdów do PDF lub obrazów. System Windows zazwyczaj posiada czcionki używane w prezentacjach. Serwery i kontenery Linux zazwyczaj mają niewiele czcionek, więc Aspose.Slides rysuje tekst czcionką zastępczą. Zastępstwo ma inne kształty i szerokości liter, dlatego linie mogą zawijać się inaczej, a tekst może wyjść poza swój kształt, a znaki, których brak w czcionce zastępczej, nie są rysowane poprawnie. Jeśli w ogóle nie zainstalowano żadnej czcionki, obsługa czcionek w Javie nie może się uruchomić i Aspose.Slides przerywa działanie z błędem.

Ten artykuł pokazuje, jak sprawdzić, które czcionki Aspose.Slides zastępuje, jak zainstalować czcionki w systemach Debian, Ubuntu i Alpine Linux, jak dodać własne pliki czcionek oraz jak ustawić czcionkę używaną, gdy czcionka jest brakująca. Przykłady działają w Dockerze na oficjalnych obrazach Eclipse Temurin, tak jak w [Uruchom Aspose.Slides for Java w Dockerze](/slides/pl/java/how-to-run-aspose-slides-in-docker/). Polecenia pakietowe to instrukcje Dockerfile; na serwerze Linux uruchom te same polecenia jako root.

Dokumentację API czcionek, taką jak osadzanie czcionek w prezentacji oraz reguły zastępowania i zamiany, znajdziesz w [Czcionki PowerPoint](/slides/pl/java/powerpoint-fonts/).

## **Sprawdź, które czcionki są zastępowane**

Poniższy projekt Maven raportuje czcionki, które Aspose.Slides zastępuje w bieżącym środowisku. Utwórz folder o nazwie *font-check* i dodaj do niego poniższe pliki.

*`pom.xml`* jest tym samym, co w [Uruchom Aspose.Slides for Java w Dockerze](/slides/pl/java/how-to-run-aspose-slides-in-docker/#create-the-project), ale z `artifactId` i nazwą pliku JAR zmienionymi na *font-check*:

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

*`src/main/java/FontCheck.java`* dodaje jedną ramkę tekstową dla każdej nazwy czcionki do slajdu i przypisuje czcionkę metodą [setLatinFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Nazwy czcionek pochodzą z wiersza poleceń; bez argumentów program sprawdza Calibri, Arial i Times New Roman. Wypisuje foldery, w których Aspose.Slides szuka czcionek ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#getFontFolders--)), renderuje slajd do *output/fonts.pdf* i wypisuje zastąpienia zgłoszone przez [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Dwa opcjonalne kroki na początku, wczytanie folderu *fonts* i odczyt zmiennej `DEFAULT_FONT`, są opisane później w tym artykule.

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
        // Czcionki do sprawdzenia: argumenty wiersza poleceń lub trzy popularne czcionki Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Wczytaj pliki czcionek z folderu fonts w katalogu roboczym, jeśli taki istnieje.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Użyj czcionki podanej w zmiennej środowiskowej DEFAULT_FONT, jeśli jest ustawiona, dla tekstu, którego czcionka jest brakująca.
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

`getFontFolders` może zwrócić ten sam folder wielokrotnie, więc program zbiera foldery w zbiorze przed ich wypisaniem.

*.dockerignore* trzyma lokalne wyniki budowania poza kontekstem budowania:

```text
target/
output/
```

*Dockerfile* buduje program przy użyciu obrazu Maven i uruchamia go na obrazie środowiska uruchomieniowego Eclipse Temurin Java, który już zawiera fontconfig i czcionki DejaVu. [Uruchom Aspose.Slides for Java w Dockerze](/slides/pl/java/how-to-run-aspose-slides-in-docker/) wyjaśnia każdą instrukcję.

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

Zbuduj obraz i uruchom sprawdzenie:

```bash
docker build -t font-check .
docker run --rm font-check
```

Obraz zawiera tylko czcionki DejaVu, więc wszystkie trzy czcionki są zastępowane przez DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Aby sprawdzić czcionki własnych prezentacji, przekaż ich nazwy jako argumenty, np. `docker run --rm font-check "Segoe UI" Consolas`. Aby skopiować *output/fonts.pdf* z kontenera, użyj poleceń z [Skopiuj wynik na swój komputer](/slides/pl/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalowanie czcionek w Debianie i Ubuntu**

### **Czcionki podstawowe Microsoft**

Pakiet `ttf-mscorefonts-installer` pobiera i instaluję podstawowe czcionki Microsoft przeznaczone do sieci, w tym Arial, Times New Roman, Courier New, Verdana, Georgia i Trebuchet MS. Czcionki są licencjonowane na podstawie umowy licencyjnej użytkownika końcowego Microsoft (EULA), a pakiet instaluję je dopiero po zaakceptowaniu EULA. Budowanie obrazu Docker nie może odpowiedzieć na monitu, więc instalator odrzuca EULA i nie instaluje czcionek, choć `apt-get install` wciąż zgłasza sukces. Zaakceptuj EULA przy pomocy `debconf-set-selections` **przed** instalacją pakietu. Akceptacja później nie pomaga: pakiet jest już zainstalowany, a apt nie uruchamia instalatora ponownie.

Dodaj tę instrukcję do etapu runtime w *Dockerfile*, bezpośrednio po linii `FROM`, aby wykonała się jako root, przed instrukcją `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Zbuduj obraz i uruchom sprawdzenie ponownie tymi samymi dwoma poleceniami. Arial i Times New Roman są teraz zainstalowane:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, domyślna czcionka prezentacji tworzonej przez Aspose.Slides, nie należy do czcionek podstawowych, więc nadal jest zastępowana. Zobacz [Ustaw domyślną czcionkę dla brakujących czcionek](#set-a-default-font-for-missing-fonts).

Obrazy Eclipse Temurin oparte na Ubuntu włączają `multiverse`, komponent Ubuntu zawierający ten pakiet. W Debianie pakiet znajduje się w komponencie `contrib`, którego obrazy Debian nie włączają. W etapie runtime opartym na Debianie, takim jak w [Użyj innego obrazu bazowego](/slides/pl/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), włącz `contrib` w tej samej instrukcji:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Inne pakiety czcionek**

Debian i Ubuntu także udostępniają wolne czcionki, na przykład:

| Pakiet | Czcionki |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif i Mono, o tych samych metrykach co Arial, Times New Roman i Courier New |
| `fonts-crosextra-carlito` | Carlito, o tych samych metrykach co Calibri |
| `fonts-crosextra-caladea` | Caladea, o tych samych metrykach co Cambria |

Instaluj je przy pomocy `apt-get install` w instrukcji `RUN` etapu runtime, tak samo jak czcionki podstawowe Microsoft. Aspose.Slides for Java nie korzysta z aliasów czcionek konfiguracji Linux: po zainstalowaniu `fonts-liberation` tekst w Arial nadal jest rysowany ogólną czcionką zastępczą, a nie Liberation Sans. Aby użyć czcionki o zgodnych metrykach zamiast brakującej, ustaw ją jako [czcionkę domyślną](#set-a-default-font-for-missing-fonts) lub dodaj [regułę zamiany czcionki](/slides/pl/java/font-substitution/).

## **Dodaj własne pliki czcionek**

Czcionki niepakowane przez dystrybucje, takie jak czcionki Twojej organizacji lub inne czcionki, do których masz licencję na serwerze, można dodać jako pliki czcionek. Umieść pliki czcionek, np. pliki *.ttf*, w folderze *fonts* wewnątrz folderu *font-check*. Przykłady poniżej używają plików Carlito, czcionki o tych samych metrykach co Calibri, które możesz pobrać z [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Zainstaluj czcionki w systemowym folderze czcionek**

Aspose.Slides odczytuje czcionki z folderów wypisanych w linii `Font folders`. Aby zainstalować czcionki dla wszystkich aplikacji w obrazie, skopiuj je do */usr/local/share/fonts*, folderu przeznaczonego na czcionki instalowane lokalnie. Dodaj tę instrukcję do etapu runtime w *Dockerfile*, po instrukcji `RUN` instalującej czcionki podstawowe Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Przebuduj obraz, a potem sprawdź Calibri i Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito nie jest już zastępowane:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Wczytaj czcionki z folderu aplikacji**

Zamiast instalować czcionki w folderze systemowym, możesz je dołączyć do aplikacji i wczytać przy pomocy [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Czcionki będą wtedy dostępne tylko dla Aspose.Slides i zostaną wdrożone razem z aplikacją. *FontCheck* robi tak: gdy jego katalog roboczy, */app* w kontenerze, zawiera folder *fonts*, program przekazuje ten folder do `loadExternalFonts` przed utworzeniem prezentacji. [Niestandardowa czcionka](/slides/pl/java/custom-font/) opisuje inne sposoby dostarczania czcionek, np. wczytywanie z pamięci.

W *Dockerfile* usuń instrukcję `COPY fonts/ /usr/local/share/fonts/` i dodaj tę po instrukcji kopiującej folder *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Przebuduj obraz i uruchom sprawdzenie tymi samymi dwoma poleceniami. Folder aplikacji pojawia się teraz wśród folderów czcionek, a Carlito nadal nie jest zastępowane:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` dodaje czcionki do zainstalowanych, ale obsługa czcionek w Javie wciąż wymaga przynajmniej jednej zainstalowanej czcionki. W obrazie bez żadnych, `loadExternalFonts` zatrzymuje się z błędem "Fontconfig head is null, check your fonts or fonts configuration".

## **Ustaw domyślną czcionkę dla brakujących czcionek**

Gdy czcionka jest brakująca, Aspose.Slides używa własnej czcionki zastępczej. Aby wybrać własną, przekaż nazwę czcionki metodzie [setDefaultRegularFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) klasy [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). *FontCheck* odczytuje nazwę czcionki ze zmiennej środowiskowej `DEFAULT_FONT`. Po wczytaniu Carlito użyj jej jako czcionki domyślnej dla brakujących czcionek:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri jest teraz rysowane przy użyciu Carlito, którego znaki mają te same szerokości co Calibri, więc tekst zachowuje podziały linii:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Domyślna czcionka zastępuje każdą brakującą czcionkę. Aby mapować pojedyncze czcionki, np. Arial na Liberation Sans i Calibri na Carlito, użyj [reguł zamiany czcionek](/slides/pl/java/font-substitution/). Reguły zmieniają renderowany wynik, ale `getSubstitutions` ich nie odzwierciedla, więc sprawdzaj czcionki w pliku wyjściowym. Dla tekstu azjatyckiego wywołaj także [setDefaultAsianFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); zobacz [Domyślna czcionka](/slides/pl/java/default-font/).

## **Instalowanie czcionek w Alpine Linux**

Obraz Eclipse Temurin oparty na Alpine również zawiera czcionki DejaVu; [Uruchom na Alpine Linux](/slides/pl/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) opisuje jego etap runtime. Aby zainstalować na nim również podstawowe czcionki Microsoft, zamień etap runtime w Dockerfile *font-check* na następujący:

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

`update-ms-fonts` pobiera i instaluję te same podstawowe czcionki Microsoft co pakiet Debian/Ubuntu, a ich EULA obowiązuje w ten sam sposób. `fc-cache` aktualizuje pamięć podręczną czcionek fontconfig. Zbuduj obraz i uruchom sprawdzenie dwoma poleceniami z [Sprawdź, które czcionki są zastępowane](#check-which-fonts-are-substituted). Wyświetli:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Pozostałe kroki na tej stronie działają tak samo na Alpine: skopiuj folder *fonts* do */usr/local/share/fonts* lub do folderu aplikacji i ustaw `DEFAULT_FONT`, aby wybrać czcionkę domyślną. Obraz Alpine nie posiada folderu */usr/local/share/fonts*, więc pojawia się on w linii `Font folders` dopiero po instrukcji `COPY`, która go tworzy.

## **FAQ**

**Dlaczego prezentacja wygląda inaczej po konwersji na serwerze?**

Serwer nie ma czcionek używanych w prezentacji, więc Aspose.Slides rysuje tekst czcionką zastępczą, której litery mają inne szerokości. Uruchom *FontCheck* z nazwami czcionek z prezentacji, aby zobaczyć, które czcionki są zastępowane, a następnie zainstaluj te czcionki lub wczytaj je z folderu aplikacji.

**Budowa zainstalowała `ttf-mscorefonts-installer`, ale Arial nadal jest zastępowany. Dlaczego?**

EULA nie została zaakceptowana przed instalacją pakietu, więc instalator pominął czcionki. Umieść polecenie `debconf-set-selections` przed `apt-get install` w instrukcji instalującej pakiet, jak pokazano w [Czcionki podstawowe Microsoft](#microsoft-core-fonts), i przebuduj obraz.

**Czy komputer otwierający PDF potrzebuje tych czcionek?**

Nie. W tych przykładach PDF zawiera czcionki użyte do rysowania tekstu, więc wygląda tak samo na każdym komputerze. Czcionki są potrzebne wyłącznie tam, gdzie Aspose.Slides renderuje prezentację.