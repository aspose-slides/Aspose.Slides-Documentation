---
title: "Konwertuj PPT i PPTX do PDF w Pythonie za pośrednictwem Java [Zawarte funkcje zaawansowane]"
linktitle: "PowerPoint do PDF"
type: docs
weight: 40
url: /pl/python-java/convert-powerpoint-to-pdf/
keywords:
- "konwertuj PowerPoint"
- "konwertuj prezentację"
- "PowerPoint do PDF"
- "prezentacja do PDF"
- "PPT do PDF"
- "konwertuj PPT do PDF"
- "PPTX do PDF"
- "konwertuj PPTX do PDF"
- "zapisz PowerPoint jako PDF"
- "zapisz PPT jako PDF"
- "zapisz PPTX jako PDF"
- "eksportuj PPT do PDF"
- "eksportuj PPTX do PDF"
- "załącznik"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Pythonie za pośrednictwem Java przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) na format PDF w Pythonie za pośrednictwem Java oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje na dokumenty PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Klasa [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwertowania prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Konkretne slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperalinki
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowa konwersja używa domyślnych ustawień eksportu PDF. Użyj opcji niestandardowych, gdy potrzebujesz kontrolować jakość obrazu, zawartość strony lub zgodność PDF.

Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) oraz kompatybilny środowisko Java przed uruchomieniem przykładów. Każdy przykład odczytuje `presentation.pptx` z bieżącego katalogu roboczego; zamień go na swój plik PPT, PPTX lub ODP. Uruchom JVM raz na proces Pythona.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia opcje niestandardowe — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — które pozwalają dostosować powstały PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Opcjami Niestandardowymi**

Korzystając z opcji konwersji niestandardowych, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i inne.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metaplikami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mogli uzyskać dostęp do danych skoroszytu oraz oglądać slajdy. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) z wartością `True`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `False`: podglądowy obraz lub ikona obiektu OLE jest renderowany na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `True` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualnym przedstawieniem; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z załączonym skoroszytem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki plików, takiej jak Adobe Acrobat Reader.
2. Otwórz panel **Attachments** w przeglądarce i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić jego dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zakazuje osadzonych plików, PDF/A-2 zezwala tylko na załączniki PDF/A, a PDF/A-3 umożliwia inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy jako strony w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszelkie ukryte slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` do otwarcia. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie w wysokiej jakości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Wykryj podstawienia czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), umożliwiając wykrycie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek na konsoli. Ostrzeżenie jest wypisywane tylko wtedy, gdy podczas eksportu podstawiona zostaje niedostępna czcionka. Użyj proxy JPype, aby otrzymywać wywołania zwrotne ostrzeżeń z API Java. Przed sprawdzeniem prefiksu, przekształć ciąg opisu Java na ciąg Pythona:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aby uzyskać więcej informacji na temat podstawień czcionek, zobacz artykuł [Font Substitution](/slides/pl/python-java/font-substitution/).
{{% /alert %}}

### **Obsługa czcionek bez dedykowanego kroju pogrubionego**

Prezentacja może zastosować formatowanie pogrubione do tekstu, nawet jeśli jego czcionka nie ma dedykowanego kroju pogrubionego. Tekst może nadal wyglądać na pogrubiony dzięki syntetycznemu pogrubianiu, które sztucznie zagęszcza standardowe glify. Gdy taki tekst wydaje się zbyt ciężki lub w inny sposób różni się od zamierzonego wyglądu w PDF, spróbuj wywołać [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) z wartością `True`. Ta opcja renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `False`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z zwykłym tekstem i drugie z pogrubionym formatowaniem zastosowanym do tej samej czcionki, która nie ma dedykowanego kroju pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Poniższe podglądy pokazują wynik z wyłączoną i włączoną opcją. W tym przykładzie pogrubiony tekst ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji jego kreski są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed wyborem ustawienia dla swojej prezentacji.

| Opcja wyłączona (`False`, domyślnie) | Opcja włączona (`True`) |
|---|---|
| ![PDF z rasteryzacją nieobsługiwanego stylu czcionki wyłączoną](unsupported-bold-disabled.png) | ![PDF z rasteryzacją nieobsługiwanego stylu czcionki włączoną](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji zamienia tylko pogrubiony tekst na bitmapę: nie można go zaznaczyć, skopiować ani przeszukać jako tekst bez OCR, a jego krawędzie wydają się miększe przy 800% powiększeniu. Tekst zwykły pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanego kroju pogrubionego. [Font substitution](/slides/pl/python-java/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Numery slajdów przekazywane do [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) są numerowane od 1. Ten przykład eksportuje slajdy 1 i 3, jeśli oba istnieją:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten przykład eksportuje pierwszy slajd na stronie o wymiarach 612 na 792 punktów (US Letter). Klonuje slajd do nowej prezentacji o określonym rozmiarze i skalowuje zawartość slajdu, aby pasowała.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Usuń pusty slajd, który został utworzony w nowej prezentacji.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standardy dostępności i zgodności dla PDF**

Przy przygotowywaniu dostępnych PDF-ów, zapoznaj się z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Użyj [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance), aby wybrać standard wyjściowy: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki takie jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako odrębna treść i mogą być oznaczone jako artefakty; alternatywny tekst jest podawany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy możliwe jest zabezpieczenie konwertowanego PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy w PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z wartością `True` w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) i [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF-ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, w celu dostępności lub archiwizacji. Wybierz odpowiedni standard i sprawdź wynik pod kątem swoich wymagań.

## **Dodatkowe zasoby**

- [Aspose.Slides for Python via Java – Dokumentacja](/slides/pl/python-java/)
- [Aspose.Slides for Python via Java – Referencja API](https://reference.aspose.com/slides/python-java/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/conversion)