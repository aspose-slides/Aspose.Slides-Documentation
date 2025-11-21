---
title: Управление заголовками и нижними колонтитулами презентации в .NET
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/net/presentation-header-and-footer/
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
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Используйте Aspose.Slides для .NET, чтобы добавлять и настраивать заголовки и нижние колонтитулы в презентациях PowerPoint и OpenDocument для профессионального вида."
---

{{% alert color="primary" %}}

[Aspose.Slides](/slides/ru/net/) предоставляет возможность работать с текстом заголовков и нижних колонтитулов слайдов, которые фактически поддерживаются на уровне мастер‑слайда.

{{% /alert %}}

[Aspose.Slides for .NET](/slides/ru/net/) предоставляет функцию управления заголовками и нижними колонтитулами внутри слайдов презентации. На самом деле они управляются на уровне мастер‑презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Заметки некоторого конкретного слайда можно обновить, как показано в примере ниже:
```c#
// Загрузить презентацию
Presentation pres = new Presentation("headerTest.pptx");

// Установка нижнего колонтитула
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Доступ и обновление заголовка
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// Сохранить презентацию
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// Метод установки текста заголовка/нижнего колонтитула
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```


## **Управление заголовком и нижним колонтитулом в раздаточных материалах и слайдах заметок**
Aspose.Slides for .NET поддерживает заголовки и нижние колонтитулы в раздаточных материалах и слайдах заметок. Пожалуйста, выполните следующие шаги:

- Load a [Презентацию](https://reference.aspose.com/slides/net/aspose.slides/presentation)содержащую видео.
- Измените настройки заголовка и нижнего колонтитула для мастер‑страницы заметок и всех слайдов заметок.
- Сделайте видимыми заполнители нижнего колонтитула на мастер‑слайде заметок и всех дочерних слайдах.
- Сделайте видимыми заполнители даты и времени на мастер‑слайде заметок и всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым заполнитель заголовка на слайде заметок.
- Установите текст в заполнитель заголовка слайда заметок.
- Установите текст в заполнитель даты‑времени слайда заметок.
- Запишите изменённый файл презентации.

Фрагмент кода предоставлен в примере ниже.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Изменить настройки заголовка и нижнего колонтитула для мастер-страницы заметок и всех слайдов заметок
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // сделать мастер-страницу заметок и все дочерние заполнители нижнего колонтитула видимыми
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // сделать мастер-страницу заметок и все дочерние заполнители заголовка видимыми
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // сделать мастер-страницу заметок и все дочерние заполнители номера слайда видимыми
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // сделать мастер-страницу заметок и все дочерние заполнители даты и времени видимыми

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // установить текст для мастер-страницы заметок и всех дочерних заполнителей заголовка
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // установить текст для мастер-страницы заметок и всех дочерних заполнителей нижнего колонтитула
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // установить текст для мастер-страницы заметок и всех дочерних заполнителей даты и времени
	}

	// Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // сделать этот заполнитель заголовка слайда заметок видимым

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // сделать этот заполнитель нижнего колонтитула слайда заметок видимым

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // сделать этот заполнитель номера слайда заметок видимым

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // сделать этот заполнитель даты и времени слайда заметок видимым

		headerFooterManager.SetHeaderText("New header text"); // установить текст в заполнитель заголовка слайда заметок
		headerFooterManager.SetFooterText("New footer text"); // установить текст в заполнитель нижнего колонтитула слайда заметок
		headerFooterManager.SetDateTimeText("New date and time text"); // установить текст в заполнитель даты и времени слайда заметок
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **Часто задаваемые вопросы**

**Могу ли я добавить «заголовок» к обычным слайдам?**

В PowerPoint «Заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаемыми элементами являются нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Что если в макете нет области нижнего колонтитула — могу ли я «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы и методы API разработаны для случаев, когда заполнитель отсутствует или скрыт.

**Как заставить номер слайда начинаться с значения, отличного от 1?**

Установите в презентации [первый номер слайда](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/); после этого нумерация пересчитывается. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в результирующем формате вместе с остальным содержимым.