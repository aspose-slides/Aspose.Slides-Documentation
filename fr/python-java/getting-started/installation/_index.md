---
title: Installation
type: docs
weight: 70
url: /fr/python-java/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installez Aspose.Slides for Python via Java sur Windows, Linux ou macOS, configurez Java et JPype, et vérifiez l'installation avec un exemple fonctionnel."
---
Aspose.Slides for Python via Java fonctionne sous Windows, Linux et macOS. Il utilise JPype pour accéder à la bibliothèque Java depuis Python. Microsoft PowerPoint n'est pas requis.

## **Prérequis**

Avant d'installer les packages Python, installez Python et un JDK qui répond aux [Exigences du système](/slides/fr/python-java/system-requirements/). Cette page répertorie les versions compatibles, les exigences d'architecture et les dépendances nécessaires pour compiler JPype à partir du code source.

Définissez `JAVA_HOME` sur le répertoire d'installation du JDK, pas sur son sous-repertoire `bin`, et ajoutez le répertoire `bin` du JDK à `PATH`. Ouvrez un nouveau terminal après avoir modifié les variables d'environnement.

## **Installer depuis PyPI**

Exécutez les commandes suivantes dans un terminal, et non dans l'invite interactive de Python. Créez un répertoire de projet et un environnement virtuel pour garder les packages isolés des autres projets.

### **Windows**

Lorsque votre interpréteur Python choisi est disponible sous le nom `python` dans le `PATH`, exécutez les commandes suivantes dans l'invite de commandes:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux et macOS**

Lorsque votre version Python choisie est disponible sous le nom `python3`, exécutez les commandes suivantes dans Bash ou zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Sur Debian ou Ubuntu, si la création de l'environnement échoue parce que `ensurepip` n'est pas disponible, installez le paquet `python3-venv` avec `sudo apt-get install python3-venv`, puis répétez la commande de création d'environnement. Une version de Python installée séparément peut nécessiter le paquet `venv` correspondant à sa version.

### **Installer les packages**

Avec l'environnement virtuel activé, installez JPype et Aspose.Slides :

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

L'utilisation de `python -m pip` garantit que les packages sont installés pour l'interpréteur utilisé pour exécuter votre application.

Pour mettre à jour une installation existante d'Aspose.Slides, exécutez `python -m pip install --upgrade aspose-slides-java` dans le même environnement.

## **Installer depuis une archive ZIP**

Vous pouvez également utiliser la bibliothèque depuis la [page de téléchargement d'Aspose.Slides](https://releases.aspose.com/slides/fr/python-java/) :

1. Installez Python et Java comme décrit dans les [Prérequis](#prerequisites).
2. Créez et activez un environnement virtuel en suivant les instructions ci-dessous.
3. Installez JPype avec `python -m pip install JPype1`.
4. Téléchargez et extrayez l'archive ZIP d'Aspose.Slides for Python via Java.
5. Localisez le répertoire du package `asposeslides` extrait. Conservez son contenu, y compris le répertoire `lib` et le fichier JAR, ensemble.
6. Placez `example.py` de la section suivante à côté du répertoire `asposeslides` afin que Python puisse importer le package.

## **Vérifier l'installation**

Enregistrez le code suivant sous le nom `example.py`. Il crée une présentation avec une zone de texte et l'enregistre sous `out.pptx` dans le répertoire de travail actuel.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Avec l'environnement virtuel activé, exécutez l'exemple depuis le répertoire contenant `example.py` :

```sh
python example.py
```

L'importation `asposeslides` enregistre la bibliothèque Java fournie avant le démarrage de la JVM. Importez `asposeslides.api` après le démarrage de la JVM, et libérez les ressources de la présentation avant de l'arrêter.

{{% alert color="info" title="Note" %}}
Sans licence, la sortie inclut un filigrane d'évaluation. Voir [Évaluer Aspose.Slides](/slides/fr/python-java/evaluate-aspose-slides/) pour les limitations d'évaluation et les informations sur la licence temporaire.
{{% /alert %}}

## **FAQ**

**Pourquoi Python indique-t-il que la JVM est introuvable ou ne peut pas être chargée ?**

Vérifiez que `JAVA_HOME` pointe vers un JDK compatible avec votre installation de Python et JPype, comme décrit dans les [Exigences du système](/slides/fr/python-java/system-requirements/). Consultez le [guide de dépannage de l'installation de JPype](https://jpype.readthedocs.io/en/latest/install.html) pour des vérifications supplémentaires.

**Pourquoi Python indique-t-il que `asposeslides` est absent après l'installation ?**

Le package a peut-être été installé pour un interpréteur Python différent. Activez l'environnement virtuel utilisé pour l'installation et exécutez `python -m pip show aspose-slides-java`. Pour une installation ZIP, assurez-vous que le répertoire `asposeslides` se trouve à côté de votre script ou qu'il soit autrement disponible dans le chemin de recherche des modules de Python.

**Puis-je exécuter l'exemple de façon répétée dans un notebook ?**

L'exemple est destiné à un processus Python autonome. Avant de l'adapter pour une exécution répétée dans un notebook, consultez les [Limitations et différences d'API](/slides/fr/python-java/limitations-and-api-differences/#import-the-library) concernant le cycle de vie de la JVM et les recommandations pour les notebooks.

**Pourquoi pip échoue-t-il avec `CERTIFICATE_VERIFY_FAILED` ?**

Si votre réseau utilise un proxy d'inspection HTTPS, pip doit faire confiance à son autorité de certification. Configurez le bundle CA de confiance en utilisant l'option `--cert` de pip ou la variable d'environnement `PIP_CERT`, en suivant les [instructions de certificat HTTPS de pip](https://pip.pypa.io/en/stable/topics/https-certificates/). La configuration requise dépend de votre réseau et de la version de pip.