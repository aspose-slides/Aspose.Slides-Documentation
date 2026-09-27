---
title: Instalační
type: docs
weight: 70
url: /cs/php-java/installation/
keywords:
- instalace Aspose.Slides
- stažení Aspose.Slides
- použití Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Nainstalujte Aspose.Slides pro PHP via Java na Linuxu a Windows: nastavte PHP, Javu, Apache Tomcat a PHP/Java Bridge, přidejte balíček pomocí Composeru a ověřte nastavení pomocí krátkého skriptu."
---
## **Přehled**

Aspose.Slides for PHP via Java běží ve dvou procesech. Váš PHP skript používá třídy PHP, které předávají každý volání přes PHP/Java Bridge do Aspose.Slides, který běží na Javě uvnitř Apache Tomcat. Tento článek vysvětluje, jak nastavit obě strany, nainstalovat balíček pomocí Composeru a spustit krátký skript pro ověření instalace.

## **Požadavky**

- **PHP 7.0 až 8.3**, s `allow_url_include = On` v `php.ini`. Vaše skripty načítají klientskou knihovnu mostu `Java.inc` z Tomcatu přes HTTP. Na PHP 8.4 a novějším `Java.inc` končí chybou "end() expects exactly 1 argument", pokud je načtena rozšíření PHP `xml`, a Windows verze PHP ji vždy načtou.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 nebo novější.** JRE stačí.
- **Apache Tomcat 9.** PHP/Java Bridge je postaven na API `javax.servlet`, které Tomcat 10 a novější již neposkytuje, takže most zde nezačne.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, jeho nejnovější vydání. Jeho webová aplikace `JavaBridge.war` běží v Tomcatu.

Tento článek spouští Tomcat i vaše PHP skripty na stejném počítači. Aspose.Slides otevírá a ukládá soubory uvnitř Tomcatu, takže každá cesta, kterou mu vaše skripty předají, musí být v něm platná.

## **Instalace na Linuxu**

Tyto příkazy nainstalují vše do vašeho domovského adresáře na Ubuntu 24.04. Na jiných distribucích nainstalujte stejné balíčky pomocí správce balíčků distribuce.

1. Nainstalujte PHP, Composer, Javu a nástroje pro stahování, poté zapněte `allow_url_include` pro PHP příkazovou řádku:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
```

2. Stáhněte Apache Tomcat 9 a PHP/Java Bridge, vložte `JavaBridge.war` mostu do složky `webapps` Tomcatu a spusťte Tomcat. Tomcat rozbalí soubor WAR do `webapps/JavaBridge` při spuštění:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Vytvořte složku projektu a nainstalujte Aspose.Slides for PHP via Java z [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Zastavte Tomcat, zkopírujte JAR soubor Aspose.Slides z balíčku do složky `WEB-INF/lib` mostu, nahraďte `Java.inc` mostu verzí pro PHP 8 z balíčku a spusťte Tomcat znovu:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/cs/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/cs/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Na PHP 7 vynechejte nahrazení `Java.inc`. Tomcat potřebuje několik sekund na spuštění a musí běžet, kdykoli vaše skripty používají Aspose.Slides.

## **Instalace ve Windows**

1. Nainstalujte [PHP 8.3 pro Windows](https://www.php.net/downloads.php?os=windows) a přidejte jeho složku do proměnné prostředí `PATH`. Zkopírujte `php.ini-production` do `php.ini` ve stejné složce. V `php.ini` nastavte `allow_url_include = On` a odkomentujte řádky `extension_dir = "ext"`, `extension=openssl` a `extension=zip`. Composer potřebuje `openssl` pro stahování balíčků a `zip` pro jejich rozbalení, pokud není nainstalován 7‑Zip nebo není příkaz `unzip` v `PATH`.

2. Nainstalujte [Composer](https://getcomposer.org/download/).

3. Nainstalujte Javu a nastavte proměnnou prostředí `JAVA_HOME` na její složku. Tomcat bez ní nespustí.

4. V příkazovém řádku stáhněte Apache Tomcat 9 a PHP/Java Bridge, vložte `JavaBridge.war` mostu do složky `webapps` Tomcatu a spusťte Tomcat. Skripty Tomcatu najdou Tomcat přes proměnnou `CATALINA_HOME`, takže pro následující kroky používejte stejné okno příkazového řádku. Tomcat rozbalí soubor WAR do `webapps\JavaBridge` při spuštění:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_5.0.0/php-java-bridge_5.0.0_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Vytvořte složku projektu a nainstalujte Aspose.Slides for PHP via Java z [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Zastavte Tomcat, zkopírujte JAR soubor Aspose.Slides z balíčku do složky `WEB-INF\lib` mostu, nahraďte `Java.inc` mostu verzí pro PHP 8 z balíčku a spusťte Tomcat znovu:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Na PHP 7 vynechejte nahrazení `Java.inc`. Tomcat potřebuje několik sekund na spuštění a musí běžet, kdykoli vaše skripty používají Aspose.Slides.

## **Ověření instalace**

Uložte tento skript jako *hello.php* do složky projektu. Vytvoří prezentaci s jedním textovým polem a uloží ji vedle skriptu:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

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

Spusťte jej ze složky projektu:

```bash
php hello.php
```

Skript vytvoří *hello.pptx* s jedním snímkem, který obsahuje textové pole. Bez licence snímek také nese vodoznak hodnocení; viz [Licensing](/slides/cs/php-java/licensing/).

Skript zahrnuje `aspose.slides.php` přímo: Autoloader Composeru nemůže načíst tyto třídy, protože jsou všechny definovány v tomto jediném souboru. Také předává absolutní cestu do `save`, protože Aspose.Slides běží uvnitř Tomcatu a relativní cestu vyhodnocuje vůči pracovní složce Tomcatu, ne vůči vašemu skriptu.

## **Často kladené otázky**

**Jak mohu ověřit, že je Aspose.Slides správně integrován?**

Spusťte skript v [Ověření instalace](#verify-the-installation). Pokud vytvoří *hello.pptx* bez chyb, PHP, PHP/Java Bridge a Aspose.Slides spolupracují správně.

**Proč se můj skript zastaví s chybou "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP se nepodařilo načíst `Java.inc` z Tomcatu. Pokud před tímto hlášením stojí, že je zakázán `http://` wrapper, nastavte `allow_url_include = On` v souboru `php.ini`, který načítá vaše PHP z příkazové řádky; `php --ini` ukáže, který soubor to je. Pokud se zobrazí "Connection refused", Tomcat ještě neběží: spusťte jej nebo počkejte několik sekund, dokud se nespustí.

**Jak mohu omezit spotřebu paměti při zpracování velkých prezentací?**

Zvyšte limity paměti JVM jen tak, jak jsou potřeba, a uzavřete každou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) v bloku `finally`, aby se cache uvolnila okamžitě. Tím se předejde chybám nedostatku paměti a celková spotřeba paměti zůstane předvídatelná během dávkových operací.

**Mohu vyloučit nechtěné exportní formáty a tím zmenšit konečnou velikost JAR?**

Aktuální vydání Aspose.Slides jsou dodávána jako jediná monolitická knihovna, takže nelze při sestavování zakázat konkrétní exportéry jako PDF nebo SVG.