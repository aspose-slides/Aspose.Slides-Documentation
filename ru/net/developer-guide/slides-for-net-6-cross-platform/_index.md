---
title: Aspose.Slides для .NET 6 Кросс-Платформенный
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, Кросс-платформенный
description: Aspose.Slides для .NET 6 Кросс-Платформенный
---

1. Кросс-платформенный Aspose.Slides для .NET 6 может использоваться для .NET 7 и будущих выпусках .NET.

2. **Предварительное условие**: Чтобы использовать кросс-платформенную версию Aspose.Slides для .NET 6, вам нужно скачать пакет Aspose.Slides со страницы [Выпусков](https://releases.aspose.com/slides/net/). NuGet пакет Aspose.Slides не подходит, так как он предоставляет кросс-платформенную поддержку только для .NET Standard.

3. **Требования**: [Системные требования](https://docs.aspose.com/slides/net/system-requirements/). Обратите внимание, что Aspose.Slides для .NET 6 и .NET 7 требует Linux x86_x64 с GLIBC 2.23 и выше. **CentOS** 7 (версия GLIBC которой 2.14) не поддерживается. Чтобы использовать Slides в CentOS 7 или других системах (например, Alpine), которые не соответствуют требованиям, пожалуйста, получите Aspose.Slides для .NET Standard.

## **Получение и использование кросс-платформенного Aspose.Slides**

1. Скачайте ZIP пакет последнего Aspose.Slides со страницы [Выпусков](https://releases.aspose.com/slides/net/).

2. Распакуйте файлы из *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* и поместите их в папку, которая будет использоваться для зависимостей в вашем проекте.

3. Добавьте ссылку на Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   В нашем примере (ниже) библиотеки находятся в папке проекта по следующему пути: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Поместите оставшиеся файлы (от которых зависит Aspose.Slides) в выходной каталог, добавив инструкции в файл csproj вашего проекта следующим образом:
```
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Обратите внимание на TargetPath. 

   По умолчанию, `<CopyToOutputDirectory>` копирует файлы, сохраняя их относительный путь, но нам нужно, чтобы зависимые библиотеки попали в ту же папку, где генерируется выход (местоположение Aspose.Slides.dll).

## Заметки

### **Поддержка System.Drawing.Common только для Windows**

Начиная с .NET 6, поддержка System.Drawing.Common (которая обеспечивала поддержку GDI+) доступна [только в Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Aspose.Slides для .NET зависит от GDI+. Кроме того, публичный API Aspose.Slides содержит типы (Bitmap, Metafile, Graphics и т.д.) из пакета System.Drawing.Common.

### **Собственная подсистема графики**

Чтобы решить проблему изменения, нарушающего поддержку кросс-платформенности для System.Drawing.Common, Aspose.Slides, начиная с версии 23.6, использует свою собственную реализацию подсистемы графики.

Это поддерживаемые системы: **Windows**, **Linux** и **macOS**.

Кросс-платформенный Aspose.Slides представляет собой коллекцию библиотек:

| Aspose.Slides.dll                                          | Основная сборка .NET, ответственная за всю логику Aspose.Slides    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Зависимость: реализация подсистемы графики для Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Зависимость: реализация подсистемы графики для Win x64    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Зависимость: реализация подсистемы графики для Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | Зависимость: реализация подсистемы графики для macOS      |

Aspose.Slides.dll использует библиотеку, которая требуется системе, на которой она работает. Библиотеки обычно находятся в одном и том же месте, что и Aspose.Slides.dll в любой файловой системе.

### **Публичный API Aspose.Slides и типы из System.Drawing.Common. Решение проблемы конфликтов имен**

Публичный API Aspose.Slides использует типы из System.Drawing.Common (Bitmap, Metafile, Graphics и многие другие). Чтобы облегчить плавный переход на новый кросс-платформенный продукт Aspose.Slides и избежать множества разрушительных изменений в публичном API Slides, собственная реализация подсистемы графики **дублирует** типы и пространства имен из System.Drawing.Common.

Следовательно, если вы разрабатываете или работаете в среде Linux, вам просто нужно использовать Aspose.Slides как зависимость — и весь API остается тем же.

**Потенциальная проблема**: Описанная настройка имеет свои недостатки. Например, если вы разрабатываете в Windows и у вас есть проекты, которые используют оригинальный System.Drawing.Common, вы можете столкнуться с конфликтами с типами Aspose.Slides.

**Решение**: Вы можете использовать extern alias для решения проблемы. См. [**Использование пакета System.Drawing.Common и классы Slides для .NET 6 (CS0433: Тип существует как в Slides, так и в System.Drawing.Common)**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error).

Команда Slides работает над задачами, которые приведут к упрощению и унификации публичного API.

### **Пакеты NuGet и ZIP**

* Пакет NuGet Aspose.Slides для .NET в настоящее время не поддерживает кросс-платформенный Aspose.Slides для .NET 6.

* Пакет NuGet Aspose.Slides для .NET поддерживает кросс-платформенность для .NET Standard, но не для .NET 6.

* Кросс-платформенная версия Aspose.Slides доступна в виде ZIP пакетов, предоставленных на странице [Выпусков](https://releases.aspose.com/slides/net/).

* ZIP пакет содержит следующую структуру папок:

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* Каждая папка содержит сборки для соответствующей версии .NET. Для net6.0 есть две версии: win и crossplatform. Последняя содержит кросс-платформенный Aspose.Slides.dll и все его зависимости. Распакованное содержимое этой папки может использоваться как дополнительная зависимость в проекте для кросс-платформенной разработки и других случаев использования Aspose.Slides.