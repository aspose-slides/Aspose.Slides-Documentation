---
title: Zarządzaj etykietami poufności w prezentacjach PowerPoint w PHP
linktitle: Etykiety poufności
type: docs
weight: 50
url: /pl/php-java/sensitivity-labels/
keywords:
- etykieta poufności
- Microsoft Purview
- Microsoft Information Protection
- metadane MIP
- oznaczenie treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- PHP
- Aspose.Slides
description: "Odczyt, dodawanie, aktualizacja, usuwanie i migracja etykiet poufności Microsoft Purview w prezentacjach PowerPoint PPTX w PHP."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub migrować metadane etykiet zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides for PHP via Java udostępnia nowoczesne metadane etykiet poufności poprzez [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSensitivityLabels). Ta metoda zwraca [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="primary" title="Uwaga" %}}
Identyfikatory etykiet poufności i informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozum właściwości etykiet poufności**

Każda [SensitivityLabel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/) zawiera następujące metadane:

| Metody | Cel |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getId) i [SensitivityLabel::setId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setId) | Pobierz lub ustaw identyfikator etykiety poufności w polityce Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getSiteId) i [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Pobierz lub ustaw witrynę powiązaną z polityką etykiety. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#isEnabled) i [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Pobierz lub ustaw, czy etykieta jest włączona. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#isRemoved) i [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Pobierz lub ustaw, czy etykieta została usunięta. Ustaw wartość na `true`, gdy stan usunięcia ma być zachowany w metadanych. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) i [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Pobierz lub ustaw, czy etykieta została zastosowana automatycznie czy w wyniku decyzji użytkownika. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Pobierz typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelassignmenttype/) definiuje sposób przypisania etykiety:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę domyślną lub zastosowaną automatycznie.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym ręcznie zastosowane, zalecane i obowiązkowe etykiety.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wymień istniejące etykiety poufności**

Odczytaj nowoczesną kolekcję etykiet z [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSensitivityLabels) i wylicz ją. Poniższy przykład wymienia wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Dodaj etykietę poufności z oznaczeniem treści**

Użyj [SensitivityLabelCollection::add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#add) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Po zwróceniu nowej [SensitivityLabel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/) dodaj wymagane wartości oznaczeń za pomocą listy zwróconej przez [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zaktualizuj etykietę poufności**

Wartości [SensitivityLabel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwróconej przez [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), którą modyfikuje się za pomocą operacji na liście. Po znalezieniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby utrwalić zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Oznacz etykietę poufności jako usuniętą**

Aby zachować fakt, że etykieta została usunięta, znajdź etykietę i wywołaj [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setRemoved) z wartością `true`. Dzięki temu wpis etykiety pozostaje, a jej stan usunięcia jest zapisany. Jeśli zamiast tego musisz usunąć wpis z nowoczesnej kolekcji, użyj [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); użyj [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#clear), aby usunąć wszystkie wpisy.

Poniższy przykład oznacza konkretną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Odczytaj i migruj starsze etykiety poufności MIP**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet poufności w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analizuje starsze własne właściwości i zwraca tablicę Java obiektów [SensitivityLabel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [SensitivityLabelCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/) przy użyciu [SensitivityLabelCollection::add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#add). Ponieważ dodanie etykiety z powtarzającym się identyfikatorem powoduje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niezwiązane metadane pozostają nienaruszone. Użyj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane za pomocą listy zwróconej przez [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) opisują oznaczenia powiązane z etykietą poufności. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ pracy musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#setRemoved) z wartością `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety poufności?**

Tak. Starsze etykiety mogą pozostać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne za pośrednictwem [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSensitivityLabels). Użyj [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getSensitivityLabels), aby odczytać starsze metadane i migrować tylko te etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabelcollection/#add) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwrócone przez [SensitivityLabel::getId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sensitivitylabel/#getId) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety poufności?**

Zapisz prezentację jako PPTX, wywołując [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/), jak pokazano w powyższych przykładach.