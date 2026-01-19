---
title: Блокировка презентаций
type: docs
weight: 110
url: /ru/net/presentation-locking/
---

## **Блокировка презентаций**
Общее применение **Aspose.Slides** — создание, обновление и сохранение презентаций Microsoft PowerPoint 2007 (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложения, использующего Aspose.Slides таким образом, получают доступ к полученным презентациям. Защита их от редактирования является распространённой задачей. Важно, чтобы автоматически сгенерированные презентации сохраняли оригинальное форматирование и содержание.

В этой статье объясняется, как построены презентации и слайды, а также как Aspose.Slides for .NET может применить защиту к презентации и затем снять её. Эта возможность уникальна для Aspose.Slides и, на момент написания, недоступна в Microsoft PowerPoint. Она предоставляет разработчикам способ контролировать использование презентаций, создаваемых их приложениями.

## **Состав слайда**
Слайд PPTX состоит из множества компонентов, таких как автофигуры, таблицы, OLE‑объекты, сгруппированные фигуры, изображения, видеокадры, коннекторы и другие элементы, используемые для построения презентации.

В Aspose.Slides for .NET каждый элемент на слайде преобразуется в объект Shape. Иными словами, каждый элемент на слайде является объектом Shape или объектом, наследующим Shape.

Структура PPTX сложна, поэтому в отличие от PPT, где можно использовать один универсальный замок для всех типов фигур, в PPTX существуют разные типы замков для разных типов фигур. Класс BaseShapeLock является универсальным классом блокировки PPTX. В Aspose.Slides for .NET для PPTX поддерживаются следующие типы замков:

- AutoShapeLock блокирует автофигуры.
- ConnectorLock блокирует коннекторные фигуры.
- GraphicalObjectLock блокирует графические объекты.
- GroupshapeLock блокирует групповые фигуры.
- PictureFrameLock блокирует рамки изображений.

Любое действие, выполненное над всеми объектами Shape в объекте Presentation, применяется ко всей презентации.

## **Применение и удаление защиты**
Применение защиты гарантирует, что презентация не может быть отредактирована. Это полезный метод защиты содержимого презентации.

**Применение защиты к фигурам PPTX**

Aspose.Slides for .NET предоставляет класс Shape для работы с фигурой на слайде.

Как упоминалось ранее, каждый класс фигуры имеет соответствующий класс блокировки фигуры для защиты. В этой статье рассматриваются замки NoSelect, NoMove и NoResize. Они обеспечивают невозможность выбора фигур (через щелчки мышью или другими способами), перемещения и изменения размеров.

Примеры кода ниже применяют защиту ко всем типам фигур в презентации.

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Удаление защиты**

Защита, применённая с помощью Aspose.Slides for .NET, может быть удалена только с помощью Aspose.Slides for .NET. Чтобы разблокировать фигуру, установите значение соответствующего замка в false. Пример кода ниже показывает, как разблокировать фигуры в защищённой презентации.

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Скачать пример кода**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)