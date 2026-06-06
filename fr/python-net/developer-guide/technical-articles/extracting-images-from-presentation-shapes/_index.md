---
title: Extraire des images des formes de présentation en Python
linktitle: Image depuis forme
type: docs
weight: 90
url: /fr/python-net/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET - solution rapide et conviviale pour le code."
---
## **Vue d'ensemble**

Les images d’une présentation peuvent apparaître dans plusieurs types de formes : en tant que cadres d’image ordinaires, comme remplissages d’image appliqués aux formes, comme images d’aperçu d’objet OLE, comme miniatures de trames vidéo ou audio, comme images de zoom, ou comme images imbriquées dans les formes tableau, graphique et SmartArt. Aspose.Slides stocke ces images dans la collection d’images de la présentation, exposée via les objets [ImageCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/) et [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/).

Si vous avez seulement besoin d’exporter chaque ressource d’image intégrée dans une présentation, parcourez `presentation.images`. Cet article se concentre sur une tâche différente : parcourir les formes pour détecter où les images sont utilisées dans les diapositives, afin que les fichiers enregistrés conservent un contexte utile tel que le numéro de diapositive, la position de la forme et le type de source (cadre d’image, image de remplissage, aperçu multimédia, aperçu OLE ou image de zoom).

{{% alert title="Tip" color="primary" %}}
Utilisez la propriété `binary_data` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) pour préserver les données d’image encodées d’origine et le type de fichier. Utilisez la propriété `image` avec `save` lorsque vous souhaitez normaliser la sortie vers un format spécifique tel que PNG.
{{% /alert %}}

## **Méthodes d’aide partagées**

Les méthodes d’assistance ci‑dessous raccourcissent les exemples. `save_original_image` écrit les octets intégrés d’origine, choisit une extension sûre à partir du type MIME et ignore les binaires d’image dupliqués grâce à un hachage SHA‑256.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Extraire les images des cadres d’image**

Utilisez cette approche pour les images insérées comme objets autonomes. Un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) stocke son image dans `picture_format.picture.image`, qui renvoie un objet [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Extraire les images des formes remplies d’image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d’abord le type de remplissage de la forme : s’il n’est pas [FillType.PICTURE](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/), il n’y a aucune image à extraire de ce remplissage. L’exemple ci‑dessous gère les objets [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/) et enregistre chaque image au format PNG via la propriété `image` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Extraire les images d’aperçu des cadres d’objet OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/oleobjectframe/) peut disposer d’une image de substitution que PowerPoint utilise comme aperçu de l’objet sur une diapositive. Cette image est accessible via `substitute_picture_format.picture.image`. Extraire cette image vous donne l’aperçu, et non le contenu du package OLE intégré.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images d’aperçu des cadres vidéo**

Un [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) peut également stocker une image d’aperçu dans `picture_format.picture.image`. Il s’agit du poster ou de la vignette affichée sur la diapositive, pas d’une trame décodée du flux vidéo.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images d’aperçu des cadres audio**

Un [AudioFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/) peut stocker une vignette dans `picture_format.picture.image`. Il s’agit de l’image affichée pour l’objet audio sur la diapositive.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images des objets de zoom**

[ZoomFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/zoomframe/) et [SectionZoomFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sectionzoomframe/) peuvent utiliser des images personnalisées. Lisez `zoom_image` depuis le cadre de zoom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Extraire les images des cadres de zoom de sommaire**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/summaryzoomframe/) est également une forme. Ses éléments de section peuvent utiliser des images personnalisées, exposées via la propriété `zoom_image` de chaque section de zoom de sommaire.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images des formes tableau**

Un [Table](https://reference.aspose.com/slides/fr/python-net/aspose.slides/table/) est une forme. Les images dans un tableau sont généralement stockées comme remplissages d’image dans les cellules du tableau.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images des formes graphique**

Un [Chart](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/) est une forme. L’exemple ci‑dessus extrait une image du remplissage d’image de la zone du graphique.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extraire les images des formes SmartArt**

Un [SmartArt](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartart/) est une forme. Selon la mise en page SmartArt, les images peuvent être stockées dans les remplissages de puces des nœuds ou dans les formats de remplissage des formes de nœuds.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Inclure les images à l’intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. L’assistance partagée `enumerate_shapes` possède une option `include_grouped_shapes`. Définissez‑la sur `True` lorsque vous voulez inspecter les formes à l’intérieur des objets [GroupShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/groupshape/). L’exemple ci‑dessus extrait les images des cadres d’image, des formes remplies d’image, des aperçus d’objet OLE, des miniatures de cadres vidéo et audio. Pour inclure également les images de tableau, graphique, SmartArt et zoom de sommaire, réutilisez la logique d’extraction spécialisée des sections précédentes tout en conservant le même parcours récursif des formes.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Cas limites et notes pratiques**

- **Images en double :** plusieurs formes peuvent référencer la même image ou des images distinctes ayant des octets identiques. Hachez la propriété `binary_data` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) avant d’écrire les fichiers si vous voulez un fichier de sortie par image unique.  
- **Données d’origine vs. sortie convertie :** enregistrer la propriété `binary_data` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) préserve les données JPEG, PNG, GIF, SVG, EMF ou WMF intégrées. Enregistrer la propriété `image` via `save` est utile lorsque vous désirez un format de sortie cohérent.  
- **Types de remplissage non pris en charge :** les formes à remplissage plein, dégradé, motif ou sans remplissage ne contiennent pas de remplissage d’image. Vérifiez [FillType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) avant de lire `picture_fill_format`.  
- **Formes groupées :** la collection de formes de la diapositive de niveau supérieur ne « aplatit » pas les groupes. Inspectez récursivement [GroupShape.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/groupshape/shapes/) lorsque le contenu groupé importe.  
- **Aperçus d’objets OLE :** un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/oleobjectframe/) peut exposer une image d’aperçu via `substitute_picture_format`, mais cette image n’est que l’aperçu de la diapositive. Ce n’est pas le fichier intégré à l’intérieur de l’objet OLE.  
- **Vignettes de cadres vidéo :** un [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) peut exposer une image d’aperçu via `picture_format`, mais cette image n’est que le poster affiché sur la diapositive. Elle n’est pas extraite du flux vidéo.  
- **Vignettes de cadres audio :** un [AudioFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audioframe/) peut exposer une icône ou une vignette via `picture_format` ; ce n’est pas les données audio intégrées.  
- **Images de zoom :** les formes de zoom de diapositive, de section et de sommaire peuvent utiliser des objets [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) personnalisés via `image`.  
- **Modèles de formes imbriquées :** les objets tableau, graphique et SmartArt implémentent [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/), mais leurs images sont souvent stockées dans les objets de format de cellule de tableau, d’élément de graphique ou de nœud SmartArt.  
- **Images recadrées ou transformées :** accéder à [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) vous donne la ressource d’image stockée. Cela ne rend pas le recadrage, la transparence, le recolorage, la rotation ou d’autres effets visuels appliqués par la forme.

## **FAQ**

**Puis‑je extraire l’image d’origine sans recadrage, effets ou transformations de forme ?**  
Oui. Accédez à l’objet [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) et écrivez sa propriété `binary_data` sur le disque. Cela préserve l’image encodée d’origine stockée dans la présentation, et non la façon dont l’image est rendue sur la diapositive.

**Puis‑je exporter chaque image extraite au format PNG ?**  
Oui. Utilisez la propriété `image` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) pour obtenir un objet image, puis appelez `save` avec [ImageFormat.PNG](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imageformat/). Cela convertit la sortie et peut ne pas conserver le type de fichier d’origine ou les données vectorielles.

**Comment éviter d’enregistrer la même image plusieurs fois ?**  
Utilisez un hachage de la propriété `binary_data` de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou notez une autre référence vers le fichier de sortie existant.

**Pourquoi certaines formes ne produisent‑elles pas d’image ?**  
Les cadres d’image, les formes remplies d’image, les cadres d’objet OLE, les cadres multimédia, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de formes exposent les images via des objets de format imbriqués, si bien qu’une simple vérification `picture_format` ou `fill_format` ne suffit pas toujours.

**Puis‑je extraire la vignette affichée pour un cadre vidéo ?**  
Oui. Utilisez [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) et lisez `picture_format.picture.image`. Cela extrait l’image du poster stockée avec le cadre vidéo, pas une trame générée à partir du fichier vidéo.

**Comment déterminer quelles formes utilisent une image spécifique de la collection d’images de la présentation ?**  
Aspose.Slides ne stocke pas de liens inverses de [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) vers les formes. Construisez une correspondance lors du parcours : chaque fois que vous trouvez une référence d’image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l’élément de la collection.

**Puis‑je extraire les images intégrées à l’intérieur d’objets OLE, comme les documents joints ?**  
Vous pouvez extraire l’aperçu de diapositive de l’objet OLE via la propriété `substitute_picture_format` de [OleObjectFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/oleobjectframe/). Cependant, cet aperçu n’est pas le document intégré lui‑-même. Pour extraire les images à l’intérieur du fichier intégré, extrayez les données OLE et examinez‑les avec les outils appropriés pour ce type de fichier.