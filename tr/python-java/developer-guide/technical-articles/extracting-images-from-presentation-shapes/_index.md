---
title: Python ile Java üzerinden Sunum Şekillerinden Görselleri Çıkarma
linktitle: Şekilden Görsel
type: docs
weight: 100
url: /tr/python-java/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkarma
- görsel getirme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görselleri çıkarın - hızlı, kod dostu bir çözüm."
---
## **Genel Bakış**

Bir sunumdaki görseller çeşitli şekil türlerinde görüntülenebilir: sıradan resim çerçeveleri olarak, şekillere uygulanmış resim dolgu (picture fill) olarak, OLE nesne ön izleme görselleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekillerinin içinde iç içe yer alan görseller olarak. Aspose.Slides bu görselleri sunum görüntü koleksiyonunda saklar ve bu koleksiyon [ImageCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) ve [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesneleri aracılığıyla sunulur.

Eğer sadece bir sunuma gömülü tüm görsel kaynaklarını dışa aktarmanız gerekiyorsa, [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) üzerinden döngü yapın. Bu makale farklı bir göreve odaklanır: şekilleri dolaşarak slaytlarda görsellerin nerede kullanıldığını bulmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, dolgu resmi, medya önizlemesi, OLE önizlemesi veya yakınlaştırma görseli) gibi yararlı bağlamı koruyabilir.

{{% alert title="Tip" color="success" %}}
Orijinal kodlanmış görsel verisini ve dosya tipini korumak için [PPImage.getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getBinaryData) kullanın. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde `save` ile [PPImage.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getImage) kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Fonksiyonlar**

`image_helpers.py` dosyasına aşağıdaki paylaşılan yardımcı fonksiyonları, örnek betiklerin yanında kaydedin. Bu fonksiyonlar örnekleri kısa tutar. `save_original_image` orijinal gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 hash'iyle yinelenen görsel ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görselleri Çıkarma**

Bu yöntemi bağımsız nesne olarak eklenen resimler için kullanın. Bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) resmi [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImage) aracılığıyla erişim sağlar; bu metotlar bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesi döndürür.

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

## **Resim Dolgulu Şekillerden Görselleri Çıkarma**

Şekiller resmi dolgu olarak kullanabilir. Önce şeklin dolgu tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) değilse, bu dolgudan çıkarılacak bir resim yoktur. Aşağıdaki örnek [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) nesnelerini işler ve her görseli [PPImage.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getImage) aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) PowerPoint'in nesnenin slayttaki ön izlemesi olarak kullandığı bir ikame resmi (substitute picture) içerebilir. Bu görüntü [getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImage) aracılığıyla elde edilebilir. Bu resmi çıkarmak size OLE paketinin gömülü içeriği değil, sadece ön izleme görselini verir.

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

## **Video Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) ayrıca bir ön izleme görselini [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImage) aracılığıyla depolayabilir. Bu, slaytta gösterilen afiş ya da küçük resimdir, video akışından çözümlenen bir çerçeve değildir.

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

## **Ses Çerçevelerinden Ön İzleme Görselleri Çıkarma**

Bir [AudioFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/) bir küçük resim (thumbnail) [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImage) aracılığıyla depolayabilir. Bu, slayttaki ses nesnesi için gösterilen görseldir.

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

## **Zoom Nesnelerinden Görselleri Çıkarma**

[ZoomFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zoomframe/) ve [SectionZoomFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sectionzoomframe/) şekilleri özel görseller kullanabilir. Zoom çerçevesinden [getZoomImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zoomobject/#getZoomImage) metodunu okuyun.

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

## **Özet Zoom Çerçevelerinden Görselleri Çıkarma**

Bir [SummaryZoomFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/summaryzoomframe/) aynı zamanda bir şekildir. Bölüm öğeleri özel görseller kullanabilir; bu görseller her özet zoom bölümünün [getZoomImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zoomobject/#getZoomImage) metodu aracılığıyla ortaya çıkar.

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

## **Tablo Şekillerinden Görselleri Çıkarma**

Bir [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) bir şekildir. Tablo içindeki görseller genellikle tablo hücrelerinde resim dolgusu (picture fill) olarak saklanır.

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

## **Grafik Şekillerinden Görselleri Çıkarma**

Bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim dolgusundan bir görsel çıkarır.

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

## **SmartArt Şekillerinden Görselleri Çıkarma**

Bir [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görseller düğüm madde işareti dolgularında veya düğüm şekillerinin dolgu formatlarında saklanabilir.

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

## **Gruplanmış Şekiller İçindeki Görselleri Dahil Et**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerate_shapes` yardımcı fonksiyonunda bir `include_grouped_shapes` seçeneği bulunur. [GroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/) nesnelerinin içindeki şekilleri incelemek istediğinizde bunu `True` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim dolgulu şekillerden, OLE nesne ön izlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet zoom görsellerini de dahil etmek için, aynı yinelemeli şekil dolaşımını koruyarak önceki bölümlerdeki özel çıkarma mantığını yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görseller:** Birden fazla şekil aynı görsele ya da aynı baytlara sahip ayrı görsellere başvurabilir. Benzersiz her görsel için bir çıktı dosyası istiyorsanız dosyaları yazmadan önce [PPImage.getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getBinaryData) hash'ini alın.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [PPImage.getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getBinaryData) kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verilerini korur. `save` ile [PPImage.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getImage) kaydetmek, tutarlı bir çıktı formatı istediğinizde faydalıdır.
- **Desteklenmeyen dolgu tipleri:** Düz, degrade, desen ve dolgu olmayan şekiller resim doldurması içermez. [getPictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getPictureFillFormat) okumadan önce [FillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) kontrol edin.
- **Gruplanmış şekiller:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Gruplanmış içerik önemli olduğunda [GroupShape.getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/#getShapes) metodunu yinelemeli olarak inceleyin.
- **OLE nesne ön izlemeleri:** Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) [getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla bir ön izleme görseli sağlayabilir, ancak bu görsel yalnızca slayd ön izlemesidir. OLE nesnesi içindeki gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat) aracılığıyla bir ön izleme görseli sağlayabilir, ancak bu görsel yalnızca slaytta gösterilen afiştir. Video akışından çıkarılmaz.
- **Ses çerçeve küçük resimleri:** Bir [AudioFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/) [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat) aracılığıyla bir simge veya küçük resim sağlayabilir; bu gömülü ses verisi değildir.
- **Zoom görselleri:** Slayt zoomu, bölüm zoomu ve özet zoom şekilleri, [getZoomImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/zoomobject/#getZoomImage) aracılığıyla özel [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) arayüzünü uygular, ancak görselleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) erişmek size saklanan görsel kaynağını verir. Şekil tarafından uygulanan kırpma, şeffaflık, renk değiştirme, döndürme veya diğer görsel etkileri yansıtmaz.

## **SSS**

**Kırpma, efektler veya şekil dönüşümleri olmadan orijinal görseli çıkarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesine erişin ve [PPImage.getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getBinaryData) yöntemini diske yazın. Bu, sunumda saklanan orijinal kodlanmış görseli korur, slaytta görüntülenme şekli değil.

**Çıkarılan her görseli PNG olarak dışa aktarabilir miyim?**

Evet. Görsel nesnesi elde etmek için [PPImage.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getImage) kullanın ve ardından `save` ile [ImageFormat.Png](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/) çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya türünü veya vektör verisini korumayabilir.

**Aynı görseli birden çok kez kaydetmekten nasıl kaçınırım?**

[PPImage.getBinaryData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getBinaryData) hash'ini kullanın ve hash'leri bir kümede tutun. Yeni bir görselin hash'i zaten mevcutsa, onu atlayın ya da mevcut çıktı dosyasına başka bir referans kaydedin.

**Neden bazı şekiller görsel üretmiyor?**

Resim çerçeveleri, resim dolgulu şekiller, OLE nesne çerçeveleri, medya çerçeveleri, zoom çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görsellere referans verebilir. Bazı şekil tipleri görselleri iç içe biçimlendirme nesneleri üzerinden sunar, bu yüzden basit bir [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat) veya şekil [getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getFillFormat) kontrolü her zaman yeterli değildir.

**Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) kullanın ve [getPictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImage) metodlarını okuyun. Bu, video çerçevesiyle birlikte depolanan poster görselini çıkarır; video dosyasından oluşturulan bir çerçeve değildir.

**Sunum görüntü koleksiyonundan belirli bir görseli hangi şekillerin kullandığını nasıl belirleyebilirim?**

Aspose.Slides, [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesinden şekillere ters bağlantılar saklamaz. Gezinme sırasında bir eşleme oluşturun: bir görsel referansı bulduğunuzda slayt numarasını, şekil yolunu ve görsel hash'ini ya da koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü, örneğin ekli belgeler gibi görselleri çıkarabilir miyim?**

[OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla OLE nesnesinin slayt ön izlemesini çıkarabilirsiniz. Ancak bu ön izleme, gömülü belgeyi temsil etmez. Gömülü dosyanın içindeki görselleri çıkarmak için OLE verisini çıkarın ve dosya türüne uygun araçlarla inceleyin.