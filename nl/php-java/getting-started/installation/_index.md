---
title: Installatie
type: docs
weight: 70
url: /nl/php-java/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Installeer Aspose.Slides voor PHP via Java op Linux en Windows: configureer PHP, Java, Apache Tomcat en PHP/Java Bridge, voeg het pakket toe met Composer en controleer de installatie met een kort script."
---
## **Overzicht**

Aspose.Slides voor PHP via Java draait in twee processen. Uw PHP‑script gebruikt PHP‑klassen die elke oproep via de PHP/Java Bridge naar Aspose.Slides sturen, dat op Java draait binnen Apache Tomcat. Dit artikel legt uit hoe beide zijden in te stellen, het pakket met Composer te installeren en een kort script uit te voeren om de installatie te verifiëren.

## **Voorvereisten**

- **PHP 7.0 tot en met 8.3**, met `allow_url_include = On` in `php.ini`. Uw scripts laden de client‑bibliotheek van de bridge, `Java.inc`, van Tomcat via HTTP. Op PHP 8.4 en hoger stopt `Java.inc` met de fout "end() expects exactly 1 argument" zodra de PHP‑extensie `xml` geladen is, en de Windows‑builds van PHP laden deze altijd.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 of later.** Een JRE volstaat.
- **Apache Tomcat 9.** De PHP/Java Bridge is gebouwd op de `javax.servlet`‑API, die door Tomcat 10 en hoger niet meer wordt geleverd, waardoor de bridge daar niet start.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, de nieuwste release. Zijn webapplicatie, `JavaBridge.war`, draait in Tomcat.

Dit artikel draait Tomcat en uw PHP‑scripts op dezelfde computer. Aspose.Slides opent en slaat bestanden op binnen Tomcat, dus elk pad dat uw scripts eraan doorgeven moet daar geldig zijn.

## **Installeren op Linux**

Deze commando's installeren alles in uw thuismap op Ubuntu 24.04. Op andere distributies installeert u dezelfde pakketten met de pakketbeheerder van de distributie.

1. Installeer PHP, Composer, Java en de download‑hulpmiddelen, en schakel vervolgens `allow_url_include` in voor de PHP‑opdrachtregel:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Download Apache Tomcat 9 en PHP/Java Bridge, plaats de `JavaBridge.war` van de bridge in de map `webapps` van Tomcat, en start Tomcat. Tomcat pakt het WAR‑bestand uit naar `webapps/JavaBridge` bij het starten:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Maak een projectmap aan en installeer Aspose.Slides voor PHP via Java vanaf [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Stop Tomcat, kopieer het Aspose.Slides‑JAR‑bestand uit het pakket naar de map `WEB-INF/lib` van de bridge, vervang de `Java.inc` van de bridge door de PHP 8‑versie uit het pakket, en start Tomcat opnieuw:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/nl/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/nl/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Op PHP 7 slaat u de vervanging van `Java.inc` over. Tomcat heeft enkele seconden nodig om te starten, en moet draaien telkens wanneer uw scripts Aspose.Slides gebruiken.

## **Installeren op Windows**

1. Installeer [PHP 8.3 voor Windows](https://www.php.net/downloads.php?os=windows) en voeg de map toe aan de omgevingsvariabele `PATH`. Kopieer `php.ini-production` naar `php.ini` in dezelfde map. In `php.ini` zet u `allow_url_include = On` en haalt u de commentaartekens weg bij de regels `extension_dir = "ext"`, `extension=openssl` en `extension=zip`. Composer heeft `openssl` nodig om pakketten te downloaden, en `zip` om ze uit te pakken, tenzij 7‑Zip geïnstalleerd is of een `unzip`‑commando in `PATH` staat.
2. Installeer [Composer](https://getcomposer.org/download/).
3. Installeer Java en stel de omgevingsvariabele `JAVA_HOME` in op de map ervan. Tomcat start niet zonder deze variabele.
4. In de opdrachtprompt downloadt u Apache Tomcat 9 en PHP/Java Bridge, plaatst u de `JavaBridge.war` van de bridge in de map `webapps` van Tomcat, en start u Tomcat. De scripts van Tomcat vinden Tomcat via de variabele `CATALINA_HOME`, dus blijf dezelfde opdrachtprompt‑venster gebruiken voor de volgende stappen. Tomcat pakt het WAR‑bestand uit naar `webapps\JavaBridge` bij het starten:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_5.2.1/php-java-bridge_5.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Maak een projectmap aan en installeer Aspose.Slides voor PHP via Java vanaf [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Stop Tomcat, kopieer het Aspose.Slides‑JAR‑bestand uit het pakket naar de map `WEB-INF\lib` van de bridge, vervang de `Java.inc` van de bridge door de PHP 8‑versie uit het pakket, en start Tomcat opnieuw:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Op PHP 7 slaat u de vervanging van `Java.inc` over. Tomcat heeft enkele seconden nodig om te starten, en moet draaien telkens wanneer uw scripts Aspose.Slides gebruiken.

## **Controleer de installatie**

Sla dit script op als *hello.php* in de projectmap. Het maakt een presentatie met één tekstvak aan en slaat deze naast het script op:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/nl/lib/aspose.slides.php");

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

Voer het uit vanuit de projectmap:

```bash
php hello.php
```

Het script schrijft *hello.pptx*, met één dia die het tekstvak bevat. Zonder licentie bevat de dia ook een evaluatiewatermerk; zie [Licensing](/slides/nl/php-java/licensing/).

Het script include `aspose.slides.php` direct: de autoloader van Composer kan deze klassen niet laden, omdat ze allemaal gedefinieerd zijn in dat ene bestand. Het geeft ook een absoluut pad door aan `save`, omdat Aspose.Slides binnen Tomcat draait en een relatief pad resolveert ten opzichte van de werkmap van Tomcat, niet die van uw script.

## **Veelgestelde vragen**

**Hoe kan ik controleren of Aspose.Slides correct is geïntegreerd?**

Voer het script uit in [Controleer de installatie](#verify-the-installation). Als het *hello.pptx* schrijft zonder fouten, werken PHP, PHP/Java Bridge en Aspose.Slides samen.

**Waarom stopt mijn script met “Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"’?**

PHP kon `Java.inc` niet laden vanaf Tomcat. Als het bericht ervoor aangeeft dat de `http://`‑wrapper uitgeschakeld is, zet dan `allow_url_include = On` in het `php.ini`‑bestand dat door uw PHP‑opdrachtregel wordt geladen; `php --ini` toont welk bestand dat is. Als er "Connection refused" staat, draait Tomcat nog niet: start het, of wacht enkele seconden totdat het is opgestart.

**Hoe kan ik het geheugenverbruik beperken bij het verwerken van grote presentaties?**

Verhoog de JVM‑geheugenlimieten alleen tot het noodzakelijke, en sluit elke [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie in een `finally`‑blok om de cache onmiddellijk vrij te geven. Dit voorkomt out‑of‑memory‑fouten en houdt het totale geheugenverbruik voorspelbaar tijdens batch‑operaties.

**Kan ik ongewenste exportformaten uitsluiten om de uiteindelijke JAR‑grootte te verkleinen?**

Huidige Aspose.Slides‑releases worden geleverd als één monolithische bibliotheek, dus u kunt specifieke exporters zoals PDF of SVG niet uitschakelen tijdens het bouwen.