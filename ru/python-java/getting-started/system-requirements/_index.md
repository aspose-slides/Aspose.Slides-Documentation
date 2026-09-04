---
title: Системные требования
type: docs
weight: 60
url: /ru/python-java/system-requirements/
keywords:
- системные требования
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Проверьте требования к операционной системе, Python, Java и JPype для запуска Aspose.Slides for Python via Java на Windows, Linux и macOS."
---
## **Обзор**

Aspose.Slides for Python via Java создает, изменяет, конвертирует и визуализирует презентации без установки Microsoft PowerPoint. Он использует JPype для доступа к Java‑библиотеке из Python, поэтому среда должна поддерживать Python, Java и JPype одновременно.

## **Поддерживаемые операционные системы**

Пакет [Aspose.Slides](https://pypi.org/project/aspose-slides-java/) поддерживает следующие семейства операционных систем:

- Windows
- Linux
- macOS

Выберите версию операционной системы, поддерживаемую выбранными версиями Python, Java и JPype. Наличие только Java не гарантирует совместимость с пакетом Python и его мостом.

## **Требования к Python, Java и JPype**

| Component | Requirement |
| --- | --- |
| Python | Пакет Aspose.Slides объявляет поддержку Python 3.7–3.14. Выбранный релиз JPype должен поддерживать ту же версию Python; например, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) требует Python 3.8 или новее. |
| Java | Установите среду выполнения Java или JDK, совместимые с выбранным релизом JPype. Текущие [требования JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) указывают на Java 11 или новее. Java 8 не может запускать JPype1 1.7.1. |
| JPype | Установите пакет JPype1 для вашего интерпретатора Python, операционной системы и архитектуры процессора. |
| CPU architecture | Python и Java Virtual Machine (JVM) должны использовать совпадающие архитектуры. Например, 64‑разрядный интерпретатор Python требует совместимую 64‑разрядную JVM. |

На Apple Silicon Python и Java должны оба использовать ARM64 или оба использовать x64. JVM, работающая независимо, всё равно может не загрузиться через JPype, если её архитектура отличается от архитектуры Python.

Для новой среды подходящим отправным пунктом являются Python 3.12, JDK 17 и JPype1 1.7.1. Эта комбинация была проверена с Aspose.Slides for Python via Java 26.6.0 на Windows. Другие комбинации должны удовлетворять требованиям всех трёх компонентов.

Для настройки среды и примера рабочей проверки см. [Установка](/slides/ru/python-java/installation/).

## **Дополнительные зависимости**

Совместное готовое колесо JPype не требует C++ компилятора. Если JPype необходимо собрать из исходного кода, установите совместимый C++ компилятор и файлы разработки Python, требуемые для вашей платформы. См. [инструкции по установке JPype](https://jpype.readthedocs.io/en/latest/install.html) для требований к сборке и устранения неполадок.

## **FAQ**

**Нужен ли мне установленный Microsoft PowerPoint?**

Нет. Aspose.Slides обрабатывает презентации независимо от PowerPoint. По‑прежнему требуются Python, Java и JPype.

**Могу ли я использовать Python 3.7 с любой версией JPype?**

Нет. Хотя пакет Aspose.Slides объявляет поддержку Python 3.7, JPype1 1.7.1 требует Python 3.8 или новее. Выбирайте версии, требования которых перекрываются.

**Можно ли сочетать 32‑разрядный Python с 64‑разрядной Java?**

Нет. JPype загружает JVM в процесс Python, поэтому Python и Java должны иметь одинаковую архитектуру. То же требование применяется к ARM64 и x64 на macOS.