---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint na Androidzie
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/androidjava/sensitivity-labels/
keywords:
- etykieta wrażliwości
- Microsoft Purview
- Ochrona informacji Microsoft
- metadane MIP
- oznaczenia treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Android
- Java
- Aspose.Slides
description: "Odczyt, dodawanie, aktualizacja, usuwanie i migracja etykiet wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Etykiety wrażliwości Microsoft Purview pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub migrować metadane etykiet zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides for Android via Java udostępnia nowoczesne metadane etykiet wrażliwości poprzez [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Ta metoda zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="primary" title="Note" %}}

Identyfikatory etykiet wrażliwości i informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet oraz wymagania polityki w środowisku przed dodaniem lub migracją metadanych. Wartości zwracane przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.

{{% /alert %}}

## **Zrozum właściwości etykiet wrażliwości**

Każdy [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/) zawiera następujące metadane:

| Metody | Cel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getId--) i [ISensitivityLabel.setId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setId-java.lang.String-) | Pobierz lub ustaw identyfikator etykiety wrażliwości w polityce Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getSiteId--) i [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setSiteId-java.util.UUID-) | Pobierz lub ustaw witrynę powiązaną z polityką etykiety. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#isEnabled--) i [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setEnabled-boolean-) | Pobierz lub ustaw, czy etykieta jest włączona. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#isRemoved--) i [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) | Pobierz lub ustaw, czy etykieta została usunięta. Ustaw wartość na `true`, gdy stan usunięcia musi być zachowany w metadanych. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getAssignmentMethodType--) i [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setAssignmentMethodType-int-) | Pobierz lub ustaw, czy etykieta została zastosowana automatycznie lub w wyniku decyzji użytkownika. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) | Pobierz typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) definiuje, jak etykieta została przypisana:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) reprezentuje domyślną lub automatycznie zastosowaną etykietę.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym ręcznie zastosowane, rekomendowane i obowiązkowe etykiety.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Oznaczenie treści nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Oznaczenie treści stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Oznaczenie treści znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wymień istniejące etykiety wrażliwości**

Odczytaj nowoczesną kolekcję etykiet z [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) i wylicz ją. Poniższy przykład wypisuje wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Dodaj etykietę wrażliwości z oznaczeniem treści**

Użyj [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Po zwróceniu nowego [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez listę zwróconą przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zaktualizuj etykietę wrażliwości**

Wartości [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwróconej przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--), która jest modyfikowana poprzez operacje listy. Po odnalezieniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby utrwalić zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Oznacz etykietę wrażliwości jako usuniętą**

Aby zachować informację o usunięciu etykiety, znajdź etykietę i wywołaj [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) z wartością `true`. Dzięki temu wpis pozostaje w kolekcji, a jego stan usunięcia jest zarejestrowany. Jeśli zamiast tego chcesz usunąć wpis z nowoczesnej kolekcji, użyj [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-); aby usunąć wszystkie wpisy, użyj [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#clear--).

Poniższy przykład oznacza konkretną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odczytaj i migruj starsze etykiety wrażliwości MIP**

Starsze przepływy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji. Odczytaj te metadane za pomocą [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--). Metoda analizuje starsze właściwości niestandardowe i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/).

Aby zmigrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/) poprzez [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Ponieważ dodanie etykiety o tym samym identyfikatorze powoduje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niezwiązane metadane pozostają nienaruszone. Użyj [IPresentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.saveformat/) aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez listę zwróconą przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) z wartością `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-) usuwa wpis z nowoczesnej kolekcji. Wybierz operację zgodnie z wymaganiami organizacji dotyczącymi przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostawać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne przez [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Użyj [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--) aby odczytać starsze metadane i migrować tylko te ważne, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwracane przez [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.isensitivitylabel/#getId--) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy używać, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [IPresentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.saveformat/), jak pokazano w powyższych przykładach.