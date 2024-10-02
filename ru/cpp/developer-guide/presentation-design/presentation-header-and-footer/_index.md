---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/cpp/presentation-header-and-footer/
keywords: "Заголовок и нижний колонтитул в PowerPoint"
description: "Заголовок и нижний колонтитул в PowerPoint с помощью Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/cpp/) предоставляет поддержку для работы с текстом заголовков и нижних колонтитулов слайдов, который на самом деле поддерживается на уровне мастер-слайдов.

{{% /alert %}} 

[Aspose.Slides для C++](/slides/ru/cpp/) предоставляет функцию управления заголовками и нижними колонтитулами в слайдах презентации. Они фактически управляются на уровне мастер-презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Заметки для какого-то конкретного слайда могут быть обновлены, как показано в примере ниже:

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
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"Привет, новый заголовок");
            }
        }
    }
}
```

``` cpp
// Загрузить презентацию
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Установка нижнего колонтитула
pres->get_HeaderFooterManager()->SetAllFootersText(u"Текст моего нижнего колонтитула");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Доступ и обновление заголовка
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Сохранить презентацию
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Управление заголовком и нижним колонтитулом в раздаточных материалах и заметках**
Aspose.Slides для C++ поддерживает заголовок и нижний колонтитул в раздаточных материалах и заметках. Пожалуйста, следуйте приведённым ниже шагам:

- Загрузите [Презентацию](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастер-заметок и всех заметок.
- Установите видимость мастер-заметок и всех дочерних мест для нижнего колонтитула.
- Установите видимость мастер-заметок и всех дочерних мест для даты и времени.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Установите видимость места заголовка на слайде заметок.
- Установите текст в место заголовка на слайде заметок.
- Установите текст в место даты и времени на слайде заметок.
- Запишите изменённый файл презентации.

Фрагмент кода представлен в приведённом ниже примере.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Измените настройки заголовка и нижнего колонтитула для мастер-заметок и всех заметок
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// сделайте мастер-заметку и все дочерние места для нижнего колонтитула видимыми
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// сделайте мастер-заметку и все дочерние места для заголовков видимыми
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// сделайте мастер-заметку и все дочерние места для номеров слайдов видимыми
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// сделайте мастер-заметку и все дочерние места для даты и времени видимыми
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// установите текст для мастер-заметки и всех дочерних мест заголовков
	headerFooterManager->SetHeaderAndChildHeadersText(u"Текст заголовка");
	// установите текст для мастер-заметки и всех дочерних мест нижнего колонтитула
	headerFooterManager->SetFooterAndChildFootersText(u"Текст нижнего колонтитула");
	// установите текст для мастер-заметки и всех дочерних мест даты и времени
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Текст даты и времени");
}

// Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// сделайте это место для заголовка заметки видимым
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// сделайте это место для нижнего колонтитула заметки видимым
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// сделайте это место для номера слайда заметки видимым
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// сделайте это место для даты и времени заметки видимым
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// установите текст для места заголовка на слайде заметок
	headerFooterManager->SetHeaderText(u"Новый текст заголовка");
	// установите текст для места нижнего колонтитула на слайде заметок
	headerFooterManager->SetFooterText(u"Новый текст нижнего колонтитула");
	// установите текст для места даты и времени на слайде заметок
	headerFooterManager->SetDateTimeText(u"Новый текст даты и времени");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```