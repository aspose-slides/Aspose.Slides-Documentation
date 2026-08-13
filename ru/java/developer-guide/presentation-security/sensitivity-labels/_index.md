---
title: Управление метками чувствительности в презентациях PowerPoint на Java
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Читать, добавлять, обновлять, удалять и мигрировать метки чувствительности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для Java."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматизированной обработке презентаций приложение может потребоваться сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides предоставляет метаданные современных меток чувствительности через [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Этот метод возвращает [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/), который можно просмотреть и изменить перед сохранением презентации в формате PPTX.

{{% alert color="info" title="Примечание" %}}
Идентификаторы меток чувствительности и информация о политике определяются в вашей конфигурации Microsoft Purview. Проверьте доступность меток и требования политики в вашей среде перед добавлением или миграцией метаданных. Значения [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) описывают маркировки содержимого, связанные с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.
{{% /alert %}}

## **Понимание свойств меток чувствительности**

Каждый [ISensitivityLabel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/) содержит следующие метаданные:

| Методы | Назначение |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getId--) и [ISensitivityLabel.setId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Получить или задать идентификатор метки чувствительности в политике Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getSiteId--) и [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Получить или задать сайт, связанный с политикой метки. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#isEnabled--) и [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Получить или задать, включена ли метка. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#isRemoved--) и [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Получить или задать, была ли метка удалена. Установите значение `true`, когда состояние удаления должно сохраняться в метаданных. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) и [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Получить или задать, была ли метка применена автоматически или по решению пользователя. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Получить типы маркировки содержимого, связанные с меткой. |

Класс [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelassignmenttype/) определяет, как была назначена метка:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelassignmenttype/) представляет метку по умолчанию или автоматически применённую метку.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelassignmenttype/) представляет метку, применённую по решению пользователя, включая вручную применяемые, рекомендуемые и обязательные метки.

Класс [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Описание |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) | Метку применили по умолчанию или автоматически. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого заголовка связана с меткой. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого нижнего колонтитула связана с меткой. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) | Маркировка содержимого водяного знака связана с меткой. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ru/java/com.aspose.slides/sensitivitylabelcontenttype/) | Защита шифрованием связана с меткой. |

Несколько типов маркировки могут быть связаны с одной меткой.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток через [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) и перечислите её. В следующем примере перечисляются все свойства и маркировки содержимого, хранящиеся для каждой метки:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Добавление метки чувствительности с маркировкой содержимого**

Используйте [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После того как метод вернёт новый [ISensitivityLabel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/), добавьте необходимые значения маркировки через список, возвращаемый [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

В следующем примере добавляется вручную выбранная метка, связанная с маркировкой нижнего колонтитула и водяного знака, затем результат сохраняется в формате PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обновление метки чувствительности**

Значения [ISensitivityLabel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/) доступны для чтения и записи, за исключением того, что список, возвращаемый [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), изменяется через его операции со списком. После нахождения необходимой метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

В следующем примере обновляются состояние включения и метод назначения первой метки:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Пометить метку чувствительности как удалённую**

Чтобы сохранить факт удаления метки, найдите её и вызовите [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) с `true`. Это сохраняет запись метки, одновременно фиксируя её состояние удаления. Если вместо этого необходимо удалить запись из современной коллекции, используйте [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); используйте [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#clear--) чтобы удалить все записи.

В следующем примере конкретная метка помечается как удалённая, и сохраняется обновлённая презентация:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Чтение и миграция устаревших меток чувствительности MIP**

Старые рабочие процессы на основе MIP могут хранить метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Метод разбирает устаревшие пользовательские свойства и возвращает массив объектов [ISensitivityLabel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/).

Чтобы перенести метаданные, добавьте каждую полученную метку в современную [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/) через [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Поскольку добавление метки с дублирующим идентификатором вызывает исключение, в примере проверяется целевая коллекция перед копированием каждой метки. Вы можете добавить дополнительную проверку, чтобы подтвердить, что каждая устаревшая метка всё ещё существует в текущей политике Purview.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Миграция копирует разобранные объекты меток в современную коллекцию. Очистка всех пользовательских свойств документа не требуется, поэтому несвязанные метаданные документа остаются нетронутыми. Используйте [IPresentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) , чтобы записать современные метаданные меток в файл PPTX.

## **Вопросы и ответы**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавляемые через список, возвращаемый [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), описывают маркировки, связанные с меткой чувствительности. Они не создают видимый текст или объекты в презентации. При необходимости отобразить эти маркировки добавьте соответствующее содержимое слайда отдельно.

**В чём разница между пометкой метки как удалённой и её удалением из коллекции?**

Вызов [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) с `true` сохраняет запись метки и фиксирует её состояние удаления. Вызов [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации по сохранению метаданных.

**Может ли презентация содержать как устаревшие метаданные MIP, так и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, в то время как современные метки доступны через [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Используйте [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) , чтобы прочитать устаревшие метаданные и перенести только действительные метки, которые ещё не присутствуют в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) генерирует исключение, если коллекция уже содержит метку с тем же идентификатором. Проверьте существующие значения, возвращаемые [ISensitivityLabel.getId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isensitivitylabel/#getId--) , перед добавлением или миграцией меток.

**Какой формат вывода следует использовать, чтобы сохранить обновлённые метки чувствительности?**

Сохраните презентацию в формате PPTX, вызвав [IPresentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/) , как показано в примерах выше.