---
title: Ограничения метаданных вывода
type: docs
weight: 320
url: /ru/net/api-limitations/
keywords:
- Ограничения API
- формат экспорта
- приложение
- производитель
- свойства документа
- метаданные
- генератор
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET записывает фиксированные метаданные application, creator и producer в сохраняемые файлы PPTX, PDF и ODP, независимо от того, какое имя приложения вы задаете."
---
## **Обзор**

При создании или экспорте презентаций с помощью Aspose.Slides в выходной файл записываются определённые технические метаданные. Эта статья объясняет ограничения, связанные с полями метаданных `Application`, `Creator`, `Producer` и generator в файлах PPTX, PDF и ODP.

## **Application и Producer**

При создании или экспорте презентаций с помощью Aspose.Slides for .NET в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** идентифицирует программу, которая создала или последняя сохранила **PPTX**‑презентацию. В Aspose.Slides for .NET это значение фиксировано и отображает название библиотеки, а не имя вашего приложения, даже если вы задаёте [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** идентифицирует движок рендеринга, который сгенерировал конечный файл при экспорте. В экспортах **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for .NET оба этих поля фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Вы не можете переопределить эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как «Aspose.Slides for .NET». Для **PDF** свойства Creator и Producer записываются как «Aspose.Slides for .NET», за которым следует версия библиотеки. Для **ODP** поле generator записывается как «Aspose.Slides for .NET», за которым также следует версия библиотеки. Такое поведение заложено в дизайн и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, заданных в [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

Это ограничение не действует на файлы **PPT**: в файле PPT имя приложения, установленное в [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/), сохраняется.