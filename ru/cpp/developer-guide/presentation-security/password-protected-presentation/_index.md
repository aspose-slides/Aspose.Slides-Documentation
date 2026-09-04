---
title: Защита презентаций паролем в C++
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/cpp/password-protected-presentation/
keywords:
- презентация, защищённая паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- проверка пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- C++
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, в C++ с Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменение, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Write-Protect Presentations](/slides/ru/cpp/write-protected-presentation/).

Ниже описанные рабочие процессы применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важны их файловое и потоковое поведение.

## **Шифрование презентации паролем открытия**

Используйте [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/encrypt/) для назначения пароля открытия. Затем используйте [IPresentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/save/) для сохранения зашифрованной презентации.

Следующий пример шифрует презентацию PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Сделать свойства документа публичными**

По умолчанию Aspose.Slides включает свойства документа в шифрование презентации. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) управляет этим поведением независимо от шифрования содержимого слайдов. Перед вызовом [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/encrypt/) передайте в этот метод значение `false`, если система индексации, классификации, поиска или управления документами должна читать метаданные без пароля открытия.

Следующий пример создает зашифрованную презентацию PPTX, при этом оставляя встроенные свойства документа публичными:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Передача `false` в `set_EncryptDocumentProperties` не делает публичными слайды, мастер‑слайды, макеты, фигуры, медиа или другое содержимое презентации. Это влияет только на свойства документа. Чтобы прочитать эти свойства без загрузки зашифрованного содержимого, см. [Manage Presentation Properties](/slides/ru/cpp/presentation-properties/).

## **Загрузка зашифрованной презентации**

Установите [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/) в пароль открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) при загрузке файла. Загрузка завершается ошибкой, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Работайте с расшифрованной презентацией.
```

## **Удаление шифрования из презентации**

Загрузите презентацию с её паролем открытия, вызовите [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/removeencryption/), и сохраните результат. Сохранённую презентацию затем можно загружать без пароля.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Проверка пароля открытия перед загрузкой**

Используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) для получения [IPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/) без создания полного экземпляра презентации. Проверьте [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) перед запросом или проверкой пароля. Если защита присутствует, проверьте предоставленное значение с помощью [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Рабочий процесс с путём к файлу**

Следующий пример проверяет пароль открытия для файла PPTX, передаёт проверенное значение в [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/), а затем загружает полную презентацию:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Рабочий процесс с потоком**

Перегрузка метода потока [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) предоставляет тот же рабочий процесс. Сбросьте позицию поискового потока перед загрузкой полной презентации из этого потока.

Следующий пример использует файл PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Возвращаемые значения CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkpassword/) возвращает `true` только когда презентация имеет пароль открытия и предоставленный пароль правильный. Он возвращает `false` в каждом из следующих случаев:

- Пароль неверен.
- У презентации нет пароля открытия.
- Предоставленный пароль равен null или пустой строке.

Поведение одинаково для презентаций PPT и PPTX.

## **Проверка, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) для подтверждения, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте `IPresentationInfo::get_IsPasswordProtected`, как показано выше.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Рекомендации по безопасности**

{{% alert color="warning" title="Security" %}}
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько необходимо, и повторно используйте успешный результат проверки при немедленной загрузке презентации.

Публичные свойства документа могут раскрывать имена авторов, названия, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения, даже если содержимое презентации зашифровано. Шифруйте чувствительные метаданные вместе с презентацией. Оставлять свойства публичными следует только как осознанное решение, когда системы должны индексировать, классифицировать, искать или управлять файлом без пароля открытия.
{{% /alert %}}

## **Защита паролем презентации онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При необходимости введите отдельный пароль для защиты редактирования.
5. Примените защиту и загрузите полученный файл.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ru/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль перед созданием полноценного экземпляра презентации.

**Может ли приложение читать метаданные без пароля открытия?**

Да, но только когда презентация была зашифрована с `set_EncryptDocumentProperties(false)`. Приложение должно затем использовать режим загрузки только свойств документа, описанный в [Manage Presentation Properties](/slides/ru/cpp/presentation-properties/).

**Поддерживают ли процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по пути к файлу и по потоку работают одинаково для презентаций PPT и PPTX.