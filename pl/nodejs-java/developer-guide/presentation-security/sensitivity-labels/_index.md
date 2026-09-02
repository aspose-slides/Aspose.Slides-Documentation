---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w JavaScript
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Odczytuj, dodawaj, aktualizuj, usuwaj i migruj etykiety wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides for Node.js via Java udostępnia nowoczesne metadane etykiet wrażliwości poprzez [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Metoda ta zwraca [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="primary" title="Note" %}}
Identyfikatory etykiet wrażliwości oraz informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia treści powiązane z etykietą; nie dodają one samodzielnie widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie właściwości etykiet wrażliwości**

Każda [SensitivityLabel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/) zawiera następujące metadane:

| Metody | Cel |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getId) i [SensitivityLabel.setId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Pobierz lub ustaw identyfikator etykiety wrażliwości w polityce Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) i [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Pobierz lub ustaw witrynę powiązaną z polityką etykiety. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) i [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Pobierz lub ustaw, czy etykieta jest włączona. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) i [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Pobierz lub ustaw, czy etykieta została usunięta. Ustaw wartość na `true`, gdy stan usunięcia musi być zachowany w metadanych. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) i [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Pobierz lub ustaw, czy etykieta została zastosowana automatycznie czy w wyniku decyzji użytkownika. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Pobierz typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) określa, w jaki sposób etykieta została przypisana:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę domyślną lub zastosowaną automatycznie.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym etykiety stosowane ręcznie, zalecane i obowiązkowe.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie zawartości nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie zawartości stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie zawartości znaków wodnych jest powiązane z etykietą. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Lista istniejących etykiet wrażliwości**

Od­czytaj nowoczesną kolekcję etykiet z [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) i wylicz ją. Poniższy przykład wymienia wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Dodaj etykietę wrażliwości z oznaczeniem treści**

Użyj [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Po tym, jak metoda zwróci nową [SensitivityLabel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez listę zwróconą przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aktualizacja etykiety wrażliwości**

Wartości [SensitivityLabel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwróconej przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), którą modyfikuje się przy pomocy operacji na liście. Po zlokalizowaniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby zachować zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Oznacz etykietę wrażliwości jako usuniętą**

Aby zachować fakt, że etykieta została usunięta, znajdź etykietę i wywołaj [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) z `true`. To zachowuje wpis etykiety, rejestrując jej stan usunięcia. Jeśli zamiast tego musisz usunąć wpis z nowoczesnej kolekcji, użyj [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); użyj [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear), aby usunąć wszystkie wpisy.

Poniższy przykład oznacza konkretną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odczyt i migracja starszych etykiet wrażliwości MIP**

Starsze procesy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane przy pomocy [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analizuje starsze niestandardowe właściwości i zwraca tablicę obiektów [SensitivityLabel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/) przy pomocy [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Ponieważ dodanie identyfikatora duplikującej etykiety powoduje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga to czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niepowiązane metadane dokumentu pozostają nienaruszone. Użyj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez listę zwróconą przez [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią zawartość slajdów osobno, jeśli Twój proces musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) z `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji w zakresie przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostawać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne za pośrednictwem [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Użyj [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels), aby odczytać starsze metadane i migrować tylko te ważne etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta z tym samym identyfikatorem zostanie dodana więcej niż raz?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwracane przez [SensitivityLabel.getId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sensitivitylabel/#getId), zanim dodasz lub zmigrujesz etykiety.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/), jak pokazano w powyższych przykładach.