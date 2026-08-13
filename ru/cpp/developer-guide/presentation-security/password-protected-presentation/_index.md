---
title: Защита презентаций паролем в C++
linktitle: Защита паролем
type: docs
weight: 20
url: /ru/cpp/password-protected-presentation/
keywords:
- блокировать PowerPoint
- блокировать презентацию
- разблокировать PowerPoint
- разблокировать презентацию
- защитить PowerPoint
- защитить презентацию
- установить пароль
- добавить пароль
- шифровать PowerPoint
- шифровать презентацию
- расшифровать PowerPoint
- расшифровать презентацию
- защита от записи
- безопасность PowerPoint
- безопасность презентации
- удалить пароль
- удалить защиту
- удалить шифрование
- отключить пароль
- отключить защиту
- удалить защиту от записи
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как без труда блокировать и разблокировать защищённые паролем презентации PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Защитите свои презентации."
---
## **Введение**

Когда вы защищаете презентацию паролем, вы задаёте пароль, который накладывает определённые ограничения на презентацию. Чтобы снять ограничения, необходимо ввести пароль. Презентация, защищённая паролем, считается заблокированной презентацией.

Обычно вы можете установить пароль, чтобы наложить эти ограничения на презентацию:

- **Модификация**

  Если вы хотите, чтобы только определённые пользователи могли изменять вашу презентацию, вы можете установить ограничение на модификацию. Это ограничение препятствует людям изменять, менять или копировать содержимое вашей презентации (если только они не предоставят пароль).

  Однако в этом случае, даже без пароля, пользователь сможет открыть ваш документ. В режиме только для чтения пользователь может просматривать содержимое — гиперссылки, анимацию, эффекты и прочее — но не может копировать элементы или сохранять презентацию.

- **Открытие**

  Если вы хотите, чтобы только определённые пользователи могли открыть вашу презентацию, вы можете установить ограничение на открытие. Это ограничение препятствует людям даже просматривать содержимое вашей презентации (если только они не предоставят пароль).

  Технически ограничение на открытие также запрещает пользователям модифицировать презентацию: когда люди не могут открыть презентацию, они не могут вносить в неё изменения.

  **Примечание**: когда вы защищаете презентацию паролем от открытия, файл презентации становится зашифрованным.

## **Как защитить презентацию паролем онлайн**

1. Перейдите на нашу страницу [**Aspose.Slides Lock**](https://products.aspose.app/slides/ru/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Нажмите **Drop or upload your files**.

3. Выберите файл, который хотите защитить паролем, на вашем компьютере.

4. Введите желаемый пароль для защиты редактирования; введите желаемый пароль для защиты просмотра.

5. Если вы хотите, чтобы пользователи видели вашу презентацию как окончательную копию, поставьте галочку **Mark as final**.

6. Нажмите **PROTECT NOW.**

7. Нажмите **DOWNLOAD NOW.**

## **Защита паролем презентаций в Aspose.Slides**
**Поддерживаемые форматы**

Aspose.Slides поддерживает защиту паролем, шифрование и похожие операции для презентаций следующих форматов:

- PPTX и PPT — Microsoft PowerPoint Presentation
- ODP — OpenDocument Presentation
- OTP — OpenDocument Presentation Template

**Поддерживаемые операции**

Aspose.Slides позволяет использовать защиту паролем для предотвращения модификаций презентаций следующими способами:

- Шифрование презентации
- Установка защиты от записи для презентации

**Другие операции**

Aspose.Slides позволяет выполнять другие задачи, связанные с защитой паролем и шифрованием, следующими способами:

- Расшифровка презентации; открытие зашифрованной презентации
- Удаление шифрования; отключение защиты паролем
- Удаление защиты от записи у презентации
- Получение свойств зашифрованной презентации
- Проверка, зашифрована ли презентация
- Проверка, защищена ли презентация паролем.

## **Шифрование презентации**

Вы можете зашифровать презентацию, установив пароль. Затем, чтобы изменить заблокированную презентацию, пользователю потребуется ввести пароль.

Чтобы зашифровать или защитить презентацию паролем, используйте метод encrypt (из [ProtectionManager](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager)) для установки пароля презентации. Передайте пароль методу encrypt и используйте метод save для сохранения теперь зашифрованной презентации.

Этот пример кода показывает, как зашифровать презентацию:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Установка защиты от записи для презентации**

Вы можете добавить отметку «Не изменять» к презентации. Таким образом, вы сообщаете пользователям, что не хотите, чтобы они вносили изменения в презентацию.

**Примечание**: процесс защиты от записи не шифрует презентацию. Поэтому пользователи — если они захотят — могут изменить презентацию, но для сохранения изменений им придётся сохранить её под другим именем.

Чтобы установить защиту от записи, используйте метод setWriteProtection. Этот пример кода показывает, как установить защиту от записи для презентации:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Загрузка зашифрованной презентации**

Aspose.Slides позволяет загрузить зашифрованный файл, передав его пароль. Чтобы расшифровать презентацию, вызовите метод [RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) без параметров. Затем вам потребуется ввести правильный пароль для загрузки презентации.

Этот пример кода показывает, как расшифровать презентацию:

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// работа с расшифрованной презентацией
```

## **Удаление шифрования из презентации**

Вы можете удалить шифрование или защиту паролем из презентации. Таким образом, пользователи смогут получать доступ к презентации или изменять её без ограничений.

Чтобы удалить шифрование или защиту паролем, вызовите метод [RemoveEncryption](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Этот пример кода показывает, как удалить шифрование из презентации:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Удаление защиты от записи у презентации**

Вы можете использовать Aspose.Slides для удаления защиты от записи, установленной для файла презентации. Таким образом, пользователи могут модифицировать её как захотят — без предупреждений.

Для удаления защиты от записи используйте метод [RemoveWriteProtection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Этот пример кода показывает, как удалить защиту от записи у презентации:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Получение свойств зашифрованной презентации**

Обычно пользователи сталкиваются с трудностями при получении свойств документа зашифрованной или защищённой паролем презентации. Однако Aspose.Slides предоставляет механизм, позволяющий защищать презентацию паролем и одновременно получать доступ к её свойствам документа.

**Примечание:** По умолчанию, когда Aspose.Slides шифрует презентацию, свойства документа презентации также защищаются паролем. Если нужно сделать свойства документа доступными даже после шифрования, Aspose.Slides позволяет это сделать.

Если вы хотите, чтобы пользователи сохраняли возможность доступа к свойствам зашифрованной презентации, передайте `false` в метод `set_EncryptDocumentProperties` интерфейса [IProtectionManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprotectionmanager/). Этот пример кода показывает, как зашифровать презентацию, одновременно предоставляя пользователям доступ к её свойствам документа:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Загрузка только свойств документа из зашифрованной презентации**

Чтобы просмотреть метаданные зашифрованной презентации без загрузки её слайдов и другого содержимого, создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/) и установите [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) в `true`. В этом режиме Aspose.Slides игнорирует пароль и загружает только публично доступные свойства документа.

Следующий пример кода читает встроенные и пользовательские свойства документа через [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Этот рабочий процесс работает только тогда, когда свойства документа оставлены незашифрованными (публичными) при шифровании презентации. Если свойства документа зашифрованы, установка `LoadOptions::set_OnlyLoadDocumentProperties` в `true` приводит к исключению, поскольку пароль игнорируется в этом режиме. Чтобы получить зашифрованные свойства документа или загрузить полную презентацию, включая её слайды и другое содержимое, укажите правильный пароль с помощью `LoadOptions::set_Password` в [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/).

## **Проверка, защищена ли презентация паролем**

Перед загрузкой презентации вы можете проверить и убедиться, что презентация не защищена паролем. Это поможет избежать ошибок и подобных проблем, которые возникают при попытке загрузить защищённую паролем презентацию без пароля.

Этот код C++ показывает, как проверить презентацию на наличие пароля (без загрузки самой презентации):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Проверка, зашифрована ли презентация**

Aspose.Slides позволяет проверить, зашифрована ли презентация. Для этой операции используйте метод [get_IsEncrypted()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), который возвращает `true`, если презентация зашифрована, и `false`, если нет.

Этот пример кода показывает, как проверить, зашифрована ли презентация:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Проверка, защищена ли презентация от записи**

Aspose.Slides позволяет проверить, защищена ли презентация от записи. Для этой операции используйте метод [get_IsWriteProtected()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), который возвращает `true`, если презентация защищена от записи, и `false`, если нет.

Этот пример кода показывает, как проверить, защищена ли презентация от записи:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Проверка использования пароля презентации**

Возможно, вам потребуется убедиться, что конкретный пароль был использован для защиты документа презентации. Aspose.Slides предоставляет средства для проверки пароля.

Этот пример кода показывает, как проверить пароль:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// проверка, совпадает ли "pass" с
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Он возвращает `true`, если презентация зашифрована указанным паролем. В противном случае возвращает `false`.

{{% alert color="info" title="Смотрите также" %}} 
- [Digital Signature in PowerPoint](/slides/ru/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Какие методы шифрования поддерживает Aspose.Slides?**

Aspose.Slides поддерживает современные методы шифрования, включая алгоритмы на основе AES, обеспечивая высокий уровень безопасности данных ваших презентаций.

**Что происходит, если при попытке открыть презентацию ввести неверный пароль?**

Выбрасывается исключение, указывающее, что доступ к презентации запрещён. Это помогает предотвратить несанкционированный доступ и защищает содержимое презентации.

**Есть ли влияния на производительность при работе с защищёнными паролем презентациями?**

Процессы шифрования и дешифрования могут добавить небольшие задержки при открытии и сохранении файлов. В большинстве случаев влияние на производительность минимально и не существенно сказывается на общем времени обработки ваших задач с презентациями.