---
title: Obsługa ostrzeżeń prezentacji w Pythonie za pośrednictwem Javy
type: docs
weight: 90
url: /pl/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- wywołanie zwrotne ostrzeżenia
- polityka ostrzeżeń
- utrata danych
- uszkodzenie źródła
- problem kompatybilności
- podstawianie czcionek
- podpis cyfrowy
- ładowanie prezentacji
- renderowanie prezentacji
- konwersja prezentacji
- zapisywanie prezentacji
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak zbierać, klasyfikować i reagować na ostrzeżenia podczas ładowania, renderowania, konwersji i zapisywania prezentacji przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Aspose.Slides może zgłaszać odzyskiwalne problemy podczas ładowania, renderowania, konwersji lub zapisywania prezentacji. Przykłady obejmują uszkodzone rekordy źródłowe, treść, której nie można zachować, podstawianie czcionek oraz ograniczenia docelowego formatu. Wywołanie zwrotne ostrzeżenia pozwala aplikacji zarejestrować te warunki i zdecydować, czy bieżąca operacja może być kontynuowana.

Zaimplementuj interfejs `IWarningCallback` za pośrednictwem `jpype.JProxy` i zbadaj wartości `getWarningType` i `getDescription` dostarczane przez `IWarningInfo`. Zwróć [ReturnAction.Continue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/returnaction/#Continue), aby zaakceptować ostrzeżenie, lub [ReturnAction.Abort](https://reference.aspose.com/slides/pl/python-java/aspose.slides/returnaction/#Abort), aby zatrzymać operację.

Użyj [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setWarningCallback) dla ostrzeżeń podnoszonych podczas otwierania prezentacji. Klasy opcji renderowania i eksportu dziedziczą [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setWarningCallback), które odbierają ostrzeżenia z renderowania slajdów, konwersji i zapisywania. Ponieważ samo ostrzeżenie nie identyfikuje operacji aplikacji, powiąż każdą instancję wywołania zwrotnego ze stage operacji podczas budowania zbiorczego raportu.

## **Ostrzeżenia i wyjątki**

Ostrzeżenie opisuje warunek, z którego Aspose.Slides może się otworzyć, jeśli wywołanie zwrotne zwróci `ReturnAction.Continue`. Wyjątek oznacza, że żądana operacja nie może zakończyć się normalnie; wyjątki nie są konwertowane na ostrzeżenia i nie mogą być obsługiwane przez politykę ostrzeżeń.

Zwrócenie `ReturnAction.Abort` nakazuje dyspozytorowi ostrzeżeń zakończenie bieżącej operacji poprzez podniesienie wyjątku. Publiczny typ wyjątku zależy od operacji i formatu prezentacji. Na przykład podczas ładowania może wystąpić [PptxReadException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxreadexception/) lub [PptReadException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptreadexception/), a podczas zapisywania lub eksportu może pojawić się [PptxException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxexception/). Obsłuż wyjątek na granicy operacji i użyj raportu ostrzeżeń, aby określić, czy polityka aplikacji spowodowała przerwanie, zamiast polegać wyłącznie na podtypie wyjątku lub jego komunikacie. Wywołanie zwrotne rejestruje ostrzeżenie przed zwróceniem `ReturnAction.Abort`, zapewniając, że przyczyna pozostanie dostępna dla aplikacji.

## **Kategorie ostrzeżeń**

Klasa [WarningType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/) udostępnia stałe liczbowe dla następujących kategorii:

| Typ ostrzeżenia | Znaczenie | Typowa polityka |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Prezentacja źródłowa zawiera uszkodzenia, które mogą uniemożliwić użycie dokumentu zapisanego w oryginalnym formacie. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#DataLoss) | Tekst, wykresy, obrazy lub inne dane mogą być nieobecne po załadowaniu lub zapisaniu. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentacja może utracić istotne formatowanie. | Abort w trybie ścisłej walidacji; w przeciwnym razie rejestruj i kontynuuj. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Może wystąpić ograniczona różnica w formatowaniu. | Rejestruj do diagnostyki i kontynuuj. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Wynik może nie otworzyć się lub nie działać poprawnie w niektórych aplikacjach lub starszych wersjach. | Loguj i kontynuuj, chyba że kompatybilność jest wymagana. |
| [UnexpectedContent](https://reference.aspose.com/slides/pl/python-java/aspose.slides/warningtype/#UnexpectedContent) | Źródło zawiera nieobsługiwaną lub nierozpoznaną treść, której wpływ może być jeszcze nieznany. | Rejestruj i kontynuuj, lub traktuj jako błąd w polityce ścisłej. |

Kategoria powinna kierować decyzją polityki. Przechowuj wartość zwróconą przez `getDescription` do diagnostyki, ale nie opieraj logiki aplikacji na jej treści, ponieważ tekst komunikatu może się różnić w zależności od scenariusza ostrzeżenia i wersji produktu.

## **Zbieranie i klasyfikacja ostrzeżeń**

Poniższy przykład używa jednego raportu na poziomie aplikacji dla całego potoku przetwarzania. Oddzielna instancja wywołania zwrotnego oznacza ostrzeżenia pochodzące od ładowania, renderowania, konwersji do PDF i zapisu PPTX. Polityka przerywa przy uszkodzeniu źródła lub utracie danych, opcjonalnie przerywa przy dużej utracie formatowania i kontynuuje w przypadku pozostałych ostrzeżeń.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Przekaż `False` dla `abort_on_major_formatting_loss` przy konstruowaniu `WarningPolicy`, jeśli duże różnice w formatowaniu są akceptowalne. Problemy z kompatybilnością, drobne straty formatowania oraz nieoczekiwana treść nadal pozostają w raporcie, nawet gdy operacja jest kontynuowana. Rozszerz `WarningPolicy.get_action`, jeśli aplikacja musi odrzucić którąkolwiek z tych kategorii.

## **Typowe scenariusze ostrzeżeń**

Ostrzeżenia mogą pojawiać się na różnych etapach przepływu pracy:

- **Podpisy cyfrowe:** Podpisana prezentacja może wygenerować ostrzeżenie podczas ładowania, że jej podpis zostanie utracony w trakcie przetwarzania. Aspose.Slides zgłasza ten stan `DataLoss` poprzez `IPresentationSignedWarningInfo`. Wywołanie zwrotne na etapie ładowania pozwala aplikacji odrzucić plik lub explicite zaakceptować zgłosioną utratę.
- **Podstawianie czcionek:** Niedostępna czcionka może zostać zastąpiona podczas renderowania lub eksportu slajdu. Ostrzeżenia o podstawianiu czcionek są zgłaszane jako `DataLoss`, więc ścisła polityka powyżej przerywa operację, nawet jeśli aplikacja uznałaby konkretne zastąpienie za wizualnie dopuszczalne. Aby zaobserwować to zachowanie, użyj prezentacji wejściowej zawierającej tekst w czcionce niedostępnej w środowisku wykonawczym. Opis ostrzeżenia identyfikuje podstawienie; skonfiguruj wymagane czcionki lub [font substitution rules](/slides/pl/python-java/font-substitution/) przed ponowną próbą.
- **Nieobsługiwana lub nieoczekiwana treść:** Ładowarka może napotkać rekordy prezentacji lub funkcje, których nie rozpoznaje. Takie ostrzeżenia mogą używać `UnexpectedContent` lub bardziej surowej kategorii, gdy wiadomo, że dane lub formatowanie są dotknięte.
- **Kompatybilność formatu:** Zapis do innego formatu prezentacji może pominąć funkcje lub wygenerować wynik zachowujący się inaczej w niektórych aplikacjach. Na przykład zapis prezentacji z więcej niż ośmioma poziomymi lub pionowymi prowadnicami rysunkowymi do starszego PPT zgłasza `CompatibilityIssue`. Wywołanie zwrotne na etapie zapisu może zarejestrować utratę i kontynuować, lub odrzucić ją, jeśli konieczne jest zachowanie wszystkich prowadnic.
- **Zachowanie przy ładowaniu:** Opcje ładowania i zachowania legacy również mogą generować ostrzeżenia. Na przykład `IObsoletePresLockingBehaviorWarningInfo` identyfikuje użycie przestarzałego zachowania blokady prezentacji jako `CompatibilityIssue`.

Ostrzeżenia zależą od dokumentu źródłowego, formatu docelowego, operacji i wersji Aspose.Slides. Nie zakładaj, że każdy plik generuje ostrzeżenie lub że scenariusz zawsze mapuje się na jedną kategorię.

## **Bezpieczne obsługiwanie przerwanych operacji**

Gdy wywołanie zwrotne zwróci `ReturnAction.Abort`, nie używaj obiektu, którego ładowanie się nie powiodło, i nie zakładaj, że wynik renderowania lub zapisu jest kompletny. Operacja może zakończyć się po utworzeniu pliku wyjściowego, ale przed jego pełnym zapisaniem.

Zapisz zweryfikowane wyniki w oddzielnej ścieżce, np. `validated-output.pptx`. Zastąp istniejącą prezentację dopiero po pomyślnym zakończeniu operacji, spełnieniu polityki ostrzeżeń i gdy wynik może być otwarty i sprawdzony. Dzięki temu unikniesz nadpisania prawidłowego pliku źródłowego wynikiem częściowym lub odrzuconym.

Pusty raport ostrzeżeń nie jest gwarancją, że każda cecha źródłowa została zachowana. Zastosuj dodatkowe kontrole treści i wizualne wymagane przez aplikację. Zobacz także [Open Presentations](/slides/pl/python-java/open-presentation/) i [Save Presentations](/slides/pl/python-java/save-presentation/).

## **FAQ**

**Czy wywołanie zwrotne ostrzeżenia może obsłużyć każdy błąd Aspose.Slides?**

Nie. Obsługuje ono warunki odzyskiwalne zgłaszane jako ostrzeżenia. Wyjątki występujące niezależnie od wywołania zwrotnego muszą być obsługiwane przez aplikację wokół wywołań ładowania, renderowania, konwersji lub zapisu.

**Czy zwrócenie `ReturnAction.Continue` gwarantuje identyczny wynik?**

Nie. Pozwala jedynie na kontynuację przetwarzania. Zgłoszony warunek może nadal powodować różnice w danych, formatowaniu lub kompatybilności, dlatego należy przeanalizować zebrane typy ostrzeżeń i ich opisy.

**Jak aplikacja może zidentyfikować operację, która wywołała ostrzeżenie?**

Utwórz oddzielną instancję wywołania zwrotnego dla każdej operacji i przechowuj definiowaną przez aplikację fazę razem z wartościami zwracanymi przez `getWarningType` i `getDescription`, jak pokazano w przykładzie.