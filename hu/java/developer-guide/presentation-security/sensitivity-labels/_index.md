---
title: "PowerPoint-prezentációk érzékenységi címkéinek kezelése Java-ban"
linktitle: "Érzékenységi címkék"
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
- dokumentum-irányítás
- PowerPoint
- PPTX
- prezentációbiztonság
- Java
- Aspose.Slides
description: "Olvasd, hozzáad, frissítsd, távolítsd el és migráld a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és szabályozásában. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy szabályzat által kiválasztott címkét, frissítenie kell annak állapotát, vagy migrálnia kell a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Az Aspose.Slides a modern érzékenységi címke metaadatokat a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével teszi elérhetővé. Ez a metódus egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/) objektumot ad vissza, amely ellenőrizhető és módosítható, mielőtt a prezentáció PPTX formátumban kerül mentésre.

{{% alert color="primary" title="Megjegyzés" %}}

Az érzékenységi címke azonosítókat és a szabályzati információkat a Microsoft Purview beállítása határozza meg. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetében, mielőtt metaadatokat adna hozzá vagy migrálna. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) értékek a címkéhez kapcsolódó tartalomjelöléseket írják le; önmagukban nem hoznak létre látható szöveget vagy alakzatot a diákon.

{{% /alert %}}

## **Az érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Módszerek | Cél |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getId--) és [ISensitivityLabel.setId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Az érzékenységi címke azonosítójának lekérése vagy beállítása a Purview szabályzatban. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getSiteId--) és [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | A címke szabályzathoz kapcsolódó webhely lekérése vagy beállítása. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#isEnabled--) és [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | A címke engedélyezett állapotának lekérése vagy beállítása. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#isRemoved--) és [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | A címke eltávolított állapotának lekérése vagy beállítása. Állítsa `true`-ra, ha a eltávolítási állapotot a metaadatban meg kell őrizni. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) és [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | A címke automatikus vagy felhasználói döntés alapján történő alkalmazásának lekérése vagy beállítása. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | A címkéhez kapcsolódó tartalomjelölési típusok lekérése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) osztály határozza meg, hogyan lett a címke hozzárendelve:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) az alapértelmezett vagy automatikusan alkalmazott címkét jelöli.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelassignmenttype/) a felhasználói döntés alapján alkalmazott címkét jelöli, beleértve a manuálisan alkalmazott, javasolt és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) osztály határozza meg a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A címkét alapértelmezés szerint vagy automatikusan alkalmazták. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A fejléctartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A lábléc tartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | A vízjel tartalom jelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem kapcsolódik a címkéhez. |

Több jelöléstípus is kapcsolódhat egy címkéhez.

## **Meglévő érzékenységi címkék felsorolása**

Olvassa be a modern címkegyűjteményt a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével, és enumerálja azt. A következő példa minden tulajdonságot és tartalomjelölést sorol fel, amely egy címkéhez tárolva van:

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

Használja a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) metódust a címke azonosítóval, webhelyazonosítóval, engedélyezett állapottal és hozzárendelési módszerrel. Miután a metódus visszaadja az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) objektumot, adja hozzá a szükséges jelölési értékeket a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listán keresztül.

A következő példa manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelölésekkel kapcsolódik, majd PPTX-ként menti az eredményt:

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

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) értékei olvashatók/írhatók, kivéve, hogy a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott lista a lista műveletein keresztül módosítható. A kívánt címke megtalálása után frissítheti annak azonosítóját, webhelyazonosítóját, engedélyezett állapotát, hozzárendelési módszerét, eltávolított állapotát és tartalomjelölési típusait. Mentse a prezentációt a változások elmentéséhez.

A következő példa frissíti az első címke engedélyezett állapotát és hozzárendelési módszerét:

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

## **Érzékenységi címke megjelölése eltávolítottként**

A címke eltávolításának megőrzéséhez keresse meg a címkét, és hívja meg a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metódust `true` értékkel. Ez megtartja a címke bejegyzését, miközben rögzíti az eltávolított állapotát. Ha ehelyett a modern gyűjteményből szeretne bejegyzést törölni, használja a [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) metódust; a [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#clear--) metódus minden bejegyzést töröl.

A következő példa egy konkrét címkét megjelöl eltávolítottként, és elmenti a frissített prezentációt:

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

Az idősebb, MIP-alapú munkafolyamatok a modern címkegyűjtemény helyett egyedi dokumentumtulajdonságokban tárolhatják az érzékenységi címke metaadatokat. Olvassa be ezeket a metaadatokat a [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódussal. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá az egyes visszaadott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/) gyűjteményhez a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) segítségével. Mivel egy duplikált címkeazonosító hozzáadása kivételt vált ki, a példa a másolás előtt ellenőrzi a célgyűjteményt. További ellenőrzést is beépíthet, hogy megerősítse, a régi címke még mindig létezik-e az aktuális Purview szabályzatban.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyedi dokumentumtulajdonságot törölni, így a nem kapcsolódó dokumentummetaadatok érintetlenek maradnak. Használja az [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) lehetőséggel a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**Létrehoz-e egy tartalomjelölés típus látható fejléct, láblécet vagy vízjelet a diákon?**

Nem. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) listáján keresztül hozzáadott értékek a címkéhez kapcsolódó jelöléseket írják le. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. A megfelelő diatartalmat külön kell hozzáadni, ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket.

**Mi a különbség a címke eltávolítottként megjelölése és a gyűjteményből való törlése között?**

A [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) `true` értékkel való meghívása megtartja a címke bejegyzését, és rögzíti az eltávolított állapotát. A [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) meghívása a bejegyzést törli a modern gyűjteményből. Válassza azt a műveletet, amelyik megfelel a szervezet metaadat-megőrzési követelményeinek.

**Tartalmazhat-e egy prezentáció egyszerre régi MIP metaadatokat és modern érzékenységi címkéket?**

Igen. A régi címkék maradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével érhetők el. Használja a [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódust a régi metaadatok olvasásához, és migrálja csak azokat a címkéket, amelyek még nincsenek jelen a modern gyűjteményben.

**Mi történik, ha ugyanazzal az azonosítóval rendelkező címkét többször hozzáadják?**

Az [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kivételt dob, ha a gyűjtemény már tartalmaz egy azonos azonosítóval rendelkező címkét. Ellenőrizze a [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isensitivitylabel/#getId--) által visszaadott meglévő értékeket, mielőtt hozzáadna vagy migrálná a címkéket.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódus [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) paraméterrel történő meghívásával, ahogyan a fenti példák mutatják.