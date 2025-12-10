---
title: Cómo ejecutar los ejemplos
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
description: "Ejecute rápidamente los ejemplos de Aspose.Slides para Java: clone el repositorio, restaure los paquetes y luego compile y pruebe las funcionalidades para PPT, PPTX y ODP."
---

## **Descargar Aspose.Slides desde GitHub**
Todos los ejemplos de Aspose.Slides para Java están alojados en [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Puede clonar el repositorio usando su cliente de Github favorito o descargar el archivo ZIP desde [aquí](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extraiga el contenido del archivo ZIP a cualquier carpeta en su computadora. Todos los ejemplos se encuentran en la carpeta **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importar ejemplos en el IDE**
El proyecto utiliza el sistema de compilación Maven. Cualquier IDE moderno puede abrir o importar fácilmente el proyecto y sus dependencias. A continuación le mostramos cómo usar IDEs populares para compilar y ejecutar los ejemplos.

### **IntelliJ IDEA**
Haga clic en el menú **File** y elija **Open**. Navegue hasta la carpeta del proyecto y seleccione el archivo **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Se abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Project, explore los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haga clic derecho en el archivo y elija "Run ..", el ejemplo se ejecutará y la salida se mostrará en la ventana de consola integrada.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Haga clic en el menú **File** y elija **Import**. Seleccione **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navegue hasta la carpeta que clonó o descargó de GitHub y seleccione el archivo **pom.xml**. Se abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Package Explorer, explore los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haga clic derecho en el archivo y elija **Run As** - **Java Application**, el ejemplo se ejecutará y la salida se mostrará en la ventana de consola integrada.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Haga clic en el menú **File** y elija **Open Project**. Navegue hasta la carpeta que clonó o descargó de GitHub. El ícono de la carpeta **Examples** mostrará que es un proyecto Maven. Seleccione Examples y ábralo.

![todo:image_alt_text](netbeans_openproject.png)

Se abrirá el proyecto y descargará las dependencias automáticamente. Desde la pestaña Projects, explore los ejemplos en **source packages**. Para ejecutar un ejemplo, simplemente haga clic derecho en el archivo y elija **Run File**, el ejemplo se ejecutará y la salida se mostrará en la ventana de consola integrada.

![todo:image_alt_text](netbeans_run_example.png)

## **Agregar la biblioteca Aspose.Slides al repositorio local de Maven**
Cuando importe el proyecto **Aspose.Slides Examples** al IDE, Maven descarga automáticamente el archivo JAR aspose.slides desde el [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). En caso de que no tenga acceso a Internet, puede añadir manualmente el JAR en su repositorio local.

### **mvn install**
Descargue el [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), extráigalo y copie el archivo aspose.slides-version.jar a otro lugar, por ejemplo, la unidad C. Ejecute el siguiente comando:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Ahora, el JAR **aspose.slides** está copiado en su repositorio local de Maven.

### **pom.xml**
Después de la instalación, simplemente declare la coordenada **aspose.slides** en pom.xml. Añada el siguiente repositorio en la pestaña repositories y la dependencia en la pestaña dependencies.
``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```


### **Listo**
Compílelo, ahora el JAR **aspose.slides** puede recuperarse de su repositorio local de Maven.

## **Contribuir**
Si desea agregar o mejorar un ejemplo, le animamos a contribuir al proyecto. Todos los ejemplos y proyectos de demostración en este repositorio son de código abierto y pueden usarse libremente en sus propias aplicaciones.

Para contribuir, puede bifurcar el repositorio, editar el código fuente y enviar una Pull Request. Revisaremos los cambios y los incluiremos en el repositorio si son útiles.