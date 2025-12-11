---
title: Последовательность выбора шрифтов в Aspose.Slides для С++
linktitle: Выбор шрифтов
type: docs
weight: 80
url: /ru/cpp/font-selection-sequence/
keywords:
- выбор шрифтов
- подстановка шрифтов
- замена шрифтов
- правило подстановки
- доступный шрифт
- отсутствующий шрифт
- PowerPoint
- OpenDocument
- презентация
- С++
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для С++ выбирает шрифты, обеспечивая чёткую и последовательную презентацию файлов PPT, PPTX и ODP — улучшите свои слайды сейчас."
---

## **Выбор шрифтов**

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced — see [**Замена шрифтов**](https://docs.aspose.com/slides/cpp/font-replacement/) and [**Подстановка шрифтов**](https://docs.aspose.com/slides/cpp/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides ищет шрифты в операционной системе, чтобы найти шрифт, соответствующий выбранному в презентации шрифту. 
2. Если найден выбранный шрифт, Aspose.Slides использует его. В противном случае Aspose.Slides использует заменяющий шрифт, максимально приближённый к тому, который использует PowerPoint.
3. Если правила замены шрифтов заданы через [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/), они применяются. 

Aspose.Slides позволяет добавить шрифты во время выполнения приложения и затем использовать их. Смотрите [**Пользовательские шрифты**](https://docs.aspose.com/slides/cpp/custom-font/). 

When additional fonts are placed within a presentation, they are called [**Встроенные шрифты**](https://docs.aspose.com/slides/cpp/embedded-font/).

Aspose.Slides позволяет добавить шрифты, которые применяются *только* к выходным документам. Например, если презентация, которую вы собираетесь конвертировать в PDF, содержит шрифты, отсутствующие в вашей системе и встроенные шрифты, вы можете добавить или загрузить необходимые шрифты как **внешние шрифты**. 

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **FAQ**

**Как определить, какие шрифты фактически используются в презентации перед конвертией?**

Aspose.Slides позволяет проверять используемые шрифты через [font manager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/), чтобы вы могли решить, [embed](/slides/ru/cpp/embedded-font/), [replace](/slides/ru/cpp/font-replacement/), или добавить [external sources](/slides/ru/cpp/custom-font/). Это помогает предотвратить нежелательные подстановки при рендеринге и экспорте.

**Могу ли я добавить дополнительные каталоги шрифтов без их установки в операционную систему?**

Да. Вы можете зарегистрировать [external font sources](/slides/ru/cpp/custom-font/) такие как папки или потоки в памяти для рендеринга и экспорта. Это устраняет зависимость от шрифтов хостовой системы и делает макет предсказуемым.

**Как предотвратить тихий переход к неподходящему шрифту, когда отсутствует глиф?**

Определите явные [font replacement](/slides/ru/cpp/font-replacement/) и правила [fallBack](/slides/ru/cpp/fallback-font/) шрифтов заранее. Анализируя используемые шрифты и задавая контролируемый приоритет замен, вы обеспечите согласованную типографику и избежите неожиданных результатов.