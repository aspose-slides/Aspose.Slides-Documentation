---
title: Управление метками чувствительности в презентациях PowerPoint на PHP
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/php-java/sensitivity-labels/
keywords:
- метка чувствительности
- Microsoft Purview
- Microsoft Information Protection
- метаданные MIP
- маркировка контента
- защита информации
- управление документами
- PowerPoint
- PPTX
- безопасность презентаций
- PHP
- Aspose.Slides
description: "Чтение, добавление, обновление, удаление и миграция меток чувствительности Microsoft Purview в презентациях PowerPoint PPTX на PHP."
---
## **Обзор**

Метки чувствительности Microsoft Purview помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides for PHP via Java предоставляет современные метаданные меток чувствительности через [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSensitivityLabels). Этот метод возвращает [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/), которую можно просмотреть и изменить до сохранения презентации в формате PPTX.

{{% alert color="primary" title="Note" %}}
Идентификаторы меток чувствительности и информация о политике определяются конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) описывают маркировки контента, связанные с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.
{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [SensitivityLabel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/) содержит следующие метаданные:

| Методы | Назначение |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getId) и [SensitivityLabel::setId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setId) | Получить или установить идентификатор метки чувствительности в политике Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getSiteId) и [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Получить или установить сайт, связанный с политикой метки. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#isEnabled) и [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Получить или установить, включена ли метка. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#isRemoved) и [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Получить или установить, была ли метка удалена. Установите значение `true`, когда состояние удаления должно сохраняться в метаданных. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) и [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Получить или установить, была ли метка применена автоматически или по решению пользователя. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Получить типы маркировки контента, связанные с меткой. |

Класс [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelassignmenttype/) определяет способ назначения метки:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, назначенную по умолчанию или автоматически.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Класс [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Значение |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) | Метка применена по умолчанию или автоматически. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) | К метке относится маркировка содержимого заголовка. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) | К метке относится маркировка содержимого нижнего колонтитула. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) | К метке относится маркировка водяного знака. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcontenttype/) | К метке относится защита шифрованием. |

Несколько типов маркировки могут быть связаны с одной меткой.

## **Перечисление существующих меток чувствительности**

Прочитайте современную коллекцию меток через [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSensitivityLabels) и пройдите её. Ниже приведён пример, который выводит каждое свойство и маркировку контента, сохранённые для каждой метки:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Добавление метки чувствительности с маркировкой контента**

Используйте [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#add) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После возврата нового [SensitivityLabel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/) добавьте необходимые типы маркировки через список, возвращаемый [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Ниже пример, который добавляет вручную выбранную метку, связанную с маркировкой нижнего колонтитула и водяного знака, а затем сохраняет результат в формате PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Обновление метки чувствительности**

Значения [SensitivityLabel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/) доступны для чтения и записи, за исключением списка, возвращаемого [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), который изменяется через его операции над списком. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки контента. Сохраните презентацию, чтобы зафиксировать изменения.

Ниже пример, который обновляет состояние включения и метод назначения первой метки:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Отметить метку чувствительности как удалённую**

Чтобы сохранить факт удаления метки, найдите её и вызовите [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setRemoved) с параметром `true`. Это сохраняет запись о метке, фиксируя её состояние удаления. Если же необходимо полностью удалить запись из современной коллекции, используйте [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); для удаления всех записей воспользуйтесь [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#clear).

Ниже пример, который отмечает конкретную метку как удалённую и сохраняет обновлённую презентацию:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Чтение и миграция устаревших меток MIP**

Старые рабочие процессы на основе MIP могут сохранять метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Метод разбирает устаревшие пользовательские свойства и возвращает массив Java‑объектов [SensitivityLabel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/).

Для миграции метаданных добавьте каждую полученную метку в современную [SensitivityLabelCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/) через [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#add). Поскольку добавление дублирующего идентификатора метки вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. При необходимости можно добавить дополнительную проверку, подтверждающую, что каждая устаревшая метка всё ещё существует в текущей политике Purview.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Миграция копирует разобранные объекты меток в современную коллекцию. Это не требует очистки всех пользовательских свойств документа, поэтому несвязанные метаданные документа остаются нетронутыми. Используйте [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) с [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/) для записи современных метаданных меток в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки контента видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавленные через список, возвращаемый [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), описывают маркировки, связанные с меткой чувствительности. Они не создают видимый текст или фигуры в презентации. При необходимости отобразить такие маркировки добавьте соответствующее содержимое слайдов отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Вызов [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#setRemoved) с `true` сохраняет запись о метке и фиксирует её состояние удаления. Вызов [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации по хранению метаданных.

**Может ли презентация содержать одновременно устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSensitivityLabels). Используйте [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getSensitivityLabels) для чтения устаревших метаданных и миграции только тех меток, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabelcollection/#add) вызывает исключение, когда в коллекции уже существует метка с таким же идентификатором. Проверяйте существующие значения, возвращаемые [SensitivityLabel::getId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sensitivitylabel/#getId), перед добавлением или миграцией меток.

**Какой формат вывода следует использовать для сохранения обновлённых меток чувствительности?**

Сохраните презентацию в формате PPTX, вызвав [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) с [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/), как показано в примерах выше.