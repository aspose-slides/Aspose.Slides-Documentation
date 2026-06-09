---
title: Python'da Sunum Şekillerinden Görüntü Çıkarma
linktitle: Şekilden Görüntü
type: docs
weight: 90
url: /tr/python-net/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkar
- görsel al
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu çözüm."
---
## **Genel Bakış**

Bir sunumdaki görüntüler çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurmalar olarak, OLE nesne önizleme görüntüleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görüntüleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görüntüler olarak. Aspose.Slides bu görüntüleri sunum görüntü koleksiyonunda depolar ve bu koleksiyon [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) ve [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesneleri aracılığıyla sunulur.

Sadece bir sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız gerekiyorsa, `presentation.images` üzerinden yineleyin. Bu makale farklı bir göreve odaklanır: slaytlarda görüntülerin nerede kullanıldığını bulmak için şekilleri gezmek, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma görüntüsü, medya önizlemesi, OLE önizlemesi veya yakınlaştırma görüntüsü) gibi yararlı bağlamı koruyabilir.

{{% alert title="Tip" color="primary" %}}
Orijinal kodlanmış görüntü verisini ve dosya türünü korumak için [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `binary_data` özelliğini kullanın. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde `save` ile birlikte `image` özelliğini kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `save_original_image` orijinal gömülü baytları yazar, MIME türünden güvenli bir uzantı seçer ve SHA-256 karmasıyla yinelenen görüntü ikili verilerini atlar.

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

## **Resim Çerçevelerinden Görüntü Çıkarma**

Bu yöntemi bağımsız nesneler olarak eklenen resimler için kullanın. Bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) resmini `picture_format.picture.image` içinde depolar; bu, bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Görüntü Çıkarma**

Şekiller bir resmi doldurma olarak kullanabilir. Önce şeklin doldurma türünü kontrol edin: eğer [FillType.PICTURE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) değilse, bu doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnelerini işler ve her görüntüyü [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `image` özelliği aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/) PowerPoint'in slaytta nesnenin önizlemesi olarak kullandığı bir yedek resim içerebilir. Bu görüntü `substitute_picture_format.picture.image` aracılığıyla elde edilir. Bu resmi çıkarmak size önizleme görüntüsünü verir, gömülü OLE paket içeriğini değil.

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

## **Video Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) `picture_format.picture.image` içinde bir önizleme resmi de depolayabilir. Bu, slaytta gösterilen poster ya da küçük resimdir, video akışından çözülen bir kare değildir.

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

## **Ses Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [AudioFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/) `picture_format.picture.image` içinde bir küçük resim depolayabilir. Bu, slayttaki ses nesnesi için gösterilen görüntüdür.

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

## **Yakınlaştırma Nesnelerinden Görüntü Çıkarma**

[ZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/zoomframe/) ve [SectionZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectionzoomframe/) şekilleri özel görüntüler kullanabilir. Yakınlaştırma çerçevesinden `zoom_image` özelliğini okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Görüntü Çıkarma**

Bir [SummaryZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomframe/) aynı zamanda bir şekildir. Bölüm öğeleri özel görüntüler kullanabilir; bu, her özet yakınlaştırma bölümünün `zoom_image` özelliği aracılığıyla ortaya çıkar.

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

## **Tablo Şekillerinden Görüntü Çıkarma**

Bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) bir şekildir. Tablodaki görüntüler genellikle tablo hücrelerinde resim doldurmaları olarak depolanır.

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

## **Grafik Şekillerinden Görüntü Çıkarma**

Bir [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görüntü çıkarır.

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

## **SmartArt Şekillerinden Görüntü Çıkarma**

Bir [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görüntüler düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde depolanabilir.

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

## **Gruplanmış Şekiller İçindeki Görüntüleri Dahil Et**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerate_shapes` yardımcı işlevi bir `include_grouped_shapes` seçeneğine sahiptir. [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `True` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görüntüleri çıkarır. Ayrıca tablo, grafik, SmartArt ve özet yakınlaştırma görüntülerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını aynı yinelemeli şekil taramasını koruyarak yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görüntüler:** Birden fazla şekil aynı görüntüyü ya da aynı baytlara sahip ayrı görüntüleri referans alabilir. Tekil her görüntü için bir çıktı dosyası istiyorsanız, dosyaları yazmadan önce [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `binary_data` özelliğini hash'leyin.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `binary_data` özelliğini kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verilerini korur. `save` ile `image` özelliğini kaydetmek, tutarlı bir çıktı formatı istediğinizde faydalıdır.
- **Desteklenmeyen doldurma türleri:** Katı, degrade, desen ve doldurma olmayan şekiller resim doldurması içermez. `picture_fill_format` okuma işleminden önce [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) kontrol edin.
- **Gruplanmış şekiller:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Gruplanmış içerik önemli olduğunda [GroupShape.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/shapes/) öğesini yinelemeli olarak inceleyin.
- **OLE nesne önizlemeleri:** Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/) `substitute_picture_format` aracılığıyla bir önizleme resmi sağlayabilir, ancak bu resim yalnızca slayt önizlemesidir. OLE nesnesinin içindeki gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) `picture_format` aracılığıyla bir önizleme resmi sunabilir, ancak bu resim sadece slaytta gösterilen posterdir. Video akışından çıkarılmaz.
- **Ses çerçeve küçük resimleri:** Bir [AudioFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/) `picture_format` aracılığıyla bir simge veya küçük resim gösterebilir; bu gömülü ses verisi değildir.
- **Yakınlaştırma görüntüleri:** Slayt yakınlaştırması, bölüm yakınlaştırması ve özet yakınlaştırma şekilleri `image` aracılığıyla özel [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) uygular, ancak görüntüleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde depolanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) erişmek size depolanmış görüntü kaynağını verir. Şekil tarafından uygulanan kırpma, şeffaflık, yeniden renklendirme, döndürme veya diğer görsel efektleri render etmez.

## **SSS**

**Kırpma, efektler veya şekil dönüşümleri olmadan orijinal görüntüyü çıkarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesine erişin ve `binary_data` özelliğini diske yazın. Bu, sunumda depolanan orijinal kodlanmış görüntüyü, slaytta görüntünün nasıl render edildiği yerine korur.

**Her çıkarılan görüntüyü PNG olarak dışa aktarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `image` özelliğini kullanarak bir görüntü nesnesi alın ve ardından [ImageFormat.PNG](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/) ile `save` çağrısı yapın. Bu, çıktıyı dönüştürür ve orijinal dosya türünü veya vektör verisini korumayabilir.

**Aynı görüntüyü birden fazla kez kaydetmekten nasıl kaçınırım?**

[PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin `binary_data` özelliğinin bir hash'ini kullanın ve hash'leri bir kümede tutun. Yeni bir görüntünün hash'i zaten mevcutsa, atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

**Neden bazı şekiller görüntü üretmiyor?**

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntülere referans verebilir. Bazı şekil türleri görüntüleri iç içe biçimlendirme nesneleri aracılığıyla ortaya çıkar, bu yüzden basit bir `picture_format` ya da şekil `fill_format` kontrolü her zaman yeterli olmayabilir.

**Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) kullanın ve `picture_format.picture.image`'i okuyun. Bu, video çerçevesiyle birlikte depolanan poster görüntüyü çıkarır, video dosyasından üretilen bir kareyi değil.

**Sunum görüntü koleksiyonundaki belirli bir görüntüyü hangi şekiller kullandığını nasıl belirleyebilirim?**

Aspose.Slides, [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinden şekillere ters bağlantılar saklamaz. Gezinme sırasında bir eşleme oluşturun: bir görüntü referansı bulduğunuzda, slayt numarasını, şekil yolunu ve görüntü hash'ini ya da koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü görüntüleri, örneğin ekli belgeler gibi, çıkarabilir miyim?**

[OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/) nesnesinin `substitute_picture_format` özelliğinden OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme gömülü belge değildir. Gömülü dosyanın içindeki görüntüleri çıkarmak için OLE verisini çıkarın ve o dosya türüne uygun araçlarla inceleyin.