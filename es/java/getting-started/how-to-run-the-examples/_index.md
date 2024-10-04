---
title: Cómo ejecutar los ejemplos
type: docs
weight: 140
url: /java/how-to-run-the-examples/
---

## **Descargar desde GitHub**
Todos los ejemplos de Aspose.Slides para Java están alojados en [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Puedes clonar el repositorio utilizando tu cliente de Github favorito o descargar el archivo ZIP desde [aquí](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrae el contenido del archivo ZIP a cualquier carpeta de tu computadora. Todos los ejemplos se encuentran en la carpeta **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importar ejemplos en el IDE**
El proyecto utiliza el sistema de construcción Maven. Cualquier IDE moderno puede abrir o importar fácilmente el proyecto y sus dependencias. A continuación, te mostramos cómo usar IDEs populares para construir y ejecutar los ejemplos.

### **IntelliJ IDEA**
Haz clic en el menú **File** y elige **Open**. Navega hasta la carpeta del proyecto y selecciona el archivo **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Se abrirá el proyecto y se descargarán las dependencias automáticamente. Desde la pestaña del proyecto, navega por los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haz clic derecho en el archivo y elige "Run ..", el ejemplo se ejecutará y la salida se mostrará en la ventana de salida de consola incorporada.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Haz clic en el menú **File** y elige **Import**. Selecciona **Maven** - Proyectos Maven existentes.

![todo:image_alt_text](eclipse_import.png)

Navega hasta la carpeta que clonaste o descargaste de GitHub y selecciona el archivo **pom.xml**. Se abrirá el proyecto y se descargarán las dependencias automáticamente. Desde la pestaña Package Explorer, navega por los ejemplos en la carpeta **src/main/java**. Para ejecutar un ejemplo, simplemente haz clic derecho en el archivo y elige **Run As** - **Java Application**, el ejemplo se ejecutará y la salida se mostrará en la ventana de salida de consola incorporada.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Haz clic en el menú **File** y elige **Open Project**. Navega hasta la carpeta que clonaste o descargaste de GitHub. El icono de la carpeta **Examples** mostrará que es un proyecto Maven. Selecciona Examples y ábrelo.

![todo:image_alt_text](netbeans_openproject.png)

Se abrirá el proyecto y se descargarán las dependencias automáticamente. Desde la pestaña Projects, navega por los ejemplos en **source packages**. Para ejecutar un ejemplo, simplemente haz clic derecho en el archivo y elige **Run File**, el ejemplo se ejecutará y la salida se mostrará en la ventana de salida de consola incorporada.

![todo:image_alt_text](netbeans_run_example.png)

## **Agregar la biblioteca Aspose.Slides en el repositorio local de Maven**
Cuando importas el proyecto **Aspose.Slides Examples** en el IDE, Maven descarga automáticamente el archivo JAR de aspose.slides desde [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). En caso de que no tengas acceso a internet, puedes agregar manualmente el JAR en tu repositorio local.

### **mvn install**
Descarga el [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), extráelo y copia el aspose.slides-version.jar a otro lugar, por ejemplo, la unidad C. Ejecuta el siguiente comando:

```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```

Ahora, el JAR de **aspose.slides** está copiado en tu repositorio local de Maven.

### **pom.xml**
Después de instalar, simplemente declara la coordenada **aspose.slides** en pom.xml. Agrega el siguiente repositorio en la pestaña de repositorios y la dependencia en la pestaña de dependencias.

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

### **Hecho**
Compílalo, ahora el JAR de **aspose.slides** se puede recuperar de tu repositorio local de Maven.

## **Contribuir**
Si deseas agregar o mejorar un ejemplo, te animamos a contribuir al proyecto. Todos los ejemplos y proyectos de exhibición en este repositorio son de código abierto y se pueden utilizar libremente en tus propias aplicaciones.

Para contribuir, puedes bifurcar el repositorio, editar el código fuente y enviar una Pull Request. Revisaremos los cambios e incluiremos en el repositorio si se consideran útiles.