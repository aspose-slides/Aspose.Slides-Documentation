---
title: Рендеринг слайдов презентации в виде SVG‑изображений на Python
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- Параметры экспорта SVG
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint в виде SVG‑изображений на Python и управляйте шрифтами, текстом и изображениями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый формат изображений на основе XML, который хорошо подходит для веб‑публикации, средств просмотра слайдов, рабочих процессов по доступности и автоматической последующей обработки. Aspose.Slides экспортирует каждый слайд в отдельный SVG‑файл и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым в разных браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), выберите слайд и запишите его в поток. Приведённый пример экспортирует каждый слайд презентации в отдельный SVG‑файл.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Имя файла использует [Slide.slide_number](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/slide_number/) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.write_as_svg](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/write_as_svg/), когда средству просмотра слайдов или веб‑странице требуется только эта форма.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.use_frame_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/use_frame_size/) включает текстовую рамку в область рендеринга, а [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) определяет, применяется ли поворот рамки. Установите [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) в `True`, когда текст должен отображаться без лигатур.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Управление текстом и шрифтами**

### **Векторизовать весь текст**

Установите [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/vectorize_text/) в `True`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, однако текст более не может быть выбран или найден как SVG‑текст.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `ADD_LINKS_TO_FONT_FILES`, чтобы ссылаться на отдельные файлы шрифтов, `EMBED` — чтобы включить данные шрифта в SVG, или `VECTORIZE` — чтобы отрисовать только текст, использующий внешние шрифты, как графику. Перед встраиванием шрифтов проверьте лицензирование шрифтов.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Сокращение размера встроенных изображений**

Используйте [SVGOptions.pictures_compression](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/pictures_compression/) для снижения разрешения встроенных изображений, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) для исключения обрезанных областей исходных изображений и [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/jpeg_quality/) для управления качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт точности изображения или сохранённых данных изображения.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**Когда следует использовать [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/vectorize_text/) вместо [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions.vectorize_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/vectorize_text/), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgexternalfontshandling/), когда нужно преобразовать в графику только текст, использующий внешние шрифты.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их предоставлять. Протестируйте результат, так как более низкое разрешение изображения, более низкое качество JPEG и векторизованный текст имеют разные компромиссы между качеством и размером.