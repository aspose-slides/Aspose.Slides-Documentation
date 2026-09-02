---
title: Správa štítků citlivosti v prezentacích PowerPoint v Pythonu
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v prezentacích PowerPoint PPTX pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatizovaného zpracování prezentace může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku zapsaná starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides for Python via .NET zpřístupňuje moderní metadata štítků citlivosti prostřednictvím [Presentation.sensitivity_labels](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sensitivity_labels/). Tento vlastnost vrací [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/), kterou lze prohlédnout a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Poznámka" %}}
Identifikátory štítků citlivosti a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politik ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/content_mark_types/) popisují obsahové označení spojené se štítkem; samy o sobě nepřidávají viditelný text ani tvary do snímků.
{{% /alert %}}

## **Pochopení vlastností štítku citlivosti**

Každý [SensitivityLabel](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/) obsahuje následující metadata:

| Vlastnost | Účel |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/id/) | Identifikuje štítek citlivosti v politice Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifikuje web (site) spojený s politikou štítku. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indikuje, zda je štítek povolen. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/is_removed/) | Ukazuje, že štítek byl odstraněn. Nastavte tuto vlastnost na `True`, pokud má být stav odstranění zachován v metadatech. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Určuje, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Uvádí typy obsahových označení spojené se štítkem. |

Výčtový typ [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelassignmenttype/) popisuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Výčtový typ [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) identifikuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím způsobem nebo automaticky. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu záhlaví. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu zápatí. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu vodoznaku. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazena šifrovací ochrana. |

S jedním štítkem může být spojeno více typů označení.

## **Seznam existujících štítků citlivosti**

Přečtěte moderní kolekci štítků z [Presentation.sensitivity_labels](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sensitivity_labels/) a proveďte její enumeraci. Následující příklad vypisuje každou vlastnost a obsahové označení uložené pro každý štítek:

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

## **Přidání štítku citlivosti s obsahovým označením**

Použijte [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/add/) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Identifikátor webu předávejte jako objekt Python `uuid.UUID`. Po návratu metody nového [SensitivityLabel](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/), přidejte požadované hodnoty označení do [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Následující příklad přidá ručně vybraný štítek spojený s označením zápatí a vodoznaku a poté uloží výsledek jako PPTX:

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

## **Aktualizace štítku citlivosti**

Vlastnosti [SensitivityLabel](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/) jsou čitelné i zapisovatelné, kromě toho, že seznam vrácený z [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/content_mark_types/) se mění pomocí jeho operací se seznamem. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy obsahových označení. Uložte prezentaci, aby se změny zachovaly.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

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

## **Označení štítku citlivosti jako odstraněného**

Aby se zachovala informace, že byl štítek odstraněn, najděte štítek a nastavte [SensitivityLabel.is_removed](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/is_removed/) na `True`. Tím se zachová záznam štítku a zaznamená jeho stav odstranění. Pokud místo toho potřebujete odstranit záznam z moderní kolekce, použijte [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); použijte [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/clear/) k smazání všech záznamů.

Následující příklad označí konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

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

## **Čtení a migrace starších štítků citlivosti MIP**

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Tato metadata načtěte pomocí [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Metoda parsuje starší vlastní vlastnosti a vrací objekty [SensitivityLabel](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/).

Aby se metadata migrovala, přidejte každý vrácený štítek do moderní [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/) pomocí [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/add/). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad kontroluje cílovou kolekci před kopírováním každého štítku. Můžete přidat další ověření, aby se potvrdilo, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace kopíruje parsované objekty štítků do moderní kolekce. Není nutné mazat všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčeny. Použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) s [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu obsahového označení viditelný záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/content_mark_types/) popisují označení spojená se štítkem citlivosti. Nevytvářejí viditelný text ani tvary v prezentaci. Přidejte odpovídající obsah snímku samostatně, pokud váš pracovní postup musí tato označení zobrazit.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Nastavení [SensitivityLabel.is_removed](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/is_removed/) na `True` zachovává záznam štítku a zaznamenává jeho stav odstranění. Volání [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) smaže záznam z moderní kolekce. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará metadata MIP, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [Presentation.sensitivity_labels](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/sensitivity_labels/). Použijte [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) k načtení starých metadat a migrujte pouze platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán vícekrát?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabelcollection/add/) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Zkontrolujte existující hodnoty [SensitivityLabel.id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sensitivitylabel/id/) před přidáním nebo migrací štítků.

**Jaký výstupní formát by měl být použit k zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) s [SaveFormat.PPTX](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/saveformat/), jak je ukázáno v příkladech výše.