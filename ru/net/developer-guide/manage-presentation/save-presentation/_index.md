---
title: Сохранение презентации в .NET
linktitle: Сохранение презентации
type: docs
weight: 80
url: /net/save-presentation/
keywords: "Сохранить PowerPoint, PPT, PPTX, Сохранить презентацию, файл, поток, C#, Csharp, .NET"
description: "Сохранить презентацию PowerPoint как файл или поток в C# или .NET"
---

## **Сохранение презентации**
В открытии презентации описано, как использовать класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) содержит содержимое презентации. Независимо от того, создаете ли вы презентацию с нуля или модифицируете существующую, когда вы закончите, вы захотите сохранить презентацию. С помощью Aspose.Slides для .NET она может быть сохранена как **файл** или **поток**. Эта статья объясняет, как сохранить презентацию разными способами:

### **Сохранение презентации в файлы**
Сохраните презентацию в файлы, вызвав метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Просто передайте имя файла и формат сохранения в метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). Примеры, приведённые ниже, показывают, как сохранить презентацию с помощью Aspose.Slides для .NET, используя C#.

```c#
// Создайте объект Presentation, который представляет файл PPT
Presentation presentation = new Presentation();

//...выполните некоторые действия...

// Сохраните вашу презентацию в файл
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Сохранение презентации в потоки**
Вы можете сохранить презентацию в поток, передав выходной поток методу Save класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Существует много типов потоков, в которые можно сохранить презентацию. В приведенном ниже примере мы создали новый файл презентации, добавили текст в фигуру и сохранили презентацию в поток.

```c#
// Создайте объект Presentation, который представляет файл PPT
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Добавьте текст в фигуру
    shape.TextFrame.Text = "Этот демонстрационный пример показывает, как создать файл PowerPoint и сохранить его в поток.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```

### **Сохранение презентаций с заранее определенным типом представления**
Aspose.Slides для .NET предоставляет возможность задать тип представления для сгенерированной презентации, когда она открыта в PowerPoint, с помощью класса [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties). Свойство [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) используется для задания типа представления с использованием перечисления [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype).

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **Сохранение презентаций в строгом формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этой цели он предоставляет класс [**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions), где вы можете установить свойство Conformance при сохранении файла презентации. Если вы установите его значение как Conformance.Iso29500_2008_Strict, то выходной файл презентации будет сохранён в строгом формате Office Open XML.

Следующий пример кода создает презентацию и сохраняет её в строгом формате Office Open XML. При вызове метода Save для презентации объект **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** передается с установленным свойством [**Conformance**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance) как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/net/aspose.slides.export/conformance).

```csharp
   // Создайте объект Presentation, который представляет файл презентации
   using (Presentation presentation = new Presentation())
   {
       // Получите первый слайд
       ISlide slide = presentation.Slides[0];

       // Добавьте автозначок типа линия
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // Сохраните презентацию в строгом формате Office Open XML
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });
   }
```

### **Сохранение презентаций в формате Office Open XML в режиме Zip64**
Файл Office Open XML представляет собой ZIP-архив, который имеет предел 4 ГБ (2^32 байт) на не сжатый размер файла, сжатый размер файла и общий размер архива, а также лимит 65,535 (2^16-1) файлов в архиве. Расширения формата ZIP64 увеличивают эти лимиты до 2^64.

Новое свойство [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) позволяет вам выбирать, когда использовать расширения формата ZIP64 для сохраненного файла Office Open XML.

Это свойство предоставляет следующие режимы:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) означает, что расширения формата ZIP64 будут использоваться только в том случае, если презентация выходит за пределы указанных ограничений. Это режим по умолчанию.
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) означает, что расширения формата ZIP64 использоваться не будут. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) означает, что расширения формата ZIP64 будут использоваться всегда.

Следующий код C# демонстрирует, как сохранить презентацию в формате PPTX с расширениями формата ZIP64:

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Сохранение в режиме Zip64Mode.Never вызовет [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/), если презентацию невозможно сохранить в формате ZIP32.

{{% /alert %}}

### **Сохранение обновлений прогресса в процентах**
В интерфейсе [**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions) и абстрактном классе [**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions) был добавлен новый интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback). Интерфейс **IProgressCallback** представляет собой объект обратного вызова для сохранения обновлений прогресса в процентах.

Ниже приведенные фрагменты кода показывают, как использовать интерфейс IProgressCallback:

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}
```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Используйте процентное значение прогресса здесь
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% файл преобразован");
    }
}
```

{{% alert title="Информация" color="info" %}}

Используя собственное API, Aspose разработал [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), которое позволяет пользователям разбивать свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из данной презентации как новые файлы PowerPoint (PPTX или PPT). 

{{% /alert %}}

<h2>Открыть и сохранить презентацию</h2>

<a name="csharp-open-save-presentation"><strong>Шаги: открыть и сохранить презентацию в C#</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) в любом формате, т.е. PPT, PPTX, ODP и т.д.
2. Сохраните _Презентацию_ в любой формат, поддерживаемый [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Загрузите любой поддерживаемый файл в Presentation, например ppt, pptx, odp и т.д.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```