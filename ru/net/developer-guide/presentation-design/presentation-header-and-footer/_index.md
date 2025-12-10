---
title: Управление заголовками и нижними колонтитулами презентаций в .NET
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
description: "Используйте Aspose.Slides for .NET для добавления и настройки заголовков и нижних колонтитулов в презентациях PowerPoint и OpenDocument, чтобы придать им профессиональный вид."
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ru/net/) предоставляет поддержку для работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически находятся на уровне мастер‑слайда.
{{% /alert %}} 

Aspose.Slides for .NET предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Фактически они управляются на уровне мастера презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Заметки некоторого конкретного слайда могут быть обновлены, как показано в примере ниже:
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
// Метод для установки текста заголовка/нижнего колонтитула
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





## **Управление заголовками и нижними колонтитулами на раздаточных и заметочных слайдах**
Aspose.Slides for .NET поддерживает заголовки и нижние колонтитулы в раздаточных и заметочных слайдах. Пожалуйста, выполните следующие действия:

- Загрузите [Презентацию ](https://reference.aspose.com/slides/net/aspose.slides/presentation)с видео.
- Измените настройки заголовка и нижнего колонтитула для мастер‑страницы заметок и всех слайдов заметок.
- Сделайте видимыми плейсхолдеры нижнего колонтитула на мастер‑слайде заметок и всех дочерних слайдах.
- Сделайте видимыми плейсхолдеры даты и времени на мастер‑слайде заметок и всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым плейсхолдер заголовка на слайде заметок.
- Установите текст в плейсхолдер заголовка слайда заметок.
- Установите текст в плейсхолдер даты и времени слайда заметок.
- Сохраните изменённый файл презентации.

Пример кода приведён ниже.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Изменить настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // сделать мастер‑слайд заметок и все дочерние плейсхолдеры нижнего колонтитула видимыми
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // сделать мастер‑слайд заметок и все дочерние плейсхолдеры заголовка видимыми
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // сделать мастер‑слайд заметок и все дочерние плейсхолдеры номера слайда видимыми
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // сделать мастер‑слайд заметок и все дочерние плейсхолдеры даты и времени видимыми

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // установить текст в мастер‑слайд заметок и все дочерние плейсхолдеры заголовка
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // установить текст в мастер‑слайд заметок и все дочерние плейсхолдеры нижнего колонтитула
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // установить текст в мастер‑слайд заметок и все дочерние плейсхолдеры даты и времени
	}

	// Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // сделать плейсхолдер заголовка этого слайда заметок видимым

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // сделать плейсхолдер нижнего колонтитула этого слайда заметок видимым

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // сделать плейсхолдер номера слайда этого слайда заметок видимым

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // сделать плейсхолдер даты и времени этого слайда заметок видимым

		headerFooterManager.SetHeaderText("New header text"); // установить текст в плейсхолдер заголовка слайда заметок
		headerFooterManager.SetFooterText("New footer text"); // установить текст в плейсхолдер нижнего колонтитула слайда заметок
		headerFooterManager.SetDateTimeText("New date and time text"); // установить текст в плейсхолдер даты и времени слайда заметок
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Могу ли я добавить "заголовок" к обычным слайдам?**

В PowerPoint заголовок существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются лишь нижний колонтитул, дата/время и номер слайда. В Aspose.Slides действуют те же ограничения: заголовок только для заметок/раздаточных, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Что если макет не содержит области нижнего колонтитула — могу ли я включить её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы API и методы предназначены для случаев, когда плейсхолдер отсутствует или скрыт.

**Как задать начальный номер слайда, отличающийся от 1?**

Установите [первый номер слайда](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) презентации; после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в результирующем формате вместе с остальным содержимым.