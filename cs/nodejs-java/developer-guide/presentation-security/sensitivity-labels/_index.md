---
title: Spravovat citlivé štítky v PowerPoint prezentacích v JavaScriptu
linktitle: Citlivé štítky
type: docs
weight: 50
url: /cs/nodejs-java/sensitivity-labels/
keywords:
- citlivý štítek
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- zabezpečení prezentací
- Node.js
- JavaScript
- Aspose.Slides
description: "Číst, přidávat, aktualizovat, odstraňovat a migrovat citlivé štítky Microsoft Purview v PowerPoint PPTX prezentacích pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides for Node.js via Java vystavuje moderní metadata citlivých štítků prostřednictvím [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Tento metod vrací [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/), kterou lze prohlédnout a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Note" %}}

Identifikátory citlivých štítků a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politik ve vašem prostředí před přidáním nebo migrací metadat. Hodnoty [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují označení obsahu spojená se štítkem; samy o sobě nepřidávají viditelný text ani tvary na snímky.

{{% /alert %}}

## **Pochopení vlastností citlivých štítků**

Každý [SensitivityLabel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getId) a [SensitivityLabel.setId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Získat nebo nastavit identifikátor citlivého štítku v politice Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) a [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Získat nebo nastavit místo (site) spojené s politikou štítku. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) a [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Získat nebo nastavit, zda je štítek povolen. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Získat nebo nastavit, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když má být stav odstranění zachován v metadatech. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) a [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Získat typy označení obsahu spojené se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) definuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozí nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu záhlaví je spojeno se štítkem. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu zápatí je spojeno se štítkem. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu vodoznaku je spojeno se štítkem. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Šifrovací ochrana je spojena se štítkem. |

Více typů označení může být spojeno s jedním štítkem.

## **Seznam existujících citlivých štítků**

Přečtěte moderní kolekci štítků pomocí [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) a projděte ji. Následující příklad vypisuje každou vlastnost a označení obsahu uložené pro každý štítek:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Přidat citlivý štítek s označením obsahu**

Použijte [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) s identifikátorem štítku, identifikátorem místa, stavem povolení a metodou přiřazení. Po vrácení nového [SensitivityLabel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/) přidejte požadované hodnoty označení pomocí seznamu vráceného metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Následující příklad přidává ručně vybraný štítek spojený se zápatím a vodoznakem a potom výsledek uloží jako PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aktualizovat citlivý štítek**

Hodnoty [SensitivityLabel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/) jsou čitelné i zapisovatelné, s výjimkou toho, že seznam vrácený metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) se mění pomocí operací na tomto seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor místa, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Označit citlivý štítek jako odstraněný**

Chcete‑li zachovat fakt, že byl štítek odstraněn, najděte jej a zavolejte [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) s hodnotou `true`. Tím se položka štítku zachová a zaznamená se její stav odstranění. Pokud místo toho potřebujete položku z moderní kolekce odstranit, použijte [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); použijte [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) k odstranění všech položek.

Následující příklad označuje konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Číst a migrovat staré MIP citlivé štítky**

Starší pracovní postupy založené na MIP mohou ukládat metadata citlivých štítků do vlastních vlastností dokumentu místo moderní kolekce štítků. Přečtěte tato metadata pomocí [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [SensitivityLabel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/) pomocí [SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad kontroluje cílovou kolekci před kopírováním každého štítku. Můžete přidat další ověření, aby bylo jisté, že každý starý štítek stále existuje v aktuální politice Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Není nutné vymazat všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčena. Použijte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) k zapsání moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu označení obsahu viditelný záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané prostřednictvím seznamu vráceného metodou [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují označení spojená se štítkem. Nevytvářejí viditelný text ani tvary v prezentaci. Pokud váš pracovní postup musí tato označení zobrazit, přidejte odpovídající obsah snímků samostatně.

** Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) s hodnotou `true` ponechává položku štítku a zaznamenává jeho stav odstranění. Volání [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) štítek z moderní kolekce odstraní. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní citlivé štítky?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou k dispozici pomocí [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Použijte [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) k načtení starých metadat a migrujte jen platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když se štítek se stejným identifikátorem přidá vícekrát?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [SensitivityLabel.getId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sensitivitylabel/#getId).

**Jaký výstupní formát použít k zachování aktualizovaných citlivých štítků?**

Uložte prezentaci jako PPTX voláním [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/), jak je uvedeno v příkladech výše.