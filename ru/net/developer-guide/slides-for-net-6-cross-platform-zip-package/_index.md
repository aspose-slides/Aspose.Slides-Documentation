---
title: Aspose.Slides для .NET 6 Cross-Platform (ZIP-пакет)
type: docs
weight: 237
url: /ru/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
  - кроссплатформенный
  - .NET 6
  - GLIBC
  - csproj
  - путь назначения
  - зависимая библиотека
  - Aspose.Slides.dll
  - System.Drawing.Common
  - конфликт имён
  - внешний псевдоним
  - CS0433
  - PowerPoint
  - OpenDocument
  - презентация
  - .NET
  - C#
  - Aspose.Slides
description: "Используйте Aspose.Slides для .NET 6 для создания кроссплатформенных C# приложений на Windows, Linux и macOS, которые создают, редактируют и конвертируют файлы PowerPoint PPT, PPTX и ODP."
---
## **Обзор**

В этой статье объясняется, как использовать Aspose.Slides для .NET 6 Cross-Platform из ZIP‑пакета. Описывается, как загрузить пакет, распаковать файлы из папки `net6.0/crossplatform`, добавить ссылку на `Aspose.Slides.dll` и настроить файл проекта так, чтобы необходимые зависимые библиотеки копировались в каталог вывода приложения.

Статья также описывает содержимое кроссплатформенного пакета, включая основную сборку Aspose.Slides .NET и платформенно‑специфичные библиотеки подсистемы графики для Windows, Linux и macOS.

{{% alert title="Note" color="info" %}}
Aspose.Slides for .NET 6 Cross-Platform также доступен в [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Использование кроссплатформенного Aspose.Slides из ZIP‑пакета**

1. Скачайте ZIP‑пакет последней версии Aspose.Slides со страницы [Release Page](https://releases.aspose.com/slides/ru/net/).

2. Распакуйте файлы из *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* и поместите их в папку, которая будет использоваться для зависимостей в вашем проекте.

3. Добавьте ссылку на Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   В нашем примере (ниже) библиотеки находятся в папке проекта по следующему пути: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Разместите оставшиеся файлы (от которых зависит Aspose.Slides) в каталоге вывода, добавив инструкции в файл проекта csproj следующим образом:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Обратите внимание на `TargetPath`.

   По умолчанию `<CopyToOutputDirectory>` копирует файлы, сохраняя их относительный путь, но нам требуется, чтобы зависимые библиотеки помещались в ту же папку, где генерируется вывод (расположение Aspose.Slides.dll).

## **Примечания**

### **Собственная подсистема графики**

Aspose.Slides кроссплатформенный представляет собой набор библиотек:

| Aspose.Slides.dll                                          | Основная сборка .NET, отвечающая за всю логику Aspose.Slides |
| ---------------------------------------------------------- | ----------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Зависимость: реализация подсистемы графики для Windows x64 |
| aspose.slides.drawing.capi_vc14x86.dll                     | Зависимость: реализация подсистемы графики для Windows x64 |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Зависимость: реализация подсистемы графики для Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Зависимость: реализация подсистемы графики для macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Зависимость: реализация подсистемы графики для macOS ARM64 (AArch64) |

Aspose.Slides.dll использует библиотеку, требуемую системой, на которой он запускается. Библиотеки обычно находятся в том же месте, что и Aspose.Slides.dll в любой файловой системе.

### **Структура ZIP‑пакета**

ZIP‑пакет содержит следующую структуру папок:

Aspose.Slides
├─── net6.0
│  ├─── crossplatform
│  └─── default
├─── net20
├─── net462
└─── netstandard2.0

* Каждый каталог содержит сборки для соответствующей версии .NET. Для net6.0 существует две версии: default и crossplatform. Последняя содержит кроссплатформенный Aspose.Slides.dll и все его зависимости. Распакованное содержимое этой папки можно использовать в качестве добавления зависимости в проект для кроссплатформенной разработки и других сценариев использования Aspose.Slides.

## **См. также**

- [Системные требования](/slides/ru/net/system-requirements/)