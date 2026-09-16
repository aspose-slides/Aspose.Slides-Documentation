---
title: Exporter des présentations vers XAML avec Python
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/python-net/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
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
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Python en utilisant Aspose.Slides — solution rapide, sans Office, qui préserve la mise en page."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l'aide d'Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation en XAML avec les paramètres par défaut, et démontre comment personnaliser l'exportation via [XamlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/), y compris l'exportation des diapositives masquées. L'article répond également à quelques questions fréquentes concernant les polices de secours, la compatibilité des piles XAML et le comportement d'exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec les fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations vers XAML avec les options par défaut**

L'exemple Python suivant montre comment exporter une présentation en XAML avec les paramètres par défaut :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du processus, tel que renvoyé par [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Le dossier est créé automatiquement, et toutes les images nécessaires y sont également enregistrées.

Le nom du dossier de sortie provient du nom du fichier source sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu vers la présentation d'entrée, le dossier de sortie est créé relativement au répertoire de travail actuel, et non à côté du fichier d'entrée.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez la classe [XamlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation en XAML.

Pour inclure les diapositives masquées dans la sortie XAML, définissez la propriété [export_hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) sur `True`, comme illustré dans l'exemple Python suivant :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images séparées et des ressources de soutien. Conservez tous ces fichiers lors du stockage ou de la transmission d’une exportation.

Les exemples ci‑dessous utilisent le sauvegardeur de système de fichiers par défaut dans un répertoire temporaire, puis collectent les fichiers générés.

### **Comprendre le cycle de vie de l'exportation**

- Lancez l'exportation avec la surcharge spécifique à XAML de [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) qui accepte les options XAML. Lisez les fichiers générés uniquement après le retour réussi de la méthode.
- Conservez le chemin relatif de chaque artefact car XAML peut référencer des ressources à l'aide de chemins relatifs.
- Lisez les artefacts en tant que octets. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Signalez le succès global uniquement après que la collecte et toute opération de stockage subséquente soient terminées. Laissez les erreurs de stockage remonter à l’appelant et nettoyez les sorties partielles si la persistance échoue.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) vaut par défaut `False`, ce qui exclut les documents XAML des diapositives masquées. Le définir sur `True` les inclut ainsi que toutes les ressources nécessaires à leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un fichier par diapositive.

{{% alert color="warning" title="Warning" %}}
Les exemples modifient temporairement le répertoire de travail actuel du processus, ce qui affecte tous les threads. Exécutez chaque exportation dans un processus de travail dédié, ou assurez‑vous qu’aucune autre tâche du processus ne dépend du répertoire courant pendant l’exportation. Un répertoire temporaire unique ne rend pas les exportations concurrentes dans le même processus sûres.
{{% /alert %}}

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, l'exporte vers un répertoire temporaire, collecte chaque artefact dans un dictionnaire de noms relatifs et d’octets, puis affiche son nom, son type et son nombre d’octets. Il préserve la structure de répertoires générée et supprime les fichiers temporaires après la collecte. Le chemin d'entrée est résolu avant de changer le répertoire de travail.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Décoder uniquement le XAML, et uniquement lorsque l'inspection textuelle est nécessaire.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Les vérifications d'extension sont utiles pour l’inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Décodifiez uniquement le XAML qui nécessite un traitement textuel. Cette approche utilise à la fois l'espace disque temporaire et la mémoire pour l'exportation collectée.

### **Emballez les artefacts collectés dans une archive ZIP**

Cet exemple autonome collecte l'exportation, valide ses noms et écrit les octets originaux dans une archive ZIP. Un nom d'archive unique sépare les travaux d'exportation. Les entrées ZIP utilisent des barres obliques avant et conservent les répertoires relatifs. Les noms dangereux ou les collisions après normalisation rejettent l’ensemble du paquet avant écriture.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Le répertoire ZIP a été finalisé avant de signaler le succès.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

L’exemple utilise [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) pour écrire une archive locale après la collecte de l’exportation temporaire. Pour le stockage à distance, remplacez l’étape d’écriture d’archive par des téléchargements des octets collectés. Utilisez un identifiant de travail d’exportation plus le nom d’artefact relatif complet comme clé d’objet, ou stockez l’identifiant du travail, le nom relatif et les données binaires dans une ligne de base de données. Publiez le travail uniquement après que tous les téléchargements soient terminés ou que la transaction de base de données soit validée. Nettoyez les sorties partielles si la persistance échoue.

Pour les présentations volumineuses, traitez les fichiers temporaires un par un après l’exportation au lieu de collecter tous leurs octets dans un dictionnaire. Cela évite une copie supplémentaire en mémoire de l’ensemble de l’exportation, mais n’élimine pas les exigences de mémoire de l’exportateur lui‑même.

### **Conserver les noms de ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination le nécessite, mais conservez les répertoires relatifs. Ne conservez pas uniquement le nom de fichier final sauf si chaque nom généré est connu pour être unique et que les références aux ressources restent valides.
- Appliquez la validation des noms propre à la destination. Lors de l’écriture de fichiers isolés, rejetez les chemins absolus et les segments de traversée, résolvez la destination et vérifiez qu’elle reste en dessous du répertoire d’exportation prévu. Utilisez un répertoire contrôlé par l’application sans liens symboliques susceptibles de rediriger les écritures.
- Utilisez un espace de noms de stockage séparé pour chaque travail d’exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse du système de destination.
- Avant la publication, analysez chaque document XAML en tant que XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs `Source` ou `ImageSource` d’image. Résolvez chaque URI relative par rapport au répertoire de l’artefact XAML contenant, normalisez le nom de stockage résultant et confirmez que la clé du dictionnaire correspondante, l’entrée ZIP ou l’objet stocké existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` référence `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver seulement `image1.png` casserait cette relation. Pour le stockage d’objets, préservez la même arborescence sous le préfixe du travail et rendez ces URLs de ressources accessibles au consommateur XAML. Rouvrez le ZIP complet pour vérifier les noms des entrées et les octets des ressources, puis chargez des diapositives représentatives dans l’environnement XAML cible afin de confirmer que les images sont résolues correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d’origine n’est pas disponible sur la machine ?**

Définissez [default_regular_font](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) dans [XamlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/) — elle est utilisée comme police de secours pendant l’exportation lorsque l’originale manque. Cela ne garantit pas que le XAML généré référence la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient présentes dans l’environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF ou peut‑il être utilisé dans d’autres piles XAML ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d’autres piles XAML, telles que UWP et Xamarin.Forms, n’est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [export_hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) dans [XamlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export.xaml/xamloptions/) — laissez‑la désactivée si vous n’avez pas besoin de les exporter.