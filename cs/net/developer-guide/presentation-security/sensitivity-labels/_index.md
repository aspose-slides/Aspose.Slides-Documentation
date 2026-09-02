---
title: Správa citlivostních štítků v PowerPoint prezentacích v .NET
linktitle: Citlivostní štítky
type: docs
weight: 50
url: /cs/net/sensitivity-labels/
keywords:
- citlivostní štítek
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentace
- .NET
- C#
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte citlivostní štítky Microsoft Purview v PowerPoint PPTX prezentacích pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Microsoft Purview citlivostní štítky pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatizovaného zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku zapsaná starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides zpřístupňuje moderní metadata citlivostních štítků prostřednictvím [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/). Toto vlastnost vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/), kterou lze prozkoumat a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Poznámka" %}}
Identifikátory citlivostních štítků a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve vašem prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) popisují označení obsahu spojená se štítkem; samy o sobě nepřidávají do snímků viditelný text ani tvary.
{{% /alert %}}

## **Porozumění vlastnostem citlivostního štítku**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Vlastnost | Účel |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/id/) | Identifikuje citlivostní štítek v politice Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/siteid/) | Identifikuje lokalitu spojenou s politikou štítku. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isenabled/) | Udává, zda je štítek povolen. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) | Indikuje, že byl štítek odebrán. Nastavte tuto vlastnost na `true`, když je třeba zachovat stav odebrání v metadatech. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Určuje, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Uvádí typy označení obsahu spojené se štítkem. |

Výčtový typ [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) popisuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Výčtový typ [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) určuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozí nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu záhlaví je spojeno se štítkem. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu zápatí je spojeno se štítkem. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu vodoznaku je spojeno se štítkem. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Šifrovací ochrana je spojena se štítkem. |

Více typů označení může být spojeno s jedním štítkem.

## **Vypsání existujících citlivostních štítků**

Načtěte moderní kolekci štítků z [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/) a enumerujte ji. Následující příklad uvádí všechny vlastnosti a označení obsahu uložené pro každý štítek:

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

## **Přidání citlivostního štítku s označením obsahu**

Použijte [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/) s identifikátorem štítku, identifikátorem lokality, stavem povolení a metodou přiřazení. Po vrácení nového [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/), přidejte požadované hodnoty označení prostřednictvím [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Následující příklad přidá ručně vybraný štítek spojený se značením zápatí a vodoznaku a poté uloží výsledek jako PPTX:

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

## **Aktualizace citlivostního štítku**

Vlastnosti [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/) jsou čtení/zápis, kromě toho, že kolekce vrácená [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) se upravuje pomocí operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor lokality, stav povolení, metodu přiřazení, stav odebrání a typy označení obsahu. Uložte prezentaci pro zachování změn.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

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

## **Označení citlivostního štítku jako odebraný**

Pro zachování informace, že byl štítek odebrán, najděte štítek a nastavte [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) na `true`. Tím se zachová položka štítku a zaznamená jeho stav odebrání. Pokud místo toho potřebujete položku z moderní kolekce smazat, použijte [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/removeat/); použijte [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/clear/) pro smazání všech položek.

Následující příklad označí konkrétní štítek jako odebraný a uloží aktualizovanou prezentaci:

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

## **Čtení a migrace starších MIP citlivostních štítků**

Starší pracovní postupy založené na MIP mohou ukládat metadata citlivostních štítků do vlastních vlastností dokumentu místo moderní kolekce štítků. Přečtěte tato metadata pomocí [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad kontroluje cílovou kolekci před zkopírováním každého štítku. Můžete přidat další ověření, aby se potvrdilo, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Nevyžaduje vymazání všech vlastních vlastností dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčena. Použijte [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **FAQ**

**Vytváří přidání typu označení obsahu viditelné záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) popisují označení spojená s citlivostním štítkem. Nevytvářejí v prezentaci viditelný text ani tvary. Pokud váš pracovní postup musí tyto označení vykreslit, přidejte odpovídající obsah snímků samostatně.

**Jaký je rozdíl mezi označením štítku jako odebraného a jeho smazáním ze sbírky?**

Nastavení [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) na `true` zachová položku štítku a zaznamená jeho stav odebrání. Volání [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/removeat/) smaže položku z moderní sbírky. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchování metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní citlivostní štítky?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/). Použijte [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/getsensitivitylabels/) k načtení starých metadat a migrujte pouze platné štítky, které již nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán vícekrát?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/) vyvolá `ArgumentException`, pokud sbírka již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty [ISensitivityLabel.Id](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/id/).

**Jaký výstupní formát by měl být použit k zachování aktualizovaných citlivostních štítků?**

Uložte prezentaci jako PPTX voláním [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/), jak ukazují výše uvedené příklady.