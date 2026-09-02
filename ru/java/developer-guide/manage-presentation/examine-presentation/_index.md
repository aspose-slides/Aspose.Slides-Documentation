---
title: Получить и обновить информацию о презентации на Java
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Java для более быстрых инсайтов и более умных проверок контента."
---
## **Обзор**

В этой статье показано, как просматривать информацию о презентации в Aspose.Slides. Описывается, как определить текущий формат презентации без полной загрузки файла, прочитать её свойства документа и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/documentproperties/) и демонстрируют типичные операции по работе с метаданными презентации.

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и других) она находится в данный момент.

Можно проверить формат презентации без её загрузки. См. следующий код Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Получение свойств презентации**

Этот код Java показывает, как получить свойства презентации (информацию о презентации):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Вы также можете просмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со следующими свойствами документа.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

В этом примере кода показано, как изменить некоторые свойства презентации:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Защита паролем презентаций](/slides/ru/java/password-protected-presentation/)
- [Защита от записи презентаций](/slides/ru/java/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию о [встроенных шрифтах](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов в содержимом](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsmanager/#getFonts--) , чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, есть ли скрытые слайды и сколько их?**

Пройдите по [коллекции слайдов](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#getHidden--) .

**Можно ли определить, используются ли пользовательские размеры и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlideSize--) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдите по всем [диаграммам](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chartdata/#getDataSourceType--) и отметьте, является ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжелые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимацию и мультимедиа; присвойте грубую оценку сложности, чтобы отметить потенциальные узкие места производительности.