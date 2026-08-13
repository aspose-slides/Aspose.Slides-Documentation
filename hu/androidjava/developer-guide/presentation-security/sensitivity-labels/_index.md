---
title: Érzékenységi címkék kezelése PowerPoint bemutatókban Androidon
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/androidjava/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadat
- tartalomjelölés
- információvédelem
- dokumentum irányítás
- PowerPoint
- PPTX
- bemutató biztonság
- Android
- Java
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX bemutatókban az Aspose.Slides for Android Java használatával."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és irányításában. Az automatikus bemutatófeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy szabályzat által kiválasztott címkét, frissítenie kell annak állapotát, vagy át kell migrálnia egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Az Aspose.Slides for Android Java-n keresztül modern érzékenységi címke metaadatokat tesz elérhetővé a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- ) metódussal. Ez a módszer egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/) példányt ad vissza, amelyet a bemutató PPTX-ként való mentése előtt megtekinthetünk és módosíthatunk.

{{% alert color="info" title="Note" %}}
Az érzékenységi címke azonosítókat és a szabályzati információkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetben, mielőtt metaadatokat adna hozzá vagy migrálna. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) értékek leírják a címkéhez kapcsolódó tartalomjelöléseket; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Az érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/) a következő metaadatokat tartalmazza:

| Módszerek | Cél |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getId--) és [ISensitivityLabel.setId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | A Purview szabályzatban az érzékenységi címke azonosítójának lekérése vagy beállítása. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) és [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | A címkekezeléshez tartozó hely meghatározása vagy beállítása. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) és [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | A címke engedélyezett állapotának lekérése vagy beállítása. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) és [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | A címke eltávolításra került-e állapotának lekérése vagy beállítása. Állítsa `true` értékre, ha a eltávolítási állapotot a metaadatokban meg kell őrizni. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) és [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | A címke automatikus vagy felhasználói döntés által történő alkalmazásának lekérése vagy beállítása. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | A címkéhez kapcsolódó tartalomjelölés típusainak lekérése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) osztály határozza meg, hogyan lett a címke hozzárendelve:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) egy alapértelmezett vagy automatikusan alkalmazott címkét képvisel.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) egy felhasználói döntés által alkalmazott címkét jelöl, beleértve a kézi, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) osztály határozza meg a címkéhez tartozó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | A címke alapértelmezettként vagy automatikusan lett alkalmazva. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | A fejléc tartalomjelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | A lábléc tartalomjelölése kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalomjelölés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem kapcsolódik a címkéhez. |

Több jelöléstípus is társítható egy címkéhez.

## **Meglévő érzékenységi címkék felsorolása**

Olvassa be a modern címkegyűjteményt a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével, és sorolja fel. A következő példa minden tulajdonságot és a címkékhez tárolt tartalomjelölést listáz:

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

Használja a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) metódust a címke azonosítóval, helyazonosítóval, engedélyezett állapottal és hozzárendelési módszerrel. A metódus visszaadja az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/) példányt; ezután adja hozzá a szükséges jelölésértékeket a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listán keresztül.

A következő példa egy kézzel kiválasztott címkét ad hozzá, amely a lábléc és vízjel jelölésekkel van társítva, majd a végeredményt PPTX-formátumban menti:

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

Az [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/) értékek olvashatóak/írhatók, kivéve a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listát, amelyet a lista műveleteivel módosítanak. A szükséges címke megtalálása után frissítheti az azonosítóját, helyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és a tartalomjelölés típusait. Mentse a bemutatót a változások rögzítéséhez.

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

## **Érzékenységi címke megjelölése eltávolítottként**

Az eltávolított címke állapotának megőrzéséhez keresse meg a címkét, és hívja meg az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metódust `true` értékkel. Ez megőrzi a címke bejegyzését, miközben rögzíti az eltávolított állapotát. Ha ehelyett a modern gyűjteményből szeretne bejegyzést törölni, használja az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); az összes bejegyzés törléséhez alkalmazza az [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) metódust.

A következő példa egy konkrét címkét megjelöl eltávolítottként, majd elmenti a frissített bemutatót:

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

A régebbi MIP-alapú munkafolyamatok az érzékenységi címke metaadatokat az egyéni dokumentumtulajdonságokban tárolhatják a modern címkegyűjtemény helyett. Olvassa be ezeket a metaadatokat az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) segítségével. A metódus feldolgozza a régi egyéni tulajdonságokat, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/) objektumokból álló tömböt ad vissza.

A metaadatok migrálásához adja hozzá minden visszakapott címkét a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/)‑hez a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) metódussal. Mivel egy már létező címke azonosító hozzáadása kivételt okoz, a példa a célgyűjteményt ellenőrzi, mielőtt másolná a címkét. További ellenőrzést is beépíthet, hogy biztosítsa, a régi címke még létezik a jelenlegi Purview szabályzatban.

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

A migráció átmásolja a feldolgozott címkeobjektumokat a modern gyűjteménybe. Nem szükséges az összes egyéni dokumentumtulajdonságot törölni, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) paraméterrel a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**A tartalomjelölés típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz létre a diákon?**

Nem. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listához hozzáadott értékek leírják a címkéhez kapcsolódó jelöléseket. Ezek nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket, külön kell hozzáadni a megfelelő diatartalmat.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**

Az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) `true` értékkel történő hívása megtartja a címke bejegyzését, és rögzíti eltávolított állapotát. Az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) hívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadat-megőrzési követelményeinek.

**Tartalmazhat egy bemutató egyszerre régi MIP metaadatokat és modern érzékenységi címkéket?**

Igen. A régi címkék megmaradhatnak az egyéni dokumentumtulajdonságokban, míg a modern címkék a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével érhetők el. Használja az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódust a régi metaadatok olvasásához, és csak azokat a váltható címkéket migrálja, amelyek még nincsenek jelen a modern gyűjteményben.

**Mi történik, ha ugyanazzal az azonosítóval rendelkező címkét többször adjuk hozzá?**

A [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kivételt dob, ha a gyűjtemény már tartalmaz ugyanazzal az azonosítóval rendelkező címkét. Ellenőrizze a meglévő értékeket a [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getId--) által visszaadott lista alapján, mielőtt címkéket adna hozzá vagy migrálna.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a bemutatót PPTX formátumban az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódus [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) paraméterrel való meghívásával, ahogyan a fenti példákban látható.