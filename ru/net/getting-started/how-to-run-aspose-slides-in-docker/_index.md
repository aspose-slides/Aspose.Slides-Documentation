---
title: Запуск Aspose.Slides для .NET в Docker
linktitle: Docker
type: docs
weight: 140
url: /ru/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker контейнер
- многоэтапная сборка
- образ контейнера
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- шрифты
- преобразование PDF
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте и запустите консольное приложение Aspose.Slides для .NET в Docker: многоэтапный Dockerfile на официальных образах .NET, необходимые Linux‑библиотеки и шрифты, а также как скопировать сгенерированные файлы на ваш компьютер."
---
## **Обзор**

Эта статья показывает, как запустить Aspose.Slides for .NET в контейнере Docker. Вы создаёте небольшое консольное приложение, которое создаёт презентацию с текстовым полем и преобразует её в PDF, упаковываете его в многоэтапный Dockerfile на официальных образах .NET от Microsoft, запускаете его и копируете сгенерированные файлы на свой компьютер. В статье также перечислены библиотеки Linux и шрифты, необходимые Aspose.Slides в контейнере, и приводится вариант для Alpine Linux.

Для работы достаточно установить Docker на ваш компьютер. .NET SDK входит в образ сборки, поэтому его устанавливать не нужно. Чтобы установить Docker, см. [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Выбор пакета и базового образа**

Стандартные контейнерные образы .NET 10 основаны на Ubuntu 24.04. На этих образах используйте пакет [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Он требует библиотеку `fontconfig`, а образ среды выполнения .NET не содержит ни этой библиотеки, ни шрифтов, поэтому Dockerfile в этой статье устанавливает оба компонента.

Aspose.Slides.NET6.CrossPlatform не работает на Alpine Linux. Для образов на Alpine используйте пакет [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) с `libgdiplus`, как описано в разделе [Run on Alpine Linux](#run-on-alpine-linux). Сравнение двух пакетов см. в [Installation](/slides/ru/net/installation/).

## **Создание проекта**

Создайте папку с именем *HelloSlidesDocker* и добавьте в неё три файла.

*HelloSlidesDocker.csproj* описывает консольное приложение для .NET 10, указывает версию образов контейнеров, используемых ниже, и ссылается на Aspose.Slides.NET6.CrossPlatform. Установите версию пакета на последнюю, указанную на [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* создаёт [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), добавляет прямоугольник с текстом на первый слайд и сохраняет презентацию дважды через метод [Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/): как PPTX и как PDF. Оба файла помещаются в папку *output* в рабочем каталоге. Затем приложение выводит список шрифтов, которые были заменены при рендеринге PDF, используя [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/), чтобы вы могли увидеть, имеются ли в контейнере шрифты, используемые презентацией.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* исключает папки *bin* и *obj* локальной сборки, а также вывод предыдущих запусков, из контекста сборки Docker, поэтому образ создаётся только из исходных файлов.

```text
bin/
obj/
output/
```

## **Написание Dockerfile**

Добавьте файл с именем *Dockerfile* в эту же папку:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Файл содержит два этапа:

- **Этап сборки** начинается с образа .NET SDK. Сначала копируются файлы проекта и восстанавливаются пакеты NuGet, чтобы Docker мог переиспользовать этот слой, пока файл проекта не изменяется. Затем копируется исходный код и публикуется приложение в */app*.
- **Этап выполнения** начинается с меньшего образа .NET runtime, в котором нет SDK, и копирует только опубликованное приложение. Устанавливаются два пакета:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform загружает эту библиотеку при запуске. Без неё приложение завершается с `DllNotFoundException`, указывающей на `libfontconfig.so.1`.
  - `fonts-dejavu-core`: в образе выполнения нет шрифтов, а Aspose.Slides требует хотя бы один установленный шрифт для отрисовки текста; без шрифтов конверсия останавливается с `InvalidOperationException: Cannot find any fonts installed on the system.` Текст в неподдерживаемых шрифтах отрисовывается заменяющим шрифтом. Шрифты DejaVu — небольшой набор, позволяющий отрисовывать текст; для конвертации презентаций с их оригинальными шрифтами см. [Deploy Fonts](/slides/ru/net/deploy-fonts/).

  Параметр `--no-install-recommends` и удаление списков пакетов позволяют сохранить небольшой размер образа. Последние строки создают папку *output*, передают её пользователю без прав root `app` (его идентификатор хранится в переменной `APP_UID`) и запускают приложение от имени этого пользователя.

Для приложения ASP.NET Core начните этап выполнения с `mcr.microsoft.com/dotnet/aspnet:10.0`. Он основан на том же образе Ubuntu, поэтому требуются те же пакеты.

## **Сборка и запуск контейнера**

Откройте терминал в папке *HelloSlidesDocker*. Соберите образ, затем запустите контейнер:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

При первом построении скачиваются базовые образы и пакеты NuGet, поэтому он длится дольше, чем последующие сборки. Контейнер запускает приложение и завершает работу. Вывод выглядит так:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Первая строка показывает, что текст использует Calibri — стандартный шрифт новой презентации, и что Calibri не установлен в образе, поэтому Aspose.Slides отрисовал текст шрифтом DejaVu Sans. Текст в PDF — реальный, выделяемый шрифт. Без лицензии Aspose.Slides также добавляет водяной знак оценки на каждый сохранённый слайд; см. [Licensing](/slides/ru/net/licensing/).

## **Копирование вывода на ваш компьютер**

Файлы находятся в папке */app/output* остановленного контейнера. Скопируйте их в папку *output* на вашем компьютере, затем удалите контейнер:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Эти две команды работают одинаково в Bash, PowerShell и Windows Command Prompt.

В Linux вы также можете смонтировать папку вашего компьютера в контейнер, чтобы приложение записывало файлы напрямую туда:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Опция `--user` запускает приложение с вашими UID и GID, поэтому оно может писать в созданную вами папку, а файлы будут принадлежать вам. `--rm` удаляет контейнер после остановки.

## **Запуск на Alpine Linux**

Чтобы запустить приложение в образе на базе Alpine, переключитесь на пакет Aspose.Slides.NET и измените этап выполнения. Этап сборки остаётся прежним.

1. В *HelloSlidesDocker.csproj* замените ссылку на пакет:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. В *Program.cs* добавьте эту строку после директив `using`, перед первым вызовом Aspose.Slides. Она включает поддержку System.Drawing для Linux, которую использует Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. В *Dockerfile* замените этап выполнения (всё, что начиная со второй строки `FROM`) на:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Этап Alpine устанавливает три пакета и меняет одну настройку:

- `libgdiplus` — графическая библиотека, используемая Aspose.Slides.NET в Linux.
- `font-dejavu` предоставляет шрифты. Без шрифтов конверсия останавливается с `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` и `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` обеспечивают данные о культурах. Образы .NET для Alpine работают в режиме глобализации‑инвариантности по умолчанию, и в этом режиме Aspose.Slides прекращает работу с `CultureNotFoundException` для `en-US`.

Соберите, запустите и скопируйте вывод теми же командами, что выше. В этом образе приложение выводит только строку `Saved`: с Aspose.Slides.NET в Linux fontconfig выбирает замену отсутствующего шрифта, и [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) её не перечисляет. Подробнее, как проверить какой шрифт используется, см. [Deploy Fonts](/slides/ru/net/deploy-fonts/).

## **FAQ**

**Приложение завершается с ошибкой "Unable to load shared library 'libaspose.slides.drawing.capi…'". Что отсутствует?**

На образах Ubuntu и Debian нужен пакет `libfontconfig1`; сообщение указывает, что не удалось открыть `libfontconfig.so.1`. На Alpine Linux сообщение означает, что используется Aspose.Slides.NET6.CrossPlatform; переключитесь на Aspose.Slides.NET, как описано в разделе [Run on Alpine Linux](#run-on-alpine-linux).

**Почему текст в PDF отображается другим шрифтом, чем в PowerPoint?**

Шрифты, используемые презентацией, не установлены в образе, поэтому Aspose.Slides отрисовывает текст заменяющим шрифтом. Вывод приложения перечисляет каждый заменённый шрифт. [Deploy Fonts](/slides/ru/net/deploy-fonts/) объясняет, как установить шрифты в образе или загрузить их из папки приложения.

**Нужен ли мне .NET SDK на моём компьютере?**

Нет. Этап сборки компилирует приложение внутри образа SDK. Вам нужен SDK только в том случае, если вы хотите собирать и запускать приложение вне Docker; см. [Installation](/slides/ru/net/installation/).