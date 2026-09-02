---
title: Управление метками чувствительности в презентациях PowerPoint на JavaScript
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Читать, добавлять, обновлять, удалять и мигрировать метки чувствительности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides for Node.js via Java предоставляет современные метаданные меток чувствительности через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Этот метод возвращает [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/), которую можно просмотреть и изменить перед сохранением презентации в формате PPTX.

{{% alert color="primary" title="Note" %}}
Идентификаторы меток чувствительности и информация о политике определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в своей среде перед добавлением или миграцией метаданных. Значения [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) описывают типы маркировки, связанные с меткой; они сами по себе не добавляют видимый текст или объекты на слайды.
{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [SensitivityLabel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/) содержит следующие метаданные:

| Методы | Назначение |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getId) и [SensitivityLabel.setId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Получить или задать идентификатор метки чувствительности в политике Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) и [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Получить или задать сайт, связанный с политикой метки. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) и [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Получить или задать, включена ли метка. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) и [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Получить или задать, была ли метка удалена. Установите значение `true`, когда состояние удаления должно сохраняться в метаданных. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) и [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Получить или задать, была ли метка применена автоматически или по решению пользователя. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Получить типы маркировки содержимого, связанные с меткой. |

Класс [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) определяет способ назначения метки:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по умолчанию или автоматически.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Класс [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) определяет тип маркировки, связанной с меткой:

| Значение | Описание |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Метка применена по умолчанию или автоматически. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка заголовка. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка нижнего колонтитула. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана маркировка водяного знака. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | К метке привязана защита шифрованием. |

Один метке могут соответствовать несколько типов маркировки.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) и перечислите её. В следующем примере перечисляются все свойства и типы маркировки, хранящиеся для каждой метки:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Добавление метки чувствительности с маркировкой содержимого**

Используйте [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) с идентификатором метки, идентификатором сайта, состоянием включения и способом назначения. После того как метод вернёт новый [SensitivityLabel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/), добавьте необходимые значения маркировки через список, полученный от [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

В следующем примере добавляется вручную выбранная метка, связанная с маркировками нижнего колонтитула и водяного знака, после чего результат сохраняется как PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обновление метки чувствительности**

Значения [SensitivityLabel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/) доступны для чтения и записи, за исключением списка, возвращаемого [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), который изменяется через операции над списком. Найдя нужную метку, вы можете обновить её идентификатор, идентификатор сайта, состояние включения, способ назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

В следующем примере обновляются состояние включения и способ назначения первой метки:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Пометить метку чувствительности как удалённую**

Чтобы зафиксировать факт удаления метки, найдите её и вызовите [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) со значением `true`. Это сохраняет запись о метке, отмечая её как удалённую. Если необходимо полностью удалить запись из современной коллекции, используйте [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); для удаления всех записей примените [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear).

В следующем примере конкретная метка помечается как удалённая, после чего обновлённая презентация сохраняется:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Чтение и миграция устаревших меток чувствительности MIP**

Старые рабочие процессы, основанные на MIP, могут сохранять метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Метод parses legacy custom properties and returns an array of [SensitivityLabel] objects.

Чтобы мигрировать метаданные, добавьте каждую полученную метку в современную [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/) через [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Поскольку добавление метки с дублирующим идентификатором вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы убедиться, что каждая устаревшая метка всё ещё присутствует в текущей политике Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Миграция копирует разобранные объекты меток в современную коллекцию. При этом не требуется очищать все пользовательские свойства документа, поэтому несвязанные метаданные остаются нетронутыми. Используйте [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через список, возвращаемый [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), описывают маркировки, связанные с меткой чувствительности. Они не создают видимый текст или объекты в презентации. Если ваш рабочий процесс должен отображать такие маркировки, добавьте соответствующее содержимое слайда отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Вызов [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) со значением `true` сохраняет запись о метке и фиксирует её состояние как удалённое. Вызов [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) полностью удаляет запись из современной коллекции. Выбирайте действие, соответствующее требованиям вашей организации по хранению метаданных.

**Может ли презентация одновременно содержать устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Используйте [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) для чтения устаревших метаданных и мигрируйте только те метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) генерирует исключение, когда коллекция уже содержит метку с таким же идентификатором. Проверьте существующие значения, полученные через [SensitivityLabel.getId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sensitivitylabel/#getId), перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток чувствительности?**

Сохраните презентацию в формате PPTX, вызвав [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/), как показано в примерах выше.