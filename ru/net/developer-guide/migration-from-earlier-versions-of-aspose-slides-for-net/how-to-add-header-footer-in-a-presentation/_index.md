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

Новый [Aspose.Slides for .NET API](/slides/ru/net/) был выпущен, и теперь этот единый продукт поддерживает возможность генерировать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}}
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, написанный для версий Aspose.Slides for .NET до 13.x, необходимо внести небольшие изменения в ваш код, после чего он будет работать так же, как и ранее. Все классы, которые ранее находились в пространствах имен Aspose.Slide и Aspose.Slides.Pptx в старом Aspose.Slides for .NET, теперь объединены в единое пространство имен Aspose.Slides. Ознакомьтесь с приведённым ниже простым фрагментом кода для добавления верхнего и нижнего колонтитула в презентацию в устаревшем API Aspose.Slides и следуйте шагам, описывающим миграцию к новому объединённому API.
## **Подход к устаревшему Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Установка свойств видимости верхнего и нижнего колонтитулов
sourcePres.UpdateSlideNumberFields = true;

//Обновление полей даты и времени
sourcePres.UpdateDateTimeFields = true;

//Показать заполнитель даты и времени
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Показать заполнитель нижнего колонтитула
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Показать номер слайда
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Установить видимость верхнего и нижнего колонтитулов на титульном слайде
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


## **Новый подход Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Установка свойств видимости верхнего и нижнего колонтитулов
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Обновление полей даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель нижнего колонтитула
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Установить видимость верхнего и нижнего колонтитулов на титульном слайде
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Записать презентацию на диск
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
