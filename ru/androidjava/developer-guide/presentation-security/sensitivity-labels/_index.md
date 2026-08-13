---
title: Управление метками чувствительности в презентациях PowerPoint на Android
linktitle: Метки чувствительности
type: docs
weight: 50
url: /ru/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Чтение, добавление, обновление, удаление и миграция меток чувствительности Microsoft Purview в презентациях PowerPoint PPTX с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Microsoft Purview sensitivity labels помогают организациям классифицировать и управлять документами. При автоматической обработке презентаций приложение может потребовать сохранить существующую метку, применить метку, выбранную политикой, обновить её состояние или перенести метаданные метки, записанные более старым рабочим процессом Microsoft Information Protection (MIP).

Aspose.Slides for Android via Java предоставляет современные метаданные меток чувствительности через [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Этот метод возвращает [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/) , которую можно просмотреть и изменить перед сохранением презентации в формате PPTX.

{{% alert color="info" title="Примечание" %}}

Идентификаторы меток чувствительности и информация о политике определяются вашей конфигурацией Microsoft Purview. Проверьте доступность меток и требования политики в своей среде перед добавлением или миграцией метаданных. Значения [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) описывают типы маркировки, связанные с меткой; они сами по себе не добавляют видимый текст или фигуры на слайды.

{{% /alert %}}

## **Понимание свойств метки чувствительности**

Каждый [ISensitivityLabel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/) содержит следующие метаданные:

| Методы | Назначение |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getId--) и [ISensitivityLabel.setId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setId-java.lang.String-) | Получить или установить идентификатор метки чувствительности в политике Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getSiteId--) и [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setSiteId-java.util.UUID-) | Получить или установить сайт, связанный с политикой метки. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#isEnabled--) и [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setEnabled-boolean-) | Получить или установить, включена ли метка. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#isRemoved--) и [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) | Получить или установить, была ли метка удалена. Установите значение `true`, когда состояние удаления должно быть сохранено в метаданных. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getAssignmentMethodType--) и [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setAssignmentMethodType-int-) | Получить или установить, была ли метка применена автоматически или через решение пользователя. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) | Получить типы контентной маркировки, связанные с меткой. |

Класс [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) определяет способ назначения метки:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) представляет метку, применённую по умолчанию или автоматически.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) представляет метку, применённую через решение пользователя, включая вручную применённые, рекомендованные и обязательные метки.

Класс [SensitivityLabelContentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) определяет маркировку, связанную с меткой:

| Значение | Описание |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Метка была применена по умолчанию или автоматически. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Маркировка содержимого заголовка связана с меткой. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Маркировка содержимого нижнего колонтитула связана с меткой. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Маркировка содержимого водяного знака связана с меткой. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Защита шифрованием связана с меткой. |

Несколько типов маркировки могут быть ассоциированы с одной меткой.

## **Список существующих меток чувствительности**

Прочитайте современную коллекцию меток из [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) и перечислите её. Пример ниже выводит каждое свойство и маркировку, сохранённые для каждой метки:

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

Используйте [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) с идентификатором метки, идентификатором сайта, состоянием включения и методом назначения. После возврата нового [ISensitivityLabel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/) добавьте необходимые значения маркировки через список, возвращаемый [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--).

Пример ниже добавляет вручную выбранную метку, ассоциированную с маркировкой нижнего колонтитула и водяного знака, а затем сохраняет результат в формате PPTX:

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

Значения [ISensitivityLabel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/) читаются и записываются, за исключением списка, возвращаемого [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--), который изменяется с помощью операций над списком. После нахождения нужной метки вы можете обновить её идентификатор, идентификатор сайта, состояние включения, метод назначения, состояние удаления и типы маркировки содержимого. Сохраните презентацию, чтобы зафиксировать изменения.

Пример ниже обновляет состояние включения и метод назначения первой метки:

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

Чтобы сохранить факт удаления метки, найдите её и вызовите [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) с параметром `true`. Это сохраняет запись о метке, фиксируя её удалённое состояние. Если необходимо полностью удалить запись из современной коллекции, используйте [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-); для очистки всех записей примените [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#clear--).

Пример ниже помечает конкретную метку как удалённую и сохраняет обновлённую презентацию:

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

## **Чтение и миграция устаревших меток MIP**

Более старые рабочие процессы, основанные на MIP, могут хранить метаданные меток чувствительности в пользовательских свойствах документа вместо современной коллекции меток. Прочитайте эти метаданные с помощью [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--). Метод разбирает устаревшие пользовательские свойства и возвращает массив объектов [ISensitivityLabel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/).

Для миграции метаданных добавьте каждую полученную метку в современную [ISensitivityLabelCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/) через [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Поскольку попытка добавить дублирующий идентификатор метки вызывает исключение, пример проверяет целевую коллекцию перед копированием каждой метки. При необходимости можно добавить дополнительную проверку, подтверждающую, что каждая устаревшая метка всё ещё существует в текущей политике Purview.

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

Миграция копирует разобранные объекты меток в современную коллекцию. Она не требует очистки всех пользовательских свойств документа, поэтому метаданные, не связанные с метками, остаются нетронутыми. Используйте [IPresentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.saveformat/) для записи современных метаданных метки в файл PPTX.

## **FAQ**

**Создаёт ли добавление типа маркировки содержимого видимый заголовок, нижний колонтитул или водяной знак на слайдах?**

Нет. Значения, добавляемые через список, возвращаемый [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--), описывают маркировку, связанную с меткой чувствительности. Они не создают видимый текст или фигуры в презентации. При необходимости отобразить эти маркировки добавьте соответствующее содержимое слайда отдельно.

**В чём разница между пометкой метки как удаленной и её удалением из коллекции?**

Вызов [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) с параметром `true` сохраняет запись о метке и фиксирует её состояние удаления. Вызов [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-) удаляет запись из современной коллекции. Выберите операцию, соответствующую требованиям вашей организации по хранению метаданных.

**Можно ли в одной презентации одновременно использовать устаревшие метаданные MIP и современные метки чувствительности?**

Да. Устаревшие метки могут оставаться в пользовательских свойствах документа, тогда как современные метки доступны через [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Используйте [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--) для чтения устаревших метаданных и мигрируйте только те метки, которых ещё нет в современной коллекции.

**Что происходит, если метка с тем же идентификатором добавляется более одного раза?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) генерирует исключение, если в коллекции уже существует метка с таким же идентификатором. Проверьте существующие значения, возвращаемые [ISensitivityLabel.getId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.isensitivitylabel/#getId--), перед добавлением или миграцией меток.

**Какой формат вывода следует использовать, чтобы сохранить обновленные метки чувствительности?**

Сохраните презентацию в формате PPTX, вызвав [IPresentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides.saveformat/), как показано в примерах выше.