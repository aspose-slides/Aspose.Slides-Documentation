---
title: Управление метками конфиденциальности в презентациях PowerPoint на .NET
linktitle: Метки конфиденциальности
type: docs
weight: 50
url: /ru/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Чтение, добавление, обновление, удаление и миграция меток конфиденциальности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для .NET."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides предоставляет современный метаданные меток конфиденциальности через [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/). Это свойство возвращает [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/), который можно просматривать и изменять перед сохранением презентации в формате PPTX.

{{% alert color="primary" title="Note" %}}
Идентификаторы меток конфиденциальности и информация о политиках определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/) описывают маркировку содержимого, связанную с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.
{{% /alert %}}

## **Понимание свойств метки конфиденциальности**

Каждый [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/) содержит следующие метаданные:

| Свойство | Назначение |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/id/) | Идентифицирует метку конфиденциальности в политике Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/siteid/) | Идентифицирует сайт, связанный с политикой метки. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isenabled/) | Указывает, включена ли метка. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) | Указывает, что метка была удалена. Установите это свойство в `true`, если состояние удаления должно сохраняться в метаданных. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Указывает, была ли метка применена автоматически или по решению пользователя. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Список типов маркировки содержимого, связанных с меткой. |

Перечисление [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) описывает, как была назначена метка:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или применённую автоматически.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Перечисление [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Описание |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Метка была применена по умолчанию или автоматически. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого заголовка ассоциирована с меткой. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого нижнего колонтитула ассоциирована с меткой. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого водяного знака ассоциирована с меткой. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ru/net/aspose.slides/sensitivitylabelcontenttype/) | Шифрование защиты ассоциировано с меткой. |

Несколько типов маркировки могут быть связаны с одной меткой.

## **Список существующих меток конфиденциальности**

Прочитайте современную коллекцию меток из [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/) и перечислите её. В следующем примере перечисляются все свойства и маркировки содержимого, сохранённые для каждой метки:

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

## **Добавление метки конфиденциальности с маркировкой содержимого**

Используйте [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После того как метод вернёт новую [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/), добавьте требуемые значения маркировки через [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/).

В следующем примере добавляется вручную выбранная метка, связанная с маркировкой нижнего колонтитула и водяного знака, после чего результат сохраняется как PPTX:

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

## **Обновление метки конфиденциальности**

Свойства [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/) доступны для чтения и записи, за исключением коллекции, возвращаемой [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/), которая изменяется через операции списка. После поиска необходимой метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

В следующем примере обновляются состояние включения и метод назначения первой метки:

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

## **Пометить метку конфиденциальности как удалённую**

Чтобы сохранить факт удаления метки, найдите её и установите [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) в `true`. Это сохраняет запись о метке, фиксируя её состояние удаления. Если вместо этого необходимо удалить запись из современной коллекции, используйте [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/removeat/); используйте [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/clear/) для удаления всех записей.

В следующем примере конкретная метка помечается как удалённая и сохраняется обновлённая презентация:

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

## **Чтение и миграция устаревших меток конфиденциальности MIP**

Более старые рабочие процессы, основанные на MIP, могут хранить метаданные меток конфиденциальности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Метод анализирует устаревшие пользовательские свойства и возвращает массив объектов [ISensitivityLabel](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/).

Для миграции метаданных добавьте каждую полученную метку в современную [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/) через [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/). Поскольку попытка добавить метку с дублирующим идентификатором вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы убедиться, что каждая устаревшая метка всё ещё существует в текущей политике Purview.

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

Миграция копирует разобранные объекты меток в современную коллекцию. Она не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные остаются нетронутыми. Используйте [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) вместе с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) для записи современных метаданных меток в файл PPTX.

## **Часто задаваемые вопросы**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/contentmarktypes/), описывают маркировку, связанную с меткой конфиденциальности. Они не создают видимый текст или фигуры в презентации. При необходимости отобразить эти маркировки добавьте соответствующее содержимое слайда отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Установка [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/isremoved/) в `true` сохраняет запись о метке и фиксирует её состояние удаления. Вызов [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/removeat/) полностью удаляет запись из современной коллекции. Выбирайте действие, соответствующее требованиям вашей организации по сохранению метаданных.

**Можно ли в презентации одновременно иметь устаревшие метаданные MIP и современные метки конфиденциальности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [Presentation.SensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sensitivitylabels/). Используйте [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/getsensitivitylabels/) для чтения устаревших метаданных и мигрируйте только те метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с одинаковым идентификатором добавляется более одного раза?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabelcollection/add/) бросает `ArgumentException`, когда коллекция уже содержит метку с тем же идентификатором. Проверяйте существующие значения [ISensitivityLabel.Id](https://reference.aspose.com/slides/ru/net/aspose.slides/isensitivitylabel/id/) перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток конфиденциальности?**

Сохраняйте презентацию в формате PPTX, вызывая [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/), как показано в примерах выше.