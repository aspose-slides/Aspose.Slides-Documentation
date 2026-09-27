---
title: Лицензирование
type: docs
weight: 120
url: /ru/cpp/licensing/
keywords:
- лицензия
- временная лицензия
- установить лицензию
- использовать лицензию
- проверить лицензию
- файл лицензии
- версия оценки
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте, управляйте и устраняйте проблемы с лицензиями в Aspose.Slides for C++. Обеспечьте беспрерывный доступ ко всем функциям с помощью нашего пошагового руководства по лицензированию."
---
## **Обзор**

Aspose.Slides можно использовать в режиме оценки или с действующей лицензией. Версия оценки предоставляет тот же функционал, что и лицензированная версия, но добавляет водяной знак оценки на каждый слайд каждой презентации, которую она сохраняет, и обрезает текст, который ваш код читает из презентаций.

В этой статье объясняется, как работает лицензирование в Aspose.Slides и как применить лицензию перед использованием библиотеки. Лицензию можно загрузить из файла или из потока с помощью класса `License`. В статье также показывается, как проверить, была ли лицензия применена корректно.

## **Оценка Aspose.Slides**

{{% alert color="info" title="Note" %}}
Вы можете скачать оценочную версию **Aspose.Slides for C++** со [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.Cpp/) или в виде ZIP‑пакета со [download page](https://releases.aspose.com/slides/cpp/). Оценочная версия предлагает тот же функционал, что и лицензированный продукт. На самом деле оценочный пакет идентичен купленному – он просто становится лицензированным после того, как вы добавите несколько строк кода для применения лицензии.
{{% /alert %}}

После того как вы убедитесь в ценности **Aspose.Slides**, вы можете [purchase a license](https://purchase.aspose.com/pricing/slides/cpp/). Мы рекомендуем ознакомиться с доступными типами подписок. Если у вас есть вопросы, смело обращайтесь к команде продаж Aspose.

Каждая лицензия Aspose включает годовую подписку на бесплатные обновления, включая новые версии и исправления ошибок, выпущенные в течение этого периода. Независимо от того, используете ли вы лицензированную или оценочную версию, вы получаете бесплатную и неограниченную техническую поддержку.
{{% alert color="info" title="Note" %}}
Для тестирования Aspose.Slides без ограничений вы можете запросить **30‑Day Temporary License**. Подробности см. на странице [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

**Ограничения версии оценки**

* Оценочная версия (без указания лицензии) предоставляет полный функционал продукта, но добавляет текстовое поле с водяным знаком оценки на каждый слайд каждой сохранённой презентации.
* Текст, который ваш код читает из презентации, обрезается до первых нескольких символов с последующим уведомлением об ограничении оценки. Текст, который ваш код записывает, сохраняется полностью.

## **Лицензирование в Aspose.Slides**

* Оценочная версия становится лицензированной после покупки лицензии и её применения несколькими строками кода.
* Лицензия представляет собой обычный XML‑файл, содержащий такие детали, как название продукта, количество разработчиков, для которых лицензия действительна, дата окончания подписки и др.
* Файл лицензии подписан цифровой подписью, поэтому его нельзя изменять. Даже случайное изменение, например добавление перевода строки, сделает файл недействительным.
* Когда вы передаёте только имя файла без пути, Aspose.Slides for C++ ищет файл лицензии только в текущем рабочем каталоге. Он не ищет в каталоге исполняемого файла или библиотеки Aspose.Slides, поэтому указывайте полный путь, если файл находится в другом месте.
* Чтобы избавиться от ограничений версии оценки, необходимо установить лицензию до использования Aspose.Slides. Лицензия требуется только один раз за приложение или процесс.

## **Применить лицензию**

Лицензию можно загрузить из **файла** или **потока**.

{{% alert color="info" title="Note" %}}
Aspose.Slides предоставляет класс [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) для операций с лицензиями.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Новые лицензии могут активировать Aspose.Slides только начиная с версии 21.4. Более ранние версии используют другую систему лицензирования и не распознают эти лицензии.
{{% /alert %}}

### **File**

Самый простой способ установить лицензию – разместить файл лицензии в рабочем каталоге программы и указать только имя файла без пути. В противном случае укажите полный путь к файлу.

Следующий код C++ применяет файл лицензии *Aspose.Slides.lic* из рабочего каталога программы:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Если лицензия действительна, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) возвращается, и программа завершается без вывода; с этого момента Aspose.Slides работает без ограничений оценки. Если файл отсутствует в рабочем каталоге, метод бросает [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) с сообщением *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Пример не обрабатывает исключение, поэтому программа останавливается.

{{% alert color="warning" title="Warning" %}}
Если вы разместили файл лицензии в другом каталоге, при вызове метода [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) имя файла в конце указанного полного пути должно точно совпадать с именем вашего файла лицензии.

Например, если вы переименовали файл лицензии в *Aspose.Slides.lic.xml*, вы должны передать полный путь, заканчивающийся *Aspose.Slides.lic.xml*, в метод [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) в вашем коде.
{{% /alert %}}

### **Stream**

Загрузите лицензию из потока, когда ваша программа не хранит лицензию в виде файла, например, когда она читает лицензию из базы данных. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) принимает любой [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/), содержащий лицензию. Чтобы пример был коротким, следующий код C++ открывает *Aspose.Slides.lic* в рабочем каталоге с помощью [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) и применяет лицензию из этого потока:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Действительная лицензия даёт тот же результат, что и в примере с файлом. Если файл не существует, [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) бросает [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) до применения лицензии, и программа останавливается.

## **Validate a License**

Чтобы проверить, была ли лицензия установлена правильно, вызовите [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/). Метод возвращает `true` только после применения действительной лицензии и `false` до этого. Следующий код C++ применяет файл лицензии из рабочего каталога, а затем проверяет её:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

При действительной лицензии программа выводит *License is good!*. Если файл отсутствует или не является файлом лицензии, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) бросает исключение до проверки, и программа останавливается без вывода. Если файл лицензии имеет неподходящую подпись, например из‑за редактирования, SetLicense возвращает без ошибки, но `IsLicensed` возвращает `false`, поэтому ничего не выводится, и Aspose.Slides остаётся в режиме оценки.

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}
Метод [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) **не является потокобезопасным**. Если вам необходимо вызывать этот метод из нескольких потоков одновременно, рекомендуется использовать примитивы синхронизации (например, lock), чтобы избежать возможных проблем.
{{% /alert %}}

## **FAQ**

### Можно ли применить лицензию в полностью офлайн‑среде (без доступа к интернету)?

Да. Проверка лицензии выполняется локально с использованием файла лицензии; подключение к интернету не требуется.

### Что происходит после окончания годовой подписки? Прекратит ли библиотека работу?

Нет. Лицензия является бессрочной: вы можете продолжать использовать версии, выпущенные до даты окончания подписки; просто вы не сможете пользоваться более новыми выпусками без продления подписки.