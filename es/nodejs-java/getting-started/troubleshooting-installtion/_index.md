---
title: Solución de problemas al instalar Aspose.Slides para Node.js a través de Java
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "Descargar Aspose.Slides, Instalar Aspose.Slides, Solución de problemas de instalación de Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Solución de problemas al instalar Aspose.Slides para Node.js a través de Java en Windows, Linux o macOS"
---

Cuando [instalando](/nodejs-java/installation/) `aspose.slides.via.java` usando `npm`, hay casos en los que ocurren errores durante la compilación de los módulos `java` y `node-gyp`. Hemos investigado estos errores en más detalle e identificado requisitos específicos para las versiones de los programas y paquetes instalados. 

## **Requisitos de versión**

1. Para Node.js 12 y versiones anteriores:
   - Python no mayor a 3.10.
   - Para Windows, se recomienda instalar Visual Studio Build Tools no más reciente que 2017.
   - versión del paquete java de npm: 0.12.1.

2. Para Node.js 13:
   - Mismos requisitos que para Node.js 12.

3. Para Node.js 14:
   - Python 3.10.
   - versión del paquete java de npm: 0.14.0.

4. Para Node.js 15:
   - Python 3.12.
   - versión del paquete java de npm: 0.14.0.

5. Para Node.js 16 y versiones más nuevas:
   - Python 3.12.
   - versión del paquete java de npm: 0.14.0.

**Siga las instrucciones a continuación para instalar los programas requeridos.**

### **Instalación en Unix**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/).
- Instalar Java (JDK 1.8).
- Instalar una herramienta de compilación C/C++ adecuada, como [GCC](https://gcc.gnu.org).

### **Instalación en macOS**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/).
- Instalar Java (JDK 1.8) y modificar la sección JVMCapabilities en /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist con privilegios de administrador. jdk1.8.x_xxx.jdk depende de su versión de jdk. Debe verse así: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- Instalar los `Xcode Command Line Tools` de forma independiente ejecutando `xcode-select --install`. -- O -- Alternativamente, si ya tiene [el Xcode completo instalado](https://developer.apple.com/xcode/download/), puede instalar las herramientas de línea de comandos en el menú `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalación en Windows**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/) desde la [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Instalar Java (JDK 1.8).
- Instalar [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (utilizando "Visual C++ build tools" si usa una versión anterior a VS2019, de lo contrario, use "Desarrollo de escritorio con C++" o [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) utilizando la carga de trabajo "Desarrollo de escritorio con C++").

Asegúrese de que Node.js, Python y Java estén agregados a la variable PATH.

## **Instalación de Aspose.Slides para Node.js a través de Java en Node.js versión 14 y versiones más nuevas**

Simplemente use el comando:
```
npm i aspose.slides.via.java
```

## **Instalación de Aspose.Slides para Node.js a través de Java en Node.js versión 12 o 13**

Aspose.Slides para Node.js a través de Java debe ser instalado manualmente. Use el siguiente comando:

- Para Node.js 12:
```
npm i java@0.12.1
```
- Para Node.js 13: 
```
npm i java@0.13.0
```

Después de eso, descargue [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) y extráigalo a la carpeta `node_modules/aspose.slides.via.java`.

## **Validación de la instalación**

Para validar la instalación, cree un archivo `index.js` en la raíz de su proyecto con el siguiente contenido:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Ejecute este archivo usando el comando `node index.js`.

## **Información adicional**

No es posible cubrir todos los problemas posibles dentro del alcance de este artículo. Dado que los problemas surgen debido a la compilación de módulos `java` y `node-gyp`, los siguientes enlaces también serán útiles:
- [instalación de java](https://www.npmjs.com/package/java#installation) 
- [instalación de node-gyp](https://www.npmjs.com/package/node-gyp#installation)