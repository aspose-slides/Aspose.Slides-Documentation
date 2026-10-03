---
title: "Ανάπτυξη Γραμματοσειρών για Aspose.Slides για Java σε Linux και σε Docker"
linktitle: "Ανάπτυξη Γραμματοσειρών"
type: docs
weight: 155
url: /el/java/deploy-fonts/
keywords:
- ανάπτυξη γραμματοσειρών
- εγκατάσταση γραμματοσειρών
- γραμματοσειρές σε Docker
- γραμματοσειρές σε Linux
- ελλείπουσες γραμματοσειρές
- αντικατάσταση γραμματοσειρών
- βασικές γραμματοσειρές Microsoft
- ttf-mscorefonts-installer
- προσαρμοσμένες γραμματοσειρές
- προεπιλεγμένη γραμματοσειρά
- διακομιστής
- container
- μετατροπή PDF
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανάπτυξη γραμματοσειρών για Aspose.Slides για Java σε διακομιστές Linux και σε containers Docker: ελέγξτε ποιες γραμματοσειρές υποκαθίστανται, εγκαταστήστε πακέτα γραμματοσειρών σε Debian, Ubuntu και Alpine, προσθέστε τα δικά σας αρχεία γραμματοσειρών και ορίστε μια προεπιλεγμένη γραμματοσειρά."
---
## **Επισκόπηση**

Aspose.Slides σχεδιάζει το κείμενο χρησιμοποιώντας τις γραμματοσειρές που είναι διαθέσιμες όταν αποδίδει μια παρουσίαση, για παράδειγμα όταν μετατρέπει διαφάνειες σε PDF ή σε εικόνες. Ένα Windows desktop συνήθως διαθέτει τις γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις. Οι Linux διακομιστές και τα containers συνήθως έχουν λίγες γραμματοσειρές, έτσι το Aspose.Slides σχεδιάζει το κείμενο με μια εναλλακτική γραμματοσειρά. Η εναλλακτική γραμματοσειρά έχει διαφορετικά σχήματα και πλάτη γραμμάτων, επομένως οι γραμμές μπορεί να τυλίγονται διαφορετικά και το κείμενο μπορεί να υπερβεί το σχήμα του, και χαρακτήρες που λείπουν στην εναλλακτική δεν σχεδιάζονται σωστά. Εάν δεν είναι εγκατεστημένη καμία γραμματοσειρά, η υποστήριξη γραμματοσειρών της Java δεν μπορεί να εκκινηθεί και το Aspose.Slides σταματά με σφάλμα.

Αυτό το άρθρο δείχνει πώς να ελέγξετε ποιες γραμματοσειρές υποκαθιστά το Aspose.Slides, πώς να εγκαταστήσετε γραμματοσειρές σε Debian, Ubuntu και Alpine Linux, πώς να προσθέσετε τα δικά σας αρχεία γραμματοσειρών και πώς να ορίσετε τη γραμματοσειρά που χρησιμοποιείται όταν λείπει μια γραμματοσειρά. Τα παραδείγματα εκτελούνται σε Docker στις επίσημες εικόνες Eclipse Temurin, όπως στη [Εκτέλεση Aspose.Slides για Java σε Docker](/slides/el/java/how-to-run-aspose-slides-in-docker/). Οι εντολές πακέτου είναι οδηγίες Dockerfile· σε έναν Linux διακομιστή, εκτελέστε τις ίδιες εντολές ως root.

Για το ίδιο το API γραμματοσειρών, όπως η ενσωμάτωση γραμματοσειρών σε παρουσίαση και οι κανόνες εναλλακτικών και αντικατάστασης, δείτε [Γραμματοσειρές PowerPoint](/slides/el/java/powerpoint-fonts/).

## **Έλεγχος Ποιες Γραμματοσειρές Υποκαθίστανται**

Το παρακάτω Maven project αναφέρει τις γραμματοσειρές που υποκαθιστά το Aspose.Slides στο τρέχον περιβάλλον. Δημιουργήστε έναν φάκελο με όνομα *font-check* και προσθέστε τα παρακάτω αρχεία σε αυτόν.

*`pom.xml`* είναι αυτό που προέρχεται από τη [Εκτέλεση Aspose.Slides για Java σε Docker](/slides/el/java/how-to-run-aspose-slides-in-docker/#create-the-project), με το artifact ID και το όνομα του αρχείου JAR να έχουν αλλάξει σε *font-check*:

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

*`src/main/java/FontCheck.java`* προσθέτει ένα πλαίσιο κειμένου ανά όνομα γραμματοσειράς σε μια διαφάνεια και ορίζει τη γραμματοσειρά με τη μέθοδο [setLatinFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Τα ονόματα γραμματοσειρών προέρχονται από τη γραμμή εντολών· χωρίς ορίσματα, το πρόγραμμα ελέγχει Calibri, Arial και Times New Roman. Εκτυπώνει τους φακέλους στους οποίους το Aspose.Slides ψάχνει για γραμματοσειρές ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--)), αποδίδει τη διαφάνεια σε *output/fonts.pdf* και εκτυπώνει τις υποκαταστάσεις που επιστρέφει το [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Τα δύο προαιρετικά βήματα στην αρχή, η φόρτωση ενός φακέλου *fonts* και η ανάγνωση μιας μεταβλητής `DEFAULT_FONT`, εξηγούνται πιο κάτω σε αυτό το άρθρο.

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
        // Οι γραμματοσειρές προς έλεγχο: τα ορίσματα γραμμής εντολών ή τρεις κοινές γραμματοσειρές Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Φορτώστε τα αρχεία γραμματοσειρών από το φάκελο fonts στον τρέχοντα φάκελο εργασίας, εάν υπάρχει.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Χρησιμοποιήστε τη γραμματοσειρά που ορίζεται στη μεταβλητή περιβάλλοντος DEFAULT_FONT, εάν έχει οριστεί, για κείμενο που λείπει η γραμματοσειρά.
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

`getFontFolders` μπορεί να επιστρέψει έναν φάκελο více από μία φορά, έτσι το πρόγραμμα συγκεντρώνει τους φακέλους σε ένα σύνολο πριν τους εκτυπώσει.

*.dockerignore* κρατά τα τοπικά αποτελέσματα κατασκευής εκτός του build context:

```text
target/
output/
```

*Dockerfile* κατασκευάζει το πρόγραμμα με την εικόνα Maven και το εκτελεί στην εικόνα χρόνου εκτέλεσης Java Eclipse Temurin, η οποία περιέχει ήδη το fontconfig και τις γραμματοσειρές DejaVu. Η [Εκτέλεση Aspose.Slides για Java σε Docker](/slides/el/java/how-to-run-aspose-slides-in-docker/) εξηγεί κάθε εντολή.

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

Κατασκευάστε την εικόνα και εκτελέστε τον έλεγχο:

```bash
docker build -t font-check .
docker run --rm font-check
```

Η εικόνα έχει μόνο τις γραμματοσειρές DejaVu, έτσι και οι τρεις γραμματοσειρές αντικαθίστανται με DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Για να ελέγξετε τις γραμματοσειρές των δικών σας παρουσιάσεων, περάστε τα ονόματά τους ως ορίσματα, π.χ. `docker run --rm font-check "Segoe UI" Consolas`. Για να αντιγράψετε το *output/fonts.pdf* έξω από το container, χρησιμοποιήστε τις εντολές στο [Αντιγραφή του Αποτελέσματος στο Μηχάνημά Σας](/slides/el/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Microsoft Core Fonts**

Το πακέτο `ttf-mscorefonts-installer` κατεβάζει και εγκαθιστά τις βασικές γραμματοσειρές της Microsoft για το διαδίκτυο, μεταξύ αυτών Arial, Times New Roman, Courier New, Verdana, Georgia και Trebuchet MS. Οι γραμματοσειρές έχουν άδεια χρήσης σύμφωνα με το ΕΣΔΑ (EULA) της Microsoft, και το πακέτο τις εγκαθιστά μόνο μετά την αποδοχή του ΕΣΔΑ. Η διαδικασία κατασκευής Docker δεν μπορεί να απαντήσει στην προτροπή, έτσι ο εγκαταστάτης απορρίπτει το ΕΣΔΑ και δεν εγκαθιστά γραμματοσειρές, ενώ το `apt-get install` εξακολουθεί να αναφέρει επιτυχία. Αποδεχτείτε το ΕΣΔΑ με `debconf-set-selections` **πριν** εγκατασταθεί το πακέτο. Η αποδοχή του σε μια μεταγενέστερη εντολή δεν βοηθά: το πακέτο είναι ήδη εγκατεστημένο και το apt δεν τρέχει ξανά τον εγκαταστάτη.

Προσθέστε αυτή την εντολή στο στάδιο χρόνου εκτέλεσης του *Dockerfile*, αμέσως μετά τη γραμμή `FROM`, έτσι ώστε να εκτελείται ως root, πριν την εντολή `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Κατασκευάστε ξανά την εικόνα και τρέξτε τον έλεγχο με τις ίδιες δύο εντολές. Τα Arial και Times New Roman είναι πλέον εγκατεστημένα:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Η Calibri, η προεπιλεγμένη γραμματοσειρά μιας παρουσίασης που δημιουργεί το Aspose.Slides, δεν είναι μία από τις βασικές γραμματοσειρές, οπότε εξακολουθεί να υποκαθίσταται. Δείτε την ενότητα [Ορισμός Προεπιλεγμένης Γραμματοσειράς για Ελλείπουσες Γραμματοσειρές](#set-a-default-font-for-missing-fonts).

Οι εικόνες Eclipse Temurin βασισμένες σε Ubuntu ενεργοποιούν το `multiverse`, το τμήμα του Ubuntu που περιέχει το πακέτο. Στο Debian, το πακέτο βρίσκεται στο τμήμα `contrib`, το οποίο οι εικόνες Debian δεν ενεργοποιούν. Σε ένα στάδιο χρόνου εκτέλεσης βασισμένο σε Debian, όπως αυτό στο [Χρήση Άλλης Βασικής Εικόνας](/slides/el/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), ενεργοποιήστε το `contrib` στην ίδια εντολή:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Άλλα Πακέτα Γραμματοσειρών**

Το Debian και το Ubuntu συσκευάζουν επίσης ελεύθερα αδειοδοτημένες γραμματοσειρές, για παράδειγμα:

| Πακέτο | Γραμματοσειρές |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, και Mono, με ίδιες μετρικές με Arial, Times New Roman και Courier New |
| `fonts-crosextra-carlito` | Carlito, με ίδιες μετρικές με Calibri |
| `fonts-crosextra-caladea` | Caladea, με ίδιες μετρικές με Cambria |

Εγκαταστήστε τα με `apt-get install` σε μια εντολή `RUN` του σταδίου χρόνου εκτέλεσης, με τον ίδιο τρόπο όπως οι βασικές γραμματοσειρές της Microsoft. Το Aspose.Slides for Java δεν εφαρμόζει τις εναλλακτικές ονομασίες γραμματοσειρών της διαμόρφωσης γραμματοσειρών Linux: με εγκατεστημένο το `fonts-liberation`, το κείμενο σε Arial εξακολουθεί να σχεδιάζεται με τη γενική εναλλακτική γραμματοσειρά, όχι με Liberation Sans. Για να χρησιμοποιήσετε μια γραμματοσειρά με συμβατές μετρικές αντί για μια ελλείπουσα, ορίστε την ως [προεπιλεγμένη γραμματοσειρά](#set-a-default-font-for-missing-fonts) ή προσθέστε έναν [κανόνα αντικατάστασης γραμματοσειρών](/slides/el/java/font-substitution/).

## **Προσθήκη Δικών Σας Αρχείων Γραμματοσειράς**

Οι γραμματοσειρές που οι διανομές δεν συσκευάζουν, όπως οι γραμματοσειρές του οργανισμού σας ή άλλες που έχετε άδεια χρήσης στον διακομιστή, μπορούν να προστεθούν ως αρχεία γραμματοσειράς. Τοποθετήστε τα αρχεία γραμματοσειράς, π.χ. αρχεία *.ttf*, σε φάκελο με όνομα *fonts* μέσα στο φάκελο *font-check*. Τα παραδείγματα παρακάτω χρησιμοποιούν τα αρχεία του Carlito, μια γραμματοσειρά με ίδιες μετρικές με Calibri, τα οποία μπορείτε να κατεβάσετε από το [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Εγκατάσταση των Γραμματοσειρών σε Φάκελο Συστήματος**

Το Aspose.Slides διαβάζει τις γραμματοσειρές στους φακέλους που εμφανίζονται στη γραμμή `Font folders`. Για να εγκαταστήσετε τις γραμματοσειρές σας για κάθε εφαρμογή στην εικόνα, αντιγράψτε τες στο */usr/local/share/fonts*, τον φάκελο για τοπικές γραμματοσειρές. Προσθέστε αυτή την εντολή στο στάδιο χρόνου εκτέλεσης του *Dockerfile*, μετά την εντολή `RUN` που εγκαθιστά τις βασικές γραμματοσειρές της Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Ξανακατασκευάστε την εικόνα, έπειτα ελέγξτε Calibri και Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Το Carlito δεν υποκαθίσταται πλέον:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Φόρτωση Γραμματοσειρών από τον Φάκελο Εφαρμογής**

Αντί να εγκαταστήσετε τις γραμματοσειρές σε φάκελο συστήματος, μπορείτε να τις συσκευάσετε μαζί με την εφαρμογή και να τις φορτώσετε με τη μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Οι γραμματοσειρές γίνονται τότε διαθέσιμες μόνο στο Aspose.Slides και αναπτύσσονται μαζί με την εφαρμογή. Το *FontCheck* το κάνει αυτό: όταν ο τρέχων φάκελος εργασίας, */app* στο container, περιέχει φάκελο *fonts*, το πρόγραμμα περνά αυτό το φάκελο στην `loadExternalFonts` πριν δημιουργήσει την παρουσίαση. Το [Προσαρμοσμένη Γραμματοσειρά](/slides/el/java/custom-font/) περιγράφει άλλους τρόπους παροχής γραμματοσειρών, όπως η φόρτωση από μνήμη.

Στο *Dockerfile*, αφαιρέστε την εντολή `COPY fonts/ /usr/local/share/fonts/` και προσθέστε αυτήν μετά την εντολή που αντιγράφει το φάκελο *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Ξανακατασκευάστε την εικόνα και εκτελέστε τον έλεγχο με τις ίδιες δύο εντολές. Ο φάκελος εφαρμογής εμφανίζεται τώρα μεταξύ των φακέλων γραμματοσειρών, και το Carlito δεν υποκαθίσταται:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` προσθέτει γραμματοσειρές στις εγκατεστημένες, αλλά η υποστήριξη γραμματοσειρών της Java εξακολουθεί να χρειάζεται τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Σε μια εικόνα χωρίς καμία, το `loadExternalFonts` σταματά με το σφάλμα "Fontconfig head is null, check your fonts or fonts configuration".

## **Ορισμός Προεπιλεγμένης Γραμματοσειράς για Ελλείπουσες Γραμματοσειρές**

Όταν λείπει μια γραμματοσειρά, το Aspose.Slides χρησιμοποιεί μια εναλλακτική που επιλέγει μόνο του. Για να την επιλέξετε εσείς, περάστε το όνομα της γραμματοσειράς στη μέθοδο [setDefaultRegularFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) του [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) και δώστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/). Το *FontCheck* διαβάζει το όνομα της γραμματοσειράς από τη μεταβλητή περιβάλλοντος `DEFAULT_FONT`. Με το Carlito φορτωμένο, χρησιμοποιήστε το για τις ελλείπουσες γραμματοσειρές:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Τώρα η Calibri σχεδιάζεται με Carlito, των οποίων οι χαρακτήρες έχουν τα ίδια πλάτη με αυτούς της Calibri, έτσι το κείμενο διατηρεί τις αλλαγές γραμμής:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Η προεπιλεγμένη γραμματοσειρά αντικαθιστά κάθε ελλείπουσα γραμματοσειρά. Για να αντιστοιχίσετε μεμονωμένες γραμματοσειρές, π.χ. Arial σε Liberation Sans και Calibri σε Carlito, χρησιμοποιήστε [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/java/font-substitution/). Οι κανόνες αλλάζουν το παραγόμενο αποτέλεσμα, αλλά το `getSubstitutions` δεν τα αντικατοπτρίζει, οπότε ελέγξτε τις γραμματοσειρές στο αρχείο εξόδου. Για ασιατικό κείμενο, καλέστε επίσης [setDefaultAsianFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); δείτε το [Προεπιλεγμένη Γραμματοσειρά](/slides/el/java/default-font/).

## **Εγκατάσταση Γραμματοσειρών σε Alpine Linux**

Η εικόνα Eclipse Temurin βασισμένη σε Alpine περιέχει επίσης τις γραμματοσειρές DejaVu· η ενότητα [Εκτέλεση σε Alpine Linux](/slides/el/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) περιγράφει το στάδιο χρόνου εκτέλεσης. Για να εγκαταστήσετε και τις βασικές γραμματοσειρές της Microsoft, αντικαταστήστε το στάδιο χρόνου εκτέλεσης του Dockerfile *font-check* με το εξής:

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

`update-ms-fonts` κατεβάζει και εγκαθιστά τις ίδιες βασικές γραμματοσειρές της Microsoft όπως το πακέτο Debian και Ubuntu, και το ΕΣΔΑ τους εφαρμόζεται με τον ίδιο τρόπο. `fc-cache` ενημερώνει την κρυφή μνήμη γραμματοσειρών του fontconfig. Κατασκευάστε την εικόνα και τρέξτε τον έλεγχο με τις δύο εντολές από την ενότητα [Έλεγχος Ποιες Γραμματοσειρές Υποκαθίστανται](#check-which-fonts-are-substituted). Εκτυπώνει:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Τα υπόλοιπα βήματα σε αυτή τη σελίδα λειτουργούν με τον ίδιο τρόπο στο Alpine: αντιγράψτε το φάκελο *fonts* στο */usr/local/share/fonts* ή στον φάκελο εφαρμογής και ορίστε `DEFAULT_FONT` για να επιλέξετε τη προεπιλεγμένη γραμματοσειρά. Η εικόνα Alpine δεν έχει φάκελο */usr/local/share/fonts*, έτσι αυτός ο φάκελος εμφανίζεται στη γραμμή `Font folders` μόνο μετά από εντολή `COPY` που τον δημιουργεί.

## **ΣΥΝΗΘΩΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί μια παρουσίαση φαίνεται διαφορετική όταν μετατρέπεται σε διακομιστή;**

Ο διακομιστής δεν διαθέτει τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση, έτσι το Aspose.Slides σχεδιάζει το κείμενο με μια εναλλακτική γραμματοσειρά της οποίας τα γράμματα έχουν διαφορετικά πλάτη. Εκτελέστε το *FontCheck* με τα ονόματα γραμματοσειρών της παρουσίασης για να δείτε ποιες υποκαθίστανται, στη συνέχεια εγκαταστήστε τις ή φορτώστε τις από το φάκελο εφαρμογής.

**Το build εγκατέστησε το ttf-mscorefonts-installer, αλλά το Arial εξακολουθεί να υποκαθίσταται. Γιατί;**

Το ΕΣΔΑ δεν είχε αποδεκτεί πριν την εγκατάσταση του πακέτου, έτσι ο εγκαταστάτης παρακάμψε τις γραμματοσειρές. Τοποθετήστε την εντολή `debconf-set-selections` πριν το `apt-get install` στην εντολή που εγκαθιστά το πακέτο, όπως φαίνεται στα [Microsoft Core Fonts](#microsoft-core-fonts), και ξανακατασκευάστε την εικόνα.

**Χρειάζονται οι υπολογιστές που ανοίγουν το PDF τις γραμματοσειρές;**

Όχι. Στα παραδείγματα αυτά, το PDF περιέχει τις γραμματοσειρές που χρησιμοποιήθηκαν για τη σχεδίαση του κειμένου, έτσι φαίνεται ίδιο σε οποιονδήποτε υπολογιστή. Οι γραμματοσειρές απαιτούνται μόνο εκεί που το Aspose.Slides αποδίδει την παρουσίαση.