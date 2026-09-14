---
title: Spravovat štítky citlivosti v PowerPoint prezentacích v Pythonu
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/python-java/sensitivity-labels/
keywords:
- štítek citlivosti
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentací
- Python
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v PowerPoint PPTX prezentacích pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Microsoft Purview štítky citlivosti pomáhají organizacím klasifikovat a řídit dokumenty. Během automatizovaného zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides zpřístupňuje moderní metadata štítků citlivosti přes [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSensitivityLabels). Tato metoda vrací [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/), kterou lze prozkoumat a upravit před uložením prezentace jako PPTX.

{{% alert color="info" title="Poznámka" %}}

Identifikátory štítků citlivosti a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují typy označení obsahu přiřazené ke štítku; samy o sobě nepřidávají viditelný text ani tvary do snímků.

{{% /alert %}}

## **Pochopení vlastností štítku citlivosti**

Každý [SensitivityLabel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [getId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getId) a [setId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setId) | Získat nebo nastavit identifikátor štítku citlivosti v politice Purview. |
| [getSiteId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getSiteId) a [setSiteId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Získat nebo nastavit webové místo spojené s politikou štítku. |
| [isEnabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#isEnabled) a [setEnabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Získat nebo nastavit, zda je štítek povolen. |
| [isRemoved](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#isRemoved) a [setRemoved](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Získat nebo nastavit, zda byl štítek odebrán. Nastavte hodnotu na `True`, když je třeba zachovat stav odstranění v metadatech. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) a [setAssignmentMethodType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [getContentMarkTypes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Získat typy označení obsahu spojené se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelassignmenttype/) definuje způsob přiřazení štítku:

- [Standard](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [Privileged](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě uživatelského rozhodnutí, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) určuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [None](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím nebo automatickým způsobem. |
| [Header](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) | Obsah označení záhlaví je spojen s štítkem. |
| [Footer](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) | Obsah označení zápatí je spojen s štítkem. |
| [Watermark](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) | Obsah označení vodoznaku je spojen s štítkem. |
| [Encryption](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcontenttype/) | Šifrovací ochrana je spojená se štítkem. |

Jednotlivému štítku může být přiřazeno více typů označení.

## **Seznam existujících štítků citlivosti**

Načtěte moderní kolekci štítků pomocí [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSensitivityLabels) a projděte ji. Následující příklad vypíše každou vlastnost a označení obsahu uložené pro každý štítek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Přidání štítku citlivosti s označením obsahu**

Použijte [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#add) s identifikátorem štítku, identifikátorem webového místa, stavem povolení a metodou přiřazení. Po návratu nové instance [SensitivityLabel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/) přidejte požadované hodnoty označení prostřednictvím seznamu vráceného metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Následující příklad přidá ručně vybraný štítek spojený se zápatím a vodoznakem a následně výsledek uloží jako PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktualizace štítku citlivosti**

Hodnoty [SensitivityLabel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/) jsou čitelné i zapisovatelné, s výjimkou seznamu vráceného metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), který se upravuje pomocí operací na seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webového místa, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Označit štítek citlivosti jako odstraněný**

Pro zachování informace, že byl štítek odstraněn, najděte štítek a zavolejte [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setRemoved) s hodnotou `True`. Tím se zachová záznam o štítku a zaznamená jeho stav odstranění. Pokud místo toho potřebujete ze moderní kolekce položku odstranit, použijte [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); pro smazání všech položek použijte [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#clear).

Následující příklad označí konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Čtení a migrace starých MIP štítků citlivosti**

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Přečtěte tato metadata pomocí [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [SensitivityLabel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/) pomocí [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#add). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad před kopírováním každého štítku kontroluje cílovou kolekci. Můžete přidat další ověření, aby bylo jisté, že každý starý štítek stále existuje v aktuální politice Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Migrace kopíruje analyzované objekty štítků do moderní kolekce. Nevyžaduje vymazání všech vlastních vlastností dokumentu, takže nesouvisející metadata zůstávají zachována. Použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu označení obsahu viditelné záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes seznam vrácený metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují označení spojené se štítkem citlivosti. Nevytvářejí viditelný text ani tvary v prezentaci. Pokud váš pracovní postup musí tato označení vykreslit, přidejte odpovídající obsah snímků samostatně.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním ze sbírky?**

Volání [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#setRemoved) s `True` ponechá záznam o štítku a zaznamená jeho stav odstranění. Volání [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) štítek ze moderní sbírky odstraní. Zvolte operaci, která odpovídá požadavkům vaší organizace na uchování metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSensitivityLabels). Použijte [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getSensitivityLabels) k načtení starých metadat a migrujte pouze platné štítky, které ještě nejsou v moderní sbírce.

**Co se stane, když je štítek se stejným identifikátorem přidán více než jednou?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabelcollection/#add) vyvolá výjimku, pokud sbírka již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [SensitivityLabel.getId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sensitivitylabel/#getId).

**Jaký výstupní formát použít k zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/), jak je ukázáno v příkladech výše.