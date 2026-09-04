---
title: Ograniczenia i różnice w API
type: docs
weight: 100
url: /pl/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- Różnice w API
- Python
- Java
- JPype
- Ograniczenia JVM
- PowerPoint
description: "Dowiedz się o ograniczeniach JVM i różnicach w API między Aspose.Slides dla Java a Python via Java, w tym o importach, czyszczeniu zasobów i obsłudze plików."
---
## **Przegląd**

Aspose.Slides for Python via Java używa JPype do uzyskania dostępu do biblioteki Java z Pythona. Poniższe przykłady porównują importy pakietów, tworzenie prezentacji oraz obsługę plików w obu interfejsach API.

## **Znane ograniczenia**

- **Cykl życia JVM:** JPype obsługuje jedną JVM na proces Pythona. Po jej zamknięciu nie można jej ponownie uruchomić w tym samym procesie. Uruchom ją raz i używaj ponownie dla kolejnych operacji na prezentacjach.
- **Kompatybilność architektur:** Python i Java muszą mieć zgodne architektury. Zobacz [Wymagania systemowe](/slides/pl/python-java/system-requirements/#python-java-and-jpype-requirements) po szczegóły.

Zobacz [Przewodnik użytkownika JPype](https://jpype.readthedocs.io/en/latest/userguide.html) po szczegóły dotyczące tych ograniczeń i interoperacyjności Java.

## **Różnice w publicznym API**

Porównaj poniższe przykłady w Java i Pythonie. Szczegóły członków Python via Java znajdziesz w [API Reference](/slides/pl/python-java/api-reference/).

### **Import biblioteki**

Java importuje klasy z `com.aspose.slides`. W Pythonie importuj `asposeslides` przed uruchomieniem JVM, a następnie klasy z `asposeslides.api` po uruchomieniu JVM. Użyj [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) aby uniknąć uruchamiania już działającej JVM.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Przykłady w Pythonie pozostawiają JVM uruchomioną aż do zakończenia procesu Pythona. W notatniku użyj tej samej aktywnej JVM w kolejnych komórkach. Jeśli została już zamknięta, uruchom ponownie kernel notatnika przed ponownym użyciem obiektów Java.
{{% /alert %}}

### **Utworzenie prezentacji**

Java używa słowa kluczowego `new`; Python wywołuje klasę [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) bezpośrednio. Zwolnij zasoby prezentacji za pomocą [Presentation.dispose](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#dispose) w bloku `finally`.

Oba przykłady zapisują pustą prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) i [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Odczyt plików i użycie stałych formatów**

Java może wczytać prezentację z strumienia wejściowego Java. W Pythonie odczytaj plik jako dane binarne i przekaż uzyskane bajty do [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#createpresentationfrombytes). Obiekt pliku Pythona nie jest strumieniem wejściowym Java.

Poniższe przykłady wymagają istniejącego `presentation.pptx` w katalogu roboczym i zapisują kopię jako `result.pptx`. Oba zamykają plik wejściowy i zwalniają zasoby prezentacji. Przykład w Pythonie wczytuje cały plik wejściowy do pamięci.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy muszę ponownie uruchamiać JVM dla każdej prezentacji?**

Nie. Nie zamykaj JVM i twórz oraz zwalniaj obiekty prezentacji w razie potrzeby. Wyłączenie JVM uniemożliwia dalsze operacje Java w tym samym procesie Pythona.

**Czy mogę otworzyć prezentację bezpośrednio z ścieżki pliku?**

Tak. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) akceptuje ścieżkę do pliku. Użyj pomocy opartej na bajtach, gdy dane prezentacji są już dostępne jako bajty Pythona.

**Czy powinienem zmieniać nazwy stałych formatów przy tłumaczeniu przykładów Java na Python?**

Nie. Na przykład [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#pptx) używa takiej samej pisowni i kapitalizacji w obu API.