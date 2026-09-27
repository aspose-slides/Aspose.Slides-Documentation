---
title: Установка
type: docs
weight: 70
url: /ru/php-java/installation/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Установите Aspose.Slides for PHP via Java на Linux и Windows: настройте PHP, Java, Apache Tomcat и PHP/Java Bridge, добавьте пакет с помощью Composer и проверьте настройку с помощью короткого скрипта."
---
## **Обзор**

Aspose.Slides for PHP via Java работает в двух процессах. Ваш PHP‑скрипт использует PHP‑классы, которые передают каждый вызов через PHP/Java Bridge к Aspose.Slides, работающему на Java в Apache Tomcat. В этой статье объясняется, как настроить обе стороны, установить пакет с помощью Composer и выполнить короткий скрипт для проверки установки.

## **Требования**

- **PHP 7.0 – 8.3**, с `allow_url_include = On` в `php.ini`. Ваши скрипты загружают клиентскую библиотеку моста `Java.inc` из Tomcat по HTTP. В PHP 8.4 и новее `Java.inc` завершается ошибкой «end() expects exactly 1 argument», если загружено расширение `xml`, а сборки PHP для Windows всегда его загружают.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 или новее.** Достаточно JRE.
- **Apache Tomcat 9.** PHP/Java Bridge построен на API `javax.servlet`, которое больше не предоставляется в Tomcat 10 и новее, поэтому мост не запускается там.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, последняя версия. Его веб‑приложение `JavaBridge.war` работает в Tomcat.

В этой статье Tomcat и ваши PHP‑скрипты запускаются на одном компьютере. Aspose.Slides открывает и сохраняет файлы внутри Tomcat, поэтому каждый путь, передаваемый скриптами, должен быть действителен в этой среде.

## **Установка на Linux**

Эти команды устанавливают всё в ваш домашний каталог на Ubuntu 24.04. На других дистрибутивах установите те же пакеты с помощью менеджера пакетов дистрибутива.

1. Установите PHP, Composer, Java и инструменты загрузки, затем включите `allow_url_include` для командной строки PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
```

1. Скачайте Apache Tomcat 9 и PHP/Java Bridge, поместите `JavaBridge.war` моста в папку `webapps` Tomcat и запустите Tomcat. Tomcat распаковывает WAR‑файл в `webapps/JavaBridge` при старте:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Создайте папку проекта и установите Aspose.Slides for PHP via Java из [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Остановите Tomcat, скопируйте JAR‑файл Aspose.Slides из пакета в папку моста `WEB-INF/lib`, замените `Java.inc` моста версией для PHP 8 из пакета и снова запустите Tomcat:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/ru/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/ru/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   На PHP 7 пропустите замену `Java.inc`. Tomcat запускается несколько секунд и должен быть запущен каждый раз, когда ваши скрипты используют Aspose.Slides.

## **Установка на Windows**

1. Установите [PHP 8.3 для Windows](https://www.php.net/downloads.php?os=windows) и добавьте его папку в переменную окружения `PATH`. Скопируйте `php.ini-production` в `php.ini` в той же папке. В `php.ini` установите `allow_url_include = On` и раскомментируйте строки `extension_dir = "ext"`, `extension=openssl` и `extension=zip`. Composer нуждается в `openssl` для загрузки пакетов и в `zip` для их распаковки, если не установлен 7‑Zip или команда `unzip` недоступна в `PATH`.
1. Установите [Composer](https://getcomposer.org/download/).
1. Установите Java и задайте переменную окружения `JAVA_HOME`, указывающую на её папку. Без неё Tomcat не стартует.
1. В командной строке скачайте Apache Tomcat 9 и PHP/Java Bridge, поместите `JavaBridge.war` моста в папку `webapps` Tomcat и запустите Tomcat. Скрипты Tomcat ищут Tomcat через переменную `CATALINA_HOME`, поэтому продолжайте работать в том же окне командной строки для следующих шагов. Tomcat распаковывает WAR‑файл в `webapps\JavaBridge` при старте:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Создайте папку проекта и установите Aspose.Slides for PHP via Java из [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Остановите Tomcat, скопируйте JAR‑файл Aspose.Slides из пакета в папку моста `WEB-INF\lib`, замените `Java.inc` моста версией для PHP 8 из пакета и снова запустите Tomcat:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   На PHP 7 пропустите замену `Java.inc`. Tomcat запускается несколько секунд и должен быть запущен каждый раз, когда ваши скрипты используют Aspose.Slides.

## **Проверка установки**

Сохраните этот скрипт как *hello.php* в папке проекта. Он создаёт презентацию с одним текстовым полем и сохраняет её рядом со скриптом:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ru/lib/aspose.slides.php");

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

Запустите его из папки проекта:

```bash
php hello.php
```

Скрипт записывает *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии на слайде будет отображаться ватермарк оценки; см. [Licensing](/slides/ru/php-java/licensing/).

Скрипт напрямую включает `aspose.slides.php`: автозагрузчик Composer не может загрузить эти классы, потому что они все определены в едином файле. Также передаётся абсолютный путь в `save`, поскольку Aspose.Slides работает внутри Tomcat и разрешает относительные пути относительно рабочей папки Tomcat, а не вашего скрипта.

## **FAQ**

**Как убедиться, что Aspose.Slides интегрирован правильно?**

Запустите скрипт из раздела [Verify the Installation](#verify-the-installation). Если он создал *hello.pptx* без ошибок, PHP, PHP/Java Bridge и Aspose.Slides работают совместно.

**Почему мой скрипт останавливается с ошибкой «Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'»?**

PHP не смог загрузить `Java.inc` из Tomcat. Если сообщение перед этим указывает, что wrapper `http://` отключён, включите `allow_url_include = On` в том `php.ini`, который используется командой `php --ini`. Если появляется «Connection refused», Tomcat ещё не запущен: запустите его или подождите несколько секунд, пока он полностью стартует.

**Как ограничить потребление памяти при обработке больших презентаций?**

Увеличивайте лимиты памяти JVM только настолько, насколько это необходимо, и закрывайте каждый объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) в блоке `finally`, чтобы своевременно освобождать кэш. Это предотвращает ошибки «out‑of‑memory» и делает использование памяти предсказуемым при пакетных операциях.

**Можно ли исключить ненужные форматы экспорта, чтобы уменьшить размер итогового JAR?**

Текущие релизы Aspose.Slides поставляются как единый монолитный библиотечный файл, поэтому отключить отдельные экспортеры (например, PDF или SVG) на этапе сборки нельзя.