---
title: Изменение размера фигур в презентациях с Python
linktitle: Изменение размеров фигур
type: docs
weight: 130
url: /ru/python-net/re-sizing-shapes-on-slide/
keywords:
- изменение размера фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — автоматизируйте коррекцию макета слайдов и повышайте производительность."
---

## **Обзор**

Один из самых распространённых вопросов от клиентов Aspose.Slides for Python — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья показывает, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры, чтобы они соответствовали новому макету слайда.
```py
import aspose.slides as slides

# Загрузить файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Получить исходный размер слайда.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Изменить размер слайда без масштабирования существующих фигур.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Получить новый размер слайда.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Изменить размер и переместить фигуры на каждом слайде.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Масштабировать размер фигуры.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Масштабировать позицию фигуры.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

Если слайд содержит таблицу, приведённый выше код работать не будет. В этом случае необходимо изменить размер каждой ячейки таблицы.

{{% /alert %}} 

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц установка ширины или высоты является особым случаем: необходимо настроить высоту отдельных строк и ширину столбцов, чтобы изменить общий размер таблицы.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Получить исходный размер слайда.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Изменить размер слайда без масштабирования существующих фигур.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Получить новый размер слайда.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Масштабировать размер фигуры.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Масштабировать позицию фигуры.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Масштабировать размер фигуры.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Масштабировать позицию фигуры.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Масштабировать размер фигуры.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Масштабировать позицию фигуры.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **ЧаВо**

**Почему фигуры выглядят искажёнными или обрезанными после изменения размера слайда?**

При изменении размера слайда фигуры сохраняют своё исходное положение и размер, если масштаб явно не изменён. Это может привести к обрезке содержимого или смещению фигур.

**Работает ли предоставленный код для всех типов фигур?**

Базовый пример работает для большинства типов фигур (текстовые поля, изображения, диаграммы и т.д.). Однако для таблиц необходимо обрабатывать строки и столбцы отдельно, поскольку высота и ширина таблицы определяются размерами отдельных ячеек.

**Как изменить размер таблиц при изменении размера слайда?**

Необходимо пройтись по всем строкам и столбцам таблицы и пропорционально изменить их высоту и ширину, как показано во втором примере кода.

**Будет ли это изменение размера работать для шаблонных слайдов и слайдов макета?**

Да, но также следует пройтись по [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) и [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность во всей презентации.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Вы можете использовать [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответствующим образом, чтобы сохранить макет.

**Есть ли ограничение на размер слайда, который можно установить?**

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Вы можете проверить свойство `aspect_ratio_locked` фигуры перед масштабированием. Если оно заблокировано, изменяйте ширину или высоту пропорционально, а не масштабируйте их по отдельности.