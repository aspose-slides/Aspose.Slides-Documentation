---
title: Изучение Презентации
type: docs
weight: 30
url: /ru/php-java/examine-presentation/

---

Aspose.Slides для PHP через Java позволяет вам изучить презентацию, чтобы узнать ее свойства и понять ее поведение.

{{% alert title="Информация" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) и [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) содержат свойства и методы, используемые в операциях здесь.

{{% /alert %}} 

## **Проверка Формата Презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и другие) находится презентация в данный момент.

Вы можете проверить формат презентации, не загружая саму презентацию. Посмотрите этот PHP код:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Получение Свойств Презентации**

Этот PHP код показывает, как получить свойства презентации (информацию о презентации):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Вы можете увидеть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Обновление Свойств Презентации**

Aspose.Slides предоставляет метод [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), который позволяет вам вносить изменения в свойства презентации.

Этот PHP код показывает, как редактировать свойства презентации:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  $props->setTitle("Мой заголовок");
  $info->updateDocumentProperties($props);

```

### **Полезные Ссылки**

Чтобы получить больше информации о презентации и ее атрибутах безопасности, вы можете найти эти ссылки полезными:

- [Проверка, зашифрована ли Презентация](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли Презентация от записи (только для чтения)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли Презентация паролем перед загрузкой](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты Презентации](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).