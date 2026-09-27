---
title: Telepítés
type: docs
weight: 70
url: /hu/php-java/installation/
keywords:
- Aspose.Slides telepítése
- Aspose.Slides letöltése
- Aspose.Slides használata
- Aspose.Slides telepítése
- Windows
- Linux
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP via Java telepítése Linuxra és Windowsra: PHP, Java, Apache Tomcat és PHP/Java Bridge beállítása, a csomag hozzáadása Composerrel, és a beállítás ellenőrzése egy rövid szkripttel."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java két folyamatban fut. A PHP szkriptje PHP osztályokat használ, amelyek minden hívást a PHP/Java Bridge-en keresztül az Aspose.Slides-nek továbbítanak, amely Java alatt fut az Apache Tomcaton belül. Ez a cikk elmagyarázza, hogyan állítsa be mindkét oldalt, hogyan telepítse a csomagot a Composerrel, és hogyan futtasson egy rövid szkriptet a telepítés ellenőrzéséhez.

## **Előfeltételek**

- **PHP 7.0‑tól 8.3‑ig**, `allow_url_include = On` beállítással a `php.ini`‑ban. A szkriptek a bridge klienskönyvtárát, a `Java.inc`‑t töltik be a Tomcat‑ról HTTP‑n keresztül. PHP 8.4‑től és újabb verzióknál a `Java.inc` leáll a “end() expects exactly 1 argument” hibaüzenettel, ha a PHP `xml` kiterjesztése be van töltve, és a Windows‑os PHP‑k mindig betöltik azt.
- **[Composer](https://getcomposer.org/)**
- **Java 8 vagy újabb.** A JRE elegendő.
- **Apache Tomcat 9.** A PHP/Java Bridge a `javax.servlet` API-ra épül, amelyet a Tomcat 10 és újabb verziók már nem biztosítanak, ezért a bridge ott nem indul el.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, a legújabb kiadás. A webalkalmazása, a `JavaBridge.war`, a Tomcatban fut.

Ez a cikk a Tomcatot és a PHP szkripteket ugyanazon a számítógépen futtatja. Az Aspose.Slides a Tomcaton belül nyit és ment fájlokat, ezért minden útvonalnak, amelyet a szkriptek átadnak neki, érvényesnek kell lennie ott.

## **Telepítés Linuxon**

Ezek a parancsok mindent a saját home könyvtárába telepítenek Ubuntu 24.04-en. Más disztribúciókon a csomagok telepítése a disztribúció csomagkezelőjével történik.

1. Telepítse a PHP‑t, a Composer‑t, a Javat és a letöltő eszközöket, majd kapcsolja be az `allow_url_include` beállítást a PHP parancssorhoz:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Töltse le az Apache Tomcat 9‑et és a PHP/Java Bridge‑et, helyezze a bridge `JavaBridge.war` fájlját a Tomcat `webapps` mappájába, és indítsa el a Tomcatot. A Tomcat a WAR fájlt a `webapps/JavaBridge` mappába csomagolja ki indításkor:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Hozzon létre egy projekt mappát, és telepítse az Aspose.Slides for PHP via Java‑t a [Packagist](https://packagist.org/packages/aspose/slides) oldalról:

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Állítsa le a Tomcatot, másolja az Aspose.Slides JAR fájlt a csomagból a bridge `WEB-INF/lib` mappájába, cserélje le a bridge `Java.inc` fájlját a csomag PHP 8 verziójára, majd indítsa újra a Tomcatot:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/hu/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/hu/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   PHP 7‑nél hagyja ki a `Java.inc` cseréjét. A Tomcat néhány másodperc alatt elindul, és futnia kell, amikor a szkriptek az Aspose.Slides‑t használják.

## **Telepítés Windowson**

1. Telepítse a [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) verziót, és adja hozzá a mappáját a `PATH` környezeti változóhoz. Másolja a `php.ini-production` fájlt `php.ini`‑ra ugyanabban a mappában. A `php.ini`‑ban állítsa be az `allow_url_include = On` értéket, és kommentálja ki a `extension_dir = "ext"`, `extension=openssl` és `extension=zip` sorokat. A Composernek szüksége van az `openssl`‑re a csomagok letöltéséhez, valamint a `zip`‑re a kicsomagoláshoz, hacsak nincs telepítve 7‑Zip vagy nincs `unzip` parancs a `PATH`‑ban.
2. Telepítse a [Composer](https://getcomposer.org/download/)‑t.
3. Telepítse a Javat, és állítsa be a `JAVA_HOME` környezeti változót a telepítési mappájára. A Tomcat enélkül nem indul el.
4. A Parancssorban töltse le az Apache Tomcat 9‑et és a PHP/Java Bridge‑et, helyezze a bridge `JavaBridge.war` fájlját a Tomcat `webapps` mappájába, és indítsa el a Tomcatot. A Tomcat szkriptek a `CATALINA_HOME` változón keresztül találják meg a Tomcatot, ezért a következő lépésekhez használja ugyanazt a Parancssor ablakot. A Tomcat a WAR fájlt a `webapps\JavaBridge` mappába csomagolja ki indításkor:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Hozzon létre egy projekt mappát, és telepítse az Aspose.Slides for PHP via Java‑t a [Packagist](https://packagist.org/packages/aspose/slides) oldalról:

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Állítsa le a Tomcatot, másolja az Aspose.Slides JAR fájlt a csomagból a bridge `WEB-INF\lib` mappájába, cserélje le a bridge `Java.inc` fájlját a csomag PHP 8 verziójára, majd indítsa újra a Tomcatot:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   PHP 7‑nél hagyja ki a `Java.inc` cseréjét. A Tomcat néhány másodperc alatt elindul, és futnia kell, amikor a szkriptek az Aspose.Slides‑t használják.

## **A telepítés ellenőrzése**

Mentse el ezt a szkriptet *hello.php* néven a projekt mappában. Egy prezentációt hoz létre egy szövegdobozzal, és a szkript mellé menti azt:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

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

Futtassa a projekt mappából:

```bash
php hello.php
```

A szkript *hello.pptx*‑t ír ki, egy diával, amely a szövegdobozt tartalmazza. Licenc nélkül a dia egy értékelő vízjelet is visel; lásd a [Licencelés](/slides/hu/php-java/licensing/) oldalt.

A szkript közvetlenül tartalmazza a `aspose.slides.php`‑t: a Composer automatikus betöltője nem tudja betölteni ezeket az osztályokat, mivel mindegyik egyetlen fájlban van definiálva. Emellett abszolút útvonalat ad át a `save` metódusnak, mivel az Aspose.Slides a Tomcaton belül fut, és a relatív útvonalat a Tomcat munkakönyvtára ellenőrzéséhez oldja fel, nem a szkriptétől.

## **GYIK**

**Hogyan ellenőrizhetem, hogy az Aspose.Slides megfelelően integrálva van?**

Futtassa a szkriptet a [A telepítés ellenőrzése](#a-telepítés-ellenőrzése) szekcióban leírtak szerint. Ha *hello.pptx* fájlt ír ki hiba nélkül, a PHP, a PHP/Java Bridge és az Aspose.Slides együttműködnek.

**Miért áll le a szkript a „Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'” hibaüzenettel?**

A PHP nem tudta betölteni a `Java.inc` fájlt a Tomcat‑ról. Ha az üzenet előtt azt jelzi, hogy a `http://` wrapper le van tiltva, állítsa be az `allow_url_include = On` értéket abban a `php.ini`‑ban, amelyet a PHP parancssora használ; a `php --ini` megmutatja, melyik fájl az. Ha a hiba „Connection refused”, a Tomcat még nem fut: indítsa el, vagy várjon néhány másodpercet, amíg elindul.

**Hogyan korlátozhatom a memóriafogyasztást nagy prezentációk feldolgozása közben?**

Emelje csak annyira a JVM memória korlátját, amennyire szükség van, és minden [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példányt zárjon le egy `finally` blokkban a gyors gyorsítótár felszabadításáért. Ez megakadályozza a memória‑elfogyási hibákat, és a kötegelt műveletek során előre látható memóriahasználatot biztosít.

**Kizárhatok-e nem kívánt exportformátumokat a végső JAR méretének csökkentése érdekében?**

Az aktuális Aspose.Slides kiadások egyetlen monolitikus könyvtárként kerülnek szállításra, így nem lehet egyes exportereket, például a PDF‑et vagy az SVG‑t letiltani fordításkor.