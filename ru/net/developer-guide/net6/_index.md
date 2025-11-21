---
title: .NET 6 поддержка
type: docs
weight: 235
url: /ru/net/net6/
keywords:
- .NET 6 поддержка
- Облачное решение
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Настройте Aspose.Slides для .NET 6, чтобы создавать, редактировать и конвертировать презентации PowerPoint PPT, PPTX и ODP в современных кроссплатформенных C# приложениях."
---

## Введение

Начиная с [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), поддержка .NET6 была реализована. Особенность этой поддержки заключается в том, что .NET6 больше не поддерживает System.Drawing.Common для Linux ([изменение, нарушающее совместимость](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), и Slides реализует эту графическую подсистему самостоятельно как компонент на C++.

Aspose.Slides для .NET теперь работает без зависимостей от GDI/libgdiplus на:
* Windows
* Linux

_MacOS_ поддержка находится в разработке.

## Использование Slides для .NET6 в AWS и Azure

.NET6 является предпочтительной версией Aspose.Slides для использования в облаке (AWS, Azure или других облачных решениях).

Ранее, когда Aspose.Slides использовался на хосте Linux, требовалось устанавливать дополнительные зависимости (libgdiplus), что часто было неудобно или непрактично (например, при использовании [AWS Lambda](https://aws.amazon.com/lambda)). С Slides для .NET6 эти зависимости больше не нужны, поэтому развертывание значительно упрощается.

Другой момент — проблемы, которые возникали при использовании Aspose.Slides в облачном решении с хостом Windows. Например, у [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) есть ограничения для процесса, что приводило к проблемам при операции экспорта PDF (см. [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Использование Aspose.Slides для .NET6 решает эту проблему.

## Использование пакета System.Drawing.Common и классов Slides для .NET6 (ошибка CS0433: тип существует как в Slides, так и в System.Drawing.Common)

Иногда в проекте необходимо использовать как зависимости System.Drawing, так и Slides для .NET6 (например, когда проект .NET6 зависит от других пакетов, которые в свою очередь зависят от System.Drawing). Это может вызвать такие ошибки:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

В этом случае можно использовать [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) для Aspose.Slides (версии менее 24.8):
1) Выберите сборку Aspose.Slides в зависимостях проекта и нажмите **Properties**.
  ![Aspose Slides package properties](package_properties.png)
2) Установите псевдоним (например, "Slides").
  ![Aspose Slides alias](set_alias.png)

Теперь типы из System.Drawing.Common будут использоваться по умолчанию. Псевдоним внешней сборки следует указывать там, где требуются типы Aspose.Slides.
```c#
extern alias Slides;
using Slides::Aspose.Slides;
```


Полный пример:
```c#
extern alias Slides;
using Slides::Aspense.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


Начиная с версии 24.8, устаревший публичный API с зависимостями от System.Drawing был удалён. Что касается приведённого выше примера кода, изображение слайда можно получить следующим образом.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

Новый API описан более подробно в разделе [Modern API](/net/modern-api/).