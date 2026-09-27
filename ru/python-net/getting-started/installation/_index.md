---
title: Установка
type: docs
weight: 70
url: /ru/python-net/installation/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Установите Aspose.Slides for Python via .NET из PyPI с помощью pip на Windows, Linux и macOS, а также установите нативные библиотеки, необходимые для Linux и macOS."
---
## **Обзор**

Эта статья объясняет, как установить Aspose.Slides for Python via .NET на Windows, Linux и macOS. Пакет размещён на [PyPI](https://pypi.org/project/aspose.slides/) и устанавливается с помощью pip. Он включает .NET runtime, который использует, поэтому вам не требуется устанавливать .NET. На Linux и macOS этот runtime требует нативных библиотек, которые может не включать операционная система; ниже перечислены эти библиотеки.

Aspose.Slides for Python via .NET поддерживает Python 3.5‑3.14. PyPI предоставляет пакеты для Windows (32‑бит и 64‑бит), Linux (x86_64 и ARM64) и macOS (Intel и Apple silicon).

## **Windows**

В Windows установите пакет с помощью pip. Другие библиотеки не требуются.

```bash
pip install aspose.slides
```

## **Linux**

В Linux .NET runtime, включённый в пакет, требует две библиотеки:

- **libgdiplus**, реализация Windows GDI+ API. Без неё сохранение презентации завершится ошибкой `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Без неё процесс Python завершается при первом вызове Aspose.Slides с сообщением `Couldn't find a valid ICU package installed on the system`.

В Debian и Ubuntu установите обе библиотеки с помощью apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Имя пакета ICU содержит номер версии: `libicu76` — пакет для Debian 13. В Debian 12 устанавливайте `libicu72`, а в Ubuntu 24.04 — `libicu74`. Чтобы узнать имя пакета в вашей системе, выполните:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Затем установите пакет в виртуальное окружение. В текущих выпусках Debian и Ubuntu системный Python не позволяет выполнять `pip install` вне виртуального окружения и прерывается ошибкой `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Запускайте свои скрипты с активированным тем же виртуальным окружением. Если вы используете Python, который не управляется вашим дистрибутивом (например, в официальных образах Docker `python`), вы также можете выполнить `pip install aspose.slides` без виртуального окружения.

Шрифты, используемые в ваших презентациях, или подходящие их заменители, должны быть установлены в системе, чтобы текст корректно отображался при конвертации слайдов в PDF или изображения.

## **macOS**

Мы не проверяли установку на macOS. На macOS Aspose.Slides требует следующих предварительных условий:

- **Python с общими библиотеками**, то есть Python, собранный с опцией конфигурации `--enable-shared`. Если вы устанавливаете Python через [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), задайте переменную окружения `PYTHON_CONFIGURE_OPTS` со значением `--enable-shared` при установке версии Python.
- **Библиотека libpython в системном каталоге библиотек.** Python, установленный через pyenv, хранит свою libpython‑библиотеку (например, *libpython3.9.dylib*) в *~/.pyenv/versions*; создайте символьную ссылку на неё в */usr/local/lib*.
- **libgdiplus**, реализация Windows GDI+ API. Homebrew предоставляет её в пакете `mono-libgdiplus`.

Затем установите пакет с помощью pip.

## **Проверка установки**

Чтобы проверить установку, сохраните первый пример из [Create Presentations](/slides/ru/python-net/create-presentation/) как *hello.py* и выполните `python hello.py`. Он создаст *new_presentation.pptx* в текущем каталоге.

## **Обновление**

Чтобы обновить существующую установку до последней версии, выполните эту команду в окружении, где был установлен пакет:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Могу ли я установить Aspose.Slides в виртуальном окружении?**

Да. Вы можете установить его в любом виртуальном окружении Python с помощью pip. Нативные библиотеки, необходимые для Linux и macOS, устанавливаются в системе, а не в виртуальном окружении.

**Могу ли я использовать Aspose.Slides в контейнерах Docker?**

Да. Образ должен включать те же нативные библиотеки, что и Linux‑система — libgdiplus и ICU — а также шрифты, используемые в ваших презентациях.

**Существует ли бесплатная версия или ограничения пробной версии?**

Да. Без лицензии Aspose.Slides работает в режиме оценки: на каждый сохраняемый слайд добавляется водяной знак «evaluation», а текст, считываемый из презентаций, обрезается. Чтобы снять эти ограничения, примените действительную [license](/slides/ru/python-net/licensing/).