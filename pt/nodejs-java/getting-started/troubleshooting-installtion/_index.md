---
title: Resolução de Problemas na Instalação do Aspose.Slides para Node.js via Java
linktitle: Resolução de Problemas na Instalação
type: docs
weight: 75
url: /pt/nodejs-java/troubleshooting-installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- solução de problemas de instalação
- requisitos de versão
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Resolva problemas de instalação do Aspose.Slides para Node.js via Java, corrija erros e dependências comuns e garanta um funcionamento suave com PPT, PPTX e ODP."
---
## **Introdução**

Quando [instalação](/slides/pt/nodejs-java/installation/) `aspose.slides.via.java` usando `npm`, há casos em que ocorrem erros durante a compilação dos módulos `java` e `node-gyp`. Investigamos esses erros com mais detalhes e identificamos requisitos específicos para as versões dos programas e pacotes instalados. 

## **Requisitos de versão**

1. Para Node.js 12 e anteriores:
   - Python não superior a 3.10.
   - Para Windows, recomenda‑se instalar o Visual Studio Build Tools não mais recente que 2017.
   - npm java package version: 0.12.1.

2. Para Node.js 13:
   - Mesmos requisitos da seção Node.js 12.

3. Para Node.js 14:
   - Python 3.10.
   - npm java package version: 0.14.0.

4. Para Node.js 15:
   - Python 3.12.
   - npm java package version: 0.14.0.

5. Para Node.js 16 e superiores:
   - Python 3.12.
   - npm java package version: 0.14.0.

**Siga as instruções abaixo para instalar os programas necessários.**

### **Instalação no Unix**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/).
- Instalar Java (JDK 1.8).
- Instalar uma cadeia de ferramentas de compilação C/C++ adequada, como [GCC](https://gcc.gnu.org).

### **Instalação no macOS**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/).
- Instalar Java (JDK 1.8) e modificar a seção JVMCapabilities em /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist com privilégios de root. jdk1.8.x_xxx.jdk depende da sua versão do jdk. Deixe assim: 
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
- Instalar as `Xcode Command Line Tools` de forma independente executando `xcode-select --install`. -- OU -- Alternativamente, se já tiver o [full Xcode installed](https://developer.apple.com/xcode/download/), você pode instalar as Command Line Tools pelo menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalação no Windows**

- Instalar [Node.js](https://nodejs.org/en/download).
- Instalar [Python](https://devguide.python.org/versions/) da [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Instalar Java (JDK 1.8).
- Instalar [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (usando "Visual C++ build tools" se estiver usando uma versão anterior ao VS2019, caso contrário use a carga de trabalho "Desktop development with C++" ou [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) usando a carga de trabalho "Desktop development with C++").


Certifique‑se de que Node.js, Python e Java foram adicionados à variável PATH.

## **Instalação do Aspose.Slides para Node.js via Java na versão 14 ou superior do Node.js**

Basta usar o comando:
```
npm i aspose.slides.via.java
```

## **Instalação do Aspose.Slides para Node.js via Java na versão 12 ou 13 do Node.js**

Aspose.Slides for Node.js via Java precisa ser instalado manualmente. Use o comando a seguir:

- Para Node.js 12:
```
npm i java@0.12.1
```
- Para Node.js 13: 
```
npm i java@0.13.0
```

Depois disso, baixe [aspose.slides.via.java](https://releases.aspose.com/slides/pt/nodejs-java/) e extraia para a pasta `node_modules/aspose.slides.via.java`.

## **Validação da instalação**

Para validar a instalação, crie um arquivo `index.js` na raiz do seu projeto com o seguinte conteúdo:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Execute este arquivo usando o comando `node index.js`.

## **Informações adicionais**

Não é possível cobrir todos os problemas possíveis dentro do escopo deste artigo. Como os problemas surgem devido à compilação dos módulos `java` e `node-gyp`, os links a seguir também serão úteis:
- [java installation](https://www.npmjs.com/package/java#installation) 
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)