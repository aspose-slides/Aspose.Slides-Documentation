---
title: Создание новой презентации
type: docs
weight: 10
url: /net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO был разработан, чтобы дать возможность разработчикам создавать приложения, которые могут работать внутри Microsoft Office. VSTO основан на COM, но он обернут в .NET-объект, что позволяет использовать его в .NET-приложениях. VSTO требует поддержки .NET framework, а также среды выполнения CLR Microsoft Office. Хотя его можно использовать для создания надстроек Microsoft Office, практически невозможно использовать его в качестве серверного компонента. У него также есть серьезные проблемы с развертыванием.

Aspose.Slides для .NET - это компонент, который можно использовать для манипуляции презентациями Microsoft PowerPoint, так же как и VSTO, но у него есть несколько преимуществ:

- Aspose.Slides содержит только управляемый код и не требует установки среды выполнения Microsoft Office.
- Его можно использовать как клиентский компонент или как серверный компонент.
- Развертывание простое, так как Aspose.Slides содержится в одном DLL.

{{% /alert %}} 
## **Создание презентации**
Ниже приведены два примера кода, которые иллюстрируют, как VSTO и Aspose.Slides для .NET могут быть использованы для достижения одной и той же цели. Первый пример - [VSTO](/slides/net/create-a-new-presentation/); [второй пример](/slides/net/create-a-new-presentation/) использует Aspose.Slides.
### **Пример VSTO**
**Вывод VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

```c#
//Примечание: PowerPoint - это пространство имен, которое было определено выше вот так
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Создание презентации
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Получите макет титульного слайда
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Добавьте титульный слайд.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Установите текст заголовка
slide.Shapes.Title.TextFrame.TextRange.Text = "Заголовок слайда";

//Установите текст подзаголовка
slide.Shapes[2].TextFrame.TextRange.Text = "Подзаголовок слайда";

//Запишите вывод на диск
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Пример Aspose.Slides для .NET**
**Вывод Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

```c#
//Создание презентации
Presentation pres = new Presentation();

//Добавьте титульный слайд
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Установите текст заголовка
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Заголовок слайда";

//Установите текст подзаголовка
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Подзаголовок слайда";

//Запишите вывод на диск
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```