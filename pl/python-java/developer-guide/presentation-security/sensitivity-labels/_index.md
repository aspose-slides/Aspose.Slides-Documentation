---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w języku Python
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/python-java/sensitivity-labels/
keywords:
- etykieta wrażliwości
- Microsoft Purview
- Microsoft Information Protection
- metadane MIP
- oznaczanie treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Python
- Aspose.Slides
description: "Odczytuj, dodawaj, aktualizuj, usuwaj i migruj etykiety wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub przenieść metadane etykiety zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides udostępnia nowoczesne metadane etykiet wrażliwości za pomocą [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSensitivityLabels). Ta metoda zwraca [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/) , którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="info" title="Uwaga" %}}
Identyfikatory etykiet wrażliwości oraz informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości zwracane przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie właściwości etykiet wrażliwości**

Każdy [SensitivityLabel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/) zawiera następujące metadane:

| Metody | Cel |
| --- | --- |
| [getId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getId) i [setId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setId) | Pobiera lub ustawia identyfikator etykiety wrażliwości w polityce Purview. |
| [getSiteId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getSiteId) i [setSiteId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Pobiera lub ustawia witrynę powiązaną z polityką etykiety. |
| [isEnabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#isEnabled) i [setEnabled](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Pobiera lub ustawia, czy etykieta jest włączona. |
| [isRemoved](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#isRemoved) i [setRemoved](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Pobiera lub ustawia, czy etykieta została usunięta. Ustaw wartość na `True`, gdy stan usunięcia ma być zachowany w metadanych. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) i [setAssignmentMethodType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Pobiera lub ustawia, czy etykieta została zastosowana automatycznie, czy na podstawie decyzji użytkownika. |
| [getContentMarkTypes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Pobiera typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelassignmenttype/) definiuje sposób, w jaki etykieta została przypisana:

- [Standard](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje domyślną lub automatycznie zastosowaną etykietę.
- [Privileged](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym etykiety zastosowane ręcznie, zalecane i obowiązkowe.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [None](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [Header](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie treści nagłówka. |
| [Footer](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie treści stopki. |
| [Watermark](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie treści znaku wodnego. |
| [Encryption](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązana jest ochrona szyfrowaniem. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wylistowanie istniejących etykiet wrażliwości**

Odczytaj nowoczesną kolekcję etykiet za pomocą [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSensitivityLabels) i enumeruj ją. Poniższy przykład wymienia wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Dodanie etykiety wrażliwości z oznaczeniem treści**

Użyj [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#add) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Po zwróceniu nowego [SensitivityLabel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez listę zwróconą przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktualizacja etykiety wrażliwości**

Wartości [SensitivityLabel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwróconej przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), którą modyfikuje się poprzez operacje na liście. Po odnalezieniu odpowiedniej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby utrwalić zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Oznaczenie etykiety wrażliwości jako usuniętej**

Aby zachować informację, że etykieta została usunięta, znajdź etykietę i wywołaj [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setRemoved) z `True`. To zachowuje wpis etykiety, jednocześnie rejestrując jej stan usunięcia. Jeśli zamiast tego musisz usunąć wpis z nowoczesnej kolekcji, użyj [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); użyj [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#clear), aby usunąć wszystkie wpisy.

Poniższy przykład oznacza określoną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odczyt i migracja starszych etykiet MIP wrażliwości**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analizuje starsze niestandardowe właściwości i zwraca tablicę obiektów [SensitivityLabel](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/) przy użyciu [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#add). Ponieważ dodanie etykiety o duplikującym się identyfikatorze powoduje wyjątek, przykład sprawdza kolekcję docelową przed kopiowaniem każdej etykiety. Możesz dodać dodatkową walidację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niepowiązane metadane dokumentu pozostają nienaruszone. Użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane za pośrednictwem listy zwróconej przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ pracy musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#setRemoved) z `True` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne za pomocą [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSensitivityLabels). Użyj [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/python-java/aspose.slides/documentproperties/#getSensitivityLabels), aby odczytać starsze metadane i migrować tylko ważne etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabelcollection/#add) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwrócone przez [SensitivityLabel.getId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sensitivitylabel/#getId) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy powinien być użyty, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/), jak pokazano w powyższych przykładach.