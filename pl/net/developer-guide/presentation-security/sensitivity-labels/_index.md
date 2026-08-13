---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w .NET
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Odczytuj, dodawaj, aktualizuj, usuwaj i migruj etykiety wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez politykę, zaktualizować jej stan lub migrować metadane etykiety zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides udostępnia nowoczesne metadane etykiet wrażliwości poprzez [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/). Ta właściwość zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/), którą można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="info" title="Note" %}}

Identyfikatory etykiet wrażliwości i informacje o polityce są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania polityki w swoim środowisku przed dodaniem lub migracją metadanych. Wartości [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) opisują oznaczenia treści powiązane z etykietą; same nie dodają widocznego tekstu ani kształtów na slajdach.

{{% /alert %}}

## **Zrozumienie właściwości etykiety wrażliwości**

Każdy [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/) zawiera następujące metadane:

| Właściwość | Cel |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/id/) | Identyfikuje etykietę wrażliwości w polityce Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/siteid/) | Identyfikuje witrynę powiązaną z polityką etykiety. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isenabled/) | Wskazuje, czy etykieta jest włączona. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) | Wskazuje, że etykieta została usunięta. Ustaw tę właściwość na `true`, gdy stan usunięcia musi być zachowany w metadanych. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Określa, czy etykieta została zastosowana automatycznie, czy na podstawie decyzji użytkownika. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Wymienia typy oznaczeń treści związane z etykietą. |

Wyliczenie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) opisuje sposób przydzielenia etykiety:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje domyślną lub automatycznie zastosowaną etykietę.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną na podstawie decyzji użytkownika, w tym etykiety ręcznie wybrane, rekomendowane i obowiązkowe.

Wyliczenie [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) identyfikuje oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pl/net/aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wylistowanie istniejących etykiet wrażliwości**

Odczytaj nowoczesną kolekcję etykiet z [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/) i wylicz ją. Poniższy przykład wypisuje każdą właściwość i oznaczenie treści przechowywane dla każdej etykiety:

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

Użyj [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przydzielenia. Po zwróceniu nowego [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/).

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

Właściwości [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/) są odczytywalne i zapisywalne, z wyjątkiem kolekcji zwracanej przez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/), która jest modyfikowana poprzez operacje listy. Po zlokalizowaniu wymaganej etykiety możesz zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przydzielenia, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby utrwalić zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przydzielenia pierwszej etykiety:

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

Aby zachować informację, że etykieta została usunięta, znajdź etykietę i ustaw [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) na `true`. To zachowuje wpis etykiety, jednocześnie rejestrując jej stan usunięcia. Jeśli zamiast tego potrzebujesz usunąć wpis z nowoczesnej kolekcji, użyj [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/removeat/); użyj [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/clear/) aby usunąć wszystkie wpisy.

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

## **Odczyt i migracja starszych etykiet wrażliwości MIP**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane przy użyciu [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda parsuje starsze własności i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/) za pomocą [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/). Ponieważ dodanie etykiety o tym samym identyfikatorze powoduje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

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

Migracja kopiuje sparsowane obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niezwiązane metadane pozostają nienaruszone. Użyj [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane przez [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/contentmarktypes/) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ pracy musi renderować te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Ustawienie [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/isremoved/) na `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/removeat/) usuwa wpis z nowoczesnej kolekcji. Wybierz operację odpowiadającą wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać jednocześnie starsze metadane MIP i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne przez [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sensitivitylabels/). Użyj [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/getsensitivitylabels/), aby odczytać starsze metadane i migrować tylko te ważne, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabelcollection/add/) zgłasza `ArgumentException`, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości [ISensitivityLabel.Id](https://reference.aspose.com/slides/pl/net/aspose.slides/isensitivitylabel/id/) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/), jak pokazano w powyższych przykładach.