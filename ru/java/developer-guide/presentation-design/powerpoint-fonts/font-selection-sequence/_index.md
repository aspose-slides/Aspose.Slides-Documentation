---
title: Последовательность выбора шрифтов в Java
linktitle: Последовательность выбора шрифтов в Java
type: docs
weight: 80
url: /ru/java/font-selection-sequence/
keywords:
- шрифт
- выбор шрифта
- подмена шрифта
- замена шрифта
- презентация PowerPoint
- Java
- Aspose.Slides для Java
description: Последовательность выбора шрифтов PowerPoint в Java
---

## Выбор шрифта

Определенные правила применяются к шрифтам в презентации, когда презентация загружается, отображается или конвертируется в другой формат. Например, при попытке конвертировать презентацию (ее слайды) в изображения, шрифты презентации проверяются, чтобы подтвердить, что выбранные шрифты доступны в операционной системе. Если шрифты подтверждаются как отсутствующие, они заменяются — смотрите [**Замена шрифтов**](https://docs.aspose.com/slides/java/font-replacement/) и [**Подмена шрифтов**](https://docs.aspose.com/slides/java/font-substitution/).

Это процесс, который Aspose.Slides следует при работе со шрифтами:

1. Aspose.Slides ищет шрифты в операционной системе, чтобы найти шрифт, соответствующий выбранному шрифту презентации. 
2. Если выбранный шрифт найден, Aspose.Slides использует его. В противном случае Aspose.Slides использует заменяющий шрифт, который максимально близок к тому, что использовал бы PowerPoint.
3. Если правила замены шрифтов были установлены через [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/), они применяются.

Aspose.Slides позволяет вам добавлять шрифты в среду выполнения приложения и затем использовать эти шрифты. Смотрите [**Пользовательские шрифты**](https://docs.aspose.com/slides/java/custom-font/).

Когда дополнительные шрифты включены в презентацию, они называются [**Встроенные шрифты**](https://docs.aspose.com/slides/java/embedded-font/).

Aspose.Slides позволяет вам добавлять шрифты, которые применяются *только* к выходным документам. Например, если презентация, которую вы собираетесь конвертировать в PDF, содержит шрифты, отсутствующие в вашей системе, и встроенные шрифты, вы можете добавить или загрузить необходимые шрифты как **внешние шрифты**.

{{% alert title="Примечание" color="primary" %}} 
Мы не распространяем шрифты, ни платные, ни бесплатные. Наш API позволяет вам загружать внешние шрифты и встраивать их в документы, но вы делаете это на свой риск и ответственность.
{{% /alert %}}