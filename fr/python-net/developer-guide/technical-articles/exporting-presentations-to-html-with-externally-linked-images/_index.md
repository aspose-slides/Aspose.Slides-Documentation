---
title: Exporter des présentations en HTML avec des images liées externes en Python
linktitle: Exporter des présentations en HTML avec des images liées externes
type: docs
weight: 100
url: /fr/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- image liée extérieure
- ressource liée
- ressource externe
- Python
- Aspose.Slides
description: "Exporter les présentations PowerPoint et OpenDocument en HTML en Python à l'aide d'Aspose.Slides avec des images enregistrées comme fichiers liés externes."
---
## **Vue d'ensemble**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n'est pas toujours le meilleur format pour un site web, un CMS ou une chaîne de conversion côté serveur.

Utilisez des images liées externes lorsque vous souhaitez :

- réduire la taille du document HTML ;
- mettre en cache les images séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les images générées après l'exportation ;
- conserver la structure de sortie plus proche de ce qu'une application web attend.

Pour le flux de travail général de conversion HTML, consultez [Convertir des présentations PowerPoint en HTML](/slides/fr/python-net/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des images de l'export.

## **Comment fonctionne l'exportation d'images liées**

Dans .NET et Java, [ILinkEmbedController](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/ilinkembedcontroller/) représente l'interface de rappel utilisée par l'exportateur pour décider si une ressource doit être intégrée ou liée. En Python via .NET, les classes Python ne peuvent actuellement pas implémenter directement cette interface de rappel .NET, ainsi le flux de travail pratique est :

1. Exporter la présentation vers HTML avec [HtmlOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/htmloptions/).
2. Utiliser [SlideImageFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/slideimageformat/) avec [SVGOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/) afin que les diapositives soient représentées en SVG dans le HTML.
3. Déplacer les données d'image Base64 des URL `data:` du HTML vers des fichiers séparés.
4. Remplacer les URL `data:` d'origine par des liens relatifs tels que `assets/resource-1.jpg`.

Le chemin du système de fichiers et l'URL du navigateur sont des préoccupations distinctes. Par exemple, l'exemple ci‑dessous écrit les fichiers image dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives comme `assets/resource-1.jpg`. Un navigateur résout ces URL par rapport au fichier HTML qui contient le lien.

## **Exporter le HTML avec des images liées**

L'exemple Python suivant crée un répertoire de sortie, y enregistre le fichier HTML, stocke les images extraites dans un sous‑répertoire `assets`, et réécrit les URL d'images Base64 en liens relatifs. L'exemple extrait les formats d'image Base64 courants lorsque Aspose.Slides fournit une extension de fichier sûre. Les URL de données non reconnues restent intégrées.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Après l'exportation, le dossier de sortie peut avoir cette structure :

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Les fichiers exacts dépendent du contenu de la présentation et des options d'exportation. Par exemple, les images matricielles sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d'image différent de celui utilisé dans la présentation source lorsqu'il produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choisir les URL pour le déploiement**

L'exemple utilise un préfixe d'URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.jpg`.

Utilisez un nom de répertoire d'actifs différent ou réécrivez les liens générés lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire d'actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire d'actifs est situé un niveau au-dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d'objets pour chaque tâche de conversion afin d'éviter d'écraser les fichiers d'un autre export.

## **Quand intégrer plutôt**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, comme une pièce jointe d'e‑mail, un aperçu hors ligne ou un document qui sera déplacé sans dossier d'actifs associé. Les images liées sont plus appropriées lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par une chaîne de construction ou mis en cache par les navigateurs indépendamment du HTML.

## **FAQ**

**Puis-je externaliser uniquement les images et laisser les autres ressources intégrées ?**

Oui. L'exemple n'extrait que les URL de données Base64 `image/*` dont les types de contenu sont répertoriés dans `EXTENSIONS_BY_CONTENT_TYPE`. Les autres URL de données restent intégrées.

**Pourquoi l'extension de l'image exportée diffère-t-elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l'exportation HTML afin d'améliorer la taille ou la compatibilité avec les navigateurs. Par exemple, une image du fichier source peut être écrite en JPEG ou PNG selon le résultat rendu.

**Les URL relatives fonctionnent-elles après avoir déplacé le fichier HTML ?**

Les URL relatives ne fonctionnent que si la même structure de dossiers relative est préservée. Si le HTML fait référence à `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML à moins que vous ne génériez un préfixe d'URL différent.

**Les applications serveur doivent-elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque tâche de conversion. Cela évite les collisions de noms de fichiers et empêche un export d'écraser les ressources générées par un autre export.