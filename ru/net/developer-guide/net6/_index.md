---
title: Поддержка .NET 6
type: docs
weight: 235
url: /ru/net/net6/
keywords:
- поддержка .NET 6
- облачное решение
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

## **Введение**

Начиная с [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), реализована поддержка .NET6. Особенность этой поддержки — .NET6 больше не поддерживает System.Drawing.Common для Linux ([изменение, нарушающее совместимость](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), и Slides реализует эту графическую подсистему самостоятельно как C++‑компонент.

Aspose.Slides для .NET теперь работает без зависимости от GDI/libgdiplus на:
* Windows
* Linux

*MacOS* поддержка находится в стадии разработки.

## **Использование Slides для .NET 6 в AWS и Azure**

.NET6 — предпочтительная версия Aspose.Slides для облачных решений (AWS, Azure или других облаков).

Раньше при использовании Aspose.Slides на Linux‑хосте требовалось устанавливать дополнительные зависимости (libgdiplus), что часто было неудобно или непрактично (например, при работе с [AWS Lambda](https://aws.amazon.com/lambda)). С Slides для .NET6 эти зависимости больше не нужны, поэтому развертывание значительно упрощается.

Еще один аспект — проблемы, возникавшие при использовании Aspose.Slides в облачных решениях с Windows‑хостом. Например, у [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) есть ограничения для процесса, что приводит к сбоям при экспорте PDF (см. [это](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Использование Aspose.Slides для .NET6 решает эту проблему.

## **Использование пакета System.Drawing.Common и классов Slides для .NET 6 (CS0433: Ошибка «Тип существует как в Slides, так и в System.Drawing.Common»)**

Иногда в проекте необходимо одновременно использовать зависимости System.Drawing и Slides для .NET6 (например, когда проект .NET6 зависит от других пакетов, которые в свою очередь зависят от System.Drawing). Это может вызвать такие ошибки:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

В этом случае можно использовать [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) для Aspose.Slides (версии ниже 24.8):
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
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


Начиная с версии 24.8, устаревший публичный API с зависимостями от System.Drawing удалён. Что касается приведённого выше примера кода, получить изображение слайда можно следующим образом.  
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

Новый API более подробно описан в разделе [Modern API](/slides/ru/net/modern-api/).