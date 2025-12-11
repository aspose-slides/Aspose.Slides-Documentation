---
title: Получение и обновление информации о презентации на Android
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/androidjava/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получение свойств
- чтение свойств
- изменение свойств
- модификация свойств
- обновление свойств
- исследовать PPTX
- исследовать PPT
- исследовать ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Java для более быстрых выводов и более умного аудита контента."
---

Aspose.Slides for Android via Java позволяет исследовать презентацию, чтобы узнать её свойства и понять её поведение.

{{% alert title="Info" color="info" %}} 
Классы [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) и [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) содержат свойства и методы, используемые в этих операциях.
{{% /alert %}} 

## **Проверка формата презентации**

Прежде чем работать с презентацией, вам может потребоваться узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. См. этот Java‑код:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **Получение свойств презентации**

Этот Java‑код показывает, как получить свойства презентации (информацию о презентации):
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```


Возможно, вы захотите посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Этот пример кода показывает, как редактировать некоторые свойства презентации:
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа презентации PowerPoint](output_properties.png)

## **Полезные ссылки**

Чтобы получить более подробную информацию о презентации и её атрибутах безопасности, вам могут быть полезны следующие ссылки:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только чтение)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, используемого для защиты презентации](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите [информацию о встроенных шрифтах](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) на уровне презентации, затем сравните эти записи с набором [шрифтов, действительно используемых в содержимом](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--).

**Могу ли я определить, используются ли пользовательские размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) и ориентацию со стандартными предустановками; это помогает предсказать поведение при печати и экспорте.

**Есть ли быстрый способ проверить, ссылаются ли диаграммы на внешние источники данных?**

Да. Обойдите все [диаграммы](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимации и мультимедиа; присвойте приблизительный показатель сложности, чтобы выделить потенциальные узкие места производительности.