---
title: Сохранить презентации в режиме только для чтения с помощью Python
linktitle: Презентация только для чтения
type: docs
weight: 30
url: /ru/python-net/read-only-presentation/
keywords:
- только для чтения
- защита презентации
- предотвращение редактирования
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Загружайте и сохраняйте файлы PowerPoint (PPT, PPTX) в режиме только для чтения с помощью Aspose.Slides for Python via .NET, получая точные предварительные просмотры слайдов без изменения ваших презентаций."
---

## **Применить режим только для чтения**

В PowerPoint 2019 компания Microsoft внедрила параметр **Always Open Read-Only**, как одну из возможностей, которые пользователи могут использовать для защиты своих презентаций. Вы можете захотеть использовать этот параметр только для чтения, чтобы защитить презентацию, когда

- Вы хотите предотвратить случайные изменения и сохранить содержимое вашей презентации в безопасности. 
- Вы хотите предупредить людей, что предоставленная вами презентация является окончательной версией. 

После того как вы выберете параметр **Always Open Read-Only** для презентации, при открытии презентации пользователи видят рекомендацию **Read-Only** и могут увидеть сообщение в следующем виде: *To prevent accidental changes, the author has set this file to open as read-only.*

Рекомендация **Read-Only** — это простой, но эффективный способ отговорить от редактирования, потому что пользователям необходимо выполнить действие, чтобы удалить рекомендацию, прежде чем им будет разрешено редактировать презентацию. Если вы не хотите, чтобы пользователи вносили изменения в презентацию, и хотите вежливо об этом сообщить, то рекомендация **Read-Only** может быть хорошим вариантом.

> Если презентация с защитой **Read-Only** открывается в более старой версии Microsoft PowerPoint, которая не поддерживает недавно введённую функцию, рекомендация **Read-Only** игнорируется (презентация открывается обычным способом).

Aspose.Slides for Python via .NET позволяет установить презентацию в режим **Read-Only**, что означает, что пользователи (после открытия презентации) видят рекомендацию **Read-Only**. Этот пример кода показывает, как установить презентацию в режим **Read-Only** на Python с использованием Aspose.Slides:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**Примечание**: Рекомендация **Read-Only** предназначена просто для того, чтобы отговорить от редактирования или предотвратить случайные изменения PowerPoint‑презентации. Если мотивированный пользователь, который знает, что делает, решит отредактировать вашу презентацию, он легко удалит настройку **Read-Only**. Если вам действительно нужно предотвратить неавторизованное редактирование, лучше использовать [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Чем «Read-Only recommended» отличается от полной защиты паролем?**

«Read-Only recommended» только отображает предложение открыть файл в режиме только для чтения и легко обходится. [Password protection](/slides/ru/python-net/password-protected-presentation/) действительно ограничивает открытие или редактирование и подходит, когда нужны реальные меры безопасности.

**Можно ли сочетать «Read-Only recommended» с водяными знаками для усиления отвращения к правке?**

Да. Рекомендацию можно сочетать с [watermarks](/slides/ru/python-net/watermark/) как визуальным средством сдерживания; они независимы и хорошо работают вместе.

**Может ли макрос или внешнее средство всё равно изменить файл, когда рекомендация включена?**

Да. Рекомендация не блокирует программные изменения. Чтобы предотвратить автоматические правки, используйте [passwords and encryption](/slides/ru/python-net/password-protected-presentation/).

**Как «Read-Only recommended» соотносится с флагами «is_encrypted» и «is_write_protected»?**

Это разные сигналы. «Read-Only recommended» — мягкое, необязательное уведомление; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) и [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) указывают на реальные ограничения записи или чтения, зависящие от пароля или шифрования.