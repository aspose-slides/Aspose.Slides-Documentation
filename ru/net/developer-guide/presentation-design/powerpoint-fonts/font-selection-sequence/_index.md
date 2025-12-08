---
title: Последовательность выбора шрифта в C#
linktitle: Последовательность выбора шрифта в C#
type: docs
weight: 80
url: /ru/net/font-selection-sequence/
keywords:
- шрифт
- выбор шрифта
- подстановка шрифта
- замена шрифта
- презентация PowerPoint
- C#
- Csharp
- Aspose.Slides for .NET
description: Последовательность выбора шрифтов PowerPoint в C#
---

## **Выбор шрифтов**

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced — see [**Замена шрифтов**](https://docs.aspose.com/slides/net/font-replacement/) and [**Подстановка шрифтов**](https://docs.aspose.com/slides/net/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides ищет шрифты в операционной системе, чтобы найти шрифт, соответствующий выбранному в презентации. 
2. Если найден выбранный шрифт, Aspose.Slides использует его. В противном случае Aspose.Slides использует заменяющий шрифт, максимально близкий к тому, который использовал бы PowerPoint.
3. Если правила замены шрифтов были заданы через [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), они применяются. 

Aspose.Slides позволяет добавить шрифты в среду выполнения приложения и затем использовать их. См. [**Пользовательские шрифты**](https://docs.aspose.com/slides/net/custom-font/). 

Когда дополнительные шрифты размещаются внутри презентации, они называются [**Встроенные шрифты**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides позволяет добавить шрифты, которые применяются *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from your system and embedded fonts, you can add or load the needed fonts as **внешние шрифты**. 

{{% alert title="Note" color="primary" %}} 
Мы не распространяем шрифты, ни платные, ни бесплатные. Наш API позволяет загружать внешние шрифты и внедрять их в документы, но вы делаете это на свой суд и ответственность.
{{% /alert %}}

## **Вопросы и ответы**

**How can I determine which fonts are actually used in a presentation before conversion?**

Aspose.Slides позволяет проверить используемые шрифты через [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), чтобы вы могли решить, [embed](/slides/ru/net/embedded-font/), [replace](/slides/ru/net/font-replacement/) или добавить [external sources](/slides/ru/net/custom-font/). Это помогает предотвратить нежелательные подстановки при рендеринге и экспорте.

**Can I add extra font directories without installing them on the operating system?**

Yes. Вы можете зарегистрировать [external font sources](/slides/ru/net/custom-font/) такие как папки или потоки в памяти для рендеринга и экспорта. Это устраняет зависимость от шрифтов хост‑системы и делает макет предсказуемым.

**How do I prevent a silent fallback to an unsuitable font when a glyph is missing?**

Define explicit [font replacement](/slides/ru/net/font-replacement/) and font [fallBack rules](/slides/ru/net/fallback-font/) in advance. Анализируя используемые шрифты и устанавливая управляемый приоритет для замен, вы обеспечиваете согласованную типографику и избегаете неожиданных результатов.