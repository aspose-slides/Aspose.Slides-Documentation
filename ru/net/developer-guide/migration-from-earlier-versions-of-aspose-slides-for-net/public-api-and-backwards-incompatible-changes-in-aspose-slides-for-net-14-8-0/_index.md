---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 14.8.0
linktitle: Aspose.Slides для .NET 14.8.0
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
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Изменённые свойства**
#### **Добавлен интерфейс IVbaProject, изменено свойство Presentation.VbaProject**
Свойство VbaProject класса Presentation было заменено. Вместо представления свойства VbaProject в виде необработанных байтов проекта VBA теперь добавлена реализация нового интерфейса IVbaProject.

Используйте свойство IVbaProject для управления VBA‑проектами, встроенными в презентацию. Вы можете добавлять новые ссылки на проекты, изменять существующие модули и создавать новые.

Также можно создать новый VBA‑проект с помощью класса VbaProject, который реализует интерфейс IVbaProject.

Следующий пример демонстрирует создание простого VBA‑проекта, содержащего один модуль, и добавление двух требуемых ссылок на библиотеки.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Создать новый VBA проект

    pres.VbaProject = new VbaProject();

    // Добавить пустой модуль в VBA проект

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Установить исходный код модуля

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Создать ссылку на <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Создать ссылку на Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Добавить ссылки в VBA проект

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Этот пример показывает, как скопировать VBA‑проект из существующей презентации в новую.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Добавлены интерфейсы, свойства и варианты перечислений**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeries.Overlap**
Свойство Aspose.Slides.Charts.IChartSeries.Overlap определяет, насколько столбцы и полосы перекрываются на 2D‑диаграммах (значения от ‑100 до 100).

Это свойство относится не только к текущей серии, но и ко всем сериям в родительской группе серий — это проекция соответствующего свойства группы. Поэтому свойство доступно только для чтения.

- Используйте свойство ParentSeriesGroup, чтобы получить доступ к родительской группе серий.  
- Используйте свойство ParentSeriesGroup.Overlap (чтение/запись), чтобы изменить значение.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


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
Свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap определяет, насколько столбцы и полосы перекрываются на 2D‑диаграммах (от ‑100 до 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Добавлено значение перечисления ShapeThumbnailBounds.Appearance**
Этот метод создания эскиза фигуры позволяет генерировать эскиз в пределах её визуального представления. При этом учитываются все эффекты фигуры. Сгенерированный эскиз ограничивается границами слайда.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```