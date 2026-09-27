---
title: Installation
type: docs
weight: 70
url: /de/php-java/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides-Installation
- Windows
- Linux
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für PHP via Java unter Linux und Windows: richten Sie PHP, Java, Apache Tomcat und die PHP/Java Bridge ein, fügen Sie das Paket mit Composer hinzu und überprüfen Sie die Einrichtung mit einem kurzen Skript."
---
## **Übersicht**

Aspose.Slides for PHP via Java läuft in zwei Prozessen. Ihr PHP‑Skript verwendet PHP‑Klassen, die jeden Aufruf über die PHP/Java Bridge an Aspose.Slides weiterleiten, das unter Java in Apache Tomcat ausgeführt wird. Dieser Artikel erklärt, wie beide Seiten eingerichtet werden, das Paket mit Composer installiert und ein kurzes Skript ausgeführt wird, um die Installation zu überprüfen.

## **Voraussetzungen**

- **PHP 7.0 bis 8.3**, mit `allow_url_include = On` in `php.ini`. Ihre Skripte laden die Client‑Bibliothek der Bridge, `Java.inc`, von Tomcat über HTTP. Bei PHP 8.4 und höher beendet sich `Java.inc` mit dem Fehler "end() expects exactly 1 argument", sobald die PHP‑Erweiterung `xml` geladen ist, und die Windows‑Builds von PHP laden sie immer.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 oder höher.** Ein JRE reicht aus.
- **Apache Tomcat 9.** Die PHP/Java Bridge basiert auf der `javax.servlet`‑API, die Tomcat 10 und später nicht mehr bereitstellt, sodass die Bridge dort nicht startet.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, die neueste Version. Ihre Web‑Anwendung `JavaBridge.war` läuft in Tomcat.

Dieser Artikel führt Tomcat und Ihre PHP‑Skripte auf demselben Computer aus. Aspose.Slides öffnet und speichert Dateien innerhalb von Tomcat, daher muss jeder Pfad, den Ihre Skripte an es übergeben, dort gültig sein.

## **Installation unter Linux**

Diese Befehle installieren alles in Ihrem Home‑Verzeichnis auf Ubuntu 24.04. Auf anderen Distributionen installieren Sie die gleichen Pakete mit dem Paket‑Manager der Distribution.

1. Installieren Sie PHP, Composer, Java und die Download‑Tools und aktivieren Sie `allow_url_include` für die PHP‑Kommandozeile:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Laden Sie Apache Tomcat 9 und PHP/Java Bridge herunter, legen Sie die Bridge‑Datei `JavaBridge.war` in den Ordner `webapps` von Tomcat und starten Sie Tomcat. Tomcat entpackt die WAR‑Datei beim Start in `webapps/JavaBridge`:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Erstellen Sie einen Projektordner und installieren Sie Aspose.Slides for PHP via Java von [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Stoppen Sie Tomcat, kopieren Sie die Aspose.Slides‑JAR‑Datei aus dem Paket in den Ordner `WEB-INF/lib` der Bridge, ersetzen Sie die Bridge‑Datei `Java.inc` durch die PHP 8‑Version aus dem Paket und starten Sie Tomcat erneut:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/de/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/de/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Auf PHP 7 überspringen Sie den Ersatz von `Java.inc`. Tomcat benötigt ein paar Sekunden zum Starten und muss laufen, sobald Ihre Skripte Aspose.Slides verwenden.

## **Installation unter Windows**

1. Installieren Sie [PHP 8.3 für Windows](https://www.php.net/downloads.php?os=windows) und fügen Sie dessen Ordner der Umgebungsvariable `PATH` hinzu. Kopieren Sie `php.ini-production` nach `php.ini` im selben Ordner. In `php.ini` setzen Sie `allow_url_include = On` und entfernen das Kommentarzeichen bei den Zeilen `extension_dir = "ext"`, `extension=openssl` und `extension=zip`. Composer benötigt `openssl`, um Pakete herunterzuladen, und `zip`, um sie zu entpacken, sofern nicht 7‑Zip installiert ist oder ein `unzip`‑Befehl im `PATH` steht.
2. Installieren Sie [Composer](https://getcomposer.org/download/).
3. Installieren Sie Java und setzen Sie die Umgebungsvariable `JAVA_HOME` auf dessen Ordner. Ohne diese startet Tomcat nicht.
4. Laden Sie im Eingabeaufforderungsfenster Apache Tomcat 9 und PHP/Java Bridge herunter, legen Sie die Bridge‑Datei `JavaBridge.war` in den Ordner `webapps` von Tomcat und starten Sie Tomcat. Tomcat‑Skripte finden Tomcat über die Variable `CATALINA_HOME`, daher verwenden Sie das gleiche Eingabeaufforderungsfenster für die nächsten Schritte. Tomcat entpackt die WAR‑Datei beim Start in `webapps\JavaBridge`:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Erstellen Sie einen Projektordner und installieren Sie Aspose.Slides for PHP via Java von [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Stoppen Sie Tomcat, kopieren Sie die Aspose.Slides‑JAR‑Datei aus dem Paket in den Ordner `WEB-INF\lib` der Bridge, ersetzen Sie die Bridge‑Datei `Java.inc` durch die PHP 8‑Version aus dem Paket und starten Sie Tomcat erneut:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Auf PHP 7 überspringen Sie den Ersatz von `Java.inc`. Tomcat benötigt ein paar Sekunden zum Starten und muss laufen, sobald Ihre Skripte Aspose.Slides verwenden.

## **Installation überprüfen**

Speichern Sie dieses Skript als *hello.php* im Projektordner. Es erstellt eine Präsentation mit einer Textbox und speichert sie neben dem Skript:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/de/lib/aspose.slides.php");

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

Führen Sie es im Projektordner aus:

```bash
php hello.php
```

Das Skript erzeugt *hello.pptx* mit einer Folie, die die Textbox enthält. Ohne Lizenz enthält die Folie zudem ein Evaluations‑Wasserzeichen; siehe [Licensing](/slides/de/php-java/licensing/).

Das Skript bindet `aspose.slides.php` direkt ein: Der Autoloader von Composer kann diese Klassen nicht laden, weil sie alle in dieser einen Datei definiert sind. Außerdem wird ein absoluter Pfad an `save` übergeben, weil Aspose.Slides innerhalb von Tomcat läuft und einen relativen Pfad relativ zum Arbeitsverzeichnis von Tomcat, nicht zu Ihrem Skript, auflöst.

## **FAQ**

**Wie kann ich überprüfen, ob Aspose.Slides korrekt integriert ist?**

Führen Sie das Skript unter [Installation überprüfen](#installation-überprüfen) aus. Wenn *hello.pptx* ohne Fehler geschrieben wird, funktionieren PHP, PHP/Java Bridge und Aspose.Slides zusammen.

**Warum stoppt mein Skript mit "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP konnte `Java.inc` nicht von Tomcat laden. Wenn die Meldung davor besagt, dass der `http://`‑Wrapper deaktiviert ist, setzen Sie `allow_url_include = On` in der `php.ini`, die Ihre PHP‑Kommandozeile lädt; `php --ini` zeigt, welche Datei das ist. Wenn die Meldung "Connection refused" lautet, läuft Tomcat noch nicht: starten Sie ihn oder warten Sie ein paar Sekunden, bis er gestartet ist.

**Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?**

Erhöhen Sie die JVM‑Speichergrenzen nur so weit, wie nötig, und schließen Sie jede [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz in einem `finally`‑Block, um den Cache sofort freizugeben. Das verhindert Out‑of‑Memory‑Fehler und hält den Gesamtspeicherverbrauch bei Batch‑Operationen vorhersehbar.

**Kann ich unerwünschte Exportformate ausschließen, um die finale JAR‑Größe zu verkleinern?**

Aktuelle Aspose.Slides‑Versionen werden als einzelne monolithische Bibliothek ausgeliefert, sodass Sie bestimmte Exporter wie PDF oder SVG nicht zur Buildzeit deaktivieren können.