---
title: Instalacja
type: docs
weight: 70
url: /pl/python-java/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Zainstaluj Aspose.Slides for Python via Java w systemie Windows, Linux lub macOS, skonfiguruj Javę i JPype oraz zweryfikuj konfigurację przy użyciu działającego przykładu."
---
Aspose.Slides for Python via Java działa na systemach Windows, Linux i macOS. Używa JPype do dostępu do biblioteki Java z Pythona. Microsoft PowerPoint nie jest wymagany.

## **Wymagania wstępne**

Przed instalacją pakietów Pythona zainstaluj Pythona i JDK, które spełniają [System Requirements](/slides/pl/python-java/system-requirements/). Ta strona zawiera listę kompatybilnych wersji, wymagań architektury oraz wszelkich zależności potrzebnych do budowy JPype ze źródeł.

Ustaw `JAVA_HOME` na katalog instalacyjny JDK, a nie na jego podkatalog `bin`, oraz dodaj katalog `bin` JDK do zmiennej `PATH`. Otwórz nowy terminal po zmianie zmiennych środowiskowych.

## **Instalacja z PyPI**

Uruchom poniższe polecenia w terminalu, a nie w interaktywnym wierszu Pythona. Utwórz katalog projektu i wirtualne środowisko, aby pakiety były odizolowane od innych projektów.

### **Windows**

Przy wybranym interpreterze Pythona dostępnym jako `python` w `PATH`, uruchom poniższe polecenia w wierszu poleceń:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux i macOS**

Przy wybranej wersji Pythona dostępnej jako `python3`, uruchom poniższe polecenia w Bash lub zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

W systemach Debian lub Ubuntu, jeśli tworzenie środowiska nie powiedzie się z powodu braku `ensurepip`, zainstaluj pakiet `python3-venv` poleceniem `sudo apt-get install python3-venv`, a następnie powtórz polecenie tworzenia środowiska. Osobno zainstalowana wersja Pythona może wymagać odpowiadającego jej pakietu `venv` specyficznego dla wersji.

### **Instalacja pakietów**

Przy włączonym wirtualnym środowisku, zainstaluj JPype i Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Użycie `python -m pip` zapewnia, że pakiety są instalowane dla interpretera używanego do uruchomienia aplikacji.

Aby zaktualizować istniejącą instalację Aspose.Slides, uruchom `python -m pip install --upgrade aspose-slides-java` w tym samym środowisku.

## **Instalacja z archiwum ZIP**

Możesz również używać biblioteki z [strony pobierania Aspose.Slides](https://releases.aspose.com/slides/pl/python-java/):

1. Zainstaluj Pythona i Javę zgodnie z opisem w [Wymagania wstępne](#prerequisites).
2. Utwórz i aktywuj wirtualne środowisko, korzystając z powyższych instrukcji.
3. Zainstaluj JPype poleceniem `python -m pip install JPype1`.
4. Pobierz i rozpakuj archiwum ZIP Aspose.Slides for Python via Java.
5. Zlokalizuj rozpakowany katalog pakietu `asposeslides`. Zachowaj jego zawartość, w tym katalog `lib` i plik JAR, razem.
6. Umieść `example.py` z kolejnej sekcji obok katalogu `asposeslides`, aby Python mógł zaimportować pakiet.

## **Weryfikacja instalacji**

Zapisz poniższy kod jako `example.py`. Tworzy on prezentację z polem tekstowym i zapisuje ją jako `out.pptx` w bieżącym katalogu roboczym.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Przy włączonym wirtualnym środowisku, uruchom przykład z katalogu zawierającego `example.py`:

```sh
python example.py
```

Import `asposeslides` rejestruje dołączoną bibliotekę Java przed uruchomieniem JVM. Zaimportuj `asposeslides.api` po uruchomieniu JVM i zwolnij zasoby prezentacji przed jej zamknięciem.

{{% alert color="info" title="Uwaga" %}}
Bez licencji wynik zawiera znak wodny oceny. Zobacz [Ocena Aspose.Slides](/slides/pl/python-java/evaluate-aspose-slides/) w celu poznania ograniczeń wersji próbnej i informacji o tymczasowej licencji.
{{% /alert %}}

## **FAQ**

**Dlaczego Python zgłasza, że nie można znaleźć lub załadować JVM?**

Sprawdź, czy `JAVA_HOME` wskazuje na JDK zgodny z Twoją instalacją Pythona i JPype, zgodnie z opisem w [System Requirements](/slides/pl/python-java/system-requirements/). Zobacz [poradnik rozwiązywania problemów instalacji JPype](https://jpype.readthedocs.io/en/latest/install.html) po dodatkowe wskazówki.

**Dlaczego Python zgłasza, że brak `asposeslides` po instalacji?**

Pakiet mógł zostać zainstalowany dla innego interpretera Pythona. Aktywuj wirtualne środowisko użyte przy instalacji i uruchom `python -m pip show aspose-slides-java`. W przypadku instalacji z ZIP, upewnij się, że katalog `asposeslides` znajduje się obok Twojego skryptu lub jest dostępny w ścieżce wyszukiwania modułów Pythona.

**Czy mogę uruchamiać przykład wielokrotnie w notebooku?**

Przykład jest przeznaczony do uruchomienia w samodzielnym procesie Pythona. Przed dostosowaniem go do wielokrotnego uruchamiania w notebooku, zapoznaj się z [Ograniczenia i różnice w API](/slides/pl/python-java/limitations-and-api-differences/#import-the-library) w kwestii cyklu życia JVM i wskazówek dotyczących notebooków.

**Dlaczego pip kończy się niepowodzeniem z błędem `CERTIFICATE_VERIFY_FAILED`?**

Jeśli Twoja sieć używa proxy do inspekcji HTTPS, pip musi zaufać jego urzędowi certyfikacji. Skonfiguruj zaufany pakiet certyfikatów przy użyciu opcji `--cert` pip lub zmiennej środowiskowej `PIP_CERT`, zgodnie z [instrukcjami dotyczącymi certyfikatów HTTPS w pip](https://pip.pypa.io/en/stable/topics/https-certificates/). Wymagana konfiguracja zależy od Twojej sieci i wersji pip.