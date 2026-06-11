---
title: Kompatybilność z PyInstaller i cx_Freeze
linktitle: Kompatybilność z PyInstaller
type: docs
weight: 122
url: /pl/python-net/compatibility-with-pyinstaller/
keywords:
- kompatybilność
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Spakuj Aspose.Slides for Python via .NET przy użyciu PyInstaller. Postępuj zgodnie z tym przewodnikiem, aby złożyć, skonfigurować i rozwiązać problemy w swojej aplikacji, tworząc samodzielny plik wykonywalny."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET są standardowymi rozszerzeniami C Pythona, więc mogą być zamrażane jako zależności programu przy użyciu narzędzi takich jak PyInstaller i cx_Freeze (lub podobnych). Umożliwia to tworzenie plików wykonywalnych z Twoich skryptów Pythona. Takie narzędzia nazywane są „freezerami”, ponieważ pakują Twój kod i jego zależności w jeden plik dystrybuowalny, który działa na innych komputerach bez konieczności instalacji Pythona ani dodatkowych bibliotek. Podejście to upraszcza rozpowszechnianie aplikacji Pythona.

Zamrażanie rozszerzenia Aspose.Slides for Python via .NET jako zależności przedstawiono poniżej przy użyciu prostego programu wykorzystującego Aspose.Slides.

## **PyInstaller**

Zazwyczaj nie jest wymagane nic szczególnego przy pakowaniu programu zależnego od rozszerzenia Aspose.Slides for Python via .NET. Gdy program importuje rozszerzenie w sposób widoczny dla PyInstaller, rozszerzenie zostanie dołączone do programu. Ponieważ Aspose.Slides for Python via .NET zawiera hooki PyInstaller, jego zależności są automatycznie wykrywane i kopiowane do pakietu.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Jednak PyInstaller może czasami pominąć ukryte importy — moduły importowane dynamicznie lub pośrednio przez Twój kod. Aby dodać ukryty import, użyj opcji PyInstaller. Zależności rozszerzenia są określone w hookach PyInstaller dostarczanych wraz z Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Aby zamrozić program przy użyciu cx_Freeze, skonfiguruj go tak, aby zawierał główny pakiet rozszerzenia Aspose.Slides for Python via .NET, którego używasz. Zapewnia to, że rozszerzenie i wszystkie zależne moduły zostaną skopiowane do builda razem z Twoją aplikacją.

### **Używanie skryptu cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Używanie skryptu Setup**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint lub .NET na komputerze użytkownika?**

Nie, PowerPoint nie jest wymagany. Aspose.Slides jest samodzielnym silnikiem; pakiet Python dostarcza wszystko, co jest potrzebne, jako rozszerzenie dla CPython. Użytkownik nie musi instalować .NET oddzielnie.

**Jak prawidłowo dołączyć licencję do zamrożonej aplikacji?**

Możesz przechowywać plik XML licencji obok pliku wykonywalnego lub osadzić go jako zasób i wczytać z dostępnej ścieżki przed pierwszym wywołaniem API. Ważne: nie modyfikuj zawartości XML (nawet nie zmieniaj podziału linii).

**Co zrobić, jeśli czcionki renderują się inaczej po buildzie niż w środowisku deweloperskim?**

Upewnij się, że używane czcionki są dostępne w docelowym środowisku (zawarte w pakiecie lub zainstalowane w systemie) oraz że ich ścieżki są prawidłowo rozwiązywane w czasie wykonywania; zachowanie czcionek jest szczególnie wrażliwe na Linuksie.