---
title: Кросс‑платформенный пакет для .NET 6 и более новых версий
linktitle: Кросс‑платформенный пакет
type: docs
weight: 235
url: /ru/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- кросс‑платформенный
- поддержка .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Узнайте, когда использовать пакет Aspose.Slides.NET6.CrossPlatform: почему он существует, на каких платформах работает и что требуется в Linux вместо libgdiplus."
---
## **Введение**

Aspose.Slides for .NET публикуется в виде двух пакетов NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) отрисовывает слайды с помощью библиотеки System.Drawing.Common от Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) отрисовывает их собственным графическим движком. Эта статья объясняет, зачем нужен второй пакет, где он работает, что требуется на Linux и как он сосуществует с System.Drawing.Common в одном проекте.

## **Почему отдельный пакет**

Начиная с .NET 6, Microsoft поддерживает System.Drawing.Common [только на Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). В результате на Linux Aspose.Slides.NET требуется переключатель `System.Drawing.EnableUnixSupport` в дополнение к библиотеке `libgdiplus`, и он не работает, если проект ссылается на System.Drawing.Common версии 7 или новее. [System Requirements](/slides/ru/net/system-requirements/) описывает эти условия.

Aspose.Slides.NET6.CrossPlatform не использует System.Drawing.Common или `libgdiplus`. Его графический движок — это нативная библиотека, которую пакет содержит в виде одного билда для каждой поддерживаемой платформы. Оба пакета предоставляют одинаковые пространства имён и классы Aspose.Slides, поэтому переключение с одного на другой меняет только ссылку на пакет, а не ваш код.

|  | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Графика | System.Drawing.Common | Нативный графический движок, включённый в пакет |
| Целевые фреймворки | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Требования к Linux | `libgdiplus` and the `System.Drawing.EnableUnixSupport` switch | `fontconfig` |
| Alpine Linux | Поддерживается | Не поддерживается |

## **Поддерживаемые платформы**

Aspose.Slides.NET6.CrossPlatform работает с .NET 6 и более новыми версиями на следующих платформах:

- **Windows**: x86 и x64. Нативная библиотека использует runtime Microsoft Visual C++; см. [System Requirements](/slides/ru/net/system-requirements/).
- **Linux**: x64 с glibc 2.23 или новее, и ARM64 с glibc 2.39 или новее.
- **macOS**: x64 (Intel) и ARM64 (Apple silicon).

Он не работает на Windows с ARM64, на Alpine Linux или других дистрибутивах, построенных на musl вместо glibc, а также на дистрибутивах со старой glibc, например CentOS 7. На этих системах используйте Aspose.Slides.NET.

## **Установка на Linux**

На Linux пакет требует библиотеку `fontconfig`, но не `libgdiplus`. На Debian и Ubuntu установите `fontconfig`, а затем добавьте пакет в ваш проект:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

В Debian и Ubuntu пакет `libfontconfig1` также устанавливает шрифты DejaVu, поэтому текст отображается без дополнительных шрифтовых пакетов. Без `fontconfig` создание [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) завершается ошибкой `TypeInitializationException`, внутреннее исключение `DllNotFoundException` сообщает, что `libfontconfig.so.1` не может быть открыт. [System Requirements](/slides/ru/net/system-requirements/) включает небольшую программу, проверяющую настройки.

## **Облачные и контейнерные хосты**

Поскольку ему не нужен `libgdiplus`, Aspose.Slides.NET6.CrossPlatform является пакетом, который следует использовать на Linux‑хостах, где невозможно установить `libgdiplus`. Он всё равно требует `fontconfig` и шрифты, которые могут отсутствовать в минимальных базовых образах. Например, базовый образ AWS Lambda для .NET 8 не содержит ни того, ни другого. В контейнерном образе, построенном на нём, выполните `dnf install -y fontconfig`, что также установит шрифты Noto Sans.

Для руководств по конкретным облачным платформам см. [Aspose.Slides on Cloud Platforms](/slides/ru/net/slides-on-cloud-platforms/).

## **Использование System.Drawing.Common в том же проекте (CS0433)**

Проект, использующий Aspose.Slides.NET6.CrossPlatform, может также ссылаться на System.Drawing.Common, напрямую или через другой пакет. Текущая версия Aspose.Slides не открывает публичных типов в пространствах имён `System`, поэтому две библиотеки не конфликтуют, и вы можете импортировать пространства имён `Aspose.Slides` и `System.Drawing` в одном файле.

Если компилятор сообщает ошибку CS0433, потому что тип, например `Image` или `Graphics`, существует как в Aspose.Slides, так и в System.Drawing.Common, ваш проект использует более старую версию Aspose.Slides. Обновите пакет до последней версии. Aspose.Slides возвращает отрисованные изображения как объекты [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), которые описаны в разделе [Modern API](/slides/ru/net/modern-api/).

## **FAQ**

**Нужно ли менять код при переходе с Aspose.Slides.NET на Aspose.Slides.NET6.CrossPlatform?**

Нет. Оба пакета предоставляют одинаковые пространства имён и классы Aspose.Slides, поэтому нужно лишь заменить ссылку на пакет. Aspose.Slides.NET6.CrossPlatform не требует переключателя `System.Drawing.EnableUnixSupport`. В проект добавляйте только один из двух пакетов.

**Могу ли я использовать Aspose.Slides.NET6.CrossPlatform в проекте .NET Framework?**

Нет. Пакет нацелен только на .NET 6 и более новые версии. Для .NET Framework 4.6.2 и новее используйте Aspose.Slides.NET.