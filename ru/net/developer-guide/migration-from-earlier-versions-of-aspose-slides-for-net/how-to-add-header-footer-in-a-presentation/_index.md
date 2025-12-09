---
title: Как добавить заголовки и нижние колонтитулы в презентации в .NET
linktitle: Добавить заголовок и нижний колонтитул
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
description: "Узнайте, как добавить заголовки и нижние колонтитулы в презентации PowerPoint PPT, PPTX и ODP в .NET, используя как устаревшие, так и современные API Aspose.Slides."
---

{{% alert color="primary" %}} 

Выпущен новый [API Aspose.Slides для .NET](/slides/ru/net/), и теперь этот единый продукт поддерживает возможность создания документов PowerPoint с нуля и их редактирования.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный для Aspose.Slides для .NET версий ранее 13.x, необходимо внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые находились в старых версиях Aspose.Slides для .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в единственное пространство имен Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым фрагментом кода для добавления верхнего и нижнего колонтитулов в презентацию в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию на новое объединённое API.
## **Legacy Aspose.Slides for .NET approach**
```c#
PresentationEx sourcePres = new PresentationEx();

//Настройка свойств видимости верхних и нижних колонтитулов
sourcePres.UpdateSlideNumberFields = true;

//Обновление полей даты и времени
sourcePres.UpdateDateTimeFields = true;

//Показать заполнитель даты и времени
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Показать заполнитель нижнего колонтитула
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Показать номер слайда
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Установить видимость верхних и нижних колонтитулов на титульном слайде
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Записать презентацию на диск
sourcePres.Write("NewSource.pptx");
```

```c#
//Создать презентацию
Presentation pres = new Presentation();

//Получить первый слайд
Slide sld = pres.GetSlideByPosition(1);

//Получить доступ к верхнему/нижнему колонтитулу слайда
HeaderFooter hf = sld.HeaderFooter;

//Установить видимость номера страницы
hf.PageNumberVisible = true;

//Установить видимость нижнего колонтитула
hf.FooterVisible = true;

//Установить видимость верхнего колонтитула
hf.HeaderVisible = true;

//Установить видимость даты и времени
hf.DateTimeVisible = true;

//Установить формат даты и времени
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Установить текст верхнего колонтитула
hf.HeaderText = "Header Text";

//Установить текст нижнего колонтитула
hf.FooterText = "Footer Text";

//Записать презентацию на диск
pres.Write("HeadFoot.ppt");
```




## **New Aspose.Slides for .NET 13.x approach**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Настройка свойств видимости верхних и нижних колонтитулов
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Обновление полей даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель нижнего колонтитула
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Установить видимость верхних и нижних колонтитулов на титульном слайде
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Записать презентацию на диск
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
