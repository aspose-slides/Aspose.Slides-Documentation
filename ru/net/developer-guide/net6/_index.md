---
title: "Поддержка .NET 6"
type: docs
weight: 235
url: /ru/net/net6/
keywords:
- "поддержка .NET 6"
- "облачное решение"
- "AWS Lambda"
- "Azure Functions"
- "System.Drawing.Common"
- "GDI"
- "libgdiplus"
- "CS0433"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Настройте Aspose.Slides для .NET 6, чтобы создавать, редактировать и конвертировать презентации PowerPoint PPT, PPTX и ODP в современных кросс‑платформенных C# приложениях."
---

## **Введение**

Начиная с [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), была реализована поддержка .NET6. Особенность этой поддержки заключается в том, что .NET6 больше не поддерживает System.Drawing.Common для Linux ([изменение, ломающее совместимость](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), и Slides реализует эту графическую подсистему самостоятельно как компонент на C++.

Aspose.Slides для .NET теперь работает без зависимостей от GDI/libgdiplus на:
* Windows
* Linux

Поддержка _MacOS_ находится в разработке.

## **Использование Slides для .NET 6 в AWS и Azure**

.NET6 является предпочтительной версией для Aspose.Slides, используемой в облаке (AWS, Azure или другие облачные решения).

Ранее, когда Aspose.Slides использовался на Linux‑хосте, требовалась установка дополнительных зависимостей (libgdiplus), что часто было неудобно или непрактично (например, при использовании [AWS Lambda](https://aws.amazon.com/lambda)). С Slides для .NET6 эти зависимости больше не нужны, поэтому развертывание значительно упрощается.

Еще один момент — проблемы, возникавшие при использовании Aspose.Slides в облачном решении с Windows‑хостом. Например, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) имеют ограничения для процесса и приводят к ошибкам при экспорте PDF (см. [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Использование Aspose.Slides для .NET6 решает эту проблему.

## **Использование пакета System.Drawing.Common и классов Slides для .NET 6 (Ошибка CS0433: тип существует и в Slides, и в System.Drawing.Common)**

Иногда в проекте необходимо одновременно использовать зависимости System.Drawing и Slides для .NET6 (например, когда проект .NET6 зависит от других пакетов, которые в свою очередь зависят от System.Drawing). Это может привести к конфликтным ошибкам, например:

* CS0433: Тип 'Image' существует и в 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56', и в 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: Тип 'Graphics' существует и в 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56', и в 'System.Drawing.Common, Version=6.0.0.0'

В этом случае можно использовать [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) для Aspose.Slides (версии ниже 24.8):
1) Выберите сборку Aspose.Slides в зависимостях проекта и нажмите **Properties**.
  ![Aspose Slides package properties](package_properties.png)
2) Установите псевдоним (например, "Slides").
  ![Aspose Slides alias](set_alias.png)

Теперь типы из System.Drawing.Common будут использоваться по умолчанию. Внешний псевдоним сборки следует указывать там, где требуются типы Aspose.Slides.
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


Начиная с версии 24.8, устаревший публичный API с зависимостями от System.Drawing был удалён. Что касается приведённого выше примера кода, изображение слайда можно получить следующим образом.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

Подробное описание нового API доступно в разделе [Modern API](/net/modern-api/).