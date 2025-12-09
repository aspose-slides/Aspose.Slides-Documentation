---
title: Создание новых презентаций с помощью VSTO и Aspose.Slides для .NET
linktitle: Создать новую презентацию
type: docs
weight: 10
url: /ru/net/create-a-new-presentation/
keywords:
- создать презентацию
- новая презентация
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Перейдите от автоматизации Microsoft Office к Aspose.Slides для .NET и создавайте новые презентации PowerPoint (PPT, PPTX) в C# с чистым, надежным кодом."
---

{{% alert color="primary" %}} 

VSTO был разработан, чтобы позволить разработчикам создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но обёрнут в объект .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET Framework, а также CLR‑базированного окружения Microsoft Office. Хотя его можно использовать для создания надстроек Microsoft Office, практически невозможно применять его как серверный компонент. Кроме того, у него есть серьёзные проблемы с развертыванием.

Aspose.Slides for .NET — это компонент, который позволяет работать с презентациями Microsoft PowerPoint, как и VSTO, но имеет несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как клиентский, так и серверный компонент.
- Развертывание простое, поскольку Aspose.Slides поставляется в виде одного DLL.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, показывающие, как VSTO и Aspose.Slides for .NET могут быть использованы для достижения одной цели. Первый пример — [VSTO](/slides/ru/net/create-a-new-presentation/); второй пример — [второй пример](/slides/ru/net/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше так
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Пример Aspose.Slides for .NET**
**Вывод Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//Создать презентацию
Presentation pres = new Presentation();

//Добавить титульный слайд
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Установить текст заголовка
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Установить текст подзаголовка
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Записать результат на диск
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
