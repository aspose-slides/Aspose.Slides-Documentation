---
title: Instalacja
type: docs
weight: 70
url: /pl/php-java/installation/
keywords:
- instalowanie Aspose.Slides
- pobieranie Aspose.Slides
- używanie Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zainstaluj Aspose.Slides for PHP via Java na systemach Linux i Windows: skonfiguruj PHP, Javę, Apache Tomcat i PHP/Java Bridge, dodaj pakiet za pomocą Composer i zweryfikuj konfigurację krótkim skryptem."
---
## **Przegląd**

Aspose.Slides for PHP via Java działa w dwóch procesach. Twój skrypt PHP używa klas PHP, które przekazują każde wywołanie przez PHP/Java Bridge do Aspose.Slides, które działa na Javie w Apache Tomcat. Ten artykuł wyjaśnia, jak skonfigurować obie strony, zainstalować pakiet przy pomocy Composer i uruchomić krótki skrypt w celu weryfikacji instalacji.

## **Wymagania wstępne**

- **PHP 7.0 do 8.3**, z `allow_url_include = On` w `php.ini`. Twoje skrypty ładują bibliotekę kliencką mostu `Java.inc` z Tomcata przez HTTP. W PHP 8.4 i nowszych `Java.inc` przestaje działać z błędem "end() expects exactly 1 argument", gdy załadowane jest rozszerzenie `xml` PHP, a wersje Windows PHP zawsze je ładują.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 lub późniejsza.** Wystarczy JRE.
- **Apache Tomcat 9.** PHP/Java Bridge jest zbudowany na API `javax.servlet`, którego Tomcat 10 i nowsze już nie zapewniają, więc most nie uruchamia się na nich.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, najnowsze wydanie. Jego aplikacja webowa `JavaBridge.war` działa w Tomcat.

Ten artykuł uruchamia Tomcat i Twoje skrypty PHP na tym samym komputerze. Aspose.Slides otwiera i zapisuje pliki wewnątrz Tomcata, więc każda ścieżka przekazywana przez Twoje skrypty musi być tam prawidłowa.

## **Instalacja w systemie Linux**

Poniższe polecenia instalują wszystko w Twoim katalogu domowym na Ubuntu 24.04. Na innych dystrybucjach zainstaluj te same pakiety przy użyciu menedżera pakietów danej dystrybucji.

1. Zainstaluj PHP, Composer, Javę i narzędzia pobierania, a następnie włącz `allow_url_include` dla wiersza poleceń PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Pobierz Apache Tomcat 9 i PHP/Java Bridge, umieść plik `JavaBridge.war` mostu w katalogu `webapps` Tomcata i uruchom Tomcat. Tomcat rozpakowuje plik WAR do `webapps/JavaBridge` podczas uruchamiania:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Utwórz katalog projektu i zainstaluj Aspose.Slides for PHP via Java z [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Zatrzymaj Tomcat, skopiuj plik JAR Aspose.Slides z pakietu do katalogu `WEB-INF/lib` mostu, zamień `Java.inc` mostu na wersję PHP 8 z pakietu i uruchom Tomcat ponownie:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/pl/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/pl/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   W PHP 7 pomiń zamianę `Java.inc`. Tomcat potrzebuje kilka sekund na uruchomienie i musi być uruchomiony za każdym razem, gdy Twoje skrypty używają Aspose.Slides.

## **Instalacja w systemie Windows**

1. Zainstaluj [PHP 8.3 dla Windows](https://www.php.net/downloads.php?os=windows) i dodaj jego folder do zmiennej środowiskowej `PATH`. Skopiuj `php.ini-production` do `php.ini` w tym samym folderze. W `php.ini` ustaw `allow_url_include = On` oraz odkomentuj linie `extension_dir = "ext"`, `extension=openssl` i `extension=zip`. Composer potrzebuje `openssl` do pobierania pakietów i `zip` do ich rozpakowywania, chyba że zainstalowano 7‑Zip lub dostępna jest komenda `unzip` w `PATH`.
2. Zainstaluj [Composer](https://getcomposer.org/download/).
3. Zainstaluj Javę i ustaw zmienną środowiskową `JAVA_HOME` na jej katalog. Tomcat nie uruchomi się bez niej.
4. W wierszu poleceń pobierz Apache Tomcat 9 i PHP/Java Bridge, umieść plik `JavaBridge.war` mostu w katalogu `webapps` Tomcata i uruchom Tomcat. Skrypty Tomcata znajdują Tomcat poprzez zmienną `CATALINA_HOME`, więc używaj tego samego okna wiersza poleceń w kolejnych krokach. Tomcat rozpakowuje plik WAR do `webapps\JavaBridge` podczas uruchamiania:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Utwórz katalog projektu i zainstaluj Aspose.Slides for PHP via Java z [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Zatrzymaj Tomcat, skopiuj plik JAR Aspose.Slides z pakietu do katalogu `WEB-INF\lib` mostu, zamień `Java.inc` mostu na wersję PHP 8 z pakietu i uruchom Tomcat ponownie:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   W PHP 7 pomiń zamianę `Java.inc`. Tomcat potrzebuje kilka sekund na uruchomienie i musi być uruchomiony za każdym razem, gdy Twoje skrypty używają Aspose.Slides.

## **Weryfikacja instalacji**

Zapisz ten skrypt jako *hello.php* w katalogu projektu. Tworzy on prezentację z jednym polem tekstowym i zapisuje ją obok skryptu:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pl/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uruchom go z katalogu projektu:

```bash
php hello.php
```

Skrypt zapisuje *hello.pptx* z jedną slajdem zawierającym pole tekstowe. Bez licencji slajd zawiera znak wodny oceny; zobacz [Licencjonowanie](/slides/pl/php-java/licensing/).

Skrypt ładuje `aspose.slides.php` bezpośrednio: autoloader Composer nie może załadować tych klas, ponieważ wszystkie są zdefiniowane w jednym pliku. Przekazuje on także ścieżkę bezwzględną do `save`, ponieważ Aspose.Slides działa w Tomcat i rozwiązuje ścieżkę względną względem katalogu roboczego Tomcata, a nie Twojego skryptu.

## **FAQ**

**Jak mogę zweryfikować, czy Aspose.Slides jest poprawnie zintegrowany?**

Uruchom skrypt w [Zweryfikuj instalację](#verify-the-installation). Jeśli zapisze *hello.pptx* bez błędów, PHP, PHP/Java Bridge i Aspose.Slides działają razem.

**Dlaczego mój skrypt przerywa z komunikatem "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP nie mógł załadować `Java.inc` z Tomcata. Jeśli poprzednia wiadomość mówi, że wrapper `http://` jest wyłączony, ustaw `allow_url_include = On` w pliku `php.ini`, który jest ładowany przez Twoją linię poleceń PHP; `php --ini` pokaże, który to plik. Jeśli pojawia się "Connection refused", Tomcat jeszcze nie działa: uruchom go lub poczekaj kilka sekund, aż się uruchomi.

**Jak mogę ograniczyć zużycie pamięci przy przetwarzaniu dużych prezentacji?**

Podnoś limity pamięci JVM tylko tak wysoko, jak jest to potrzebne, i zamykaj każdą instancję [Prezentacji](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w bloku `finally`, aby szybko zwolnić pamięć podręczną. Zapobiega to błędom „out‑of‑memory” i utrzymuje przewidywalne zużycie pamięci podczas operacji wsadowych.

**Czy mogę wykluczyć niepotrzebne formaty eksportu, aby zmniejszyć ostateczny rozmiar JAR?**

Obecne wydania Aspose.Slides są dystrybuowane jako jedna monolityczna biblioteka, więc nie możesz wyłączyć konkretnych eksporterów, takich jak PDF czy SVG, w czasie budowania.