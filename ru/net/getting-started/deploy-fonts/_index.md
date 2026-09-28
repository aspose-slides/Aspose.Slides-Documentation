---
title: Развертывание шрифтов для Aspose.Slides на Linux и в Docker
linktitle: Развертывание шрифтов
type: docs
weight: 145
url: /ru/net/deploy-fonts/
keywords:
- развертывание шрифтов
- установка шрифтов
- шрифты в Docker
- шрифты на Linux
- отсутствующие шрифты
- замена шрифтов
- основные шрифты Microsoft
- ttf-mscorefonts-installer
- пользовательские шрифты
- шрифт по умолчанию
- сервер
- контейнер
- преобразование PDF
- презентация
- .NET
- C#
- Aspose.Slides
description: "Развертывание шрифтов для Aspose.Slides для .NET на Linux‑серверах и в Docker‑контейнерах: проверить, какие шрифты заменяются, установить пакеты шрифтов в Debian, Ubuntu и Alpine, добавить свои файлы шрифтов и задать шрифт по умолчанию."
---
## **Обзор**

Aspose.Slides рисует текст шрифтами, доступными ему при отображении презентации, например при конвертации слайдов в PDF или изображения. На настольном компьютере под Windows обычно есть шрифты, используемые в презентациях. На Linux‑серверах и в контейнерах обычно мало шрифтов или их нет, поэтому Aspose.Slides рисует текст заменяющим шрифтом. Замена имеет другие формы букв и другие ширины, поэтому строки могут переноситься иначе, текст может выходить за пределы своей формы, а символы, которых нет в заменяющем шрифте, отрисовываются некорректно. Если шрифт вовсе не установлен, конверсия останавливается с ошибкой.

В этой статье показано, как проверить, какие шрифты заменяет Aspose.Slides, как установить шрифты в Debian, Ubuntu и Alpine Linux, как добавить свои файлы шрифтов и как задать шрифт, который будет использоваться при отсутствии шрифта. Примеры запускаются в Docker на официальных образах .NET, как в статье [Run Aspose.Slides for .NET in Docker](/slides/ru/net/how-to-run-aspose-slides-in-docker/). Команды пакетов являются инструкциями Dockerfile; на Linux‑сервере выполните те же команды от имени root.

Для самого API шрифтов, например встраивания шрифтов в презентацию и правил резервирования и замены, см. [PowerPoint Fonts](/slides/ru/net/powerpoint-fonts/).

## **Проверка заменяемых шрифтов**

Следующее консольное приложение выводит шрифты, которые Aspose.Slides заменяет в текущей среде. Создайте папку с именем *FontCheck* и добавьте в неё файлы, указанные ниже.

*FontCheck.csproj* ссылается на [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), пакет для Debian и Ubuntu. Он также копирует файлы необязательной папки *fonts* в вывод приложения; раздел [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) использует её.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* добавляет один текстовый блок на каждый шрифт на слайде и задаёт шрифт через свойство [LatinFont](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/latinfont/). Имена шрифтов берутся из командной строки; без аргументов приложение проверяет Calibri, Arial и Times New Roman. Оно выводит папки, в которых Aspose.Slides ищет шрифты ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/getfontfolders/)), рендерит слайд в *output/fonts.pdf* и выводит замены, сообщённые [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/). Два необязательных шага в начале — загрузка папки *fonts* и чтение переменной `DEFAULT_FONT` — описаны позже в этой статье.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Шрифты для проверки: аргументы командной строки или три распространённых шрифта Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Загрузить файлы шрифтов из папки fonts рядом с приложением, если она существует.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Использовать шрифт, указанный в переменной окружения DEFAULT_FONT, если она задана, для текста, у которого шрифт отсутствует.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* исключает локальные результаты сборки из контекста сборки:

```text
bin/
obj/
output/
```

*Dockerfile* собирает приложение с использованием образа .NET SDK и запускает его на образе .NET runtime. На этапе runtime устанавливается `libfontconfig1`, который требует Aspose.Slides.NET6.CrossPlatform, и шрифты DejaVu. Статья [Run Aspose.Slides for .NET in Docker](/slides/ru/net/how-to-run-aspose-slides-in-docker/) объясняет каждую инструкцию.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Соберите образ и запустите проверку:

```bash
docker build -t font-check .
docker run --rm font-check
```

В образе присутствуют только шрифты DejaVu, поэтому все три шрифта заменяются на DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Чтобы проверить шрифты в собственных презентациях, передайте их имена в качестве аргументов, например `docker run --rm font-check "Segoe UI" Consolas`. Чтобы скопировать *output/fonts.pdf* из контейнера, используйте команды в разделе [Copy the Output to Your Machine](/slides/ru/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Установка шрифтов в Debian и Ubuntu**

### **Microsoft Core Fonts**

Пакет `ttf-mscorefonts-installer` загружает и устанавливает базовые шрифты Microsoft для веба, среди которых Arial, Times New Roman, Courier New, Verdana, Georgia и Trebuchet MS. Шрифты лицензированы согласно пользовательскому лицензионному соглашению Microsoft (EULA), и пакет устанавливает их только после принятия EULA. Сборка Docker не может ответить на запрос, поэтому установщик отклоняет EULA и не устанавливает шрифты, хотя `apt-get install` всё равно сообщает об успехе. Примите EULA с помощью `debconf-set-selections` **до** установки пакета.

В *Dockerfile* замените инструкцию `RUN`, которая устанавливает пакеты в этапе runtime, на следующее:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Соберите образ и запустите проверку ещё раз теми же двумя командами. Arial и Times New Roman теперь установлены:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, шрифт по умолчанию для презентаций, создаваемых Aspose.Slides, не относится к базовым шрифтам, поэтому он всё ещё заменяется. См. раздел [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

В Debian пакет находится в компоненте репозитория `contrib`, который не включён в базовые образы Debian; образы .NET 8 и .NET 9 основаны на Debian 12. Включите `contrib` в той же инструкции:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Образы .NET 10 на базе Ubuntu уже включают `multiverse`, компонент Ubuntu, содержащий этот пакет.

### **Другие пакеты шрифтов**

Debian и Ubuntu также поставляют свободно лицензированные шрифты, например:

| Пакет | Шрифты |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif и Mono, с теми же метриками, что у Arial, Times New Roman и Courier New |
| `fonts-crosextra-carlito` | Carlito, с теми же метриками, что у Calibri |
| `fonts-crosextra-caladea` | Caladea, с теми же метриками, что у Cambria |

Устанавливайте их с помощью `apt-get install` в той же инструкции `RUN`. Aspose.Slides.NET6.CrossPlatform не использует алиасы шрифтов из конфигурации Linux: даже при установленном `fonts-liberation` текст в Arial по‑прежнему рисуется заменяющим шрифтом, а не Liberation Sans. Чтобы использовать совместимый по метрикам шрифт вместо отсутствующего, задайте его как [default font](#set-a-default-font-for-missing-fonts) или добавьте [правило замены шрифтов](/slides/ru/net/font-substitution/).

## **Добавление собственных файлов шрифтов**

Шрифты, которые не включены в дистрибутивы, например шрифты вашей организации или другие лицензированные шрифты, можно добавить в виде файлов. Поместите файлы шрифтов, например *.ttf*, в папку *fonts* внутри папки *FontCheck*. В примерах ниже используются файлы Carlito, шрифт с теми же метриками, что у Calibri, которые можно скачать с [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Установка шрифтов в системную папку шрифтов**

Aspose.Slides читает шрифты из папок, указанных в строке `Font folders`. Чтобы установить шрифты для всех приложений в образе, скопируйте их в */usr/local/share/fonts* — папку для локально установленных шрифтов. Добавьте эту инструкцию в этап runtime *Dockerfile* после инструкции `RUN`, которая устанавливает пакеты:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Загрузка шрифтов из папки приложения**

Вместо установки шрифтов в образе их можно разместить вместе с приложением и загрузить с помощью [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/). Шрифты тогда будут доступны только Aspose.Slides и будут развернуты вместе с приложением. *FontCheck* делает именно это: *FontCheck.csproj* копирует папку *fonts* в вывод приложения, а *Program.cs* перед созданием презентации передаёт эту папку в `LoadExternalFonts`. Подробнее о других способах поставки шрифтов, например загрузке из памяти, читайте в разделе [Custom Font](/slides/ru/net/custom-font/).

Пересоберите образ, затем проверьте Calibri и Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Папка приложения теперь отображается среди папок шрифтов, и Carlito более не заменяется:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Установка шрифта по умолчанию для отсутствующих шрифтов**

Когда шрифт отсутствует, Aspose.Slides использует замену, выбранную автоматически. Чтобы задать замену вручную, установите свойство [DefaultRegularFont](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaultregularfont/) объекта [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). *FontCheck* считывает имя шрифта из переменной окружения `DEFAULT_FONT`. При загруженном Carlito используйте его для отсутствующих шрифтов:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri теперь рисуется шрифтом Carlito, у которого одинаковые ширины символов, поэтому текст сохраняет переносы строк:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Шрифт по умолчанию заменяет каждый отсутствующий шрифт. Чтобы сопоставить отдельные шрифты, например Arial → Liberation Sans и Calibri → Carlito, используйте [правила замены шрифтов](/slides/ru/net/font-substitution/). Правила меняют вывод, но `GetSubstitutions` их не отражает, поэтому проверяйте шрифты в результирующем файле. Для азиатского текста также задайте [DefaultAsianFont](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaultasianfont/); см. раздел [Default Font](/slides/ru/net/default-font/).

## **Установка шрифтов в Alpine Linux**

В Alpine Linux используйте пакет Aspose.Slides.NET; изменения, необходимые для работы в Alpine, перечислены в статье [Run on Alpine Linux](/slides/ru/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux). Внесите те же изменения в *FontCheck*: замените ссылку на пакет, добавьте оператор `SetSwitch` в *Program.cs* и используйте следующий этап runtime, который также устанавливает шрифты Microsoft:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` загружает и устанавливает те же базовые шрифты Microsoft, что и пакет для Debian и Ubuntu, и их EULA применяется одинаково. `fc-cache` обновляет кэш шрифтов.

С Aspose.Slides.NET на Linux библиотека конфигурации шрифтов (fontconfig) выбирает замену для отсутствующего шрифта, и `GetSubstitutions` её не сообщает, поэтому *FontCheck* выводит `No font substitutions.` Чтобы увидеть, какой шрифт используется для заданного имени, запросите fontconfig внутри контейнера:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

С установленными базовыми шрифтами Microsoft для Arial используется Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Без них, когда инструкция `RUN` устанавливает только `icu-libs libgdiplus font-dejavu`, та же команда выводит:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Почему презентация выглядит иначе после конвертации на сервере?**

На сервере нет шрифтов, используемых в презентации, поэтому Aspose.Slides рисует текст заменяющим шрифтом, у которого другие ширины букв. Запустите *FontCheck* с именами шрифтов презентации, чтобы увидеть, какие шрифты заменяются, затем установите их или загрузите из папки приложения.

**Сборка установила ttf-mscorefonts-installer, но Arial всё ещё заменяется. Почему?**

EULA не была принята до установки пакета, поэтому установщик пропустил шрифты. Добавьте команду `debconf-set-selections` перед `apt-get install`, как показано в разделе [Microsoft Core Fonts](#microsoft-core-fonts), и пересоберите образ.

**Нужны ли шрифты на компьютере, где открывается PDF?**

Нет. В этих примерах PDF уже содержит использованные шрифты, поэтому он выглядит одинаково на любом компьютере. Шрифты требуются только там, где Aspose.Slides рендерит презентацию.