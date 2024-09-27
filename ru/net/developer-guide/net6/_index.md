---
title: Поддержка .NET6
type: docs
weight: 235
url: /ru/net/net6/
keywords: ".NET6 Cloud AWS Azure"
description: "Поддержка .NET6"
---

## Введение

Начиная с [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), была реализована поддержка .NET6. Особенность этой поддержки заключается в том, что .NET6 больше не поддерживает System.Drawing.Common для Linux ([прерывающее изменение](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) и Slides реализует эту графическую подсистему самостоятельно как компонент C++.

Aspose.Slides для .NET теперь работает без зависимостей от GDI/libgdiplus на:
* Windows
* Linux

Поддержка _MacOS_ находится в процессе.

## Использование Slides для .NET6 на AWS и Azure

.NET6 является предпочтительной версией для Aspose.Slides, используемого в облаке (AWS, Azure или других облачных решениях).

Ранее, когда Aspose.Slides использовался на Linux-хосте, приходилось устанавливать дополнительные зависимости (libgdiplus), и это часто было неудобно или нецелесообразно (например, при использовании [AWS Lambda](https://aws.amazon.com/lambda)). С Slides для .NET6 эти зависимости больше не нужны, поэтому развертывание стало намного проще.

Еще одним моментом являются проблемы, которые возникали, когда Aspose.Slides использовался на облачном решении с Windows-хостом. Например, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) имеют ограничения для процесса, что приводит к проблемам во время операции экспорта PDF (см. [это](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Использование Aspose.Slides для .NET6 решает эту проблему.

## Использование пакета System.Drawing.Common и классов Slides для .NET6 (ошибка CS0433: Тип существует как в Slides, так и в System.Drawing.Common)

Иногда необходимо использовать зависимости как System.Drawing, так и Slides для .NET6 в проекте (например, когда проект .NET6 зависит от других пакетов, которые, в свою очередь, зависят от System.Drawing). Это может привести к ошибкам компиляции, таким как:

* CS0433: Тип 'Image' существует как в 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56', так и в 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: Тип 'Graphics' существует как в 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56', так и в 'System.Drawing.Common, Version=6.0.0.0'

В этом случае можно использовать [внешний псевдоним](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) для Slides:
1) Выберите сборку Aspose.Slides из зависимостей проекта и затем нажмите **Свойства**.
  ![Свойства пакета Aspose Slides](package_properties.png)
2) Установите псевдоним (например, "Slides").
  ![Псевдоним Aspose Slides](set_alias.png)

Теперь типы из System.Drawing.Common будут использоваться по умолчанию. Внешний псевдоним сборки должен быть указан там, где нужны типы Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Полный пример:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```