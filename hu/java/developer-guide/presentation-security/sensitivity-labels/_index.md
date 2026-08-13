---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban Java-val
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/java/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadatok
- tartalomjelölés
- információvédelem
- dokumentumkezelés
- PowerPoint
- PPTX
- prezentációbiztonság
- Java
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és kezelésében. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, egy szabály által kiválasztott címkét kell alkalmaznia, frissítenie kell annak állapotát, vagy át kell migrálnia egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Az Aspose.Slides a modern érzékenységi címke metaadatokat a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels-- ) segítségével biztosítja. Ez a metódus egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/) objektumot ad vissza, amely a prezentáció PPTX formátumba történő mentése előtt ellenőrizhető és módosítható.

{{% alert color="info" title="Note" %}}
Az érzékenységi címke azonosítókat és a szabályinformációkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabálykövetelményeket a környezetében, mielőtt metaadatokat adna hozzá vagy migrálna. Az [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) értékek a címkéhez kapcsolódó tartalomjelöléseket írják le; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Értse meg az érzékenységi címke tulajdonságait**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Metódusok | Cél |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getId--) és [ISensitivityLabel.setId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Az érzékenységi címke azonosítójának lekérdezése vagy beállítása a Purview szabályban. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getSiteId--) és [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | A címkére szabályhoz kapcsolódó webhely lekérdezése vagy beállítása. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#isEnabled--) és [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | A címke engedélyezett állapotának lekérdezése vagy beállítása. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#isRemoved--) és [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | A címke eltávolításra került-e állapotának lekérdezése vagy beállítása. Állítsa `true`-ra, ha az eltávolítási állapotot meg kell őrizni a metaadatokban. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) és [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | A címke automatikus vagy felhasználói döntésen alapuló alkalmazásának lekérdezése vagy beállítása. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | A címkéhez kapcsolódó tartalomjelölés típusainak lekérdezése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) osztály meghatározza, hogyan került a címke hozzárendelésre:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) a felhasználói döntésen alapuló címkét jelöl, beleértve a kézzel alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) osztály definiálja a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címke alapértelmezés szerint vagy automatikusan lett alkalmazva. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címkéhez fejléctartalom jelölés tartozik. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címkéhez lábléc tartalom jelölés tartozik. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címkéhez vízjel tartalom jelölés tartozik. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címkéhez titkosítási védelem tartozik. |

Több jelöléstípus is kapcsolható egy címkéhez.

## **Létező érzékenységi címkék listázása**

Olvassa be a modern címkegyűjteményt a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével, és enumerálja azt. A következő példa felsorolja az egyes címkékhez tárolt minden tulajdonságot és tartalomjelölést:

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

## **Érzékenységi címke hozzáadása tartalomjelöléssel**

Használja a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) metódust a címke azonosítóval, a webhely azonosítóval, az engedélyezett állapottal és a hozzárendelési móddal. A metódus visszatér a új [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) objektummal, majd adja hozzá a szükséges jelölési értékeket a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listán keresztül.

A következő példa manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelölésekkel kapcsolódik, majd a eredményt PPTX formátumban menti:

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

## **Érzékenységi címke frissítése**

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) értékek olvashatóak/írhatók, kivéve, hogy a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listát a lista műveleteivel módosítja. A szükséges címke megtalálása után frissítheti annak azonosítóját, a webhely azonosítóját, az engedélyezett állapotot, a hozzárendelési módot, az eltávolítási állapotot és a tartalomjelölés típusait. Mentse a prezentációt a változások rögzítéséhez.

A következő példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

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

## **Címke megjelölése eltávolítottként**

A címke eltávolításának megőrzéséhez keresse meg a címkét, és hívja meg az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metódust `true` értékkel. Ez megtartja a címke bejegyzést, miközben rögzíti annak eltávolított állapotát. Ha ehelyett egy bejegyzést szeretne törölni a modern gyűjteményből, használja az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) metódust; az összes bejegyzés törléséhez használja az [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#clear--) metódust.

A következő példa egy adott címkét megjelöl eltávolítottként, majd menti a frissített prezentációt:

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

## **Régi MIP érzékenységi címkék olvasása és migrálása**

A régebbi MIP-alapú munkafolyamatok az érzékenységi címke metaadatokat a modern címkegyűjtemény helyett egyedi dokumentumtulajdonságokban tárolhatják. Olvassa be ezeket a metaadatokat az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) segítségével. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá a visszakapott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/)‑hoz a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) használatával. Mivel a duplikált címkeazonosító hozzáadása kivételt vált ki, a példa ellenőrzi a célgyűjteményt minden címke másolása előtt. További validációt is hozzáadhat, hogy megerősítse, minden régi címke még létezik-e a jelenlegi Purview szabályban.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyedi dokumentumtulajdonság törlése, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja az [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) opcióval a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**A tartalomjelölés típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz létre a diákon?**  
Nem. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listához hozzáadott értékek a címkéhez kapcsolódó jelöléseket írják le; nem hoznak létre látható szöveget vagy alakzatot a prezentációban. A megfelelő dia tartalmat külön kell hozzáadni, ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**  
Az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) `true` értékkel megtartja a címke bejegyzést és rögzíti az eltávolított állapotot. Az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) törli a bejegyzést a modern gyűjteményből. Válassza ki a műveletet, amely megfelel a szervezet metaadatmegőrzési követelményeinek.

**Tartalmazhat-e egy prezentáció egyszerre régi MIP metaadatokat és modern érzékenységi címkéket?**  
Igen. A régi címkék megmaradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék elérhetők a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével. Használja az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódust a régi metaadatok olvasásához, és csak a modern gyűjteményben már nem létező érvényes címkéket migrálja.

**Mi történik, ha ugyanazzal az azonosítóval rendelkező címkét többször hozzáadnak?**  
Az [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kivételt vált ki, ha a gyűjtemény már tartalmaz egy azonos azonosítóval rendelkező címkét. Ellenőrizze a meglévő értékeket a [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getId--) által visszaadottak alapján, mielőtt hozzáadna vagy migrálná a címkéket.

**Milyen kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**  
Mentse a prezentációt PPTX formátumban az [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódus [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) opcióval, ahogyan a fenti példák mutatják.