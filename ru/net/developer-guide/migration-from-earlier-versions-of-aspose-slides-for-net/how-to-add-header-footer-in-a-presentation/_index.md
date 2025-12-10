---
title: Как добавить колонтитулы в презентации в .NET
linktitle: Добавить колонтитул
type: docs
weight: 20
url: /ru/net/how-to-add-header-footer-in-a-presentation/
keywords:
- миграция
- добавить заголовок
- добавить нижний колонтитул
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
description: "Узнайте, как добавить колонтитулы в презентации PowerPoint PPT, PPTX и ODP в .NET, используя как устаревшие, так и современные API Aspose.Slides."
---

{{% alert color="primary" %}} 
Вышел новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единый продукт поддерживает возможность создания PowerPoint-документов с нуля и их редактирования.
{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный для версий Aspose.Slides for .NET ранее 13.x, необходимо внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые находились в старых версиях Aspose.Slides for .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым примером кода для добавления колонтитулов в презентацию в устаревшем API Aspose.Slides и следуйте инструкциям, описывающим процесс миграции на новый объединённый API.
## **Подход Legacy Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Установка свойств видимости верхнего и нижнего колонтитулов
//Обновление полей даты и времени
//Показать заполнитель даты и времени
//Показать заполнитель нижнего колонтитула
//Показать номер слайда
//Установить  видимость верхнего и нижнего колонтитулов на титульном слайде
//Записать презентацию на диск
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Создать презентацию
Presentation pres = new Presentation();

//Получить первый слайд
Slide sld = pres.GetSlideByPosition(1);

//Получить доступ к заголовку/колонтитулу слайда
HeaderFooter hf = sld.HeaderFooter;

//Установить видимость номера слайда
hf.PageNumberVisible = true;

//Установить видимость нижнего колонтитула
hf.FooterVisible = true;

//Установить видимость верхнего колонтитула
hf.HeaderVisible = true;

//Установить видимость даты и времени
hf.DateTimeVisible = true;

//Установить формат даты и времени
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Установить текст заголовка
hf.HeaderText = "Header Text";

//Установить текст нижнего колонтитула
hf.FooterText = "Footer Text";

//Записать презентацию на диск
pres.Write("HeadFoot.ppt");
```


## **Новый подход Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Установка свойств видимости колонтитулов
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Обновление полей даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель нижнего колонтитула
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Установить видимость колонтитулов на титульном слайде
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Записать презентацию на диск
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
