---
title: Получить и обновить информацию о презентации на Android
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Java для более быстрых выводов и более умных аудитов контента."
---
## **Обзор**

В этой статье показано, как просматривать информацию о презентации в Aspose.Slides. Она объясняет, как определить текущий формат презентации без загрузки полного файла, прочитать её свойства документов и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/documentproperties/) и демонстрируют типичные операции работы с метаданными презентации.

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Можно проверить формат презентации без её загрузки. Смотрите этот код Java:

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

Возможно, вам будет полезно посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть PowerPoint‑презентация со свойствами документа, показанными ниже.

![Исходные свойства документа PowerPoint‑презентации](input_properties.png)

Этот пример кода показывает, как изменить некоторые свойства презентации:

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

![Изменённые свойства документа PowerPoint‑презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её параметрах безопасности, могут быть полезны следующие ссылки:

- [Password-Protect Presentations](/slides/ru/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/androidjava/write-protected-presentation/)

## **Вопросы и ответы**

**Как проверить, вложены ли шрифты и какие именно?**

Ищите информацию о [вложенных шрифтах](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsmanager/#getFonts--) для определения критически важных шрифтов при рендеринге.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#getHidden--) .

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlideSize--) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ узнать, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдитесь по всем [диаграммам](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) и отметьте, является ли данные внутренними или основанными на ссылке, включая любые повреждённые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный показатель сложности, чтобы выделить потенциальные узкие места производительности.