---
title: Excepciones Comunes y Errores Relacionados con Fuentes en Linux
type: docs
weight: 200
url: /es/php-java/technical-articles/common-errors-involving-fonts
keywords: "Excepción de fuente, Error de fuente, Linux, Java, Aspose.Slides para PHP a través de Java"
description: "Excepciones y errores de fuentes en Linux"
---

## **Texto o imágenes faltantes (emf o wmf) cuando se ejecuta el código en Linux**

Este problema ocurre en sistemas con restricciones en estos casos:

1. Cuando no hay fuentes instaladas o cuando no se puede acceder a la carpeta de fuentes para el proceso de java.
2. Cuando no se puede acceder al directorio TEMP.

### Solución

Verifica y confirma que se ha otorgado acceso al directorio TEMP y a la carpeta de fuentes.

{{% alert color="warning" %}}

En algunos casos, es posible que no puedas otorgar acceso a las carpetas debido a restricciones impuestas por el entorno o una política de seguridad. Prueba estos métodos alternativos:

{{% /alert %}}

**Método alternativo**

Usa [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) para cargar las fuentes requeridas sin instalarlas:

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

Si no se puede acceder al directorio TEMP, utiliza este código para especificar otro directorio como TEMP para Java:
```php

```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **Excepción: InvalidOperationException: No se pueden encontrar fuentes instaladas en el sistema**

Esta excepción ocurre cuando

1) el proceso de Java no puede acceder a la carpeta de fuentes
2) no se han instalado fuentes.

### Solución

1. Verifica y confirma que se ha otorgado acceso a la carpeta de fuentes para el proceso de Java.

2. Instala algunas fuentes o usa [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

3. Instala fuentes.

   * Ubuntu: 

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * CentOS: 

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * Usando [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader):

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **Excepción: NoClassDefFoundError: No se pudo inicializar la clase com.aspose.slides.internal.ey.this**

Esta excepción ocurre en un sistema Linux que carece de fontconfig y fuentes.

### Solución:

Instala fontconfig:

* Ubuntu:

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS:

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

Además, algunas versiones de open-jdk (por ejemplo, **alpine JDK**) también **requieren fuentes instaladas**.

* Ubuntu:

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* CentOS:

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **Excepción: UnsatisfiedLinkError: libfreetype.so.6: no se puede abrir el archivo de objeto compartido: No existe tal archivo o directorio**

Esta excepción ocurre en un sistema Linux que carece de la biblioteca libfreetype.

### Solución:

Instala libfreetype y fontconfig:

* Ubuntu: 

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS: 

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="CONSEJO" color="primary" %}} 

No olvides instalar fuentes o usar FontsLoader.

{{% /alert %}}  