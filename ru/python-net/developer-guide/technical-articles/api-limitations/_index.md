---
title: Ограничения API
type: docs
weight: 210
url: /ru/python-net/api-limitations/
keywords:
- ограничения API
- формат экспорта
- приложение
- производитель
- свойства документа
- метаданные
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте об ограничениях Aspose.Slides for Python: при экспорте устанавливаются фиксированные метаданные Application/Producer в PPT, PPTX, ODP и PDF — это поможет планировать интеграцию без неожиданностей."
---

## **Приложение и Производитель**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for Python via .NET, в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** определяет программу, создавшую или последнюю сохранявшую **PPTX**‑презентацию. В Aspose.Slides for Python via .NET это значение фиксировано и отображает поставщика библиотеки, а не имя вашего приложения, даже если вы задаёте [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** определяет движок рендеринга, который генерирует окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for Python via .NET оба этих поля фиксированы и отражают библиотеку и её версию.

**What’s restricted**

Вы не можете переопределить эти поля через API для указанных выше форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for Python via .NET". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for Python via .NET x.x.x". Такое поведение заложено в дизайне и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, присвоенных [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).