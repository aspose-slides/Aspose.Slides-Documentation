---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/net/manage-smartart/
keywords: "SmartArt, текст из SmartArt, организационная диаграмма, диаграмма организации с изображениями, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "SmartArt и организационная диаграмма в презентациях PowerPoint на C# или .NET"
---

## **Получить текст из SmartArt**
Теперь к интерфейсу ISmartArtShape и классу SmartArtShape было добавлено свойство TextFrame. Это свойство позволяет получить весь текст из SmartArt, если он содержит не только текст узлов. Пример кода ниже поможет вам получить текст из узла SmartArt.

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
- Сохраните презентацию в виде файла PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

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



## **Проверить скрытое свойство SmartArt**
Обратите внимание, что метод com.aspose.slides.ISmartArtNode.isHidden() возвращает true, если этот узел является скрытым в модели данных. Чтобы проверить скрытое свойство любого узла SmartArt, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt RadialCycle.
- Добавьте узел на SmartArt.
- Проверьте свойство isHidden.
- Сохраните презентацию в виде файла PPTX.

В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```c#
using (Presentation presentation = new Presentation())
{
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Добавить узел на SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Проверка свойства isHidden
    bool hidden = node.IsHidden; // Возвращает true

    if (hidden)
    {
        // Выполнить некоторые действия или уведомления
    }
    // Сохранение презентации
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Получить или установить тип организационной диаграммы**
Методы com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) позволяют получить или установить тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить тип организационной диаграммы, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Добавьте SmartArt на слайд.
- Получите или установите тип организационной диаграммы.
- Сохраните презентацию в виде файла PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```c#
using (Presentation presentation = new Presentation())
{
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Получить или установить тип организационной диаграммы 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Сохранение презентации
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Создать организационную диаграмму с изображениями**
Aspose.Slides для .NET предоставляет простой API для создания организационных диаграмм с изображениями. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию с желаемым типом (ChartType.PictureOrganizationChart).
1. Запишите измененную презентацию в файл PPTX.

Ниже приведен код для создания диаграммы.

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