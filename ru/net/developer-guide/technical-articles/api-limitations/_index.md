---
title: Ограничения API
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
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте о ограничениях Aspose.Slides for .NET: при экспорте устанавливаются фиксированные метаданные Application/Producer в PPT, PPTX, ODP и PDF — это поможет планировать интеграции без сюрпризов."
---

## **Приложение и Производитель**

При создании или экспорте презентаций с помощью Aspose.Slides for .NET в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** указывает программу, которая создала или последней сохранила **PPTX**‑презентацию. В Aspose.Slides for .NET это значение фиксировано и отображает поставщика библиотеки, а не название вашего приложения, даже если вы задаете [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) .

**Producer** указывает движок рендеринга, который сгенерировал окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for .NET оба эти поля фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Вы не можете переопределить эти поля через API для указанных выше форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for .NET". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for .NET x.x.x". Такое поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, присвоенных [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) .