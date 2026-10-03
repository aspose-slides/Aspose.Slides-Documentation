---
title: Ejecutar Aspose.Slides for Java en Docker
linktitle: Docker
type: docs
weight: 150
url: /es/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Contenedor Docker
- compilación multi-etapa
- imagen de contenedor
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- fuentes
- conversión a PDF
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Compila y ejecuta una aplicación Aspose.Slides for Java en Docker: un Dockerfile multi-etapa sobre las imágenes oficiales de Maven y Eclipse Temurin, las bibliotecas y fuentes de Linux que necesita Aspose.Slides, y cómo copiar los archivos generados a su máquina."
---
## **Visión general**

Este artículo muestra cómo ejecutar Aspose.Slides for Java en un contenedor Docker. Usted crea un proyecto Maven pequeño que crea una presentación con un cuadro de texto y la convierte a PDF, la empaqueta con un Dockerfile de varias etapas en las imágenes oficiales de Maven y Eclipse Temurin, la ejecuta y copia los archivos generados a su máquina. El artículo también explica qué necesita Aspose.Slides en una imagen Linux además de Java, y termina con variantes para Alpine Linux y para imágenes que instalan Java a partir de los paquetes de la distribución.

Solo necesita Docker en su máquina. El JDK y Maven forman parte de la imagen de compilación, por lo que no tiene que instalarlos. Para instalar Docker, consulte [Obtener Docker](https://docs.docker.com/get-started/get-docker/).

## **Elegir las imágenes base**

El Dockerfile de este artículo utiliza dos imágenes oficiales de Docker Hub:

- [maven](https://hub.docker.com/_/maven) con la etiqueta `3.9-eclipse-temurin-21` compila la aplicación. Contiene Apache Maven 3.9 y el JDK Eclipse Temurin 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) con la etiqueta `21-jre` la ejecuta. Contiene el tiempo de ejecución Java 21 de Eclipse Temurin sobre Ubuntu, sin el JDK ni Maven.

Aspose.Slides for Java dibuja texto con el soporte de fuentes de Java, que en Linux necesita las bibliotecas fontconfig y FreeType y al menos una fuente instalada. Las imágenes Eclipse Temurin ya incluyen fontconfig, FreeType y las fuentes DejaVu, por lo que el Dockerfile de este artículo no instala paquetes. En una imagen sin ninguna fuente, guardar una presentación se detiene con el error "Fontconfig head is null, check your fonts or fonts configuration". Si compila sobre otra imagen base, vea [Use Another Base Image](#use-another-base-image).

## **Crear el proyecto**

Cree una carpeta llamada *hello-slides-docker* y añada los siguientes archivos.

*`pom.xml`* declara el repositorio Maven de Aspose y la dependencia Aspose.Slides for Java, como se describe en [Installation](/slides/es/java/installation/); Aspose.Slides for Java no está publicado en Maven Central, por lo que la entrada del repositorio es obligatoria. El elemento `finalName` nombra el archivo JAR de la aplicación *hello-slides.jar*, y el [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) copia las dependencias de la aplicación a *target/lib* cuando Maven lo empaqueta. Establezca la versión de Aspose.Slides a la más reciente listada en el [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*`src/main/java/HelloSlides.java`* crea una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/), añade un rectángulo con texto a su primera diapositiva y guarda la presentación dos veces con el método [save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-): como PPTX y como PDF. Ambos archivos se colocan en la carpeta *output* bajo el directorio de trabajo. El programa luego lista las fuentes que Aspose.Slides sustituye al renderizar la presentación, usando [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), de modo que pueda ver si el contenedor tiene las fuentes que la presentación utiliza.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*`.dockerignore`* mantiene fuera del contexto de compilación de Docker la carpeta *target* de una compilación local y la salida de ejecuciones anteriores, de modo que la imagen se construya solo a partir de los archivos fuente.

```text
target/
output/
```

## **Escribir el Dockerfile**

Añada un archivo llamado *Dockerfile* a la carpeta *hello-slides-docker*:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

El archivo tiene dos etapas:

- **The build stage** comienza a partir de la imagen Maven. Copia primero *pom.xml* y ejecuta `mvn dependency:go-offline`, que descarga Aspose.Slides for Java y los plugins Maven, de modo que Docker reutiliza esa capa mientras *pom.xml* no cambie. Luego copia el código fuente y ejecuta `mvn package`, que compila el programa en *target/hello-slides.jar* y copia el archivo JAR de Aspose.Slides a *target/lib*. La opción `-B` ejecuta Maven en modo no interactivo (batch).
- **The runtime stage** comienza a partir de la imagen de tiempo de ejecución Java más pequeña y copia solo el archivo JAR de la aplicación y la carpeta *lib*. Crea la carpeta *output*, la asigna a `ubuntu`, el usuario sin privilegios que define la imagen basada en Ubuntu, y ejecuta la aplicación como ese usuario. El classpath `hello-slides.jar:lib/*` contiene la aplicación y cada archivo JAR en *lib*; Java expande el `*` por sí mismo.

El proyecto se compila para Java 11 (la propiedad `maven.compiler.release`), por lo que la etapa de tiempo de ejecución puede usar una versión más reciente de Java. Por ejemplo, para ejecutar la aplicación en Java 25, cambie la imagen de la etapa de tiempo de ejecución a `eclipse-temurin:25-jre`.

## **Compilar y ejecutar el contenedor**

Abra una terminal en la carpeta *hello-slides-docker*. Compile la imagen y, a continuación, ejecute un contenedor a partir de ella:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

La primera compilación descarga las imágenes base, los plugins Maven y Aspose.Slides for Java, por lo que tarda varios minutos; las compilaciones posteriores los reutilizan. El contenedor ejecuta la aplicación y se detiene. Imprime:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La primera línea muestra que el texto usa Calibri, la fuente predeterminada de una nueva presentación, y que Calibri no está instalada en la imagen, por lo que Aspose.Slides dibujó el texto con DejaVu Sans. El texto en el PDF es texto real, seleccionable, en esa fuente. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; vea [Licensing](/slides/es/java/licensing/).

## **Copiar la salida a su máquina**

Los archivos se encuentran en la carpeta */app/output* del contenedor detenido. Cópielos a una carpeta *output* en su máquina y, a continuación, elimine el contenedor:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Estos dos comandos funcionan de la misma forma en Bash, PowerShell y el símbolo del sistema de Windows.

En Linux, puede montar una carpeta de su máquina dentro del contenedor, de modo que la aplicación escriba sus archivos allí directamente:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

La opción `--user` ejecuta la aplicación con sus identificadores de usuario y grupo, por lo que puede escribir en la carpeta que creó y los archivos le pertenecen. `--rm` elimina el contenedor cuando se detiene.

## **Ejecutar en Alpine Linux**

Eclipse Temurin también está disponible como una imagen basada en Alpine Linux, que es más pequeña. Contiene fontconfig, FreeType y las fuentes DejaVu también, por lo que la aplicación no necesita paquetes adicionales allí. Para usarla, reemplace la etapa de tiempo de ejecución en *Dockerfile* (todo a partir de la segunda línea `FROM`) por:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

La imagen Alpine no tiene usuario `ubuntu`, por lo que esta etapa crea un usuario llamado `app` con `adduser` y ejecuta la aplicación como ese usuario. Compile, ejecute y copie la salida con los mismos comandos que arriba. La aplicación imprime las mismas dos líneas.

## **Usar otra imagen base**

Si su imagen instala Java a partir de los paquetes de la distribución Linux, instale también las bibliotecas de fuentes de Java y una fuente. En Debian y Ubuntu, el paquete `openjdk-21-jre-headless` enumera fontconfig, FreeType y HarfBuzz solo como paquetes recomendados, por lo que `apt-get install --no-install-recommends` los omite, y la aplicación se detiene con un `UnsatisfiedLinkError` para `libfontmanager.so`. Esta etapa de tiempo de ejecución instala Java 21, las bibliotecas y las fuentes DejaVu en Debian 13, y crea un usuario sin privilegios llamado `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

La misma etapa funciona en Ubuntu 26.04 con `FROM ubuntu:26.04`.

## **FAQ**

**Guardar la presentación se detiene con "Fontconfig head is null, check your fonts or fonts configuration". ¿Qué falta?**

Una fuente. El soporte de fuentes de Java no encontró ninguna fuente instalada en la imagen. Instale un paquete de fuentes, por ejemplo `fonts-dejavu-core` en Debian y Ubuntu, como en [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/es/java/deploy-fonts/) enumera otros paquetes de fuentes.

**La aplicación se detiene con un UnsatisfiedLinkError para libfontmanager.so. ¿Qué falta?**

Una biblioteca nativa del soporte de fuentes de Java; el mensaje indica el archivo que no pudo cargarse, por ejemplo `libharfbuzz.so.0`. Esto ocurre cuando Java se instala desde los paquetes de la distribución sin sus paquetes recomendados. Instale las bibliotecas listadas en [Use Another Base Image](#use-another-base-image).

**¿Por qué el texto del PDF está en una fuente distinta a la de PowerPoint?**

Las fuentes que usa la presentación no están instaladas en la imagen, por lo que Aspose.Slides dibuja el texto con una fuente sustituta. La salida de la aplicación enumera cada fuente reemplazada. [Deploy Fonts](/slides/es/java/deploy-fonts/) explica cómo instalar fuentes en la imagen o cargarlas desde la carpeta de la aplicación.

**¿Cuánta memoria puede usar la aplicación en el contenedor?**

Por defecto, Java limita su heap a una cuarta parte de la memoria disponible para el contenedor, por ejemplo a unos 250 MB cuando inicia el contenedor con `docker run -m 1g`. Para procesar presentaciones grandes, aumente la proporción con la opción `MaxRAMPercentage`, por ejemplo `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java entonces imprime una línea "Picked up JAVA_TOOL_OPTIONS" antes de la salida de la aplicación.

**¿Necesito un JDK o Maven en mi máquina?**

No. La etapa de compilación construye la aplicación dentro de la imagen Maven. Sólo necesita un JDK y Maven si también quiere compilar y ejecutar la aplicación fuera de Docker; vea [Installation](/slides/es/java/installation/).