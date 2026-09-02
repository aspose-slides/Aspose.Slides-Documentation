---
title: Как запустить Aspose.Slides в Docker
linktitle: Aspose.Slides в Docker
type: docs
weight: 150
url: /ru/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides в Docker
- Docker-контейнер
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- шрифты
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Запуск Aspose.Slides for Python via .NET в Docker: рабочий Dockerfile, необходимые нативные библиотеки, настройка шрифтов и лицензирование в контейнере."
---
## **Обзор**

Aspose.Slides for Python via .NET работает в Linux‑контейнерах, но пакет представляет собой Python‑обёртку
вокруг встроенного runtime .NET Core 3.1. Этот runtime требует три нативные библиотеки, которые отсутствуют в облегчающих образах Python,
и он чувствителен к их версиям. В этой статье приводится рабочий Dockerfile,
объясняется, зачем каждая зависимость, и показывается, как добавить шрифты и лицензию.

## **Рабочий Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Сборка и запуск:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Почему базовый образ — Debian 11**

Колёса `aspose.slides` содержат runtime **.NET Core 3.1**, а этот runtime предшествует версиям библиотек,
которые поставляются в текущих релизах Debian. На Debian 12 и 13 контейнер собирается успешно,
но затем падает при первом вызове `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Сообщение вводит в заблуждение — ICU действительно установлен в этих образах, но это ICU 72 или 76, а .NET
Core 3.1 распознаёт только более старые основные версии. Кроме того, Debian 12 поставляется с OpenSSL 3, что
вызывает вторую ошибку:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` основан на Debian 11, который содержит обе версии, ожидаемые встроенным runtime:

| Пакет | Версия в Debian 11 | Зачем нужен |
|---|---|---|
| `libgdiplus` | 6.0.4 | Реализация GDI+, используемая для рендеринга фигур, текста и изображений |
| `libicu67` | 67.1 | Данные глобализации. Новые основные версии не распознаются .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Криптография. Предустановлен в Debian 11; отсутствует в Debian 12+ |
| `libfontconfig1` | — | Поиск шрифтов |

`libssl1.1` уже присутствует в базовом образе, поэтому его не требуется указывать в `apt-get install`.

Если вам необходимо использовать более новый базовый образ, установите `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`, чтобы обойти требование ICU. Это отключает форматирование, зависящее от культуры, и **не** решает проблему с OpenSSL, поэтому Debian 11 остаётся более простым вариантом.

## **Шрифты**

Облегчённые образы не содержат шрифтов вообще. Без хотя бы одного установленного шрифта текст отображается пустыми квадратами
в PDF, изображениях и HTML‑выводе. `fonts-dejavu-core` — небольшой универсальный набор для начала.

Чтобы соответствовать задуманному виду презентации, скопируйте используемые ею шрифты в образ и укажите их Aspose.Slides:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Лицензирование в контейнере**

Не включайте файл лицензии в образ — любой, кто загрузит образ, получит лицензию. Вместо этого монтируйте её
во время запуска:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Без лицензии библиотека работает в режиме оценки, который добавляет водяной знак и ограничивает количество
обрабатываемых слайдов. Смотрите [Лицензирование](/slides/ru/python-net/licensing/) для подробностей.

## **Память**

Рендеринг в PDF или изображения требует больше памяти, чем чтение файла. Контейнеры с жесткими ограничениями по памяти могут быть завершены OOM‑киллером в процессе конвертации, что обычно проявляется как исчезновение процесса без трассировки Python. Если это происходит, увеличьте лимит памяти контейнера перед тем, как расследовать код.