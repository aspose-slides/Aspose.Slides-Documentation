---
title: Distribuire i font per Aspose.Slides per Java su Linux e in Docker
linktitle: Distribuire i font
type: docs
weight: 155
url: /it/java/deploy-fonts/
keywords:
- installare i font
- installare i font
- font in Docker
- font su Linux
- font mancanti
- sostituzione dei font
- font core di Microsoft
- ttf-mscorefonts-installer
- font personalizzati
- font predefinito
- server
- container
- conversione PDF
- presentazione
- Java
- Aspose.Slides
description: "Distribuire i font per Aspose.Slides per Java su server Linux e in container Docker: verificare quali font sono sostituiti, installare i pacchetti di font su Debian, Ubuntu e Alpine, aggiungere i propri file di font e impostare un font predefinito."
---
## **Panoramica**

Aspose.Slides disegna il testo con i font disponibili quando rende una presentazione, ad esempio quando converte le diapositive in PDF o in immagini. Un desktop Windows solitamente dispone dei font utilizzati dalle presentazioni. I server Linux e i container solitamente hanno pochi font, quindi Aspose.Slides disegna il testo con un font sostitutivo. Un sostituto ha forme di lettere e larghezze diverse, così le linee possono a capo in modo diverso e il testo può eccedere la sua forma, e i caratteri mancanti nel sostituto non vengono disegnati correttamente. Se non è installato alcun font, il supporto ai font di Java non può avviarsi e Aspose.Slides si interrompe con un errore.

Questo articolo mostra come verificare quali font Aspose.Slides sostituisce, come installare i font su Debian, Ubuntu e Alpine Linux, come aggiungere i propri file di font e come impostare il font da utilizzare quando un font è mancante. Gli esempi vengono eseguiti in Docker sulle immagini ufficiali di Eclipse Temurin, come in [Run Aspose.Slides for Java in Docker](/slides/it/java/how-to-run-aspose-slides-in-docker/). I comandi dei pacchetti sono istruzioni Dockerfile; su un server Linux, esegui gli stessi comandi come root.

Per l'API dei font stessa, come l'incorporamento dei font in una presentazione e le regole di fallback e sostituzione, vedi [PowerPoint Fonts](/slides/it/java/powerpoint-fonts/).

## **Verifica Quali Font Sono Sostituiti**

Il progetto Maven seguente riferisce i font che Aspose.Slides sostituisce nell'ambiente corrente. Crea una cartella chiamata *font-check* e aggiungi i file sottostanti.

*`pom.xml`* è quello di [Run Aspose.Slides for Java in Docker](/slides/it/java/how-to-run-aspose-slides-in-docker/#create-the-project), con l'ID dell'artefatto e il nome del file JAR modificati in *font-check*:

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

*`src/main/java/FontCheck.java`* aggiunge una casella di testo per nome di font a una diapositiva e assegna il font con il metodo [setLatinFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). I nomi dei font provengono dalla riga di comando; senza argomenti, il programma controlla Calibri, Arial e Times New Roman. Stampa le cartelle in cui Aspose.Slides cerca i font ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--)), rende la diapositiva in *output/fonts.pdf* e stampa le sostituzioni riportate da [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). I due passaggi opzionali all'inizio, il caricamento di una cartella *fonts* e la lettura della variabile `DEFAULT_FONT`, sono spiegati più avanti in questo articolo.

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
        // I font da verificare: gli argomenti della riga di comando, o tre font comuni di Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Carica i file di font dalla cartella fonts nella directory di lavoro, se presente.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Usa il font specificato nella variabile d'ambiente DEFAULT_FONT, se impostata, per il testo il cui font è mancante.
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

`getFontFolders` può restituire una cartella più di una volta, quindi il programma raccoglie le cartelle in un set prima di stamparle.

*.dockerignore* mantiene i risultati di build locali fuori dal contesto di build:

```text
target/
output/
```

*Dockerfile* compila il programma con l'immagine Maven e lo esegue sull'immagine runtim Java di Eclipse Temurin, che contiene già fontconfig e i font DejaVu. [Run Aspose.Slides for Java in Docker](/slides/it/java/how-to-run-aspose-slides-in-docker/) spiega ogni istruzione.

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

Compila l'immagine ed esegui il controllo:

```bash
docker build -t font-check .
docker run --rm font-check
```

L'immagine contiene solo i font DejaVu, quindi tutti e tre i font sono sostituiti con DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Per verificare i font delle tue presentazioni, passa i loro nomi come argomenti, ad esempio `docker run --rm font-check "Segoe UI" Consolas`. Per copiare *output/fonts.pdf* fuori dal contenitore, usa i comandi in [Copy the Output to Your Machine](/slides/it/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installa Font su Debian e Ubuntu**

### **Font Core di Microsoft**

Il pacchetto `ttf-mscorefonts-installer` scarica e installa i font core di Microsoft per il web, tra cui Arial, Times New Roman, Courier New, Verdana, Georgia e Trebuchet MS. I font sono concessi in licenza secondo l'accordo di licenza per l'utente finale (EULA) di Microsoft, e il pacchetto li installa solo dopo che l'EULA è stata accettata. Una build Docker non può rispondere al prompt, quindi l'installatore rifiuta l'EULA e non installa alcun font, mentre `apt-get install` segnala comunque il successo. Accetta l'EULA con `debconf-set-selections` **prima** che il pacchetto venga installato. Accettarla in un'istruzione successiva non è utile: il pacchetto è già installato e apt non riesegue l'installatore.

Aggiungi questa istruzione alla fase runtime del *Dockerfile*, subito dopo la sua riga `FROM`, in modo che venga eseguita come root, prima dell'istruzione `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Compila l'immagine ed esegui nuovamente il controllo con gli stessi due comandi. Arial e Times New Roman sono ora installati:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, il font predefinito di una presentazione creata da Aspose.Slides, non è uno dei font core, quindi è ancora sostituito. Vedi [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Le immagini Ubuntu‑based di Eclipse Temurin abilitano `multiverse`, il componente Ubuntu che contiene il pacchetto. Su Debian, il pacchetto è nel componente `contrib`, che le immagini Debian non abilitano. In una fase runtime basata su Debian, come quella in [Use Another Base Image](/slides/it/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), abilita `contrib` nella stessa istruzione:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Altri Pacchetti di Font**

Debian e Ubuntu impacchettano anche font con licenza libera, per esempio:

| Pacchetto | Font |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif e Mono, con le stesse metriche di Arial, Times New Roman e Courier New |
| `fonts-crosextra-carlito` | Carlito, con le stesse metriche di Calibri |
| `fonts-crosextra-caladea` | Caladea, con le stesse metriche di Cambria |

Installa i pacchetti con `apt-get install` in un'istruzione `RUN` della fase runtime, nello stesso modo dei font core di Microsoft. Aspose.Slides for Java non applica gli alias dei font della configurazione Linux: con `fonts-liberation` installato, il testo in Arial viene comunque disegnato con il font sostitutivo generale, non con Liberation Sans. Per usare un font metricamente compatibile al posto di uno mancante, impostalo come [font predefinito](#set-a-default-font-for-missing-fonts) o aggiungi una [regola di sostituzione dei font](/slides/it/java/font-substitution/).

## **Aggiungi i Tuoi File di Font**

I font che le distribuzioni non impacchettano, come i font della tua organizzazione o altri font per i quali possiedi licenza d'uso sul server, possono essere aggiunti come file di font. Metti i file di font, per esempio file *.ttf*, in una cartella chiamata *fonts* all'interno della cartella *font-check*. Gli esempi qui sotto usano i file di Carlito, un font con le stesse metriche di Calibri, che puoi scaricare da [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installa i Font in una Cartella di Font di Sistema**

Aspose.Slides legge i font nelle cartelle stampate sulla riga `Font folders`. Per installare i tuoi font per ogni applicazione nell'immagine, copiali in */usr/local/share/fonts*, la cartella per i font installati localmente. Aggiungi questa istruzione alla fase runtime del *Dockerfile*, dopo l'istruzione `RUN` che installa i font core di Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Ricostruisci l'immagine, poi verifica Calibri e Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito non è più sostituito:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Carica i Font dalla Cartella dell'Applicazione**

Invece di installare i font in una cartella di sistema, puoi distribuirli con l'applicazione e caricarli con [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). I font saranno allora disponibili solo a Aspose.Slides e saranno distribuiti insieme all'applicazione. *FontCheck* lo fa: quando la sua directory di lavoro, */app* nel contenitore, contiene una cartella *fonts*, il programma passa quella cartella a `loadExternalFonts` prima di creare la presentazione. [Custom Font](/slides/it/java/custom-font/) descrive le altre modalità di fornitura dei font, ad esempio il caricamento dalla memoria.

Nel *Dockerfile*, rimuovi l'istruzione `COPY fonts/ /usr/local/share/fonts/` e aggiungi questa subito dopo l'istruzione che copia la cartella *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Ricostruisci l'immagine ed esegui il controllo con gli stessi due comandi. La cartella dell'applicazione ora compare tra le cartelle dei font, e Carlito non è ancora sostituito:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` aggiunge i font a quelli installati, ma il supporto ai font di Java richiede comunque almeno un font installato. In un'immagine priva di font, `loadExternalFonts` si interrompe con l'errore "Fontconfig head is null, check your fonts or fonts configuration".

## **Imposta un Font Predefinito per i Font Mancanti**

Quando un font è mancante, Aspose.Slides usa un sostituto scelto autonomamente. Per sceglierlo tu, passa il nome del font al metodo [setDefaultRegularFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) di [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) e passa le opzioni al costruttore di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). *FontCheck* legge il nome del font dalla variabile d'ambiente `DEFAULT_FONT`. Con Carlito caricato, usalo per i font mancanti:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri ora viene disegnato con Carlito, i cui caratteri hanno le stesse larghezze di quelli di Calibri, così il testo mantiene le interruzioni di riga:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Il font predefinito sostituisce ogni font mancante. Per mappare font individuali, ad esempio Arial verso Liberation Sans e Calibri verso Carlito, usa le [regole di sostituzione dei font](/slides/it/java/font-substitution/). Le regole modificano l'output renderizzato, ma `getSubstitutions` non le riflette, quindi verifica i font nel file di output. Per il testo asiatico, chiama anche [setDefaultAsianFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); vedi [Default Font](/slides/it/java/default-font/).

## **Installa Font su Alpine Linux**

L'immagine Alpine‑based di Eclipse Temurin contiene anche i font DejaVu; [Run on Alpine Linux](/slides/it/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) descrive la sua fase runtime. Per installare anche i font core di Microsoft, sostituisci la fase runtime del Dockerfile *font-check* con questa:

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

`update-ms-fonts` scarica e installa gli stessi font core di Microsoft del pacchetto Debian/Ubuntu, e la loro EULA si applica allo stesso modo. `fc-cache` aggiorna la cache dei font di fontconfig. Compila l'immagine ed esegui il controllo con i due comandi da [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Stampa:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Gli altri passaggi di questa pagina funzionano allo stesso modo su Alpine: copia la cartella *fonts* in */usr/local/share/fonts* o nella cartella dell'applicazione, e imposta `DEFAULT_FONT` per scegliere il font predefinito. L'immagine Alpine non ha una cartella */usr/local/share/fonts*, quindi quella cartella appare sulla riga `Font folders` solo dopo che un'istruzione `COPY` la crea.

## **FAQ**

**Perché una presentazione appare diversa quando viene convertita su un server?**

Il server non dispone dei font utilizzati dalla presentazione, quindi Aspose.Slides disegna il testo con un font sostitutivo le cui lettere hanno altre larghezze. Esegui *FontCheck* con i nomi dei font della presentazione per vedere quali sono sostituiti, poi installa quei font o caricali dalla cartella dell'applicazione.

**La build ha installato `ttf-mscorefonts-installer`, ma Arial è ancora sostituito. Perché?**

L'EULA non è stata accettata prima dell'installazione del pacchetto, quindi l'installatore ha saltato i font. Inserisci il comando `debconf-set-selections` prima di `apt-get install` nell'istruzione che installa il pacchetto, come mostrato in [Font Core di Microsoft](#microsoft-core-fonts), e ricostruisci l'immagine.

**Il computer che apre il PDF ha bisogno dei font?**

No. In questi esempi, il PDF contiene i font usati per disegnare il testo, quindi appare identico su qualsiasi computer. I font sono necessari solo dove Aspose.Slides rende la presentazione.