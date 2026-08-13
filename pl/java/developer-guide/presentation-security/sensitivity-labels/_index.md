---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w Javie
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/java/sensitivity-labels/
keywords:
- etykieta wrażliwości
- Microsoft Purview
- Microsoft Information Protection
- metadane MIP
- oznaczenie treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Java
- Aspose.Slides
description: "Odczytuj, dodawaj, aktualizuj, usuwaj i migruj etykiety wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX za pomocą Aspose.Slides dla Javy."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub przenieść metadane etykiet zapisane przez starszy proces Microsoft Information Protection (MIP).

Aspose.Slides udostępnia nowoczesne metadane etykiet wrażliwości za pośrednictwem [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Ta metoda zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="info" title="Note" %}}
Identyfikatory etykiet wrażliwości oraz informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości zwracane przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie właściwości etykiety wrażliwości**

Każdy [ISensitivityLabel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/) zawiera następujące metadane:

| Metody | Zastosowanie |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getId--) i [ISensitivityLabel.setId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Pobiera lub ustawia identyfikator etykiety wrażliwości w polityce Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getSiteId--) i [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Pobiera lub ustawia identyfikator witryny powiązanej z polityką etykiety. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#isEnabled--) i [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Pobiera lub ustawia informację, czy etykieta jest włączona. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#isRemoved--) i [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Pobiera lub ustawia informację, czy etykieta została usunięta. Ustaw wartość `true`, gdy stan usunięcia musi być zachowany w metadanych. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) i [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Pobiera lub ustawia informację, czy etykieta została zastosowana automatycznie, czy w wyniku decyzji użytkownika. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Pobiera typy oznaczeń treści powiązane z etykietą. |

Klasa [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelassignmenttype/) określa, w jaki sposób etykieta została przydzielona:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę domyślną lub zastosowaną automatycznie.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę przydzieloną w wyniku decyzji użytkownika, w tym etykiety zastosowane ręcznie, zalecane i obowiązkowe.

Klasa [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) definiuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie nagłówka. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie stopki. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest oznaczenie znaku wodnego. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Z etykietą powiązane jest zabezpieczenie szyfrowaniem. |

Jednej etykiecie może być przypisanych wiele typów oznaczeń.

## **Wyświetl istniejące etykiety wrażliwości**

Odczytaj nowoczesną kolekcję etykiet z [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) i wyenumeruj ją. Poniższy przykład wypisuje wszystkie właściwości i oznaczenia treści przechowywane dla każdej etykiety:

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

Użyj [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia oraz metodą przydziału. Po zwróceniu nowego [ISensitivityLabel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/) dodaj wymagane wartości oznaczeń za pomocą listy zwróconej przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

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

Wartości w [ISensitivityLabel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem listy zwróconej przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), która jest modyfikowana poprzez operacje na tej liście. Po odnalezieniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przydziału, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby utrwalić zmiany.

Poniższy przykład aktualizuje stan włączenia oraz metodę przydziału pierwszej etykiety:

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

Aby zachować informację o usunięciu etykiety, znajdź ją i wywołaj [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) z wartością `true`. Spowoduje to zachowanie wpisu etykiety przy jednoczesnym zapisaniu jej stanu usunięcia. Jeśli zamiast tego musisz usunąć wpis z nowoczesnej kolekcji, użyj [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); użyj [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#clear--) aby usunąć wszystkie wpisy.

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

## **Odczyt i migracja starszych etykiet wrażliwości MIP**

Starsze przepływy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoda analizuje starsze właściwości niestandardowe i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/) przy użyciu [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Ponieważ dodanie etykiety o zduplikowanym identyfikatorze powoduje wyjątek, przykład najpierw sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

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

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niepowiązane metadane dokumentu pozostają nienaruszone. Użyj [IPresentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/) aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez listę zwróconą przez [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) z wartością `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne poprzez [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Użyj [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) aby odczytać starsze metadane i migrować tylko te ważne, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, kiedy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) zgłasza wyjątek, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości zwracane przez [ISensitivityLabel.getId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isensitivitylabel/#getId--) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [IPresentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/), tak jak pokazano w powyższych przykładach.