---
title: Проверка презентации
type: docs
weight: 30
url: /net/examine-presentation/
keywords: "Проверка PowerPoint, PPTX, PPT, Проверка презентации, Свойства PowerPoint, Свойства презентации, C#, Csharp, .NET"
description: "Проверка и получение свойств презентации PowerPoint на C# или .NET"
---

Aspose.Slides для .NET позволяет вам исследовать презентацию, чтобы узнать ее свойства и понять ее поведение. 

{{% alert title="Информация" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) и [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) содержат свойства и методы, используемые в операциях здесь.

{{% /alert %}} 

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и других) находится презентация в данный момент.

Вы можете проверить формат презентации без загрузки самой презентации. Посмотрите этот код на C#:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Получение свойств презентации**

Этот код на C# показывает, как получить свойства презентации (информацию о презентации):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Вы можете захотеть посмотреть [свойства класса DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfoUpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), который позволяет вам вносить изменения в свойства презентации.

Этот код на C# показывает, как редактировать свойства презентации:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");

IDocumentProperties props = info.ReadDocumentProperties();
props.Title = "Мой заголовок";
info.UpdateDocumentProperties(props);
```

### **Полезные ссылки**

Чтобы получить больше информации о презентации и ее атрибутах безопасности, вы можете найти эти ссылки полезными:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только для чтения)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты презентации](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).