---
title: Создание новых презентаций с использованием VSTO и Aspose.Slides для .NET
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
description: "Перейдите с автоматизации Microsoft Office на Aspose.Slides для .NET и создавайте новые презентации PowerPoint (PPT, PPTX) на C# с чистым, надёжным кодом."
---
{{% alert color="info" %}} 

VSTO был разработан, чтобы позволить разработчикам создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но упакован в объект .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET Framework, а также среды выполнения Microsoft Office, основанной на CLR. Хотя его можно использовать для создания надстроек Microsoft Office, использовать его в качестве серверного компонента почти невозможно. У него также есть серьёзные проблемы с развертыванием.

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как клиентский компонент, так и как серверный компонент.
- Развёртывание простое, потому что Aspose.Slides находится в едином DLL.

{{% /alert %}} 
## **Создание презентации**
Первый пример – [VSTO](/slides/ru/net/create-a-new-presentation/); [второй пример](/slides/ru/net/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше следующим образом
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Создать презентацию
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


### **Пример Aspose.Slides для .NET**
**Вывод из Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Создать презентацию
Presentation pres = new Presentation();

//Добавить титульный слайд
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Установить текст заголовка
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Установить текст подзаголовка
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Записать вывод на диск
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```