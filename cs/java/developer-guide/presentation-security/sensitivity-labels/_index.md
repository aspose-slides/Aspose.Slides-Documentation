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
- metadata MIP
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentací
- Java
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte štítky citlivosti Microsoft Purview v PowerPoint PPTX prezentacích pomocí Aspose.Slides pro Java."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatizovaného zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides vystavuje moderní metadata štítků citlivosti prostřednictvím [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Tato metoda vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/), kterou lze před uložením prezentace jako PPTX prozkoumat a upravit.

{{% alert color="info" title="Poznámka" %}}
Identifikátory štítků citlivosti a informace o politice jsou definovány ve vaší konfiguraci Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují označení obsahu přidružená ke štítku; samy o sobě nepřidávají viditelný text ani tvary do snímků.
{{% /alert %}}

## **Pochopte vlastnosti štítků citlivosti**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Získat nebo nastavit identifikátor štítku citlivosti v politice Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Získat nebo nastavit web přidružený k politice štítku. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Získat nebo nastavit, zda je štítek povolen. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Získat nebo nastavit, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když je třeba stav odstranění uchovat v metadatech. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Získat typy označení obsahu přidružené k štítku. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) definuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) definuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozí nebo automaticky. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu záhlaví je přidruženo k štítku. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu zápatí je přidruženo k štítku. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu vodoznaku je přidruženo k štítku. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sensitivitylabelcontenttype/) | Šifrovací ochrana je přidružena k štítku. |

K jednomu štítku může být přiřazeno více typů označení.

## **Vypsat existující štítky citlivosti**

Přečtěte moderní kolekci štítků z [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) a enumerujte ji. V následujícím příkladu jsou vypsány všechny vlastnosti a označení obsahu uložené pro každý štítek:

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

## **Přidat štítek citlivosti s označením obsahu**

Použijte [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po vrácení nové [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) přidejte požadované hodnoty označení přes seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Následující příklad přidává ručně vybraný štítek spojený se značkami zápatí a vodoznaku a poté výsledek uloží jako PPTX:

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

## **Aktualizovat štítek citlivosti**

Hodnoty [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/) jsou čitelné i zápisovatelné, s výjimkou seznamu vráceného metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), který se upravuje pomocí operací nad tímto seznamem. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

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

## **Označit štítek citlivosti jako odstraněný**

Pro zachování informace, že byl štítek odstraněn, najděte štítek a zavolejte [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true`. Tím se štítek ponechá v kolekci a zaznamená se jeho stav odstranění. Pokud místo toho potřebujete položku z moderní kolekce smazat, použijte [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); k odstranění všech položek použijte [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#clear--).

Následující příklad označuje konkrétní štítek jako odstraněný a ukládá aktualizovanou prezentaci:

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

## **Číst a migrovat starší štítky citlivosti MIP**

Starší workflow založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Tato metadata načtěte pomocí [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Protože přidání štítku se stejným identifikátorem vyvolá výjimku, příklad před kopírováním každého štítku kontroluje cílovou kolekci. Můžete přidat další ověření, aby bylo jisté, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Není nutné mazat všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata zůstávají nedotčena. Použijte [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **FAQ**

**Vytváří přidání typu označení obsahu viditelný záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané přes seznam vrácený metodou [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) popisují označení spojená se štítkem citlivosti. Nevytvářejí viditelný text ani tvary v prezentaci. Pokud váš workflow musí tato označení vykreslit, přidejte odpovídající obsah snímků samostatně.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) s hodnotou `true` zachová položku štítku a zaznamená jeho stav odstranění. Volání [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) položku z moderní kolekce odstraní. Zvolte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará metadata MIP, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné přes [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Použijte [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) k načtení starých metadat a migrujte jen platné štítky, které už nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán více než jednou?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [ISensitivityLabel.getId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isensitivitylabel/#getId--).

**Jaký výstupní formát použít pro zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/), jak je ukázáno v příkladech výše.