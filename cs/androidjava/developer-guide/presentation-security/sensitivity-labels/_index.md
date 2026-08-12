---
title: Správa štítků citlivosti v prezentacích PowerPoint na Androidu
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/androidjava/sensitivity-labels/
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
- bezpečnost prezentací
- Android
- Java
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v prezentacích PowerPoint PPTX pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

Microsoft Purview štítky citlivosti pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentace může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides pro Android přes Java poskytuje moderní metadata štítků citlivosti prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Tato metoda vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/), kterou lze zkontrolovat a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Poznámka" %}}

Identifikátory štítků citlivosti a informace o politice jsou definovány ve vaší konfiguraci Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) popisují obsahové označení spojené se štítkem; samy o sobě nepřidávají viditelný text ani tvary do snímků.

{{% /alert %}}

## **Pochopení vlastností štítku citlivosti**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getId--) a [ISensitivityLabel.setId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setId-java.lang.String-) | Získat nebo nastavit identifikátor štítku citlivosti v politice Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getSiteId--) a [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setSiteId-java.util.UUID-) | Získat nebo nastavit web, ke kterému je politika štítku přiřazena. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#isEnabled--) a [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setEnabled-boolean-) | Získat nebo nastavit, zda je štítek povolen. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#isRemoved--) a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) | Získat nebo nastavit, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když má být stav odebrání zachován v metadatech. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getAssignmentMethodType--) a [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setAssignmentMethodType-int-) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) | Získat typy obsahových označení spojených se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) určuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) určuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím nebo automatickým způsobem. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | S hlavičkou je spojeno obsahové označení. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | S patičkou je spojeno obsahové označení. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | S vodoznakem je spojeno obsahové označení. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.sensitivitylabelcontenttype/) | Štítek je spojen s šifrovacím zabezpečením. |

Jednomu štítku může být přiřazeno více typů označení.

## **Vypsání existujících štítků citlivosti**

Načtěte moderní kolekci štítků z [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--) a projděte ji. Následující příklad vypíše všechny vlastnosti a obsahová označení uložená pro každý štítek:

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

Použijte [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po návratu nové [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/) přidejte požadované hodnoty označení prostřednictvím seznamu vráceného metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--).

Následující příklad přidá ručně vybraný štítek spojený s označením patičky a vodoznaku a poté výsledek uloží jako PPTX:

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

Hodnoty [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/) jsou čitelné i zapisovatelné, kromě toho, že seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) se upravuje prostřednictvím jeho operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odebrání a typy obsahových označení. Uložte prezentaci, aby se změny zachovaly.

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

## **Označení štítku citlivosti jako odebraného**

Chcete‑li zachovat informaci, že byl štítek odebrán, najděte štítek a zavolejte [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) s hodnotou `true`. Tím se zachová záznam štítku a zaznamená se jeho odebraný stav. Pokud místo toho potřebujete smazat záznam z moderní kolekce, použijte [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-); pro smazání všech záznamů použijte [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#clear--).

Následující příklad označí konkrétní štítek jako odebraný a uloží aktualizovanou prezentaci:

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

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Načtěte tato metadata pomocí [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--). Metoda parsuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad nejprve zkontroluje cílovou kolekci, než zkopíruje každý štítek. Můžete přidat další ověření, aby bylo potvrzeno, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje parsované objekty štítků do moderní kolekce. Není nutné vymazat všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata zůstávají nedotčena. Použijte [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.saveformat/) pro zápis moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu obsahového označení viditelnou hlavičku, patičku nebo vodoznak na snímcích?**

Ne. Hodnoty přidané prostřednictvím seznamu vráceného metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getContentMarkTypes--) popisují označení spojená se štítkem citlivosti. Nevytvářejí žádný viditelný text ani tvary v prezentaci. Pokud váš pracovní postup musí tato označení vykreslit, přidejte odpovídající obsah snímků samostatně.

** Jaký je rozdíl mezi označením štítku jako odebraného a jeho smazáním z kolekce?**

Volání [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#setRemoved-boolean-) s hodnotou `true` ponechá záznam štítku a zaznamená jeho odebraný stav. Volání [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#removeAt-int-) odstraní záznam z moderní kolekce. Zvolte operaci, která odpovídá požadavkům vaší organizace na uchování metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstávat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.ipresentation/#getSensitivityLabels--). Pro načtení starých metadat použijte [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.idocumentproperties/#getSensitivityLabels--) a migrujte pouze platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když se štítek se stejným identifikátorem přidá vícekrát?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.isensitivitylabel/#getId--).

**V jakém výstupním formátu by se mělo uložit, aby se zachovaly aktualizované štítky citlivosti?**

Uložte prezentaci jako PPTX voláním [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.saveformat/), jak je ukázáno v příkladech výše.