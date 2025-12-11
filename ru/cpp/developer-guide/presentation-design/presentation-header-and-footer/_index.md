---
title: Управление заголовками и нижними колонтитулами презентаций в C++
linktitle: Заголовок и колонтитул
type: docs
weight: 140
url: /ru/cpp/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный материал
- примечания
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Используйте Aspose.Slides для C++, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального вида."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/cpp/) предоставляет поддержку для работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически поддерживаются на уровне мастер‑слайда.

{{% /alert %}} 

[Aspose.Slides for C++](/slides/ru/cpp/) предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Они фактически управляются на уровне мастера презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Примечания к некоторому конкретному слайду могут быть обновлены, как показано в примере ниже:
``` cpp
// Функция для установки текста заголовка/нижнего колонтитула
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Загрузка презентации
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Установка нижнего колонтитула
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Доступ и обновление заголовка
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Сохранение презентации
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```


## **Управление заголовками и нижними колонтитулами на раздаточных и слайдах примечаний**
Aspose.Slides for C++ поддерживает заголовки и нижние колонтитулы в раздаточных листах и слайдах примечаний. Пожалуйста, выполните следующие шаги:

- Загрузите [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)содержащий видео.
- Измените настройки Header и Footer для master‑примечаний и всех слайдов примечаний.
- Сделайте видимыми master‑слайд примечаний и все дочерние заполнители Footer.
- Сделайте видимыми master‑слайд примечаний и все дочерние заполнители Date and time.
- Измените настройки Header и Footer только для первого слайда примечаний.
- Сделайте видимым заполнитель Header на слайде примечаний.
- Установите текст в заполнитель Header слайда примечаний.
- Установите текст в заполнитель Date-time слайда примечаний.
- Запишите изменённый файл презентации.

Фрагмент кода предоставлен в примере ниже.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Изменить настройки заголовка и нижнего колонтитула для мастер‑заметок и всех слайдов заметок
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// сделать мастер‑слайд заметок и все дочерние заполняющие элементы Footer видимыми
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// сделать мастер‑слайд заметок и все дочерние заполняющие элементы Header видимыми
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// сделать мастер‑слайд заметок и все дочерние заполняющие элементы SlideNumber видимыми
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// сделать мастер‑слайд заметок и все дочерние заполняющие элементы Date and time видимыми
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// установить текст для мастер‑слайда заметок и всех дочерних заполняющих элементов Header
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// установить текст для мастер‑слайда заметок и всех дочерних заполняющих элементов Footer
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// установить текст для мастер‑слайда заметок и всех дочерних заполняющих элементов Date and time
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// сделать видимым заполнитель Header этого слайда заметок
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// сделать видимым заполнитель Footer этого слайда заметок
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// сделать видимым заполнитель SlideNumber этого слайда заметок
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// сделать видимым заполнитель Date-time этого слайда заметок
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// установить текст в заполнитель Header слайда заметок
	headerFooterManager->SetHeaderText(u"New header text");
	// установить текст в заполнитель Footer слайда заметок
	headerFooterManager->SetFooterText(u"New footer text");
	// установить текст в заполнитель Date-time слайда заметок
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Могу ли я добавить "header" к обычным слайдам?**

В PowerPoint "Header" существует только для примечаний и раздаточных материалов; на обычных слайдах поддерживаемыми элементами являются нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: header только для Notes/Handout, а на слайдах — Footer/DateTime/SlideNumber.

**Что если в макете нет области footer — могу ли я "включить" её видимость?**

Да. Проверьте видимость через менеджер header/footer и включите её при необходимости. Эти индикаторы и методы API предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как сделать, чтобы номер слайда начинался с значения, отличного от 1?**

Установите [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/); после этого вся нумерация пересчитывается. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они рендерятся как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах примечаний, они также появятся в выходном формате вместе с остальным содержимым.