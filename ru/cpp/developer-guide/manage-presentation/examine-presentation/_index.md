---
title: Исследование презентации - C++ PowerPoint API
linktitle: Исследование презентации
type: docs
weight: 30
url: /ru/cpp/examine-presentation/
description: C++ PowerPoint API позволяет вам исследовать презентацию, чтобы узнать её свойства и понять её поведение.
---

Aspose.Slides для C++ позволяет вам исследовать презентацию, чтобы узнать её свойства и понять её поведение.

{{% alert title="Информация" color="info" %}}

Классы [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) и [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) содержат свойства и методы, используемые в операциях здесь.

{{% /alert %}} 

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть выяснить, в каком формате (PPT, PPTX, ODP и других) находится презентация в данный момент.

Вы можете проверить формат презентации без её загрузки. Посмотрите этот код на C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Получение свойств презентации**

Этот код на C++ покажет вам, как получить свойства презентации (информацию о презентации):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo::UpdateDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info#ac9fce3667003cdb8bf05816c589a6f88), который позволяет вам вносить изменения в свойства презентации.

Этот код на C++ покажет вам, как редактировать свойства презентации:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");

auto props = info->ReadDocumentProperties();
props->set_Title(u"Мой заголовок");
info->UpdateDocumentProperties(props);
```

### **Полезные ссылки**

Чтобы получить дополнительную информацию о презентации и её атрибутах безопасности, вы можете найти эти ссылки полезными:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только для чтения)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед её загрузкой](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты презентации](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).
