---
title: Solución de problemas de instalación de Aspose.Slides para Node.js vía Java
linktitle: Solución de problemas de instalación
type: docs
weight: 75
url: /es/nodejs-java/troubleshooting-installation/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- solución de problemas de instalación
- requisitos de versión
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Solucione los problemas de instalación de Aspose.Slides para Node.js vía Java, corrija errores y dependencias comunes, y garantice un trabajo fluido con PPT, PPTX y ODP."
---

Al [instalar](/slides/es/nodejs-java/installation/) `aspose.slides.via.java` usando `npm`, hay casos en los que se producen errores durante la compilación de los módulos `java` y `node-gyp`. Hemos investigado estos errores con mayor detalle e identificado requisitos específicos para las versiones de los programas y paquetes instalados. 

## **Requisitos de versión**

1. Para Node.js 12 y versiones anteriores:
   - Python no superior a 3.10.
   - En Windows, se recomienda instalar Visual Studio Build Tools no más recientes que 2017.
   - Versión del paquete npm java: 0.12.1.

2. Para Node.js 13:
   - Mismos requisitos que para Node.js 12.

3. Para Node.js 14:
   - Python 3.10.
   - Versión del paquete npm java: 0.14.0.

4. Para Node.js 15:
   - Python 3.12.
   - Versión del paquete npm java: 0.14.0.

5. Para Node.js 16 y versiones posteriores:
   - Python 3.12.
   - Versión del paquete npm java: 0.14.0.

**Siga las instrucciones a continuación para instalar los programas requeridos.**

### **Instalación en Unix**

- Instale [Node.js](https://nodejs.org/en/download).
- Instale [Python](https://devguide.python.org/versions/).
- Instale Java (JDK 1.8).
- Instale una cadena de herramientas adecuada de compilador C/C++, como [GCC](https://gcc.gnu.org).

### **Instalación en macOS**

- Instale [Node.js](https://nodejs.org/en/download).
- Instale [Python](https://devguide.python.org/versions/).
- Instale Java (JDK 1.8) y modifique la sección JVMCapabilities en /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist con privilegios de superusuario. jdk1.8.x_xxx.jdk depende de su versión de jdk. Hágalo lucir así: 
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

- Instale las `Xcode Command Line Tools` de forma independiente ejecutando `xcode-select --install`. -- O -- Alternativamente, si ya tiene instalado el [Xcode completo](https://developer.apple.com/xcode/download/), puede instalar las Command Line Tools bajo el menú `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalación en Windows**

- Instale [Node.js](https://nodejs.org/en/download).
- Instale [Python](https://devguide.python.org/versions/) desde la [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Instale Java (JDK 1.8).
- Instale [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (utilizando "Visual C++ build tools" si usa una versión anterior a VS2019, de lo contrario use la carga de trabajo "Desktop development with C++" o [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) usando la carga de trabajo "Desktop development with C++").

- Asegúrese de que Node.js, Python y Java estén añadidos a la variable PATH.

## **Instalación de Aspose.Slides para Node.js vía Java en la versión 14 o posterior de Node.js**

Simplemente use el comando:
```
npm i aspose.slides.via.java
```


## **Instalación de Aspose.Slides para Node.js vía Java en la versión 12 o 13 de Node.js**

Aspose.Slides for Node.js vía Java necesita instalarse manualmente. Use el siguiente comando:

- Para Node.js 12:
```
npm i java@0.12.1
```

- Para Node.js 13: 
```
npm i java@0.13.0
```


Después de eso, descargue [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) y extráigalo en la carpeta `node_modules/aspose.slides.via.java`.

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

No es posible cubrir todos los problemas posibles dentro del alcance de este artículo. Dado que los problemas surgen debido a la compilación de los módulos `java` y `node-gyp`, los siguientes enlaces también serán útiles:
- [instalación de java](https://www.npmjs.com/package/java#installation) 
- [instalación de node-gyp](https://www.npmjs.com/package/node-gyp#installation)