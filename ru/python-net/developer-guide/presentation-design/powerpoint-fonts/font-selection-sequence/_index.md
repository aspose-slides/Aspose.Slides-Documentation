---
title: Последовательность выбора шрифтов в презентациях на Python
linktitle: Выбор шрифтов
type: docs
weight: 80
url: /ru/python-net/font-selection-sequence/
keywords:
- выбор шрифта
- замена шрифта
- подмена шрифта
- правило замены
- доступный шрифт
- отсутствующий шрифт
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: Узнайте, как Aspose.Slides for Python via .NET выбирает шрифты, обеспечивая четкое и единообразное отображение файлов PPT, PPTX и ODP — улучшите свои слайды прямо сейчас.
---

## Выбор шрифта

Некоторые правила применяются к шрифтам в презентации, когда презентация загружается, отображается или конвертируется в другой формат. Например, когда вы пытаетесь конвертировать презентацию (ее слайды) в изображения, шрифты презентации проверяются, чтобы убедиться, что выбранные шрифты доступны в операционной системе. Если шрифты подтверждены как отсутствующие, они заменяются — см. [**Замена шрифта**](https://docs.aspose.com/slides/python-net/font-replacement/) и [**Подстановка шрифта**](https://docs.aspose.com/slides/python-net/font-substitution/).

Это процесс, который Aspose.Slides следует при работе с шрифтами:

1. Aspose.Slides ищет шрифты в операционной системе, чтобы найти шрифт, соответствующий выбранному шрифту презентации. 
2. Если выбранный шрифт найден, Aspose.Slides использует его. В противном случае Aspose.Slides использует шрифт замены, который максимально близок к тому, что использовал бы PowerPoint.
3. Если правила замены шрифтов были установлены через [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), они применяются. 

Aspose.Slides позволяет добавлять шрифты в среду выполнения приложения и затем использовать эти шрифты. См. [**Пользовательские шрифты**](https://docs.aspose.com/slides/python-net/custom-font/). 

Когда дополнительные шрифты размещаются внутри презентации, они называются [**Встраиваемыми шрифтами**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides позволяет добавлять шрифты, которые применяются *только* к выходным документам. Например, если презентация, которую вы хотите конвертировать в PDF, содержит шрифты, отсутствующие в вашей системе, и встраиваемые шрифты, вы можете добавить или загрузить необходимые шрифты как **внешние шрифты**. 

{{% alert title="Примечание" color="primary" %}} 
Мы не распространяем никакие шрифты, ни платные, ни бесплатные. Наш API позволяет загружать внешние шрифты и встраивать их в документы, но вы делаете это с шрифтами на свое усмотрение и ответственность.
{{% /alert %}}