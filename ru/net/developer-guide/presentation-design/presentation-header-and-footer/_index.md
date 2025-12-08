---
title: Заголовок и нижний колонтитул презентации
type: docs
weight: 140
url: /ru/net/presentation-header-and-footer/
keywords: "Заголовок, нижний колонтитул, установить заголовок, установить нижний колонтитул, установить заголовок и нижний колонтитул, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Заголовок и нижний колонтитул PowerPoint на C# или .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ru/net/) предоставляет поддержку работы с текстом заголовков и нижних колонтитулов слайдов, которые фактически управляются на уровне мастера слайда.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ru/net/) обеспечивает возможность управления заголовками и нижними колонтитулами внутри презентационных слайдов. Они действительно управляются на уровне мастера презентации.
## **Управление текстом заголовков и нижних колонтитулов**
Примечания к отдельному слайду можно обновить, как показано в примере ниже:
```c#
// Загрузка презентации
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
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **Управление заголовками и нижними колонтитулами в раздаточных материалах и слайдах с примечаниями**
Aspose.Slides for .NET поддерживает заголовки и нижние колонтитулы в раздаточных материалах и слайдах с примечаниями. Пожалуйста, выполните следующие шаги:

- Загрузите [Презентацию](https://reference.aspose.com/slides/net/aspose.slides/presentation) с видеоматериалом.
- Измените настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок.
- Сделайте видимыми заполнители нижних колонтитулов в мастере заметок и во всех дочерних слайдах.
- Сделайте видимыми заполнители даты и времени в мастере заметок и во всех дочерних слайдах.
- Измените настройки заголовка и нижнего колонтитула только для первого слайда заметок.
- Сделайте видимым заполнитель заголовка в слайде заметок.
- Установите текст в заполнитель заголовка слайда заметок.
- Установите текст в заполнитель даты и времени слайда заметок.
- Сохраните изменённый файл презентации.

Ниже приведён пример кода.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Изменить настройки заголовка и нижнего колонтитула для мастера заметок и всех слайдов заметок
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители нижнего колонтитула видимыми
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители заголовка видимыми
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители номеров слайдов видимыми
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // сделать мастер‑слайд заметок и все дочерние заполнители даты и времени видимыми

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // установить текст в мастер‑слайд заметок и все дочерние заполнители заголовка
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // установить текст в мастер‑слайд заметок и все дочерние заполнители нижнего колонтитула
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // установить текст в мастер‑слайд заметок и все дочерние заполнители даты и времени
	}

	// Изменить настройки заголовка и нижнего колонтитула только для первого слайда заметок
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // сделать заполнитель заголовка этого слайда заметок видимым

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // сделать заполнитель нижнего колонтитула этого слайда заметок видимым

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // сделать заполнитель номера слайда этого слайда заметок видимым

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // сделать заполнитель даты и времени этого слайда заметок видимым

		headerFooterManager.SetHeaderText("New header text"); // установить текст в заполнитель заголовка слайда заметок
		headerFooterManager.SetFooterText("New footer text"); // установить текст в заполнитель нижнего колонтитула слайда заметок
		headerFooterManager.SetDateTimeText("New date and time text"); // установить текст в заполнитель даты и времени слайда заметок
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**Можно ли добавить «заголовок» к обычным слайдам?**

В PowerPoint «Заголовок» существует только для заметок и раздаточных материалов; на обычных слайдах поддерживаются только нижний колонтитул, дата/время и номер слайда. В Aspose.Slides это соответствует тем же ограничениям: заголовок только для заметок/раздаточных материалов, а на слайдах — нижний колонтитул/дата‑время/номер слайда.

**Если в макете отсутствует область нижнего колонтитула, можно ли «включить» её видимость?**

Да. Проверьте видимость через менеджер заголовков/нижних колонтитулов и включите её при необходимости. Эти индикаторы API и методы предназначены для случаев, когда заполнитель отсутствует или скрыт.

**Как задать номер слайда, начинающийся не с 1?**

Установите [номер первого слайда] (https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) презентации; после этого нумерация будет пересчитана. Например, можно начать с 0 или 10 и скрыть номер на титульном слайде.

**Что происходит с заголовками/нижними колонтитулами при экспорте в PDF/изображения/HTML?**

Они отображаются как обычные текстовые элементы презентации. То есть, если элементы видимы на слайдах/страницах заметок, они также появятся в выходном формате вместе с остальным содержимым.