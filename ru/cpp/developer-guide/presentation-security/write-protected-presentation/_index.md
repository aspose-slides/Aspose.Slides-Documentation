---
title: Защита презентаций от записи в C++
linktitle: Защита от записи
type: docs
weight: 25
url: /ru/cpp/write-protected-presentation/
keywords:
- защита от записи
- защита PowerPoint от записи
- пароль для изменения
- ограничить редактирование презентации
- удалить защиту от записи
- проверка пароля изменения
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Устанавливайте, определяйте, проверяйте и удаляйте пароли защиты от записи в презентациях PowerPoint PPT и PPTX с помощью Aspose.Slides для C++."
---
## **Введение**

Пароль защиты от записи ограничивает изменение презентации, но не шифрует её содержимое. Пользователи могут загрузить и просмотреть презентацию с защитой от записи без пароля. В зависимости от приложения они также могут иметь возможность редактировать содержимое и сохранять его под другим именем, поэтому защита от записи не должна рассматриваться как механизм конфиденциальности.

Пароль открытия служит другой цели: он шифрует презентацию и требуется для загрузки её содержимого. Чтобы зашифровать презентацию или проверить пароль открытия, см. [Защита паролем презентаций](/slides/ru/cpp/password-protected-presentation/).

Описанные в статье рабочие процессы применимы как к презентациям PPT, так и PPTX. В примерах используются файлы PPTX; при сохранении в PPT используйте расширение `.ppt` и соответствующий формат сохранения PPT.

## **Установить защиту от записи в презентации**

Используйте [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) для назначения пароля, позволяющего изменять презентацию. Сохранение презентации сохраняет настройку защиты.

Следующий пример устанавливает защиту от записи в презентации PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Загрузка презентации с защитой от записи**

Поскольку защита от записи не шифрует содержимое презентации, пароль не требуется для её загрузки. Пароль имеет значение только при проверке разрешения на изменение защищённой презентации.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Не передавайте пароль защиты от записи в [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/). Это свойство принимает пароль открытия для зашифрованного содержимого. Если у презентации есть оба типа защиты, передайте пароль открытия для её загрузки и обрабатывайте пароль защиты от записи отдельно.

## **Удалить защиту от записи из презентации**

Используйте [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) для снятия ограничения изменения, затем сохраните презентацию.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Проверить, защищена ли презентация от записи**

Чтобы изучить файл без создания полного экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/), вызовите [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) и проверьте [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). Свойство использует [NullableBool](https://reference.aspose.com/slides/ru/cpp/aspose.slides/nullablebool/) и возвращает `NullableBool::True`, когда обнаружена защита от записи.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Перегрузка метода для потока [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) предоставляет ту же информацию для презентации, переданной в виде потока.

## **Проверить пароль защиты от записи**

Используйте [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) для проверки пароля изменения без загрузки полной презентации. Сначала проверьте [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/), чтобы приложение запрашивало или проверяло пароль только тогда, когда присутствует защита от записи.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) проверяет только пароль защиты от записи. Он не проверяет пароль открытия и не определяет, может ли быть загружено зашифрованное содержимое. Напротив, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/checkpassword/) проверяет только пароль открытия. Если полная презентация уже загружена, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) предоставляет эквивалентную проверку защиты от записи через менеджер защиты.

В производственных приложениях не записывайте пароли в журнал и не включайте их в диагностические сообщения. Избегайте ненужных повторных попыток проверки и храните пароли в памяти только в течение необходимого времени.

{{% alert color="info" title="Смотрите также" %}}
- [Защита паролем презентаций](/slides/ru/cpp/password-protected-presentation/)
- [Презентации только для чтения](/slides/ru/cpp/read-only-presentation/)
- [Цифровая подпись в PowerPoint](/slides/ru/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Часто задаваемые вопросы**

**Шифрует ли защита от записи презентацию?**

Нет. Она ограничивает изменение, но оставляет содержимое презентации доступным для загрузки и просмотра.

**Требуется ли пароль защиты от записи для открытия презентации?**

Нет. Для загрузки зашифрованного содержимого презентации требуется только пароль открытия.

**Может ли у презентации быть одновременно пароль открытия и пароль защиты от записи?**

Да. Передайте пароль открытия через параметры загрузки, чтобы открыть зашифрованную презентацию, и проверяйте пароль защиты от записи отдельно, когда требуется авторизация на изменение.