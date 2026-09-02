---
title: Управление метками конфиденциальности в презентациях PowerPoint на C++
linktitle: Метки конфиденциальности
type: docs
weight: 50
url: /ru/cpp/sensitivity-labels/
keywords:
- метка конфиденциальности
- Microsoft Purview
- Microsoft Information Protection
- метаданные MIP
- маркировка содержимого
- защита информации
- управление документами
- PowerPoint
- PPTX
- безопасность презентаций
- C++
- Aspose.Slides
description: "Читать, добавлять, обновлять, удалять и мигрировать метки конфиденциальности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для C++."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребоваться сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides предоставляет современные метаданные меток конфиденциальности через [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Этот метод возвращает [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/), которую можно просмотреть и изменить перед сохранением презентации в формате PPTX.

{{% alert color="primary" title="Примечание" %}}

Идентификаторы меток конфиденциальности и информация о политике определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) описывают маркировки содержимого, связанные с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.

{{% /alert %}}

## **Понимание свойств метки конфиденциальности**

Каждый [ISensitivityLabel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/) содержит следующие метаданные:

| Доступ к свойствам | Описание |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_id/) | Идентифицирует метку конфиденциальности в политике Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Идентифицирует сайт, связанный с политикой метки. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Указывает, включена ли метка. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Указывает, что метка была удалена. Установите значение `true`, когда состояние удаления должно сохраняться в метаданных. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Указывает, была ли метка применена автоматически или в результате решения пользователя. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Список типов маркировки содержимого, связанных с меткой. |

Перечисление [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelassignmenttype/) описывает, как была назначена метка:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или автоматически применённую.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую пользователем, включая вручную применяемые, рекомендованные и обязательные метки.

Перечисление [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) идентифицирует маркировку, связанную с меткой:

| Значение | Значение |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) | Метка применена по умолчанию или автоматически. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка заголовка. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка нижнего колонтитула. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка водяного знака. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана защита шифрованием. |

К одной метке могут быть привязаны несколько типов маркировки.

## **Список существующих меток конфиденциальности**

Чтение современной коллекции меток из [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) и её перечисление. В следующем примере перечисляются все свойства и маркировки содержимого, хранящиеся для каждой метки:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Добавление метки конфиденциальности с маркировкой содержимого**

Используйте [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/add/) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После возврата метода получаете новую [ISensitivityLabel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/), добавьте требуемые типы маркировки через [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

В следующем примере добавляется вручную выбранная метка, связанная с маркировками нижнего колонтитула и водяного знака, после чего результат сохраняется в формате PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Обновление метки конфиденциальности**

Значения [ISensitivityLabel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/) доступны для чтения/записи через их методы‑получатели и методы‑установщики, за исключением коллекции, возвращаемой [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/), которая модифицируется через операции списка. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

В следующем примере обновляются состояние включения и метод назначения первой метки:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Отметка метки конфиденциальности как удалённой**

Чтобы сохранить факт удаления метки, найдите её и вызовите [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_isremoved/) с `true`. Это сохраняет запись о метке, фиксируя её состояние удаления. Если вместо этого необходимо удалить запись из современной коллекции, используйте [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/removeat/); для удаления всех записей используйте [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/clear/).

В следующем примере конкретная метка отмечается как удалённая и сохраняется обновлённая презентация:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Чтение и миграция устаревших меток MIP**

Старые рабочие процессы на основе MIP могут хранить метаданные меток конфиденциальности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Метод разбирает устаревшие пользовательские свойства и возвращает массив объектов [ISensitivityLabel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/).

Для миграции метаданных добавьте каждую полученную метку в современную [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/) через [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/add/). Поскольку добавление дублирующего идентификатора метки вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы подтвердить, что каждая устаревшая метка всё ещё существует в текущей политике Purview.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Миграция копирует разобранные объекты меток в современную коллекцию. Она не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные остаются нетронутыми. Используйте [IPresentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/save/) с [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/), описывают маркировки, связанные с меткой конфиденциальности. Они не создают видимый текст или фигуры в презентации. Добавьте соответствующее содержимое слайда отдельно, если ваш рабочий процесс должен отобразить эти маркировки.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Вызов [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/set_isremoved/) с `true` сохраняет запись о метке и фиксирует её состояние удаления. Вызов [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/removeat/) удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации по сохранению метаданных.

**Может ли презентация содержать одновременно устаревшие метаданные MIP и современные метки конфиденциальности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, в то время как современные метки доступны через [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Используйте [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) для чтения устаревших метаданных и мигрируйте только валидные метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabelcollection/add/) бросает исключение аргумента, когда коллекция уже содержит метку с таким же идентификатором. Проверьте существующие значения [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isensitivitylabel/get_id/) перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток конфиденциальности?**

Сохраните презентацию как PPTX, вызвав [IPresentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/save/) с [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/), как показано в примерах выше.