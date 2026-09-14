---
title: Usprawnij zastępowanie czcionek w prezentacjach przy użyciu Pythona w środowisku Java
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/python-java/font-replacement/
keywords:
- czcionka
- zamień czcionkę
- zastępowanie czcionki
- zmień czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides dla Pythona poprzez Java, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala zastąpić jedną czcionkę inną w całej prezentacji. Gdy czcionka zostaje zamieniona, wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zamianę czcionek, załaduj prezentację, określ czcionkę źródłową i czcionkę zastępującą, wywołaj metodę zamiany czcionek i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy zamierzasz celowo przełączyć się z jednej rodziny czcionek na inną w całej prezentacji.

## **Zamiana czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zamianę czcionki w następujący sposób:

1. Załaduj odpowiednią prezentację. 
2. Załaduj czcionkę, którą chcesz zastąpić.
3. Załaduj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w języku Python demonstruje zamianę czcionek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Załaduj prezentację.
presentation = Presentation("Fonts.pptx")
try:
    # Załaduj czcionkę źródłową, która zostanie zastąpiona.
    source_font = FontData("Arial")

    # Załaduj nową czcionkę.
    destination_font = FontData("Times New Roman")

    # Zastąp czcionkę.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Zapisz prezentację.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 

Aby ustawić reguły określające, co się stanie w określonych warunkach (na przykład, gdy czcionka nie jest dostępna), zobacz [Zastępowanie czcionek](/slides/pl/python-java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „zastępowaniem czcionki” a „czcionkami zapasowymi”?**

Zastąpienie to celowe przełączenie z jednej rodziny na drugą w całym dokumencie. [Zastępowanie](/slides/pl/python-java/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Zapasowa](/slides/pl/python-java/fallback-font/) jest stosowana do pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy główne i notatki; komentarze również są częścią dokumentu i są uwzględniane przez silnik czcionek.

**Czy czcionka zostanie zmieniona w osadzonych obiektach OLE (na przykład Excel)?**

Nie. [Zawartość OLE](/slides/pl/python-java/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie reformatuje wewnętrznych danych OLE; może być wyświetlane jako obraz lub jako edytowalna zawartość zewnętrzna.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**

Ukierunkowane zastąpienie jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, zamiast stosować globalną zamianę w całym dokumencie. Logika wyboru czcionki podczas renderowania pozostaje taka sama.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/): zapewnia listę [używanych rodzin](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getFonts) oraz informacje o [zastąpieniach/\"nieznane\" czcionkach](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/#getSubstitutions), co pomaga w planowaniu zamiany.

**Czy zamiana czcionek działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/zastępowania czcionek](/slides/pl/python-java/font-selection-sequence/), więc wcześniej wykonana zamiana zostanie uwzględniona podczas konwersji.

**Czy muszę instalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka pozwala na [ładowanie zewnętrznych czcionek](/slides/pl/python-java/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/python-java/convert-powerpoint/).

**Czy zamiana naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. W przeciwnym razie [skonfiguruj czcionki zapasowe](/slides/pl/python-java/fallback-font/) aby objąć brakujące znaki.