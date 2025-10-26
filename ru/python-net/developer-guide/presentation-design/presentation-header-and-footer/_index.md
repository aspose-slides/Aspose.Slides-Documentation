---
title: Управление заголовками и нижними колонтитулами презентации с помощью Python
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/python-net/developer-guide/presentation-design/presentation-header-and-footer/
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

Aspose.Slides for Python позволяет управлять заполнителями заголовков и нижних колонтитулов во всей презентации с точным диапазоном действия. Текст нижнего колонтитула, дата/время и номера слайдов управляются на уровне мастер‑слайда и могут применяться глобально или корректироваться для отдельного слайда. Заголовки поддерживаются в заметках и раздаточных материалах, где вы можете переключать их видимость и задавать текст заголовка, нижнего колонтитула, даты/времени и номеров страниц через специальный менеджер заголовков и нижних колонтитулов на мастер‑записном слайде или отдельных слайдах заметок. В этой статье описаны основные шаблоны обновления этих заполнителей и последовательного распространения изменений по всей презентации.

## **Управление текстом заголовка и нижнего колонтитула**

В этом разделе вы узнаете, как управлять содержимым заголовков и нижних колонтитулов в презентации — включать или изменять нижний колонтитул, дату и время, а также номера слайдов. Мы кратко опишем области применения этих настроек (вся презентация, отдельные слайды и представления заметок/раздаточных материалов) и покажем, как с помощью API Aspose.Slides быстро и последовательно их обновлять.

Пример кода ниже открывает презентацию, включает и задаёт текст нижнего колонтитула, обновляет текст заголовка на мастер‑записном слайде и сохраняет файл.

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

## **Управление заголовком и нижним колонтитулом на слайдах заметок**

В этом разделе вы узнаете, как управлять заголовками и нижними колонтитулами специально для слайдов заметок в Aspose.Slides. Мы расскажем, как включать необходимые заполнители, задавать текст для нижних колонтитулов, даты/времени и номеров страниц, а также как последовательно применять эти изменения к мастеру заметок и отдельным страницам заметок.

Выполните перечисленные ниже шаги:

1. Загрузите файл презентации.  
2. Получите мастер‑слайд заметок и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. На мастер‑слайде заметок включите видимость заголовка, нижнего колонтитула, номера слайда и даты/времени для мастера и всех дочерних слайдов заметок.  
4. На мастер‑слайде заметок задайте текст заголовка, нижнего колонтитула и даты/времени для мастера и всех дочерних слайдов заметок.  
5. Получите слайд заметок для первого слайда презентации и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Только для этого первого слайда заметок убедитесь, что заголовок, нижний колонтитул, номер слайда и дата/время видимы (включите те, которые выключены).  
7. Только для этого первого слайда заметок задайте текст заголовка, нижнего колонтитула и даты/времени.  
8. Сохраните презентацию в формате PPTX.

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

## **FAQ**

**Можно ли добавить «заголовок» на обычные слайды?**

В PowerPoint «Заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это ограничение сохраняется: заголовок — только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Что если в макете отсутствует область нижнего колонтитула — можно ли «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и при необходимости включите её. Эти индикаторы API и методы предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как сделать так, чтобы нумерация слайдов начиналась с значения, отличного от 1?**

Установите [номер первого слайда презентации](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/); после этого вся нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отрисовываются как обычные текстовые элементы презентации. То есть если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.