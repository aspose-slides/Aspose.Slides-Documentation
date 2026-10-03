---
title: Requisitos del sistema
type: docs
weight: 60
url: /es/java/system-requirements/
keywords:
- requisitos del sistema
- plataformas compatibles
- versiones de Java
- JDK
- JRE
- fontconfig
- fuentes
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Comprueba qué necesita Aspose.Slides for Java antes de instalarlo: las versiones de Java compatibles y los sistemas operativos, así como la biblioteca de fuentes y las fuentes que requiere Linux."
---
## **Introducción**

Aspose.Slides for Java es una biblioteca independiente: no necesita Microsoft PowerPoint ni Microsoft Office. Es un único archivo JAR, publicado en el repositorio Maven de Aspose. El archivo JAR contiene solo clases y recursos Java, sin bibliotecas nativas, y no declara dependencias de otras bibliotecas. Por lo tanto, el mismo archivo se ejecuta en cualquier sistema operativo y procesador para el que haya un tiempo de ejecución Java compatible disponible.

Este artículo enumera las versiones de Java y los sistemas operativos compatibles, así como la biblioteca de fuentes y las fuentes que Linux necesita, y termina con un programa breve que verifica su configuración. Para añadir la biblioteca a un proyecto, consulte [Installation](/slides/es/java/installation/).

## **Versiones de Java compatibles**

Aspose.Slides for Java se ejecuta en Java 8 o posterior, con un JDK o un JRE. Esto incluye las versiones de soporte a largo plazo Java 8, 11, 17, 21 y 25, y versiones posteriores como Java 26 y Java 27. El tiempo de ejecución Java puede provenir de cualquier proveedor, por ejemplo Eclipse Temurin, Amazon Corretto, Oracle o los paquetes OpenJDK de una distribución Linux.

Aspose.Slides no necesita opciones de JVM, como `--add-opens`, en ninguna de estas versiones. En Java 11, la JVM muestra una advertencia que comienza con "WARNING: An illegal reflective access operation has occurred"; la advertencia no afecta al resultado.

{{% alert color="warning" title="Warning" %}}
Java 6 y Java 7 están obsoletos. Aspose.Slides for Java 26.9 todavía se ejecuta en ellos pero muestra una advertencia de obsolescencia. A partir de la versión 26.10, Java 8 es el mínimo, y Java 6 y Java 7 ya no son compatibles.
{{% /alert %}}

El proyecto Maven y los comandos en [Installation](/slides/es/java/installation/) necesitan JDK 11 o posterior. Con Java 8, compile y ejecute su programa como se muestra en [Check Your Setup](#check-your-setup).

## **Sistemas operativos compatibles**

Dado que el archivo JAR no contiene código nativo, Aspose.Slides for Java se ejecuta en Windows, Linux y macOS, en cualquier arquitectura de procesador que el tiempo de ejecución Java admita, como x64 y ARM64. El tiempo de ejecución Java es el único requisito en Windows. En Linux, el soporte de fuentes de Java también necesita la biblioteca de fuentes y las fuentes descritas en [Linux](#linux).

## **Linux**

Aspose.Slides for Java dispone y dibuja texto con el soporte de fuentes del tiempo de ejecución Java. En Linux, ese soporte requiere la biblioteca fontconfig y al menos una fuente instalada. Las imágenes oficiales de contenedores de distribuciones Linux a menudo no tienen ninguno de los dos. Sin ellos, el primer ejemplo en [Create Presentations](/slides/es/java/create-presentation/) falla al guardar la presentación, deja un archivo vacío y muestra este error:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Las imágenes oficiales de contenedor `eclipse-temurin`, para Ubuntu y para Alpine Linux, ya incluyen fontconfig y las fuentes DejaVu, por lo que no es necesario instalar nada en ellas. En otros sistemas, instale los paquetes a continuación. Los comandos para Debian, Ubuntu y Red Hat utilizan `sudo`; en un Dockerfile, ejecútelos en una instrucción `RUN` sin `sudo`. Las fuentes DejaVu son suficientes para que Aspose.Slides se ejecute; las fuentes que utilizan sus presentaciones se cubren en [Fonts](#fonts).

### **Debian y Ubuntu**

Si instala Java desde los paquetes de Debian o Ubuntu con la configuración predeterminada de `apt-get`, como hace el comando en [Installation](/slides/es/java/installation/#linux), los paquetes Java también instalan la biblioteca fontconfig, las fuentes DejaVu y la biblioteca HarfBuzz que necesitan dichos paquetes Java, y no se requiere nada más.

Con un tiempo de ejecución Java de otra fuente, como un archivo de Eclipse Temurin, instale fontconfig y las fuentes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Un Dockerfile a menudo instala los paquetes Java de Debian o Ubuntu, como `openjdk-21-jdk-headless` o `default-jdk-headless`, con la opción `--no-install-recommends`, que omite los tres. Instale fontconfig y las fuentes DejaVu con el comando anterior, y también instale HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Sin HarfBuzz, estos paquetes Java muestran `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, y el guardado falla con un `UnsatisfiedLinkError` que indica que `libharfbuzz.so.0` no se puede abrir.

### **Red Hat Enterprise Linux**

Los paquetes `java-<version>-openjdk-headless` de Red Hat Enterprise Linux no instalan la biblioteca fontconfig. Instálela junto con las fuentes DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Los paquetes completos `java-<version>-openjdk` instalan fontconfig y fuentes como dependencias, al igual que los paquetes Amazon Corretto de Amazon Linux 2023, como `java-21-amazon-corretto-headless`.

### **Alpine Linux**

En un Dockerfile basado en Alpine Linux, instale fontconfig y las fuentes DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

En las versiones actuales de Alpine, `ttf-dejavu` instala el paquete `font-dejavu`. Instale Java con el paquete `openjdk<version>-jre` o `openjdk<version>-jdk`, como `openjdk25-jdk`. Los paquetes `openjdk<version>-jre-headless` de Alpine Linux no contienen la biblioteca de fuentes de Java, por lo que con ellos el programa falla con `UnsatisfiedLinkError: no fontmanager in system library path`, incluso cuando las fuentes están instaladas.

### **Fonts**

Para que el texto se renderice con las fuentes y métricas correctas, las fuentes que utilizan sus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema o cargadas por su aplicación. Consulte [Deploy Fonts](/slides/es/java/deploy-fonts/), [Font Substitution](/slides/es/java/font-substitution/) y [Custom Fonts](/slides/es/java/custom-font/).

## **Comprobar su configuración**

Para comprobar que la biblioteca y sus requisitos están presentes, ejecute un programa que guarde una presentación y renderice una diapositiva a una imagen. Guardar y renderizar utilizan el soporte de fuentes del tiempo de ejecución Java, que es lo que proporcionan los requisitos de Linux anteriores.

Guarde el código siguiente como *CheckSetup.java* en la carpeta que contiene el archivo JAR de Aspose.Slides. Para descargar el archivo JAR, consulte [Use the JAR File without Maven](/slides/es/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Añade un rectángulo con texto a la primera diapositiva y guarda la presentación.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Renderiza la diapositiva a un píxel por punto y guarda la imagen.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Con JDK 11 o posterior, ejecute el programa en esa carpeta con el comando a continuación. Si su archivo JAR tiene un nombre diferente, cambie el nombre en los comandos.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Con Java 8, o en un sistema que solo tenga un JRE, compile el programa con `javac` de un JDK y luego ejecute la clase compilada. En Linux y macOS, ejecute:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

En Windows, ejecute el mismo comando `javac`, y luego ejecute la clase con un punto y coma como separador de la ruta de clases. Mantenga las comillas, de modo que PowerShell no interprete el punto y coma como el final del comando: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

El programa añade un rectángulo con texto a la primera diapositiva y guarda la presentación como *hello.pptx* con el método [save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Luego renderiza la diapositiva con [getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#getImage-float-float-) y guarda el resultado como *hello.png* con [IImage.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/#save-java.lang.String-int-) en el formato [ImageFormat.Png](https://reference.aspose.com/slides/es/java/com.aspose.slides/imageformat/). Los factores de escala de 1 renderizan un píxel por punto, por lo que la diapositiva predeterminada de 720 × 540 puntos se convierte en una imagen de 720 × 540 píxeles, con el texto visible dentro del rectángulo. Sin una licencia, ambos archivos también llevan una marca de evaluación; vea [Licensing](/slides/es/java/licensing/). Si falta algún requisito, el programa se detiene con uno de los errores descritos en [Linux](#linux).

## **Herramientas de desarrollo**

Puede crear aplicaciones que utilicen Aspose.Slides con cualquier JDK de una versión de Java compatible. Use Apache Maven con el repositorio Maven de Aspose, como se describe en [Installation](/slides/es/java/installation/), o cualquier otra herramienta de compilación que pueda usar un repositorio Maven. También puede añadir el archivo JAR a la ruta de clases de su IDE o herramienta de compilación manualmente.

## **FAQ**

**¿Necesito tener Microsoft PowerPoint instalado para conversiones y renderizado?**

No, PowerPoint no es necesario. Aspose.Slides es un motor independiente para [creación](/slides/es/java/create-presentation/), modificación, [conversión](/slides/es/java/convert-presentation/) y [renderizado](/slides/es/java/convert-powerpoint-to-png/) de presentaciones.

**¿Aspose.Slides for Java necesita una pantalla o un entorno de escritorio en un servidor Linux?**

No. Aspose.Slides no necesita un servidor X ni una pantalla, por lo que se ejecuta en servidores y contenedores. En Linux, solo necesita la biblioteca de fuentes y las fuentes descritas en [Linux](#linux).

**¿Qué fuentes son necesarias para una renderización correcta?**

Las fuentes utilizadas en la presentación, o [sustitutos](/slides/es/java/font-substitution/) adecuados, deben estar disponibles. En Linux y macOS, instale los paquetes de fuentes que sus presentaciones necesiten para obtener una renderización coherente.

**¿Por qué una fuente personalizada se renderiza como sustituta o texto ausente en Linux?**

Si el archivo de fuente tiene entradas de tabla de nombres inconsistentes o corruptas, la pila de coincidencia de fuentes de Linux (FreeType/fontconfig) puede seleccionar un registro inválido, lo que hace que la fuente no se resuelva. Utilizar una versión de la fuente con tablas de nombres corregidas o instalar un reemplazo coherente soluciona el problema.