---
title: Конвертация ODP в PPTX на C#
linktitle: Конвертация ODP в PPTX
type: docs
weight: 10
url: /ru/net/convert-odp-to-pptx/
keywords: "Конвертация OpenOffice Presentation, ODP, ODP в PPTX, C#, Csharp, .NET"
description: "Конвертация OpenOffice ODP в PowerPoint Presentation PPTX на C# или .NET"
---

## Обзор

В этой статье разобраны следующие темы.

- [C# Конвертация ODP в PPTX](#csharp-odp-to-pptx)
- [C# Конвертация ODP в PowerPoint](#csharp-odp-to-powerpoint)

## Конвертация ODP в PPTX на C#

Aspose.Slides для .NET предлагает класс Presentation, который представляет файл презентации. Класс [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. Следующий пример показывает, как конвертировать ODP-презентацию в PPTX-презентацию.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Шаги: Конвертация ODP в PPTX на C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Шаги: Конвертация ODP в PowerPoint на C#</strong></a>

```c#
// Открыть файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Сохранение ODP-презентации в формате PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Пример в реальном времени**
Вы можете посетить веб-приложение [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/conversion/), которое разработано с использованием **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.