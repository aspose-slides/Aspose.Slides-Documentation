---
title: Instalación
type: docs
weight: 70
url: /es/php-java/installation/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- utilizar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- Linux
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Instale Aspose.Slides para PHP a través de Java en Linux y Windows: configure PHP, Java, Apache Tomcat y PHP/Java Bridge, añada el paquete con Composer y verifique la configuración con un script breve."
---
## **Descripción general**

Aspose.Slides for PHP via Java se ejecuta en dos procesos. Su script PHP utiliza clases PHP que envían cada llamada a través del PHP/Java Bridge a Aspose.Slides, que se ejecuta en Java dentro de Apache Tomcat. Este artículo explica cómo configurar ambos lados, instalar el paquete con Composer y ejecutar un script breve para verificar la instalación.

## **Requisitos previos**

- **PHP 7.0 a 8.3**, con `allow_url_include = On` en `php.ini`. Sus scripts cargan la biblioteca cliente del puente, `Java.inc`, desde Tomcat mediante HTTP. En PHP 8.4 y posteriores, `Java.inc` se detiene con el error "end() expects exactly 1 argument" siempre que la extensión `xml` de PHP esté cargada, y las compilaciones de PHP para Windows siempre la cargan.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 o posterior.** Basta con un JRE.
- **Apache Tomcat 9.** PHP/Java Bridge está construido sobre la API `javax.servlet`, que Tomcat 10 y posteriores ya no proporcionan, por lo que el puente no se inicia allí.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, su última versión. Su aplicación web, `JavaBridge.war`, se ejecuta en Tomcat.

Este artículo ejecuta Tomcat y sus scripts PHP en el mismo equipo. Aspose.Slides abre y guarda archivos dentro de Tomcat, por lo que cada ruta que sus scripts le pasen debe ser válida allí.

## **Instalación en Linux**

Estos comandos instalan todo en su carpeta personal en Ubuntu 24.04. En otras distribuciones, instale los mismos paquetes con el gestor de paquetes de la distribución.

1. Instale PHP, Composer, Java y las herramientas de descarga, y active `allow_url_include` para la línea de comandos de PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Descargue Apache Tomcat 9 y PHP/Java Bridge, coloque el `JavaBridge.war` del puente en la carpeta `webapps` de Tomcat y arranque Tomcat. Tomcat descomprime el archivo WAR en `webapps/JavaBridge` al iniciarse:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Cree una carpeta de proyecto e instale Aspose.Slides for PHP via Java desde [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Detenga Tomcat, copie el archivo JAR de Aspose.Slides del paquete a la carpeta `WEB-INF/lib` del puente, reemplace `Java.inc` del puente con la versión para PHP 8 del paquete, y vuelva a iniciar Tomcat:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/es/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/es/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   En PHP 7, omita la sustitución de `Java.inc`. Tomcat tarda unos segundos en iniciarse y debe estar ejecutándose siempre que sus scripts usen Aspose.Slides.

## **Instalación en Windows**

1. Instale [PHP 8.3 para Windows](https://www.php.net/downloads.php?os=windows) y añada su carpeta a la variable de entorno `PATH`. Copie `php.ini-production` a `php.ini` en la misma carpeta. En `php.ini`, establezca `allow_url_include = On` y descomente las líneas `extension_dir = "ext"`, `extension=openssl` y `extension=zip`. Composer necesita `openssl` para descargar paquetes y `zip` para descomprimirlos, a menos que tenga instalado 7‑Zip o un comando `unzip` en `PATH`.
2. Instale [Composer](https://getcomposer.org/download/).
3. Instale Java y establezca la variable de entorno `JAVA_HOME` apuntando a su carpeta. Tomcat no arranca sin ella.
4. En el símbolo del sistema, descargue Apache Tomcat 9 y PHP/Java Bridge, coloque el `JavaBridge.war` del puente en la carpeta `webapps` de Tomcat y arranque Tomcat. Los scripts de Tomcat localizan Tomcat mediante la variable `CATALINA_HOME`, por lo que debe seguir usando la misma ventana del símbolo del sistema para los pasos siguientes. Tomcat descomprime el archivo WAR en `webapps\JavaBridge` al iniciarse:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Cree una carpeta de proyecto e instale Aspose.Slides for PHP via Java desde [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Detenga Tomcat, copie el archivo JAR de Aspose.Slides del paquete a la carpeta `WEB-INF\lib` del puente, reemplace `Java.inc` del puente con la versión para PHP 8 del paquete, y vuelva a iniciar Tomcat:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   En PHP 7, omita la sustitución de `Java.inc`. Tomcat tarda unos segundos en iniciarse y debe estar ejecutándose siempre que sus scripts usen Aspose.Slides.

## **Verificar la instalación**

Guarde este script como *hello.php* en la carpeta del proyecto. Crea una presentación con un cuadro de texto y la guarda junto al script:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

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

Ejecútelo desde la carpeta del proyecto:

```bash
php hello.php
```

El script genera *hello.pptx*, con una diapositiva que contiene el cuadro de texto. Sin una licencia, la diapositiva también muestra una marca de agua de evaluación; consulte [Licencias](/slides/es/php-java/licensing/).

El script incluye `aspose.slides.php` directamente: el cargador automático de Composer no puede cargar estas clases, porque todas están definidas en ese único archivo. Además, pasa una ruta absoluta a `save`, ya que Aspose.Slides se ejecuta dentro de Tomcat y resuelve una ruta relativa respecto a la carpeta de trabajo de Tomcat, no a la de su script.

## **FAQ**

**¿Cómo puedo comprobar que Aspose.Slides está integrado correctamente?**

Ejecute el script en [Verificar la instalación](#verify-the-installation). Si genera *hello.pptx* sin errores, PHP, PHP/Java Bridge y Aspose.Slides funcionan juntos.

**¿Por qué mi script se detiene con "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP no pudo cargar `Java.inc` desde Tomcat. Si el mensaje anterior indica que el wrapper `http://` está deshabilitado, active `allow_url_include = On` en el archivo `php.ini` que utiliza la línea de comandos de PHP; `php --ini` muestra cuál es. Si indica "Connection refused", Tomcat aún no está en ejecución: arránquelo o espere unos segundos hasta que se inicie.

**¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?**

Aumente los límites de memoria de la JVM solo lo necesario y cierre cada instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en un bloque `finally` para liberar la caché rápidamente. Así se evitan errores de falta de memoria y se mantiene predecible el uso total de memoria durante operaciones por lotes.

**¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?**

Las versiones actuales de Aspose.Slides se distribuyen como una única biblioteca monolítica, por lo que no es posible desactivar exportadores específicos como PDF o SVG en tiempo de compilación.