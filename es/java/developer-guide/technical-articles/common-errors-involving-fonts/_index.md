---
title: Excepciones y errores comunes de fuentes en Linux
type: docs
weight: 200
url: /es/java/technical-articles/common-errors-involving-fonts
keywords: "Excepción de fuente, Error de fuente, Linux, Java, Aspose.Slides for Java"
description: "Excepciones y errores de fuentes en Linux"
---

## **Texto o imágenes faltantes (EMF o WMF) cuando el código se ejecuta en Linux**

Este problema ocurre en sistemas con restricciones en los siguientes casos:

1. Cuando no hay fuentes instaladas o cuando la carpeta de fuentes para el proceso java no se puede acceder
2. Cuando no se puede acceder al directorio TEMP.

### **Solución**

Verifique y confirme que se haya concedido acceso al directorio TEMP y a la carpeta de fuentes. 

{{% alert color="warning" %}}
En algunos casos, puede que no pueda conceder acceso a las carpetas debido a restricciones impuestas por el entorno o una política de seguridad. Pruebe estas soluciones alternativas: 
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


## **Exception: InvalidOperationException: No se pueden encontrar fuentes instaladas en el sistema**

Esta excepción ocurre cuando

1) el proceso Java no puede acceder a la carpeta de fuentes.
2) no se han instalado fuentes.

### **Solución**

1. Verifique y confirme que se haya concedido acceso a la carpeta de fuentes para el proceso Java.

2. Instale algunas fuentes o utilice [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

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


## **Exception: NoClassDefFoundError: No se pudo inicializar la clase com.aspose.slides.internal.ey.this**

Esta excepción ocurre en un sistema Linux que carece de fontconfig y fuentes. 

### **Solución**

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


## **Exception: UnsatisfiedLinkError: libfreetype.so.6: No se puede abrir el archivo de objeto compartido: No existe el archivo o el directorio**

Esta excepción ocurre en un sistema Linux que carece de la biblioteca libfreetype. 

### **Solución**

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