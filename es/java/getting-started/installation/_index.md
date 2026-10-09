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
description: "Instala Aspose.Slides for Java desde el repositorio Maven de Aspose o como archivo JAR, configura los requisitos previos de Linux y verifica la instalación con un primer programa."
---
## **Visión general**

Este artículo explica cómo añadir Aspose.Slides for Java a un proyecto. Aspose.Slides for Java se publica en el propio repositorio Maven de Aspose, no en Maven Central, por lo que un proyecto Maven debe declarar ese repositorio. También puedes descargar el archivo JAR y añadirlo tú mismo al classpath. Ambas rutas terminan con un pequeño programa que confirma que la biblioteca funciona.

Aspose.Slides for Java no requiere Microsoft PowerPoint. Genera programáticamente los archivos de presentación necesarios. Sin embargo, para ver las presentaciones generadas, puede que necesites Microsoft PowerPoint u otro visor de presentaciones.

## **Requisitos previos**

- Un Java Development Kit (JDK). El proyecto y los comandos de este artículo necesitan JDK 11 o posterior. En JDK 11, el programa que verifica la instalación muestra una advertencia que comienza con “WARNING: An illegal reflective access operation has occurred”; no afecta al resultado y puede ignorarse.
- [Apache Maven](https://maven.apache.org/install.html), si utilizas la vía Maven.
- En Linux, la biblioteca fontconfig y al menos una fuente instalada. Ver [Linux](#linux).

## **Instalar desde el repositorio Maven**

Aspose aloja sus bibliotecas Java en su propio [repositorio Maven](https://releases.aspose.com/java/repo/com/aspose/). Para usar [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) en un proyecto Maven, añade dos entradas a tu *pom.xml*.

1. **Declarar el repositorio Maven de Aspose.**

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
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

El clasificador `jdk8` es necesario: selecciona la compilación Java SE de la biblioteca. Sustituye `26.10` por la última versión listada en el [repositorio](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). El repositorio publica un archivo de suma de verificación SHA‑1 junto a cada JAR, que Maven verifica al descargar la biblioteca.

### **Comprobar la instalación**

Para comprobar la configuración con un proyecto nuevo:

1. Crea una carpeta para el proyecto y guarda este *pom.xml* en ella:

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   Además del repositorio y la dependencia, este *pom.xml* establece la versión de Java a compilar, nombra la clase que `mvn exec:java` ejecuta y fija el plugin del compilador, porque el plugin más antiguo que algunas instalaciones Maven usan por defecto ignora la configuración `maven.compiler.release`.

2. Guarda el primer ejemplo en [Crear presentaciones](/slides/es/java/create-presentation/) como *src/main/java/HelloSlides.java*.

3. En la carpeta del proyecto, ejecuta:

   ```bash
   mvn compile exec:java
   ```

Maven descarga Aspose.Slides for Java, compila el programa y lo ejecuta. El programa guarda *new_presentation.pptx* en la carpeta del proyecto.

## **Usar el archivo JAR sin Maven**

1. Descarga *aspose-slides-26.10-jdk8.jar* desde la [carpeta de versiones](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) del repositorio. Para otra versión, abre su carpeta en el [repositorio](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) y descarga el archivo que termina en *-jdk8.jar*.
2. Guarda el primer ejemplo en [Crear presentaciones](/slides/es/java/create-presentation/) como *HelloSlides.java* en la misma carpeta que el archivo JAR.
3. En esa carpeta, ejecuta:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

El JDK compila y ejecuta el único archivo fuente, y el programa guarda *new_presentation.pptx* en la carpeta. En tu propia aplicación, añade el archivo JAR al classpath en tu herramienta de compilación o IDE.

## **Linux**

Aspose.Slides for Java utiliza el soporte de fuentes de Java, que en Linux necesita la biblioteca fontconfig y al menos una fuente instalada. Sin ellas, al guardar una presentación se produce el error “Fontconfig head is null, check your fonts or fonts configuration”. Las imágenes mínimas de servidores y contenedores pueden carecer de ambos; la imagen oficial de contenedor Ubuntu, por ejemplo, no tiene ninguno.

En Debian y Ubuntu, este comando instala un JDK, Maven, fontconfig y las fuentes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Las fuentes usadas en tus presentaciones, o sustitutos adecuados, también deben estar instaladas para que el texto se renderice correctamente.

## **Preguntas frecuentes**

### ¿Cómo puedo verificar que Aspose.Slides está integrado correctamente?

Compila tu proyecto, instancia una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) en blanco y guárdala con un nombre nuevo. Si el archivo se crea sin lanzar excepciones, la biblioteca se ha integrado con éxito.

### ¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?

Aumenta los límites de memoria de la JVM solo tanto como sea necesario y llama a [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) en cada instancia de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dentro de un bloque `finally` para liberar la caché rápidamente. Esto evita errores de falta de memoria y mantiene el uso total de memoria predecible durante operaciones por lotes.

### ¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?

Las versiones actuales de Aspose.Slides se distribuyen como una única biblioteca monolítica, por lo que no puedes desactivar exportadores específicos como PDF o SVG en tiempo de compilación.