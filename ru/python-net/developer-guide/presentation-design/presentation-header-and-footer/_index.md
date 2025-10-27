---
title: Управление заголовками и нижними колонтитулами презентаций с помощью Python
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/python-net/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный материал
- заметки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Используйте Aspose.Slides для Python через .NET, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального вида."
---

## **Обзор**

Aspose.Slides для Python позволяет управлять заполняющими полями заголовков и нижних колонтитулов во всей презентации с точным охватом. Текст нижнего колонтитула, дата/время и номера слайдов управляются на уровне шаблона и могут применяться глобально или корректироваться для отдельного слайда. Заголовки поддерживаются в заметках и раздаточных материалах, где можно переключать их видимость и задавать текст заголовка, нижнего колонтитула, дата/время и номера страниц через специализированный менеджер заголовков и нижних колонтитулов на мастер‑слайде заметок или отдельных слайдах заметок. В этой статье описаны основные схемы обновления этих заполняющих полей и последовательного применения изменений по всей презентации.

## **Управление текстом заголовков и нижних колонтитулов**

В этом разделе вы узнаете, как управлять содержимым заголовков и нижних колонтитулов в презентации — включать или изменять нижний колонтитул, дату и время, а также номера слайдов. Мы кратко опишем области применения этих настроек (вся презентация, отдельные слайды и представления заметок/раздаточных материалов) и покажем, как с помощью API Aspose.Slides быстро и последовательно их обновлять.

Ниже приведён пример кода, который открывает презентацию, включает и задаёт текст нижнего колонтитула, обновляет текст заголовка на мастер‑слайде заметок и сохраняет файл.

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление заголовками и нижними колонтитулами на слайдах заметок**

В этом разделе вы узнаете, как управлять заголовками и нижними колонтитулами специально для слайдов заметок в Aspose.Slides. Мы рассмотрим включение соответствующих заполняющих полей, задавание текста нижних колонтитулов, даты/времени и номеров страниц, а также последовательное применение этих изменений в мастере заметок и отдельных страницах заметок.

Выполните следующие шаги:

1. Загрузите файл презентации.
1. Получите мастер‑слайд заметок и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. На мастер‑слайде заметок включите видимость заголовка, нижнего колонтитула, номера слайда и даты/времени для мастера и всех дочерних слайдов заметок.
1. На мастер‑слайде заметок задайте текст заголовка, нижнего колонтитула и даты/времени для мастера и всех дочерних слайдов заметок.
1. Получите слайд заметок для первого слайда презентации и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. Только для этого первого слайда заметок убедитесь, что заголовок, нижний колонтитул, номер слайда и дата/время видимы (включите те, которые отключены).
1. Только для этого первого слайда заметок задайте текст заголовка, нижнего колонтитула и даты/времени.
1. Сохраните презентацию в формате PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Могу ли я добавить «заголовок» на обычные слайды?**

В PowerPoint «заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это такие же ограничения: заголовок только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Что если в макете отсутствует область нижнего колонтитула — можно ли «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков и нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API предназначены для случаев, когда заполняющее поле отсутствует или скрыто.

**Как задать начальное значение номера слайда, отличное от 1?**

Установите [номер первого слайда](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) презентации; после этого все нумерации пересчитываются. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.