---
title: Экспортировать слайды презентации как SVG‑изображения в Python
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
description: "Экспортировать слайды PowerPoint как SVG‑изображения в Python и управлять шрифтами, текстом и изображениями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый XML‑основанный формат изображений, который хорошо подходит для веб‑публикаций, просмотрщиков презентаций, процессов обеспечения доступности и автоматической последующей обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд как SVG**

Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), выберите слайд и запишите его в поток. Ниже приведён пример, экспортирующий каждый слайд презентации в отдельный файл SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Имя файла использует [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/), а не индекс цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), если просмотрщик слайдов или веб‑страница требует только эту форму.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) включает текстовую рамку в область рендеринга, а [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) в `True`, когда текст должен рендериться без лигатур.

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

## **Управление обрезкой конца линии у наконечников стрелок**

SVG 1.1 не имеет параметра отступа маркера, позволяющего указать, где линия должна остановиться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортированную линию, чтобы её штрих не выступал за пределы маркера. Установите [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) в `True`, чтобы рисовать штрих до оригинального конца линии. Эта настройка влияет только на вывод SVG. Позиция и длина линии на слайде сохраняются.

В примере рисуются треугольные и ромбовидные наконечники на линиях толщиной 2 и 10 пунктов. Он экспортирует один и тот же слайд дважды, изменяя только параметр обрезки.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Сравнение показывает треугольный наконечник на 10‑пунктовой линии. При включённой обрезке кончик острый. При отключённой обрезке штрих выступает за наклонные стороны маркера и образует плоский конец.

![Увеличенный треугольник 10‑пунктов с острым наконечником, когда обрезка включена, и с плоским концом, когда обрезка отключена](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен на 2‑пунктовом треугольнике. Заполненный ромб покрывает конец штриха при обеих толщинах.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст текстом или будет преобразован в векторную графику, а также как внешние шрифты включаются или ссылаются. Ниже перечисленные параметры помогают сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) в `True`, чтобы записать весь текст слайдов как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, но текст уже нельзя будет выделять или искать как SVG‑текст.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `ADD_LINKS_TO_FONT_FILES`, чтобы ссылаться на отдельные файлы шрифтов, `EMBED`, чтобы включить данные шрифта в SVG, или `VECTORIZE`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их внедрением.

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

## **Уменьшить размер встроенных изображений**

Используйте [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) для снижения разрешения встроенных изображений, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) для исключения обрезанных областей источника и [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) для контроля качества кодирования JPEG. Эти параметры уменьшают размер файла за счёт качества изображения или сохранения данных изображения.

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

## **Управление разрешением растеризации метафайлов**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы сбалансировать детализацию и размер файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором содержится изображение EMF с плотно расположенными диагональными линиями. Ниже пример экспортирует первый слайд этой презентации с тремя разрешениями растеризации через [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Все остальные параметры экспорта остаются одинаковыми, чтобы можно было сравнить результаты.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

В результате EMF превращается в один встроенный PNG в каждом SVG. Ниже приведены измерения для предоставленной презентации; они не являются общей формулой преобразования DPI в размеры пикселей.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растра при одинаковом увеличенном размере отображения. Диагональные линии демонстрируют заметную пикселизацию при 72 DPI и более гладкие края при более высоких разрешениях, при этом размер SVG растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Увеличенные детали диагональных линий при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) контролирует снижение разрешения изображений и может скрывать эффект изменения разрешения растеризации метафайла. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) контролирует качество кодирования JPEG, а не разрешение растеризации метафайла.

## **Вопросы и ответы**

**Когда следует использовать [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) вместо [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Какой лучший способ уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, когда целевая среда может их обслуживать. Проверьте результат, поскольку снижение разрешения изображения, уменьшение качества JPEG и векторизация текста имеют разные компромиссы между качеством и размером.