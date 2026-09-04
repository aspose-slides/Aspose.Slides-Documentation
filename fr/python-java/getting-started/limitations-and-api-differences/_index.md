---
title: Limitations et différences d'API
type: docs
weight: 100
url: /fr/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides pour Python via Java
- différences d'API
- Python
- Java
- JPype
- limitations de la JVM
- PowerPoint
description: "Apprenez les limitations de la JVM et les différences d'API entre Aspose.Slides for Java et Python via Java, y compris les importations, le nettoyage des ressources et la gestion des fichiers."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java utilise JPype pour accéder à la bibliothèque Java depuis Python. Les exemples ci‑dessous comparent les importations de packages, la création de présentations et la gestion des fichiers dans les deux API.

## **Limitations connues**

- **JVM lifecycle:** JPype prend en charge une JVM par processus Python. Après l'avoir arrêtée, vous ne pouvez pas la redémarrer dans le même processus. Démarrez‑la une fois et réutilisez‑la pour les opérations de présentation ultérieures.
- **Architecture compatibility:** Python et Java doivent avoir des architectures compatibles. Voir les [Exigences système](/slides/fr/python-java/system-requirements/#python-java-and-jpype-requirements) pour plus de détails.

Consultez le [Guide de l'utilisateur JPype](https://jpype.readthedocs.io/en/latest/userguide.html) pour plus de détails sur ces restrictions et l'interopérabilité Java.

## **Différences d'API publiques**

Comparez les exemples Java et Python ci‑dessous. Pour les détails des membres Python via Java, consultez la [Référence API](/slides/fr/python-java/api-reference/).

### **Importer la bibliothèque**

Java importe les classes depuis `com.aspose.slides`. En Python, importez `asposeslides` avant de démarrer la JVM, puis importez les classes depuis `asposeslides.api` après que la JVM soit en cours d'exécution. Utilisez [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) pour éviter de démarrer une JVM déjà en cours.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Les exemples Python laissent la JVM en fonctionnement jusqu'à la fin du processus Python. Dans un notebook, réutilisez la JVM active entre les cellules. Si elle a déjà été arrêtée, redémarrez le noyau du notebook avant d'utiliser à nouveau les objets Java.
{{% /alert %}}

### **Créer une présentation**

Java utilise le mot clé `new` ; Python appelle directement la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Libérez les ressources de la présentation avec [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose) dans un bloc `finally`.

Les deux exemples enregistrent une présentation vide à l'aide de [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) et de [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lire des fichiers et utiliser les constantes de format**

Java peut charger une présentation à partir d'un flux d'entrée Java. En Python, lisez le fichier en tant que données binaires et transmettez les octets résultants à [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#createpresentationfrombytes). Un objet fichier Python n'est pas un flux d'entrée Java.

Les exemples ci‑dessous nécessitent un fichier `presentation.pptx` existant dans le répertoire de travail et enregistrent une copie sous le nom `result.pptx`. Les deux ferment le fichier d'entrée et libèrent les ressources de la présentation. L'exemple Python lit l'intégralité du fichier d'entrée en mémoire.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dois‑je redémarrer la JVM pour chaque présentation ?**

Non. Gardez la JVM en cours d'exécution et créez ou libérez les objets présentation selon les besoins. L'arrêt de la JVM empêche toute autre opération Java dans le même processus Python.

**Puis‑je ouvrir une présentation directement à partir d'un chemin de fichier ?**

Oui. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) accepte un chemin de fichier. Utilisez l'assistant basé sur les octets lorsque les données de la présentation sont déjà disponibles sous forme d'octets Python.

**Dois‑je modifier les noms des constantes de format lors de la traduction des exemples Java en Python ?**

Non. Par exemple, [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#pptx) utilise la même orthographe et capitalisation dans les deux API.