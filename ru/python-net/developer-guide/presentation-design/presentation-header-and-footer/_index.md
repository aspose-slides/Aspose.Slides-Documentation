---
title: У管理Рай Презентации Заголовков И Нижних Колонтитулов С Помощью Python
linktitle: Заголовок И Нижний Колонтитул
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
- записки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Используйте Aspose.Slides for Python via .NET, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального вида."
---

## **Обзор**

Aspose.Slides for Python позволяет управлять заполняющими областями заголовка и нижнего колонтитула по всей презентации с точным контролем области применения. Текст нижнего колонтитула, дата/время и номера слайдов управляются на уровне мастера и могут применяться глобально или настраиваться для отдельного слайда. Заголовки поддерживаются в заметках и раздаточных материалах, где можно переключать их видимость и задавать текст заголовка, нижнего колонтитула, даты/времени и номеров страниц через специализированный менеджер заголовка и нижнего колонтитула на главном слайде заметок или отдельных слайдах заметок. В этой статье описаны основные шаблоны обновления этих заполняющих областей и консистентного распространения изменений по всей презентации.

## **Управление текстом заголовка и нижнего колонтитула**

В этом разделе вы узнаете, как управлять содержимым заголовка и нижнего колонтитула в презентации — включать или изменять нижний колонтитул, дату и время, а также номера слайдов. Мы кратко опишем области применения этих настроек (вся презентация, отдельные слайды и представления заметок/раздаточных материалов) и покажем, как с помощью API Aspose.Slides быстро и последовательно их обновлять.

Пример кода ниже открывает презентацию, включает и задаёт текст нижнего колонтитула, обновляет текст заголовка на главном слайде заметок и сохраняет файл.

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

В этом разделе вы узнаете, как управлять заголовками и нижними колонтитулами специально для слайдов заметок в Aspose.Slides. Мы рассмотрим включение соответствующих заполняющих областей, задачу текста для нижних колонтитулов, даты/времени и номеров страниц, а также последовательное применение этих изменений к мастеру заметок и отдельным страницам заметок.

Выполните следующие шаги:

1. Загрузите файл презентации.  
2. Получите мастер‑слайд заметок и его [менеджер заголовка и нижнего колонтитула](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. На мастер‑слайде заметок включите видимость Header, Footer, Slide number и Date-time для мастера и всех дочерних слайдов заметок.  
4. На мастер‑слайде заметок задайте текст для Header, Footer и Date-time для мастера и всех дочерних слайдов заметок.  
5. Получите слайд заметок первого слайда презентации и его [менеджер заголовка и нижнего колонтитула](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Для только этого первого слайда заметок убедитесь, что Header, Footer, Slide number и Date-time видимы (включите любые отключённые).  
7. Для только этого первого слайда заметок задайте текст для Header, Footer и Date-time.  
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

**Могу ли я добавить «заголовок» к обычным слайдам?**  
В PowerPoint «заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются лишь нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для заметок/раздаточных материалов, а на слайдах — Footer/DateTime/SlideNumber.

**Что если в макете нет области нижнего колонтитула — могу ли я «включить» его видимость?**  
Да. Проверьте видимость через менеджер заголовка/нижнего колонтитула и включите её при необходимости. Такие индикаторы API и методы предназначены для случаев, когда заполняющая область отсутствует или скрыта.

**Как задать номер слайда, начиная с значения, отличного от 1?**  
Установите [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) презентации; после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**  
Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в результирующем формате вместе с другим содержимым.