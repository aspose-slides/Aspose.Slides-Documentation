---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w Pythonie
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/python-net/sensitivity-labels/
keywords:
- etykieta wrażliwości
- Microsoft Purview
- Microsoft Information Protection
- metadane MIP
- oznaczenia treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Python
- Aspose.Slides
description: "Odczyt, dodawanie, aktualizacja, usuwanie i migracja etykiet wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub migrować metadane etykiety zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides for Python via .NET udostępnia nowoczesne metadane etykiet wrażliwości poprzez [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sensitivity_labels/). Właściwość ta zwraca [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="primary" title="Uwaga" %}}
Identyfikatory etykiet wrażliwości i informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet oraz wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozum właściwości etykiet wrażliwości**

Każda [SensitivityLabel](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/) zawiera następujące metadane:

| Właściwość | Cel |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/id/) | Identyfikuje etykietę wrażliwości w polityce Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/site_id/) | Identyfikuje witrynę powiązaną z polityką etykiety. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Wskazuje, czy etykieta jest włączona. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/is_removed/) | Wskazuje, że etykieta została usunięta. Ustaw tę właściwość na `True`, gdy stan usunięcia musi być zachowany w metadanych. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Określa, czy etykieta została zastosowana automatycznie, czy w wyniku decyzji użytkownika. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Wymienia typy oznaczeń treści powiązane z etykietą. |

Wyliczenie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelassignmenttype/) opisuje, jak etykieta została przypisana:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje domyślną lub automatycznie zastosowaną etykietę.  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym etykiety stosowane ręcznie, rekomendowane i obowiązkowe.

Wyliczenie [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) identyfikuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wypisz istniejące etykiety wrażliwości**

Odczytaj nowoczesną kolekcję etykiet z [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sensitivity_labels/) i wylicz ją. Poniższy przykład wymienia każdą właściwość i oznaczenie treści przechowywane dla każdej etykiety:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Dodaj etykietę wrażliwości z oznaczeniem treści**

Użyj [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/add/) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Przekaż identyfikator witryny jako obiekt Python `uuid.UUID`. Po zwróceniu nowej [SensitivityLabel](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/), dołącz wymagane wartości oznaczeń do [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj etykietę wrażliwości**

Właściwości [SensitivityLabel](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwracanej przez [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/content_mark_types/), która jest modyfikowana za pomocą operacji na liście. Po odnalezieniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby zachować zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Oznacz etykietę wrażliwości jako usuniętą**

Aby zachować informację, że etykieta została usunięta, znajdź etykietę i ustaw [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/is_removed/) na `True`. To zachowuje wpis etykiety, jednocześnie rejestrując jej stan usunięcia. Jeśli zamiast tego potrzebujesz usunąć wpis z nowoczesnej kolekcji, użyj [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); użyj [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/clear/) aby usunąć wszystkie wpisy.

Poniższy przykład oznacza konkretną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Odczytaj i migruj starsze etykiety wrażliwości MIP**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Metoda parsuje starsze niestandardowe właściwości i zwraca obiekty [SensitivityLabel](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/) poprzez [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/add/). Ponieważ dodanie etykiety o tym samym identyfikatorze powoduje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Migracja kopiuje sparsowane obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niezwiązane metadane dokumentu pozostają nienaruszone. Użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) z [SaveFormat.PPTX](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdów osobno, jeśli Twój przepływ pracy musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Ustawienie [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/is_removed/) na `True` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne poprzez [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sensitivity_labels/). Użyj [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/pl/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) aby odczytać starsze metadane i migrować tylko te prawidłowe etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabelcollection/add/) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości [SensitivityLabel.id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sensitivitylabel/id/) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy powinien być użyty, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) z [SaveFormat.PPTX](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/), jak pokazano w powyższych przykładach.