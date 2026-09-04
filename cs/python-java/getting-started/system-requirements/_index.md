---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/python-java/system-requirements/
keywords:
- systémové požadavky
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Zkontrolujte požadavky na operační systém, Python, Javu a JPype pro provoz Aspose.Slides for Python via Java na Windows, Linuxu a macOS."
---
## **Přehled**

Aspose.Slides for Python via Java vytváří, upravuje, převádí a vykresluje prezentace, aniž by byl nainstalován Microsoft PowerPoint. Používá JPype k přístupu k Java knihovně z Pythonu, takže prostředí musí podporovat Python, Javu a JPype zároveň.

## **Podporované operační systémy**

Balíček [balíček Aspose.Slides](https://pypi.org/project/aspose-slides-java/) podporuje následující rodiny operačních systémů:

- Windows
- Linux
- macOS

Vyberte verzi operačního systému, která je podporována vámi zvolenými verzemi Pythonu, Javy a JPype. Pouhá dostupnost Javy nezaručuje kompatibilitu s balíčkem Python a jeho mostem.

## **Požadavky na Python, Javu a JPype**

| Komponenta | Požadavek |
| --- | --- |
| Python | Balíček Aspose.Slides uvádí podporu Pythonu 3.7 až 3.14. Vybraná verze JPype musí podporovat stejnou verzi Pythonu; například [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) vyžaduje Python 3.8 nebo novější. |
| Java | Nainstalujte Java runtime nebo JDK kompatibilní s vybranou verzí JPype. Aktuální [požadavky JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) specifikují Javu 11 nebo novější. Java 8 nemůže spustit JPype1 1.7.1. |
| JPype | Nainstalujte balíček JPype1 pro váš Python interpreter, operační systém a architekturu CPU. |
| CPU architektura | Python a Java Virtual Machine (JVM) musí používat shodné architektury. Například 64‑bitový interpreter Pythonu vyžaduje kompatibilní 64‑bitovou JVM. |

Na Apple Silicon musí Python i Java používat buď ARM64, nebo oba x64. JVM, který běží samostatně, může stále selhat při načítání přes JPype, pokud se jeho architektura liší od Pythonu.

Pro nové prostředí jsou vhodným výchozím bodem Python 3.12, JDK 17 a JPype1 1.7.1. Tato kombinace byla ověřena s Aspose.Slides for Python via Java 26.6.0 na Windows. Ostatní kombinace musí splňovat požadavky všech tří komponent.

Pro nastavení prostředí a funkční ověřovací příklad viz [Instalace](/slides/cs/python-java/installation/).

## **Další závislosti**

Kompatibilní předkompilovaný JPype wheel nevyžaduje C++ kompilátor. Pokud je JPype nutné sestavit ze zdrojového kódu, nainstalujte kompatibilní C++ kompilátor a soubory vývoje Pythonu požadované vaším platformou. Podívejte se na [instrukce instalace JPype](https://jpype.readthedocs.io/en/latest/install.html) pro požadavky na sestavení a řešení problémů.

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint?**

Ne. Aspose.Slides zpracovává prezentace nezávisle na PowerPointu. Python, Java a JPype jsou stále vyžadovány.

**Mohu použít Python 3.7 s libovolnou verzí JPype?**

Ne. I když balíček Aspose.Slides uvádí podporu Pythonu 3.7, JPype1 1.7.1 vyžaduje Python 3.8 nebo novější. Vyberte verze, jejichž požadavky se překrývají.

**Mohu kombinovat 32‑bitový Python s 64‑bitovou Javou?**

Ne. JPype načítá JVM do procesu Pythonu, takže Python a Java musí mít shodné architektury. Stejný požadavek platí pro ARM64 a x64 na macOS.