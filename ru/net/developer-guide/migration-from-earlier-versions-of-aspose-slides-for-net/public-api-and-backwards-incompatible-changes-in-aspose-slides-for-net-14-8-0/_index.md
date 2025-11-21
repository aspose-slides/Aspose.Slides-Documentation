---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 14.8.0
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) классы, методы, свойства и т. д., а также другие изменения, внесённые в API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Изменённые свойства**
#### **Добавлен интерфейс IVbaProject, изменено свойство Presentation.VbaProject**
Свойство VbaProject класса Presentation было заменено. Вместо представления свойства VbaProject в виде необработанных байтов проекта VBA добавлена реализация нового интерфейса IVbaProject.

Используйте свойство IVbaProject для управления проектами VBA, встроенными в презентацию. Вы можете добавлять новые ссылки на проекты, редактировать существующие модули и создавать новые.

Кроме того, можно создать новый проект VBA с помощью класса VbaProject, который реализует интерфейс IVbaProject.

Следующий пример показывает создание простого проекта VBA, содержащего один модуль, и добавление двух обязательных ссылок на библиотеки.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Этот пример показывает, как скопировать проект VBA из существующей презентации в новую.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Добавленные интерфейсы, свойства и параметры перечисления**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeries.Overlap**
Свойство Aspose.Slides.Charts.IChartSeries.Overlap задаёт степень перекрытия столбцов и полос на 2‑D диаграммах (в диапазоне от -100 до 100).

Это свойство относится не только к этой серии, но и ко всем сериям в родительской группе серии — это проекция соответствующего свойства группы. Поэтому свойство является только для чтения.

- Используйте свойство ParentSeriesGroup, чтобы получить доступ к родительской группе серии.
- Используйте свойство ParentSeriesGroup.Overlap для чтения/записи, чтобы изменить значение.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap задаёт степень перекрытия столбцов и полос на 2‑D диаграммах (от -100 до 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот метод создания миниатюры фигуры позволяет генерировать миниатюру в пределах её внешнего вида. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```