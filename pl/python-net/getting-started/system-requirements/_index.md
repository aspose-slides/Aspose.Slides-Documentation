---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/python-net/system-requirements/
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
- Python
- Aspose.Slides
description: "Odkryj wymagania systemowe Aspose.Slides for Python via .NET. Zapewnij płynne wsparcie PowerPoint i OpenDocument na Windows, Linux i macOS."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET nie wymaga instalacji żadnych produktów firm trzecich, takich jak Microsoft PowerPoint. Aspose.Slides jest silnikiem do tworzenia, modyfikowania, konwertowania i renderowania dokumentów w różnych formatach, w tym w formatach prezentacji Microsoft PowerPoint.

## **Obsługiwane systemy operacyjne**

Aspose.Slides for Python obsługuje Windows (32‑bit i 64‑bit), macOS oraz 64‑bitowy Linux na systemach z zainstalowanym Pythonem 3.5 lub nowszym.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">System operacyjny</td>
        <td style="font-weight: bold; width:400px">Wersje</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>i inne</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Wymagania systemowe dla docelowych platform Linux i macOS**

- Biblioteki uruchomieniowe GCC 6 (lub nowsze).
- [libgdiplus](https://github.com/mono/libgdiplus), otwarto‑źródłowa implementacja interfejsu API GDI+.
- Zależności środowiska uruchomieniowego .NET Core. Instalacja samego .NET Core Runtime nie jest wymagana.
- Dla Pythona 3.5‑3.7 wymagane jest zbudowanie Pythona z `pymalloc`. Opcja kompilacji `--with-pymalloc` jest włączona domyślnie. Zazwyczaj wersja Pythona z `pymalloc` ma w nazwie pliku przyrostek `m`.
- Biblioteka współdzielona `libpython`. Opcja kompilacji Pythona `--enable-shared` jest domyślnie wyłączona, a niektóre dystrybucje Pythona nie zawierają biblioteki `libpython`. Na niektórych platformach Linux można zainstalować bibliotekę `libpython` przy użyciu menedżera pakietów (np. `sudo apt-get install libpython3.7`). Częstym problemem jest instalacja biblioteki `libpython` w niestandardowej lokalizacji bibliotek współdzielonych. Można to rozwiązać, używając opcji kompilacji Pythona do ustawienia alternatywnych ścieżek bibliotek podczas kompilacji lub tworząc dowiązanie symboliczne do pliku biblioteki `libpython` w standardowej lokalizacji systemowej. Zazwyczaj nazwa pliku biblioteki współdzielonej `libpython` to `libpythonX.Ym.so.1.0` dla Pythona 3.5‑3.7 lub `libpythonX.Y.so.1.0` dla Pythona 3.8 i nowszych (np. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany; Aspose.Slides jest samodzielnym silnikiem do [tworzenia](/slides/pl/python-net/create-presentation/), modyfikowania, [konwertowania](/slides/pl/python-net/convert-presentation/) i [renderowania](/slides/pl/python-net/convert-powerpoint-to-png/) prezentacji.

**Czy wymagana jest określona wersja .NET (Core/5+/6+) na maszynie?**

Instalacja samego środowiska uruchomieniowego .NET nie jest wymagana, ale jego zależności muszą być obecne na Linux/macOS. Oznacza to, że system powinien zawierać pakiety zwykle instalowane jako zależności .NET, bez pełnej instalacji środowiska uruchomieniowego.

**Jakie czcionki są potrzebne do prawidłowego renderowania?**

W praktyce muszą być dostępne czcionki użyte w prezentacji lub odpowiednie [zastępniki](/slides/pl/python-net/font-substitution/). Aby zapewnić spójne renderowanie na Linux/macOS, zaleca się zainstalowanie popularnych pakietów czcionek.

**Dlaczego niestandardowa czcionka jest renderowana jako zamiennik lub brakujący tekst na Linuxie?**

Jeśli plik czcionki zawiera niespójne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek w Linuxie (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje, że czcionka nie zostaje rozpoznana. Użycie wersji czcionki z poprawionymi wpisami w tabeli nazw lub zainstalowanie spójnego zamiennika rozwiązuje problem.