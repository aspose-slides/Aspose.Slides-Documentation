---
title: Excepciones y errores comunes relacionados con fuentes en Linux
type: docs
weight: 200
url: /es/java/technical-articles/common-errors-involving-fonts
keywords: "Excepción de fuente, Error de fuente, Linux, Java, Aspose.Slides para Java"
description: "Excepciones y errores de fuentes en Linux"
---

## **Texto o imágenes faltantes (emf o wmf) cuando se ejecuta el código en Linux**

Este problema ocurre en sistemas con restricciones en estos casos:

1. Cuando no hay fuentes instaladas o cuando no se puede acceder a la carpeta de fuentes para el proceso de java
2. Cuando no se puede acceder al directorio TEMP.

### Solución

Verifique y confirme que se ha concedido acceso al directorio TEMP y a la carpeta de fuentes.

{{% alert color="warning" %}}

En algunos casos, puede que no pueda conceder acceso a las carpetas debido a restricciones impuestas por el entorno o una política de seguridad. Intente estas soluciones alternativas:

{{% /alert %}}

**Solución alternativa**

Utilice [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) para cargar las fuentes requeridas sin instalarlas:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Si no se puede acceder al directorio TEMP, use este código para especificar otro directorio como TEMP para Java:
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
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Excepción: InvalidOperationException: No se pueden encontrar fuentes instaladas en el sistema**

Esta excepción ocurre cuando

1) el proceso de Java no puede acceder a la carpeta de fuentes
2) no se han instalado fuentes.

### Solución

1. Verifique y confirme que se ha concedido acceso a la carpeta de fuentes para el proceso de Java.

2. Instale algunas fuentes o use [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

3. Instalar fuentes.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * Usando [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Excepción: NoClassDefFoundError: No se pudo inicializar la clase com.aspose.slides.internal.ey.this**

Esta excepción ocurre en un sistema Linux que carece de fontconfig y fuentes.

### Solución:

Instale fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Además, algunas versiones de open-jdk (por ejemplo, **alpine JDK**) también **requieren fuentes instaladas**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Excepción: UnsatisfiedLinkError: libfreetype.so.6: no se puede abrir el archivo de objeto compartido: No existe el archivo o directorio**

Esta excepción ocurre en un sistema Linux que carece de la biblioteca libfreetype.

### Solución:

Instale libfreetype y fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 

No olvide instalar fuentes o usar FontsLoader.

{{% /alert %}}  