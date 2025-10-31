---
title: Управление заголовками и нижними колонтитулами презентации с помощью Python
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

Aspose.Slides для Python позволяет управлять заполнителями заголовков и нижних колонтитулов по всей презентации с точным диапазоном. Текст нижнего колонтитула, дата/время и номера слайдов управляются на уровне шаблона и могут применяться глобально или настраиваться для отдельного слайда. Заголовки поддерживаются в заметках и раздаточных материалах, где можно включать их отображение и задавать текст заголовка, нижнего колонтитула, даты/времени и номеров страниц через специальный менеджер заголовков и нижних колонтитулов на мастер‑слайде заметок или отдельных слайдах заметок. В этой статье описаны основные шаблоны обновления этих заполнителей и распространения изменений по всей презентации.

## **Управление текстом заголовка и нижнего колонтитула**

В этом разделе вы узнаете, как управлять содержимым заголовков и нижних колонтитулов в презентации — включать или изменять нижний колонтитул, дату и время, а также номера слайдов. Мы кратко опишем области применения этих настроек (вся презентация, отдельные слайды и представления заметок/раздаточных материалов) и покажем, как быстро и последовательно обновлять их с помощью API Aspose.Slides.

Пример кода ниже открывает презентацию, включает и задает текст нижнего колонтитула, обновляет текст заголовка на мастер‑слайде заметок и сохраняет файл.

```py
import aspose.slides as slides

# Функция для задания текста заголовка.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Привет, это заголовок"


# Загрузка презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Установить нижний колонтитул.
    presentation.header_footer_manager.set_all_footers_text("Мой текст нижнего колонтитула")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Доступ к мастер‑слайду заметок и его обновление.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление заголовком и нижним колонтитулом на слайдах заметок**

В этом разделе вы узнаете, как управлять заголовками и нижними колонтитулами именно для слайдов заметок в Aspose.Slides. Мы рассмотрим включение соответствующих заполнителей, задание текста для нижних колонтитулов, даты/времени и номеров страниц, а также последовательное применение этих изменений к мастеру заметок и отдельным страницам заметок.

Выполните следующие шаги:

1. Загрузите файл презентации.  
1. Получите мастер‑слайд заметок и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
1. На мастер‑слайде заметок включите отображение заголовка, нижнего колонтитула, номера слайда и даты/времени для мастера и всех дочерних слайдов заметок.  
1. На мастер‑слайде заметок задайте текст заголовка, нижнего колонтитула и даты/времени для мастера и всех дочерних слайдов заметок.  
1. Получите слайд заметок первого слайда презентации и его [менеджер заголовков и нижних колонтитулов](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
1. Только для этого первого слайда заметок убедитесь, что заголовок, нижний колонтитул, номер слайда и дата/время видимы (включите те, которые выключены).  
1. Только для этого первого слайда заметок задайте текст заголовка, нижнего колонтитула и даты/времени.  
1. Сохраните презентацию в формате PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Сделать видимыми все дочерние заполнители заголовка, нижнего колонтитула, номера слайда и даты/времени.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Задать текст на мастер‑слайде заметок и всех дочерних заполнителях заголовка, нижнего колонтитула и даты/времени.
        header_footer_manager.set_header_and_child_headers_text("Текст заголовка")
        header_footer_manager.set_footer_and_child_footers_text("Текст нижнего колонтитула")
        header_footer_manager.set_date_time_and_child_date_times_text("Текст даты и времени")

    # Изменить настройки заголовка, нижнего колонтитула, номера слайда и даты/времени только для первого слайда заметок.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Убедиться, что заполнители заголовка, нижнего колонтитула, номера слайда и даты/времени видимы.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Задать текст на заполнителях заголовка, нижнего колонтитула и даты/времени слайда заметок.
        header_footer_manager.set_header_text("Новый текст заголовка")
        header_footer_manager.set_footer_text("Новый текст нижнего колонтитула")
        header_footer_manager.set_date_time_text("Новый текст даты и времени")

    # Сохранить презентацию.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли добавить «заголовок» к обычным слайдам?**

В PowerPoint «Заголовок» существует только для заметок и раздаточных листов; на обычных слайдах поддерживаются лишь нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для Заметок/Раздаточных листов, а на слайдах — Нижний колонтитул/Дата‑время/Номер слайда.

**А если в макете нет области нижнего колонтитула — можно включить её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы API и методы предназначены для ситуаций, когда заполнитель отсутствует или скрыт.

**Как задать начальный номер слайда, отличный от 1?**

Установите [первый номер слайда](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) презентации; после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.