---
title: Instalación
type: docs
weight: 70
url: /es/nodejs-java/installation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Instale Aspose.Slides para Node.js mediante Java desde npm en Windows, Linux y macOS: el JDK, Python y las herramientas de compilación C++ que necesita, el comando npm y un primer script para comprobar la instalación."
---
## **Visión general**

Este artículo explica cómo instalar Aspose.Slides para Node.js mediante Java en Windows, Linux y macOS, y cómo comprobar que la instalación funciona.

Aspose.Slides para Node.js mediante Java se distribuye como el paquete `aspose.slides.via.java` en npm. Ejecuta Aspose.Slides en una máquina virtual Java a través del paquete [`java`](https://github.com/joeferner/node-java), un complemento nativo de Node.js que npm compila en tu equipo durante la instalación. Por eso la instalación necesita, además de Node.js:

- **Un Kit de Desarrollo de Java (JDK) 8 o posterior.** Una máquina virtual Java por sí sola no es suficiente: la compilación necesita los archivos de encabezado del JDK.
- **Python 3**, que la herramienta de compilación [node-gyp](https://github.com/nodejs/node-gyp) utiliza.
- **Una cadena de herramientas de compilación C++** para tu sistema operativo.

## **Instalar los requisitos previos**

### **Windows**

1. Instala [Node.js](https://nodejs.org/en/download) 20 o posterior.  
2. Instala un JDK, por ejemplo [Eclipse Temurin](https://adoptium.net/), y establece la variable de entorno `JAVA_HOME` a su carpeta de instalación. La compilación utiliza el JDK al que apunta `JAVA_HOME`.  
3. Instala [Python 3](https://www.python.org/downloads/).  
4. Instala [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) con la carga de trabajo **Desarrollo de escritorio con C++**. Mantén los componentes predeterminados de la carga de trabajo, que incluyen **MSVC v143 - VS 2022 C++ x64/x86 build tools** y el **Windows 11 SDK**. Visual Studio 2026 no funciona: la versión de node-gyp con la que compila el paquete `java` no la reconoce.

### **Linux**

Instala Node.js 20 o posterior desde [nodejs.org](https://nodejs.org/en/download) o el repositorio de paquetes de tu distribución. Después, instala un JDK, Python 3 y las herramientas de compilación C++. En Debian y Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

En Linux, la compilación encuentra el JDK instalado sin configuración adicional. Si tienes varios JDK instalados, establece `JAVA_HOME` al que desees usar.

### **macOS**

Instala Node.js 20 o posterior, un JDK y las Herramientas de línea de comandos de Xcode, que incluyen Python 3 y el compilador C++. Consulta [Resolución de problemas de instalación](/slides/es/nodejs-java/troubleshooting-installation/) para notas específicas de macOS.

## **Instalar desde npm**

Crea una carpeta de proyecto e instala el paquete:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm descarga Aspose.Slides y compila el puente `java`, lo que puede tardar unos minutos. Si la compilación falla, consulta [Resolución de problemas de instalación](/slides/es/nodejs-java/troubleshooting-installation/).

## **Comprobar la instalación**

Crea un archivo llamado *hello.js* en la carpeta del proyecto con el siguiente código. Crea una presentación, añade un cuadro de texto a su primera diapositiva y guarda el resultado como *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides se ejecuta en una máquina virtual Java que mantiene Node.js en ejecución, por lo que hay que terminar el proceso explícitamente.
process.exit(0);
```

Ejecuta el script:

```bash
node hello.js
```

Si *hello.pptx* aparece en la carpeta del proyecto, la instalación funciona. La máquina virtual Java que ejecuta Aspose.Slides impide que Node.js finalice por sí mismo, por eso el script termina con `process.exit(0)`. [Crear presentaciones](/slides/es/nodejs-java/create-presentation/) explica el código.

## **Instalar desde un archivo ZIP**

El paquete también está disponible como un archivo ZIP con el mismo contenido que el paquete npm. Para instalarlo desde el archivo:

1. Instala los requisitos previos para tu sistema operativo, como se describió arriba.  
2. Descarga el archivo en la [página de descarga de Aspose.Slides para Node.js mediante Java](https://releases.aspose.com/slides/es/nodejs-java/).  
3. Crea una carpeta de proyecto:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Extrae el archivo en una subcarpeta llamada *aspose.slides.via.java* dentro de la carpeta del proyecto, de modo que el *package.json* del archivo quede en *hello-slides/aspose.slides.via.java/package.json*.  
5. Instala el paquete desde esa carpeta:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm instala el puente `java` del que depende el paquete y lo compila, como lo hace para el paquete npm.

6. Comprueba la instalación como se describe en [Comprobar la instalación](#check-the-installation).

## **Preguntas frecuentes**

**¿Existe una versión gratuita o limitación de prueba?**

Sí. Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua de evaluación a cada diapositiva que guarda y recorta el texto leído de las presentaciones. Para eliminar estas limitaciones, aplica una [licencia](/slides/es/nodejs-java/licensing/) válida.

**¿Por qué mi script no finaliza después de terminar?**

El paquete `java` inicia una máquina virtual Java dentro del proceso Node.js, y esa máquina virtual mantiene el proceso en ejecución. Llama a `process.exit` cuando tu script haya terminado su trabajo.