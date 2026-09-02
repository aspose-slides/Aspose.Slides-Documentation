---
title: Správa štítků citlivosti v PowerPoint prezentacích v Javě
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/java/sensitivity-labels/
keywords:
- štítek citlivosti
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentace
- Java
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v PowerPoint PPTX prezentacích pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentace může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku zapsaná starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides vystavuje moderní metadata štítků citlivosti prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Tato metoda vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/), kterou lze prozkoumat a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Poznámka" %}}
Identifikátory štítků citlivosti a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítku a požadavky politiky ve vašem prostředí, než přidáte nebo migrujete metadata. Hodnoty [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují obsahové označení spojené se štítkem; samy o sobě nepřidávají viditelný text ani tvary do snímků.
{{% /alert %}}

## **Pochopení vlastností označení citlivosti**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getId--) a [ISensitivityLabel.setId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Získat nebo nastavit identifikátor štítku citlivosti v politice Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getSiteId--) a [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Získat nebo nastavit místo (site) spojené s politikou štítku. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#isEnabled--) a [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Získat nebo nastavit, zda je štítek povolen. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#isRemoved--) a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Získat nebo nastavit, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když má být stav odstranění zachován v metadatech. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) a [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Získat typy obsahových označení spojených se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) určuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) definuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím způsobem nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení hlavičky. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení paty. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení vodoznaku. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazena ochrana šifrováním. |

Více typů označení může být přiřazeno jednomu štítku.

## **Seznam existujících štítků citlivosti**

Načtěte moderní kolekci štítků pomocí [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) a enumerujte ji. Následující příklad vypisuje každou vlastnost a obsahové označení uložené pro každý štítek:

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

## **Přidání štítku citlivosti s obsahovým označením**

Použijte [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) s identifikátorem štítku, identifikátorem místa, stavem povolení a metodou přiřazení. Po vrácení nového [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) přidejte požadované hodnoty označení prostřednictvím seznamu vráceného metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Následující příklad přidává ručně vybraný štítek spojený s označením paty a vodoznaku a poté výsledek uloží jako PPTX:

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

## **Aktualizace štítku citlivosti**

Hodnoty [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) jsou čitelné i zapisovatelné, kromě toho, že seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) se upravuje pomocí operací na tomto seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor místa, stav povolení, metodu přiřazení, stav odstranění a typy obsahových označení. Uložte prezentaci, aby se změny projevily.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

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

## **Označení štítku citlivosti jako odstraněného**

Chcete‑li zachovat informaci o tom, že byl štítek odstraněn, najděte štítek a zavolejte [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true`. Tím se uchová záznam štítku a zaznamená jeho stav odstranění. Pokud místo toho potřebujete ze moderní kolekce štítek odstranit, použijte [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); pro smazání všech položek použijte [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#clear--).

Následující příklad označí konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

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

## **Čtení a migrace starých MIP štítků citlivosti**

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Načtěte tato metadata pomocí [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoda parsuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad před kopírováním každého štítku kontroluje cílovou kolekci. Můžete doplnit další ověření, aby bylo jisté, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje parsované objekty štítků do moderní kolekce. Nevyžaduje vymazání všech vlastních vlastností dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčena. Použijte [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu obsahového označení viditelnou hlavičku, patu nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují označení spojená se štítkem citlivosti. Nevytvářejí viditelný text ani tvary v prezentaci. Příslušný obsah snímku přidejte samostatně, pokud váš pracovní postup musí tato označení zobrazit.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true` ponechá záznam štítku a zaznamená jeho stav odstranění. Volání [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) štítek z moderní kolekce odstraní. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Použijte [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) k načtení starých metadat a migrujte jen platné štítky, které ještě v moderní kolekci nejsou.

**Co se stane, když je štítek se stejným identifikátorem přidán více než jednou?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getId--).

**Jaký výstupní formát použít pro zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/), jak je ukázáno v příkladech výše.