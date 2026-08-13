---
title: Správa štítků citlivosti v prezentacích PowerPoint v .NET
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/net/sensitivity-labels/
keywords:
- štítek citlivosti
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- označení obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentací
- .NET
- C#
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v prezentacích PowerPoint PPTX pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatizovaného zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítků zapsaná starším pracovním procesem Microsoft Information Protection (MIP).

Aspose.Slides zpřístupňuje moderní metadata štítků citlivosti prostřednictvím [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/). Tato vlastnost vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/), kterou lze zkontrolovat a upravit před uložením prezentace jako PPTX.

{{% alert color="info" title="Note" %}}
Identifikátory štítků citlivosti a informace o politice jsou definovány ve vaší konfiguraci Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) popisují označení obsahu spojená se štítkem; samy o sobě nepřidávají na snímky viditelný text ani tvary.
{{% /alert %}}

## **Pochopte vlastnosti štítků citlivosti**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Vlastnost | Účel |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/id/) | Identifikuje štítek citlivosti v politice Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/siteid/) | Identifikuje web spojený s politikou štítku. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isenabled/) | Určuje, zda je štítek povolen. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) | Uvádí, že štítek byl odstraněn. Nastavte tuto vlastnost na `true`, pokud má být stav odstranění zachován v metadatech. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Určuje, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Uvádí typy označení obsahu spojené se štítkem. |

Výčtová hodnota [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) popisuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný rozhodnutím uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Výčtová hodnota [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) identifikuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím způsobem nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Oznámení obsahu záhlaví je spojeno se štítkem. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Oznámení obsahu paty je spojeno se štítkem. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Oznámení obsahu vodoznaku je spojeno se štítkem. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/net/aspose.slides/sensitivitylabelcontenttype/) | Šifrování je spojeno se štítkem. |

Více typů označení může být přiřazeno k jednomu štítku.

## **Vypsat existující štítky citlivosti**

Načtěte moderní kolekci štítků z [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/) a projděte ji. Následující příklad vypisuje každou vlastnost a označení obsahu uložené pro každý štítek:

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

## **Přidat štítek citlivosti s označením obsahu**

Použijte [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po vrácení nové [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/) přidejte požadované hodnoty označení pomocí [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Následující příklad přidává ručně vybraný štítek spojený s označením paty a vodoznaku a poté výsledek uloží jako PPTX:

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

## **Aktualizovat štítek citlivosti**

Vlastnosti [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/) jsou čitelné i zapisovatelné, kromě toho, že kolekce vrácená přes [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) se mění pomocí operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

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

## **Označit štítek citlivosti jako odstraněný**

Aby se zachoval fakt, že byl štítek odstraněn, najděte štítek a nastavte [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) na `true`. Tím se zachová záznam o štítku a zaznamená se jeho stav odstranění. Pokud místo toho potřebujete smazat záznam z moderní kolekce, použijte [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/removeat/); pro smazání všech záznamů použijte [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/clear/).

Následující příklad označuje konkrétní štítek jako odstraněný a ukládá aktualizovanou prezentaci:

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

## **Načíst a migrovat staré MIP štítky citlivosti**

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Načtěte tato metadata pomocí [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad kontroluje cílovou kolekci před kopírováním každého štítku. Můžete přidat další ověření, aby se potvrdilo, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Není nutné čistit všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčena. Použijte [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu označení obsahu viditelné záhlaví, patu nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/contentmarktypes/) popisují označení spojená se štítkem citlivosti. Nevytvářejí ve prezentaci viditelný text ani tvary. Pokud váš pracovní postup musí tato označení vykreslit, přidejte odpovídající obsah snímků samostatně.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Nastavení [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/isremoved/) na `true` zachovává záznam o štítku a zaznamená jeho stav odstranění. Volání [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/removeat/) odstraní záznam z moderní kolekce. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [Presentation.SensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sensitivitylabels/). Použijte [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/cs/net/aspose.slides/idocumentproperties/getsensitivitylabels/) ke čtení starých metadat a migrujte pouze platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán více než jednou?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabelcollection/add/) vyvolá `ArgumentException`, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty [ISensitivityLabel.Id](https://reference.aspose.com/slides/cs/net/aspose.slides/isensitivitylabel/id/).

**Jaký výstupní formát použít k zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) s parametrem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/), jak je ukázáno v příkladech výše.