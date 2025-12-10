---
title: Управление SmartArt в презентациях PowerPoint в .NET
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/net/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- скрытое свойство
- организационная схема
- схема организации с изображением
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для .NET, используя понятные примеры кода на C#, ускоряющие разработку слайдов и автоматизацию."
---

## **Получить текст из объекта SmartArt**
Сейчас свойство TextFrame добавлено в интерфейс ISmartArtShape и класс SmartArtShape соответственно. Это свойство позволяет получить весь текст из SmartArt, если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.
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


## **Изменить тип макета объекта SmartArt**
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


## **Проверить скрытое свойство объекта SmartArt**
Обратите внимание, что метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если данный узел скрыт в модели данных. Чтобы проверить скрытое свойство любого узла SmartArt, выполните следующие шаги:

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
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получить или установить тип организационной схемы, связанный с текущим узлом. Чтобы получить или установить тип схемы, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt на слайд.
- Получите или установите тип организационной схемы.
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


## **Создать организационную схему с изображением**
Aspose.Slides for .NET предоставляет простой API для создания PictureOrganization схем простым способом. Чтобы создать схему на слайде:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд по его индексу.
1. Добавьте схему с данными по умолчанию и нужным типом (ChartType.PictureOrganizationChart).
1. Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания схемы.
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

**Поддерживает ли SmartArt отражение/инверсию для RTL‑языков?**

Да. Свойство [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает инверсию.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/net/shape-manipulations/) через коллекцию фигур ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) или [клонировать весь слайд](/slides/ru/net/clone-slides/), содержащий эту форму. Оба подхода сохраняют размер, расположение и стили.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/net/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG с помощью API, который преобразует слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычная практика — использовать [альтернативный текст](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) или [Имя](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) и искать форму по этому атрибуту в [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), затем проверять тип, чтобы подтвердить, что это [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). В документации описаны типичные методы поиска и работы с формами.