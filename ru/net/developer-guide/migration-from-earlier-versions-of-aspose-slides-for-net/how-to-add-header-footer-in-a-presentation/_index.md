---
title: Как добавить верхние и нижние колонтитулы в презентации в .NET
linktitle: Добавить верхний и нижний колонтитул
type: docs
weight: 20
url: /ru/net/how-to-add-header-footer-in-a-presentation/
keywords:
- миграция
- добавить верхний колонтитул
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
description: "Узнайте, как добавить верхние и нижние колонтитулы в презентациях PowerPoint PPT, PPTX и ODP в .NET, используя как устаревшие, так и современные API Aspose.Slides."
---

{{% alert color="primary" %}}

Новый [Aspose.Slides for .NET API](/slides/ru/net/) выпущен, и теперь этот единый продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}}
## **Поддержка наследуемого кода**
Чтобы использовать наследуемый код, разработанный для Aspose.Slides for .NET версий до 13.x, необходимо внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые находились в старых версиях Aspose.Slides for .NET в пространствах имён Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имён Aspose.Slides. Пожалуйста, ознакомьтесь со следующим простым фрагментом кода для добавления колонтитулов в презентацию в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию к новому объединённому API.
## **Устаревший подход Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Установка свойств видимости верхних и нижних колонтитулов
sourcePres.UpdateSlideNumberFields = true;

//Обновить поля даты и времени
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

//Получить доступ к заголовку/колонтитулу слайда
HeaderFooter hf = sld.HeaderFooter;

//Установить видимость номера страницы
hf.PageNumberVisible = true;

//Установить видимость колонтитула
hf.FooterVisible = true;

//Установить видимость заголовка
hf.HeaderVisible = true;

//Установить видимость даты и времени
hf.DateTimeVisible = true;

//Установить формат даты и времени
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Установить текст заголовка
hf.HeaderText = "Header Text";

//Установить текст колонтитула
hf.FooterText = "Footer Text";

//Записать презентацию на диск
pres.Write("HeadFoot.ppt");
```



## **Новый подход Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Установка свойств видимости верхних и нижних колонтитулов
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Обновление полей даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель нижнего колонтитула
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Установить видимость верхних и нижних колонтитулов на титульных слайдах
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Записать презентацию на диск
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
