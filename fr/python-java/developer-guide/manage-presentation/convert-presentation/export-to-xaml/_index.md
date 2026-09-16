---
title: Exporter des présentations au XAML en Python via Java
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/python-java/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter la présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir la présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- Python
- Java
- Aspose.Slides
description: "Exporter les présentations PowerPoint et OpenDocument au XAML avec Aspose.Slides pour Python via Java. Utilisez les options par défaut ou incluez les diapositives masquées."
---
## **Vue d’ensemble**

Cet article explique comment exporter des présentations PowerPoint au format XAML à l'aide d'Aspose.Slides pour Python via Java. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation au format XAML avec les paramètres par défaut et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions courantes concernant les polices de secours, la compatibilité des piles XAML et le comportement d'exportation des diapositives masquées.

Les exemples nécessitent Aspose.Slides pour Python via Java ainsi qu'un runtime Java compatible. Placez `pres.pptx` dans le répertoire de travail actuel. Chaque exemple démarre la JVM uniquement si elle n'est pas déjà en cours d'exécution.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations au XAML avec les options par défaut**

L'exemple Python suivant montre comment exporter une présentation au XAML avec les paramètres par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Par défaut, les diapositives exportées sont enregistrées dans un sous-dossier `pres` du répertoire de travail actuel du processus. Le dossier est créé automatiquement, et toutes les images nécessaires y sont également enregistrées.

Le nom du dossier de sortie est dérivé du nom du fichier source, sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu vers la présentation d'entrée, le dossier de sortie est créé relativement au répertoire de travail actuel, plutôt qu'à côté du fichier d'entrée.

## **Exporter des présentations au XAML avec des options personnalisées**

Utilisez la classe [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation au XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez `IXamlOutputSaver` et transmettez une instance de votre implémentation à la méthode [setOutputSaver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) avec `True`, comme le montre l'exemple Python suivant :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images séparées et des ressources de support. Assignez un `IXamlOutputSaver` personnalisé à [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setOutputSaver) pour recevoir ces artefacts au lieu d'utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l'exportation avec la surcharge spécifique XAML de [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) qui accepte les options XAML.

En Python, utilisez `jpype.JProxy` pour implémenter l'interface Java `IXamlOutputSaver`. Convertissez le chemin du rappel en `str` et copiez le tableau d'octets Java vers des `bytes` Python avant de retourner, comme démontré ci-dessous.

### **Comprendre le cycle de vie du rappel**

- `path` identifie l'artefact et peut inclure des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources en utilisant des chemins relatifs.
- `data` contient les octets de l'artefact. Les images et autres ressources binaires ne doivent pas être décodées comme du texte.
- Le sauvegardeur est responsable de conserver ou de persister les données avant de retourner. Les exemples copient chaque tableau d'octets dans une mémoire appartenant à l'application.
- Considérez l'exportation comme réussie uniquement lorsque l'opération d'enregistrement de la présentation retourne et que chaque rappel s'est terminé avec succès. Ne masquez pas les erreurs de stockage ni ne lancez d'écritures en arrière-plan non observées. Si la persistance se produit après, ne signalez le succès global qu'après que cette étape a également réussi.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) s'applique également à un sauvegardeur personnalisé. Le réglage par défaut, `False`, exclut les documents XAML de diapositives masquées. Passer `True` les inclut ainsi que toutes les ressources nécessaires à leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ou un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un dictionnaire Python de noms et de valeurs `bytes` immuables, et affiche son nom, son type et le nombre d'octets. Il conserve exactement les noms fournis. Les noms en double marquent la collection comme invalide plutôt que d'écraser silencieusement un artefact. L'exemple vérifie cela avant d'utiliser les résultats.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Décoder uniquement le XAML, et uniquement lorsque l'inspection textuelle est nécessaire.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Les vérifications d'extension sont utiles pour l'inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez `bytes.decode` avec UTF-8 uniquement pour le XAML nécessitant un traitement textuel.

### **Emballez les artefacts collectés dans une archive ZIP**

Cet exemple indépendant collecte l'exportation, valide ses noms et écrit les octets originaux dans une archive ZIP. Un nom d'archive unique sépare les travaux d'exportation concurrents. Les entrées ZIP utilisent des barres obliques avant et conservent les répertoires relatifs. Les noms dangereux ou ceux qui entrent en conflit après normalisation rejettent l'ensemble du paquet avant son écriture.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpime.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # La fermeture finalise le répertoire ZIP avant que le succès ne soit signalé.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

L'exemple utilise `zipfile.ZipFile` de Python pour écrire une archive locale ; l'exportateur lui‑même n'écrit pas de fichiers XAML ou image séparés. Pour le stockage à distance, remplacez l'étape d'écriture d'archive par des téléchargements des tableaux d'octets collectés. Utilisez un identifiant de travail d'exportation plus le nom d'artefact relatif complet comme clé de blob, ou stockez l'identifiant du travail, le nom relatif et les données binaires dans une ligne de base de données. Publiez le travail seulement après que tous les téléchargements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle en cas d'échec de persistance.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l'application afin d'éviter de conserver une copie supplémentaire de l'exportation complète en mémoire. Gardez chaque rappel synchrone du point de vue de l'exportateur : ne retournez qu'après que la destination a accepté les octets, et laissez les échecs remonter à l'appelant.

### **Conserver les noms des ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l'exige, mais conservez les répertoires relatifs. N'utilisez pas uniquement `pathlib.Path.name` à moins que chaque nom généré ne soit connu pour être unique et que les références de ressources restent valides.
- Appliquez une validation de nom spécifique à la destination. Lors de l'écriture de fichiers séparés, rejetez les chemins absolus et les segments de traversée, résolvez la destination avec `pathlib.Path.resolve` et vérifiez qu'elle reste sous le répertoire d'exportation prévu, y compris le séparateur de répertoire dans le contrôle de confinement. Utilisez un répertoire contrôlé par l'application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage séparés pour chaque travail d'exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant la publication, analysez chaque document XAML comme XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs d'image `Source` ou `ImageSource`. Résolvez chaque URI relative par rapport au répertoire de l'artefact XAML contenant, normalisez le nom de stockage résultant et confirmez que la clé de carte, l'entrée ZIP ou l'objet stocké correspondant existe. Traitez les URI externes et les expressions de balisage XAML séparément des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` référence `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver uniquement `image1.png` casserait cette relation. Pour le stockage d'objets, conservez la même structure sous le préfixe du travail et rendez ces URL de ressources accessibles au consommateur XAML. Rouvrez le ZIP complet pour vérifier les noms d'entrées et les octets des ressources, et chargez des diapositives représentatives dans l'environnement XAML cible afin de confirmer que les images sont correctement résolues.

## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Appelez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions] — il est utilisé comme police de secours lors de l'exportation lorsque la police d'origine est absente. Cela ne garantit pas que le XAML généré référence la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML sont disponibles dans l'environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d'autres piles XAML également ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d'autres piles XAML, comme UWP et Xamarin.Forms, n'est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment puis‑je empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) dans [XamlOptions] — laissez‑le désactivé si vous n'avez pas besoin de les exporter.