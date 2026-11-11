---
title: Рендер слайдов презентации в виде SVG‑изображений на Python
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
- параметры экспорта SVG
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Экспортировать слайды PowerPoint в виде SVG‑изображений на Python и управлять шрифтами, текстом и изображениями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотров слайдов, рабочих процессов по обеспечению доступа и автоматической пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/), когда экспортируемый SVG должен быть компактным, предсказуемым в разных браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), выберите слайд и запишите его в поток. Ниже приведён пример, экспортирующий каждый слайд презентации в отдельный файл SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Имя файла использует [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), если просмотрщик слайдов или веб‑страница требуется только эта форма.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) включает рамку текста в область рендеринга, а [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) в `True`, если текст должен отображаться без лигатур.

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

При экспорте слайдов в SVG вы можете контролировать, останется ли текст в виде текста или будет преобразован в векторную графику, а также как будут включаться или ссылаться внешние шрифты. Ниже перечислены параметры, помогающие найти баланс между визуальной согласованностью, возможностью выделения текста и зависимостями от шрифтов в экспортированном SVG.

### **Векторизация всего текста**

Установите [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) в `True`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, но текст больше нельзя будет выделять или искать как SVG‑текст.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `ADD_LINKS_TO_FONT_FILES`, чтобы ссылаться на отдельные файлы шрифтов, `EMBED`, чтобы включить данные шрифта в SVG, или `VECTORIZE`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Перед включением шрифтов убедитесь в наличии соответствующей лицензии.

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

Используйте [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) для уменьшения разрешения встроенных изображений, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) для исключения обрезанных областей источника и [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) для контроля качества JPEG‑кодирования. Эти настройки уменьшают размер файла за счёт качества изображения или сохранённых данных изображения.

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

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) задаёт нижний предел разрешения для растеризуемых метафайлов при экспорте в SVG. Используйте его для баланса между детализацией и размером файла, когда растеризуется изображение EMF или WMF. Параметр не определяет глобальное DPI для SVG и не принуждает каждый объект на слайде стать растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), содержащий изображение EMF с плотно расположенными диагональными линиями. Ниже пример, экспортирующий первый слайд этой презентации с тремя разрешениями растеризации через [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Все остальные параметры экспорта остаются одинаковыми, чтобы результаты можно было сравнить.

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

В результате EMF преобразуется в один встроенный PNG в каждом SVG. Ниже приведены измерения для данной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растра в одинаковом увеличенном размере отображения. Диагональные линии демонстрируют заметную пикселизацию при 72 DPI и более плавные границы при более высоких разрешениях, при этом размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Увеличенные детали диагональных линий при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) управляет уменьшением разрешения изображения и может маскировать эффект изменения разрешения растеризации метафайла. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) контролирует качество JPEG‑кодирования, а не разрешение растеризации метафайла.

## **Вопросы и ответы**

**Когда следует использовать [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) вместо [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), когда весь текст должен быть независимым от шрифтов. Используйте [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей и выбора ссылок на файлы шрифтов, если целевая среда умеет их обслуживать. Тестируйте результат, поскольку уменьшение разрешения изображений, снижение качества JPEG и векторизация текста имеют разные компромиссы между качеством и размером.