---
title: Instalacja
type: docs
weight: 70
url: /pl/python-net/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- macOS
- Python
description: "Dowiedz się, jak szybko zainstalować Aspose.Slides for Python via .NET. Przewodnik krok po kroku, wymagania systemowe i przykłady kodu — rozpocznij pracę z prezentacjami PowerPoint już dziś!"
---
## **Przegląd**

Pakiet Aspose.Slides for Python via .NET zawiera wszystkie niezbędne biblioteki .NET, co oznacza, że nie ma potrzeby instalowania .NET oddzielnie. Ułatwia to proces konfiguracji i pozwala programistom od razu rozpocząć pracę z prezentacjami. Należy jednak pamiętać, że w zależności od systemu operacyjnego lub środowiska może być konieczne zainstalowanie niektórych zależności specyficznych dla platformy wymaganych przez .NET. Dodatkowo, należy spełnić określone wymagania systemowe, aby zapewnić pełną kompatybilność i prawidłowe działanie pakietu.

## **Windows**

**Wymagania systemowe**

Sprawdź i upewnij się, że specyfikacje Twojego komputera spełniają lub przewyższają [wymagania systemowe](/slides/pl/python-net/system-requirements/).

### **Instalacja Aspose.Slides**

`pip` jest najprostszym sposobem pobrania i instalacji [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) w systemie Windows.

Aby zainstalować Aspose.Slides, uruchom następujące polecenie:

```sh
pip install aspose-slides
```

**Użycie Aspose.Slides**

Przetestuj swoją instalację Aspose.Slides, uruchamiając poniższy kod, aby utworzyć prezentację PowerPoint:

```python
# Importuj moduł Aspose.Slides dla Pythona via .NET.
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Wymagania systemowe**

Sprawdź i upewnij się, że specyfikacje Twojego komputera spełniają lub przewyższają [wymagania systemowe](/slides/pl/python-net/system-requirements/).

### **Wymagania wstępne**

**Python z bibliotekami współdzielonymi**

Istnieje kilka sposobów instalacji Pythona w systemie macOS, ale zdecydowanie zalecamy użycie [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

Po zainstalowaniu i skonfigurowaniu **pyenv**, zainstaluj Pythona z bibliotekami współdzielonymi, uruchamiając następujące polecenia w aplikacji Terminal:

1. Zainstaluj Pythona:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Ustaw go jako globalną wersję Pythona:

```sh
pyenv global 3.9.13
```

3. Ustaw go jako wersję Pythona specyficzną dla powłoki:

```sh
pyenv shell 3.9.13
```

4. Utwórz dowiązanie symboliczne do biblioteki libpython w katalogu systemowym bibliotek:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Uwaga: wymagany jest Python 3.5 lub nowszy. Wersja 3.9.13 jest użyta tutaj wyłącznie jako przykład.

**Instalacja biblioteki libgdiplus**

Biblioteka **libgdiplus** jest implementacją Windows GDI+ dla systemów macOS i Linux, z której .NET korzysta do funkcji graficznych na tych platformach.
Aby zainstalować tę bibliotekę w systemie macOS, uruchom następujące polecenie:

```sh
brew install mono-libgdiplus
```

### **Instalacja Aspose.Slides**

`pip` jest najprostszym sposobem pobrania i instalacji [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) w systemie macOS.

Aby zainstalować Aspose.Slides, uruchom następujące polecenie:

```sh
pip install aspose-slides
```

**Użycie Aspose.Slides**

Przetestuj swoją instalację Aspose.Slides, uruchamiając poniższy kod, aby utworzyć prezentację PowerPoint:

```python
# Importuj moduł Aspose.Slides dla Pythona via .NET.
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zainstalować Aspose.Slides w środowisku wirtualnym?**

Tak, możesz zainstalować go w dowolnym wirtualnym środowisku Pythona przy użyciu `pip`. Upewnij się tylko, że środowisko ma dostęp do wymaganych natywnych zależności w zależności od systemu operacyjnego.

**Czy mogę używać Aspose.Slides w kontenerach Docker?**

Tak, ale musisz upewnić się, że Twój obraz Docker zawiera wymagane natywne biblioteki (**libgdiplus**, pakiety czcionek itp.) oraz odpowiednią wersję Pythona.

**Czy istnieje wersja darmowa lub ograniczenia wersji próbnej?**

Tak, domyślnie Aspose.Slides działa w trybie ewaluacyjnym, który dodaje znaki wodne i może mieć inne ograniczenia. Aby usunąć ograniczenia, musisz zastosować ważną [licencję](/slides/pl/python-net/licensing/).