---
title: Aspose.Slides for .NET 6 кросс-платформенный (ZIP-пакет)
type: docs
weight: 237
url: /ru/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- кросс-платформенный
- .NET 6
- GLIBC
- csproj
- целевой путь
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
description: "Используйте Aspose.Slides для .NET 6 для создания кросс-платформенных приложений C# в Windows, Linux и macOS, которые создают, редактируют и конвертируют файлы PowerPoint PPT, PPTX и ODP."
---

{{% alert title="Примечание" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform также доступен через [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Использование кросс‑платформенного Aspose.Slides из ZIP‑пакета**

1. Скачайте ZIP‑пакет последней версии Aspose.Slides со [Страницы выпуска](https://releases.aspose.com/slides/net/).

2. Распакуйте файлы из *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* и поместите их в папку, которая будет использоваться для зависимостей в вашем проекте.

3. Добавьте ссылку на Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   В нашем примере (см. ниже) библиотеки находятся в папке проекта по пути: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Поместите оставшиеся файлы (от которых зависит Aspose.Slides) в каталог вывода, добавив инструкции в файл проекта csproj следующим образом:
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

   По умолчанию `<CopyToOutputDirectory>` копирует файлы, сохраняя их относительный путь, но нам нужно, чтобы зависимые библиотеки попали в ту же папку, где генерируется вывод (расположение Aspose.Slides.dll).

## **Примечания**

### **Собственная графическая подсистема**

Кросс‑платформенный Aspose.Slides — это набор библиотек:

| Aspose.Slides.dll                                          | Основная сборка .NET, отвечающая за всю логику Aspose.Slides                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Зависимость: реализация графической подсистемы для Windows x64                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | Зависимость: реализация графической подсистемы для Windows x64                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Зависимость: реализация графической подсистемы для Linux (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Зависимость: реализация графической подсистемы для macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Зависимость: реализация графической подсистемы для macOS ARM64 (AArch64)    |

Aspose.Slides.dll использует библиотеку, требуемую системой, на которой он работает. Библиотеки обычно находятся в том же месте, что и Aspose.Slides.dll, в любой файловой системе.

### **Структура ZIP‑пакета**

ZIP‑пакет содержит следующую структуру папок:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Каждая папка содержит сборки для соответствующей версии .NET. Для net6.0 существуют две версии: default и crossplatform. Последняя содержит кросс‑платформенный Aspose.Slides.dll и все его зависимости. Распакованное содержимое этой папки можно использовать как добавление зависимостей в проект для кросс‑платформенной разработки и других случаев использования Aspose.Slides.

## **См. также**

- [System Requirements](/slides/ru/net/system-requirements/)