---
title: Convertir les présentations PowerPoint en Markdown en Python via Java
linktitle: PowerPoint vers Markdown
type: docs
weight: 140
url: /fr/python-java/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en MD
- présentation en MD
- diapositive en MD
- PPT en MD
- PPTX en MD
- enregistrer PowerPoint en Markdown
- enregistrer présentation en Markdown
- enregistrer diapositive en Markdown
- enregistrer PPT en MD
- enregistrer PPTX en MD
- exporter PPT en MD
- exporter PPTX en MD
- exportation d'images Markdown
- liens d'images CDN
- PowerPoint
- présentation
- Markdown
- Python
- Java
- Aspose.Slides
description: "Convertir les présentations PPT et PPTX en Markdown en Python via Java et contrôler où les images bitmap, métafichier et SVG exportées sont enregistrées et référencées."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java peut convertir des présentations PPT et PPTX en Markdown pour la documentation, les sites statiques, la migration de contenu et les flux de travail de contrôle de version. Vous pouvez choisir une variante de Markdown, contrôler la façon dont le contenu des diapositives est rendu et décider où les images exportées sont stockées ainsi que comment le Markdown généré les référence.

Par défaut, l’exportation Markdown utilise une sortie texte uniquement. Pour exporter du contenu visuel, définissez le type d’exportation avec la méthode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setExportType) sur la valeur `Sequential` ou `Visual` de l’énumération [MarkdownExportType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownexporttype/). `Sequential` rend les éléments de la diapositive séparément et dans l’ordre, tandis que `Visual` regroupe les éléments pour préserver leurs relations visuelles. La valeur `TextOnly` n’émet pas de ressources image, de sorte que les rappels de sauvegarde d’image ne sont pas invoqués dans ce mode.

## **Convertir une présentation en Markdown**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) puis appelez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec la valeur `Md` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Chaque exemple lit `presentation.pptx` depuis le répertoire de travail actuel. Installez Aspose.Slides for Python via Java ainsi qu’un runtime Java compatible avant d’exécuter les exemples. Démarrez la JVM une fois par processus Python.

## **Sélectionner une variante de Markdown**

La méthode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setFlavor) contrôle la spécification Markdown utilisée pour la sortie. L’énumération [Flavor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/flavor/) comprend CommonMark, GitHub Flavored Markdown et d’autres variantes prises en charge.

L’exemple suivant exporte une présentation au format CommonMark :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Exporter les images avec le comportement d’enregistrement local par défaut**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/) propose deux méthodes pour configurer les images enregistrées localement :

- [setBasePath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) spécifie le répertoire de base pour le document Markdown et ses ressources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) spécifie le sous‑répertoire des images. Sa valeur par défaut est `Images`.

L’exemple suivant rend le contenu visuel, écrit les images dans `output/assets` et crée des références d’image relatives dans le document Markdown :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Ce comportement sert également de secours lorsqu’un gestionnaire d’enregistrement d’image personnalisé renvoie `False`.

## **Personnaliser l’enregistrement des images et les liens Markdown**

Utilisez la méthode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/) pour enregistrer un rappel destiné aux ressources bitmap et métafile non SVG émises lors de l’exportation Markdown. Son rappel `MarkdownImageSavingHandler` reçoit l’objet image, sa valeur [ImageFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/) et le lien Markdown généré sous forme d’un tableau `String[]` à un seul élément. Enregistrez ou téléversez l’image avec le format fourni, puis remplacez `link[0]` par la référence qui doit apparaître dans la sortie Markdown.

Les ressources émises au format SVG sont gérées séparément. Enregistrez un rappel avec la méthode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/). Son rappel `MarkdownSvgImageSavingHandler` reçoit un objet [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) et le paramètre `String[] link` à un seul élément. Un SVG n’a pas d’argument `ImageFormat` ; écrivez ou téléversez ses données XML à l’aide de la méthode [SvgImage.getSvgData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/#getSvgData). Selon le mode d’exportation et le groupement visuel, un SVG présent dans la présentation source peut être rasterisé ou combiné avec d’autres contenus ; la ressource non SVG résultante est alors transmise au rappel d’enregistrement d’image. Enregistrez les deux rappels lorsque chaque ressource visuelle exportée nécessite un traitement personnalisé.

La valeur de retour du gestionnaire détermine qui traite l’image :

- Retournez `True` après que le gestionnaire a enregistré, téléversé, transformé ou traité l’image et a affecté une valeur valide à `link[0]`. Aspose.Slides écrit cette valeur dans le document Markdown et n’effectue pas son enregistrement local par défaut.
- Retournez `False` pour laisser Aspose.Slides enregistrer l’image localement et générer son lien selon les valeurs définies par [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
Un gestionnaire qui renvoie `True` prend la responsabilité de l’image. S’il renvoie `True` sans attribuer un lien valide et non vide, l’exportation échoue avec une `InvalidOperationException`.
{{% /alert %}}

En Python, enregistrez ces rappels avec `jpype.JProxy`, en implémentant l’interface de rappel Java via sa méthode `invoke`. L’argument `link` est un tableau de chaînes Java mutable : convertissez `link[0]` en chaîne Python avant de le traiter, puis réattribuez l’URL de remplacement à `link[0]`.

### **Enregistrer les images dans un répertoire d’origine CDN et utiliser des URL externes**

L’exemple suivant considère `cdn-origin/presentations/quarterly-report` comme un répertoire d’origine CDN monté ou synchronisé. Chaque gestionnaire extrait le nom de fichier généré, enregistre l’image dans ce répertoire personnalisé et remplace la référence locale générée par une URL CDN publique. L’échantillon ne réalise aucun téléversement réseau : l’URL ne devient valide qu’après que le répertoire a été monté comme origine CDN ou que ses fichiers ont été publiés sur le CDN. Pour le stockage d’objets, remplacez l’écriture sur le système de fichiers par l’opération de téléversement du SDK de stockage et attribuez `link[0]` uniquement après le succès du téléversement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Le gestionnaire de bitmap renvoie délibérément `False` pour les images de moins de 128 × 128 pixels, de sorte qu’Aspose.Slides enregistre ces images dans `output/fallback-images` selon le comportement par défaut. Les ressources bitmap et métafile plus grandes, ainsi que les ressources SVG, sont traitées par le code personnalisé. Par exemple, une référence locale générée telle que `fallback-images/image1.png` devient `https://cdn.example.com/presentations/quarterly-report/image1.png`. Les gestionnaires n’utilisent des chemins propres au système d’exploitation que lors de l’écriture de fichiers ; les liens écrits dans le Markdown utilisent des barres obliques `/` et des noms de fichiers échappés en URL. Appliquez la même règle lors de la création de liens relatifs : utilisez `/`, pas le séparateur de répertoires propre à la plateforme.

## **FAQ**

**Un seul gestionnaire peut‑il traiter à la fois les images raster et les images SVG ?**

Non. Utilisez [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/) pour les ressources bitmap et métafile émises et [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/) pour les ressources émises au format SVG. Le premier fournit un objet image et une valeur [ImageFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/) ; le second fournit un objet [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) dont les données SVG peuvent être lues avec [SvgImage.getSvgData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/#getSvgData). Un SVG source rasterisé lors de l’exportation est traité par le rappel d’enregistrement d’image à la place.

**Que se passe‑t‑il lorsqu’un gestionnaire d’enregistrement d’image renvoie `False` ?**

Aspose.Slides utilise son comportement d’enregistrement local par défaut. L’emplacement de l’image et la référence générée sont contrôlés par les valeurs définies avec [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) et [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Un gestionnaire peut‑il fournir une URL sans enregistrer l’image localement ?**

Oui. Le gestionnaire peut téléverser l’image vers un stockage d’objets ou la transmettre à un autre service, affecter l’URL résultante à `link[0]` et retourner `True`. Le gestionnaire doit alors finaliser le traitement lui‑même ; retourner `True` empêche l’enregistrement local par défaut.

**Pourquoi l’exportation Markdown lève‑t‑elle une `InvalidOperationException` provenant d’un gestionnaire ?**

Cette exception survient lorsque le gestionnaire renvoie `True` mais ne fournit pas de lien valide. Assignez le chemin relatif ou l’URL externe qui doit être écrit dans le Markdown avant de retourner `True`.

**Quel séparateur de chemin les liens d’image doivent‑ils utiliser ?**

Utilisez des barres obliques `/` dans les liens Markdown et les URL. Utilisez `pathlib.Path` uniquement pour les chemins du système de fichiers, puis construisez ou normalisez séparément la référence Markdown.

**Les hyperliens sont‑ils préservés lors de l’exportation Markdown ?**

Oui. Les liens texte [hyperlinks](/slides/fr/python-java/manage-hyperlinks/) sont conservés sous forme de liens Markdown standard. Les [transitions](/slides/fr/python-java/slide-transition/) et [animations](/slides/fr/python-java/powerpoint-animation/) des diapositives ne sont pas converties.

**Peut‑on convertir plusieurs présentations en Markdown en parallèle ?**

Vous pouvez traiter différents fichiers de présentation en parallèle, mais ne partagez pas la même instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) entre les threads. Suivez les [multithreading guidelines](/slides/fr/python-java/multithreading/) et utilisez une instance distincte pour chaque fichier.