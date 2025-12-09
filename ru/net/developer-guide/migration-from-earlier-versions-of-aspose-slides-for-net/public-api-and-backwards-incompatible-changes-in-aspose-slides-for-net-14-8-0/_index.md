---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 14.8.0
linktitle: Aspose.Slides для .NET 14.8.0
type: docs
weight: 100
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides for .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Изменённые свойства**
#### **Добавлен интерфейс IVbaProject, изменено свойство Presentation.VbaProject**
Свойство VbaProject класса Presentation было заменено. Вместо представления необработанных байтов проекта VBA в свойстве VbaProject, была добавлена реализация нового интерфейса IVbaProject.

Используйте свойство IVbaProject для управления VBA‑проектами, встроенными в презентацию. Вы можете добавлять новые ссылки на проекты, редактировать существующие модули и создавать новые.

Кроме того, вы можете создать новый VBA‑проект, используя класс VbaProject, который реализует интерфейс IVbaProject.

В следующем примере показано создание простого VBA‑проекта, содержащего один модуль, и добавление двух необходимых ссылок на библиотеки.

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

Этот пример показывает, как скопировать VBA‑проект из существующей презентации в новую.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Добавлены интерфейсы, свойства и варианты перечисления**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeries.Overlap**
Свойство Aspose.Slides.Charts.IChartSeries.Overlap определяет степень перекрытия столбцов и линий на двумерных диаграммах (в диапазоне от -100 до 100).

Это свойство относится не только к этой серии, но и ко всем сериям в родительской группе серий — это проекция соответствующего свойства группы. Поэтому это свойство является только для чтения.

- Используйте свойство ParentSeriesGroup для доступа к родительской группе серий.
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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap определяет степень перекрытия столбцов и линий на двумерных диаграммах (от -100 до 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
#### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот метод создания эскиза фигуры позволяет сформировать миниатюру фигуры в границах её отображения. Он учитывает все эффекты фигуры. Сгенерированный эскиз ограничивается границами слайда.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```