---
title: Instalación
type: docs
weight: 70
url: /es/java/installation/
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
- Java
- Aspose.Slides
description: "Instale Aspose.Slides for Java desde el repositorio Maven de Aspose o como archivo JAR, configure los requisitos previos en Linux y verifique la instalación con un primer programa."
---
## **Visión general**

Este artículo explica cómo agregar Aspose.Slides for Java a un proyecto. Aspose.Slides for Java se publica en el propio repositorio Maven de Aspose, no en Maven Central, por lo que un proyecto Maven debe declarar ese repositorio. También puede descargar el archivo JAR y colocarlo en el classpath manualmente. Ambas rutas terminan con un pequeño programa que confirma que la biblioteca funciona.

Aspose.Slides for Java no requiere Microsoft PowerPoint. Genera programáticamente los archivos de presentación necesarios. Sin embargo, para ver las presentaciones generadas, puede que necesite Microsoft PowerPoint u otro visor de presentaciones.

## **Requisitos previos**

- Un kit de desarrollo de Java (JDK). El proyecto y los comandos de este artículo requieren JDK 11 o posterior. En JDK 11, el programa que verifica la instalación muestra una advertencia que comienza con "WARNING: An illegal reflective access operation has occurred"; no afecta al resultado y puede ignorarse.
- [Apache Maven](https://maven.apache.org/install.html), si utiliza la ruta Maven.
- En Linux, la biblioteca fontconfig y al menos una fuente instalada. Ver [Linux](#linux).

## **Instalar desde el repositorio Maven**

Aspose aloja sus bibliotecas Java en su propio [repositorio Maven](https://releases.aspose.com/java/repo/com/aspose/). Para usar [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) en un proyecto Maven, agregue dos entradas a su *pom.xml*.

1. **Declare el repositorio Maven de Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Agregar la dependencia Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

El clasificador `jdk16` es necesario: selecciona la versión Java SE de la biblioteca. Reemplace `26.9` con la última versión listada en el [repositorio](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). El repositorio publica un archivo de suma de verificación SHA-1 junto a cada JAR, que Maven verifica al descargar la biblioteca.

### **Comprobar la instalación**

Para comprobar la configuración con un nuevo proyecto:

1. Cree una carpeta para el proyecto y guarde este *pom.xml* en ella:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Además del repositorio y la dependencia, este *pom.xml* establece la versión de Java para compilar, nombra la clase que `mvn exec:java` ejecuta y fija el plugin del compilador, porque el plugin más antiguo que algunas instalaciones de Maven usan por defecto ignora la configuración `maven.compiler.release`.

2. Guarde el primer ejemplo en [Create Presentations](/slides/es/java/create-presentation/) como *src/main/java/HelloSlides.java*.

3. En la carpeta del proyecto, ejecute:

   ```bash
   mvn compile exec:java
   ```

Maven descarga Aspose.Slides for Java, compila el programa y lo ejecuta. El programa guarda *new_presentation.pptx* en la carpeta del proyecto.

## **Usar el archivo JAR sin Maven**

1. Descargue *aspose-slides-26.9-jdk16.jar* de la [carpeta de versión](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) en el repositorio. Para otra versión, abra su carpeta en el [repositorio](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) y descargue el archivo que termine en *-jdk16.jar*.

2. Guarde el primer ejemplo en [Create Presentations](/slides/es/java/create-presentation/) como *HelloSlides.java* en la misma carpeta que el archivo JAR.

3. En esa carpeta, ejecute:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

El JDK compila y ejecuta el archivo fuente único, y el programa guarda *new_presentation.pptx* en la carpeta. En su propia aplicación, agregue el archivo JAR al classpath en su herramienta de compilación o IDE.

## **Linux**

Aspose.Slides for Java utiliza el soporte de fuentes de Java, que en Linux necesita la biblioteca fontconfig y al menos una fuente instalada. Sin ellas, guardar una presentación falla con el error "Fontconfig head is null, check your fonts or fonts configuration". Las imágenes mínimas de servidor y contenedor pueden carecer de ambas; la imagen oficial de contenedor Ubuntu, por ejemplo, no tiene ninguna.

En Debian y Ubuntu, este comando instala un JDK, Maven, fontconfig y las fuentes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Las fuentes utilizadas en sus presentaciones, o sustitutos adecuados, también deben estar instaladas para que el texto se renderice correctamente.

## **Preguntas frecuentes**

### ¿Cómo puedo comprobar que Aspose.Slides está integrado correctamente?

Compila su proyecto, cree una instancia de una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) vacía y guárdela con un nuevo nombre. Si el archivo se crea sin lanzar excepciones, la biblioteca se ha integrado correctamente.

### ¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?

Aumente los límites de memoria de la JVM solo tanto como sea necesario, y llame a [dispose](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#dispose--) en cada instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) dentro de un bloque `finally` para liberar la caché rápidamente. Esto evita errores de falta de memoria y mantiene el uso de memoria general predecible durante operaciones por lotes.

### ¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?

Las versiones actuales de Aspose.Slides se distribuyen como una única biblioteca monolítica, por lo que no puede desactivar exportadores específicos como PDF o SVG en tiempo de compilación.