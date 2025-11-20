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
description: "Используйте Aspose.Slides для Python через .NET, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального внешнего вида."
---

## **Обзор**

Aspose.Slides for Python позволяет управлять заполнителями заголовка и нижнего колонтитула во всей презентации с точным ограничением области. Текст нижнего колонтитула, дата/время и номера слайдов управляются на уровне мастер‑слайда и могут применяться глобально или корректироваться для отдельного слайда. Заголовки поддерживаются в заметках и раздаточных материалах, где можно включать их видимость и задавать текст заголовка, нижнего колонтитула, даты/времени и номеров страниц через специализированный менеджер заголовков и нижних колонтитулов на мастер‑слайде заметок или отдельных слайдах заметок. Эта статья описывает ключевые схемы обновления этих заполнителей и последовательного распространения изменений по всей презентации.

## **Управление текстом заголовка и нижнего колонтитула**

В этом разделе вы узнаете, как управлять содержимым заголовка и нижнего колонтитула в презентации — включать или изменять нижний колонтитул, дату и время, а также номера слайдов. Мы кратко опишем области применения этих настроек (вся презентация, отдельные слайды и представления заметок/раздаточных материалов) и покажем, как быстро и последовательно обновлять их с помощью API Aspose.Slides.

Пример кода ниже открывает презентацию, включает и задает текст нижнего колонтитула, обновляет текст заголовка на мастер‑слайде заметок и сохраняет файл.
```py
import aspose.slides as slides

# Функция для установки текста заголовка.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Загрузить презентацию.
with slides.Presentation("sample.pptx") as presentation:
    # Установить нижний колонтитул.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Доступ и обновление заголовка.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление заголовками и нижними колонтитулами на слайдах заметок**

В этом разделе вы узнаете, как управлять заголовками и нижними колонтитулами специально для слайдов заметок в Aspose.Slides. Мы рассмотрим включение соответствующих заполнителей, задание текста для нижних колонтитулов, даты/времени и номеров страниц, а также последовательное применение этих изменений к мастер‑слайду заметок и отдельным страницам заметок.

Выполните следующие шаги:

1. Загрузите файл презентации.
1. Получите мастер‑слайд заметок и его [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. На мастер‑слайде заметок включите видимость Header, Footer, Slide number и Date-time для мастера и всех дочерних слайдов заметок.
1. На мастер‑слайде заметок задайте текст для Header, Footer и Date-time для мастера и всех дочерних слайдов заметок.
1. Получите слайд заметок для первого слайда презентации и его [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
1. Только для этого первого слайда заметок убедитесь, что Header, Footer, Slide number и Date-time видимы (включите те, которые отключены).
1. Только для этого первого слайда заметок задайте текст для Header, Footer и Date-time.
1. Сохраните презентацию в формате PPTX.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Сделать видимыми мастер‑слайд заметок и все дочерние плейсхолдеры заголовков, нижних колонтитулов, номеров слайдов и даты/времени.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Установить текст на мастер‑слайде заметок и всех дочерних плейсхолдерах заголовка, нижнего колонтитула и даты/времени.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Изменить настройки заголовка, нижнего колонтитула, номера слайда и даты/времени только для первого слайда заметок.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Убедиться, что плейсхолдеры заголовка, нижнего колонтитула, номера слайда и даты/времени видимы.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Установить текст в плейсхолдерах заголовка, нижнего колонтитула и даты/времени слайда заметок.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли добавить «заголовок» к обычным слайдам?**

В PowerPoint «Header» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это те же ограничения: заголовок только для Notes/Handout, а на слайдах — Footer/DateTime/SlideNumber.

**Что если макет не содержит области нижнего колонтитула — можно ли «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как задать стартовый номер слайда, отличный от 1?**

Установите [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) презентации; после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они рендерятся как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в результирующем формате вместе с остальным содержимым.