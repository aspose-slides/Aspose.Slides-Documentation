---
title: Installation
type: docs
weight: 70
url: /python-java/installation/
keySlides: "Télécharger Aspose.Slides, Installer Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, Linux, Python"
description: "Installer Aspose.Slides pour Python via Java sur Windows, Linux ou macOS"
---

Aspose.Slides pour Python via Java est une API indépendante de la plateforme et peut être utilisée sur n'importe quelle plateforme (Windows, Linux et MacOS) où `Python`, `Java` et le pont `jpype1` sont installés.

## **Exigences pour les programmes et les versions**

Pour assurer le bon fonctionnement d'Aspose.Slides pour Python via Java, les programmes et packages suivants doivent être installés :

- Version JRE >=8 (JPype1 a été testé sur des versions de Java allant de 1.8 à 11).
- Version Python >=3.7,<=3.12.
- Version du package JPype1 : >=1.5.0.

## **Installer depuis pip**

Vous pouvez facilement installer Aspose.Slides pour Python via Java depuis [pip](https://pypi.org/) tant que vous avez tous les programmes requis (Java, Python) installés.

Créez un nouveau dossier de projet.

[Installez JPype1](https://jpype.readthedocs.io/en/latest/install.html) en utilisant la commande suivante :
```
$ pip install JPype1
```

Installez Aspose.Slides pour Python via Java en utilisant la commande suivante :
```
$ pip install aspose-slides-java
```

## **Installer depuis une archive ZIP**

Pour installer et utiliser Aspose.Slides pour Python via Java à partir d'une archive ZIP, suivez plutôt ces instructions :

### **Windows**

1. Installez JDK8 et configurez la variable d'environnement `JAVA_HOME`.
2. [Installez Python](https://www.python.org/downloads/) version >=3.7 et ajoutez python.exe à `PATH`.
3. [Installez Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Installez JPype1](https://jpype.readthedocs.io/en/latest/install.html). Vous pouvez exécuter les commandes ci-dessous dans le terminal python :
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Téléchargez Aspose.Slides pour Python via Java](https://releases.aspose.com/slides/python-java/) et extrayez-le dans `aspose-slides-java`.
6. Créez un fichier nommé `example.py` dans le dossier `aspose-slides-java` en utilisant le code d'exemple suivant :

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. Maintenant, exécutez `py example.py` @invite de commande pour l'exécuter.

### **Linux**

1. Installez JDK8 pour Linux et configurez la variable d'environnement `JAVA_HOME`.
2. [Installez Python](https://www.python.org/downloads/) version >=3.7.
3. Installez `g++` et `python-dev`.

- Pour Debian/Ubuntu :
    ```
    sudo apt-get install g++ python3-dev
    ```
- Pour les systèmes basés sur RedHat :
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Installez JPype1](https://jpype.readthedocs.io/en/latest/install.html). Vous pouvez exécuter les commandes ci-dessous dans le terminal python :
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Téléchargez Aspose.Slides pour Python via Java](https://releases.aspose.com/slides/python-java/) et extrayez-le dans `aspose-slides-java`.
6. Créez un fichier de test nommé `example.py` en utilisant ce code d'exemple dans le dossier `aspose-slides-java` :

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Maintenant, exécutez `py example.py` @invite de commande pour l'exécuter.

### **Mac**

1. Installez JDK8 pour Mac et configurez la variable d'environnement `JAVA_HOME`.
2. Modifiez la section JVMCapabilities dans `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` avec des privilèges root. `jdk1.8.x_xxx.jdk` dépend de votre version de jdk. Faites-le ressembler à ceci :
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Installez Python](https://www.python.org/downloads/) version >=3.7.
4. Installez les compilateurs GCC ou Clang selon la version de Python et la plateforme.
5. [Installez JPype1](https://jpype.readthedocs.io/en/latest/install.html). Vous pouvez exécuter les commandes ci-dessous dans le terminal python :
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Téléchargez Aspose.Slides pour Python via Java](https://releases.aspose.com/slides/python-java/) et extrayez-le dans `aspose-slides-java`.
7. Créez un fichier de test nommé `example.py` en utilisant ce code d'exemple dans le dossier `aspose-slides-java` :

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Maintenant, exécutez `python example.py` @invite de commande pour l'exécuter.