---
title: Excepciones y errores comunes relacionados con fuentes en Linux
type: docs
weight: 200
url: /es/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Excepción de fuente, Error de fuente, Linux, Java, Aspose.Slides para Java"
description: "Excepciones y errores de fuentes en Linux"
---
## **Resumen**

Cuando Aspose.Slides se utiliza en Linux, pueden producirse problemas relacionados con las fuentes si el proceso Java no puede acceder a las carpetas de fuentes requeridas o al directorio temporal, si no hay fuentes instaladas en el sistema, o si faltan bibliotecas del sistema necesarias como fontconfig o libfreetype.

Este artículo describe los errores y excepciones comunes relacionados con las fuentes en Linux y proporciona soluciones para resolverlos. Explica cómo comprobar el acceso a los directorios de fuentes y TEMP, instalar las fuentes y bibliotecas necesarias, y usar `FontsLoader` para cargar fuentes sin instalarlas a nivel del sistema.

## **Texto o imágenes faltantes (EMF o WMF) cuando el código se ejecuta en Linux**

Este problema ocurre en sistemas con restricciones en los siguientes casos:

1. Cuando no hay fuentes instaladas o cuando la carpeta de fuentes para el proceso Java no puede ser accedida
2. Cuando el directorio TEMP no puede ser accedido.

### **Solución**

Compruebe y confirme que se ha concedido acceso al directorio TEMP y a la carpeta de fuentes. 

{{% alert color="warning" %}}
En algunos casos, puede que no pueda conceder acceso a las carpetas debido a restricciones impuestas por el entorno o una política de seguridad. Pruebe estas soluciones alternativas: 
{{% /alert %}}

**Solución alternativa**

Use [FontsLoader](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontsLoader) para cargar las fuentes requeridas sin instalarlas:

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

1) el proceso Java no puede acceder a la carpeta de fuentes
2) no se han instalado fuentes.

### **Solución**

1. Compruebe y confirme que se ha concedido acceso a la carpeta de fuentes para el proceso Java.

2. Instale algunas fuentes o use [FontsLoader](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontsLoader).

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

   * Usando [FontsLoader](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Excepción: NoClassDefFoundError: No se pudo inicializar la clase com.aspose.slides.internal.ey.this**

Esta excepción ocurre en un sistema Linux que carece de fontconfig y fuentes. 

### **Solución**

Instalar fontconfig:

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

Además, algunas versiones de open‑jdk (por ejemplo, **alpine JDK**) también **requieren fuentes instaladas**.

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

## **Excepción: UnsatisfiedLinkError: libfreetype.so.6: No se puede abrir el archivo de objeto compartido: No existe el archivo o el directorio**

Esta excepción ocurre en un sistema Linux que carece de la biblioteca libfreetype. 

### **Solución**

Instalar libfreetype y fontconfig:

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

{{% alert title="TIP" color="info" %}} 
No olvide instalar fuentes o usar FontsLoader.
{{% /alert %}}