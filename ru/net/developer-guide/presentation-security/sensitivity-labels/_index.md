---
title: Управление метками чувствительности в презентациях PowerPoint на .NET
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/net/sensitivity-labels/
keywords:
- метка чувствительности
- Microsoft Purview
- Microsoft Information Protection
- метаданные MIP
- маркировка содержимого
- защита информации
- управление документами
- PowerPoint
- PPTX
- безопасность презентаций
- .NET
- C#
- Aspose.Slides
description: "Чтение, добавление, обновление, удаление и миграция меток чувствительности Microsoft Purview в презентациях PowerPoint PPTX с использованием Aspose.Slides для .NET."
---
## **Обзор**

Метки чувствительности Microsoft Purview помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides предоставляет современные метаданные меток чувствительности через [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/). Это свойство возвращает [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/), которую можно просматривать и изменять перед сохранением презентации в формате PPTX.

{{% alert color="info" title="Примечание" %}}
Идентификаторы меток чувствительности и информация о политиках определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или переносом метаданных. Значения [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/) описывают связанные с меткой маркировки содержимого; они сами по себе не добавляют видимый текст или фигуры на слайды.
{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/) содержит следующие метаданные:

| Property | Purpose |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/id/) | Идентифицирует метку чувствительности в политике Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/siteid/) | Идентифицирует сайт, связанный с политикой метки. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isenabled/) | Указывает, включена ли метка. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) | Указывает, что метка была удалена. Установите это свойство в `true`, когда состояние удаления должно сохраняться в метаданных. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Определяет, была ли метка применена автоматически или по решению пользователя. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Список типов маркировки содержимого, связанных с меткой. |

Перечисление [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) описывает способ назначения метки:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или применённую автоматически.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Перечисление [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Метка была применена по умолчанию или автоматически. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого заголовка связана с меткой. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого нижнего колонтитула связана с меткой. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого водяного знака связана с меткой. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Защита шифрованием связана с меткой. |

Один метке могут соответствовать несколько типов маркировки.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток из [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/) и переберите её. Ниже приведён пример, выводящий каждое свойство и маркировку содержимого, хранящуюся для каждой метки:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Добавление метки чувствительности с маркировкой содержимого**

Вызовите [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После возврата нового [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/) добавьте необходимые значения маркировки через [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Ниже пример, добавляющий вручную выбранную метку, связанную с маркировкой нижнего колонтитула и водяного знака, и сохраняющий результат в PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Обновление метки чувствительности**

Свойства [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/) доступны для чтения и записи, за исключением коллекции, возвращаемой [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/), которая изменяется через операции списка. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

Ниже пример, обновляющий состояние включения и метод назначения первой метки:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Обозначение метки чувствительности как удалённой**

Чтобы сохранить факт удаления метки, найдите её и установите [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) в `true`. Это сохраняет запись о метке, фиксируя её состояние удаления. Если необходимо полностью удалить запись из современной коллекции, используйте [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/removeat/); для удаления всех записей – [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/clear/).

Пример, помечающий конкретную метку как удалённую и сохраняющий обновлённую презентацию:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Чтение и миграция устаревших меток MIP**

Старые MIP‑ориентированные рабочие процессы могут хранить метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Метод разбирает пользовательские свойства и возвращает массив объектов [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/).

Для миграции метаданных добавьте каждую возвращённую метку в современную [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/) через [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/). Поскольку добавление дублирующего идентификатора метки приводит к исключению, пример проверяет целевую коллекцию перед копированием каждой метки. При необходимости можно добавить дополнительную проверку, чтобы убедиться, что каждая устаревшая метка всё ещё присутствует в текущей политике Purview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Миграция копирует разобранные объекты меток в современную коллекцию. Она не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные остаются нетронутыми. Используйте [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/), описывают маркировки, связанные с меткой чувствительности. Они не создают видимый текст или фигуры в презентации. При необходимости отобразить такие маркировки добавьте соответствующее содержимое слайдов отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Установка [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) в `true` сохраняет запись о метке и фиксирует её состояние удаления. Вызов [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/removeat/) полностью удаляет запись из современной коллекции. Выберите действие, соответствующее требованиям вашей организации по сохранению метаданных.

**Можно ли в одной презентации одновременно иметь устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, в то время как современные метки доступны через [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/). Используйте [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/getsensitivitylabels/) для чтения устаревших метаданных и мигрируйте только действительные метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/) генерирует `ArgumentException`, когда коллекция уже содержит метку с таким же идентификатором. Проверяйте существующие значения [ISensitivityLabel.Id](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/id/) перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток чувствительности?**

Сохраняйте презентацию в формате PPTX, вызывая [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/), как показано в примерах выше.