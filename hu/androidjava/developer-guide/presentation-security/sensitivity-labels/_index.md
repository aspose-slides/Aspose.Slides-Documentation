---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban Androidon
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/androidjava/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadat
- tartalomjelzés
- információvédelem
- dokumentumkezelés
- PowerPoint
- PPTX
- prezentációbiztonság
- Android
- Java
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

A Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és kezelésében. Az automatikus prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, alkalmaznia kell egy szabály által kiválasztott címkét, frissítenie kell annak állapotát, vagy migrálnia kell a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatait.

Az Aspose.Slides for Android via Java a modern érzékenységi címke metaadatokat a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- ) metóduson keresztül teszi elérhetővé. Ez a metódus egy [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/ ) objektumot ad vissza, amelyet a prezentáció PPTX formátumba mentése előtt ellenőrizhet és módosíthat.

{{% alert color="primary" title="Note" %}}
Az érzékenységi címke azonosítókat és a szabályi információkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a szabályi követelményeket a környezetben, mielőtt metaadatokat adna hozzá vagy migrálná őket. Az [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) értékek leírják a címkéhez kapcsolódó tartalomjelzéseket; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Érzékenységi címke tulajdonságainak megértése**

Minden [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/ ) a következő metaadatokat tartalmazza:

| Módszerek | Cél |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getId--) és [ISensitivityLabel.setId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | A Purview szabályban szereplő érzékenységi címke azonosítójának lekérdezése vagy beállítása. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) és [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | A címke szabállyal kapcsolatos webhely lekérdezése vagy beállítása. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) és [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | A címke engedélyezett állapotának lekérdezése vagy beállítása. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) és [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | A címke eltávolított állapotának lekérdezése vagy beállítása. Állítsa `true`-ra, ha a metaadatokban meg kell tartani az eltávolítási állapotot. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) és [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | A címke automatikus vagy felhasználói döntés alapján történő alkalmazásának lekérdezése vagy beállítása. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | A címkéhez kapcsolódó tartalomjelzés típusainak lekérdezése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) osztály meghatározza, hogyan lett a címke hozzárendelve:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/ ) felhasználói döntés útján alkalmazott címkét jelöl, beleértve a manuálisan alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) osztály határozza meg a címkéhez tartozó jelzést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | A címke alapértelmezetten vagy automatikusan lett alkalmazva. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | A fejléc tartalomjelzés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | Az élőláb tartalomjelzés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | A vízjel tartalomjelzés kapcsolódik a címkéhez. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sensitivitylabelcontenttype/ ) | A címkéhez titkosítási védelem kapcsolódik. |

Több jelzéstípus is kapcsolódhat egy címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címkegyűjteményt a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels-- ) metódusból, és járja végig. Az alábbi példa minden tulajdonságot és tartalomjelzést felsorol minden címkéhez:

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

## **Érzékenységi címke hozzáadása tartalomjelzéssel**

Használja a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) metódust a címke azonosítóval, a helyazonosítóval, az engedélyezett állapottal és az hozzárendelési móddal. A metódus visszaadja az új [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/ ) objektumot, amelyhez adja hozzá a szükséges jelzési értékeket a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listán keresztül.

Az alábbi példa manuálisan kiválasztott címkét ad hozzá, amelyhez az élőláb és a vízjel jelzések kapcsolódnak, majd a végeredményt PPTX formátumban menti:

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

Az [ISensitivityLabel] értékek olvashatók/írhatók, kivéve a [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listát, amelyet listaműveletekkel módosíthat. A szükséges címke megtalálása után frissítheti annak azonosítóját, helyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és tartalomjelzési típusait. Mentse a prezentációt a módosítások mentéséhez.

Az alábbi példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

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

A címke eltávolításának ténye megőrzéséhez keresse meg a címkét, és hívja meg az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) metódust `true` értékkel. Ez megtartja a címke bejegyzését, miközben rögzíti az eltávolított állapotot. Ha helyette törölni kell egy bejegyzést a modern gyűjteményből, használja az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) metódust; az összes bejegyzés törléséhez használja az [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) metódust.

Az alábbi példa egy adott címkét megjelöl eltávolítottként, és menti a frissített prezentációt:

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

## **Legacy MIP érzékenységi címkék olvasása és migrálása**

A régebbi MIP-alapú munkafolyamatok a modern címkegyűjtemény helyett saját dokumentumtulajdonságokban tárolhatják az érzékenységi címke metaadatait. Olvassa be ezeket a metaadatokat az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódussal. A metódus az örökölt egyedi tulajdonságokat elemzi, és egy [ISensitivityLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá az egyes visszakapott címkéket a modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/) gyűjteményhez a [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) segítségével. Mivel egy duplikált címkeazonosító hozzáadása kivételt vált ki, a példa a másolás előtt ellenőrzi a célgyűjteményt. További ellenőrzést adhat hozzá, hogy megerősítse, minden örökölt címke még létezik-e a jelenlegi Purview szabályban.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe másolja. Nem szükséges az összes egyedi dokumentumtulajdonság törlése, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) formátummal a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**Létrehoz-e a tartalomjelzés típusának hozzáadása látható fejlécet, láblécet vagy vízjelet a diákon?**

Nem. A [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) által visszaadott listához hozzáadott értékek leírják a címkéhez kapcsolódó jelzéseket. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. A megfelelő diákatartalmat külön kell hozzáadni, ha a munkafolyamatnak meg kell jelenítenie ezeket a jelzéseket.

**Mi a különbség a címke eltávolítottként való megjelölése és a gyűjteményből való törlése között?**

Az [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) `true` értékkel való meghívása megtartja a címke bejegyzését és rögzíti az eltávolított állapotát. Az [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) meghívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezet metaadat-tartási követelményeinek.

**Lehet egy prezentációban egyszerre legacy MIP metaadat és modern érzékenységi címke?**

Igen. A régi címkék maradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék a [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) segítségével érhetők el. Használja az [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) metódust a régi metaadatok beolvasásához, és migrálja csak azokat a címkéket, amelyek még nem vannak jelen a modern gyűjteményben.

**Mi történik, ha ugyanazzal az azonosítóval rendelkező címkét többször adjuk hozzá?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kivételt dob, ha a gyűjtemény már tartalmazza ugyanazzal az azonosítóval a címkét. Ellenőrizze a [ISensitivityLabel.getId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isensitivitylabel/#getId--) által visszaadott meglévő értékeket a címkék hozzáadása vagy migrálása előtt.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódus [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) paraméterével, ahogyan a fenti példákban látható.