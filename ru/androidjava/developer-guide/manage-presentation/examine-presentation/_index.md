---
title: Изучение презентации
type: docs
weight: 30
url: /ru/androidjava/examine-presentation/

---

Aspose.Slides для Android через Java позволяет вам изучить презентацию, чтобы узнать ее свойства и понять ее поведение.

{{% alert title="Информация" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) и [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) содержат свойства и методы, используемые в операциях здесь.

{{% /alert %}} 

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и другие) находится презентация в данный момент.

Вы можете проверить формат презентации, не загружая ее. Смотрите этот Java код:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Получение свойств презентации**

Этот Java код показывает вам, как получить свойства презентации (информацию о презентации):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Вам может быть интересно увидеть [свойства класса DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--).

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), который позволяет вносить изменения в свойства презентации.

Этот Java код показывает вам, как редактировать свойства презентации:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");

IDocumentProperties props = info.readDocumentProperties();
props.setTitle("Мой заголовок");
info.updateDocumentProperties(props);
```

### **Полезные ссылки**

Чтобы получить больше информации о презентации и ее атрибутах безопасности, вы можете найти эти ссылки полезными:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только для чтения)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, используемого для защиты презентации](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).