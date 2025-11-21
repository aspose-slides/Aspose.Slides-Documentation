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
description: "Перейдите от автоматизации Microsoft Office к Aspose.Slides для .NET и создавайте новые презентации PowerPoint (PPT, PPTX) на C# с чистым и надёжным кодом."
---

{{% alert color="primary" %}} 

VSTO был разработан, чтобы позволить разработчикам создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но упакован в объект .NET, чтобы его можно было использовать в приложениях .NET. VSTO требует поддержки .NET framework, а также среды выполнения CLR‑базированного Microsoft Office. Хотя его можно использовать для создания надстроек Microsoft Office, почти невозможно использовать его как серверный компонент. У него также есть серьёзные проблемы с развертыванием.

Aspose.Slides для .NET — это компонент, который можно использовать для работы с презентациями Microsoft PowerPoint, так же как и VSTO, но он имеет несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как клиентский компонент, так и как серверный компонент.
- Развёртывание простое, так как Aspose.Slides содержится в едином DLL.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, которые показывают, как VSTO и Aspose.Slides для .NET можно использовать для достижения одной и той же цели. Первый пример — [VSTO](/slides/ru/net/create-a-new-presentation/); [второй пример](/slides/ru/net/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Примечание: PowerPoint — это пространство имён, которое было определено выше так
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Создать презентацию
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Получить макет слайда заголовка
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Добавить слайд заголовка.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Установить текст заголовка
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Установить текст подзаголовка
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Записать вывод на диск
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Пример Aspose.Slides для .NET**
**Вывод из Aspose.Slides** 

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

//Записать вывод на диск
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
