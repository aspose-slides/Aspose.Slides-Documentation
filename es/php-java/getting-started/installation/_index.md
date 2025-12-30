---
title: Instalación
type: docs
weight: 70
url: /es/php-java/installation/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Instale rápidamente Aspose.Slides para PHP mediante Java. Guía paso a paso, requisitos del sistema y ejemplos de código — ¡comience a trabajar con presentaciones PowerPoint hoy mismo!"
---

## **Configurar el entorno**

1. Instale PHP 7, añada la ruta de PHP a la variable del sistema `PATH` y establezca `allow_url_include` en `On` en el archivo `php.ini`.
1. Instale JRE 8. Establezca la variable de entorno `JAVA_HOME` con la ruta del JRE instalado.
1. Instale Apache Tomcat 8.0.

## **Descargar Aspose.Slides for PHP via Java**

`packagist` es la forma más sencilla de descargar [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides).

Para instalar Aspose.Slides usando Packagist, ejecute este comando:
   ```bash
   composer require aspose/slides
   ```


## **Configurar Apache Tomcat**

1. Descargue PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) desde http://php-java-bridge.sourceforge.net/pjb/download.php y extraiga el archivo `JavaBridge.war` en la carpeta `webapps` de Tomcat.
1. Inicie el servicio Apache Tomcat.
1. Descargue [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) y extráigalo a la carpeta `aspose.slides`. Copie el archivo `jar/aspose-slides-x.x-php.jar` en la carpeta `webapps\JavaBridge\WEB-INF\lib`. Si está usando **PHP 8**, sustituya el `Java.inc` original del PHP-Java Bridge por el `Java.inc` del archivo `Java.inc.php8.zip`.
1. Reinicie el servicio Apache Tomcat.
1. Ejecute `example.php` en la carpeta `aspose.slides` para ejecutar el ejemplo con este comando:
   ```bash
   php example.php
   ```


## **FAQ**

**¿Cómo puedo verificar que Aspose.Slides está integrado correctamente?**

Compile su proyecto, instancie una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en blanco y guárdela con un nombre nuevo. Si el archivo se crea sin lanzar excepciones, la biblioteca se ha integrado con éxito.

**¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?**

Aumente los límites de memoria de la JVM sólo lo necesario y cierre cada instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en un bloque `finally` para liberar la caché de inmediato. Esto evita errores de falta de memoria y mantiene predecible el uso total de memoria durante operaciones por lotes.

**¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?**

Las versiones actuales de Aspose.Slides se distribuyen como una única biblioteca monolítica, por lo que no es posible desactivar exportadores específicos como PDF o SVG en el momento de la compilación.