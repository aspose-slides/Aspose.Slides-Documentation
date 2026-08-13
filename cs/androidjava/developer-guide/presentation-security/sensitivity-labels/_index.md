---
title: Správa citlivostních štítků v prezentacích PowerPoint na Androidu
linktitle: Citlivostní štítky
type: docs
weight: 50
url: /cs/androidjava/sensitivity-labels/
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
- bezpečnost prezentací
- Android
- Java
- Aspose.Slides
description: Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte citlivostní štítky Microsoft Purview v prezentacích PowerPoint PPTX pomocí Aspose.Slides pro Android prostřednictvím Javy.
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítků vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides for Android via Java zpřístupňuje moderní metadata citlivostních štítků prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Tato metoda vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/) , kterou lze zkontrolovat a upravit před uložením prezentace jako PPTX.

{{% alert color="info" title="Poznámka" %}}
Identifikátory citlivostních štítků a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve vašem prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují obsahové označování spojené se štítkem; samy o sobě nepřidávají viditelný text ani tvary do snímků.
{{% /alert %}}

## **Porozumění vlastnostem citlivostních štítků**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getId--) a [ISensitivityLabel.setId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Získá nebo nastaví identifikátor citlivostního štítku v politice Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) a [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Získá nebo nastaví identifikátor webu spojený s politikou štítku. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) a [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Získá nebo nastaví, zda je štítek povolen. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Získá nebo nastaví, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když musí být stav odstranění zachován v metadatech. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) a [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Získá nebo nastaví, zda byl štítek aplikován automaticky nebo rozhodnutím uživatele. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Získá typy obsahových označení spojených se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) určuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) určuje označení spojené se štítkem:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím způsobem nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Značení obsahu hlavičky je spojeno se štítkem. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Značení obsahu patičky je spojeno se štítkem. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Značení obsahu vodoznaku je spojeno se štítkem. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Šifrovací ochrana je spojena se štítkem. |

Jednomu štítku může být přiřazeno více typů označení.

## **Seznam existujících citlivostních štítků**

Načtěte moderní kolekci štítků pomocí [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) a projděte ji. Následující příklad vypisuje všechny vlastnosti a obsahová označení uložená pro každý štítek:

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

## **Přidání citlivostního štítku s obsahovým označením**

Použijte [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po vrácení nové [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/) přidejte požadované hodnoty označení pomocí seznamu vráceného metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Následující příklad přidá ručně vybraný štítek spojený s označením patičky a vodoznaku a poté uloží výsledek jako PPTX:

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

## **Aktualizace citlivostního štítku**

[ISensitivityLabel] hodnoty jsou čitelné i zapisovatelné, kromě toho, že seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) se upravuje pomocí jeho operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy obsahových označení. Uložte prezentaci, aby se změny zachovaly.

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

## **Označení citlivostního štítku jako odstraněného**

Chcete‑li zachovat informaci, že byl štítek odstraněn, najděte štítek a zavolejte [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true`. Tím se zachová položka štítku a zaznamená se jeho stav odstranění. Pokud místo toho potřebujete položku z moderní kolekce smazat, použijte [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); pro smazání všech položek použijte [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--).

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

## **Čtení a migrace starých MIP citlivostních štítků**

Starší pracovní postupy založené na MIP mohou uchovávat metadata citlivostních štítků v uživatelských vlastnostech dokumentu místo moderní kolekce štítků. Načtěte tato metadata pomocí [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoda analyzuje starší uživatelské vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Vzhledem k tomu, že přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad kontroluje cílovou kolekci před kopírováním každého štítku. Můžete přidat další validaci pro ověření, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace kopíruje analyzované objekty štítků do moderní kolekce. Není nutné vymazat všechny uživatelské vlastnosti dokumentu, takže nesouvisející metadata zůstávají nedotčena. Použijte [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/) pro zápis moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu obsahového označení viditelnou hlavičku, patičku nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují označení spojená s citlivostním štítkem. Nevytvářejí ve prezentaci viditelný text nebo tvary. Pokud váš pracovní postup musí tyto označení zobrazit, přidejte odpovídající obsah snímků samostatně.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true` zachová položku štítku a zaznamená jeho stav odstranění. Volání [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) smaže položku z moderní kolekce. Zvolte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní citlivostní štítky?**

Ano. Staré štítky mohou zůstat v uživatelských vlastnostech dokumentu, zatímco moderní štítky jsou k dispozici prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Použijte [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) pro načtení starých metadat a migrujte pouze platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán vícekrát?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isensitivitylabel/#getId--).

**Jaký výstupní formát použít pro zachování aktualizovaných citlivostních štítků?**

Uložte prezentaci jako PPTX voláním [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/), jak je ukázáno v příkladech výše.