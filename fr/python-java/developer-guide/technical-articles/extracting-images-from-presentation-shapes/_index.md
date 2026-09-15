---
title: Extraire des images des formes de présentation en Python via Java
linktitle: Image à partir de la forme
type: docs
weight: 100
url: /fr/python-java/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java - solution rapide et conviviale pour le code."
---
## **Vue d'ensemble**

Les images d’une présentation peuvent apparaître sous plusieurs types de formes : cadres d’image ordinaires, remplissages d’image appliqués à des formes, aperçus d’objets OLE, miniatures de cadres vidéo ou audio, images de zoom ou images imbriquées dans des formes tableau, graphique et SmartArt. Aspose.Slides stocke ces images dans la collection d’images de la présentation, exposée via les objets [ImageCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/) et [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).

Si vous avez seulement besoin d’exporter chaque ressource image intégrée à une présentation, parcourez [Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages). Cet article se concentre sur une tâche différente : parcourir les formes pour trouver où les images sont utilisées dans les diapositives, afin que les fichiers enregistrés conservent un contexte utile comme le numéro de diapositive, la position de la forme et le type source (cadre d’image, image de remplissage, aperçu multimédia, aperçu OLE ou image de zoom).

{{% alert title="Tip" color="success" %}}

Utilisez [PPImage.getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getBinaryData) pour préserver les données d’image encodées d’origine et le type de fichier. Utilisez [PPImage.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getImage) avec `save` lorsque vous souhaitez normaliser la sortie vers un format spécifique tel que PNG.

{{% /alert %}}

## **Fonctions d'assistance partagées**

Enregistrez les fonctions d’assistance partagées ci‑dessous dans `image_helpers.py` à côté des scripts d’exemple. Elles raccourcissent les exemples. `save_original_image` écrit les octets intégrés d’origine, choisit une extension sûre à partir du type MIME et ignore les binaires d’image dupliqués grâce à la fonction de hachage SHA‑256.

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
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
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **Extraire les images des cadres d'image**

Utilisez cette approche pour les images insérées comme objets autonomes. Un [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) donne accès à son image via [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#getPicture) et [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImage), qui renvoie un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les images des formes à remplissage image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d’abord le type de remplissage de la forme : s’il n’est pas [FillType.Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/), il n’y a aucune image à extraire de ce remplissage. L’exemple ci‑dessous gère les objets [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) et enregistre chaque image au format PNG via [PPImage.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getImage).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **Extraire les aperçus d’image des cadres d’objet OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) peut posséder une image de substitution que PowerPoint utilise comme aperçu de l’objet sur la diapositive. Cette image est disponible via [getSubstitutePictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#getPicture) et [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImage). Extraire cette image vous donne l’aperçu, pas le contenu du paquet OLE intégré.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les aperçus d’image des cadres vidéo**

Un [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) peut également stocker une image d’aperçu dans [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#getPicture) et [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImage). Il s’agit du poster ou de la miniature affichée sur la diapositive, pas d’une image décodée à partir du flux vidéo.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les aperçus d’image des cadres audio**

Un [AudioFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/) peut stocker une vignette dans [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#getPicture) et [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImage). Il s’agit de l’image affichée pour l’objet audio sur la diapositive.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les images des objets Zoom**

Les formes [ZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomframe/) et [SectionZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sectionzoomframe/) peuvent utiliser des images personnalisées. Lisez [getZoomImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomobject/#getZoomImage) depuis le cadre de zoom.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **Extraire les images des cadres de Zoom de synthèse**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/summaryzoomframe/) est également une forme. Ses éléments de section peuvent utiliser des images personnalisées, exposées via la méthode [getZoomImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomobject/#getZoomImage) de chaque section de zoom de synthèse.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les images des formes Tableau**

Un [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/) est une forme. Les images dans un tableau sont généralement stockées comme remplissages d’image dans les cellules du tableau.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les images des formes Graphique**

Un [Chart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/) est une forme. L’exemple ci‑dessous extrait une image du remplissage image de la zone du graphique.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraire les images des formes SmartArt**

Un objet [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/) est une forme. Selon la disposition du SmartArt, les images peuvent être stockées dans les remplissages des puces de nœud ou dans les formats de remplissage des formes de nœud.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Inclure les images à l’intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. L’assistant partagé `enumerate_shapes` possède une option `include_grouped_shapes`. Réglez‑la sur `True` lorsque vous voulez inspecter les formes à l’intérieur des objets [GroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/). L’exemple ci‑dessous extrait les images des cadres d’image, des formes à remplissage image, des aperçus d’objet OLE, des miniatures de cadres vidéo et audio. Pour inclure également les images de tableau, de graphique, de SmartArt et de zoom de synthèse, réutilisez la logique d’extraction spécialisée des sections précédentes tout en conservant le même parcours récursif des formes.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Cas limites et notes pratiques**

- **Images dupliquées :** plusieurs formes peuvent référencer la même image ou des images distinctes avec des octets identiques. Hachez [PPImage.getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getBinaryData) avant d’écrire les fichiers si vous voulez un fichier de sortie par image unique.
- **Données d’origine vs sortie convertie :** l’enregistrement de [PPImage.getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getBinaryData) préserve les données JPEG, PNG, GIF, SVG, EMF ou WMF intégrées. L’enregistrement de [PPImage.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getImage) via `save` est utile lorsque vous désirez un format de sortie cohérent.
- **Types de remplissage non pris en charge :** les formes à remplissage uni, dégradé, motif ou sans remplissage ne contiennent pas d’image de remplissage. Vérifiez [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) avant de lire [getPictureFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Formes groupées :** la collection de formes de la diapositive de niveau supérieur ne « aplatit » pas les groupes. Parcourez récursivement [GroupShape.getShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/#getShapes) lorsque le contenu groupé importe.
- **Aperçus d’objet OLE :** un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) peut exposer une image d’aperçu via [getSubstitutePictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), mais cette image n’est que l’aperçu de la diapositive. Ce n’est pas le fichier intégré à l’intérieur de l’objet OLE.
- **Miniatures de cadres vidéo :** un [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) peut exposer une image d’aperçu via [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat), mais cette image n’est que le poster affiché sur la diapositive. Elle n’est pas extraite du flux vidéo.
- **Miniatures de cadres audio :** un [AudioFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/) peut exposer une icône ou une vignette via [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat) ; ce n’est pas les données audio intégrées.
- **Images de zoom :** les formes de zoom de diapositive, de section et de synthèse peuvent utiliser des objets [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) personnalisés via [getZoomImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Modèles de formes imbriquées :** les objets tableau, graphique et SmartArt implémentent [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/), mais leurs images sont souvent stockées dans des objets de format de cellule de tableau, d’élément de graphique ou de nœud SmartArt.
- **Images rognées ou transformées :** accéder à [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) vous fournit la ressource image stockée. Cela ne rend pas les découpes, transparences, recolorations, rotations ou autres effets visuels appliqués par la forme.

## **FAQ**

**Puis‑je extraire l’image originale sans rognage, effets ou transformations de forme ?**

Oui. Accédez à l’objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) et écrivez [PPImage.getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getBinaryData) sur le disque. Cela préserve l’image encodée d’origine stockée dans la présentation, pas la façon dont elle est rendue sur la diapositive.

**Puis‑je exporter chaque image extraite au format PNG ?**

Oui. Utilisez [PPImage.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getImage) pour obtenir un objet image, puis appelez `save` avec [ImageFormat.Png](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/). Cela convertit la sortie et peut ne pas préserver le type de fichier d’origine ou les données vectorielles.

**Comment éviter d’enregistrer plusieurs fois la même image ?**

Utilisez un hachage de [PPImage.getBinaryData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getBinaryData) et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou enregistrez une autre référence vers le fichier de sortie existant.

**Pourquoi certaines formes ne produisent‑elles pas d’image ?**

Les cadres d’image, les formes à remplissage image, les cadres d’objet OLE, les cadres multimédia, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de forme exposent les images via des objets de format imbriqués, de sorte qu’un simple appel à [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat) ou à [shape getFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getFillFormat) ne suffit pas toujours.

**Puis‑je extraire la miniature affichée pour un cadre vidéo ?**

Oui. Utilisez [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) et lisez [getPictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#getPicture) et [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImage). Cela extrait l’image du poster stockée avec le cadre vidéo, pas une image générée à partir du fichier vidéo.

**Comment déterminer quelles formes utilisent une image spécifique de la collection d’images de la présentation ?**

Aspose.Slides ne stocke pas de liens inverses de [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) vers les formes. Construisez une cartographie pendant le parcours : chaque fois que vous trouvez une référence d’image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l’élément de collection de l’image.

**Puis‑je extraire les images incorporées dans les objets OLE, comme les documents joints ?**

Vous pouvez extraire l’aperçu du diapositive de l’objet OLE via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Cependant, cet aperçu n’est pas le document intégré lui‑même. Pour extraire les images à l’intérieur du fichier intégré, extrayez les données OLE et analysez‑les avec les outils appropriés à ce type de fichier.