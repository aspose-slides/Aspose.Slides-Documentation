---
title: Installation
type: docs
weight: 70
url: /fr/nodejs-java/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Installez Aspose.Slides pour Node.js via Java depuis npm sur Windows, Linux et macOS : le JDK, Python et les outils de construction C++ nécessaires, la commande npm et un premier script pour vérifier l'installation."
---
## **Vue d'ensemble**

Cet article explique comment installer Aspose.Slides pour Node.js via Java sur Windows, Linux et macOS, et comment vérifier que l'installation fonctionne.

Aspose.Slides for Node.js via Java est distribué sous forme du package `aspose.slides.via.java` sur npm. Il exécute Aspose.Slides dans une machine virtuelle Java via le package [`java`](https://github.com/joeferner/node-java), un module natif Node.js que npm compile sur votre ordinateur lors de l'installation. C'est pourquoi l'installation nécessite, en plus de Node.js :

- **Un Kit de développement Java (JDK) 8 ou supérieur.** Un simple environnement d'exécution Java ne suffit pas : la construction nécessite les fichiers d'en-tête du JDK.
- **Python 3**, utilisé par l'outil de construction [node-gyp](https://github.com/nodejs/node-gyp).
- **Une chaîne d'outils de construction C++** pour votre système d'exploitation.

## **Installer les prérequis**

### **Windows**

1. Installez [Node.js](https://nodejs.org/en/download) 20 ou ultérieur.  
1. Installez un JDK, par exemple [Eclipse Temurin](https://adoptium.net/), et définissez la variable d'environnement `JAVA_HOME` sur son dossier d'installation. La construction utilise le JDK auquel pointe `JAVA_HOME`.  
1. Installez [Python 3](https://www.python.org/downloads/).  
1. Installez les [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) avec la charge de travail **Desktop development with C++**. Conservez les composants par défaut de la charge de travail, qui comprennent **MSVC v143 - VS 2022 C++ x64/x86 build tools** et le **Windows 11 SDK**. Visual Studio 2026 ne fonctionne pas : la version de node-gyp avec laquelle le package `java` est compilé ne le reconnaît pas.

### **Linux**

Installez Node.js 20 ou ultérieur depuis [nodejs.org](https://nodejs.org/en/download) ou la source de paquets de votre distribution. Puis installez un JDK, Python 3 et les outils de construction C++. Sur Debian et Ubuntu :

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Sur Linux, la construction trouve le JDK installé sans configuration supplémentaire. Si plusieurs JDK sont installés, définissez `JAVA_HOME` sur celui que vous souhaitez utiliser.

### **macOS**

Installez Node.js 20 ou ultérieur, un JDK et les outils en ligne de commande Xcode, qui incluent Python 3 et le compilateur C++. Consultez [Troubleshooting Installation](/slides/fr/nodejs-java/troubleshooting-installation/) pour les notes spécifiques à macOS.

## **Installer depuis npm**

Créez un dossier de projet et installez le package :

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm télécharge Aspose.Slides et compile le pont `java`, ce qui peut prendre quelques minutes. Si la compilation échoue, consultez [Troubleshooting Installation](/slides/fr/nodejs-java/troubleshooting-installation/).

## **Vérifier l'installation**

Créez un fichier nommé *hello.js* dans le dossier du projet avec le code suivant. Il crée une présentation, ajoute une zone de texte à la première diapositive et enregistre le résultat sous le nom *hello.pptx* :

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

// Aspose.Slides s'exécute dans une machine virtuelle Java qui maintient Node.js en cours d'exécution, il faut donc terminer le processus explicitement.
process.exit(0);
```

Exécutez le script :

```bash
node hello.js
```

Si *hello.pptx* apparaît dans le dossier du projet, l'installation fonctionne. La machine virtuelle Java qui exécute Aspose.Slides empêche Node.js de se terminer automatiquement, c'est pourquoi le script se termine par `process.exit(0)`. [Create Presentations](/slides/fr/nodejs-java/create-presentation/) explique le code.

## **Installer depuis une archive ZIP**

Le package est également disponible sous forme d'archive ZIP contenant les mêmes éléments que le package npm. Pour l'installer depuis l'archive :

1. Installez les prérequis pour votre système d'exploitation, comme décrit ci-dessus.  
1. Téléchargez l'archive depuis la [page de téléchargement Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/).  
1. Créez un dossier de projet :

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Extrayez l'archive dans un sous-dossier nommé *aspose.slides.via.java* à l'intérieur du dossier du projet, de sorte que le *package.json* de l'archive se trouve à *hello-slides/aspose.slides.via.java/package.json*.  
1. Installez le package depuis ce dossier :

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installe le pont `java` dont dépend le package et le compile, comme il le fait pour le package npm.

1. Vérifiez l'installation comme décrit dans [Check the Installation](#check-the-installation).

## **FAQ**

**Existe-t-il une version gratuite ou une limitation d'essai ?**

Oui. Sans licence, Aspose.Slides s'exécute en mode d'évaluation : il ajoute un filigrane d'évaluation à chaque diapositive enregistrée et tronque le texte lu à partir des présentations. Pour supprimer ces limitations, appliquez une [licence](/slides/fr/nodejs-java/licensing/) valide.

**Pourquoi mon script ne se termine-t-il pas après son exécution ?**

Le package `java` démarre une machine virtuelle Java à l'intérieur du processus Node.js, et cette machine virtuelle maintient le processus en cours d'exécution. Appelez `process.exit` lorsque votre script a terminé son travail.