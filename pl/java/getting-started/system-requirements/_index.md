---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/java/system-requirements/
keywords:
- wymagania systemowe
- wspierane platformy
- wersje Java
- JDK
- JRE
- fontconfig
- czcionki
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Sprawdź, co Aspose.Slides for Java wymaga przed instalacją: wspierane wersje Java i systemy operacyjne oraz biblioteka czcionek i czcionki, które wymaga Linux."
---
## **Wprowadzenie**

Aspose.Slides for Java jest samodzielną biblioteką: nie wymaga Microsoft PowerPoint ani Microsoft Office. To pojedynczy plik JAR, publikowany w repozytorium Maven firmy Aspose. Plik JAR zawiera wyłącznie klasy i zasoby Java, bez bibliotek natywnych, i nie deklaruje zależności od innych bibliotek. Ten sam plik działa więc na każdym systemie operacyjnym i procesorze, dla którego dostępny jest obsługiwany środowisko uruchomieniowe Java.

Ten artykuł wymienia obsługiwane wersje Java i systemy operacyjne oraz bibliotekę czcionek i czcionki potrzebne w systemie Linux, a kończy się krótkim programem sprawdzającym konfigurację. Aby dodać bibliotekę do projektu, zobacz [Instalacja](/slides/pl/java/installation/).

## **Obsługiwane wersje Java**

Aspose.Slides for Java działa na Java 8 lub nowszej, z JDK lub JRE. Obejmuje to wydania z długoterminowym wsparciem Java 8, 11, 17, 21 i 25 oraz późniejsze, takie jak Java 26 i Java 27. Środowisko uruchomieniowe Java może pochodzić od dowolnego dostawcy, na przykład Eclipse Temurin, Amazon Corretto, Oracle lub pakiety OpenJDK dystrybucji Linux.

Aspose.Slides nie wymaga żadnych opcji JVM, takich jak `--add-opens`, w żadnej z tych wersji. W Java 11 JVM wypisuje ostrzeżenie zaczynające się od „WARNING: An illegal reflective access operation has occurred”; ostrzeżenie nie wpływa na wynik.

{{% alert color="warning" title="Warning" %}}
Java 6 i Java 7 są przestarzałe. Aspose.Slides for Java 26.9 nadal działa na nich, ale wyświetla ostrzeżenie o przestarzałości. Od wersji 26.10 minimalną wersją jest Java 8, a Java 6 i 7 nie są już wspierane.
{{% /alert %}}

Projekt Maven oraz polecenia w [Instalacja](/slides/pl/java/installation/) wymagają JDK 11 lub nowszego. Z Java 8 skompiluj i uruchom program jak opisano w [Sprawdź konfigurację](#sprawdź-konfigurację).

## **Obsługiwane systemy operacyjne**

Ponieważ plik JAR nie zawiera kodu natywnego, Aspose.Slides for Java działa na Windows, Linux i macOS, na dowolnej architekturze procesora obsługiwanej przez środowisko uruchomieniowe Java, takiej jak x64 i ARM64. Na Windows jedynym wymogiem jest środowisko uruchomieniowe Java. W systemie Linux wsparcie czcionek Java wymaga także biblioteki czcionek i czcionek opisanych w sekcji [Linux](#linux).

## **Linux**

Aspose.Slides for Java układa i rysuje tekst przy użyciu wsparcia czcionek środowiska uruchomieniowego Java. W Linux to wsparcie wymaga biblioteki fontconfig oraz co najmniej jednej zainstalowanej czcionki. Oficjalne obrazy kontenerów dystrybucji Linux często nie zawierają żadnego z nich. Bez nich pierwszy przykład w [Tworzenie prezentacji](/slides/pl/java/create-presentation/) nie udaje się przy zapisie prezentacji, pozostawia pusty plik i zgłasza następujący błąd:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Oficjalne obrazy kontenerów `eclipse-temurin` dla Ubuntu i Alpine Linux już zawierają fontconfig i czcionki DejaVu, więc nie trzeba nic instalować. Na innych systemach zainstaluj poniższe pakiety. Polecenia dla Debiana, Ubuntu i Red Hat używają `sudo`; w Dockerfile uruchom je w instrukcji `RUN` bez `sudo`. Czcionki DejaVu wystarczają do uruchomienia Aspose.Slides; czcionki użyte w Twoich prezentacjach opisano w sekcji [Czcionki](#czcionki).

### **Debian i Ubuntu**

Jeśli instalujesz Javę z pakietów Debian lub Ubuntu przy domyślnych ustawieniach `apt-get`, tak jak w poleceniu w [Instalacja](/slides/pl/java/installation/#linux), pakiety Java również instalują bibliotekę fontconfig, czcionki DejaVu oraz bibliotekę HarfBuzz, której te pakiety potrzebują, i nic więcej nie jest wymagane.

Przy środowisku uruchomieniowym Java z innego źródła, np. archiwum Eclipse Temurin, zainstaluj fontconfig i czcionki DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile często instalują pakiety Java Debiana lub Ubuntu, takie jak `openjdk-21-jdk-headless` lub `default-jdk-headless`, z opcją `--no-install-recommends`, która pomija wszystkie trzy. Zainstaluj fontconfig i czcionki DejaVu poleceniem powyżej oraz HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Bez HarfBuzz te pakiety Java wypisują `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, a zapis kończy się `UnsatisfiedLinkError`, informującym, że nie można otworzyć `libharfbuzz.so.0`.

### **Red Hat Enterprise Linux**

Pakiety `java-<version>-openjdk-headless` w Red Hat Enterprise Linux nie instalują biblioteki fontconfig. Zainstaluj ją razem z czcionkami DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Pełne pakiety `java-<version>-openjdk` instalują fontconfig i czcionki jako zależności, tak samo jak pakiety Amazon Corretto dla Amazon Linux 2023, np. `java-21-amazon-corretto-headless`.

### **Alpine Linux**

W Dockerfile opartym na Alpine Linux zainstaluj fontconfig i czcionki DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

W aktualnych wydaniach Alpine `ttf-dejavu` instaluje pakiet `font-dejavu`. Zainstaluj Javę pakietem `openjdk<version>-jre` lub `openjdk<version>-jdk`, np. `openjdk25-jdk`. Pakiety `openjdk<version>-jre-headless` w Alpine nie zawierają biblioteki czcionek Javy, więc z nimi program kończy się błędem `UnsatisfiedLinkError: no fontmanager in system library path`, nawet jeśli czcionki są zainstalowane.

### **Czcionki**

Aby tekst był renderowany właściwymi czcionkami i metrykami, czcionki użyte w prezentacjach lub ich odpowiednie zamienniki muszą być zainstalowane w systemie lub załadowane przez aplikację. Zobacz [Wdrażanie czcionek](/slides/pl/java/deploy-fonts/), [Zamiana czcionek](/slides/pl/java/font-substitution/) i [Własne czcionki](/slides/pl/java/custom-font/).

## **Sprawdź konfigurację**

Aby zweryfikować, że biblioteka i jej wymagania są spełnione, uruchom program zapisujący prezentację i renderujący slajd jako obraz. Zapis i renderowanie korzystają ze wsparcia czcionek środowiska uruchomieniowego Java, które zapewniają opisane wyżej wymagania Linux.

Zapisz poniższy kod jako *CheckSetup.java* w katalogu zawierającym plik JAR Aspose.Slides. Aby pobrać plik JAR, zobacz [Użyj pliku JAR bez Maven](/slides/pl/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Dodaj prostokąt z tekstem do pierwszego slajdu i zapisz prezentację.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Renderuj slajd z jednym pikselem na punkt i zapisz obraz.
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

Z JDK 11 lub nowszym uruchom program w tym katalogu poleceniem poniżej. Jeśli Twój plik JAR ma inną nazwę, zmień nazwę w poleceniach.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Z Java 8 lub na systemie posiadającym jedynie JRE, skompiluj program `javac` z JDK, a następnie uruchom skompilowaną klasę. Na Linux i macOS uruchom:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

W Windows uruchom to samo polecenie `javac`, a następnie klasę, używając średnika jako separatora ścieżki klas. Zachowaj cudzysłowy, aby PowerShell nie traktował średnika jako zakończenia polecenia: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Program dodaje prostokąt z tekstem do pierwszego slajdu i zapisuje prezentację jako *hello.pptx* metodą [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Następnie renderuje slajd metodą [getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getImage-float-float-) i zapisuje wynik jako *hello.png* przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) w formacie [ImageFormat.Png](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/). Czynniki skalowania równe 1 renderują po jednym pikselu na punkt, więc domyślny slajd 720 × 540 punktów staje się obrazem 720 × 540 pikseli, z widocznym tekstem w prostokącie. Bez licencji oba pliki zawierają znak wodny oceny; zobacz [Licencjonowanie](/slides/pl/java/licensing/). Jeśli brakuje wymaganego elementu, program zatrzyma się jednym z błędów opisanych w sekcji [Linux](#linux).

## **Narzędzia deweloperskie**

Możesz budować aplikacje używające Aspose.Slides przy dowolnym JDK obsługiwanej wersji Java. Użyj Apache Maven z repozytorium Maven firmy Aspose, jak opisano w [Instalacja](/slides/pl/java/installation/), lub dowolnego innego narzędzia budującego, które potrafi korzystać z repozytorium Maven. Możesz także dodać plik JAR do ścieżki klas swojego IDE lub narzędzia budującego samodzielnie.

## **FAQ**

**Czy muszę mieć zainstalowany Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany. Aspose.Slides jest samodzielnym silnikiem do [tworzenia](/slides/pl/java/create-presentation/), modyfikowania, [konwersji](/slides/pl/java/convert-presentation/) i [renderowania](/slides/pl/java/convert-powerpoint-to-png/) prezentacji.

**Czy Aspose.Slides for Java wymaga wyświetlacza lub środowiska graficznego na serwerze Linux?**

Nie. Aspose.Slides nie potrzebuje serwera X ani wyświetlacza, więc działa na serwerach i w kontenerach. W Linux potrzebuje jedynie biblioteki czcionek i czcionek opisanych w sekcji [Linux](#linux).

**Jakie czcionki są potrzebne do poprawnego renderowania?**

Czcionki użyte w prezentacji lub odpowiednie [zamienniki](/slides/pl/java/font-substitution/) muszą być dostępne. Na systemach Linux i macOS zainstaluj pakiety czcionek, których potrzebują Twoje prezentacje, aby uzyskać spójny render.

**Dlaczego niestandardowa czcionka renderuje się jako zamiennik lub brakujący tekst w systemie Linux?**

Jeśli plik czcionki ma niezgodne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek Linux (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje, że czcionka pozostaje nierozpoznana. Użycie wersji czcionki z poprawionymi rekordami tabeli nazw lub zainstalowanie spójnego zamiennika rozwiązuje problem.