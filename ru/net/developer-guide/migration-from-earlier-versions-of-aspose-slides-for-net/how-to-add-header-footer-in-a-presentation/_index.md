---
title: Как добавить заголовок и подвал в презентацию
type: docs
weight: 20
url: /ru/net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

Выпущен новый [Aspose.Slides для .NET API](/slides/ru/net/), и теперь этот продукт поддерживает возможность генерировать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с использованием Aspose.Slides для .NET версий до 13.x, вам нужно внести небольшие изменения в ваш код, и он будет работать как раньше. Все классы, которые были предусмотрены в старом Aspose.Slides для .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в одно пространство имен Aspose.Slides. Пожалуйста, посмотрите следующий простой фрагмент кода для добавления заголовка и подвала в презентацию в устаревшем API Aspose.Slides и следуйте шагам, описывающим, как перейти на новый объединенный API.
## **Устаревший подход Aspose.Slides для .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Установка свойств видимости заголовка и подвала
sourcePres.UpdateSlideNumberFields = true;

//Обновление полей даты и времени
sourcePres.UpdateDateTimeFields = true;

//Показать заполнитель даты и времени
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Показать заполнитель подвала
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Показать номер слайда
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Установить видимость заголовка и подвала на титульном слайде
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Записать презентацию на диск
sourcePres.Write("NewSource.pptx");
```

```c#
//Создать презентацию
Presentation pres = new Presentation();

//Получить первый слайд
Slide sld = pres.GetSlideByPosition(1);

//Получить доступ к заголовку / подвалу слайда
HeaderFooter hf = sld.HeaderFooter;

//Установить видимость номера страницы
hf.PageNumberVisible = true;

//Установить видимость подвала
hf.FooterVisible = true;

//Установить видимость заголовка
hf.HeaderVisible = true;

//Установить видимость даты и времени
hf.DateTimeVisible = true;

//Установить формат даты и времени
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Установить текст заголовка
hf.HeaderText = "Текст заголовка";

//Установить текст подвала
hf.FooterText = "Текст подвала";

//Записать презентацию на диск
pres.Write("HeadFoot.ppt");
```



## **Новый подход Aspose.Slides для .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Установка свойств видимости заголовка и подвала
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Обновление полей даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель даты и времени
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Показать заполнитель подвала
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Установить видимость заголовка и подвала на всех титульных слайдах
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Записать презентацию на диск
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```