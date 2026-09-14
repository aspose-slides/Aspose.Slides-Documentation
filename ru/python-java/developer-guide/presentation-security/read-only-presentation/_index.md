---
title: Сохранение презентаций в режиме только для чтения с помощью Python
linktitle: Презентация только для чтения
type: docs
weight: 30
url: /ru/python-java/read-only-presentation/
keywords:
- только для чтения
- защитить презентацию
- предотвратить редактирование
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Загружайте и сохраняйте файлы PowerPoint (PPT, PPTX) в режиме только для чтения с помощью Aspose.Slides for Python via Java, обеспечивая точные предварительные просмотры слайдов без изменения ваших презентаций."
---
## **Введение**

В PowerPoint 2019 Microsoft представила параметр **Always Open Read-Only** как одну из опций, которые пользователи могут использовать для защиты своих презентаций. Вы можете захотеть использовать эту настройку только для чтения, чтобы защитить презентацию, когда:

- Вы хотите предотвратить случайные изменения и сохранить содержимое презентации в безопасности. 
- Вы хотите сообщить людям, что предоставленная вами презентация является окончательной версией. 

После выбора опции **Always Open Read-Only** для презентации, при открытии её пользователи видят рекомендацию **Read-Only** и могут увидеть сообщение в следующем виде: *Чтобы предотвратить случайные изменения, автор установил открытие этого файла только для чтения.*

Рекомендация **Read-Only** — простое, но эффективное средство удержания от редактирования, так как пользователю приходится выполнять действие, чтобы убрать её, прежде чем он сможет изменить презентацию. Если вы не хотите, чтобы пользователи вносили изменения в презентацию, и хотите вежливо об этом сообщить, рекомендация **Read-Only** может быть хорошим вариантом.

> Если презентация с защитой **Read-Only** открывается в более старой версии Microsoft PowerPoint, которая не поддерживает недавно введённую функцию, рекомендация **Read-Only** игнорируется (презентация открывается как обычно).

## **Применение режима только для чтения**

Aspose.Slides for Python via Java позволяет установить презентацию в режим **Read-Only**, что означает, что пользователи (после открытия презентации) видят рекомендацию **Read-Only**. Этот пример кода показывает, как установить презентацию в режим **Read-Only** на Python с использованием Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Рекомендация **Read-Only** предназначена просто для того, чтобы отговорить от редактирования или предотвратить случайные изменения PowerPoint‑презентации. Если мотивированный человек, знающий, что делает, решит отредактировать вашу презентацию, он легко снимет настройку только для чтения. Если вам действительно необходимо предотвратить несанкционированное редактирование, лучше использовать [более строгие защиты, включающие шифрование и пароли](/slides/ru/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Чем «Read-Only recommended» отличается от полной защиты паролем?**

«Read-Only recommended» только отображает предложение открыть файл в режиме только для чтения и легко обходится. [Защита паролем](/slides/ru/python-java/password-protected-presentation/) действительно ограничивает открытие или редактирование и подходит, когда нужны реальные меры безопасности.

**Можно ли сочетать «Read-Only recommended» с водяными знаками для дополнительного сдерживания редактирования?**

Да. Рекомендацию можно комбинировать с [водяными знаками](/slides/ru/python-java/watermark/) как визуальным средством сдерживания; они работают независимо и хорошо сочетаются.

**Может ли макрос или внешнее средство всё равно изменить файл, когда рекомендация включена?**

Да. Рекомендация не блокирует программные изменения. Чтобы предотвратить автоматическое редактирование, используйте [пароли и шифрование](/slides/ru/python-java/password-protected-presentation/).

**Как «Read-Only recommended» соотносится с методами [isEncrypted](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isEncrypted) и [isWriteProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

Это разные сигналы. «Read-Only recommended» — мягкое, необязательное приглашение; [isWriteProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isWriteProtected) и [isEncrypted](https://reference.aspose.com/slides/ru/python-java/aspose.slides/protectionmanager/#isEncrypted) указывают на реальные ограничения записи или чтения, зависящие от паролей или шифрования.