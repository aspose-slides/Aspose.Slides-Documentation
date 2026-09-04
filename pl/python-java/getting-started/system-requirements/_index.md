---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/python-java/system-requirements/
keywords:
- wymagania systemowe
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Sprawdź wymagania systemu operacyjnego, Pythona, Javy i JPype niezbędne do uruchomienia Aspose.Slides for Python via Java w systemach Windows, Linux i macOS."
---
## **Przegląd**

Aspose.Slides for Python via Java tworzy, modyfikuje, konwertuje i renderuje prezentacje bez zainstalowanego Microsoft PowerPoint. Używa JPype do dostępu do biblioteki Java z Pythona, dlatego środowisko musi jednocześnie obsługiwać Python, Java i JPype.

## **Obsługiwane systemy operacyjne**

Pakiet [Aspose.Slides](https://pypi.org/project/aspose-slides-java/) obsługuje następujące rodziny systemów operacyjnych:

- Windows
- Linux
- macOS

Wybierz wersję systemu operacyjnego obsługiwaną przez wybrane wersje Pythona, Javy i JPype. Dostępność samej Javy nie zapewnia zgodności z pakietem Pythona i jego mostem.

## **Wymagania dotyczące Pythona, Javy i JPype**

| Komponent | Wymaganie |
| --- | --- |
| Python | Pakiet Aspose.Slides deklaruje obsługę Pythona w wersjach od 3.7 do 3.14. Wybrana wersja JPype musi obsługiwać tę samą wersję Pythona; na przykład JPype1 1.7.1 wymaga Pythona 3.8 lub nowszego. |
| Java | Zainstaluj środowisko uruchomieniowe Java lub JDK kompatybilne z wybraną wersją JPype. Aktualne wymagania JPype określają Java 11 lub nowszą. Java 8 nie może uruchomić JPype1 1.7.1. |
| JPype | Zainstaluj pakiet JPype1 dla swojego interpretera Pythona, systemu operacyjnego i architektury CPU. |
| Architektura CPU | Python i wirtualna maszyna Java (JVM) muszą używać zgodnych architektur. Na przykład 64‑bitowy interpreter Pythona wymaga kompatybilnej 64‑bitowej JVM. |

Na Apple Silicon Python i Java muszą używać zarówno ARM64, jak i x64. JVM działająca niezależnie może nadal nie załadować się przez JPype, jeśli jej architektura różni się od architektury Pythona.

Dla nowego środowiska odpowiednym punktem wyjścia są Python 3.12, JDK 17 i JPype1 1.7.1. Ta kombinacja została zweryfikowana z Aspose.Slides for Python via Java 26.6.0 na systemie Windows. Inne kombinacje muszą spełniać wymagania wszystkich trzech komponentów.

Aby skonfigurować środowisko i zobaczyć działający przykład weryfikacyjny, zobacz [Instalacja](/slides/pl/python-java/installation/).

## **Dodatkowe zależności**

Kompatybilny gotowy pakiet JPype nie wymaga kompilatora C++. Jeśli JPype musi być budowany ze źródeł, zainstaluj kompatybilny kompilator C++ oraz pliki rozwojowe Pythona wymagane przez Twoją platformę. Zobacz [instrukcje instalacji JPype](https://jpype.readthedocs.io/en/latest/install.html) w celu poznania wymagań budowania i rozwiązywania problemów.

## **FAQ**

**Czy muszę mieć zainstalowany Microsoft PowerPoint?**

Nie. Aspose.Slides przetwarza prezentacje niezależnie od PowerPointa. Python, Java i JPype wciąż są wymagane.

**Czy mogę używać Pythona 3.7 z dowolną wersją JPype?**

Nie. Chociaż pakiet Aspose.Slides deklaruje wsparcie dla Pythona 3.7, JPype1 1.7.1 wymaga Pythona 3.8 lub nowszego. Wybierz wersje, których wymagania się pokrywają.

**Czy mogę mieszać 32‑bitowego Pythona z 64‑bitową Javą?**

Nie. JPype ładuje JVM do procesu Pythona, więc Python i Java muszą mieć zgodne architektury. To samo wymóg obowiązuje dla ARM64 i x64 w systemie macOS.