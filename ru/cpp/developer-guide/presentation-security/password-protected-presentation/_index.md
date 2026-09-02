---
title: Защита презентаций паролем в C++
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/cpp/password-protected-presentation/
keywords:
- презентация с защитой паролем
- пароль открытия
- шифрование PowerPoint
- расшифровка PowerPoint
- валидация пароля презентации
- проверка пароля презентации
- открытие зашифрованной презентации
- удаление шифрования
- PowerPoint
- PPT
- PPTX
- презентация
- C++
- Aspose.Slides
description: "Шифрование, обнаружение, проверка, открытие и расшифровка презентаций PowerPoint PPT и PPTX, защищённых паролем, в C++ с помощью Aspose.Slides."
---
## **Обзор**

Пароль открытия шифрует презентацию. Правильный пароль требуется для загрузки и просмотра содержимого презентации, поэтому эта защита обеспечивает конфиденциальность.

Пароль открытия отличается от пароля защиты от записи. Защита от записи ограничивает изменения, но не шифрует содержимое и не препятствует загрузке презентации. Чтобы управлять паролями для изменения презентаций, см. [Write-Protect Presentations](/slides/ru/cpp/write-protected-presentation/).

Приведённые ниже рабочие процессы применимы как к презентациям PPT, так и PPTX. Примеры используют оба формата, где важны их файловое и потоковое поведение.

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

## **Загрузка зашифрованной презентации**

Установите [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/) в пароль открытия и передайте параметры в [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) при загрузке файла. Загрузка не удалась, если требуется пароль открытия, но предоставленный пароль отсутствует или неверен.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Работа с дешифрованной презентацией.
```

## **Удаление шифрования из презентации**

Загрузите презентацию с её паролем открытия, вызовите [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/removeencryption/), и сохраните результат. Сохранённую презентацию затем можно загрузить без пароля.

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

Используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) для получения [IPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/) без создания полного экземпляра презентации. Проверьте [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) перед запросом или проверкой пароля. При наличии защиты проверьте предоставленное значение с помощью [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Рабочий процесс с файловым путём**

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

Перегрузка потока метода [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) предоставляет тот же рабочий процесс. Сбросьте позицию поиска в потоке перед загрузкой полной презентации из этого потока.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkpassword/) возвращает `true` только когда презентация имеет пароль открытия и предоставленный пароль правильный. Возвращает `false` в каждом из следующих случаев:

- Пароль неверный.
- У презентации нет пароля открытия.
- Предоставленный пароль равен null или пустой строке.

Поведение одинаковое для презентаций PPT и PPTX.

## **Проверка, зашифрована ли загруженная презентация**

После загрузки презентации с правильным паролем проверьте [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/get_isencrypted/), чтобы подтвердить, что исходная презентация была зашифрована. Чтобы обнаружить защиту паролем открытия до загрузки, используйте `IPresentationInfo::get_IsPasswordProtected`, как показано выше.

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

{{% alert color="warning" title="Безопасность" %}}
Не записывайте пароли открытия в журналы и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки, храните пароли в памяти только столько, сколько требуется, и повторно используйте успешный результат проверки при немедленной загрузке презентации.
{{% /alert %}}

## **Защита презентации паролем онлайн**

1. Откройте приложение [Aspose.Slides Lock](https://products.aspose.app/slides/ru/lock).
2. Выберите или загрузите презентацию.
3. Введите пароль для защиты просмотра.
4. При необходимости введите отдельный пароль для защиты редактирования.
5. Примените защиту и загрузите полученный файл.

{{% alert color="info" title="Смотрите также" %}}
- [Write-Protect Presentations](/slides/ru/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ru/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**В чём разница между паролем открытия и паролем защиты от записи?**

Пароль открытия шифрует презентацию и требуется для загрузки её содержимого. Пароль защиты от записи ограничивает изменение без шифрования содержимого.

**Могу ли я проверить пароль открытия без загрузки всех слайдов?**

Да. Получите информацию о презентации, проверьте наличие защиты паролем открытия и проверьте пароль перед созданием полного экземпляра презентации.

**Поддерживают ли процессы проверки пароля как PPT, так и PPTX?**

Да. Обнаружение и проверка пароля по файловому пути и по потоку ведут себя одинаково для презентаций PPT и PPTX.