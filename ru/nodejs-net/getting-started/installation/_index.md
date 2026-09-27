---
title: Установка
type: docs
weight: 70
url: /ru/nodejs-net/installation/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Установите Aspose.Slides for Node.js via .NET из npm на Windows или Linux: предварительные требования, переопределение edge-js, одноразовое восстановление NuGet и первая программа, создающая презентацию."
---
## **Обзор**

Aspose.Slides for Node.js via .NET — это npm‑пакет `aspose.slides.via.net`. Он запускает библиотеку Aspose.Slides .NET внутри Node.js через мост [edge-js](https://github.com/agracio/edge-js), поэтому для работы требуется как Node.js, так и .NET.

В этой статье вы пройдёте путь от чистой машины до первой программы, создающей презентацию. Есть четыре шага: создать проект с переопределением edge-js, установить пакет из npm, один раз восстановить .NET‑зависимости пакета и запустить скрипт из папки проекта.

## **Предварительные требования**

- **Node.js 22 или 24 LTS**, 64‑разрядная сборка, с сайта [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 или новее**, с сайта [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Одна только среда выполнения .NET недостаточна: шаг восстановления ниже требует SDK, так же как и мост при запуске скрипта. Выполните `dotnet --list-sdks`, чтобы проверить, какие SDK установлены.
- **Только для Linux**:
  - инструменты сборки `python3`, `make` и `g++`, потому что npm компилирует edge‑js во время установки в Linux;
  - библиотеку fontconfig, которую загружает нативная библиотека рисования Aspose.Slides.  
  В Debian это пакеты `python3`, `make`, `g++` и `libfontconfig1`.

Шаги в этой статье были протестированы на следующих платформах:

| Платформа | Результат |
|---|---|
| Windows x64 с Node.js 22 или 24 | Работает. Тестировано с установленным Microsoft Visual C++ Redistributable. |
| Linux x64 с Node.js 22 или 24, где системный OpenSSL из той же ветки релизов, что и OpenSSL, встроенный в Node.js, например Debian 13 | Работает. |
| Linux, где версии OpenSSL различаются, например Debian 12 | Node.js падает с ошибкой сегментации при создании презентации. |
| macOS | Не проверено. |

В Linux сравните две версии перед началом. Первая команда выводит версию OpenSSL, встроенную в Node.js; вторая — системную версию. Используйте систему, где обе начинаются с одинаковых основных и второстепенных номеров, например `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Если команда `openssl` не найдена, сначала установите пакет `openssl`.

## **Создание проекта**

Создайте папку для проекта, инициализируйте её и добавьте переопределение, указывающее npm, какую версию edge-js установить:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Пакет требует более старую версию edge-js, предкомпилированные Windows‑бинарные файлы которой заканчиваются на Node.js 20, поэтому без переопределения первый скрипт в Windows завершается сообщением «The edge module has not been pre-compiled for node.js version». Команда записывает переопределение в секцию `overrides` файла `package.json`; добавьте его перед установкой пакета.

## **Установка пакета**

Установите Aspose.Slides for Node.js via .NET из npm:

```sh
npm install aspose.slides.via.net
```

Во время установки пакет копирует свои нативные библиотеки рисования (файлы, в названиях которых присутствует `aspose.slides.drawing.capi`) в папку проекта рядом с `package.json`.

Пакет также опубликован в виде ZIP‑архива на [releases.aspose.com](https://releases.aspose.com/slides/ru/nodejs-net/). В этой статье рассматривается только установка из npm.

## **Восстановление .NET‑зависимостей**

Пакет содержит сборки Aspose.Slides .NET, но не 20 пакетов NuGet, от которых зависят эти сборки. Во время выполнения .NET ищет их в кэше пакетов NuGet: `%USERPROFILE%\.nuget\packages` в Windows, `~/.nuget/packages` в Linux или в папке, указанной переменной окружения `NUGET_PACKAGES`. Если их нет, первый скрипт завершается сообщением «assembly specified in the dependencies manifest was not found».

Чтобы заполнить кэш, создайте папку `deps` в папке проекта и сохраните в ней следующий файл под именем `deps.csproj`. Каждый элемент `PackageDownload` загружает один пакет точной версии, указанной в скобках; ничего не компилируется.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Затем восстановите его из папки проекта:

```sh
dotnet restore deps/deps.csproj
```

Этот шаг требуется один раз на машину, а не на каждый проект: пакеты остаются в кэше NuGet, и последующие проекты на той же машине используют их. После восстановления можете удалить папку `deps`.

## **Запуск первой программы**

Создайте файл `hello.js` в папке проекта со следующим кодом. Он создаёт презентацию, добавляет прямоугольник с текстом «Hello, World!» на первый слайд и сохраняет результат как `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Новая презентация содержит один пустой слайд.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Позиция и размер задаются в пунктах (1/72 дюйма): x, y, ширина, высота.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Освободить .NET‑объект, поддерживающий презентацию.
    presentation.dispose();
}
```

Запустите его из папки проекта:

```sh
node hello.js
```

Скрипт выводит `Saved hello.pptx`. Откройте `hello.pptx`, чтобы увидеть один слайд с заполненным прямоугольником, содержащим текст. Без лицензии Aspose.Slides добавляет водяной знак оценки; см. [Evaluate Aspose.Slides](/slides/ru/nodejs-net/evaluate-aspose-slides/) и [Licensing](/slides/ru/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Запускайте свои скрипты из папки проекта, той, что содержит `package.json`. Относительные пути, такие как `hello.pptx`, разрешаются относительно текущей папки, и на некоторых машинах скрипт, запущенный из другой папки, не может создать презентацию.
{{% /alert %}}

JavaScript API отражает Aspose.Slides for .NET: классы сохраняют свои .NET‑имена, свойства и методы используют camelCase (`Slides` становится `slides`, `AddAutoShape` становится `addAutoShape`), а элементы коллекций читаются via `get(index)`. Отдельной справки API для этого пакета нет, поэтому используйте [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ru/net/) для деталей классов и членов, например [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/shapecollection/addautoshape/).

## **Часто задаваемые вопросы**

**Что означает сообщение «The edge module has not been pre-compiled for node.js version»?**

npm установил более старую версию edge-js, которую запрашивает пакет. Добавьте переопределение из [Create a Project](#create-a-project) и снова выполните `npm install`.

**Что означает сообщение «assembly specified in the dependencies manifest was not found»?**

Зависимости .NET отсутствуют в кэше NuGet. При том же запуске также выводится сообщение «edge.initializeClrFunc is not a function». Выполните [Restore the .NET Dependencies](#restore-the-net-dependencies) один раз, затем снова запустите скрипт.

**Что означает сообщение «The edge native module is not available» в Linux?**

edge-js не был скомпилирован во время `npm install`, например из‑за отсутствия `python3`, `make` или `g++`. npm не сообщает об этом как об ошибке. Установите инструменты сборки, затем запустите `npm rebuild edge-js` в папке проекта.

**Почему создание презентации завершается с пустой ошибкой "Error"?**

В Linux проверьте, установлена ли библиотека fontconfig (`libfontconfig1` в Debian); без неё нативная библиотека рисования не может загрузиться. На любой системе также убедитесь, что скрипт запускается из папки проекта.

**Почему Node.js падает с ошибкой сегментации в Linux?**

Системный OpenSSL и OpenSSL, встроенный в Node.js, принадлежат к разным веткам релизов. Сравните их, как показано в [Prerequisites](#prerequisites), и используйте дистрибутив или сборку Node.js, где они совпадают.

**Нужно ли выполнять восстановление NuGet для каждого проекта?**

Нет. Восстановление заполняет кэш NuGet для вашей учётной записи, и каждый проект на этой машине использует один и тот же кэш.