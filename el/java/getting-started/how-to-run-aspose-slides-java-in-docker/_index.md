---
title: Εκτέλεση Aspose.Slides for Java σε Docker
linktitle: Docker
type: docs
weight: 150
url: /el/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Κοντέινερ Docker
- κατασκευή πολλαπλών σταδίων
- εικόνα κοντέινερ
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- γραμματοσειρές
- μετατροπή PDF
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και εκτελέστε μια εφαρμογή Aspose.Slides for Java σε Docker: ένα Dockerfile πολλαπλών σταδίων στις επίσημες εικόνες Maven και Eclipse Temurin, τις βιβλιοθήκες Linux και τις γραμματοσειρές που χρειάζεται το Aspose.Slides, και πώς να αντιγράψετε τα παραγόμενα αρχεία στον υπολογιστή σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εκτελέσετε το Aspose.Slides for Java σε ένα κοντέινερ Docker. Δημιουργείτε ένα μικρό έργο Maven που δημιουργεί μια παρουσίαση με πλαίσιο κειμένου και τη μετατρέπει σε PDF, το πακετάρετε με ένα Dockerfile πολλαπλών σταδίων πάνω στις επίσημες εικόνες Maven και Eclipse Temurin, το εκτελείτε και αντιγράφετε τα παραγόμενα αρχεία στον υπολογιστή σας. Το άρθρο εξηγεί επίσης τι χρειάζεται το Aspose.Slides σε μια εικόνα Linux εκτός από τη Java και ολοκληρώνεται με παραλλαγές για Alpine Linux και για εικόνες που εγκαθιστούν τη Java από τα πακέτα της διανομής.

Χρειάζεστε μόνο το Docker στον υπολογιστή σας. Το JDK και το Maven περιλαμβάνονται στην εικόνα δημιουργίας, έτσι δεν χρειάζεται να τα εγκαταστήσετε. Για την εγκατάσταση του Docker, δείτε [Λάβετε Docker](https://docs.docker.com/get-started/get-docker/).

## **Επιλογή των Βασικών Εικόνων**

The Dockerfile in this article uses two official images from Docker Hub:

- [maven](https://hub.docker.com/_/maven) with the tag `3.9-eclipse-temurin-21` χτίζει την εφαρμογή. Περιέχει Apache Maven 3.9 και το Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) with the tag `21-jre` το εκτελεί. Περιέχει το Eclipse Temurin Java 21 runtime σε Ubuntu, χωρίς το JDK και το Maven.

Το Aspose.Slides for Java σχεδιάζει κείμενο με την υποστήριξη γραμματοσειρών της Java, η οποία σε Linux απαιτεί τις βιβλιοθήκες fontconfig και FreeType και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Οι εικόνες Eclipse Temurin περιέχουν ήδη fontconfig, FreeType και τις γραμματοσειρές DejaVu, έτσι το Dockerfile σε αυτό το άρθρο δεν εγκαθιστά πακέτα. Σε μια εικόνα χωρίς καμία γραμματοσειρά, η αποθήκευση μιας παρουσίασης σταματά με το σφάλμα "Fontconfig head is null, check your fonts or fonts configuration". Αν δημιουργήσετε σε άλλη βασική εικόνα, δείτε [Χρήση Άλλης Βασικής Εικόνας](#use-another-base-image).

## **Δημιουργία Έργου**

Δημιουργήστε ένα φάκελο με όνομα *hello-slides-docker* και προσθέστε τα παρακάτω αρχεία σε αυτόν.

*pom.xml* δηλώνει το αποθετήριο Maven του Aspose και την εξάρτηση Aspose.Slides for Java, όπως περιγράφεται στην [Εγκατάσταση](/slides/el/java/installation/). Το Aspose.Slides for Java δεν είναι δημοσιευμένο στο Maven Central, έτσι απαιτείται η καταχώρηση του αποθετηρίου. Το στοιχείο `finalName` ορίζει το αρχείο JAR της εφαρμογής *hello-slides.jar*, και το [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) αντιγράφει τις εξαρτήσεις της εφαρμογής στο *target/lib* όταν το Maven το πακετάρει. Ορίστε την έκδοση του Aspose.Slides στην πιο πρόσφατη που εμφανίζεται στο [αποθετήριο](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
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
        <finalName>hello-slides</finalName>
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

*src/main/java/HelloSlides.java* δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη του διαφάνεια, και αποθηκεύει την παρουσίαση δύο φορές με τη μέθοδο [save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-): ως PPTX και ως PDF. Και τα δύο αρχεία αποθηκεύονται στο φάκελο *output* στο τρέχον κατάλογο εργασίας. Το πρόγραμμα στη συνέχεια καταγράφει τις γραμματοσειρές που το Aspose.Slides αντικαθιστά όταν αποδίδει την παρουσίαση, χρησιμοποιώντας το [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), ώστε να δείτε αν το κοντέινερ διαθέτει τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* διατηρεί το φάκελο *target* μιας τοπικής δημιουργίας και την έξοδο προηγούμενων εκτελέσεων εκτός του περιβάλλοντος κατασκευής Docker, έτσι η εικόνα δημιουργείται μόνο από τα αρχεία πηγής.

```text
target/
output/
```

## **Γράψτε το Dockerfile**

Προσθέστε ένα αρχείο με όνομα *Dockerfile* στον φάκελο *hello-slides-docker*:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Το αρχείο έχει δύο στάδια:

- **The build stage** αρχίζει από την εικόνα Maven. Αντιγράφει πρώτα το *pom.xml* και εκτελεί `mvn dependency:go-offline`, το οποίο κατεβάζει το Aspose.Slides for Java και τα πρόσθετα Maven, έτσι το Docker επαναχρησιμοποιεί αυτό το στρώμα όσο το *pom.xml* δεν αλλάξει. Στη συνέχεια αντιγράφει τον πηγαίο κώδικα και εκτελεί `mvn package`, το οποίο μεταγλωττίζει το πρόγραμμα στο *target/hello-slides.jar* και αντιγράφει το αρχείο JAR του Aspose.Slides στο *target/lib*. Η επιλογή `-B` εκτελεί το Maven σε μη διαδραστική (batch) λειτουργία.
- **The runtime stage** αρχίζει από τη μικρότερη εικόνα χρόνου εκτέλεσης Java και αντιγράφει μόνο το αρχείο JAR της εφαρμογής και το φάκελο *lib*. Δημιουργεί το φάκελο *output*, το προσδίδει στο `ubuntu`, τον μη‑root χρήστη που ορίζει η εικόνα βασισμένη σε Ubuntu, και εκτελεί την εφαρμογή ως αυτός ο χρήστης. Η διαδρομή κλάσης `hello-slides.jar:lib/*` περιέχει την εφαρμογή και κάθε αρχείο JAR στο *lib*· η Java επεκτείνει το `*` αυτόματα.

Το έργο μεταγλωττίζεται για Java 11 (την ιδιότητα `maven.compiler.release`), έτσι το στάδιο χρόνου εκτέλεσης μπορεί να χρησιμοποιήσει μια νεότερη έκδοση της Java. Για παράδειγμα, για να εκτελέσετε την εφαρμογή σε Java 25, αλλάξτε την εικόνα του σταδίου χρόνου εκτέλεσης σε `eclipse-temurin:25-jre`.

## **Δημιουργία και Εκτέλεση του Κοντέινερ**

Ανοίξτε ένα τερματικό στον φάκελο *hello-slides-docker*. Δημιουργήστε την εικόνα, μετά εκτελέστε ένα κοντέινερ από αυτήν:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Η πρώτη δημιουργία κατεβάζει τις βασικές εικόνες, τα πρόσθετα Maven και το Aspose.Slides for Java, οπότε διαρκεί αρκετά λεπτά· οι μεταγενέστερες δημιουργίες τις επαναχρησιμοποιούν. Το κοντέινερ εκτελεί την εφαρμογή και σταματά. Εμφανίζει:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Η πρώτη γραμμή δείχνει ότι το κείμενο χρησιμοποιεί **Calibri**, την προεπιλεγμένη γραμματοσειρά μιας νέας παρουσίασης, και ότι το **Calibri** δεν είναι εγκατεστημένο στην εικόνα, έτσι το Aspose.Slides σχεδίασε το κείμενο με **DejaVu Sans**. Το κείμενο στο PDF είναι πραγματικό, επιλέξιμο κείμενο με αυτή τη γραμματοσειρά. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε [Αδειοδότηση](/slides/el/java/licensing/).

## **Αντιγραφή του Αποτελέσματος στον Υπολογιστή Σας**

Τα αρχεία βρίσκονται στο φάκελο */app/output* του σταματημένου κοντέινερ. Αντιγράψτε τα σε ένα φάκελο *output* στον υπολογιστή σας, έπειτα αφαιρέστε το κοντέινερ:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Αυτές οι δύο εντολές λειτουργούν με τον ίδιο τρόπο σε Bash, PowerShell και το Windows Command Prompt.

Σε Linux, μπορείτε αντί αυτού να προσαρτήσετε έναν φάκελο του μηχανήματός σας στο κοντέινερ, ώστε η εφαρμογή να γράφει τα αρχεία εκεί απευθείας:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Η επιλογή `--user` εκτελεί την εφαρμογή με τα UID και GID του χρήστη σας, ώστε να μπορεί να γράψει στον φάκελο που δημιουργήσατε και τα αρχεία να ανήκουν σε εσάς. Η `--rm` αφαιρεί το κοντέινερ όταν σταματήσει.

## **Εκτέλεση σε Alpine Linux**

Το Eclipse Temurin είναι επίσης διαθέσιμο ως εικόνα βασισμένη σε Alpine Linux, η οποία είναι μικρότερη. Περιέχει επίσης fontconfig, FreeType και τις γραμματοσειρές DejaVu, έτσι η εφαρμογή δεν χρειάζεται επιπλέον πακέτα εκεί. Για να το χρησιμοποιήσετε, αντικαταστήστε το στάδιο χρόνου εκτέλεσης στο *Dockerfile* (όλα από τη δεύτερη γραμμή `FROM`) με:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Η εικόνα Alpine δεν έχει χρήστη `ubuntu`, έτσι αυτό το στάδιο δημιουργεί έναν χρήστη με όνομα `app` με την `adduser` και εκτελεί την εφαρμογή ως αυτός ο χρήστης. Δημιουργήστε, εκτελέστε και αντιγράψτε το αποτέλεσμα με τις ίδιες εντολές όπως παραπάνω. Η εφαρμογή εμφανίζει τις ίδιες δύο γραμμές.

## **Χρήση Άλλης Βασικής Εικόνας**

Αν η εικόνα σας εγκαθιστά τη Java από τα πακέτα της διανομής Linux, εγκαταστήστε τις βιβλιοθήκες γραμματοσειρών της Java και μια γραμματοσειρά μαζί τους. Σε Debian και Ubuntu, το πακέτο `openjdk-21-jre-headless` αναφέρει τα fontconfig, FreeType και HarfBuzz μόνο ως προτεινόμενα πακέτα, έτσι η εντολή `apt-get install --no-install-recommends` τα αφήνει έξω, και η εφαρμογή σταματά με ένα `UnsatisfiedLinkError` για το `libfontmanager.so`. Αυτό το στάδιο χρόνου εκτέλεσης εγκαθιστά Java 21, τις βιβλιοκες και τις γραμματοσειρές DejaVu σε Debian 13, και δημιουργεί έναν μη‑root χρήστη με όνομα `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Το ίδιο στάδιο λειτουργεί σε Ubuntu 26.04 με `FROM ubuntu:26.04`.

## **Συχνές Ερωτήσεις**

**Η αποθήκευση της παρουσίασης σταματά με το μήνυμα "Fontconfig head is null, check your fonts or fonts configuration". Τι λείπει;**

Μία γραμματοσειρά. Η υποστήριξη γραμματοσειρών της Java δεν βρήκε εγκατεστημένη γραμματοσειρά στην εικόνα. Εγκαταστήστε ένα πακέτο γραμματοσειρών, π.χ. `fonts-dejavu-core` σε Debian και Ubuntu, όπως στην [Χρήση Άλλης Βασικής Εικόνας](#use-another-base-image). Το [Ανάπτυξη Γραμματοσειρών](/slides/el/java/deploy-fonts/) απαριθμεί άλλα πακέτα γραμματοσειρών.

**Η εφαρμογή σταματά με UnsatisfiedLinkError για libfontmanager.so. Τι λείπει;**

Μία εγγενή βιβλιοθήκη της υποστήριξης γραμματοσειρών της Java· το μήνυμα αναφέρει το αρχείο που δεν μπόρεσε να φορτωθεί, π.χ. `libharfbuzz.so.0`. Αυτό συμβαίνει όταν η Java εγκαθίσταται από τα πακέτα της διανομής χωρίς τα προτεινόμενα πακέτα τους. Εγκαταστήστε τις βιβλιοθήκες που αναφέρονται στην [Χρήση Άλλης Βασικής Εικόνας](#use-another-base-image).

**Γιατί το κείμενο στο PDF εμφανίζεται με διαφορετική γραμματοσειρά από το PowerPoint;**

Οι γραμματοσειρές που χρησιμοποιεί η παρουσίαση δεν είναι εγκατεστημένες στην εικόνα, έτσι το Aspose.Slides σχεδιάζει το κείμενο με εναλλακτική γραμματοσειρά. Η έξοδος της εφαρμογής εμφανίζει κάθε αντικατεστημένη γραμματοσειρά. Το [Ανάπτυξη Γραμματοσειρών](/slides/el/java/deploy-fonts/) εξηγεί πώς να εγκαταστήσετε γραμματοσειρές στην εικόνα ή να τις φορτώσετε από το φάκελο της εφαρμογής.

**Πόση μνήμη μπορεί να χρησιμοποιήσει η εφαρμογή στο κοντέινερ;**

Από προεπιλογή, η Java περιορίζει το heap της σε ένα τέταρτο της μνήμης που είναι διαθέσιμη στο κοντέινερ, π.χ. περίπου 250 MB όταν ξεκινάτε το κοντέινερ με `docker run -m 1g`. Για την επεξεργασία μεγάλων παρουσιάσεων, αυξήστε το ποσοστό με την επιλογή `MaxRAMPercentage`, π.χ. `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Η Java τότε εκτυπώνει τη γραμμή "Picked up JAVA_TOOL_OPTIONS" πριν την έξοδο της εφαρμογής.

**Χρειάζομαι JDK ή Maven στον υπολογιστή μου;**

Όχι. Το στάδιο δημιουργίας μεταγλωττίζει την εφαρμογή μέσα στην εικόνα Maven. Χρειάζεστε JDK και Maven μόνο αν θέλετε επίσης να δημιουργήσετε και να εκτελέσετε την εφαρμογή εκτός Docker· δείτε [Εγκατάσταση](/slides/el/java/installation/).