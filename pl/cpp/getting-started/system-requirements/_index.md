---
title: Wymagania systemowe
type: docs
weight: 80
url: /pl/cpp/system-requirements/
keywords:
- wymagania systemowe
- system operacyjny
- instalacja
- zależności
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj wymagania systemowe Aspose.Slides for C++. Zapewnij płynne wsparcie dla PowerPoint i OpenDocument w systemach Windows, Linux i macOS."
---
## **Wprowadzenie**

Aspose.Slides nie wymaga zainstalowanego programu Microsoft PowerPoint, ponieważ Aspose.Slides jest niezależnym silnikiem do tworzenia, konwertowania, układania i renderowania dokumentów Microsoft PowerPoint.

## **Obsługiwane systemy operacyjne**
Aspose.Slides for C++ jest natywną biblioteką C++. Aspose.Slides for C++ obsługuje następujące systemy operacyjne i platformy 64‑bitowe oraz 32‑bitowe:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- System operacyjny Ubuntu 16.04 lub nowszy.
- CentOS 8 lub nowszy.
- Fedora 24 lub nowszy.
- I inne systemy Linux x86_64 z glibc 2.23 lub nowszym.

### **macOS**
- macOS Monterey 12.1 lub nowszy.

## **Środowiska programistyczne**
Możesz używać Aspose.Slides for C++ przy tworzeniu aplikacji na systemy Windows, Linux lub macOS.

### **Windows**
- Microsoft Visual Studio 2017 lub nowszy.
- CMake 3.18 lub nowszy.

### **Linux**
- Clang 3.9 lub nowszy.
- GCC 6.1 lub nowszy.
- CMake 3.18 lub nowszy.

### **macOS**
- Xcode 13.4 lub nowszy.

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany; Aspose.Slides jest samodzielnym silnikiem do [tworzenia](/slides/pl/cpp/create-presentation/), modyfikacji, [konwertowania](/slides/pl/cpp/convert-presentation/) oraz [renderowania](/slides/pl/cpp/convert-powerpoint-to-png/) prezentacji.

**Jakie czcionki są potrzebne do prawidłowego renderowania?**

W praktyce, czcionki użyte w prezentacji lub odpowiednie [zastępniki](/slides/pl/cpp/font-substitution/) muszą być dostępne. Aby zapewnić spójne renderowanie w systemach Linux/macOS, zaleca się zainstalowanie popularnych pakietów czcionek.

**Dlaczego niestandardowa czcionka jest renderowana jako zapasowa lub brakujący tekst w systemie Linux?**

Jeśli plik czcionki zawiera niezgodne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek w Linux (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje, że czcionka nie zostanie rozpoznana. Użycie wersji czcionki z poprawionymi rekordami tabeli nazw lub zainstalowanie spójnego zamiennika rozwiązuje problem.