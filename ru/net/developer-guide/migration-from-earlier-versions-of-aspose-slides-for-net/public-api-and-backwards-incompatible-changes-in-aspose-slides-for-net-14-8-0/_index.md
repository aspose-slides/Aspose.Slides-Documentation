---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.8.0
linktitle: Aspose.Slides для .NET 14.8.0
type: docs
weight: 100
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- миграция
- наследуемый код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и изменений, разрушающих совместимость, в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 
Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) или [удалённых](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) классов, методов, свойств и т.д., а также другие изменения, внесённые в API Aspose.Slides для .NET 14.8.0.
{{% /alert %}} 
## **Изменения публичного API**
### **Изменённые свойства**
#### **Добавлен интерфейс IVbaProject, изменено свойство Presentation.VbaProject**
Свойство VbaProject класса Presentation было заменено. Вместо представления свойства VbaProject в виде необработанных байтов VBA‑проекта теперь добавлена реализация нового интерфейса IVbaProject.

Используйте свойство IVbaProject для управления VBA‑проектами, встроенными в презентацию. Вы можете добавлять новые ссылки на проекты, редактировать существующие модули и создавать новые.

Также вы можете создать новый VBA‑проект, используя класс VbaProject, который реализует интерфейс IVbaProject.

Ниже приведён пример создания простого VBA‑проекта, содержащего один модуль, и добавления двух обязательных ссылок на библиотеки.

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

Этот пример демонстрирует, как скопировать VBA‑проект из существующей презентации в новую.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Добавлены интерфейсы, свойства и варианты перечислений**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeries.Overlap**
Свойство Aspose.Slides.Charts.IChartSeries.Overlap определяет степень перекрытия столбцов и полос на двумерных диаграммах (от -100 до 100).

Это свойство относится не только к данной серии, но и ко всем сериям в родительской группе — это проекция соответствующего свойства группы. Поэтому свойство доступно только для чтения.

- Используйте свойство ParentSeriesGroup, чтобы получить доступ к родительской группе серий.
- Используйте свойство ParentSeriesGroup.Overlap для записи нового значения.

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
Свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap определяет степень перекрытия столбцов и полос на двумерных диаграммах (от -100 до 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот метод создания эскиза формы позволяет сформировать эскиз в границах её визуального представления. Учтены все эффекты формы. Сгенерированный эскиз ограничен границами слайда.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```