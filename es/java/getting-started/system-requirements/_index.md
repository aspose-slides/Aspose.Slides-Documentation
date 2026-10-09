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
description: "Comprueba qué necesita Aspose.Slides for Java antes de instalarlo: las versiones de Java y los sistemas operativos compatibles, y la biblioteca de fuentes y fuentes que Linux requiere."
---
## **Introducción**

Aspose.Slides for Java es una biblioteca independiente: no necesita Microsoft PowerPoint ni Microsoft Office. Es un único archivo JAR, publicado en el repositorio Maven de Aspose. El archivo JAR contiene solo clases y recursos Java, sin bibliotecas nativas, y no declara dependencias de otras bibliotecas. Por lo tanto, el mismo archivo se ejecuta en cualquier sistema operativo y procesador para los que exista un tiempo de ejecución Java compatible.

Este artículo enumera las versiones de Java y los sistemas operativos compatibles, la biblioteca de fuentes y las fuentes que necesita Linux, y termina con un pequeño programa que comprueba tu configuración. Para añadir la biblioteca a un proyecto, consulta [Instalación](/slides/es/java/installation/).

## **Versiones de Java compatibles**

Aspose.Slides for Java se ejecuta en Java 8 o posterior, con un JDK o un JRE. Esto incluye las versiones de soporte a largo plazo Java 8, 11, 17, 21 y 25, y versiones posteriores como Java 26 y Java 27. El tiempo de ejecución Java puede provenir de cualquier proveedor, por ejemplo Eclipse Temurin, Amazon Corretto, Oracle o los paquetes OpenJDK de una distribución Linux.

Aspose.Slides no necesita opciones de JVM, como `--add-opens`, en ninguna de estas versiones. En Java 11, la JVM muestra una advertencia que comienza con "WARNING: An illegal reflective access operation has occurred"; la advertencia no afecta al resultado.

{{% alert color="warning" title="Warning" %}}
Java 6 y Java 7 están obsoletos. Aspose.Slides for Java 26.9 sigue ejecutándose en ellos pero muestra una advertencia de deprecación. A partir de la versión 26.10, Java 8 es el mínimo, y Java 6 y Java 7 ya no son compatibles.
{{% /alert %}}

El proyecto Maven y los comandos en [Instalación](/slides/es/java/installation/) requieren JDK 11 o posterior. Con Java 8, compila y ejecuta tu programa como se muestra en [Comprueba tu configuración](#check-your-setup).

## **Sistemas operativos compatibles**

Porque el archivo JAR no contiene código nativo, Aspose.Slides for Java se ejecuta en Windows, Linux y macOS, en cualquier arquitectura de procesador que soporte el tiempo de ejecución Java, como x64 y ARM64. El tiempo de ejecución Java es el único requisito en Windows. En Linux, el soporte de fuentes de Java también necesita la biblioteca de fuentes y las fuentes descritas en [Linux](#linux).

## **Linux**

Aspose.Slides for Java dispone y dibuja texto con el soporte de fuentes del tiempo de ejecución Java. En Linux, ese soporte requiere la biblioteca fontconfig y al menos una fuente instalada. Las imágenes oficiales de contenedores de distribuciones Linux a menudo no tienen ninguno de los dos. Sin ellos, el primer ejemplo en [Crear presentaciones](/slides/es/java/create-presentation/) falla al guardar la presentación, deja un archivo vacío y reporta este error:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Las imágenes oficiales de contenedor `eclipse-temurin`, para Ubuntu y Alpine Linux, ya contienen fontconfig y las fuentes DejaVu, por lo que no es necesario instalar nada en ellas. En otros sistemas, instala los paquetes a continuación. Los comandos de Debian, Ubuntu y Red Hat usan `sudo`; en un Dockerfile, ejecútalos en una instrucción `RUN` sin `sudo`. Las fuentes DejaVu son suficientes para que Aspose.Slides funcione; las fuentes que usan tus presentaciones se tratan en [Fuentes](#fonts).

### **Debian y Ubuntu**

Si instalas Java desde los paquetes Debian o Ubuntu con la configuración predeterminada de `apt-get`, como hace el comando en [Instalación](/slides/es/java/installation/#linux), los paquetes Java también instalan la biblioteca fontconfig, las fuentes DejaVu y la biblioteca HarfBuzz que necesitan esos paquetes Java, y no se requiere nada más.

Con un tiempo de ejecución Java de otra fuente, como un archivo de Eclipse Temurin, instala fontconfig y las fuentes DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Un Dockerfile suele instalar los paquetes Java de Debian o Ubuntu, como `openjdk-21-jdk-headless` o `default-jdk-headless`, con la opción `--no-install-recommends`, que omite los tres. Instala fontconfig y las fuentes DejaVu con el comando anterior, e instala también HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Sin HarfBuzz, estos paquetes Java imprimen `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, y al guardar falla con un `UnsatisfiedLinkError` que indica que `libharfbuzz.so.0` no se puede abrir.

### **Red Hat Enterprise Linux**

Los paquetes `java-<version>-openjdk-headless` de Red Hat Enterprise Linux no instalan la biblioteca fontconfig. Instálala junto con las fuentes DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Los paquetes completos `java-<version>-openjdk` instalan fontconfig y fuentes como dependencias, al igual que los paquetes Amazon Corretto de Amazon Linux 2023, como `java-21-amazon-corretto-headless`.

### **Alpine Linux**

En un Dockerfile basado en Alpine Linux, instala fontconfig y las fuentes DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

En las versiones actuales de Alpine, `ttf-dejavu` instala el paquete `font-dejavu`. Instala Java con el paquete `openjdk<version>-jre` o `openjdk<version>-jdk`, como `openjdk25-jdk`. Los paquetes `openjdk<version>-jre-headless` de Alpine Linux no contienen la biblioteca de fuentes de Java, por lo que con ellos el programa falla con `UnsatisfiedLinkError: no fontmanager in system library path`, incluso cuando las fuentes están instaladas.

### **Fuentes**

Para que el texto se represente con las fuentes y métricas correctas, las fuentes que usan tus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema o cargadas por tu aplicación. Consulta [Desplegar fuentes](/slides/es/java/deploy-fonts/), [Sustitución de fuentes](/slides/es/java/font-substitution/) y [Fuentes personalizadas](/slides/es/java/custom-font/).

## **Comprueba tu configuración**

Para comprobar que la biblioteca y sus requisitos están presentes, ejecuta un programa que guarde una presentación y renderice una diapositiva a una imagen. Guardar y renderizar usan el soporte de fuentes del tiempo de ejecución Java, que es lo que proporcionan los requisitos de Linux descritos arriba.

Guarda el código siguiente como *CheckSetup.java* en la carpeta que contiene el archivo JAR de Aspose.Slides. Para descargar el archivo JAR, consulta [Usar el archivo JAR sin Maven](/slides/es/java/installation/#use-the-jar-file-without-maven).

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

Con JDK 11 o posterior, ejecuta el programa en esa carpeta con el comando a continuación. Si tu archivo JAR tiene un nombre diferente, cambia el nombre en los comandos.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Con Java 8, o en un sistema que solo tenga un JRE, compila el programa con `javac` desde un JDK y luego ejecuta la clase compilada. En Linux y macOS, ejecuta:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

En Windows, ejecuta el mismo comando `javac` y luego ejecuta la clase con un punto y coma como separador de la ruta de clases. Mantén las comillas, para que PowerShell no interprete el punto y coma como el fin del comando: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

El programa añade un rectángulo con texto a la primera diapositiva y guarda la presentación como *hello.pptx* con el método [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Después renderiza la diapositiva con [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) y guarda el resultado como *hello.png* con [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) en el formato [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Los factores de escala de 1 representan un píxel por punto, de modo que la diapositiva predeterminada de 720 × 540 puntos se convierte en una imagen de 720 × 540 píxeles, con el texto visible dentro del rectángulo. Sin una licencia, ambos archivos llevan también una marca de agua de evaluación; consulta [Licencias](/slides/es/java/licensing/). Si falta algún requisito, el programa se detiene con uno de los errores descritos en [Linux](#linux).

## **Herramientas de desarrollo**

Puedes crear aplicaciones que utilicen Aspose.Slides con cualquier JDK de una versión de Java compatible. Usa Apache Maven con el repositorio Maven de Aspose, como se describe en [Instalación](/slides/es/java/installation/), o cualquier otra herramienta de compilación que pueda usar un repositorio Maven. También puedes añadir el archivo JAR a la ruta de clases de tu IDE o herramienta de compilación manualmente.

## **Preguntas frecuentes**

**¿Necesito que Microsoft PowerPoint esté instalado para conversiones y renderizado?**

No, PowerPoint no es necesario. Aspose.Slides es un motor independiente para [crear](/slides/es/java/create-presentation/), modificar, [convertir](/slides/es/java/convert-presentation/) y [renderizar](/slides/es/java/convert-powerpoint-to-png/) presentaciones.

**¿Aspose.Slides for Java necesita un monitor o un entorno de escritorio en un servidor Linux?**

No. Aspose.Slides no necesita un servidor X ni un monitor, por lo que funciona en servidores y contenedores. En Linux, solo necesita la biblioteca de fuentes y las fuentes descritas en [Linux](#linux).

**¿Qué fuentes son necesarias para un renderizado correcto?**

Las fuentes usadas en la presentación, o [sustitutos](/slides/es/java/font-substitution/) adecuados, deben estar disponibles. En Linux y macOS, instala los paquetes de fuentes que necesiten tus presentaciones para obtener un renderizado coherente.

**¿Por qué una fuente personalizada se renderiza como sustituta o texto faltante en Linux?**

Si el archivo de fuente tiene entradas de tabla de nombres inconsistentes o corruptas, la pila de coincidencia de fuentes de Linux (FreeType/fontconfig) puede seleccionar un registro inválido, lo que hace que la fuente quede sin resolver. Utilizar una versión de la fuente con registros de tabla de nombres corregidos o instalar un reemplazo coherente resuelve el problema.