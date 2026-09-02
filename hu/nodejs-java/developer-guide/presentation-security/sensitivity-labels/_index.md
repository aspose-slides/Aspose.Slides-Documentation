---
title: Érzékenységi címkék kezelése PowerPoint prezentációkban JavaScript-ben
linktitle: Érzékenységi címkék
type: docs
weight: 50
url: /hu/nodejs-java/sensitivity-labels/
keywords:
- érzékenységi címke
- Microsoft Purview
- Microsoft Information Protection
- MIP metaadat
- tartalomjelzés
- információvédelem
- dokumentumirányítás
- PowerPoint
- PPTX
- prezentációbiztonság
- Node.js
- JavaScript
- Aspose.Slides
description: "Olvassa, adja hozzá, frissítse, távolítsa el és migrálja a Microsoft Purview érzékenységi címkéket PowerPoint PPTX prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Microsoft Purview érzékenységi címkék segítik a szervezeteket a dokumentumok osztályozásában és irányításában. Az automatikus prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, egy házirend által kiválasztott címkét kell alkalmaznia, frissítenie kell annak állapotát, vagy át kell migrálnia egy régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatot.

Aspose.Slides for Node.js via Java modern érzékenységi címke metaadatokat tesz elérhetővé a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) segítségével. Ez a metódus egy [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/) példányt ad vissza, amelyet megvizsgálhat és módosíthat a prezentáció PPTX formátumba mentése előtt.

{{% alert color="primary" title="Note" %}}

Az érzékenységi címke azonosítókat és a házirend információkat a Microsoft Purview konfigurációja határozza meg. Ellenőrizze a címkék elérhetőségét és a házirendi követelményeket a környezetben, mielőtt metaadatokat adna hozzá vagy migrálná őket. A [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) értékek leírják a címkéhez kapcsolódó tartalom jelzéseket; önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.

{{% /alert %}}

## **Az érzékenységi címke tulajdonságainak megértése**

Minden [SensitivityLabel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/) a következő metaadatokkal rendelkezik:

| Metódusok | Leírás |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getId) és [SensitivityLabel.setId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Az érzékenységi címke azonosítójának lekérése vagy beállítása a Purview házirendben. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) és [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | A címke házirendhez kapcsolódó hely (site) lekérése vagy beállítása. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) és [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Annak lekérése vagy beállítása, hogy a címke engedélyezve van-e. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) és [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Annak lekérése vagy beállítása, hogy a címke el lett-e távolítva. Állítsa a értéket `true`‑ra, ha a eltávolítási állapotot metaadatként meg kell őrizni. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) és [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Annak lekérése vagy beállítása, hogy a címkét automatikusan vagy felhasználói döntés alapján alkalmazták-e. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | A címkéhez kapcsolódó tartalomjelzés típusok lekérése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) osztály meghatározza, hogyan lett a címke hozzárendelve:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) alapértelmezett vagy automatikusan alkalmazott címkét jelöl.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a manuálisan alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) osztály definiálja a címkéhez tartozó jelzést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | A címke alapértelmezés szerint vagy automatikusan lett alkalmazva. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Fejléc tartalomjelzés van a címkéhez rendelve. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Lábléc tartalomjelzés van a címkéhez rendelve. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalomjelzés van a címkéhez rendelve. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem van a címkéhez rendelve. |

Több jelzés típus is társítható egy címkéhez.

## **Meglévő érzékenységi címkék listázása**

Olvassa be a modern címkegyűjteményt a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) segítségével, és enumerálja. Az alábbi példa minden tulajdonságot és a címkékhez tárolt tartalomjelzést listáz:

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

## **Érzékenységi címke hozzáadása tartalomjelzéssel**

Használja a [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) metódust a címkeazonosítóval, helyazonosítóval, engedélyezett állapottal és hozzárendelési módszerrel. A metódus visszatér az új [SensitivityLabel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/) példánnyal, amelyhez a szükséges jelzésértékeket a [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listán keresztül adhatja hozzá.

Az alábbi példa egy manuálisan kiválasztott címkét ad hozzá, amely lábléc és vízjel jelzésekkel van társítva, majd a végeredményt PPTX formátumban menti:

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

## **Érzékenységi címke frissítése**

A [SensitivityLabel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/) értékek olvashatók/írhatók, kivéve a [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listát, amelyet a lista műveletein keresztül módosíthat. A szükséges címke megtalálása után frissítheti annak azonosítóját, helyazonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és tartalomjelzés típusait. Mentse a prezentációt a változtatások alkalmazásához.

Az alábbi példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

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

## **Címke megjelölése eltávolítottnak**

A címke eltávolításának megőrzéséhez találja meg a címkét, és hívja meg a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) metódust `true` értékkel. Ez megőrzi a címke bejegyzését, miközben rögzíti az eltávolított állapotát. Ha a modern gyűjteményből bejegyzést szeretne ténylegesen törölni, használja a [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) metódust; minden bejegyzés törléséhez használja a [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) metódust.

Az alábbi példa egy adott címkét megjelöl eltávolítottnak, majd elmenti a frissített prezentációt:

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

## **Örökölt MIP érzékenységi címkék olvasása és migrálása**

A régebbi MIP-alapú munkafolyamatok érzékenységi címke metaadatokat tárolhatnak egyedi dokumentumtulajdonságokban a modern címkegyűjtemény helyett. Olvassa be ezeket a metaadatokat a [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) segítségével. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy [SensitivityLabel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/) objektumok tömbjét adja vissza.

A metaadatok migrálásához adja hozzá a visszaadott címkéket a modern [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/) gyűjteményhez a [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) metódussal. Mivel egy már meglévő címkeazonosító hozzáadása kivételt eredményez, a példa a célgyűjteményt ellenőrzi a másolás előtt. További ellenőrzéseket is beépíthet, hogy megerősítse, minden örökölt címke továbbra is létezik a aktuális Purview házirendben.

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

A migráció a feldolgozott címkeobjektumokat a modern gyűjteménybe helyezi. Nem igényli az összes egyedi dokumentumtulajdonság törlését, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentummal a modern címke metaadatok PPTX fájlba írásához.

## **GYIK**

**Létrehozza-e egy tartalomjelzés típus hozzáadása látható fejlécet, láblécet vagy vízjelet a diákon?**

Nem. A [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott lista által hozzáadott értékek leírják a címkéhez kapcsolódó jelzéseket. Nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Amennyiben a munkafolyamatnak meg kell jelenítenie ezeket a jelzéseket, a megfelelő diatartalmat külön kell hozzáadni.

**Mi a különbség egy címke eltávolítottnak jelölése és a gyűjteményből való törlése között?**

A [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) `true` értékkel történő meghívása megtartja a címke bejegyzését, és rögzíti az eltávolított állapotát. A [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) hívása eltávolítja a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel a szervezete metaadat‑megőrzési követelményeinek.

**Tartalmazhat‑e egy prezentáció egyszerre örökölt MIP metaadatokat és modern érzékenységi címkéket?**

Igen. Az örökölt címkék maradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék a [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) segítségével érhetők el. Használja a [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) metódust az örökölt metaadatok olvasásához, és csak azokat a címkéket migrálja, amelyek már nem szerepelnek a modern gyűjteményben.

**Mi történik, ha ugyanazzal az azonosítóval rendelkező címkét többször adnak hozzá?**

A [SensitivityLabelCollection.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) kivételt dob, ha a gyűjtemény már tartalmaz ilyen azonosítóval rendelkező címkét. Ellenőrizze a [SensitivityLabel.getId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sensitivitylabel/#getId) által visszaadott meglévő értékeket a címkék hozzáadása vagy migrálása előtt.

**Melyik kimeneti formátumot kell használni a frissített érzékenységi címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódus hívásával, a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentummal, ahogyan a fenti példákban látható.