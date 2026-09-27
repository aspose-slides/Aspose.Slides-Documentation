---
title: Installation
type: docs
weight: 70
url: /sv/php-java/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- installation av Aspose.Slides
- Windows
- Linux
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Installera Aspose.Slides för PHP via Java på Linux och Windows: konfigurera PHP, Java, Apache Tomcat och PHP/Java Bridge, lägg till paketet med Composer och verifiera installationen med ett kort skript."
---
## **Översikt**

Aspose.Slides för PHP via Java körs i två processer. Ditt PHP‑script använder PHP‑klasser som skickar varje anrop via PHP/Java Bridge till Aspose.Slides, som körs på Java inne i Apache Tomcat. Denna artikel förklarar hur du konfigurerar båda sidorna, installerar paketet med Composer och kör ett kort skript för att verifiera installationen.

## **Förutsättningar**

- **PHP 7.0 to 8.3**, med `allow_url_include = On` i `php.ini`. Dina skript laddar broens klientbibliotek, `Java.inc`, från Tomcat via HTTP. På PHP 8.4 och senare avbryter `Java.inc` med felet ”end() expects exactly 1 argument” när PHP:s `xml`‑tillägg är laddat, och Windows‑byggnader av PHP laddar det alltid.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 or later.** En JRE räcker.
- **Apache Tomcat 9.** PHP/Java Bridge är byggt på `javax.servlet`‑API‑et, som Tomcat 10 och senare inte längre tillhandahåller, så bron startar inte där.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, den senaste releasen. Dess webbapplikation, `JavaBridge.war`, körs i Tomcat.

Denna artikel kör Tomcat och dina PHP‑skript på samma dator. Aspose.Slides öppnar och sparar filer inuti Tomcat, så varje sökväg som dina skript skickar till den måste vara giltig där.

## **Installera på Linux**

1. Installera PHP, Composer, Java och nedladdningsverktygen, och sätt sedan på `allow_url_include` för PHP‑kommandoraden:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Hämta Apache Tomcat 9 och PHP/Java Bridge, placera broens `JavaBridge.war` i Tomcats `webapps`‑mapp och starta Tomcat. Tomcat packar upp WAR‑filen till `webapps/JavaBridge` när den startas:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Skapa en projektmapp och installera Aspose.Slides for PHP via Java från [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Stoppa Tomcat, kopiera Aspose.Slides‑JAR‑filen från paketet till broens `WEB-INF/lib`‑mapp, ersätt broens `Java.inc` med PHP 8‑versionen från paketet och starta Tomcat igen:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/sv/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/sv/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   På PHP 7 hoppar du över ersättningen av `Java.inc`. Tomcat tar några sekunder att starta och måste vara igång när dina skript använder Aspose.Slides.

## **Installera på Windows**

1. Installera [PHP 8.3 för Windows](https://www.php.net/downloads.php?os=windows) och lägg till dess katalog i `PATH`‑miljövariabeln. Kopiera `php.ini-production` till `php.ini` i samma katalog. I `php.ini`, sätt `allow_url_include = On` och avkommentera raderna `extension_dir = "ext"`, `extension=openssl` och `extension=zip`. Composer behöver `openssl` för att hämta paket och `zip` för att packa upp dem, såvida inte 7‑Zip är installerat eller ett `unzip`‑kommando finns i `PATH`.
2. Installera [Composer](https://getcomposer.org/download/).
3. Installera Java och sätt `JAVA_HOME`‑miljövariabeln till dess katalog. Tomcat startar inte utan den.
4. I Kommandotolken, hämta Apache Tomcat 9 och PHP/Java Bridge, placera broens `JavaBridge.war` i Tomcats `webapps`‑mapp och starta Tomcat. Tomcats skript hittar Tomcat via variabeln `CATALINA_HOME`, så fortsätt använda samma Kommandotolks‑fönster för nästa steg. Tomcat packar upp WAR‑filen till `webapps\JavaBridge` när den startas:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Skapa en projektmapp och installera Aspose.Slides for PHP via Java från [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Stoppa Tomcat, kopiera Aspose.Slides‑JAR‑filen från paketet till broens `WEB-INF\lib`‑mapp, ersätt broens `Java.inc` med PHP 8‑versionen från paketet och starta Tomcat igen:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   På PHP 7 hoppar du över ersättningen av `Java.inc`. Tomcat tar några sekunder att starta och måste vara igång när dina skript använder Aspose.Slides.

## **Verifiera installationen**

Spara detta skript som *hello.php* i projektmappen. Det skapar en presentation med en textruta och sparar den bredvid skriptet:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

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

Kör det från projektmappen:

```bash
php hello.php
```

Skriptet skriver *hello.pptx*, med en bild som innehåller textrutan. Utan licens visas dessutom en utvärderingsvattenstämpel; se [Licensing](/slides/sv/php-java/licensing/).

Skriptet inkluderar `aspose.slides.php` direkt: Composers autoloader kan inte ladda dessa klasser, eftersom de alla definieras i den en enda filen. Det skickar även en absolut sökväg till `save`, eftersom Aspose.Slides körs inne i Tomcat och löser en relativ sökväg mot Tomcats arbetskatalog, inte ditt skripts.

## **FAQ**

**Hur kan jag verifiera att Aspose.Slides är korrekt integrerat?**

Kör skriptet i [Verifiera installationen](#verify-the-installation). Om det skriver *hello.pptx* utan fel, fungerar PHP, PHP/Java Bridge och Aspose.Slides ihop.

**Varför stoppar mitt skript med ”Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'”?**

PHP kunde inte läsa in `Java.inc` från Tomcat. Om meddelandet före detta säger att `http://`‑omslaget är inaktiverat, sätt `allow_url_include = On` i den `php.ini`‑fil som ditt PHP‑kommandorad använder; `php --ini` visar vilken fil det är. Om det står ”Connection refused”, är Tomcat ännu inte igång: starta den eller vänta några sekunder tills den har startat.

**Hur kan jag begränsa minnesförbrukningen när jag bearbetar stora presentationer?**

Öka JVM‑minnesgränsen bara så mycket som behövs, och stäng varje [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans i ett `finally`‑block för att snabbt frigöra cachen. Detta förhindrar out‑of‑memory‑fel och håller den totala minnesanvändningen förutsägbar under batch‑operationer.

**Kan jag utesluta oönskade exportformat för att minska den slutgiltiga JAR‑storleken?**

Aktuella Aspose.Slides‑releaser levereras som ett enda monolitiskt bibliotek, så du kan inte inaktivera specifika exporterare som PDF eller SVG vid byggtiden.