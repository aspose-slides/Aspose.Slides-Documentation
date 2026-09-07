---
title: FAQ
type: docs
weight: 340
url: /pl/python-java/faqs/
keywords:
- FAQ
- format prezentacji
- błąd braku pamięci
- rozmiar slajdu
- wyodrębnianie tekstu
- rozmiar akapitu
- obramowania tabeli
- czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Znajdź odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides for Python via Java, w tym formatów plików, wykorzystania pamięci, rozmiarów slajdów, tekstu, tabel, obrazów i czcionek."
---
## **Przegląd**

To FAQ obejmuje obsługiwane formaty plików, wykorzystanie pamięci przy dużych prezentacjach, rozmiary i podglądy slajdów, wyodrębnianie tekstu, obramowania tabel, umieszczanie obrazów oraz różnice w czcionkach przy konwertowaniu prezentacji do PDF lub obrazów.

## **FAQ**

### **Obsługiwane formaty plików**

**Jakie formaty plików obsługuje Aspose.Slides for Python via Java?**

Zobacz [Supported File Formats](/slides/pl/python-java/supported-file-formats/) aby poznać obsługiwane formaty prezentacji, dokumentów i obrazów oraz ich możliwości importu i eksportu.

### **Wyjątki**

**Dlaczego otrzymuję błąd braku pamięci podczas ładowania dużej prezentacji z obrazami? Czy istnieje limit rozmiaru pliku?**

Nie ma jednego progu rozmiaru pliku, który przewidywałby, czy prezentacja zmieści się w pamięci. Wymagania pamięciowe zależą od struktury prezentacji, zdekompresowanych obrazów, efektów oraz wykonywanych operacji. Obrazy mogą zajmować znacznie więcej pamięci niż ich skompresowany rozmiar na dysku.

Aspose.Slides for Python via Java używa silnika Java poprzez JPype, więc sterta JVM musi mieć wystarczającą ilość miejsca do przetwarzania. Dostępna pamięć RAM systemu nie wskazuje, ile pamięci może wykorzystać JVM. Zwolnij prezentacje za pomocą [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose) po zakończeniu ich używania. Aby skonfigurować środowisko, zobacz [Wymagania systemowe](/slides/pl/python-java/system-requirements/) oraz [Instalacja](/slides/pl/python-java/installation/).

### **Praca ze slajdami**

**Czy mogę zmienić rozmiar slajdów w prezentacji?**

Tak. Użyj [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getslidesize), aby uzyskać dostęp do ustawień rozmiaru slajdów w prezentacji, a następnie [SlideSize.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/#setsize), aby ustawić wymiary i wybrać, jak skalować istniejącą treść.

**Czy slajdy w tej samej prezentacji mogą mieć różne rozmiary?**

Nie. Dokumenty Microsoft PowerPoint określają rozmiar slajdu na poziomie prezentacji, więc wszystkie slajdy mają te same wymiary.

**Czy mogę podglądnąć slajd przed zapisaniem prezentacji?**

Tak. Wyrenderuj slajd jako obraz i wyświetl ten obraz w swojej aplikacji. Nie musisz najpierw zapisywać prezentacji.

### **Praca z tekstem**

**Czy mogę pobrać cały tekst z prezentacji?**

Tak. Klasa [SlideUtil](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/) udostępnia metody do pobierania tekstu z prezentacji oraz poszczególnych slajdów.

**Dlaczego rozmiary akapitów różnią się w systemach Windows i Linux?**

Wymiary akapitu zależą od metryk czcionek używanych do renderowania tekstu. Jeśli czcionka jest brakująca, substytut może mieć inne szerokości znaków i wysokości linii, co zmienia zawijanie tekstu i wymiary akapitu. Zainstaluj te same czcionki na obu systemach lub załaduj te same pliki czcionek za pomocą [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadexternalfonts) przed tworzeniem lub ładowaniem prezentacji.

### **Formatowanie i obrazy**

**Jak mogę ustawić kolor obramowania tabeli?**

Użyj [Cell.getCellFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/#getcellformat), aby uzyskać dostęp do formatowania obramowania każdej komórki i ustawić kolor wypełnienia odpowiednich obramowań. Aby zmienić wszystkie obramowania, przetwórz wszystkie komórki. Aby zmienić tylko kontur tabeli, zaktualizuj jedynie obramowania skierowane na zewnątrz komórek znajdujących się na jej krawędziach.

**Jakie jednostki są używane do pozycjonowania i wymiarowania obrazów?**

Współrzędne i wymiary kształtów mierzone są w punktach. Jeden cal to 72 punkty; wartości te nie są współrzędnymi pikseli.

### **Praca z czcionkami**

**Dlaczego czcionki zmieniają się podczas konwersji prezentacji do PDF lub obrazów?**

Wymagane czcionki mogą być nieobecne na maszynie wykonującej konwersję. Zainstaluj oryginalne czcionki lub użyj [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadexternalfonts), aby dodać foldery je zawierające. Załaduj czcionki zewnętrzne przed tworzeniem lub otwieraniem prezentacji.

Poniższy przykład rejestruje folder czcionek. Zamień ścieżkę na istniejący folder zawierający Twoje pliki czcionek. Zakłada on środowisko opisane w [Instalacja](/slides/pl/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Przykład pozostawia działającą maszynę JVM dla kolejnych operacji na prezentacjach. Aby uzyskać informacje o używaniu w notebooku i ograniczeniach cyklu życia JVM, zobacz [Ograniczenia i różnice API](/slides/pl/python-java/limitations-and-api-differences/).