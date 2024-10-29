---
title: Блокировка презентации
type: docs
weight: 110
url: /ru/net/presentation-locking/
---

## **Блокировка презентации**
Распространенное использование **Aspose.Slides** — создание, обновление и сохранение презентаций Microsoft PowerPoint 2007 (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложения, использующего Aspose.Slides таким образом, получают доступ к выходным презентациям. Защита их от редактирования — распространенная проблема. Важно, чтобы автоматически генерируемые презентации сохраняли оригинальное форматирование и содержание.

Это объясняет, как конструируются презентации и слайды, и как Aspose.Slides для .NET может применять защиту к презентации и затем удалять ее. Эта функция уникальна для Aspose.Slides и на момент написания недоступна в Microsoft PowerPoint. Это дает разработчикам способ контролировать, как используются презентации, создаваемые их приложениями.
## **Состав слайда**
Слайд PPTX состоит из множества компонентов, таких как автоформы, таблицы, OLE-объекты, сгруппированные формы, рамки для изображений, видеокадры, соединители и другие различные элементы, доступные для создания презентации.

В Aspose.Slides для .NET каждый элемент на слайде превращается в объект Shape. Другими словами, каждый элемент на слайде — это либо объект Shape, либо объект, производный от объекта Shape.

Структура PPTX сложна, поэтому в отличие от PPT, где можно использовать универсальную блокировку для всех типов форм, для разных типов форм существуют разные типы блокировок. Класс BaseShapeLock — это универсальный класс блокировки PPTX. В Aspose.Slides для .NET поддерживаются следующие типы блокировок для PPTX.

- AutoShapeLock блокирует автоформы.
- ConnectorLock блокирует соединительные формы.
- GraphicalObjectLock блокирует графические объекты.
- GroupshapeLock блокирует групповые формы.
- PictureFrameLock блокирует рамки для изображений.

Любое действие, выполняемое над всеми объектами Shape в объекте Presentation, применяется ко всей презентации.
## **Применение и снятие защиты**
Применение защиты гарантирует, что презентация не может быть отредактирована. Это полезная техника для защиты содержания презентации.

**Применение защиты к формам PPTX**

Aspose.Slides для .NET предоставляет класс Shape для работы с формой на слайде.

Как было упомянуто ранее, каждый класс формы имеет связанный класс блокировки формы для защиты. Эта статья фокусируется на блокировках NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что формы не могут быть выбраны (через щелчки мыши или другие методы выбора), и их нельзя перемещать или изменять размер.

Приведенные ниже примеры кода применяют защиту ко всем типам форм в презентации.

``` csharp

 //Создаем объект класса Presentation, который представляет файл PPTX

PresentationEx pTemplate = new PresentationEx("Применение защиты.pptx");//Создаем объект класса Presentation, который представляет файл PPTX


//Объект ISlide для доступа к слайдам в презентации

SlideEx slide = pTemplate.Slides[0];

//Объект IShape для хранения временных форм

ShapeEx shape;

//Перебираем все слайды в презентации

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Перебираем все формы в слайде

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//если форма является автоформой

		if (shape is AutoShapeEx)

		{

			//Приведение к автоформе и получение блокировки автоформы

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Применение блокировок форм

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//если форма является групповой формой

		else if (shape is GroupShapeEx)

		{

			//Приведение к групповой форме и получение блокировки групповой формы

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Применение блокировок форм

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//если форма является соединителем

		else if (shape is ConnectorEx)

		{

			//Приведение к соединительной форме и получение блокировки соединительной формы

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Применение блокировок форм

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//если форма является рамкой для изображения

		else if (shape is PictureFrameEx)

		{

			//Приведение к рамке для изображения и получение блокировки рамки

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Применение блокировок форм

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Сохранение файла презентации

pTemplate.Save("ЗаблокированныйШаблон.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Снятие защиты**

Защита, примененная с использованием Aspose.Slides для .NET, может быть снята только с помощью Aspose.Slides для .NET. Чтобы разблокировать форму, установите значение примененной блокировки в false. Пример кода, который следует, показывает, как разблокировать формы в заблокированной презентации.

``` csharp

 //Открываем нужную презентацию

PresentationEx pTemplate = new PresentationEx("ЗаблокированныйШаблон.pptx");
 
//Объект ISlide для доступа к слайдам в презентации

SlideEx slide = pTemplate.Slides[0];

//Объект IShape для хранения временных форм

ShapeEx shape;

//Перебираем все слайды в презентации

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Перебираем все формы в слайде

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//если форма является автоформой

		if (shape is AutoShapeEx)

		{

			//Приведение к автоформе и получение блокировки автоформы

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Применение разблокировки форм

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//если форма является групповой формой

		else if (shape is GroupShapeEx)

		{

			//Приведение к групповой форме и получение блокировки групповой формы

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Применение разблокировки форм

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//если форма является соединителем

		else if (shape is ConnectorEx)

		{

			//Приведение к соединительной форме и получение блокировки соединительной формы

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Применение разблокировки форм

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//если форма является рамкой для изображения

		else if (shape is PictureFrameEx)

		{

			//Приведение к рамке для изображения и получение блокировки рамки

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Применение разблокировки форм

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Сохранение файла презентации

pTemplate.Save("СнятиеЗащитыПример.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)