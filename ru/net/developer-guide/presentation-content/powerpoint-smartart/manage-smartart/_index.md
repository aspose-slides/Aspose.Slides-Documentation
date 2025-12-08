---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/net/manage-smartart/
keywords: "SmartArt, текст из SmartArt, организационная диаграмма, диаграмма с изображениями, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "SmartArt и организационная диаграмма в презентациях PowerPoint на C# или .NET"
---

## **Получить текст из SmartArt**
Теперь свойство TextFrame добавлено к интерфейсу ISmartArtShape и классу SmartArtShape соответственно. Это свойство позволяет получить весь текст из SmartArt, если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **Изменить тип макета SmartArt**
Чтобы изменить тип макета SmartArt, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте SmartArt BasicBlockList.
- Измените LayoutType на BasicProcess.
- Запишите презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```c#
using (Presentation presentation = new Presentation())
{
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Изменить LayoutType на BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Сохранение презентации
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **Проверить свойство Hidden у SmartArt**
Обратите внимание, метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если данный узел скрыт в модели данных. Чтобы проверить свойство hidden у любого узла SmartArt, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство isHidden.
- Запишите презентацию в файл PPTX.

В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```c#
using (Presentation presentation = new Presentation())
{
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Добавить узел в SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Проверить свойство IsHidden
    bool hidden = node.IsHidden; // Возвращает true

    if (hidden)
    {
        // Выполнить некоторые действия или уведомления
    }
    // Сохранение презентации
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **Получить или установить тип организационной схемы**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получать или задавать тип организационной схемы, связанный с текущим узлом. Чтобы получить или установить тип организационной схемы, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt на слайд.
- Получите или задайте тип организационной схемы.
- Запишите презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```c#
using (Presentation presentation = new Presentation())
{
    // Добавить SmartArt BasicProcess
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Получить или установить тип организационной схемы
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Сохранение презентации
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **Создать организационную схему с изображениями**
Aspose.Slides for .NET предоставляет простой API для создания диаграмм PictureOrganization. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и нужным типом (ChartType.PictureOrganizationChart).
1. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы.
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение/реверс для RTL-языков?**

Да. Свойство [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверс.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [clone the SmartArt shape](/slides/ru/net/shape-manipulations/) через коллекцию фигур ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) или [clone the entire slide](/slides/ru/net/clone-slides/), содержащий эту фигуру. Оба подхода сохраняют размер, позицию и стили.

**Как отобразить SmartArt в растровом изображении для предварительного просмотра или веб‑экспорта?**

[Render the slide](/slides/ru/net/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, преобразующего слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Распространённый приём — использовать [alternative text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) или [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) и искать фигуру по этому атрибуту в [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), затем проверять тип, чтобы подтвердить, что это [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). Документация описывает типичные техники поиска и работы с фигурами.