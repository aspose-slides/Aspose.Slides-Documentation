---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.8.0
type: docs
weight: 100
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) или [удаленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) классы, методы, свойства и так далее, а также другие изменения, внесенные в API Aspose.Slides для .NET 14.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Измененные свойства**
#### **Добавлен интерфейс IVbaProject, изменено свойство Presentation.VbaProject**
Свойство VbaProject класса Presentation было заменено. Вместо необработанного байтового представления VBA проекта свойство VbaProject добавлено новое исполнение интерфейса IVbaProject.

Используйте свойство IVbaProject для управления VBA проектами, встроенными в презентацию. Вы можете добавлять новые ссылки на проекты, редактировать существующие модули и создавать новые.

Также вы можете создать новый VBA проект, используя класс VbaProject, который реализует интерфейс IVbaProject.

Следующий пример демонстрирует создание простого VBA проекта, содержащего один модуль, и добавление двух необходимых ссылок на библиотеки.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Создать новый VBA проект

    pres.VbaProject = new VbaProject();

    // Добавить пустой модуль в VBA проект

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Модуль");

    // Установить исходный код модуля

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Тест""

        End Sub";

    // Создать ссылку на <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Создать ссылку на Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0");

    // Добавить ссылки в VBA проект

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

Этот пример показывает, как скопировать VBA проект из существующей презентации в новую.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Добавленные интерфейсы, свойства и варианты перечисления**
#### **Добавлено свойство Aspose.Slides.Charts.IChartSeries.Overlap**
Свойство Aspose.Slides.Charts.IChartSeries.Overlap определяет, насколько бары и столбцы должны перекрывать друг друга на 2D диаграммах (в диапазоне от -100 до 100).

Это свойство не только этой серии, но и всех серий в родительской группе серий - это проекция соответствующего группового свойства. Таким образом, это свойство только для чтения.

- Используйте свойство ParentSeriesGroup, чтобы получить доступ к родительской группе серий.
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
Свойство Aspose.Slides.Charts.IChartSeriesGroup.Overlap определяет, насколько бары и столбцы должны перекрывать друг друга на 2D диаграммах (от -100 до 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Добавлено значение Enum ShapeThumbnailBounds.Appearance**
Этот метод создания миниатюры формы позволяет вам генерировать миниатюру формы в рамках ее внешнего вида. Он учитывает все эффекты формы. Сгенерированная миниатюра формы ограничена границами слайда.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 