---
title: Desplegar fuentes para Aspose.Slides para Java en Linux y Docker
linktitle: Desplegar fuentes
type: docs
weight: 155
url: /es/java/deploy-fonts/
keywords:
- desplegar fuentes
- instalar fuentes
- fuentes en Docker
- fuentes en Linux
- fuentes faltantes
- sustitución de fuentes
- fuentes principales de Microsoft
- ttf-mscorefonts-installer
- fuentes personalizadas
- fuente predeterminada
- servidor
- contenedor
- conversión a PDF
- presentación
- Java
- Aspose.Slides
description: "Desplegar fuentes para Aspose.Slides para Java en servidores Linux y contenedores Docker: comprobar qué fuentes se sustituyen, instalar paquetes de fuentes en Debian, Ubuntu y Alpine, añadir sus propios archivos de fuentes y establecer una fuente predeterminada."
---
## **Resumen**

Aspose.Slides dibuja el texto con las fuentes que tiene disponibles al renderizar una presentación, por ejemplo cuando convierte diapositivas a PDF o a imágenes. Un escritorio Windows suele disponer de las fuentes que usan las presentaciones. Los servidores y contenedores Linux normalmente tienen pocas fuentes, por lo que Aspose.Slides dibuja el texto con una fuente de sustitución. Una sustituta tiene formas y anchuras de letra diferentes, de modo que las líneas pueden ajustarse de forma distinta y el texto puede desbordarse de su forma, y los caracteres que le falten a la sustituta no se dibujan correctamente. Si no hay ninguna fuente instalada, el soporte de fuentes de Java no puede iniciarse y Aspose.Slides se detiene con un error.

Este artículo muestra cómo comprobar qué fuentes sustituye Aspose.Slides, cómo instalar fuentes en Debian, Ubuntu y Alpine Linux, cómo añadir sus propios archivos de fuentes y cómo establecer la fuente que se usa cuando falta una fuente. Los ejemplos se ejecutan en Docker con las imágenes oficiales de Eclipse Temurin, como en [Run Aspose.Slides for Java in Docker](/slides/es/java/how-to-run-aspose-slides-in-docker/). Los comandos de paquetes son instrucciones de Dockerfile; en un servidor Linux, ejecute los mismos comandos como root.

Para la API de fuentes propiamente dicha, como incrustar fuentes en una presentación y reglas de sustitución y reemplazo, consulte [PowerPoint Fonts](/slides/es/java/powerpoint-fonts/).

## **Comprobar qué fuentes son sustituidas**

El proyecto Maven siguiente informa de las fuentes que Aspose.Slides sustituye en el entorno actual. Cree una carpeta llamada *font-check* y añada los archivos siguientes.

*`pom.xml`* es el mismo que en [Run Aspose.Slides for Java in Docker](/slides/es/java/how-to-run-aspose-slides-in-docker/#create-the-project), con el ID de artefacto y el nombre del archivo JAR cambiados a *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*`src/main/java/FontCheck.java`* agrega un cuadro de texto por cada nombre de fuente a una diapositiva y asigna la fuente con el método [setLatinFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Los nombres de fuente provienen de la línea de comandos; sin argumentos, el programa comprueba Calibri, Arial y Times New Roman. Imprime las carpetas en las que Aspose.Slides busca fuentes ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsloader/#getFontFolders--)), renderiza la diapositiva a *output/fonts.pdf* y muestra las sustituciones reportadas por [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Los dos pasos opcionales al inicio, cargar una carpeta *fonts* y leer una variable `DEFAULT_FONT`, se explican más adelante en este artículo.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Las fuentes a comprobar: los argumentos de la línea de comandos, o tres fuentes comunes de Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Cargar los archivos de fuentes desde la carpeta fonts en el directorio de trabajo, si existe.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Usar la fuente indicada en la variable de entorno DEFAULT_FONT, si está establecida, para el texto cuya fuente falta.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` puede devolver una carpeta más de una vez, por lo que el programa recoge las carpetas en un conjunto antes de imprimirlas.

*.dockerignore* mantiene los resultados de compilación locales fuera del contexto de compilación:

```text
target/
output/
```

*Dockerfile* construye el programa con la imagen Maven y lo ejecuta sobre la imagen de tiempo de ejecución Java de Eclipse Temurin, que ya incluye fontconfig y las fuentes DejaVu. [Run Aspose.Slides for Java in Docker](/slides/es/java/how-to-run-aspose-slides-in-docker/) explica cada instrucción.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Compilar la imagen y ejecutar la comprobación:

```bash
docker build -t font-check .
docker run --rm font-check
```

La imagen solo tiene las fuentes DejaVu, por lo que las tres fuentes se reemplazan por DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Para comprobar las fuentes de sus propias presentaciones, pase sus nombres como argumentos, por ejemplo `docker run --rm font-check "Segoe UI" Consolas`. Para copiar *output/fonts.pdf* fuera del contenedor, use los comandos de [Copy the Output to Your Machine](/slides/es/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalar fuentes en Debian y Ubuntu**

### **Microsoft Core Fonts**

El paquete `ttf-mscorefonts-installer` descarga e instala las fuentes principales de Microsoft para la web, entre ellas Arial, Times New Roman, Courier New, Verdana, Georgia y Trebuchet MS. Las fuentes están licenciadas bajo el acuerdo de licencia de usuario final (EULA) de Microsoft, y el paquete las instala solo después de que se acepte la EULA. Una compilación Docker no puede responder al aviso, por lo que el instalador rechaza la EULA y no instala fuentes, aunque `apt-get install` indique éxito. Acepte la EULA con `debconf-set-selections` **antes** de que se instale el paquete. Aceptarla en una instrucción posterior no ayuda: el paquete ya está instalado y apt no vuelve a ejecutar su instalador.

Añada esta instrucción a la fase de tiempo de ejecución del *Dockerfile*, justo después de la línea `FROM`, de modo que se ejecute como root, antes de la instrucción `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Construya la imagen y vuelva a ejecutar la comprobación con los mismos dos comandos. Arial y Times New Roman ahora están instalados:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, la fuente predeterminada de una presentación que crea Aspose.Slides, no es una de las fuentes principales, por lo que sigue sustituyéndose. Consulte [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Las imágenes basadas en Ubuntu de Eclipse Temurin habilitan `multiverse`, el componente de Ubuntu que contiene el paquete. En Debian, el paquete está en el componente `contrib`, que las imágenes de Debian no habilitan. En una fase de tiempo de ejecución basada en Debian, como la de [Use Another Base Image](/slides/es/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), habilite `contrib` en la misma instrucción:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Otros paquetes de fuentes**

Debian y Ubuntu también empaquetan fuentes con licencia libre, por ejemplo:

| Paquete | Fuentes |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif y Mono, con las mismas métricas que Arial, Times New Roman y Courier New |
| `fonts-crosextra-carlito` | Carlito, con las mismas métricas que Calibri |
| `fonts-crosextra-caladea` | Caladea, con las mismas métricas que Cambria |

Instálelos con `apt-get install` en una instrucción `RUN` de la fase de tiempo de ejecución, del mismo modo que las fuentes principales de Microsoft. Aspose.Slides for Java no aplica los alias de fuentes de la configuración de fuentes de Linux: con `fonts-liberation` instalado, el texto en Arial sigue dibujándose con la fuente de sustitución general, no con Liberation Sans. Para usar una fuente compatible en métricas en lugar de una que falta, establézcala como la [fuente predeterminada](#set-a-default-font-for-missing-fonts) o añada una [regla de sustitución de fuentes](/slides/es/java/font-substitution/).

## **Añadir sus propios archivos de fuentes**

Las fuentes que las distribuciones no empaquetan, como las fuentes de su organización o otras fuentes que tiene licencia para usar en el servidor, pueden añadirse como archivos de fuentes. Coloque los archivos de fuentes, por ejemplo archivos *.ttf*, en una carpeta llamada *fonts* dentro de la carpeta *font-check*. Los ejemplos siguientes usan los archivos de Carlito, una fuente con las mismas métricas que Calibri, que puede descargar de [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalar las fuentes en una carpeta de fuentes del sistema**

Aspose.Slides lee las fuentes en las carpetas mostradas en la línea `Font folders`. Para instalar sus fuentes para cualquier aplicación en la imagen, cópielas a */usr/local/share/fonts*, la carpeta de fuentes instaladas localmente. Añada esta instrucción a la fase de tiempo de ejecución del *Dockerfile*, después de la instrucción `RUN` que instala las fuentes principales de Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Vuelva a crear la imagen y, a continuación, compruebe Calibri y Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito ya no se sustituye:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Cargar fuentes desde la carpeta de la aplicación**

En lugar de instalar las fuentes en una carpeta del sistema, puede enviarlas con la aplicación y cargarlas con [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Las fuentes estarán disponibles solo para Aspose.Slides y se desplegarán junto con la aplicación. *FontCheck* hace esto: cuando su directorio de trabajo, */app* en el contenedor, contiene una carpeta *fonts*, el programa pasa esa carpeta a `loadExternalFonts` antes de crear la presentación. [Custom Font](/slides/es/java/custom-font/) describe otras formas de suministrar fuentes, como cargarlas desde memoria.

En el *Dockerfile*, elimine la instrucción `COPY fonts/ /usr/local/share/fonts/` y añada esta después de la instrucción que copia la carpeta *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Vuelva a crear la imagen y ejecute la comprobación con los mismos dos comandos. La carpeta de la aplicación ahora aparece entre las carpetas de fuentes, y Carlito sigue sin sustituirse:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` añade fuentes a las instaladas, pero el soporte de fuentes de Java sigue necesitando al menos una fuente instalada. En una imagen sin ninguna, `loadExternalFonts` se detiene con el error “Fontconfig head is null, check your fonts or fonts configuration”.

## **Establecer una fuente predeterminada para fuentes faltantes**

Cuando falta una fuente, Aspose.Slides usa una sustituta que elige él mismo. Para elegirla usted, pase el nombre de la fuente al método [setDefaultRegularFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) de [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/) y pase las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). *FontCheck* lee el nombre de la fuente de la variable de entorno `DEFAULT_FONT`. Con Carlito cargado, úselo para fuentes faltantes:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri ahora se dibuja con Carlito, cuyos caracteres tienen la misma anchura que los de Calibri, por lo que el texto conserva sus saltos de línea:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

La fuente predeterminada sustituye a cualquier fuente faltante. Para mapear fuentes individuales, por ejemplo Arial a Liberation Sans y Calibri a Carlito, use [reglas de sustitución de fuentes](/slides/es/java/font-substitution/). Las reglas cambian la salida renderizada, pero `getSubstitutions` no las refleja, así que compruebe las fuentes en el archivo de salida. Para texto asiático, también llame a [setDefaultAsianFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); vea [Default Font](/slides/es/java/default-font/).

## **Instalar fuentes en Alpine Linux**

La imagen basada en Alpine de Eclipse Temurin también contiene las fuentes DejaVu; [Run on Alpine Linux](/slides/es/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) describe su fase de tiempo de ejecución. Para instalar también las fuentes principales de Microsoft, reemplace la fase de tiempo de ejecución del Dockerfile *font-check* con esta:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` descarga e instala las mismas fuentes principales de Microsoft que el paquete de Debian y Ubuntu, y su EULA se aplica de la misma manera. `fc-cache` actualiza la caché de fuentes de fontconfig. Construya la imagen y ejecute la comprobación con los dos comandos de [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Imprime:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Los demás pasos de esta página funcionan de la misma forma en Alpine: copie la carpeta *fonts* a */usr/local/share/fonts* o a la carpeta de la aplicación, y establezca `DEFAULT_FONT` para elegir la fuente predeterminada. La imagen Alpine no tiene la carpeta */usr/local/share/fonts*, por lo que esa carpeta aparece en la línea `Font folders` sólo después de que una instrucción `COPY` la cree.

## **FAQ**

**¿Por qué una presentación se ve diferente al convertirse en un servidor?**

El servidor no dispone de las fuentes que utiliza la presentación, de modo que Aspose.Slides dibuja el texto con una fuente de sustitución cuyas letras tienen otras anchuras. Ejecute *FontCheck* con los nombres de fuente de la presentación para ver qué fuentes se sustituyen, luego instale esas fuentes o cárguelas desde la carpeta de la aplicación.

**El proceso instaló ttf-mscorefonts-installer, pero Arial sigue sustituyéndose. ¿Por qué?**

La EULA no se aceptó antes de que se instalara el paquete, por lo que el instalador omitió las fuentes. Coloque el comando `debconf-set-selections` antes de `apt-get install` en la instrucción que instala el paquete, tal y como se muestra en [Microsoft Core Fonts](#microsoft-core-fonts), y vuelva a crear la imagen.

**¿Necesita el equipo que abre el PDF las fuentes?**

No. En estos ejemplos, el PDF contiene las fuentes que se usaron para dibujar el texto, por lo que se ve igual en cualquier equipo. Las fuentes solo son necesarias donde Aspose.Slides renderiza la presentación.