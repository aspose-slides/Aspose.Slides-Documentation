---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/python-net/presentation-header-and-footer/
keywords: "Заголовок, нижний колонтитул, установить заголовок, установить нижний колонтитул, установить заголовок и нижний колонтитул, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Заголовок и нижний колонтитул PowerPoint на Python"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/python-net/) предоставляет поддержку работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически поддерживаются на уровне мастера слайдов.

{{% /alert %}} 

[Aspose.Slides для Python через .NET](/slides/ru/python-net/) предоставляет функцию управления заголовками и нижними колонтитулами внутри слайдов презентации. На самом деле они управляются на уровне мастера презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Заметки некоторых конкретных слайдов могут быть обновлены, как показано в примере ниже:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Метод для установки текста заголовка/нижнего колонтитула
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Привет, новый заголовок"

# Загрузка презентации
with slides.Presentation("combined_with_master.pptx") as pres:
    # Установка нижнего колонтитула
    pres.header_footer_manager.set_all_footers_text("Мой текст нижнего колонтитула")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # Доступ и обновление заголовка
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # Сохранение презентации
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Управление заголовком и нижним колонтитулом в раздаточных материалах и слайдах заметок**
Aspose.Slides для Python через .NET поддерживает заголовок и нижний колонтитул в раздаточных материалах и слайдах заметок. Пожалуйста, выполните следующие шаги:

- Загрузите [Презентацию](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок.
- Установите видимость мастера заметок и всех дочерних заполнитель нижнего колонтитула.
- Установите видимость мастера заметок и всех дочерних заполнителей даты и времени.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Установите видимость заполнителя заголовка слайда заметок.
- Установите текст для заполнителя заголовка слайда заметок.
- Установите текст для заполнителя даты и времени слайда заметок.
- Запишите модифицированный файл презентации.

Фрагмент кода предоставлен в следующем примере.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# Сделайте видимыми мастер-слайд заметок и все дочерние заполнители нижнего колонтитула
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# Установите текст для мастер-слайда заметок и всех дочерних заполнителей заголовка
		headerFooterManager.set_header_and_child_headers_text("Текст заголовка") 
		headerFooterManager.set_footer_and_child_footers_text("Текст нижнего колонтитула") 
		headerFooterManager.set_date_time_and_child_date_times_text("Текст даты и времени") 

	# Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# Сделайте заполнитель заголовка слайда заметок видимым

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# Установите текст для заполнителя заголовка слайда заметок
		headerFooterManager.set_header_text("Новый текст заголовка") 
		headerFooterManager.set_footer_text("Новый текст нижнего колонтитула") 
		headerFooterManager.set_date_time_text("Новый текст даты и времени") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```