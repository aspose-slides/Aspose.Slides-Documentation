---
title: Zarządzaj etykietami wrażliwości w prezentacjach PowerPoint w .NET
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Odczytuj, dodawaj, aktualizuj, usuwaj i migruj etykiety wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Etykiety wrażliwości Microsoft Purview pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez zasadę, zaktualizować jej stan lub migrować metadane etykiety zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides udostępnia nowoczesne metadane etykiet wrażliwości poprzez [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/). Ta właściwość zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="primary" title="Note" %}}
Identyfikatory etykiet wrażliwości i informacje o zasadach są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet oraz wymagania zasad w swojej środowisku przed dodaniem lub migracją metadanych. Wartości [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie własności etykiety wrażliwości**

Każdy [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/) zawiera następujące metadane:

| Właściwość | Cel |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/id/) | Identyfikuje etykietę wrażliwości w polityce Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/siteid/) | Identyfikuje witrynę powiązaną z polityką etykiety. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isenabled/) | Określa, czy etykieta jest włączona. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) | Wskazuje, że etykieta została usunięta. Ustaw tę właściwość na `true`, aby stan usunięcia był zachowany w metadanych. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Określa, czy etykieta została zastosowana automatycznie, czy na podstawie decyzji użytkownika. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Zawiera listę typów oznaczeń treści powiązanych z etykietą. |

Wyliczenie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) opisuje, w jaki sposób etykieta została przypisana:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) oznacza domyślną lub automatycznie zastosowaną etykietę.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) oznacza etykietę zastosowaną w wyniku decyzji użytkownika, w tym etykiety stosowane ręcznie, zalecane i obowiązkowe.

Wyliczenie [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) identyfikuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Z nagłówkiem powiązane jest oznaczenie treści. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Z stopką powiązane jest oznaczenie treści. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Z znakiem wodnym powiązane jest oznaczenie treści. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Z ochroną szyfrowania powiązane jest oznaczenie treści. |

Jednej etykiecie może być przypisanych wiele typów oznaczeń.

## **Wyświetlanie istniejących etykiet wrażliwości**

Odczytaj nowoczesną kolekcję etykiet z [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/) i przeiteruj ją. Poniższy przykład wypisuje każdą właściwość i oznaczenie treści przechowywane dla każdej etykiety:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Dodanie etykiety wrażliwości z oznaczeniem treści**

Użyj [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/) podając identyfikator etykiety, identyfikator witryny, stan włączenia oraz metodę przypisania. Po zwróceniu nowego [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/) dodaj wymagane wartości oznaczeń poprzez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Aktualizacja etykiety wrażliwości**

Właściwości [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem kolekcji zwracanej przez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/), którą modyfikuje się przy użyciu operacji na liście. Po znalezieniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby zachować zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Oznaczenie etykiety wrażliwości jako usuniętej**

Aby zachować informację, że etykieta została usunięta, znajdź ją i ustaw [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) na `true`. To zachowuje wpis etykiety, rejestrując jej stan usunięcia. Jeśli zamiast tego potrzebujesz usunąć wpis z nowoczesnej kolekcji, użyj [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/removeat/); aby usunąć wszystkie wpisy, użyj [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/clear/).

Poniższy przykład oznacza konkretną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Odczyt i migracja starszych etykiet MIP**

Starsze przepływy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych własnościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda analizuje starsze własności niestandardowe i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/) przy użyciu [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/). Ponieważ dodanie etykiety o tym samym identyfikatorze wywołuje wyjątek, przykład najpierw sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową walidację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Migracja kopiuje przetworzone obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich własności niestandardowych dokumentu, więc niezwiązane metadane pozostają nienaruszone. Użyj [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/) aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane poprzez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdów osobno, jeśli Twój przepływ wymaga renderowania tych oznaczeń.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Ustawienie [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) na `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/removeat/) usuwa wpis z nowoczesnej kolekcji. Wybierz operację zgodną z wymaganiami organizacji dotyczącymi retencji metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostać w niestandardowych własnościach dokumentu, podczas gdy nowoczesne etykiety są dostępne przez [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/). Użyj [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/getsensitivitylabels/) aby odczytać starsze metadane i migrować tylko te etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana wielokrotnie?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/) zgłasza `ArgumentException`, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości [ISensitivityLabel.Id](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/id/) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/), jak pokazano w powyższych przykładach.