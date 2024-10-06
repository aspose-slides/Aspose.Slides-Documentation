---
title: Résolution des problèmes d'installation d'Aspose.Slides pour Node.js via Java
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "Télécharger Aspose.Slides, Installer Aspose.Slides, Résolution des problèmes d'installation d'Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Résolution des problèmes d'installation d'Aspose.Slides pour Node.js via Java sous Windows, Linux ou macOS"
---

Lorsque vous [installez](/nodejs-java/installation/) `aspose.slides.via.java` en utilisant `npm`, il arrive que des erreurs se produisent lors de la compilation des modules `java` et `node-gyp`. Nous avons examiné ces erreurs plus en détail et identifié des exigences spécifiques pour les versions des programmes et des packages installés.

## **Exigences de version**

1. Pour Node.js 12 et versions antérieures :
   - Python pas supérieur à 3.10.
   - Pour Windows, il est recommandé d'installer Visual Studio Build Tools pas plus récent que 2017.
   - Version du package java npm : 0.12.1.

2. Pour Node.js 13 :
   - Same requirements as for Node.js 12.

3. Pour Node.js 14 :
   - Python 3.10.
   - Version du package java npm : 0.14.0.

4. Pour Node.js 15 :
   - Python 3.12.
   - Version du package java npm : 0.14.0.

5. Pour Node.js 16 et versions ultérieures :
   - Python 3.12.
   - Version du package java npm : 0.14.0.

**Suivez les instructions ci-dessous pour installer les programmes requis.**

### **Installation sur Unix**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/).
- Installez Java (JDK 1.8).
- Installez une chaîne d'outils de compilation C/C++ appropriée, comme [GCC](https://gcc.gnu.org).

### **Installation sur macOS**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/).
- Installez Java (JDK 1.8) et modifiez la section JVMCapabilities dans /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist avec les privilèges administratifs. jdk1.8.x_xxx.jdk dépend de votre version jdk. Faites-le ressembler à ceci : 
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
- Installez les `Xcode Command Line Tools` en exécutant `xcode-select --install`. -- OU -- Alternativement, si vous avez déjà le [Xcode complet installé](https://developer.apple.com/xcode/download/), vous pouvez installer les outils en ligne de commande sous le menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installation sur Windows**

- Installez [Node.js](https://nodejs.org/en/download).
- Installez [Python](https://devguide.python.org/versions/) depuis le [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installez Java (JDK 1.8).
- Installez [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (en utilisant "Visual C++ build tools" si vous utilisez une version antérieure à VS2019, sinon utilisez "Desktop development with C++" workload ou [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) en utilisant le "Desktop development with C++" workload).

Assurez-vous que Node.js, Python et Java sont ajoutés à la variable PATH.

## **Installation d'Aspose.Slides pour Node.js via Java sur Node.js version 14 et versions ultérieures**

Utilisez simplement la commande :
```
npm i aspose.slides.via.java
```

## **Installation d'Aspose.Slides pour Node.js via Java sur Node.js version 12 ou 13**

Aspose.Slides pour Node.js via Java doit être installé manuellement. Utilisez la commande suivante :

- Pour Node.js 12 :
```
npm i java@0.12.1
```
- Pour Node.js 13 : 
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

Exécutez ce fichier en utilisant la commande `node index.js`.

## **Informations supplémentaires**

Il n'est pas possible de couvrir tous les problèmes possibles dans le cadre de cet article. Étant donné que les problèmes surviennent en raison de la compilation des modules `java` et `node-gyp`, les liens suivants seront également utiles :
- [installation de java](https://www.npmjs.com/package/java#installation) 
- [installation de node-gyp](https://www.npmjs.com/package/node-gyp#installation)