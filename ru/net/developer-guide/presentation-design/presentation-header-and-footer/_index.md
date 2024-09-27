---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/net/presentation-header-and-footer/
keywords: "Заголовок, нижний колонтитул, установить заголовок, установить нижний колонтитул, установить заголовок и нижний колонтул, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Заголовок и нижний колонтитул PowerPoint на C# или .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/net/) предоставляет поддержку для работы с текстами заголовков и нижних колонтитулов слайдов, которые фактически поддерживаются на уровне мастер-слайда.

{{% /alert %}} 

[Aspose.Slides для .NET](/slides/ru/net/) предоставляет возможность управления заголовками и нижними колонтитулами внутри слайдов презентации. Они фактически управляются на уровне мастер-презентации.
## **Управление текстом заголовка и нижнего колонтитула**
Заметки некоторых конкретных слайдов могут быть обновлены, как показано в примере ниже:

```c#
// Загрузка презентации
Presentation pres = new Presentation("headerTest.pptx");

// Установка нижнего колонтитула
pres.HeaderFooterManager.SetAllFootersText("Мой текст нижнего колонтитула");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Доступ к заголовку и его обновление
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Сохранение презентации
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
                ((IAutoShape)shape).TextFrame.Text = "Привет новый заголовок";
            }
        }
    }
}
```




## **Управление заголовком и нижним колонтитулом на листах раздаток и заметок**
Aspose.Slides для .NET поддерживает заголовки и нижние колонтитулы на листах раздаток и заметок. Пожалуйста, выполните следующие шаги:

- Загрузите [Презентацию](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащую видео.
- Измените настройки заголовков и нижних колонтитулов для мастер-заметок и всех листов заметок.
- Установите мастер-заметки и все дочерние заполнители нижнего колонтитула видимыми.
- Установите мастер-заметки и все дочерние заполнители даты и времени видимыми.
- Измените настройки заголовков и нижних колонтитулов только для первого листа заметок.
- Установите заполнитель заголовка листа заметок видимым.
- Установите текст в заполнителе заголовка листа заметок.
- Установите текст в заполнителе даты и времени листа заметок.
- Запишите изменённый файл презентации.

Код, приведённый в приведённом ниже примере.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Измените настройки заголовков и нижних колонтитулов для мастер-заметок и всех листов заметок
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // сделать мастер-заметки и все дочерние заполнители нижнего колонтитула видимыми
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // сделать мастер-заметки и все дочерние заполнители заголовка видимыми
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // сделать мастер-заметки и все дочерние заполнители номера слайда видимыми
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // сделать мастер-заметки и все дочерние заполнители даты и времени видимыми

		headerFooterManager.SetHeaderAndChildHeadersText("Текст заголовка"); // установить текст в мастер-заметки и все дочерние заполнители заголовка
		headerFooterManager.SetFooterAndChildFootersText("Текст нижнего колонтитула"); // установить текст в мастер-заметки и все дочерние заполнители нижнего колонтитула
		headerFooterManager.SetDateTimeAndChildDateTimesText("Текст даты и времени"); // установить текст в мастер-заметки и все дочерние заполнители даты и времени
	}

	// Измените настройки заголовков и нижних колонтитулов только для первого листа заметок
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // сделать заполнитель заголовка этого листа заметок видимым

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // сделать заполнитель нижнего колонтитула этого листа заметок видимым

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // сделать заполнитель номера слайда этого листа заметок видимым

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // сделать заполнитель даты и времени этого листа заметок видимым

		headerFooterManager.SetHeaderText("Новый текст заголовка"); // установить текст в заполнителе заголовка листа заметок
		headerFooterManager.SetFooterText("Новый текст нижнего колонтитула"); // установить текст в заполнителе нижнего колонтитула листа заметок
		headerFooterManager.SetDateTimeText("Новый текст даты и времени"); // установить текст в заполнителе даты и времени листа заметок
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```