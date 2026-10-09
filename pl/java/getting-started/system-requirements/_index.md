---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/java/system-requirements/
keywords:
- wymagania systemowe
- obsługiwane platformy
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
description: "Sprawdź, czego potrzebuje Aspose.Slides for Java przed instalacją: wspierane wersje Java i systemy operacyjne oraz biblioteka czcionek i czcionki wymagane w Linuksie."
---
## **Wprowadzenie**

Aspose.Slides for Java to samodzielna biblioteka: nie wymaga Microsoft PowerPoint ani Microsoft Office. Jest to pojedynczy plik JAR, opublikowany w repozytorium Maven firmy Aspose. Plik JAR zawiera wyłącznie klasy i zasoby Javy, bez bibliotek natywnych, i nie deklaruje zależności od innych bibliotek. Ten sam plik działa na każdym systemie operacyjnym i procesorze, dla którego dostępny jest obsługiwany środowisko Java Runtime.

Ten artykuł wymienia wspierane wersje Javy i systemy operacyjne oraz bibliotekę czcionek i czcionki potrzebne w Linuksie, a kończy się krótkim programem, który sprawdza Twoją konfigurację. Aby dodać bibliotekę do projektu, zobacz [Instalacja](/slides/pl/java/installation/).

## **Wspierane wersje Javy**

Aspose.Slides for Java działa na Java 8 lub nowszej, z JDK lub JRE. Obejmuje to wersje o długoterminowym wsparciu Java 8, 11, 17, 21 i 25 oraz późniejsze, takie jak Java 26 i Java 27. Środowisko Java może pochodzić od dowolnego dostawcy, np. Eclipse Temurin, Amazon Corretto, Oracle lub pakietów OpenJDK dystrybucji Linuksa.

Aspose.Slides nie wymaga żadnych opcji JVM, takich jak `--add-opens`, w żadnej z tych wersji. W Java 11 JVM wypisuje ostrzeżenie zaczynające się od „WARNING: An illegal reflective access operation has occurred”; ostrzeżenie nie wpływa na wynik.

{{% alert color="warning" title="Warning" %}}
Java 6 i Java 7 są przestarzałe. Aspose.Slides for Java 26.9 nadal działa na nich, ale wypisuje ostrzeżenie o przestarzałości. Od wersji 26.10 minimalną wersją jest Java 8, a Java 6 i Java 7 nie są już wspierane.
{{% /alert %}}

Projekt Maven i polecenia w [Instalacja](/slides/pl/java/installation/) wymagają JDK 11 lub nowszego. Z Java 8 kompiluj i uruchamiaj program tak, jak pokazano w [Sprawdź swoją konfigurację](#check-your-setup).

## **Wspierane systemy operacyjne**

Ponieważ plik JAR nie zawiera kodu natywnego, Aspose.Slides for Java działa na Windows, Linux i macOS, na dowolnej architekturze procesora obsługiwanej przez środowisko Java, takiej jak x64 i ARM64. Środowisko Java jest jedynym wymogiem w Windows. W Linuksie wsparcie czcionek Javy wymaga także biblioteki czcionek i czcionek opisanych w [Linux](#linux).

## **Linux**

Aspose.Slides for Java układa i rysuje tekst przy użyciu wsparcia czcionek środowiska Java. W Linuksie to wsparcie wymaga biblioteki fontconfig oraz przynajmniej jednej zainstalowanej czcionki. Oficjalne obrazy kontenerów dystrybucji Linuksa często nie zawierają ich. Bez nich pierwszy przykład w [Tworzenie prezentacji](/slides/pl/java/create-presentation/) nie udaje się przy zapisywaniu prezentacji, pozostawia pusty plik i zgłasza następujący błąd:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Oficjalne obrazy kontenerów `eclipse-temurin` dla Ubuntu i Alpine Linux już zawierają fontconfig i czcionki DejaVu, więc nie trzeba nic instalować. Na innych systemach zainstaluj poniższe pakiety. Polecenia dla Debian, Ubuntu i Red Hat używają `sudo`; w Dockerfile uruchom je w instrukcji `RUN` bez `sudo`. Czcionki DejaVu wystarczą do działania Aspose.Slides; czcionki używane w Twoich prezentacjach opisano w [Czcionki](#fonts).

### **Debian i Ubuntu**

Jeśli instalujesz Javę z pakietów Debian lub Ubuntu przy domyślnych ustawieniach `apt-get`, tak jak w poleceniu w [Instalacja](/slides/pl/java/installation/#linux), pakiety Java również instalują bibliotekę fontconfig, czcionki DejaVu i bibliotekę HarfBuzz, której te pakiety Java potrzebują, i nie jest wymagane nic więcej.

Przy środowisku Java pochodzącym z innego źródła, np. archiwum Eclipse Temurin, zainstaluj fontconfig i czcionki DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile często instalują pakiety Java Debian lub Ubuntu, takie jak `openjdk-21-jdk-headless` lub `default-jdk-headless`, z opcją `--no-install-recommends`, co pomija wszystkie trzy. Zainstaluj fontconfig i czcionki DejaVu przy użyciu powyższego polecenia oraz także HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Bez HarfBuzz te pakiety Java wypisują `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, a zapisanie kończy się `UnsatisfiedLinkError`, który informuje, że nie można otworzyć `libharfbuzz.so.0`.

### **Red Hat Enterprise Linux**

Pakiety `java-<version>-openjdk-headless` Red Hat Enterprise Linux nie instalują biblioteki fontconfig. Zainstaluj ją razem z czcionkami DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Pełne pakiety `java-<version>-openjdk` instalują fontconfig i czcionki jako zależności, podobnie jak pakiety Amazon Corretto dla Amazon Linux 2023, np. `java-21-amazon-corretto-headless`.

### **Alpine Linux**

W Dockerfile opartym na Alpine Linux zainstaluj fontconfig i czcionki DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

W aktualnych wydaniach Alpine `ttf-dejavu` instalują pakiet `font-dejavu`. Zainstaluj Javę przy pomocy pakietu `openjdk<version>-jre` lub `openjdk<version>-jdk`, np. `openjdk25-jdk`. Pakiety `openjdk<version>-jre-headless` Alpine nie zawierają biblioteki czcionek Javy, więc program kończy się błędem `UnsatisfiedLinkError: no fontmanager in system library path`, nawet gdy czcionki są zainstalowane.

### **Czcionki**

Aby tekst był renderowany z odpowiednimi czcionkami i metrykami, czcionki używane w Twoich prezentacjach lub odpowiednie zamienniki muszą być zainstalowane w systemie lub załadowane przez aplikację. Zobacz [Wdrażanie czcionek](/slides/pl/java/deploy-fonts/), [Zamiana czcionek](/slides/pl/java/font-substitution/) i [Czcionki niestandardowe](/slides/pl/java/custom-font/).

## **Sprawdź swoją konfigurację**

Aby zweryfikować, że biblioteka i jej wymagania są spełnione, uruchom program zapisujący prezentację i renderujący slajd do obrazu. Zapis i renderowanie korzystają ze wsparcia czcionek środowiska Java, które zapewniają opisane wyżej wymagania Linuksa.

Zapisz poniższy kod jako *CheckSetup.java* w folderze zawierającym plik JAR Aspose.Slides. Aby pobrać plik JAR, zobacz [Używanie pliku JAR bez Maven](/slides/pl/java/installation/#use-the-jar-file-without-maven).

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

            // Renderuj slajd w skali jeden piksel na punkt i zapisz obraz.
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

Z JDK 11 lub nowszym uruchom program w tym folderze przy pomocy poniższego polecenia. Jeśli plik JAR ma inną nazwę, zmień nazwę w poleceniach.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Z Java 8 lub w systemie posiadającym tylko JRE skompiluj program przy użyciu `javac` z JDK, a następnie uruchom skompilowaną klasę. W Linuksie i macOS uruchom:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

W Windows uruchom to samo polecenie `javac`, a potem klasę, używając średnika jako separatora ścieżki klas. Zachowaj cudzysłowy, aby PowerShell nie potraktował średnika jako zakończenia polecenia: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Program dodaje prostokąt z tekstem do pierwszego slajdu i zapisuje prezentację jako *hello.pptx* metodą [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Następnie renderuje slajd metodą [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) i zapisuje wynik jako *hello.png* przy użyciu [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) w formacie [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Czynniki skali 1 renderują po jednym pikselu na punkt, więc domyślny slajd 720 × 540 punktów staje się obrazem 720 × 540 pikseli, z widocznym tekstem w prostokącie. Bez licencji oba pliki zawierają znak wodny oceny; zobacz [Licencjonowanie](/slides/pl/java/licensing/). Jeśli brakuje któregokolwiek wymogu, program zatrzyma się jednym z błędów opisanych w [Linux](#linux).

## **Narzędzia deweloperskie**

Możesz budować aplikacje używające Aspose.Slides przy dowolnym JDK wspierającej wersji Javy. Używaj Apache Maven z repozytorium Maven Aspose, jak opisano w [Instalacja](/slides/pl/java/installation/), lub dowolnego innego narzędzia budującego obsługującego repozytorium Maven. Możesz także dodać plik JAR do ścieżki klas swojego IDE lub narzędzia budującego samodzielnie.

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany. Aspose.Slides to samodzielny silnik do [tworzenia](/slides/pl/java/create-presentation/), modyfikacji, [konwersji](/slides/pl/java/convert-presentation/) i [renderowania](/slides/pl/java/convert-powerpoint-to-png/) prezentacji.

**Czy Aspose.Slides for Java wymaga wyświetlacza lub środowiska graficznego na serwerze Linux?**

Nie. Aspose.Slides nie potrzebuje serwera X ani wyświetlacza, więc działa na serwerach i w kontenerach. W Linuksie potrzebna jest tylko biblioteka czcionek i czcionki opisane w [Linux](#linux).

**Jakie czcionki są potrzebne do poprawnego renderowania?**

Czcionki użyte w prezentacji lub odpowiednie [zamienniki](/slides/pl/java/font-substitution/) muszą być dostępne. W Linuksie i macOS zainstaluj pakiety czcionek wymagane przez Twoje prezentacje, aby uzyskać spójny rendering.

**Dlaczego niestandardowa czcionka jest renderowana jako zastępcza lub brakujący tekst w Linuksie?**

Jeśli plik czcionki ma niezgodne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek Linuksa (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje niewłaściwe rozpoznanie czcionki. Użycie wersji czcionki z poprawionymi rekordami tabeli nazw lub instalacja spójnego zamiennika rozwiązuje problem.