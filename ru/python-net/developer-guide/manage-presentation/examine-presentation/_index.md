---
title: Изучение Презентации
type: docs
weight: 30
url: /ru/python-net/examine-presentation/
keywords: "Проверка PowerPoint, PPTX, PPT, Проверка Презентации, Свойства PowerPoint, Свойства Презентации, Python"
description: "Проверка и получение Свойств Презентации PowerPoint в Python"
---

Aspose.Slides для Python через .NET позволяет изучать презентацию, чтобы узнать ее свойства и понять ее поведение. 

{{% alert title="Информация" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) содержат свойства и методы, используемые в здесь в операциях.

{{% /alert %}} 

## **Проверка Формата Презентации**

Перед работой с презентацией вы можете узнать, в каком формате (PPT, PPTX, ODP и другие) в данный момент находится презентация.

Вы можете проверить формат презентации, не загружая ее. Смотрите этот код на Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Получение Свойств Презентации**

Этот код на Python показывает, как получить свойства презентации (информацию о презентации):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Вы можете посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Обновление Свойств Презентации**

Aspose.Slides предоставляет метод [PresentationInfoUpdateDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), который позволяет вам вносить изменения в свойства презентации.

Этот код на Python показывает, как редактировать свойства презентации:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.title)

props.title = "Мой заголовок"
info.update_document_properties(props)

print(props.title)
```

### **Полезные Ссылки**

Чтобы получить дополнительную информацию о презентации и ее атрибутах безопасности, вы можете найти эти ссылки полезными:

- [Проверка на то, зашифрована ли Презентация](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка на то, защищена ли Презентация от записи (только для чтения)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка на то, защищена ли Презентация паролем перед ее загрузкой](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты Презентации](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).