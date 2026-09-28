---
title: Требования к системе
type: docs
weight: 60
url: /ru/net/system-requirements/
keywords:
- системные требования
- поддерживаемые платформы
- целевые фреймворки
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Проверьте, что требуется Aspose.Slides для .NET перед установкой: целевые фреймворки каждого пакета NuGet, поддерживаемые операционные системы и процессоры, а также библиотеки и шрифты, необходимые Linux."
---
## **Введение**

Aspose.Slides for .NET — самостоятельная библиотека: ей не нужен Microsoft PowerPoint или Microsoft Office. Она публикуется как два пакета NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) и [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Оба предоставляют одинаковые пространства имён и классы Aspose.Slides; они различаются целевыми фреймворками и способом отрисовки слайдов, что определяет, где они работают и что им требуется.

Эта статья перечисляет версии .NET и платформы, поддерживаемые каждым пакетом, а также системные библиотеки и шрифты, необходимые Linux, и заканчивается небольшой программой, проверяющей вашу настройку. Чтобы добавить пакет в проект, смотрите [Установка](/slides/ru/net/installation/).

## **Поддерживаемые версии .NET**

Каждый пакет содержит одну сборку Aspose.Slides для каждой целевой платформы, и NuGet выбирает сборку, соответствующую целевой платформе вашего проекта.

| Пакет | Целевые фреймворки в пакете | Ваш проект может использовать |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 или новее; .NET 6 или новее, включая .NET 8, .NET 9 и .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 или новее, включая .NET 8, .NET 9 и .NET 10 |

Сборка `netstandard2.0` позволяет библиотеке классов .NET Standard 2.0 ссылаться на Aspose.Slides.NET. Приложение, использующее такую библиотеку, запускает сборку, соответствующую целевому фреймворку самого приложения: например, приложение .NET 8 запускает сборку `net6.0`.

## **Поддерживаемые операционные системы и процессоры**

**Aspose.Slides.NET** содержит только независимый от процессора (AnyCPU) управляемый код, поэтому он работает на архитектуре процессора среды выполнения .NET, которая его загружает. Он отрисовывает слайды через библиотеку Microsoft System.Drawing.Common, которую Microsoft поддерживает [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). В Linux Aspose.Slides.NET поэтому нужен библиотека `libgdiplus` и стартовый переключатель, описанные в разделе [Linux](#linux). Он работает на дистрибутивах Linux, предоставляющих `libgdiplus`, таких как Debian, Ubuntu и Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** отрисовывает слайды собственным графическим движком. Движок — это нативная библиотека, которую пакет содержит в отдельной сборке для каждой платформы, поэтому пакет работает только на следующих платформах:

| Операционная система | Процессоры | Примечания |
|---|---|---|
| Windows | x86, x64 | Windows на ARM64 не поддерживается. |
| Linux | x64, ARM64 | Требуется glibc 2.23 или новее на x64 и glibc 2.39 или новее на ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform не работает на Alpine Linux или других дистрибутивах, построенных на musl вместо glibc, и не работает на дистрибутивах со старой glibc, например CentOS 7. На таких системах используйте Aspose.Slides.NET.

В Windows нативная библиотека Aspose.Slides.NET6.CrossPlatform использует среду выполнения Microsoft Visual C++ (*MSVCP140.dll* и *VCRUNTIME140.dll*, плюс *VCRUNTIME140_1.dll* на x64). Если эти файлы отсутствуют на целевой машине, установите [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Оба пакета требуют дополнительных системных библиотек в Linux. Без них первый пример из раздела [Создание презентаций](/slides/ru/net/create-presentation/) завершится исключением вместо сохранения файла. Ниже приведены команды для Debian и Ubuntu; в этих дистрибутивах каждая библиотека также ставит шрифты DejaVu (`fonts-dejavu-core`), поэтому текст отображается без дополнительных шрифтов.

### **Aspose.Slides.NET6.CrossPlatform**

Linux‑библиотека пакета требует библиотеку `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Без неё создание [Презентации](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) завершается `TypeInitializationException`, внутри которого `DllNotFoundException` сообщает, что `libfontconfig.so.1` нельзя открыть.

Минимальные базовые образы могут не включать `fontconfig`. Например, базовый образ AWS Lambda для .NET 8 не содержит ни `fontconfig`, ни шрифтов. В образе контейнера, построенном на нём, выполните `dnf install -y fontconfig`, что также установит шрифты Noto Sans.

### **Aspose.Slides.NET**

Пакет требует два компонента в Linux:

1. Библиотеку `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Переключатель `System.Drawing.EnableUnixSupport`, включаемый в начале вашего приложения до любого вызова Aspose.Slides. В файле *Program.cs* с top‑level statements поместите его после директив `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Без `libgdiplus` сохранение презентации завершится `TypeInitializationException`, внутри которого `DllNotFoundException` сообщает, что `libgdiplus` не может быть загружен. Без переключателя внутреннее исключение будет `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Переключатель работает только с System.Drawing.Common 6, той версией, от которой зависит Aspose.Slides.NET. Microsoft убрала его в System.Drawing.Common 7. Если ваш проект ссылается на System.Drawing.Common 7 или новее, напрямую или через другой пакет, Aspose.Slides.NET не работает в Linux и выдаёт `PlatformNotSupportedException` даже при установленном `libgdiplus` и включённом переключателе. В этом случае используйте Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

В Alpine Linux используйте Aspose.Slides.NET с переключателем, описанным выше. Образы Alpine обычно не содержат шрифтов, и `libgdiplus` сам по себе не устанавливает их, поэтому установите `libgdiplus` вместе хотя бы с одним пакетом шрифтов. Без шрифтов сохранение презентации приводит к следующей ошибке:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Вариант 1: шрифты DejaVu**

Рекомендуемый вариант — пакет `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

В текущих релизах Alpine `ttf-dejavu` ставит пакет `font-dejavu`, который также ставит `fontconfig` и необходимые инструменты шрифтов.

**Вариант 2: основные шрифты Microsoft**

Если ваши презентации используют шрифты Microsoft, такие как Arial, Times New Roman, Courier New или Verdana, установите вместо этого основные шрифты Microsoft. Шаг `update-ms-fonts` загружает шрифты во время сборки образа, поэтому сборка должна иметь доступ к интернету:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Поддержка глобализации**

Оба пакета нуждаются в поддержке глобализации .NET, которую .NET в Linux предоставляет через библиотеки ICU. В [globalization‑invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) создание [Презентации](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) завершается `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Некоторые образы контейнеров включают этот режим. Например, образы .NET runtime для Alpine Linux (`runtime-deps`, `runtime` и `aspnet`) задают `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` и не включают ICU. В образе, построенном на них, установите ICU и выключите режим:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Также убедитесь, что ваш файл проекта не задаёт свойство `InvariantGlobalization` со значением `true`.

## **Проверьте настройку**

Чтобы убедиться, что пакет и его требования выполнены, запустите программу, сохраняющую презентацию и рендерящую слайд в изображение. Сохранение и рендеринг используют графическую библиотеку и шрифты, которые обеспечивают вышеописанные требования Linux.

Создайте консольное приложение и добавьте пакет, как описано в [Установка](/slides/ru/net/installation/), замените содержимое *Program.cs* кодом ниже и выполните `dotnet run`. Если вы используете Aspose.Slides.NET в Linux, добавьте оператор переключателя `System.Drawing.EnableUnixSupport`, показанный в разделе [Linux](#linux), после директив `using`. Программа использует top‑level statements и `using`‑объявления, которые требуют C# 9 или новее. Проекты, нацеленные на .NET 6 или новее, по умолчанию используют более новую версию C#; в проекте, нацеленном на .NET Framework, добавьте `<LangVersion>latest</LangVersion>` в `PropertyGroup` файла проекта.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Программа добавляет прямоугольник с текстом на первый слайд и сохраняет презентацию как *hello.pptx* методом [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Затем она рендерит слайд с помощью [GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/getimage/) и сохраняет результат как *hello.png* методом [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/save/) в формате [ImageFormat.Png](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/). Коэффициент масштабирования 1 отображает один пиксель на пункт, поэтому слайд 720 × 540 пунктов превращается в изображение 720 × 540 пикселей, с видимым текстом внутри прямоугольника. Без лицензии оба файла содержат водяной знак оценки; см. [Licensing](/slides/ru/net/licensing/). Если какое‑либо требование отсутствует, программа завершится одним из исключений, описанных в разделе [Linux](#linux).

## **Инструменты разработки**

Вы можете создавать приложения, использующие Aspose.Slides, любым инструментом, поддерживающим целевой фреймворк вашего проекта: .NET SDK и его CLI `dotnet` в Windows, Linux и macOS, либо Visual Studio в Windows. Описание обоих вариантов смотрите в [Установка](/slides/ru/net/installation/).

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется. Aspose.Slides — самостоятельный движок для [создания](/slides/ru/net/create-presentation/), изменения, [конвертации](/slides/ru/net/convert-presentation/) и [рендеринга](/slides/ru/net/convert-powerpoint-to-png/) презентаций.

**Какой пакет следует использовать?**

Используйте Aspose.Slides.NET в Windows и Aspose.Slides.NET6.CrossPlatform в Linux и macOS. В Alpine Linux, в Linux‑системах со старой glibc и в проектах, нацеленных на .NET Framework, используйте Aspose.Slides.NET. Добавляйте только один из двух пакетов в проект.

**Какие шрифты нужны для корректного рендеринга?**

Шрифты, используемые в презентации, или подходящие их заменители, должны быть доступны в операционной системе. В Linux и macOS установите пакеты шрифтов, необходимые вашим презентациям, чтобы обеспечить одинаковый рендеринг. В Alpine Linux установите хотя бы один пакет шрифтов дополнительно к `libgdiplus`, как описано в разделе [Alpine Linux](#alpine-linux).

**Почему пользовательский шрифт отображается как резервный или отсутствующий текст в Linux?**

Если файл шрифта содержит неконсистентные или повреждённые записи в таблице имён, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать неверную запись, из‑за чего шрифт остаётся неразрешённым. Использование версии шрифта с исправленными записями таблицы имён или установка согласующей замены решает проблему.