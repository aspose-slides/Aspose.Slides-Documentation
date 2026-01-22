---
title: Dépannage de l'installation d'Aspose.Slides pour Node.js via Java
linktitle: Dépannage de l'installation
type: docs
weight: 75
url: /fr/nodejs-java/troubleshooting-installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- résolution des problèmes d'installation
- exigences de version
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Déboguez les problèmes d'installation d'Aspose.Slides pour Node.js via Java, corrigez les erreurs et dépendances courantes, et assurez un fonctionnement fluide avec PPT, PPTX et ODP."
---

Lorsque vous [installez](/slides/fr/nodejs-java/installation/) `aspose.slides.via.java` en utilisant `npm`, il arrive que des erreurs surviennent lors de la compilation des modules `java` et `node-gyp`. Nous avons étudié ces erreurs plus en détail et identifié des exigences spécifiques pour les versions des programmes et packages installés. 

## **Exigences de version**

1. Pour Node.js 12 et antérieurs:
   - Python ne doit pas être supérieur à 3.10.
   - Sous Windows, il est recommandé d'installer Visual Studio Build Tools pas plus récent que 2017.
   - version du package npm java: 0.12.1.

2. Pour Node.js 13:
   - Même exigences que pour Node.js 12.

3. Pour Node.js 14:
   - Python 3.10.
   - version du package npm java: 0.14.0.

4. Pour Node.js 15:
   - Python 3.12.
   - version du package npm java: 0.14.0.

5. Pour Node.js 16 et plus récents:
   - Python 3.12.
   - version du package npm java: 0.14.0.

**Suivez les instructions ci-dessous pour installer les programmes requis.**

### **Installation sur Unix**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/).
- Installez Java (JDK 1.8).
- Installez une chaîne d'outils de compilation C/C++ appropriée, comme [GCC](https://gcc.gnu.org).

### **Installation sur macOS**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/).
- Installez Java (JDK 1.8) et modifiez la section JVMCapabilities dans /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist avec les privilèges root. jdk1.8.x_xxx.jdk dépend de votre version de jdk. Faites-le ressembler à ceci:
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

- Installez les `Xcode Command Line Tools` en tant que programme autonome en exécutant `xcode-select --install`. -- OR -- Alternativement, si vous avez déjà le [Xcode complet installé](https://developer.apple.com/xcode/download/), vous pouvez installer les Command Line Tools via le menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installation sur Windows**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/) depuis le [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installez Java (JDK 1.8).
- Installez [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (en utilisant "Visual C++ build tools" si vous utilisez une version antérieure à VS2019, sinon utilisez la charge de travail "Desktop development with C++" ou [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) en utilisant la charge de travail "Desktop development with C++").

Assurez-vous que Node.js, Python et Java sont ajoutés à la variable PATH.

## **Installation d'Aspose.Slides pour Node.js via Java sur la version 14 et supérieure de Node.js**

Utilisez simplement la commande :
```
npm i aspose.slides.via.java
```


## **Installation d'Aspose.Slides pour Node.js via Java sur la version 12 ou 13 de Node.js**

Aspose.Slides pour Node.js via Java doit être installé manuellement. Utilisez la commande suivante :

- Pour Node.js 12:
```
npm i java@0.12.1
```

- Pour Node.js 13:
```
npm i java@0.13.0
```


Après cela, téléchargez [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) et extrayez-le dans le dossier `node_modules/aspose.slides.via.java`.

## **Validation de l'installation**

Pour valider l'installation, créez un fichier `index.js` à la racine de votre projet avec le contenu suivant :
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


Exécutez ce fichier avec la commande `node index.js`.

## **Informations complémentaires**

Il n'est pas possible de couvrir tous les problèmes possibles dans le cadre de cet article. Comme les problèmes proviennent de la compilation des modules `java` et `node-gyp`, les liens suivants seront également utiles :
- [installation de java](https://www.npmjs.com/package/java#installation) 
- [installation de node-gyp](https://www.npmjs.com/package/node-gyp#installation)