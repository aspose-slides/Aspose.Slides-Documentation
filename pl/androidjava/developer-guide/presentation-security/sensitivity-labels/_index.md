---
title: "Zarządzanie etykietami poufności w prezentacjach PowerPoint na Androidzie"
linktitle: "Etykiety poufności"
type: docs
weight: 50
url: /pl/androidjava/sensitivity-labels/
keywords:
- "etykieta poufności"
- "Microsoft Purview"
- "Microsoft Information Protection"
- "metadane MIP"
- "oznaczenia treści"
- "ochrona informacji"
- "zarządzanie dokumentem"
- "PowerPoint"
- "PPTX"
- "bezpieczeństwo prezentacji"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Odczyt, dodawanie, aktualizacja, usuwanie i migracja etykiet poufności Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną w ramach polityki, zaktualizować jej stan lub przenieść metadane etykiety zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides for Android via Java udostępnia nowoczesne metadane etykiet poufności za pośrednictwem [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Metoda ta zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/), które można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="info" title="Note" %}}
Identyfikatory etykiet poufności i informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet oraz wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości zwracane przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie właściwości etykiet poufności**

Każdy [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/) zawiera następujące metadane:

| Metody | Cel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) i [ISensitivityLabel.setId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Pobiera lub ustawia identyfikator etykiety poufności w polityce Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) i [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Pobiera lub ustawia identyfikator witryny powiązanej z polityką etykiety. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) i [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Pobiera lub ustawia, czy etykieta jest włączona. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) i [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Pobiera lub ustawia, czy etykieta została usunięta. Ustaw wartość `true`, gdy stan usunięcia ma być zachowany w metadanych. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) i [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Pobiera lub ustawia, czy etykieta została zastosowana automatycznie, czy w wyniku decyzji użytkownika. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Pobiera typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) określa sposób przypisania etykiety:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę domyślną lub zastosowaną automatycznie.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną w wyniku decyzji użytkownika, w tym etykiety zastosowane ręcznie, rekomendowane i obowiązkowe.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wylistowanie istniejących etykiet poufności**

Odczytaj nowoczesną kolekcję etykiet za pomocą [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) i wylicz ją. Poniższy przykład wypisuje wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

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

## **Dodanie etykiety poufności z oznaczeniem treści**

Użyj [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) podając identyfikator etykiety, identyfikator witryny, stan włączenia oraz metodę przypisania. Po zwróceniu nowego [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez listę zwróconą przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

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

## **Aktualizacja etykiety poufności**

Wartości [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwracanej przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), którą modyfikuje się przy użyciu operacji na liście. Po znalezieniu wymaganej etykiety można zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby zachować zmiany.

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

## **Oznaczenie etykiety poufności jako usuniętej**

Aby zachować informację o usunięciu etykiety, znajdź etykietę i wywołaj [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) z wartością `true`. Spowoduje to zachowanie wpisu etykiety przy jednoczesnym zapisaniu jej stanu usunięcia. Jeśli zamiast tego trzeba usunąć wpis z nowoczesnej kolekcji, użyj [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); użyj [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) , aby usunąć wszystkie wpisy.

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

## **Odczyt i migracja starszych etykiet MIP poufności**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet poufności w niestandardowych własnościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoda analizuje starsze własności niestandardowe i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/) przy użyciu [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Ponieważ dodanie identycznego identyfikatora etykiety powoduje wyrzucenie wyjątku, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową walidację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

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

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych własności dokumentu, więc niepowiązane metadane dokumentu pozostają nienaruszone. Użyj [IPresentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez listę zwróconą przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia powiązane z etykietą poufności. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ pracy musi renderować te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) z wartością `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety poufności?**

Tak. Starsze etykiety mogą pozostać w niestandardowych własnościach dokumentu, podczas gdy nowoczesne etykiety są dostępne poprzez [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Użyj [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) , aby odczytać starsze metadane i migrować tylko te prawidłowe etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwracane przez [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy powinien być użyty, aby zachować zaktualizowane etykiety poufności?**

Zapisz prezentację jako PPTX, wywołując [IPresentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/), jak pokazano w powyższych przykładach.