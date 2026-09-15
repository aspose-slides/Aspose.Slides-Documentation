---
title: Exporter des présentations au format HTML avec des images liées externes
type: docs
weight: 100
url: /fr/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- exporter diapositive
- exporter PPT
- exporter PPTX
- exporter ODP
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- image liée
- image liée externement
- ressource liée
- ressource externe
- Python
- Java
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument au format HTML en Python à l'aide d'Aspose.Slides avec des images et d'autres ressources enregistrées comme fichiers liés externes."
---
## **Vue d'ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n'est pas toujours le meilleur format pour un site web, un CMS ou un pipeline de conversion côté serveur.

Utilisez des ressources liées externement lorsque vous souhaitez :

- réduire la taille du document HTML ;
- mettre en cache les images, polices, audio ou vidéo séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l'exportation ;
- garder la structure de sortie plus proche de ce qu'une application web attend.

Pour le flux de travail général de conversion HTML, consultez [Convert PowerPoint Presentations to HTML](/slides/fr/python-java/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l'exportation.

## **Comment fonctionne l'exportation des ressources liées**

`ILinkEmbedController` permet à votre application de décider, ressource par ressource, si l'exportateur intègre les données dans le HTML ou les enregistre de façon externe et écrit un lien.

L'interface possède trois méthodes :

- `ILinkEmbedController.getObjectStoringLocation` décide si une ressource doit être liée ou intégrée.
- `ILinkEmbedController.getUrl` renvoie l'URL qui sera écrite dans le HTML généré ou vers une autre ressource liée.
- `ILinkEmbedController.saveExternal` écrit les données de la ressource liée sur le disque ou vers une autre cible de stockage.

Le chemin du système de fichiers et l'URL du navigateur sont des préoccupations distinctes. Par exemple, l'exemple ci‑dessus écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.svg`. Un navigateur résout ces URL par rapport au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu'un lien de ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Exporter du HTML avec des ressources liées**

L'exemple Python suivant crée un répertoire de sortie, enregistre le fichier HTML à cet endroit et stocke les ressources liées dans un sous‑répertoire `assets`. Le contrôleur lie les ressources d'image, de police, audio, vidéo et CSS courantes lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources qui ne sont pas reconnues restent intégrées.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Après l'exportation, le dossier de sortie a la structure suivante :

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Les fichiers exacts dépendent du contenu de la présentation et des options d'exportation. Par exemple, les images raster sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d'image différent de celui utilisé dans la présentation source lorsque cela produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choisir les URL pour le déploiement**

L'exemple utilise un préfixe d'URL relative : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsqu'une ressource liée fait référence à une autre ressource liée, l'exemple utilise le paramètre `referrer` dans `ILinkEmbedController.getUrl` et renvoie uniquement le nom de fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` se trouvent tous deux dans le dossier `assets`, le fichier SVG doit référencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un préfixe d'URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire des actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire des actifs est un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

L'URL renvoyée par `ILinkEmbedController.getUrl` doit correspondre à l'emplacement final déployé du fichier écrit par `ILinkEmbedController.saveExternal`. Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d'objets pour chaque tâche de conversion afin d'éviter d'écraser les fichiers d'un autre export.

## **Quand intégrer à la place**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, par exemple une pièce jointe d'email, un aperçu hors ligne ou un document qui sera déplacé sans dossier d'actifs associé. Les ressources liées sont plus adaptées lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par un pipeline de construction ou mis en cache par les navigateurs de façon indépendante du HTML.

## **FAQ**

**Puis-je externaliser uniquement les images et garder les autres ressources intégrées ?**

Oui. Dans `ILinkEmbedController.getObjectStoringLocation`, renvoyez [LinkEmbedDecision.Link](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linkembeddecision/#Link) uniquement pour les types de contenu que vous souhaitez enregistrer comme fichiers séparés, et renvoyez [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linkembeddecision/#Embed) pour tout le reste.

**Pourquoi l'extension de l'image exportée diffère-t-elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images raster lors de l'exportation HTML afin d'améliorer la taille ou la compatibilité avec les navigateurs. Par exemple, une image provenant du fichier source peut être écrite en JPEG ou PNG selon le résultat rendu.

**Les URL relatives fonctionnent-elles après avoir déplacé le fichier HTML ?**

Les URL relatives ne fonctionnent que lorsque la même structure de dossiers relative est conservée. Si le HTML référence `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML sauf si vous générez un préfixe d'URL différent.

**Les applications serveur doivent-elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque tâche de conversion. Cela évite les collisions de noms de fichiers et empêche un export d'écraser les ressources générées par un autre export.