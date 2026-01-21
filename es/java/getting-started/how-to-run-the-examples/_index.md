---
title: Cómo ejecutar ejemplos
type: docs
weight: 140
url: /es/java/how-to-run-the-examples/
keywords:
- ejemplos
- requisitos de software
- GitHub
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Ejecute ejemplos de Aspose.Slides para Java rápidamente: clone el repositorio, restaure los paquetes y luego compile y pruebe las funcionalidades para PPT, PPTX y ODP."
---

## **Descargar Aspose.Slides desde GitHub**
Todos los ejemplos de Aspose.Slides para Java están alojados en [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Puedes clonar el repositorio usando tu cliente favorito de Github o descargar el archivo ZIP desde [aquí](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrae el contenido del archivo ZIP a cualquier carpeta de tu ordenador. Todos los ejemplos se encuentran en la carpeta **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importar ejemplos al IDE**
El proyecto utiliza el sistema de compilación Maven. Cualquier IDE moderno puede abrir o importar fácilmente el proyecto y sus dependencias. A continuación, te mostramos cómo usar IDEs populares para compilar y ejecutar los ejemplos.

### **IntelliJ IDEA**
Haz clic en el menú **File** y elige **Open**. Navega a la carpeta del proyecto y selecciona el archivo **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Project, explora los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haz clic con el botón derecho sobre el archivo y elige "Run ..", el ejemplo se ejecutará y la salida se mostrará en la ventana de consola incorporada.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Haz clic en el menú **File** y elige **Import**. Selecciona **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navega a la carpeta que clonaste o descargaste de GitHub y selecciona el archivo **pom.xml**. Abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Package Explorer, explora los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haz clic con el botón derecho sobre el archivo y elige **Run As** - **Java Application**, el ejemplo se ejecutará y la salida se mostrará en la ventana de consola incorporada.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Haz clic en el menú **File** y elige **Open Project**. Navega a la carpeta que clonaste o descargaste de GitHub. El icono de la carpeta **Examples** mostrará que es un proyecto Maven. Selecciona **Examples** y ábrelo.

![todo:image_alt_text](netbeans_openproject.png)

Abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Projects, explora los ejemplos en **source packages**. Para ejecutar un ejemplo, simplemente haz clic con el botón derecho sobre el archivo y elige **Run File**, el ejemplo se ejecutará y la salida se mostrará en la ventana de consola incorporada.

![todo:image_alt_text](netbeans_run_example.png)

## **Añadir la biblioteca Aspose.Slides al repositorio local de Maven**
Al importar el proyecto **Aspose.Slides Examples** al IDE, Maven descarga automáticamente el archivo JAR aspose.slides desde el [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). En caso de que no tengas acceso a Internet, puedes añadir manualmente el JAR a tu repositorio local.

### **mvn install**
Descarga el [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), extráelo y copia el archivo aspose.slides-version.jar a otro lugar, por ejemplo, la unidad C. Ejecuta el siguiente comando:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Ahora, el jar **aspose.slides** está copiado en tu repositorio local de Maven.

### **pom.xml**
Después de la instalación, solo declara la coordenada **aspose.slides** en pom.xml. Añade el siguiente repositorio en la pestaña repositories y la dependencia en la pestaña dependencies.
``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```


### **Hecho**
Compílalo, ahora el jar **aspose.slides** puede recuperarse de tu repositorio local de Maven.

## **Contribuir**
Si deseas añadir o mejorar un ejemplo, te animamos a contribuir al proyecto. Todos los ejemplos y proyectos de demostración en este repositorio son de código abierto y pueden utilizarse libremente en tus propias aplicaciones.

Para contribuir, puedes hacer fork del repositorio, editar el código fuente y enviar un Pull Request. Revisaremos los cambios e incluiremos el aporte en el repositorio si resulta útil.